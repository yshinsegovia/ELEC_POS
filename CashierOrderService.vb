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
    ' SAVE TRANSACTION USING STUDENT WALLET
    '========================================================
    Public Function SaveTransaction(
    studentID As String,
    cashierID As Integer,
    totalAmount As Decimal,
    cart As DataTable
) As Integer

        If String.IsNullOrWhiteSpace(studentID) Then
            Throw New Exception("Student ID is required.")
        End If

        If cashierID <= 0 Then
            Throw New Exception("Invalid cashier account.")
        End If

        If cart Is Nothing OrElse cart.Rows.Count = 0 Then
            Throw New Exception("The cart is empty.")
        End If

        If totalAmount <= 0D Then
            Throw New Exception("The order total must be greater than zero.")
        End If

        'Calculate the total from the actual cart items.
        Dim calculatedTotal As Decimal = 0D

        For Each row As DataRow In cart.Rows

            Dim quantity As Integer = Convert.ToInt32(row("quantity"))
            Dim price As Decimal = Convert.ToDecimal(row("price"))
            Dim subtotal As Decimal = Convert.ToDecimal(row("subtotal"))

            If quantity <= 0 Then
                Throw New Exception("Product quantity must be greater than zero.")
            End If

            If price < 0D Then
                Throw New Exception("Product price cannot be negative.")
            End If

            Dim expectedSubtotal As Decimal =
            Decimal.Round(price * quantity, 2, MidpointRounding.AwayFromZero)

            If subtotal <> expectedSubtotal Then
                Throw New Exception(
                "The subtotal for " & row("item_name").ToString() &
                " is incorrect. Please review the cart."
            )
            End If

            calculatedTotal += subtotal
        Next

        calculatedTotal =
        Decimal.Round(calculatedTotal, 2, MidpointRounding.AwayFromZero)

        If calculatedTotal <> totalAmount Then
            Throw New Exception(
            "The order total does not match the cart. Please refresh the order and try again."
        )
        End If

        Dim transactionID As Integer = 0

        Using connection As MySqlConnection = database.GetConnection()

            connection.Open()

            Using dbTransaction As MySqlTransaction =
            connection.BeginTransaction()

                Try
                    '1. Confirm the student exists.
                    Const studentQuery As String =
                    "SELECT COUNT(*) FROM user_reg " &
                    "WHERE student_id = @student_id"

                    Using command As New MySqlCommand(
                    studentQuery, connection, dbTransaction)

                        command.Parameters.AddWithValue("@student_id", studentID.Trim())

                        If Convert.ToInt32(command.ExecuteScalar()) = 0 Then
                            Throw New Exception("Student ID does not exist.")
                        End If
                    End Using

                    '2. Confirm the cashier exists.
                    Const cashierQuery As String =
                    "SELECT COUNT(*) FROM `user` " &
                    "WHERE user_id = @cashier_id " &
                    "AND LOWER(role) = 'cashier'"

                    Using command As New MySqlCommand(
                    cashierQuery, connection, dbTransaction)

                        command.Parameters.AddWithValue("@cashier_id", cashierID)

                        If Convert.ToInt32(command.ExecuteScalar()) = 0 Then
                            Throw New Exception("Cashier account does not exist.")
                        End If
                    End Using

                    '3. Lock the student's wallet so two payments
                    '   cannot spend the same balance simultaneously.
                    Dim balanceBefore As Decimal

                    Const walletQuery As String =
                    "SELECT balance FROM student_wallets " &
                    "WHERE student_id = @student_id FOR UPDATE"

                    Using command As New MySqlCommand(
                    walletQuery, connection, dbTransaction)

                        command.Parameters.AddWithValue("@student_id", studentID.Trim())

                        Dim result As Object = command.ExecuteScalar()

                        If result Is Nothing OrElse result Is DBNull.Value Then
                            Throw New Exception(
                            "This student does not have a wallet. Please check the student ID."
                        )
                        End If

                        balanceBefore = Convert.ToDecimal(result)
                    End Using

                    '4. Reject the payment if the wallet has insufficient funds.
                    If balanceBefore < calculatedTotal Then
                        Throw New Exception(
                        "Insufficient wallet balance." &
                        Environment.NewLine &
                        "Order total: ₱" & calculatedTotal.ToString("N2") &
                        Environment.NewLine &
                        "Available balance: ₱" & balanceBefore.ToString("N2") &
                        Environment.NewLine &
                        "Please load the student's wallet first."
                    )
                    End If

                    Dim balanceAfter As Decimal =
                    balanceBefore - calculatedTotal

                    '5. Save the transaction as a wallet payment.
                    Const transactionQuery As String =
                    "INSERT INTO transactions " &
                    "(student_id, cashier_id, total_amount, " &
                    "payment_method, order_status) " &
                    "VALUES (@student_id, @cashier_id, @total_amount, " &
                    "'Wallet', 'Pending')"

                    Using command As New MySqlCommand(
                    transactionQuery, connection, dbTransaction)

                        command.Parameters.AddWithValue("@student_id", studentID.Trim())
                        command.Parameters.AddWithValue("@cashier_id", cashierID)
                        command.Parameters.AddWithValue("@total_amount", calculatedTotal)

                        command.ExecuteNonQuery()

                        transactionID = Convert.ToInt32(command.LastInsertedId)
                    End Using

                    '6. Save each item and deduct its stock.
                    For Each row As DataRow In cart.Rows

                        Dim stockID As Integer =
                        Convert.ToInt32(row("stock_id"))

                        Dim quantity As Integer =
                        Convert.ToInt32(row("quantity"))

                        Dim price As Decimal =
                        Convert.ToDecimal(row("price"))

                        Dim subtotal As Decimal =
                        Convert.ToDecimal(row("subtotal"))

                        Dim itemName As String =
                        row("item_name").ToString()

                        'Lock and check the current stock.
                        Dim currentStock As Integer =
                        GetStockQuantity(stockID, dbTransaction)

                        If currentStock < 0 Then
                            Throw New Exception(
                            "Product no longer exists: " & itemName
                        )
                        End If

                        If currentStock < quantity Then
                            Throw New Exception(
                            "Not enough stock for " & itemName & "." &
                            Environment.NewLine &
                            "Available stock: " & currentStock.ToString()
                        )
                        End If

                        'Save the order item.
                        Const itemQuery As String =
                        "INSERT INTO transaction_items " &
                        "(transaction_id, stock_id, quantity, price, subtotal) " &
                        "VALUES (@transaction_id, @stock_id, @quantity, @price, @subtotal)"

                        Using command As New MySqlCommand(
                        itemQuery, connection, dbTransaction)

                            command.Parameters.AddWithValue("@transaction_id", transactionID)
                            command.Parameters.AddWithValue("@stock_id", stockID)
                            command.Parameters.AddWithValue("@quantity", quantity)
                            command.Parameters.AddWithValue("@price", price)
                            command.Parameters.AddWithValue("@subtotal", subtotal)

                            command.ExecuteNonQuery()
                        End Using



                        UpdateStockStatus(stockID, dbTransaction)
                    Next

                    '7. Deduct the total from the wallet.
                    Const updateWalletQuery As String =
                    "UPDATE student_wallets " &
                    "SET balance = @balance " &
                    "WHERE student_id = @student_id"

                    Using command As New MySqlCommand(
                    updateWalletQuery, connection, dbTransaction)

                        command.Parameters.AddWithValue("@balance", balanceAfter)
                        command.Parameters.AddWithValue("@student_id", studentID.Trim())

                        If command.ExecuteNonQuery() <> 1 Then
                            Throw New Exception("Wallet balance could not be updated.")
                        End If
                    End Using

                    '8. Record the wallet payment in wallet history.
                    ' CHANGED 'PAYMENT' TO 'Payment'
                    Const walletHistoryQuery As String =
                    "INSERT INTO wallet_transactions " &
                    "(student_id, cashier_id, transaction_id, transaction_type, " &
                    "amount, balance_before, balance_after, description) " &
                    "VALUES (@student_id, @cashier_id, @transaction_id, 'Payment', " &
                    "@amount, @balance_before, @balance_after, @description)"

                    Using command As New MySqlCommand(
                    walletHistoryQuery, connection, dbTransaction)

                        command.Parameters.AddWithValue("@student_id", studentID.Trim())
                        command.Parameters.AddWithValue("@cashier_id", cashierID)
                        command.Parameters.AddWithValue("@transaction_id", transactionID)
                        command.Parameters.AddWithValue("@amount", calculatedTotal)
                        command.Parameters.AddWithValue("@balance_before", balanceBefore)
                        command.Parameters.AddWithValue("@balance_after", balanceAfter)
                        command.Parameters.AddWithValue(
                        "@description", "Wallet payment for order #" & transactionID
                    )

                        command.ExecuteNonQuery()
                    End Using

                    '9. Commit everything together.
                    dbTransaction.Commit()

                Catch ex As Exception

                    Try
                        dbTransaction.Rollback()
                    Catch
                        'Preserve the original error.
                    End Try

                    Throw New Exception(
                    "Transaction failed: " & ex.Message,
                    ex
                )
                End Try
            End Using
        End Using

        Return transactionID

    End Function


    '========================================================
    ' GET ORDERS
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

        If Not String.IsNullOrWhiteSpace(searchText) Then
            conditions.Add(
                "(" &
                "CAST(t.transaction_id AS CHAR) LIKE @search " &
                "OR t.student_id LIKE @search " &
                "OR CONCAT(ur.firstname, ' ', ur.lastname) " &
                "LIKE @search" &
                ")"
            )
            parameters.Add(New MySqlParameter("@search", "%" & searchText.Trim() & "%"))
        End If

        If Not String.IsNullOrWhiteSpace(statusFilter) AndAlso statusFilter <> "All" Then
            conditions.Add("t.order_status = @status")
            parameters.Add(New MySqlParameter("@status", statusFilter))
        End If

        If conditions.Count > 0 Then
            query &= " WHERE " & String.Join(" AND ", conditions)
        End If

        query &= " ORDER BY t.transaction_date DESC"

        Try
            Using connection As MySqlConnection = database.GetConnection()
                connection.Open()

                Using command As New MySqlCommand(query, connection)
                    For Each parameter As MySqlParameter In parameters
                        command.Parameters.Add(parameter)
                    Next

                    Using adapter As New MySqlDataAdapter(command)
                        adapter.Fill(table)
                    End Using
                End Using
            End Using

            Return table

        Catch ex As Exception
            Throw New Exception("Error loading orders: " & ex.Message)
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
            Using connection As MySqlConnection = database.GetConnection()
                connection.Open()

                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@transaction_id", transactionID)

                    Using adapter As New MySqlDataAdapter(command)
                        adapter.Fill(table)
                    End Using
                End Using
            End Using

            Return table

        Catch ex As Exception
            Throw New Exception("Error loading order information: " & ex.Message)
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
            Using connection As MySqlConnection = database.GetConnection()
                connection.Open()

                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@transaction_id", transactionID)

                    Using adapter As New MySqlDataAdapter(command)
                        adapter.Fill(table)
                    End Using
                End Using
            End Using

            Return table

        Catch ex As Exception
            Throw New Exception("Error loading order details: " & ex.Message)
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
            Using connection As MySqlConnection = database.GetConnection()
                connection.Open()

                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@transaction_id", transactionID)

                    Dim result As Object = command.ExecuteScalar()

                    If result Is Nothing OrElse result Is DBNull.Value Then
                        Return ""
                    End If

                    Return result.ToString()
                End Using
            End Using

        Catch ex As Exception
            Throw New Exception("Error getting order status: " & ex.Message)
        End Try

    End Function


    '========================================================
    ' CANCEL ORDER AND REFUND STUDENT WALLET
    '========================================================
    Public Sub CancelOrder(
    transactionID As Integer,
    cashierID As Integer
)

        If transactionID <= 0 Then
            Throw New Exception("Invalid transaction ID.")
        End If

        If cashierID <= 0 Then
            Throw New Exception("Invalid cashier account.")
        End If

        Using connection As MySqlConnection = database.GetConnection()

            connection.Open()

            Using dbTransaction As MySqlTransaction =
            connection.BeginTransaction()

                Try
                    '1. Verify the cashier account.
                    Const cashierQuery As String =
                    "SELECT COUNT(*) FROM `user` " &
                    "WHERE user_id = @cashier_id " &
                    "AND LOWER(role) = 'cashier'"

                    Using command As New MySqlCommand(
                    cashierQuery, connection, dbTransaction)

                        command.Parameters.AddWithValue("@cashier_id", cashierID)

                        If Convert.ToInt32(command.ExecuteScalar()) = 0 Then
                            Throw New Exception("Only a valid cashier account can cancel an order.")
                        End If
                    End Using

                    '2. Lock the order and verify that it is Pending.
                    Dim studentID As String = ""
                    Dim orderTotal As Decimal
                    Dim currentStatus As String = ""

                    Const orderQuery As String =
                    "SELECT student_id, total_amount, order_status " &
                    "FROM transactions " &
                    "WHERE transaction_id = @transaction_id " &
                    "FOR UPDATE"

                    Using command As New MySqlCommand(
                    orderQuery, connection, dbTransaction)

                        command.Parameters.AddWithValue("@transaction_id", transactionID)

                        Using reader As MySqlDataReader = command.ExecuteReader()
                            If Not reader.Read() Then
                                Throw New Exception("Order was not found.")
                            End If

                            studentID = reader("student_id").ToString()
                            orderTotal = Convert.ToDecimal(reader("total_amount"))
                            currentStatus = reader("order_status").ToString()
                        End Using
                    End Using

                    If currentStatus <> "Pending" Then
                        Throw New Exception(
                        "This order cannot be cancelled because its current status is '" &
                        currentStatus & "'. Only Pending orders can be cancelled.")
                    End If

                    If orderTotal <= 0D Then
                        Throw New Exception("The order total is invalid. No cancellation was processed.")
                    End If

                    '3. Lock the wallet and get its current balance.
                    Dim balanceBefore As Decimal

                    Const walletQuery As String =
                    "SELECT balance FROM student_wallets " &
                    "WHERE student_id = @student_id " &
                    "FOR UPDATE"

                    Using command As New MySqlCommand(
                    walletQuery, connection, dbTransaction)

                        command.Parameters.AddWithValue("@student_id", studentID)

                        Dim result As Object = command.ExecuteScalar()

                        If result Is Nothing OrElse result Is DBNull.Value Then
                            Throw New Exception("The student's wallet was not found. Cancellation was not completed.")
                        End If

                        balanceBefore = Convert.ToDecimal(result)
                    End Using

                    Dim balanceAfter As Decimal =
                    balanceBefore + orderTotal

                    '4. Read the ordered products and lock their stock rows.
                    Dim stockQuantities As New Dictionary(Of Integer, Integer)

                    Const itemsQuery As String =
                    "SELECT stock_id, SUM(quantity) AS total_quantity " &
                    "FROM transaction_items " &
                    "WHERE transaction_id = @transaction_id " &
                    "GROUP BY stock_id " &
                    "ORDER BY stock_id"

                    Using command As New MySqlCommand(
                    itemsQuery, connection, dbTransaction)

                        command.Parameters.AddWithValue("@transaction_id", transactionID)

                        Using reader As MySqlDataReader = command.ExecuteReader()
                            While reader.Read()
                                Dim stockID As Integer = Convert.ToInt32(reader("stock_id"))
                                Dim quantity As Integer = Convert.ToInt32(reader("total_quantity"))

                                If quantity <= 0 Then
                                    Throw New Exception("An invalid product quantity was found in this order.")
                                End If

                                stockQuantities.Add(stockID, quantity)
                            End While
                        End Using
                    End Using

                    If stockQuantities.Count = 0 Then
                        Throw New Exception("No order items were found. Cancellation was not completed.")
                    End If

                    '5. Lock each stock row and verify that it still exists.
                    For Each item As KeyValuePair(Of Integer, Integer) In stockQuantities

                        Const lockStockQuery As String =
                        "SELECT quantity FROM stocks " &
                        "WHERE stock_id = @stock_id FOR UPDATE"

                        Using command As New MySqlCommand(
                        lockStockQuery, connection, dbTransaction)

                            command.Parameters.AddWithValue("@stock_id", item.Key)

                            Dim result As Object = command.ExecuteScalar()

                            If result Is Nothing OrElse result Is DBNull.Value Then
                                Throw New Exception("A product in this order no longer exists. Cancellation was not completed.")
                            End If
                        End Using
                    Next

                    '6. Restore the stock and recalculate its status.
                    For Each item As KeyValuePair(Of Integer, Integer) In stockQuantities

                        Const restoreStockQuery As String =
                        "UPDATE stocks " &
                        "SET quantity = quantity + @quantity, " &
                        "status = CASE " &
                        "WHEN quantity + @quantity <= 0 THEN 'Unavailable' " &
                        "WHEN quantity + @quantity BETWEEN 1 AND 10 THEN 'Low Stock' " &
                        "ELSE 'Available' END " &
                        "WHERE stock_id = @stock_id"

                        Using command As New MySqlCommand(
                        restoreStockQuery, connection, dbTransaction)

                            command.Parameters.AddWithValue("@quantity", item.Value)
                            command.Parameters.AddWithValue("@stock_id", item.Key)

                            If command.ExecuteNonQuery() <> 1 Then
                                Throw New Exception(
                                "Failed to restore stock for product ID " &
                                item.Key.ToString() & ".")
                            End If
                        End Using
                    Next

                    '7. Refund the student's wallet.
                    Const refundWalletQuery As String =
                    "UPDATE student_wallets " &
                    "SET balance = @balance " &
                    "WHERE student_id = @student_id"

                    Using command As New MySqlCommand(
                    refundWalletQuery, connection, dbTransaction)

                        command.Parameters.AddWithValue("@balance", balanceAfter)
                        command.Parameters.AddWithValue("@student_id", studentID)

                        If command.ExecuteNonQuery() <> 1 Then
                            Throw New Exception("The student's wallet could not be refunded.")
                        End If
                    End Using

                    '8. Record the refund in wallet history.
                    ' CHANGED 'REFUND' TO 'Refund'
                    Const refundHistoryQuery As String =
                    "INSERT INTO wallet_transactions " &
                    "(student_id, cashier_id, transaction_id, transaction_type, " &
                    "amount, balance_before, balance_after, description) " &
                    "VALUES (@student_id, @cashier_id, @transaction_id, 'Refund', " &
                    "@amount, @balance_before, @balance_after, @description)"

                    Using command As New MySqlCommand(
                    refundHistoryQuery, connection, dbTransaction)

                        command.Parameters.AddWithValue("@student_id", studentID)
                        command.Parameters.AddWithValue("@cashier_id", cashierID)
                        command.Parameters.AddWithValue("@transaction_id", transactionID)
                        command.Parameters.AddWithValue("@amount", orderTotal)
                        command.Parameters.AddWithValue("@balance_before", balanceBefore)
                        command.Parameters.AddWithValue("@balance_after", balanceAfter)
                        command.Parameters.AddWithValue(
                        "@description",
                        "Wallet refund for cancelled order #" &
                        transactionID.ToString())

                        command.ExecuteNonQuery()
                    End Using

                    '9. Mark the order as Cancelled.
                    Const cancelQuery As String =
                    "UPDATE transactions " &
                    "SET order_status = 'Cancelled' " &
                    "WHERE transaction_id = @transaction_id " &
                    "AND order_status = 'Pending'"

                    Using command As New MySqlCommand(
                    cancelQuery, connection, dbTransaction)

                        command.Parameters.AddWithValue("@transaction_id", transactionID)

                        If command.ExecuteNonQuery() <> 1 Then
                            Throw New Exception("The order status changed. Please refresh and try again.")
                        End If
                    End Using

                    '10. Save all changes together.
                    dbTransaction.Commit()

                Catch ex As Exception

                    Try
                        dbTransaction.Rollback()
                    Catch
                        'Preserve the original error.
                    End Try

                    Throw New Exception(
                    "Order cancellation failed: " & ex.Message, ex)

                End Try

            End Using
        End Using

    End Sub


    '========================================================
    ' KITCHEN: START PREPARING
    '========================================================
    Public Sub StartPreparingOrder(
        transactionID As Integer,
        kitchenUserID As Integer
    )

        UpdateKitchenOrderStatus(
            transactionID,
            kitchenUserID,
            "Pending",
            "Preparing"
        )

    End Sub


    '========================================================
    ' KITCHEN: COMPLETE ORDER
    '========================================================
    Public Sub CompleteKitchenOrder(
        transactionID As Integer,
        kitchenUserID As Integer
    )

        UpdateKitchenOrderStatus(
            transactionID,
            kitchenUserID,
            "Preparing",
            "Completed"
        )

    End Sub

    '========================================================
    ' KITCHEN: UPDATE ORDER STATUS SAFELY
    '========================================================
    Private Sub UpdateKitchenOrderStatus(
        transactionID As Integer,
        kitchenUserID As Integer,
        previousStatus As String,
        newStatus As String
    )

        If transactionID <= 0 Then
            Throw New Exception("Invalid transaction ID.")
        End If

        If kitchenUserID <= 0 Then
            Throw New Exception("Invalid kitchen account.")
        End If

        Using connection As MySqlConnection = database.GetConnection()

            connection.Open()

            Using dbTransaction As MySqlTransaction =
                connection.BeginTransaction()

                Try
                    ' 1. Verify that the logged-in user is kitchen staff.
                    Const userQuery As String =
                        "SELECT COUNT(*) FROM `user` " &
                        "WHERE user_id = @user_id " &
                        "AND LOWER(role) = 'kitchen'"

                    Using command As New MySqlCommand(
                        userQuery, connection, dbTransaction)

                        command.Parameters.AddWithValue(
                            "@user_id", kitchenUserID)

                        If Convert.ToInt32(command.ExecuteScalar()) = 0 Then
                            Throw New Exception(
                                "Only a kitchen account can update order status.")
                        End If

                    End Using

                    ' 2. Update the order status.
                    Const updateQuery As String =
                        "UPDATE transactions " &
                        "SET order_status = @new_status " &
                        "WHERE transaction_id = @transaction_id " &
                        "AND order_status = @previous_status"

                    Using command As New MySqlCommand(
                        updateQuery, connection, dbTransaction)

                        command.Parameters.AddWithValue(
                            "@new_status", newStatus)

                        command.Parameters.AddWithValue(
                            "@transaction_id", transactionID)

                        command.Parameters.AddWithValue(
                            "@previous_status", previousStatus)

                        If command.ExecuteNonQuery() <> 1 Then
                            Throw New Exception(
                                "The order is no longer " & previousStatus &
                                ". Refresh the order list and try again.")
                        End If

                    End Using

                    ' 3. IF COMPLETED, DEDUCT THE STOCK NOW!
                    If newStatus = "Completed" Then

                        ' Get all items from this order
                        Const itemsQuery As String =
                            "SELECT stock_id, quantity " &
                            "FROM transaction_items " &
                            "WHERE transaction_id = @transaction_id"

                        Dim itemsToDeduct As New List(Of KeyValuePair(Of Integer, Integer))

                        Using command As New MySqlCommand(
                            itemsQuery, connection, dbTransaction)

                            command.Parameters.AddWithValue("@transaction_id", transactionID)

                            Using reader As MySqlDataReader = command.ExecuteReader()
                                While reader.Read()
                                    itemsToDeduct.Add(New KeyValuePair(Of Integer, Integer)(
                                        Convert.ToInt32(reader("stock_id")),
                                        Convert.ToInt32(reader("quantity"))
                                    ))
                                End While
                            End Using
                        End Using

                        ' Deduct the stock for each item
                        For Each item As KeyValuePair(Of Integer, Integer) In itemsToDeduct

                            Const deductStockQuery As String =
                                "UPDATE stocks " &
                                "SET quantity = quantity - @quantity " &
                                "WHERE stock_id = @stock_id"

                            Using command As New MySqlCommand(
                                deductStockQuery, connection, dbTransaction)

                                command.Parameters.AddWithValue("@quantity", item.Value)
                                command.Parameters.AddWithValue("@stock_id", item.Key)

                                If command.ExecuteNonQuery() <> 1 Then
                                    Throw New Exception(
                                        "Failed to deduct stock for product ID " & item.Key.ToString())
                                End If
                            End Using

                            ' Update the status (Available, Low Stock, Unavailable)
                            UpdateStockStatus(item.Key, dbTransaction)
                        Next
                    End If

                    ' 4. Commit everything
                    dbTransaction.Commit()

                Catch ex As Exception

                    Try
                        dbTransaction.Rollback()
                    Catch
                        ' Preserve the original error.
                    End Try

                    Throw New Exception(
                        "Unable to update order status: " & ex.Message, ex)

                End Try
            End Using
        End Using

    End Sub
End Class