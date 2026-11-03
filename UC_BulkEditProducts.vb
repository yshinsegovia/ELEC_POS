
Imports System.Collections.Generic
Imports System.Data

Public Class UC_BulkEditProducts

    Private ReadOnly productService As New ProductService()

    ' Selected product IDs received from UC_Products.
    Private selectedStockIDs As New List(Of Integer)

    ' Loaded product records.
    Private bulkProducts As DataTable


    '========================================================
    ' RECEIVE SELECTED PRODUCT IDS
    '========================================================
    Public Sub SetSelectedProducts(stockIDs As List(Of Integer))

        selectedStockIDs.Clear()

        If stockIDs Is Nothing Then
            Return
        End If

        For Each stockID As Integer In stockIDs
            If stockID > 0 AndAlso
               Not selectedStockIDs.Contains(stockID) Then

                selectedStockIDs.Add(stockID)

            End If
        Next

    End Sub


    '========================================================
    ' LOAD FORM
    '========================================================
    Private Sub UC_BulkEditProducts_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        Try
            SetupBulkGrid()
            LoadSelectedProducts()

        Catch ex As Exception
            MessageBox.Show(
                "Unable to load the selected products." &
                Environment.NewLine & ex.Message,
                "Bulk Edit Products",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )
        End Try

    End Sub


    '========================================================
    ' SETUP GRID
    '========================================================
    Private Sub SetupBulkGrid()

        With dgvBulkProducts
            .DataSource = Nothing
            .AutoGenerateColumns = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ReadOnly = False
            .EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .RowHeadersVisible = False
        End With

    End Sub


    '========================================================
    ' LOAD SELECTED PRODUCTS
    '========================================================
    Private Sub LoadSelectedProducts()

        If selectedStockIDs.Count = 0 Then

            MessageBox.Show(
                "No valid products were selected.",
                "Bulk Edit Products",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        bulkProducts =
            productService.GetProductsByIDs(selectedStockIDs)

        If bulkProducts Is Nothing Then
            Throw New Exception(
                "The product service did not return any data."
            )
        End If

        If Not bulkProducts.Columns.Contains("stock_id") Then
            Throw New Exception(
                "The product data does not contain the required " &
                "'stock_id' column. Check ProductService.GetProductsByIDs()."
            )
        End If

        dgvBulkProducts.DataSource = bulkProducts

        ConfigureGridColumns()

        lblTitle.Text =
            "Bulk Edit Products (" &
            bulkProducts.Rows.Count.ToString() &
            " selected)"

        If bulkProducts.Rows.Count = 0 Then

            MessageBox.Show(
                "The selected products could not be found.",
                "Bulk Edit Products",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

        End If

    End Sub


    '========================================================
    ' CONFIGURE GRID COLUMNS
    '========================================================
    Private Sub ConfigureGridColumns()

        ' Hide the actual database ID.
        If dgvBulkProducts.Columns.Contains("stock_id") Then
            dgvBulkProducts.Columns("stock_id").Visible = False
        End If

        ' Hide common alternative ID column names, if present.
        If dgvBulkProducts.Columns.Contains("id") Then
            dgvBulkProducts.Columns("id").Visible = False
        End If

        ' Friendly column headings.
        SetColumnHeader("item_name", "Product Name")
        SetColumnHeader("category", "Category")
        SetColumnHeader("quantity", "Quantity")
        SetColumnHeader("unit", "Unit")
        SetColumnHeader("price", "Price")
        SetColumnHeader("status", "Stock Status")

        ' Status is controlled by the system.
        If dgvBulkProducts.Columns.Contains("status") Then
            dgvBulkProducts.Columns("status").ReadOnly = True
        End If

        ' IDs must never be editable.
        If dgvBulkProducts.Columns.Contains("stock_id") Then
            dgvBulkProducts.Columns("stock_id").ReadOnly = True
        End If

        If dgvBulkProducts.Columns.Contains("id") Then
            dgvBulkProducts.Columns("id").ReadOnly = True
        End If

    End Sub


    '========================================================
    ' SET COLUMN HEADER SAFELY
    '========================================================
    Private Sub SetColumnHeader(
        columnName As String,
        headerText As String
    )

        If dgvBulkProducts.Columns.Contains(columnName) Then
            dgvBulkProducts.Columns(columnName).HeaderText = headerText
        End If

    End Sub


    '========================================================
    ' GRID CELL CLICK
    '========================================================
    Private Sub dgvBulkProducts_CellContentClick(
        sender As Object,
        e As DataGridViewCellEventArgs
    ) Handles dgvBulkProducts.CellContentClick

        ' No special action is required.

    End Sub


    '========================================================
    ' VALIDATE GRID VALUES
    '========================================================
    Private Function ValidateBulkProducts() As Boolean

        If dgvBulkProducts.IsCurrentCellInEditMode Then
            dgvBulkProducts.EndEdit()
        End If

        Me.Validate()

        If bulkProducts Is Nothing OrElse
           bulkProducts.Rows.Count = 0 Then

            MessageBox.Show(
                "There are no products to update.",
                "Bulk Edit Products",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return False

        End If

        For Each row As DataRow In bulkProducts.Rows

            If row.RowState = DataRowState.Deleted Then
                Continue For
            End If

            Dim productName As String =
                Convert.ToString(row("item_name")).Trim()

            Dim category As String =
                Convert.ToString(row("category")).Trim()

            Dim unit As String =
                Convert.ToString(row("unit")).Trim()

            If productName = "" Then

                MessageBox.Show(
                    "Product names cannot be empty.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Return False

            End If

            If category = "" Then

                MessageBox.Show(
                    "Please enter a category for " & productName & ".",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Return False

            End If

            If unit = "" Then

                MessageBox.Show(
                    "Please enter a unit for " & productName & ".",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Return False

            End If

            Dim quantity As Integer
            Dim price As Decimal

            If row.IsNull("quantity") OrElse
               Not Integer.TryParse(
                   Convert.ToString(row("quantity")),
                   quantity
               ) OrElse quantity < 0 Then

                MessageBox.Show(
                    "Quantity must be a whole number that is zero or higher for " &
                    productName & ".",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Return False

            End If

            If row.IsNull("price") OrElse
               Not Decimal.TryParse(
                   Convert.ToString(row("price")),
                   price
               ) OrElse price < 0D Then

                MessageBox.Show(
                    "Price must be a valid number that is zero or higher for " &
                    productName & ".",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Return False

            End If

        Next

        Return True

    End Function


    '========================================================
    ' UPDATE ALL PRODUCTS
    '========================================================
    Private Sub btnUpdateAll_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnUpdateAll.Click

        If Not ValidateBulkProducts() Then
            Return
        End If

        Dim answer As DialogResult =
            MessageBox.Show(
                "Are you sure you want to save changes to all " &
                bulkProducts.Rows.Count.ToString() &
                " selected products?",
                "Confirm Bulk Update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            )

        If answer <> DialogResult.Yes Then
            Return
        End If

        Try

            Dim success As Boolean =
                productService.UpdateProductsBulk(bulkProducts)

            If success Then

                MessageBox.Show(
                    "All selected products were updated successfully.",
                    "Bulk Edit Products",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                )

                Dim adminForm As admin =
                    TryCast(Me.FindForm(), admin)

                If adminForm IsNot Nothing Then
                    adminForm.ReturnToProducts()
                End If

            Else

                MessageBox.Show(
                    "No products were updated.",
                    "Bulk Edit Products",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

            End If

        Catch ex As Exception

            MessageBox.Show(
                "Unable to update the selected products." &
                Environment.NewLine & ex.Message,
                "Bulk Edit Products",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    '========================================================
    ' CANCEL BULK EDIT
    '========================================================
    Private Sub btnCancel_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnCancel.Click

        Dim adminForm As admin =
            TryCast(Me.FindForm(), admin)

        If adminForm IsNot Nothing Then

            adminForm.ReturnToProducts()

        Else

            MessageBox.Show(
                "Unable to return to the products page.",
                "Navigation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

        End If

    End Sub


    '========================================================
    ' TITLE CLICK
    '========================================================
    Private Sub lblTitle_Click(
        sender As Object,
        e As EventArgs
    ) Handles lblTitle.Click

    End Sub

End Class
