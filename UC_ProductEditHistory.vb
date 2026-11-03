
Imports MySqlConnector
Imports System.Data

Public Class UC_ProductEditHistory

    '========================================================
    ' LOAD PAGE
    '========================================================
    Private Sub UC_ProductEditHistory_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        SetupGrid()
        LoadHistory()

    End Sub

    '========================================================
    ' SETUP DATAGRIDVIEW
    '========================================================
    Private Sub SetupGrid()

        With dgvProductEditHistory
            .AutoGenerateColumns = True
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .RowHeadersVisible = False
            .AllowUserToOrderColumns = True
        End With

    End Sub

    '========================================================
    ' LOAD ALL HISTORY
    '========================================================
    Private Sub LoadHistory()

        Dim table As New DataTable()

        Try

            Using conn As MySqlConnection = GetConnection()

                conn.Open()

                Dim query As String =
                    "SELECT history_id, batch_id, stock_id, " &
                    "product_name, field_name, old_value, new_value, " &
                    "changed_by, changed_at " &
                    "FROM product_edit_history " &
                    "ORDER BY changed_at DESC, history_id DESC"

                Using cmd As New MySqlCommand(query, conn)

                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(table)
                    End Using

                End Using

            End Using

            dgvProductEditHistory.DataSource = table
            FormatGrid()

            If table.Rows.Count = 0 Then

                MessageBox.Show(
                    "No product edit history was found." &
                    Environment.NewLine &
                    "Edit a product using Bulk Edit to record a new history entry.",
                    "No History Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                )

            End If

        Catch ex As Exception

            MessageBox.Show(
                "Could not load product edit history." &
                Environment.NewLine & ex.Message,
                "History Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    '========================================================
    ' FORMAT GRID COLUMNS
    '========================================================
    Private Sub FormatGrid()

        If dgvProductEditHistory.Columns.Count = 0 Then Return

        SetColumnHeader("history_id", "History ID")
        SetColumnHeader("batch_id", "Batch ID")
        SetColumnHeader("stock_id", "Stock ID")
        SetColumnHeader("product_name", "Product")
        SetColumnHeader("field_name", "Field Changed")
        SetColumnHeader("old_value", "Old Value")
        SetColumnHeader("new_value", "New Value")
        SetColumnHeader("changed_by", "Changed By")
        SetColumnHeader("changed_at", "Date Changed")

        'Date formatting
        If dgvProductEditHistory.Columns.Contains("changed_at") Then

            dgvProductEditHistory.Columns("changed_at").
                DefaultCellStyle.Format = "MMM dd, yyyy hh:mm tt"

            dgvProductEditHistory.Columns("changed_at").FillWeight = 125

        End If

        'History ID
        If dgvProductEditHistory.Columns.Contains("history_id") Then
            dgvProductEditHistory.Columns("history_id").FillWeight = 55
        End If

        'Batch ID
        If dgvProductEditHistory.Columns.Contains("batch_id") Then

            With dgvProductEditHistory.Columns("batch_id")
                .FillWeight = 170
                .MinimumWidth = 180
                .DefaultCellStyle.WrapMode =
                    DataGridViewTriState.False
                .DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleLeft
            End With

        End If

        'Stock ID
        If dgvProductEditHistory.Columns.Contains("stock_id") Then
            dgvProductEditHistory.Columns("stock_id").FillWeight = 55
        End If

        'Product name
        If dgvProductEditHistory.Columns.Contains("product_name") Then
            dgvProductEditHistory.Columns("product_name").FillWeight = 110
        End If

        'Field changed
        If dgvProductEditHistory.Columns.Contains("field_name") Then
            dgvProductEditHistory.Columns("field_name").FillWeight = 80
        End If

        'Old value
        If dgvProductEditHistory.Columns.Contains("old_value") Then
            dgvProductEditHistory.Columns("old_value").FillWeight = 80
        End If

        'New value
        If dgvProductEditHistory.Columns.Contains("new_value") Then
            dgvProductEditHistory.Columns("new_value").FillWeight = 80
        End If

        'Changed by
        If dgvProductEditHistory.Columns.Contains("changed_by") Then
            dgvProductEditHistory.Columns("changed_by").FillWeight = 85
        End If

    End Sub

    '========================================================
    ' SET COLUMN HEADER
    '========================================================
    Private Sub SetColumnHeader(
        columnName As String,
        headerText As String
    )

        If dgvProductEditHistory.Columns.Contains(columnName) Then
            dgvProductEditHistory.Columns(columnName).HeaderText = headerText
        End If

    End Sub

    '========================================================
    ' SEARCH BUTTON
    '========================================================
    Private Sub btnSearch_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnSearch.Click

        SearchHistory()

    End Sub

    '========================================================
    ' SEARCH WHEN ENTER IS PRESSED
    '========================================================
    Private Sub txtSearch_KeyDown(
        sender As Object,
        e As KeyEventArgs
    ) Handles txtSearch.KeyDown

        If e.KeyCode = Keys.Enter Then

            e.SuppressKeyPress = True
            SearchHistory()

        End If

    End Sub

    '========================================================
    ' SEARCH HISTORY
    '========================================================
    Private Sub SearchHistory()

        Dim searchText As String = txtSearch.Text.Trim()
        Dim table As New DataTable()

        Try

            Using conn As MySqlConnection = GetConnection()

                conn.Open()

                Dim query As String =
                    "SELECT history_id, batch_id, stock_id, " &
                    "product_name, field_name, old_value, new_value, " &
                    "changed_by, changed_at " &
                    "FROM product_edit_history " &
                    "WHERE CAST(history_id AS CHAR) LIKE @search " &
                    "OR CAST(batch_id AS CHAR) LIKE @search " &
                    "OR CAST(stock_id AS CHAR) LIKE @search " &
                    "OR product_name LIKE @search " &
                    "OR field_name LIKE @search " &
                    "OR old_value LIKE @search " &
                    "OR new_value LIKE @search " &
                    "OR changed_by LIKE @search " &
                    "OR CAST(changed_at AS CHAR) LIKE @search " &
                    "ORDER BY changed_at DESC, history_id DESC"

                Using cmd As New MySqlCommand(query, conn)

                    cmd.Parameters.Add(
                        "@search",
                        MySqlDbType.VarChar
                    ).Value = "%" & searchText & "%"

                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(table)
                    End Using

                End Using

            End Using

            dgvProductEditHistory.DataSource = table
            FormatGrid()

            If table.Rows.Count = 0 Then

                MessageBox.Show(
                    "No matching history was found.",
                    "Search Result",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                )

            End If

        Catch ex As Exception

            MessageBox.Show(
                "Could not search product edit history." &
                Environment.NewLine & ex.Message,
                "Search Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    '========================================================
    ' REFRESH BUTTON
    '========================================================
    Private Sub btnRefresh_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnRefresh.Click

        txtSearch.Clear()
        LoadHistory()

    End Sub

End Class
