
Public Class admin

    '========================================================
    ' USERCONTROL INSTANCES
    ' Each page is created only ONCE
    '========================================================
    Private dashboardPage As UC_Dashboard
    Private studentsPage As UC_Students
    Private productsPage As UC_Products
    Private transactionPage As UC_Transaction


    '========================================================
    ' FORM LOAD
    '========================================================
    Private Sub admin_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        SetupLayout()

        InitializePages()

        ShowDashboard()

    End Sub


    '========================================================
    ' SETUP ADMIN LAYOUT
    '========================================================
    Private Sub SetupLayout()

        pnlSidebar.Dock = DockStyle.Left
        pnlContent.Dock = DockStyle.Fill

    End Sub


    '========================================================
    ' INITIALIZE PAGES
    ' Create each UserControl only ONCE
    '========================================================
    Private Sub InitializePages()

        dashboardPage = New UC_Dashboard()

        studentsPage = New UC_Students()

        productsPage = New UC_Products()

        transactionPage = New UC_Transaction()

    End Sub


    '========================================================
    ' DASHBOARD
    '========================================================
    Private Sub btnDashboard_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnDashboard.Click

        ShowDashboard()

    End Sub


    Private Sub ShowDashboard()

        ShowUserControl(dashboardPage)

    End Sub


    '========================================================
    ' STUDENTS
    '========================================================
    Private Sub btnStudents_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnStudents.Click

        ShowStudents()

    End Sub


    Private Sub ShowStudents()

        ShowUserControl(studentsPage)

    End Sub


    '========================================================
    ' PRODUCTS
    '========================================================
    Private Sub btnProducts_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnProducts.Click

        ShowProducts()

    End Sub


    Private Sub ShowProducts()

        ShowUserControl(productsPage)

    End Sub


    '========================================================
    ' TRANSACTIONS
    '========================================================
    Private Sub btnTransaction_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnTransaction.Click

        ShowTransactions()

    End Sub


    Private Sub ShowTransactions()

        ShowUserControl(transactionPage)

    End Sub


    '========================================================
    ' SHOW USERCONTROL
    '========================================================
    Private Sub ShowUserControl(
        userControl As UserControl
    )

        ' If the page is already inside pnlContent,
        ' do not add it again.
        If pnlContent.Controls.Contains(userControl) Then

            userControl.BringToFront()

            Return

        End If


        ' Remove the current page
        pnlContent.Controls.Clear()


        ' Make the page fill the content panel
        userControl.Dock = DockStyle.Fill


        ' Add the page
        pnlContent.Controls.Add(userControl)


        ' Bring it to the front
        userControl.BringToFront()

    End Sub


    '========================================================
    ' LOGOUT
    '========================================================
    Private Sub btnLogout_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnLogout.Click

        ' Ask for confirmation
        Dim answer As DialogResult =
            MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            )


        ' User selected No
        If answer <> DialogResult.Yes Then

            Return

        End If


        '====================================================
        ' CREATE LOGIN FORM
        '====================================================
        Dim loginForm As New Form1()


        '====================================================
        ' SHOW LOGIN FORM FIRST
        '====================================================
        loginForm.Show()


        '====================================================
        ' HIDE ADMIN FORM
        '====================================================
        Me.Hide()


        '====================================================
        ' DISPOSE ADMIN FORM
        '====================================================
        Me.Dispose()

    End Sub


End Class
