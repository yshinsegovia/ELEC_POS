
Imports MySqlConnector
Imports System.Data

Public Class DashboardService

    '========================================================
    ' GET TOTAL ORDERS
    '========================================================
    Public Function GetTotalOrders() As Integer

        Dim query As String =
            "SELECT COUNT(*) " &
            "FROM transactions"

        Try

            Using connection As MySqlConnection =
                database.GetConnection()

                connection.Open()

                Using command As New MySqlCommand(
                    query,
                    connection
                )

                    Return Convert.ToInt32(
                        command.ExecuteScalar()
                    )

                End Using

            End Using

        Catch ex As Exception

            Throw New Exception(
                "Error getting total orders: " &
                ex.Message
            )

        End Try

    End Function


    '========================================================
    ' GET TOTAL SALES
    '========================================================
    Public Function GetTotalSales() As Decimal

        Dim query As String =
            "SELECT COALESCE(SUM(total_amount), 0) " &
            "FROM transactions"

        Try

            Using connection As MySqlConnection =
                database.GetConnection()

                connection.Open()

                Using command As New MySqlCommand(
                    query,
                    connection
                )

                    Return Convert.ToDecimal(
                        command.ExecuteScalar()
                    )

                End Using

            End Using

        Catch ex As Exception

            Throw New Exception(
                "Error getting total sales: " &
                ex.Message
            )

        End Try

    End Function


    '========================================================
    ' GET TOTAL STUDENTS
    '========================================================
    Public Function GetTotalStudents() As Integer

        Dim query As String =
            "SELECT COUNT(*) " &
            "FROM user_reg"

        Try

            Using connection As MySqlConnection =
                database.GetConnection()

                connection.Open()

                Using command As New MySqlCommand(
                    query,
                    connection
                )

                    Return Convert.ToInt32(
                        command.ExecuteScalar()
                    )

                End Using

            End Using

        Catch ex As Exception

            Throw New Exception(
                "Error getting total students: " &
                ex.Message
            )

        End Try

    End Function


    '========================================================
    ' GET LOW STOCK COUNT
    '
    ' 1 to 10 = Low Stock
    ' 0 = Unavailable
    '========================================================
    Public Function GetLowStockCount() As Integer

        Dim query As String =
            "SELECT COUNT(*) " &
            "FROM stocks " &
            "WHERE quantity BETWEEN 1 AND 10"

        Try

            Using connection As MySqlConnection =
                database.GetConnection()

                connection.Open()

                Using command As New MySqlCommand(
                    query,
                    connection
                )

                    Return Convert.ToInt32(
                        command.ExecuteScalar()
                    )

                End Using

            End Using

        Catch ex As Exception

            Throw New Exception(
                "Error getting low stock count: " &
                ex.Message
            )

        End Try

    End Function


    '========================================================
    ' GET RECENT ORDERS
    '========================================================
    Public Function GetRecentOrders() As DataTable

        Dim table As New DataTable()


        Dim query As String =
            "SELECT " &
            "t.transaction_id AS `Transaction ID`, " &
            "t.student_id AS `Student ID`, " &
            "CONCAT(ur.firstname, ' ', ur.lastname) AS `Student Name`, " &
            "u.username AS `Cashier`, " &
            "t.transaction_date AS `Date`, " &
            "t.total_amount AS `Total`, " &
            "t.payment_method AS `Payment` " &
            "FROM transactions t " &
            "INNER JOIN user_reg ur " &
            "ON t.student_id = ur.student_id " &
            "INNER JOIN `user` u " &
            "ON t.cashier_id = u.user_id " &
            "ORDER BY t.transaction_date DESC " &
            "LIMIT 10"

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


            Return table


        Catch ex As Exception

            Throw New Exception(
                "Error loading recent orders: " &
                ex.Message
            )

        End Try

    End Function

End Class