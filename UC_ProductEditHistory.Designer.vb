<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_ProductEditHistory
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
        dgvProductEditHistory = New DataGridView()
        lblTitle = New Label()
        txtSearch = New TextBox()
        btnRefresh = New Button()
        Label1 = New Label()
        CType(dgvProductEditHistory, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' dgvProductEditHistory
        ' 
        dgvProductEditHistory.AllowUserToAddRows = False
        dgvProductEditHistory.AllowUserToDeleteRows = False
        dgvProductEditHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvProductEditHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvProductEditHistory.Location = New Point(3, 275)
        dgvProductEditHistory.Name = "dgvProductEditHistory"
        dgvProductEditHistory.RowHeadersWidth = 51
        dgvProductEditHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvProductEditHistory.Size = New Size(871, 316)
        dgvProductEditHistory.TabIndex = 23
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Sitka Text Semibold", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.Location = New Point(22, 42)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(299, 33)
        lblTitle.TabIndex = 24
        lblTitle.Text = "PRODUCT EDIT HISTORY"
        ' 
        ' txtSearch
        ' 
        txtSearch.Font = New Font("Sitka Text", 10F, FontStyle.Bold)
        txtSearch.Location = New Point(96, 233)
        txtSearch.Multiline = True
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(223, 36)
        txtSearch.TabIndex = 25
        ' 
        ' btnRefresh
        ' 
        btnRefresh.BackColor = Color.FromArgb(CByte(190), CByte(160), CByte(122))
        btnRefresh.Font = New Font("Sitka Display", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRefresh.Location = New Point(708, 219)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(120, 36)
        btnRefresh.TabIndex = 27
        btnRefresh.Text = "Refresh"
        btnRefresh.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Sitka Text Semibold", 10F, FontStyle.Bold)
        Label1.Location = New Point(19, 236)
        Label1.Name = "Label1"
        Label1.Size = New Size(71, 24)
        Label1.TabIndex = 28
        Label1.Text = "Search:"
        ' 
        ' UC_ProductEditHistory
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(106), CByte(106), CByte(67))
        Controls.Add(Label1)
        Controls.Add(btnRefresh)
        Controls.Add(txtSearch)
        Controls.Add(lblTitle)
        Controls.Add(dgvProductEditHistory)
        Name = "UC_ProductEditHistory"
        Size = New Size(874, 699)
        CType(dgvProductEditHistory, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents dgvProductEditHistory As DataGridView
    Friend WithEvents lblTitle As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnRefresh As Button
    Friend WithEvents Label1 As Label

End Class
