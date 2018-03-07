Imports System.IO


Public Class History


    Private Sub History_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Me.Visible = False

        File.Delete("D:\KDBrowser\history.txt")

        For Each link As String In lstHistory.Items
            File.AppendAllText("D:\KDBrowser\history.txt", link & vbNewLine)
        Next

    End Sub

    Private Sub btnDeleteAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteAll.Click
        lstHistory.Items.Clear()
        File.Delete("D:\KDBrowser\history.txt")
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        File.Delete("D:\KDBrowser\history.txt")

        For Each link As String In lstHistory.Items
            File.AppendAllText("D:\KDBrowser\history.txt", link & vbNewLine)
        Next
        Me.Visible = False
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        lstHistory.Items.Remove(lstHistory.SelectedItem)
    End Sub

    Private Sub lstHistory_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstHistory.MouseDoubleClick
        Form1.addTabFromHistory(Form1.TabControl1, lstHistory.SelectedItem.ToString)
    End Sub
End Class