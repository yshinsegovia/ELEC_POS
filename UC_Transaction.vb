Imports System.Data

Public Class UC_Transaction

    '========================================================
    ' SERVICE
    '========================================================
    Private ReadOnly transactionService As New TransactionService()


    '========================================================
    ' FORM LOAD
    '========================================================
    Private Sub UC_Transaction_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        SetupTransactionGrid()
        LoadTransactions()

    End Sub


    '========================================================
    ' SETUP GRID (Original Design Kept)
    '========================================================
    Private Sub SetupTransactionGrid()

        dgvTransaction.AutoGenerateColumns = True
        dgvTransaction.ReadOnly = True
        dgvTransaction.AllowUserToAddRows = False
        dgvTransaction.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect
        dgvTransaction.MultiSelect = False
        dgvTransaction.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill

    End Sub


    '========================================================
    ' LOAD ALL TRANSACTIONS
    '========================================================
    Private Sub LoadTransactions()

        Try

            dgvTransaction.DataSource =
                transactionService.GetTransactions()

            FormatTransactionGrid()
            UpdateSummaryFromGrid()

        Catch ex As Exception

            ShowError(
                "Unable to load transactions.",
                ex
            )

        End Try

    End Sub


    '========================================================
    ' FORMAT GRID (Original Design Kept)
    '========================================================
    Private Sub FormatTransactionGrid()

        If dgvTransaction.Columns.Count = 0 Then
            Return
        End If

        If dgvTransaction.Columns.Contains("transaction_id") Then
            dgvTransaction.Columns("transaction_id").HeaderText = "Transaction ID"
        End If

        If dgvTransaction.Columns.Contains("student_id") Then
            dgvTransaction.Columns("student_id").HeaderText = "Student ID"
        End If

        If dgvTransaction.Columns.Contains("cashier") Then
            dgvTransaction.Columns("cashier").HeaderText = "Cashier"
        End If

        If dgvTransaction.Columns.Contains("transaction_date") Then
            dgvTransaction.Columns("transaction_date").HeaderText = "Date"
            dgvTransaction.Columns("transaction_date").DefaultCellStyle.Format = "MMM dd, yyyy hh:mm tt"
        End If

        If dgvTransaction.Columns.Contains("total_amount") Then
            dgvTransaction.Columns("total_amount").HeaderText = "Total"
            dgvTransaction.Columns("total_amount").DefaultCellStyle.Format = "₱#,##0.00"
        End If

        If dgvTransaction.Columns.Contains("payment_method") Then
            dgvTransaction.Columns("payment_method").HeaderText = "Payment"
        End If

        If dgvTransaction.Columns.Contains("order_status") Then
            dgvTransaction.Columns("order_status").HeaderText = "Status"
        End If

    End Sub


    '========================================================
    ' UPDATE SUMMARY LABELS DYNAMICALLY
    ' (Calculates based on whatever is currently on screen)
    '========================================================
    Private Sub UpdateSummaryFromGrid()

        Dim totalCount As Integer = 0
        Dim totalSales As Decimal = 0D

        For Each row As DataGridViewRow In dgvTransaction.Rows

            If Not row.IsNewRow Then
                totalCount += 1

                If dgvTransaction.Columns.Contains("total_amount") AndAlso
                   row.Cells("total_amount").Value IsNot Nothing AndAlso
                   Not IsDBNull(row.Cells("total_amount").Value) Then

                    totalSales += Convert.ToDecimal(row.Cells("total_amount").Value)
                End If
            End If

        Next

        lblTotalTrascations.Text = totalCount.ToString("N0")
        lblTotalSales.Text = "₱" & totalSales.ToString("N2")

    End Sub


    '========================================================
    ' ALL RECORDS BUTTON
    '========================================================
    Private Sub btnAll_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnAll.Click

        ' Clears search and loads every transaction
        txtSearchProducts.Clear()
        LoadTransactions()

    End Sub


    '========================================================
    ' TODAY BUTTON
    '========================================================
    Private Sub btnToday_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnToday.Click

        Try

            dgvTransaction.DataSource =
                transactionService.GetTodayTransactions()

            FormatTransactionGrid()
            UpdateSummaryFromGrid() ' Updates labels for TODAY

        Catch ex As Exception

            ShowError(
                "Unable to load today's transactions.",
                ex
            )

        End Try

    End Sub


    '========================================================
    ' THIS WEEK BUTTON
    '========================================================
    Private Sub btnThisWeek_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnThisWeek.Click

        Try

            dgvTransaction.DataSource =
                transactionService.GetThisWeekTransactions()

            FormatTransactionGrid()
            UpdateSummaryFromGrid() ' Updates labels for THIS WEEK

        Catch ex As Exception

            ShowError(
                "Unable to load this week's transactions.",
                ex
            )

        End Try

    End Sub


    '========================================================
    ' THIS MONTH BUTTON
    '========================================================
    Private Sub btnThisMonth_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnThisMonth.Click

        Try

            dgvTransaction.DataSource =
                transactionService.GetThisMonthTransactions()

            FormatTransactionGrid()
            UpdateSummaryFromGrid() ' Updates labels for THIS MONTH

        Catch ex As Exception

            ShowError(
                "Unable to load this month's transactions.",
                ex
            )

        End Try

    End Sub


    '========================================================
    ' AUTO SEARCH WHILE TYPING (Replaces Search Button)
    '========================================================
    Private Sub txtSearchProducts_TextChanged(
        sender As Object,
        e As EventArgs
    ) Handles txtSearchProducts.TextChanged

        SearchTransactions()

    End Sub


    '========================================================
    ' SEARCH TRANSACTIONS
    '========================================================
    Private Sub SearchTransactions()

        Try

            Dim searchText As String =
                txtSearchProducts.Text.Trim()

            If searchText = "" Then

                LoadTransactions()
                Return

            End If

            dgvTransaction.DataSource =
                transactionService.SearchTransactions(
                    searchText
                )

            FormatTransactionGrid()
            UpdateSummaryFromGrid() ' Updates labels for SEARCH RESULTS

        Catch ex As Exception

            ShowError(
                "Unable to search transactions.",
                ex
            )

        End Try

    End Sub


    '========================================================
    ' CLICK TRANSACTION
    '========================================================
    Private Sub dgvTransaction_CellContentClick(
        sender As Object,
        e As DataGridViewCellEventArgs
    ) Handles dgvTransaction.CellContentClick

        If e.RowIndex < 0 Then
            Return
        End If

        Dim transactionID As Integer

        If Not Integer.TryParse(
            dgvTransaction.Rows(
                e.RowIndex
            ).Cells(
                "transaction_id"
            ).Value.ToString(),
            transactionID
        ) Then

            Return

        End If

        ShowTransactionDetails(transactionID)

    End Sub


    '========================================================
    ' SHOW TRANSACTION DETAILS
    '========================================================
    Private Sub ShowTransactionDetails(
        transactionID As Integer
    )

        Try

            Dim transactionInfo As DataTable =
                transactionService.GetTransactionInfo(
                    transactionID
                )

            If transactionInfo.Rows.Count = 0 Then

                MessageBox.Show(
                    "Transaction not found.",
                    "Transaction",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Return

            End If


            Dim row As DataRow =
                transactionInfo.Rows(0)

            Dim details As String =
                "TRANSACTION DETAILS" &
                Environment.NewLine &
                Environment.NewLine &
                "Transaction ID: " &
                row("transaction_id").ToString() &
                Environment.NewLine &
                "Student ID: " &
                row("student_id").ToString() &
                Environment.NewLine &
                "Cashier: " &
                row("cashier").ToString() &
                Environment.NewLine &
                "Date: " &
                Convert.ToDateTime(
                    row("transaction_date")
                ).ToString(
                    "MMMM dd, yyyy hh:mm tt"
                ) &
                Environment.NewLine &
                "Payment: " &
                row("payment_method").ToString() &
                Environment.NewLine &
                "Total: ₱" &
                Convert.ToDecimal(
                    row("total_amount")
                ).ToString("N2")


            Dim items As DataTable =
                transactionService.GetTransactionDetails(
                    transactionID
                )

            details &=
                Environment.NewLine &
                Environment.NewLine &
                "PRODUCTS" &
                Environment.NewLine &
                "--------------------------------" &
                Environment.NewLine


            For Each item As DataRow In items.Rows

                details &=
                    item("Product").ToString() &
                    " x" &
                    item("Quantity").ToString() &
                    " = ₱" &
                    Convert.ToDecimal(
                        item("Subtotal")
                    ).ToString("N2") &
                    Environment.NewLine

            Next


            MessageBox.Show(
                details,
                "Transaction Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

        Catch ex As Exception

            ShowError(
                "Unable to load transaction details.",
                ex
            )

        End Try

    End Sub


    '========================================================
    ' ERROR MESSAGE
    '========================================================
    Private Sub ShowError(
        message As String,
        ex As Exception
    )

        MessageBox.Show(
            message &
            Environment.NewLine &
            Environment.NewLine &
            ex.Message,
            "Transaction Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
        )

    End Sub

End Class