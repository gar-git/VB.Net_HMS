Imports System.Data
Imports System.Data.OleDb
Public Class StaffAccount

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Application.Exit()
    End Sub

    Private Sub NewButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewButton.Click
        TextBox1.Text = Nothing
        TextBox2.Text = Nothing
        TextBox3.Text = Nothing
        TextBox4.Text = Nothing
        TextBox5.Text = Nothing
        TextBox6.Text = Nothing
        TextBox7.Text = Nothing
        TextBox8.Text = Nothing
        TextBox9.Text = Nothing
        TextBox10.Text = Nothing
        TextBox11.Text = Nothing
        TextBox12.Text = Nothing
    End Sub

    Private Sub RetButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RetButton.Click
        DataGridView1.Show()
        con.Open()
        Dim ds As New DataSet
        Dim dt As New DataTable
        ds.Tables.Add(dt)
        da = New OleDbDataAdapter("select * from staff", con)
        da.Fill(dt)
        DataGridView1.DataSource = dt.DefaultView
        con.Close()
    End Sub

    Private Sub UpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateButton.Click
        Try
            con.Open()
            Dim ID As String = TextBox1.Text
            cmd = New OleDbCommand("UPDATE staff SET staff.sName = '" & TextBox2.Text & "', staff.Address = '" & TextBox4.Text & "', staff.Contact = '" & TextBox5.Text & "', staff.Age = " & TextBox12.Text & ",staff.Email = '" & TextBox6.Text & "', staff.job = '" & TextBox7.Text & "', staff.salary = '" & TextBox8.Text & "', staff.Gender = '" & TextBox9.Text & "', Staff.BloodGroup = '" & TextBox10.Text & "', staff.JoinDate = '" & TextBox11.Text & "'  WHERE staff.ID=" & Val(TextBox1.Text), con)
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

    Private Sub StaffAccount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.Hide()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.Hide()
        MainFrame.Show()
        MsgBox("You have successfully Logged out")
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Hide()
        AdminPage.Show()
    End Sub

    Private Sub SaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        Try
            con.Open()
            cmd = New OleDbCommand("insert into Staff values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox12.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','" & TextBox9.Text & "','" & TextBox10.Text & "','" & TextBox11.Text & "')", con)
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
        RetButton.PerformClick()
    End Sub

    Private Sub RetspecificButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RetspecificButton.Click
        Try
            con.Open()
            cmd = New OleDbCommand("Select * from staff where ID=" & (TextBox1.Text), con)
            myr = cmd.ExecuteReader()
            myr.Read()
            TextBox2.Text = myr("Sname")
            TextBox3.Text = "Cannot Show Password"
            TextBox4.Text = myr("Address")
            TextBox5.Text = myr("Contact")
            TextBox6.Text = myr("Email")
            TextBox7.Text = myr("Job")
            TextBox8.Text = myr("Salary")
            TextBox9.Text = myr("Gender")
            TextBox10.Text = myr("BloodGroup")
            TextBox11.Text = myr("JoinDate")
            TextBox12.Text = myr("Age")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        con.Close()
    End Sub

    Private Sub DeleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        Try
            con.Open()
            cmd = New OleDbCommand("delete from staff where ID=" & (TextBox1.Text), con)
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

    Private Sub Button8_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button8.MouseHover
        Button8.Font = New Font(Label1.Font.Name, 24, FontStyle.Regular)
        Button8.ForeColor = Color.FromArgb(255, 255, 255)
    End Sub

    Private Sub Button8_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button8.MouseLeave
        Button8.Font = New Font(Label7.Font.Name, 18, FontStyle.Regular)
        Button8.ForeColor = Color.FromArgb(255, 255, 255)
    End Sub
    Private Sub Button9_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button9.MouseHover
        Button9.Font = New Font(Label1.Font.Name, 24, FontStyle.Regular)
        Button9.ForeColor = Color.FromArgb(255, 255, 255)
    End Sub

    Private Sub Button9_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button9.MouseLeave
        Button9.Font = New Font(Label7.Font.Name, 18, FontStyle.Regular)
        Button9.ForeColor = Color.FromArgb(255, 255, 255)
    End Sub

    Private Sub Button10_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button10.MouseHover
        Button10.Font = New Font(Label1.Font.Name, 24, FontStyle.Regular)
        Button10.ForeColor = Color.FromArgb(255, 255, 255)
    End Sub

    Private Sub Button10_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button10.MouseLeave
        Button10.Font = New Font(Label7.Font.Name, 18, FontStyle.Regular)
        Button10.ForeColor = Color.FromArgb(255, 255, 255)
    End Sub

    Private Sub EmptyButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmptyButton.Click
        DataGridView1.Visible = False
    End Sub
End Class