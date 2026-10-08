
Imports MySqlConnector
Imports System.Data

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
    ' USERCONTROL LOAD
    '========================================================
    Private Sub UC_Dashboard_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        SetupRecentOrdersGrid()

        LoadDashboard()


        '----------------------------------------------------
        ' REFRESH EVERY 5 SECONDS
        '----------------------------------------------------
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

            '------------------------------------------------
            ' TOTAL ORDERS
            '------------------------------------------------
            Dim totalOrders As Integer =
                dashboardService.GetTotalOrders()

            lblTotalOrders.Text =
                totalOrders.ToString()


            '------------------------------------------------
            ' TOTAL SALES
            '------------------------------------------------
            Dim totalSales As Decimal =
                dashboardService.GetTotalSales()

            lblTotalSales.Text =
                "₱" &
                totalSales.ToString("N2")


            '------------------------------------------------
            ' TOTAL STUDENTS
            '------------------------------------------------
            Dim totalStudents As Integer =
                dashboardService.GetTotalStudents()

            lblTotalStudents.Text =
                totalStudents.ToString()


            '------------------------------------------------
            ' LOW STOCK
            '------------------------------------------------
            Dim lowStock As Integer =
                dashboardService.GetLowStockCount()

            lblLowStockCount.Text =
                lowStock.ToString()


            '------------------------------------------------
            ' RECENT ORDERS
            '------------------------------------------------
            Dim recentOrders As DataTable =
                dashboardService.GetRecentOrders()

            dgvRecentOrders.DataSource =
                recentOrders


            '------------------------------------------------
            ' FORMAT DATE
            '------------------------------------------------
            If dgvRecentOrders.Columns.Contains(
                "Date"
            ) Then

                dgvRecentOrders.Columns(
                    "Date"
                ).DefaultCellStyle.Format =
                    "MMM dd, yyyy hh:mm tt"

            End If


            '------------------------------------------------
            ' FORMAT TOTAL
            '------------------------------------------------
            If dgvRecentOrders.Columns.Contains(
                "Total"
            ) Then

                dgvRecentOrders.Columns(
                    "Total"
                ).DefaultCellStyle.Format =
                    "₱#,##0.00"

            End If

        Catch ex As MySqlException

            MessageBox.Show(
                "Database error while loading Dashboard:" &
                Environment.NewLine &
                Environment.NewLine &
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
    ' AUTOMATIC REFRESH
    '========================================================
    Private Sub DashboardTimer_Tick(
        sender As Object,
        e As EventArgs
    )

        LoadDashboard()

    End Sub


    '========================================================
    ' STOP TIMER WHEN USERCONTROL IS DISPOSED
    '========================================================
    Private Sub UC_Dashboard_Disposed(
        sender As Object,
        e As EventArgs
    ) Handles Me.Disposed

        If dashboardTimer IsNot Nothing Then

            dashboardTimer.Stop()

            dashboardTimer.Dispose()

        End If

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
