<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MAIN_MENU
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
        Me.Pvpbutton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PVAIbutton = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Settingsbutton = New System.Windows.Forms.Button()
        Me.FEN_CODE_BUTTON = New System.Windows.Forms.Button()
        Me.Calculate_moves_button = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Pvpbutton
        '
        Me.Pvpbutton.Location = New System.Drawing.Point(12, 84)
        Me.Pvpbutton.Name = "Pvpbutton"
        Me.Pvpbutton.Size = New System.Drawing.Size(268, 36)
        Me.Pvpbutton.TabIndex = 0
        Me.Pvpbutton.Text = "Player VS Player"
        Me.Pvpbutton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 44)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "PLAY"
        '
        'PVAIbutton
        '
        Me.PVAIbutton.Location = New System.Drawing.Point(12, 126)
        Me.PVAIbutton.Name = "PVAIbutton"
        Me.PVAIbutton.Size = New System.Drawing.Size(268, 36)
        Me.PVAIbutton.TabIndex = 2
        Me.PVAIbutton.Text = "Player VS AI"
        Me.PVAIbutton.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 168)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(268, 36)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "AI VS AI"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Settingsbutton
        '
        Me.Settingsbutton.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Settingsbutton.Location = New System.Drawing.Point(12, 437)
        Me.Settingsbutton.Name = "Settingsbutton"
        Me.Settingsbutton.Size = New System.Drawing.Size(128, 63)
        Me.Settingsbutton.TabIndex = 4
        Me.Settingsbutton.Text = "Settings"
        Me.Settingsbutton.UseVisualStyleBackColor = True
        '
        'FEN_CODE_BUTTON
        '
        Me.FEN_CODE_BUTTON.Location = New System.Drawing.Point(155, 437)
        Me.FEN_CODE_BUTTON.Name = "FEN_CODE_BUTTON"
        Me.FEN_CODE_BUTTON.Size = New System.Drawing.Size(125, 59)
        Me.FEN_CODE_BUTTON.TabIndex = 5
        Me.FEN_CODE_BUTTON.Text = "Use FEN code"
        Me.FEN_CODE_BUTTON.UseVisualStyleBackColor = True
        '
        'Calculate_moves_button
        '
        Me.Calculate_moves_button.Location = New System.Drawing.Point(12, 395)
        Me.Calculate_moves_button.Name = "Calculate_moves_button"
        Me.Calculate_moves_button.Size = New System.Drawing.Size(268, 36)
        Me.Calculate_moves_button.TabIndex = 6
        Me.Calculate_moves_button.Text = "TEST: Calculate nodes"
        Me.Calculate_moves_button.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 210)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(110, 27)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'MAIN_MENU
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(319, 512)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Calculate_moves_button)
        Me.Controls.Add(Me.FEN_CODE_BUTTON)
        Me.Controls.Add(Me.Settingsbutton)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.PVAIbutton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Pvpbutton)
        Me.Name = "MAIN_MENU"
        Me.Text = "MAIN_MENU"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Pvpbutton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PVAIbutton As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Settingsbutton As System.Windows.Forms.Button
    Friend WithEvents FEN_CODE_BUTTON As System.Windows.Forms.Button
    Friend WithEvents Calculate_moves_button As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
