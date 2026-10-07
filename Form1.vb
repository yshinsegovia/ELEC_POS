Imports MySqlConnector

Public Class Form1

    '========================================
    ' FORM LOAD
    '========================================
    Private Sub Form1_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

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
                    "SELECT user_id, username, role " &
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


                    Using reader As MySqlDataReader =
                        cmd.ExecuteReader()


                        '========================================
                        ' LOGIN SUCCESS
                        '========================================
                        If reader.Read() Then

                            Dim userID As Integer =
                                Convert.ToInt32(
                                    reader("user_id")
                                )

                            Dim loggedUsername As String =
                                reader("username").ToString()

                            Dim role As String =
                                reader("role").ToString()


                            '========================================
                            ' CHECK ROLE
                            '========================================
                            If role.ToLower() = "user" Then

                                MessageBox.Show(
                                    "Login successful!",
                                    "Login",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                )


                                '========================================
                                ' OPEN ADMIN FORM
                                '========================================
                                Dim adminForm As New admin()

                                adminForm.Show()

                                Me.Hide()

                            Else

                                MessageBox.Show(
                                    "You do not have permission to access the Admin Dashboard.",
                                    "Access Denied",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning
                                )

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