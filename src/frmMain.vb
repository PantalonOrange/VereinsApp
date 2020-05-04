'frmMain
'Main form that contains all sub forms
'Copyright (C)2019,2020 by Christian Brunner

Public Class frmMain

    Public User As String
    Dim returnAppVersion As New service_ReturnAppVersion
    Dim AppVersion As String = returnAppVersion._appVersion()
    Dim checkSecurity As New service_CheckSecurity

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "VereinsApp - GAR14 1.Batterie"
        stsStripLabel.Text = "Aktueller Benutzer angemeldet: " & User
    End Sub

    Private Sub frmMain_Close(sender As Object, e As EventArgs) Handles MyBase.Closed
        signOff()
    End Sub

    Private Sub SignoffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SignOffToolStripMenuItem.Click
        signOff()
        Me.Close()
    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        Dim changePassword As New frmChangePassword
        changePassword.MdiParent = Me
        changePassword.Show()
    End Sub

    Private Sub AppUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AppUserToolStripMenuItem.Click
        checkSecurity._checkSecurity(User, "USER")
        If checkSecurity._returnSecurityCheck Then
            Dim appUsers As New frmUsers
            appUsers.MdiParent = Me
            appUsers.Show()
        Else
            MessageBox.Show("Keine Berechtigung für Modul USER", "Berechtigung", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub MemberToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MemberToolStripMenuItem.Click
        checkSecurity._checkSecurity(User, "MEMBER")
        If checkSecurity._returnSecurityCheck Then
            Dim associationMembers As New frmMembers
            associationMembers.MdiParent = Me
            associationMembers.Show()
        Else
            MessageBox.Show("Keine Berechtigung für Modul MEMBER", "Berechtigung", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ExpeditionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExpeditionsToolStripMenuItem.Click
        checkSecurity._checkSecurity(User, "EXPEDITION")
        If checkSecurity._returnSecurityCheck Then
            Dim allExpeditions As New frmExpeditions
            allExpeditions.MdiParent = Me
            allExpeditions.Show()
        Else
            MessageBox.Show("Keine Berechtigung für Modul EXPEDITION", "Berechtigung", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub CashFlowStripMenuItem_Click(sender As Object, e As EventArgs) Handles CashFlowToolStripMenuItem.Click
        checkSecurity._checkSecurity(User, "CASH")
        If checkSecurity._returnSecurityCheck Then
            Dim allCashFlows As New frmCash
            allCashFlows.MdiParent = Me
            allCashFlows.Show()
        Else
            MessageBox.Show("Keine Berechtigung für Modul CASH", "Berechtigung", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub InfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InfoToolStripMenuItem.Click
        MessageBox.Show("VereinsApp (" & AppVersion & ")" & vbCrLf &
                        "Erstellt für Gebirgsartiellerie Regiment Kaiser Nr.14 1.Batterie" & vbCrLf & vbCrLf &
                        "Dieses Programm verwendet die MariaDB auf einer QNAP-NAS" & vbCrLf & vbCrLf &
                        "Copyright (c)2019, 2020 Christian Brunner" & vbCrLf &
                        "(Pantalon Orange OSS)" & vbCrLf &
                        "Alle Rechte vorbehalten!", "Information und Copyright",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub SupportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupportToolStripMenuItem.Click
        Dim MailAdress As String = "mailto:mail.brc@gmail.com?subject=VereinsApp"
        Try
            Process.Start(MailAdress)
        Catch ex As Exception
            MessageBox.Show("Fehler bei Aufruf Mailprogramm", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub signOff()
        frmLogin.txtBoxUserName.Text = ""
        frmLogin.txtBoxPassword.Text = ""
        frmLogin.txtBoxUserName.Select()
        frmLogin.Show()
    End Sub
End Class