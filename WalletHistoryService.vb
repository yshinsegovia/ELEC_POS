
Imports MySqlConnector
Imports System.Data

Public Class WalletHistoryService

    Public Function GetWalletHistory(studentId As String) As DataTable

        If String.IsNullOrWhiteSpace(studentId) Then
            Throw New ArgumentException("Student ID is required.")
        End If

        Dim history As New DataTable()

        Const sql As String =
            "SELECT " &
            "wt.wallet_transaction_id AS 'History ID', " &
            "wt.transaction_type AS 'Transaction Type', " &
            "wt.amount AS 'Amount', " &
            "wt.balance_before AS 'Balance Before', " &
            "wt.balance_after AS 'Balance After', " &
            "wt.description AS 'Description', " &
            "wt.created_at AS 'Date', " &
            "u.username AS 'Cashier' " &
            "FROM wallet_transactions wt " &
            "LEFT JOIN user u ON wt.cashier_id = u.user_id " &
            "WHERE wt.student_id = @studentId " &
            "ORDER BY wt.created_at DESC, " &
            "wt.wallet_transaction_id DESC;"

        Using conn As MySqlConnection = database.GetConnection()
            conn.Open()

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@studentId", studentId.Trim())

                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(history)
                End Using
            End Using
        End Using

        Return history

    End Function

End Class
