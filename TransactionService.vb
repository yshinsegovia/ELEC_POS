
Imports MySqlConnector
Imports System.Data

Public Class TransactionService

    '========================================================
    ' GET ALL TRANSACTIONS
    '========================================================
    Public Function GetTransactions() As DataTable

        Dim table As New DataTable()

        Using conn As MySqlConnection = GetConnection()

            conn.Open()

            Dim query As String =
                "SELECT " &
                "t.transaction_id, " &
                "t.student_id, " &
                "u.username AS cashier, " &
                "t.transaction_date, " &
                "t.total_amount, " &
                "t.payment_method " &
                "FROM transactions t " &
                "LEFT JOIN `user` u " &
                "ON t.cashier_id = u.user_id " &
                "ORDER BY t.transaction_date DESC"

            Using cmd As New MySqlCommand(query, conn)

                Using adapter As New MySqlDataAdapter(cmd)

                    adapter.Fill(table)

                End Using

            End Using

        End Using

        Return table

    End Function


    '========================================================
    ' GET TRANSACTIONS FOR TODAY
    '========================================================
    Public Function GetTodayTransactions() As DataTable

        Dim query As String =
            "SELECT " &
            "t.transaction_id, " &
            "t.student_id, " &
            "u.username AS cashier, " &
            "t.transaction_date, " &
            "t.total_amount, " &
            "t.payment_method " &
            "FROM transactions t " &
            "LEFT JOIN `user` u " &
            "ON t.cashier_id = u.user_id " &
            "WHERE DATE(t.transaction_date) = CURDATE() " &
            "ORDER BY t.transaction_date DESC"

        Return ExecuteTransactionQuery(query)

    End Function


    '========================================================
    ' GET TRANSACTIONS FOR THIS WEEK
    '========================================================
    Public Function GetThisWeekTransactions() As DataTable

        Dim query As String =
            "SELECT " &
            "t.transaction_id, " &
            "t.student_id, " &
            "u.username AS cashier, " &
            "t.transaction_date, " &
            "t.total_amount, " &
            "t.payment_method " &
            "FROM transactions t " &
            "LEFT JOIN `user` u " &
            "ON t.cashier_id = u.user_id " &
            "WHERE YEARWEEK(t.transaction_date, 1) = " &
            "YEARWEEK(CURDATE(), 1) " &
            "ORDER BY t.transaction_date DESC"

        Return ExecuteTransactionQuery(query)

    End Function


    '========================================================
    ' GET TRANSACTIONS FOR THIS MONTH
    '========================================================
    Public Function GetThisMonthTransactions() As DataTable

        Dim query As String =
            "SELECT " &
            "t.transaction_id, " &
            "t.student_id, " &
            "u.username AS cashier, " &
            "t.transaction_date, " &
            "t.total_amount, " &
            "t.payment_method " &
            "FROM transactions t " &
            "LEFT JOIN `user` u " &
            "ON t.cashier_id = u.user_id " &
            "WHERE YEAR(t.transaction_date) = YEAR(CURDATE()) " &
            "AND MONTH(t.transaction_date) = MONTH(CURDATE()) " &
            "ORDER BY t.transaction_date DESC"

        Return ExecuteTransactionQuery(query)

    End Function


    '========================================================
    ' SEARCH TRANSACTIONS
    '========================================================
    Public Function SearchTransactions(
        searchText As String
    ) As DataTable

        Dim table As New DataTable()

        Using conn As MySqlConnection = GetConnection()

            conn.Open()

            Dim query As String =
                "SELECT " &
                "t.transaction_id, " &
                "t.student_id, " &
                "u.username AS cashier, " &
                "t.transaction_date, " &
                "t.total_amount, " &
                "t.payment_method " &
                "FROM transactions t " &
                "LEFT JOIN `user` u " &
                "ON t.cashier_id = u.user_id " &
                "WHERE CAST(t.transaction_id AS CHAR) LIKE @search " &
                "OR t.student_id LIKE @search " &
                "OR u.username LIKE @search " &
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
    ' GET TRANSACTION DETAILS
    '========================================================
    Public Function GetTransactionDetails(
        transactionID As Integer
    ) As DataTable

        Dim table As New DataTable()

        Using conn As MySqlConnection = GetConnection()

            conn.Open()

            Dim query As String =
                "SELECT " &
                "s.item_name AS Product, " &
                "ti.quantity AS Quantity, " &
                "ti.price AS Price, " &
                "ti.subtotal AS Subtotal " &
                "FROM transaction_items ti " &
                "INNER JOIN stocks s " &
                "ON ti.stock_id = s.stock_id " &
                "WHERE ti.transaction_id = @transactionID " &
                "ORDER BY ti.transaction_item_id"

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
    ' GET TRANSACTION INFORMATION
    '========================================================
    Public Function GetTransactionInfo(
        transactionID As Integer
    ) As DataTable

        Dim table As New DataTable()

        Using conn As MySqlConnection = GetConnection()

            conn.Open()

            Dim query As String =
                "SELECT " &
                "t.transaction_id, " &
                "t.student_id, " &
                "u.username AS cashier, " &
                "t.transaction_date, " &
                "t.total_amount, " &
                "t.payment_method " &
                "FROM transactions t " &
                "LEFT JOIN `user` u " &
                "ON t.cashier_id = u.user_id " &
                "WHERE t.transaction_id = @transactionID"

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
    ' TOTAL TRANSACTIONS
    '========================================================
    Public Function GetTotalTransactions() As Integer

        Using conn As MySqlConnection = GetConnection()

            conn.Open()

            Dim query As String =
                "SELECT COUNT(*) FROM transactions"

            Using cmd As New MySqlCommand(query, conn)

                Return Convert.ToInt32(
                    cmd.ExecuteScalar()
                )

            End Using

        End Using

    End Function


    '========================================================
    ' TOTAL SALES
    '========================================================
    Public Function GetTotalSales() As Decimal

        Using conn As MySqlConnection = GetConnection()

            conn.Open()

            Dim query As String =
                "SELECT COALESCE(SUM(total_amount), 0) " &
                "FROM transactions"

            Using cmd As New MySqlCommand(query, conn)

                Return Convert.ToDecimal(
                    cmd.ExecuteScalar()
                )

            End Using

        End Using

    End Function


    '========================================================
    ' PRIVATE HELPER
    '========================================================
    Private Function ExecuteTransactionQuery(
        query As String
    ) As DataTable

        Dim table As New DataTable()

        Using conn As MySqlConnection = GetConnection()

            conn.Open()

            Using cmd As New MySqlCommand(query, conn)

                Using adapter As New MySqlDataAdapter(cmd)

                    adapter.Fill(table)

                End Using

            End Using

        End Using

        Return table

    End Function

End Class
