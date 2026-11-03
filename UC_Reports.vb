
Imports System.Data
Imports System.Windows.Forms

Public Class UC_Reports

    Private ReadOnly reportService As New ReportService()

    '==================================================
    ' FORM LOAD
    '==================================================
    Private Sub UC_Reports_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        SetupReportGrid()
        LoadReportCards()
        ShowTransactionsReport()

    End Sub


    '==================================================
    ' LOAD SUMMARY CARDS
    '==================================================
    Private Sub LoadReportCards()

        Try
            lblReportTotalTransaction.Text =
                reportService.GetTotalTransactions().ToString("N0")

            lblReportTotalSales.Text =
                "₱" & reportService.GetTotalSales().ToString("N2")

            lblReportCompleteOrders.Text =
                reportService.GetTotalCompletedOrders().ToString("N0")

            lblReportProductSales.Text =
                reportService.GetTotalProductSales().ToString("N0")

        Catch ex As Exception
            ShowReportError(ex)
        End Try

    End Sub


    '==================================================
    ' TRANSACTIONS BUTTON
    '==================================================
    Private Sub btnTransactions_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnTransactions.Click

        ShowTransactionsReport()

    End Sub


    '==================================================
    ' SALES BUTTON
    '==================================================
    Private Sub btnSales_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnSales.Click

        ShowSalesReport()

    End Sub


    '==================================================
    ' COMPLETED ORDERS BUTTON
    '==================================================
    Private Sub btnCompletedOrders_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnCompletedOrders.Click

        ShowCompletedOrdersReport()

    End Sub


    '==================================================
    ' PRODUCT SALES BUTTON
    '==================================================
    Private Sub btnProductSales_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnProductSales.Click

        ShowProductSalesReport()

    End Sub


    '==================================================
    ' SHOW TRANSACTIONS
    '==================================================
    Private Sub ShowTransactionsReport()

        Try
            lblReportTitle.Text = "ALL TRANSACTIONS"

            dgvReport.DataSource =
                reportService.GetTransactionList()

            FormatReportGrid()

        Catch ex As Exception
            ShowReportError(ex)
        End Try

    End Sub


    '==================================================
    ' SHOW SALES
    '==================================================
    Private Sub ShowSalesReport()

        Try
            lblReportTitle.Text = "SALES REPORT"

            dgvReport.DataSource =
                reportService.GetSalesReport()

            FormatReportGrid()

        Catch ex As Exception
            ShowReportError(ex)
        End Try

    End Sub


    '==================================================
    ' SHOW COMPLETED ORDERS
    '==================================================
    Private Sub ShowCompletedOrdersReport()

        Try
            lblReportTitle.Text = "COMPLETED ORDERS"

            dgvReport.DataSource =
                reportService.GetCompletedOrderList()

            FormatReportGrid()

        Catch ex As Exception
            ShowReportError(ex)
        End Try

    End Sub


    '==================================================
    ' SHOW PRODUCT SALES
    '==================================================
    Private Sub ShowProductSalesReport()

        Try
            lblReportTitle.Text = "PRODUCT SALES"

            dgvReport.DataSource =
                reportService.GetProductSales()

            FormatReportGrid()

        Catch ex As Exception
            ShowReportError(ex)
        End Try

    End Sub


    '==================================================
    ' SETUP REPORT GRID
    '==================================================
    Private Sub SetupReportGrid()

        With dgvReport

            .AutoGenerateColumns = True
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False
            .SelectionMode =
                DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill
            .RowHeadersVisible = False

        End With

    End Sub


    '==================================================
    ' FORMAT REPORT GRID
    '==================================================
    Private Sub FormatReportGrid()

        SetupReportGrid()

        For Each column As DataGridViewColumn In dgvReport.Columns

            Select Case column.Name

                Case "Sales", "Total"
                    column.DefaultCellStyle.Format = "₱#,##0.00"
                    column.DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleRight

                Case "Date"
                    column.DefaultCellStyle.Format =
                        "MM/dd/yyyy hh:mm tt"

            End Select

        Next

    End Sub


    '==================================================
    ' DISPLAY ERROR
    '==================================================
    Private Sub ShowReportError(ex As Exception)

        MessageBox.Show(
            "Unable to load the report." &
            Environment.NewLine &
            Environment.NewLine &
            ex.Message,
            "HungryTable Reports",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning
        )

    End Sub

End Class
