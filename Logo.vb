Imports System.Data.SqlClient
Public Class Logo

    Public count As Integer
    Dim submittedanswer As String
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call connect()
        Dim sqlcom As SqlCommand
        Dim sqlcom1 As SqlCommand
        Dim sqlcom2 As SqlCommand
        Dim query As String
        Dim query1 As String
        Dim query2 As String
        Dim sda As SqlDataAdapter
        Dim dt As DataTable
        Try
            query2 = "Truncate table logo_submitted"
            sqlcom2 = New SqlCommand(query2, con)
            sqlcom2.ExecuteNonQuery()
            query = "INSERT INTO [quiz].[dbo].[logo_submitted]([sa])VALUES('" + submittedanswer + "')"
            sqlcom = New SqlCommand(query, con)
            sqlcom.ExecuteNonQuery()
            query1 = "select ls.sa from logo_submitted ls where ls.sa='Xbox'"
            sqlcom1 = New SqlCommand(query1, con)
            sqlcom1.ExecuteNonQuery()
            sda = New SqlDataAdapter(sqlcom1)
            dt = New DataTable()
            sda.Fill(dt)
            count = 0
            If (dt.Rows.Count > 0) Then
                TextBox1.Text = 1
                count = count + 1
                count = TextBox1.Text
            Else
                count = TextBox1.Text
                MsgBox("Incorrect.The correct answer is Xbox")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Hide()
        logo1.Show()
    End Sub
    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        submittedanswer = RadioButton1.Text
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        
        submittedanswer = RadioButton2.Text
    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        
        submittedanswer = RadioButton3.Text
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
       
        submittedanswer = RadioButton4.Text
    End Sub

    Private Sub Logo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = 0
    End Sub
End Class