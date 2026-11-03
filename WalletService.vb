
Imports MySqlConnector
Imports System
Imports System.Data

Public Class WalletService

    ' Get the current wallet balance of a student.
    Public Function GetWalletBalance(studentId As String) As Decimal

        If String.IsNullOrWhiteSpace(studentId) Then
            Throw New ArgumentException("Student ID is required.")
        End If

        Using conn As MySqlConnection = database.GetConnection()
            conn.Open()

            Const sql As String =
                "SELECT balance " &
                "FROM student_wallets " &
                "WHERE student_id = @studentId;"

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@studentId", studentId.Trim())

                Dim result As Object = cmd.ExecuteScalar()

                If result Is Nothing OrElse result Is DBNull.Value Then
                    Throw New Exception(
                        "No wallet was found for this student. Please check the student ID."
                    )
                End If

                Return Convert.ToDecimal(result)
            End Using
        End Using

    End Function


    ' Submit a wallet-load request for admin approval.
    ' This method DOES NOT change the student's balance.
    Public Function LoadWallet(
        studentId As String,
        cashierId As Integer,
        amount As Decimal
    ) As Decimal

        RequestWalletLoad(studentId, cashierId, amount)

        ' Return the requested amount, not the wallet balance.
        Return amount

    End Function


    ' Create a pending wallet-load request.
    ' Returns the new request ID.
    Public Function RequestWalletLoad(
        studentId As String,
        cashierId As Integer,
        amount As Decimal
    ) As Integer

        If String.IsNullOrWhiteSpace(studentId) Then
            Throw New ArgumentException("Student ID is required.")
        End If

        If cashierId <= 0 Then
            Throw New ArgumentException("A valid cashier ID is required.")
        End If

        If amount < 50D Then
            Throw New ArgumentException(
                "The minimum wallet load is ₱50.00."
            )
        End If

        If amount > 99999999.99D Then
            Throw New ArgumentException("The wallet load amount is too large.")
        End If

        Using conn As MySqlConnection = database.GetConnection()
            conn.Open()

            Using trans As MySqlTransaction = conn.BeginTransaction()

                Try
                    ' Check that the student's wallet exists.
                    Const walletSql As String =
                        "SELECT COUNT(*) " &
                        "FROM student_wallets " &
                        "WHERE student_id = @studentId;"

                    Using cmd As New MySqlCommand(walletSql, conn, trans)
                        cmd.Parameters.AddWithValue(
                            "@studentId", studentId.Trim()
                        )

                        If Convert.ToInt32(cmd.ExecuteScalar()) = 0 Then
                            Throw New Exception(
                                "No wallet was found for this student."
                            )
                        End If
                    End Using

                    ' Verify that the account is a cashier.
                    Const cashierSql As String =
                        "SELECT COUNT(*) " &
                        "FROM `user` " &
                        "WHERE user_id = @cashierId " &
                        "AND LOWER(role) = 'cashier';"

                    Using cmd As New MySqlCommand(cashierSql, conn, trans)
                        cmd.Parameters.AddWithValue("@cashierId", cashierId)

                        If Convert.ToInt32(cmd.ExecuteScalar()) = 0 Then
                            Throw New Exception("Invalid cashier account.")
                        End If
                    End Using

                    ' Save the request as Pending.
                    Const insertSql As String =
                        "INSERT INTO wallet_load_requests " &
                        "(student_id, cashier_id, amount, status) " &
                        "VALUES (@studentId, @cashierId, @amount, 'Pending');"

                    Dim requestId As Integer

                    Using cmd As New MySqlCommand(insertSql, conn, trans)
                        cmd.Parameters.AddWithValue(
                            "@studentId", studentId.Trim()
                        )
                        cmd.Parameters.AddWithValue("@cashierId", cashierId)
                        cmd.Parameters.AddWithValue("@amount", amount)

                        cmd.ExecuteNonQuery()
                        requestId = Convert.ToInt32(cmd.LastInsertedId)
                    End Using

                    trans.Commit()

                    Return requestId

                Catch
                    Try
                        trans.Rollback()
                    Catch
                        ' Preserve the original error.
                    End Try

                    Throw
                End Try

            End Using
        End Using

    End Function


    ' Get all wallet-load requests awaiting admin approval.
    Public Function GetPendingWalletLoads() As DataTable

        Dim table As New DataTable()

        Const sql As String =
            "SELECT " &
            "r.request_id AS `Request ID`, " &
            "r.student_id AS `Student ID`, " &
            "CONCAT(s.firstname, ' ', s.lastname) AS `Student Name`, " &
            "r.amount AS `Amount`, " &
            "u.username AS `Cashier`, " &
            "r.requested_at AS `Requested At`, " &
            "r.status AS `Status` " &
            "FROM wallet_load_requests r " &
            "INNER JOIN user_reg s ON r.student_id = s.student_id " &
            "INNER JOIN `user` u ON r.cashier_id = u.user_id " &
            "WHERE r.status = 'Pending' " &
            "ORDER BY r.requested_at ASC;"

        Using conn As MySqlConnection = database.GetConnection()
            Using cmd As New MySqlCommand(sql, conn)
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(table)
                End Using
            End Using
        End Using

        Return table

    End Function


    ' Approve a pending request.
    ' The wallet balance and transaction history are updated together.
    Public Sub ApproveWalletLoad(
        requestId As Integer,
        adminId As Integer
    )

        If requestId <= 0 Then
            Throw New ArgumentException("Invalid request ID.")
        End If

        If adminId <= 0 Then
            Throw New ArgumentException("Invalid admin ID.")
        End If

        Using conn As MySqlConnection = database.GetConnection()
            conn.Open()

            Using trans As MySqlTransaction = conn.BeginTransaction()

                Try
                    ' Confirm the reviewing account is an admin.
                    Const adminSql As String =
                        "SELECT COUNT(*) " &
                        "FROM `user` " &
                        "WHERE user_id = @adminId " &
                        "AND LOWER(role) = 'admin';"

                    Using cmd As New MySqlCommand(adminSql, conn, trans)
                        cmd.Parameters.AddWithValue("@adminId", adminId)

                        If Convert.ToInt32(cmd.ExecuteScalar()) = 0 Then
                            Throw New Exception(
                                "Only an admin can approve wallet loads."
                            )
                        End If
                    End Using

                    Dim studentId As String = ""
                    Dim cashierId As Integer
                    Dim amount As Decimal

                    ' Lock the request so it cannot be approved twice.
                    Const requestSql As String =
                        "SELECT student_id, cashier_id, amount " &
                        "FROM wallet_load_requests " &
                        "WHERE request_id = @requestId " &
                        "AND status = 'Pending' " &
                        "FOR UPDATE;"

                    Using cmd As New MySqlCommand(requestSql, conn, trans)
                        cmd.Parameters.AddWithValue("@requestId", requestId)

                        Using reader As MySqlDataReader = cmd.ExecuteReader()
                            If Not reader.Read() Then
                                Throw New Exception(
                                    "The request was not found or is no longer pending."
                                )
                            End If

                            studentId = reader("student_id").ToString()
                            cashierId = Convert.ToInt32(reader("cashier_id"))
                            amount = Convert.ToDecimal(reader("amount"))
                        End Using
                    End Using

                    If amount < 50D OrElse amount > 99999999.99D Then
                        Throw New Exception("The requested amount is invalid.")
                    End If

                    Dim balanceBefore As Decimal

                    ' Lock the student's wallet.
                    Const lockSql As String =
                        "SELECT balance " &
                        "FROM student_wallets " &
                        "WHERE student_id = @studentId " &
                        "FOR UPDATE;"

                    Using cmd As New MySqlCommand(lockSql, conn, trans)
                        cmd.Parameters.AddWithValue("@studentId", studentId)

                        Dim result As Object = cmd.ExecuteScalar()

                        If result Is Nothing OrElse result Is DBNull.Value Then
                            Throw New Exception("The student's wallet was not found.")
                        End If

                        balanceBefore = Convert.ToDecimal(result)
                    End Using

                    Dim balanceAfter As Decimal = balanceBefore + amount

                    If balanceAfter > 99999999.99D Then
                        Throw New Exception(
                            "The resulting wallet balance is too large."
                        )
                    End If

                    ' Add money only after admin approval.
                    Const updateSql As String =
                        "UPDATE student_wallets " &
                        "SET balance = @balance " &
                        "WHERE student_id = @studentId;"

                    Using cmd As New MySqlCommand(updateSql, conn, trans)
                        cmd.Parameters.AddWithValue("@balance", balanceAfter)
                        cmd.Parameters.AddWithValue("@studentId", studentId)

                        If cmd.ExecuteNonQuery() <> 1 Then
                            Throw New Exception("The wallet could not be updated.")
                        End If
                    End Using

                    ' Record the approved load in wallet history.
                    Const historySql As String =
                        "INSERT INTO wallet_transactions " &
                        "(student_id, cashier_id, transaction_id, " &
                        "transaction_type, amount, balance_before, " &
                        "balance_after, description) " &
                        "VALUES (@studentId, @cashierId, NULL, 'LOAD', " &
                        "@amount, @balanceBefore, @balanceAfter, @description);"

                    Using cmd As New MySqlCommand(historySql, conn, trans)
                        cmd.Parameters.AddWithValue("@studentId", studentId)
                        cmd.Parameters.AddWithValue("@cashierId", cashierId)
                        cmd.Parameters.AddWithValue("@amount", amount)
                        cmd.Parameters.AddWithValue("@balanceBefore", balanceBefore)
                        cmd.Parameters.AddWithValue("@balanceAfter", balanceAfter)
                        cmd.Parameters.AddWithValue(
                            "@description",
                            "Admin-approved wallet load #" & requestId
                        )

                        cmd.ExecuteNonQuery()
                    End Using

                    ' Mark the request as Approved.
                    Const approveSql As String =
                        "UPDATE wallet_load_requests " &
                        "SET status = 'Approved', " &
                        "reviewed_by = @adminId, " &
                        "reviewed_at = CURRENT_TIMESTAMP " &
                        "WHERE request_id = @requestId " &
                        "AND status = 'Pending';"

                    Using cmd As New MySqlCommand(approveSql, conn, trans)
                        cmd.Parameters.AddWithValue("@adminId", adminId)
                        cmd.Parameters.AddWithValue("@requestId", requestId)

                        If cmd.ExecuteNonQuery() <> 1 Then
                            Throw New Exception(
                                "The request status changed. Refresh and try again."
                            )
                        End If
                    End Using

                    trans.Commit()

                Catch
                    Try
                        trans.Rollback()
                    Catch
                        ' Preserve the original error.
                    End Try

                    Throw
                End Try

            End Using
        End Using

    End Sub


    ' Reject a pending request without changing the wallet balance.
    Public Sub RejectWalletLoad(
        requestId As Integer,
        adminId As Integer,
        reason As String
    )

        If requestId <= 0 OrElse adminId <= 0 Then
            Throw New ArgumentException("Invalid request or admin ID.")
        End If

        If String.IsNullOrWhiteSpace(reason) Then
            Throw New ArgumentException(
                "Please provide a reason for rejecting this request."
            )
        End If

        Using conn As MySqlConnection = database.GetConnection()
            conn.Open()

            Const sql As String =
                "UPDATE wallet_load_requests r " &
                "INNER JOIN `user` u ON u.user_id = @adminId " &
                "SET r.status = 'Rejected', " &
                "r.reviewed_by = @adminId, " &
                "r.reviewed_at = CURRENT_TIMESTAMP, " &
                "r.rejection_reason = @reason " &
                "WHERE r.request_id = @requestId " &
                "AND r.status = 'Pending' " &
                "AND LOWER(u.role) = 'admin';"

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@adminId", adminId)
                cmd.Parameters.AddWithValue("@reason", reason.Trim())
                cmd.Parameters.AddWithValue("@requestId", requestId)

                If cmd.ExecuteNonQuery() <> 1 Then
                    Throw New Exception(
                        "The request was not found, is no longer pending, " &
                        "or your account is not an admin."
                    )
                End If
            End Using
        End Using

    End Sub




    '========================================================
    ' GET WALLET LOAD REQUESTS BY STATUS
    '========================================================
    Public Function GetWalletLoadsByStatus(
    status As String
) As DataTable

        If status <> "Pending" AndAlso
       status <> "Approved" AndAlso
       status <> "Rejected" Then

            Throw New ArgumentException(
            "Invalid wallet request status."
        )

        End If

        Dim dt As New DataTable()

        Using conn As MySqlConnection = database.GetConnection()

            conn.Open()

            Const sql As String =
            "SELECT " &
            "w.request_id, " &
            "w.student_id, " &
            "r.firstname, " &
            "r.lastname, " &
            "w.amount, " &
            "u.username AS cashier_username, " &
            "w.requested_at, " &
            "w.status " &
            "FROM wallet_load_requests w " &
            "INNER JOIN user_reg r " &
            "ON w.student_id = r.student_id " &
            "INNER JOIN `user` u " &
            "ON w.cashier_id = u.user_id " &
            "WHERE w.status = @status " &
            "ORDER BY w.requested_at DESC;"

            Using cmd As New MySqlCommand(sql, conn)

                cmd.Parameters.AddWithValue("@status", status)

                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using

            End Using

        End Using

        Return dt

    End Function


End Class
