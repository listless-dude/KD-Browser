Imports System.Net.Mail

Public Class Options
    Dim history As Integer = 0

    Public Sub setHistory(ByVal Int As Integer)
        history = Int
    End Sub
    Public Function getHistory()
        Return history
    End Function
    
    Private Sub Options_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtHomePage.Text = My.Settings.homePage

        If My.Settings.HomePageOrBlankPAge = 0 Then
            cmbStartUp.SelectedIndex = 0
        ElseIf My.Settings.HomePageOrBlankPAge = 1 Then
            cmbStartUp.SelectedIndex = 1
        End If
        My.Settings.HomePageOrBlankPAge = cmbStartUp.SelectedIndex.ToString
        My.Settings.Save()
        My.Settings.Reload()

        If rbRememberHis.Checked = True Then
            setHistory(0)
        End If
        If rbNeverRememberHis.Checked = True Then
            setHistory(1)
        End If
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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        My.Settings.homePage = txtHomePage.Text
        My.Settings.Save()
        My.Settings.Reload()


        My.Settings.HomePageOrBlankPAge = cmbStartUp.SelectedIndex.ToString
        My.Settings.Save()
        My.Settings.Reload()

        MsgBox("Changes Saved! You must restart your browser to complete action.")
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        My.Settings.homePage = (txtHomePage.Text)
        txtHomePage.Text = ("")
        MsgBox("Done")
    End Sub
End Class