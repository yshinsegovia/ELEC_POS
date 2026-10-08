
Imports MySqlConnector
Imports System.Data

Public Class CashierHistoryService

    '========================================================
    ' GET COMPLETED TRANSACTION HISTORY
    '========================================================
    Public Function GetHistory(
        searchText As String
    ) As DataTable

        Dim table As New DataTable()

        Using conn As MySqlConnection = GetConnection()

            conn.Open()

            Dim query As String =
                "SELECT " &
                "t.transaction_id AS transaction_id, " &
                "t.student_id AS student_id, " &
                "CONCAT(ur.firstname, ' ', ur.lastname) AS student_name, " &
                "t.total_amount AS total_amount, " &
                "t.transaction_date AS transaction_date, " &
                "t.payment_method AS payment_method, " &
                "t.order_status AS order_status, " &
                "u.username AS cashier " &
                "FROM transactions t " &
                "INNER JOIN user_reg ur " &
                "ON t.student_id = ur.student_id " &
                "INNER JOIN `user` u " &
                "ON t.cashier_id = u.user_id " &
                "WHERE t.order_status = 'Completed' " &
                "AND (" &
                "CAST(t.transaction_id AS CHAR) LIKE @search " &
                "OR t.student_id LIKE @search " &
                "OR CONCAT(ur.firstname, ' ', ur.lastname) LIKE @search" &
                ") " &
                "ORDER BY t.transaction_date DESC"

            Using cmd As New MySqlCommand(query, conn)

                cmd.Parameters.AddWithValue(
                    "@search",
                    "%" & searchText & "%"
                )

                Using adapter As New MySqlDataAdapter(cmd)

                    adapter.Fill(table)

                End Using

            End Using

        End Using

        Return table

    End Function


    '========================================================
    ' GET ONE COMPLETED TRANSACTION
    '========================================================
    Public Function GetHistoryInfo(
        transactionID As Integer
    ) As DataTable

        Dim table As New DataTable()

        Using conn As MySqlConnection = GetConnection()

            conn.Open()

            Dim query As String =
                "SELECT " &
                "t.transaction_id, " &
                "t.student_id, " &
                "CONCAT(ur.firstname, ' ', ur.lastname) AS student_name, " &
                "u.username AS cashier, " &
                "t.transaction_date, " &
                "t.payment_method, " &
                "t.order_status, " &
                "t.total_amount " &
                "FROM transactions t " &
                "INNER JOIN user_reg ur " &
                "ON t.student_id = ur.student_id " &
                "INNER JOIN `user` u " &
                "ON t.cashier_id = u.user_id " &
                "WHERE t.transaction_id = @transactionID " &
                "AND t.order_status = 'Completed' " &
                "LIMIT 1"

            Using cmd As New MySqlCommand(query, conn)

                cmd.Parameters.AddWithValue(
                    "@transactionID",
                    transactionID
                )

                Using adapter As New MySqlDataAdapter(cmd)

                    adapter.Fill(table)

                End Using

            End Using

        End Using

        Return table

    End Function


    '========================================================
    ' GET PRODUCTS FROM ONE TRANSACTION
    '========================================================
    Public Function GetHistoryDetails(
        transactionID As Integer
    ) As DataTable

        Dim table As New DataTable()

        Using conn As MySqlConnection = GetConnection()

            conn.Open()

            Dim query As String =
                "SELECT " &
                "s.item_name AS Product, " &
                "ti.quantity AS Qty, " &
                "ti.price AS Price, " &
                "ti.subtotal AS Subtotal " &
                "FROM transaction_items ti " &
                "INNER JOIN stocks s " &
                "ON ti.stock_id = s.stock_id " &
                "WHERE ti.transaction_id = @transactionID " &
                "ORDER BY ti.transaction_item_id ASC"

            Using cmd As New MySqlCommand(query, conn)

                cmd.Parameters.AddWithValue(
                    "@transactionID",
                    transactionID
                )

                Using adapter As New MySqlDataAdapter(cmd)

                    adapter.Fill(table)

                End Using

            End Using

        End Using

        Return table

    End Function

End Class
