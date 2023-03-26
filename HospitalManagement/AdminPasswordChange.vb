Imports System.Data
Imports System.Data.OleDb
Public Class AdminPasswordChange

    Private Sub AdminPasswordChange_Load_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label5.Text = Adminid
        Label13.Text = AdminName
        TextBox1.Text = Adminid
        TextBox2.Text = AdminName
        TextBox1.ReadOnly = True
        TextBox2.ReadOnly = True
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Application.Exit()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If (TextBox3.Text = Nothing Or TextBox4.Text = Nothing) Then
            MsgBox("Enter the values in the fields")
        ElseIf (TextBox3.Text = AdminPass) Then
            Try
                con.Open()
                cmd = New OleDbCommand("UPDATE AdminID SET  AdminID.[Password] = '" & Val(TextBox4.Text) & "' where Id=" & Val(TextBox1.Text), con)
                Dim i As Integer = 0
                i = cmd.ExecuteNonQuery()
                If i > 0 Then
                    MsgBox("Updated")
                Else
                    MsgBox("Failed")

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        AdminPage.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        MainFrame.Show()
    End Sub
End Class