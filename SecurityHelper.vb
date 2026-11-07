Imports System.Security.Cryptography
Imports System.Text

Public Module SecurityHelper

    '========================================================
    ' HASH PASSWORD USING SHA256
    '========================================================
    Public Function HashPassword(password As String) As String
        If String.IsNullOrEmpty(password) Then Return ""

        Using sha256 As SHA256 = SHA256.Create()
            ' Convert the password to bytes
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(password)

            ' Compute the hash
            Dim hash As Byte() = sha256.ComputeHash(bytes)

            ' Convert the hash back to a readable hexadecimal string
            Dim builder As New StringBuilder()
            For Each b As Byte In hash
                builder.Append(b.ToString("x2"))
            Next

            Return builder.ToString()
        End Using
    End Function

End Module