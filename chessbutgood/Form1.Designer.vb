﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Save_Board_FEN = New System.Windows.Forms.Button()
        Me.Fen_of_board_Save_name = New System.Windows.Forms.TextBox()
        Me.Aivsaibutton = New System.Windows.Forms.Button()
        Me.timer_label = New System.Windows.Forms.Label()
        Me.LabelDepth1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GameInfoLabel = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Ai_information_label = New System.Windows.Forms.Label()
        Me.ShowOpeningMovesButt = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Save_Board_FEN
        '
        Me.Save_Board_FEN.Location = New System.Drawing.Point(12, 12)
        Me.Save_Board_FEN.Name = "Save_Board_FEN"
        Me.Save_Board_FEN.Size = New System.Drawing.Size(164, 47)
        Me.Save_Board_FEN.TabIndex = 0
        Me.Save_Board_FEN.Text = "Save Board"
        Me.Save_Board_FEN.UseVisualStyleBackColor = True
        '
        'Fen_of_board_Save_name
        '
        Me.Fen_of_board_Save_name.Location = New System.Drawing.Point(12, 65)
        Me.Fen_of_board_Save_name.Name = "Fen_of_board_Save_name"
        Me.Fen_of_board_Save_name.Size = New System.Drawing.Size(163, 22)
        Me.Fen_of_board_Save_name.TabIndex = 1
        '
        'Aivsaibutton
        '
        Me.Aivsaibutton.Location = New System.Drawing.Point(12, 93)
        Me.Aivsaibutton.Name = "Aivsaibutton"
        Me.Aivsaibutton.Size = New System.Drawing.Size(163, 32)
        Me.Aivsaibutton.TabIndex = 2
        Me.Aivsaibutton.Text = "play"
        Me.Aivsaibutton.UseVisualStyleBackColor = True
        '
        'timer_label
        '
        Me.timer_label.AutoSize = True
        Me.timer_label.Location = New System.Drawing.Point(1104, 12)
        Me.timer_label.Name = "timer_label"
        Me.timer_label.Size = New System.Drawing.Size(78, 17)
        Me.timer_label.TabIndex = 3
        Me.timer_label.Text = "Information"
        '
        'LabelDepth1
        '
        Me.LabelDepth1.AutoSize = True
        Me.LabelDepth1.Location = New System.Drawing.Point(1104, 29)
        Me.LabelDepth1.Name = "LabelDepth1"
        Me.LabelDepth1.Size = New System.Drawing.Size(0, 17)
        Me.LabelDepth1.TabIndex = 4
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 131)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(164, 35)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Calculate Moves"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 169)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 17)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Information"
        '
        'GameInfoLabel
        '
        Me.GameInfoLabel.AutoSize = True
        Me.GameInfoLabel.Location = New System.Drawing.Point(12, 186)
        Me.GameInfoLabel.Name = "GameInfoLabel"
        Me.GameInfoLabel.Size = New System.Drawing.Size(0, 17)
        Me.GameInfoLabel.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 349)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 17)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "AI Information"
        '
        'Ai_information_label
        '
        Me.Ai_information_label.AutoSize = True
        Me.Ai_information_label.Location = New System.Drawing.Point(9, 366)
        Me.Ai_information_label.Name = "Ai_information_label"
        Me.Ai_information_label.Size = New System.Drawing.Size(0, 17)
        Me.Ai_information_label.TabIndex = 9
        '
        'ShowOpeningMovesButt
        '
        Me.ShowOpeningMovesButt.Location = New System.Drawing.Point(15, 811)
        Me.ShowOpeningMovesButt.Name = "ShowOpeningMovesButt"
        Me.ShowOpeningMovesButt.Size = New System.Drawing.Size(160, 35)
        Me.ShowOpeningMovesButt.TabIndex = 10
        Me.ShowOpeningMovesButt.Text = "Show Opening Moves"
        Me.ShowOpeningMovesButt.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(1281, 892)
        Me.Controls.Add(Me.ShowOpeningMovesButt)
        Me.Controls.Add(Me.Ai_information_label)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GameInfoLabel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.LabelDepth1)
        Me.Controls.Add(Me.timer_label)
        Me.Controls.Add(Me.Aivsaibutton)
        Me.Controls.Add(Me.Fen_of_board_Save_name)
        Me.Controls.Add(Me.Save_Board_FEN)
        Me.DoubleBuffered = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1299, 939)
        Me.MinimumSize = New System.Drawing.Size(1299, 939)
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.Text = "CHESS ENGINE"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Save_Board_FEN As System.Windows.Forms.Button
    Friend WithEvents Fen_of_board_Save_name As System.Windows.Forms.TextBox
    Friend WithEvents Aivsaibutton As System.Windows.Forms.Button
    Friend WithEvents timer_label As System.Windows.Forms.Label
    Friend WithEvents LabelDepth1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GameInfoLabel As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Ai_information_label As System.Windows.Forms.Label
    Friend WithEvents ShowOpeningMovesButt As System.Windows.Forms.Button

End Class
