<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class kitchen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Label1 = New Label()
        Label2 = New Label()
        lblPendingNum = New Label()
        Label7 = New Label()
        dgvKitchenOrders = New DataGridView()
        pnlOrderDetails = New Panel()
        btnCompleteOrder = New Button()
        btnStartPreparing = New Button()
        lblOrderTotal = New Label()
        Label12 = New Label()
        btnCloseDetails = New Button()
        lblOrderStatus = New Label()
        Label14 = New Label()
        lblOrderDate = New Label()
        Label9 = New Label()
        lblOrderStudentID = New Label()
        lblOrderStudentName = New Label()
        lblOrderPayment = New Label()
        lblOrderCashier = New Label()
        lblTransactionID = New Label()
        dgvOrderDetails = New DataGridView()
        Label6 = New Label()
        Label8 = New Label()
        Label5 = New Label()
        Label10 = New Label()
        Label11 = New Label()
        Label13 = New Label()
        btnlogout = New Button()
        cmbFilterStatus = New ComboBox()
        Label4 = New Label()
        CType(dgvKitchenOrders, ComponentModel.ISupportInitialize).BeginInit()
        pnlOrderDetails.SuspendLayout()
        CType(dgvOrderDetails, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Viner Hand ITC", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(12, 23)
        Label1.Name = "Label1"
        Label1.Size = New Size(218, 37)
        Label1.TabIndex = 4
        Label1.Text = "HUNGRY TABLE"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Viner Hand ITC", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(236, 23)
        Label2.Name = "Label2"
        Label2.Size = New Size(190, 37)
        Label2.TabIndex = 5
        Label2.Text = "- Kitchen Order"
        ' 
        ' lblPendingNum
        ' 
        lblPendingNum.AutoSize = True
        lblPendingNum.Font = New Font("Sitka Banner", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblPendingNum.Location = New Point(94, 70)
        lblPendingNum.Name = "lblPendingNum"
        lblPendingNum.Size = New Size(57, 33)
        lblPendingNum.TabIndex = 7
        lblPendingNum.Text = "+++"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Sitka Banner", 10.1999989F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(85, 21)
        Label7.Name = "Label7"
        Label7.Size = New Size(74, 24)
        Label7.TabIndex = 6
        Label7.Text = "PENDING"
        ' 
        ' dgvKitchenOrders
        ' 
        dgvKitchenOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvKitchenOrders.Location = New Point(15, 290)
        dgvKitchenOrders.Name = "dgvKitchenOrders"
        dgvKitchenOrders.RowHeadersWidth = 51
        dgvKitchenOrders.Size = New Size(1090, 422)
        dgvKitchenOrders.TabIndex = 31
        ' 
        ' pnlOrderDetails
        ' 
        pnlOrderDetails.BorderStyle = BorderStyle.Fixed3D
        pnlOrderDetails.Controls.Add(btnCompleteOrder)
        pnlOrderDetails.Controls.Add(btnStartPreparing)
        pnlOrderDetails.Controls.Add(lblOrderTotal)
        pnlOrderDetails.Controls.Add(Label12)
        pnlOrderDetails.Controls.Add(btnCloseDetails)
        pnlOrderDetails.Controls.Add(lblOrderStatus)
        pnlOrderDetails.Controls.Add(Label14)
        pnlOrderDetails.Controls.Add(lblOrderDate)
        pnlOrderDetails.Controls.Add(Label9)
        pnlOrderDetails.Controls.Add(lblOrderStudentID)
        pnlOrderDetails.Controls.Add(lblOrderStudentName)
        pnlOrderDetails.Controls.Add(lblOrderPayment)
        pnlOrderDetails.Controls.Add(lblOrderCashier)
        pnlOrderDetails.Controls.Add(lblTransactionID)
        pnlOrderDetails.Controls.Add(dgvOrderDetails)
        pnlOrderDetails.Controls.Add(Label6)
        pnlOrderDetails.Controls.Add(Label8)
        pnlOrderDetails.Controls.Add(Label5)
        pnlOrderDetails.Controls.Add(Label10)
        pnlOrderDetails.Controls.Add(Label11)
        pnlOrderDetails.Controls.Add(Label13)
        pnlOrderDetails.Location = New Point(214, 107)
        pnlOrderDetails.Name = "pnlOrderDetails"
        pnlOrderDetails.Size = New Size(639, 656)
        pnlOrderDetails.TabIndex = 32
        pnlOrderDetails.Visible = False
        ' 
        ' btnCompleteOrder
        ' 
        btnCompleteOrder.BackColor = Color.Green
        btnCompleteOrder.Font = New Font("Sitka Display Semibold", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCompleteOrder.Location = New Point(93, 589)
        btnCompleteOrder.Name = "btnCompleteOrder"
        btnCompleteOrder.Size = New Size(175, 31)
        btnCompleteOrder.TabIndex = 26
        btnCompleteOrder.Text = "COMPLETE ORDER"
        btnCompleteOrder.UseVisualStyleBackColor = False
        btnCompleteOrder.Visible = False
        ' 
        ' btnStartPreparing
        ' 
        btnStartPreparing.BackColor = Color.SteelBlue
        btnStartPreparing.Font = New Font("Sitka Display Semibold", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnStartPreparing.Location = New Point(33, 589)
        btnStartPreparing.Name = "btnStartPreparing"
        btnStartPreparing.Size = New Size(175, 31)
        btnStartPreparing.TabIndex = 25
        btnStartPreparing.Text = "START PREPARING"
        btnStartPreparing.UseVisualStyleBackColor = False
        btnStartPreparing.Visible = False
        ' 
        ' lblOrderTotal
        ' 
        lblOrderTotal.AutoSize = True
        lblOrderTotal.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblOrderTotal.Location = New Point(174, 521)
        lblOrderTotal.Name = "lblOrderTotal"
        lblOrderTotal.Size = New Size(80, 24)
        lblOrderTotal.TabIndex = 23
        lblOrderTotal.Text = "+++++++"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label12.Location = New Point(33, 521)
        Label12.Name = "Label12"
        Label12.Size = New Size(97, 24)
        Label12.TabIndex = 22
        Label12.Text = "Order Total:"
        ' 
        ' btnCloseDetails
        ' 
        btnCloseDetails.BackColor = Color.Red
        btnCloseDetails.Font = New Font("Sitka Display Semibold", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCloseDetails.Location = New Point(480, 589)
        btnCloseDetails.Name = "btnCloseDetails"
        btnCloseDetails.Size = New Size(116, 31)
        btnCloseDetails.TabIndex = 21
        btnCloseDetails.Text = "CLOSE"
        btnCloseDetails.UseVisualStyleBackColor = False
        ' 
        ' lblOrderStatus
        ' 
        lblOrderStatus.AutoSize = True
        lblOrderStatus.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblOrderStatus.ForeColor = Color.White
        lblOrderStatus.Location = New Point(458, 203)
        lblOrderStatus.Name = "lblOrderStatus"
        lblOrderStatus.Size = New Size(80, 24)
        lblOrderStatus.TabIndex = 19
        lblOrderStatus.Text = "+++++++"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label14.ForeColor = Color.White
        Label14.Location = New Point(360, 203)
        Label14.Name = "Label14"
        Label14.Size = New Size(60, 24)
        Label14.TabIndex = 18
        Label14.Text = "Status:"
        ' 
        ' lblOrderDate
        ' 
        lblOrderDate.AutoSize = True
        lblOrderDate.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblOrderDate.ForeColor = Color.White
        lblOrderDate.Location = New Point(458, 91)
        lblOrderDate.Name = "lblOrderDate"
        lblOrderDate.Size = New Size(80, 24)
        lblOrderDate.TabIndex = 15
        lblOrderDate.Text = "+++++++"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = Color.White
        Label9.Location = New Point(360, 91)
        Label9.Name = "Label9"
        Label9.Size = New Size(92, 24)
        Label9.TabIndex = 14
        Label9.Text = "Date/Time:"
        ' 
        ' lblOrderStudentID
        ' 
        lblOrderStudentID.AutoSize = True
        lblOrderStudentID.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblOrderStudentID.ForeColor = Color.White
        lblOrderStudentID.Location = New Point(219, 146)
        lblOrderStudentID.Name = "lblOrderStudentID"
        lblOrderStudentID.Size = New Size(80, 24)
        lblOrderStudentID.TabIndex = 13
        lblOrderStudentID.Text = "+++++++"
        ' 
        ' lblOrderStudentName
        ' 
        lblOrderStudentName.AutoSize = True
        lblOrderStudentName.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblOrderStudentName.ForeColor = Color.White
        lblOrderStudentName.Location = New Point(219, 203)
        lblOrderStudentName.Name = "lblOrderStudentName"
        lblOrderStudentName.Size = New Size(80, 24)
        lblOrderStudentName.TabIndex = 12
        lblOrderStudentName.Text = "+++++++"
        ' 
        ' lblOrderPayment
        ' 
        lblOrderPayment.AutoSize = True
        lblOrderPayment.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblOrderPayment.ForeColor = Color.White
        lblOrderPayment.Location = New Point(458, 148)
        lblOrderPayment.Name = "lblOrderPayment"
        lblOrderPayment.Size = New Size(80, 24)
        lblOrderPayment.TabIndex = 11
        lblOrderPayment.Text = "+++++++"
        ' 
        ' lblOrderCashier
        ' 
        lblOrderCashier.AutoSize = True
        lblOrderCashier.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblOrderCashier.ForeColor = Color.White
        lblOrderCashier.Location = New Point(219, 261)
        lblOrderCashier.Name = "lblOrderCashier"
        lblOrderCashier.Size = New Size(80, 24)
        lblOrderCashier.TabIndex = 10
        lblOrderCashier.Text = "+++++++"
        ' 
        ' lblTransactionID
        ' 
        lblTransactionID.AutoSize = True
        lblTransactionID.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTransactionID.ForeColor = Color.White
        lblTransactionID.Location = New Point(219, 91)
        lblTransactionID.Name = "lblTransactionID"
        lblTransactionID.Size = New Size(80, 24)
        lblTransactionID.TabIndex = 9
        lblTransactionID.Text = "+++++++"
        ' 
        ' dgvOrderDetails
        ' 
        dgvOrderDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvOrderDetails.Location = New Point(-1, 330)
        dgvOrderDetails.Name = "dgvOrderDetails"
        dgvOrderDetails.RowHeadersWidth = 51
        dgvOrderDetails.Size = New Size(640, 188)
        dgvOrderDetails.TabIndex = 8
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = Color.White
        Label6.Location = New Point(360, 148)
        Label6.Name = "Label6"
        Label6.Size = New Size(77, 24)
        Label6.TabIndex = 7
        Label6.Text = "Payment:"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label8.ForeColor = Color.White
        Label8.Location = New Point(78, 261)
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
        Label5.Location = New Point(73, 203)
        Label5.Name = "Label5"
        Label5.Size = New Size(116, 24)
        Label5.TabIndex = 3
        Label5.Text = "Student Name:"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.ForeColor = Color.White
        Label10.Location = New Point(73, 146)
        Label10.Name = "Label10"
        Label10.Size = New Size(91, 24)
        Label10.TabIndex = 2
        Label10.Text = "Student ID:"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.ForeColor = Color.White
        Label11.Location = New Point(73, 91)
        Label11.Name = "Label11"
        Label11.Size = New Size(98, 24)
        Label11.TabIndex = 1
        Label11.Text = "Transaction:"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Sitka Display", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label13.ForeColor = Color.Black
        Label13.Location = New Point(242, 15)
        Label13.Name = "Label13"
        Label13.Size = New Size(157, 29)
        Label13.TabIndex = 0
        Label13.Text = "ORDER DETAILS"
        ' 
        ' btnlogout
        ' 
        btnlogout.BackColor = Color.FromArgb(CByte(190), CByte(160), CByte(122))
        btnlogout.Font = New Font("Sitka Display Semibold", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnlogout.Location = New Point(32, 732)
        btnlogout.Name = "btnlogout"
        btnlogout.Size = New Size(116, 31)
        btnlogout.TabIndex = 27
        btnlogout.Text = "Logout"
        btnlogout.UseVisualStyleBackColor = False
        ' 
        ' cmbFilterStatus
        ' 
        cmbFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cmbFilterStatus.Font = New Font("Segoe UI", 10.0F)
        cmbFilterStatus.FormattingEnabled = True
        cmbFilterStatus.Location = New Point(203, 231)
        cmbFilterStatus.Name = "cmbFilterStatus"
        cmbFilterStatus.Size = New Size(151, 31)
        cmbFilterStatus.TabIndex = 33
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Sitka Subheading", 10.0F)
        Label4.ForeColor = Color.White
        Label4.Location = New Point(78, 238)
        Label4.Name = "Label4"
        Label4.Size = New Size(107, 24)
        Label4.TabIndex = 34
        Label4.Text = "Filter Status:"
        ' 
        ' kitchen
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(106), CByte(106), CByte(67))
        ClientSize = New Size(1114, 839)
        Controls.Add(Label4)
        Controls.Add(cmbFilterStatus)
        Controls.Add(btnlogout)
        Controls.Add(pnlOrderDetails)
        Controls.Add(dgvKitchenOrders)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "kitchen"
        StartPosition = FormStartPosition.CenterScreen
        Text = "k"
        CType(dgvKitchenOrders, ComponentModel.ISupportInitialize).EndInit()
        pnlOrderDetails.ResumeLayout(False)
        pnlOrderDetails.PerformLayout()
        CType(dgvOrderDetails, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Public Property pnlNumPending As Panel
    Friend WithEvents pnlTotalTransactions As Panel
    Friend WithEvents lblPendingNum As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents dgvKitchenOrders As DataGridView
    Friend WithEvents pnlOrderDetails As Panel
    Friend WithEvents btnStartPreparing As Button
    Friend WithEvents btnCloseDetails As Button
    Friend WithEvents lblOrderStatus As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents lblOrderDate As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblOrderStudentID As Label
    Friend WithEvents lblOrderStudentName As Label
    Friend WithEvents lblOrderPayment As Label
    Friend WithEvents lblOrderCashier As Label
    Friend WithEvents lblTransactionID As Label
    Friend WithEvents dgvOrderDetails As DataGridView
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents lblOrderTotal As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents btnCompleteOrder As Button
    Friend WithEvents btnlogout As Button
    Friend WithEvents cmbFilterStatus As ComboBox
    Friend WithEvents Label4 As Label
End Class
