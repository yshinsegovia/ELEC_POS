
Imports MySqlConnector
Imports System.Data

Public Class ReportService

    '==================================================
    ' 1. ALL TRANSACTIONS REPORT
    '==================================================
    Public Function GetTransactionList() As DataTable

        Dim query As String =
            "SELECT " &
            "t.transaction_id AS `Transaction ID`, " &
            "t.student_id AS `Student ID`, " &
            "CONCAT_WS(' ', s.firstname, s.lastname) AS `Student Name`, " &
            "u.username AS `Cashier`, " &
            "t.total_amount AS `Total`, " &
            "t.payment_method AS `Payment Method`, " &
            "t.order_status AS `Status`, " &
            "t.transaction_date AS `Date` " &
            "FROM transactions t " &
            "LEFT JOIN user_reg s ON t.student_id = s.student_id " &
            "LEFT JOIN user u ON t.cashier_id = u.user_id " &
            "ORDER BY t.transaction_date DESC"

        Return ExecuteReportQuery(query)

    End Function


    '==================================================
    ' 2. ALL COMPLETED SALES REPORT
    '==================================================
    Public Function GetSalesReport() As DataTable

        Dim query As String =
            "SELECT " &
            "t.transaction_id AS `Transaction ID`, " &
            "t.transaction_date AS `Date`, " &
            "t.total_amount AS `Sales`, " &
            "t.payment_method AS `Payment Method` " &
            "FROM transactions t " &
            "WHERE t.order_status = 'Completed' " &
            "ORDER BY t.transaction_date DESC"

        Return ExecuteReportQuery(query)

    End Function


    '==================================================
    ' 3. ALL COMPLETED ORDERS REPORT
    '==================================================
    Public Function GetCompletedOrderList() As DataTable

        Dim query As String =
            "SELECT " &
            "t.transaction_id AS `Transaction ID`, " &
            "t.student_id AS `Student ID`, " &
            "CONCAT_WS(' ', s.firstname, s.lastname) AS `Student Name`, " &
            "u.username AS `Cashier`, " &
            "t.total_amount AS `Total`, " &
            "t.payment_method AS `Payment Method`, " &
            "t.transaction_date AS `Date` " &
            "FROM transactions t " &
            "LEFT JOIN user_reg s ON t.student_id = s.student_id " &
            "LEFT JOIN user u ON t.cashier_id = u.user_id " &
            "WHERE t.order_status = 'Completed' " &
            "ORDER BY t.transaction_date DESC"

        Return ExecuteReportQuery(query)

    End Function


    '==================================================
    ' 4. PRODUCT SALES REPORT
    '==================================================
    Public Function GetProductSales() As DataTable

        Dim query As String =
            "SELECT " &
            "COALESCE(s.item_name, 'Product no longer available') AS `Product`, " &
            "SUM(ti.quantity) AS `Quantity Sold`, " &
            "SUM(ti.subtotal) AS `Sales` " &
            "FROM transaction_items ti " &
            "INNER JOIN transactions t " &
            "ON ti.transaction_id = t.transaction_id " &
            "LEFT JOIN stocks s ON ti.stock_id = s.stock_id " &
            "WHERE t.order_status = 'Completed' " &
            "GROUP BY ti.stock_id, s.item_name " &
            "ORDER BY SUM(ti.quantity) DESC"

        Return ExecuteReportQuery(query)

    End Function


    '==================================================
    ' 5. TOTAL TRANSACTIONS CARD
    '==================================================
    Public Function GetTotalTransactions() As Integer

        Dim query As String =
            "SELECT COUNT(*) FROM transactions"

        Return ExecuteScalarInteger(query)

    End Function


    '==================================================
    ' 6. TOTAL SALES CARD
    '==================================================
    Public Function GetTotalSales() As Decimal

        Dim query As String =
            "SELECT COALESCE(SUM(total_amount), 0) " &
            "FROM transactions " &
            "WHERE order_status = 'Completed'"

        Return ExecuteScalarDecimal(query)

    End Function


    '==================================================
    ' 7. COMPLETED ORDERS CARD
    '==================================================
    Public Function GetTotalCompletedOrders() As Integer

        Dim query As String =
            "SELECT COUNT(*) FROM transactions " &
            "WHERE order_status = 'Completed'"

        Return ExecuteScalarInteger(query)

    End Function


    '==================================================
    ' 8. PRODUCT SALES CARD
    ' Total quantity sold in completed transactions.
    '==================================================
    Public Function GetTotalProductSales() As Integer

        Dim query As String =
            "SELECT COALESCE(SUM(ti.quantity), 0) " &
            "FROM transaction_items ti " &
            "INNER JOIN transactions t " &
            "ON ti.transaction_id = t.transaction_id " &
            "WHERE t.order_status = 'Completed'"

        Return ExecuteScalarInteger(query)

    End Function


    '==================================================
    ' SHARED DATATABLE QUERY
    '==================================================
    Private Function ExecuteReportQuery(
        query As String
    ) As DataTable

        Dim table As New DataTable()

        Using conn As MySqlConnection = GetConnection()

            Using cmd As New MySqlCommand(query, conn)

                Using adapter As New MySqlDataAdapter(cmd)

                    adapter.Fill(table)

                End Using

            End Using

        End Using

        Return table

    End Function


    '==================================================
    ' SHARED INTEGER QUERY
    '==================================================
    Private Function ExecuteScalarInteger(
        query As String
    ) As Integer

        Using conn As MySqlConnection = GetConnection()

            Using cmd As New MySqlCommand(query, conn)

                conn.Open()

                Return Convert.ToInt32(cmd.ExecuteScalar())

            End Using

        End Using

    End Function


    '==================================================
    ' SHARED DECIMAL QUERY
    '==================================================
    Private Function ExecuteScalarDecimal(
        query As String
    ) As Decimal

        Using conn As MySqlConnection = GetConnection()

            Using cmd As New MySqlCommand(query, conn)

                conn.Open()

                Return Convert.ToDecimal(cmd.ExecuteScalar())

            End Using

        End Using

    End Function

End Class
