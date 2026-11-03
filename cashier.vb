
Public Class cashier

    '========================================================
    ' USER CONTROL PAGES
    '========================================================
    Private newOrdersPage As UC_NewOrders
    Private ordersPage As UC_Orders
    Private historyPage As UC_History
    Private walletHistoryPage As UC_WalletHistory


    '========================================================
    ' FORM LOAD
    '========================================================
    Private Sub cashier_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        SetupLayout()

        InitializePages()

        LoadCashierName()

        ShowNewOrders()

    End Sub


    '========================================================
    ' SETUP LAYOUT
    '========================================================
    Private Sub SetupLayout()

        pnlCashierContent.Dock = DockStyle.Fill

    End Sub


    '========================================================
    ' INITIALIZE USER CONTROLS
    '========================================================
    Private Sub InitializePages()

        newOrdersPage = New UC_NewOrders()

        ordersPage = New UC_Orders()

        historyPage = New UC_History()

        walletHistoryPage = New UC_WalletHistory()

    End Sub


    '========================================================
    ' LOAD LOGGED-IN CASHIER NAME
    '========================================================
    Private Sub LoadCashierName()

        If CurrentSession.CurrentUser Is Nothing Then

            lblCashierName.Text = "Cashier"

            Return

        End If

        lblCashierName.Text =
            "" &
            CurrentSession.CurrentUser.Username

    End Sub


    '========================================================
    ' NEW ORDERS BUTTON
    '========================================================
    Private Sub btnNewOrders_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnNewOrders.Click

        ShowNewOrders()

    End Sub


    '========================================================
    ' SHOW NEW ORDERS
    '========================================================
    Private Sub ShowNewOrders()

        ShowUserControl(newOrdersPage)

    End Sub


    '========================================================
    ' ORDERS BUTTON
    '========================================================
    Private Sub btnOrders_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnOrders.Click

        ShowOrders()

    End Sub


    '========================================================
    ' SHOW ORDERS
    '========================================================
    Private Sub ShowOrders()

        ShowUserControl(ordersPage)

    End Sub


    '========================================================
    ' HISTORY BUTTON
    '========================================================
    Private Sub btnHistory_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnHistory.Click

        ShowHistory()

    End Sub


    '========================================================
    ' SHOW HISTORY
    '========================================================
    Private Sub ShowHistory()

        ShowUserControl(historyPage)

    End Sub


    '========================================================
    ' WALLET HISTORY BUTTON
    '========================================================
    Private Sub btncWalletHistory_Click(
        sender As Object,
        e As EventArgs
    ) Handles btncWalletHistory.Click

        ShowWalletHistory()

    End Sub


    '========================================================
    ' SHOW WALLET HISTORY
    '========================================================
    Private Sub ShowWalletHistory()

        ShowUserControl(walletHistoryPage)

    End Sub


    '========================================================
    ' SHOW USER CONTROL
    '========================================================
    Private Sub ShowUserControl(
        page As UserControl
    )

        If page Is Nothing Then
            Return
        End If

        '----------------------------------------------------
        ' If the page is already inside the content panel,
        ' bring it to the front.
        '----------------------------------------------------
        If pnlCashierContent.Controls.Contains(page) Then

            page.BringToFront()

            Return

        End If

        '----------------------------------------------------
        ' Remove the current page from the content panel.
        ' The UserControl objects remain available for reuse.
        '----------------------------------------------------
        pnlCashierContent.Controls.Clear()

        '----------------------------------------------------
        ' Fill the content panel.
        '----------------------------------------------------
        page.Dock = DockStyle.Fill

        '----------------------------------------------------
        ' Add the selected page.
        '----------------------------------------------------
        pnlCashierContent.Controls.Add(page)

        '----------------------------------------------------
        ' Bring the selected page to the front.
        '----------------------------------------------------
        page.BringToFront()

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

        '----------------------------------------------------
        ' Clear current session.
        '----------------------------------------------------
        CurrentSession.CurrentUser = Nothing

        '----------------------------------------------------
        ' Return to login.
        '----------------------------------------------------
        Dim loginForm As New Form1()

        loginForm.Show()

        '----------------------------------------------------
        ' Close the cashier form.
        '----------------------------------------------------
        Me.Hide()

        Me.Dispose()

    End Sub


    '========================================================
    ' DESIGNER EVENT
    '========================================================
    Private Sub pnlCashierContent_Paint(
        sender As Object,
        e As PaintEventArgs
    ) Handles pnlCashierContent.Paint

    End Sub


    '========================================================
    ' DESIGNER EVENT
    '========================================================
    Private Sub lblCashierName_Click(
        sender As Object,
        e As EventArgs
    )

    End Sub

End Class
