Public Class theboardclass
    Protected piece As pieces
    Private Is_checkmate As Boolean
    Public Sub set_checkmate(ByVal CHECK As Boolean)
        Me.Is_checkmate = CHECK
    End Sub
    Public Sub set_hasmoved(ByVal bool As Boolean)
        Me.piece.has_moved(bool)
    End Sub
    Public Function get_checkmate_status()
        Return Is_checkmate
    End Function
    Public Function getvalue()
        Return Me.piece.get_value
    End Function
    Public Sub New(ByVal p, ByVal t)
        Me.piece = New pieces
        Me.piece.setpiece(p, t)
    End Sub
    Public Sub setpiece(ByVal s As String, ByVal t As Integer)
        Me.piece.setpiece(s, t)
    End Sub
    Public Function getpiece()
        Return Me.piece
    End Function
    Public Function getsym()
        Return Me.piece.getsym
    End Function
    Public Sub resetimage()
        Me.piece.resetimage()
    End Sub
    Public Sub setimageselected()
        Me.piece.setimageselected()
    End Sub
    Public Sub set_value(ByVal values)
        Me.piece.set_value(values)
    End Sub
    Public Sub calculatemoves(ByVal board(,) As theboardclass, ByVal whosgo As Integer)
        Dim oppteam As Integer

        If Me.piece.getteam = 0 Then
            oppteam = 1
        Else
            oppteam = 0
        End If

        Select Case Me.piece.getsym
            Case "c"
                Me.getstraightmoves(oppteam, board)
                '----------------------------------------------------------------------------------
            Case "p"
                Me.getpawnmoves(oppteam, board)
                '----------------------------------------------------------------------------------
            Case "h"
                Me.gethorsemoves(oppteam, board)
                '----------------------------------------------------------------------------------
            Case "b"
                Me.getdiagonalmove(oppteam, board)
                '----------------------------------------------------------------------------------
            Case "q"
                Me.getstraightmoves(oppteam, board)
                Me.getdiagonalmove(oppteam, board)
                '----------------------------------------------------------------------------------
            Case "k"
                Me.calculatekingmoves(board, whosgo)
        End Select
    End Sub
    Public Sub set_has_moved_2(ByVal bool)
        Me.piece.is_pawn_move_two_space_set(bool)

    End Sub
    Public Sub Change_king_p(ByVal x, ByVal y)
        Me.piece.changekingtochecked(x, y)
    End Sub
    
    Private Sub kingmoves(ByVal x As Integer, ByVal y As Integer, ByVal iscastling As Boolean)
        Dim isokay As Boolean = False
        If Form1.first_time = False Then
            If Me.getteam = 1 Then

                For xs = 0 To Form1.zerolistofincheckplaces.Count - 1
                    If Form1.zerolistofincheckplaces(xs).x = x And Form1.zerolistofincheckplaces(xs).y = y Then
                        isokay = True
                    End If
                Next
            ElseIf Me.getteam = 0 Then
                For xs = 0 To Form1.onelistofincheckplaces.Count - 1

                    If Form1.onelistofincheckplaces(xs).x = x And Form1.onelistofincheckplaces(xs).y = y Then
                        isokay = True
                    End If
                Next
            End If
            


            If Form1.checked = True Then
                If isokay = False Then
                    Select Case Form1.incheckpiece.direction
                        Case "right"
                            If x = Me.getx + 1 And y = Me.gety Then
                                isokay = True
                            End If
                        Case "left"
                            If x = Me.getx - 1 And y = Me.gety Then
                                isokay = True
                            End If
                        Case "down"
                            If x = Me.getx And y = Me.gety + 1 Then
                                isokay = True
                            End If
                        Case "up"
                            If x = Me.getx And y = Me.gety - 1 Then
                                isokay = True
                            End If
                        Case "downleft"
                            If x = Me.getx - 1 And y = Me.gety + 1 Then
                                isokay = True
                            End If
                        Case "downright"
                            If x = Me.getx + 1 And y = Me.gety + 1 Then
                                isokay = True
                            End If
                        Case "upleft"
                            If x = Me.getx - 1 And y = Me.gety - 1 Then
                                isokay = True
                            End If
                        Case "upright"
                            If x = Me.getx + 1 And y = Me.gety - 1 Then
                                isokay = True
                            End If
                    End Select
                End If
                


                
            End If


            If isokay = False Then
                If Form1.board(x, y).getsym <> "k" Then
                    Me.piece.addmoves(x, y, iscastling, False)
                End If
            End If


        Else
            Dim newpos As Form1.position
            newpos.x = x
            newpos.y = y
            If Me.getteam = 0 Then

                Form1.zerolistofincheckplaces.Add(newpos)
            ElseIf Me.getteam = 1 Then
                Form1.onelistofincheckplaces.Add(newpos)

            End If
            Me.piece.addmoves(x, y, False, False)

        End If


    End Sub
    Public Sub resetmoves()
        Me.piece.resetmoves()
    End Sub
    Public Sub addcheckmoves(ByVal x, ByVal y)
        Me.piece.addcheckmoves(x, y)
    End Sub
    Public Sub set_image(ByVal path As String)

    End Sub
    Public Function getmoves() As List(Of Form1.position)

        Return Me.piece.getmoves
    End Function
    Public Function Get_hasmoved()

        Return Me.piece.get_hasmoved
    End Function
    
    Public Sub calculatekingmoves(ByVal board(,) As theboardclass, ByVal whosgo As Integer)
        Dim isokay As Boolean = False
        'castling
        If Form1.first_time = False Then
            Select Case Me.getteam
                Case 0

                    'left
                    isokay = False
                    If Me.piece.get_hasmoved = False And Form1.board(0, 0).getsym = "c" And Form1.board(0, 0).Get_hasmoved = False Then

                        For x = Me.getx - 1 To 1 Step -1
                            For Each M In Form1.onelistofincheckplaces
                                If Form1.board(x, 0).getsym <> "_" Or M.x = x And M.y = 0 Then

                                    If isokay = True Then
                                        Exit For
                                    End If
                                    If x <> 1 Or Form1.board(x, 0).getsym <> "_" Then
                                        isokay = True
                                    End If

                                End If
                            Next
                        Next
                        If isokay = False Then
                            Form1.CastlePublicLetter &= "Q"

                            Me.kingmoves(Me.getx - 2, 0, True)

                        End If

                    End If
                    'right
                    isokay = False

                    If Me.piece.get_hasmoved = False And Form1.board(7, 0).getsym = "c" And Form1.board(7, 0).Get_hasmoved = False Then


                        For x = Me.getx + 1 To 6
                            For Each M In Form1.onelistofincheckplaces
                                If Form1.board(x, 0).getsym <> "_" Or M.x = x And M.y = 0 Then
                                    If isokay = True Then
                                        Exit For
                                    End If

                                    isokay = True
                                End If
                            Next
                        Next
                        If isokay = False Then
                            Form1.CastlePublicLetter &= "K"

                            Me.kingmoves(Me.getx + 2, 0, True)


                        End If

                    End If
                Case 1

                    'left
                    isokay = False
                    If Me.piece.get_hasmoved = False And Form1.board(0, 7).getsym = "c" And Form1.board(0, 7).Get_hasmoved = False Then

                        For x = Me.getx - 1 To 1 Step -1
                            For Each M In Form1.zerolistofincheckplaces
                                If Form1.board(x, 7).getsym <> "_" Or M.x = x And M.y = 7 Then
                                    If isokay = True Then
                                        Exit For
                                    End If

                                    isokay = True
                                End If
                            Next
                        Next
                        If isokay = False Then
                            Form1.CastlePublicLetter &= "q"

                            Me.kingmoves(Me.getx - 2, 7, True)


                        End If

                    End If
                    'right
                    isokay = False
                    If Me.piece.get_hasmoved = False And Form1.board(7, 7).getsym = "c" And Form1.board(7, 7).Get_hasmoved = False Then

                        For x = Me.getx + 1 To 6
                            For Each M In Form1.zerolistofincheckplaces
                                If Form1.board(x, 7).getsym <> "_" Or M.x = x And M.y = 7 Then
                                    If isokay = True Then
                                        Exit For
                                    End If
                                    If x <> 1 Or Form1.board(x, 7).getsym <> "_" Then
                                        isokay = True
                                    End If


                                End If
                            Next


                        Next
                        If isokay = False Then
                            Form1.CastlePublicLetter &= "k"

                            Me.kingmoves(Me.getx + 2, 7, True)

                        End If

                    End If
            End Select
            If Me.piece.getx - 1 >= 0 And Me.piece.gety - 1 >= 0 Then
                If board(Me.piece.getx - 1, Me.piece.gety - 1).getteam <> Me.getteam Then
                    Me.kingmoves(Me.piece.getx - 1, Me.piece.gety - 1, False)
                End If
            End If


            If Me.piece.getx + 1 <= 7 And Me.piece.gety - 1 >= 0 Then
                If board(Me.piece.getx + 1, Me.piece.gety - 1).getteam <> Me.getteam Then

                    Me.kingmoves(Me.piece.getx + 1, Me.piece.gety - 1, False)
                End If
            End If


            If Me.piece.getx - 1 >= 0 And Me.piece.gety + 1 <= 7 Then
                If board(Me.piece.getx - 1, Me.piece.gety + 1).getteam <> Me.getteam Then
                    Me.kingmoves(Me.piece.getx - 1, Me.piece.gety + 1, False)
                End If
            End If

            If Me.piece.getx + 1 <= 7 And Me.piece.gety + 1 <= 7 Then
                If board(Me.piece.getx + 1, Me.piece.gety + 1).getteam <> Me.getteam Then
                    Me.kingmoves(Me.piece.getx + 1, Me.piece.gety + 1, False)
                End If
            End If
            '--------------------------------------------




            If Me.piece.getx - 1 >= 0 Then
                If board(Me.piece.getx - 1, Me.piece.gety).getteam <> Me.getteam Then
                    Me.kingmoves(Me.piece.getx - 1, Me.piece.gety, False)
                End If
            End If

            If Me.piece.gety - 1 >= 0 Then
                If board(Me.piece.getx, Me.piece.gety - 1).getteam <> Me.getteam Then
                    Me.kingmoves(Me.piece.getx, Me.piece.gety - 1, False)
                End If
            End If

            If Me.piece.getx + 1 <= 7 Then
                If board(Me.piece.getx + 1, Me.piece.gety).getteam <> Me.getteam Then
                    Me.kingmoves(Me.piece.getx + 1, Me.piece.gety, False)
                End If
            End If
            If Me.piece.gety + 1 <= 7 Then
                If board(Me.piece.getx, Me.piece.gety + 1).getteam <> Me.getteam Then
                    Me.kingmoves(Me.piece.getx, Me.piece.gety + 1, False)
                End If
            End If
        Else
            If Me.piece.getx - 1 >= 0 And Me.piece.gety - 1 >= 0 Then

                Me.kingmoves(Me.piece.getx - 1, Me.piece.gety - 1, False)

        End If


        If Me.piece.getx + 1 <= 7 And Me.piece.gety - 1 >= 0 Then


                Me.kingmoves(Me.piece.getx + 1, Me.piece.gety - 1, False)

        End If


        If Me.piece.getx - 1 >= 0 And Me.piece.gety + 1 <= 7 Then

                Me.kingmoves(Me.piece.getx - 1, Me.piece.gety + 1, False)

        End If

        If Me.piece.getx + 1 <= 7 And Me.piece.gety + 1 <= 7 Then

                Me.kingmoves(Me.piece.getx + 1, Me.piece.gety + 1, False)

        End If
        '--------------------------------------------




        If Me.piece.getx - 1 >= 0 Then

            Me.kingmoves(Me.piece.getx - 1, Me.piece.gety, False)

        End If

        If Me.piece.gety - 1 >= 0 Then

            Me.kingmoves(Me.piece.getx, Me.piece.gety - 1, False)

        End If

        If Me.piece.getx + 1 <= 7 Then

            Me.kingmoves(Me.piece.getx + 1, Me.piece.gety, False)

        End If
        If Me.piece.gety + 1 <= 7 Then

            Me.kingmoves(Me.piece.getx, Me.piece.gety + 1, False)

        End If
        End If
        









    End Sub

    Public Function getteam()
        Return Me.piece.getteam
    End Function
    Public Function gety()
        Return Me.piece.gety
    End Function
    Public Function getx()
        Return Me.piece.getx
    End Function
    Private Sub getpawnmoves(ByVal oppteam As Integer, ByVal board(,) As theboardclass)
        Dim pos As Form1.position
        
        If Me.piece.getteam = 0 Then
            If Me.piece.gety = 7 Then
                'If Form1.is_ai_calulating = False Then
                '    'If Me.getteam <> Form1.AIPLAYER.get_team Then

                '    '    Promotion.team_of_proting_pawn = 1
                '    '    Promotion.promotion_place.x = Me.piece.getx
                '    '    Promotion.promotion_place.y = Me.piece.gety
                '    '    MsgBox(Form1.board(Promotion.promotion_place.x, Promotion.promotion_place.y).getsym & " at x: " & Promotion.promotion_place.x & " and y: " & Promotion.promotion_place.y)
                '    '    Promotion.Show()


                '    'Else
                '    '    Promotion.promotion_place.x = Me.piece.getx
                '    '    Promotion.promotion_place.y = Me.piece.gety
                '    '    Form1.board(Promotion.promotion_place.x, Promotion.promotion_place.y).setpiece("q", Form1.board(Promotion.promotion_place.x, Promotion.promotion_place.y).getteam)

                '    'End If
                'End If
            Else
                If Me.piece.gety = 1 Then
                    If board(Me.piece.getx, Me.piece.gety + 1).getteam = 2 Then
                        Me.piece.addmoves(Me.piece.getx, Me.piece.gety + 1, False, False)
                        If board(Me.piece.getx, Me.piece.gety + 2).getteam = 2 Then
                            Me.piece.addmoves(Me.piece.getx, Me.piece.gety + 2, False, False)
                        End If
                    End If

                Else
                    If board(Me.piece.getx, Me.piece.gety + 1).getteam = 2 Then
                        Me.piece.addmoves(Me.piece.getx, Me.piece.gety + 1, False, False)
                    End If
                End If
                If Me.piece.getx < 7 Then
                    If board(Me.piece.getx + 1, Me.piece.gety + 1).getteam = oppteam Then

                        Me.piece.addmoves(Me.piece.getx + 1, Me.piece.gety + 1, False, False)
                    ElseIf (board(Me.piece.getx + 1, Me.piece.gety).getteam = oppteam And board(Me.piece.getx + 1, Me.piece.gety).can_el_pasentfunc) Then
                        Me.piece.addmoves(Me.piece.getx + 1, Me.piece.gety + 1, False, True)

                   
                    End If
                    Me.piece.addunderattack(Me.piece.getx + 1, Me.piece.gety + 1)
                    pos.x = Me.piece.getx + 1
                    pos.y = Me.piece.gety + 1
                    Form1.WHITEPawnmoves.Add(pos)
                End If
                If Me.piece.getx > 0 Then
                    If board(Me.piece.getx - 1, Me.piece.gety + 1).getteam = oppteam Then
                        Me.piece.addmoves(Me.piece.getx - 1, Me.piece.gety + 1, False, False)
                    ElseIf (board(Me.piece.getx - 1, Me.piece.gety).getteam = oppteam And board(Me.piece.getx - 1, Me.piece.gety).can_el_pasentfunc) Then
                        Me.piece.addmoves(Me.piece.getx - 1, Me.piece.gety + 1, False, True)
                       
                    End If
                    Me.piece.addunderattack(Me.piece.getx - 1, Me.piece.gety + 1)
                    pos.x = Me.piece.getx - 1
                    pos.y = Me.piece.gety + 1
                    Form1.WHITEPawnmoves.Add(pos)
                End If
            End If



        Else
            If Me.piece.gety = 0 Then

                If Form1.is_ai_calulating = False Then
                    If Me.getteam <> Form1.AIPLAYER.get_team Then

                        Promotion.team_of_proting_pawn = 1
                        Promotion.promotion_place.x = Me.piece.getx
                        Promotion.promotion_place.y = Me.piece.gety
                        Promotion.Show()

                    Else
                        Promotion.promotion_place.x = Me.piece.getx
                        Promotion.promotion_place.y = Me.piece.gety
                        Form1.board(Promotion.promotion_place.x, Promotion.promotion_place.y).setpiece("q", Form1.board(Promotion.promotion_place.x, Promotion.promotion_place.y).getteam)
                    End If
                End If



            Else
                If Me.piece.gety = 6 Then
                    If board(Me.piece.getx, Me.piece.gety - 1).getteam = 2 Then
                        Me.piece.addmoves(Me.piece.getx, Me.piece.gety - 1, False, False)
                        If board(Me.piece.getx, Me.piece.gety - 2).getteam = 2 Then

                            Me.piece.addmoves(Me.piece.getx, Me.piece.gety - 2, False, False)
                        End If
                    End If

                Else
                    If board(Me.piece.getx, Me.piece.gety - 1).getteam = 2 Then
                        Me.piece.addmoves(Me.piece.getx, Me.piece.gety - 1, False, False)
                    End If
                End If
                If Me.piece.getx < 7 Then
                    If board(Me.piece.getx + 1, Me.piece.gety - 1).getteam = oppteam Then
                        Me.piece.addmoves(Me.piece.getx + 1, Me.piece.gety - 1, False, False)
                    ElseIf (board(Me.piece.getx + 1, Me.piece.gety).getteam = oppteam And board(Me.piece.getx + 1, Me.piece.gety).can_el_pasentfunc) Then
                        Me.piece.addmoves(Me.piece.getx + 1, Me.piece.gety - 1, False, True)


                    End If
                    pos.x = Me.piece.getx + 1
                    pos.y = Me.piece.gety - 1
                    Form1.BLACKPawnmoves.Add(pos)
                    Me.piece.addunderattack(Me.piece.getx + 1, Me.piece.gety - 1)
                End If
                If Me.piece.getx > 0 Then
                    If board(Me.piece.getx - 1, Me.piece.gety - 1).getteam = oppteam Then
                        Me.piece.addmoves(Me.piece.getx - 1, Me.piece.gety - 1, False, False)
                    ElseIf (board(Me.piece.getx - 1, Me.piece.gety).getteam = oppteam And board(Me.piece.getx - 1, Me.piece.gety).can_el_pasentfunc) Then
                        Me.piece.addmoves(Me.piece.getx - 1, Me.piece.gety - 1, False, True)


                    End If
                    pos.x = Me.piece.getx - 1
                    pos.y = Me.piece.gety - 1
                    Form1.BLACKPawnmoves.Add(pos)
                    Me.piece.addunderattack(Me.piece.getx - 1, Me.piece.gety - 1)
                End If
            End If

        End If
        
    End Sub
    Public Function can_el_pasentfunc()
        Return Me.piece.return_el_pasent
    End Function
    Public Sub set_round_2_moves(ByVal num As Integer)
        Me.piece.set_round_moved_2(num)
    End Sub
    Private Sub gethorsemoves(ByVal oppteam As Integer, ByVal board(,) As theboardclass)
        
        For x = -2 To 2
            If x <> 0 Then
                For y = -2 To 2
                    If y <> 0 Then

                        If Me.piece.getx + x > -1 And Me.piece.getx + x < 8 And Me.piece.gety + y < 8 And Me.piece.gety + y > -1 Then

                            If InStr(Str(y), "2") > 0 And InStr(Str(x), "2") > 0 Then
                            Else
                                If InStr(Str(y), "1") > 0 And InStr(Str(x), "1") > 0 Then

                                Else

                                    If board(Me.piece.getx + x, Me.piece.gety + y).piece.getteam <> Me.piece.getteam Then
                                        Me.piece.addmoves(Me.piece.getx + x, Me.piece.gety + y, False, False)
                                        Me.piece.addunderattack(Me.piece.getx + x, Me.piece.gety + y)
                                    Else
                                        Me.piece.addunderattack(Me.piece.getx + x, Me.piece.gety + y)

                                    End If

                                End If

                            End If
                        End If

                    End If
                Next
            End If

        Next
        
    End Sub
    Private Sub whatteam(ByVal board(,) As theboardclass, ByVal oppteam As Integer, ByRef x As Integer, ByRef y As Integer, ByVal osupdown As String, ByVal count As Integer, ByVal osup As Boolean)
        Dim isokay As Boolean = False
        Dim xpos As Integer
        Dim ypos As Integer
        Dim new_pos As Form1.position
        If x > -1 And x < 8 And y > -1 And y < 8 Then
            If board(x, y).piece.getteam = oppteam Then
                'If Form1.is_ai_calulating = False Then
                '    MsgBox("")
                'End If
                Me.piece.addmoves(x, y, False, False)
                Me.piece.addunderattack(x, y)
                If board(x, y).getsym = "k" Then

                    For ii = Me.piece.getmoves.Count - 1 - count To Me.piece.getmoves.Count - 1
                        If ii >= 0 Then
                            Form1.incheckpiece.moves.Add(Me.piece.getmoves(ii))
                        End If

                    Next
                Else
                    Dim xx As Integer = x
                    isokay = False
                    Select Case osupdown

                        Case "lu"
                            xx -= 1
                            For yy = y - 1 To 0 Step -1
                                If xx > 0 Then

                                    If board(xx, yy).getsym = "k" And board(xx, yy).getteam = oppteam Then
                                        If Me.getteam = 0 Then

                                            new_pos.x = x
                                            new_pos.y = y
                                            Form1.pinned.teamwhite.Add(new_pos)

                                            new_pos.x = Me.piece.getx
                                            new_pos.y = Me.piece.gety
                                            Form1.pinned.piecepinningwhite.Add(new_pos)
                                        ElseIf Me.getteam = 1 Then

                                            new_pos.x = x
                                            new_pos.y = y
                                            Form1.pinned.teamblack.Add(new_pos)

                                            new_pos.x = Me.piece.getx
                                            new_pos.y = Me.piece.gety
                                            Form1.pinned.piecepinningblack.Add(new_pos)
                                        End If

                                        yy = 0
                                    End If
                                    xx -= 1
                                Else
                                    yy = 0
                                End If
                            Next


                            '------------------------------------------------------------------
                        Case "ld"
                            xx -= 1
                            For yy = y + 1 To 7 Step 1
                                If xx >= 0 Then

                                    If board(xx, yy).getsym = "k" And board(xx, yy).getteam = oppteam Then
                                        If Me.getteam = 0 Then
                                            new_pos.x = x
                                            new_pos.y = y
                                            Form1.pinned.teamwhite.Add(new_pos)
                                            new_pos.x = Me.piece.getx
                                            new_pos.y = Me.piece.gety
                                            Form1.pinned.piecepinningwhite.Add(new_pos)


                                        ElseIf Me.getteam = 1 Then
                                            new_pos.x = x
                                            new_pos.y = y
                                            Form1.pinned.teamblack.Add(new_pos)
                                            new_pos.x = Me.piece.getx
                                            new_pos.y = Me.piece.gety
                                            Form1.pinned.piecepinningblack.Add(new_pos)

                                        End If


                                        yy = 7

                                    End If



                                    xx -= 1
                                Else
                                    yy = 7
                                End If


                            Next
                            '-----------------------------------------------



                        Case "rd"
                            xx += 1
                            For yy = y + 1 To 7 Step 1
                                If xx < 7 Then

                                    If board(xx, yy).getsym = "k" And board(xx, yy).getteam = oppteam Then
                                        If Me.getteam = 0 Then
                                            new_pos.x = x
                                            new_pos.y = y
                                            Form1.pinned.teamwhite.Add(new_pos)
                                            new_pos.x = Me.piece.getx
                                            new_pos.y = Me.piece.gety
                                            Form1.pinned.piecepinningwhite.Add(new_pos)
                                        ElseIf Me.getteam = 1 Then
                                            new_pos.x = x
                                            new_pos.y = y
                                            Form1.pinned.teamblack.Add(new_pos)
                                            new_pos.x = Me.piece.getx
                                            new_pos.y = Me.piece.gety
                                            Form1.pinned.piecepinningblack.Add(new_pos)
                                        End If

                                        yy = 7
                                    End If
                                    xx += 1
                                Else
                                    yy = 7
                                End If
                            Next

                            '-----------------
                        Case "ru"
                            xx += 1
                            For yy = y - 1 To 0 Step -1
                                If xx < 7 Then

                                    If board(xx, yy).getsym = "k" And board(xx, yy).getteam = oppteam Then
                                        If Me.getteam = 0 Then
                                            new_pos.x = x
                                            new_pos.y = y
                                            Form1.pinned.teamwhite.Add(new_pos)
                                            new_pos.x = Me.piece.getx
                                            new_pos.y = Me.piece.gety
                                            Form1.pinned.piecepinningwhite.Add(new_pos)
                                        ElseIf Me.getteam = 1 Then
                                            new_pos.x = x
                                            new_pos.y = y
                                            Form1.pinned.teamblack.Add(new_pos)
                                            new_pos.x = Me.piece.getx
                                            new_pos.y = Me.piece.gety
                                            Form1.pinned.piecepinningblack.Add(new_pos)
                                        End If

                                        yy = 0
                                    End If
                                    xx += 1
                                Else
                                    yy = 0
                                End If


                            Next
                    End Select
                End If

                If osup = False Then
                    x = 7
                Else
                    x = 0
                End If
            ElseIf board(x, y).piece.getteam = 2 Then
                Me.piece.addmoves(x, y, False, False)
                Me.piece.addunderattack(x, y)
            Else
                Me.piece.addunderattack(x, y)
                If osup = False Then
                    x = 7
                Else
                    x = 0
                End If
            End If
        End If



    End Sub
    Private Sub getstraightmoves(ByVal oppteam As Integer, ByVal board(,) As theboardclass)
        Dim isokay As Boolean = False
        Dim whpawncount As Integer = 0
        Dim blpawncount As Integer = 0
        'right
        Dim new_pos As Form1.position
        For x = Me.piece.getx + 1 To 7
            If board(x, Me.piece.gety).piece.getteam = 2 Then
                Me.piece.addmoves(x, Me.piece.gety, False, False)
                Me.piece.addunderattack(x, Me.piece.gety)
            ElseIf board(x, Me.piece.gety).piece.getteam = oppteam And board(x, Me.piece.gety).piece.getsym = "k" Then
                Me.piece.addmoves(x, Me.piece.gety, False, False)
                Me.piece.addunderattack(x, Me.piece.gety)

                For xx = Me.piece.getx + 1 To x

                    new_pos.x = xx
                    new_pos.y = Me.piece.gety
                    Form1.incheckpiece.moves.Add(new_pos)
                Next
                x = 7
            ElseIf board(x, Me.piece.gety).piece.getteam = oppteam Then

                Me.piece.addmoves(x, Me.piece.gety, False, False)

                Me.piece.addunderattack(x, Me.piece.gety)


                For ii = x + 1 To 7
                    If board(ii, Me.piece.gety).getteam = oppteam And board(ii, Me.piece.gety).getsym = "k" Then
                        If Me.getteam = 0 Then

                            new_pos.x = x
                            new_pos.y = Me.piece.gety
                            Form1.pinned.teamwhite.Add(new_pos)

                            new_pos.x = Me.piece.getx
                            new_pos.y = Me.piece.gety
                            Form1.pinned.piecepinningwhite.Add(new_pos)

                        ElseIf Me.getteam = 1 Then

                            new_pos.x = x
                            new_pos.y = Me.piece.gety
                            Form1.pinned.teamblack.Add(new_pos)

                            new_pos.x = Me.piece.getx
                            new_pos.y = Me.piece.gety
                            Form1.pinned.piecepinningblack.Add(new_pos)

                        End If
                    ElseIf board(ii, Me.piece.gety).getteam = Me.getteam Then
                        'If board(ii, Me.piece.gety).getsym = "p" Then

                        '    If board(ii + 1, Me.piece.gety).getsym = "p" Then
                        '        Select Case board(ii, Me.piece.gety).getteam
                        '            Case 0
                        '                If board(ii + 1, Me.piece.gety).getteam = 1 Then
                        '                    board(ii + 1, Me.piece.gety).set_has_moved_2(False)
                        '                    board(ii, Me.piece.gety).set_has_moved_2(False)
                        '                    board(ii + 1, Me.piece.gety).calculatemoves(Form1.board, Me.getteam)
                        '                    board(ii, Me.piece.gety).calculatemoves(Form1.board, Me.getteam)
                        '                End If
                        '            Case 1
                        '                If board(ii + 1, Me.piece.gety).getteam = 0 Then
                        '                    board(ii + 1, Me.piece.gety).set_has_moved_2(False)
                        '                    board(ii, Me.piece.gety).set_has_moved_2(False)

                        '                End If

                        '        End Select
                        '    End If
                        'End If
                        ii = 7




                        End If
                Next
                x = 7
            Else
              
                Me.piece.addunderattack(x, Me.piece.gety)
                x = 7
            End If
        Next

        '------------
        'left

        For x = Me.piece.getx - 1 To 0 Step -1
            If board(x, Me.piece.gety).piece.getteam = 2 Then
                Me.piece.addmoves(x, Me.piece.gety, False, False)
                Me.piece.addunderattack(x, Me.piece.gety)
            ElseIf board(x, Me.piece.gety).piece.getteam = oppteam And board(x, Me.piece.gety).piece.getsym = "k" Then
                Me.piece.addmoves(x, Me.piece.gety, False, False)
                Me.piece.addunderattack(x, Me.piece.gety)


                For xx = Me.piece.getx - 1 To x Step -1

                    new_pos.x = xx
                    new_pos.y = Me.piece.gety
                    Form1.incheckpiece.moves.Add(new_pos)
                Next

                x = 0
            ElseIf board(x, Me.piece.gety).piece.getteam = oppteam Then
                For ii = x - 1 To 0 Step -1
                    If board(ii, Me.piece.gety).getteam = oppteam And board(ii, Me.piece.gety).getsym = "k" Then
                        If Me.getteam = 0 Then


                            new_pos.x = x
                            new_pos.y = Me.piece.gety
                            Form1.pinned.teamwhite.Add(new_pos)


                            new_pos.x = Me.piece.getx
                            new_pos.y = Me.piece.gety
                            Form1.pinned.piecepinningwhite.Add(new_pos)
                        ElseIf Me.getteam = 1 Then



                            new_pos.x = x
                            new_pos.y = Me.piece.gety
                            Form1.pinned.teamblack.Add(new_pos)

                            new_pos.x = Me.piece.getx
                            new_pos.y = Me.piece.gety
                            Form1.pinned.piecepinningblack.Add(new_pos)
                        End If
                    ElseIf board(ii, Me.piece.gety).getteam = Me.piece.getteam Then
                        ii = 0
                    End If
                Next
                Me.piece.addmoves(x, Me.piece.gety, False, False)

                Me.piece.addunderattack(x, Me.piece.gety)
                x = 0
            Else

                Me.piece.addunderattack(x, Me.piece.gety)
                x = 0
            End If
        Next
        '----------------------------------------------------------------------

        'down

        For y = Me.piece.gety + 1 To 7
            If board(Me.piece.getx, y).piece.getteam = 2 Then
                Me.piece.addmoves(Me.piece.getx, y, False, False)
                Me.piece.addunderattack(Me.piece.getx, y)
            ElseIf board(Me.piece.getx, y).piece.getteam = oppteam And board(Me.piece.getx, y).piece.getsym = "k" Then
                Me.piece.addmoves(Me.piece.getx, y, False, False)
                Me.piece.addunderattack(Me.piece.getx, y)

                For yy = Me.piece.gety + 1 To y

                    new_pos.x = Me.piece.getx
                    new_pos.y = yy
                    Form1.incheckpiece.moves.Add(new_pos)
                Next

                y = 7
            ElseIf board(Me.piece.getx, y).piece.getteam = oppteam Then

                Me.piece.addmoves(Me.piece.getx, y, False, False)
                Me.piece.addunderattack(Me.piece.getx, y)
                For ii = y + 1 To 7
                    If board(Me.piece.getx, ii).getteam = oppteam And board(Me.piece.getx, ii).getsym = "k" Then
                        If Me.getteam = 0 Then


                            new_pos.x = Me.piece.getx
                            new_pos.y = y
                            Form1.pinned.teamwhite.Add(new_pos)
                            new_pos.x = Me.piece.getx
                            new_pos.y = Me.piece.gety
                            Form1.pinned.piecepinningwhite.Add(new_pos)
                        ElseIf Me.getteam = 1 Then


                            new_pos.x = Me.piece.getx
                            new_pos.y = y
                            Form1.pinned.teamblack.Add(new_pos)
                            new_pos.x = Me.piece.getx
                            new_pos.y = Me.piece.gety
                            Form1.pinned.piecepinningblack.Add(new_pos)
                        End If
                    ElseIf board(Me.piece.getx, ii).getteam = Me.piece.getteam Then
                        ii = 7
                    End If
                Next
                y = 7
            Else
                Me.piece.addunderattack(Me.piece.getx, y)
                y = 7
            End If
        Next
        'up
        For y = Me.piece.gety - 1 To 0 Step -1
            If board(Me.piece.getx, y).piece.getteam = 2 Then
                Me.piece.addmoves(Me.piece.getx, y, False, False)
                Me.piece.addunderattack(Me.piece.getx, y)
            ElseIf board(Me.piece.getx, y).piece.getteam = oppteam And board(Me.piece.getx, y).piece.getsym = "k" Then
                Me.piece.addmoves(Me.piece.getx, y, False, False)
                Me.piece.addunderattack(Me.piece.getx, y)

                For yy = Me.piece.gety + 1 To y

                    new_pos.x = Me.piece.getx
                    new_pos.y = yy
                    Form1.incheckpiece.moves.Add(new_pos)
                Next

                y = 0
            ElseIf board(Me.piece.getx, y).piece.getteam = oppteam Then

                Me.piece.addmoves(Me.piece.getx, y, False, False)
                Me.piece.addunderattack(Me.piece.getx, y)
                For ii = y - 1 To 0 Step -1
                    If board(Me.piece.getx, ii).getteam = oppteam And board(Me.piece.getx, ii).getsym = "k" Then
                        If Me.getteam = 0 Then

                            new_pos.x = Me.piece.getx
                            new_pos.y = y
                            Form1.pinned.teamwhite.Add(new_pos)
                            new_pos.x = Me.piece.getx
                            new_pos.y = Me.piece.gety
                            Form1.pinned.piecepinningwhite.Add(new_pos)
                        ElseIf Me.getteam = 1 Then

                            new_pos.x = Me.piece.getx
                            new_pos.y = y
                            Form1.pinned.teamblack.Add(new_pos)
                            new_pos.x = Me.piece.getx
                            new_pos.y = Me.piece.gety
                            Form1.pinned.piecepinningblack.Add(new_pos)
                        End If
                    ElseIf board(Me.piece.getx, ii).getteam = Me.piece.getteam Then
                        ii = 0
                    End If
                Next
                y = 0
            Else
                Me.piece.addunderattack(Me.piece.getx, y)
                y = 0
            End If
        Next
    End Sub
    Public Sub getdiagonalmove(ByVal oppteam As Integer, ByVal board(,) As theboardclass)
        Dim y As Integer
        Dim osupdown As String
        Dim ydown As Boolean = False
        Dim count As Integer = 0
        Dim osup As Boolean
        'right down
        y = Me.piece.gety + 1
        osupdown = "rd"
        osup = False
        ydown = False
        For x = Me.piece.getx + 1 To 7
            Me.whatteam(board, oppteam, x, y, osupdown, count, osup)

            y += 1
            count += 1

        Next
        'right up
        count = 0
        y = Me.piece.gety - 1
        osupdown = "ru"
        osup = False
        ydown = True
        For x = Me.piece.getx + 1 To 7
            Me.whatteam(board, oppteam, x, y, osupdown, count, osup)
            y -= 1
            count += 1
        Next
        'left down
        count = 0
        y = Me.piece.gety + 1
        osupdown = "ld"
        osup = True
        ydown = False
        For x = Me.piece.getx - 1 To 0 Step -1
            Me.whatteam(board, oppteam, x, y, osupdown, count, osup)
            y += 1
            count += 1
        Next
        'left up

        y = Me.piece.gety - 1
        count = 0
        osupdown = "lu"
        osup = True
        ydown = True
        For x = Me.piece.getx - 1 To 0 Step -1
            Me.whatteam(board, oppteam, x, y, osupdown, count, osup)
            y -= 1
            count += 1
        Next

    End Sub
    Public Sub setmoves(ByVal mov As List(Of Form1.position))
        Me.piece.setmoves(mov)
    End Sub
End Class
