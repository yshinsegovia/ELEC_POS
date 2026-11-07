Imports MySqlConnector
Imports System.Data
Imports System.Collections.Generic

Public Class UC_Products

    '========================================================
    ' SERVICE
    '========================================================
    Private ReadOnly productService As New ProductService()

    '========================================================
    ' CURRENT CATEGORY FILTER
    '========================================================
    Private CurrentCategory As String = "All"

    '========================================================
    ' CURRENT PRODUCT BEING EDITED
    '========================================================
    Private EditingStockID As Integer = 0

    '========================================================
    ' GUARD FLAG — prevents filter events firing while
    ' we programmatically rebuild the dropdown list.
    '========================================================
    Private isLoadingFilter As Boolean = False

    '========================================================
    ' REFRESH PRODUCTS (used by Bulk Edit page)
    '========================================================
    Public Sub RefreshProducts()
        LoadProducts()
        LoadFilterCategories()
    End Sub

    '========================================================
    ' FORM LOAD
    '========================================================
    Private Sub UC_Products_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        pnlAddProduct.Visible = False
        pnlEditProduct.Visible = False

        SetupCategoryComboBox()
        SetupUnitComboBox()

        SetupEditCategoryComboBox()
        SetupEditUnitComboBox()

        SetupProductGrid()

        'Load the filter dropdown from the database.
        LoadFilterCategories()

        LoadProducts()

    End Sub

    '========================================================
    ' SETUP ADD CATEGORY COMBOBOX (from DB)
    '========================================================
    Private Sub SetupCategoryComboBox()

        cmbCategory.Items.Clear()

        For Each category As String In GetDistinctCategories()
            cmbCategory.Items.Add(category)
        Next

        cmbCategory.SelectedIndex = -1

    End Sub

    '========================================================
    ' SETUP ADD UNIT COMBOBOX
    '========================================================
    Private Sub SetupUnitComboBox()

        cmbUnit.Items.Clear()
        cmbUnit.Items.Add("pcs")
        cmbUnit.Items.Add("bottle")
        cmbUnit.Items.Add("cup")
        cmbUnit.Items.Add("pack")
        cmbUnit.Items.Add("box")
        cmbUnit.SelectedIndex = -1

    End Sub

    '========================================================
    ' SETUP EDIT CATEGORY COMBOBOX (from DB)
    '========================================================
    Private Sub SetupEditCategoryComboBox()

        cmbEditCategory.Items.Clear()

        For Each category As String In GetDistinctCategories()
            cmbEditCategory.Items.Add(category)
        Next

        cmbEditCategory.SelectedIndex = -1

    End Sub

    '========================================================
    ' SETUP EDIT UNIT COMBOBOX
    '========================================================
    Private Sub SetupEditUnitComboBox()

        cmbEditUnit.Items.Clear()
        cmbEditUnit.Items.Add("pcs")
        cmbEditUnit.Items.Add("bottle")
        cmbEditUnit.Items.Add("cup")
        cmbEditUnit.Items.Add("pack")
        cmbEditUnit.Items.Add("box")
        cmbEditUnit.SelectedIndex = -1

    End Sub

    '========================================================
    ' GET DISTINCT CATEGORIES FROM STOCKS TABLE
    '========================================================
    Private Function GetDistinctCategories() As List(Of String)

        Dim list As New List(Of String)()

        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()

                Const query As String =
                    "SELECT DISTINCT category FROM stocks " &
                    "WHERE category IS NOT NULL AND category <> '' " &
                    "ORDER BY category ASC"

                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            list.Add(reader("category").ToString())
                        End While
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading categories." & Environment.NewLine & ex.Message, "Categories", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return list

    End Function

    '========================================================
    ' LOAD FILTER DROPDOWN
    '========================================================
    Private Sub LoadFilterCategories()

        isLoadingFilter = True

        Try
            Dim current As String = "All"

            If cmbFilterCategory.SelectedItem IsNot Nothing Then
                current = cmbFilterCategory.SelectedItem.ToString()
            End If

            cmbFilterCategory.Items.Clear()
            cmbFilterCategory.Items.Add("All")

            For Each category As String In GetDistinctCategories()
                cmbFilterCategory.Items.Add(category)
            Next

            Dim found As Boolean = False
            For i As Integer = 0 To cmbFilterCategory.Items.Count - 1
                If cmbFilterCategory.Items(i).ToString() = current Then
                    cmbFilterCategory.SelectedIndex = i
                    found = True
                    Exit For
                End If
            Next

            If Not found Then
                cmbFilterCategory.SelectedIndex = 0
            End If

            CurrentCategory = cmbFilterCategory.SelectedItem.ToString()

        Finally
            isLoadingFilter = False
        End Try

    End Sub

    '========================================================
    ' FILTER DROPDOWN — SELECTION CHANGED
    '========================================================
    Private Sub cmbFilterCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFilterCategory.SelectedIndexChanged
        If isLoadingFilter Then Return
        If cmbFilterCategory.SelectedItem Is Nothing Then Return

        CurrentCategory = cmbFilterCategory.SelectedItem.ToString()

        If AnyPanelVisible() Then Return
        LoadProducts()
    End Sub

    '========================================================
    ' SETUP PRODUCT GRID (Original Design)
    '========================================================
    Private Sub SetupProductGrid()

        dgvListofProducts.Columns.Clear()

        dgvListofProducts.AutoGenerateColumns = False
        dgvListofProducts.AllowUserToAddRows = False
        dgvListofProducts.AllowUserToDeleteRows = False
        dgvListofProducts.ReadOnly = True
        dgvListofProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvListofProducts.MultiSelect = True
        dgvListofProducts.RowHeadersVisible = False
        dgvListofProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        Dim colProduct As New DataGridViewTextBoxColumn With {.Name = "Product", .HeaderText = "Product", .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill}
        dgvListofProducts.Columns.Add(colProduct)

        Dim colCategory As New DataGridViewTextBoxColumn With {.Name = "Category", .HeaderText = "Category", .Width = 120}
        dgvListofProducts.Columns.Add(colCategory)

        Dim colPrice As New DataGridViewTextBoxColumn With {.Name = "Price", .HeaderText = "Price", .Width = 90}
        colPrice.DefaultCellStyle.Format = "₱#,##0.00"
        dgvListofProducts.Columns.Add(colPrice)

        Dim colStock As New DataGridViewTextBoxColumn With {.Name = "Stock", .HeaderText = "Stock", .Width = 70}
        dgvListofProducts.Columns.Add(colStock)

        Dim colUnit As New DataGridViewTextBoxColumn With {.Name = "Unit", .HeaderText = "Unit", .Width = 80}
        dgvListofProducts.Columns.Add(colUnit)

        Dim colStatus As New DataGridViewTextBoxColumn With {.Name = "Status", .HeaderText = "Status", .Width = 110}
        dgvListofProducts.Columns.Add(colStatus)

        Dim colEdit As New DataGridViewButtonColumn With {.Name = "Edit", .HeaderText = "Action", .Text = "EDIT", .UseColumnTextForButtonValue = True, .Width = 80}
        dgvListofProducts.Columns.Add(colEdit)

        Dim colID As New DataGridViewTextBoxColumn With {.Name = "StockID", .HeaderText = "Stock ID", .Visible = False}
        dgvListofProducts.Columns.Add(colID)

    End Sub

    '========================================================
    ' LOAD PRODUCTS
    '========================================================
    Private Sub LoadProducts()

        Try
            Dim searchText As String = txtSearchProducts.Text.Trim()
            Dim table As DataTable = productService.GetProducts(CurrentCategory, searchText)

            dgvListofProducts.Rows.Clear()

            For Each row As DataRow In table.Rows
                AddProductRow(row)
            Next

        Catch ex As MySqlException
            ShowDatabaseError("loading products", ex)
        Catch ex As Exception
            MessageBox.Show("Error loading products:" & Environment.NewLine & ex.Message, "Products", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    '========================================================
    ' ADD PRODUCT ROW TO GRID
    '========================================================
    Private Sub AddProductRow(row As DataRow)

        Dim stockID As Integer = Convert.ToInt32(row("stock_id"))
        Dim productName As String = Convert.ToString(row("item_name"))
        Dim category As String = Convert.ToString(row("category"))
        Dim quantity As Integer = Convert.ToInt32(row("quantity"))
        Dim unit As String = Convert.ToString(row("unit"))
        Dim price As Decimal = Convert.ToDecimal(row("price"))
        Dim status As String = productService.GetStockStatus(quantity)

        dgvListofProducts.Rows.Add(productName, category, price, quantity, unit, status, "EDIT", stockID)

    End Sub

    '========================================================
    ' AUTO SEARCH WHILE TYPING
    '========================================================
    Private Sub txtSearchProducts_TextChanged(sender As Object, e As EventArgs) Handles txtSearchProducts.TextChanged
        If AnyPanelVisible() Then Return
        LoadProducts()
    End Sub

    '========================================================
    ' ADD PRODUCT
    '========================================================
    Private Sub btnAddProducts_Click(sender As Object, e As EventArgs) Handles btnAddProducts.Click
        If AnyPanelVisible() Then Return

        ClearAddProductFields()
        pnlEditProduct.Visible = False
        pnlAddProduct.Visible = True
        pnlAddProduct.BringToFront()
        txtProductName.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim productName As String = txtProductName.Text.Trim()
        Dim category As String = GetSelectedValue(cmbCategory)
        Dim unit As String = GetSelectedValue(cmbUnit)
        Dim price As Decimal
        Dim quantity As Integer

        If Not ValidateProductInput(productName, category, unit, txtPrice.Text.Trim(), txtQuantity.Text.Trim(), price, quantity) Then Return

        If MessageBox.Show("Add this product to the product list?", "Add Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return

        Try
            Dim success As Boolean = productService.AddProduct(productName, category, quantity, unit, price)

            If Not success Then
                MessageBox.Show("A product with this name already exists.", "Add Product", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtProductName.Focus()
                Return
            End If

            MessageBox.Show("Product added successfully!", "Add Product", MessageBoxButtons.OK, MessageBoxIcon.Information)

            CloseAddProductPanel()
            LoadProducts()
            LoadFilterCategories()
            SetupCategoryComboBox()
            SetupEditCategoryComboBox()

        Catch ex As MySqlException
            ShowDatabaseError("adding product", ex)
        Catch ex As Exception
            MessageBox.Show("Error adding product:" & Environment.NewLine & ex.Message, "Add Product", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MessageBox.Show("Are you sure you want to cancel?", "Add Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            CloseAddProductPanel()
        End If
    End Sub

    Private Sub CloseAddProductPanel()
        ClearAddProductFields()
        pnlAddProduct.Visible = False
    End Sub

    Private Sub ClearAddProductFields()
        txtProductName.Clear()
        txtPrice.Clear()
        txtQuantity.Clear()
        cmbCategory.SelectedIndex = -1
        cmbCategory.Text = ""
        cmbUnit.SelectedIndex = -1
    End Sub

    '========================================================
    ' EDIT PRODUCT
    '========================================================
    Private Sub dgvListofProducts_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListofProducts.CellContentClick
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return
        If dgvListofProducts.Columns(e.ColumnIndex).Name <> "Edit" Then Return
        OpenEditProduct(e.RowIndex)
    End Sub

    Private Sub OpenEditProduct(rowIndex As Integer)
        Try
            Dim row As DataGridViewRow = dgvListofProducts.Rows(rowIndex)

            If row.Cells("StockID").Value Is Nothing OrElse row.Cells("StockID").Value Is DBNull.Value Then
                MessageBox.Show("Unable to identify this product.", "Edit Product", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            EditingStockID = Convert.ToInt32(row.Cells("StockID").Value)
            txtEditProductName.Text = Convert.ToString(row.Cells("Product").Value)
            SelectComboBoxValue(cmbEditCategory, Convert.ToString(row.Cells("Category").Value))
            txtEditPrice.Text = Convert.ToDecimal(row.Cells("Price").Value).ToString("0.00")
            txtEditQuantity.Text = Convert.ToString(row.Cells("Stock").Value)
            SelectComboBoxValue(cmbEditUnit, Convert.ToString(row.Cells("Unit").Value))

            pnlAddProduct.Visible = False
            pnlEditProduct.Visible = True
            pnlEditProduct.BringToFront()
            txtEditProductName.Focus()

        Catch ex As Exception
            MessageBox.Show("Unable to open product for editing:" & Environment.NewLine & ex.Message, "Edit Product", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdateProduct_Click(sender As Object, e As EventArgs) Handles btnUpdateProduct.Click
        If EditingStockID <= 0 Then
            MessageBox.Show("No product is selected for editing.", "Edit Product", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim productName As String = txtEditProductName.Text.Trim()
        Dim category As String = GetSelectedValue(cmbEditCategory)
        Dim unit As String = GetSelectedValue(cmbEditUnit)
        Dim price As Decimal
        Dim quantity As Integer

        If Not ValidateProductInput(productName, category, unit, txtEditPrice.Text.Trim(), txtEditQuantity.Text.Trim(), price, quantity, True) Then Return

        If MessageBox.Show("Save changes to this product?", "Edit Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return

        Try
            Dim success As Boolean = productService.UpdateProduct(EditingStockID, productName, category, quantity, unit, price)

            If Not success Then
                MessageBox.Show("A different product already uses this name.", "Edit Product", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtEditProductName.Focus()
                Return
            End If

            MessageBox.Show("Product updated successfully!", "Edit Product", MessageBoxButtons.OK, MessageBoxIcon.Information)

            CloseEditProductPanel()
            LoadProducts()
            LoadFilterCategories()
            SetupCategoryComboBox()
            SetupEditCategoryComboBox()

        Catch ex As MySqlException
            ShowDatabaseError("updating product", ex)
        Catch ex As Exception
            MessageBox.Show("Error updating product:" & Environment.NewLine & ex.Message, "Edit Product", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancelEdit_Click(sender As Object, e As EventArgs) Handles btnCancelEdit.Click
        If MessageBox.Show("Are you sure you want to cancel?", "Edit Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            CloseEditProductPanel()
        End If
    End Sub

    Private Sub CloseEditProductPanel()
        EditingStockID = 0
        ClearEditProductFields()
        pnlEditProduct.Visible = False
    End Sub

    Private Sub ClearEditProductFields()
        txtEditProductName.Clear()
        txtEditPrice.Clear()
        txtEditQuantity.Clear()
        cmbEditCategory.SelectedIndex = -1
        cmbEditCategory.Text = ""
        cmbEditUnit.SelectedIndex = -1
    End Sub

    '========================================================
    ' VALIDATION & HELPERS
    '========================================================
    Private Function ValidateProductInput(productName As String, category As String, unit As String, priceText As String, quantityText As String, ByRef price As Decimal, ByRef quantity As Integer, Optional isEditing As Boolean = False) As Boolean
        Dim title As String = If(isEditing, "Edit Product", "Add Product")

        If productName = "" Then
            MessageBox.Show("Please enter the Product Name.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            If isEditing Then txtEditProductName.Focus() Else txtProductName.Focus()
            Return False
        End If

        If category = "" Then
            MessageBox.Show("Please select or type a Category.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            If isEditing Then cmbEditCategory.Focus() Else cmbCategory.Focus()
            Return False
        End If

        If Not Decimal.TryParse(priceText, price) OrElse price < 0 Then
            MessageBox.Show("Please enter a valid Price (cannot be negative).", title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            If isEditing Then txtEditPrice.Focus() Else txtPrice.Focus()
            Return False
        End If

        If Not Integer.TryParse(quantityText, quantity) OrElse quantity < 0 Then
            MessageBox.Show("Quantity must be a whole number (cannot be negative).", title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            If isEditing Then txtEditQuantity.Focus() Else txtQuantity.Focus()
            Return False
        End If

        If unit = "" Then
            MessageBox.Show("Please select a Unit.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            If isEditing Then cmbEditUnit.Focus() Else cmbUnit.Focus()
            Return False
        End If

        Return True
    End Function

    Private Function GetSelectedValue(comboBox As ComboBox) As String
        If comboBox.SelectedItem IsNot Nothing Then Return comboBox.SelectedItem.ToString().Trim()
        Return comboBox.Text.Trim()
    End Function

    Private Sub SelectComboBoxValue(comboBox As ComboBox, value As String)
        comboBox.SelectedIndex = -1
        For index As Integer = 0 To comboBox.Items.Count - 1
            If comboBox.Items(index).ToString().Equals(value, StringComparison.OrdinalIgnoreCase) Then
                comboBox.SelectedIndex = index
                Exit For
            End If
        Next

        If comboBox.SelectedIndex = -1 AndAlso value <> "" Then
            comboBox.Text = value
        End If
    End Sub

    Private Function AnyPanelVisible() As Boolean
        Return pnlAddProduct.Visible OrElse pnlEditProduct.Visible
    End Function

    Private Sub ShowDatabaseError(action As String, ex As Exception)
        MessageBox.Show("Database error while " & action & ":" & Environment.NewLine & ex.Message, "Products", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    '========================================================
    ' QUICK RESTOCK (LOW STOCK)
    '========================================================
    Private Sub btnEditLowStock_Click(sender As Object, e As EventArgs) Handles btnEditLowStock.Click

        If AnyPanelVisible() Then Return

        Try
            ' 1. Get all IDs where quantity is 10 or below.
            Dim lowStockIDs As List(Of Integer) = productService.GetLowStockIDs()

            ' 2. If there are none, tell the user.
            If lowStockIDs.Count = 0 Then
                MessageBox.Show(
                    "There are currently no low stock items to edit.",
                    "Low Stock",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                )
                Return
            End If

            ' 3. Open the existing Bulk Edit form and pass the IDs.
            Dim adminForm As admin = TryCast(Me.FindForm(), admin)

            If adminForm Is Nothing Then
                MessageBox.Show("Unable to find the admin form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            adminForm.ShowBulkEditProducts(lowStockIDs)

        Catch ex As Exception
            MessageBox.Show("Error opening low stock list: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    '========================================================
    ' EMPTY DESIGNER EVENTS 
    '========================================================
    Private Sub txtEditProductName_TextChanged(sender As Object, e As EventArgs) Handles txtEditProductName.TextChanged
    End Sub
    Private Sub pnlEditProduct_Paint(sender As Object, e As PaintEventArgs) Handles pnlEditProduct.Paint
    End Sub
    Private Sub cmbEditCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEditCategory.SelectedIndexChanged
    End Sub
    Private Sub txtEditPrice_TextChanged(sender As Object, e As EventArgs) Handles txtEditPrice.TextChanged
    End Sub
    Private Sub cmbEditUnit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEditUnit.SelectedIndexChanged
    End Sub
    Private Sub txtEditQuantity_TextChanged(sender As Object, e As EventArgs) Handles txtEditQuantity.TextChanged
    End Sub
    Private Sub pnlAddProduct_Paint(sender As Object, e As PaintEventArgs) Handles pnlAddProduct.Paint
    End Sub

End Class