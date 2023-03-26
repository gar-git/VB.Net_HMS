Imports System.Data
Imports System.Data.OleDb
Public Class PatientBilling



    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Application.Exit()

    End Sub


    Private Sub PatientBilling_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Hide()
        MainFrame.Show()
        MsgBox("You have successfully Logged out")
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
    End Sub
    Private Sub NewButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewButton.Click

    End Sub
End Class