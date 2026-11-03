<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class admin
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
        pnlSidebar = New Panel()
        btnWalletLoadRequests = New Button()
        btnProductEditHistory = New Button()
        btnWalletHistory = New Button()
        btnReports = New Button()
        Label1 = New Label()
        btnLogout = New Button()
        btnTransaction = New Button()
        btnProducts = New Button()
        btnStudents = New Button()
        btnDashboard = New Button()
        pnlContent = New Panel()
        pnlSidebar.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlSidebar
        ' 
        pnlSidebar.BackColor = Color.FromArgb(CByte(106), CByte(106), CByte(67))
        pnlSidebar.BorderStyle = BorderStyle.Fixed3D
        pnlSidebar.Controls.Add(btnWalletLoadRequests)
        pnlSidebar.Controls.Add(btnProductEditHistory)
        pnlSidebar.Controls.Add(btnWalletHistory)
        pnlSidebar.Controls.Add(btnReports)
        pnlSidebar.Controls.Add(Label1)
        pnlSidebar.Controls.Add(btnLogout)
        pnlSidebar.Controls.Add(btnTransaction)
        pnlSidebar.Controls.Add(btnProducts)
        pnlSidebar.Controls.Add(btnStudents)
        pnlSidebar.Controls.Add(btnDashboard)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Location = New Point(0, 0)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Size = New Size(240, 674)
        pnlSidebar.TabIndex = 0
        ' 
        ' btnWalletLoadRequests
        ' 
        btnWalletLoadRequests.BackColor = Color.FromArgb(CByte(190), CByte(160), CByte(122))
        btnWalletLoadRequests.Font = New Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnWalletLoadRequests.Location = New Point(3, 454)
        btnWalletLoadRequests.Name = "btnWalletLoadRequests"
        btnWalletLoadRequests.Size = New Size(240, 56)
        btnWalletLoadRequests.TabIndex = 10
        btnWalletLoadRequests.Text = "Wallet Load Requests"
        btnWalletLoadRequests.UseVisualStyleBackColor = False
        ' 
        ' btnProductEditHistory
        ' 
        btnProductEditHistory.BackColor = Color.FromArgb(CByte(190), CByte(160), CByte(122))
        btnProductEditHistory.Font = New Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnProductEditHistory.Location = New Point(0, 392)
        btnProductEditHistory.Name = "btnProductEditHistory"
        btnProductEditHistory.Size = New Size(240, 56)
        btnProductEditHistory.TabIndex = 9
        btnProductEditHistory.Text = "Product Edit History"
        btnProductEditHistory.UseVisualStyleBackColor = False
        ' 
        ' btnWalletHistory
        ' 
        btnWalletHistory.BackColor = Color.FromArgb(CByte(190), CByte(160), CByte(122))
        btnWalletHistory.Font = New Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnWalletHistory.Location = New Point(0, 330)
        btnWalletHistory.Name = "btnWalletHistory"
        btnWalletHistory.Size = New Size(240, 56)
        btnWalletHistory.TabIndex = 8
        btnWalletHistory.Text = "Wallet History"
        btnWalletHistory.UseVisualStyleBackColor = False
        ' 
        ' btnReports
        ' 
        btnReports.BackColor = Color.FromArgb(CByte(190), CByte(160), CByte(122))
        btnReports.Font = New Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnReports.Location = New Point(3, 518)
        btnReports.Name = "btnReports"
        btnReports.Size = New Size(240, 56)
        btnReports.TabIndex = 7
        btnReports.Text = "Reports"
        btnReports.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Viner Hand ITC", 13.8F, FontStyle.Bold)
        Label1.Location = New Point(12, 26)
        Label1.Name = "Label1"
        Label1.Size = New Size(218, 37)
        Label1.TabIndex = 2
        Label1.Text = "HUNGRY TABLE"
        ' 
        ' btnLogout
        ' 
        btnLogout.BackColor = Color.FromArgb(CByte(190), CByte(160), CByte(122))
        btnLogout.Font = New Font("Sitka Subheading", 10.1999989F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnLogout.Location = New Point(138, 628)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(102, 34)
        btnLogout.TabIndex = 6
        btnLogout.Text = "Logout"
        btnLogout.UseVisualStyleBackColor = False
        ' 
        ' btnTransaction
        ' 
        btnTransaction.BackColor = Color.FromArgb(CByte(190), CByte(160), CByte(122))
        btnTransaction.Font = New Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnTransaction.Location = New Point(0, 268)
        btnTransaction.Name = "btnTransaction"
        btnTransaction.Size = New Size(240, 56)
        btnTransaction.TabIndex = 4
        btnTransaction.Text = "Transactions"
        btnTransaction.UseVisualStyleBackColor = False
        ' 
        ' btnProducts
        ' 
        btnProducts.BackColor = Color.FromArgb(CByte(190), CByte(160), CByte(122))
        btnProducts.Font = New Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnProducts.Location = New Point(0, 206)
        btnProducts.Name = "btnProducts"
        btnProducts.Size = New Size(240, 56)
        btnProducts.TabIndex = 3
        btnProducts.Text = "Products"
        btnProducts.UseVisualStyleBackColor = False
        ' 
        ' btnStudents
        ' 
        btnStudents.BackColor = Color.FromArgb(CByte(190), CByte(160), CByte(122))
        btnStudents.Font = New Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnStudents.Location = New Point(0, 144)
        btnStudents.Name = "btnStudents"
        btnStudents.Size = New Size(240, 56)
        btnStudents.TabIndex = 2
        btnStudents.Text = "Students"
        btnStudents.UseVisualStyleBackColor = False
        ' 
        ' btnDashboard
        ' 
        btnDashboard.BackColor = Color.FromArgb(CByte(190), CByte(160), CByte(122))
        btnDashboard.Font = New Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnDashboard.Location = New Point(0, 82)
        btnDashboard.Name = "btnDashboard"
        btnDashboard.Size = New Size(240, 56)
        btnDashboard.TabIndex = 1
        btnDashboard.Text = "Dashboard"
        btnDashboard.UseVisualStyleBackColor = False
        ' 
        ' pnlContent
        ' 
        pnlContent.BackColor = Color.FromArgb(CByte(106), CByte(106), CByte(67))
        pnlContent.Dock = DockStyle.Fill
        pnlContent.Location = New Point(240, 0)
        pnlContent.Name = "pnlContent"
        pnlContent.Size = New Size(874, 674)
        pnlContent.TabIndex = 1
        ' 
        ' admin
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1114, 674)
        Controls.Add(pnlContent)
        Controls.Add(pnlSidebar)
        Name = "admin"
        StartPosition = FormStartPosition.CenterScreen
        Text = "admin"
        pnlSidebar.ResumeLayout(False)
        pnlSidebar.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnTransaction As Button
    Friend WithEvents btnProducts As Button
    Friend WithEvents btnStudents As Button
    Friend WithEvents btnDashboard As Button
    Friend WithEvents pnlContent As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btnReports As Button
    Friend WithEvents btnWalletHistory As Button
    Friend WithEvents btnProductEditHistory As Button
    Friend WithEvents btnWalletLoadRequests As Button
End Class
