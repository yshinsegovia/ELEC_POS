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

        'Student ID is auto-generated — prevent manual editing.
        txtStudentID.ReadOnly = True

        'Set up grid so columns fill the whole width.
        SetupStudentGrid()

        'Load students from database
        LoadStudents()

        'Load Courses from the DATABASE (not hardcoded).
        LoadCourses()

        'Load Year Level options
        cmbYearlvl.Items.Clear()
        cmbYearlvl.Items.Add("1")
        cmbYearlvl.Items.Add("2")
        cmbYearlvl.Items.Add("3")
        cmbYearlvl.Items.Add("4")

    End Sub


    '========================================================
    ' LOAD COURSES FROM DATABASE
    '========================================================
    Private Sub LoadCourses()

        Try
            Using conn As MySqlConnection = GetConnection()

                conn.Open()

                Dim query As String =
                    "SELECT course_code FROM courses " &
                    "ORDER BY course_code ASC"

                Using cmd As New MySqlCommand(query, conn)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()

                        ' Preserve the current selection if any.
                        Dim current As String = ""

                        If cmbCourse.SelectedItem IsNot Nothing Then
                            current = cmbCourse.SelectedItem.ToString()
                        End If

                        cmbCourse.Items.Clear()

                        While reader.Read()
                            cmbCourse.Items.Add(
                                reader("course_code").ToString()
                            )
                        End While

                        If current <> "" Then
                            SelectComboBoxValue(cmbCourse, current)
                        End If

                    End Using

                End Using

            End Using

        Catch ex As Exception

            MessageBox.Show(
                "Error loading courses." &
                Environment.NewLine &
                ex.Message,
                "Courses",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    '========================================================
    ' SETUP STUDENT GRID
    '========================================================
    Private Sub SetupStudentGrid()

        With dgvStudentList

            .AutoGenerateColumns = True
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .RowHeadersVisible = False

            .AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill

            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None

            .BackgroundColor = SystemColors.Window
            .BorderStyle = BorderStyle.None

            .AllowUserToOrderColumns = False

        End With

    End Sub


    '========================================================
    ' FORMAT COLUMNS SO NOTHING IS LEFT EMPTY
    '========================================================
    Private Sub FormatStudentColumns()

        If dgvStudentList.Columns.Count = 0 Then Return

        For Each col As DataGridViewColumn In dgvStudentList.Columns
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            col.MinimumWidth = 80
        Next

        SetColumn("student_id", "Student ID", 90)
        SetColumn("firstname", "First Name", 110)
        SetColumn("lastname", "Last Name", 110)
        SetColumn("email", "Email", 220)
        SetColumn("course", "Course", 90)
        SetColumn("yearlvl", "Year Level", 80)

    End Sub


    '========================================================
    ' HELPER — SET HEADER + FILL WEIGHT
    '========================================================
    Private Sub SetColumn(
        columnName As String,
        headerText As String,
        fillWeight As Integer
    )

        If Not dgvStudentList.Columns.Contains(columnName) Then
            Return
        End If

        Dim col As DataGridViewColumn =
            dgvStudentList.Columns(columnName)

        col.HeaderText = headerText
        col.FillWeight = fillWeight
        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        col.MinimumWidth = 80

    End Sub


    '========================================================
    ' LOAD STUDENTS
    '========================================================
    Private Sub LoadStudents()

        Try

            Using conn As MySqlConnection = GetConnection()

                conn.Open()

                Dim query As String =
                    "SELECT student_id, firstname, lastname, " &
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

            FormatStudentColumns()

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
    ' GENERATE NEXT STUDENT ID
    '========================================================
    Private Function GenerateNextStudentID() As String

        Try

            Using conn As MySqlConnection = GetConnection()

                conn.Open()

                Const countQuery As String =
                    "SELECT COUNT(*) FROM user_reg"

                Dim totalStudents As Integer

                Using cmd As New MySqlCommand(countQuery, conn)
                    totalStudents = Convert.ToInt32(cmd.ExecuteScalar())
                End Using

                If totalStudents = 0 Then
                    Return DateTime.Now.Year.ToString() & "-001"
                End If

                Const lastQuery As String =
                    "SELECT student_id FROM user_reg " &
                    "ORDER BY student_id DESC LIMIT 1"

                Dim lastStudentID As String

                Using cmd As New MySqlCommand(lastQuery, conn)

                    Dim result As Object = cmd.ExecuteScalar()

                    If result Is Nothing OrElse result Is DBNull.Value Then
                        Return DateTime.Now.Year.ToString() & "-001"
                    End If

                    lastStudentID = result.ToString()

                End Using

                Dim parts() As String = lastStudentID.Split("-"c)

                If parts.Length <> 2 Then
                    Return DateTime.Now.Year.ToString() & "-001"
                End If

                Dim yearPart As String = parts(0)
                Dim numberPart As Integer

                If Not Integer.TryParse(parts(1), numberPart) Then
                    Return DateTime.Now.Year.ToString() & "-001"
                End If

                Return yearPart & "-" & (numberPart + 1).ToString("D3")

            End Using

        Catch ex As Exception

            MessageBox.Show(
                "Unable to generate the next Student ID." &
                Environment.NewLine & ex.Message,
                "Student ID Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

            Return ""

        End Try

    End Function


    '========================================================
    ' ADD STUDENT BUTTON
    '========================================================
    Private Sub btnAddStudents_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnAddStudents.Click

        Dim nextID As String = GenerateNextStudentID()

        If String.IsNullOrWhiteSpace(nextID) Then
            Return
        End If

        txtStudentID.Text = nextID
        txtStudentID.ReadOnly = True

        pnlAddStudent.Visible = True

        txtFirstname.Focus()

    End Sub


    '========================================================
    ' SAVE STUDENT (WITH INITIAL WALLET LOAD)
    '========================================================
    Private Sub btnSave_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnSave.Click

        Dim studentID As String = txtStudentID.Text.Trim()
        Dim username As String = studentID ' Username auto-generated from Student ID
        Dim firstname As String = txtFirstname.Text.Trim()
        Dim lastname As String = txtLastname.Text.Trim()
        Dim email As String = txtEmail.Text.Trim()

        Dim course As String = ""
        If cmbCourse.SelectedItem IsNot Nothing Then
            course = cmbCourse.SelectedItem.ToString().Trim()
        Else
            course = cmbCourse.Text.Trim()
        End If

        Dim yearlvl As String = ""
        If cmbYearlvl.SelectedItem IsNot Nothing Then
            yearlvl = cmbYearlvl.SelectedItem.ToString().Trim()
        End If

        ' Check Initial Balance
        Dim initialBalance As Decimal = 0D
        If Not String.IsNullOrWhiteSpace(txtInitialBalance.Text) Then
            If Not Decimal.TryParse(txtInitialBalance.Text.Trim(), initialBalance) OrElse initialBalance < 0 Then
                MessageBox.Show("Please enter a valid Initial Wallet Load (0 or higher).", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtInitialBalance.Focus()
                Return
            End If
        End If

        '==================== VALIDATION ====================
        If studentID = "" Then
            MessageBox.Show("The Student ID was not generated. Please click Add Student again.", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If firstname = "" Then
            MessageBox.Show("Please enter the First Name.", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFirstname.Focus()
            Return
        End If

        If lastname = "" Then
            MessageBox.Show("Please enter the Last Name.", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLastname.Focus()
            Return
        End If

        If email = "" Then
            MessageBox.Show("Please enter the Email.", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmail.Focus()
            Return
        End If

        If course = "" Then
            MessageBox.Show("Please select or type a Course.", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbCourse.Focus()
            Return
        End If

        If yearlvl = "" Then
            MessageBox.Show("Please select a Year Level.", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbYearlvl.Focus()
            Return
        End If


        '==================== SAVE TO DATABASE ====================
        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()

                ' Use a transaction to ensure Student, Wallet, and History are saved together
                Using trans As MySqlTransaction = conn.BeginTransaction()
                    Try
                        '---- Check duplicate Student ID ----
                        Dim checkStudentQuery As String = "SELECT COUNT(*) FROM user_reg WHERE student_id = @student_id"
                        Using checkStudentCmd As New MySqlCommand(checkStudentQuery, conn, trans)
                            checkStudentCmd.Parameters.AddWithValue("@student_id", studentID)
                            If Convert.ToInt32(checkStudentCmd.ExecuteScalar()) > 0 Then
                                MessageBox.Show("Student ID already exists. Please click Add Student again to get the next ID.", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Return
                            End If
                        End Using

                        '---- Auto-add the course to `courses` if it's new ----
                        Dim checkCourseQuery As String = "SELECT COUNT(*) FROM courses WHERE course_code = @course"
                        Using checkCourseCmd As New MySqlCommand(checkCourseQuery, conn, trans)
                            checkCourseCmd.Parameters.AddWithValue("@course", course)
                            If Convert.ToInt32(checkCourseCmd.ExecuteScalar()) = 0 Then
                                Dim insertCourseQuery As String = "INSERT INTO courses (course_code) VALUES (@course)"
                                Using insertCourseCmd As New MySqlCommand(insertCourseQuery, conn, trans)
                                    insertCourseCmd.Parameters.AddWithValue("@course", course)
                                    insertCourseCmd.ExecuteNonQuery()
                                End Using
                            End If
                        End Using

                        '---- 1. Insert Student ----
                        Dim insertQuery As String =
                            "INSERT INTO user_reg " &
                            "(student_id, username, firstname, lastname, email, course, yearlvl) " &
                            "VALUES (@student_id, @username, @firstname, @lastname, @email, @course, @yearlvl)"

                        Using cmd As New MySqlCommand(insertQuery, conn, trans)
                            cmd.Parameters.AddWithValue("@student_id", studentID)
                            cmd.Parameters.AddWithValue("@username", username)
                            cmd.Parameters.AddWithValue("@firstname", firstname)
                            cmd.Parameters.AddWithValue("@lastname", lastname)
                            cmd.Parameters.AddWithValue("@email", email)
                            cmd.Parameters.AddWithValue("@course", course)
                            cmd.Parameters.AddWithValue("@yearlvl", yearlvl)
                            cmd.ExecuteNonQuery()
                        End Using

                        '---- 2. Create the Student's Wallet ----
                        Dim insertWalletQuery As String =
                            "INSERT INTO student_wallets (student_id, balance) " &
                            "VALUES (@student_id, @balance)"

                        Using cmd As New MySqlCommand(insertWalletQuery, conn, trans)
                            cmd.Parameters.AddWithValue("@student_id", studentID)
                            cmd.Parameters.AddWithValue("@balance", initialBalance)
                            cmd.ExecuteNonQuery()
                        End Using

                        '---- 3. Record Initial Load in Wallet History (If they put money) ----
                        If initialBalance > 0D Then
                            Dim insertHistoryQuery As String =
                                "INSERT INTO wallet_transactions " &
                                "(student_id, cashier_id, transaction_type, amount, balance_before, balance_after, description) " &
                                "VALUES (@student_id, @user_id, 'Wallet', @amount, 0, @balance_after, 'Initial load during registration')"

                            Using cmd As New MySqlCommand(insertHistoryQuery, conn, trans)
                                cmd.Parameters.AddWithValue("@student_id", studentID)
                                ' Using the Admin's ID who is currently logged in
                                cmd.Parameters.AddWithValue("@user_id", CurrentSession.CurrentUser.UserID)
                                cmd.Parameters.AddWithValue("@amount", initialBalance)
                                cmd.Parameters.AddWithValue("@balance_after", initialBalance)
                                cmd.ExecuteNonQuery()
                            End Using
                        End If

                        '---- Commit Everything ----
                        trans.Commit()

                    Catch
                        trans.Rollback()
                        Throw
                    End Try
                End Using
            End Using

            '==================== SUCCESS ====================
            MessageBox.Show(
                "Student added successfully!" & Environment.NewLine &
                "Student ID: " & studentID & Environment.NewLine &
                "Starting Balance: ₱" & initialBalance.ToString("N2"),
                "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information
            )

            LoadStudents()
            LoadCourses()
            ClearStudentFields()

            ' Keep panel open + auto-fill next ID.
            Dim nextID As String = GenerateNextStudentID()
            If Not String.IsNullOrWhiteSpace(nextID) Then
                txtStudentID.Text = nextID
            End If

            txtFirstname.Focus()

        Catch ex As Exception
            MessageBox.Show("Error adding student." & Environment.NewLine & ex.Message, "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        txtFirstname.Clear()
        txtLastname.Clear()
        txtEmail.Clear()
        txtInitialBalance.Clear()

        cmbCourse.SelectedIndex = -1
        cmbCourse.Text = ""

        cmbYearlvl.SelectedIndex = -1

    End Sub


    '========================================================
    ' AUTO SEARCH WHILE TYPING
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
                    "SELECT student_id, firstname, lastname, " &
                    "email, course, yearlvl " &
                    "FROM user_reg " &
                    "WHERE student_id LIKE @search " &
                    "OR firstname LIKE @search " &
                    "OR lastname LIKE @search " &
                    "OR email LIKE @search " &
                    "OR course LIKE @search " &
                    "OR yearlvl LIKE @search " &
                    "ORDER BY lastname ASC, firstname ASC"

                Using cmd As New MySqlCommand(query, conn)

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

            FormatStudentColumns()

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
    ' SELECT COMBOBOX VALUE
    '========================================================
    Private Sub SelectComboBoxValue(
        comboBox As ComboBox,
        value As String
    )

        comboBox.SelectedIndex = -1

        For index As Integer = 0 To comboBox.Items.Count - 1

            If comboBox.Items(index).ToString().Equals(
                value,
                StringComparison.OrdinalIgnoreCase
            ) Then

                comboBox.SelectedIndex = index
                Exit For

            End If

        Next

    End Sub

End Class