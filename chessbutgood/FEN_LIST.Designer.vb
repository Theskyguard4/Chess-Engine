<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FEN_LIST
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
        Me.START_FEN_BUTT = New System.Windows.Forms.Button()
        Me.FEN_LINE_TB = New System.Windows.Forms.TextBox()
        Me.Fen_label = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'START_FEN_BUTT
        '
        Me.START_FEN_BUTT.Location = New System.Drawing.Point(12, 71)
        Me.START_FEN_BUTT.Name = "START_FEN_BUTT"
        Me.START_FEN_BUTT.Size = New System.Drawing.Size(1370, 40)
        Me.START_FEN_BUTT.TabIndex = 0
        Me.START_FEN_BUTT.Text = "Start With FEN"
        Me.START_FEN_BUTT.UseVisualStyleBackColor = True
        '
        'FEN_LINE_TB
        '
        Me.FEN_LINE_TB.Location = New System.Drawing.Point(12, 43)
        Me.FEN_LINE_TB.Name = "FEN_LINE_TB"
        Me.FEN_LINE_TB.Size = New System.Drawing.Size(1370, 22)
        Me.FEN_LINE_TB.TabIndex = 2
        '
        'Fen_label
        '
        Me.Fen_label.AutoSize = True
        Me.Fen_label.Location = New System.Drawing.Point(9, 9)
        Me.Fen_label.Name = "Fen_label"
        Me.Fen_label.Size = New System.Drawing.Size(113, 17)
        Me.Fen_label.TabIndex = 4
        Me.Fen_label.Text = "Divide string by /"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1164, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(216, 28)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Pick From list"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FEN_LIST
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1392, 119)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Fen_label)
        Me.Controls.Add(Me.FEN_LINE_TB)
        Me.Controls.Add(Me.START_FEN_BUTT)
        Me.Name = "FEN_LIST"
        Me.Text = "FEN_LIST"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents START_FEN_BUTT As System.Windows.Forms.Button
    Friend WithEvents FEN_LINE_TB As System.Windows.Forms.TextBox
    Friend WithEvents Fen_label As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
