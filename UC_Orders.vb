
Imports System.Data

Public Class UC_Orders

    '========================================================
    ' SERVICE
    '========================================================
    Private ReadOnly orderService As New CashierOrderService()

    '========================================================
    ' CURRENT FILTER
    '========================================================
    Private CurrentStatusFilter As String = "All"

    '========================================================
    ' SELECTED TRANSACTION
    '========================================================
    Private selectedTransactionID As Integer = 0

    '========================================================
    ' REFRESH TIMER
    '========================================================
    Private ReadOnly orderRefreshTimer As New Timer()

    '========================================================
    ' USERCONTROL LOAD
    '========================================================
    Private Sub UC_Orders_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        SetupOrdersGrid()
        SetupOrderDetailsGrid()
        ClearOrderDetails()

        CurrentStatusFilter = "All"
        LoadOrders()

        orderRefreshTimer.Interval = 5000

        AddHandler orderRefreshTimer.Tick,
            AddressOf OrderRefreshTimer_Tick

        orderRefreshTimer.Start()

    End Sub

    '========================================================
    ' SETUP MAIN ORDERS GRID
    '========================================================
    Private Sub SetupOrdersGrid()

        dgvOrders.Columns.Clear()

        dgvOrders.AutoGenerateColumns = False
        dgvOrders.AllowUserToAddRows = False
        dgvOrders.AllowUserToDeleteRows = False
        dgvOrders.ReadOnly = True
        dgvOrders.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect
        dgvOrders.MultiSelect = False
        dgvOrders.RowHeadersVisible = False

        Dim colID As New DataGridViewTextBoxColumn()
        colID.Name = "Transaction ID"
        colID.HeaderText = "Order #"
        colID.DataPropertyName = "Transaction ID"
        colID.Width = 70
        dgvOrders.Columns.Add(colID)

        Dim colStudentID As New DataGridViewTextBoxColumn()
        colStudentID.Name = "Student ID"
        colStudentID.HeaderText = "Student ID"
        colStudentID.DataPropertyName = "Student ID"
        colStudentID.Width = 100
        dgvOrders.Columns.Add(colStudentID)

        Dim colStudentName As New DataGridViewTextBoxColumn()
        colStudentName.Name = "Student Name"
        colStudentName.HeaderText = "Student Name"
        colStudentName.DataPropertyName = "Student Name"
        colStudentName.AutoSizeMode =
            DataGridViewAutoSizeColumnMode.Fill
        dgvOrders.Columns.Add(colStudentName)

        Dim colTotal As New DataGridViewTextBoxColumn()
        colTotal.Name = "Total"
        colTotal.HeaderText = "Total"
        colTotal.DataPropertyName = "Total"
        colTotal.Width = 90
        colTotal.DefaultCellStyle.Format = "₱#,##0.00"
        dgvOrders.Columns.Add(colTotal)

        Dim colDate As New DataGridViewTextBoxColumn()
        colDate.Name = "Date/Time"
        colDate.HeaderText = "Date/Time"
        colDate.DataPropertyName = "Date/Time"
        colDate.Width = 145
        colDate.DefaultCellStyle.Format =
            "MMM dd, yyyy hh:mm tt"
        dgvOrders.Columns.Add(colDate)

        Dim colStatus As New DataGridViewTextBoxColumn()
        colStatus.Name = "Status"
        colStatus.HeaderText = "Status"
        colStatus.DataPropertyName = "Status"
        colStatus.Width = 100
        dgvOrders.Columns.Add(colStatus)

        Dim colView As New DataGridViewButtonColumn()
        colView.Name = "View"
        colView.HeaderText = "Action"
        colView.Text = "VIEW"
        colView.UseColumnTextForButtonValue = True
        colView.Width = 70
        dgvOrders.Columns.Add(colView)

    End Sub

    '========================================================
    ' SETUP ORDER DETAILS GRID
    '========================================================
    Private Sub SetupOrderDetailsGrid()

        dgvOrderDetails.Columns.Clear()

        dgvOrderDetails.AutoGenerateColumns = False
        dgvOrderDetails.AllowUserToAddRows = False
        dgvOrderDetails.AllowUserToDeleteRows = False
        dgvOrderDetails.ReadOnly = True
        dgvOrderDetails.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect
        dgvOrderDetails.MultiSelect = False
        dgvOrderDetails.RowHeadersVisible = False

        Dim colProduct As New DataGridViewTextBoxColumn()
        colProduct.Name = "Product"
        colProduct.HeaderText = "Product"
        colProduct.DataPropertyName = "Product"
        colProduct.AutoSizeMode =
            DataGridViewAutoSizeColumnMode.Fill
        dgvOrderDetails.Columns.Add(colProduct)

        Dim colQty As New DataGridViewTextBoxColumn()
        colQty.Name = "Qty"
        colQty.HeaderText = "Qty"
        colQty.DataPropertyName = "Qty"
        colQty.Width = 50
        dgvOrderDetails.Columns.Add(colQty)

        Dim colPrice As New DataGridViewTextBoxColumn()
        colPrice.Name = "Price"
        colPrice.HeaderText = "Price"
        colPrice.DataPropertyName = "Price"
        colPrice.Width = 90
        colPrice.DefaultCellStyle.Format = "₱#,##0.00"
        dgvOrderDetails.Columns.Add(colPrice)

        Dim colSubtotal As New DataGridViewTextBoxColumn()
        colSubtotal.Name = "Subtotal"
        colSubtotal.HeaderText = "Subtotal"
        colSubtotal.DataPropertyName = "Subtotal"
        colSubtotal.Width = 100
        colSubtotal.DefaultCellStyle.Format = "₱#,##0.00"
        dgvOrderDetails.Columns.Add(colSubtotal)

    End Sub

    '========================================================
    ' LOAD ORDERS
    '========================================================
    Private Sub LoadOrders()

        Try

            Dim table As DataTable =
                orderService.GetOrders(
                    txtSearchOrders.Text.Trim(),
                    CurrentStatusFilter
                )

            dgvOrders.DataSource = table

        Catch ex As Exception

            MessageBox.Show(
                ex.Message,
                "Orders",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    '========================================================
    ' SEARCH BUTTON
    '========================================================
    Private Sub btnSearchOrder_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnSearchOrder.Click

        LoadOrders()

    End Sub

    '========================================================
    ' SEARCH TEXT CHANGED
    '========================================================
    Private Sub txtSearchOrders_TextChanged(
        sender As Object,
        e As EventArgs
    ) Handles txtSearchOrders.TextChanged

        ' Search when the Search button is clicked.

    End Sub

    '========================================================
    ' ENTER KEY SEARCH
    '========================================================
    Private Sub txtSearchOrders_KeyDown(
        sender As Object,
        e As KeyEventArgs
    ) Handles txtSearchOrders.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnSearchOrder.PerformClick()
        End If

    End Sub

    '========================================================
    ' ALL ORDERS
    '========================================================
    Private Sub btnAllOrders_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnAllOrders.Click

        CurrentStatusFilter = "All"
        HideOrderDetails()
        LoadOrders()

    End Sub

    '========================================================
    ' PENDING ORDERS
    '========================================================
    Private Sub btnPendingOrders_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnPendingOrders.Click

        CurrentStatusFilter = "Pending"
        HideOrderDetails()
        LoadOrders()

    End Sub

    '========================================================
    ' PREPARING ORDERS
    '========================================================
    Private Sub btnPreparinOrders_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnPreparinOrders.Click

        CurrentStatusFilter = "Preparing"
        HideOrderDetails()
        LoadOrders()

    End Sub

    '========================================================
    ' COMPLETED ORDERS
    '========================================================
    Private Sub btnCompletedOrders_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnCompletedOrders.Click

        CurrentStatusFilter = "Completed"
        HideOrderDetails()
        LoadOrders()

    End Sub

    '========================================================
    ' CANCELLED ORDERS LIST BUTTON
    '========================================================
    Private Sub btnCancelOrderList_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnCancelOrderList.Click

        CurrentStatusFilter = "Cancelled"

        HideOrderDetails()
        LoadOrders()

    End Sub

    '========================================================
    ' VIEW BUTTON
    '========================================================
    Private Sub dgvOrders_CellContentClick(
        sender As Object,
        e As DataGridViewCellEventArgs
    ) Handles dgvOrders.CellContentClick

        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then
            Return
        End If

        If dgvOrders.Columns(e.ColumnIndex).Name <> "View" Then
            Return
        End If

        Dim value As Object =
            dgvOrders.Rows(e.RowIndex).
            Cells("Transaction ID").Value

        If value Is Nothing OrElse value Is DBNull.Value Then
            Return
        End If

        selectedTransactionID = Convert.ToInt32(value)

        ShowOrderDetails(selectedTransactionID)

    End Sub

    '========================================================
    ' SHOW ORDER DETAILS
    '========================================================
    Private Sub ShowOrderDetails(
        transactionID As Integer
    )

        Try

            Dim infoTable As DataTable =
                orderService.GetOrderInfo(transactionID)

            If infoTable.Rows.Count = 0 Then

                MessageBox.Show(
                    "Order not found.",
                    "Order Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                HideOrderDetails()
                Return

            End If

            Dim info As DataRow = infoTable.Rows(0)

            Dim currentStatus As String =
                info("order_status").ToString()

            If CurrentStatusFilter <> "All" AndAlso
               Not currentStatus.Equals(
                   CurrentStatusFilter,
                   StringComparison.OrdinalIgnoreCase
               ) Then

                HideOrderDetails()
                Return

            End If

            lblTransactionID.Text =
                info("transaction_id").ToString()

            lblOrderStudentID.Text =
                info("student_id").ToString()

            lblOrderStudentName.Text =
                info("student_name").ToString()

            lblOrderCashier.Text =
                info("cashier").ToString()

            lblOrderDate.Text =
                Convert.ToDateTime(
                    info("transaction_date")
                ).ToString("MMM dd, yyyy hh:mm tt")

            lblOrderPayment.Text =
                info("payment_method").ToString()

            lblOrderStatus.Text = currentStatus

            lblOrderTotal.Text =
                "TOTAL: ₱" &
                Convert.ToDecimal(
                    info("total_amount")
                ).ToString("N2")

            dgvOrderDetails.DataSource =
                orderService.GetOrderDetails(transactionID)

            UpdateStatusButtons(currentStatus)

            pnlOrderDetails.Visible = True
            pnlOrderDetails.BringToFront()

        Catch ex As Exception

            MessageBox.Show(
                ex.Message,
                "Order Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    '========================================================
    ' UPDATE ACTION BUTTON VISIBILITY
    '========================================================
    Private Sub UpdateStatusButtons(status As String)

        ' Cancellation is available only for Pending orders.
        btnCancelOrder.Visible =
            status.Equals(
                "Pending",
                StringComparison.OrdinalIgnoreCase
            )

    End Sub

    '========================================================
    ' CANCEL ORDER BUTTON
    '========================================================
    Private Sub btnCancelOrder_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnCancelOrder.Click

        If selectedTransactionID <= 0 Then

            MessageBox.Show(
                "Please open an order first.",
                "Cancel Order",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        Try

            ' Recheck the status in the database.
            Dim currentStatus As String =
                orderService.GetOrderStatus(
                    selectedTransactionID
                )

            If Not currentStatus.Equals(
                "Pending",
                StringComparison.OrdinalIgnoreCase
            ) Then

                MessageBox.Show(
                    "Only Pending orders can be cancelled." &
                    Environment.NewLine &
                    "Current status: " & currentStatus,
                    "Cancel Order",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                LoadOrders()
                ShowOrderDetails(selectedTransactionID)
                Return

            End If

            ' Ask for confirmation.
            Dim confirmation As DialogResult =
                MessageBox.Show(
                    "Are you sure you want to cancel order #" &
                    selectedTransactionID.ToString() & "?" &
                    Environment.NewLine & Environment.NewLine &
                    "The student's wallet will be refunded, " &
                    "and the products will be returned to stock.",
                    "Confirm Cancellation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                )

            If confirmation <> DialogResult.Yes Then
                Return
            End If

            ' Verify the logged-in cashier.
            If CurrentSession.CurrentUser Is Nothing Then

                MessageBox.Show(
                    "No logged-in user was found. Please log in again.",
                    "Cancel Order",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Return

            End If

            Dim cashierID As Integer =
                CurrentSession.CurrentUser.UserID

            If cashierID <= 0 Then

                MessageBox.Show(
                    "The cashier account is invalid.",
                    "Cancel Order",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Return

            End If

            ' Save cancellation, refund, and stock restoration.
            orderService.CancelOrder(
                selectedTransactionID,
                cashierID
            )

            MessageBox.Show(
                "Order #" & selectedTransactionID.ToString() &
                " was cancelled successfully." &
                Environment.NewLine & Environment.NewLine &
                "The student's wallet was refunded, " &
                "stock was restored, and the refund was recorded.",
                "Order Cancelled",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            ' Automatically show the Cancelled Orders list.
            CurrentStatusFilter = "Cancelled"

            HideOrderDetails()
            LoadOrders()

        Catch ex As Exception

            MessageBox.Show(
                ex.Message,
                "Cancel Order",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

            LoadOrders()

            If selectedTransactionID > 0 Then
                ShowOrderDetails(selectedTransactionID)
            End If

        End Try

    End Sub

    '========================================================
    ' CLOSE ORDER DETAILS
    '========================================================
    Private Sub btnCloseOrder_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnCloseOrder.Click

        HideOrderDetails()

    End Sub

    '========================================================
    ' HIDE ORDER DETAILS
    '========================================================
    Private Sub HideOrderDetails()

        pnlOrderDetails.Visible = False
        selectedTransactionID = 0

        ClearOrderDetails()

    End Sub

    '========================================================
    ' CLEAR ORDER DETAILS
    '========================================================
    Private Sub ClearOrderDetails()

        lblTransactionID.Text = "-"
        lblOrderStudentID.Text = "-"
        lblOrderStudentName.Text = "-"
        lblOrderCashier.Text = "-"
        lblOrderDate.Text = "-"
        lblOrderPayment.Text = "-"
        lblOrderStatus.Text = "-"
        lblOrderTotal.Text = "TOTAL: ₱0.00"

        dgvOrderDetails.DataSource = Nothing

        btnCancelOrder.Visible = False

    End Sub

    '========================================================
    ' AUTO REFRESH
    '========================================================
    Private Sub OrderRefreshTimer_Tick(
        sender As Object,
        e As EventArgs
    )

        LoadOrders()

        If pnlOrderDetails.Visible AndAlso
           selectedTransactionID > 0 Then

            ShowOrderDetails(selectedTransactionID)

        End If

    End Sub

    '========================================================
    ' DISPOSE
    '========================================================
    Private Sub UC_Orders_Disposed(
        sender As Object,
        e As EventArgs
    ) Handles Me.Disposed

        orderRefreshTimer.Stop()

        RemoveHandler orderRefreshTimer.Tick,
            AddressOf OrderRefreshTimer_Tick

        orderRefreshTimer.Dispose()

    End Sub

    '========================================================
    ' DESIGNER EVENTS
    '========================================================
    Private Sub lblTransactionID_Click(
        sender As Object,
        e As EventArgs
    ) Handles lblTransactionID.Click
    End Sub

    Private Sub lblOrderStudentID_Click(
        sender As Object,
        e As EventArgs
    ) Handles lblOrderStudentID.Click
    End Sub

    Private Sub lblOrderStudentName_Click(
        sender As Object,
        e As EventArgs
    ) Handles lblOrderStudentName.Click
    End Sub

    Private Sub lblOrderCashier_Click(
        sender As Object,
        e As EventArgs
    ) Handles lblOrderCashier.Click
    End Sub

    Private Sub lblOrderDate_Click(
        sender As Object,
        e As EventArgs
    ) Handles lblOrderDate.Click
    End Sub

    Private Sub lblOrderPayment_Click(
        sender As Object,
        e As EventArgs
    ) Handles lblOrderPayment.Click
    End Sub

    Private Sub lblOrderStatus_Click(
        sender As Object,
        e As EventArgs
    ) Handles lblOrderStatus.Click
    End Sub

    Private Sub dgvOrderDetails_CellContentClick(
        sender As Object,
        e As DataGridViewCellEventArgs
    ) Handles dgvOrderDetails.CellContentClick
    End Sub

    Private Sub lblOrderTotal_Click(
        sender As Object,
        e As EventArgs
    ) Handles lblOrderTotal.Click
    End Sub

    Private Sub pnlOrderDetails_Paint(
        sender As Object,
        e As PaintEventArgs
    ) Handles pnlOrderDetails.Paint
    End Sub

End Class
