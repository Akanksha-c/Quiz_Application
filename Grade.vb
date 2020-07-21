Imports System.Data.SqlClient

Public Class Grade
    Public name1 As String
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
       
    End Sub

    Private Sub Grade_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
     
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        homepage.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Call connect()
        Dim dapt As SqlDataAdapter
        Dim dt As New DataTable
        name1 = login.getvariable()
        Try
            dapt = New SqlDataAdapter("select * from results where name = '" & name1 & "' ", con)
            dapt.Fill(dt)
            DataGridView1.DataSource = dt
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub
End Class