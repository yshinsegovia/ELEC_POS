
Imports MySqlConnector

Public Class Form1

    '========================================
    ' FORM LOAD
    '========================================
    Private Sub Form1_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        ' Hide the password using *
        txtpass.PasswordChar = "*"c
        txtpass.UseSystemPasswordChar = False

    End Sub


    '========================================
    ' LOGIN BUTTON
    '========================================
    Private Sub btnlogin_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnlogin.Click

        '========================================
        ' GET USER INPUT
        '========================================
        Dim username As String = txtuser.Text.Trim()
        Dim password As String = txtpass.Text

        '========================================
        ' CHECK EMPTY FIELDS
        '========================================
        If String.IsNullOrWhiteSpace(username) OrElse
           String.IsNullOrWhiteSpace(password) Then

            MessageBox.Show(
                "Please enter your username and password.",
                "Login",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        '========================================
        ' CONNECT TO DATABASE
        '========================================
        Try

            Using conn As MySqlConnection = GetConnection()

                conn.Open()

                '========================================
                ' LOGIN QUERY
                '========================================
                Const query As String =
                    "SELECT user_id, username, password, role " &
                    "FROM `user` " &
                    "WHERE username = @username " &
                    "AND password = @password " &
                    "LIMIT 1"

                Using cmd As New MySqlCommand(query, conn)

                    cmd.Parameters.AddWithValue("@username", username)
                    cmd.Parameters.AddWithValue("@password", password)

                    '========================================
                    ' READ LOGIN RESULT
                    '========================================
                    Using reader As MySqlDataReader = cmd.ExecuteReader()

                        If Not reader.Read() Then

                            MessageBox.Show(
                                "Invalid username or password.",
                                "Login Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            )

                            txtpass.Clear()
                            txtpass.Focus()

                            Return

                        End If

                        '========================================
                        ' GET USER INFORMATION
                        '========================================
                        Dim userID As Integer =
                            Convert.ToInt32(reader("user_id"))

                        Dim loggedUsername As String =
                            reader("username").ToString()

                        Dim loggedPassword As String =
                            reader("password").ToString()

                        Dim role As String =
                            reader("role").ToString().Trim().ToLowerInvariant()

                        '========================================
                        ' CHECK ROLE BEFORE OPENING A FORM
                        '========================================
                        Select Case role

                            Case "user", "admin"

                                ' Save Admin session
                                CurrentSession.CurrentUser = New session With {
                                    .UserID = userID,
                                    .Username = loggedUsername,
                                    .Password = loggedPassword,
                                    .UserRole = role
                                }

                                MessageBox.Show(
                                    "Admin login successful!",
                                    "Login",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                )

                                Dim adminForm As New admin()

                                adminForm.Show()
                                Me.Hide()


                            Case "cashier"

                                ' Save Cashier session
                                CurrentSession.CurrentUser = New session With {
                                    .UserID = userID,
                                    .Username = loggedUsername,
                                    .Password = loggedPassword,
                                    .UserRole = role
                                }

                                MessageBox.Show(
                                    "Cashier login successful!",
                                    "Login",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                )

                                Dim cashierForm As New cashier()

                                cashierForm.Show()
                                Me.Hide()


                            Case "kitchen"

                                ' Save Kitchen session
                                CurrentSession.CurrentUser = New session With {
                                    .UserID = userID,
                                    .Username = loggedUsername,
                                    .Password = loggedPassword,
                                    .UserRole = role
                                }

                                MessageBox.Show(
                                    "Kitchen login successful!",
                                    "Login",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                )

                                Dim kitchenForm As New kitchen()

                                kitchenForm.Show()
                                Me.Hide()


                            Case Else

                                ' Clear session for an unknown role
                                CurrentSession.CurrentUser = Nothing

                                MessageBox.Show(
                                    "Your account role is not recognized." &
                                    Environment.NewLine &
                                    "Please contact the administrator.",
                                    "Access Denied",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning
                                )

                        End Select

                    End Using

                End Using

            End Using

            '========================================
            ' DATABASE ERROR
            '========================================
        Catch ex As MySqlException

            MessageBox.Show(
                "Database connection error:" &
                Environment.NewLine &
                Environment.NewLine &
                ex.Message,
                "Database Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

            '========================================
            ' GENERAL ERROR
            '========================================
        Catch ex As Exception

            MessageBox.Show(
                "An error occurred:" &
                Environment.NewLine &
                Environment.NewLine &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    '========================================
    ' ENTER KEY TO LOGIN
    '========================================
    Private Sub txtpass_KeyDown(
        sender As Object,
        e As KeyEventArgs
    ) Handles txtpass.KeyDown

        If e.KeyCode = Keys.Enter Then

            e.SuppressKeyPress = True
            btnlogin.PerformClick()

        End If

    End Sub

End Class
