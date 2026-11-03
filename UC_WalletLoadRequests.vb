
Imports System
Imports System.Data
Imports MySqlConnector
Imports Microsoft.VisualBasic

Public Class UC_WalletLoadRequests

    Private ReadOnly walletService As New WalletService()

    Private currentStatus As String = "Pending"
    Private selectedRequestID As Integer = 0

    ' ==========================================
    ' USER CONTROL LOAD
    ' ==========================================
    Private Sub UC_WalletLoadRequests_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        SetupDataGridView()
        HideRequestDetails()
        ShowRequests("Pending")

    End Sub

    ' ==========================================
    ' DATAGRIDVIEW SETTINGS
    ' ==========================================
    Private Sub SetupDataGridView()

        With dgvWalletRequests
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoGenerateColumns = True
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .RowHeadersVisible = False
        End With

        AddViewButtonColumn()

    End Sub

    ' ==========================================
    ' ADD VIEW BUTTON COLUMN
    ' ==========================================
    Private Sub AddViewButtonColumn()

        If dgvWalletRequests.Columns.Contains("btnView") Then
            Return
        End If

        Dim viewButton As New DataGridViewButtonColumn()

        With viewButton
            .Name = "btnView"
            .HeaderText = "Action"
            .Text = "View"
            .UseColumnTextForButtonValue = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .FlatStyle = FlatStyle.Standard
        End With

        dgvWalletRequests.Columns.Add(viewButton)

    End Sub

    ' ==========================================
    ' DISPLAY REQUESTS BY STATUS
    ' ==========================================
    Private Sub ShowRequests(status As String)

        Try
            currentStatus = status
            HideRequestDetails()

            Dim dt As DataTable =
                walletService.GetWalletLoadsByStatus(status)

            dgvWalletRequests.DataSource = Nothing
            dgvWalletRequests.DataSource = dt

            ' Hide internal ID column.
            If dgvWalletRequests.Columns.Contains("request_id") Then
                dgvWalletRequests.Columns("request_id").Visible = False
            End If

            ' Set readable column headers.
            SetColumnHeader("student_id", "Student ID")
            SetColumnHeader("firstname", "First Name")
            SetColumnHeader("lastname", "Last Name")
            SetColumnHeader("amount", "Load Amount")
            SetColumnHeader("cashier_username", "Cashier")
            SetColumnHeader("requested_at", "Request Date")
            SetColumnHeader("status", "Status")

            ' View is available only for pending requests.
            If dgvWalletRequests.Columns.Contains("btnView") Then
                dgvWalletRequests.Columns("btnView").Visible =
                    (status = "Pending")
            End If

            dgvWalletRequests.ClearSelection()

        Catch ex As Exception
            MessageBox.Show(
                "Unable to load wallet requests." &
                Environment.NewLine & ex.Message,
                "Wallet Requests",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )
        End Try

    End Sub

    Private Sub SetColumnHeader(
        columnName As String,
        headerText As String
    )

        If dgvWalletRequests.Columns.Contains(columnName) Then
            dgvWalletRequests.Columns(columnName).HeaderText = headerText
        End If

    End Sub

    ' ==========================================
    ' PENDING BUTTON
    ' ==========================================
    Private Sub btnPending_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnPending.Click

        ShowRequests("Pending")

    End Sub

    ' ==========================================
    ' APPROVED BUTTON
    ' ==========================================
    Private Sub btnListApproved_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnListApproved.Click

        ShowRequests("Approved")

    End Sub

    ' ==========================================
    ' REJECTED BUTTON
    ' ==========================================
    Private Sub btnListRejected_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnListRejected.Click

        ShowRequests("Rejected")

    End Sub

    ' ==========================================
    ' REFRESH BUTTON
    ' ==========================================
    Private Sub btnRefresh_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnRefresh.Click

        ShowRequests(currentStatus)

    End Sub

    ' ==========================================
    ' VIEW BUTTON IN DATAGRIDVIEW
    ' ==========================================
    Private Sub dgvWalletRequests_CellContentClick(
        sender As Object,
        e As DataGridViewCellEventArgs
    ) Handles dgvWalletRequests.CellContentClick

        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then
            Return
        End If

        If currentStatus <> "Pending" Then
            Return
        End If

        If dgvWalletRequests.Columns(e.ColumnIndex).Name <> "btnView" Then
            Return
        End If

        Try
            Dim row As DataGridViewRow =
                dgvWalletRequests.Rows(e.RowIndex)

            selectedRequestID =
                Convert.ToInt32(row.Cells("request_id").Value)

            lblRequestID.Text =
                selectedRequestID.ToString()

            lblStudentID.Text =
                GetCellText(row, "student_id")

            lblStudentName.Text =
                (GetCellText(row, "firstname") & " " &
                 GetCellText(row, "lastname")).Trim()

            lblAmount.Text =
                "₱" & Convert.ToDecimal(
                    row.Cells("amount").Value
                ).ToString("N2")

            lblCashier.Text =
                GetCellText(row, "cashier_username")

            lblRequestDate.Text =
                GetCellText(row, "requested_at")

            lblStatus.Text = "Pending"

            ' Only pending requests can be approved or rejected.
            btnApprove.Visible = True
            btnReject.Visible = True
            btnApprove.Enabled = True
            btnReject.Enabled = True

            pnlRequestDetails.Visible = True
            pnlRequestDetails.BringToFront()

        Catch ex As Exception
            selectedRequestID = 0

            MessageBox.Show(
                "Unable to display request details." &
                Environment.NewLine & ex.Message,
                "Request Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )
        End Try

    End Sub

    Private Function GetCellText(
        row As DataGridViewRow,
        columnName As String
    ) As String

        If Not dgvWalletRequests.Columns.Contains(columnName) Then
            Return String.Empty
        End If

        Dim cellValue As Object = row.Cells(columnName).Value

        If cellValue Is Nothing OrElse
           cellValue Is DBNull.Value Then

            Return String.Empty
        End If

        Return cellValue.ToString()

    End Function

    ' ==========================================
    ' APPROVE REQUEST
    ' ==========================================
    Private Sub btnApprove_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnApprove.Click

        If selectedRequestID <= 0 Then
            MessageBox.Show(
                "Please select a pending request first.",
                "Approve Request",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )
            Return
        End If

        If currentStatus <> "Pending" Then
            MessageBox.Show(
                "Only pending requests can be approved.",
                "Approve Request",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )
            Return
        End If

        If CurrentSession.CurrentUser Is Nothing Then
            MessageBox.Show(
                "No user is currently logged in.",
                "Approve Request",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )
            Return
        End If

        Dim adminID As Integer =
            CurrentSession.CurrentUser.UserID

        Dim result As DialogResult = MessageBox.Show(
            "Approve this wallet-load request?" &
            Environment.NewLine &
            "The student's wallet balance will increase.",
            "Confirm Approval",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        )

        If result <> DialogResult.Yes Then
            Return
        End If

        Try
            walletService.ApproveWalletLoad(
                selectedRequestID,
                adminID
            )

            MessageBox.Show(
                "Wallet-load request approved successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            ShowRequests("Pending")

        Catch ex As Exception
            MessageBox.Show(
                "Unable to approve this request." &
                Environment.NewLine & ex.Message,
                "Approval Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )
        End Try

    End Sub

    ' ==========================================
    ' REJECT REQUEST
    ' ==========================================
    Private Sub btnReject_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnReject.Click

        If selectedRequestID <= 0 Then
            MessageBox.Show(
                "Please select a pending request first.",
                "Reject Request",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )
            Return
        End If

        If currentStatus <> "Pending" Then
            MessageBox.Show(
                "Only pending requests can be rejected.",
                "Reject Request",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )
            Return
        End If

        If CurrentSession.CurrentUser Is Nothing Then
            MessageBox.Show(
                "No user is currently logged in.",
                "Reject Request",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )
            Return
        End If

        Dim reason As String = Interaction.InputBox(
            "Enter the reason for rejecting this request:",
            "Reject Wallet Load",
            ""
        ).Trim()

        If String.IsNullOrWhiteSpace(reason) Then
            MessageBox.Show(
                "Please enter a rejection reason. The request was not rejected.",
                "Rejection Reason Required",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )
            Return
        End If

        Dim result As DialogResult = MessageBox.Show(
            "Are you sure you want to reject this request?",
            "Confirm Rejection",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        )

        If result <> DialogResult.Yes Then
            Return
        End If

        Try
            Dim adminID As Integer =
                CurrentSession.CurrentUser.UserID

            walletService.RejectWalletLoad(
                selectedRequestID,
                adminID,
                reason
            )

            MessageBox.Show(
                "Wallet-load request rejected successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            ShowRequests("Pending")

        Catch ex As Exception
            MessageBox.Show(
                "Unable to reject this request." &
                Environment.NewLine & ex.Message,
                "Rejection Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )
        End Try

    End Sub

    ' ==========================================
    ' CLOSE DETAILS PANEL
    ' ==========================================
    Private Sub btnCloseRequest_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnCloseRequest.Click

        HideRequestDetails()

    End Sub

    Private Sub HideRequestDetails()

        pnlRequestDetails.Visible = False
        selectedRequestID = 0

    End Sub

End Class
