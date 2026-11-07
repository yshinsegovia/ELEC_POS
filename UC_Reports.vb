Imports System.Data
Imports System.Drawing
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

        ' Setup the ComboBox Dropdown
        cmbReportType.Items.Clear()
        cmbReportType.Items.Add("All Transactions")
        cmbReportType.Items.Add("Completed Orders")
        cmbReportType.Items.Add("Product Sales")

        ' Default to All Transactions (this will trigger the SelectedIndexChanged event)
        cmbReportType.SelectedIndex = 0

    End Sub

    '==================================================
    ' LOAD SUMMARY CARDS
    '==================================================
    Private Sub LoadReportCards()

        Try
            ' Assuming you renamed the labels in the designer
            lblReportTotalTransaction.Text = reportService.GetTotalTransactions().ToString("N0")
            lblReportTotalSales.Text = "₱" & reportService.GetTotalSales().ToString("N2")
            lblReportCompleteOrders.Text = reportService.GetTotalCompletedOrders().ToString("N0")
            lblReportProductSales.Text = reportService.GetTotalProductSales().ToString("N0")

        Catch ex As Exception
            ShowReportError(ex)
        End Try

    End Sub

    '==================================================
    ' COMBO BOX SELECTION CHANGED
    '==================================================
    Private Sub cmbReportType_SelectedIndexChanged(
        sender As Object,
        e As EventArgs
    ) Handles cmbReportType.SelectedIndexChanged

        If cmbReportType.SelectedItem Is Nothing Then Return

        Dim selectedReport As String = cmbReportType.SelectedItem.ToString()

        Try
            Select Case selectedReport

                Case "All Transactions"
                    lblReportTitle.Text = "ALL TRANSACTIONS"
                    dgvReport.DataSource = reportService.GetTransactionList()

                Case "Completed Orders"
                    lblReportTitle.Text = "COMPLETED ORDERS"
                    dgvReport.DataSource = reportService.GetCompletedOrderList()

                Case "Product Sales"
                    lblReportTitle.Text = "PRODUCT SALES"
                    dgvReport.DataSource = reportService.GetProductSales()

            End Select

            ' Format the grid after loading new data
            FormatReportGrid()

        Catch ex As Exception
            ShowReportError(ex)
        End Try

    End Sub

    '==================================================
    ' SETUP GRID (Cleans up the gray space)
    '==================================================
    Private Sub SetupReportGrid()

        With dgvReport
            .AutoGenerateColumns = True
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False

            ' Fixes the gray empty space
            .RowHeadersVisible = False
            .BackgroundColor = Color.White

            ' Stretches columns to fill the width so nothing is cut off
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End With

    End Sub

    '==================================================
    ' FORMAT REPORT GRID (Fixes cut-off dates and money)
    '==================================================
    Private Sub FormatReportGrid()

        SetupReportGrid()

        For Each column As DataGridViewColumn In dgvReport.Columns

            Select Case column.Name
                Case "Sales", "Total"
                    column.DefaultCellStyle.Format = "₱#,##0.00"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                Case "Date"
                    ' Force the date to show the full Date AND Time
                    column.DefaultCellStyle.Format = "MMM dd, yyyy hh:mm tt"
                    ' Give the date column more space so it doesn't get cut off
                    column.FillWeight = 150
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