
Imports System.Text.RegularExpressions
Imports System.Data.SqlClient
Public Class login
    Public name1 As String

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call connect()
        Dim nameValid As Boolean
        Dim pwdValid As Boolean

        Dim name As String = TextBox1.Text
        If String.IsNullOrWhiteSpace(name) Then
            MessageBox.Show("Enter your username to login!")
        Else
            If Not Regex.Match(name, "^[a-z0-9 ]*$", RegexOptions.IgnoreCase).Success Then
                MessageBox.Show("Please enter a valid username!")
                TextBox1.Focus()
                TextBox1.Clear()
                nameValid = False
            Else
                nameValid = True
            End If
        End If

        Dim pwd As String = TextBox3.Text
        If String.IsNullOrWhiteSpace(pwd) Then
            MessageBox.Show("Password is required!")
        Else
            Dim pattern As String = "^.*(?=.{6,8})(?=.*[a-zA-Z0-9]).*$"
            If pwd.Trim <> "" Then
                If Not Regex.IsMatch(pwd, pattern) Then
                    MessageBox.Show("Password is not Valid. Enter minimum 6 characters")
                    TextBox3.Clear()
                    TextBox3.Focus()
                Else
                    pwdValid = True
                End If

            End If
        End If

        If (nameValid = True And pwdValid = True) Then
            Dim adapter As New SqlDataAdapter()
            Dim table As New DataTable()
            Dim query As String
            Dim sqlcom As SqlCommand
            Try
                query = "SELECT name, password FROM sign_up WHERE name = @name AND password = @pwd"
                sqlcom = New SqlCommand(query, con)
                sqlcom.Parameters.Add("@name", SqlDbType.VarChar).Value = TextBox1.Text
                sqlcom.Parameters.Add("@pwd", SqlDbType.VarChar).Value = TextBox3.Text

                adapter.SelectCommand = sqlcom
                adapter.Fill(table)

                If table.Rows.Count > 0 Then
                    name1 = TextBox1.Text
                    Me.Hide()
                    homepage.Show()

                Else

        MessageBox.Show("This Username Or/And Password Doesn't Exists", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End If
            Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        End If
    End Sub

    Public Function getvariable()
        Return (name1)
    End Function


    Private Function sqlcom() As SqlCommand
        Throw New NotImplementedException
    End Function

End Class
