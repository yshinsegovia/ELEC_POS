Public Class admin

    Private Sub admin_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        pnlSidebar.Dock = DockStyle.Left
        pnlContent.Dock = DockStyle.Fill

        ShowDashboard()

    End Sub


    '========================================
    ' DASHBOARD
    '========================================
    Private Sub btnDashboard_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnDashboard.Click

        ShowDashboard()

    End Sub


    Private Sub ShowDashboard()

        pnlContent.Controls.Clear()

        Dim dashboard As New UC_Dashboard()

        dashboard.Dock = DockStyle.Fill

        pnlContent.Controls.Add(dashboard)

        dashboard.BringToFront()

    End Sub


    '========================================
    ' STUDENTS
    '========================================
    Private Sub btnStudents_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnStudents.Click

        ShowStudents()

    End Sub


    Private Sub ShowStudents()

        pnlContent.Controls.Clear()

        Dim students As New UC_Students()

        students.Dock = DockStyle.Fill

        pnlContent.Controls.Add(students)

        students.BringToFront()

    End Sub


    '========================================
    ' PRODUCTS
    '========================================
    Private Sub btnProducts_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnProducts.Click

        ShowProducts()

    End Sub


    Private Sub ShowProducts()

        pnlContent.Controls.Clear()

        Dim products As New UC_Products()

        products.Dock = DockStyle.Fill

        pnlContent.Controls.Add(products)

        products.BringToFront()

    End Sub


    '========================================
    ' TRANSACTIONS
    '========================================
    Private Sub btnTransactions_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnTransaction.Click

        ShowTransactions()

    End Sub


    Private Sub ShowTransactions()

        pnlContent.Controls.Clear()

        Dim transactions As New UC_Transaction()

        transactions.Dock = DockStyle.Fill

        pnlContent.Controls.Add(transactions)

        transactions.BringToFront()

    End Sub

    '========================================
    ' LOGOUT
    '========================================
    Private Sub btnLogout_Click(
    sender As Object,
    e As EventArgs
) Handles btnLogout.Click

        Dim answer As DialogResult =
        MessageBox.Show(
            "Are you sure you want to logout?",
            "Logout",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        )

        If answer = DialogResult.Yes Then

            Dim loginForm As New Form1()

            loginForm.Show()

            Me.Close()

        End If

    End Sub
End Class