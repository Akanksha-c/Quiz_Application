Imports System.Data.SqlClient
Public Class logo_res
    Public count As Integer

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        Label3.Text = logo4.count
    End Sub

    Private Sub logo_res_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label3.Text = logo4.count
        Dim a As Integer
        a = logo4.count
        If a = 0 Then
            Label4.Text = "Oops.! Better luck next time.! :("
        ElseIf a = 1 Then
            Label4.Text = "You can do better than that.! :)"
        ElseIf a = 2 Then
            Label4.Text = "Oh well... ;)"
        ElseIf a = 3 Then
            Label4.Text = "Hey.! Not bad.! :D"
        ElseIf a = 4 Then
            Label4.Text = "Almost a Trivia Genius.! Congrats.! :D"
        Else
            Label4.Text = "Yaay.! You are a Trivia Genius.! :D"
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        Homepage.show()
    End Sub
End Class