
Imports MySqlConnector
Imports System.Data

Public Class UC_Products

    '========================================================
    ' SERVICE
    '========================================================
    Private ReadOnly productService As New ProductService()


    '========================================================
    ' CURRENT CATEGORY
    '========================================================
    Private CurrentCategory As String = "All"


    '========================================================
    ' CURRENT PRODUCT BEING EDITED
    '========================================================
    Private EditingStockID As Integer = 0


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

        LoadProducts()

    End Sub


    '========================================================
    ' SETUP ADD CATEGORY COMBOBOX
    '========================================================
    Private Sub SetupCategoryComboBox()

        cmbCategory.Items.Clear()

        cmbCategory.Items.Add("Rice Meals")
        cmbCategory.Items.Add("Drinks")
        cmbCategory.Items.Add("Snacks")
        cmbCategory.Items.Add("Desserts")

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
    ' SETUP EDIT CATEGORY COMBOBOX
    '========================================================
    Private Sub SetupEditCategoryComboBox()

        cmbEditCategory.Items.Clear()

        cmbEditCategory.Items.Add("Rice Meals")
        cmbEditCategory.Items.Add("Drinks")
        cmbEditCategory.Items.Add("Snacks")
        cmbEditCategory.Items.Add("Desserts")

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
    ' SETUP PRODUCT GRID
    '========================================================
    Private Sub SetupProductGrid()

        dgvListofProducts.Columns.Clear()

        dgvListofProducts.AutoGenerateColumns = False
        dgvListofProducts.AllowUserToAddRows = False
        dgvListofProducts.AllowUserToDeleteRows = False
        dgvListofProducts.ReadOnly = True

        dgvListofProducts.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect

        dgvListofProducts.MultiSelect = False
        dgvListofProducts.RowHeadersVisible = False


        '----------------------------------------------------
        ' PRODUCT
        '----------------------------------------------------
        Dim colProduct As New DataGridViewTextBoxColumn With {
            .Name = "Product",
            .HeaderText = "Product",
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        }

        dgvListofProducts.Columns.Add(colProduct)


        '----------------------------------------------------
        ' CATEGORY
        '----------------------------------------------------
        Dim colCategory As New DataGridViewTextBoxColumn With {
            .Name = "Category",
            .HeaderText = "Category",
            .Width = 120
        }

        dgvListofProducts.Columns.Add(colCategory)


        '----------------------------------------------------
        ' PRICE
        '----------------------------------------------------
        Dim colPrice As New DataGridViewTextBoxColumn With {
            .Name = "Price",
            .HeaderText = "Price",
            .Width = 90
        }

        colPrice.DefaultCellStyle.Format = "₱#,##0.00"

        dgvListofProducts.Columns.Add(colPrice)


        '----------------------------------------------------
        ' STOCK
        '----------------------------------------------------
        Dim colStock As New DataGridViewTextBoxColumn With {
            .Name = "Stock",
            .HeaderText = "Stock",
            .Width = 70
        }

        dgvListofProducts.Columns.Add(colStock)


        '----------------------------------------------------
        ' UNIT
        '----------------------------------------------------
        Dim colUnit As New DataGridViewTextBoxColumn With {
            .Name = "Unit",
            .HeaderText = "Unit",
            .Width = 80
        }

        dgvListofProducts.Columns.Add(colUnit)


        '----------------------------------------------------
        ' STATUS
        '----------------------------------------------------
        Dim colStatus As New DataGridViewTextBoxColumn With {
            .Name = "Status",
            .HeaderText = "Status",
            .Width = 110
        }

        dgvListofProducts.Columns.Add(colStatus)


        '----------------------------------------------------
        ' EDIT BUTTON
        '----------------------------------------------------
        Dim colEdit As New DataGridViewButtonColumn With {
            .Name = "Edit",
            .HeaderText = "Action",
            .Text = "EDIT",
            .UseColumnTextForButtonValue = True,
            .Width = 80
        }

        dgvListofProducts.Columns.Add(colEdit)


        '----------------------------------------------------
        ' HIDDEN STOCK ID
        '----------------------------------------------------
        Dim colID As New DataGridViewTextBoxColumn With {
            .Name = "StockID",
            .HeaderText = "Stock ID",
            .Visible = False
        }

        dgvListofProducts.Columns.Add(colID)

    End Sub


    '========================================================
    ' LOAD PRODUCTS
    '========================================================
    Private Sub LoadProducts()

        Try

            Dim searchText As String =
                txtSearchProducts.Text.Trim()


            Dim table As DataTable =
                productService.GetProducts(
                    CurrentCategory,
                    searchText
                )


            dgvListofProducts.Rows.Clear()


            For Each row As DataRow In table.Rows

                AddProductRow(row)

            Next


        Catch ex As MySqlException

            ShowDatabaseError(
                "loading products",
                ex
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
    ' ADD PRODUCT ROW TO GRID
    '========================================================
    Private Sub AddProductRow(
        row As DataRow
    )

        Dim stockID As Integer =
            Convert.ToInt32(
                row("stock_id")
            )


        Dim productName As String =
            Convert.ToString(
                row("item_name")
            )


        Dim category As String =
            Convert.ToString(
                row("category")
            )


        Dim quantity As Integer =
            Convert.ToInt32(
                row("quantity")
            )


        Dim unit As String =
            Convert.ToString(
                row("unit")
            )


        Dim price As Decimal =
            Convert.ToDecimal(
                row("price")
            )


        Dim status As String =
            productService.GetStockStatus(
                quantity
            )


        dgvListofProducts.Rows.Add(
            productName,
            category,
            price,
            quantity,
            unit,
            status,
            "EDIT",
            stockID
        )

    End Sub


    '========================================================
    ' ALL PRODUCTS
    '========================================================
    Private Sub btnAll_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnAll.Click

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

        If AnyPanelVisible() Then
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

        If AnyPanelVisible() Then
            Return
        End If


        LoadProducts()

    End Sub


    '========================================================
    ' ENTER KEY SEARCH
    '========================================================
    Private Sub txtSearchProducts_KeyDown(
        sender As Object,
        e As KeyEventArgs
    ) Handles txtSearchProducts.KeyDown

        If e.KeyCode = Keys.Enter Then

            e.SuppressKeyPress = True

            btnSearchP.PerformClick()

        End If

    End Sub


    '========================================================
    ' ADD PRODUCT BUTTON
    '========================================================
    Private Sub btnAddProducts_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnAddProducts.Click

        If AnyPanelVisible() Then
            Return
        End If


        ClearAddProductFields()


        pnlEditProduct.Visible = False

        pnlAddProduct.Visible = True

        pnlAddProduct.BringToFront()


        txtProductName.Focus()

    End Sub


    '========================================================
    ' SAVE NEW PRODUCT
    '========================================================
    Private Sub btnSave_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnSave.Click

        Dim productName As String =
            txtProductName.Text.Trim()


        Dim category As String =
            GetSelectedValue(
                cmbCategory
            )


        Dim unit As String =
            GetSelectedValue(
                cmbUnit
            )


        Dim price As Decimal

        Dim quantity As Integer


        If Not ValidateProductInput(
            productName,
            category,
            unit,
            txtPrice.Text.Trim(),
            txtQuantity.Text.Trim(),
            price,
            quantity
        ) Then

            Return

        End If


        Dim answer As DialogResult =
            MessageBox.Show(
                "Add this product to the product list?",
                "Add Product",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            )


        If answer <> DialogResult.Yes Then
            Return
        End If


        Try

            Dim success As Boolean =
                productService.AddProduct(
                    productName,
                    category,
                    quantity,
                    unit,
                    price
                )


            If Not success Then

                MessageBox.Show(
                    "A product with this name already exists.",
                    "Add Product",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                txtProductName.Focus()

                Return

            End If


            MessageBox.Show(
                "Product added successfully!",
                "Add Product",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )


            CloseAddProductPanel()

            LoadProducts()


        Catch ex As MySqlException

            ShowDatabaseError(
                "adding product",
                ex
            )


        Catch ex As Exception

            MessageBox.Show(
                "Error adding product:" &
                Environment.NewLine &
                Environment.NewLine &
                ex.Message,
                "Add Product",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    '========================================================
    ' CANCEL ADD
    '========================================================
    Private Sub btnCancel_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnCancel.Click

        Dim answer As DialogResult =
            MessageBox.Show(
                "Are you sure you want to cancel?",
                "Add Product",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            )


        If answer <> DialogResult.Yes Then
            Return
        End If


        CloseAddProductPanel()

    End Sub


    '========================================================
    ' CLOSE ADD PRODUCT PANEL
    '========================================================
    Private Sub CloseAddProductPanel()

        ClearAddProductFields()

        pnlAddProduct.Visible = False

    End Sub


    '========================================================
    ' CLEAR ADD PRODUCT FIELDS
    '========================================================
    Private Sub ClearAddProductFields()

        txtProductName.Clear()
        txtPrice.Clear()
        txtQuantity.Clear()

        cmbCategory.SelectedIndex = -1
        cmbUnit.SelectedIndex = -1

    End Sub


    '========================================================
    ' EDIT BUTTON
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


        If dgvListofProducts.Columns(
            e.ColumnIndex
        ).Name <> "Edit" Then

            Return

        End If


        OpenEditProduct(
            e.RowIndex
        )

    End Sub


    '========================================================
    ' OPEN EDIT PRODUCT PANEL
    '========================================================
    Private Sub OpenEditProduct(
        rowIndex As Integer
    )

        Try

            Dim row As DataGridViewRow =
                dgvListofProducts.Rows(rowIndex)


            '------------------------------------------------
            ' CHECK STOCK ID
            '------------------------------------------------
            If row.Cells("StockID").Value Is Nothing OrElse
               row.Cells("StockID").Value Is DBNull.Value Then

                MessageBox.Show(
                    "Unable to identify this product.",
                    "Edit Product",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Return

            End If


            '------------------------------------------------
            ' SAVE STOCK ID
            '------------------------------------------------
            EditingStockID =
                Convert.ToInt32(
                    row.Cells("StockID").Value
                )


            '------------------------------------------------
            ' LOAD PRODUCT NAME
            '------------------------------------------------
            txtEditProductName.Text =
                Convert.ToString(
                    row.Cells("Product").Value
                )


            '------------------------------------------------
            ' LOAD CATEGORY
            '------------------------------------------------
            SelectComboBoxValue(
                cmbEditCategory,
                Convert.ToString(
                    row.Cells("Category").Value
                )
            )


            '------------------------------------------------
            ' LOAD PRICE
            '------------------------------------------------
            txtEditPrice.Text =
                Convert.ToDecimal(
                    row.Cells("Price").Value
                ).ToString("0.00")


            '------------------------------------------------
            ' LOAD QUANTITY
            '------------------------------------------------
            txtEditQuantity.Text =
                Convert.ToString(
                    row.Cells("Stock").Value
                )


            '------------------------------------------------
            ' LOAD UNIT
            '------------------------------------------------
            SelectComboBoxValue(
                cmbEditUnit,
                Convert.ToString(
                    row.Cells("Unit").Value
                )
            )


            '------------------------------------------------
            ' SHOW EDIT PANEL
            '------------------------------------------------
            pnlAddProduct.Visible = False

            pnlEditProduct.Visible = True

            pnlEditProduct.BringToFront()


            txtEditProductName.Focus()

        Catch ex As Exception

            MessageBox.Show(
                "Unable to open product for editing:" &
                Environment.NewLine &
                Environment.NewLine &
                ex.Message,
                "Edit Product",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    '========================================================
    ' UPDATE PRODUCT
    '========================================================
    Private Sub btnUpdateProduct_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnUpdateProduct.Click

        If EditingStockID <= 0 Then

            MessageBox.Show(
                "No product is selected for editing.",
                "Edit Product",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If


        Dim productName As String =
            txtEditProductName.Text.Trim()


        Dim category As String =
            GetSelectedValue(
                cmbEditCategory
            )


        Dim unit As String =
            GetSelectedValue(
                cmbEditUnit
            )


        Dim price As Decimal

        Dim quantity As Integer


        If Not ValidateProductInput(
            productName,
            category,
            unit,
            txtEditPrice.Text.Trim(),
            txtEditQuantity.Text.Trim(),
            price,
            quantity,
            True
        ) Then

            Return

        End If


        Dim answer As DialogResult =
            MessageBox.Show(
                "Save changes to this product?",
                "Edit Product",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            )


        If answer <> DialogResult.Yes Then
            Return
        End If


        Try

            Dim success As Boolean =
                productService.UpdateProduct(
                    EditingStockID,
                    productName,
                    category,
                    quantity,
                    unit,
                    price
                )


            If Not success Then

                MessageBox.Show(
                    "A different product already uses this name.",
                    "Edit Product",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                txtEditProductName.Focus()

                Return

            End If


            MessageBox.Show(
                "Product updated successfully!",
                "Edit Product",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )


            CloseEditProductPanel()

            LoadProducts()


        Catch ex As MySqlException

            ShowDatabaseError(
                "updating product",
                ex
            )


        Catch ex As Exception

            MessageBox.Show(
                "Error updating product:" &
                Environment.NewLine &
                Environment.NewLine &
                ex.Message,
                "Edit Product",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    '========================================================
    ' CANCEL EDIT
    '========================================================
    Private Sub btnCancelEdit_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnCancelEdit.Click

        Dim answer As DialogResult =
            MessageBox.Show(
                "Are you sure you want to cancel?",
                "Edit Product",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            )


        If answer <> DialogResult.Yes Then
            Return
        End If


        CloseEditProductPanel()

    End Sub


    '========================================================
    ' CLOSE EDIT PRODUCT PANEL
    '========================================================
    Private Sub CloseEditProductPanel()

        EditingStockID = 0

        ClearEditProductFields()

        pnlEditProduct.Visible = False

    End Sub


    '========================================================
    ' CLEAR EDIT FIELDS
    '========================================================
    Private Sub ClearEditProductFields()

        txtEditProductName.Clear()
        txtEditPrice.Clear()
        txtEditQuantity.Clear()

        cmbEditCategory.SelectedIndex = -1
        cmbEditUnit.SelectedIndex = -1

    End Sub


    '========================================================
    ' VALIDATE PRODUCT INPUT
    '========================================================
    Private Function ValidateProductInput(
        productName As String,
        category As String,
        unit As String,
        priceText As String,
        quantityText As String,
        ByRef price As Decimal,
        ByRef quantity As Integer,
        Optional isEditing As Boolean = False
    ) As Boolean

        Dim title As String =
            If(
                isEditing,
                "Edit Product",
                "Add Product"
            )


        '----------------------------------------------------
        ' PRODUCT NAME
        '----------------------------------------------------
        If productName = "" Then

            MessageBox.Show(
                "Please enter the Product Name.",
                title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )


            If isEditing Then

                txtEditProductName.Focus()

            Else

                txtProductName.Focus()

            End If


            Return False

        End If


        '----------------------------------------------------
        ' CATEGORY
        '----------------------------------------------------
        If category = "" Then

            MessageBox.Show(
                "Please select a Category.",
                title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )


            If isEditing Then

                cmbEditCategory.Focus()

            Else

                cmbCategory.Focus()

            End If


            Return False

        End If


        '----------------------------------------------------
        ' PRICE
        '----------------------------------------------------
        If Not Decimal.TryParse(
            priceText,
            price
        ) Then

            MessageBox.Show(
                "Please enter a valid Price.",
                title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )


            If isEditing Then

                txtEditPrice.Focus()

            Else

                txtPrice.Focus()

            End If


            Return False

        End If


        If price < 0 Then

            MessageBox.Show(
                "Price cannot be negative.",
                title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )


            If isEditing Then

                txtEditPrice.Focus()

            Else

                txtPrice.Focus()

            End If


            Return False

        End If


        '----------------------------------------------------
        ' QUANTITY
        '----------------------------------------------------
        If Not Integer.TryParse(
            quantityText,
            quantity
        ) Then

            MessageBox.Show(
                "Quantity must be a whole number.",
                title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )


            If isEditing Then

                txtEditQuantity.Focus()

            Else

                txtQuantity.Focus()

            End If


            Return False

        End If


        If quantity < 0 Then

            MessageBox.Show(
                "Quantity cannot be negative.",
                title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )


            If isEditing Then

                txtEditQuantity.Focus()

            Else

                txtQuantity.Focus()

            End If


            Return False

        End If


        '----------------------------------------------------
        ' UNIT
        '----------------------------------------------------
        If unit = "" Then

            MessageBox.Show(
                "Please select a Unit.",
                title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )


            If isEditing Then

                cmbEditUnit.Focus()

            Else

                cmbUnit.Focus()

            End If


            Return False

        End If


        Return True

    End Function


    '========================================================
    ' GET COMBOBOX VALUE
    '========================================================
    Private Function GetSelectedValue(
        comboBox As ComboBox
    ) As String

        If comboBox.SelectedItem Is Nothing Then

            Return ""

        End If


        Return comboBox.SelectedItem.
            ToString().
            Trim()

    End Function


    '========================================================
    ' SELECT COMBOBOX VALUE
    '========================================================
    Private Sub SelectComboBoxValue(
        comboBox As ComboBox,
        value As String
    )

        comboBox.SelectedIndex = -1


        For index As Integer = 0 To comboBox.Items.Count - 1
            If comboBox.Items(index).
                ToString().
                Equals(
                    value,
                    StringComparison.OrdinalIgnoreCase
                ) Then

                comboBox.SelectedIndex = index

                Exit For

            End If

        Next

    End Sub


    '========================================================
    ' CHECK IF A PANEL IS OPEN
    '========================================================
    Private Function AnyPanelVisible() As Boolean

        Return pnlAddProduct.Visible OrElse
               pnlEditProduct.Visible

    End Function


    '========================================================
    ' DATABASE ERROR
    '========================================================
    Private Sub ShowDatabaseError(
        action As String,
        ex As Exception
    )

        MessageBox.Show(
            "Database error while " &
            action &
            ":" &
            Environment.NewLine &
            Environment.NewLine &
            ex.Message,
            "Products",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
        )

    End Sub


    '========================================================
    ' EMPTY DESIGNER EVENTS
    '========================================================
    Private Sub txtEditProductName_TextChanged(
        sender As Object,
        e As EventArgs
    ) Handles txtEditProductName.TextChanged

    End Sub


    Private Sub pnlEditProduct_Paint(
        sender As Object,
        e As PaintEventArgs
    ) Handles pnlEditProduct.Paint

    End Sub


    Private Sub cmbEditCategory_SelectedIndexChanged(
        sender As Object,
        e As EventArgs
    ) Handles cmbEditCategory.SelectedIndexChanged

    End Sub


    Private Sub txtEditPrice_TextChanged(
        sender As Object,
        e As EventArgs
    ) Handles txtEditPrice.TextChanged

    End Sub


    Private Sub cmbEditUnit_SelectedIndexChanged(
        sender As Object,
        e As EventArgs
    ) Handles cmbEditUnit.SelectedIndexChanged

    End Sub


    Private Sub txtEditQuantity_TextChanged(
        sender As Object,
        e As EventArgs
    ) Handles txtEditQuantity.TextChanged

    End Sub


    Private Sub pnlAddProduct_Paint(
        sender As Object,
        e As PaintEventArgs
    ) Handles pnlAddProduct.Paint

    End Sub

End Class
