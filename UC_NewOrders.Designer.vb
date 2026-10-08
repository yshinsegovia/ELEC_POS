<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_NewOrders
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
        Panel1 = New Panel()
        lblYearCart = New Label()
        lblCourse = New Label()
        lblStudentName = New Label()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        btnStudentNewOrder = New Button()
        Label3 = New Label()
        txtStudentIDorder = New TextBox()
        Label2 = New Label()
        Panel2 = New Panel()
        lblOrderChange = New Label()
        btnClearCart = New Button()
        btnPay = New Button()
        Label18 = New Label()
        Label13 = New Label()
        txtCash = New TextBox()
        lblCartTotal = New Label()
        Label26 = New Label()
        Label12 = New Label()
        dgvOrderCart = New DataGridView()
        tabMenu = New TabControl()
        tabDrinks = New TabPage()
        tabSnacks = New TabPage()
        tabDesserts = New TabPage()
        tabRice = New TabPage()
        Label7 = New Label()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        CType(dgvOrderCart, ComponentModel.ISupportInitialize).BeginInit()
        tabMenu.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Sitka Text Semibold", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(346, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(136, 33)
        Label1.TabIndex = 2
        Label1.Text = "New Order"
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(lblYearCart)
        Panel1.Controls.Add(lblCourse)
        Panel1.Controls.Add(lblStudentName)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(btnStudentNewOrder)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(txtStudentIDorder)
        Panel1.Controls.Add(Label2)
        Panel1.Location = New Point(3, 58)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(418, 308)
        Panel1.TabIndex = 3
        ' 
        ' lblYearCart
        ' 
        lblYearCart.AutoSize = True
        lblYearCart.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblYearCart.Location = New Point(152, 262)
        lblYearCart.Name = "lblYearCart"
        lblYearCart.Size = New Size(110, 24)
        lblYearCart.TabIndex = 13
        lblYearCart.Text = "++++++++++"
        ' 
        ' lblCourse
        ' 
        lblCourse.AutoSize = True
        lblCourse.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCourse.Location = New Point(152, 203)
        lblCourse.Name = "lblCourse"
        lblCourse.Size = New Size(110, 24)
        lblCourse.TabIndex = 12
        lblCourse.Text = "++++++++++"
        ' 
        ' lblStudentName
        ' 
        lblStudentName.AutoSize = True
        lblStudentName.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblStudentName.Location = New Point(152, 143)
        lblStudentName.Name = "lblStudentName"
        lblStudentName.Size = New Size(110, 24)
        lblStudentName.TabIndex = 11
        lblStudentName.Text = "++++++++++"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(13, 262)
        Label6.Name = "Label6"
        Label6.Size = New Size(89, 24)
        Label6.TabIndex = 10
        Label6.Text = "Year Level:"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(13, 203)
        Label5.Name = "Label5"
        Label5.Size = New Size(64, 24)
        Label5.TabIndex = 9
        Label5.Text = "Course:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(13, 143)
        Label4.Name = "Label4"
        Label4.Size = New Size(116, 24)
        Label4.TabIndex = 8
        Label4.Text = "Student Name:"
        ' 
        ' btnStudentNewOrder
        ' 
        btnStudentNewOrder.Font = New Font("Sitka Heading Semibold", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnStudentNewOrder.Location = New Point(313, 72)
        btnStudentNewOrder.Name = "btnStudentNewOrder"
        btnStudentNewOrder.Size = New Size(94, 29)
        btnStudentNewOrder.TabIndex = 7
        btnStudentNewOrder.Text = "Search"
        btnStudentNewOrder.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(13, 70)
        Label3.Name = "Label3"
        Label3.Size = New Size(95, 24)
        Label3.TabIndex = 6
        Label3.Text = "Student_ID:"
        ' 
        ' txtStudentIDorder
        ' 
        txtStudentIDorder.Font = New Font("Sitka Banner Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtStudentIDorder.Location = New Point(104, 67)
        txtStudentIDorder.Multiline = True
        txtStudentIDorder.Name = "txtStudentIDorder"
        txtStudentIDorder.Size = New Size(203, 34)
        txtStudentIDorder.TabIndex = 5
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Sitka Display", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(96, 13)
        Label2.Name = "Label2"
        Label2.Size = New Size(211, 26)
        Label2.TabIndex = 4
        Label2.Text = "STUDENT INFORMATION"
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(lblOrderChange)
        Panel2.Controls.Add(btnClearCart)
        Panel2.Controls.Add(btnPay)
        Panel2.Controls.Add(Label18)
        Panel2.Controls.Add(Label13)
        Panel2.Controls.Add(txtCash)
        Panel2.Controls.Add(lblCartTotal)
        Panel2.Controls.Add(Label26)
        Panel2.Controls.Add(Label12)
        Panel2.Controls.Add(dgvOrderCart)
        Panel2.Location = New Point(424, 58)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(437, 686)
        Panel2.TabIndex = 4
        ' 
        ' lblOrderChange
        ' 
        lblOrderChange.AutoSize = True
        lblOrderChange.Font = New Font("Sitka Display Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblOrderChange.Location = New Point(104, 456)
        lblOrderChange.Name = "lblOrderChange"
        lblOrderChange.Size = New Size(78, 26)
        lblOrderChange.TabIndex = 100
        lblOrderChange.Text = "++++++"
        ' 
        ' btnClearCart
        ' 
        btnClearCart.Font = New Font("Sitka Heading Semibold", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnClearCart.Location = New Point(283, 564)
        btnClearCart.Name = "btnClearCart"
        btnClearCart.Size = New Size(94, 29)
        btnClearCart.TabIndex = 99
        btnClearCart.Text = "CLEAR"
        btnClearCart.UseVisualStyleBackColor = True
        ' 
        ' btnPay
        ' 
        btnPay.Font = New Font("Sitka Heading Semibold", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnPay.Location = New Point(55, 564)
        btnPay.Name = "btnPay"
        btnPay.Size = New Size(94, 29)
        btnPay.TabIndex = 14
        btnPay.Text = "PAY"
        btnPay.UseVisualStyleBackColor = True
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.Font = New Font("Sitka Display Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label18.Location = New Point(13, 456)
        Label18.Name = "Label18"
        Label18.Size = New Size(72, 26)
        Label18.TabIndex = 97
        Label18.Text = "Change:"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label13.Location = New Point(13, 385)
        Label13.Name = "Label13"
        Label13.Size = New Size(49, 24)
        Label13.TabIndex = 96
        Label13.Text = "Cash:"
        ' 
        ' txtCash
        ' 
        txtCash.Font = New Font("Sitka Banner Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtCash.Location = New Point(104, 382)
        txtCash.Multiline = True
        txtCash.Name = "txtCash"
        txtCash.Size = New Size(203, 34)
        txtCash.TabIndex = 95
        ' 
        ' lblCartTotal
        ' 
        lblCartTotal.AutoSize = True
        lblCartTotal.Font = New Font("Sitka Display Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCartTotal.Location = New Point(104, 319)
        lblCartTotal.Name = "lblCartTotal"
        lblCartTotal.Size = New Size(78, 26)
        lblCartTotal.TabIndex = 94
        lblCartTotal.Text = "++++++"
        ' 
        ' Label26
        ' 
        Label26.AutoSize = True
        Label26.Font = New Font("Sitka Display Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label26.Location = New Point(13, 319)
        Label26.Name = "Label26"
        Label26.Size = New Size(54, 26)
        Label26.TabIndex = 93
        Label26.Text = "Total:"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Sitka Display", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label12.Location = New Point(155, 13)
        Label12.Name = "Label12"
        Label12.Size = New Size(115, 26)
        Label12.TabIndex = 14
        Label12.Text = "ORDER CART"
        ' 
        ' dgvOrderCart
        ' 
        dgvOrderCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvOrderCart.Location = New Point(3, 87)
        dgvOrderCart.Name = "dgvOrderCart"
        dgvOrderCart.RowHeadersWidth = 51
        dgvOrderCart.Size = New Size(431, 188)
        dgvOrderCart.TabIndex = 0
        ' 
        ' tabMenu
        ' 
        tabMenu.Controls.Add(tabDrinks)
        tabMenu.Controls.Add(tabSnacks)
        tabMenu.Controls.Add(tabDesserts)
        tabMenu.Controls.Add(tabRice)
        tabMenu.Location = New Point(13, 427)
        tabMenu.Name = "tabMenu"
        tabMenu.SelectedIndex = 0
        tabMenu.Size = New Size(370, 322)
        tabMenu.TabIndex = 85
        ' 
        ' tabDrinks
        ' 
        tabDrinks.Location = New Point(4, 29)
        tabDrinks.Name = "tabDrinks"
        tabDrinks.Padding = New Padding(3)
        tabDrinks.Size = New Size(362, 289)
        tabDrinks.TabIndex = 2
        tabDrinks.Text = "Drinks"
        tabDrinks.UseVisualStyleBackColor = True
        ' 
        ' tabSnacks
        ' 
        tabSnacks.Location = New Point(4, 29)
        tabSnacks.Name = "tabSnacks"
        tabSnacks.Padding = New Padding(3)
        tabSnacks.Size = New Size(362, 289)
        tabSnacks.TabIndex = 3
        tabSnacks.Text = "Snacks"
        tabSnacks.UseVisualStyleBackColor = True
        ' 
        ' tabDesserts
        ' 
        tabDesserts.Location = New Point(4, 29)
        tabDesserts.Name = "tabDesserts"
        tabDesserts.Padding = New Padding(3)
        tabDesserts.Size = New Size(362, 289)
        tabDesserts.TabIndex = 4
        tabDesserts.Text = "Desserts"
        tabDesserts.UseVisualStyleBackColor = True
        ' 
        ' tabRice
        ' 
        tabRice.Location = New Point(4, 29)
        tabRice.Name = "tabRice"
        tabRice.Padding = New Padding(3)
        tabRice.Size = New Size(362, 289)
        tabRice.TabIndex = 5
        tabRice.Text = "Rice Meal"
        tabRice.UseVisualStyleBackColor = True
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Sitka Display", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(150, 377)
        Label7.Name = "Label7"
        Label7.Size = New Size(61, 26)
        Label7.TabIndex = 101
        Label7.Text = "MENU"
        ' 
        ' UC_NewOrders
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(Label7)
        Controls.Add(tabMenu)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(Label1)
        Name = "UC_NewOrders"
        Size = New Size(875, 785)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(dgvOrderCart, ComponentModel.ISupportInitialize).EndInit()
        tabMenu.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Public Property lblYearLevelCart As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtStudentIDorder As TextBox
    Friend WithEvents btnStudentNewOrder As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblCourse As Label
    Friend WithEvents lblStudentName As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents tabMenu As TabControl
    Friend WithEvents tabDrinks As TabPage
    Friend WithEvents tabSnacks As TabPage
    Friend WithEvents tabDesserts As TabPage
    Friend WithEvents tabRice As TabPage
    Friend WithEvents Label12 As Label
    Friend WithEvents dgvOrderCart As DataGridView
    Friend WithEvents btnClearCart As Button
    Friend WithEvents btnPay As Button
    Public Property lblChangeCart As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txtCash As TextBox
    Friend WithEvents lblCartTotal As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents lblOrderChange As Label
    Friend WithEvents lblYearCart As Label
    Friend WithEvents Label7 As Label

End Class
