Imports System.Net
Imports System.IO

Public Class webbrowserfunctions

    Inherits WebBrowser


    Private Sub webBrowserDocCompl() Handles Me.DocumentCompleted
        Dim tabPage As TabPage = Me.Tag


        If Me.DocumentTitle.Length > 25 Then
            tabPage.Text = Me.DocumentTitle.Substring(0, 25)
        Else
            tabPage.Text = Me.DocumentTitle

        End If
        Form1.txtUrl.Text = Me.Url.ToString

        If Not History.lstHistory.Items.Contains(Form1.txtUrl.Text) And Options.getHistory = 0 Then
            History.lstHistory.Items.Add(Form1.txtUrl.Text)
        End If

        If Me.DocumentTitle.ToLower = "navigation canceled" Then
            Me.Navigate("D:\KDBrowser\default.html")
        End If


    End Sub

    Public Sub New()
        Me.ScriptErrorsSuppressed = True
    End Sub

    Private Sub webbrowserfunctions_Navigated(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserNavigatedEventArgs) Handles Me.Navigated
        webicons()

        Form1.PictureBox1.Visible = False

    End Sub

    Private Sub webbrowserfunctions_Navigating(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserNavigatingEventArgs) Handles Me.Navigating
        Form1.PictureBox1.Visible = True
        Form1.txtUrl.Text = "about:blank (page is loading please wait)"

    End Sub

    Private Sub webbrowserfunctions_ProgressChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserProgressChangedEventArgs) Handles Me.ProgressChanged
        Try
            If e.CurrentProgress > -1 Then
                Form1.ProgressBar1.Maximum = e.MaximumProgress
                Form1.ProgressBar1.Value = e.CurrentProgress
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub webicons()
        Try
            Dim wc As New WebClient
            Dim memorystream As New MemoryStream(wc.DownloadData("http://" & New Uri(Me.Url.ToString).Host & "/favicon.ico"))
            Dim icon As New Icon(memorystream)

            If Form1.ImageList1.Images.Count = -1 Then
                Form1.ImageList1.Images.Add(icon.ToBitmap)
                Form1.TabControl1.SelectedTab.ImageIndex = 0
            Else
                Form1.ImageList1.Images.Clear()
                Form1.ImageList1.Images.Add(icon.ToBitmap)
                Form1.TabControl1.SelectedTab.ImageIndex = 0
            End If
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub webbrowserfunctions_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Validated
        Form1.PictureBox1.Visible = False
    End Sub

    Private Sub webbrowserfunctions_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Validating
        Form1.PictureBox1.Visible = True
    End Sub
End Class
