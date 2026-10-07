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
        CType(dgvListofProducts, ComponentModel.ISupportInitialize).BeginInit()
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
        ' UC_Products
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
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

End Class
