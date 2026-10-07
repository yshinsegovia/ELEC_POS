Imports MySqlConnector
Imports System.Data

Public Class UC_Products

    '========================================================
    ' CURRENT CATEGORY
    '========================================================
    Private CurrentCategory As String = "All"

    '========================================================
    ' CURRENT EDITING ROW
    ' -1 means no row is being edited
    '========================================================
    Private EditingRowIndex As Integer = -1


    '========================================================
    ' FORM LOAD
    '========================================================
    Private Sub UC_Products_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        SetupProductGrid()
        LoadProducts()

    End Sub


    '========================================================
    ' SETUP PRODUCT GRID
    '========================================================
    Private Sub SetupProductGrid()

        dgvListofProducts.Columns.Clear()

        dgvListofProducts.AutoGenerateColumns = False
        dgvListofProducts.AllowUserToAddRows = False
        dgvListofProducts.AllowUserToDeleteRows = False

        'Read-only when not editing
        dgvListofProducts.ReadOnly = True

        dgvListofProducts.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect

        dgvListofProducts.MultiSelect = False
        dgvListofProducts.RowHeadersVisible = False


        '====================================================
        ' PRODUCT
        '====================================================
        Dim colProduct As New DataGridViewTextBoxColumn()

        colProduct.Name = "Product"
        colProduct.HeaderText = "Product"
        colProduct.AutoSizeMode =
            DataGridViewAutoSizeColumnMode.Fill

        dgvListofProducts.Columns.Add(colProduct)


        '====================================================
        ' CATEGORY
        '====================================================
        Dim colCategory As New DataGridViewTextBoxColumn()

        colCategory.Name = "Category"
        colCategory.HeaderText = "Category"
        colCategory.Width = 120

        dgvListofProducts.Columns.Add(colCategory)


        '====================================================
        ' PRICE
        '====================================================
        Dim colPrice As New DataGridViewTextBoxColumn()

        colPrice.Name = "Price"
        colPrice.HeaderText = "Price"
        colPrice.Width = 90

        dgvListofProducts.Columns.Add(colPrice)


        '====================================================
        ' STOCK
        '====================================================
        Dim colStock As New DataGridViewTextBoxColumn()

        colStock.Name = "Stock"
        colStock.HeaderText = "Stock"
        colStock.Width = 70

        dgvListofProducts.Columns.Add(colStock)


        '====================================================
        ' UNIT
        '====================================================
        Dim colUnit As New DataGridViewTextBoxColumn()

        colUnit.Name = "Unit"
        colUnit.HeaderText = "Unit"
        colUnit.Width = 80

        dgvListofProducts.Columns.Add(colUnit)


        '====================================================
        ' STATUS
        '====================================================
        Dim colStatus As New DataGridViewTextBoxColumn()

        colStatus.Name = "Status"
        colStatus.HeaderText = "Status"
        colStatus.Width = 110

        dgvListofProducts.Columns.Add(colStatus)


        '====================================================
        ' EDIT / SAVE BUTTON
        '====================================================
        Dim colEdit As New DataGridViewButtonColumn()

        colEdit.Name = "Edit"
        colEdit.HeaderText = "Action"
        colEdit.Width = 80

        'We will manually change the text
        colEdit.UseColumnTextForButtonValue = False

        dgvListofProducts.Columns.Add(colEdit)


        '====================================================
        ' HIDDEN STOCK ID
        '====================================================
        Dim colID As New DataGridViewTextBoxColumn()

        colID.Name = "StockID"
        colID.HeaderText = "Stock ID"
        colID.Visible = False

        dgvListofProducts.Columns.Add(colID)

    End Sub


    '========================================================
    ' LOAD PRODUCTS
    '========================================================
    Private Sub LoadProducts()

        Try

            'Do not allow loading while editing
            If EditingRowIndex <> -1 Then
                Return
            End If

            dgvListofProducts.Rows.Clear()

            Using conn As MySqlConnection = GetConnection()

                conn.Open()

                Dim query As String =
                    "SELECT stock_id, item_name, category, " &
                    "quantity, unit, price " &
                    "FROM stocks "

                Dim conditions As New List(Of String)

                Dim parameters As New List(Of MySqlParameter)


                '================================================
                ' CATEGORY FILTER
                '================================================
                If CurrentCategory <> "All" Then

                    conditions.Add(
                        "category = @category"
                    )

                    parameters.Add(
                        New MySqlParameter(
                            "@category",
                            CurrentCategory
                        )
                    )

                End If


                '================================================
                ' SEARCH FILTER
                '================================================
                If txtSearchProducts.Text.Trim() <> "" Then

                    conditions.Add(
                        "(item_name LIKE @search " &
                        "OR category LIKE @search)"
                    )

                    parameters.Add(
                        New MySqlParameter(
                            "@search",
                            "%" &
                            txtSearchProducts.Text.Trim() &
                            "%"
                        )
                    )

                End If


                '================================================
                ' ADD WHERE
                '================================================
                If conditions.Count > 0 Then

                    query &=
                        " WHERE " &
                        String.Join(
                            " AND ",
                            conditions
                        )

                End If


                '================================================
                ' SORT
                '================================================
                query &= " ORDER BY item_name ASC"


                Using cmd As New MySqlCommand(
                    query,
                    conn
                )

                    For Each parameter As MySqlParameter In parameters

                        cmd.Parameters.Add(parameter)

                    Next


                    Using reader As MySqlDataReader =
                        cmd.ExecuteReader()

                        While reader.Read()

                            Dim stockID As Integer =
                                Convert.ToInt32(
                                    reader("stock_id")
                                )

                            Dim itemName As String =
                                reader("item_name").ToString()

                            Dim category As String =
                                reader("category").ToString()

                            Dim quantity As Integer =
                                Convert.ToInt32(
                                    reader("quantity")
                                )

                            Dim unit As String =
                                reader("unit").ToString()

                            Dim price As Decimal =
                                Convert.ToDecimal(
                                    reader("price")
                                )


                            '================================================
                            ' AUTOMATIC STATUS
                            '================================================
                            Dim status As String

                            If quantity <= 0 Then

                                status = "Unavailable"

                            ElseIf quantity <= 10 Then

                                status = "Low Stock"

                            Else

                                status = "Available"

                            End If


                            '================================================
                            ' ADD ROW
                            '================================================
                            Dim rowIndex As Integer =
                                dgvListofProducts.Rows.Add(
                                    itemName,
                                    category,
                                    price.ToString("0.00"),
                                    quantity.ToString(),
                                    unit,
                                    status,
                                    "Edit",
                                    stockID
                                )


                            '================================================
                            ' MAKE ROW READ-ONLY
                            '================================================
                            For Each cell As DataGridViewCell In
                                dgvListofProducts.Rows(rowIndex).Cells

                                cell.ReadOnly = True

                            Next

                        End While

                    End Using

                End Using

            End Using


        Catch ex As MySqlException

            MessageBox.Show(
                "Database error:" &
                Environment.NewLine &
                Environment.NewLine &
                ex.Message,
                "Products",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )


        Catch ex As Exception

            MessageBox.Show(
                "Error loading products:" &
                Environment.NewLine &
                Environment.NewLine &
                ex.Message,
                "Products",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    '========================================================
    ' ALL
    '========================================================
    Private Sub btnAll_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnAll.Click

        If EditingRowIndex <> -1 Then

            MessageBox.Show(
                "Please save the current product first.",
                "Products",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            Return

        End If

        CurrentCategory = "All"

        LoadProducts()

    End Sub


    '========================================================
    ' RICE MEALS
    '========================================================
    Private Sub btnRiceMeal_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnRiceMeal.Click

        If EditingRowIndex <> -1 Then

            MessageBox.Show(
                "Please save the current product first.",
                "Products",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            Return

        End If

        CurrentCategory = "Rice Meals"

        LoadProducts()

    End Sub


    '========================================================
    ' DRINKS
    '========================================================
    Private Sub btnDrinks_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnDrinks.Click

        If EditingRowIndex <> -1 Then

            MessageBox.Show(
                "Please save the current product first.",
                "Products",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            Return

        End If

        CurrentCategory = "Drinks"

        LoadProducts()

    End Sub


    '========================================================
    ' SNACKS
    '========================================================
    Private Sub btnSnacks_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnSnacks.Click

        If EditingRowIndex <> -1 Then

            MessageBox.Show(
                "Please save the current product first.",
                "Products",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            Return

        End If

        CurrentCategory = "Snacks"

        LoadProducts()

    End Sub


    '========================================================
    ' DESSERTS
    '========================================================
    Private Sub btnDesserts_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnDesserts.Click

        If EditingRowIndex <> -1 Then

            MessageBox.Show(
                "Please save the current product first.",
                "Products",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            Return

        End If

        CurrentCategory = "Desserts"

        LoadProducts()

    End Sub


    '========================================================
    ' SEARCH BUTTON
    '========================================================
    Private Sub btnSearchP_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnSearchP.Click

        If EditingRowIndex <> -1 Then

            MessageBox.Show(
                "Please save the current product first.",
                "Products",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            Return

        End If

        LoadProducts()

    End Sub


    '========================================================
    ' SEARCH TEXTBOX
    '========================================================
    Private Sub txtSearchProducts_TextChanged(
        sender As Object,
        e As EventArgs
    ) Handles txtSearchProducts.TextChanged

        If EditingRowIndex <> -1 Then
            Return
        End If

        LoadProducts()

    End Sub


    '========================================================
    ' ADD PRODUCT
    '========================================================
    Private Sub btnAddProducts_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnAddProducts.Click

        MessageBox.Show(
            "Add Product form will be created next.",
            "Products",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        )

    End Sub


    '========================================================
    ' EDIT / SAVE BUTTON
    '========================================================
    Private Sub dgvListofProducts_CellContentClick(
        sender As Object,
        e As DataGridViewCellEventArgs
    ) Handles dgvListofProducts.CellContentClick

        If e.RowIndex < 0 Then
            Return
        End If

        If e.ColumnIndex < 0 Then
            Return
        End If


        'Only respond to Edit column
        If dgvListofProducts.Columns(
            e.ColumnIndex
        ).Name <> "Edit" Then

            Return

        End If


        '====================================================
        ' NO ROW CURRENTLY EDITING
        '====================================================
        If EditingRowIndex = -1 Then

            StartEditing(e.RowIndex)

            Return

        End If


        '====================================================
        ' SAME ROW = SAVE
        '====================================================
        If EditingRowIndex = e.RowIndex Then

            SaveEditing(e.RowIndex)

            Return

        End If


        '====================================================
        ' ANOTHER ROW
        '====================================================
        MessageBox.Show(
            "Please save the current product first.",
            "Products",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        )

    End Sub


    '========================================================
    ' START EDITING
    '========================================================
    Private Sub StartEditing(
        rowIndex As Integer
    )

        EditingRowIndex = rowIndex


        '====================================================
        ' ENABLE GRID EDITING
        '====================================================
        dgvListofProducts.ReadOnly = False


        '====================================================
        ' FIRST: MAKE EVERY CELL READ-ONLY
        '====================================================
        For Each cell As DataGridViewCell In
            dgvListofProducts.Rows(rowIndex).Cells

            cell.ReadOnly = True

        Next


        '====================================================
        ' ALLOW THESE CELLS TO BE EDITED
        '====================================================
        dgvListofProducts.Rows(rowIndex).
            Cells("Product").
            ReadOnly = False

        dgvListofProducts.Rows(rowIndex).
            Cells("Category").
            ReadOnly = False

        dgvListofProducts.Rows(rowIndex).
            Cells("Price").
            ReadOnly = False

        dgvListofProducts.Rows(rowIndex).
            Cells("Stock").
            ReadOnly = False

        dgvListofProducts.Rows(rowIndex).
            Cells("Unit").
            ReadOnly = False


        '====================================================
        ' STATUS CANNOT BE EDITED
        '====================================================
        dgvListofProducts.Rows(rowIndex).
            Cells("Status").
            ReadOnly = True


        '====================================================
        ' STOCK ID CANNOT BE EDITED
        '====================================================
        dgvListofProducts.Rows(rowIndex).
            Cells("StockID").
            ReadOnly = True


        '====================================================
        ' CHANGE EDIT TO SAVE
        '====================================================
        dgvListofProducts.Rows(rowIndex).
            Cells("Edit").
            Value = "Save"


        '====================================================
        ' SELECT ROW
        '====================================================
        dgvListofProducts.ClearSelection()

        dgvListofProducts.Rows(rowIndex).
            Selected = True


        '====================================================
        ' SELECT PRODUCT CELL
        '====================================================
        dgvListofProducts.CurrentCell =
            dgvListofProducts.Rows(rowIndex).
            Cells("Product")


        '====================================================
        ' START EDIT MODE
        '====================================================
        dgvListofProducts.BeginEdit(True)

    End Sub


    '========================================================
    ' SAVE EDITING
    '========================================================
    Private Sub SaveEditing(
        rowIndex As Integer
    )

        '====================================================
        ' IMPORTANT:
        ' FINISH CURRENT CELL EDIT FIRST
        '====================================================
        dgvListofProducts.EndEdit()


        Try

            '================================================
            ' GET VALUES
            '================================================
            Dim productName As String =
                Convert.ToString(
                    dgvListofProducts.Rows(rowIndex).
                    Cells("Product").Value
                ).Trim()


            Dim category As String =
                Convert.ToString(
                    dgvListofProducts.Rows(rowIndex).
                    Cells("Category").Value
                ).Trim()


            Dim priceText As String =
                Convert.ToString(
                    dgvListofProducts.Rows(rowIndex).
                    Cells("Price").Value
                ).Trim()


            Dim stockText As String =
                Convert.ToString(
                    dgvListofProducts.Rows(rowIndex).
                    Cells("Stock").Value
                ).Trim()


            Dim unit As String =
                Convert.ToString(
                    dgvListofProducts.Rows(rowIndex).
                    Cells("Unit").Value
                ).Trim()


            Dim stockID As Integer =
                Convert.ToInt32(
                    dgvListofProducts.Rows(rowIndex).
                    Cells("StockID").Value
                )


            '================================================
            ' VALIDATE PRODUCT NAME
            '================================================
            If productName = "" Then

                MessageBox.Show(
                    "Product name cannot be empty.",
                    "Products",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Return

            End If


            '================================================
            ' VALIDATE CATEGORY
            '================================================
            If category = "" Then

                MessageBox.Show(
                    "Category cannot be empty.",
                    "Products",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Return

            End If


            '================================================
            ' VALIDATE PRICE
            '================================================
            Dim price As Decimal

            If Not Decimal.TryParse(
                priceText,
                price
            ) Then

                MessageBox.Show(
                    "Please enter a valid price.",
                    "Products",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Return

            End If


            If price < 0 Then

                MessageBox.Show(
                    "Price cannot be negative.",
                    "Products",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Return

            End If


            '================================================
            ' VALIDATE STOCK
            '================================================
            Dim quantity As Integer

            If Not Integer.TryParse(
                stockText,
                quantity
            ) Then

                MessageBox.Show(
                    "Stock must be a whole number.",
                    "Products",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Return

            End If


            If quantity < 0 Then

                MessageBox.Show(
                    "Stock cannot be negative.",
                    "Products",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Return

            End If


            '================================================
            ' VALIDATE UNIT
            '================================================
            If unit = "" Then

                MessageBox.Show(
                    "Unit cannot be empty.",
                    "Products",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Return

            End If


            '================================================
            ' AUTOMATIC STATUS
            '================================================
            Dim status As String

            If quantity <= 0 Then

                status = "Unavailable"

            ElseIf quantity <= 10 Then

                status = "Low Stock"

            Else

                status = "Available"

            End If


            '================================================
            ' CONFIRM SAVE
            '================================================
            Dim answer As DialogResult =
                MessageBox.Show(
                    "Save changes to this product?",
                    "Save Product",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                )


            If answer <> DialogResult.Yes Then

                Return

            End If


            '================================================
            ' UPDATE DATABASE
            '================================================
            Using conn As MySqlConnection =
                GetConnection()

                conn.Open()


                Dim query As String =
                    "UPDATE stocks SET " &
                    "item_name = @item_name, " &
                    "category = @category, " &
                    "quantity = @quantity, " &
                    "unit = @unit, " &
                    "price = @price, " &
                    "status = @status " &
                    "WHERE stock_id = @stock_id"


                Using cmd As New MySqlCommand(
                    query,
                    conn
                )

                    cmd.Parameters.AddWithValue(
                        "@item_name",
                        productName
                    )

                    cmd.Parameters.AddWithValue(
                        "@category",
                        category
                    )

                    cmd.Parameters.AddWithValue(
                        "@quantity",
                        quantity
                    )

                    cmd.Parameters.AddWithValue(
                        "@unit",
                        unit
                    )

                    cmd.Parameters.AddWithValue(
                        "@price",
                        price
                    )

                    cmd.Parameters.AddWithValue(
                        "@status",
                        status
                    )

                    cmd.Parameters.AddWithValue(
                        "@stock_id",
                        stockID
                    )


                    Dim result As Integer =
                        cmd.ExecuteNonQuery()


                    If result <= 0 Then

                        MessageBox.Show(
                            "Product was not updated.",
                            "Products",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        )

                        Return

                    End If

                End Using

            End Using


            '================================================
            ' SUCCESS
            '================================================
            MessageBox.Show(
                "Product updated successfully!",
                "Products",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )


            '================================================
            ' RESET EDIT MODE
            '================================================
            dgvListofProducts.EndEdit()

            dgvListofProducts.ReadOnly = True

            EditingRowIndex = -1


            '================================================
            ' RELOAD PRODUCTS
            '================================================
            LoadProducts()


        Catch ex As MySqlException

            MessageBox.Show(
                "Database error while saving:" &
                Environment.NewLine &
                Environment.NewLine &
                ex.Message,
                "Products",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )


        Catch ex As Exception

            MessageBox.Show(
                "Error saving product:" &
                Environment.NewLine &
                Environment.NewLine &
                ex.Message,
                "Products",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

End Class