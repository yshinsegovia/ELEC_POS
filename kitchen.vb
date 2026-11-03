
Imports System.Data

Public Class kitchen

    Private ReadOnly orderService As New CashierOrderService()

    Private currentStatusFilter As String = "Pending"
    Private selectedTransactionID As Integer = 0
    Private isLoading As Boolean = False

    '========================================================
    ' FORM LOAD
    '========================================================
    Private Sub kitchen_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        btnPending.Text = "Pending"
        btnListPreparing.Text = "Preparing"
        btnListCompleted.Text = "Completed"
        btnListCancelled.Text = "Cancelled"

        ' Configure order list.
        With dgvKitchenOrders
            .AutoGenerateColumns = True
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            .RowHeadersVisible = False
        End With

        ' Configure order items list.
        With dgvOrderDetails
            .AutoGenerateColumns = True
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            .RowHeadersVisible = False
        End With

        ' Add a View button if one does not already exist.
        If Not dgvKitchenOrders.Columns.Contains("View") Then

            Dim viewButton As New DataGridViewButtonColumn()

            viewButton.Name = "View"
            viewButton.HeaderText = "Action"
            viewButton.Text = "VIEW"
            viewButton.UseColumnTextForButtonValue = True
            viewButton.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells
            viewButton.MinimumWidth = 70

            dgvKitchenOrders.Columns.Add(viewButton)

        End If

        ' Keep the View button compact.
        dgvKitchenOrders.Columns("View").AutoSizeMode =
            DataGridViewAutoSizeColumnMode.AllCells

        HideOrderDetails()
        LoadKitchenOrders()

    End Sub

    '========================================================
    ' LOAD ORDERS
    '========================================================
    Private Sub LoadKitchenOrders()

        If isLoading Then Return

        isLoading = True

        Try

            dgvKitchenOrders.DataSource =
                orderService.GetOrders("", currentStatusFilter)

            ' Reapply sizing after refreshing the data.
            dgvKitchenOrders.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill

            If dgvKitchenOrders.Columns.Contains("View") Then
                dgvKitchenOrders.Columns("View").AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells
            End If

            UpdateOrderCounts()

        Catch ex As Exception

            MessageBox.Show(
                ex.Message,
                "Load Orders Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        Finally

            isLoading = False

        End Try

    End Sub

    '========================================================
    ' UPDATE PENDING AND PREPARING COUNTS
    '========================================================
    Private Sub UpdateOrderCounts()

        Try

            Dim pendingOrders As DataTable =
                orderService.GetOrders("", "Pending")

            Dim preparingOrders As DataTable =
                orderService.GetOrders("", "Preparing")



        Catch ex As Exception

            MessageBox.Show(
                ex.Message,
                "Order Count Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

        End Try

    End Sub

    '========================================================
    ' STATUS FILTER BUTTONS
    '========================================================
    Private Sub btnPending_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnPending.Click

        ChangeStatusFilter("Pending")

    End Sub

    Private Sub btnListPreparing_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnListPreparing.Click

        ChangeStatusFilter("Preparing")

    End Sub

    Private Sub btnListCompleted_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnListCompleted.Click

        ChangeStatusFilter("Completed")

    End Sub

    Private Sub btnListCancelled_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnListCancelled.Click

        ChangeStatusFilter("Cancelled")

    End Sub

    Private Sub ChangeStatusFilter(status As String)

        currentStatusFilter = status

        HideOrderDetails()
        LoadKitchenOrders()

    End Sub

    '========================================================
    ' VIEW BUTTON IN EACH ORDER ROW
    '========================================================
    Private Sub dgvKitchenOrders_CellContentClick(
        sender As Object,
        e As DataGridViewCellEventArgs
    ) Handles dgvKitchenOrders.CellContentClick

        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return

        If dgvKitchenOrders.Columns(e.ColumnIndex).Name <> "View" Then
            Return
        End If

        Dim row As DataGridViewRow =
            dgvKitchenOrders.Rows(e.RowIndex)

        If row.Cells("Transaction ID").Value Is Nothing OrElse
           row.Cells("Transaction ID").Value Is DBNull.Value Then
            Return
        End If

        Dim transactionID As Integer =
            Convert.ToInt32(row.Cells("Transaction ID").Value)

        ShowOrderDetails(transactionID)

    End Sub

    '========================================================
    ' DISPLAY ORDER DETAILS
    '========================================================
    Private Sub ShowOrderDetails(transactionID As Integer)

        Try

            Dim orderInfo As DataTable =
                orderService.GetOrderInfo(transactionID)

            If orderInfo.Rows.Count = 0 Then

                MessageBox.Show(
                    "Order not found.",
                    "Order Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Return

            End If

            Dim orderRow As DataRow = orderInfo.Rows(0)

            selectedTransactionID = transactionID

            Dim status As String =
                orderRow("order_status").ToString()

            lblTransactionID.Text =
                orderRow("transaction_id").ToString()

            lblOrderStudentID.Text =
                orderRow("student_id").ToString()

            lblOrderStudentName.Text =
                orderRow("student_name").ToString()

            lblOrderCashier.Text =
                orderRow("cashier").ToString()

            lblOrderDate.Text =
                Convert.ToDateTime(
                    orderRow("transaction_date")
                ).ToString("MMM dd, yyyy hh:mm tt")

            lblOrderPayment.Text =
                orderRow("payment_method").ToString()

            lblOrderStatus.Text = status

            lblOrderTotal.Text =
                "TOTAL: ₱" &
                Convert.ToDecimal(
                    orderRow("total_amount")
                ).ToString("N2")

            dgvOrderDetails.DataSource =
                orderService.GetOrderDetails(transactionID)

            ' Keep all item columns fitted to the grid.
            dgvOrderDetails.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill

            UpdateStatusButtons(status)

            pnlOrderDetails.Visible = True
            pnlOrderDetails.BringToFront()

        Catch ex As Exception

            MessageBox.Show(
                ex.Message,
                "Order Details Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    '========================================================
    ' SHOW ACTION BUTTONS BASED ON STATUS
    '========================================================
    Private Sub UpdateStatusButtons(status As String)

        btnStartPreparing.Visible = (status = "Pending")
        btnCompleteOrder.Visible = (status = "Preparing")

    End Sub

    '========================================================
    ' START PREPARING
    '========================================================
    Private Sub btnStartPreparing_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnStartPreparing.Click

        If selectedTransactionID <= 0 Then Return

        Try

            Dim transactionID As Integer = selectedTransactionID

            If orderService.GetOrderStatus(transactionID) <> "Pending" Then

                MessageBox.Show(
                    "Only Pending orders can be started. Please refresh and try again.",
                    "Invalid Order Status",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                LoadKitchenOrders()
                ShowOrderDetails(transactionID)
                Return

            End If

            If CurrentSession.CurrentUser Is Nothing OrElse
               CurrentSession.CurrentUser.UserID <= 0 OrElse
               CurrentSession.CurrentUser.UserRole.ToLowerInvariant() <> "kitchen" Then

                MessageBox.Show(
                    "A valid kitchen session is required.",
                    "Session Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Return

            End If

            orderService.StartPreparingOrder(
                transactionID,
                CurrentSession.CurrentUser.UserID
            )

            MessageBox.Show(
                "Order is now being prepared.",
                "Order Updated",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            HideOrderDetails()
            LoadKitchenOrders()

        Catch ex As Exception

            MessageBox.Show(
                ex.Message,
                "Start Preparing Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    '========================================================
    ' COMPLETE ORDER
    '========================================================
    Private Sub btnCompleteOrder_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnCompleteOrder.Click

        If selectedTransactionID <= 0 Then Return

        Try

            Dim transactionID As Integer = selectedTransactionID

            If orderService.GetOrderStatus(transactionID) <> "Preparing" Then

                MessageBox.Show(
                    "Only Preparing orders can be completed. Please refresh and try again.",
                    "Invalid Order Status",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                LoadKitchenOrders()
                ShowOrderDetails(transactionID)
                Return

            End If

            If CurrentSession.CurrentUser Is Nothing OrElse
               CurrentSession.CurrentUser.UserID <= 0 OrElse
               CurrentSession.CurrentUser.UserRole.ToLowerInvariant() <> "kitchen" Then

                MessageBox.Show(
                    "A valid kitchen session is required.",
                    "Session Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Return

            End If

            orderService.CompleteKitchenOrder(
                transactionID,
                CurrentSession.CurrentUser.UserID
            )

            MessageBox.Show(
                "Order has been completed.",
                "Order Updated",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            HideOrderDetails()
            LoadKitchenOrders()

        Catch ex As Exception

            MessageBox.Show(
                ex.Message,
                "Complete Order Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    '========================================================
    ' CLOSE ORDER DETAILS PANEL
    '========================================================
    Private Sub btnCloseDetails_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnCloseDetails.Click

        HideOrderDetails

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

        lblTransactionID.Text = ""
        lblOrderStudentID.Text = ""
        lblOrderStudentName.Text = ""
        lblOrderCashier.Text = ""
        lblOrderDate.Text = ""
        lblOrderPayment.Text = ""
        lblOrderStatus.Text = ""
        lblOrderTotal.Text = ""

        dgvOrderDetails.DataSource = Nothing

        btnStartPreparing.Visible = False
        btnCompleteOrder.Visible = False

    End Sub

    '========================================================
    ' LOGOUT
    '========================================================
    Private Sub btnlogout_Click(sender As Object, e As EventArgs) Handles btnlogout.Click

        Dim result As DialogResult = MessageBox.Show(
        "Are you sure you want to log out?",
        "Confirm Logout",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
    )

        If result = DialogResult.Yes Then

            Try
                ' Clear the current user session.
                CurrentSession.CurrentUser = Nothing

                ' Return to the login form.
                Dim loginForm As New Form1()
                loginForm.Show()

                ' Close the Kitchen form.
                Me.Close()

            Catch ex As Exception

                MessageBox.Show(
                "Unable to log out: " & ex.Message,
                "Logout Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

            End Try

        End If

    End Sub
End Class
