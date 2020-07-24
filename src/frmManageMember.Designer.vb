<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmManageMember
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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtBoxMemberName = New System.Windows.Forms.TextBox()
        Me.lblMemberName = New System.Windows.Forms.Label()
        Me.txtBoxStreet = New System.Windows.Forms.TextBox()
        Me.lblStreet = New System.Windows.Forms.Label()
        Me.txtBoxZip = New System.Windows.Forms.TextBox()
        Me.lblZipCity = New System.Windows.Forms.Label()
        Me.txtBoxCity = New System.Windows.Forms.TextBox()
        Me.txtBoxCountry = New System.Windows.Forms.TextBox()
        Me.lblCountry = New System.Windows.Forms.Label()
        Me.txtBoxPhone = New System.Windows.Forms.TextBox()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.txtBoxMail = New System.Windows.Forms.TextBox()
        Me.lblMail = New System.Windows.Forms.Label()
        Me.txtBoxFunction = New System.Windows.Forms.TextBox()
        Me.lblFunction = New System.Windows.Forms.Label()
        Me.lblBirthday = New System.Windows.Forms.Label()
        Me.dateBirthday = New System.Windows.Forms.DateTimePicker()
        Me.dateStart = New System.Windows.Forms.DateTimePicker()
        Me.lblStart = New System.Windows.Forms.Label()
        Me.dateEnd = New System.Windows.Forms.DateTimePicker()
        Me.lblEnd = New System.Windows.Forms.Label()
        Me.chkBoxEnd = New System.Windows.Forms.CheckBox()
        Me.lbltxtid = New System.Windows.Forms.Label()
        Me.lblid = New System.Windows.Forms.Label()
        Me.lblChange = New System.Windows.Forms.Label()
        Me.lblChangeDate = New System.Windows.Forms.Label()
        Me.lblGrade = New System.Windows.Forms.Label()
        Me.cmbBoxGrade = New System.Windows.Forms.ComboBox()
        Me.txtBoxFirstName = New System.Windows.Forms.TextBox()
        Me.picBoxGrade = New System.Windows.Forms.PictureBox()
        Me.chkBoxSupporter = New System.Windows.Forms.CheckBox()
        CType(Me.picBoxGrade, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(396, 250)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(131, 44)
        Me.btnCancel.TabIndex = 17
        Me.btnCancel.Text = "Button1"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(203, 250)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(183, 44)
        Me.btnSave.TabIndex = 16
        Me.btnSave.Text = "Button1"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtBoxMemberName
        '
        Me.txtBoxMemberName.Location = New System.Drawing.Point(106, 9)
        Me.txtBoxMemberName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBoxMemberName.MaxLength = 128
        Me.txtBoxMemberName.Name = "txtBoxMemberName"
        Me.txtBoxMemberName.Size = New System.Drawing.Size(200, 20)
        Me.txtBoxMemberName.TabIndex = 1
        '
        'lblMemberName
        '
        Me.lblMemberName.AutoSize = True
        Me.lblMemberName.Location = New System.Drawing.Point(8, 13)
        Me.lblMemberName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblMemberName.Name = "lblMemberName"
        Me.lblMemberName.Size = New System.Drawing.Size(39, 13)
        Me.lblMemberName.TabIndex = 13
        Me.lblMemberName.Text = "Label1"
        '
        'txtBoxStreet
        '
        Me.txtBoxStreet.Location = New System.Drawing.Point(106, 30)
        Me.txtBoxStreet.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBoxStreet.MaxLength = 128
        Me.txtBoxStreet.Name = "txtBoxStreet"
        Me.txtBoxStreet.Size = New System.Drawing.Size(421, 20)
        Me.txtBoxStreet.TabIndex = 3
        '
        'lblStreet
        '
        Me.lblStreet.AutoSize = True
        Me.lblStreet.Location = New System.Drawing.Point(8, 34)
        Me.lblStreet.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblStreet.Name = "lblStreet"
        Me.lblStreet.Size = New System.Drawing.Size(39, 13)
        Me.lblStreet.TabIndex = 15
        Me.lblStreet.Text = "Label1"
        '
        'txtBoxZip
        '
        Me.txtBoxZip.Location = New System.Drawing.Point(106, 51)
        Me.txtBoxZip.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBoxZip.MaxLength = 6
        Me.txtBoxZip.Name = "txtBoxZip"
        Me.txtBoxZip.Size = New System.Drawing.Size(86, 20)
        Me.txtBoxZip.TabIndex = 4
        '
        'lblZipCity
        '
        Me.lblZipCity.AutoSize = True
        Me.lblZipCity.Location = New System.Drawing.Point(8, 55)
        Me.lblZipCity.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblZipCity.Name = "lblZipCity"
        Me.lblZipCity.Size = New System.Drawing.Size(39, 13)
        Me.lblZipCity.TabIndex = 17
        Me.lblZipCity.Text = "Label1"
        '
        'txtBoxCity
        '
        Me.txtBoxCity.Location = New System.Drawing.Point(193, 51)
        Me.txtBoxCity.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBoxCity.MaxLength = 128
        Me.txtBoxCity.Name = "txtBoxCity"
        Me.txtBoxCity.Size = New System.Drawing.Size(334, 20)
        Me.txtBoxCity.TabIndex = 5
        '
        'txtBoxCountry
        '
        Me.txtBoxCountry.Location = New System.Drawing.Point(106, 72)
        Me.txtBoxCountry.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBoxCountry.MaxLength = 128
        Me.txtBoxCountry.Name = "txtBoxCountry"
        Me.txtBoxCountry.Size = New System.Drawing.Size(421, 20)
        Me.txtBoxCountry.TabIndex = 6
        '
        'lblCountry
        '
        Me.lblCountry.AutoSize = True
        Me.lblCountry.Location = New System.Drawing.Point(8, 76)
        Me.lblCountry.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCountry.Name = "lblCountry"
        Me.lblCountry.Size = New System.Drawing.Size(39, 13)
        Me.lblCountry.TabIndex = 20
        Me.lblCountry.Text = "Label1"
        '
        'txtBoxPhone
        '
        Me.txtBoxPhone.Location = New System.Drawing.Point(106, 93)
        Me.txtBoxPhone.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBoxPhone.MaxLength = 128
        Me.txtBoxPhone.Name = "txtBoxPhone"
        Me.txtBoxPhone.Size = New System.Drawing.Size(421, 20)
        Me.txtBoxPhone.TabIndex = 7
        '
        'lblPhone
        '
        Me.lblPhone.AutoSize = True
        Me.lblPhone.Location = New System.Drawing.Point(8, 97)
        Me.lblPhone.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(39, 13)
        Me.lblPhone.TabIndex = 22
        Me.lblPhone.Text = "Label1"
        '
        'txtBoxMail
        '
        Me.txtBoxMail.Location = New System.Drawing.Point(106, 114)
        Me.txtBoxMail.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBoxMail.MaxLength = 128
        Me.txtBoxMail.Name = "txtBoxMail"
        Me.txtBoxMail.Size = New System.Drawing.Size(421, 20)
        Me.txtBoxMail.TabIndex = 8
        '
        'lblMail
        '
        Me.lblMail.AutoSize = True
        Me.lblMail.Location = New System.Drawing.Point(8, 118)
        Me.lblMail.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblMail.Name = "lblMail"
        Me.lblMail.Size = New System.Drawing.Size(39, 13)
        Me.lblMail.TabIndex = 24
        Me.lblMail.Text = "Label1"
        '
        'txtBoxFunction
        '
        Me.txtBoxFunction.Location = New System.Drawing.Point(106, 135)
        Me.txtBoxFunction.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBoxFunction.MaxLength = 128
        Me.txtBoxFunction.Name = "txtBoxFunction"
        Me.txtBoxFunction.Size = New System.Drawing.Size(421, 20)
        Me.txtBoxFunction.TabIndex = 9
        '
        'lblFunction
        '
        Me.lblFunction.AutoSize = True
        Me.lblFunction.Location = New System.Drawing.Point(8, 139)
        Me.lblFunction.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblFunction.Name = "lblFunction"
        Me.lblFunction.Size = New System.Drawing.Size(39, 13)
        Me.lblFunction.TabIndex = 26
        Me.lblFunction.Text = "Label1"
        '
        'lblBirthday
        '
        Me.lblBirthday.AutoSize = True
        Me.lblBirthday.Location = New System.Drawing.Point(8, 182)
        Me.lblBirthday.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblBirthday.Name = "lblBirthday"
        Me.lblBirthday.Size = New System.Drawing.Size(39, 13)
        Me.lblBirthday.TabIndex = 28
        Me.lblBirthday.Text = "Label1"
        '
        'dateBirthday
        '
        Me.dateBirthday.Location = New System.Drawing.Point(106, 178)
        Me.dateBirthday.Name = "dateBirthday"
        Me.dateBirthday.Size = New System.Drawing.Size(200, 20)
        Me.dateBirthday.TabIndex = 12
        '
        'dateStart
        '
        Me.dateStart.Location = New System.Drawing.Point(106, 199)
        Me.dateStart.Name = "dateStart"
        Me.dateStart.Size = New System.Drawing.Size(200, 20)
        Me.dateStart.TabIndex = 13
        '
        'lblStart
        '
        Me.lblStart.AutoSize = True
        Me.lblStart.Location = New System.Drawing.Point(8, 203)
        Me.lblStart.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblStart.Name = "lblStart"
        Me.lblStart.Size = New System.Drawing.Size(39, 13)
        Me.lblStart.TabIndex = 30
        Me.lblStart.Text = "Label1"
        '
        'dateEnd
        '
        Me.dateEnd.Location = New System.Drawing.Point(106, 220)
        Me.dateEnd.Name = "dateEnd"
        Me.dateEnd.Size = New System.Drawing.Size(200, 20)
        Me.dateEnd.TabIndex = 15
        '
        'lblEnd
        '
        Me.lblEnd.AutoSize = True
        Me.lblEnd.Location = New System.Drawing.Point(8, 224)
        Me.lblEnd.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblEnd.Name = "lblEnd"
        Me.lblEnd.Size = New System.Drawing.Size(39, 13)
        Me.lblEnd.TabIndex = 32
        Me.lblEnd.Text = "Label1"
        '
        'chkBoxEnd
        '
        Me.chkBoxEnd.AutoSize = True
        Me.chkBoxEnd.Location = New System.Drawing.Point(312, 223)
        Me.chkBoxEnd.Name = "chkBoxEnd"
        Me.chkBoxEnd.Size = New System.Drawing.Size(15, 14)
        Me.chkBoxEnd.TabIndex = 14
        Me.chkBoxEnd.UseVisualStyleBackColor = True
        '
        'lbltxtid
        '
        Me.lbltxtid.AutoSize = True
        Me.lbltxtid.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltxtid.Location = New System.Drawing.Point(9, 265)
        Me.lbltxtid.Name = "lbltxtid"
        Me.lbltxtid.Size = New System.Drawing.Size(27, 9)
        Me.lbltxtid.TabIndex = 35
        Me.lbltxtid.Text = "Label1"
        '
        'lblid
        '
        Me.lblid.AutoSize = True
        Me.lblid.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblid.Location = New System.Drawing.Point(56, 265)
        Me.lblid.Name = "lblid"
        Me.lblid.Size = New System.Drawing.Size(27, 9)
        Me.lblid.TabIndex = 36
        Me.lblid.Text = "Label2"
        '
        'lblChange
        '
        Me.lblChange.AutoSize = True
        Me.lblChange.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChange.Location = New System.Drawing.Point(9, 285)
        Me.lblChange.Name = "lblChange"
        Me.lblChange.Size = New System.Drawing.Size(27, 9)
        Me.lblChange.TabIndex = 37
        Me.lblChange.Text = "Label1"
        '
        'lblChangeDate
        '
        Me.lblChangeDate.AutoSize = True
        Me.lblChangeDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChangeDate.Location = New System.Drawing.Point(56, 286)
        Me.lblChangeDate.Name = "lblChangeDate"
        Me.lblChangeDate.Size = New System.Drawing.Size(27, 9)
        Me.lblChangeDate.TabIndex = 38
        Me.lblChangeDate.Text = "Label1"
        '
        'lblGrade
        '
        Me.lblGrade.AutoSize = True
        Me.lblGrade.Location = New System.Drawing.Point(8, 160)
        Me.lblGrade.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblGrade.Name = "lblGrade"
        Me.lblGrade.Size = New System.Drawing.Size(39, 13)
        Me.lblGrade.TabIndex = 39
        Me.lblGrade.Text = "Label1"
        '
        'cmbBoxGrade
        '
        Me.cmbBoxGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBoxGrade.FormattingEnabled = True
        Me.cmbBoxGrade.Location = New System.Drawing.Point(106, 156)
        Me.cmbBoxGrade.MaxLength = 128
        Me.cmbBoxGrade.Name = "cmbBoxGrade"
        Me.cmbBoxGrade.Size = New System.Drawing.Size(331, 21)
        Me.cmbBoxGrade.TabIndex = 10
        '
        'txtBoxFirstName
        '
        Me.txtBoxFirstName.Location = New System.Drawing.Point(307, 9)
        Me.txtBoxFirstName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBoxFirstName.MaxLength = 128
        Me.txtBoxFirstName.Name = "txtBoxFirstName"
        Me.txtBoxFirstName.Size = New System.Drawing.Size(220, 20)
        Me.txtBoxFirstName.TabIndex = 2
        '
        'picBoxGrade
        '
        Me.picBoxGrade.Location = New System.Drawing.Point(396, 178)
        Me.picBoxGrade.Name = "picBoxGrade"
        Me.picBoxGrade.Size = New System.Drawing.Size(131, 69)
        Me.picBoxGrade.TabIndex = 40
        Me.picBoxGrade.TabStop = False
        '
        'chkBoxSupporter
        '
        Me.chkBoxSupporter.AutoSize = True
        Me.chkBoxSupporter.Location = New System.Drawing.Point(443, 157)
        Me.chkBoxSupporter.Name = "chkBoxSupporter"
        Me.chkBoxSupporter.Size = New System.Drawing.Size(81, 17)
        Me.chkBoxSupporter.TabIndex = 11
        Me.chkBoxSupporter.Text = "CheckBox1"
        Me.chkBoxSupporter.UseVisualStyleBackColor = True
        '
        'frmManageMember
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(533, 300)
        Me.Controls.Add(Me.chkBoxSupporter)
        Me.Controls.Add(Me.picBoxGrade)
        Me.Controls.Add(Me.txtBoxFirstName)
        Me.Controls.Add(Me.cmbBoxGrade)
        Me.Controls.Add(Me.lblGrade)
        Me.Controls.Add(Me.lblChangeDate)
        Me.Controls.Add(Me.lblChange)
        Me.Controls.Add(Me.lblid)
        Me.Controls.Add(Me.lbltxtid)
        Me.Controls.Add(Me.chkBoxEnd)
        Me.Controls.Add(Me.dateEnd)
        Me.Controls.Add(Me.lblEnd)
        Me.Controls.Add(Me.dateStart)
        Me.Controls.Add(Me.lblStart)
        Me.Controls.Add(Me.dateBirthday)
        Me.Controls.Add(Me.lblBirthday)
        Me.Controls.Add(Me.txtBoxFunction)
        Me.Controls.Add(Me.lblFunction)
        Me.Controls.Add(Me.txtBoxMail)
        Me.Controls.Add(Me.lblMail)
        Me.Controls.Add(Me.txtBoxPhone)
        Me.Controls.Add(Me.lblPhone)
        Me.Controls.Add(Me.txtBoxCountry)
        Me.Controls.Add(Me.lblCountry)
        Me.Controls.Add(Me.txtBoxCity)
        Me.Controls.Add(Me.txtBoxZip)
        Me.Controls.Add(Me.lblZipCity)
        Me.Controls.Add(Me.txtBoxStreet)
        Me.Controls.Add(Me.lblStreet)
        Me.Controls.Add(Me.txtBoxMemberName)
        Me.Controls.Add(Me.lblMemberName)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.Name = "frmManageMember"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmManageMember"
        CType(Me.picBoxGrade, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents txtBoxMemberName As TextBox
    Friend WithEvents lblMemberName As Label
    Friend WithEvents txtBoxStreet As TextBox
    Friend WithEvents lblStreet As Label
    Friend WithEvents txtBoxZip As TextBox
    Friend WithEvents lblZipCity As Label
    Friend WithEvents txtBoxCity As TextBox
    Friend WithEvents txtBoxCountry As TextBox
    Friend WithEvents lblCountry As Label
    Friend WithEvents txtBoxPhone As TextBox
    Friend WithEvents lblPhone As Label
    Friend WithEvents txtBoxMail As TextBox
    Friend WithEvents lblMail As Label
    Friend WithEvents txtBoxFunction As TextBox
    Friend WithEvents lblFunction As Label
    Friend WithEvents lblBirthday As Label
    Friend WithEvents dateBirthday As DateTimePicker
    Friend WithEvents dateStart As DateTimePicker
    Friend WithEvents lblStart As Label
    Friend WithEvents dateEnd As DateTimePicker
    Friend WithEvents lblEnd As Label
    Friend WithEvents chkBoxEnd As CheckBox
    Friend WithEvents lbltxtid As Label
    Friend WithEvents lblid As Label
    Friend WithEvents lblChange As Label
    Friend WithEvents lblChangeDate As Label
    Friend WithEvents lblGrade As Label
    Friend WithEvents cmbBoxGrade As ComboBox
    Friend WithEvents txtBoxFirstName As TextBox
    Friend WithEvents picBoxGrade As PictureBox
    Friend WithEvents chkBoxSupporter As CheckBox
End Class
