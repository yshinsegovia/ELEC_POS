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
        btnSearchOrder = New Button()
        Label3 = New Label()
        txtSearchOrders = New TextBox()
        Label2 = New Label()
        btnPreparinOrders = New Button()
        btnPendingOrders = New Button()
        btnAllOrders = New Button()
        btnCompletedOrders = New Button()
        dgvOrders = New DataGridView()
        Label1 = New Label()
        pnlOrderDetails = New Panel()
        btnCompleteOrder = New Button()
        lblOrderTotal = New Label()
        Label12 = New Label()
        btnCloseOrder = New Button()
        btnStartPreparing = New Button()
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
        CType(dgvOrders, ComponentModel.ISupportInitialize).BeginInit()
        pnlOrderDetails.SuspendLayout()
        CType(dgvOrderDetails, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnSearchOrder
        ' 
        btnSearchOrder.Font = New Font("Sitka Heading Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSearchOrder.Location = New Point(301, 133)
        btnSearchOrder.Name = "btnSearchOrder"
        btnSearchOrder.Size = New Size(94, 29)
        btnSearchOrder.TabIndex = 11
        btnSearchOrder.Text = "Search"
        btnSearchOrder.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(17, 135)
        Label3.Name = "Label3"
        Label3.Size = New Size(63, 24)
        Label3.TabIndex = 10
        Label3.Text = "Search:"
        ' 
        ' txtSearchOrders
        ' 
        txtSearchOrders.Font = New Font("Sitka Banner Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtSearchOrders.Location = New Point(92, 128)
        txtSearchOrders.Multiline = True
        txtSearchOrders.Name = "txtSearchOrders"
        txtSearchOrders.Size = New Size(203, 34)
        txtSearchOrders.TabIndex = 9
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Sitka Display", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(358, 21)
        Label2.Name = "Label2"
        Label2.Size = New Size(98, 33)
        Label2.TabIndex = 8
        Label2.Text = "ORDERS"
        ' 
        ' btnPreparinOrders
        ' 
        btnPreparinOrders.Font = New Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnPreparinOrders.Location = New Point(427, 220)
        btnPreparinOrders.Name = "btnPreparinOrders"
        btnPreparinOrders.Size = New Size(156, 31)
        btnPreparinOrders.TabIndex = 14
        btnPreparinOrders.Text = "PREPARING"
        btnPreparinOrders.UseVisualStyleBackColor = True
        ' 
        ' btnPendingOrders
        ' 
        btnPendingOrders.Font = New Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnPendingOrders.Location = New Point(252, 220)
        btnPendingOrders.Name = "btnPendingOrders"
        btnPendingOrders.Size = New Size(156, 31)
        btnPendingOrders.TabIndex = 13
        btnPendingOrders.Text = "PENDING"
        btnPendingOrders.UseVisualStyleBackColor = True
        ' 
        ' btnAllOrders
        ' 
        btnAllOrders.Font = New Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnAllOrders.Location = New Point(73, 220)
        btnAllOrders.Name = "btnAllOrders"
        btnAllOrders.Size = New Size(156, 31)
        btnAllOrders.TabIndex = 12
        btnAllOrders.Text = "ALL"
        btnAllOrders.UseVisualStyleBackColor = True
        ' 
        ' btnCompletedOrders
        ' 
        btnCompletedOrders.Font = New Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnCompletedOrders.Location = New Point(609, 220)
        btnCompletedOrders.Name = "btnCompletedOrders"
        btnCompletedOrders.Size = New Size(156, 31)
        btnCompletedOrders.TabIndex = 15
        btnCompletedOrders.Text = "COMPLETED"
        btnCompletedOrders.UseVisualStyleBackColor = True
        ' 
        ' dgvOrders
        ' 
        dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvOrders.Location = New Point(0, 322)
        dgvOrders.Name = "dgvOrders"
        dgvOrders.RowHeadersWidth = 51
        dgvOrders.Size = New Size(875, 381)
        dgvOrders.TabIndex = 16
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Sitka Display", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(351, 293)
        Label1.Name = "Label1"
        Label1.Size = New Size(148, 26)
        Label1.TabIndex = 17
        Label1.Text = "ORDERS RECORD"
        ' 
        ' pnlOrderDetails
        ' 
        pnlOrderDetails.BorderStyle = BorderStyle.FixedSingle
        pnlOrderDetails.Controls.Add(btnCompleteOrder)
        pnlOrderDetails.Controls.Add(lblOrderTotal)
        pnlOrderDetails.Controls.Add(Label12)
        pnlOrderDetails.Controls.Add(btnCloseOrder)
        pnlOrderDetails.Controls.Add(btnStartPreparing)
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
        pnlOrderDetails.Location = New Point(125, 90)
        pnlOrderDetails.Name = "pnlOrderDetails"
        pnlOrderDetails.Size = New Size(640, 648)
        pnlOrderDetails.TabIndex = 18
        pnlOrderDetails.Visible = False
        ' 
        ' btnCompleteOrder
        ' 
        btnCompleteOrder.Font = New Font("Sitka Display Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCompleteOrder.Location = New Point(258, 589)
        btnCompleteOrder.Name = "btnCompleteOrder"
        btnCompleteOrder.Size = New Size(175, 31)
        btnCompleteOrder.TabIndex = 24
        btnCompleteOrder.Text = "COMPLETE ORDER"
        btnCompleteOrder.UseVisualStyleBackColor = True
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
        ' btnCloseOrder
        ' 
        btnCloseOrder.Font = New Font("Sitka Display Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCloseOrder.Location = New Point(480, 589)
        btnCloseOrder.Name = "btnCloseOrder"
        btnCloseOrder.Size = New Size(116, 31)
        btnCloseOrder.TabIndex = 21
        btnCloseOrder.Text = "CLOSE"
        btnCloseOrder.UseVisualStyleBackColor = True
        ' 
        ' btnStartPreparing
        ' 
        btnStartPreparing.Font = New Font("Sitka Display Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnStartPreparing.Location = New Point(26, 589)
        btnStartPreparing.Name = "btnStartPreparing"
        btnStartPreparing.Size = New Size(175, 31)
        btnStartPreparing.TabIndex = 20
        btnStartPreparing.Text = "START PREPARING"
        btnStartPreparing.UseVisualStyleBackColor = True
        ' 
        ' lblOrderStatus
        ' 
        lblOrderStatus.AutoSize = True
        lblOrderStatus.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
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
        Label11.Location = New Point(242, 15)
        Label11.Name = "Label11"
        Label11.Size = New Size(157, 29)
        Label11.TabIndex = 0
        Label11.Text = "ORDER DETAILS"
        ' 
        ' UC_Orders
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(pnlOrderDetails)
        Controls.Add(btnCompletedOrders)
        Controls.Add(Label1)
        Controls.Add(btnAllOrders)
        Controls.Add(btnSearchOrder)
        Controls.Add(dgvOrders)
        Controls.Add(Label3)
        Controls.Add(btnPendingOrders)
        Controls.Add(txtSearchOrders)
        Controls.Add(btnPreparinOrders)
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

    Friend WithEvents btnSearchOrder As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents txtSearchOrders As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnPreparinOrders As Button
    Friend WithEvents btnPendingOrders As Button
    Friend WithEvents btnAllOrders As Button
    Friend WithEvents btnCompletedOrders As Button
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
    Friend WithEvents btnStartPreparing As Button
    Friend WithEvents btnCloseOrder As Button
    Friend WithEvents lblOrderTotal As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents btnCompleteOrder As Button

End Class
