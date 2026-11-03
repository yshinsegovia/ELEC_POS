<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cashier
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
        Panel1 = New Panel()
        lblCashierName = New Label()
        Label1 = New Label()
        Panel2 = New Panel()
        btncWalletHistory = New Button()
        btnLogout = New Button()
        btnHistory = New Button()
        btnOrders = New Button()
        btnNewOrders = New Button()
        pnlCashierContent = New Panel()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(106), CByte(106), CByte(67))
        Panel1.Controls.Add(lblCashierName)
        Panel1.Controls.Add(Label1)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1114, 54)
        Panel1.TabIndex = 1
        ' 
        ' lblCashierName
        ' 
        lblCashierName.AutoSize = True
        lblCashierName.Font = New Font("Sitka Text Semibold", 10.7999992F, FontStyle.Bold)
        lblCashierName.ForeColor = Color.White
        lblCashierName.Location = New Point(854, 11)
        lblCashierName.Name = "lblCashierName"
        lblCashierName.Size = New Size(145, 26)
        lblCashierName.TabIndex = 22
        lblCashierName.Text = "-------------------"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Viner Hand ITC", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(12, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(218, 37)
        Label1.TabIndex = 3
        Label1.Text = "HUNGRY TABLE"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.FromArgb(CByte(106), CByte(106), CByte(67))
        Panel2.BorderStyle = BorderStyle.Fixed3D
        Panel2.Controls.Add(btncWalletHistory)
        Panel2.Controls.Add(btnLogout)
        Panel2.Controls.Add(btnHistory)
        Panel2.Controls.Add(btnOrders)
        Panel2.Controls.Add(btnNewOrders)
        Panel2.Dock = DockStyle.Left
        Panel2.Location = New Point(0, 54)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(239, 785)
        Panel2.TabIndex = 2
        ' 
        ' btncWalletHistory
        ' 
        btncWalletHistory.BackColor = Color.FromArgb(CByte(190), CByte(160), CByte(122))
        btncWalletHistory.Font = New Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btncWalletHistory.Location = New Point(-1, 279)
        btncWalletHistory.Name = "btncWalletHistory"
        btncWalletHistory.Size = New Size(240, 56)
        btncWalletHistory.TabIndex = 8
        btncWalletHistory.Text = "Wallet History"
        btncWalletHistory.UseVisualStyleBackColor = False
        ' 
        ' btnLogout
        ' 
        btnLogout.BackColor = Color.FromArgb(CByte(190), CByte(160), CByte(122))
        btnLogout.Font = New Font("Sitka Subheading", 10.1999989F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnLogout.Location = New Point(138, 704)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(102, 34)
        btnLogout.TabIndex = 7
        btnLogout.Text = "Logout"
        btnLogout.UseVisualStyleBackColor = False
        ' 
        ' btnHistory
        ' 
        btnHistory.BackColor = Color.FromArgb(CByte(190), CByte(160), CByte(122))
        btnHistory.Font = New Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnHistory.Location = New Point(-1, 200)
        btnHistory.Name = "btnHistory"
        btnHistory.Size = New Size(240, 56)
        btnHistory.TabIndex = 6
        btnHistory.Text = "History"
        btnHistory.UseVisualStyleBackColor = False
        ' 
        ' btnOrders
        ' 
        btnOrders.BackColor = Color.FromArgb(CByte(190), CByte(160), CByte(122))
        btnOrders.Font = New Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnOrders.Location = New Point(-1, 122)
        btnOrders.Name = "btnOrders"
        btnOrders.Size = New Size(240, 56)
        btnOrders.TabIndex = 4
        btnOrders.Text = "Orders"
        btnOrders.UseVisualStyleBackColor = False
        ' 
        ' btnNewOrders
        ' 
        btnNewOrders.BackColor = Color.FromArgb(CByte(190), CByte(160), CByte(122))
        btnNewOrders.Font = New Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnNewOrders.Location = New Point(0, 50)
        btnNewOrders.Name = "btnNewOrders"
        btnNewOrders.Size = New Size(240, 56)
        btnNewOrders.TabIndex = 3
        btnNewOrders.Text = "New Orders"
        btnNewOrders.UseVisualStyleBackColor = False
        ' 
        ' pnlCashierContent
        ' 
        pnlCashierContent.BackColor = Color.FromArgb(CByte(190), CByte(160), CByte(122))
        pnlCashierContent.Dock = DockStyle.Fill
        pnlCashierContent.Location = New Point(239, 54)
        pnlCashierContent.Name = "pnlCashierContent"
        pnlCashierContent.Size = New Size(875, 785)
        pnlCashierContent.TabIndex = 3
        ' 
        ' cashier
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1114, 839)
        Controls.Add(pnlCashierContent)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Name = "cashier"
        StartPosition = FormStartPosition.CenterScreen
        Text = "cashier"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btnNewOrders As Button
    Friend WithEvents btnHistory As Button
    Friend WithEvents btnOrders As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents pnlCashierContent As Panel
    Friend WithEvents btncWalletHistory As Button
    Friend WithEvents lblCashierName As Label
End Class
