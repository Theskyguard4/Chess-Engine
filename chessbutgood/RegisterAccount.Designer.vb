<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RegisterAccount
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
        Me.cretaeprofileBUTT = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PasswordTB = New System.Windows.Forms.TextBox()
        Me.UsernameTB = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RepeatPasswordTB = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ErrorMsgCP = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cretaeprofileBUTT
        '
        Me.cretaeprofileBUTT.Location = New System.Drawing.Point(12, 279)
        Me.cretaeprofileBUTT.Name = "cretaeprofileBUTT"
        Me.cretaeprofileBUTT.Size = New System.Drawing.Size(389, 46)
        Me.cretaeprofileBUTT.TabIndex = 0
        Me.cretaeprofileBUTT.Text = "Create Profile"
        Me.cretaeprofileBUTT.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(63, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 20)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Username"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(66, 165)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 20)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Password"
        '
        'PasswordTB
        '
        Me.PasswordTB.Location = New System.Drawing.Point(166, 165)
        Me.PasswordTB.Name = "PasswordTB"
        Me.PasswordTB.Size = New System.Drawing.Size(235, 22)
        Me.PasswordTB.TabIndex = 9
        '
        'UsernameTB
        '
        Me.UsernameTB.Location = New System.Drawing.Point(166, 105)
        Me.UsernameTB.Name = "UsernameTB"
        Me.UsernameTB.Size = New System.Drawing.Size(235, 22)
        Me.UsernameTB.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 225)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(141, 20)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Repeat Password"
        '
        'RepeatPasswordTB
        '
        Me.RepeatPasswordTB.Location = New System.Drawing.Point(166, 225)
        Me.RepeatPasswordTB.Name = "RepeatPasswordTB"
        Me.RepeatPasswordTB.Size = New System.Drawing.Size(235, 22)
        Me.RepeatPasswordTB.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(62, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(278, 46)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Create Profile"
        '
        'ErrorMsgCP
        '
        Me.ErrorMsgCP.AutoSize = True
        Me.ErrorMsgCP.Location = New System.Drawing.Point(12, 69)
        Me.ErrorMsgCP.Name = "ErrorMsgCP"
        Me.ErrorMsgCP.Size = New System.Drawing.Size(0, 17)
        Me.ErrorMsgCP.TabIndex = 15
        '
        'RegisterAccount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(413, 337)
        Me.Controls.Add(Me.ErrorMsgCP)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.RepeatPasswordTB)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PasswordTB)
        Me.Controls.Add(Me.UsernameTB)
        Me.Controls.Add(Me.cretaeprofileBUTT)
        Me.Name = "RegisterAccount"
        Me.Text = "Form2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cretaeprofileBUTT As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PasswordTB As System.Windows.Forms.TextBox
    Friend WithEvents UsernameTB As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents RepeatPasswordTB As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ErrorMsgCP As System.Windows.Forms.Label
End Class
