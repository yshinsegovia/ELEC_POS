<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_WalletHistory
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
        Label2 = New Label()
        txtStudentID = New TextBox()
        btnSearch = New Button()
        Label1 = New Label()
        dgvWalletHistory = New DataGridView()
        Label3 = New Label()
        lblWalletBalance = New Label()
        lblStudentName = New Label()
        CType(dgvWalletHistory, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Sitka Display", 17.8F, FontStyle.Bold)
        Label2.Location = New Point(21, 23)
        Label2.Name = "Label2"
        Label2.Size = New Size(258, 43)
        Label2.TabIndex = 16
        Label2.Text = "WALLET HISTORY"
        ' 
        ' txtStudentID
        ' 
        txtStudentID.Font = New Font("Sitka Text", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtStudentID.Location = New Point(21, 128)
        txtStudentID.Multiline = True
        txtStudentID.Name = "txtStudentID"
        txtStudentID.Size = New Size(265, 47)
        txtStudentID.TabIndex = 17
        ' 
        ' btnSearch
        ' 
        btnSearch.BackColor = Color.FromArgb(CByte(190), CByte(160), CByte(122))
        btnSearch.Font = New Font("Sitka Display", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSearch.Location = New Point(320, 139)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(120, 36)
        btnSearch.TabIndex = 18
        btnSearch.Text = "Search"
        btnSearch.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Sitka Banner Semibold", 11F, FontStyle.Bold)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(21, 97)
        Label1.Name = "Label1"
        Label1.Size = New Size(94, 28)
        Label1.TabIndex = 19
        Label1.Text = "Student ID"
        ' 
        ' dgvWalletHistory
        ' 
        dgvWalletHistory.AllowUserToAddRows = False
        dgvWalletHistory.AllowUserToDeleteRows = False
        dgvWalletHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvWalletHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvWalletHistory.Location = New Point(3, 321)
        dgvWalletHistory.MultiSelect = False
        dgvWalletHistory.Name = "dgvWalletHistory"
        dgvWalletHistory.ReadOnly = True
        dgvWalletHistory.RowHeadersWidth = 51
        dgvWalletHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvWalletHistory.Size = New Size(869, 284)
        dgvWalletHistory.TabIndex = 20
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Sitka Banner Semibold", 15F, FontStyle.Bold)
        Label3.ForeColor = Color.White
        Label3.Location = New Point(21, 280)
        Label3.Name = "Label3"
        Label3.Size = New Size(200, 36)
        Label3.TabIndex = 21
        Label3.Text = "Wallet Transaction"
        ' 
        ' lblWalletBalance
        ' 
        lblWalletBalance.AutoSize = True
        lblWalletBalance.Font = New Font("Sitka Banner Semibold", 15F, FontStyle.Bold)
        lblWalletBalance.ForeColor = Color.White
        lblWalletBalance.Location = New Point(617, 280)
        lblWalletBalance.Name = "lblWalletBalance"
        lblWalletBalance.Size = New Size(200, 36)
        lblWalletBalance.TabIndex = 23
        lblWalletBalance.Text = "Wallet Transaction"
        ' 
        ' lblStudentName
        ' 
        lblStudentName.AutoSize = True
        lblStudentName.Font = New Font("Sitka Banner Semibold", 12F, FontStyle.Bold)
        lblStudentName.ForeColor = Color.White
        lblStudentName.Location = New Point(572, 242)
        lblStudentName.Name = "lblStudentName"
        lblStudentName.Size = New Size(133, 29)
        lblStudentName.TabIndex = 24
        lblStudentName.Text = "Student Name:"
        ' 
        ' UC_WalletHistory
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(106), CByte(106), CByte(67))
        Controls.Add(lblStudentName)
        Controls.Add(lblWalletBalance)
        Controls.Add(Label3)
        Controls.Add(dgvWalletHistory)
        Controls.Add(Label1)
        Controls.Add(btnSearch)
        Controls.Add(txtStudentID)
        Controls.Add(Label2)
        Name = "UC_WalletHistory"
        Size = New Size(875, 785)
        CType(dgvWalletHistory, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents txtStudentID As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvWalletHistory As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents lblWalletBalance As Label
    Friend WithEvents lblStudentName As Label

End Class
