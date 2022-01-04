<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.timer_label = New System.Windows.Forms.Label()
        Me.LabelDepth1 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GameInfoLabel = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Ai_information_label = New System.Windows.Forms.Label()
        Me.ShowOpeningMovesButt = New System.Windows.Forms.Button()
        Me.PieceInfo = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.WhiteteamPP = New System.Windows.Forms.PictureBox()
        Me.BlackteamPP = New System.Windows.Forms.PictureBox()
        Me.MoveLabel = New System.Windows.Forms.Label()
        Me.WhiteTeamGameTag = New System.Windows.Forms.Label()
        Me.BlackTeamGameTag = New System.Windows.Forms.Label()
        Me.WhosWinningTB = New System.Windows.Forms.TextBox()
        Me.MiddleLineTB = New System.Windows.Forms.TextBox()
        Me.UndoMoveButt = New System.Windows.Forms.PictureBox()
        Me.RedoButt = New System.Windows.Forms.PictureBox()
        Me.ExitButt = New System.Windows.Forms.PictureBox()
        Me.NewGameButt = New System.Windows.Forms.PictureBox()
        CType(Me.WhiteteamPP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BlackteamPP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UndoMoveButt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RedoButt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExitButt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NewGameButt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Save_Board_FEN
        '
        Me.Save_Board_FEN.Location = New System.Drawing.Point(324, 132)
        Me.Save_Board_FEN.Name = "Save_Board_FEN"
        Me.Save_Board_FEN.Size = New System.Drawing.Size(164, 47)
        Me.Save_Board_FEN.TabIndex = 0
        Me.Save_Board_FEN.Text = "Save Board"
        Me.Save_Board_FEN.UseVisualStyleBackColor = True
        Me.Save_Board_FEN.Visible = False
        '
        'Fen_of_board_Save_name
        '
        Me.Fen_of_board_Save_name.Location = New System.Drawing.Point(458, 206)
        Me.Fen_of_board_Save_name.Name = "Fen_of_board_Save_name"
        Me.Fen_of_board_Save_name.Size = New System.Drawing.Size(163, 22)
        Me.Fen_of_board_Save_name.TabIndex = 1
        Me.Fen_of_board_Save_name.Visible = False
        '
        'timer_label
        '
        Me.timer_label.AutoSize = True
        Me.timer_label.Location = New System.Drawing.Point(714, 162)
        Me.timer_label.Name = "timer_label"
        Me.timer_label.Size = New System.Drawing.Size(78, 17)
        Me.timer_label.TabIndex = 3
        Me.timer_label.Text = "Information"
        Me.timer_label.Visible = False
        '
        'LabelDepth1
        '
        Me.LabelDepth1.AutoSize = True
        Me.LabelDepth1.Location = New System.Drawing.Point(1104, 29)
        Me.LabelDepth1.Name = "LabelDepth1"
        Me.LabelDepth1.Size = New System.Drawing.Size(0, 17)
        Me.LabelDepth1.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(613, 186)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 17)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Information"
        Me.Label1.Visible = False
        '
        'GameInfoLabel
        '
        Me.GameInfoLabel.AutoSize = True
        Me.GameInfoLabel.Location = New System.Drawing.Point(12, 186)
        Me.GameInfoLabel.Name = "GameInfoLabel"
        Me.GameInfoLabel.Size = New System.Drawing.Size(0, 17)
        Me.GameInfoLabel.TabIndex = 7
        Me.GameInfoLabel.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(163, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 17)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "AI Information"
        '
        'Ai_information_label
        '
        Me.Ai_information_label.AutoSize = True
        Me.Ai_information_label.BackColor = System.Drawing.Color.Transparent
        Me.Ai_information_label.Location = New System.Drawing.Point(263, 45)
        Me.Ai_information_label.Name = "Ai_information_label"
        Me.Ai_information_label.Size = New System.Drawing.Size(0, 17)
        Me.Ai_information_label.TabIndex = 9
        '
        'ShowOpeningMovesButt
        '
        Me.ShowOpeningMovesButt.Location = New System.Drawing.Point(553, 339)
        Me.ShowOpeningMovesButt.Name = "ShowOpeningMovesButt"
        Me.ShowOpeningMovesButt.Size = New System.Drawing.Size(160, 35)
        Me.ShowOpeningMovesButt.TabIndex = 10
        Me.ShowOpeningMovesButt.Text = "Show Opening Moves"
        Me.ShowOpeningMovesButt.UseVisualStyleBackColor = True
        Me.ShowOpeningMovesButt.Visible = False
        '
        'PieceInfo
        '
        Me.PieceInfo.AutoSize = True
        Me.PieceInfo.Location = New System.Drawing.Point(798, 181)
        Me.PieceInfo.Name = "PieceInfo"
        Me.PieceInfo.Size = New System.Drawing.Size(78, 17)
        Me.PieceInfo.TabIndex = 11
        Me.PieceInfo.Text = "Piece Info: "
        Me.PieceInfo.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(371, 296)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(164, 35)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Calculate Moves"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'WhiteteamPP
        '
        Me.WhiteteamPP.BackColor = System.Drawing.Color.White
        Me.WhiteteamPP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.WhiteteamPP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.WhiteteamPP.Location = New System.Drawing.Point(15, 12)
        Me.WhiteteamPP.Name = "WhiteteamPP"
        Me.WhiteteamPP.Size = New System.Drawing.Size(50, 50)
        Me.WhiteteamPP.TabIndex = 12
        Me.WhiteteamPP.TabStop = False
        '
        'BlackteamPP
        '
        Me.BlackteamPP.BackColor = System.Drawing.Color.White
        Me.BlackteamPP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BlackteamPP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BlackteamPP.Location = New System.Drawing.Point(15, 795)
        Me.BlackteamPP.Name = "BlackteamPP"
        Me.BlackteamPP.Size = New System.Drawing.Size(50, 50)
        Me.BlackteamPP.TabIndex = 13
        Me.BlackteamPP.TabStop = False
        '
        'MoveLabel
        '
        Me.MoveLabel.AutoSize = True
        Me.MoveLabel.BackColor = System.Drawing.Color.Transparent
        Me.MoveLabel.Font = New System.Drawing.Font("Imprint MT Shadow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MoveLabel.Location = New System.Drawing.Point(905, 72)
        Me.MoveLabel.Name = "MoveLabel"
        Me.MoveLabel.Size = New System.Drawing.Size(89, 28)
        Me.MoveLabel.TabIndex = 14
        Me.MoveLabel.Text = "Label3"
        '
        'WhiteTeamGameTag
        '
        Me.WhiteTeamGameTag.AutoSize = True
        Me.WhiteTeamGameTag.BackColor = System.Drawing.Color.Transparent
        Me.WhiteTeamGameTag.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WhiteTeamGameTag.Location = New System.Drawing.Point(71, 33)
        Me.WhiteTeamGameTag.Name = "WhiteTeamGameTag"
        Me.WhiteTeamGameTag.Size = New System.Drawing.Size(86, 29)
        Me.WhiteTeamGameTag.TabIndex = 15
        Me.WhiteTeamGameTag.Text = "Label3"
        '
        'BlackTeamGameTag
        '
        Me.BlackTeamGameTag.AutoSize = True
        Me.BlackTeamGameTag.BackColor = System.Drawing.Color.Transparent
        Me.BlackTeamGameTag.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlackTeamGameTag.Location = New System.Drawing.Point(71, 795)
        Me.BlackTeamGameTag.Name = "BlackTeamGameTag"
        Me.BlackTeamGameTag.Size = New System.Drawing.Size(86, 29)
        Me.BlackTeamGameTag.TabIndex = 16
        Me.BlackTeamGameTag.Text = "Label3"
        '
        'WhosWinningTB
        '
        Me.WhosWinningTB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.WhosWinningTB.Location = New System.Drawing.Point(18, 72)
        Me.WhosWinningTB.Multiline = True
        Me.WhosWinningTB.Name = "WhosWinningTB"
        Me.WhosWinningTB.Size = New System.Drawing.Size(36, 773)
        Me.WhosWinningTB.TabIndex = 17
        '
        'MiddleLineTB
        '
        Me.MiddleLineTB.BackColor = System.Drawing.Color.Black
        Me.MiddleLineTB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MiddleLineTB.Location = New System.Drawing.Point(12, 454)
        Me.MiddleLineTB.Multiline = True
        Me.MiddleLineTB.Name = "MiddleLineTB"
        Me.MiddleLineTB.ReadOnly = True
        Me.MiddleLineTB.Size = New System.Drawing.Size(100, 22)
        Me.MiddleLineTB.TabIndex = 18
        '
        'UndoMoveButt
        '
        Me.UndoMoveButt.BackColor = System.Drawing.Color.Transparent
        Me.UndoMoveButt.BackgroundImage = CType(resources.GetObject("UndoMoveButt.BackgroundImage"), System.Drawing.Image)
        Me.UndoMoveButt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.UndoMoveButt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UndoMoveButt.Location = New System.Drawing.Point(901, 759)
        Me.UndoMoveButt.Name = "UndoMoveButt"
        Me.UndoMoveButt.Size = New System.Drawing.Size(176, 33)
        Me.UndoMoveButt.TabIndex = 19
        Me.UndoMoveButt.TabStop = False
        '
        'RedoButt
        '
        Me.RedoButt.BackColor = System.Drawing.Color.Transparent
        Me.RedoButt.BackgroundImage = CType(resources.GetObject("RedoButt.BackgroundImage"), System.Drawing.Image)
        Me.RedoButt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.RedoButt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RedoButt.Location = New System.Drawing.Point(1278, 759)
        Me.RedoButt.Name = "RedoButt"
        Me.RedoButt.Size = New System.Drawing.Size(176, 33)
        Me.RedoButt.TabIndex = 20
        Me.RedoButt.TabStop = False
        '
        'ExitButt
        '
        Me.ExitButt.BackColor = System.Drawing.Color.Transparent
        Me.ExitButt.BackgroundImage = CType(resources.GetObject("ExitButt.BackgroundImage"), System.Drawing.Image)
        Me.ExitButt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ExitButt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ExitButt.Location = New System.Drawing.Point(1090, 23)
        Me.ExitButt.Name = "ExitButt"
        Me.ExitButt.Size = New System.Drawing.Size(176, 37)
        Me.ExitButt.TabIndex = 21
        Me.ExitButt.TabStop = False
        '
        'NewGameButt
        '
        Me.NewGameButt.BackColor = System.Drawing.Color.Transparent
        Me.NewGameButt.BackgroundImage = CType(resources.GetObject("NewGameButt.BackgroundImage"), System.Drawing.Image)
        Me.NewGameButt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.NewGameButt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NewGameButt.Location = New System.Drawing.Point(901, 23)
        Me.NewGameButt.Name = "NewGameButt"
        Me.NewGameButt.Size = New System.Drawing.Size(176, 37)
        Me.NewGameButt.TabIndex = 22
        Me.NewGameButt.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1494, 915)
        Me.ControlBox = False
        Me.Controls.Add(Me.NewGameButt)
        Me.Controls.Add(Me.ExitButt)
        Me.Controls.Add(Me.RedoButt)
        Me.Controls.Add(Me.UndoMoveButt)
        Me.Controls.Add(Me.MiddleLineTB)
        Me.Controls.Add(Me.WhosWinningTB)
        Me.Controls.Add(Me.BlackTeamGameTag)
        Me.Controls.Add(Me.WhiteTeamGameTag)
        Me.Controls.Add(Me.MoveLabel)
        Me.Controls.Add(Me.BlackteamPP)
        Me.Controls.Add(Me.WhiteteamPP)
        Me.Controls.Add(Me.PieceInfo)
        Me.Controls.Add(Me.ShowOpeningMovesButt)
        Me.Controls.Add(Me.Ai_information_label)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GameInfoLabel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.LabelDepth1)
        Me.Controls.Add(Me.timer_label)
        Me.Controls.Add(Me.Fen_of_board_Save_name)
        Me.Controls.Add(Me.Save_Board_FEN)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1500, 950)
        Me.MinimumSize = New System.Drawing.Size(1500, 950)
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CHESS ENGINE"
        CType(Me.WhiteteamPP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BlackteamPP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UndoMoveButt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RedoButt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExitButt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NewGameButt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Save_Board_FEN As System.Windows.Forms.Button
    Friend WithEvents Fen_of_board_Save_name As System.Windows.Forms.TextBox
    Friend WithEvents timer_label As System.Windows.Forms.Label
    Friend WithEvents LabelDepth1 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GameInfoLabel As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Ai_information_label As System.Windows.Forms.Label
    Friend WithEvents ShowOpeningMovesButt As System.Windows.Forms.Button
    Friend WithEvents PieceInfo As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents WhiteteamPP As System.Windows.Forms.PictureBox
    Friend WithEvents BlackteamPP As System.Windows.Forms.PictureBox
    Friend WithEvents MoveLabel As System.Windows.Forms.Label
    Friend WithEvents WhiteTeamGameTag As System.Windows.Forms.Label
    Friend WithEvents BlackTeamGameTag As System.Windows.Forms.Label
    Friend WithEvents WhosWinningTB As System.Windows.Forms.TextBox
    Friend WithEvents MiddleLineTB As System.Windows.Forms.TextBox
    Friend WithEvents UndoMoveButt As System.Windows.Forms.PictureBox
    Friend WithEvents RedoButt As System.Windows.Forms.PictureBox
    Friend WithEvents ExitButt As System.Windows.Forms.PictureBox
    Friend WithEvents NewGameButt As System.Windows.Forms.PictureBox

End Class
