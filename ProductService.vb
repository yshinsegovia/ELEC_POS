
Imports MySqlConnector
Imports System.Data

Public Class ProductService

    '========================================================
    ' GET PRODUCTS
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
                "quantity, unit, price, status " &
                "FROM stocks"

            Dim conditions As New List(Of String)
            Dim parameters As New List(Of MySqlParameter)


            '------------------------------------------------
            ' CATEGORY FILTER
            '------------------------------------------------
            If category <> "All" Then

                conditions.Add(
                    "category = @category"
                )

                parameters.Add(
                    New MySqlParameter(
                        "@category",
                        category
                    )
                )

            End If


            '------------------------------------------------
            ' SEARCH FILTER
            '------------------------------------------------
            If searchText <> "" Then

                conditions.Add(
                    "(item_name LIKE @search " &
                    "OR category LIKE @search)"
                )

                parameters.Add(
                    New MySqlParameter(
                        "@search",
                        "%" & searchText & "%"
                    )
                )

            End If


            '------------------------------------------------
            ' WHERE
            '------------------------------------------------
            If conditions.Count > 0 Then

                query &= " WHERE " &
                         String.Join(
                             " AND ",
                             conditions
                         )

            End If


            '------------------------------------------------
            ' SORT
            '------------------------------------------------
            query &= " ORDER BY item_name ASC"


            Using cmd As New MySqlCommand(
                query,
                conn
            )

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


            '------------------------------------------------
            ' CHECK DUPLICATE PRODUCT
            '------------------------------------------------
            If ProductExists(
                conn,
                productName
            ) Then

                Return False

            End If


            Dim query As String =
                "INSERT INTO stocks " &
                "(item_name, category, quantity, unit, price, status) " &
                "VALUES " &
                "(@item_name, @category, @quantity, " &
                "@unit, @price, @status)"


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
                    GetStockStatus(quantity)
                )


                Return cmd.ExecuteNonQuery() > 0

            End Using

        End Using

    End Function


    '========================================================
    ' UPDATE PRODUCT
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


            '------------------------------------------------
            ' CHECK DUPLICATE PRODUCT
            ' IGNORE CURRENT PRODUCT
            '------------------------------------------------
            If ProductExists(
                conn,
                productName,
                stockID
            ) Then

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
                    GetStockStatus(quantity)
                )

                cmd.Parameters.AddWithValue(
                    "@stock_id",
                    stockID
                )


                Return cmd.ExecuteNonQuery() > 0

            End Using

        End Using

    End Function


    '========================================================
    ' PRODUCT EXISTS
    '========================================================
    Public Function ProductExists(
        conn As MySqlConnection,
        productName As String,
        Optional excludeStockID As Integer = 0
    ) As Boolean

        Dim query As String


        '----------------------------------------------------
        ' ADD PRODUCT
        '----------------------------------------------------
        If excludeStockID = 0 Then

            query =
                "SELECT COUNT(*) " &
                "FROM stocks " &
                "WHERE item_name = @item_name"

        Else

            '------------------------------------------------
            ' EDIT PRODUCT
            ' Ignore the product currently being edited
            '------------------------------------------------
            query =
                "SELECT COUNT(*) " &
                "FROM stocks " &
                "WHERE item_name = @item_name " &
                "AND stock_id <> @stock_id"

        End If


        Using cmd As New MySqlCommand(
            query,
            conn
        )

            cmd.Parameters.AddWithValue(
                "@item_name",
                productName
            )


            If excludeStockID <> 0 Then

                cmd.Parameters.AddWithValue(
                    "@stock_id",
                    excludeStockID
                )

            End If


            Dim count As Integer =
                Convert.ToInt32(
                    cmd.ExecuteScalar()
                )


            Return count > 0

        End Using

    End Function


    '========================================================
    ' GET STOCK STATUS
    '========================================================
    Public Function GetStockStatus(
        quantity As Integer
    ) As String

        If quantity <= 0 Then

            Return "Unavailable"

        ElseIf quantity <= 10 Then

            Return "Low Stock"

        Else

            Return "Available"

        End If

    End Function

End Class
