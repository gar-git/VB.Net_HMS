Imports System.Data
Imports System.Data.OleDb
Public Class patient
    Dim reservedpatientname As String
    Dim charges As Integer
    Dim totalwardbeds As Integer
    Dim countbeds As Integer
    Dim availability As String
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Application.Exit()
    End Sub
    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        Try
            con.Open()
            cmd = New OleDbCommand("Select Charges,ID from room ", con)
            myr = cmd.ExecuteReader()
            ComboBox4.Items.Clear()
            While myr.Read()
                ComboBox4.Items.Add(myr("ID"))
                charges = myr("Charges")
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        con.Close()
    End Sub
    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        Try
            con.Open()
            cmd = New OleDbCommand("Select Charges,ID from ward ", con)
            myr = cmd.ExecuteReader()
            ComboBox4.Items.Clear()
            While myr.Read()
                ComboBox4.Items.Add(myr("ID"))
                charges = myr("Charges")

            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        con.Close()
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        Label11.Text = charges
        Dim i As Integer = ComboBox4.SelectedItem
        If RadioButton1.Checked = True Then
            Try
                con.Open()
                cmd = New OleDbCommand("Select Name from patientadmit where room=" & Val(ComboBox4.SelectedItem) & "and ward=0", con)
                myr = cmd.ExecuteReader()
                myr.Read()
                reservedpatientname = myr("Name")
            Catch ex As Exception
                reservedpatientname = Nothing
            End Try
            con.Close()
        End If
        If RadioButton2.Checked = True Then
            Try
                Try
                    con.Open()
                    cmd = New OleDbCommand("Select beds from ward where id=" & i, con)
                    myr = cmd.ExecuteReader()
                    myr.Read()
                    totalwardbeds = myr("beds")
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                con.Close()
                con.Open()
                cmd = New OleDbCommand("Select Name from patientadmit where room=0 and ward=" & Val(ComboBox4.SelectedItem), con)
                myr = cmd.ExecuteReader()
                countbeds = 0
                While myr.Read()
                    countbeds = countbeds + 1
                End While
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            con.Close()
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If RadioButton1.Checked = True Then
            If ComboBox4.SelectedItem = Nothing Then
                Label13.Text = "Please Select you staying mode"
                Label13.Font = New Font(Label1.Font.Name, 18, FontStyle.Regular)
                Label13.ForeColor = Color.FromArgb(255, 0, 0)
            ElseIf ComboBox4.SelectedItem <> Nothing Then
                If reservedpatientname = Nothing Then
                    Label13.Text = "Available"
                    Label13.Font = New Font(Label1.Font.Name, 18, FontStyle.Regular)
                    Label13.ForeColor = Color.FromArgb(124, 252, 0)
                    availability = "available"
                    MsgBox(availability)
                ElseIf reservedpatientname <> Nothing Then
                    Label13.Text = "Booked by " + reservedpatientname
                    Label13.Font = New Font(Label1.Font.Name, 18, FontStyle.Regular)
                    Label13.ForeColor = Color.FromArgb(255, 0, 0)
                    availability = "unavailable"
                    MsgBox(availability)
                End If
            End If
        End If
        If RadioButton2.Checked = True Then
            Dim i As Integer
            i = totalwardbeds - countbeds
            Dim total As String = i
            If i > 0 Then
                Label13.Text = total + " bed(s) available"
                Label13.Font = New Font(Label1.Font.Name, 18, FontStyle.Regular)
                Label13.ForeColor = Color.FromArgb(124, 252, 0)
                availability = "available"
                MsgBox(availability)
            ElseIf i = 0 Then
                Label13.Text = " bed(s) unavailable"
                Label13.Font = New Font(Label1.Font.Name, 18, FontStyle.Regular)
                Label13.ForeColor = Color.FromArgb(255, 0, 0)
                availability = "unavailable"
                MsgBox(availability)
            End If
        End If
    End Sub
    Private Sub NewButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewButton.Click
        TextBox1.Text = Nothing
        TextBox2.Text = Nothing
        TextBox3.Text = Nothing
        TextBox4.Text = Nothing
        TextBox5.Text = Nothing
        TextBox6.Text = Nothing
        TextBox11.Text = Nothing
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1
        ComboBox4.SelectedIndex = -1
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        Label11.Text = Nothing
        Label13.Text = Nothing
    End Sub
    Private Sub SaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        If availability = "available" Then
            Try
                Dim temp As Integer = 0
                con.Open()
                If RadioButton1.Checked Then
                    Dim d As String = "insert into patientAdmit values('" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & ComboBox1.SelectedItem & "', '" & ComboBox2.SelectedItem & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "', '" & TextBox11.Text & "', '" & TextBox5.Text & "', '" & ComboBox3.SelectedItem & "', '" & ComboBox4.SelectedItem & "', '" & Val(temp) & "', '" & TextBox6.Text & "' , no )"
                    cmd = New OleDbCommand(d, con)
                    Dim i As Integer = 0
                    i = cmd.ExecuteNonQuery
                    If i > 0 Then
                        MsgBox("Saved", MsgBoxStyle.Information)
                    Else
                        MsgBox("Failed", MsgBoxStyle.Information)
                    End If
                ElseIf RadioButton2.Checked Then
                    Dim d As String = "insert into patientAdmit values('" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & ComboBox1.SelectedItem & "', '" & ComboBox2.SelectedItem & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "', '" & TextBox11.Text & "', '" & TextBox5.Text & "', '" & ComboBox3.SelectedItem & "', '" & Val(temp) & "', '" & ComboBox4.SelectedItem & "', '" & TextBox6.Text & "', no )"
                    cmd = New OleDbCommand(d, con)
                    Dim i As Integer = 0
                    i = cmd.ExecuteNonQuery
                    If i > 0 Then
                        MsgBox("Saved", MsgBoxStyle.Information)
                    Else
                        MsgBox("Failed", MsgBoxStyle.Information)
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            con.Close()
            RetButton.PerformClick()
        End If
    End Sub

    Private Sub patient_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            DataGridView1.Hide()
            con.Open()
            cmd = New OleDbCommand("select docname from doctor", con)
            myr = cmd.ExecuteReader()
            While myr.Read()
                ComboBox3.Items.Add(myr("docname"))
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        con.Close()
    End Sub

    Private Sub UpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub RetspecificButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RetspecificButton.Click
        Dim mode As String = ""
        Dim number As Integer
        Try
            con.Open()
            cmd = New OleDbCommand("Select * from patientadmit where Id=" & (TextBox1.Text), con)
            myr = cmd.ExecuteReader()
            myr.Read()
            TextBox2.Text = myr("name")
            ComboBox1.SelectedItem = myr("gender")
            ComboBox2.SelectedItem = myr("bloodgroup")
            TextBox3.Text = myr("contact")
            TextBox4.Text = myr("email")
            TextBox11.Text = myr("Address")
            TextBox5.Text = myr("disease")
            ComboBox3.SelectedItem = myr("doctorname")
            If myr("room") = 0 Then
                mode = "Ward"
                number = myr("ward")
            End If
            If myr("ward") = 0 Then
                mode = "Room"
                number = myr("room")
            End If
            TextBox6.Text = myr("admitdate")
        Catch ex As Exception
        End Try
        con.Close()
        If mode = "Ward" Then
            RadioButton2.Checked = True
            ComboBox4.SelectedItem = number
        ElseIf mode = "Room" Then
            RadioButton1.Checked = True
            ComboBox4.SelectedItem = number
        End If
    End Sub

    Private Sub RetButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RetButton.Click
        DataGridView1.Show()
        con.Open()
        Dim ds As New DataSet
        Dim dt As New DataTable
        ds.Tables.Add(dt)
        da = New OleDbDataAdapter("select * from PatientAdmit", con)
        da.Fill(dt)
        DataGridView1.DataSource = dt.DefaultView
        con.Close()
    End Sub

    Private Sub DeleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        Try
            con.Open()
            cmd = New OleDbCommand("delete from PatientAdmit where ID=" & (TextBox1.Text), con)
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

    Private Sub EmptyButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmptyButton.Click
        DataGridView1.Hide()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.Hide()
        MainFrame.Show()
        MsgBox("You have successfully Logged out")
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click

    End Sub
End Class