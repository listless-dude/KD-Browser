Imports System.Net
Imports System.IO
Imports Microsoft.Win32



Public Class Form1
    Dim InitialZoom As Integer = 100
    Public Enum Exec
        OLECMDID_OPTICAL_ZOOM = 63
    End Enum
    Private Enum execOpt
        OLECMDEXECOPT_DODEFAULT = 0
        OLECMDEXECOPT_PROMPTUSER = 1
        OLECMDEXECOPT_DONTPROMPTUSER = 2
        OLECMDEXECOPT_SHOWHELP = 3
    End Enum
    Public Sub PerformZoom(ByVal Value As Integer)
        Try
            Dim browser As webbrowserfunctions = Me.TabControl1.SelectedTab.Tag
            Dim Res As Object = Nothing
            Dim MyWeb As Object
            MyWeb = browser.ActiveXInstance
            MyWeb.ExecWB(Exec.OLECMDID_OPTICAL_ZOOM, execOpt.OLECMDEXECOPT_PROMPTUSER, CObj(Value), CObj(IntPtr.Zero))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnForward.Click
        Dim browser As webbrowserfunctions = Me.TabControl1.SelectedTab.Tag
        browser.GoForward()

    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        File.Delete("D:\KDBrowser\history.txt")
        For Each link As String In History.lstHistory.Items
            File.AppendAllText("D:\KDBrowser\history.txt", link & vbNewLine)
        Next


        For Each favouriteName As String In lstName.Items
            File.AppendAllText("D:\KDBrowser\favouriteName.txt", favouriteName & vbNewLine)

        Next
        For Each favouriteURL As String In lstUrl.Items
            File.AppendAllText("D:\KDBrowser\favouriteURL.txt", favouriteURL & vbNewLine)

        Next
    End Sub



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PictureBox1.Visible = False



        cmbSearchEngines.Items.Add("Google")
        cmbSearchEngines.Items.Add("YouTube")
        cmbSearchEngines.Items.Add("Wikipedia")

        cmbSearchEngines.SelectedIndex = 0

        addTab(TabControl1)

        If My.Settings.HomePageOrBlankPAge = 0 Then
            Dim browser As webbrowserfunctions = Me.TabControl1.SelectedTab.Tag
            browser.Navigate("https://www.google.co.in")

        ElseIf My.Settings.HomePageOrBlankPAge = 1 Then
            Dim browser As webbrowserfunctions = Me.TabControl1.SelectedTab.Tag
            browser.Navigate("about:blank")
        End If




        Try
            History.Show()
            History.Visible = False
            For Each link As String In File.ReadAllLines("D:\KDBrowser\history.txt")
                History.lstHistory.Items.Add(link.ToString)
            Next



        Catch ex As Exception

        End Try

        Try
            For Each url As String In File.ReadAllLines("D:\KDBrowser\favouriteURL.txt")
                ListBox3.Items.Add(url)
            Next
        Catch ex As Exception

        End Try

        Try
            ListBox3.SelectedIndex = 0
        Catch ex As Exception

        End Try

        Try
            For Each Name As String In File.ReadAllLines("D:\KDBrowser\favouriteName.txt")
                Dim newBookmark As New ToolStripButton
                newBookmark.Text = Name

                newBookmark.Tag = ListBox3.SelectedItem.ToString
                ToolStrip2.Items.Add(newBookmark)
                ListBox3.SelectedIndex = ListBox3.SelectedIndex + 1

            Next
        Catch ex As Exception

        End Try

        createdBookClic()


    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Dim browser As webbrowserfunctions = Me.TabControl1.SelectedTab.Tag
        browser.GoBack()

    End Sub

    Private Sub btnReload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReload.Click
        Dim browser As webbrowserfunctions = Me.TabControl1.SelectedTab.Tag
        browser.Refresh()

    End Sub

    Private Sub btnDownloads_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub txtUrl_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUrl.KeyUp
        Dim browser As webbrowserfunctions = Me.TabControl1.SelectedTab.Tag
        If e.KeyCode = Keys.Enter Then
            browser.Navigate(txtUrl.Text)
        End If
    End Sub

    Private Sub txtUrlSearchEngines_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUrlSearchEngines.KeyUp

        Dim browser As webbrowserfunctions = Me.TabControl1.SelectedTab.Tag

        Select Case (cmbSearchEngines.SelectedIndex)
            Case 0
                If e.KeyCode = Keys.Enter Then
                    browser.Navigate("https://www.google.co.in/search?q=" + txtUrlSearchEngines.Text)
                End If
            Case 1
                If e.KeyCode = Keys.Enter Then
                    browser.Navigate("https://www.youtube.com/results?search_query=" + txtUrlSearchEngines.Text)
                End If
            Case 2
                If e.KeyCode = Keys.Enter Then
                    browser.Navigate("https://en.wikipedia.org/wiki/" + txtUrlSearchEngines.Text)
                End If
        End Select
    End Sub

    Private Sub btnHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHome.Click
        Dim browser As webbrowserfunctions = Me.TabControl1.SelectedTab.Tag
        browser.Navigate(My.Settings.homePage)
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsToolStripMenuItem.Click
        Options.Show()

    End Sub

    Private Sub DownloadsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DownloadsToolStripMenuItem.Click
        History.Visible = True

    End Sub
    Private Sub txtUrl_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUrl.TextChanged
        txtUrl.AutoCompleteCustomSource.Clear()
        For i As Integer = 0 To History.lstHistory.Items.Count - 1
            txtUrl.AutoCompleteCustomSource.Add(History.lstHistory.Items(i))
        Next

    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        addTab(TabControl1)
    End Sub

    Private Sub CloseTabToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseTabToolStripMenuItem.Click
        removeTab()
        If TabControl1.TabCount = 0 Then
            Me.Close()
        End If
    End Sub

    Public Sub addTab(ByRef tabControl As TabControl)
        Dim browser As New webbrowserfunctions
        Dim tab As New TabPage
        browser.Tag = tab
        tab.Tag = browser
        TabControl1.TabPages.Add(tab)
        tab.Controls.Add(browser)
        browser.Dock = DockStyle.Fill
        browser.Navigate("www.google.co.in")

        TabControl1.SelectedTab = tab
    End Sub

    Public Sub addTabFromHistory(ByRef tabControl As TabControl, ByRef link As String)
        Dim browser As New webbrowserfunctions
        Dim tab As New TabPage
        browser.Tag = tab
        tab.Tag = browser
        TabControl1.TabPages.Add(tab)
        tab.Controls.Add(browser)
        browser.Dock = DockStyle.Fill
        browser.Navigate(link)

        TabControl1.SelectedTab = tab
    End Sub

    Public Sub removeTab()
        If TabControl1.TabPages.Count <> 0 Then
            TabControl1.SelectedTab.Dispose()
        Else : Close()

        End If
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Try
            Dim browser As webbrowserfunctions = TabControl1.SelectedTab.Tag
            txtUrl.Text = browser.Url.ToString

        Catch ex As Exception

        End Try
    End Sub

    Private Sub NewTabToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewTabToolStripMenuItem.Click
        addTab(TabControl1)
    End Sub

    Private Sub NewWindowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewWindowToolStripMenuItem.Click
        Dim newWindow As New Form1
        newWindow.Show()
    End Sub

    Private Sub UndoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoToolStripMenuItem.Click
        txtUrl.Undo()

    End Sub

    Private Sub RedoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RedoToolStripMenuItem.Click
        txtUrl.ClearUndo()

    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripMenuItem.Click
        txtUrl.Cut()

    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        txtUrl.Copy()

    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        txtUrl.Paste()

    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        txtUrl.SelectAll()
    End Sub

    Private Sub SaveHTMLCodeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveHTMLCodeToolStripMenuItem.Click
        Dim browser As webbrowserfunctions = TabControl1.SelectedTab.Tag

        Dim filename As String = InputBox("Enter Filename", "Save HTML", ".txt")
        Dim path As String = "C:\Users\Swarup\Downloads\" & filename

        Try
            If File.Exists(path) Then
                Dim allText As String
                allText = browser.DocumentText
                File.WriteAllText(path, allText)
            Else
                File.Create(path).Dispose()
                Dim allText As String
                allText = browser.DocumentText
                File.WriteAllText(path, allText)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim browser As webbrowserfunctions = TabControl1.SelectedTab.Tag
        browser.Navigate("C:\Users\Swarup\Documents\Visual Studio 2010\Projects\KD Browser\KD Browser\default.html")
    

    End Sub

    Private Sub addBookmarks()
        Dim browser As webbrowserfunctions = TabControl1.SelectedTab.Tag

        Dim newBookmark As New ToolStripButton
        newBookmark.Text = TabControl1.SelectedTab.Text
        newBookmark.Tag = browser.Url
        ToolStrip2.Items.Add(newBookmark)
        lstName.Items.Add(TabControl1.SelectedTab.Text)
        lstUrl.Items.Add(browser.Url.ToString)

        AddHandler newBookmark.Click, AddressOf newBookmarkClick

    End Sub
    Private Sub newBookmarkClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim browser As webbrowserfunctions = TabControl1.SelectedTab.Tag

        If TypeOf sender Is ToolStripButton Then
            browser.Navigate(CType(sender, ToolStripButton).Tag)

        End If
    End Sub

    Private Sub createdBookClic()
        For Each item As ToolStripButton In ToolStrip2.Items
            AddHandler item.Click, AddressOf bookclick
        Next
    End Sub

    Private Sub bookclick(ByVal sender As Object, ByVal e As EventArgs)
        txtUrl.Text = CType(sender, ToolStripButton).Tag

        bookNav()

    End Sub

    Private Sub bookNav()
        Dim browser As webbrowserfunctions = TabControl1.SelectedTab.Tag
        browser.Navigate(txtUrl.Text)

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End

    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        Dim browser As webbrowserfunctions = TabControl1.SelectedTab.Tag
        browser.ShowPrintDialog()
    End Sub

    Private Sub PrintPreviewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPreviewToolStripMenuItem.Click
        Dim browser As webbrowserfunctions = TabControl1.SelectedTab.Tag
        browser.ShowPrintPreviewDialog()
    End Sub

    Private Sub PagePropertiesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PagePropertiesToolStripMenuItem.Click
        Dim browser As webbrowserfunctions = TabControl1.SelectedTab.Tag
        browser.ShowPropertiesDialog()
    End Sub

    Private Sub SavePageAsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SavePageAsToolStripMenuItem.Click
        Dim browser As webbrowserfunctions = TabControl1.SelectedTab.Tag
        browser.ShowSaveAsDialog()

    End Sub

    Private Sub PageSetupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageSetupToolStripMenuItem.Click
        Dim browser As webbrowserfunctions = TabControl1.SelectedTab.Tag
        browser.ShowPageSetupDialog()
    End Sub

    Private Sub HTMLEditorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HTMLEditorToolStripMenuItem.Click
        HTMLEditor.Show()

    End Sub

    Private Sub BookmarkThisPageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BookmarkThisPageToolStripMenuItem.Click
        addBookmarks()
        MsgBox("Bookmark Added! Your Bookmark Added To The Bottom Of The Page!")
    End Sub

    Private Sub RemoveBookmarksToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveBookmarksToolStripMenuItem.Click
        ToolStrip2.Items.Clear()
        File.Delete("D:\KDBrowser\favouriteURL.txt")
        File.Delete("D:\KDBrowser\favouriteName.txt")
        MsgBox("Bookmarks Cleared!")
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        InitialZoom += 10
        PerformZoom(InitialZoom)
    End Sub

    Private Sub ToolStripButton2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        InitialZoom -= 10
        PerformZoom(InitialZoom)
    End Sub

    Private Sub FullScreenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.Location = New Point(0, 0)
        Me.Size = SystemInformation.PrimaryMonitorSize
        'Me.WindowState = 2
        'Me.TopMost = True
    End Sub

    Private Sub ExitFullScreenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DownloadManagerToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DownloadManagerToolStripMenuItem.Click
        Downloader.Visible = True

    End Sub
    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        Dim browser As webbrowserfunctions = TabControl1.SelectedTab.Tag
        Using ofd As New OpenFileDialog
            ofd.Filter = "HTML Files|*.htm;*.html"

            If ofd.ShowDialog() = Windows.Forms.DialogResult.OK Then

                browser.Navigate(ofd.FileName)
            End If
        End Using
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        removeTab()
        If TabControl1.TabCount = 0 Then
            Me.Close()
        End If
    End Sub
End Class
