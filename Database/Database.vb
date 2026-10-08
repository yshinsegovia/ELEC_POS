Imports MySqlConnector

Module database

    Public connectionString As String =
        "Server=localhost;" &
        "Port=3306;" &
        "Database=HungryTable;" &
        "User ID=root;" &
        "Password=root;"

    Public Function GetConnection() As MySqlConnection

        Return New MySqlConnection(connectionString)

    End Function

End Module