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
        lblWalletBalance = New Label()
        lblStudentName = New Label()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        btnStudentNewOrder = New Button()
        Label3 = New Label()
        txtStudentIDorder = New TextBox()
        Label2 = New Label()
        Panel2 = New Panel()
        btnCartAdd = New Button()
        btnMin = New Button()
        btnLoadWallet = New Button()
        txtWalletLoadAmount = New TextBox()
        btnClearCart = New Button()
        btnPay = New Button()
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
        Label1.Font = New Font("Sitka Text Semibold", 17.8F, FontStyle.Bold)
        Label1.Location = New Point(17, 12)
        Label1.Name = "Label1"
        Label1.Size = New Size(207, 43)
        Label1.TabIndex = 2
        Label1.Text = "NEW ORDER"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(106), CByte(106), CByte(67))
        Panel1.BorderStyle = BorderStyle.Fixed3D
        Panel1.Controls.Add(lblYearCart)
        Panel1.Controls.Add(lblCourse)
        Panel1.Controls.Add(lblWalletBalance)
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
        lblYearCart.BackColor = Color.FromArgb(CByte(106), CByte(106), CByte(67))
        lblYearCart.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblYearCart.ForeColor = Color.White
        lblYearCart.Location = New Point(152, 220)
        lblYearCart.Name = "lblYearCart"
        lblYearCart.Size = New Size(110, 24)
        lblYearCart.TabIndex = 13
        lblYearCart.Text = "++++++++++"
        ' 
        ' lblCourse
        ' 
        lblCourse.AutoSize = True
        lblCourse.BackColor = Color.FromArgb(CByte(106), CByte(106), CByte(67))
        lblCourse.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCourse.ForeColor = Color.White
        lblCourse.Location = New Point(152, 172)
        lblCourse.Name = "lblCourse"
        lblCourse.Size = New Size(110, 24)
        lblCourse.TabIndex = 12
        lblCourse.Text = "++++++++++"
        ' 
        ' lblWalletBalance
        ' 
        lblWalletBalance.AutoSize = True
        lblWalletBalance.BackColor = Color.FromArgb(CByte(106), CByte(106), CByte(67))
        lblWalletBalance.Font = New Font("Sitka Display Semibold", 11.1999989F, FontStyle.Bold)
        lblWalletBalance.ForeColor = Color.White
        lblWalletBalance.Location = New Point(187, 261)
        lblWalletBalance.Name = "lblWalletBalance"
        lblWalletBalance.Size = New Size(170, 28)
        lblWalletBalance.TabIndex = 101
        lblWalletBalance.Text = "WALLET BALANCE:"
        ' 
        ' lblStudentName
        ' 
        lblStudentName.AutoSize = True
        lblStudentName.BackColor = Color.FromArgb(CByte(106), CByte(106), CByte(67))
        lblStudentName.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblStudentName.ForeColor = Color.White
        lblStudentName.Location = New Point(152, 129)
        lblStudentName.Name = "lblStudentName"
        lblStudentName.Size = New Size(110, 24)
        lblStudentName.TabIndex = 11
        lblStudentName.Text = "++++++++++"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.FromArgb(CByte(106), CByte(106), CByte(67))
        Label6.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = Color.White
        Label6.Location = New Point(40, 220)
        Label6.Name = "Label6"
        Label6.Size = New Size(89, 24)
        Label6.TabIndex = 10
        Label6.Text = "Year Level:"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.FromArgb(CByte(106), CByte(106), CByte(67))
        Label5.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = Color.White
        Label5.Location = New Point(65, 172)
        Label5.Name = "Label5"
        Label5.Size = New Size(64, 24)
        Label5.TabIndex = 9
        Label5.Text = "Course:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.FromArgb(CByte(106), CByte(106), CByte(67))
        Label4.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.White
        Label4.Location = New Point(13, 129)
        Label4.Name = "Label4"
        Label4.Size = New Size(116, 24)
        Label4.TabIndex = 8
        Label4.Text = "Student Name:"
        ' 
        ' btnStudentNewOrder
        ' 
        btnStudentNewOrder.BackColor = Color.FromArgb(CByte(190), CByte(160), CByte(122))
        btnStudentNewOrder.Font = New Font("Sitka Heading Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnStudentNewOrder.Location = New Point(313, 72)
        btnStudentNewOrder.Name = "btnStudentNewOrder"
        btnStudentNewOrder.Size = New Size(94, 29)
        btnStudentNewOrder.TabIndex = 7
        btnStudentNewOrder.Text = "Search"
        btnStudentNewOrder.UseVisualStyleBackColor = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Sitka Display Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.White
        Label3.Location = New Point(13, 70)
        Label3.Name = "Label3"
        Label3.Size = New Size(95, 24)
        Label3.TabIndex = 6
        Label3.Text = "Student_ID:"
        ' 
        ' txtStudentIDorder
        ' 
        txtStudentIDorder.Font = New Font("Sitka Banner Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtStudentIDorder.Location = New Point(117, 67)
        txtStudentIDorder.Multiline = True
        txtStudentIDorder.Name = "txtStudentIDorder"
        txtStudentIDorder.Size = New Size(190, 34)
        txtStudentIDorder.TabIndex = 5
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Sitka Display", 11.8F, FontStyle.Bold)
        Label2.Location = New Point(96, 13)
        Label2.Name = "Label2"
        Label2.Size = New Size(236, 29)
        Label2.TabIndex = 4
        Label2.Text = "STUDENT INFORMATION"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.FromArgb(CByte(106), CByte(106), CByte(67))
        Panel2.BorderStyle = BorderStyle.Fixed3D
        Panel2.Controls.Add(btnCartAdd)
        Panel2.Controls.Add(btnMin)
        Panel2.Controls.Add(btnLoadWallet)
        Panel2.Controls.Add(txtWalletLoadAmount)
        Panel2.Controls.Add(btnClearCart)
        Panel2.Controls.Add(btnPay)
        Panel2.Controls.Add(lblCartTotal)
        Panel2.Controls.Add(Label26)
        Panel2.Controls.Add(Label12)
        Panel2.Controls.Add(dgvOrderCart)
        Panel2.Location = New Point(424, 58)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(437, 686)
        Panel2.TabIndex = 4
        ' 
        ' btnCartAdd
        ' 
        btnCartAdd.BackColor = Color.FromArgb(CByte(190), CByte(160), CByte(122))
        btnCartAdd.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Bold)
        btnCartAdd.Location = New Point(273, 301)
        btnCartAdd.Name = "btnCartAdd"
        btnCartAdd.Size = New Size(43, 34)
        btnCartAdd.TabIndex = 105
        btnCartAdd.Text = "+"
        btnCartAdd.UseVisualStyleBackColor = False
        ' 
        ' btnMin
        ' 
        btnMin.BackColor = Color.FromArgb(CByte(190), CByte(160), CByte(122))
        btnMin.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Bold)
        btnMin.Location = New Point(345, 302)
        btnMin.Name = "btnMin"
        btnMin.Size = New Size(43, 34)
        btnMin.TabIndex = 104
        btnMin.Text = "-"
        btnMin.UseVisualStyleBackColor = False
        ' 
        ' btnLoadWallet
        ' 
        btnLoadWallet.BackColor = Color.FromArgb(CByte(190), CByte(160), CByte(122))
        btnLoadWallet.Font = New Font("Sitka Heading Semibold", 11F, FontStyle.Bold)
        btnLoadWallet.Location = New Point(138, 583)
        btnLoadWallet.Name = "btnLoadWallet"
        btnLoadWallet.Size = New Size(144, 46)
        btnLoadWallet.TabIndex = 103
        btnLoadWallet.Text = "LOAD WALLET"
        btnLoadWallet.UseVisualStyleBackColor = False
        ' 
        ' txtWalletLoadAmount
        ' 
        txtWalletLoadAmount.Font = New Font("Sitka Banner Semibold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtWalletLoadAmount.Location = New Point(113, 543)
        txtWalletLoadAmount.Multiline = True
        txtWalletLoadAmount.Name = "txtWalletLoadAmount"
        txtWalletLoadAmount.Size = New Size(203, 34)
        txtWalletLoadAmount.TabIndex = 102
        ' 
        ' btnClearCart
        ' 
        btnClearCart.BackColor = Color.FromArgb(CByte(190), CByte(160), CByte(122))
        btnClearCart.Font = New Font("Sitka Heading Semibold", 10F, FontStyle.Bold)
        btnClearCart.Location = New Point(240, 409)
        btnClearCart.Name = "btnClearCart"
        btnClearCart.Size = New Size(94, 40)
        btnClearCart.TabIndex = 99
        btnClearCart.Text = "CLEAR"
        btnClearCart.UseVisualStyleBackColor = False
        ' 
        ' btnPay
        ' 
        btnPay.BackColor = Color.FromArgb(CByte(190), CByte(160), CByte(122))
        btnPay.Font = New Font("Sitka Heading Semibold", 10F, FontStyle.Bold)
        btnPay.Location = New Point(108, 411)
        btnPay.Name = "btnPay"
        btnPay.Size = New Size(94, 37)
        btnPay.TabIndex = 14
        btnPay.Text = "PAY"
        btnPay.UseVisualStyleBackColor = False
        ' 
        ' lblCartTotal
        ' 
        lblCartTotal.AutoSize = True
        lblCartTotal.Font = New Font("Sitka Display Semibold", 11.8F, FontStyle.Bold)
        lblCartTotal.ForeColor = Color.White
        lblCartTotal.Location = New Point(113, 306)
        lblCartTotal.Name = "lblCartTotal"
        lblCartTotal.Size = New Size(85, 29)
        lblCartTotal.TabIndex = 94
        lblCartTotal.Text = "++++++"
        ' 
        ' Label26
        ' 
        Label26.AutoSize = True
        Label26.Font = New Font("Sitka Display Semibold", 11.8F, FontStyle.Bold)
        Label26.ForeColor = Color.White
        Label26.Location = New Point(22, 306)
        Label26.Name = "Label26"
        Label26.Size = New Size(61, 29)
        Label26.TabIndex = 93
        Label26.Text = "Total:"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Sitka Display", 11.8F, FontStyle.Bold)
        Label12.Location = New Point(155, 13)
        Label12.Name = "Label12"
        Label12.Size = New Size(127, 29)
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
        Label7.Font = New Font("Sitka Display", 11.8F, FontStyle.Bold)
        Label7.Location = New Point(150, 377)
        Label7.Name = "Label7"
        Label7.Size = New Size(69, 29)
        Label7.TabIndex = 101
        Label7.Text = "MENU"
        ' 
        ' UC_NewOrders
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(106), CByte(106), CByte(67))
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
    Friend WithEvents lblCartTotal As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents lblYearCart As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblWalletBalance As Label
    Friend WithEvents txtWalletLoadAmount As TextBox
    Friend WithEvents btnLoadWallet As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents btnMin As Button
    Friend WithEvents btnCartAdd As Button
    Public Property btnAdd As Button
End Class
