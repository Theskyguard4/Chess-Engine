Public Class pieces
    Protected images As PictureBox
    Protected Team As Integer
    Protected symbal As String
    Protected xpos As Integer
    Protected ypos As Integer
    Protected move As New List(Of Form1.position)
    Protected ispinned As Boolean
    Protected movesave As Form1.position
    Protected value As Integer
    Protected ispawnmovedtwospaces As Boolean = False
    Protected CanDoElPasent As Boolean
    Protected roundmoved2 As Integer
    Protected hasmoved As Boolean = False
    Public Sub set_el_pasent(ByVal bool As Boolean)
        CanDoElPasent = bool
    End Sub
    Public Function return_el_pasent()
    
        If Me.ispawnmovedtwospaces = True And (Form1.rounds + 1) - Me.roundmoved2 = 1 Then
            Return True
        End If
        Return False
    End Function
    Public Function return_rounds_after_el_pas()
        Return roundmoved2
    End Function
    Public Sub set_round_moved_2(ByVal num As Integer)
        Me.roundmoved2 = num
    End Sub
    Public Sub is_pawn_move_two_space_set(ByVal bool As Boolean)
        ispawnmovedtwospaces = bool
    End Sub
    Public Sub has_moved(ByVal bool As Boolean)
        hasmoved = bool
    End Sub
    Public Function get_hasmoved()
        Return hasmoved
    End Function
    Public Function get_ispawnmovedtwo()
        Return ispawnmovedtwospaces
    End Function
    Public Function get_value()
        Return Me.value

    End Function
    Public Sub set_value(ByVal values As Integer)
        Me.value = values


    End Sub

    Public Sub setpinfalse()
        Me.ispinned = False
    End Sub
    Public Sub setpintrue()
        Me.ispinned = True
    End Sub
    Public Function getpin() As Boolean
        Return ispinned
    End Function
    Private Sub moveto(ByVal sender As Object, ByVal e As EventArgs)

    End Sub
    Public Sub setimageselected()
        Me.images.Image = Image.FromFile("D:\documents\chessimages\selected.png")
    End Sub

    Public Sub resetimage()
        Dim s As String = Me.symbal
        Dim t As Integer = Me.getteam
        Select Case s
            Case "p"
                If t = 0 Then
                    Me.images.Image = Image.FromFile("D:\documents\chessimages\wpawn.png")
                Else
                    Me.images.Image = Image.FromFile("D:\documents\chessimages\bpawn.png")
                End If
            Case "c"
                If t = 0 Then
                    Me.images.Image = Image.FromFile("D:\documents\chessimages\wcastle.png")
                Else
                    Me.images.Image = Image.FromFile("D:\documents\chessimages\bcastle.png")
                End If
            Case "h"
                If t = 0 Then
                    Me.images.Image = Image.FromFile("D:\documents\chessimages\whorse.png")
                Else
                    Me.images.Image = Image.FromFile("D:\documents\chessimages\bhorse.png")
                End If
            Case "b"
                If t = 0 Then
                    Me.images.Image = Image.FromFile("D:\documents\chessimages\whitebich.png")
                Else
                    Me.images.Image = Image.FromFile("D:\documents\chessimages\bbich.png")
                End If
            Case "q"
                If t = 0 Then
                    Me.images.Image = Image.FromFile("D:\documents\chessimages\wqueen.png")
                Else
                    Me.images.Image = Image.FromFile("D:\documents\chessimages\bqueen.png")
                End If
            Case "k"
                If t = 0 Then
                    Me.images.Image = Image.FromFile("D:\documents\chessimages\wking.png")
                Else
                    Me.images.Image = Image.FromFile("D:\documents\chessimages\bking.png")
                End If
            Case "_"
                Me.images.Image = Image.FromFile("D:\documents\chessimages\blankse.png")
        End Select


    End Sub
    Public Sub drawavaliblemoves(ByVal move As List(Of Form1.position))

        If IsNothing(move) = False Then


            For xx = 0 To move.Count - 1
                If Form1.pieceselected.getsym = "k" Then
                    xx = xx
                End If
                Form1.board(move(xx).x, move(xx).y).setimageselected()
            Next
        End If


    End Sub
    Private Function ispickedokay()
        For x = 0 To Form1.pieceselected.move.Count - 1
            If Form1.pieceselected.move(x).x = Me.getx And Form1.pieceselected.move(x).y = Me.gety Then
                'pawn moves
                If Form1.pieceselected.symbal = "p" Then
                    If Me.gety = Form1.pieceselected.ypos + 2 Or Me.gety = Form1.pieceselected.ypos - 2 Then
                        Me.ispawnmovedtwospaces = True
                        Me.roundmoved2 = Form1.rounds
                    ElseIf Me.ispawnmovedtwospaces = True Then
                        Me.ispawnmovedtwospaces = False


                    End If

                End If

                If Me.hasmoved = False Then
                    Me.hasmoved = True
                End If

                Return True
            End If
        Next
        Return False
    End Function
    Private Sub PictureBox1_Click(ByVal sender As Object, ByVal e As EventArgs)


        If Form1.isselectedownalready = False Then
            'MsgBox(Me.getsym) 'when u click on a piece displays the sym
            If Me.getteam = Form1.whosgo Then
                Form1.isselectedownalready = True
                Me.drawavaliblemoves(Me.move)
                Form1.pieceselected = Me.dupe
            End If
        Else
            'If changeboard2(Me.symbal, Me.Team, Me.getx, Me.gety) = True Then
            If Me.getteam = Form1.whosgo Then
                If IsNothing(Form1.pieceselected.move) = False Then

                    Form1.deletemoves(Form1.pieceselected.move, Form1.board)
                End If

                Form1.pieceselected = Me.dupe
                Me.drawavaliblemoves(Me.move)
            Else
                If Me.ispickedokay = True Then

                    If Form1.board(Form1.pieceselected.getx, Form1.pieceselected.gety).getmoves(get_move_number(Form1.pieceselected.getx, Form1.pieceselected.gety, Me.getx, Me.gety)).iscastling = True Then

                        Me.Change_castling_pos(Form1.pieceselected.getteam, Form1.pieceselected.getx, Me.getx)
                        changeboard.changepiecetowhere(Me.getsym, Me.getteam, Me.xpos, Me.gety, Form1.pieceselected.getx, Form1.pieceselected.gety, True, True)


                    ElseIf Form1.board(Form1.pieceselected.getx, Form1.pieceselected.gety).getmoves(get_move_number(Form1.pieceselected.getx, Form1.pieceselected.gety, Me.getx, Me.gety)).IsAlPasentMove = True Then
                        Me.change_al_pasent(Me.getx, Me.gety, Form1.pieceselected.getteam)
                        changeboard.changepiecetowhere(Me.getsym, Me.getteam, Me.xpos, Me.gety, Form1.pieceselected.getx, Form1.pieceselected.gety, True, False)
                    Else
                        changeboard.changepiecetowhere(Me.getsym, Me.getteam, Me.xpos, Me.gety, Form1.pieceselected.getx, Form1.pieceselected.gety, True, False)
                    End If

                    If Me.getsym = "p" Then
                        If Me.getteam = 0 And Me.gety = 7 Then
                            If Form1.settings.Playing_Agaisnt_AI <> True And Me.getteam <> Form1.AIPLAYER.get_team Then
                                Promotion.team_of_proting_pawn = 0
                                Promotion.promotion_place.x = Me.getx
                                Promotion.promotion_place.y = Me.gety
                                Promotion.Show()
                                Do Until Form1.confirmed = True
                                    Application.DoEvents()
                                Loop
                            End If


                        ElseIf Me.getteam = 1 And Me.gety = 0 Then

                            If Form1.settings.Playing_Agaisnt_AI <> True And Me.getteam <> Form1.AIPLAYER.get_team Then
                                Promotion.team_of_proting_pawn = 1
                                Promotion.promotion_place.x = Me.getx
                                Promotion.promotion_place.y = Me.gety
                                Promotion.Show()
                                Do Until Form1.confirmed = True
                                    Application.DoEvents()
                                Loop
                            End If



                        End If

                    End If
                    Form1.deletemoves(Form1.pieceselected.move, Form1.board)

                    Form1.Game()
                End If
            End If
        End If


    End Sub
    Private Sub change_al_pasent(ByVal movex As Integer, ByVal movey As Integer, ByVal teamtaking As Integer)
        Select Case teamtaking
            Case 0
                changeboard.settoblank(movex, movey - 1)
            Case 1
                changeboard.settoblank(movex, movey + 1)
        End Select
    End Sub

    Private Sub Change_castling_pos(ByVal team_of_castle As Integer, ByVal kingbeforex As Integer, ByVal movex As Integer)
        Dim pos_of_castlex As Integer

        If movex > kingbeforex Then
            pos_of_castlex = 7
        ElseIf movex < kingbeforex Then
            pos_of_castlex = 0
        End If
        Select Case team_of_castle
            Case 0
                If pos_of_castlex = 0 Then
                    changeboard.changepiecetowhere("c", 0, kingbeforex - 1, 0, pos_of_castlex, 0, False, False)

                ElseIf pos_of_castlex = 7 Then
                    changeboard.changepiecetowhere("c", 0, kingbeforex + 1, 0, pos_of_castlex, 0, False, False)
                End If
            Case 1
                If pos_of_castlex = 0 Then
                    changeboard.changepiecetowhere("c", 1, kingbeforex - 1, 7, pos_of_castlex, 7, False, False)

                ElseIf pos_of_castlex = 7 Then
                    changeboard.changepiecetowhere("c", 1, kingbeforex + 1, 7, pos_of_castlex, 7, False, False)
                End If
        End Select

    End Sub
    Private Function get_move_number(ByVal PSelectedx As Integer, ByVal PSelectedy As Integer, ByVal movex As Integer, ByVal movey As Integer)
        Dim count As Integer = 0
        For Each M In Form1.board(PSelectedx, PSelectedy).getmoves
            If M.x = movex And M.y = movey Then
                Return count
            End If
            count += 1
        Next
    End Function
    Public Sub New()

    End Sub
    Public Sub resetmov()
        Me.move.Clear()
    End Sub
    Public Sub setxy(ByVal x As Integer, ByVal y As Integer)
        Me.xpos = x
        Me.ypos = y
    End Sub


    Public Sub resetmoves()
        Me.move.Clear()

    End Sub
    Public Sub addcheckmoves(ByVal x, ByVal y)
        Dim movesave As Form1.position
        If IsNothing(Me.move) = True Then
            Me.move.Clear()

            Me.move(0) = New Form1.position

        End If





        movesave.x = x
        movesave.y = y
        Me.move.Add(movesave)



    End Sub
    Private Sub decideifincheck(ByVal x, ByVal y)

    End Sub
    Public Sub addunderattack(ByVal x As Integer, ByVal y As Integer)
        Dim new_pos As Form1.position


        If Form1.board(x, y).getsym = "k" And Form1.board(x, y).getteam <> Me.getteam Then
            'MsgBox("in check")
            Form1.checked = True
            Form1.incheckpiece.kingmove.x = x 'king pos
            Form1.incheckpiece.kingmove.y = y 'king pos
            Form1.incheckpiece.team = Me.getteam ' attacking team
            Form1.incheckpiece.sy = Me.getsym 'attacking sym
            Form1.incheckpiece.x = Me.getx 'attacking pos
            Form1.incheckpiece.y = Me.gety 'attacking pos
            Form1.incheckpiece.xdiff = x - Me.getx
            Form1.incheckpiece.ydiff = y - Me.gety
            'MsgBox(Form1.incheckpiece.ydiff & "     " & Form1.inchdeckpiece.xdiff)
            Dim yy As Integer = Me.gety
            If Form1.incheckpiece.xdiff < 0 And Form1.incheckpiece.ydiff < 0 Then
                'up left

                yy -= 1
                For xx = Me.getx - 1 To Form1.incheckpiece.kingmove.x + 1 Step -1
                    If Form1.board(xx, yy).getsym = "_" Then


                        new_pos.x = xx
                        new_pos.y = yy
                        Form1.incheckpiece.blockablepositions.Add(new_pos)
                        Form1.incheckpiece.direction = "upleft"

                    End If
                    If yy < Form1.incheckpiece.kingmove.x + 1 Then
                        xx = 0
                    End If
                    yy -= 1
                Next
            ElseIf Form1.incheckpiece.xdiff < 0 And Form1.incheckpiece.ydiff > 0 Then
                ' down left
                yy += 1
                For xx = Me.getx - 1 To Form1.incheckpiece.kingmove.x + 1 Step -1
                    If Form1.board(xx, yy).getsym = "_" Then
                        new_pos.x = xx
                        new_pos.y = yy
                        Form1.incheckpiece.blockablepositions.Add(new_pos)
                        Form1.incheckpiece.direction = "downleft"
                    End If
                    If yy > Form1.incheckpiece.kingmove.y - 1 Then
                        xx = 0
                    End If
                    yy += 1
                Next
            ElseIf Form1.incheckpiece.xdiff > 0 And Form1.incheckpiece.ydiff < 0 Then
                ' up right
                yy -= 1
                For xx = Me.getx + 1 To Form1.incheckpiece.kingmove.x - 1 Step 1
                    If Form1.board(xx, yy).getsym = "_" Then
                        new_pos.x = xx
                        new_pos.y = yy
                        Form1.incheckpiece.blockablepositions.Add(new_pos)
                        Form1.incheckpiece.direction = "upright"

                    End If
                    If yy < Form1.incheckpiece.kingmove.x + 1 Then
                        xx = 7
                    End If
                    yy -= 1
                Next
            ElseIf Form1.incheckpiece.xdiff > 1 And Form1.incheckpiece.ydiff > 1 Then
                ' down right //
                yy += 1
                For xx = Me.getx + 1 To Form1.incheckpiece.kingmove.x - 1 Step 1
                    If Form1.board(xx, yy).getsym = "_" Then
                        new_pos.x = xx
                        new_pos.y = yy
                        Form1.incheckpiece.blockablepositions.Add(new_pos)
                        Form1.incheckpiece.direction = "downright"

                    End If
                    If yy > Form1.incheckpiece.kingmove.y - 1 Then
                        xx = 7
                    End If
                    yy += 1
                Next
            ElseIf Form1.incheckpiece.xdiff > 0 And Form1.incheckpiece.ydiff = 0 Then
                'right
                For xx = Me.getx + 1 To Form1.incheckpiece.kingmove.x - 1 Step 1
                    If Form1.board(xx, yy).getsym = "_" Then
                        new_pos.x = xx
                        new_pos.y = yy
                        Form1.incheckpiece.blockablepositions.Add(new_pos)
                        Form1.incheckpiece.direction = "right"
                    End If

                Next
            ElseIf Form1.incheckpiece.xdiff < 0 And Form1.incheckpiece.ydiff = 0 Then
                'left
                For xx = Me.getx - 1 To Form1.incheckpiece.kingmove.x + 1 Step -1
                    If Form1.board(xx, yy).getsym = "_" Then
                        new_pos.x = xx
                        new_pos.y = yy
                        Form1.incheckpiece.blockablepositions.Add(new_pos)
                        Form1.incheckpiece.direction = "left"

                    End If

                Next
            ElseIf Form1.incheckpiece.xdiff = 0 And Form1.incheckpiece.ydiff < 0 Then
                'up
                For xx = Me.gety - 1 To Form1.incheckpiece.kingmove.y + 1 Step -1
                    If Form1.board(xx, yy).getsym = "_" Then
                        new_pos.x = xx
                        new_pos.y = yy
                        Form1.incheckpiece.blockablepositions.Add(new_pos)
                        Form1.incheckpiece.direction = "up"

                    End If

                Next
            ElseIf Form1.incheckpiece.xdiff = 0 And Form1.incheckpiece.ydiff > 0 Then
                'down
                Dim xxx As Integer = Me.gety
                'MsgBox("x: " & xxx - 1 & " to " & Form1.incheckpiece.kingmove.y + 1)
                For xx = xxx + 1 To Form1.incheckpiece.kingmove.y - 1 Step 1
                    If Form1.board(xx, yy).getsym = "_" Then
                        new_pos.x = xx
                        new_pos.y = yy
                        Form1.incheckpiece.blockablepositions.Add(new_pos)
                        Form1.incheckpiece.direction = "down"

                    End If

                Next


            End If
        End If
        If Me.getteam = 0 Then
            'MsgBox(x & " = x, " & y & " = y, ")

            new_pos.x = x
            new_pos.y = y
            Form1.zerolistofincheckplaces.Add(new_pos)
        ElseIf Me.getteam = 1 Then

            new_pos.x = x
            new_pos.y = y
            Form1.onelistofincheckplaces.Add(new_pos)

        End If

    End Sub
    Private Function order_moves(ByVal moves_list As List(Of moves))






        Return moves_list
    End Function


    Public Sub addmoves(ByVal x As Integer, ByVal y As Integer, ByVal castlingbool As Boolean, ByVal isAlPasent As Boolean)







        Me.movesave.x = x
        Me.movesave.y = y
        Me.movesave.iscastling = castlingbool
        Me.movesave.IsAlPasentMove = isAlPasent
        If Form1.whosgo = 0 And Form1.rounds = 2 Then
            'MsgBox("")
        End If
        Me.move.Add(movesave)






    End Sub
    Public Function getmoves() As List(Of Form1.position)
        Return Me.move
    End Function
    Public Sub drawimage(ByVal x, ByVal y)
        setxy(x, y)
        Me.images.SetBounds((x * 76) + 180, (y * 76) + 40, 60, 60)
        Me.images.BackgroundImageLayout = ImageLayout.Stretch
        Me.images.BackColor = Color.Transparent
        AddHandler Me.images.Click, AddressOf PictureBox1_Click
        Form1.Controls.Add(Me.images)
    End Sub
    Public Function getimage()
        Return Me.images
    End Function
    Public Function getx()
        Return Me.xpos

    End Function
    Public Function gety()
        Return Me.ypos
    End Function
    Public Function getteam()
        Return Me.Team

    End Function
    Public Function getsym()
        Return Me.symbal
    End Function
    Public Function dupe()
        Return Me
    End Function
    Public Sub setpiece(ByVal s, ByVal t)


        Me.Team = t
        Me.symbal = s
        If Form1.rounds = 0 Then
            Me.images = New PictureBox
        End If

        Select Case Me.symbal
            Case "p"
                Me.set_value(Form1.pawnvalue)


                If t = 0 Then

                    Me.images.Image = Image.FromFile("D:\documents\chessimages\wpawn.png")
                Else

                    Me.images.Image = Image.FromFile("D:\documents\chessimages\bpawn.png")
                End If
            Case "c"
                Me.set_value(Form1.castlevalue)
                If t = 0 Then

                    Me.images.Image = Image.FromFile("D:\documents\chessimages\wcastle.png")
                Else

                    Me.images.Image = Image.FromFile("D:\documents\chessimages\bcastle.png")
                End If
            Case "h"
                Me.set_value(Form1.horsevalue)
                If t = 0 Then

                    Me.images.Image = Image.FromFile("D:\documents\chessimages\whorse.png")
                Else

                    Me.images.Image = Image.FromFile("D:\documents\chessimages\bhorse.png")
                End If
            Case "b"
                Me.set_value(Form1.bishopvalue)
                If t = 0 Then

                    Me.images.Image = Image.FromFile("D:\documents\chessimages\whitebich.png")
                Else

                    Me.images.Image = Image.FromFile("D:\documents\chessimages\bbich.png")
                End If
            Case "q"
                Me.set_value(Form1.queenvalue)
                If t = 0 Then

                    Me.images.Image = Image.FromFile("D:\documents\chessimages\wqueen.png")
                Else

                    Me.images.Image = Image.FromFile("D:\documents\chessimages\bqueen.png")
                End If
            Case "k"
                If t = 0 Then
                    Me.images.Image = Image.FromFile("D:\documents\chessimages\wking.png")
                Else
                    Me.images.Image = Image.FromFile("D:\documents\chessimages\bking.png")
                End If
            Case "_"

                Me.images.Image = Image.FromFile("D:\documents\chessimages\blankse.png")


        End Select


    End Sub
    Public Sub setmoves(ByVal mov As List(Of Form1.position))
        For Each M In mov
            Me.move.Add(M)
        Next
    End Sub

End Class
