
Imports System.Text.RegularExpressions
Imports System.Data.SqlClient

Public Class sign_up

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call connect()
        Call Disp()
    End Sub

    Function Disp()
        Dim nameValid As Boolean
        Dim emailValid As Boolean
        Dim pwdValid As Boolean
        Try
            Dim name As String = TextBox1.Text
            If Not Regex.Match(name, "^[a-z0-9 ]*$", RegexOptions.IgnoreCase).Success Then
                MessageBox.Show("Please enter a valid username!")
                TextBox1.Focus()
                TextBox1.Clear()
                nameValid = False
            Else
                nameValid = True
            End If

            Dim email As String = TextBox2.Text
            Dim reEmail As Regex = New Regex("([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\." + _
           ")|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})", _
           RegexOptions.IgnoreCase _
           Or RegexOptions.CultureInvariant _
           Or RegexOptions.IgnorePatternWhitespace _
           Or RegexOptions.Compiled _
           )

            Dim blnPossibleMatch As Boolean = reEmail.IsMatch(email)

            If blnPossibleMatch Then

                'Check If Entered Email Is In Correct Format
                If Not email.Equals(reEmail.Match(email).ToString) Then

                    MessageBox.Show("Invalid Email Address!")

                Else

                    emailValid = True 'Email is Perfect

                End If

            Else 'Not A Match To Pattern

                emailValid = False 'Set Boolean Variable To False

                MessageBox.Show("Invalid Email Address!") 'Inform User

                TextBox2.Clear() 'Clear Textbox

                TextBox2.Focus() 'Set Focus To TextBox

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


            Dim cpwd As String = TextBox4.Text
            If (String.IsNullOrWhiteSpace(cpwd) And pwdValid = True) Then
                MessageBox.Show("Confirm your Password!")
            Else
                If cpwd <> pwd Then
                    MessageBox.Show("Confirm password should match the password!")
                Else
                    If (nameValid = True And emailValid = True And pwdValid = True) Then
                        Dim query As String
                        Dim sqlcom As SqlCommand
                        Try
                            If MsgBox("Are you Sure?", vbOKCancel) = vbOK Then
                                query = "insert into sign_up ([name],[email],[password]) values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "')"
                                sqlcom = New SqlCommand(query, con)
                                sqlcom.ExecuteNonQuery()
                                MessageBox.Show("Sign up Successful!")
                                Me.Hide()
                                login.Show()
                            End If
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
        Return Nothing

    End Function

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Try
            Me.Hide()
            login.Show()
        Catch ex As Exception

        End Try
    End Sub
   
End Class
