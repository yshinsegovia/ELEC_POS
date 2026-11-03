
Imports System.Data

Public Class UC_WalletHistory

    Private ReadOnly walletService As New WalletService()
    Private ReadOnly walletHistoryService As New WalletHistoryService()

    Private Sub UC_WalletHistory_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        SetupWalletHistoryGrid()

        lblWalletBalance.Text = "₱0.00"
        dgvWalletHistory.DataSource = Nothing

    End Sub

    Private Sub SetupWalletHistoryGrid()

        dgvWalletHistory.Columns.Clear()
        dgvWalletHistory.AutoGenerateColumns = False
        dgvWalletHistory.AllowUserToAddRows = False
        dgvWalletHistory.AllowUserToDeleteRows = False
        dgvWalletHistory.ReadOnly = True
        dgvWalletHistory.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect
        dgvWalletHistory.MultiSelect = False
        dgvWalletHistory.RowHeadersVisible = False
        dgvWalletHistory.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill

        dgvWalletHistory.Columns.Add(
            New DataGridViewTextBoxColumn With {
                .Name = "TransactionType",
                .HeaderText = "Type",
                .DataPropertyName = "Transaction Type"
            })

        Dim amountColumn As New DataGridViewTextBoxColumn With {
            .Name = "Amount",
            .HeaderText = "Amount",
            .DataPropertyName = "Amount"
        }
        amountColumn.DefaultCellStyle.Format = "₱#,##0.00"
        dgvWalletHistory.Columns.Add(amountColumn)

        Dim beforeColumn As New DataGridViewTextBoxColumn With {
            .Name = "BalanceBefore",
            .HeaderText = "Balance Before",
            .DataPropertyName = "Balance Before"
        }
        beforeColumn.DefaultCellStyle.Format = "₱#,##0.00"
        dgvWalletHistory.Columns.Add(beforeColumn)

        Dim afterColumn As New DataGridViewTextBoxColumn With {
            .Name = "BalanceAfter",
            .HeaderText = "Balance After",
            .DataPropertyName = "Balance After"
        }
        afterColumn.DefaultCellStyle.Format = "₱#,##0.00"
        dgvWalletHistory.Columns.Add(afterColumn)

        dgvWalletHistory.Columns.Add(
            New DataGridViewTextBoxColumn With {
                .Name = "Cashier",
                .HeaderText = "Cashier",
                .DataPropertyName = "Cashier"
            })

        dgvWalletHistory.Columns.Add(
            New DataGridViewTextBoxColumn With {
                .Name = "Description",
                .HeaderText = "Description",
                .DataPropertyName = "Description"
            })

        Dim dateColumn As New DataGridViewTextBoxColumn With {
            .Name = "Date",
            .HeaderText = "Date and Time",
            .DataPropertyName = "Date"
        }
        dateColumn.DefaultCellStyle.Format =
            "MMM dd, yyyy hh:mm tt"
        dgvWalletHistory.Columns.Add(dateColumn)

    End Sub

    Private Sub btnSearch_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnSearch.Click

        SearchWalletHistory()

    End Sub

    Private Sub txtStudentID_KeyDown(
        sender As Object,
        e As KeyEventArgs
    ) Handles txtStudentID.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SearchWalletHistory()
        End If

    End Sub

    Private Sub SearchWalletHistory()

        Dim studentId As String = txtStudentID.Text.Trim()

        If String.IsNullOrWhiteSpace(studentId) Then
            MessageBox.Show(
                "Please enter a student ID.",
                "Wallet History",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )
            txtStudentID.Focus()
            Return
        End If

        Try

            Dim balance As Decimal =
                walletService.GetWalletBalance(studentId)

            Dim historyTable As DataTable =
                walletHistoryService.GetWalletHistory(studentId)

            lblWalletBalance.Text = "₱" & balance.ToString("N2")
            dgvWalletHistory.DataSource = historyTable

            If historyTable.Rows.Count = 0 Then
                MessageBox.Show(
                    "The student has no wallet transactions yet.",
                    "Wallet History",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                )
            End If

        Catch ex As Exception

            lblWalletBalance.Text = "₱0.00"
            dgvWalletHistory.DataSource = Nothing

            MessageBox.Show(
                "Unable to load wallet information." &
                Environment.NewLine & Environment.NewLine &
                ex.Message,
                "Wallet History",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


End Class
