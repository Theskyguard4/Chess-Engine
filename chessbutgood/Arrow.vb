Public Class Arrow
    Protected ArrowVis As PictureBox
    Protected Length As Integer
    Protected Width As Integer
    Protected X As Integer
    Protected Y As Integer
    Protected Startpoint As Form1.BasicPosition
    Protected Endpoint As Form1.BasicPosition
    Protected Direction As Integer
    Public Sub New()
        Me.Direction = 0
        Me.ArrowVis = New PictureBox
        Me.ArrowVis.SetBounds(0, 0, 0, 0)
        Me.ArrowVis.Enabled = False
        Me.ArrowVis.Visible = False
        Me.ArrowVis.BackColor = Color.Transparent
        Me.ArrowVis.SizeMode = PictureBoxSizeMode.StretchImage
        Me.ArrowVis.Image = Image.FromFile(MAIN_MENU.settings.AssetPATH & "arrow.png")
        AddHandler ArrowVis.Click, AddressOf ArrowVis_Click

        Form1.Controls.Add(Me.ArrowVis)
    End Sub
    Private Sub ArrowVis_Click(ByVal sender As Object, ByVal e As MouseEventArgs)
        Me.ArrowVis.Enabled = False
        Me.ArrowVis.Visible = False
        Me.ClearArrow()
        Form1.CurrentArrowPointer -= 1

    End Sub
    Public Sub ClearArrow()
        Me.X = 0
        Me.Y = 0
        Me.Length = 0
        Me.Width = 0
        Me.ArrowVis.Enabled = False
        Me.ArrowVis.Visible = False
    End Sub

    Public Sub CalPos()
        'up
        If Me.Startpoint.y > Me.Endpoint.y And Me.Startpoint.X = Me.Endpoint.X Then
            Me.X = ((Me.Endpoint.X * 75) + 48 + (-(Me.Endpoint.X) + 4)) + 30
            Me.Y = ((Me.Endpoint.y * 74) + 55 + (-Me.Endpoint.y)) + 25
            Me.Width = 10
            Me.Length = (((Me.Startpoint.y * 74) + 55 + (-Me.Startpoint.y)) - Y)
            Me.ArrowVis.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            Me.Direction = 270
        End If
        'down
        If Me.Startpoint.y < Me.Endpoint.y And Me.Startpoint.X = Me.Endpoint.X Then
            Me.X = ((Me.Startpoint.X * 75) + 48 + (-(Me.Startpoint.X) + 4)) + 30
            Me.Y = ((Me.Startpoint.y * 74) + 55 + (-Me.Startpoint.y)) + 75
            Me.Width = 10
            Me.Length = (((Me.Endpoint.y * 74) + 55 + (-Me.Endpoint.y)) - Y) + 35
            Me.ArrowVis.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            Me.Direction = 90
        End If
        'left
        If Me.Startpoint.y = Me.Endpoint.y And Me.Startpoint.X > Me.Endpoint.X Then
            Me.X = ((Me.Endpoint.X * 75) + 48 + (-(Me.Endpoint.X) + 4)) + 30
            Me.Y = ((Me.Endpoint.y * 74) + 55 + (-Me.Endpoint.y)) + 25
            Me.Width = (((Me.Startpoint.X * 75) + 48 + (-(Me.Startpoint.X) + 4)) - X)
            Me.Length = 10
            Me.ArrowVis.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            Me.Direction = 180
        End If
        'right
        If Me.Startpoint.y = Me.Endpoint.y And Me.Startpoint.X < Me.Endpoint.X Then
            Me.X = ((Me.Startpoint.X * 75) + 48 + (-(Me.Startpoint.X) + 4)) + 75
            Me.Y = ((Me.Startpoint.y * 74) + 55 + (-Me.Startpoint.y)) + 25
            Me.Width = (((Me.Endpoint.X * 75) + 48 + (-(Me.Endpoint.X) + 4)) - X) + 35
            Me.Length = 10

            Me.Direction = 0
        End If
       

        Me.ArrowVis.SetBounds(Me.X, Me.Y, Me.Width, Me.Length)
        Me.ArrowVis.BringToFront()
        Me.ArrowVis.Enabled = True
        Me.ArrowVis.Visible = True
    End Sub
    Public Sub SetStart(ByVal xx As Integer, ByVal yy As Integer)
        Select Case Me.Direction
            Case 90
                Me.ArrowVis.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            Case 180
                Me.ArrowVis.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            Case 270
                Me.ArrowVis.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
        End Select
        Me.Startpoint.X = xx
        Me.Startpoint.y = yy
        Form1.Cursor = Cursors.Arrow
    End Sub
    Public Sub SetEnd(ByVal xx As Integer, ByVal yy As Integer)
        Me.Endpoint.X = xx
        Me.Endpoint.y = yy
        Me.CalPos()
        Form1.Cursor = Cursors.Hand
    End Sub
    Public Sub SetPos(ByVal XX As Integer, ByVal YY As Integer, ByVal W As Integer, ByVal L As Integer)
        Me.X = XX
        Me.Y = YY
        Me.Width = W
        Me.Length = L
        Me.ArrowVis.SetBounds(XX, YY, W, L)
        Me.ArrowVis.Enabled = True
        Me.ArrowVis.Visible = True
    End Sub
    Public Function XPos()
        Return Me.X
    End Function
    Public Function YPos()
        Return Me.Y
    End Function
    Public Function VisRepLength()
        Return Me.Length
    End Function
    Public Function VisRepWidth()
        Return Me.Width
    End Function

    Public Sub XPos(ByVal xx As Integer)
        Me.X = xx
    End Sub
    Public Sub YPos(ByVal yy As Integer)
        Me.Y = yy
    End Sub
    Public Sub VisRepLength(ByVal Len As Integer)
        Me.Length = Len
    End Sub
    Public Sub VisRepWidth(ByVal wid As Integer)
        Me.Width = wid
    End Sub
End Class
