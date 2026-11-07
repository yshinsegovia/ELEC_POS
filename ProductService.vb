Imports MySqlConnector
Imports System
Imports System.Data
Imports System.Collections.Generic
Imports System.Globalization

Public Class ProductService

    '========================================================
    ' GET PRODUCTS (Used by the Grid)
    '========================================================
    Public Function GetProducts(
        category As String,
        searchText As String
    ) As DataTable

        Dim table As New DataTable()

        Using conn As MySqlConnection = GetConnection()
            conn.Open()

            Dim query As String =
                "SELECT stock_id, item_name, category, " &
                "quantity, unit, price, status FROM stocks"

            Dim conditions As New List(Of String)
            Dim parameters As New List(Of MySqlParameter)

            If category <> "All" Then
                conditions.Add("category = @category")
                parameters.Add(New MySqlParameter("@category", category))
            End If

            If Not String.IsNullOrWhiteSpace(searchText) Then
                conditions.Add("(item_name LIKE @search OR category LIKE @search)")
                parameters.Add(New MySqlParameter("@search", "%" & searchText.Trim() & "%"))
            End If

            If conditions.Count > 0 Then
                query &= " WHERE " & String.Join(" AND ", conditions)
            End If

            query &= " ORDER BY item_name ASC"

            Using cmd As New MySqlCommand(query, conn)
                For Each parameter As MySqlParameter In parameters
                    cmd.Parameters.Add(parameter)
                Next

                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(table)
                End Using
            End Using
        End Using

        Return table

    End Function

    '========================================================
    ' GET LOW STOCK PRODUCT IDs (Quantity <= 10)
    '========================================================
    Public Function GetLowStockIDs() As List(Of Integer)

        Dim ids As New List(Of Integer)()

        Using conn As MySqlConnection = GetConnection()
            conn.Open()

            Dim query As String =
                "SELECT stock_id FROM stocks " &
                "WHERE quantity <= 10 " &
                "ORDER BY quantity ASC"

            Using cmd As New MySqlCommand(query, conn)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        ids.Add(Convert.ToInt32(reader("stock_id")))
                    End While
                End Using
            End Using
        End Using

        Return ids

    End Function

    '========================================================
    ' ADD PRODUCT
    '========================================================
    Public Function AddProduct(
        productName As String,
        category As String,
        quantity As Integer,
        unit As String,
        price As Decimal
    ) As Boolean

        Using conn As MySqlConnection = GetConnection()
            conn.Open()

            If ProductExists(conn, productName) Then
                Return False
            End If

            Dim query As String =
                "INSERT INTO stocks " &
                "(item_name, category, quantity, unit, price, status) " &
                "VALUES (@item_name, @category, @quantity, @unit, @price, @status)"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@item_name", productName)
                cmd.Parameters.AddWithValue("@category", category)
                cmd.Parameters.AddWithValue("@quantity", quantity)
                cmd.Parameters.AddWithValue("@unit", unit)
                cmd.Parameters.AddWithValue("@price", price)
                cmd.Parameters.AddWithValue("@status", GetStockStatus(quantity))

                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using

    End Function

    '========================================================
    ' UPDATE ONE PRODUCT
    '========================================================
    Public Function UpdateProduct(
        stockID As Integer,
        productName As String,
        category As String,
        quantity As Integer,
        unit As String,
        price As Decimal
    ) As Boolean

        Using conn As MySqlConnection = GetConnection()
            conn.Open()

            If ProductExists(conn, productName, stockID) Then
                Return False
            End If

            Dim query As String =
                "UPDATE stocks SET " &
                "item_name = @item_name, " &
                "category = @category, " &
                "quantity = @quantity, " &
                "unit = @unit, " &
                "price = @price, " &
                "status = @status " &
                "WHERE stock_id = @stock_id"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@item_name", productName)
                cmd.Parameters.AddWithValue("@category", category)
                cmd.Parameters.AddWithValue("@quantity", quantity)
                cmd.Parameters.AddWithValue("@unit", unit)
                cmd.Parameters.AddWithValue("@price", price)
                cmd.Parameters.AddWithValue("@status", GetStockStatus(quantity))
                cmd.Parameters.AddWithValue("@stock_id", stockID)

                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using

    End Function

    '========================================================
    ' CHECK IF PRODUCT EXISTS
    '========================================================
    Public Function ProductExists(
        conn As MySqlConnection,
        productName As String,
        Optional excludeStockID As Integer = 0
    ) As Boolean

        Dim query As String =
            "SELECT COUNT(*) FROM stocks WHERE item_name = @item_name"

        If excludeStockID <> 0 Then
            query &= " AND stock_id <> @stock_id"
        End If

        Using cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@item_name", productName)
            If excludeStockID <> 0 Then
                cmd.Parameters.AddWithValue("@stock_id", excludeStockID)
            End If

            Return Convert.ToInt32(cmd.ExecuteScalar()) > 0
        End Using

    End Function

    '========================================================
    ' GET STOCK STATUS
    '========================================================
    Public Function GetStockStatus(quantity As Integer) As String
        If quantity <= 0 Then
            Return "Unavailable"
        ElseIf quantity <= 10 Then
            Return "Low Stock"
        Else
            Return "Available"
        End If
    End Function

    '========================================================
    ' GET SELECTED PRODUCTS FOR BULK EDIT
    '========================================================
    Public Function GetProductsByIDs(stockIDs As List(Of Integer)) As DataTable

        Dim table As New DataTable()

        If stockIDs Is Nothing OrElse stockIDs.Count = 0 Then
            Return table
        End If

        Using conn As MySqlConnection = GetConnection()
            conn.Open()

            Dim parameters As New List(Of String)

            Using cmd As New MySqlCommand()
                cmd.Connection = conn

                For i As Integer = 0 To stockIDs.Count - 1
                    Dim parameterName As String = "@id" & i
                    parameters.Add(parameterName)
                    cmd.Parameters.AddWithValue(parameterName, stockIDs(i))
                Next

                cmd.CommandText =
                    "SELECT stock_id, item_name, category, " &
                    "quantity, unit, price, status " &
                    "FROM stocks WHERE stock_id IN (" &
                    String.Join(",", parameters) & ") " &
                    "ORDER BY item_name ASC"

                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(table)
                End Using
            End Using
        End Using

        Return table

    End Function

    '========================================================
    ' BULK UPDATE PRODUCTS AND RECORD EDIT HISTORY
    '========================================================
    Public Function UpdateProductsBulk(products As DataTable) As Boolean

        If products Is Nothing OrElse products.Rows.Count = 0 Then
            Return False
        End If

        Dim batchID As String = "BATCH-" & DateTime.Now.ToString("yyyyMMdd-HHmmss-fff")
        Dim changedBy As String = "Unknown"

        If CurrentSession.CurrentUser IsNot Nothing Then
            changedBy = CurrentSession.CurrentUser.Username
        End If

        Using conn As MySqlConnection = GetConnection()
            conn.Open()

            Using transaction = conn.BeginTransaction()
                Try
                    'Check for empty or duplicate product names.
                    Dim productNames As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)

                    For Each row As DataRow In products.Rows
                        Dim productName As String = Convert.ToString(row("item_name")).Trim()

                        If productName = "" Then
                            Throw New Exception("Product names cannot be empty.")
                        End If

                        If Not productNames.Add(productName) Then
                            Throw New Exception("Duplicate product name: " & productName)
                        End If
                    Next

                    'Update each selected product.
                    For Each row As DataRow In products.Rows
                        Dim stockID As Integer = Convert.ToInt32(row("stock_id"))
                        Dim productName As String = Convert.ToString(row("item_name")).Trim()
                        Dim category As String = Convert.ToString(row("category")).Trim()
                        Dim quantity As Integer = Convert.ToInt32(row("quantity"))
                        Dim unit As String = Convert.ToString(row("unit")).Trim()
                        Dim price As Decimal = Convert.ToDecimal(row("price"), CultureInfo.CurrentCulture)

                        If category = "" OrElse unit = "" Then
                            Throw New Exception("Category and unit are required for " & productName & ".")
                        End If

                        If quantity < 0 OrElse price < 0D Then
                            Throw New Exception("Quantity and price cannot be negative for " & productName & ".")
                        End If

                        'Get the original database values.
                        Dim oldName As String = ""
                        Dim oldCategory As String = ""
                        Dim oldQuantity As Integer
                        Dim oldUnit As String = ""
                        Dim oldPrice As Decimal

                        Using checkCmd As New MySqlCommand(
                            "SELECT item_name, category, quantity, unit, price " &
                            "FROM stocks WHERE stock_id = @id FOR UPDATE", conn, transaction)

                            checkCmd.Parameters.AddWithValue("@id", stockID)

                            Using reader = checkCmd.ExecuteReader()
                                If Not reader.Read() Then
                                    Throw New Exception("Product ID " & stockID.ToString() & " no longer exists.")
                                End If

                                oldName = Convert.ToString(reader("item_name"))
                                oldCategory = Convert.ToString(reader("category"))
                                oldQuantity = Convert.ToInt32(reader("quantity"))
                                oldUnit = Convert.ToString(reader("unit"))
                                oldPrice = Convert.ToDecimal(reader("price"))
                            End Using
                        End Using

                        'Check whether another product already uses the name.
                        Using checkCmd As New MySqlCommand(
                            "SELECT COUNT(*) FROM stocks WHERE item_name = @name AND stock_id <> @id", conn, transaction)

                            checkCmd.Parameters.AddWithValue("@name", productName)
                            checkCmd.Parameters.AddWithValue("@id", stockID)

                            If Convert.ToInt32(checkCmd.ExecuteScalar()) > 0 Then
                                Throw New Exception("The product name '" & productName & "' is already being used.")
                            End If
                        End Using

                        'Save the product changes.
                        Using cmd As New MySqlCommand(
                            "UPDATE stocks SET " &
                            "item_name = @name, category = @category, quantity = @quantity, " &
                            "unit = @unit, price = @price, status = @status " &
                            "WHERE stock_id = @id", conn, transaction)

                            cmd.Parameters.AddWithValue("@name", productName)
                            cmd.Parameters.AddWithValue("@category", category)
                            cmd.Parameters.AddWithValue("@quantity", quantity)
                            cmd.Parameters.AddWithValue("@unit", unit)
                            cmd.Parameters.AddWithValue("@price", price)
                            cmd.Parameters.AddWithValue("@status", GetStockStatus(quantity))
                            cmd.Parameters.AddWithValue("@id", stockID)

                            If cmd.ExecuteNonQuery() = 0 Then
                                Throw New Exception("Could not update product: " & productName)
                            End If
                        End Using

                        'Record only fields that actually changed.
                        If oldName <> productName Then
                            InsertProductHistory(conn, transaction, batchID, stockID, productName, "item_name", oldName, productName, changedBy)
                        End If
                        If oldCategory <> category Then
                            InsertProductHistory(conn, transaction, batchID, stockID, productName, "category", oldCategory, category, changedBy)
                        End If
                        If oldQuantity <> quantity Then
                            InsertProductHistory(conn, transaction, batchID, stockID, productName, "quantity", oldQuantity.ToString(CultureInfo.InvariantCulture), quantity.ToString(CultureInfo.InvariantCulture), changedBy)
                        End If
                        If oldUnit <> unit Then
                            InsertProductHistory(conn, transaction, batchID, stockID, productName, "unit", oldUnit, unit, changedBy)
                        End If
                        If oldPrice <> price Then
                            InsertProductHistory(conn, transaction, batchID, stockID, productName, "price", oldPrice.ToString(CultureInfo.InvariantCulture), price.ToString(CultureInfo.InvariantCulture), changedBy)
                        End If

                    Next

                    transaction.Commit()
                    Return True

                Catch
                    transaction.Rollback()
                    Throw
                End Try
            End Using
        End Using

    End Function

    '========================================================
    ' INSERT ONE PRODUCT HISTORY RECORD
    '========================================================
    Private Sub InsertProductHistory(
        conn As MySqlConnection,
        transaction As MySqlTransaction,
        batchID As String,
        stockID As Integer,
        productName As String,
        fieldName As String,
        oldValue As String,
        newValue As String,
        changedBy As String
    )

        Using cmd As New MySqlCommand(
            "INSERT INTO product_edit_history " &
            "(batch_id, stock_id, product_name, field_name, " &
            "old_value, new_value, changed_by) " &
            "VALUES (@batch, @stockID, @productName, @field, " &
            "@oldValue, @newValue, @changedBy)", conn, transaction)

            cmd.Parameters.AddWithValue("@batch", batchID)
            cmd.Parameters.AddWithValue("@stockID", stockID)
            cmd.Parameters.AddWithValue("@productName", productName)
            cmd.Parameters.AddWithValue("@field", fieldName)
            cmd.Parameters.AddWithValue("@oldValue", oldValue)
            cmd.Parameters.AddWithValue("@newValue", newValue)
            cmd.Parameters.AddWithValue("@changedBy", changedBy)

            cmd.ExecuteNonQuery()
        End Using

    End Sub

End Class