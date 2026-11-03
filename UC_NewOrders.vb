
Imports MySqlConnector
Imports System.Data
Imports System.Collections.Generic
Imports System.Text

Public Class UC_NewOrders

    '========================================================
    ' SERVICES
    '========================================================
    Private ReadOnly orderService As New CashierOrderService()
    Private ReadOnly walletService As New WalletService()

    '========================================================
    ' CURRENT STUDENT
    '========================================================
    Private currentStudentID As String = ""

    '========================================================
    ' PRODUCT AND CART DATA
    '========================================================
    Private productTable As DataTable
    Private cartTable As DataTable

    '========================================================
    ' DYNAMIC PRODUCT PANELS
    '========================================================
    Private flpRice As FlowLayoutPanel
    Private flpDrinks As FlowLayoutPanel
    Private flpSnacks As FlowLayoutPanel
    Private flpDesserts As FlowLayoutPanel

    '========================================================
    ' PRODUCT REFRESH TIMER
    '========================================================
    Private ReadOnly productRefreshTimer As New Timer()

    ' Tracks the last warning state for each product.
    ' Prevents the same warning from appearing every 5 seconds.
    Private ReadOnly notifiedStockStates As New Dictionary(Of Integer, String)()

    '========================================================
    ' USERCONTROL LOAD
    '========================================================
    Private Sub UC_NewOrders_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        SetupCartGrid()
        SetupDynamicProductPanels()
        LoadAllProducts()

        tabMenu.SelectedTab = tabRice
        LoadSelectedCategory()

        ClearPaymentFields()

        lblWalletBalance.Text = "Wallet Balance: ₱0.00"

        ' Check stock immediately when the form loads.
        CheckLowStockNotifications()

        productRefreshTimer.Interval = 5000

        AddHandler productRefreshTimer.Tick,
            AddressOf ProductRefreshTimer_Tick

        productRefreshTimer.Start()

    End Sub

    '========================================================
    ' SETUP ORDER CART GRID
    '========================================================
    Private Sub SetupCartGrid()

        With dgvOrderCart

            .Columns.Clear()
            .AutoGenerateColumns = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False
            .ReadOnly = True

            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .RowHeadersVisible = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        End With

        Dim productColumn As New DataGridViewTextBoxColumn()

        With productColumn
            .Name = "item_name"
            .HeaderText = "Product"
            .FillWeight = 180
            .MinimumWidth = 100
            .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft
        End With

        dgvOrderCart.Columns.Add(productColumn)

        Dim quantityColumn As New DataGridViewTextBoxColumn()

        With quantityColumn
            .Name = "quantity"
            .HeaderText = "Qty"
            .FillWeight = 55
            .MinimumWidth = 45
        End With

        dgvOrderCart.Columns.Add(quantityColumn)

        Dim priceColumn As New DataGridViewTextBoxColumn()

        With priceColumn
            .Name = "price"
            .HeaderText = "Price"
            .FillWeight = 90
            .MinimumWidth = 75
            .DefaultCellStyle.Format = "₱#,##0.00"
            .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight
        End With

        dgvOrderCart.Columns.Add(priceColumn)

        Dim subtotalColumn As New DataGridViewTextBoxColumn()

        With subtotalColumn
            .Name = "subtotal"
            .HeaderText = "Subtotal"
            .FillWeight = 100
            .MinimumWidth = 85
            .DefaultCellStyle.Format = "₱#,##0.00"
            .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight
        End With

        dgvOrderCart.Columns.Add(subtotalColumn)

    End Sub

    '========================================================
    ' CREATE DYNAMIC PRODUCT PANELS
    '========================================================
    Private Sub SetupDynamicProductPanels()

        tabRice.Controls.Clear()
        flpRice = CreateProductFlowPanel("flpRice")
        tabRice.Controls.Add(flpRice)

        tabDrinks.Controls.Clear()
        flpDrinks = CreateProductFlowPanel("flpDrinks")
        tabDrinks.Controls.Add(flpDrinks)

        tabSnacks.Controls.Clear()
        flpSnacks = CreateProductFlowPanel("flpSnacks")
        tabSnacks.Controls.Add(flpSnacks)

        tabDesserts.Controls.Clear()
        flpDesserts = CreateProductFlowPanel("flpDesserts")
        tabDesserts.Controls.Add(flpDesserts)

    End Sub

    '========================================================
    ' CREATE FLOWLAYOUTPANEL
    '========================================================
    Private Function CreateProductFlowPanel(
        panelName As String
    ) As FlowLayoutPanel

        Dim panel As New FlowLayoutPanel()

        panel.Name = panelName
        panel.Dock = DockStyle.Fill
        panel.FlowDirection = FlowDirection.LeftToRight
        panel.WrapContents = True
        panel.AutoScroll = True
        panel.Padding = New Padding(8)
        panel.Margin = New Padding(0)

        Return panel

    End Function

    '========================================================
    ' LOAD ALL PRODUCTS
    '========================================================
    Private Sub LoadAllProducts()

        Try

            productTable = orderService.GetProducts()

        Catch ex As Exception

            MessageBox.Show(
                ex.Message,
                "Product Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    '========================================================
    ' LOW-STOCK AND OUT-OF-STOCK NOTIFICATIONS
    '========================================================
    Private Sub CheckLowStockNotifications()

        Try

            ' Get the latest stock information from the database.
            Dim latestProducts As DataTable =
                orderService.GetProducts()

            Dim currentStockStates As New Dictionary(Of Integer, String)()
            Dim alerts As New StringBuilder()

            For Each row As DataRow In latestProducts.Rows

                Dim stockID As Integer =
                    Convert.ToInt32(row("stock_id"))

                Dim itemName As String =
                    row("item_name").ToString()

                Dim quantity As Integer =
                    Convert.ToInt32(row("quantity"))

                Dim stockState As String = ""

                If quantity <= 0 Then

                    stockState = "OUT OF STOCK"

                ElseIf quantity <= 3 Then

                    stockState = "LOW STOCK"

                Else

                    ' Normal stock does not require a warning.
                    Continue For

                End If

                currentStockStates(stockID) = stockState

                Dim previousState As String = Nothing

                ' Alert only when a product first enters a warning
                ' state or changes between LOW STOCK and OUT OF STOCK.
                If Not notifiedStockStates.TryGetValue(
                    stockID, previousState
                ) OrElse previousState <> stockState Then

                    If stockState = "OUT OF STOCK" Then

                        alerts.AppendLine(
                            "OUT OF STOCK: " & itemName &
                            " (0 left)"
                        )

                    Else

                        alerts.AppendLine(
                            "LOW STOCK: " & itemName &
                            " (" & quantity.ToString() & " left)"
                        )

                    End If

                End If

            Next

            ' Replace previous warning states with the latest ones.
            ' Products that return to normal stock are removed from
            ' this dictionary and can trigger a new alert later.
            notifiedStockStates.Clear()

            For Each item As KeyValuePair(Of Integer, String) _
                In currentStockStates

                notifiedStockStates(item.Key) = item.Value

            Next

            ' Show one combined popup for all newly detected alerts.
            If alerts.Length > 0 Then

                MessageBox.Show(
                    "Please check the following products:" &
                    Environment.NewLine & Environment.NewLine &
                    alerts.ToString(),
                    "HungryTable Stock Alert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

            End If

        Catch ex As Exception

            ' Avoid repeated error popups every five seconds.
            System.Diagnostics.Debug.WriteLine(
                "Stock notification error: " & ex.Message
            )

        End Try

    End Sub

    '========================================================
    ' LOAD SELECTED CATEGORY
    '========================================================
    Private Sub LoadSelectedCategory()

        If tabMenu.SelectedTab Is Nothing Then
            Return
        End If

        Select Case tabMenu.SelectedTab.Name

            Case "tabRice"
                LoadCategoryProducts("Rice Meals", flpRice)

            Case "tabDrinks"
                LoadCategoryProducts("Drinks", flpDrinks)

            Case "tabSnacks"
                LoadCategoryProducts("Snacks", flpSnacks)

            Case "tabDesserts"
                LoadCategoryProducts("Desserts", flpDesserts)

        End Select

    End Sub

    '========================================================
    ' LOAD PRODUCTS FOR ONE CATEGORY
    '========================================================
    Private Sub LoadCategoryProducts(
        category As String,
        productPanel As FlowLayoutPanel
    )

        If productPanel Is Nothing Then
            Return
        End If

        Try

            LoadAllProducts()
            productPanel.Controls.Clear()

            Dim categoryTable As DataTable =
                orderService.GetProductsByCategory(category)

            If categoryTable.Rows.Count = 0 Then

                Dim noProducts As New Label()

                noProducts.Text = "No products available."
                noProducts.AutoSize = True
                noProducts.Font =
                    New Font("Sitka Text", 10, FontStyle.Bold)
                noProducts.Margin = New Padding(10)

                productPanel.Controls.Add(noProducts)

                Return

            End If

            For Each row As DataRow In categoryTable.Rows
                CreateProductButton(row, productPanel)
            Next

        Catch ex As Exception

            MessageBox.Show(
                ex.Message,
                "Product Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    '========================================================
    ' CREATE PRODUCT BUTTON
    '========================================================
    Private Sub CreateProductButton(
        row As DataRow,
        productPanel As FlowLayoutPanel
    )

        Dim stockID As Integer =
            Convert.ToInt32(row("stock_id"))

        Dim itemName As String =
            row("item_name").ToString()

        Dim price As Decimal =
            Convert.ToDecimal(row("price"))

        Dim quantity As Integer =
            Convert.ToInt32(row("quantity"))

        Dim productButton As New Button()

        productButton.Width = 100
        productButton.Height = 105
        productButton.Margin = New Padding(7)

        productButton.Font =
            New Font("Sitka Banner", 8.5F, FontStyle.Bold)

        productButton.TextAlign = ContentAlignment.MiddleCenter
        productButton.UseCompatibleTextRendering = True
        productButton.Tag = stockID

        If quantity <= 0 Then

            productButton.Text =
                itemName & vbCrLf &
                "₱" & price.ToString("N2") & vbCrLf &
                "UNAVAILABLE"

            productButton.Enabled = False

        ElseIf quantity <= 3 Then

            productButton.Text =
                itemName & vbCrLf &
                "₱" & price.ToString("N2") & vbCrLf &
                "LOW STOCK" & vbCrLf &
                quantity.ToString() & " LEFT"

            productButton.Enabled = True

        Else

            productButton.Text =
                itemName & vbCrLf &
                "₱" & price.ToString("N2") & vbCrLf &
                "STOCK" & vbCrLf &
                quantity.ToString() & " LEFT"

            productButton.Enabled = True

        End If

        AddHandler productButton.Click,
            Sub(sender As Object, e As EventArgs)
                AddProductToCartByStockID(stockID)
            End Sub

        productPanel.Controls.Add(productButton)

    End Sub

    '========================================================
    ' TAB CHANGED
    '========================================================
    Private Sub tabMenu_SelectedIndexChanged(
        sender As Object,
        e As EventArgs
    ) Handles tabMenu.SelectedIndexChanged

        LoadSelectedCategory()

    End Sub

    '========================================================
    ' AUTOMATIC PRODUCT REFRESH
    '========================================================
    Private Sub ProductRefreshTimer_Tick(
        sender As Object,
        e As EventArgs
    )

        LoadSelectedCategory()
        CheckLowStockNotifications()

    End Sub

    '========================================================
    ' SEARCH BUTTON
    '========================================================
    Private Sub btnStudentNewOrder_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnStudentNewOrder.Click

        SearchStudent()

    End Sub

    '========================================================
    ' SEARCH STUDENT AND DISPLAY WALLET BALANCE
    '========================================================
    Private Sub SearchStudent()

        Dim studentID As String =
            txtStudentIDorder.Text.Trim()

        If studentID = "" Then

            MessageBox.Show(
                "Please enter the Student ID.",
                "Student Search",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            txtStudentIDorder.Focus()
            Return

        End If

        Try

            Dim studentTable As DataTable =
                orderService.GetStudent(studentID)

            If studentTable.Rows.Count = 0 Then

                currentStudentID = ""

                lblStudentName.Text = "-"
                lblCourse.Text = "-"
                lblYearCart.Text = "-"
                lblWalletBalance.Text = "Wallet Balance: ₱0.00"

                MessageBox.Show(
                    "Student ID not found.",
                    "Student Search",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Return

            End If

            Dim row As DataRow = studentTable.Rows(0)

            currentStudentID = row("student_id").ToString()

            Dim firstName As String =
                row("firstname").ToString()

            Dim lastName As String =
                row("lastname").ToString()

            lblStudentName.Text = firstName & " " & lastName
            lblCourse.Text = row("course").ToString()
            lblYearCart.Text = row("yearlvl").ToString()

            Dim balance As Decimal =
                walletService.GetWalletBalance(currentStudentID)

            lblWalletBalance.Text =
                "Wallet Balance: ₱" & balance.ToString("N2")

        Catch ex As Exception

            MessageBox.Show(
                ex.Message,
                "Student Search Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    '========================================================
    ' ENTER KEY = SEARCH STUDENT
    '========================================================
    Private Sub txtStudentIDorder_KeyDown(
        sender As Object,
        e As KeyEventArgs
    ) Handles txtStudentIDorder.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnStudentNewOrder.PerformClick()
        End If

    End Sub

    '========================================================
    ' ADD PRODUCT TO CART USING STOCK ID
    '========================================================
    Private Sub AddProductToCartByStockID(stockID As Integer)

        If String.IsNullOrWhiteSpace(currentStudentID) Then

            MessageBox.Show(
                "Please search for a student first.",
                "New Order",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            txtStudentIDorder.Focus()
            Return

        End If

        Try

            LoadAllProducts()

            Dim productRow As DataRow =
                GetProductRowByStockID(stockID)

            If productRow Is Nothing Then

                MessageBox.Show(
                    "Product no longer exists.",
                    "Product",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                LoadSelectedCategory()
                Return

            End If

            Dim itemName As String =
                productRow("item_name").ToString()

            Dim price As Decimal =
                Convert.ToDecimal(productRow("price"))

            Dim stockQuantity As Integer =
                Convert.ToInt32(productRow("quantity"))

            If stockQuantity <= 0 Then

                MessageBox.Show(
                    itemName & " is currently unavailable.",
                    "Out of Stock",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                LoadSelectedCategory()
                Return

            End If

            For Each cartRow As DataGridViewRow In dgvOrderCart.Rows

                If cartRow.IsNewRow Then Continue For

                If cartRow.Cells("item_name").Value Is Nothing Then
                    Continue For
                End If

                If cartRow.Cells("item_name").Value.ToString().Equals(
                    itemName,
                    StringComparison.OrdinalIgnoreCase
                ) Then

                    Dim currentQuantity As Integer =
                        Convert.ToInt32(cartRow.Cells("quantity").Value)

                    If currentQuantity >= stockQuantity Then

                        MessageBox.Show(
                            "You cannot add more " & itemName &
                            "." & Environment.NewLine &
                            "Available stock: " & stockQuantity.ToString(),
                            "Stock Limit",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        )

                        Return

                    End If

                    currentQuantity += 1

                    cartRow.Cells("quantity").Value = currentQuantity
                    cartRow.Cells("price").Value = price
                    cartRow.Cells("subtotal").Value = price * currentQuantity

                    CalculateCartTotal()
                    Return

                End If

            Next

            Dim rowIndex As Integer = dgvOrderCart.Rows.Add()

            dgvOrderCart.Rows(rowIndex).Cells("item_name").Value = itemName
            dgvOrderCart.Rows(rowIndex).Cells("quantity").Value = 1
            dgvOrderCart.Rows(rowIndex).Cells("price").Value = price
            dgvOrderCart.Rows(rowIndex).Cells("subtotal").Value = price

            CalculateCartTotal()

        Catch ex As Exception

            MessageBox.Show(
                ex.Message,
                "Cart Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    '========================================================
    ' FIND PRODUCT BY STOCK ID
    '========================================================
    Private Function GetProductRowByStockID(
        stockID As Integer
    ) As DataRow

        If productTable Is Nothing Then
            Return Nothing
        End If

        For Each row As DataRow In productTable.Rows

            If Convert.ToInt32(row("stock_id")) = stockID Then
                Return row
            End If

        Next

        Return Nothing

    End Function

    '========================================================
    ' CALCULATE CART TOTAL
    '========================================================
    Private Sub CalculateCartTotal()

        Dim total As Decimal = 0D

        For Each row As DataGridViewRow In dgvOrderCart.Rows

            If row.IsNewRow Then Continue For

            If row.Cells("subtotal").Value Is Nothing Then Continue For

            Dim subtotal As Decimal

            If Decimal.TryParse(
                row.Cells("subtotal").Value.ToString(),
                subtotal
            ) Then
                total += subtotal
            End If

        Next

        lblCartTotal.Text = "₱" & total.ToString("N2")

    End Sub

    '========================================================
    ' GET CART TOTAL
    '========================================================
    Private Function GetCartTotal() As Decimal

        Dim total As Decimal = 0D

        For Each row As DataGridViewRow In dgvOrderCart.Rows

            If row.IsNewRow Then Continue For

            If row.Cells("subtotal").Value Is Nothing Then Continue For

            Dim subtotal As Decimal

            If Decimal.TryParse(
                row.Cells("subtotal").Value.ToString(),
                subtotal
            ) Then
                total += subtotal
            End If

        Next

        Return total

    End Function

    '========================================================
    ' CLEAR CART
    '========================================================
    Private Sub btnClearCart_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnClearCart.Click

        If dgvOrderCart.Rows.Count = 0 Then Return

        Dim answer As DialogResult =
            MessageBox.Show(
                "Clear the current cart?",
                "Clear Cart",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            )

        If answer <> DialogResult.Yes Then Return

        dgvOrderCart.Rows.Clear()
        lblCartTotal.Text = "₱0.00"

    End Sub

    '========================================================
    ' PAY BUTTON - WALLET PAYMENT
    '========================================================
    Private Sub btnPay_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnPay.Click

        If String.IsNullOrWhiteSpace(currentStudentID) Then

            MessageBox.Show(
                "Please search for a student first.",
                "Payment",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            txtStudentIDorder.Focus()
            Return

        End If

        If dgvOrderCart.Rows.Count = 0 Then

            MessageBox.Show(
                "The cart is empty.",
                "Payment",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        If CurrentUser Is Nothing Then

            MessageBox.Show(
                "No cashier is currently logged in.",
                "Payment",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

            Return

        End If

        Dim cashierID As Integer = CurrentUser.UserID

        If cashierID <= 0 Then

            MessageBox.Show(
                "Invalid cashier account.",
                "Payment",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

            Return

        End If

        Try

            Dim total As Decimal = GetCartTotal()

            If total <= 0D Then

                MessageBox.Show(
                    "The order total must be greater than zero.",
                    "Payment",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Return

            End If

            BuildCartTable()

            If cartTable Is Nothing OrElse cartTable.Rows.Count = 0 Then

                MessageBox.Show(
                    "The cart has no valid products.",
                    "Payment",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Return

            End If

            Dim currentBalance As Decimal =
                walletService.GetWalletBalance(currentStudentID)

            lblWalletBalance.Text =
                "Wallet Balance: ₱" & currentBalance.ToString("N2")

            If currentBalance < total Then

                MessageBox.Show(
                    "Insufficient wallet balance." &
                    Environment.NewLine & Environment.NewLine &
                    "Order Total: ₱" & total.ToString("N2") &
                    Environment.NewLine &
                    "Wallet Balance: ₱" & currentBalance.ToString("N2") &
                    Environment.NewLine &
                    "Amount Needed: ₱" &
                    (total - currentBalance).ToString("N2") &
                    Environment.NewLine & Environment.NewLine &
                    "Please load the student's wallet first.",
                    "Insufficient Balance",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Return

            End If

            Dim answer As DialogResult =
                MessageBox.Show(
                    "Confirm wallet payment?" &
                    Environment.NewLine & Environment.NewLine &
                    "Student ID: " & currentStudentID &
                    Environment.NewLine &
                    "Order Total: ₱" & total.ToString("N2") &
                    Environment.NewLine &
                    "Current Balance: ₱" &
                    currentBalance.ToString("N2") &
                    Environment.NewLine &
                    "Balance After Payment: ₱" &
                    (currentBalance - total).ToString("N2"),
                    "Confirm Wallet Payment",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                )

            If answer <> DialogResult.Yes Then Return

            Dim transactionID As Integer =
                orderService.SaveTransaction(
                    currentStudentID,
                    cashierID,
                    total,
                    cartTable
                )

            Dim balanceAfter As Decimal = currentBalance - total

            Try

                balanceAfter =
                    walletService.GetWalletBalance(currentStudentID)

                lblWalletBalance.Text =
                    "Wallet Balance: ₱" & balanceAfter.ToString("N2")

            Catch

                lblWalletBalance.Text =
                    "Wallet Balance: Refresh required"

            End Try

            MessageBox.Show(
                "Wallet payment successful!" &
                Environment.NewLine & Environment.NewLine &
                "Transaction ID: " & transactionID.ToString() &
                Environment.NewLine &
                "Payment Method: Wallet" &
                Environment.NewLine &
                "Amount Paid: ₱" & total.ToString("N2") &
                Environment.NewLine &
                "Remaining Balance: ₱" & balanceAfter.ToString("N2"),
                "Payment Successful",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            ResetNewOrder()

            ' Refresh product display and check the latest stock.
            LoadSelectedCategory()
            CheckLowStockNotifications()

        Catch ex As Exception

            Try

                If Not String.IsNullOrWhiteSpace(currentStudentID) Then

                    Dim latestBalance As Decimal =
                        walletService.GetWalletBalance(currentStudentID)

                    lblWalletBalance.Text =
                        "Wallet Balance: ₱" & latestBalance.ToString("N2")

                End If

            Catch
                ' Keep the original payment error.
            End Try

            MessageBox.Show(
                ex.Message,
                "Wallet Payment Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

        End Try

    End Sub

    '========================================================
    ' BUILD CART DATATABLE
    '========================================================
    Private Sub BuildCartTable()

        cartTable = New DataTable()

        cartTable.Columns.Add("stock_id", GetType(Integer))
        cartTable.Columns.Add("item_name", GetType(String))
        cartTable.Columns.Add("quantity", GetType(Integer))
        cartTable.Columns.Add("price", GetType(Decimal))
        cartTable.Columns.Add("subtotal", GetType(Decimal))

        LoadAllProducts()

        If productTable Is Nothing Then
            Throw New Exception("Product data could not be loaded.")
        End If

        For Each row As DataGridViewRow In dgvOrderCart.Rows

            If row.IsNewRow Then Continue For

            If row.Cells("item_name").Value Is Nothing Then Continue For

            Dim itemName As String =
                row.Cells("item_name").Value.ToString()

            Dim productRow As DataRow =
                GetProductRowByItemName(itemName)

            If productRow Is Nothing Then
                Throw New Exception("Product not found: " & itemName)
            End If

            Dim stockID As Integer =
                Convert.ToInt32(productRow("stock_id"))

            Dim quantity As Integer =
                Convert.ToInt32(row.Cells("quantity").Value)

            Dim price As Decimal =
                Convert.ToDecimal(row.Cells("price").Value)

            Dim subtotal As Decimal =
                Convert.ToDecimal(row.Cells("subtotal").Value)

            If quantity <= 0 Then
                Throw New Exception(
                    "Invalid quantity for " & itemName & "."
                )
            End If

            Dim availableStock As Integer =
                Convert.ToInt32(productRow("quantity"))

            If quantity > availableStock Then
                Throw New Exception(
                    "Not enough stock for " & itemName & "." &
                    Environment.NewLine &
                    "Available stock: " & availableStock.ToString() &
                    Environment.NewLine &
                    "Cart quantity: " & quantity.ToString()
                )
            End If

            cartTable.Rows.Add(
                stockID,
                itemName,
                quantity,
                price,
                subtotal
            )

        Next

    End Sub

    '========================================================
    ' FIND PRODUCT BY NAME
    '========================================================
    Private Function GetProductRowByItemName(
        itemName As String
    ) As DataRow

        If productTable Is Nothing Then Return Nothing

        For Each row As DataRow In productTable.Rows

            If row("item_name").ToString().Equals(
                itemName,
                StringComparison.OrdinalIgnoreCase
            ) Then
                Return row
            End If

        Next

        Return Nothing

    End Function

    '========================================================
    ' RESET NEW ORDER
    '========================================================
    Private Sub ResetNewOrder()

        currentStudentID = ""

        txtStudentIDorder.Clear()

        lblStudentName.Text = "-"
        lblCourse.Text = "-"
        lblYearCart.Text = "-"
        lblWalletBalance.Text = "Wallet Balance: ₱0.00"

        dgvOrderCart.Rows.Clear()
        lblCartTotal.Text = "₱0.00"

        LoadAllProducts()
        LoadSelectedCategory()

        txtStudentIDorder.Focus()

    End Sub

    '========================================================
    ' CLEAR PAYMENT DISPLAY
    '========================================================
    Private Sub ClearPaymentFields()

        lblCartTotal.Text = "₱0.00"

    End Sub

    '========================================================
    ' CLEAN UP TIMER
    '========================================================
    Private Sub UC_NewOrders_Disposed(
        sender As Object,
        e As EventArgs
    ) Handles Me.Disposed

        If productRefreshTimer IsNot Nothing Then

            productRefreshTimer.Stop()
            RemoveHandler productRefreshTimer.Tick,
                AddressOf ProductRefreshTimer_Tick
            productRefreshTimer.Dispose()

        End If

    End Sub

    '========================================================
    ' OTHER DESIGNER EVENTS
    '========================================================
    Private Sub lblYearCart_Click(
        sender As Object,
        e As EventArgs
    ) Handles lblYearCart.Click
    End Sub

    Private Sub txtStudentIDorder_TextChanged(
        sender As Object,
        e As EventArgs
    ) Handles txtStudentIDorder.TextChanged
    End Sub

    Private Sub lblStudentName_Click(
        sender As Object,
        e As EventArgs
    ) Handles lblStudentName.Click
    End Sub

    Private Sub lblCourse_Click(
        sender As Object,
        e As EventArgs
    ) Handles lblCourse.Click
    End Sub

    Private Sub dgvOrderCart_CellContentClick(
        sender As Object,
        e As DataGridViewCellEventArgs
    ) Handles dgvOrderCart.CellContentClick
    End Sub

    '========================================================
    ' LOAD STUDENT WALLET - REQUIRES ADMIN APPROVAL
    '========================================================
    Private Sub btnLoadWallet_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnLoadWallet.Click

        If String.IsNullOrWhiteSpace(currentStudentID) Then

            MessageBox.Show(
                "Please search for a student first.",
                "Wallet Load",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            txtStudentIDorder.Focus()
            Return

        End If

        If CurrentSession.CurrentUser Is Nothing Then

            MessageBox.Show(
                "No cashier is currently logged in.",
                "Wallet Load",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

            Return

        End If

        Dim cashierID As Integer =
            CurrentSession.CurrentUser.UserID

        If cashierID <= 0 Then

            MessageBox.Show(
                "Invalid cashier account.",
                "Wallet Load",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

            Return

        End If

        Dim amount As Decimal

        If Not Decimal.TryParse(
            txtWalletLoadAmount.Text.Trim(),
            amount
        ) Then

            MessageBox.Show(
                "Please enter a valid wallet load amount.",
                "Wallet Load",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            txtWalletLoadAmount.Focus()
            Return

        End If

        If amount < 50D Then

            MessageBox.Show(
                "The minimum wallet load is ₱50.00.",
                "Wallet Load",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            txtWalletLoadAmount.Focus()
            Return

        End If

        If amount > 99999999.99D Then

            MessageBox.Show(
                "The wallet load amount is too large.",
                "Wallet Load",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            txtWalletLoadAmount.Focus()
            Return

        End If

        Dim answer As DialogResult =
            MessageBox.Show(
                "Submit this wallet load request?" &
                Environment.NewLine & Environment.NewLine &
                "Student ID: " & currentStudentID &
                Environment.NewLine &
                "Load Amount: ₱" & amount.ToString("N2") &
                Environment.NewLine & Environment.NewLine &
                "The student's balance will not increase " &
                "until an admin approves this request.",
                "Confirm Wallet Load Request",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            )

        If answer <> DialogResult.Yes Then Return

        Try

            Dim requestId As Integer =
                walletService.RequestWalletLoad(
                    currentStudentID,
                    cashierID,
                    amount
                )

            Dim currentBalance As Decimal =
                walletService.GetWalletBalance(currentStudentID)

            lblWalletBalance.Text =
                "Wallet Balance: ₱" & currentBalance.ToString("N2")

            txtWalletLoadAmount.Clear()

            MessageBox.Show(
                "Wallet load request submitted successfully!" &
                Environment.NewLine & Environment.NewLine &
                "Request ID: " & requestId.ToString() &
                Environment.NewLine &
                "Student ID: " & currentStudentID &
                Environment.NewLine &
                "Requested Amount: ₱" & amount.ToString("N2") &
                Environment.NewLine &
                "Status: Pending Admin Approval" &
                Environment.NewLine & Environment.NewLine &
                "The student's wallet balance has not changed.",
                "Wallet Load Request Submitted",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

        Catch ex As Exception

            MessageBox.Show(
                "The wallet load request could not be submitted." &
                Environment.NewLine & Environment.NewLine &
                ex.Message,
                "Wallet Load Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    '========================================================
    ' ADD QUANTITY OF SELECTED CART ITEM
    '========================================================
    Private Sub btnCartAdd_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnCartAdd.Click

        If dgvOrderCart.SelectedRows.Count = 0 Then

            MessageBox.Show(
                "Please select a product from the cart first.",
                "Add Quantity",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        Dim selectedRow As DataGridViewRow =
            dgvOrderCart.SelectedRows(0)

        If selectedRow.IsNewRow Then Return

        Try

            Dim itemName As String =
                selectedRow.Cells("item_name").Value.ToString()

            Dim currentQuantity As Integer =
                Convert.ToInt32(selectedRow.Cells("quantity").Value)

            LoadAllProducts()

            Dim productRow As DataRow =
                GetProductRowByItemName(itemName)

            If productRow Is Nothing Then

                MessageBox.Show(
                    "Product not found: " & itemName,
                    "Product Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Return

            End If

            Dim availableStock As Integer =
                Convert.ToInt32(productRow("quantity"))

            Dim price As Decimal =
                Convert.ToDecimal(productRow("price"))

            If currentQuantity >= availableStock Then

                MessageBox.Show(
                    "You cannot add more " & itemName & "." &
                    Environment.NewLine &
                    "Available stock: " & availableStock.ToString(),
                    "Stock Limit",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Return

            End If

            currentQuantity += 1

            selectedRow.Cells("quantity").Value = currentQuantity
            selectedRow.Cells("price").Value = price
            selectedRow.Cells("subtotal").Value =
                price * currentQuantity

            CalculateCartTotal()

        Catch ex As Exception

            MessageBox.Show(
                ex.Message,
                "Add Quantity Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    '========================================================
    ' MINUS QUANTITY OF SELECTED CART ITEM
    '========================================================
    Private Sub btnMin_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnMin.Click

        If dgvOrderCart.SelectedRows.Count = 0 Then

            MessageBox.Show(
                "Please select a product from the cart first.",
                "Remove Quantity",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        Dim selectedRow As DataGridViewRow =
            dgvOrderCart.SelectedRows(0)

        If selectedRow.IsNewRow Then Return

        Try

            Dim currentQuantity As Integer =
                Convert.ToInt32(selectedRow.Cells("quantity").Value)

            If currentQuantity <= 1 Then

                dgvOrderCart.Rows.Remove(selectedRow)

            Else

                currentQuantity -= 1

                Dim price As Decimal =
                    Convert.ToDecimal(selectedRow.Cells("price").Value)

                selectedRow.Cells("quantity").Value = currentQuantity
                selectedRow.Cells("subtotal").Value =
                    price * currentQuantity

            End If

            CalculateCartTotal()

        Catch ex As Exception

            MessageBox.Show(
                ex.Message,
                "Remove Quantity Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

End Class
