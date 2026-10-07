<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_Transaction
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
        dgvTransaction = New DataGridView()
        btnSearchTransaction = New Button()
        txtSearchProducts = New TextBox()
        btnThisMonth = New Button()
        btnThisWeek = New Button()
        btnToday = New Button()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        lblTotalSales = New Label()
        lblTotalTrascations = New Label()
        CType(dgvTransaction, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' dgvTransaction
        ' 
        dgvTransaction.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvTransaction.Location = New Point(2, 222)
        dgvTransaction.Name = "dgvTransaction"
        dgvTransaction.RowHeadersWidth = 51
        dgvTransaction.Size = New Size(871, 316)
        dgvTransaction.TabIndex = 19
        ' 
        ' btnSearchTransaction
        ' 
        btnSearchTransaction.Font = New Font("Sitka Banner", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnSearchTransaction.Location = New Point(701, 90)
        btnSearchTransaction.Name = "btnSearchTransaction"
        btnSearchTransaction.Size = New Size(124, 31)
        btnSearchTransaction.TabIndex = 18
        btnSearchTransaction.Text = "Search" & vbCrLf
        btnSearchTransaction.UseVisualStyleBackColor = True
        ' 
        ' txtSearchProducts
        ' 
        txtSearchProducts.Font = New Font("Sitka Heading", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtSearchProducts.Location = New Point(434, 90)
        txtSearchProducts.Multiline = True
        txtSearchProducts.Name = "txtSearchProducts"
        txtSearchProducts.Size = New Size(240, 31)
        txtSearchProducts.TabIndex = 17
        ' 
        ' btnThisMonth
        ' 
        btnThisMonth.Font = New Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnThisMonth.Location = New Point(360, 167)
        btnThisMonth.Name = "btnThisMonth"
        btnThisMonth.Size = New Size(156, 31)
        btnThisMonth.TabIndex = 14
        btnThisMonth.Text = "THIS MONTH"
        btnThisMonth.UseVisualStyleBackColor = True
        ' 
        ' btnThisWeek
        ' 
        btnThisWeek.Font = New Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnThisWeek.Location = New Point(185, 167)
        btnThisWeek.Name = "btnThisWeek"
        btnThisWeek.Size = New Size(156, 31)
        btnThisWeek.TabIndex = 13
        btnThisWeek.Text = "THIS WEEK"
        btnThisWeek.UseVisualStyleBackColor = True
        ' 
        ' btnToday
        ' 
        btnToday.Font = New Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnToday.Location = New Point(6, 167)
        btnToday.Name = "btnToday"
        btnToday.Size = New Size(156, 31)
        btnToday.TabIndex = 12
        btnToday.Text = "TODAY"
        btnToday.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Sitka Text Semibold", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(20, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(196, 33)
        Label1.TabIndex = 20
        Label1.Text = "TRANSACTIONS"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Sitka Subheading", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(20, 595)
        Label2.Name = "Label2"
        Label2.Size = New Size(154, 26)
        Label2.TabIndex = 21
        Label2.Text = "Total Transaction:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Sitka Subheading", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(562, 595)
        Label3.Name = "Label3"
        Label3.Size = New Size(103, 26)
        Label3.TabIndex = 22
        Label3.Text = "Total Sales:"
        ' 
        ' lblTotalSales
        ' 
        lblTotalSales.AutoSize = True
        lblTotalSales.Font = New Font("Sitka Subheading", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTotalSales.Location = New Point(671, 595)
        lblTotalSales.Name = "lblTotalSales"
        lblTotalSales.Size = New Size(84, 26)
        lblTotalSales.TabIndex = 23
        lblTotalSales.Text = "++++++"
        ' 
        ' lblTotalTrascations
        ' 
        lblTotalTrascations.AutoSize = True
        lblTotalTrascations.Font = New Font("Sitka Subheading", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTotalTrascations.Location = New Point(180, 595)
        lblTotalTrascations.Name = "lblTotalTrascations"
        lblTotalTrascations.Size = New Size(84, 26)
        lblTotalTrascations.TabIndex = 24
        lblTotalTrascations.Text = "++++++"
        ' 
        ' UC_Transaction
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(lblTotalTrascations)
        Controls.Add(lblTotalSales)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(dgvTransaction)
        Controls.Add(btnSearchTransaction)
        Controls.Add(txtSearchProducts)
        Controls.Add(btnThisMonth)
        Controls.Add(btnThisWeek)
        Controls.Add(btnToday)
        Name = "UC_Transaction"
        Size = New Size(874, 699)
        CType(dgvTransaction, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents dgvTransaction As DataGridView
    Friend WithEvents btnSearchTransaction As Button
    Friend WithEvents txtSearchProducts As TextBox
    Friend WithEvents btnThisMonth As Button
    Friend WithEvents btnThisWeek As Button
    Friend WithEvents btnToday As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblTotalSales As Label
    Friend WithEvents lblTotalTrascations As Label

End Class
