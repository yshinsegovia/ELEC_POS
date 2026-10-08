<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_Students
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
        dgvStudentList = New DataGridView()
        Label1 = New Label()
        btnViewDetails = New Button()
        txtSearchStudents = New TextBox()
        btnSearchStudents = New Button()
        btnAddStudents = New Button()
        pnlAddStudent = New Panel()
        cmbYearlvl = New ComboBox()
        cmbCourse = New ComboBox()
        btnCancel = New Button()
        btnSave = New Button()
        txtUsername = New TextBox()
        txtLastname = New TextBox()
        txtEmail = New TextBox()
        txtFirstname = New TextBox()
        txtStudentID = New TextBox()
        Label9 = New Label()
        Label8 = New Label()
        Label7 = New Label()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        CType(dgvStudentList, ComponentModel.ISupportInitialize).BeginInit()
        pnlAddStudent.SuspendLayout()
        SuspendLayout()
        ' 
        ' dgvStudentList
        ' 
        dgvStudentList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvStudentList.Location = New Point(2, 197)
        dgvStudentList.Name = "dgvStudentList"
        dgvStudentList.RowHeadersWidth = 51
        dgvStudentList.Size = New Size(871, 390)
        dgvStudentList.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Sitka Text Semibold", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(52, 38)
        Label1.Name = "Label1"
        Label1.Size = New Size(112, 33)
        Label1.TabIndex = 1
        Label1.Text = "Students"
        ' 
        ' btnViewDetails
        ' 
        btnViewDetails.Font = New Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnViewDetails.Location = New Point(303, 603)
        btnViewDetails.Name = "btnViewDetails"
        btnViewDetails.Size = New Size(218, 32)
        btnViewDetails.TabIndex = 2
        btnViewDetails.Text = "View Details"
        btnViewDetails.UseVisualStyleBackColor = True
        ' 
        ' txtSearchStudents
        ' 
        txtSearchStudents.Font = New Font("Sitka Heading", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtSearchStudents.Location = New Point(21, 140)
        txtSearchStudents.Multiline = True
        txtSearchStudents.Name = "txtSearchStudents"
        txtSearchStudents.Size = New Size(240, 40)
        txtSearchStudents.TabIndex = 3
        ' 
        ' btnSearchStudents
        ' 
        btnSearchStudents.Font = New Font("Sitka Banner", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnSearchStudents.Location = New Point(288, 144)
        btnSearchStudents.Name = "btnSearchStudents"
        btnSearchStudents.Size = New Size(143, 36)
        btnSearchStudents.TabIndex = 4
        btnSearchStudents.Text = "Search" & vbCrLf
        btnSearchStudents.UseVisualStyleBackColor = True
        ' 
        ' btnAddStudents
        ' 
        btnAddStudents.Font = New Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnAddStudents.Location = New Point(648, 140)
        btnAddStudents.Name = "btnAddStudents"
        btnAddStudents.Size = New Size(196, 40)
        btnAddStudents.TabIndex = 5
        btnAddStudents.Text = "+ Add Students"
        btnAddStudents.UseVisualStyleBackColor = True
        ' 
        ' pnlAddStudent
        ' 
        pnlAddStudent.BorderStyle = BorderStyle.FixedSingle
        pnlAddStudent.Controls.Add(cmbYearlvl)
        pnlAddStudent.Controls.Add(cmbCourse)
        pnlAddStudent.Controls.Add(btnCancel)
        pnlAddStudent.Controls.Add(btnSave)
        pnlAddStudent.Controls.Add(txtUsername)
        pnlAddStudent.Controls.Add(txtLastname)
        pnlAddStudent.Controls.Add(txtEmail)
        pnlAddStudent.Controls.Add(txtFirstname)
        pnlAddStudent.Controls.Add(txtStudentID)
        pnlAddStudent.Controls.Add(Label9)
        pnlAddStudent.Controls.Add(Label8)
        pnlAddStudent.Controls.Add(Label7)
        pnlAddStudent.Controls.Add(Label6)
        pnlAddStudent.Controls.Add(Label5)
        pnlAddStudent.Controls.Add(Label4)
        pnlAddStudent.Controls.Add(Label3)
        pnlAddStudent.Controls.Add(Label2)
        pnlAddStudent.Location = New Point(21, 144)
        pnlAddStudent.Name = "pnlAddStudent"
        pnlAddStudent.Size = New Size(823, 372)
        pnlAddStudent.TabIndex = 6
        pnlAddStudent.Visible = False
        ' 
        ' cmbYearlvl
        ' 
        cmbYearlvl.Font = New Font("Sitka Display Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        cmbYearlvl.FormattingEnabled = True
        cmbYearlvl.Items.AddRange(New Object() {"1st", "2nd", "3rd", "4th"})
        cmbYearlvl.Location = New Point(551, 249)
        cmbYearlvl.Name = "cmbYearlvl"
        cmbYearlvl.Size = New Size(151, 29)
        cmbYearlvl.TabIndex = 17
        ' 
        ' cmbCourse
        ' 
        cmbCourse.Font = New Font("Sitka Display Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        cmbCourse.FormattingEnabled = True
        cmbCourse.Items.AddRange(New Object() {"BSIT", "BSHM", "BSED", "BSBA"})
        cmbCourse.Location = New Point(148, 250)
        cmbCourse.Name = "cmbCourse"
        cmbCourse.Size = New Size(151, 29)
        cmbCourse.TabIndex = 16
        ' 
        ' btnCancel
        ' 
        btnCancel.Font = New Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnCancel.Location = New Point(473, 316)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(151, 32)
        btnCancel.TabIndex = 15
        btnCancel.Text = "CANCEL"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' btnSave
        ' 
        btnSave.Font = New Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnSave.Location = New Point(199, 316)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(151, 32)
        btnSave.TabIndex = 7
        btnSave.Text = "SAVE"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' txtUsername
        ' 
        txtUsername.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtUsername.Location = New Point(549, 65)
        txtUsername.Multiline = True
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(243, 34)
        txtUsername.TabIndex = 14
        ' 
        ' txtLastname
        ' 
        txtLastname.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtLastname.Location = New Point(551, 120)
        txtLastname.Multiline = True
        txtLastname.Name = "txtLastname"
        txtLastname.Size = New Size(243, 34)
        txtLastname.TabIndex = 12
        ' 
        ' txtEmail
        ' 
        txtEmail.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtEmail.Location = New Point(148, 181)
        txtEmail.Multiline = True
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(325, 34)
        txtEmail.TabIndex = 10
        ' 
        ' txtFirstname
        ' 
        txtFirstname.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtFirstname.Location = New Point(148, 120)
        txtFirstname.Multiline = True
        txtFirstname.Name = "txtFirstname"
        txtFirstname.Size = New Size(243, 34)
        txtFirstname.TabIndex = 9
        ' 
        ' txtStudentID
        ' 
        txtStudentID.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtStudentID.Location = New Point(148, 65)
        txtStudentID.Multiline = True
        txtStudentID.Name = "txtStudentID"
        txtStudentID.Size = New Size(243, 34)
        txtStudentID.TabIndex = 8
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(456, 250)
        Label9.Name = "Label9"
        Label9.Size = New Size(89, 24)
        Label9.TabIndex = 7
        Label9.Text = "Year Level:"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(47, 250)
        Label8.Name = "Label8"
        Label8.Size = New Size(64, 24)
        Label8.TabIndex = 6
        Label8.Text = "Course:"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(456, 123)
        Label7.Name = "Label7"
        Label7.Size = New Size(84, 24)
        Label7.TabIndex = 5
        Label7.Text = "Lastname:"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(456, 68)
        Label6.Name = "Label6"
        Label6.Size = New Size(87, 24)
        Label6.TabIndex = 4
        Label6.Text = "Username:"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(47, 184)
        Label5.Name = "Label5"
        Label5.Size = New Size(57, 24)
        Label5.TabIndex = 3
        Label5.Text = "Email:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(47, 123)
        Label4.Name = "Label4"
        Label4.Size = New Size(88, 24)
        Label4.TabIndex = 2
        Label4.Text = "Firstname:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(47, 68)
        Label3.Name = "Label3"
        Label3.Size = New Size(95, 24)
        Label3.TabIndex = 1
        Label3.Text = "Student_ID:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Sitka Display", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(344, 15)
        Label2.Name = "Label2"
        Label2.Size = New Size(129, 26)
        Label2.TabIndex = 0
        Label2.Text = "ADD STUDENT"
        ' 
        ' UC_Students
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(pnlAddStudent)
        Controls.Add(btnAddStudents)
        Controls.Add(btnSearchStudents)
        Controls.Add(txtSearchStudents)
        Controls.Add(btnViewDetails)
        Controls.Add(Label1)
        Controls.Add(dgvStudentList)
        Name = "UC_Students"
        Size = New Size(874, 699)
        CType(dgvStudentList, ComponentModel.ISupportInitialize).EndInit()
        pnlAddStudent.ResumeLayout(False)
        pnlAddStudent.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents dgvStudentList As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents btnViewDetails As Button
    Friend WithEvents txtSearchStudents As TextBox
    Friend WithEvents btnSearchStudents As Button
    Friend WithEvents btnAddStudents As Button
    Friend WithEvents pnlAddStudent As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtLastname As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtFirstname As TextBox
    Friend WithEvents txtStudentID As TextBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents cmbCourse As ComboBox
    Friend WithEvents cmbYearlvl As ComboBox

End Class
