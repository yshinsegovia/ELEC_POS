<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_Dashboard
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
        Label2 = New Label()
        Panel1 = New Panel()
        lblTotalOrders = New Label()
        Label7 = New Label()
        Panel2 = New Panel()
        lblTotalSales = New Label()
        Label3 = New Label()
        Panel3 = New Panel()
        lblTotalStudents = New Label()
        Label4 = New Label()
        Panel5 = New Panel()
        lblLowStockCount = New Label()
        Label6 = New Label()
        dgvRecentOrders = New DataGridView()
        Label5 = New Label()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        Panel5.SuspendLayout()
        CType(dgvRecentOrders, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Sitka Text Semibold", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(13, 34)
        Label1.Name = "Label1"
        Label1.Size = New Size(214, 33)
        Label1.TabIndex = 0
        Label1.Text = "Admin Dashboard"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Sitka Text Semibold", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(612, 562)
        Label2.Name = "Label2"
        Label2.Size = New Size(0, 33)
        Label2.TabIndex = 1
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.White
        Panel1.Controls.Add(lblTotalOrders)
        Panel1.Controls.Add(Label7)
        Panel1.Location = New Point(31, 119)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(163, 168)
        Panel1.TabIndex = 5
        ' 
        ' lblTotalOrders
        ' 
        lblTotalOrders.AutoSize = True
        lblTotalOrders.Font = New Font("Sitka Banner", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTotalOrders.Location = New Point(48, 101)
        lblTotalOrders.Name = "lblTotalOrders"
        lblTotalOrders.Size = New Size(57, 33)
        lblTotalOrders.TabIndex = 7
        lblTotalOrders.Text = "+++"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Sitka Banner", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(35, 24)
        Label7.Name = "Label7"
        Label7.Size = New Size(92, 33)
        Label7.TabIndex = 6
        Label7.Text = "ORDERS"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.White
        Panel2.Controls.Add(lblTotalSales)
        Panel2.Controls.Add(Label3)
        Panel2.Location = New Point(243, 119)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(163, 168)
        Panel2.TabIndex = 7
        ' 
        ' lblTotalSales
        ' 
        lblTotalSales.AutoSize = True
        lblTotalSales.Font = New Font("Sitka Banner", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTotalSales.Location = New Point(51, 100)
        lblTotalSales.Name = "lblTotalSales"
        lblTotalSales.Size = New Size(57, 33)
        lblTotalSales.TabIndex = 8
        lblTotalSales.Text = "+++"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Sitka Banner", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(35, 24)
        Label3.Name = "Label3"
        Label3.Size = New Size(73, 33)
        Label3.TabIndex = 7
        Label3.Text = "SALES"
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.White
        Panel3.Controls.Add(lblTotalStudents)
        Panel3.Controls.Add(Label4)
        Panel3.Location = New Point(469, 119)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(163, 168)
        Panel3.TabIndex = 7
        ' 
        ' lblTotalStudents
        ' 
        lblTotalStudents.AutoSize = True
        lblTotalStudents.Font = New Font("Sitka Banner", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTotalStudents.Location = New Point(53, 100)
        lblTotalStudents.Name = "lblTotalStudents"
        lblTotalStudents.Size = New Size(57, 33)
        lblTotalStudents.TabIndex = 9
        lblTotalStudents.Text = "+++"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Sitka Banner", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(28, 27)
        Label4.Name = "Label4"
        Label4.Size = New Size(103, 29)
        Label4.TabIndex = 6
        Label4.Text = "STUDENTS"
        ' 
        ' Panel5
        ' 
        Panel5.BackColor = Color.White
        Panel5.Controls.Add(lblLowStockCount)
        Panel5.Controls.Add(Label6)
        Panel5.Location = New Point(686, 119)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(163, 168)
        Panel5.TabIndex = 9
        ' 
        ' lblLowStockCount
        ' 
        lblLowStockCount.AutoSize = True
        lblLowStockCount.Font = New Font("Sitka Banner", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblLowStockCount.Location = New Point(50, 101)
        lblLowStockCount.Name = "lblLowStockCount"
        lblLowStockCount.Size = New Size(57, 33)
        lblLowStockCount.TabIndex = 10
        lblLowStockCount.Text = "+++"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Sitka Banner", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(22, 15)
        Label6.Name = "Label6"
        Label6.Size = New Size(122, 29)
        Label6.TabIndex = 6
        Label6.Text = "LOW STOCKS"
        ' 
        ' dgvRecentOrders
        ' 
        dgvRecentOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvRecentOrders.Location = New Point(31, 364)
        dgvRecentOrders.Name = "dgvRecentOrders"
        dgvRecentOrders.RowHeadersWidth = 51
        dgvRecentOrders.Size = New Size(818, 268)
        dgvRecentOrders.TabIndex = 7
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Sitka Banner", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(359, 312)
        Label5.Name = "Label5"
        Label5.Size = New Size(153, 29)
        Label5.TabIndex = 7
        Label5.Text = "RECENT ORDERS"
        ' 
        ' UC_Dashboard
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.Control
        Controls.Add(Label5)
        Controls.Add(dgvRecentOrders)
        Controls.Add(Panel5)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "UC_Dashboard"
        Size = New Size(874, 699)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        Panel5.ResumeLayout(False)
        Panel5.PerformLayout()
        CType(dgvRecentOrders, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents dgvRecentOrders As DataGridView
    Friend WithEvents Label5 As Label
    Friend WithEvents lblTotalOrders As Label
    Friend WithEvents lblTotalSales As Label
    Friend WithEvents lblTotalStudents As Label
    Friend WithEvents lblLowStockCount As Label

End Class
