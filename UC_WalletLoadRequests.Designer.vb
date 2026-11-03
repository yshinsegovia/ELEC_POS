<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_WalletLoadRequests
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        dgvWalletRequests = New DataGridView()
        btnListApproved = New Button()
        btnListRejected = New Button()
        btnRefresh = New Button()
        lblTitle = New Label()
        btnPending = New Button()
        pnlRequestDetails = New Panel()
        btnReject = New Button()
        btnApprove = New Button()
        btnCloseRequest = New Button()
        lblStatus = New Label()
        Label14 = New Label()
        lblStudentName = New Label()
        Label9 = New Label()
        lblStudentID = New Label()
        lblRequestDate = New Label()
        lblAmount = New Label()
        lblCashier = New Label()
        lblRequestID = New Label()
        Label6 = New Label()
        Label8 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label10 = New Label()
        Label11 = New Label()
        CType(dgvWalletRequests, ComponentModel.ISupportInitialize).BeginInit()
        pnlRequestDetails.SuspendLayout()
        SuspendLayout()
        ' 
        ' dgvWalletRequests
        ' 
        dgvWalletRequests.AllowUserToAddRows = False
        dgvWalletRequests.AllowUserToDeleteRows = False
        dgvWalletRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvWalletRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvWalletRequests.Location = New Point(0, 289)
        dgvWalletRequests.MultiSelect = False
        dgvWalletRequests.Name = "dgvWalletRequests"
        dgvWalletRequests.ReadOnly = True
        dgvWalletRequests.RowHeadersWidth = 51
        dgvWalletRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvWalletRequests.Size = New Size(869, 284)
        dgvWalletRequests.TabIndex = 21
        ' 
        ' btnListApproved
        ' 
        btnListApproved.BackColor = Color.Lime
        btnListApproved.Font = New Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnListApproved.Location = New Point(221, 209)
        btnListApproved.Name = "btnListApproved"
        btnListApproved.Size = New Size(156, 31)
        btnListApproved.TabIndex = 22
        btnListApproved.Text = "APPROVED"
        btnListApproved.UseVisualStyleBackColor = False
        ' 
        ' btnListRejected
        ' 
        btnListRejected.BackColor = Color.Red
        btnListRejected.Font = New Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnListRejected.Location = New Point(436, 209)
        btnListRejected.Name = "btnListRejected"
        btnListRejected.Size = New Size(156, 31)
        btnListRejected.TabIndex = 23
        btnListRejected.Text = "REJECTED"
        btnListRejected.UseVisualStyleBackColor = False
        ' 
        ' btnRefresh
        ' 
        btnRefresh.BackColor = Color.FromArgb(CByte(190), CByte(160), CByte(122))
        btnRefresh.Font = New Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnRefresh.Location = New Point(780, 209)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(89, 31)
        btnRefresh.TabIndex = 24
        btnRefresh.Text = "REFRESH"
        btnRefresh.UseVisualStyleBackColor = False
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Sitka Text Semibold", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.Location = New Point(26, 66)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(296, 33)
        lblTitle.TabIndex = 25
        lblTitle.Text = "WALLET LOAD REQUEST"
        ' 
        ' btnPending
        ' 
        btnPending.BackColor = Color.FromArgb(CByte(190), CByte(160), CByte(122))
        btnPending.Font = New Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnPending.Location = New Point(26, 209)
        btnPending.Name = "btnPending"
        btnPending.Size = New Size(156, 31)
        btnPending.TabIndex = 26
        btnPending.Text = "PENDING"
        btnPending.UseVisualStyleBackColor = False
        ' 
        ' pnlRequestDetails
        ' 
        pnlRequestDetails.BorderStyle = BorderStyle.Fixed3D
        pnlRequestDetails.Controls.Add(btnReject)
        pnlRequestDetails.Controls.Add(btnApprove)
        pnlRequestDetails.Controls.Add(btnCloseRequest)
        pnlRequestDetails.Controls.Add(lblStatus)
        pnlRequestDetails.Controls.Add(Label14)
        pnlRequestDetails.Controls.Add(lblStudentName)
        pnlRequestDetails.Controls.Add(Label9)
        pnlRequestDetails.Controls.Add(lblStudentID)
        pnlRequestDetails.Controls.Add(lblRequestDate)
        pnlRequestDetails.Controls.Add(lblAmount)
        pnlRequestDetails.Controls.Add(lblCashier)
        pnlRequestDetails.Controls.Add(lblRequestID)
        pnlRequestDetails.Controls.Add(Label6)
        pnlRequestDetails.Controls.Add(Label8)
        pnlRequestDetails.Controls.Add(Label5)
        pnlRequestDetails.Controls.Add(Label4)
        pnlRequestDetails.Controls.Add(Label10)
        pnlRequestDetails.Controls.Add(Label11)
        pnlRequestDetails.Location = New Point(134, 80)
        pnlRequestDetails.Name = "pnlRequestDetails"
        pnlRequestDetails.Size = New Size(640, 432)
        pnlRequestDetails.TabIndex = 27
        pnlRequestDetails.Visible = False
        ' 
        ' btnReject
        ' 
        btnReject.BackColor = Color.Red
        btnReject.Font = New Font("Sitka Display Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnReject.Location = New Point(242, 353)
        btnReject.Name = "btnReject"
        btnReject.Size = New Size(157, 31)
        btnReject.TabIndex = 26
        btnReject.Text = "REJECT"
        btnReject.UseVisualStyleBackColor = False
        btnReject.Visible = False
        ' 
        ' btnApprove
        ' 
        btnApprove.BackColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
        btnApprove.Font = New Font("Sitka Display Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnApprove.Location = New Point(33, 353)
        btnApprove.Name = "btnApprove"
        btnApprove.Size = New Size(157, 31)
        btnApprove.TabIndex = 25
        btnApprove.Text = "APPROVE"
        btnApprove.UseVisualStyleBackColor = False
        btnApprove.Visible = False
        ' 
        ' btnCloseRequest
        ' 
        btnCloseRequest.BackColor = Color.FromArgb(CByte(190), CByte(160), CByte(122))
        btnCloseRequest.Font = New Font("Sitka Display Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCloseRequest.Location = New Point(480, 353)
        btnCloseRequest.Name = "btnCloseRequest"
        btnCloseRequest.Size = New Size(116, 31)
        btnCloseRequest.TabIndex = 21
        btnCloseRequest.Text = "CLOSE"
        btnCloseRequest.UseVisualStyleBackColor = False
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblStatus.ForeColor = Color.White
        lblStatus.Location = New Point(480, 207)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(80, 24)
        lblStatus.TabIndex = 19
        lblStatus.Text = "+++++++"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label14.ForeColor = Color.White
        Label14.Location = New Point(395, 207)
        Label14.Name = "Label14"
        Label14.Size = New Size(60, 24)
        Label14.TabIndex = 18
        Label14.Text = "Status:"
        ' 
        ' lblStudentName
        ' 
        lblStudentName.AutoSize = True
        lblStudentName.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblStudentName.ForeColor = Color.White
        lblStudentName.Location = New Point(480, 95)
        lblStudentName.Name = "lblStudentName"
        lblStudentName.Size = New Size(80, 24)
        lblStudentName.TabIndex = 15
        lblStudentName.Text = "+++++++"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = Color.White
        Label9.Location = New Point(344, 95)
        Label9.Name = "Label9"
        Label9.Size = New Size(111, 24)
        Label9.TabIndex = 14
        Label9.Text = "Student Name"
        ' 
        ' lblStudentID
        ' 
        lblStudentID.AutoSize = True
        lblStudentID.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblStudentID.ForeColor = Color.White
        lblStudentID.Location = New Point(174, 150)
        lblStudentID.Name = "lblStudentID"
        lblStudentID.Size = New Size(80, 24)
        lblStudentID.TabIndex = 13
        lblStudentID.Text = "+++++++"
        ' 
        ' lblRequestDate
        ' 
        lblRequestDate.AutoSize = True
        lblRequestDate.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblRequestDate.ForeColor = Color.White
        lblRequestDate.Location = New Point(174, 207)
        lblRequestDate.Name = "lblRequestDate"
        lblRequestDate.Size = New Size(80, 24)
        lblRequestDate.TabIndex = 12
        lblRequestDate.Text = "+++++++"
        ' 
        ' lblAmount
        ' 
        lblAmount.AutoSize = True
        lblAmount.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblAmount.ForeColor = Color.White
        lblAmount.Location = New Point(480, 152)
        lblAmount.Name = "lblAmount"
        lblAmount.Size = New Size(80, 24)
        lblAmount.TabIndex = 11
        lblAmount.Text = "+++++++"
        ' 
        ' lblCashier
        ' 
        lblCashier.AutoSize = True
        lblCashier.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCashier.ForeColor = Color.White
        lblCashier.Location = New Point(174, 265)
        lblCashier.Name = "lblCashier"
        lblCashier.Size = New Size(80, 24)
        lblCashier.TabIndex = 10
        lblCashier.Text = "+++++++"
        ' 
        ' lblRequestID
        ' 
        lblRequestID.AutoSize = True
        lblRequestID.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblRequestID.ForeColor = Color.White
        lblRequestID.Location = New Point(174, 95)
        lblRequestID.Name = "lblRequestID"
        lblRequestID.Size = New Size(80, 24)
        lblRequestID.TabIndex = 9
        lblRequestID.Text = "+++++++"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = Color.White
        Label6.Location = New Point(384, 150)
        Label6.Name = "Label6"
        Label6.Size = New Size(71, 24)
        Label6.TabIndex = 7
        Label6.Text = "Amount:"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label8.ForeColor = Color.White
        Label8.Location = New Point(49, 265)
        Label8.Name = "Label8"
        Label8.Size = New Size(69, 24)
        Label8.TabIndex = 6
        Label8.Text = "Cashier:"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = Color.White
        Label5.Location = New Point(33, 207)
        Label5.Name = "Label5"
        Label5.Size = New Size(109, 24)
        Label5.TabIndex = 3
        Label5.Text = "Request Date:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.White
        Label4.Location = New Point(33, 150)
        Label4.Name = "Label4"
        Label4.Size = New Size(91, 24)
        Label4.TabIndex = 2
        Label4.Text = "Student ID:"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.ForeColor = Color.White
        Label10.Location = New Point(33, 95)
        Label10.Name = "Label10"
        Label10.Size = New Size(92, 24)
        Label10.TabIndex = 1
        Label10.Text = "Request ID:"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Sitka Display", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.ForeColor = Color.White
        Label11.Location = New Point(193, 11)
        Label11.Name = "Label11"
        Label11.Size = New Size(243, 29)
        Label11.TabIndex = 0
        Label11.Text = "WALLET LOAD REQUESTS"
        ' 
        ' UC_WalletLoadRequests
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(106), CByte(106), CByte(67))
        Controls.Add(pnlRequestDetails)
        Controls.Add(btnPending)
        Controls.Add(lblTitle)
        Controls.Add(btnRefresh)
        Controls.Add(btnListRejected)
        Controls.Add(btnListApproved)
        Controls.Add(dgvWalletRequests)
        Name = "UC_WalletLoadRequests"
        Size = New Size(874, 699)
        CType(dgvWalletRequests, ComponentModel.ISupportInitialize).EndInit()
        pnlRequestDetails.ResumeLayout(False)
        pnlRequestDetails.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents dgvWalletRequests As DataGridView
    Friend WithEvents btnListApproved As Button
    Friend WithEvents btnListRejected As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnPending As Button
    Friend WithEvents pnlRequestDetails As Panel
    Friend WithEvents btnApprove As Button
    Friend WithEvents btnCloseRequest As Button
    Friend WithEvents lblStatus As Label
    Friend WithEvents Label14 As Label
    Private lblStudentName As Label
    Friend WithEvents lblOrderDate As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblStudentID As Label
    Friend WithEvents lblRequestDate As Label
    Friend WithEvents lblAmount As Label
    Friend WithEvents lblCashier As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents lblRequestID As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents btnReject As Button

End Class
