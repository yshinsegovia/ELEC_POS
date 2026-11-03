
Imports System.Collections.Generic

Public Class admin

    '========================================================
    ' USERCONTROL INSTANCES
    '========================================================
    Private dashboardPage As UC_Dashboard
    Private studentsPage As UC_Students
    Private productsPage As UC_Products
    Private transactionPage As UC_Transaction
    Private reportsPage As UC_Reports
    Private walletHistoryPage As UC_WalletHistory
    Private productEditHistoryPage As UC_ProductEditHistory
    Private walletLoadRequestsPage As UC_WalletLoadRequests


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
    ' SETUP LAYOUT
    '========================================================
    Private Sub SetupLayout()

        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Width = 240
        pnlSidebar.Visible = True

        pnlContent.Dock = DockStyle.Fill
        pnlContent.Visible = True

        btnDashboard.Visible = True
        btnStudents.Visible = True
        btnProducts.Visible = True
        btnTransaction.Visible = True
        btnReports.Visible = True
        btnWalletHistory.Visible = True
        btnProductEditHistory.Visible = True
        btnLogout.Visible = True

    End Sub


    '========================================================
    ' INITIALIZE ALL PAGES
    '========================================================
    Private Sub InitializePages()

        dashboardPage = New UC_Dashboard()
        studentsPage = New UC_Students()
        productsPage = New UC_Products()
        transactionPage = New UC_Transaction()
        reportsPage = New UC_Reports()
        walletHistoryPage = New UC_WalletHistory()

        'Initialize Product Edit History.
        productEditHistoryPage = New UC_ProductEditHistory()
        walletLoadRequestsPage = New UC_WalletLoadRequests()

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
    ' REPORTS
    '========================================================
    Private Sub btnReports_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnReports.Click

        ShowReports()

    End Sub

    Private Sub ShowReports()

        ShowUserControl(reportsPage)

    End Sub


    '========================================================
    ' WALLET HISTORY
    '========================================================
    Private Sub btnWalletHistory_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnWalletHistory.Click

        ShowWalletHistory()

    End Sub

    Private Sub ShowWalletHistory()

        ShowUserControl(walletHistoryPage)

    End Sub


    '========================================================
    ' PRODUCT EDIT HISTORY
    '========================================================
    Private Sub btnProductEditHistory_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnProductEditHistory.Click

        ShowProductEditHistory()

    End Sub

    Public Sub ShowProductEditHistory()

        If productEditHistoryPage Is Nothing Then
            productEditHistoryPage = New UC_ProductEditHistory()
        End If

        ShowUserControl(productEditHistoryPage)

    End Sub


    '========================================================
    ' DISPLAY SELECTED USERCONTROL
    '========================================================
    Private Sub ShowUserControl(
        userControl As UserControl
    )

        If userControl Is Nothing Then

            MessageBox.Show(
                "The selected page has not been initialized.",
                "Page Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

            Return

        End If

        If pnlContent.Controls.Contains(userControl) Then
            userControl.BringToFront()
            Return
        End If

        pnlContent.Controls.Clear()

        userControl.Dock = DockStyle.Fill

        pnlContent.Controls.Add(userControl)
        userControl.BringToFront()

    End Sub


    '========================================================
    ' OPEN BULK EDIT PRODUCTS PAGE
    '========================================================
    Public Sub ShowBulkEditProducts(
        stockIDs As List(Of Integer)
    )

        If stockIDs Is Nothing OrElse stockIDs.Count = 0 Then

            MessageBox.Show(
                "Please select at least one product.",
                "Bulk Edit",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        Dim bulkEditPage As New UC_BulkEditProducts()

        bulkEditPage.SetSelectedProducts(stockIDs)

        ShowUserControl(bulkEditPage)

    End Sub


    '========================================================
    ' RETURN TO PRODUCTS PAGE
    '========================================================
    Public Sub ReturnToProducts()

        ShowUserControl(productsPage)

        productsPage.RefreshProducts()

    End Sub


    '========================================================
    ' WALLET LOAD REQUESTS
    '========================================================
    Private Sub btnWalletLoadRequests_Click(
    sender As Object,
    e As EventArgs
) Handles btnWalletLoadRequests.Click

        ShowWalletLoadRequests()

    End Sub

    Private Sub ShowWalletLoadRequests()

        If walletLoadRequestsPage Is Nothing Then
            walletLoadRequestsPage = New UC_WalletLoadRequests()
        End If

        ShowUserControl(walletLoadRequestsPage)

    End Sub




    '========================================================
    ' LOGOUT
    '========================================================
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

        If answer <> DialogResult.Yes Then
            Return
        End If

        CurrentSession.CurrentUser = Nothing

        Dim loginForm As New Form1()
        loginForm.Show()

        Me.Close()

    End Sub


End Class
