Imports System.Data
Imports System.Data.OleDb
Public Class DoctorAccount
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Application.Exit()
    End Sub
    Private Sub SaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        Try
            con.Open()
            cmd = New OleDbCommand("insert into Doctor values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox10.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','" & TextBox11.Text & "','" & TextBox12.Text & "','" & TextBox9.Text & "')", con)
            Dim i As Integer = 0
            i = cmd.ExecuteNonQuery
            If i > 0 Then
                MsgBox("Saved", MsgBoxStyle.Information)
            Else
                MsgBox("Failed", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        con.Close()
    End Sub

    Private Sub NewButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewButton.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
        TextBox12.Text = ""
    End Sub
    Private Sub UpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateButton.Click
        Try
            con.Open()
            Dim ID As String = TextBox1.Text
            cmd = New OleDbCommand("UPDATE Doctor SET Doctor.DocName = '" & TextBox2.Text & "', Doctor.Address = '" & TextBox4.Text & "', Doctor.Contact = '" & TextBox5.Text & "', Doctor.Age = " & TextBox10.Text & ",Doctor.Email = '" & TextBox6.Text & "', Doctor.Qualification = '" & TextBox7.Text & "', Doctor.Specialization = '" & TextBox8.Text & "', Doctor.Gender = '" & TextBox11.Text & "', Doctor.Blood = '" & TextBox12.Text & "' WHERE Doctor.ID=" & Val(TextBox1.Text), con)
            Dim i As Integer = 0
            i = cmd.ExecuteNonQuery()
            If i > 0 Then
                MsgBox("Updated", MsgBoxStyle.Information)
            Else
                MsgBox("Failed", MsgBoxStyle.Information)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        con.Close()
    End Sub

    Private Sub DeleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        Try
            con.Open()
            cmd = New OleDbCommand("delete from Doctor where ID=" & (TextBox1.Text), con)
            Dim i As Integer = 0
            i = cmd.ExecuteNonQuery()

            If i > 0 Then
                MsgBox("delete")
            Else
                MsgBox("Failed")

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        con.Close()
        RetButton.PerformClick()
    End Sub

    Private Sub RetspecificButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RetspecificButton.Click
        Try
            con.Open()
            cmd = New OleDbCommand("Select * from Doctor where ID=" & (TextBox1.Text), con)
            myr = cmd.ExecuteReader()
            myr.Read()
            TextBox2.Text = myr("DocName")
            TextBox3.Text = "Cannot Show Password"
            TextBox4.Text = myr("Address")
            TextBox5.Text = myr("Contact")
            TextBox6.Text = myr("Email")
            TextBox7.Text = myr("Qualification")
            TextBox8.Text = myr("Specialization")
            TextBox9.Text = myr("JoinDate")
            TextBox10.Text = myr("Age")
            TextBox11.Text = myr("Gender")
            TextBox12.Text = myr("Blood")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        con.Close()
    End Sub

    Private Sub RetButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RetButton.Click
        con.Open()
        Dim ds As New DataSet
        Dim dt As New DataTable
        ds.Tables.Add(dt)
        da = New OleDbDataAdapter("select * from doctor", con)
        da.Fill(dt)
        DataGridView2.DataSource = dt.DefaultView
        con.Close()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.Hide()
        MainFrame.Show()
        MsgBox("You have Successfully logged out")
    End Sub
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Hide()
        AdminPage.Show()
    End Sub

    Private Sub DoctorAccount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class