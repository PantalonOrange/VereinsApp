'frmMain
'Main form that contains all sub forms
'Copyright (C)2019,2020 by Christian Brunner

Public Class frmMain

    Public User As String
    Public RunningModules As New service_RunningModules
    Dim returnAppVersion As New service_ReturnAppVersion
    Dim AppVersion As String = returnAppVersion._appVersion()
    Dim checkSecurity As New service_CheckSecurity

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "VereinsApp - GAR14 1.Batterie"
        stsStripLabel.Text = "Aktueller Benutzer angemeldet: " & User
        DocumentToolStripMenuItem.Enabled = False 'For the next release r2
        With notifyIcon
            .Text = Me.Text
            .BalloonTipText = Me.Text
            .BalloonTipTitle = Me.Text
        End With
    End Sub

    Private Sub frmMain_Close(sender As Object, e As EventArgs) Handles MyBase.Closed
        signOff()
    End Sub

    Private Sub frmMain_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        notifyIcon.Visible = (Me.WindowState = FormWindowState.Minimized)
    End Sub

    Private Sub SignoffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SignOffToolStripMenuItem.Click, SignoffNotifyMenuStrip.Click
        signOff()
        Me.Close()
    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangePasswordToolStripMenuItem.Click, ChangePasswordNotifyMenuStrip.Click
        If Me.WindowState = FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Maximized
        End If
        Dim changePassword As New frmChangePassword
        changePassword.MdiParent = Me
        changePassword.Show()
    End Sub

    Private Sub AppUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AppUserToolStripMenuItem.Click, AppUserNotifyMenuStrip.Click
        If Not RunningModules.User Then
            If Me.WindowState = FormWindowState.Minimized Then
                Me.WindowState = FormWindowState.Maximized
            End If
            checkSecurity._checkSecurity(User, "USER")
            If checkSecurity._returnSecurityCheck Then
                Dim appUsers As New frmUsers
                appUsers.MdiParent = Me
                RunningModules.User = True
                appUsers.Show()
            Else
                MessageBox.Show("Keine Berechtigung für Modul USER", "Berechtigung", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Modul USER läuft bereits", "Modulinformnation", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub MemberToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MemberToolStripMenuItem.Click, MemberNotifyMenuStrip.Click
        If Not RunningModules.Member Then
            If Me.WindowState = FormWindowState.Minimized Then
                Me.WindowState = FormWindowState.Maximized
            End If
            checkSecurity._checkSecurity(User, "MEMBER")
            If checkSecurity._returnSecurityCheck Then
                Dim associationMembers As New frmMembers
                associationMembers.MdiParent = Me
                RunningModules.Member = True
                associationMembers.Show()
            Else
                MessageBox.Show("Keine Berechtigung für Modul MEMBER", "Berechtigung", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Modul MEMBER läuft bereits", "Modulinformnation", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ExpeditionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExpeditionsToolStripMenuItem.Click, ExpeditionsNotifyMenuStrip.Click
        If Not RunningModules.Expedition Then
            If Me.WindowState = FormWindowState.Minimized Then
                Me.WindowState = FormWindowState.Maximized
            End If
            checkSecurity._checkSecurity(User, "EXPEDITION")
            If checkSecurity._returnSecurityCheck Then
                Dim allExpeditions As New frmExpeditions
                allExpeditions.MdiParent = Me
                RunningModules.Expedition = True
                allExpeditions.Show()
            Else
                MessageBox.Show("Keine Berechtigung für Modul EXPEDITION", "Berechtigung", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Modul EXPEDITION läuft bereits", "Modulinformnation", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub CashFlowStripMenuItem_Click(sender As Object, e As EventArgs) Handles CashFlowToolStripMenuItem.Click, CashFlowNotifyMenuStrip.Click
        If Not RunningModules.CashFlow Then
            If Me.WindowState = FormWindowState.Minimized Then
                Me.WindowState = FormWindowState.Maximized
            End If
            checkSecurity._checkSecurity(User, "CASH")
            If checkSecurity._returnSecurityCheck Then
                Dim allCashFlows As New frmCash
                allCashFlows.MdiParent = Me
                RunningModules.CashFlow = True
                allCashFlows.Show()
            Else
                MessageBox.Show("Keine Berechtigung für Modul CASH", "Berechtigung", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Modul CASH läuft bereits", "Modulinformnation", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub DocumentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DocumentToolStripMenuItem.Click
        'For the next release r2
        If Not RunningModules.Documents Then
            If Me.WindowState = FormWindowState.Minimized Then
                Me.WindowState = FormWindowState.Maximized
            End If
            checkSecurity._checkSecurity(User, "DOCUMENTS")
            If checkSecurity._returnSecurityCheck Then
                Dim allDocuments As New frmDocuments
                allDocuments.MdiParent = Me
                RunningModules.Documents = True
                allDocuments.Show()
            Else
                MessageBox.Show("Keine Berechtigung für Modul DOCUMENTS", "Berechtigung", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Modul DOCUMENTS läuft bereits", "Modulinformnation", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub InfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InfoToolStripMenuItem.Click, InfoNotifyMenuStrip.Click
        If Me.WindowState = FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Maximized
        End If
        MessageBox.Show("VereinsApp (" & AppVersion & ")" & vbCrLf &
                        "Erstellt für Gebirgsartiellerie Regiment Kaiser Nr.14 1.Batterie" & vbCrLf & vbCrLf &
                        "Dieses Programm verwendet die MariaDB auf einer QNAP-NAS" & vbCrLf & vbCrLf &
                        "Copyright (c)2019, 2020 Christian Brunner" & vbCrLf &
                        "(Pantalon Orange OSS)" & vbCrLf &
                        "Alle Rechte vorbehalten!" & vbCrLf &
                        "Rangabbildungen sind Gemeinfrei und wurde von Wikipedia kopiert.",
                        "Information und Copyright",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub SupportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupportToolStripMenuItem.Click, SupportNotifyMenuStrip.Click
        If Me.WindowState = FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Maximized
        End If
        Dim MailAdress As String = "mailto:mail.brc@gmail.com?subject=VereinsApp"
        Try
            Process.Start(MailAdress)
        Catch ex As Exception
            MessageBox.Show("Fehler bei Aufruf Mailprogramm", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ShowNotifyMenuStrip_Click(sender As Object, e As EventArgs) Handles ShowNotifyMenuStrip.Click, notifyIcon.MouseDoubleClick
        If Me.WindowState = FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Maximized
        Else
            Me.Select()
        End If
    End Sub

    Private Sub signOff()
        frmLogin.txtBoxUserName.Select()
        frmLogin.Show()
    End Sub

End Class