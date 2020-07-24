<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmManageUser
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
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.txtBoxUserName = New System.Windows.Forms.TextBox()
        Me.txtBoxName = New System.Windows.Forms.TextBox()
        Me.txtBoxPassword = New System.Windows.Forms.TextBox()
        Me.chkBoxStatus = New System.Windows.Forms.CheckBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblChangeDate = New System.Windows.Forms.Label()
        Me.lblChange = New System.Windows.Forms.Label()
        Me.lblLastLoginDate = New System.Windows.Forms.Label()
        Me.lblLastLogin = New System.Windows.Forms.Label()
        Me.lblSecurity = New System.Windows.Forms.Label()
        Me.chkBoxUser = New System.Windows.Forms.CheckBox()
        Me.chkBoxMember = New System.Windows.Forms.CheckBox()
        Me.chkBoxExpedition = New System.Windows.Forms.CheckBox()
        Me.chkBoxCash = New System.Windows.Forms.CheckBox()
        Me.grpBoxSecurity = New System.Windows.Forms.GroupBox()
        Me.chkBoxDocuments = New System.Windows.Forms.CheckBox()
        Me.grpBoxSecurity.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Location = New System.Drawing.Point(8, 12)
        Me.lblUserName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(39, 13)
        Me.lblUserName.TabIndex = 0
        Me.lblUserName.Text = "Label1"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(8, 33)
        Me.lblName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(39, 13)
        Me.lblName.TabIndex = 1
        Me.lblName.Text = "Label2"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(8, 54)
        Me.lblPassword.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(39, 13)
        Me.lblPassword.TabIndex = 2
        Me.lblPassword.Text = "Label3"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(8, 75)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(39, 13)
        Me.lblStatus.TabIndex = 3
        Me.lblStatus.Text = "Label4"
        '
        'txtBoxUserName
        '
        Me.txtBoxUserName.Location = New System.Drawing.Point(106, 8)
        Me.txtBoxUserName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBoxUserName.MaxLength = 128
        Me.txtBoxUserName.Name = "txtBoxUserName"
        Me.txtBoxUserName.Size = New System.Drawing.Size(421, 20)
        Me.txtBoxUserName.TabIndex = 1
        '
        'txtBoxName
        '
        Me.txtBoxName.Location = New System.Drawing.Point(106, 29)
        Me.txtBoxName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBoxName.MaxLength = 128
        Me.txtBoxName.Name = "txtBoxName"
        Me.txtBoxName.Size = New System.Drawing.Size(421, 20)
        Me.txtBoxName.TabIndex = 2
        '
        'txtBoxPassword
        '
        Me.txtBoxPassword.Location = New System.Drawing.Point(106, 50)
        Me.txtBoxPassword.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBoxPassword.MaxLength = 128
        Me.txtBoxPassword.Name = "txtBoxPassword"
        Me.txtBoxPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtBoxPassword.Size = New System.Drawing.Size(421, 20)
        Me.txtBoxPassword.TabIndex = 3
        Me.txtBoxPassword.UseSystemPasswordChar = True
        '
        'chkBoxStatus
        '
        Me.chkBoxStatus.AutoSize = True
        Me.chkBoxStatus.Location = New System.Drawing.Point(107, 72)
        Me.chkBoxStatus.Margin = New System.Windows.Forms.Padding(2)
        Me.chkBoxStatus.Name = "chkBoxStatus"
        Me.chkBoxStatus.Size = New System.Drawing.Size(81, 17)
        Me.chkBoxStatus.TabIndex = 4
        Me.chkBoxStatus.Text = "CheckBox1"
        Me.chkBoxStatus.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(201, 160)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(183, 44)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Button1"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(394, 160)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(131, 44)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Button1"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblChangeDate
        '
        Me.lblChangeDate.AutoSize = True
        Me.lblChangeDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChangeDate.Location = New System.Drawing.Point(53, 189)
        Me.lblChangeDate.Name = "lblChangeDate"
        Me.lblChangeDate.Size = New System.Drawing.Size(27, 9)
        Me.lblChangeDate.TabIndex = 65
        Me.lblChangeDate.Text = "Label1"
        '
        'lblChange
        '
        Me.lblChange.AutoSize = True
        Me.lblChange.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChange.Location = New System.Drawing.Point(9, 189)
        Me.lblChange.Name = "lblChange"
        Me.lblChange.Size = New System.Drawing.Size(27, 9)
        Me.lblChange.TabIndex = 64
        Me.lblChange.Text = "Label1"
        '
        'lblLastLoginDate
        '
        Me.lblLastLoginDate.AutoSize = True
        Me.lblLastLoginDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastLoginDate.Location = New System.Drawing.Point(53, 171)
        Me.lblLastLoginDate.Name = "lblLastLoginDate"
        Me.lblLastLoginDate.Size = New System.Drawing.Size(27, 9)
        Me.lblLastLoginDate.TabIndex = 67
        Me.lblLastLoginDate.Text = "Label1"
        '
        'lblLastLogin
        '
        Me.lblLastLogin.AutoSize = True
        Me.lblLastLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastLogin.Location = New System.Drawing.Point(9, 171)
        Me.lblLastLogin.Name = "lblLastLogin"
        Me.lblLastLogin.Size = New System.Drawing.Size(27, 9)
        Me.lblLastLogin.TabIndex = 66
        Me.lblLastLogin.Text = "Label1"
        '
        'lblSecurity
        '
        Me.lblSecurity.AutoSize = True
        Me.lblSecurity.Location = New System.Drawing.Point(6, 19)
        Me.lblSecurity.Name = "lblSecurity"
        Me.lblSecurity.Size = New System.Drawing.Size(39, 13)
        Me.lblSecurity.TabIndex = 68
        Me.lblSecurity.Text = "Label5"
        '
        'chkBoxUser
        '
        Me.chkBoxUser.AutoSize = True
        Me.chkBoxUser.Location = New System.Drawing.Point(100, 18)
        Me.chkBoxUser.Name = "chkBoxUser"
        Me.chkBoxUser.Size = New System.Drawing.Size(81, 17)
        Me.chkBoxUser.TabIndex = 69
        Me.chkBoxUser.Text = "CheckBox1"
        Me.chkBoxUser.UseVisualStyleBackColor = True
        '
        'chkBoxMember
        '
        Me.chkBoxMember.AutoSize = True
        Me.chkBoxMember.Location = New System.Drawing.Point(178, 18)
        Me.chkBoxMember.Name = "chkBoxMember"
        Me.chkBoxMember.Size = New System.Drawing.Size(81, 17)
        Me.chkBoxMember.TabIndex = 70
        Me.chkBoxMember.Text = "CheckBox2"
        Me.chkBoxMember.UseVisualStyleBackColor = True
        '
        'chkBoxExpedition
        '
        Me.chkBoxExpedition.AutoSize = True
        Me.chkBoxExpedition.Location = New System.Drawing.Point(258, 18)
        Me.chkBoxExpedition.Name = "chkBoxExpedition"
        Me.chkBoxExpedition.Size = New System.Drawing.Size(81, 17)
        Me.chkBoxExpedition.TabIndex = 71
        Me.chkBoxExpedition.Text = "CheckBox3"
        Me.chkBoxExpedition.UseVisualStyleBackColor = True
        '
        'chkBoxCash
        '
        Me.chkBoxCash.AutoSize = True
        Me.chkBoxCash.Location = New System.Drawing.Point(101, 41)
        Me.chkBoxCash.Name = "chkBoxCash"
        Me.chkBoxCash.Size = New System.Drawing.Size(81, 17)
        Me.chkBoxCash.TabIndex = 72
        Me.chkBoxCash.Text = "CheckBox4"
        Me.chkBoxCash.UseVisualStyleBackColor = True
        '
        'grpBoxSecurity
        '
        Me.grpBoxSecurity.Controls.Add(Me.chkBoxDocuments)
        Me.grpBoxSecurity.Controls.Add(Me.chkBoxCash)
        Me.grpBoxSecurity.Controls.Add(Me.chkBoxExpedition)
        Me.grpBoxSecurity.Controls.Add(Me.lblSecurity)
        Me.grpBoxSecurity.Controls.Add(Me.chkBoxMember)
        Me.grpBoxSecurity.Controls.Add(Me.chkBoxUser)
        Me.grpBoxSecurity.Location = New System.Drawing.Point(6, 90)
        Me.grpBoxSecurity.Name = "grpBoxSecurity"
        Me.grpBoxSecurity.Size = New System.Drawing.Size(520, 65)
        Me.grpBoxSecurity.TabIndex = 73
        Me.grpBoxSecurity.TabStop = False
        '
        'chkBoxDocuments
        '
        Me.chkBoxDocuments.AutoSize = True
        Me.chkBoxDocuments.Location = New System.Drawing.Point(178, 41)
        Me.chkBoxDocuments.Name = "chkBoxDocuments"
        Me.chkBoxDocuments.Size = New System.Drawing.Size(81, 17)
        Me.chkBoxDocuments.TabIndex = 74
        Me.chkBoxDocuments.Text = "CheckBox5"
        Me.chkBoxDocuments.UseVisualStyleBackColor = True
        '
        'frmManageUser
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(536, 213)
        Me.Controls.Add(Me.lblLastLoginDate)
        Me.Controls.Add(Me.lblLastLogin)
        Me.Controls.Add(Me.lblChangeDate)
        Me.Controls.Add(Me.lblChange)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.chkBoxStatus)
        Me.Controls.Add(Me.txtBoxPassword)
        Me.Controls.Add(Me.txtBoxName)
        Me.Controls.Add(Me.txtBoxUserName)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.lblUserName)
        Me.Controls.Add(Me.grpBoxSecurity)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.Name = "frmManageUser"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmManageSingleUser"
        Me.grpBoxSecurity.ResumeLayout(False)
        Me.grpBoxSecurity.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblUserName As Label
    Friend WithEvents lblName As Label
    Friend WithEvents lblPassword As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents txtBoxUserName As TextBox
    Friend WithEvents txtBoxName As TextBox
    Friend WithEvents txtBoxPassword As TextBox
    Friend WithEvents chkBoxStatus As CheckBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents lblChangeDate As Label
    Friend WithEvents lblChange As Label
    Friend WithEvents lblLastLoginDate As Label
    Friend WithEvents lblLastLogin As Label
    Friend WithEvents lblSecurity As Label
    Friend WithEvents chkBoxUser As CheckBox
    Friend WithEvents chkBoxMember As CheckBox
    Friend WithEvents chkBoxExpedition As CheckBox
    Friend WithEvents chkBoxCash As CheckBox
    Friend WithEvents grpBoxSecurity As GroupBox
    Friend WithEvents chkBoxDocuments As CheckBox
End Class
