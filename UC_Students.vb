Imports MySqlConnector
Imports System.Data

Public Class UC_Students

    '========================================================
    ' FORM LOAD
    '========================================================
    Private Sub UC_Students_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        'Hide Add Student panel when page opens
        pnlAddStudent.Visible = False

        'Load students from database
        LoadStudents()

        'Load Course options
        cmbCourse.Items.Clear()

        cmbCourse.Items.Add("BSIT")
        cmbCourse.Items.Add("BSHM")
        cmbCourse.Items.Add("BSBA")
        cmbCourse.Items.Add("BSED")

        'Load Year Level options
        cmbYearlvl.Items.Clear()

        cmbYearlvl.Items.Add("1")
        cmbYearlvl.Items.Add("2")
        cmbYearlvl.Items.Add("3")
        cmbYearlvl.Items.Add("4")

    End Sub


    '========================================================
    ' LOAD STUDENTS
    '========================================================
    Private Sub LoadStudents()

        Try

            Using conn As MySqlConnection = GetConnection()

                conn.Open()

                Dim query As String =
                    "SELECT student_id, username, firstname, lastname, " &
                    "email, course, yearlvl " &
                    "FROM user_reg " &
                    "ORDER BY lastname ASC, firstname ASC"

                Using cmd As New MySqlCommand(query, conn)

                    Using adapter As New MySqlDataAdapter(cmd)

                        Dim table As New DataTable()

                        adapter.Fill(table)

                        dgvStudentList.DataSource = table

                    End Using

                End Using

            End Using

        Catch ex As Exception

            MessageBox.Show(
                "Error loading students." &
                Environment.NewLine &
                ex.Message,
                "Students",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    '========================================================
    ' ADD STUDENT BUTTON
    '========================================================
    Private Sub btnAddStudents_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnAddStudents.Click

        'Show Add Student panel
        pnlAddStudent.Visible = True

        'Put cursor in Student ID textbox
        txtStudentID.Focus()

    End Sub


    '========================================================
    ' SAVE STUDENT
    '========================================================
    Private Sub btnSave_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnSave.Click

        '====================================================
        ' GET VALUES
        '====================================================
        Dim studentID As String =
            txtStudentID.Text.Trim()

        Dim username As String =
            txtUsername.Text.Trim()

        Dim firstname As String =
            txtFirstname.Text.Trim()

        Dim lastname As String =
            txtLastname.Text.Trim()

        Dim email As String =
            txtEmail.Text.Trim()

        Dim course As String = ""

        If cmbCourse.SelectedItem IsNot Nothing Then
            course = cmbCourse.SelectedItem.ToString().Trim()
        End If

        Dim yearlvl As String = ""

        If cmbYearlvl.SelectedItem IsNot Nothing Then
            yearlvl = cmbYearlvl.SelectedItem.ToString().Trim()
        End If


        '====================================================
        ' VALIDATE STUDENT ID
        '====================================================
        If studentID = "" Then

            MessageBox.Show(
                "Please enter the Student ID.",
                "Add Student",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            txtStudentID.Focus()

            Return

        End If


        '====================================================
        ' VALIDATE USERNAME
        '====================================================
        If username = "" Then

            MessageBox.Show(
                "Please enter the Username.",
                "Add Student",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            txtUsername.Focus()

            Return

        End If


        '====================================================
        ' VALIDATE FIRST NAME
        '====================================================
        If firstname = "" Then

            MessageBox.Show(
                "Please enter the First Name.",
                "Add Student",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            txtFirstname.Focus()

            Return

        End If


        '====================================================
        ' VALIDATE LAST NAME
        '====================================================
        If lastname = "" Then

            MessageBox.Show(
                "Please enter the Last Name.",
                "Add Student",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            txtLastname.Focus()

            Return

        End If


        '====================================================
        ' VALIDATE EMAIL
        '====================================================
        If email = "" Then

            MessageBox.Show(
                "Please enter the Email.",
                "Add Student",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            txtEmail.Focus()

            Return

        End If


        '====================================================
        ' VALIDATE COURSE
        '====================================================
        If course = "" Then

            MessageBox.Show(
                "Please select a Course.",
                "Add Student",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            cmbCourse.Focus()

            Return

        End If


        '====================================================
        ' VALIDATE YEAR LEVEL
        '====================================================
        If yearlvl = "" Then

            MessageBox.Show(
                "Please select a Year Level.",
                "Add Student",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            cmbYearlvl.Focus()

            Return

        End If


        '====================================================
        ' SAVE TO DATABASE
        '====================================================
        Try

            Using conn As MySqlConnection = GetConnection()

                conn.Open()


                '================================================
                ' CHECK STUDENT ID
                '================================================
                Dim checkStudentQuery As String =
                    "SELECT COUNT(*) " &
                    "FROM user_reg " &
                    "WHERE student_id = @student_id"

                Using checkStudentCmd As New MySqlCommand(
                    checkStudentQuery,
                    conn
                )

                    checkStudentCmd.Parameters.AddWithValue(
                        "@student_id",
                        studentID
                    )

                    Dim studentExists As Integer =
                        Convert.ToInt32(
                            checkStudentCmd.ExecuteScalar()
                        )

                    If studentExists > 0 Then

                        MessageBox.Show(
                            "Student ID already exists.",
                            "Add Student",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        )

                        txtStudentID.Focus()

                        Return

                    End If

                End Using


                '================================================
                ' CHECK USERNAME
                '================================================
                Dim checkUsernameQuery As String =
                    "SELECT COUNT(*) " &
                    "FROM user_reg " &
                    "WHERE username = @username"

                Using checkUsernameCmd As New MySqlCommand(
                    checkUsernameQuery,
                    conn
                )

                    checkUsernameCmd.Parameters.AddWithValue(
                        "@username",
                        username
                    )

                    Dim usernameExists As Integer =
                        Convert.ToInt32(
                            checkUsernameCmd.ExecuteScalar()
                        )

                    If usernameExists > 0 Then

                        MessageBox.Show(
                            "Username already exists.",
                            "Add Student",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        )

                        txtUsername.Focus()

                        Return

                    End If

                End Using


                '================================================
                ' INSERT STUDENT
                '================================================
                Dim insertQuery As String =
                    "INSERT INTO user_reg " &
                    "(student_id, username, firstname, lastname, " &
                    "email, course, yearlvl) " &
                    "VALUES " &
                    "(@student_id, @username, @firstname, @lastname, " &
                    "@email, @course, @yearlvl)"

                Using cmd As New MySqlCommand(
                    insertQuery,
                    conn
                )

                    cmd.Parameters.AddWithValue(
                        "@student_id",
                        studentID
                    )

                    cmd.Parameters.AddWithValue(
                        "@username",
                        username
                    )

                    cmd.Parameters.AddWithValue(
                        "@firstname",
                        firstname
                    )

                    cmd.Parameters.AddWithValue(
                        "@lastname",
                        lastname
                    )

                    cmd.Parameters.AddWithValue(
                        "@email",
                        email
                    )

                    cmd.Parameters.AddWithValue(
                        "@course",
                        course
                    )

                    cmd.Parameters.AddWithValue(
                        "@yearlvl",
                        yearlvl
                    )

                    cmd.ExecuteNonQuery()

                End Using

            End Using


            '====================================================
            ' SUCCESS MESSAGE
            '====================================================
            MessageBox.Show(
                "Student added successfully!",
                "Add Student",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )


            '====================================================
            ' CLEAR FORM
            '====================================================
            ClearStudentFields()


            '====================================================
            ' HIDE PANEL
            '====================================================
            pnlAddStudent.Visible = False


            '====================================================
            ' REFRESH STUDENT LIST
            '====================================================
            LoadStudents()


        Catch ex As Exception

            MessageBox.Show(
                "Error adding student." &
                Environment.NewLine &
                ex.Message,
                "Add Student",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    '========================================================
    ' CANCEL ADD STUDENT
    '========================================================
    Private Sub btnCancel_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnCancel.Click

        Dim answer As DialogResult =
            MessageBox.Show(
                "Are you sure you want to cancel?",
                "Add Student",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            )

        If answer = DialogResult.Yes Then

            ClearStudentFields()

            pnlAddStudent.Visible = False

        End If

    End Sub


    '========================================================
    ' CLEAR STUDENT FIELDS
    '========================================================
    Private Sub ClearStudentFields()

        txtStudentID.Clear()

        txtUsername.Clear()

        txtFirstname.Clear()

        txtLastname.Clear()

        txtEmail.Clear()

        cmbCourse.SelectedIndex = -1

        cmbYearlvl.SelectedIndex = -1

    End Sub


    '========================================================
    ' SEARCH BUTTON
    '========================================================
    Private Sub btnSearchStudents_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnSearchStudents.Click

        SearchStudents()

    End Sub


    '========================================================
    ' SEARCH WHILE TYPING
    '========================================================
    Private Sub txtSearchStudents_TextChanged(
        sender As Object,
        e As EventArgs
    ) Handles txtSearchStudents.TextChanged

        SearchStudents()

    End Sub


    '========================================================
    ' SEARCH STUDENTS
    '========================================================
    Private Sub SearchStudents()

        Try

            Using conn As MySqlConnection = GetConnection()

                conn.Open()

                Dim query As String =
                    "SELECT student_id, username, firstname, lastname, " &
                    "email, course, yearlvl " &
                    "FROM user_reg " &
                    "WHERE student_id LIKE @search " &
                    "OR username LIKE @search " &
                    "OR firstname LIKE @search " &
                    "OR lastname LIKE @search " &
                    "OR email LIKE @search " &
                    "OR course LIKE @search " &
                    "OR yearlvl LIKE @search " &
                    "ORDER BY lastname ASC, firstname ASC"

                Using cmd As New MySqlCommand(
                    query,
                    conn
                )

                    cmd.Parameters.AddWithValue(
                        "@search",
                        "%" & txtSearchStudents.Text.Trim() & "%"
                    )

                    Using adapter As New MySqlDataAdapter(cmd)

                        Dim table As New DataTable()

                        adapter.Fill(table)

                        dgvStudentList.DataSource = table

                    End Using

                End Using

            End Using

        Catch ex As Exception

            MessageBox.Show(
                "Error searching students." &
                Environment.NewLine &
                ex.Message,
                "Search Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    '========================================================
    ' DATAGRIDVIEW CLICK
    '========================================================
    Private Sub dgvStudentList_CellContentClick(
        sender As Object,
        e As DataGridViewCellEventArgs
    ) Handles dgvStudentList.CellContentClick

        If e.RowIndex < 0 Then
            Return
        End If

    End Sub


    '========================================================
    ' VIEW STUDENT DETAILS
    '========================================================
    Private Sub btnViewDetails_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnViewDetails.Click

        If dgvStudentList.SelectedRows.Count = 0 Then

            MessageBox.Show(
                "Please select a student first.",
                "Student Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            Return

        End If


        '====================================================
        ' GET SELECTED ROW
        '====================================================
        Dim row As DataGridViewRow =
            dgvStudentList.SelectedRows(0)

        Dim studentID As String =
            row.Cells("student_id").Value.ToString()


        '====================================================
        ' GET STUDENT DETAILS
        '====================================================
        Try

            Using conn As MySqlConnection = GetConnection()

                conn.Open()

                Dim query As String =
                    "SELECT student_id, username, firstname, lastname, " &
                    "email, course, yearlvl " &
                    "FROM user_reg " &
                    "WHERE student_id = @student_id"

                Using cmd As New MySqlCommand(
                    query,
                    conn
                )

                    cmd.Parameters.AddWithValue(
                        "@student_id",
                        studentID
                    )

                    Using reader As MySqlDataReader =
                        cmd.ExecuteReader()

                        If reader.Read() Then

                            Dim studentInfo As String = ""

                            studentInfo =
                                "Student ID: " &
                                reader("student_id").ToString()

                            studentInfo =
                                studentInfo &
                                Environment.NewLine &
                                Environment.NewLine &
                                "Username: " &
                                reader("username").ToString()

                            studentInfo =
                                studentInfo &
                                Environment.NewLine &
                                Environment.NewLine &
                                "Name: " &
                                reader("firstname").ToString() &
                                " " &
                                reader("lastname").ToString()

                            studentInfo =
                                studentInfo &
                                Environment.NewLine &
                                Environment.NewLine &
                                "Email: " &
                                reader("email").ToString()

                            studentInfo =
                                studentInfo &
                                Environment.NewLine &
                                Environment.NewLine &
                                "Course: " &
                                reader("course").ToString()

                            studentInfo =
                                studentInfo &
                                Environment.NewLine &
                                Environment.NewLine &
                                "Year Level: " &
                                reader("yearlvl").ToString()


                            MessageBox.Show(
                                studentInfo,
                                "Student Details",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            )

                        Else

                            MessageBox.Show(
                                "Student information was not found.",
                                "Student Details",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            )

                        End If

                    End Using

                End Using

            End Using

        Catch ex As Exception

            MessageBox.Show(
                "Error loading student details." &
                Environment.NewLine &
                ex.Message,
                "Student Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

End Class