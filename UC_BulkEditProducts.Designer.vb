<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_BulkEditProducts
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
        lblTitle = New Label()
        dgvBulkProducts = New DataGridView()
        btnUpdateAll = New Button()
        btnCancel = New Button()
        CType(dgvBulkProducts, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Sitka Text Semibold", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.Location = New Point(45, 39)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(186, 33)
        lblTitle.TabIndex = 21
        lblTitle.Text = "-------------------"
        ' 
        ' dgvBulkProducts
        ' 
        dgvBulkProducts.AllowUserToAddRows = False
        dgvBulkProducts.AllowUserToDeleteRows = False
        dgvBulkProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvBulkProducts.BackgroundColor = Color.DarkGray
        dgvBulkProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvBulkProducts.Location = New Point(2, 191)
        dgvBulkProducts.Name = "dgvBulkProducts"
        dgvBulkProducts.RowHeadersWidth = 51
        dgvBulkProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvBulkProducts.Size = New Size(871, 316)
        dgvBulkProducts.TabIndex = 22
        ' 
        ' btnUpdateAll
        ' 
        btnUpdateAll.BackColor = Color.FromArgb(CByte(17), CByte(94), CByte(89))
        btnUpdateAll.Font = New Font("Sitka Banner", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnUpdateAll.Location = New Point(121, 578)
        btnUpdateAll.Name = "btnUpdateAll"
        btnUpdateAll.Size = New Size(124, 41)
        btnUpdateAll.TabIndex = 23
        btnUpdateAll.Text = "UPDATE"
        btnUpdateAll.UseVisualStyleBackColor = False
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.FromArgb(CByte(17), CByte(94), CByte(89))
        btnCancel.Font = New Font("Sitka Banner", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnCancel.Location = New Point(635, 578)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(124, 41)
        btnCancel.TabIndex = 24
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' UC_BulkEditProducts
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(106), CByte(106), CByte(67))
        Controls.Add(btnCancel)
        Controls.Add(btnUpdateAll)
        Controls.Add(dgvBulkProducts)
        Controls.Add(lblTitle)
        Name = "UC_BulkEditProducts"
        Size = New Size(874, 699)
        CType(dgvBulkProducts, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents dgvBulkProducts As DataGridView
    Friend WithEvents btnUpdateAll As Button
    Friend WithEvents btnCancel As Button

End Class
