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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.stsStripMain = New System.Windows.Forms.StatusStrip()
        Me.stsStripLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.mnuStrip = New System.Windows.Forms.MenuStrip()
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
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.notifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.notifyMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowNotifyMenuStrip = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ChangePasswordNotifyMenuStrip = New System.Windows.Forms.ToolStripMenuItem()
        Me.SignoffNotifyMenuStrip = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.AppsNotifyMenuStrip = New System.Windows.Forms.ToolStripMenuItem()
        Me.AppUserNotifyMenuStrip = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.MemberNotifyMenuStrip = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExpeditionsNotifyMenuStrip = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.CashFlowNotifyMenuStrip = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.HelpNotifyMenuStrip = New System.Windows.Forms.ToolStripMenuItem()
        Me.InfoNotifyMenuStrip = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupportNotifyMenuStrip = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.DocumentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.stsStripMain.SuspendLayout()
        Me.mnuStrip.SuspendLayout()
        Me.notifyMenuStrip.SuspendLayout()
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
        'mnuStrip
        '
        Me.mnuStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.mnuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DateiToolStripMenuItem, Me.AppsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.mnuStrip.Location = New System.Drawing.Point(0, 0)
        Me.mnuStrip.Name = "mnuStrip"
        Me.mnuStrip.Padding = New System.Windows.Forms.Padding(4, 1, 0, 1)
        Me.mnuStrip.Size = New System.Drawing.Size(533, 24)
        Me.mnuStrip.TabIndex = 2
        Me.mnuStrip.Text = "MenuStrip1"
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
        Me.AppsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AppUserToolStripMenuItem, Me.ToolStripSeparator1, Me.MemberToolStripMenuItem, Me.ExpeditionsToolStripMenuItem, Me.ToolStripSeparator2, Me.CashFlowToolStripMenuItem, Me.ToolStripSeparator9, Me.DocumentToolStripMenuItem})
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
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InfoToolStripMenuItem, Me.SupportToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(24, 22)
        Me.HelpToolStripMenuItem.Text = "&?"
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
        'notifyIcon
        '
        Me.notifyIcon.ContextMenuStrip = Me.notifyMenuStrip
        Me.notifyIcon.Icon = CType(resources.GetObject("notifyIcon.Icon"), System.Drawing.Icon)
        Me.notifyIcon.Text = "NotifyIcon1"
        Me.notifyIcon.Visible = True
        '
        'notifyMenuStrip
        '
        Me.notifyMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowNotifyMenuStrip, Me.ToolStripSeparator8, Me.ChangePasswordNotifyMenuStrip, Me.SignoffNotifyMenuStrip, Me.ToolStripSeparator4, Me.AppsNotifyMenuStrip, Me.ToolStripSeparator7, Me.HelpNotifyMenuStrip})
        Me.notifyMenuStrip.Name = "ContextMenuStrip"
        Me.notifyMenuStrip.Size = New System.Drawing.Size(162, 132)
        '
        'ShowNotifyMenuStrip
        '
        Me.ShowNotifyMenuStrip.Name = "ShowNotifyMenuStrip"
        Me.ShowNotifyMenuStrip.Size = New System.Drawing.Size(161, 22)
        Me.ShowNotifyMenuStrip.Text = "A&nzeigen"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(158, 6)
        '
        'ChangePasswordNotifyMenuStrip
        '
        Me.ChangePasswordNotifyMenuStrip.Name = "ChangePasswordNotifyMenuStrip"
        Me.ChangePasswordNotifyMenuStrip.Size = New System.Drawing.Size(161, 22)
        Me.ChangePasswordNotifyMenuStrip.Text = "&Passwort ändern"
        '
        'SignoffNotifyMenuStrip
        '
        Me.SignoffNotifyMenuStrip.Name = "SignoffNotifyMenuStrip"
        Me.SignoffNotifyMenuStrip.Size = New System.Drawing.Size(161, 22)
        Me.SignoffNotifyMenuStrip.Text = "&Abmelden"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(158, 6)
        '
        'AppsNotifyMenuStrip
        '
        Me.AppsNotifyMenuStrip.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AppUserNotifyMenuStrip, Me.ToolStripSeparator5, Me.MemberNotifyMenuStrip, Me.ExpeditionsNotifyMenuStrip, Me.ToolStripSeparator6, Me.CashFlowNotifyMenuStrip})
        Me.AppsNotifyMenuStrip.Name = "AppsNotifyMenuStrip"
        Me.AppsNotifyMenuStrip.Size = New System.Drawing.Size(161, 22)
        Me.AppsNotifyMenuStrip.Text = "Apps"
        '
        'AppUserNotifyMenuStrip
        '
        Me.AppUserNotifyMenuStrip.Name = "AppUserNotifyMenuStrip"
        Me.AppUserNotifyMenuStrip.Size = New System.Drawing.Size(151, 22)
        Me.AppUserNotifyMenuStrip.Text = "&App-Benutzer"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(148, 6)
        '
        'MemberNotifyMenuStrip
        '
        Me.MemberNotifyMenuStrip.Name = "MemberNotifyMenuStrip"
        Me.MemberNotifyMenuStrip.Size = New System.Drawing.Size(151, 22)
        Me.MemberNotifyMenuStrip.Text = "&Mitglieder"
        '
        'ExpeditionsNotifyMenuStrip
        '
        Me.ExpeditionsNotifyMenuStrip.Name = "ExpeditionsNotifyMenuStrip"
        Me.ExpeditionsNotifyMenuStrip.Size = New System.Drawing.Size(151, 22)
        Me.ExpeditionsNotifyMenuStrip.Text = "A&usrückungen"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(148, 6)
        '
        'CashFlowNotifyMenuStrip
        '
        Me.CashFlowNotifyMenuStrip.Name = "CashFlowNotifyMenuStrip"
        Me.CashFlowNotifyMenuStrip.Size = New System.Drawing.Size(151, 22)
        Me.CashFlowNotifyMenuStrip.Text = "&Kassa"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(158, 6)
        '
        'HelpNotifyMenuStrip
        '
        Me.HelpNotifyMenuStrip.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InfoNotifyMenuStrip, Me.SupportNotifyMenuStrip})
        Me.HelpNotifyMenuStrip.Name = "HelpNotifyMenuStrip"
        Me.HelpNotifyMenuStrip.Size = New System.Drawing.Size(161, 22)
        Me.HelpNotifyMenuStrip.Text = "&?"
        '
        'InfoNotifyMenuStrip
        '
        Me.InfoNotifyMenuStrip.Name = "InfoNotifyMenuStrip"
        Me.InfoNotifyMenuStrip.Size = New System.Drawing.Size(116, 22)
        Me.InfoNotifyMenuStrip.Text = "&Info"
        '
        'SupportNotifyMenuStrip
        '
        Me.SupportNotifyMenuStrip.Name = "SupportNotifyMenuStrip"
        Me.SupportNotifyMenuStrip.Size = New System.Drawing.Size(116, 22)
        Me.SupportNotifyMenuStrip.Text = "&Support"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(196, 6)
        '
        'DocumentToolStripMenuItem
        '
        Me.DocumentToolStripMenuItem.Name = "DocumentToolStripMenuItem"
        Me.DocumentToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F8), System.Windows.Forms.Keys)
        Me.DocumentToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.DocumentToolStripMenuItem.Text = "&Dokumente"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(533, 292)
        Me.Controls.Add(Me.stsStripMain)
        Me.Controls.Add(Me.mnuStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.mnuStrip
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMain"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.stsStripMain.ResumeLayout(False)
        Me.stsStripMain.PerformLayout()
        Me.mnuStrip.ResumeLayout(False)
        Me.mnuStrip.PerformLayout()
        Me.notifyMenuStrip.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents stsStripMain As StatusStrip
    Friend WithEvents mnuStrip As MenuStrip
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
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InfoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SupportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ChangePasswordToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents notifyIcon As NotifyIcon
    Friend WithEvents notifyMenuStrip As ContextMenuStrip
    Friend WithEvents ShowNotifyMenuStrip As ToolStripMenuItem
    Friend WithEvents SignoffNotifyMenuStrip As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents AppsNotifyMenuStrip As ToolStripMenuItem
    Friend WithEvents AppUserNotifyMenuStrip As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents MemberNotifyMenuStrip As ToolStripMenuItem
    Friend WithEvents ExpeditionsNotifyMenuStrip As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents CashFlowNotifyMenuStrip As ToolStripMenuItem
    Friend WithEvents ChangePasswordNotifyMenuStrip As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents HelpNotifyMenuStrip As ToolStripMenuItem
    Friend WithEvents InfoNotifyMenuStrip As ToolStripMenuItem
    Friend WithEvents SupportNotifyMenuStrip As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents DocumentToolStripMenuItem As ToolStripMenuItem
End Class
