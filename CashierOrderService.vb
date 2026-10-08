
Imports MySqlConnector
Imports System.Data

Public Class CashierOrderService

    '========================================================
    ' SEARCH STUDENT
    '========================================================
    Public Function GetStudent(
        studentID As String
    ) As DataTable

        Dim table As New DataTable()

        Dim query As String =
            "SELECT student_id, firstname, lastname, course, yearlvl " &
            "FROM user_reg " &
            "WHERE student_id = @student_id"

        Try

            Using connection As MySqlConnection =
                database.GetConnection()

                connection.Open()

                Using command As New MySqlCommand(
                    query,
                    connection
                )

                    command.Parameters.AddWithValue(
                        "@student_id",
                        studentID
                    )

                    Using adapter As New MySqlDataAdapter(
                        command
                    )

                        adapter.Fill(table)

                    End Using

                End Using

            End Using

        Catch ex As Exception

            Throw New Exception(
                "Error searching student: " &
                ex.Message
            )

        End Try


        Return table

    End Function


    '========================================================
    ' GET ALL PRODUCTS
    '========================================================
    Public Function GetProducts() As DataTable

        Dim table As New DataTable()

        Dim query As String =
            "SELECT stock_id, item_name, category, " &
            "quantity, unit, price, status " &
            "FROM stocks " &
            "ORDER BY item_name ASC"

        Try

            Using connection As MySqlConnection =
                database.GetConnection()

                connection.Open()

                Using command As New MySqlCommand(
                    query,
                    connection
                )

                    Using adapter As New MySqlDataAdapter(
                        command
                    )

                        adapter.Fill(table)

                    End Using

                End Using

            End Using

        Catch ex As Exception

            Throw New Exception(
                "Error loading products: " &
                ex.Message
            )

        End Try


        Return table

    End Function


    '========================================================
    ' GET PRODUCTS BY CATEGORY
    '========================================================
    Public Function GetProductsByCategory(
        category As String
    ) As DataTable

        Dim table As New DataTable()

        Dim query As String =
            "SELECT stock_id, item_name, category, " &
            "quantity, unit, price, status " &
            "FROM stocks " &
            "WHERE category = @category " &
            "ORDER BY item_name ASC"

        Try

            Using connection As MySqlConnection =
                database.GetConnection()

                connection.Open()

                Using command As New MySqlCommand(
                    query,
                    connection
                )

                    command.Parameters.AddWithValue(
                        "@category",
                        category
                    )

                    Using adapter As New MySqlDataAdapter(
                        command
                    )

                        adapter.Fill(table)

                    End Using

                End Using

            End Using

        Catch ex As Exception

            Throw New Exception(
                "Error loading products by category: " &
                ex.Message
            )

        End Try


        Return table

    End Function


    '========================================================
    ' CHECK CURRENT STOCK
    '========================================================
    Public Function GetStockQuantity(
        stockID As Integer,
        transaction As MySqlTransaction
    ) As Integer

        Dim query As String =
            "SELECT quantity " &
            "FROM stocks " &
            "WHERE stock_id = @stock_id " &
            "FOR UPDATE"

        Using command As New MySqlCommand(
            query,
            transaction.Connection,
            transaction
        )

            command.Parameters.AddWithValue(
                "@stock_id",
                stockID
            )

            Dim result As Object =
                command.ExecuteScalar()


            If result Is Nothing OrElse
               result Is DBNull.Value Then

                Return -1

            End If


            Return Convert.ToInt32(result)

        End Using

    End Function


    '========================================================
    ' UPDATE STOCK STATUS
    '========================================================
    Private Sub UpdateStockStatus(
        stockID As Integer,
        transaction As MySqlTransaction
    )

        Dim query As String =
            "UPDATE stocks " &
            "SET status = CASE " &
            "WHEN quantity <= 0 THEN 'Unavailable' " &
            "WHEN quantity BETWEEN 1 AND 10 THEN 'Low Stock' " &
            "ELSE 'Available' " &
            "END " &
            "WHERE stock_id = @stock_id"

        Using command As New MySqlCommand(
            query,
            transaction.Connection,
            transaction
        )

            command.Parameters.AddWithValue(
                "@stock_id",
                stockID
            )

            command.ExecuteNonQuery()

        End Using

    End Sub


    '========================================================
    ' SAVE COMPLETE TRANSACTION
    '
    ' New order always starts as Pending.
    '========================================================
    Public Function SaveTransaction(
        studentID As String,
        cashierID As Integer,
        totalAmount As Decimal,
        cart As DataTable
    ) As Integer

        If cart Is Nothing OrElse
           cart.Rows.Count = 0 Then

            Throw New Exception(
                "The cart is empty."
            )

        End If


        If String.IsNullOrWhiteSpace(studentID) Then

            Throw New Exception(
                "Student ID is required."
            )

        End If


        If cashierID <= 0 Then

            Throw New Exception(
                "Invalid cashier account."
            )

        End If


        Dim transactionID As Integer = 0


        Using connection As MySqlConnection =
            database.GetConnection()

            connection.Open()


            Using dbTransaction As MySqlTransaction =
                connection.BeginTransaction()

                Try

                    '================================================
                    ' 1. CHECK STUDENT
                    '================================================
                    Dim studentQuery As String =
                        "SELECT COUNT(*) " &
                        "FROM user_reg " &
                        "WHERE student_id = @student_id"

                    Using studentCommand As New MySqlCommand(
                        studentQuery,
                        connection,
                        dbTransaction
                    )

                        studentCommand.Parameters.AddWithValue(
                            "@student_id",
                            studentID
                        )


                        Dim studentExists As Integer =
                            Convert.ToInt32(
                                studentCommand.ExecuteScalar()
                            )


                        If studentExists = 0 Then

                            Throw New Exception(
                                "Student ID does not exist."
                            )

                        End If

                    End Using


                    '================================================
                    ' 2. CHECK CASHIER
                    '================================================
                    Dim cashierQuery As String =
                        "SELECT COUNT(*) " &
                        "FROM `user` " &
                        "WHERE user_id = @cashier_id " &
                        "AND LOWER(role) = 'cashier'"

                    Using cashierCommand As New MySqlCommand(
                        cashierQuery,
                        connection,
                        dbTransaction
                    )

                        cashierCommand.Parameters.AddWithValue(
                            "@cashier_id",
                            cashierID
                        )


                        Dim cashierExists As Integer =
                            Convert.ToInt32(
                                cashierCommand.ExecuteScalar()
                            )


                        If cashierExists = 0 Then

                            Throw New Exception(
                                "Cashier account does not exist."
                            )

                        End If

                    End Using


                    '================================================
                    ' 3. INSERT MAIN TRANSACTION
                    '================================================
                    Dim transactionQuery As String =
                        "INSERT INTO transactions " &
                        "(student_id, cashier_id, total_amount, " &
                        "payment_method, order_status) " &
                        "VALUES " &
                        "(@student_id, @cashier_id, @total_amount, " &
                        "'Cash', 'Pending')"

                    Using transactionCommand As New MySqlCommand(
                        transactionQuery,
                        connection,
                        dbTransaction
                    )

                        transactionCommand.Parameters.AddWithValue(
                            "@student_id",
                            studentID
                        )

                        transactionCommand.Parameters.AddWithValue(
                            "@cashier_id",
                            cashierID
                        )

                        transactionCommand.Parameters.AddWithValue(
                            "@total_amount",
                            totalAmount
                        )


                        transactionCommand.ExecuteNonQuery()


                        transactionID =
                            Convert.ToInt32(
                                transactionCommand.LastInsertedId
                            )

                    End Using


                    '================================================
                    ' 4. SAVE EACH PRODUCT
                    '================================================
                    For Each row As DataRow In cart.Rows

                        Dim stockID As Integer =
                            Convert.ToInt32(
                                row("stock_id")
                            )


                        Dim quantity As Integer =
                            Convert.ToInt32(
                                row("quantity")
                            )


                        Dim price As Decimal =
                            Convert.ToDecimal(
                                row("price")
                            )


                        Dim subtotal As Decimal =
                            Convert.ToDecimal(
                                row("subtotal")
                            )


                        Dim itemName As String =
                            row("item_name").ToString()


                        If quantity <= 0 Then

                            Throw New Exception(
                                "Invalid quantity for " &
                                itemName &
                                "."
                            )

                        End If


                        '============================================
                        ' CHECK STOCK
                        '============================================
                        Dim currentStock As Integer =
                            GetStockQuantity(
                                stockID,
                                dbTransaction
                            )


                        If currentStock < 0 Then

                            Throw New Exception(
                                "Product no longer exists: " &
                                itemName
                            )

                        End If


                        If currentStock < quantity Then

                            Throw New Exception(
                                "Not enough stock for " &
                                itemName &
                                "." &
                                Environment.NewLine &
                                "Available stock: " &
                                currentStock.ToString()
                            )

                        End If


                        '============================================
                        ' SAVE TRANSACTION ITEM
                        '============================================
                        Dim itemQuery As String =
                            "INSERT INTO transaction_items " &
                            "(transaction_id, stock_id, quantity, " &
                            "price, subtotal) " &
                            "VALUES " &
                            "(@transaction_id, @stock_id, " &
                            "@quantity, @price, @subtotal)"

                        Using itemCommand As New MySqlCommand(
                            itemQuery,
                            connection,
                            dbTransaction
                        )

                            itemCommand.Parameters.AddWithValue(
                                "@transaction_id",
                                transactionID
                            )

                            itemCommand.Parameters.AddWithValue(
                                "@stock_id",
                                stockID
                            )

                            itemCommand.Parameters.AddWithValue(
                                "@quantity",
                                quantity
                            )

                            itemCommand.Parameters.AddWithValue(
                                "@price",
                                price
                            )

                            itemCommand.Parameters.AddWithValue(
                                "@subtotal",
                                subtotal
                            )


                            itemCommand.ExecuteNonQuery()

                        End Using


                        '============================================
                        ' DECREASE STOCK
                        '============================================
                        Dim stockQuery As String =
                            "UPDATE stocks " &
                            "SET quantity = quantity - @quantity " &
                            "WHERE stock_id = @stock_id"

                        Using stockCommand As New MySqlCommand(
                            stockQuery,
                            connection,
                            dbTransaction
                        )

                            stockCommand.Parameters.AddWithValue(
                                "@quantity",
                                quantity
                            )

                            stockCommand.Parameters.AddWithValue(
                                "@stock_id",
                                stockID
                            )


                            stockCommand.ExecuteNonQuery()

                        End Using


                        '============================================
                        ' UPDATE STOCK STATUS
                        '============================================
                        UpdateStockStatus(
                            stockID,
                            dbTransaction
                        )

                    Next


                    '================================================
                    ' 5. COMMIT
                    '================================================
                    dbTransaction.Commit()


                Catch ex As Exception

                    Try

                        dbTransaction.Rollback()

                    Catch

                    End Try


                    Throw New Exception(
                        "Transaction failed: " &
                        ex.Message
                    )

                End Try

            End Using

        End Using


        Return transactionID

    End Function


    '========================================================
    ' GET ORDERS
    '
    ' Used by UC_Orders.
    '========================================================
    Public Function GetOrders(
        searchText As String,
        statusFilter As String
    ) As DataTable

        Dim table As New DataTable()


        Dim query As String =
            "SELECT " &
            "t.transaction_id AS `Transaction ID`, " &
            "t.student_id AS `Student ID`, " &
            "CONCAT(ur.firstname, ' ', ur.lastname) " &
            "AS `Student Name`, " &
            "t.total_amount AS `Total`, " &
            "t.transaction_date AS `Date/Time`, " &
            "t.order_status AS `Status` " &
            "FROM transactions t " &
            "INNER JOIN user_reg ur " &
            "ON t.student_id = ur.student_id"


        Dim conditions As New List(Of String)

        Dim parameters As New List(Of MySqlParameter)


        '====================================================
        ' SEARCH
        '====================================================
        If Not String.IsNullOrWhiteSpace(
            searchText
        ) Then

            conditions.Add(
                "(" &
                "CAST(t.transaction_id AS CHAR) LIKE @search " &
                "OR t.student_id LIKE @search " &
                "OR CONCAT(ur.firstname, ' ', ur.lastname) " &
                "LIKE @search" &
                ")"
            )


            parameters.Add(
                New MySqlParameter(
                    "@search",
                    "%" &
                    searchText.Trim() &
                    "%"
                )
            )

        End If


        '====================================================
        ' STATUS FILTER
        '====================================================
        If Not String.IsNullOrWhiteSpace(
            statusFilter
        ) AndAlso
           statusFilter <> "All" Then

            conditions.Add(
                "t.order_status = @status"
            )


            parameters.Add(
                New MySqlParameter(
                    "@status",
                    statusFilter
                )
            )

        End If


        '====================================================
        ' ADD WHERE
        '====================================================
        If conditions.Count > 0 Then

            query &=
                " WHERE " &
                String.Join(
                    " AND ",
                    conditions
                )

        End If


        '====================================================
        ' SORT
        '====================================================
        query &=
            " ORDER BY t.transaction_date DESC"


        Try

            Using connection As MySqlConnection =
                database.GetConnection()

                connection.Open()


                Using command As New MySqlCommand(
                    query,
                    connection
                )

                    For Each parameter As MySqlParameter
                        In parameters

                        command.Parameters.Add(parameter)

                    Next


                    Using adapter As New MySqlDataAdapter(
                        command
                    )

                        adapter.Fill(table)

                    End Using

                End Using

            End Using


            Return table


        Catch ex As Exception

            Throw New Exception(
                "Error loading orders: " &
                ex.Message
            )

        End Try

    End Function


    '========================================================
    ' GET ORDER INFORMATION
    '========================================================
    Public Function GetOrderInfo(
        transactionID As Integer
    ) As DataTable

        Dim table As New DataTable()


        Dim query As String =
            "SELECT " &
            "t.transaction_id, " &
            "t.student_id, " &
            "CONCAT(ur.firstname, ' ', ur.lastname) " &
            "AS student_name, " &
            "u.username AS cashier, " &
            "t.transaction_date, " &
            "t.payment_method, " &
            "t.order_status, " &
            "t.total_amount " &
            "FROM transactions t " &
            "INNER JOIN user_reg ur " &
            "ON t.student_id = ur.student_id " &
            "INNER JOIN `user` u " &
            "ON t.cashier_id = u.user_id " &
            "WHERE t.transaction_id = @transaction_id"


        Try

            Using connection As MySqlConnection =
                database.GetConnection()

                connection.Open()


                Using command As New MySqlCommand(
                    query,
                    connection
                )

                    command.Parameters.AddWithValue(
                        "@transaction_id",
                        transactionID
                    )


                    Using adapter As New MySqlDataAdapter(
                        command
                    )

                        adapter.Fill(table)

                    End Using

                End Using

            End Using


            Return table


        Catch ex As Exception

            Throw New Exception(
                "Error loading order information: " &
                ex.Message
            )

        End Try

    End Function


    '========================================================
    ' GET ORDER DETAILS
    '========================================================
    Public Function GetOrderDetails(
        transactionID As Integer
    ) As DataTable

        Dim table As New DataTable()


        Dim query As String =
            "SELECT " &
            "s.item_name AS `Product`, " &
            "ti.quantity AS `Qty`, " &
            "ti.price AS `Price`, " &
            "ti.subtotal AS `Subtotal` " &
            "FROM transaction_items ti " &
            "INNER JOIN stocks s " &
            "ON ti.stock_id = s.stock_id " &
            "WHERE ti.transaction_id = @transaction_id " &
            "ORDER BY ti.transaction_item_id ASC"


        Try

            Using connection As MySqlConnection =
                database.GetConnection()

                connection.Open()


                Using command As New MySqlCommand(
                    query,
                    connection
                )

                    command.Parameters.AddWithValue(
                        "@transaction_id",
                        transactionID
                    )


                    Using adapter As New MySqlDataAdapter(
                        command
                    )

                        adapter.Fill(table)

                    End Using

                End Using

            End Using


            Return table


        Catch ex As Exception

            Throw New Exception(
                "Error loading order details: " &
                ex.Message
            )

        End Try

    End Function


    '========================================================
    ' GET CURRENT ORDER STATUS
    '========================================================
    Public Function GetOrderStatus(
        transactionID As Integer
    ) As String

        Dim query As String =
            "SELECT order_status " &
            "FROM transactions " &
            "WHERE transaction_id = @transaction_id"


        Try

            Using connection As MySqlConnection =
                database.GetConnection()

                connection.Open()


                Using command As New MySqlCommand(
                    query,
                    connection
                )

                    command.Parameters.AddWithValue(
                        "@transaction_id",
                        transactionID
                    )


                    Dim result As Object =
                        command.ExecuteScalar()


                    If result Is Nothing OrElse
                       result Is DBNull.Value Then

                        Return ""

                    End If


                    Return result.ToString()

                End Using

            End Using


        Catch ex As Exception

            Throw New Exception(
                "Error getting order status: " &
                ex.Message
            )

        End Try

    End Function


    '========================================================
    ' UPDATE ORDER STATUS
    '
    ' Allowed:
    ' Pending -> Preparing
    ' Preparing -> Completed
    '========================================================
    Public Sub UpdateOrderStatus(
        transactionID As Integer,
        newStatus As String
    )

        If newStatus <> "Pending" AndAlso
           newStatus <> "Preparing" AndAlso
           newStatus <> "Completed" Then

            Throw New Exception(
                "Invalid order status."
            )

        End If


        Using connection As MySqlConnection =
            database.GetConnection()

            connection.Open()


            Using dbTransaction As MySqlTransaction =
                connection.BeginTransaction()

                Try

                    '------------------------------------------------
                    ' GET CURRENT STATUS
                    '------------------------------------------------
                    Dim getStatusQuery As String =
                        "SELECT order_status " &
                        "FROM transactions " &
                        "WHERE transaction_id = @transaction_id " &
                        "FOR UPDATE"


                    Dim currentStatus As String = ""


                    Using command As New MySqlCommand(
                        getStatusQuery,
                        connection,
                        dbTransaction
                    )

                        command.Parameters.AddWithValue(
                            "@transaction_id",
                            transactionID
                        )


                        Dim result As Object =
                            command.ExecuteScalar()


                        If result Is Nothing OrElse
                           result Is DBNull.Value Then

                            Throw New Exception(
                                "Order was not found."
                            )

                        End If


                        currentStatus =
                            result.ToString()

                    End Using


                    '------------------------------------------------
                    ' CHECK VALID STATUS MOVEMENT
                    '------------------------------------------------
                    Dim validTransition As Boolean = False


                    If currentStatus = "Pending" AndAlso
                       newStatus = "Preparing" Then

                        validTransition = True


                    ElseIf currentStatus = "Preparing" AndAlso
                           newStatus = "Completed" Then

                        validTransition = True

                    End If


                    If Not validTransition Then

                        Throw New Exception(
                            "Invalid status change: " &
                            currentStatus &
                            " → " &
                            newStatus
                        )

                    End If


                    '------------------------------------------------
                    ' UPDATE STATUS
                    '------------------------------------------------
                    Dim updateQuery As String =
                        "UPDATE transactions " &
                        "SET order_status = @order_status " &
                        "WHERE transaction_id = @transaction_id"


                    Using command As New MySqlCommand(
                        updateQuery,
                        connection,
                        dbTransaction
                    )

                        command.Parameters.AddWithValue(
                            "@order_status",
                            newStatus
                        )

                        command.Parameters.AddWithValue(
                            "@transaction_id",
                            transactionID
                        )


                        command.ExecuteNonQuery()

                    End Using


                    dbTransaction.Commit()


                Catch ex As Exception

                    Try

                        dbTransaction.Rollback()

                    Catch

                    End Try


                    Throw New Exception(
                        "Error updating order status: " &
                        ex.Message
                    )

                End Try

            End Using

        End Using

    End Sub

End Class