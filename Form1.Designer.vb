<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        PictureBox1 = New PictureBox()
        Label3 = New Label()
        btnsignup = New Button()
        btnlogin = New Button()
        txtpass = New TextBox()
        txtuser = New TextBox()
        Label2 = New Label()
        Label1 = New Label()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(101, 40)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(210, 210)
        PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize
        PictureBox1.TabIndex = 13
        PictureBox1.TabStop = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Viner Hand ITC", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(94, 285)
        Label3.Name = "Label3"
        Label3.Size = New Size(218, 37)
        Label3.TabIndex = 76
        Label3.Text = "HUNGRY TABLE"
        ' 
        ' btnsignup
        ' 
        btnsignup.BackColor = Color.FromArgb(CByte(99), CByte(107), CByte(47))
        btnsignup.Font = New Font("Sitka Banner Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnsignup.ForeColor = SystemColors.ButtonHighlight
        btnsignup.Location = New Point(175, 571)
        btnsignup.Name = "btnsignup"
        btnsignup.Size = New Size(113, 36)
        btnsignup.TabIndex = 75
        btnsignup.Text = "Sign Up"
        btnsignup.UseVisualStyleBackColor = False
        ' 
        ' btnlogin
        ' 
        btnlogin.BackColor = Color.FromArgb(CByte(99), CByte(107), CByte(47))
        btnlogin.Font = New Font("Sitka Banner Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnlogin.ForeColor = SystemColors.ButtonHighlight
        btnlogin.Location = New Point(175, 509)
        btnlogin.Name = "btnlogin"
        btnlogin.Size = New Size(113, 35)
        btnlogin.TabIndex = 74
        btnlogin.Text = "Login"
        btnlogin.UseVisualStyleBackColor = False
        ' 
        ' txtpass
        ' 
        txtpass.Font = New Font("Sitka Banner Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtpass.Location = New Point(151, 433)
        txtpass.Multiline = True
        txtpass.Name = "txtpass"
        txtpass.Size = New Size(209, 34)
        txtpass.TabIndex = 73
        ' 
        ' txtuser
        ' 
        txtuser.Font = New Font("Sitka Banner Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtuser.Location = New Point(151, 355)
        txtuser.Multiline = True
        txtuser.Name = "txtuser"
        txtuser.Size = New Size(209, 34)
        txtuser.TabIndex = 72
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Sitka Banner Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(21, 436)
        Label2.Name = "Label2"
        Label2.Size = New Size(81, 26)
        Label2.TabIndex = 71
        Label2.Text = "Password"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Sitka Banner Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(21, 358)
        Label1.Name = "Label1"
        Label1.Size = New Size(85, 26)
        Label1.TabIndex = 70
        Label1.Text = "Username"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(427, 643)
        Controls.Add(Label3)
        Controls.Add(btnsignup)
        Controls.Add(btnlogin)
        Controls.Add(txtpass)
        Controls.Add(txtuser)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(PictureBox1)
        Name = "Form1"
        Text = "Form1"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnsignup As Button
    Friend WithEvents btnlogin As Button
    Friend WithEvents txtpass As TextBox
    Friend WithEvents txtuser As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label

End Class
