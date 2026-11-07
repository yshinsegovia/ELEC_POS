<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_Orders
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
        Label3 = New Label()
        txtSearchOrders = New TextBox()
        Label2 = New Label()
        dgvOrders = New DataGridView()
        Label1 = New Label()
        pnlOrderDetails = New Panel()
        btnCancelOrder = New Button()
        lblOrderTotal = New Label()
        Label12 = New Label()
        btnCloseOrder = New Button()
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
        Label4 = New Label()
        Label10 = New Label()
        Label11 = New Label()
        cmbFilterStatus = New ComboBox()
        CType(dgvOrders, ComponentModel.ISupportInitialize).BeginInit()
        pnlOrderDetails.SuspendLayout()
        CType(dgvOrderDetails, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.White
        Label3.Location = New Point(559, 180)
        Label3.Name = "Label3"
        Label3.Size = New Size(63, 24)
        Label3.TabIndex = 10
        Label3.Text = "Search:"
        ' 
        ' txtSearchOrders
        ' 
        txtSearchOrders.Font = New Font("Sitka Banner Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtSearchOrders.Location = New Point(634, 173)
        txtSearchOrders.Multiline = True
        txtSearchOrders.Name = "txtSearchOrders"
        txtSearchOrders.Size = New Size(203, 34)
        txtSearchOrders.TabIndex = 9
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Sitka Display", 17.8F, FontStyle.Bold)
        Label2.Location = New Point(358, 21)
        Label2.Name = "Label2"
        Label2.Size = New Size(131, 43)
        Label2.TabIndex = 8
        Label2.Text = "ORDERS"
        ' 
        ' dgvOrders
        ' 
        dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvOrders.Location = New Point(-1, 274)
        dgvOrders.Name = "dgvOrders"
        dgvOrders.RowHeadersWidth = 51
        dgvOrders.Size = New Size(875, 381)
        dgvOrders.TabIndex = 16
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Sitka Display", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(350, 245)
        Label1.Name = "Label1"
        Label1.Size = New Size(148, 26)
        Label1.TabIndex = 17
        Label1.Text = "ORDERS RECORD"
        ' 
        ' pnlOrderDetails
        ' 
        pnlOrderDetails.BorderStyle = BorderStyle.Fixed3D
        pnlOrderDetails.Controls.Add(btnCancelOrder)
        pnlOrderDetails.Controls.Add(lblOrderTotal)
        pnlOrderDetails.Controls.Add(Label12)
        pnlOrderDetails.Controls.Add(btnCloseOrder)
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
        pnlOrderDetails.Controls.Add(Label4)
        pnlOrderDetails.Controls.Add(Label10)
        pnlOrderDetails.Controls.Add(Label11)
        pnlOrderDetails.Location = New Point(122, 67)
        pnlOrderDetails.Name = "pnlOrderDetails"
        pnlOrderDetails.Size = New Size(640, 648)
        pnlOrderDetails.TabIndex = 18
        pnlOrderDetails.Visible = False
        ' 
        ' btnCancelOrder
        ' 
        btnCancelOrder.BackColor = Color.Red
        btnCancelOrder.Font = New Font("Sitka Display Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCancelOrder.Location = New Point(33, 589)
        btnCancelOrder.Name = "btnCancelOrder"
        btnCancelOrder.Size = New Size(175, 31)
        btnCancelOrder.TabIndex = 25
        btnCancelOrder.Text = "CANCEL ORDER"
        btnCancelOrder.UseVisualStyleBackColor = False
        btnCancelOrder.Visible = False
        ' 
        ' lblOrderTotal
        ' 
        lblOrderTotal.AutoSize = True
        lblOrderTotal.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblOrderTotal.ForeColor = Color.White
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
        Label12.ForeColor = Color.White
        Label12.Location = New Point(33, 521)
        Label12.Name = "Label12"
        Label12.Size = New Size(97, 24)
        Label12.TabIndex = 22
        Label12.Text = "Order Total:"
        ' 
        ' btnCloseOrder
        ' 
        btnCloseOrder.BackColor = Color.FromArgb(CByte(190), CByte(160), CByte(122))
        btnCloseOrder.Font = New Font("Sitka Display Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCloseOrder.Location = New Point(480, 589)
        btnCloseOrder.Name = "btnCloseOrder"
        btnCloseOrder.Size = New Size(116, 31)
        btnCloseOrder.TabIndex = 21
        btnCloseOrder.Text = "CLOSE"
        btnCloseOrder.UseVisualStyleBackColor = False
        ' 
        ' lblOrderStatus
        ' 
        lblOrderStatus.AutoSize = True
        lblOrderStatus.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblOrderStatus.ForeColor = Color.White
        lblOrderStatus.Location = New Point(454, 207)
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
        Label14.Location = New Point(356, 207)
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
        lblOrderDate.Location = New Point(454, 95)
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
        Label9.Location = New Point(356, 95)
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
        lblOrderStudentID.Location = New Point(174, 150)
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
        lblOrderStudentName.Location = New Point(174, 207)
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
        lblOrderPayment.Location = New Point(454, 152)
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
        lblOrderCashier.Location = New Point(174, 265)
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
        lblTransactionID.Location = New Point(174, 95)
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
        Label6.Location = New Point(356, 152)
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
        Label8.Location = New Point(33, 265)
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
        Label5.Location = New Point(28, 207)
        Label5.Name = "Label5"
        Label5.Size = New Size(116, 24)
        Label5.TabIndex = 3
        Label5.Text = "Student Name:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.White
        Label4.Location = New Point(28, 150)
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
        Label10.Location = New Point(28, 95)
        Label10.Name = "Label10"
        Label10.Size = New Size(98, 24)
        Label10.TabIndex = 1
        Label10.Text = "Transaction:"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Sitka Display", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.ForeColor = Color.White
        Label11.Location = New Point(242, 15)
        Label11.Name = "Label11"
        Label11.Size = New Size(157, 29)
        Label11.TabIndex = 0
        Label11.Text = "ORDER DETAILS"
        ' 
        ' cmbFilterStatus
        ' 
        cmbFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cmbFilterStatus.Font = New Font("Segoe UI", 10F)
        cmbFilterStatus.FormattingEnabled = True
        cmbFilterStatus.Location = New Point(44, 176)
        cmbFilterStatus.Name = "cmbFilterStatus"
        cmbFilterStatus.Size = New Size(151, 31)
        cmbFilterStatus.TabIndex = 20
        ' 
        ' UC_Orders
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(106), CByte(106), CByte(67))
        Controls.Add(cmbFilterStatus)
        Controls.Add(pnlOrderDetails)
        Controls.Add(Label1)
        Controls.Add(dgvOrders)
        Controls.Add(Label3)
        Controls.Add(txtSearchOrders)
        Controls.Add(Label2)
        Name = "UC_Orders"
        Size = New Size(875, 785)
        CType(dgvOrders, ComponentModel.ISupportInitialize).EndInit()
        pnlOrderDetails.ResumeLayout(False)
        pnlOrderDetails.PerformLayout()
        CType(dgvOrderDetails, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents txtSearchOrders As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents dgvOrders As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlOrderDetails As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents dgvOrderDetails As DataGridView
    Friend WithEvents lblOrderStudentID As Label
    Friend WithEvents lblOrderStudentName As Label
    Friend WithEvents lblOrderPayment As Label
    Friend WithEvents lblOrderCashier As Label
    Friend WithEvents lblTransactionID As Label
    Friend WithEvents lblOrderStatus As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents lblOrderDate As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents btnCloseOrder As Button
    Friend WithEvents lblOrderTotal As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents btnCancelOrder As Button
    Friend WithEvents cmbFilterStatus As ComboBox

End Class
