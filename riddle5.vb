Imports System.Data.SqlClient
Public Class riddle5
    Public name1 As String
    Public count As Integer
    Private Sub riddle5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = riddle4.count
        
    End Sub
    Dim submittedanswer As String

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call connect()

        Dim sqlcom As SqlCommand
        Dim sqlcom1 As SqlCommand
        Dim query As String
        Dim query1 As String
        Dim sda As SqlDataAdapter
        Dim dt As DataTable
        Try

            query = "INSERT INTO [quiz].[dbo].[riddle_submitted]([sa])VALUES('" + submittedanswer + "')"
            sqlcom = New SqlCommand(query, con)
            sqlcom.ExecuteNonQuery()
            query1 = "select sa from riddle_submitted where sa='3'"
            sqlcom1 = New SqlCommand(query1, con)
            sda = New SqlDataAdapter(sqlcom1)
            dt = New DataTable()
            sda.Fill(dt)

            If (dt.Rows.Count > 0) Then
                count = TextBox1.Text
                count = count + 1
                TextBox1.Text = count
            Else
                count = TextBox1.Text
                MsgBox("Incorrect. The correct answer is 3")
            End If
            name1 = login.getvariable()
            Dim query2 As String
            Dim sqlcom2 As SqlCommand
            Dim category As String = "Riddles"
            query2 = "INSERT INTO [quiz].[dbo].[results] ([name],[category],[marks]) VALUES ('" & name1 & "','" & category & "','" & count & "')"
            sqlcom2 = New SqlCommand(query2, con)
            sqlcom2.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Hide()
        riddle_res.Show()
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
End Class