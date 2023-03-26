Imports System.Data
Imports System.Data.OleDb
Public Class RoomAccount

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Application.Exit()
    End Sub

    Private Sub SaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        Try
            con.Open()
            cmd = New OleDbCommand("insert into room values('" & TextBox1.Text & "','" & ComboBox1.SelectedItem & "','" & TextBox2.Text & "')", con)
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

    Private Sub RetButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RetButton.Click
        DataGridView1.Show()
        con.Open()
        Dim ds As New DataSet
        Dim dt As New DataTable
        ds.Tables.Add(dt)
        da = New OleDbDataAdapter("select * from room", con)
        da.Fill(dt)
        DataGridView1.DataSource = dt.DefaultView
        con.Close()
    End Sub

    Private Sub UpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateButton.Click
        Try
            con.Open()
            cmd = New OleDbCommand("UPDATE room SET room.type = '" & ComboBox1.SelectedItem & "', room.charges = '" & Val(TextBox2.Text) & "' where room.Id=" & Val(TextBox1.Text), con)
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

    Private Sub RetspecificButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RetspecificButton.Click
        Try
            con.Open()
            cmd = New OleDbCommand("Select * from room where Id=" & (TextBox1.Text), con)
            myr = cmd.ExecuteReader()
            myr.Read()
            TextBox2.Text = myr("charges")
            ComboBox1.Text = myr("type")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        con.Close()
    End Sub

    Private Sub RoomAccount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.Hide()
        NewButton.PerformClick()
    End Sub

    Private Sub EmptyButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmptyButton.Click
        DataGridView1.Hide()
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

    Private Sub DeleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        Try
            con.Open()
            cmd = New OleDbCommand("delete from Room where ID=" & (TextBox1.Text), con)
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
    End Sub

    Private Sub NewButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewButton.Click
        TextBox1.Text = Nothing
        ComboBox1.SelectedIndex = -1
        TextBox2.Text = Nothing
    End Sub
End Class