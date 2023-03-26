Public Class dev
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If RichTextBox2.Visible = False Then
            RichTextBox1.Visible = False
            RichTextBox2.Visible = True
            Button1.Text = "Okay"
        ElseIf RichTextBox1.Visible = False Then
            RichTextBox1.Visible = True
            RichTextBox2.Visible = False
            Button1.Text = "Contact Us"
        End If
    End Sub

    Private Sub dev_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RichTextBox2.Visible = False
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Application.Exit()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Hide()
        MainFrame.Visible = True
    End Sub
End Class