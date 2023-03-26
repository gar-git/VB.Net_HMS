Imports System.Data
Imports System.Data.OleDb
Public Class WardAccount
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Application.Exit()
    End Sub
    Private Sub NewButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewButton.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub
    Private Sub SaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        Try
            con.Open()
            cmd = New OleDbCommand("insert into Ward values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "')", con)
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

        NewButton.PerformClick()
    End Sub

    Private Sub UpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateButton.Click
        Try
            con.Open()
            cmd = New OleDbCommand("UPDATE ward SET ward.beds = '" & TextBox2.Text & "', ward.charges = '" & Val(TextBox3.Text) & "' where ward.Id=" & Val(TextBox1.Text), con)
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

        NewButton.PerformClick()
    End Sub

    Private Sub RetButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RetButton.Click
        DataGridView1.Show()
        con.Open()
        Dim ds As New DataSet
        Dim dt As New DataTable
        ds.Tables.Add(dt)
        da = New OleDbDataAdapter("select * from ward", con)
        da.Fill(dt)
        DataGridView1.DataSource = dt.DefaultView
        con.Close()
    End Sub

    Private Sub WardAccount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub DeleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        Try
            con.Open()
            cmd = New OleDbCommand("delete from ward where ID=" & (TextBox1.Text), con)
            Dim i As Integer = 0
            i = cmd.ExecuteNonQuery()
            If i > 0 Then
                MsgBox("deleted")
            Else
                MsgBox("Failed")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        con.Close()

        NewButton.PerformClick()
    End Sub

    Private Sub RetspecificButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RetspecificButton.Click
        Try
            con.Open()
            cmd = New OleDbCommand("Select * from ward where Id=" & (TextBox1.Text), con)
            myr = cmd.ExecuteReader()
            myr.Read()
            TextBox2.Text = myr("beds")
            TextBox3.Text = myr("charges")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        con.Close()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Hide()
        AdminPage.Show()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.Hide()
        MainFrame.Show()
        MsgBox("You have successfully Logged out")
    End Sub

    Private Sub Button8_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button8.MouseHover
        Button8.Font = New Font(Label1.Font.Name, 24, FontStyle.Regular)
        Button8.ForeColor = Color.FromArgb(255, 255, 255)
    End Sub

    Private Sub Button8_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button8.MouseLeave
        Button8.Font = New Font(Label1.Font.Name, 18, FontStyle.Regular)
        Button8.ForeColor = Color.FromArgb(255, 255, 255)
    End Sub

    Private Sub Button9_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button9.MouseHover
        Button9.Font = New Font(Label1.Font.Name, 24, FontStyle.Regular)
        Button9.ForeColor = Color.FromArgb(255, 255, 255)
    End Sub

    Private Sub Button10_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button10.MouseHover
        Button10.Font = New Font(Label1.Font.Name, 24, FontStyle.Regular)
        Button10.ForeColor = Color.FromArgb(255, 255, 255)
    End Sub

    Private Sub Button10_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button10.MouseLeave
        Button10.Font = New Font(Label1.Font.Name, 18, FontStyle.Regular)
        Button10.ForeColor = Color.FromArgb(255, 255, 255)
    End Sub

    Private Sub Button9_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button9.MouseLeave
        Button9.Font = New Font(Label1.Font.Name, 18, FontStyle.Regular)
        Button9.ForeColor = Color.FromArgb(255, 255, 255)
    End Sub

    Private Sub EmptyButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmptyButton.Click
        DataGridView1.Visible = False
    End Sub
End Class