Public Class Form1
    Structure checkpiece
        Dim x As Integer
        Dim y As Integer
        Dim sy As String
        Dim xdiff As Integer
        Dim ydiff As Integer
        Dim kingmove As position
        Dim moves As List(Of position)
        Dim blockablepositions As List(Of position)
        Dim team As Integer
        Dim can_be_blocked As Boolean
        Dim Can_Be_taken As Boolean

        Dim direction As String
    End Structure
    Structure move_count
        Dim moves_count As Integer
        Dim captures As Integer
        Dim checkmates As Integer
        Dim checks As Integer
        Dim castles As Integer
        Dim al_pasents As Integer
    End Structure
    Structure A_Move
        Dim is_castling As Boolean
        Dim is_al_pasent As Boolean
        Dim From_x As Integer
        Dim From_Y As Integer
        Dim New_x As Integer
        Dim New_Y As Integer
        Dim Number As Integer
        Dim risk As Integer
        Dim Sym_being_taken As String
        Dim sym_of_moving_piece As String
        Dim team_of_moving_p As Integer
        Dim team_of_new_pos As Integer
        Dim Moves As List(Of Form1.position)
        Dim from_value As Integer
        Dim new_value As Integer
        Dim Move_Score_guess As Integer
        Dim ischecking As Boolean
    End Structure
    Public Structure options
        Dim Playing_Agaisnt_AI As Boolean
        Dim AI_vs_AI As Boolean
        Dim Player_vs_player As Boolean
        Dim using_FEN As Boolean
        Dim calculating_all_moves_for_test As Boolean

    End Structure
    Public Structure position
        Dim x As Integer
        Dim y As Integer
        Dim Number As Integer
        Dim iscastling As Boolean
        Dim IsAlPasentMove As Boolean
    End Structure
    Structure pinnedlist
        Dim teamwhite As List(Of position)
        Dim teamblack As List(Of position)
        Dim piecepinningwhite As List(Of position)
        Dim piecepinningblack As List(Of position)
        Dim diffofpin As List(Of position)
    End Structure
    Public Const pawnvalue As Integer = 100
    Public Const castlevalue As Integer = 500
    Public Const horsevalue As Integer = 300
    Public Const bishopvalue As Integer = 300
    Public Const queenvalue As Integer = 900
    'saved for whole game
    Public wpawndiff As Integer
    Public wcastlediff As Integer
    Public wbishopsdiff As Integer
    Public whorsediff As Integer
    Public wqueendiff As Integer
    Public AssetFolderPath As String ' just add file name

    Public bpawndiff As Integer
    Public bcastlediff As Integer
    Public bbishopsdiff As Integer
    Public bhorsediff As Integer
    Public bqueendiff As Integer

    Public all_moves As New List(Of AI.Moves)
    Public Move As New A_Move
    Public whitecastled As Boolean = False
    Public blackcastled As Boolean = False

    Public wpawncount As Integer
    Public wcastlecount As Integer
    Public wbishopcount As Integer
    Public whorsecount As Integer
    Public wqueencount As Integer

    Public bpawncount As Integer
    Public bcastlecount As Integer
    Public bbishopcount As Integer
    Public bhorsecount As Integer
    Public bqueencount As Integer
    'saved for each predictedmove
    Public wpawncount2 As Integer
    Public wcastlecount2 As Integer
    Public wbishopcount2 As Integer
    Public whorsecount2 As Integer
    Public wqueencount2 As Integer

    Public bpawncount2 As Integer
    Public bcastlecount2 As Integer
    Public bbishopcount2 As Integer
    Public bhorsecount2 As Integer
    Public bqueencount2 As Integer
    Public list_moves As New List(Of A_Move)
    Public usefulcounter As Integer = 0
    'piece moves
    Public WHITEPawnmoves As New List(Of position)
    'Public WHITEHorsemoves As List(Of position)
    'Public WHITEBishopmoves As List(Of position)
    'Public WHITECastlemoves As List(Of position)
    'Public WHITEQueenmoves As List(Of position)

    Public BLACKPawnmoves As New List(Of position)
    'Public BLACKHorsemoves As List(Of position)
    'Public BLACKBishopmoves As List(Of position)
    'Public BLACKCastlemoves As List(Of position)
    'Public BLACKQueenmoves As List(Of position)



    Public depth_count(5) As Integer

    Public is_ai_calulating As Boolean = False
    Public AI_Move As New position
    Public incheckpiece As New checkpiece

    Public settings As options
    Public canbeblocked As Boolean = False
    Public timer_count As Integer
    Public board(7, 7) As theboardclass
    Public board2(7, 7) As theboardclass
    Public numofwhitepieces As Byte = 16
    Public numofblackpieces As Byte = 16
    Public selectedsquares() As PictureBox
    Public isselectedownalready As Boolean = False
    Public pieceselected As New pieces
    Public rounds As Integer = 0
    Public whosgo As Integer = 0
    Public checked As Boolean = False
    Public checkmate As Boolean = False
    Public whosmated As Integer
    Public opt As Integer
    Public onelistofincheckplaces As New List(Of position)
    Public zerolistofincheckplaces As New List(Of position)
    Public iskingxcheck As Boolean = False
    Public iskingycheck As Boolean = False
    Public pinned As New pinnedlist
    Public AIPLAYER As AI
    Public Aiplayer2 As AI
    Public confirmed As Boolean = False
    Public FEN_STRING_USE As New FEN_Code
    Public first_time As Boolean
    Public FEN_STRING As String
    Public isok As Boolean

    
    Sub createboard2()
        board2 = makeboard(board2)



    End Sub
    

    Public Sub reset()

        ' all piece variables
        Me.WHITEPawnmoves.Clear()
        Me.BLACKPawnmoves.Clear()


        Me.first_time = True

        isok = False
        checkmate = False
        incheckpiece.can_be_blocked = False
        incheckpiece.Can_Be_taken = False

        onelistofincheckplaces.Clear()
        canbeblocked = False

        zerolistofincheckplaces.Clear()

        incheckpiece.blockablepositions.Clear()

        pinned.teamblack.Clear()

        pinned.teamwhite.Clear()

        pinned.piecepinningblack.Clear()
        pinned.piecepinningwhite.Clear()
        checked = False

        incheckpiece.moves.Clear()
        All_moves.Clear()
    End Sub
    Private Function switchgoes(ByVal whosgo_ As Integer)
        If whosgo_ = 1 Then
            opt = 1
            Return 0
        Else
            opt = 0
            Return 1

        End If

    End Function
    Public Sub Game()
        If rounds <> 0 Then
            whosgo = switchgoes(whosgo)
        End If
        reset()
        If settings.Playing_Agaisnt_AI = True Then
            Do Until whosgo <> AIPLAYER.get_team

               

                board = AIPLAYER.get_AImove(Me.board)
                whosgo = switchgoes(whosgo)
                rounds += 1

            Loop
        End If



        
        first_time = True
        checked = False
        For y = 0 To 7
            For x = 0 To 7
                board(x, y).getmoves.Clear()
                'If board(x, y).getsym <> "k" Then
                'If board(x, y).getteam = whosgo Then


                board(x, y).calculatemoves(board, whosgo)

                'End If



                'End If
                ' x = 5 y = 2
            Next
        Next
        'MsgBox(board(5, 1).getmoves.Count)
        If rounds = 999999 Then
            MsgBox(board)
        End If
        For x = 0 To 7
            For y = 0 To 7
                If board(x, y).getsym = "k" Then
                    board(x, y).getmoves.Clear()
                    first_time = False
                    board(x, y).calculatemoves(board, whosgo)
                End If
            Next
        Next
        If checked = True Then
            Dim checkmates As Boolean = True
            Dim isok As Boolean = False
            Dim newlist As New List(Of position)

            For x = 0 To 7
                For y = 0 To 7


                    If board(x, y).getteam <> incheckpiece.team And board(x, y).getteam <> 2 And board(x, y).getsym <> "k" Then

                        newlist.Clear()
                        cantake(x, y, newlist)
                        canblock(x, y, newlist)
                        'If x = 0 And y = 4 Then
                        '    MsgBox("")
                        'End If
                        board(x, y).getmoves.Clear()
                        board(x, y).setmoves(newlist)
                        If newlist.Count > 0 Then
                            isok = True
                        End If
                    End If

                Next
            Next


            newlist = Nothing
        End If

        For M = 1 To pinned.teamblack.Count - 1
            pinned_change_moves(pinned.piecepinningblack(M).x, pinned.piecepinningblack(M).y, pinned.teamblack(M).x, pinned.teamblack(M).y)
        Next
        For M = 1 To pinned.teamwhite.Count - 1
            pinned_change_moves(pinned.piecepinningwhite(M).x, pinned.piecepinningwhite(M).y, pinned.teamwhite(M).x, pinned.teamwhite(M).y)
        Next
        rounds += 1
        Me.isselectedownalready = False



        If checkmate = True Then
            MsgBox("GAME OVER: " & incheckpiece.team & " lost")
            FEN_STRING = FEN_STRING_USE.Save_board(board)
            FileOpen(1, "D:\FEN BOARD SAVE FILES.txt", OpenMode.Append)
            PrintLine(1, FEN_STRING & "   |   WIN")
            MsgBox("Saved Fen In FEN BOARD SAVE FILES.txt")

            FileClose(1)
            Me.Close()

            Exit Sub

        End If
    End Sub
    Public Sub addround()

        reset()
        If checkmate <> True Then
            reset()
            If rounds <> 0 Then
                If whosgo = 0 Then
                    whosgo = 1
                    opt = 0
                Else
                    whosgo = 0
                    opt = 1
                End If
            Else
                opt = 1
            End If

            checked = False
            For x = 0 To 7
                For y = 0 To 7
                    If board(x, y).getsym <> "k" Then
                        'board(x, y).getmoves.Clear()
                        'If board(3, 1).getmoves.Count <> 2 And is_ai_calulating = False Then
                        '    MsgBox(board(3, 1).getmoves.Count & " " & x & y)
                        'ElseIf board(3, 1).getmoves.Count = 2 And is_ai_calulating = False Then
                        '    MsgBox(board(3, 1).getmoves.Count & " " & x & y)
                        'End If
                        board(x, y).calculatemoves(board, whosgo)


                    End If
                    ' x = 5 y = 2
                Next
            Next
            'MsgBox(board(3, 1).getmoves.Count)
            If rounds = 999999 Then
                MsgBox(board)
            End If
            For x = 0 To 7
                For y = 0 To 7
                    If board(x, y).getsym = "k" Then
                        board(x, y).calculatemoves(board, whosgo)
                    End If
                Next
            Next
            If checked = True Then
               
            End If

            For M = 1 To pinned.teamblack.Count - 1
                pinned_change_moves(pinned.piecepinningblack(M).x, pinned.piecepinningblack(M).y, pinned.teamblack(M).x, pinned.teamblack(M).y)
            Next
            For M = 1 To pinned.teamwhite.Count - 1
                pinned_change_moves(pinned.piecepinningwhite(M).x, pinned.piecepinningwhite(M).y, pinned.teamwhite(M).x, pinned.teamwhite(M).y)
            Next
            
            rounds += 1
            Me.isselectedownalready = False

            If settings.Playing_Agaisnt_AI = True Then
                If whosgo = AIPLAYER.get_team Then
                    board = AIPLAYER.get_AImove(Me.board)
                    
                End If
                If checkmate = True Then
                    MsgBox("GAME OVER: " & incheckpiece.team & " lost")
                    FEN_STRING = FEN_STRING_USE.Save_board(board)
                    FileOpen(1, "D:\FEN BOARD SAVE FILES.txt", OpenMode.Append)
                    PrintLine(1, FEN_STRING & "   |   WIN")
                    MsgBox("Saved Fen In FEN BOARD SAVE FILES.txt")

                    FileClose(1)
                    Me.Close()

                    Exit Sub

                End If
            Else
                MsgBox("GAME OVER: " & incheckpiece.team & " lost")
                FEN_STRING = FEN_STRING_USE.Save_board(board)
                FileOpen(1, "D:\FEN BOARD SAVE FILES.txt", OpenMode.Append)
                PrintLine(1, FEN_STRING & "   |   WIN")
                MsgBox("Saved Fen In FEN BOARD SAVE FILES.txt")

                FileClose(1)
                Me.Close()

                Exit Sub
            End If
        End If

        'drawunderattack()
    End Sub
    Private Sub add_to_moves(ByRef moves As List(Of position), ByVal x As Integer, ByVal y As Integer)
        Dim new_pos As Form1.position
      
        new_pos.x = x
        new_pos.y = y
        moves.Add(new_pos)

    End Sub

    Public Sub pinned_change_moves(ByVal x, ByVal y, ByVal xpinned, ByVal ypinned)
        Dim difx As Integer
        Dim dify As Integer
        Dim moves As New List(Of position)
        difx = xpinned - x
        dify = ypinned - y
        'pawn pinned
        Select Case board(xpinned, ypinned).getsym
            Case "p"
                For Each M In board(xpinned, ypinned).getmoves
                    If board(x, y).getsym = "b" Then
                        If M.x = x And M.y = y Then
                            add_to_moves(moves, x, y)
                        End If
                    End If
                    If board(x, y).getsym = "q" Or board(x, y).getsym = "c" Then
                        If M.x = x Then
                            add_to_moves(moves, M.x, M.y)
                        End If
                    End If

                Next
            Case "q"
                'straight


                If xpinned = x Or ypinned = y Then
                    For Each M In board(xpinned, ypinned).getmoves
                        If M.x = x Then
                            add_to_moves(moves, M.x, M.y)
                        End If

                    Next
                ElseIf ypinned = y Then
                    For Each M In board(xpinned, ypinned).getmoves
                        If M.y = y Then
                            add_to_moves(moves, M.x, M.y)
                        End If
                    Next
                End If
                Dim difxmove As Integer
                Dim difymove As Integer

                'diagonal
                If difx < 0 And dify < 0 Then
                    decide_diagonal_moves(x, y, "upleft", xpinned, ypinned, moves)
                End If
                'ur
                If difx > 0 And dify < 0 Then
                    decide_diagonal_moves(x, y, "upright", xpinned, ypinned, moves)
                End If
                'dl
                If difx < 0 And dify > 0 Then
                    decide_diagonal_moves(x, y, "downleft", xpinned, ypinned, moves)
                End If
                'dr
                If difx > 0 And dify > 0 Then
                    decide_diagonal_moves(x, y, "downright", xpinned, ypinned, moves)
                End If
            Case "b"
                Dim difxmove As Integer
                Dim difymove As Integer

                'diagonal
                'ul
                If difx < 0 And dify < 0 Then
                    decide_diagonal_moves(x, y, "upleft", xpinned, ypinned, moves)
                End If
                'ur
                If difx > 0 And dify < 0 Then
                    decide_diagonal_moves(x, y, "upright", xpinned, ypinned, moves)
                End If
                'dl
                If difx < 0 And dify > 0 Then
                    decide_diagonal_moves(x, y, "downleft", xpinned, ypinned, moves)
                End If
                'dr
                If difx > 0 And dify > 0 Then
                    decide_diagonal_moves(x, y, "downright", xpinned, ypinned, moves)
                End If

            Case "c"
                If xpinned = x Or ypinned = y Then
                    For Each M In board(xpinned, ypinned).getmoves
                        If M.x = x Then
                            add_to_moves(moves, M.x, M.y)
                        End If

                    Next
                ElseIf ypinned = y Then
                    For Each M In board(xpinned, ypinned).getmoves
                        If M.y = y Then
                            add_to_moves(moves, M.x, M.y)
                        End If
                    Next
                End If



        End Select

        'castle pinned

        'queen pinned

        'horse pinned
        'bishop pinned
        board(xpinned, ypinned).resetmoves()
        board(xpinned, ypinned).setmoves(moves)
    End Sub
    Private Sub decide_diagonal_moves(ByVal xpinning, ByVal ypinning, ByVal direction, ByVal xpin, ByVal ypin, ByRef moves)
        Dim xx As Integer = xpinning
        add_to_moves(moves, xpinning, ypinning)
        Select Case direction
            Case "upleft"
                xx -= 1
                For yy = ypinning - 1 To 0 Step -1
                    If xx >= 0 Then
                        If xx <> xpin And yy <> ypin Then
                            If board(xx, yy).getsym = "_" Then
                                add_to_moves(moves, xx, yy)
                            ElseIf board(xx, yy).getsym <> "_" Then
                                yy = 0
                            End If
                        End If
                        xx -= 1
                    Else
                        yy = 0
                    End If
                Next
            Case "upright"
                xx += 1
                For yy = ypinning - 1 To 0 Step -1
                    If xx <= 7 Then
                        If xx <> xpin And yy <> ypin Then
                            If board(xx, yy).getsym = "_" Then
                                add_to_moves(moves, xx, yy)
                            ElseIf board(xx, yy).getsym <> "_" Then
                                yy = 0
                            End If
                        End If
                        xx += 1
                    Else
                        yy = 0
                    End If
                Next
            Case "downleft"
                xx -= 1
                For yy = ypinning + 1 To 7 Step 1
                    If xx >= 0 Then
                        If xx <> xpin And yy <> ypin Then
                            If board(xx, yy).getsym = "_" Then
                                add_to_moves(moves, xx, yy)
                            ElseIf board(xx, yy).getsym <> "_" Then
                                yy = 7
                            End If
                        End If
                        xx -= 1
                    Else
                        yy = 7
                    End If
                Next
            Case "downright"

                xx += 1
                For yy = ypinning + 1 To 7 Step 1
                    If xx <= 7 Then
                        If xx <> xpin And yy <> ypin Then
                            If board(xx, yy).getsym = "_" Then
                                add_to_moves(moves, xx, yy)
                            ElseIf board(xx, yy).getsym <> "_" Then
                                yy = 7
                            End If
                        End If
                        xx += 1
                    Else
                        yy = 7
                    End If
                Next

        End Select

    End Sub
  

    Public Sub checkedmoves()


        
    End Sub
    Private Function removeblank(ByVal newlist() As position)
        Dim backup As position
        'For xx = 0 To newlist.Length - 1
        '    If newlist(xx).x = 0 And newlist(xx).y = 0 Then
        '        If incheckpiece.x <> 0 And incheckpiece.y <> 0 Then
        '            For looper = xx To newlist.Length - 2
        '                newlist(xx) = newlist(xx + 1)
        '                ReDim Preserve newlist(newlist.Length - 2)
        '                removeblank(newlist)
        '            Next
        '        End If
        '    End If
        'Next
        Return newlist
    End Function
    Private Sub add_to_list(ByVal x As Integer, ByVal y As Integer, ByRef newlist() As position)
        newlist(newlist.Length - 1).x = x
        newlist(newlist.Length - 1).y = y


    End Sub
    Private Sub cantake(ByVal x As Integer, ByVal y As Integer, ByRef newlist As List(Of position))
        Dim new_pos As Form1.position
        If board(x, y).getsym <> "p" Then
            For Each M In board(x, y).getmoves

                If M.x = incheckpiece.x And M.y = incheckpiece.y Then

                    new_pos.x = M.x
                    new_pos.y = M.y

                    newlist.Add(new_pos)
                End If

            Next
        Else
            For Each M In board(x, y).getmoves
                If M.x <> x Then
                    If M.x = incheckpiece.x And M.y = incheckpiece.y Then
                        Me.incheckpiece.Can_Be_taken = True

                        new_pos.x = M.x
                        new_pos.y = M.y

                        newlist.Add(new_pos)
                    End If
                End If


            Next
        End If

    End Sub
    Public Sub canblock(ByVal x As Integer, ByVal y As Integer, ByRef newlist As List(Of position))
        Dim new_pos As position
        For Each M In board(x, y).getmoves
            For Each MC In incheckpiece.blockablepositions
                If MC.x > 0 And MC.y > 0 Then
                    If M.x = MC.x And M.y = MC.y Then
                        If M.x > 0 And M.y > 0 Then
                            Me.incheckpiece.can_be_blocked = True

                            new_pos.x = M.x
                            new_pos.y = M.y

                            newlist.Add(new_pos)
                        End If

                    End If
                End If

            Next
        Next



    End Sub
    Private Function change_board(ByVal the_board(,) As theboardclass, ByVal s As String, ByVal t As Integer, ByVal x As Integer, ByVal y As Integer, ByVal piece_selected_X As Integer, ByVal piece_Selected_Y As Integer, ByVal castling As Boolean)
        If castling = True Then
            Select Case t
                Case 0
                    whitecastled = True

                Case 1
                    blackcastled = True
            End Select
        End If

        deletemoves(the_board(piece_selected_X, piece_Selected_Y).getmoves, the_board)
        the_board(x, y).setpiece(the_board(piece_selected_X, piece_Selected_Y).getsym, the_board(piece_selected_X, piece_Selected_Y).getteam)
        the_board(piece_selected_X, piece_Selected_Y).setpiece("_", 2)
        the_board(piece_selected_X, piece_Selected_Y).set_hasmoved(True)

        the_board(x, y).set_hasmoved(True)
        Return the_board


    End Function
    Public Sub Change_castling_pos(ByVal team_of_castle As Integer, ByVal kingbeforex As Integer, ByVal movex As Integer)
        Dim pos_of_castlex As Integer

        If movex > kingbeforex Then
            pos_of_castlex = 7
        ElseIf movex < kingbeforex Then
            pos_of_castlex = 0
        End If
        Select Case team_of_castle
            Case 0
                If pos_of_castlex = 0 Then
                    changeboard.changepiecetowhere("c", 0, kingbeforex - 1, 0, pos_of_castlex, 0, True, False)

                ElseIf pos_of_castlex = 7 Then
                    changeboard.changepiecetowhere("c", 0, kingbeforex + 1, 0, pos_of_castlex, 0, True, False)
                End If
            Case 1
                If pos_of_castlex = 0 Then
                    changeboard.changepiecetowhere("c", 1, kingbeforex - 1, 7, pos_of_castlex, 7, True, False)

                ElseIf pos_of_castlex = 7 Then
                    changeboard.changepiecetowhere("c", 1, kingbeforex + 1, 7, pos_of_castlex, 7, True, False)
                End If
        End Select

    End Sub
    Public Function undo_move(ByVal board(,) As theboardclass, ByVal move As A_Move)
        board(move.From_x, move.From_Y).setpiece(move.sym_of_moving_piece, move.team_of_moving_p)
        board(move.New_x, move.New_Y).setpiece(move.Sym_being_taken, move.team_of_new_pos)
        board(move.New_x, move.New_Y).setmoves(move.Moves)
        board(move.From_x, move.From_Y).set_value(move.from_value)
        board(move.New_x, move.New_Y).set_value(move.new_value)
        If move.is_castling = True Then

            If move.team_of_moving_p = 0 Then
                If move.From_x <= 4 Then
                    board(0, 0).setpiece("c", move.team_of_moving_p)
                    board(move.From_x - 1, 0).setpiece("_", 2)
                    board(0, 0).set_hasmoved(False)
                ElseIf move.From_x >= 4 Then
                    board(7, 0).setpiece("c", move.team_of_moving_p)
                    board(move.From_x + 1, 0).setpiece("_", 2)
                    board(7, 0).set_hasmoved(False)

                End If
                board(move.From_x, move.From_Y).set_hasmoved(False)
                Me.whitecastled = False

            Else
                If move.From_x <= 4 Then
                    board(0, 7).setpiece("c", move.team_of_moving_p)
                    board(move.From_x - 1, 7).setpiece("_", 2)
                    board(0, 7).set_hasmoved(False)
                ElseIf move.From_x >= 4 Then
                    board(7, 7).setpiece("c", move.team_of_moving_p)
                    board(move.From_x + 1, 7).setpiece("_", 2)
                    board(7, 7).set_hasmoved(False)
                End If
                board(move.From_x, move.From_Y).set_hasmoved(False)
                Me.blackcastled = False
            End If

        End If
        If move.is_al_pasent = True Then
            If move.team_of_moving_p = 0 Then

                board(move.New_x, move.New_Y - 1).setpiece("p", 1)


            Else
                board(move.New_x, move.New_Y + 1).setpiece("p", 1)
            End If

        End If
        If move.sym_of_moving_piece = "p" Then
            If move.From_Y = 1 Or move.From_Y = 6 Then
                board(move.From_x, move.From_Y).set_hasmoved(False)
            End If
        End If

        Return board
    End Function
    Sub search_through_moves()
        Dim whosgo__ As Integer = 1
        Dim all_moves_list As New List(Of A_Move)
        Dim depth_counter As Integer = 0
        Dim depth As Integer = 2
        For Each II In depth_count
            depth_count(II) = 0
        Next
        Dim count As Integer = 0


        is_ai_calulating = True
        all_moves_list = calculate_all_moves(board, whosgo__, all_moves_list, False)
        depth_count(depth_counter) += all_moves_list.Count
        Dim list_of_amount_of_moves(all_moves_list.Count - 1, 2) As String
        Dim list_counter(depth) As move_count

        For Each M In all_moves_list
            
            If IsNothing(M.sym_of_moving_piece) = False Then

                board = Me.change_board(board, board(M.From_x, M.From_Y).getsym, board(M.From_x, M.From_Y).getteam, M.New_x, M.New_Y, M.From_x, M.From_Y, M.is_castling)
                whosgo__ = switchgoes(whosgo__)

                list_of_amount_of_moves(count, 0) = create_pos_letter(M.From_x, M.From_Y) & "" & create_pos_letter(M.New_x, M.New_Y)
                list_of_amount_of_moves(count, 1) = "0"
                If M.is_castling = True Then
                    list_counter(depth_counter).castles += 1
                End If
                If M.ischecking = True Then
                    list_counter(depth_counter).checks += 1

                End If
                If M.Sym_being_taken <> "_" Or M.is_al_pasent = True Then
                    list_counter(depth_counter).captures += 1
                End If
                recurvive_search(depth - 1, depth_count, whosgo__, list_of_amount_of_moves, depth_counter + 1, count, list_counter)
                whosgo__ = switchgoes(whosgo__)
                board = Me.undo_move(board, M)
                count += 1


            End If

        Next
        For II = 1 To depth
            depth_count(II) += depth_count(II - 1)
        Next
        is_ai_calulating = False
        FileOpen(1, "D:\fishtest.txt", OpenMode.Output)
        For looper = 0 To all_moves_list.Count - 1

            PrintLine(1, list_of_amount_of_moves(looper, 0) & " = " & list_of_amount_of_moves(looper, 1) & "    piece: " & all_moves_list(looper).sym_of_moving_piece)

        Next
        FileClose(1)
        all_moves_list = Nothing
        'MsgBox("Depth 1: " & depth_count(0) & vbCrLf & "Depth 2: " & depth_count(1) & vbCrLf & "Depth 3: " & depth_count(2) & vbCrLf & "Depth 4: " & depth_count(3) & vbCrLf & "Depth 5: " & depth_count(4))
        Me.LabelDepth1.Text = "Depth 1: " & depth_count(0) & vbCrLf & "Depth 2: " & depth_count(1) & vbCrLf & "Depth 3: " & depth_count(2) & vbCrLf & "Depth 4: " & depth_count(3) & vbCrLf & "Depth 5: " & depth_count(4)
        list_counter = list_counter
        MsgBox(usefulcounter)
    End Sub
    
    Sub recurvive_search(ByVal depth As Integer, ByRef depth_count() As Integer, ByRef whosgo__ As Integer, ByVal list_count(,) As String, ByVal depth_counter As Integer, ByVal count As Integer, ByRef list_counter() As move_count)


        If depth = 0 Then
            depth_count(depth_count.Length - 1) += 1

        Else
            reset()
            Dim all_moves_list As New List(Of A_Move)
            all_moves_list = calculate_all_moves(board, whosgo__, all_moves_list, False)
            depth_count(depth_counter) += all_moves_list.Count - 1
            For Each M In all_moves_list






                list_count(count, 1) = Str(Int(list_count(count, 1)) + all_moves_list.Count - 1)
                If M.is_castling = True Then
                    Me.Change_castling_pos(M.From_x, M.From_Y, M.From_x)
                    changeboard.changepiecetowhere(M.sym_of_moving_piece, M.team_of_moving_p, M.New_x, M.New_Y, M.From_x, M.From_Y, False, True)
                ElseIf M.is_al_pasent = True Then
                    Me.change_al_pasent(M.New_x, M.New_Y, M.team_of_moving_p)
                    changeboard.changepiecetowhere(M.sym_of_moving_piece, M.team_of_moving_p, M.New_x, M.New_Y, M.From_x, M.From_Y, False, False)
                Else
                    changeboard.changepiecetowhere(M.sym_of_moving_piece, M.team_of_moving_p, M.New_x, M.New_Y, M.From_x, M.From_Y, False, False)
                End If

                If M.is_castling = True Then
                    list_counter(depth_counter).castles += 1
                End If
                If M.ischecking = True Then
                    list_counter(depth_counter).checks += 1

                End If
                If M.Sym_being_taken <> "_" Or M.is_al_pasent = True Then
                    list_counter(depth_counter).captures += 1
                End If
                whosgo__ = switchgoes(whosgo__)
                recurvive_search(depth - 1, depth_count, whosgo__, list_count, depth_counter + 1, count, list_counter)

                whosgo__ = switchgoes(whosgo__)
                board = Me.undo_move(board, M)





            Next
            all_moves_list = Nothing
        End If


    End Sub
    Function create_pos_letter(ByVal x As Integer, ByVal y As Integer)
        Dim pos As String
        Dim ystr As String

        Select Case y
            Case 0
                ystr = "8"
            Case 1
                ystr = "7"
            Case 2
                ystr = "6"
            Case 3
                ystr = "5"
            Case 4
                ystr = "4"
            Case 5
                ystr = "3"
            Case 6
                ystr = "2"
            Case 7
                ystr = "1"
        End Select
        Select Case x
            Case 0
                pos = "a" & ystr
            Case 1
                pos = "b" & ystr
            Case 2
                pos = "c" & ystr
            Case 3
                pos = "d" & ystr
            Case 4
                pos = "e" & ystr
            Case 5
                pos = "f" & ystr
            Case 6
                pos = "g" & ystr
            Case 7
                pos = "h" & ystr


        End Select
        Return pos
    End Function
    Public Sub change_al_pasent(ByVal movex As Integer, ByVal movey As Integer, ByVal teamtaking As Integer)
        Select Case teamtaking
            Case 0
                changeboard.settoblank(movex, movey - 1)
            Case 1
                changeboard.settoblank(movex, movey + 1)
        End Select
    End Sub
    Private Function get_move_number(ByVal PSelectedx As Integer, ByVal PSelectedy As Integer, ByVal movex As Integer, ByVal movey As Integer)
        Dim count As Integer = 0
        For Each M In board(PSelectedx, PSelectedy).getmoves
            If M.x = movex And M.y = movey Then
                Return count
            End If
            count += 1
        Next
    End Function
    Public Function calculate_all_moves(ByVal the_board(,) As theboardclass, ByVal whosgo__ As Integer, ByVal list As List(Of A_Move), ByVal only_captures As Boolean)

        first_time = True
        For y = 0 To 7
            For x = 0 To 7
                If the_board(x, y).getteam = whosgo__ Then


                    the_board(x, y).getmoves.Clear()

                    the_board(x, y).calculatemoves(the_board, whosgo)






                End If

                ' x = 5 y = 2
            Next
        Next
        'MsgBox(the_board(5, 1).getmoves.Count)
        If rounds = 999999 Then
            MsgBox(the_board)
        End If
        For x = 0 To 7
            For y = 0 To 7
                If the_board(x, y).getsym = "k" Then

                    the_board(x, y).getmoves.Clear()
                    first_time = False
                    the_board(x, y).calculatemoves(board, whosgo)

                End If
            Next
        Next
        If checked = True Then
            Dim checkmates As Boolean = True
            Dim isok As Boolean = False
            Dim newlist As New List(Of position)

            For x = 0 To 7
                For y = 0 To 7


                    If board(x, y).getteam <> incheckpiece.team And board(x, y).getteam <> 2 And board(x, y).getsym <> "k" Then

                        newlist.Clear()
                        cantake(x, y, newlist)
                        canblock(x, y, newlist)
                        'If x = 0 And y = 4 Then
                        '    MsgBox("")
                        'End If
                        board(x, y).getmoves.Clear()
                        board(x, y).setmoves(newlist)
                        If newlist.Count > 0 Then
                            isok = True
                        End If
                    End If

                Next
            Next


            newlist = Nothing
        End If

        For M = 1 To pinned.teamblack.Count - 1
            pinned_change_moves(pinned.piecepinningblack(M).x, pinned.piecepinningblack(M).y, pinned.teamblack(M).x, pinned.teamblack(M).y)
        Next
        For M = 1 To pinned.teamwhite.Count - 1
            pinned_change_moves(pinned.piecepinningwhite(M).x, pinned.piecepinningwhite(M).y, pinned.teamwhite(M).x, pinned.teamwhite(M).y)
        Next
        For xx = 0 To 7
            For yy = 0 To 7


                For Each M In the_board(xx, yy).getmoves

                    If only_captures = True Then
                        If the_board(M.x, M.y).getsym <> "_" Then
                            If board(xx, yy).getteam = whosgo__ Then
                                If M.iscastling = True Then
                                    M.iscastling = True
                                End If

                                If M.IsAlPasentMove = True Then
                                    Move.is_al_pasent = True
                                Else
                                    Move.is_al_pasent = False
                                End If

                                If M.iscastling = True Then
                                    Move.is_castling = True
                                Else
                                    Move.is_castling = False
                                End If
                                Move.From_x = xx
                                Move.From_Y = yy
                                Move.New_x = M.x
                                Move.New_Y = M.y
                                Move.team_of_moving_p = the_board(xx, yy).getteam
                                Move.team_of_new_pos = the_board(M.x, M.y).getteam
                                Move.Sym_being_taken = the_board(M.x, M.y).getsym
                                Move.sym_of_moving_piece = the_board(xx, yy).getsym
                                Move.Moves = the_board(xx, yy).getmoves
                                Move.from_value = the_board(xx, yy).getvalue
                                Move.new_value = the_board(M.x, M.y).getvalue
                                list.Add(Move)
                            End If
                        
                        End If
                    Else
                        If board(xx, yy).getteam = whosgo__ Then
                            If M.iscastling = True Then
                                M.iscastling = True
                            End If

                            If M.IsAlPasentMove = True Then
                                Move.is_al_pasent = True
                            Else
                                Move.is_al_pasent = False
                            End If

                            If M.iscastling = True Then
                                Move.is_castling = True
                            Else
                                Move.is_castling = False
                            End If
                            Move.From_x = xx
                            Move.From_Y = yy
                            Move.New_x = M.x
                            Move.New_Y = M.y
                            Move.team_of_moving_p = the_board(xx, yy).getteam
                            Move.team_of_new_pos = the_board(M.x, M.y).getteam
                            Move.Sym_being_taken = the_board(M.x, M.y).getsym
                            Move.sym_of_moving_piece = the_board(xx, yy).getsym
                            Move.Moves = the_board(xx, yy).getmoves
                            Move.from_value = the_board(xx, yy).getvalue
                            Move.new_value = the_board(M.x, M.y).getvalue
                            list.Add(Move)
                        End If
                    End If








                Next



            Next
        Next
        Return list
    End Function
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AssetFolderPath = load_game.get_asset_folder_name
        load_game.load_settings_from_file()
        all_moves = New List(Of AI.Moves)
        whosgo = 0
        If Me.settings.Playing_Agaisnt_AI = True Then

            AIPLAYER = New AI(1)

        ElseIf Me.settings.AI_vs_AI = True Then
            AIPLAYER = New AI(1)
            Aiplayer2 = New AI(1)
            Aiplayer2.set_team(0)

        End If
        If Me.settings.using_FEN = True Then
            board = FEN_STRING_USE.Setboard(board)
        Else
            board = makeboard(board)
        End If

        If settings.calculating_all_moves_for_test = True Then
            drawboard(board)


        Else
            drawboard(board)

            'createboard2()
            Game()
        End If



    End Sub
    
    Public Sub deletemoves(ByVal move As List(Of position), ByVal the_board(,) As theboardclass)
        For xx = move.Count - 1 To 0 Step -1

            the_board(move(xx).x, move(xx).y).resetimage()
        Next

    End Sub
    Sub drawunderattack()
        Select Case whosgo
            Case 0
                For x = 0 To zerolistofincheckplaces.Count - 1
                    board(zerolistofincheckplaces(x).x, zerolistofincheckplaces(x).y).setimageselected()

                Next
            Case 1
                For x = 0 To onelistofincheckplaces.Count - 1
                    board(onelistofincheckplaces(x).x, onelistofincheckplaces(x).y).setimageselected()

                Next
        End Select

    End Sub



    Public Sub New()
        incheckpiece.blockablepositions = New List(Of position)
        incheckpiece.moves = New List(Of position)
        pinned.teamblack = New List(Of position)
        pinned.teamwhite = New List(Of position)
        pinned.piecepinningblack = New List(Of position)
        pinned.piecepinningwhite = New List(Of position)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub Save_Board_FEN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save_Board_FEN.Click
        Dim FEN_STRING As String
        If Me.Fen_of_board_Save_name.Text <> "" Then
            FEN_STRING = FEN_STRING_USE.Save_board(board)
            FileOpen(1, "D:\FEN BOARD SAVE FILES.txt", OpenMode.Append)
            PrintLine(1, FEN_STRING & "   |   " & Me.Fen_of_board_Save_name.Text)
            MsgBox("Saved Fen In FEN BOARD SAVE FILES.txt")
            Me.Fen_of_board_Save_name.Text = ""
            FileClose(1)
        Else
            MsgBox("Fen string requires a Name")
        End If
    End Sub

    Private Sub Aivsaibutton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Aivsaibutton.Click
        If settings.Playing_Agaisnt_AI = True Then
            whosgo = AIPLAYER.get_team
            AIPLAYER.get_AImove(board)
            Me.addround()


        ElseIf settings.AI_vs_AI = True Then
            If whosgo = AIPLAYER.get_team Then
                AIPLAYER.get_AImove(board)
                Me.addround()
            ElseIf whosgo = Aiplayer2.get_team Then
                Aiplayer2.get_AImove(board)
                Me.addround()
            End If

        End If
    End Sub

    
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        search_through_moves()
    End Sub
End Class
