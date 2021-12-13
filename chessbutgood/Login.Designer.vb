<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.UsernameTB = New System.Windows.Forms.TextBox()
        Me.PasswordTB = New System.Windows.Forms.TextBox()
        Me.EnterSignInBUTT = New System.Windows.Forms.Button()
        Me.RegisterBUTT = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ForgotPasswordBUTT = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.LoginERRORLabel = New System.Windows.Forms.Label()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UsernameTB
        '
        Me.UsernameTB.Location = New System.Drawing.Point(98, 149)
        Me.UsernameTB.Name = "UsernameTB"
        Me.UsernameTB.Size = New System.Drawing.Size(278, 22)
        Me.UsernameTB.TabIndex = 0
        '
        'PasswordTB
        '
        Me.PasswordTB.Location = New System.Drawing.Point(98, 209)
        Me.PasswordTB.Name = "PasswordTB"
        Me.PasswordTB.Size = New System.Drawing.Size(278, 22)
        Me.PasswordTB.TabIndex = 1
        '
        'EnterSignInBUTT
        '
        Me.EnterSignInBUTT.Location = New System.Drawing.Point(104, 302)
        Me.EnterSignInBUTT.Name = "EnterSignInBUTT"
        Me.EnterSignInBUTT.Size = New System.Drawing.Size(275, 42)
        Me.EnterSignInBUTT.TabIndex = 3
        Me.EnterSignInBUTT.Text = "Sign In"
        Me.EnterSignInBUTT.UseVisualStyleBackColor = True
        '
        'RegisterBUTT
        '
        Me.RegisterBUTT.Location = New System.Drawing.Point(104, 251)
        Me.RegisterBUTT.Name = "RegisterBUTT"
        Me.RegisterBUTT.Size = New System.Drawing.Size(130, 45)
        Me.RegisterBUTT.TabIndex = 4
        Me.RegisterBUTT.Text = "Register"
        Me.RegisterBUTT.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 209)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Password"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 151)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 20)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Username"
        '
        'ForgotPasswordBUTT
        '
        Me.ForgotPasswordBUTT.Location = New System.Drawing.Point(249, 251)
        Me.ForgotPasswordBUTT.Name = "ForgotPasswordBUTT"
        Me.ForgotPasswordBUTT.Size = New System.Drawing.Size(130, 45)
        Me.ForgotPasswordBUTT.TabIndex = 8
        Me.ForgotPasswordBUTT.Text = "Forgot Password"
        Me.ForgotPasswordBUTT.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox2.Location = New System.Drawing.Point(249, 12)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(120, 120)
        Me.PictureBox2.TabIndex = 10
        Me.PictureBox2.TabStop = False
        '
        'LoginERRORLabel
        '
        Me.LoginERRORLabel.AutoSize = True
        Me.LoginERRORLabel.Location = New System.Drawing.Point(4, 115)
        Me.LoginERRORLabel.Name = "LoginERRORLabel"
        Me.LoginERRORLabel.Size = New System.Drawing.Size(0, 17)
        Me.LoginERRORLabel.TabIndex = 11
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(391, 356)
        Me.Controls.Add(Me.LoginERRORLabel)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.ForgotPasswordBUTT)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RegisterBUTT)
        Me.Controls.Add(Me.EnterSignInBUTT)
        Me.Controls.Add(Me.PasswordTB)
        Me.Controls.Add(Me.UsernameTB)
        Me.Name = "Login"
        Me.Text = "Login"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UsernameTB As System.Windows.Forms.TextBox
    Friend WithEvents PasswordTB As System.Windows.Forms.TextBox
    Friend WithEvents EnterSignInBUTT As System.Windows.Forms.Button
    Friend WithEvents RegisterBUTT As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ForgotPasswordBUTT As System.Windows.Forms.Button
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents LoginERRORLabel As System.Windows.Forms.Label
End Class
