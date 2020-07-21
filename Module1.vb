Imports System.Data.SqlClient

Module Module1
    Public con As SqlConnection

    Public Function connect()
        Try
            con = New SqlConnection("Server=.;database=quiz;uid=sa;pwd=9482075338;")
            con.Open()

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        Return Nothing
    End Function
End Module
