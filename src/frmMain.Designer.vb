<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.stsStripMain = New System.Windows.Forms.StatusStrip()
        Me.stsStripLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DateiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SignOffToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ChangePasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AppsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AppUserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MemberToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExpeditionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.CashFlowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.InfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.stsStripMain.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'stsStripMain
        '
        Me.stsStripMain.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.stsStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.stsStripLabel})
        Me.stsStripMain.Location = New System.Drawing.Point(0, 270)
        Me.stsStripMain.Name = "stsStripMain"
        Me.stsStripMain.Padding = New System.Windows.Forms.Padding(1, 0, 9, 0)
        Me.stsStripMain.Size = New System.Drawing.Size(533, 22)
        Me.stsStripMain.TabIndex = 1
        Me.stsStripMain.Text = "StatusStrip1"
        '
        'stsStripLabel
        '
        Me.stsStripLabel.Name = "stsStripLabel"
        Me.stsStripLabel.Size = New System.Drawing.Size(0, 17)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DateiToolStripMenuItem, Me.AppsToolStripMenuItem, Me.ToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 1, 0, 1)
        Me.MenuStrip1.Size = New System.Drawing.Size(533, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DateiToolStripMenuItem
        '
        Me.DateiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SignOffToolStripMenuItem, Me.ToolStripSeparator3, Me.ChangePasswordToolStripMenuItem})
        Me.DateiToolStripMenuItem.Name = "DateiToolStripMenuItem"
        Me.DateiToolStripMenuItem.Size = New System.Drawing.Size(46, 22)
        Me.DateiToolStripMenuItem.Text = "&Datei"
        '
        'SignOffToolStripMenuItem
        '
        Me.SignOffToolStripMenuItem.Name = "SignOffToolStripMenuItem"
        Me.SignOffToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F3), System.Windows.Forms.Keys)
        Me.SignOffToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.SignOffToolStripMenuItem.Text = "&Abmelden"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(174, 6)
        '
        'ChangePasswordToolStripMenuItem
        '
        Me.ChangePasswordToolStripMenuItem.Name = "ChangePasswordToolStripMenuItem"
        Me.ChangePasswordToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.ChangePasswordToolStripMenuItem.Text = "&Passwort ändern"
        '
        'AppsToolStripMenuItem
        '
        Me.AppsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AppUserToolStripMenuItem, Me.ToolStripSeparator1, Me.MemberToolStripMenuItem, Me.ExpeditionsToolStripMenuItem, Me.ToolStripSeparator2, Me.CashFlowToolStripMenuItem})
        Me.AppsToolStripMenuItem.Name = "AppsToolStripMenuItem"
        Me.AppsToolStripMenuItem.Size = New System.Drawing.Size(46, 22)
        Me.AppsToolStripMenuItem.Text = "&Apps"
        '
        'AppUserToolStripMenuItem
        '
        Me.AppUserToolStripMenuItem.Name = "AppUserToolStripMenuItem"
        Me.AppUserToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.AppUserToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.AppUserToolStripMenuItem.Text = "&App-Benutzer"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(196, 6)
        '
        'MemberToolStripMenuItem
        '
        Me.MemberToolStripMenuItem.Name = "MemberToolStripMenuItem"
        Me.MemberToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F5), System.Windows.Forms.Keys)
        Me.MemberToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.MemberToolStripMenuItem.Text = "&Mitglieder"
        '
        'ExpeditionsToolStripMenuItem
        '
        Me.ExpeditionsToolStripMenuItem.Name = "ExpeditionsToolStripMenuItem"
        Me.ExpeditionsToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F6), System.Windows.Forms.Keys)
        Me.ExpeditionsToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.ExpeditionsToolStripMenuItem.Text = "A&usrückungen"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(196, 6)
        '
        'CashFlowToolStripMenuItem
        '
        Me.CashFlowToolStripMenuItem.Name = "CashFlowToolStripMenuItem"
        Me.CashFlowToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F7), System.Windows.Forms.Keys)
        Me.CashFlowToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.CashFlowToolStripMenuItem.Text = "&Kassa"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InfoToolStripMenuItem, Me.SupportToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(24, 22)
        Me.ToolStripMenuItem1.Text = "&?"
        '
        'InfoToolStripMenuItem
        '
        Me.InfoToolStripMenuItem.Name = "InfoToolStripMenuItem"
        Me.InfoToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.InfoToolStripMenuItem.Text = "&Info"
        '
        'SupportToolStripMenuItem
        '
        Me.SupportToolStripMenuItem.Name = "SupportToolStripMenuItem"
        Me.SupportToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.SupportToolStripMenuItem.Text = "&Support"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(533, 292)
        Me.Controls.Add(Me.stsStripMain)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMain"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.stsStripMain.ResumeLayout(False)
        Me.stsStripMain.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents stsStripMain As StatusStrip
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents DateiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SignOffToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AppsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AppUserToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MemberToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExpeditionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CashFlowToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents stsStripLabel As ToolStripStatusLabel
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents InfoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SupportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ChangePasswordToolStripMenuItem As ToolStripMenuItem
End Class
