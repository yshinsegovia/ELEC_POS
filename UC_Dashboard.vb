
Imports MySqlConnector
Imports System.Data
Imports System.Collections.Generic
Imports System.Text

Public Class UC_Dashboard

    '========================================================
    ' SERVICE
    '========================================================
    Private ReadOnly dashboardService As New DashboardService()

    '========================================================
    ' REFRESH TIMER
    '========================================================
    Private ReadOnly dashboardTimer As New Timer()

    '========================================================
    ' STOCK NOTIFICATION TRACKING
    '========================================================
    Private ReadOnly notifiedStockStates As New Dictionary(Of Integer, String)()

    Private stockNotificationErrorShown As Boolean = False


    '========================================================
    ' USERCONTROL LOAD
    '========================================================
    Private Sub UC_Dashboard_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        SetupRecentOrdersGrid()

        LoadDashboard()

        CheckStockNotifications()

        dashboardTimer.Interval = 5000

        AddHandler dashboardTimer.Tick,
            AddressOf DashboardTimer_Tick

        dashboardTimer.Start()

    End Sub


    '========================================================
    ' SETUP RECENT ORDERS GRID
    '========================================================
    Private Sub SetupRecentOrdersGrid()

        dgvRecentOrders.AutoGenerateColumns = True
        dgvRecentOrders.AllowUserToAddRows = False
        dgvRecentOrders.AllowUserToDeleteRows = False
        dgvRecentOrders.ReadOnly = True

        dgvRecentOrders.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect

        dgvRecentOrders.MultiSelect = False
        dgvRecentOrders.RowHeadersVisible = False

        dgvRecentOrders.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill

    End Sub


    '========================================================
    ' LOAD DASHBOARD
    '========================================================
    Private Sub LoadDashboard()

        Try

            Dim totalOrders As Integer =
                dashboardService.GetTotalOrders()

            lblTotalOrders.Text = totalOrders.ToString()


            Dim totalSales As Decimal =
                dashboardService.GetTotalSales()

            lblTotalSales.Text = "₱" & totalSales.ToString("N2")


            Dim totalStudents As Integer =
                dashboardService.GetTotalStudents()

            lblTotalStudents.Text = totalStudents.ToString()


            Dim lowStock As Integer =
                dashboardService.GetLowStockCount()

            lblLowStockCount.Text = lowStock.ToString()


            Dim recentOrders As DataTable =
                dashboardService.GetRecentOrders()

            dgvRecentOrders.DataSource = recentOrders


            If dgvRecentOrders.Columns.Contains("Date") Then

                dgvRecentOrders.Columns("Date").DefaultCellStyle.Format =
                    "MMM dd, yyyy hh:mm tt"

            End If


            If dgvRecentOrders.Columns.Contains("Total") Then

                dgvRecentOrders.Columns("Total").DefaultCellStyle.Format =
                    "₱#,##0.00"

            End If

        Catch ex As MySqlException

            MessageBox.Show(
                "Database error while loading Dashboard:" &
                Environment.NewLine & Environment.NewLine &
                ex.Message,
                "Dashboard",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        Catch ex As Exception

            MessageBox.Show(
                ex.Message,
                "Dashboard",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    '========================================================
    ' CHECK ADMIN STOCK NOTIFICATIONS
    '========================================================
    Private Sub CheckStockNotifications()

        Try

            Dim warningProducts As DataTable =
                dashboardService.GetStockWarnings()

            Dim currentStockStates As New Dictionary(Of Integer, String)()
            Dim alerts As New StringBuilder()


            For Each product As DataRow In warningProducts.Rows

                Dim stockId As Integer =
                    Convert.ToInt32(product("stock_id"))

                Dim itemName As String =
                    Convert.ToString(product("item_name"))

                Dim quantity As Integer =
                    Convert.ToInt32(product("quantity"))

                Dim unit As String =
                    Convert.ToString(product("unit"))

                Dim stockState As String

                If quantity <= 0 Then
                    stockState = "OUT OF STOCK"
                Else
                    stockState = "LOW STOCK"
                End If


                currentStockStates(stockId) = stockState


                Dim previousState As String = Nothing

                Dim isNewWarning As Boolean =
                    Not notifiedStockStates.ContainsKey(stockId)

                Dim statusChanged As Boolean = False

                If Not isNewWarning Then

                    previousState = notifiedStockStates(stockId)

                    If previousState <> stockState Then
                        statusChanged = True
                    End If

                End If


                If isNewWarning OrElse statusChanged Then

                    If stockState = "OUT OF STOCK" Then

                        alerts.AppendLine(
                            "- " & itemName &
                            " - OUT OF STOCK (Quantity: " &
                            quantity.ToString() & " " & unit & ")"
                        )

                    Else

                        alerts.AppendLine(
                            "- " & itemName &
                            " - LOW STOCK (Quantity: " &
                            quantity.ToString() & " " & unit & ")"
                        )

                    End If

                End If

            Next


            ' Update the tracked warning states.
            notifiedStockStates.Clear()

            For Each stockId As Integer In currentStockStates.Keys

                notifiedStockStates.Add(
                    stockId,
                    currentStockStates(stockId)
                )

            Next


            stockNotificationErrorShown = False


            ' Show one popup for all new stock warnings.
            If alerts.Length > 0 Then

                MessageBox.Show(
                    "Please check the following products:" &
                    Environment.NewLine & Environment.NewLine &
                    alerts.ToString(),
                    "HungryTable - Stock Alert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

            End If

        Catch ex As Exception

            If Not stockNotificationErrorShown Then

                stockNotificationErrorShown = True

                MessageBox.Show(
                    "Unable to check stock notifications." &
                    Environment.NewLine &
                    "Please check the database connection." &
                    Environment.NewLine & Environment.NewLine &
                    ex.Message,
                    "Stock Notification Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                )

            End If

        End Try

    End Sub


    '========================================================
    ' AUTOMATIC REFRESH
    '========================================================
    Private Sub DashboardTimer_Tick(
        sender As Object,
        e As EventArgs
    )

        LoadDashboard()

        CheckStockNotifications()

    End Sub


    '========================================================
    ' STOP TIMER WHEN USERCONTROL IS DISPOSED
    '========================================================
    Private Sub UC_Dashboard_Disposed(
        sender As Object,
        e As EventArgs
    ) Handles Me.Disposed

        dashboardTimer.Stop()
        dashboardTimer.Dispose()

    End Sub


    '========================================================
    ' LABEL EVENTS
    '========================================================
    Private Sub lblTotalOrders_Click(
        sender As Object,
        e As EventArgs
    ) Handles lblTotalOrders.Click

    End Sub


    Private Sub lblTotalSales_Click(
        sender As Object,
        e As EventArgs
    ) Handles lblTotalSales.Click

    End Sub


    Private Sub lblTotalStudents_Click(
        sender As Object,
        e As EventArgs
    ) Handles lblTotalStudents.Click

    End Sub


    Private Sub lblLowStockCount_Click(
        sender As Object,
        e As EventArgs
    ) Handles lblLowStockCount.Click

    End Sub


    Private Sub dgvRecentOrders_CellContentClick(
        sender As Object,
        e As DataGridViewCellEventArgs
    ) Handles dgvRecentOrders.CellContentClick

    End Sub

End Class
