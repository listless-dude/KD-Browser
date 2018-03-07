<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Options
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtHomePage = New System.Windows.Forms.TextBox()
        Me.cmbStartUp = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbRememberHis = New System.Windows.Forms.RadioButton()
        Me.rbNeverRememberHis = New System.Windows.Forms.RadioButton()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.txtNetwork = New System.Windows.Forms.TextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(484, 361)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(476, 335)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.txtHomePage)
        Me.GroupBox1.Controls.Add(Me.cmbStartUp)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(-5, -23)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(485, 362)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Homepage"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(40, 308)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(400, 17)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "More Options Will Be Available Shortly, Maybe In Next Update"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(124, 336)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(231, 17)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Copyright 2017. All Rights Reserved"
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.Button2.Location = New System.Drawing.Point(404, 129)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(60, 30)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Save"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.Button1.Location = New System.Drawing.Point(16, 129)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(170, 30)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Default Homepage"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtHomePage
        '
        Me.txtHomePage.Location = New System.Drawing.Point(137, 77)
        Me.txtHomePage.Name = "txtHomePage"
        Me.txtHomePage.Size = New System.Drawing.Size(327, 20)
        Me.txtHomePage.TabIndex = 3
        '
        'cmbStartUp
        '
        Me.cmbStartUp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStartUp.FormattingEnabled = True
        Me.cmbStartUp.Items.AddRange(New Object() {"Open Homepage", "Open a Blank Page"})
        Me.cmbStartUp.Location = New System.Drawing.Point(137, 34)
        Me.cmbStartUp.Name = "cmbStartUp"
        Me.cmbStartUp.Size = New System.Drawing.Size(327, 21)
        Me.cmbStartUp.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Homepage:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "When browser starts:"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(476, 335)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Privacy"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(40, 216)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(400, 17)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "More Options Will Be Available Shortly, Maybe In Next Update"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbRememberHis)
        Me.GroupBox2.Controls.Add(Me.rbNeverRememberHis)
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(9, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(459, 131)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "History"
        '
        'rbRememberHis
        '
        Me.rbRememberHis.AutoSize = True
        Me.rbRememberHis.Checked = True
        Me.rbRememberHis.Location = New System.Drawing.Point(20, 36)
        Me.rbRememberHis.Name = "rbRememberHis"
        Me.rbRememberHis.Size = New System.Drawing.Size(142, 21)
        Me.rbRememberHis.TabIndex = 0
        Me.rbRememberHis.TabStop = True
        Me.rbRememberHis.Text = "Remember History"
        Me.rbRememberHis.UseVisualStyleBackColor = True
        '
        'rbNeverRememberHis
        '
        Me.rbNeverRememberHis.AutoSize = True
        Me.rbNeverRememberHis.Location = New System.Drawing.Point(20, 76)
        Me.rbNeverRememberHis.Name = "rbNeverRememberHis"
        Me.rbNeverRememberHis.Size = New System.Drawing.Size(187, 21)
        Me.rbNeverRememberHis.TabIndex = 1
        Me.rbNeverRememberHis.Text = "Donot Remember History"
        Me.rbNeverRememberHis.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.txtNetwork)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(476, 335)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Network Info"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'txtNetwork
        '
        Me.txtNetwork.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNetwork.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNetwork.Location = New System.Drawing.Point(0, 0)
        Me.txtNetwork.Multiline = True
        Me.txtNetwork.Name = "txtNetwork"
        Me.txtNetwork.ReadOnly = True
        Me.txtNetwork.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtNetwork.Size = New System.Drawing.Size(476, 335)
        Me.txtNetwork.TabIndex = 0
        '
        'Options
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 361)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Options"
        Me.Text = "Options"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtHomePage As System.Windows.Forms.TextBox
    Friend WithEvents cmbStartUp As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents rbRememberHis As System.Windows.Forms.RadioButton
    Friend WithEvents rbNeverRememberHis As System.Windows.Forms.RadioButton
    Friend WithEvents txtNetwork As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
