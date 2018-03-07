Imports System.Net.Mail

Public Class Optionsvb

    Dim history As Integer = 0

    Public Sub setHistory(ByVal Int As Integer)
        history = Int
    End Sub
    Public Function getHistory()
        Return history
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtHomePage_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHomePage.TextChanged

    End Sub

    Private Sub Optionsvb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtHomePage.Text = My.Settings.homePage

        If My.Settings.HomePageOrBlankPAge = 0 Then
            cmbStartUp.SelectedIndex = 0
        ElseIf My.Settings.HomePageOrBlankPAge = 1 Then
            cmbStartUp.SelectedIndex = 1
        End If
        My.Settings.HomePageOrBlankPAge = cmbStartUp.SelectedIndex.ToString
        My.Settings.Save()
        My.Settings.Reload()

        rbRememberHis.Checked = True
        setHistory(0)


        Try
            Dim process As New Process
            process.StartInfo.UseShellExecute = False
            process.StartInfo.RedirectStandardOutput = True

            Try
                process.StartInfo.FileName = "ipconfig"
                process.StartInfo.Arguments = "/all"
                process.StartInfo.CreateNoWindow = True
                process.Start()
                txtNetwork.Text = txtNetwork.Text + Replace(process.StandardOutput.ReadToEnd(), Chr(13) & Chr(13), Chr(13))
                process.WaitForExit()
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        My.Settings.homePage = txtHomePage.Text
        My.Settings.Save()
        My.Settings.Reload()


        My.Settings.HomePageOrBlankPAge = cmbStartUp.SelectedIndex.ToString
        My.Settings.Save()
        My.Settings.Reload()

        MsgBox("Changes Saved! You must restart your browser to complete action.")
    End Sub

    Private Sub TabPage3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage3.Click

    End Sub


    Private Sub rbRememberHis_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbRememberHis.CheckedChanged
        If rbRememberHis.Checked = True Then
            setHistory(0)
        End If
    End Sub

    Private Sub rbNeverRememberHis_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbNeverRememberHis.CheckedChanged
        If rbNeverRememberHis.Checked = True Then
            setHistory(1)
        End If
    End Sub

    Private Sub btnSendEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendEmail.Click
        Try
            Dim MyMailMessage As New MailMessage()
            MyMailMessage.From = New MailAddress(TextBox1.Text)
            MyMailMessage.To.Add(TextBox2.Text)
            MyMailMessage.Subject = TextBox4.Text
            MyMailMessage.Body = txtBody.Text
            Dim SMTPServer As New SmtpClient("smtp.gmail.com")
            SMTPServer.Port = 587
            SMTPServer.Credentials = New System.Net.NetworkCredential(TextBox1.Text, TextBox3.Text)
            SMTPServer.EnableSsl = True
            SMTPServer.Send(MyMailMessage)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        My.Settings.homePage = ("http://www.google.co.in")
        txtHomePage.Text = ("http://www.google.co.in")
        MsgBox("Done")
    End Sub
End Class