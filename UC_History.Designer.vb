<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_History
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
        btnSearchHistory = New Button()
        Label3 = New Label()
        txtSearchHistory = New TextBox()
        Label2 = New Label()
        Label11 = New Label()
        dgvOrders = New DataGridView()
        pnlHistoryDetails = New Panel()
        lblHistoryTotal = New Label()
        Label12 = New Label()
        btnCloseHistory = New Button()
        lblHistoryStatus = New Label()
        Label14 = New Label()
        lblHistoryDate = New Label()
        Label9 = New Label()
        lblHistoryStudentID = New Label()
        lblHistoryStudentName = New Label()
        lblHistoryPayment = New Label()
        lblHistoryCashier = New Label()
        lblHistoryTransactionID = New Label()
        dgvHistoryDetails = New DataGridView()
        Label6 = New Label()
        Label8 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label10 = New Label()
        Label1 = New Label()
        CType(dgvOrders, ComponentModel.ISupportInitialize).BeginInit()
        pnlHistoryDetails.SuspendLayout()
        CType(dgvHistoryDetails, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnSearchHistory
        ' 
        btnSearchHistory.Font = New Font("Sitka Heading Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSearchHistory.Location = New Point(302, 91)
        btnSearchHistory.Name = "btnSearchHistory"
        btnSearchHistory.Size = New Size(94, 29)
        btnSearchHistory.TabIndex = 14
        btnSearchHistory.Text = "Search"
        btnSearchHistory.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(18, 93)
        Label3.Name = "Label3"
        Label3.Size = New Size(63, 24)
        Label3.TabIndex = 13
        Label3.Text = "Search:"
        ' 
        ' txtSearchHistory
        ' 
        txtSearchHistory.Font = New Font("Sitka Banner Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtSearchHistory.Location = New Point(93, 86)
        txtSearchHistory.Multiline = True
        txtSearchHistory.Name = "txtSearchHistory"
        txtSearchHistory.Size = New Size(203, 34)
        txtSearchHistory.TabIndex = 12
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Sitka Display", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(323, 16)
        Label2.Name = "Label2"
        Label2.Size = New Size(106, 33)
        Label2.TabIndex = 15
        Label2.Text = "HISTORY"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Sitka Display", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.Location = New Point(18, 172)
        Label11.Name = "Label11"
        Label11.Size = New Size(182, 29)
        Label11.TabIndex = 16
        Label11.Text = "HISTORY RECORDS"
        ' 
        ' dgvOrders
        ' 
        dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvOrders.Location = New Point(0, 202)
        dgvOrders.Name = "dgvOrders"
        dgvOrders.RowHeadersWidth = 51
        dgvOrders.Size = New Size(875, 381)
        dgvOrders.TabIndex = 17
        ' 
        ' pnlHistoryDetails
        ' 
        pnlHistoryDetails.BorderStyle = BorderStyle.FixedSingle
        pnlHistoryDetails.Controls.Add(lblHistoryTotal)
        pnlHistoryDetails.Controls.Add(Label12)
        pnlHistoryDetails.Controls.Add(btnCloseHistory)
        pnlHistoryDetails.Controls.Add(lblHistoryStatus)
        pnlHistoryDetails.Controls.Add(Label14)
        pnlHistoryDetails.Controls.Add(lblHistoryDate)
        pnlHistoryDetails.Controls.Add(Label9)
        pnlHistoryDetails.Controls.Add(lblHistoryStudentID)
        pnlHistoryDetails.Controls.Add(lblHistoryStudentName)
        pnlHistoryDetails.Controls.Add(lblHistoryPayment)
        pnlHistoryDetails.Controls.Add(lblHistoryCashier)
        pnlHistoryDetails.Controls.Add(lblHistoryTransactionID)
        pnlHistoryDetails.Controls.Add(dgvHistoryDetails)
        pnlHistoryDetails.Controls.Add(Label6)
        pnlHistoryDetails.Controls.Add(Label8)
        pnlHistoryDetails.Controls.Add(Label5)
        pnlHistoryDetails.Controls.Add(Label4)
        pnlHistoryDetails.Controls.Add(Label10)
        pnlHistoryDetails.Controls.Add(Label1)
        pnlHistoryDetails.Location = New Point(123, 52)
        pnlHistoryDetails.Name = "pnlHistoryDetails"
        pnlHistoryDetails.Size = New Size(640, 648)
        pnlHistoryDetails.TabIndex = 19
        pnlHistoryDetails.Visible = False
        ' 
        ' lblHistoryTotal
        ' 
        lblHistoryTotal.AutoSize = True
        lblHistoryTotal.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblHistoryTotal.Location = New Point(467, 539)
        lblHistoryTotal.Name = "lblHistoryTotal"
        lblHistoryTotal.Size = New Size(80, 24)
        lblHistoryTotal.TabIndex = 23
        lblHistoryTotal.Text = "+++++++"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label12.Location = New Point(326, 539)
        Label12.Name = "Label12"
        Label12.Size = New Size(97, 24)
        Label12.TabIndex = 22
        Label12.Text = "Order Total:"
        ' 
        ' btnCloseHistory
        ' 
        btnCloseHistory.Font = New Font("Sitka Display Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCloseHistory.Location = New Point(454, 587)
        btnCloseHistory.Name = "btnCloseHistory"
        btnCloseHistory.Size = New Size(116, 31)
        btnCloseHistory.TabIndex = 21
        btnCloseHistory.Text = "CLOSE"
        btnCloseHistory.UseVisualStyleBackColor = True
        ' 
        ' lblHistoryStatus
        ' 
        lblHistoryStatus.AutoSize = True
        lblHistoryStatus.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblHistoryStatus.Location = New Point(454, 207)
        lblHistoryStatus.Name = "lblHistoryStatus"
        lblHistoryStatus.Size = New Size(80, 24)
        lblHistoryStatus.TabIndex = 19
        lblHistoryStatus.Text = "+++++++"
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
        ' lblHistoryDate
        ' 
        lblHistoryDate.AutoSize = True
        lblHistoryDate.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblHistoryDate.Location = New Point(454, 95)
        lblHistoryDate.Name = "lblHistoryDate"
        lblHistoryDate.Size = New Size(80, 24)
        lblHistoryDate.TabIndex = 15
        lblHistoryDate.Text = "+++++++"
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
        ' lblHistoryStudentID
        ' 
        lblHistoryStudentID.AutoSize = True
        lblHistoryStudentID.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblHistoryStudentID.Location = New Point(174, 150)
        lblHistoryStudentID.Name = "lblHistoryStudentID"
        lblHistoryStudentID.Size = New Size(80, 24)
        lblHistoryStudentID.TabIndex = 13
        lblHistoryStudentID.Text = "+++++++"
        ' 
        ' lblHistoryStudentName
        ' 
        lblHistoryStudentName.AutoSize = True
        lblHistoryStudentName.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblHistoryStudentName.Location = New Point(174, 207)
        lblHistoryStudentName.Name = "lblHistoryStudentName"
        lblHistoryStudentName.Size = New Size(80, 24)
        lblHistoryStudentName.TabIndex = 12
        lblHistoryStudentName.Text = "+++++++"
        ' 
        ' lblHistoryPayment
        ' 
        lblHistoryPayment.AutoSize = True
        lblHistoryPayment.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblHistoryPayment.Location = New Point(454, 152)
        lblHistoryPayment.Name = "lblHistoryPayment"
        lblHistoryPayment.Size = New Size(80, 24)
        lblHistoryPayment.TabIndex = 11
        lblHistoryPayment.Text = "+++++++"
        ' 
        ' lblHistoryCashier
        ' 
        lblHistoryCashier.AutoSize = True
        lblHistoryCashier.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblHistoryCashier.Location = New Point(174, 265)
        lblHistoryCashier.Name = "lblHistoryCashier"
        lblHistoryCashier.Size = New Size(80, 24)
        lblHistoryCashier.TabIndex = 10
        lblHistoryCashier.Text = "+++++++"
        ' 
        ' lblHistoryTransactionID
        ' 
        lblHistoryTransactionID.AutoSize = True
        lblHistoryTransactionID.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblHistoryTransactionID.Location = New Point(174, 95)
        lblHistoryTransactionID.Name = "lblHistoryTransactionID"
        lblHistoryTransactionID.Size = New Size(80, 24)
        lblHistoryTransactionID.TabIndex = 9
        lblHistoryTransactionID.Text = "+++++++"
        ' 
        ' dgvHistoryDetails
        ' 
        dgvHistoryDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvHistoryDetails.Location = New Point(-1, 330)
        dgvHistoryDetails.Name = "dgvHistoryDetails"
        dgvHistoryDetails.RowHeadersWidth = 51
        dgvHistoryDetails.Size = New Size(640, 188)
        dgvHistoryDetails.TabIndex = 8
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
        Label10.Size = New Size(71, 24)
        Label10.TabIndex = 1
        Label10.Text = "Order #:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Sitka Display", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(242, 15)
        Label1.Name = "Label1"
        Label1.Size = New Size(157, 29)
        Label1.TabIndex = 0
        Label1.Text = "ORDER DETAILS"
        ' 
        ' UC_History
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(pnlHistoryDetails)
        Controls.Add(dgvOrders)
        Controls.Add(Label11)
        Controls.Add(Label2)
        Controls.Add(btnSearchHistory)
        Controls.Add(Label3)
        Controls.Add(txtSearchHistory)
        Name = "UC_History"
        Size = New Size(875, 785)
        CType(dgvOrders, ComponentModel.ISupportInitialize).EndInit()
        pnlHistoryDetails.ResumeLayout(False)
        pnlHistoryDetails.PerformLayout()
        CType(dgvHistoryDetails, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnSearchHistory As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents txtSearchHistory As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents dgvOrders As DataGridView
    Friend WithEvents pnlHistoryDetails As Panel
    Friend WithEvents lblHistoryTotal As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents btnCloseHistory As Button
    Friend WithEvents lblHistoryStatus As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents lblHistoryDate As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblHistoryStudentID As Label
    Friend WithEvents lblHistoryStudentName As Label
    Friend WithEvents lblHistoryPayment As Label
    Friend WithEvents lblHistoryCashier As Label
    Friend WithEvents lblHistoryTransactionID As Label
    Friend WithEvents dgvHistoryDetails As DataGridView
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label1 As Label

End Class
