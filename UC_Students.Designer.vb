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
        CType(dgvStudentList, ComponentModel.ISupportInitialize).BeginInit()
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
        ' UC_Students
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(btnAddStudents)
        Controls.Add(btnSearchStudents)
        Controls.Add(txtSearchStudents)
        Controls.Add(btnViewDetails)
        Controls.Add(Label1)
        Controls.Add(dgvStudentList)
        Name = "UC_Students"
        Size = New Size(874, 699)
        CType(dgvStudentList, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents dgvStudentList As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents btnViewDetails As Button
    Friend WithEvents txtSearchStudents As TextBox
    Friend WithEvents btnSearchStudents As Button
    Friend WithEvents btnAddStudents As Button

End Class
