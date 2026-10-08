Imports System.Data

Public Class UC_History

    '========================================================
    ' SERVICE
    '========================================================
    Private ReadOnly historyService As New CashierHistoryService()

    '========================================================
    ' SELECTED TRANSACTION
    '========================================================
    Private selectedTransactionID As Integer = 0

    '========================================================
    ' AUTO REFRESH
    '========================================================
    Private ReadOnly historyRefreshTimer As New Timer()


    '========================================================
    ' FORM LOAD
    '========================================================
    Private Sub UC_History_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        SetupHistoryGrid()
        SetupHistoryDetailsGrid()

        HideHistoryDetails()

        LoadHistory()

        StartRefreshTimer()

    End Sub


    '========================================================
    ' SETUP HISTORY GRID
    '========================================================
    Private Sub SetupHistoryGrid()

        dgvOrders.Columns.Clear()

        dgvOrders.AutoGenerateColumns = False
        dgvOrders.AllowUserToAddRows = False
        dgvOrders.AllowUserToDeleteRows = False
        dgvOrders.ReadOnly = True

        dgvOrders.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect

        dgvOrders.MultiSelect = False
        dgvOrders.RowHeadersVisible = False


        '----------------------------------------------------
        ' ORDER #
        '----------------------------------------------------
        Dim colTransactionID As New DataGridViewTextBoxColumn With {
            .Name = "Transaction ID",
            .HeaderText = "Order #",
            .DataPropertyName = "transaction_id",
            .Width = 70
        }

        dgvOrders.Columns.Add(colTransactionID)


        '----------------------------------------------------
        ' STUDENT ID
        '----------------------------------------------------
        Dim colStudentID As New DataGridViewTextBoxColumn With {
            .Name = "Student ID",
            .HeaderText = "Student ID",
            .DataPropertyName = "student_id",
            .Width = 100
        }

        dgvOrders.Columns.Add(colStudentID)


        '----------------------------------------------------
        ' STUDENT NAME
        '----------------------------------------------------
        Dim colStudentName As New DataGridViewTextBoxColumn With {
            .Name = "Student Name",
            .HeaderText = "Student Name",
            .DataPropertyName = "student_name",
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        }

        dgvOrders.Columns.Add(colStudentName)


        '----------------------------------------------------
        ' TOTAL
        '----------------------------------------------------
        Dim colTotal As New DataGridViewTextBoxColumn With {
            .Name = "Total",
            .HeaderText = "Total",
            .DataPropertyName = "total_amount",
            .Width = 90
        }

        colTotal.DefaultCellStyle.Format = "₱#,##0.00"

        dgvOrders.Columns.Add(colTotal)


        '----------------------------------------------------
        ' DATE / TIME
        '----------------------------------------------------
        Dim colDate As New DataGridViewTextBoxColumn With {
            .Name = "Date/Time",
            .HeaderText = "Date/Time",
            .DataPropertyName = "transaction_date",
            .Width = 150
        }

        colDate.DefaultCellStyle.Format =
            "MMM dd, yyyy hh:mm tt"

        dgvOrders.Columns.Add(colDate)


        '----------------------------------------------------
        ' STATUS
        '----------------------------------------------------
        Dim colStatus As New DataGridViewTextBoxColumn With {
            .Name = "Status",
            .HeaderText = "Status",
            .DataPropertyName = "order_status",
            .Width = 100
        }

        dgvOrders.Columns.Add(colStatus)


        '----------------------------------------------------
        ' VIEW BUTTON
        '----------------------------------------------------
        Dim colView As New DataGridViewButtonColumn With {
            .Name = "View",
            .HeaderText = "Action",
            .Text = "VIEW",
            .UseColumnTextForButtonValue = True,
            .Width = 70
        }

        dgvOrders.Columns.Add(colView)

    End Sub


    '========================================================
    ' SETUP DETAILS GRID
    '========================================================
    Private Sub SetupHistoryDetailsGrid()

        dgvHistoryDetails.Columns.Clear()

        dgvHistoryDetails.AutoGenerateColumns = False
        dgvHistoryDetails.AllowUserToAddRows = False
        dgvHistoryDetails.AllowUserToDeleteRows = False
        dgvHistoryDetails.ReadOnly = True

        dgvHistoryDetails.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect

        dgvHistoryDetails.MultiSelect = False
        dgvHistoryDetails.RowHeadersVisible = False


        '----------------------------------------------------
        ' PRODUCT
        '----------------------------------------------------
        Dim colProduct As New DataGridViewTextBoxColumn With {
            .Name = "Product",
            .HeaderText = "Product",
            .DataPropertyName = "Product",
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        }

        dgvHistoryDetails.Columns.Add(colProduct)


        '----------------------------------------------------
        ' QUANTITY
        '----------------------------------------------------
        Dim colQuantity As New DataGridViewTextBoxColumn With {
            .Name = "Qty",
            .HeaderText = "Qty",
            .DataPropertyName = "Qty",
            .Width = 50
        }

        dgvHistoryDetails.Columns.Add(colQuantity)


        '----------------------------------------------------
        ' PRICE
        '----------------------------------------------------
        Dim colPrice As New DataGridViewTextBoxColumn With {
            .Name = "Price",
            .HeaderText = "Price",
            .DataPropertyName = "Price",
            .Width = 90
        }

        colPrice.DefaultCellStyle.Format =
            "₱#,##0.00"

        dgvHistoryDetails.Columns.Add(colPrice)


        '----------------------------------------------------
        ' SUBTOTAL
        '----------------------------------------------------
        Dim colSubtotal As New DataGridViewTextBoxColumn With {
            .Name = "Subtotal",
            .HeaderText = "Subtotal",
            .DataPropertyName = "Subtotal",
            .Width = 100
        }

        colSubtotal.DefaultCellStyle.Format =
            "₱#,##0.00"

        dgvHistoryDetails.Columns.Add(colSubtotal)

    End Sub


    '========================================================
    ' LOAD HISTORY
    '========================================================
    Private Sub LoadHistory()

        Try

            Dim searchText As String =
                txtSearchHistory.Text.Trim()

            Dim historyTable As DataTable =
                historyService.GetHistory(searchText)

            dgvOrders.DataSource = historyTable

        Catch ex As Exception

            MessageBox.Show(
                "Unable to load transaction history." &
                Environment.NewLine &
                Environment.NewLine &
                ex.Message,
                "History",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    '========================================================
    ' SEARCH
    '========================================================
    Private Sub btnSearchHistory_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnSearchHistory.Click

        LoadHistory()

    End Sub


    '========================================================
    ' SEARCH WHEN ENTER IS PRESSED
    '========================================================
    Private Sub txtSearchHistory_KeyDown(
        sender As Object,
        e As KeyEventArgs
    ) Handles txtSearchHistory.KeyDown

        If e.KeyCode = Keys.Enter Then

            e.SuppressKeyPress = True

            btnSearchHistory.PerformClick()

        End If

    End Sub


    '========================================================
    ' SEARCH TEXT CHANGED
    '========================================================
    Private Sub txtSearchHistory_TextChanged(
        sender As Object,
        e As EventArgs
    ) Handles txtSearchHistory.TextChanged

        'Search happens only when SEARCH is clicked
        'or ENTER is pressed.

    End Sub


    '========================================================
    ' VIEW TRANSACTION
    '========================================================
    Private Sub dgvOrders_CellContentClick(
        sender As Object,
        e As DataGridViewCellEventArgs
    ) Handles dgvOrders.CellContentClick

        If e.RowIndex < 0 Then Return
        If e.ColumnIndex < 0 Then Return

        If dgvOrders.Columns(e.ColumnIndex).Name <> "View" Then
            Return
        End If


        Dim value As Object =
            dgvOrders.Rows(e.RowIndex).
            Cells("Transaction ID").Value


        If value Is Nothing OrElse
           value Is DBNull.Value Then

            Return

        End If


        selectedTransactionID =
            Convert.ToInt32(value)


        LoadHistoryDetails(
            selectedTransactionID
        )

    End Sub


    '========================================================
    ' LOAD SELECTED TRANSACTION DETAILS
    '========================================================
    Private Sub LoadHistoryDetails(
        transactionID As Integer
    )

        Try

            Dim infoTable As DataTable =
                historyService.GetHistoryInfo(
                    transactionID
                )


            If infoTable.Rows.Count = 0 Then

                MessageBox.Show(
                    "Transaction not found.",
                    "History",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Return

            End If


            Dim info As DataRow =
                infoTable.Rows(0)


            '------------------------------------------------
            ' TRANSACTION INFORMATION
            '------------------------------------------------
            lblHistoryTransactionID.Text =
                info("transaction_id").ToString()


            lblHistoryStudentID.Text =
                info("student_id").ToString()


            lblHistoryStudentName.Text =
                info("student_name").ToString()


            lblHistoryCashier.Text =
                info("cashier").ToString()


            lblHistoryDate.Text =
                Convert.ToDateTime(
                    info("transaction_date")
                ).ToString(
                    "MMM dd, yyyy hh:mm tt"
                )


            lblHistoryPayment.Text =
                info("payment_method").ToString()


            lblHistoryStatus.Text =
                info("order_status").ToString()


            lblHistoryTotal.Text =
                "TOTAL: ₱" &
                Convert.ToDecimal(
                    info("total_amount")
                ).ToString("N2")


            '------------------------------------------------
            ' LOAD ITEMS
            '------------------------------------------------
            Dim detailsTable As DataTable =
                historyService.GetHistoryDetails(
                    transactionID
                )


            dgvHistoryDetails.DataSource =
                detailsTable


            '------------------------------------------------
            ' SHOW DETAILS PANEL
            '------------------------------------------------
            pnlHistoryDetails.Visible = True

            pnlHistoryDetails.BringToFront()

        Catch ex As Exception

            MessageBox.Show(
                "Unable to load transaction details." &
                Environment.NewLine &
                Environment.NewLine &
                ex.Message,
                "History",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    '========================================================
    ' CLOSE DETAILS
    '========================================================
    Private Sub btnCloseHistory_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnCloseHistory.Click

        HideHistoryDetails()

    End Sub


    '========================================================
    ' HIDE DETAILS PANEL
    '========================================================
    Private Sub HideHistoryDetails()

        pnlHistoryDetails.Visible = False

        selectedTransactionID = 0

        ClearHistoryDetails()

    End Sub


    '========================================================
    ' CLEAR DETAILS
    '========================================================
    Private Sub ClearHistoryDetails()

        lblHistoryTransactionID.Text = "-"
        lblHistoryStudentID.Text = "-"
        lblHistoryStudentName.Text = "-"
        lblHistoryCashier.Text = "-"
        lblHistoryDate.Text = "-"
        lblHistoryPayment.Text = "-"
        lblHistoryStatus.Text = "-"

        lblHistoryTotal.Text =
            "TOTAL: ₱0.00"

        dgvHistoryDetails.DataSource = Nothing

    End Sub


    '========================================================
    ' START AUTO REFRESH
    '========================================================
    Private Sub StartRefreshTimer()

        historyRefreshTimer.Interval = 5000

        AddHandler historyRefreshTimer.Tick,
            AddressOf HistoryRefreshTimer_Tick

        historyRefreshTimer.Start()

    End Sub


    '========================================================
    ' AUTO REFRESH
    '========================================================
    Private Sub HistoryRefreshTimer_Tick(
        sender As Object,
        e As EventArgs
    )

        LoadHistory()


        If pnlHistoryDetails.Visible AndAlso
           selectedTransactionID > 0 Then

            LoadHistoryDetails(
                selectedTransactionID
            )

        End If

    End Sub


    '========================================================
    ' CLEAN UP TIMER
    '========================================================
    Private Sub UC_History_Disposed(
        sender As Object,
        e As EventArgs
    ) Handles Me.Disposed

        If historyRefreshTimer IsNot Nothing Then

            historyRefreshTimer.Stop()

            RemoveHandler historyRefreshTimer.Tick,
                AddressOf HistoryRefreshTimer_Tick

            historyRefreshTimer.Dispose()

        End If

    End Sub


    '========================================================
    ' DESIGNER EVENTS
    '========================================================
    Private Sub lblHistoryTransactionID_Click(
        sender As Object,
        e As EventArgs
    ) Handles lblHistoryTransactionID.Click

    End Sub


    Private Sub pnlHistoryDetails_Paint(
        sender As Object,
        e As PaintEventArgs
    ) Handles pnlHistoryDetails.Paint

    End Sub


    Private Sub lblHistoryStudentID_Click(
        sender As Object,
        e As EventArgs
    ) Handles lblHistoryStudentID.Click

    End Sub


    Private Sub lblHistoryStudentName_Click(
        sender As Object,
        e As EventArgs
    ) Handles lblHistoryStudentName.Click

    End Sub


    Private Sub lblHistoryCashier_Click(
        sender As Object,
        e As EventArgs
    ) Handles lblHistoryCashier.Click

    End Sub


    Private Sub lblHistoryDate_Click(
        sender As Object,
        e As EventArgs
    ) Handles lblHistoryDate.Click

    End Sub


    Private Sub lblHistoryPayment_Click(
        sender As Object,
        e As EventArgs
    ) Handles lblHistoryPayment.Click

    End Sub


    Private Sub lblHistoryStatus_Click(
        sender As Object,
        e As EventArgs
    ) Handles lblHistoryStatus.Click

    End Sub


    Private Sub dgvHistoryDetails_CellContentClick(
        sender As Object,
        e As DataGridViewCellEventArgs
    ) Handles dgvHistoryDetails.CellContentClick

    End Sub


    Private Sub lblHistoryTotal_Click(
        sender As Object,
        e As EventArgs
    ) Handles lblHistoryTotal.Click

    End Sub

End Class
