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
        pnlSidebar.BackColor = SystemColors.AppWorkspace
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
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Viner Hand ITC", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(12, 26)
        Label1.Name = "Label1"
        Label1.Size = New Size(218, 37)
        Label1.TabIndex = 2
        Label1.Text = "HUNGRY TABLE"
        ' 
        ' btnLogout
        ' 
        btnLogout.Font = New Font("Sitka Subheading", 10.1999989F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnLogout.Location = New Point(138, 602)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(102, 34)
        btnLogout.TabIndex = 6
        btnLogout.Text = "Logout"
        btnLogout.UseVisualStyleBackColor = True
        ' 
        ' btnTransaction
        ' 
        btnTransaction.Font = New Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnTransaction.Location = New Point(0, 304)
        btnTransaction.Name = "btnTransaction"
        btnTransaction.Size = New Size(240, 56)
        btnTransaction.TabIndex = 4
        btnTransaction.Text = "Transactions"
        btnTransaction.UseVisualStyleBackColor = True
        ' 
        ' btnProducts
        ' 
        btnProducts.Font = New Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnProducts.Location = New Point(0, 242)
        btnProducts.Name = "btnProducts"
        btnProducts.Size = New Size(240, 56)
        btnProducts.TabIndex = 3
        btnProducts.Text = "Products"
        btnProducts.UseVisualStyleBackColor = True
        ' 
        ' btnStudents
        ' 
        btnStudents.Font = New Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnStudents.Location = New Point(0, 180)
        btnStudents.Name = "btnStudents"
        btnStudents.Size = New Size(240, 56)
        btnStudents.TabIndex = 2
        btnStudents.Text = "Students"
        btnStudents.UseVisualStyleBackColor = True
        ' 
        ' btnDashboard
        ' 
        btnDashboard.Font = New Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnDashboard.Location = New Point(0, 118)
        btnDashboard.Name = "btnDashboard"
        btnDashboard.Size = New Size(240, 56)
        btnDashboard.TabIndex = 1
        btnDashboard.Text = "Dashboard"
        btnDashboard.UseVisualStyleBackColor = True
        ' 
        ' pnlContent
        ' 
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
End Class
