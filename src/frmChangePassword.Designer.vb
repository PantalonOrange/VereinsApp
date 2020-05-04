<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChangePassword
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtBoxOldPassword = New System.Windows.Forms.TextBox()
        Me.lblOldPassword = New System.Windows.Forms.Label()
        Me.txtBoxNewPassword = New System.Windows.Forms.TextBox()
        Me.lblNewPassword = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtBoxOldPassword
        '
        Me.txtBoxOldPassword.Location = New System.Drawing.Point(109, 5)
        Me.txtBoxOldPassword.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBoxOldPassword.MaxLength = 128
        Me.txtBoxOldPassword.Name = "txtBoxOldPassword"
        Me.txtBoxOldPassword.Size = New System.Drawing.Size(293, 20)
        Me.txtBoxOldPassword.TabIndex = 1
        Me.txtBoxOldPassword.UseSystemPasswordChar = True
        '
        'lblOldPassword
        '
        Me.lblOldPassword.AutoSize = True
        Me.lblOldPassword.Location = New System.Drawing.Point(11, 9)
        Me.lblOldPassword.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblOldPassword.Name = "lblOldPassword"
        Me.lblOldPassword.Size = New System.Drawing.Size(39, 13)
        Me.lblOldPassword.TabIndex = 2
        Me.lblOldPassword.Text = "Label1"
        '
        'txtBoxNewPassword
        '
        Me.txtBoxNewPassword.Location = New System.Drawing.Point(109, 26)
        Me.txtBoxNewPassword.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBoxNewPassword.MaxLength = 128
        Me.txtBoxNewPassword.Name = "txtBoxNewPassword"
        Me.txtBoxNewPassword.Size = New System.Drawing.Size(293, 20)
        Me.txtBoxNewPassword.TabIndex = 2
        Me.txtBoxNewPassword.UseSystemPasswordChar = True
        '
        'lblNewPassword
        '
        Me.lblNewPassword.AutoSize = True
        Me.lblNewPassword.Location = New System.Drawing.Point(11, 30)
        Me.lblNewPassword.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblNewPassword.Name = "lblNewPassword"
        Me.lblNewPassword.Size = New System.Drawing.Size(39, 13)
        Me.lblNewPassword.TabIndex = 6
        Me.lblNewPassword.Text = "Label1"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(271, 49)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(131, 44)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Button1"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(78, 49)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(183, 44)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Button1"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'frmChangePassword
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(412, 104)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtBoxNewPassword)
        Me.Controls.Add(Me.lblNewPassword)
        Me.Controls.Add(Me.txtBoxOldPassword)
        Me.Controls.Add(Me.lblOldPassword)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmChangePassword"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmChangePassword"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtBoxOldPassword As TextBox
    Friend WithEvents lblOldPassword As Label
    Friend WithEvents txtBoxNewPassword As TextBox
    Friend WithEvents lblNewPassword As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
End Class
