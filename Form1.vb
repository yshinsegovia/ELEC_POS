
Imports MySqlConnector

Public Class Form1

    '========================================
    ' FORM LOAD
    '========================================
    Private Sub Form1_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        'Show password as *
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
        Dim username As String =
            txtuser.Text.Trim()

        Dim password As String =
            txtpass.Text.Trim()


        '========================================
        ' CHECK EMPTY FIELDS
        '========================================
        If username = "" OrElse password = "" Then

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
                Dim query As String =
                    "SELECT user_id, username, password, role " &
                    "FROM `user` " &
                    "WHERE username = @username " &
                    "AND password = @password " &
                    "LIMIT 1"


                Using cmd As New MySqlCommand(
                    query,
                    conn
                )

                    cmd.Parameters.AddWithValue(
                        "@username",
                        username
                    )

                    cmd.Parameters.AddWithValue(
                        "@password",
                        password
                    )


                    '========================================
                    ' READ LOGIN RESULT
                    '========================================
                    Using reader As MySqlDataReader =
                        cmd.ExecuteReader()


                        '========================================
                        ' LOGIN SUCCESS
                        '========================================
                        If reader.Read() Then

                            '------------------------------------
                            ' GET USER INFORMATION
                            '------------------------------------
                            Dim userID As Integer =
                                Convert.ToInt32(
                                    reader("user_id")
                                )

                            Dim loggedUsername As String =
                                reader("username").ToString()

                            Dim loggedPassword As String =
                                reader("password").ToString()

                            Dim role As String =
                                reader("role").ToString().Trim().ToLower()


                            '====================================
                            ' CREATE CURRENT SESSION
                            '====================================
                            CurrentSession.CurrentUser =
                                New session With {
                                    .UserID = userID,
                                    .Username = loggedUsername,
                                    .Password = loggedPassword,
                                    .UserRole = role
                                }


                            '====================================
                            ' OPEN ADMIN
                            '====================================
                            If role = "user" OrElse role = "admin" Then

                                MessageBox.Show(
                                    "Admin login successful!",
                                    "Login",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                )


                                Dim adminForm As New admin()

                                adminForm.Show()

                                Me.Hide()


                                '====================================
                                ' OPEN CASHIER
                                '====================================
                            ElseIf role = "cashier" Then

                                MessageBox.Show(
                                    "Cashier login successful!",
                                    "Login",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                )


                                Dim cashierForm As New cashier()

                                cashierForm.Show()

                                Me.Hide()


                                '====================================
                                ' UNKNOWN ROLE
                                '====================================
                            Else

                                MessageBox.Show(
                                    "Your account role is not recognized.",
                                    "Access Denied",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning
                                )

                                CurrentSession.CurrentUser = Nothing

                            End If


                        Else

                            '========================================
                            ' LOGIN FAILED
                            '========================================
                            MessageBox.Show(
                                "Invalid username or password.",
                                "Login Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            )

                            txtpass.Clear()
                            txtpass.Focus()

                        End If

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
    ' ENTER KEY
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