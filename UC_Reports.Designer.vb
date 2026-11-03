<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_Reports
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
        Label1 = New Label()
        pnlTotalTransactions = New Panel()
        lblReportTotalTransaction = New Label()
        Label7 = New Label()
        pnlProductSales = New Panel()
        lblReportProductSales = New Label()
        Label3 = New Label()
        pnlCompletedOrders = New Panel()
        lblReportCompleteOrders = New Label()
        Label5 = New Label()
        pnlTotalSales = New Panel()
        Label6 = New Label()
        lblReportTotalSales = New Label()
        btnCompletedOrders = New Button()
        btnSales = New Button()
        btnTransactions = New Button()
        btnProductSales = New Button()
        lblReportTitle = New Label()
        dgvReport = New DataGridView()
        pnlTotalTransactions.SuspendLayout()
        pnlProductSales.SuspendLayout()
        pnlCompletedOrders.SuspendLayout()
        pnlTotalSales.SuspendLayout()
        CType(dgvReport, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Sitka Text Semibold", 17.8F, FontStyle.Bold)
        Label1.Location = New Point(37, 26)
        Label1.Name = "Label1"
        Label1.Size = New Size(158, 43)
        Label1.TabIndex = 3
        Label1.Text = "REPORTS"
        ' 
        ' pnlTotalTransactions
        ' 
        pnlTotalTransactions.BackColor = Color.White
        pnlTotalTransactions.Controls.Add(lblReportTotalTransaction)
        pnlTotalTransactions.Controls.Add(Label7)
        pnlTotalTransactions.Location = New Point(37, 91)
        pnlTotalTransactions.Name = "pnlTotalTransactions"
        pnlTotalTransactions.Size = New Size(163, 139)
        pnlTotalTransactions.TabIndex = 6
        ' 
        ' lblReportTotalTransaction
        ' 
        lblReportTotalTransaction.AutoSize = True
        lblReportTotalTransaction.Font = New Font("Sitka Banner", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblReportTotalTransaction.Location = New Point(53, 78)
        lblReportTotalTransaction.Name = "lblReportTotalTransaction"
        lblReportTotalTransaction.Size = New Size(57, 33)
        lblReportTotalTransaction.TabIndex = 7
        lblReportTotalTransaction.Text = "+++"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Sitka Banner", 10.1999989F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(2, 28)
        Label7.Name = "Label7"
        Label7.Size = New Size(160, 24)
        Label7.TabIndex = 6
        Label7.Text = "TOTAL TRANSACTION"
        ' 
        ' pnlProductSales
        ' 
        pnlProductSales.BackColor = Color.White
        pnlProductSales.Controls.Add(lblReportProductSales)
        pnlProductSales.Controls.Add(Label3)
        pnlProductSales.Location = New Point(669, 91)
        pnlProductSales.Name = "pnlProductSales"
        pnlProductSales.Size = New Size(163, 139)
        pnlProductSales.TabIndex = 7
        ' 
        ' lblReportProductSales
        ' 
        lblReportProductSales.AutoSize = True
        lblReportProductSales.Font = New Font("Sitka Banner", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblReportProductSales.Location = New Point(53, 78)
        lblReportProductSales.Name = "lblReportProductSales"
        lblReportProductSales.Size = New Size(57, 33)
        lblReportProductSales.TabIndex = 7
        lblReportProductSales.Text = "+++"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Sitka Banner", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(7, 24)
        Label3.Name = "Label3"
        Label3.Size = New Size(149, 29)
        Label3.TabIndex = 6
        Label3.Text = "PRODUCT SALES"
        ' 
        ' pnlCompletedOrders
        ' 
        pnlCompletedOrders.BackColor = Color.White
        pnlCompletedOrders.Controls.Add(lblReportCompleteOrders)
        pnlCompletedOrders.Controls.Add(Label5)
        pnlCompletedOrders.Location = New Point(458, 91)
        pnlCompletedOrders.Name = "pnlCompletedOrders"
        pnlCompletedOrders.Size = New Size(163, 139)
        pnlCompletedOrders.TabIndex = 8
        ' 
        ' lblReportCompleteOrders
        ' 
        lblReportCompleteOrders.AutoSize = True
        lblReportCompleteOrders.Font = New Font("Sitka Banner", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblReportCompleteOrders.Location = New Point(53, 78)
        lblReportCompleteOrders.Name = "lblReportCompleteOrders"
        lblReportCompleteOrders.Size = New Size(57, 33)
        lblReportCompleteOrders.TabIndex = 7
        lblReportCompleteOrders.Text = "+++"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Sitka Banner", 10.1999989F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(3, 24)
        Label5.Name = "Label5"
        Label5.Size = New Size(158, 24)
        Label5.TabIndex = 6
        Label5.Text = "COMPLETED ORDERS"
        ' 
        ' pnlTotalSales
        ' 
        pnlTotalSales.BackColor = Color.White
        pnlTotalSales.Controls.Add(Label6)
        pnlTotalSales.Controls.Add(lblReportTotalSales)
        pnlTotalSales.Location = New Point(243, 91)
        pnlTotalSales.Name = "pnlTotalSales"
        pnlTotalSales.Size = New Size(163, 139)
        pnlTotalSales.TabIndex = 8
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Sitka Banner", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(11, 19)
        Label6.Name = "Label6"
        Label6.Size = New Size(124, 29)
        Label6.TabIndex = 8
        Label6.Text = "TOTAL SALES"
        ' 
        ' lblReportTotalSales
        ' 
        lblReportTotalSales.AutoSize = True
        lblReportTotalSales.Font = New Font("Sitka Banner", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblReportTotalSales.Location = New Point(53, 78)
        lblReportTotalSales.Name = "lblReportTotalSales"
        lblReportTotalSales.Size = New Size(57, 33)
        lblReportTotalSales.TabIndex = 7
        lblReportTotalSales.Text = "+++"
        ' 
        ' btnCompletedOrders
        ' 
        btnCompletedOrders.BackColor = Color.FromArgb(CByte(190), CByte(160), CByte(122))
        btnCompletedOrders.Font = New Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnCompletedOrders.Location = New Point(396, 263)
        btnCompletedOrders.Name = "btnCompletedOrders"
        btnCompletedOrders.Size = New Size(201, 31)
        btnCompletedOrders.TabIndex = 13
        btnCompletedOrders.Text = "COMPLETED ORDERS"
        btnCompletedOrders.UseVisualStyleBackColor = False
        ' 
        ' btnSales
        ' 
        btnSales.BackColor = Color.FromArgb(CByte(190), CByte(160), CByte(122))
        btnSales.Font = New Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnSales.Location = New Point(212, 263)
        btnSales.Name = "btnSales"
        btnSales.Size = New Size(156, 31)
        btnSales.TabIndex = 14
        btnSales.Text = "SALES"
        btnSales.UseVisualStyleBackColor = False
        ' 
        ' btnTransactions
        ' 
        btnTransactions.BackColor = Color.FromArgb(CByte(190), CByte(160), CByte(122))
        btnTransactions.Font = New Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnTransactions.Location = New Point(35, 263)
        btnTransactions.Name = "btnTransactions"
        btnTransactions.Size = New Size(156, 31)
        btnTransactions.TabIndex = 15
        btnTransactions.Text = "TRANSACTION"
        btnTransactions.UseVisualStyleBackColor = False
        ' 
        ' btnProductSales
        ' 
        btnProductSales.BackColor = Color.FromArgb(CByte(190), CByte(160), CByte(122))
        btnProductSales.Font = New Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnProductSales.Location = New Point(621, 263)
        btnProductSales.Name = "btnProductSales"
        btnProductSales.RightToLeft = RightToLeft.Yes
        btnProductSales.Size = New Size(156, 31)
        btnProductSales.TabIndex = 16
        btnProductSales.Text = "PRODUCT SALES"
        btnProductSales.UseVisualStyleBackColor = False
        ' 
        ' lblReportTitle
        ' 
        lblReportTitle.AutoSize = True
        lblReportTitle.Font = New Font("Sitka Text Semibold", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblReportTitle.ForeColor = Color.White
        lblReportTitle.Location = New Point(37, 339)
        lblReportTitle.Name = "lblReportTitle"
        lblReportTitle.Size = New Size(227, 33)
        lblReportTitle.TabIndex = 17
        lblReportTitle.Text = "REPORTS DETAILS"
        ' 
        ' dgvReport
        ' 
        dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvReport.Location = New Point(37, 389)
        dgvReport.Name = "dgvReport"
        dgvReport.RowHeadersWidth = 51
        dgvReport.Size = New Size(793, 250)
        dgvReport.TabIndex = 18
        ' 
        ' UC_Reports
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(106), CByte(106), CByte(67))
        Controls.Add(dgvReport)
        Controls.Add(lblReportTitle)
        Controls.Add(btnProductSales)
        Controls.Add(btnTransactions)
        Controls.Add(btnSales)
        Controls.Add(btnCompletedOrders)
        Controls.Add(pnlCompletedOrders)
        Controls.Add(pnlTotalSales)
        Controls.Add(pnlProductSales)
        Controls.Add(pnlTotalTransactions)
        Controls.Add(Label1)
        Name = "UC_Reports"
        Size = New Size(874, 699)
        pnlTotalTransactions.ResumeLayout(False)
        pnlTotalTransactions.PerformLayout()
        pnlProductSales.ResumeLayout(False)
        pnlProductSales.PerformLayout()
        pnlCompletedOrders.ResumeLayout(False)
        pnlCompletedOrders.PerformLayout()
        pnlTotalSales.ResumeLayout(False)
        pnlTotalSales.PerformLayout()
        CType(dgvReport, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents pnlTotalTransactions As Panel
    Friend WithEvents lblReportTotalTransaction As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents pnlProductSales As Panel
    Friend WithEvents lblReportProductSales As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents pnlCompletedOrders As Panel
    Friend WithEvents lblReportCompleteOrders As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents pnlTotalSales As Panel
    Friend WithEvents lblReportTotalSales As Label
    Friend WithEvents btnCompletedOrders As Button
    Friend WithEvents btnSales As Button
    Friend WithEvents btnTransactions As Button
    Friend WithEvents btnProductSales As Button
    Friend WithEvents lblReportTitle As Label
    Friend WithEvents dgvReport As DataGridView
    Friend WithEvents Label6 As Label

End Class
