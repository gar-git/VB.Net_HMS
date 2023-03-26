Imports System.Data
Imports System.Data.OleDb
Public Class MainFrame
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim password As String = ""
        Dim Name As String = ""
        If (ComboBox1.SelectedItem = Nothing Or ComboBox2.SelectedItem = Nothing Or TextBox2.Text = Nothing) Then
            MsgBox("Enter the Data in the Fields")
        End If
        If ComboBox1.SelectedItem = "Admin" Then
            Try
                con.Open()
                cmd = New OleDbCommand("Select password, name from AdminID where id=" & Val(ComboBox2.SelectedItem), con)
                myr = cmd.ExecuteReader()
                myr.Read()
                password = myr("password")
                Name = myr("name")
                Adminid = ComboBox2.SelectedItem
                AdminName = Name
                AdminPass = password 'for accessing on a different page
                If password = TextBox2.Text Then
                    Me.Hide()
                    AdminPage.Show()
                Else
                    MsgBox("Invalid Password")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        con.Close()
        If ComboBox1.SelectedItem = "Receptionist" Then
            Try
                con.Open()
                cmd = New OleDbCommand("Select password,Sname from staff where id=" & Val(ComboBox2.SelectedItem), con)
                myr = cmd.ExecuteReader()
                myr.Read()
                password = myr("password")
                Name = myr("Sname")
                RecepID = ComboBox2.SelectedItem
                RecepName = Name
                If password = TextBox2.Text Then
                    Me.Hide()
                    Form1.Show()
                Else
                    MsgBox("Invalid Password")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        con.Close()
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        If ComboBox1.SelectedItem = "Admin" Then
            Try

                con.Open()
                cmd = New OleDbCommand("Select * from AdminID ", con)
                myr = cmd.ExecuteReader()
                ComboBox2.Items.Clear()
                While myr.Read()
                    ComboBox2.Items.Add(myr("ID"))
                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            con.Close()
        ElseIf ComboBox1.SelectedItem = "Receptionist" Then

            Try
                con.Open()
                Dim query As String = "Select * from staff where job=" + "'Receptionist'"
                cmd = New OleDbCommand(query, con)
                myr = cmd.ExecuteReader()
                ComboBox2.Items.Clear()
                While myr.Read()
                    ComboBox2.Items.Add(myr("id"))
                End While
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            con.Close()
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox2.UseSystemPasswordChar = False
        Else
            TextBox2.UseSystemPasswordChar = True
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        TextBox2.Text = Nothing
        CheckBox1.Checked = False
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        dev.Visible = True
        Me.Hide()
    End Sub
End Class
