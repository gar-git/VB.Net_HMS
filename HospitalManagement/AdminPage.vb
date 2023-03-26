Imports System.Data
Imports System.Data.OleDb
Public Class AdminPage
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitButton.Click
        Application.Exit()
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        Label8.Show()
        Label9.Show()
        Label10.Show()
        TextBox1.Show()
        TextBox2.Show()
        TextBox3.Show()
        Button1.Show()
        Button2.Show()
        Button3.Show()
        Button4.Show()
        Button5.Show()
        Button6.Show()
        Button7.Show()
        Button8.Show()
        CheckBox1.Show()
    End Sub

    Private Sub AdminPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label15.Text = Adminid
        Label13.Text = AdminName
        Label8.Hide()
        Label9.Hide()
        Label10.Hide()
        ' Label12.Hide()
        TextBox1.Hide()
        TextBox2.Hide()
        TextBox3.Hide()
        Button1.Hide()
        Button2.Hide()
        Button3.Hide()
        Button4.Hide()
        Button5.Hide()
        Button6.Hide()
        Button7.Hide()
        Button8.Hide()
        Button9.Hide()
        CheckBox1.Hide()
        DataGridView1.Hide()
    End Sub

    Private Sub Label1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.MouseHover
        Label1.Font = New Font(Label1.Font.Name, 24, FontStyle.Regular)
        Label1.ForeColor = Color.FromArgb(255, 255, 255)
    End Sub

    Private Sub Label2_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label2.MouseHover
        Label2.Font = New Font(Label2.Font.Name, 24, FontStyle.Regular)
        Label2.ForeColor = Color.FromArgb(255, 255, 255)
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        Me.Hide()
        StaffAccount.Show()
    End Sub

    Private Sub Label3_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label3.MouseHover
        Label3.Font = New Font(Label3.Font.Name, 24, FontStyle.Regular)
        Label3.ForeColor = Color.FromArgb(255, 255, 255)
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        Me.Hide()
        WardAccount.Show()
    End Sub

    Private Sub Label4_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label4.MouseHover
        Label4.Font = New Font(Label4.Font.Name, 24, FontStyle.Regular)
        Label4.ForeColor = Color.FromArgb(255, 255, 255)
       
    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        Me.Hide()
        RoomAccount.Show()
    End Sub

    Private Sub Label5_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label5.MouseHover
        Label5.Font = New Font(Label5.Font.Name, 24, FontStyle.Regular)
        Label5.ForeColor = Color.FromArgb(255, 255, 255)
    End Sub
    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        Me.Hide()
        AdminPasswordChange.Show()
    End Sub

    Private Sub Label7_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label7.MouseHover
        Label7.Font = New Font(Label7.Font.Name, 24, FontStyle.Regular)
        Label7.ForeColor = Color.FromArgb(255, 255, 255)
    End Sub

    Private Sub Label1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.MouseLeave
        Label1.Font = New Font(Label1.Font.Name, 18, FontStyle.Regular)
        Label1.ForeColor = Color.FromArgb(0, 0, 0)
    End Sub

    Private Sub Label2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label2.MouseLeave
        Label2.Font = New Font(Label2.Font.Name, 18, FontStyle.Regular)
        Label2.ForeColor = Color.FromArgb(0, 0, 0)
    End Sub

    Private Sub Label3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label3.MouseLeave
        Label3.Font = New Font(Label3.Font.Name, 18, FontStyle.Regular)
        Label3.ForeColor = Color.FromArgb(0, 0, 0)
    End Sub

    Private Sub Label4_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label4.MouseLeave
        Label4.Font = New Font(Label4.Font.Name, 18, FontStyle.Regular)
        Label4.ForeColor = Color.FromArgb(0, 0, 0)
    End Sub

    Private Sub Label5_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label5.MouseLeave
        Label5.Font = New Font(Label5.Font.Name, 18, FontStyle.Regular)
        Label5.ForeColor = Color.FromArgb(0, 0, 0)
    End Sub

    Private Sub Label7_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label7.MouseLeave
        Label7.Font = New Font(Label7.Font.Name, 18, FontStyle.Regular)
        Label7.ForeColor = Color.FromArgb(0, 0, 0)
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            con.Open()
            cmd = New OleDbCommand("insert into AdminID values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "')", con)
            Dim i As Integer = 0
            i = cmd.ExecuteNonQuery
            If i > 0 Then
                MsgBox("Saved")
            Else
                MsgBox("Failed")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        con.Close()
        Button4.PerformClick()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            con.Open()
            cmd = New OleDbCommand("UPDATE AdminID SET AdminID.Name = '" & TextBox2.Text & "', AdminID.[Password] = '" & Val(TextBox3.Text) & "' where Id=" & Val(TextBox1.Text), con)
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
        con.Close()
        Button4.PerformClick()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            con.Open()
            cmd = New OleDbCommand("delete from AdminID where ID=" & (TextBox1.Text), con)
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
        Button4.PerformClick()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Button9.Show()
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
        Button7.Enabled = False
        Button8.Enabled = False
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True
        Button6.Enabled = True
        Button7.Enabled = True
        Button8.Enabled = True
        Try
            con.Open()
            cmd = New OleDbCommand("Select Name,Password from AdminId where Id=" & (TextBox1.Text), con)
            myr = cmd.ExecuteReader()
            myr.Read()
            TextBox2.Text = myr("Name")
            TextBox3.Text = myr("Password")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        con.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        DataGridView1.Show()
        con.Open()
        Dim ds As New DataSet
        Dim dt As New DataTable
        ds.Tables.Add(dt)
        da = New OleDbDataAdapter("select Id,name from AdminID", con)
        da.Fill(dt)
        DataGridView1.DataSource = dt.DefaultView
        con.Close()
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        Me.Hide()
        DoctorAccount.Show()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        DataGridView1.Hide()
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Hide()
        MainFrame.Visible = True
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Me.Hide()
        MainFrame.Show()
        MsgBox("You have successfully Logged out")
    End Sub

End Class