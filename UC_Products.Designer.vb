<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_Products
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Label1 = New Label()
        btnAll = New Button()
        btnRiceMeal = New Button()
        btnDrinks = New Button()
        btnSnacks = New Button()
        btnDesserts = New Button()
        btnSearchP = New Button()
        txtSearchProducts = New TextBox()
        dgvListofProducts = New DataGridView()
        btnAddProducts = New Button()
        pnlAddProduct = New Panel()
        txtQuantity = New TextBox()
        txtPrice = New TextBox()
        cmbUnit = New ComboBox()
        Label5 = New Label()
        Label4 = New Label()
        cmbCategory = New ComboBox()
        btnCancel = New Button()
        btnSave = New Button()
        txtProductName = New TextBox()
        Label9 = New Label()
        Label8 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        pnlEditProduct = New Panel()
        txtEditQuantity = New TextBox()
        Label7 = New Label()
        txtEditPrice = New TextBox()
        cmbEditUnit = New ComboBox()
        Label6 = New Label()
        cmbEditCategory = New ComboBox()
        btnCancelEdit = New Button()
        btnUpdateProduct = New Button()
        txtEditProductName = New TextBox()
        Label10 = New Label()
        Label11 = New Label()
        Label12 = New Label()
        Label13 = New Label()
        CType(dgvListofProducts, ComponentModel.ISupportInitialize).BeginInit()
        pnlAddProduct.SuspendLayout()
        pnlEditProduct.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Sitka Text Semibold", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(22, 46)
        Label1.Name = "Label1"
        Label1.Size = New Size(140, 33)
        Label1.TabIndex = 2
        Label1.Text = "PRODUCTS"
        ' 
        ' btnAll
        ' 
        btnAll.Font = New Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnAll.Location = New Point(6, 205)
        btnAll.Name = "btnAll"
        btnAll.Size = New Size(156, 31)
        btnAll.TabIndex = 3
        btnAll.Text = "ALL"
        btnAll.UseVisualStyleBackColor = True
        ' 
        ' btnRiceMeal
        ' 
        btnRiceMeal.Font = New Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnRiceMeal.Location = New Point(185, 205)
        btnRiceMeal.Name = "btnRiceMeal"
        btnRiceMeal.Size = New Size(156, 31)
        btnRiceMeal.TabIndex = 4
        btnRiceMeal.Text = "RICE MEAL"
        btnRiceMeal.UseVisualStyleBackColor = True
        ' 
        ' btnDrinks
        ' 
        btnDrinks.Font = New Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnDrinks.Location = New Point(360, 205)
        btnDrinks.Name = "btnDrinks"
        btnDrinks.Size = New Size(156, 31)
        btnDrinks.TabIndex = 5
        btnDrinks.Text = "DRINKS"
        btnDrinks.UseVisualStyleBackColor = True
        ' 
        ' btnSnacks
        ' 
        btnSnacks.Font = New Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnSnacks.Location = New Point(530, 205)
        btnSnacks.Name = "btnSnacks"
        btnSnacks.Size = New Size(156, 31)
        btnSnacks.TabIndex = 6
        btnSnacks.Text = "SNACKS"
        btnSnacks.UseVisualStyleBackColor = True
        ' 
        ' btnDesserts
        ' 
        btnDesserts.Font = New Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnDesserts.Location = New Point(701, 205)
        btnDesserts.Name = "btnDesserts"
        btnDesserts.Size = New Size(156, 31)
        btnDesserts.TabIndex = 7
        btnDesserts.Text = "DESSERT"
        btnDesserts.UseVisualStyleBackColor = True
        ' 
        ' btnSearchP
        ' 
        btnSearchP.Font = New Font("Sitka Banner", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnSearchP.Location = New Point(701, 128)
        btnSearchP.Name = "btnSearchP"
        btnSearchP.Size = New Size(124, 31)
        btnSearchP.TabIndex = 9
        btnSearchP.Text = "Search" & vbCrLf
        btnSearchP.UseVisualStyleBackColor = True
        ' 
        ' txtSearchProducts
        ' 
        txtSearchProducts.Font = New Font("Sitka Heading", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtSearchProducts.Location = New Point(434, 128)
        txtSearchProducts.Multiline = True
        txtSearchProducts.Name = "txtSearchProducts"
        txtSearchProducts.Size = New Size(240, 31)
        txtSearchProducts.TabIndex = 8
        ' 
        ' dgvListofProducts
        ' 
        dgvListofProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvListofProducts.Location = New Point(2, 260)
        dgvListofProducts.Name = "dgvListofProducts"
        dgvListofProducts.RowHeadersWidth = 51
        dgvListofProducts.Size = New Size(871, 316)
        dgvListofProducts.TabIndex = 10
        ' 
        ' btnAddProducts
        ' 
        btnAddProducts.Font = New Font("Sitka Banner", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnAddProducts.Location = New Point(540, 602)
        btnAddProducts.Name = "btnAddProducts"
        btnAddProducts.Size = New Size(228, 44)
        btnAddProducts.TabIndex = 11
        btnAddProducts.Text = "+ Add Product"
        btnAddProducts.UseVisualStyleBackColor = True
        ' 
        ' pnlAddProduct
        ' 
        pnlAddProduct.BorderStyle = BorderStyle.FixedSingle
        pnlAddProduct.Controls.Add(txtQuantity)
        pnlAddProduct.Controls.Add(txtPrice)
        pnlAddProduct.Controls.Add(cmbUnit)
        pnlAddProduct.Controls.Add(Label5)
        pnlAddProduct.Controls.Add(Label4)
        pnlAddProduct.Controls.Add(cmbCategory)
        pnlAddProduct.Controls.Add(btnCancel)
        pnlAddProduct.Controls.Add(btnSave)
        pnlAddProduct.Controls.Add(txtProductName)
        pnlAddProduct.Controls.Add(Label9)
        pnlAddProduct.Controls.Add(Label8)
        pnlAddProduct.Controls.Add(Label3)
        pnlAddProduct.Controls.Add(Label2)
        pnlAddProduct.Location = New Point(80, 165)
        pnlAddProduct.Name = "pnlAddProduct"
        pnlAddProduct.Size = New Size(688, 372)
        pnlAddProduct.TabIndex = 12
        pnlAddProduct.Visible = False
        ' 
        ' txtQuantity
        ' 
        txtQuantity.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtQuantity.Location = New Point(500, 181)
        txtQuantity.Multiline = True
        txtQuantity.Name = "txtQuantity"
        txtQuantity.Size = New Size(151, 34)
        txtQuantity.TabIndex = 23
        ' 
        ' txtPrice
        ' 
        txtPrice.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtPrice.Location = New Point(162, 181)
        txtPrice.Multiline = True
        txtPrice.Name = "txtPrice"
        txtPrice.Size = New Size(151, 34)
        txtPrice.TabIndex = 22
        ' 
        ' cmbUnit
        ' 
        cmbUnit.Font = New Font("Sitka Display Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        cmbUnit.FormattingEnabled = True
        cmbUnit.Items.AddRange(New Object() {"pcs", "bottle", "cup", "pack", "box"})
        cmbUnit.Location = New Point(162, 244)
        cmbUnit.Name = "cmbUnit"
        cmbUnit.Size = New Size(243, 29)
        cmbUnit.TabIndex = 21
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(47, 245)
        Label5.Name = "Label5"
        Label5.Size = New Size(46, 24)
        Label5.TabIndex = 20
        Label5.Text = "Unit:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(417, 184)
        Label4.Name = "Label4"
        Label4.Size = New Size(77, 24)
        Label4.TabIndex = 18
        Label4.Text = "Quantity:"
        ' 
        ' cmbCategory
        ' 
        cmbCategory.Font = New Font("Sitka Display Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        cmbCategory.FormattingEnabled = True
        cmbCategory.Items.AddRange(New Object() {"Rice Meals", "Drinks", "Snacks", "Desserts"})
        cmbCategory.Location = New Point(162, 126)
        cmbCategory.Name = "cmbCategory"
        cmbCategory.Size = New Size(151, 29)
        cmbCategory.TabIndex = 16
        ' 
        ' btnCancel
        ' 
        btnCancel.Font = New Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnCancel.Location = New Point(425, 316)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(151, 32)
        btnCancel.TabIndex = 15
        btnCancel.Text = "CANCEL"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' btnSave
        ' 
        btnSave.Font = New Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnSave.Location = New Point(73, 316)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(151, 32)
        btnSave.TabIndex = 7
        btnSave.Text = "SAVE"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' txtProductName
        ' 
        txtProductName.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtProductName.Location = New Point(162, 65)
        txtProductName.Multiline = True
        txtProductName.Name = "txtProductName"
        txtProductName.Size = New Size(243, 34)
        txtProductName.TabIndex = 8
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(47, 184)
        Label9.Name = "Label9"
        Label9.Size = New Size(51, 24)
        Label9.TabIndex = 7
        Label9.Text = "Price:"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(47, 126)
        Label8.Name = "Label8"
        Label8.Size = New Size(78, 24)
        Label8.TabIndex = 6
        Label8.Text = "Category:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(47, 68)
        Label3.Name = "Label3"
        Label3.Size = New Size(115, 24)
        Label3.TabIndex = 1
        Label3.Text = "Product Name:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Sitka Display", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(276, 21)
        Label2.Name = "Label2"
        Label2.Size = New Size(129, 26)
        Label2.TabIndex = 0
        Label2.Text = "ADD PRODUCT"
        ' 
        ' pnlEditProduct
        ' 
        pnlEditProduct.BorderStyle = BorderStyle.FixedSingle
        pnlEditProduct.Controls.Add(txtEditQuantity)
        pnlEditProduct.Controls.Add(Label7)
        pnlEditProduct.Controls.Add(txtEditPrice)
        pnlEditProduct.Controls.Add(cmbEditUnit)
        pnlEditProduct.Controls.Add(Label6)
        pnlEditProduct.Controls.Add(cmbEditCategory)
        pnlEditProduct.Controls.Add(btnCancelEdit)
        pnlEditProduct.Controls.Add(btnUpdateProduct)
        pnlEditProduct.Controls.Add(txtEditProductName)
        pnlEditProduct.Controls.Add(Label10)
        pnlEditProduct.Controls.Add(Label11)
        pnlEditProduct.Controls.Add(Label12)
        pnlEditProduct.Controls.Add(Label13)
        pnlEditProduct.Location = New Point(84, 93)
        pnlEditProduct.Name = "pnlEditProduct"
        pnlEditProduct.Size = New Size(688, 401)
        pnlEditProduct.TabIndex = 24
        pnlEditProduct.Visible = False
        ' 
        ' txtEditQuantity
        ' 
        txtEditQuantity.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtEditQuantity.Location = New Point(528, 188)
        txtEditQuantity.Multiline = True
        txtEditQuantity.Name = "txtEditQuantity"
        txtEditQuantity.Size = New Size(151, 34)
        txtEditQuantity.TabIndex = 25
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(445, 191)
        Label7.Name = "Label7"
        Label7.Size = New Size(77, 24)
        Label7.TabIndex = 24
        Label7.Text = "Quantity:"
        ' 
        ' txtEditPrice
        ' 
        txtEditPrice.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtEditPrice.Location = New Point(162, 181)
        txtEditPrice.Multiline = True
        txtEditPrice.Name = "txtEditPrice"
        txtEditPrice.Size = New Size(151, 34)
        txtEditPrice.TabIndex = 22
        ' 
        ' cmbEditUnit
        ' 
        cmbEditUnit.Font = New Font("Sitka Display Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        cmbEditUnit.FormattingEnabled = True
        cmbEditUnit.Items.AddRange(New Object() {"pcs", "bottle", "cup", "pack", "box"})
        cmbEditUnit.Location = New Point(162, 244)
        cmbEditUnit.Name = "cmbEditUnit"
        cmbEditUnit.Size = New Size(243, 29)
        cmbEditUnit.TabIndex = 21
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(47, 245)
        Label6.Name = "Label6"
        Label6.Size = New Size(46, 24)
        Label6.TabIndex = 20
        Label6.Text = "Unit:"
        ' 
        ' cmbEditCategory
        ' 
        cmbEditCategory.Font = New Font("Sitka Display Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        cmbEditCategory.FormattingEnabled = True
        cmbEditCategory.Items.AddRange(New Object() {"Rice Meals", "Drinks", "Snacks", "Desserts"})
        cmbEditCategory.Location = New Point(162, 126)
        cmbEditCategory.Name = "cmbEditCategory"
        cmbEditCategory.Size = New Size(151, 29)
        cmbEditCategory.TabIndex = 16
        ' 
        ' btnCancelEdit
        ' 
        btnCancelEdit.Font = New Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnCancelEdit.Location = New Point(427, 345)
        btnCancelEdit.Name = "btnCancelEdit"
        btnCancelEdit.Size = New Size(151, 32)
        btnCancelEdit.TabIndex = 15
        btnCancelEdit.Text = "CANCEL"
        btnCancelEdit.UseVisualStyleBackColor = True
        ' 
        ' btnUpdateProduct
        ' 
        btnUpdateProduct.Font = New Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnUpdateProduct.Location = New Point(75, 345)
        btnUpdateProduct.Name = "btnUpdateProduct"
        btnUpdateProduct.Size = New Size(151, 32)
        btnUpdateProduct.TabIndex = 7
        btnUpdateProduct.Text = "SAVE"
        btnUpdateProduct.UseVisualStyleBackColor = True
        ' 
        ' txtEditProductName
        ' 
        txtEditProductName.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtEditProductName.Location = New Point(162, 65)
        txtEditProductName.Multiline = True
        txtEditProductName.Name = "txtEditProductName"
        txtEditProductName.Size = New Size(243, 34)
        txtEditProductName.TabIndex = 8
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.Location = New Point(47, 184)
        Label10.Name = "Label10"
        Label10.Size = New Size(51, 24)
        Label10.TabIndex = 7
        Label10.Text = "Price:"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.Location = New Point(47, 126)
        Label11.Name = "Label11"
        Label11.Size = New Size(78, 24)
        Label11.TabIndex = 6
        Label11.Text = "Category:"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label12.Location = New Point(47, 68)
        Label12.Name = "Label12"
        Label12.Size = New Size(115, 24)
        Label12.TabIndex = 1
        Label12.Text = "Product Name:"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Sitka Display", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label13.Location = New Point(276, 21)
        Label13.Name = "Label13"
        Label13.Size = New Size(133, 26)
        Label13.TabIndex = 0
        Label13.Text = "EDIT PRODUCT"
        ' 
        ' UC_Products
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(pnlEditProduct)
        Controls.Add(pnlAddProduct)
        Controls.Add(btnAddProducts)
        Controls.Add(dgvListofProducts)
        Controls.Add(btnSearchP)
        Controls.Add(txtSearchProducts)
        Controls.Add(btnDesserts)
        Controls.Add(btnSnacks)
        Controls.Add(btnDrinks)
        Controls.Add(btnRiceMeal)
        Controls.Add(btnAll)
        Controls.Add(Label1)
        Name = "UC_Products"
        Size = New Size(874, 699)
        CType(dgvListofProducts, ComponentModel.ISupportInitialize).EndInit()
        pnlAddProduct.ResumeLayout(False)
        pnlAddProduct.PerformLayout()
        pnlEditProduct.ResumeLayout(False)
        pnlEditProduct.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents btnAll As Button
    Friend WithEvents btnRiceMeal As Button
    Friend WithEvents btnDrinks As Button
    Friend WithEvents btnSnacks As Button
    Friend WithEvents btnDesserts As Button
    Friend WithEvents btnSearchP As Button
    Friend WithEvents txtSearchProducts As TextBox
    Friend WithEvents dgvListofProducts As DataGridView
    Friend WithEvents btnAddProducts As Button
    Friend WithEvents pnlAddProduct As Panel
    Friend WithEvents cmbCategory As ComboBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents txtProductName As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbUnit As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents pnlEditProduct As Panel
    Friend WithEvents txtEditPrice As TextBox
    Friend WithEvents cmbEditUnit As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbEditCategory As ComboBox
    Friend WithEvents btnCancelEdit As Button
    Friend WithEvents btnUpdateProduct As Button
    Friend WithEvents txtEditProductName As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txtEditQuantity As TextBox
    Friend WithEvents Label7 As Label

End Class
