Imports System.Data
Imports System.Drawing

Public Class UC_WalletHistory

    Private ReadOnly walletService As New WalletService()
    Private ReadOnly walletHistoryService As New WalletHistoryService()

    '========================================================
    ' FORM LOAD
    '========================================================
    Private Sub UC_WalletHistory_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        SetupWalletHistoryGrid()

        lblWalletBalance.Text = "₱0.00"
        lblStudentName.Text = "Student Name: -"
        dgvWalletHistory.DataSource = Nothing

    End Sub


    '========================================================
    ' SETUP GRID (Original Design + Color Formatting)
    '========================================================
    Private Sub SetupWalletHistoryGrid()

        dgvWalletHistory.Columns.Clear()
        dgvWalletHistory.AutoGenerateColumns = False
        dgvWalletHistory.AllowUserToAddRows = False
        dgvWalletHistory.AllowUserToDeleteRows = False
        dgvWalletHistory.ReadOnly = True
        dgvWalletHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvWalletHistory.MultiSelect = False
        dgvWalletHistory.RowHeadersVisible = False
        dgvWalletHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        ' THIS LINE MAKES ROWS GROW TALLER IF TEXT WRAPS
        dgvWalletHistory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

        dgvWalletHistory.Columns.Add(
            New DataGridViewTextBoxColumn With {
                .Name = "TransactionType",
                .HeaderText = "Type",
                .DataPropertyName = "Transaction Type",
                .FillWeight = 80
            })

        Dim amountColumn As New DataGridViewTextBoxColumn With {
            .Name = "Amount",
            .HeaderText = "Amount",
            .DataPropertyName = "Amount",
            .FillWeight = 90
        }
        amountColumn.DefaultCellStyle.Format = "₱#,##0.00"
        dgvWalletHistory.Columns.Add(amountColumn)

        Dim beforeColumn As New DataGridViewTextBoxColumn With {
            .Name = "BalanceBefore",
            .HeaderText = "Balance Before",
            .DataPropertyName = "Balance Before",
            .FillWeight = 100
        }
        beforeColumn.DefaultCellStyle.Format = "₱#,##0.00"
        dgvWalletHistory.Columns.Add(beforeColumn)

        Dim afterColumn As New DataGridViewTextBoxColumn With {
            .Name = "BalanceAfter",
            .HeaderText = "Balance After",
            .DataPropertyName = "Balance After",
            .FillWeight = 100
        }
        afterColumn.DefaultCellStyle.Format = "₱#,##0.00"
        dgvWalletHistory.Columns.Add(afterColumn)

        dgvWalletHistory.Columns.Add(
            New DataGridViewTextBoxColumn With {
                .Name = "Cashier",
                .HeaderText = "Cashier",
                .DataPropertyName = "Cashier",
                .FillWeight = 80
            })

        ' --- THIS IS THE FIXED DESCRIPTION COLUMN ---
        Dim descColumn As New DataGridViewTextBoxColumn With {
            .Name = "Description",
            .HeaderText = "Description",
            .DataPropertyName = "Description",
            .FillWeight = 200, ' Makes it twice as wide as the others
            .MinimumWidth = 150
        }
        descColumn.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgvWalletHistory.Columns.Add(descColumn)
        ' -------------------------------------------

        Dim dateColumn As New DataGridViewTextBoxColumn With {
            .Name = "Date",
            .HeaderText = "Date and Time",
            .DataPropertyName = "Date",
            .FillWeight = 110
        }
        dateColumn.DefaultCellStyle.Format = "MMM dd, yyyy hh:mm tt"
        dgvWalletHistory.Columns.Add(dateColumn)

    End Sub


    '========================================================
    ' COLOR-CODING TRANSACTIONS
    '========================================================
    Private Sub dgvWalletHistory_CellFormatting(
        sender As Object,
        e As DataGridViewCellFormattingEventArgs
    ) Handles dgvWalletHistory.CellFormatting

        If e.RowIndex < 0 OrElse e.Value Is Nothing Then Return

        If dgvWalletHistory.Columns(e.ColumnIndex).Name = "TransactionType" Then
            Dim type As String = e.Value.ToString()

            If type = "Wallet" OrElse type = "LOAD" Then
                e.CellStyle.ForeColor = Color.ForestGreen
                e.CellStyle.Font = New Font(dgvWalletHistory.Font, FontStyle.Bold)
            ElseIf type = "Payment" OrElse type = "PAYMENT" Then
                e.CellStyle.ForeColor = Color.Firebrick
                e.CellStyle.Font = New Font(dgvWalletHistory.Font, FontStyle.Bold)
            ElseIf type = "Refund" OrElse type = "REFUND" Then
                e.CellStyle.ForeColor = Color.RoyalBlue
                e.CellStyle.Font = New Font(dgvWalletHistory.Font, FontStyle.Bold)
            End If
        End If

    End Sub


    '========================================================
    ' SEARCH BUTTON CLICK
    '========================================================
    Private Sub btnSearch_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnSearch.Click

        SearchWalletHistory()

    End Sub


    '========================================================
    ' ENTER KEY TO SEARCH
    '========================================================
    Private Sub txtStudentID_KeyDown(
        sender As Object,
        e As KeyEventArgs
    ) Handles txtStudentID.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SearchWalletHistory()
        End If

    End Sub


    '========================================================
    ' SEARCH WALLET HISTORY
    '========================================================
    Private Sub SearchWalletHistory()

        Dim studentId As String = txtStudentID.Text.Trim()

        If String.IsNullOrWhiteSpace(studentId) Then
            MessageBox.Show("Please enter a student ID.", "Wallet History", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtStudentID.Focus()
            Return
        End If

        Try
            Dim balance As Decimal = walletService.GetWalletBalance(studentId)
            Dim studentName As String = walletService.GetStudentName(studentId)
            Dim historyTable As DataTable = walletHistoryService.GetWalletHistory(studentId)

            lblWalletBalance.Text = "₱" & balance.ToString("N2")
            lblStudentName.Text = "Student Name: " & studentName
            dgvWalletHistory.DataSource = historyTable

            If historyTable.Rows.Count = 0 Then
                MessageBox.Show("The student has no wallet transactions yet.", "Wallet History", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            lblWalletBalance.Text = "₱0.00"
            lblStudentName.Text = "Student Name: -"
            dgvWalletHistory.DataSource = Nothing

            MessageBox.Show("Unable to load wallet information." & Environment.NewLine & Environment.NewLine & ex.Message, "Wallet History", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

End Class