
Imports System.Net
Imports System.IO
Imports System

Public Class Downloader
    Private WithEvents download As New WebClient
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim saveFileDialog1 As New SaveFileDialog

        saveFileDialog1.InitialDirectory = "C:\Users\Swarup\Downloads"
        saveFileDialog1.Title = "Save Download File To"
        saveFileDialog1.CheckPathExists = True
        saveFileDialog1.Filter = "Text Files(*.txt)|*.txt*|All files (*.*)|*.*"
        saveFileDialog1.FilterIndex = 2
        saveFileDialog1.RestoreDirectory = True

        If (saveFileDialog1.ShowDialog() = DialogResult.OK) Then
            TextBox2.Text = saveFileDialog1.FileName
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        download = New WebClient
        Dim down As String = TextBox1.Text
        Dim save As String = TextBox2.Text
        download.DownloadFileAsync(New Uri(down), save)
        Label3.Text = "Current Status: Downloading..."
    End Sub

    Private Sub download_DownloadProgressChanged(ByVal sender As Object, ByVal e As System.Net.DownloadProgressChangedEventArgs) Handles download.DownloadProgressChanged

        ProgressBar1.Maximum = e.TotalBytesToReceive
        ProgressBar1.Value = e.BytesReceived
        Label4.Text = "Download Status: " & e.ProgressPercentage & "%"

        If e.ProgressPercentage = 100 Then
            Label3.Text = "Current Status: Finished"

        End If
    End Sub

    Private Sub Downloader_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ProgressBar1.Style = ProgressBarStyle.Blocks
        Label3.Text = "Current Status: Idle"

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        download.CancelAsync()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        download.CancelAsync()
        Me.Close()

    End Sub
    Private Sub SaveFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

    End Sub
End Class