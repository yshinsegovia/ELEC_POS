Imports MySqlConnector
Imports System.Data

Public Class UC_NewOrders

    '========================================================
    ' SERVICE
    '========================================================
    Private ReadOnly orderService As New CashierOrderService()


    '========================================================
    ' CURRENT STUDENT
    '========================================================
    Private currentStudentID As String = ""


    '========================================================
    ' PRODUCT DATA
    '========================================================
    Private productTable As DataTable


    '========================================================
    ' CART DATA
    '========================================================
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
    '
    ' This lets newly-added Admin products appear while the
    ' cashier screen is still open.
    '========================================================
    Private ReadOnly productRefreshTimer As New Timer()


    '========================================================
    ' USERCONTROL LOAD
    '========================================================
    Private Sub UC_NewOrders_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        '----------------------------------------------------
        ' SETUP CART
        '----------------------------------------------------
        SetupCartGrid()


        '----------------------------------------------------
        ' SETUP PRODUCT AREAS
        '----------------------------------------------------
        SetupDynamicProductPanels()


        '----------------------------------------------------
        ' LOAD PRODUCTS
        '----------------------------------------------------
        LoadAllProducts()


        '----------------------------------------------------
        ' OPEN RICE MEAL TAB BY DEFAULT
        '----------------------------------------------------
        tabMenu.SelectedTab = tabRice


        '----------------------------------------------------
        ' LOAD DEFAULT CATEGORY
        '----------------------------------------------------
        LoadSelectedCategory()


        '----------------------------------------------------
        ' PAYMENT DISPLAY
        '----------------------------------------------------
        ClearPaymentFields()


        '----------------------------------------------------
        ' START PRODUCT REFRESH
        '----------------------------------------------------
        productRefreshTimer.Interval = 5000

        AddHandler productRefreshTimer.Tick,
            AddressOf ProductRefreshTimer_Tick

        productRefreshTimer.Start()

    End Sub


    '========================================================
    ' SETUP CART GRID
    '========================================================
    Private Sub SetupCartGrid()

        dgvOrderCart.Columns.Clear()

        dgvOrderCart.AutoGenerateColumns = False
        dgvOrderCart.AllowUserToAddRows = False
        dgvOrderCart.AllowUserToDeleteRows = False
        dgvOrderCart.ReadOnly = True

        dgvOrderCart.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect

        dgvOrderCart.MultiSelect = False
        dgvOrderCart.RowHeadersVisible = False


        '----------------------------------------------------
        ' PRODUCT
        '----------------------------------------------------
        Dim productColumn As New DataGridViewTextBoxColumn()

        productColumn.Name = "item_name"
        productColumn.HeaderText = "Product"
        productColumn.Width = 150

        dgvOrderCart.Columns.Add(productColumn)


        '----------------------------------------------------
        ' QUANTITY
        '----------------------------------------------------
        Dim quantityColumn As New DataGridViewTextBoxColumn()

        quantityColumn.Name = "quantity"
        quantityColumn.HeaderText = "Qty"
        quantityColumn.Width = 50

        dgvOrderCart.Columns.Add(quantityColumn)


        '----------------------------------------------------
        ' PRICE
        '----------------------------------------------------
        Dim priceColumn As New DataGridViewTextBoxColumn()

        priceColumn.Name = "price"
        priceColumn.HeaderText = "Price"
        priceColumn.Width = 80

        priceColumn.DefaultCellStyle.Format =
            "₱#,##0.00"

        dgvOrderCart.Columns.Add(priceColumn)


        '----------------------------------------------------
        ' SUBTOTAL
        '----------------------------------------------------
        Dim subtotalColumn As New DataGridViewTextBoxColumn()

        subtotalColumn.Name = "subtotal"
        subtotalColumn.HeaderText = "Subtotal"
        subtotalColumn.Width = 100

        subtotalColumn.DefaultCellStyle.Format =
            "₱#,##0.00"

        dgvOrderCart.Columns.Add(subtotalColumn)

    End Sub


    '========================================================
    ' CREATE DYNAMIC PRODUCT PANELS
    '========================================================
    Private Sub SetupDynamicProductPanels()

        '----------------------------------------------------
        ' RICE MEALS
        '----------------------------------------------------
        tabRice.Controls.Clear()

        flpRice =
            CreateProductFlowPanel("flpRice")

        tabRice.Controls.Add(flpRice)


        '----------------------------------------------------
        ' DRINKS
        '----------------------------------------------------
        tabDrinks.Controls.Clear()

        flpDrinks =
            CreateProductFlowPanel("flpDrinks")

        tabDrinks.Controls.Add(flpDrinks)


        '----------------------------------------------------
        ' SNACKS
        '----------------------------------------------------
        tabSnacks.Controls.Clear()

        flpSnacks =
            CreateProductFlowPanel("flpSnacks")

        tabSnacks.Controls.Add(flpSnacks)


        '----------------------------------------------------
        ' DESSERTS
        '----------------------------------------------------
        tabDesserts.Controls.Clear()

        flpDesserts =
            CreateProductFlowPanel("flpDesserts")

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

        panel.FlowDirection =
            FlowDirection.LeftToRight

        panel.WrapContents = True

        panel.AutoScroll = True

        panel.Padding =
            New Padding(8)

        panel.Margin =
            New Padding(0)


        Return panel

    End Function


    '========================================================
    ' LOAD ALL PRODUCTS
    '========================================================
    Private Sub LoadAllProducts()

        Try

            productTable =
                orderService.GetProducts()

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
    ' LOAD SELECTED CATEGORY
    '========================================================
    Private Sub LoadSelectedCategory()

        If tabMenu.SelectedTab Is Nothing Then

            Return

        End If


        Select Case tabMenu.SelectedTab.Name

            Case "tabRice"

                LoadCategoryProducts(
                    "Rice Meals",
                    flpRice
                )


            Case "tabDrinks"

                LoadCategoryProducts(
                    "Drinks",
                    flpDrinks
                )


            Case "tabSnacks"

                LoadCategoryProducts(
                    "Snacks",
                    flpSnacks
                )


            Case "tabDesserts"

                LoadCategoryProducts(
                    "Desserts",
                    flpDesserts
                )

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

            '------------------------------------------------
            ' GET LATEST PRODUCT DATA
            '------------------------------------------------
            LoadAllProducts()


            '------------------------------------------------
            ' CLEAR OLD BUTTONS
            '------------------------------------------------
            productPanel.Controls.Clear()


            '------------------------------------------------
            ' GET CATEGORY DATA
            '------------------------------------------------
            Dim categoryTable As DataTable =
                orderService.GetProductsByCategory(
                    category
                )


            '------------------------------------------------
            ' NO PRODUCTS
            '------------------------------------------------
            If categoryTable.Rows.Count = 0 Then

                Dim noProducts As New Label()

                noProducts.Text =
                    "No products available."

                noProducts.AutoSize = True

                noProducts.Font =
                    New Font(
                        "Sitka Text",
                        10,
                        FontStyle.Bold
                    )

                noProducts.Margin =
                    New Padding(10)

                productPanel.Controls.Add(
                    noProducts
                )

                Return

            End If


            '------------------------------------------------
            ' CREATE BUTTON FOR EACH PRODUCT
            '------------------------------------------------
            For Each row As DataRow In categoryTable.Rows

                CreateProductButton(
                    row,
                    productPanel
                )

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

        '--------------------------------------------------------
        ' GET PRODUCT INFORMATION
        '--------------------------------------------------------
        Dim stockID As Integer =
        Convert.ToInt32(
            row("stock_id")
        )

        Dim itemName As String =
        row("item_name").ToString()

        Dim price As Decimal =
        Convert.ToDecimal(
            row("price")
        )

        Dim quantity As Integer =
        Convert.ToInt32(
            row("quantity")
        )


        '--------------------------------------------------------
        ' CREATE BUTTON
        '--------------------------------------------------------
        Dim productButton As New Button()


        '--------------------------------------------------------
        ' BUTTON SIZE
        ' 100 x 105 allows 3 buttons to fit in your tab.
        '--------------------------------------------------------
        productButton.Width = 100
        productButton.Height = 105


        '--------------------------------------------------------
        ' SPACING BETWEEN BUTTONS
        '--------------------------------------------------------
        productButton.Margin =
        New Padding(7)


        '--------------------------------------------------------
        ' FONT
        '--------------------------------------------------------
        productButton.Font =
        New Font(
            "Sitka Banner",
            8.5F,
            FontStyle.Bold
        )


        '--------------------------------------------------------
        ' TEXT POSITION
        '--------------------------------------------------------
        productButton.TextAlign =
        ContentAlignment.MiddleCenter


        '--------------------------------------------------------
        ' ALLOW TEXT TO WRAP
        '--------------------------------------------------------
        productButton.UseCompatibleTextRendering = True


        '--------------------------------------------------------
        ' STORE STOCK ID
        '--------------------------------------------------------
        productButton.Tag = stockID


        '--------------------------------------------------------
        ' PRODUCT STATUS
        '--------------------------------------------------------
        If quantity <= 0 Then

            productButton.Text =
            itemName &
            vbCrLf &
            "₱" &
            price.ToString("N2") &
            vbCrLf &
            "UNAVAILABLE"

            productButton.Enabled = False


        ElseIf quantity <= 10 Then

            productButton.Text =
            itemName &
            vbCrLf &
            "₱" &
            price.ToString("N2") &
            vbCrLf &
            "LOW STOCK" &
            vbCrLf &
            quantity.ToString() &
            " LEFT"

            productButton.Enabled = True


        Else

            productButton.Text =
            itemName &
            vbCrLf &
            "₱" &
            price.ToString("N2") &
            vbCrLf &
            "STOCK" &
            vbCrLf &
            quantity.ToString() &
            " LEFT"

            productButton.Enabled = True

        End If


        '--------------------------------------------------------
        ' ADD CLICK EVENT
        '--------------------------------------------------------
        AddHandler productButton.Click,
        Sub(sender As Object, e As EventArgs)

            AddProductToCartByStockID(
                stockID
            )

        End Sub


        '--------------------------------------------------------
        ' ADD BUTTON TO PRODUCT PANEL
        '--------------------------------------------------------
        productPanel.Controls.Add(
        productButton
    )

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

        'Refresh only the currently selected category
        LoadSelectedCategory()

    End Sub


    '========================================================
    ' SEARCH STUDENT
    '========================================================
    Private Sub btnStudentNewOrder_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnStudentNewOrder.Click

        SearchStudent()

    End Sub


    '========================================================
    ' STUDENT SEARCH
    '========================================================
    Private Sub SearchStudent()

        Dim studentID As String =
            txtStudentIDorder.Text.Trim()


        '----------------------------------------------------
        ' EMPTY ID
        '----------------------------------------------------
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
                orderService.GetStudent(
                    studentID
                )


            '------------------------------------------------
            ' NOT FOUND
            '------------------------------------------------
            If studentTable.Rows.Count = 0 Then

                currentStudentID = ""


                lblStudentName.Text =
                    "-"


                lblCourse.Text =
                    "-"


                lblYearCart.Text =
                    "-"


                MessageBox.Show(
                    "Student ID not found.",
                    "Student Search",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Return

            End If


            '------------------------------------------------
            ' GET STUDENT
            '------------------------------------------------
            Dim row As DataRow =
                studentTable.Rows(0)


            currentStudentID =
                row("student_id").ToString()


            Dim firstName As String =
                row("firstname").ToString()


            Dim lastName As String =
                row("lastname").ToString()


            Dim course As String =
                row("course").ToString()


            Dim yearLevel As String =
                row("yearlvl").ToString()


            '------------------------------------------------
            ' DISPLAY STUDENT INFO
            '------------------------------------------------
            lblStudentName.Text =
                firstName &
                " " &
                lastName


            lblCourse.Text =
                course


            lblYearCart.Text =
                yearLevel


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
    Private Sub AddProductToCartByStockID(
        stockID As Integer
    )

        '----------------------------------------------------
        ' STUDENT REQUIRED
        '----------------------------------------------------
        If currentStudentID = "" Then

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

            '------------------------------------------------
            ' GET LATEST PRODUCT DATA
            '------------------------------------------------
            LoadAllProducts()


            Dim productRow As DataRow =
                GetProductRowByStockID(
                    stockID
                )


            If productRow Is Nothing Then

                MessageBox.Show(
                    "Product no longer exists.",
                    "Product",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                'Refresh current category
                LoadSelectedCategory()

                Return

            End If


            Dim itemName As String =
                productRow("item_name").ToString()


            Dim price As Decimal =
                Convert.ToDecimal(
                    productRow("price")
                )


            Dim stockQuantity As Integer =
                Convert.ToInt32(
                    productRow("quantity")
                )


            '------------------------------------------------
            ' CHECK STOCK
            '------------------------------------------------
            If stockQuantity <= 0 Then

                MessageBox.Show(
                    itemName &
                    " is currently unavailable.",
                    "Out of Stock",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                LoadSelectedCategory()

                Return

            End If


            '------------------------------------------------
            ' CHECK CART FOR EXISTING PRODUCT
            '------------------------------------------------
            For Each cartRow As DataGridViewRow
                In dgvOrderCart.Rows

                If cartRow.IsNewRow Then

                    Continue For

                End If


                If cartRow.Cells(
                    "item_name"
                ).Value Is Nothing Then

                    Continue For

                End If


                If cartRow.Cells(
                    "item_name"
                ).Value.ToString().
                    Equals(
                        itemName,
                        StringComparison.OrdinalIgnoreCase
                    ) Then


                    Dim currentQuantity As Integer =
                        Convert.ToInt32(
                            cartRow.Cells(
                                "quantity"
                            ).Value
                        )


                    '--------------------------------------------
                    ' DO NOT EXCEED STOCK
                    '--------------------------------------------
                    If currentQuantity >= stockQuantity Then

                        MessageBox.Show(
                            "You cannot add more " &
                            itemName &
                            "." &
                            Environment.NewLine &
                            "Available stock: " &
                            stockQuantity.ToString(),
                            "Stock Limit",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        )

                        Return

                    End If


                    currentQuantity += 1


                    cartRow.Cells(
                        "quantity"
                    ).Value =
                        currentQuantity


                    cartRow.Cells(
                        "price"
                    ).Value =
                        price


                    cartRow.Cells(
                        "subtotal"
                    ).Value =
                        price *
                        currentQuantity


                    CalculateCartTotal()

                    Return

                End If

            Next


            '------------------------------------------------
            ' ADD NEW PRODUCT TO CART
            '------------------------------------------------
            Dim rowIndex As Integer =
                dgvOrderCart.Rows.Add()


            dgvOrderCart.Rows(rowIndex).
                Cells("item_name").
                Value =
                itemName


            dgvOrderCart.Rows(rowIndex).
                Cells("quantity").
                Value =
                1


            dgvOrderCart.Rows(rowIndex).
                Cells("price").
                Value =
                price


            dgvOrderCart.Rows(rowIndex).
                Cells("subtotal").
                Value =
                price


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


        For Each row As DataRow
            In productTable.Rows

            If Convert.ToInt32(
                row("stock_id")
            ) = stockID Then

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


        For Each row As DataGridViewRow
            In dgvOrderCart.Rows

            If row.IsNewRow Then

                Continue For

            End If


            If row.Cells(
                "subtotal"
            ).Value Is Nothing Then

                Continue For

            End If


            Dim subtotal As Decimal


            If Decimal.TryParse(
                row.Cells(
                    "subtotal"
                ).Value.ToString(),
                subtotal
            ) Then

                total += subtotal

            End If

        Next


        lblCartTotal.Text =
            "₱" &
            total.ToString("N2")


        CalculateChange()

    End Sub


    '========================================================
    ' GET CART TOTAL
    '========================================================
    Private Function GetCartTotal() As Decimal

        Dim total As Decimal = 0D


        For Each row As DataGridViewRow
            In dgvOrderCart.Rows

            If row.IsNewRow Then

                Continue For

            End If


            If row.Cells(
                "subtotal"
            ).Value Is Nothing Then

                Continue For

            End If


            Dim subtotal As Decimal


            If Decimal.TryParse(
                row.Cells(
                    "subtotal"
                ).Value.ToString(),
                subtotal
            ) Then

                total += subtotal

            End If

        Next


        Return total

    End Function


    '========================================================
    ' CASH CHANGED
    '========================================================
    Private Sub txtCash_TextChanged(
        sender As Object,
        e As EventArgs
    ) Handles txtCash.TextChanged

        CalculateChange()

    End Sub


    '========================================================
    ' CALCULATE CHANGE
    '========================================================
    Private Sub CalculateChange()

        Dim total As Decimal =
            GetCartTotal()


        Dim cash As Decimal


        If Decimal.TryParse(
            txtCash.Text.Trim(),
            cash
        ) = False Then

            lblOrderChange.Text =
                "₱0.00"

            Return

        End If


        Dim change As Decimal =
            cash - total


        If change < 0 Then

            lblOrderChange.Text =
                "₱0.00"

        Else

            lblOrderChange.Text =
                "₱" &
                change.ToString("N2")

        End If

    End Sub


    '========================================================
    ' CLEAR CART
    '========================================================
    Private Sub btnClearCart_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnClearCart.Click

        If dgvOrderCart.Rows.Count = 0 Then

            Return

        End If


        Dim answer As DialogResult =
            MessageBox.Show(
                "Clear the current cart?",
                "Clear Cart",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            )


        If answer <> DialogResult.Yes Then

            Return

        End If


        dgvOrderCart.Rows.Clear()


        lblCartTotal.Text =
            "₱0.00"


        txtCash.Clear()


        lblOrderChange.Text =
            "₱0.00"

    End Sub


    '========================================================
    ' PAY BUTTON
    '========================================================
    Private Sub btnPay_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnPay.Click

        '----------------------------------------------------
        ' STUDENT
        '----------------------------------------------------
        If currentStudentID = "" Then

            MessageBox.Show(
                "Please search for a student first.",
                "Payment",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If


        '----------------------------------------------------
        ' CART
        '----------------------------------------------------
        If dgvOrderCart.Rows.Count = 0 Then

            MessageBox.Show(
                "The cart is empty.",
                "Payment",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If


        '----------------------------------------------------
        ' TOTAL
        '----------------------------------------------------
        Dim total As Decimal =
            GetCartTotal()


        '----------------------------------------------------
        ' CASH
        '----------------------------------------------------
        Dim cash As Decimal


        If Decimal.TryParse(
            txtCash.Text.Trim(),
            cash
        ) = False Then

            MessageBox.Show(
                "Please enter a valid cash amount.",
                "Payment",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            txtCash.Focus()

            Return

        End If


        '----------------------------------------------------
        ' CHECK CASH
        '----------------------------------------------------
        If cash < total Then

            MessageBox.Show(
                "Insufficient cash." &
                Environment.NewLine &
                Environment.NewLine &
                "Total: ₱" &
                total.ToString("N2") &
                Environment.NewLine &
                "Cash: ₱" &
                cash.ToString("N2"),
                "Payment",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            txtCash.Focus()

            Return

        End If


        '----------------------------------------------------
        ' CHECK CASHIER SESSION
        '----------------------------------------------------
        If CurrentSession.CurrentUser Is Nothing Then

            MessageBox.Show(
                "No cashier is currently logged in.",
                "Payment",
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
                "Payment",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

            Return

        End If


        '----------------------------------------------------
        ' CALCULATE CHANGE
        '----------------------------------------------------
        Dim change As Decimal =
            cash - total


        '----------------------------------------------------
        ' CONFIRM PAYMENT
        '----------------------------------------------------
        Dim answer As DialogResult =
            MessageBox.Show(
                "Confirm payment?" &
                Environment.NewLine &
                Environment.NewLine &
                "Student ID: " &
                currentStudentID &
                Environment.NewLine &
                "Total: ₱" &
                total.ToString("N2") &
                Environment.NewLine &
                "Cash: ₱" &
                cash.ToString("N2") &
                Environment.NewLine &
                "Change: ₱" &
                change.ToString("N2"),
                "Confirm Payment",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            )


        If answer <> DialogResult.Yes Then

            Return

        End If


        Try

            '------------------------------------------------
            ' BUILD CART
            '------------------------------------------------
            BuildCartTable()


            '------------------------------------------------
            ' SAVE
            '------------------------------------------------
            Dim transactionID As Integer =
                orderService.SaveTransaction(
                    currentStudentID,
                    cashierID,
                    total,
                    cartTable
                )


            '------------------------------------------------
            ' SUCCESS
            '------------------------------------------------
            MessageBox.Show(
                "Payment successful!" &
                Environment.NewLine &
                Environment.NewLine &
                "Transaction ID: " &
                transactionID.ToString() &
                Environment.NewLine &
                "Total: ₱" &
                total.ToString("N2") &
                Environment.NewLine &
                "Cash: ₱" &
                cash.ToString("N2") &
                Environment.NewLine &
                "Change: ₱" &
                change.ToString("N2"),
                "Payment Successful",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )


            '------------------------------------------------
            ' PREPARE NEXT ORDER
            '------------------------------------------------
            ResetNewOrder()


        Catch ex As Exception

            MessageBox.Show(
                ex.Message,
                "Payment Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    '========================================================
    ' BUILD CART DATATABLE
    '========================================================
    Private Sub BuildCartTable()

        cartTable = New DataTable()


        cartTable.Columns.Add(
            "stock_id",
            GetType(Integer)
        )


        cartTable.Columns.Add(
            "item_name",
            GetType(String)
        )


        cartTable.Columns.Add(
            "quantity",
            GetType(Integer)
        )


        cartTable.Columns.Add(
            "price",
            GetType(Decimal)
        )


        cartTable.Columns.Add(
            "subtotal",
            GetType(Decimal)
        )


        For Each row As DataGridViewRow
            In dgvOrderCart.Rows

            If row.IsNewRow Then

                Continue For

            End If


            If row.Cells(
                "item_name"
            ).Value Is Nothing Then

                Continue For

            End If


            Dim itemName As String =
                row.Cells(
                    "item_name"
                ).Value.ToString()


            Dim productRow As DataRow =
                GetProductRowByItemName(
                    itemName
                )


            If productRow Is Nothing Then

                Throw New Exception(
                    "Product not found: " &
                    itemName
                )

            End If


            Dim stockID As Integer =
                Convert.ToInt32(
                    productRow("stock_id")
                )


            Dim quantity As Integer =
                Convert.ToInt32(
                    row.Cells(
                        "quantity"
                    ).Value
                )


            Dim price As Decimal =
                Convert.ToDecimal(
                    row.Cells(
                        "price"
                    ).Value
                )


            Dim subtotal As Decimal =
                Convert.ToDecimal(
                    row.Cells(
                        "subtotal"
                    ).Value
                )


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

        If productTable Is Nothing Then

            Return Nothing

        End If


        For Each row As DataRow
            In productTable.Rows

            If row("item_name").ToString().
                Equals(
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


        lblStudentName.Text =
            "-"


        lblCourse.Text =
            "-"


        lblYearCart.Text =
            "-"


        dgvOrderCart.Rows.Clear()


        lblCartTotal.Text =
            "₱0.00"


        txtCash.Clear()


        lblOrderChange.Text =
            "₱0.00"


        'Refresh current menu
        LoadAllProducts()

        LoadSelectedCategory()


        txtStudentIDorder.Focus()

    End Sub


    '========================================================
    ' CLEAR PAYMENT DISPLAY
    '========================================================
    Private Sub ClearPaymentFields()

        lblCartTotal.Text =
            "₱0.00"


        lblOrderChange.Text =
            "₱0.00"

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

            productRefreshTimer.Dispose()

        End If

    End Sub


    '========================================================
    ' UNUSED LABEL EVENTS
    '========================================================
    Private Sub lblYearCart_Click(
        sender As Object,
        e As EventArgs
    ) Handles lblYearCart.Click

    End Sub


    Private Sub lblOrderChange_Click(
        sender As Object,
        e As EventArgs
    ) Handles lblOrderChange.Click

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

End Class
