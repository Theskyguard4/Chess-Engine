Public Class AI
    Private AILevel As Integer
    Private customSpeed As Integer
    Private My_Move As Form1.position
    Private Player_level As Integer
    Private Team_of_AI As Integer = 1
    Private whitecount As Integer = 16
    Private blackcount As Integer = 16
    Private wcountsave As Integer = 16
    Private blackcountsave As Byte = 16
    Private howmany As Integer
    Private blackvalue As New Integer
    Private whitevalue As New Integer
    Private MoveTimerCount As Integer
    Private value_diff As New Integer
    Private stringOfMovesToDo As String
    'values of each piece
    Private ListOfAllMasterGames As New List(Of String)
    Private ListofStarterMovesString As New List(Of String)
    Private ListOfStarterMoves() As String

    Public Sub setListOfStarterMoves(ByVal List() As String)
        Me.ListOfStarterMoves = List
    End Sub
    Public Function GetOpeningMovelist()
        Dim str As String
        For Each M In Me.ListOfStarterMoves
            str &= M & " "
        Next
        Return str
    End Function
    Public Function GetBookMove(ByVal IndexOfMove As Integer)
        Return Me.ListOfStarterMoves(IndexOfMove)
    End Function


    Structure Moves
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
    Public Function GetTimer()
        Return MoveTimerCount
    End Function
    Public Sub New(ByVal Difficulty As String)
        set_AIlevel(Difficulty)

    End Sub
    Public Sub set_AIlevel(ByVal difficulty As String)

        Me.AILevel = 3 'difficulty

    End Sub
    Public Function get_AIlevel() As Integer
        Return Me.AILevel
    End Function
    Public Function get_AImove(ByVal board(,) As theboardclass)
        Select Case Me.AILevel
            Case 1
            Case 2
                Me.Meduim_AI(board)
            Case 3
                Me.StartMiniMax(board, 3, Me.Team_of_AI)
        End Select








        Return board
    End Function
    Private Function Get_Move_Score(ByVal X As Integer, ByVal Y As Integer, ByVal board(,) As theboardclass, ByVal Piece_moving_sym As String)
        Dim score_of_Move As Integer


        Select Case board(X, Y).getsym
            Case "_"
                score_of_Move = 1
                For yy = 0 To 7
                    For xx = 0 To 7

                        If board(xx, yy).getteam <> Me.Team_of_AI And board(xx, yy).getteam <> 2 Then
                            For Each M In board(xx, yy).getmoves
                                If M.x = X And M.y Then
                                    Select Case board(xx, yy).getsym

                                        Case "p"
                                            score_of_Move = 5
                                        Case "c"
                                            score_of_Move = 4
                                        Case "b"
                                            score_of_Move = 3
                                        Case "h"
                                            score_of_Move = 2
                                        Case "q"
                                            score_of_Move = 1
                                        Case Else
                                            score_of_Move = 6
                                    End Select
                                End If
                            Next
                        End If
                    Next
                Next
            Case "p"
                score_of_Move = 7

            Case "c"
                score_of_Move = 10
            Case "h"
                score_of_Move = 15
            Case "b"
                score_of_Move = 20
            Case "q"
                score_of_Move = 25
        End Select



        Return score_of_Move

    End Function
    Public Function get_Opening_moves_string()
        Return Me.stringOfMovesToDo
    End Function
    Private Sub Meduim_AI(ByVal board(,) As theboardclass)
        Dim List_of_moves As New List(Of Moves)
        Dim score_of_move_now As Moves
        Dim highest_rated_move_index As Integer
        Dim highest_rated_move As Moves
        Dim count As Integer

        For XX = 0 To 7
            For YY = 0 To 7
                count = 0
                If board(XX, YY).getteam = Me.Team_of_AI Then

                    For Each M In board(XX, YY).getmoves
                        If count <> 0 Then
                            score_of_move_now.Number = Me.Get_Move_Score(M.x, M.y, board, board(XX, YY).getsym)
                            score_of_move_now.From_x = XX
                            score_of_move_now.From_Y = YY
                            score_of_move_now.New_x = M.x
                            score_of_move_now.New_Y = M.y

                            List_of_moves.Add(score_of_move_now)
                        End If

                        count += 1
                    Next



                End If
            Next
        Next
        Updateboard(Decide_best_move(List_of_moves))

    End Sub
    Private Sub Updateboard(ByVal move As Moves)
        Form1.deletemoves(Form1.board(move.From_x, move.From_Y).getmoves, Form1.board)
        Form1.board(move.New_x, move.New_Y).setpiece(Form1.board(move.From_x, move.From_Y).getsym, Form1.board(move.From_x, move.From_Y).getteam)
        Form1.board(move.From_x, move.From_Y).setpiece("_", 2)

        drawboard(Form1.board)

    End Sub
    Private Function Decide_best_move(ByVal List_of_all_moves As List(Of Moves))
        Dim Best_move As Moves
        Dim best_score As Integer = 0
        Dim index_of_best As Integer
        For Each M In List_of_all_moves
            If M.Number > best_score Then
                best_score = M.Number
                Best_move = M
            End If
        Next


        Return Best_move


    End Function
    Private Function Easymode_AI(ByVal Board, ByVal team)


    End Function
    Public Sub set_team(ByVal team)
        Me.Team_of_AI = team
    End Sub
    Private Function UpdateCalBoard(ByVal move As Moves, ByVal A_board(,) As theboardclass)


        Return A_board

    End Function
    Public Function get_team()
        Return Me.Team_of_AI
    End Function
    Private Function copy_board(ByVal A_board(,) As theboardclass, ByVal Board_to_copy(,) As theboardclass)
        For xx = 0 To 7
            For yy = 0 To 7
                A_board(xx, yy) = Board_to_copy(xx, yy)
            Next
        Next

        Return A_board
    End Function
    Private Function create_board(ByVal a_board(,) As theboardclass, ByVal Board_to_copy(,) As theboardclass)
        'For xx = 0 To 7
        '    For yy = 0 To 7
        '        a_board(xx, yy) = New theboardclass(Board_to_copy(xx, yy).getsym, Board_to_copy(xx, yy).getteam)
        '    Next
        'Next
        a_board = makeboard(a_board)
        Return a_board
    End Function
    Structure Layers
        Dim Each_board_fen As String
    End Structure
    Private Function calculate_all_moves(ByVal board(,) As theboardclass)
        For Go = 0 To 1
            For xx = 0 To 7
                For yy = 0 To 7
                    board(xx, yy).calculatemoves(board, Go)

                Next
            Next
        Next
        Return board

    End Function
    Private Function change_board(ByVal s As String, ByVal t As Integer, ByVal x As Integer, ByVal y As Integer, ByVal piece_selected_X As Integer, ByVal piece_Selected_Y As Integer)

        Form1.deletemoves(Form1.board(piece_selected_X, piece_Selected_Y).getmoves, Form1.board)
        Form1.board(x, y).setpiece(Form1.board(piece_selected_X, piece_Selected_Y).getsym, Form1.board(piece_selected_X, piece_Selected_Y).getteam)
        Form1.board(piece_selected_X, piece_Selected_Y).setpiece("_", 2)




    End Function
    Private Function undo_move(ByVal board(,) As theboardclass, ByVal move As Moves)
        board(move.From_x, move.From_Y).setpiece(move.sym_of_moving_piece, move.team_of_moving_p)
        board(move.New_x, move.New_Y).setpiece(move.Sym_being_taken, move.team_of_new_pos)
        board(move.New_x, move.New_Y).setmoves(move.Moves)
        board(move.From_x, move.From_Y).set_value(move.from_value)
        board(move.New_x, move.New_Y).set_value(move.new_value)


        Return board
    End Function

    'Private Sub Hard_mode_AI(ByVal Depth As Integer)
    '    Dim bestmove As Moves
    '    Dim bestscore As Integer
    '    Dim count As Integer
    '    Dim score As Integer
    '    Dim counts As Integer = 0
    '    Dim move As Moves
    '    Dim altha As Integer
    '    Dim beta As Integer

    '    howmany = 0

    '    bestscore = -10000
    '    'Form1.All_moves = Reorder_moves(Form1.All_moves, Form1.board)

    '    For Each M In Form1.All_moves
    '        If M.team_of_moving_p = Team_of_AI Then
    '            whitecount = Form1.numofwhitepieces
    '            blackcount = Form1.numofblackpieces

    '            howmany += 1


    '            count += 1
    '            counts = 0
    '            If count <> 1 Then




    '                Me.change_board(Form1.board(M.From_x, M.From_Y).getsym, Form1.board(M.From_x, M.From_Y).getteam, M.New_x, M.New_Y, M.From_x, M.From_Y)
    '                score = Me.MiniMax(Form1.board, Depth, counts, True, altha, beta)
    '                Form1.board = Me.undo_move(Form1.board, M)
    '                'MsgBox(score)
    '                If score > bestscore Then
    '                    bestscore = score
    '                    bestmove.From_x = M.From_x
    '                    bestmove.From_Y = M.From_Y
    '                    bestmove.New_x = M.New_x
    '                    bestmove.New_Y = M.New_Y
    '                End If

    '            End If
    '        End If

    '    Next

    '    'MsgBox("Number of moves calculated: " & howmany)
    '    MsgBox(Form1.board(bestmove.From_x, bestmove.From_Y).getsym & " score: " & bestscore)
    '    changeboard.changepiecetowhere(Form1.board(bestmove.New_x, bestmove.New_Y).getsym, Form1.board(bestmove.New_x, bestmove.New_Y).getteam, bestmove.New_x, bestmove.New_Y, bestmove.From_x, bestmove.From_Y, True, False)
    'End Sub
 
    'Private Function MiniMax(ByVal board(,) As theboardclass, ByVal depth As Integer, ByRef count As Integer, ByVal ismax As Boolean, ByVal altha As Integer, ByVal beta As Integer)


    '    Dim score As Integer
    '    Dim value As Integer
    '    Dim num As Integer
    '    Dim all_moves As New List(Of Form1.A_Move)
    '    Dim move As Form1.A_Move
    '    score = Get_all_scores(board)
    '    If depth = 0 Then ' if reached depth stop

    '        Return MiniMax_Captures_Only(board, ismax, score)


    '    End If


    '    count += 1
    '    calculate_all_moves(board)
    '    Dim counter As Integer = 0
    '    For xx = 0 To 7
    '        For yy = 0 To 7
    '            counter = 0
    '            For Each M In board(xx, yy).getmoves
    '                If counter <> 0 Then
    '                    move.From_x = xx
    '                    move.From_Y = yy
    '                    move.New_x = M.x
    '                    move.New_Y = M.y
    '                    move.team_of_moving_p = board(xx, yy).getteam
    '                    move.team_of_new_pos = board(M.x, M.y).getteam
    '                    move.Sym_being_taken = board(M.x, M.y).getsym
    '                    move.sym_of_moving_piece = board(xx, yy).getsym
    '                    move.Moves = board(xx, yy).getmoves
    '                    move.from_value = board(xx, yy).getvalue
    '                    move.new_value = board(M.x, M.y).getvalue
    '                    all_moves.Add(move)
    '                End If
    '                counter += 1
    '            Next

    '        Next
    '    Next
    '    all_moves = Reorder_moves(all_moves, board)


    '    For Each M In Form1.All_moves
    '        howmany += 1

    '        Form1.bpawncount = Form1.bpawncount
    '        Form1.bcastlecount2 = Form1.bcastlecount
    '        Form1.bbishopcount = Form1.bbishopcount
    '        Form1.bqueencount2 = Form1.bqueencount
    '        Form1.bhorsecount2 = Form1.bhorsecount

    '        Form1.wpawncount2 = Form1.wpawncount
    '        Form1.wcastlecount2 = Form1.wcastlecount
    '        Form1.whorsecount2 = Form1.whorsecount
    '        Form1.wbishopcount2 = Form1.wbishopcount
    '        Form1.wqueencount2 = Form1.wqueencount

    '        Me.change_board(board(M.From_x, M.From_Y).getsym, board(M.From_x, M.From_Y).getteam, M.New_x, M.New_Y, M.From_x, M.From_Y)
    '        If ismax = True Then
    '            value = MiniMax(board, depth - 1, count, False, altha, beta)
    '            board = Me.undo_move(board, M)
    '            If value <= score Then
    '                Return value
    '            End If
    '            If value >= score Then
    '                score = value
    '            End If
    '        Else ' ismax = false
    '            value = MiniMax(board, depth - 1, count, True, altha, beta)
    '            board = Me.undo_move(board, M)
    '            If value >= score Then
    '                Return value
    '            End If
    '            If value < score Then
    '                score = value
    '            End If

    '        End If



    '        'If value <> 0 Then
    '        '    MsgBox(value)
    '        'End If
    '        'If value > score Then
    '        '    score = value
    '        'End If



    '        num += 1
    '    Next


    '    Return score


    'End Function
    Public Sub AI_piece_inspecter()
        MsgBox("black castle: " & Form1.bcastlecount2 & vbCrLf & " white castle: " & Form1.wcastlecount2 & vbCrLf & " blackpawns: " & Form1.bpawncount)
    End Sub
    Public Function get_material(ByVal worb As String, ByVal board(,) As theboardclass)
        Dim material As Integer = 0
        If worb = "white" Then
            count_pieces(board, 0, 2)
            material += Form1.wpawncount2 * Form1.pawnvalue
            material += Form1.wcastlecount2 * Form1.castlevalue
            material += Form1.wbishopcount2 * Form1.bishopvalue
            material += Form1.whorsecount2 * Form1.horsevalue
            material += Form1.wqueencount2 * Form1.queenvalue


        Else
            count_pieces(board, 1, 2)
            material += Form1.bpawncount2 * Form1.pawnvalue
            material += Form1.bcastlecount2 * Form1.castlevalue
            material += Form1.bbishopcount2 * Form1.bishopvalue
            material += Form1.bhorsecount2 * Form1.horsevalue
            material += Form1.bqueencount2 * Form1.queenvalue
        End If
        If material < 0 Then
            MsgBox("piec count broke: " & material & " " & Form1.bpawncount)
        End If
        Return material
    End Function
    Public Sub count_pieces(ByVal board(,) As theboardclass, ByVal team As Integer, ByVal whichcount As Integer)
        If whichcount = 1 Then
            If team = 0 Then
                Form1.wpawncount = 0
                Form1.wcastlecount = 0
                Form1.wbishopcount = 0
                Form1.whorsecount = 0
                Form1.wqueencount = 0
                For Each Piece In board
                    If Piece.getteam = 0 Then
                        Select Case Piece.getsym
                            Case "q"
                                Form1.wqueencount += 1
                            Case "p"
                                Form1.wpawncount += 1
                            Case "b"
                                Form1.wbishopcount += 1
                            Case "h"
                                Form1.whorsecount += 1
                            Case "c"
                                Form1.wcastlecount += 1

                        End Select
                    End If

                Next
            Else
                Form1.bpawncount = 0
                Form1.bcastlecount = 0
                Form1.bbishopcount = 0
                Form1.bhorsecount = 0
                Form1.bqueencount = 0
                For Each Piece In board
                    If Piece.getteam = 1 Then
                        Select Case Piece.getsym
                            Case "q"
                                Form1.bqueencount += 1
                            Case "p"
                                Form1.bpawncount += 1
                            Case "b"
                                Form1.bbishopcount += 1
                            Case "h"
                                Form1.bhorsecount += 1
                            Case "c"
                                Form1.bcastlecount += 1

                        End Select
                    End If

                Next
            End If





        ElseIf whichcount = 2 Then
            If team = 0 Then
                Form1.wpawncount2 = 0
                Form1.wcastlecount2 = 0
                Form1.wbishopcount2 = 0
                Form1.whorsecount2 = 0
                Form1.wqueencount2 = 0
                For Each Piece In board
                    If Piece.getteam = 0 Then
                        Select Case Piece.getsym
                            Case "q"
                                Form1.wqueencount2 += 1
                            Case "p"
                                Form1.wpawncount2 += 1
                            Case "b"
                                Form1.wbishopcount2 += 1
                            Case "h"
                                Form1.whorsecount2 += 1
                            Case "c"
                                Form1.wcastlecount2 += 1

                        End Select
                    End If

                Next
            Else
                Form1.bpawncount2 = 0
                Form1.bcastlecount2 = 0
                Form1.bbishopcount2 = 0
                Form1.bhorsecount2 = 0
                Form1.bqueencount2 = 0
                For Each Piece In board
                    If Piece.getteam = 1 Then
                        Select Case Piece.getsym
                            Case "q"
                                Form1.bqueencount2 += 1
                            Case "p"
                                Form1.bpawncount2 += 1
                            Case "b"
                                Form1.bbishopcount2 += 1
                            Case "h"
                                Form1.bhorsecount2 += 1
                            Case "c"
                                Form1.bcastlecount2 += 1

                        End Select
                    End If

                Next
            End If
        End If
    End Sub
    Public Function get_score_of_lost(ByVal team As String)
        Dim material As Integer
        If team = "white" Then
            material += Form1.wpawndiff * Form1.pawnvalue
            material += Form1.wcastlediff * Form1.castlevalue
            material += Form1.whorsediff * Form1.horsevalue
            material += Form1.wbishopsdiff * Form1.bishopvalue
            material += Form1.wqueendiff * Form1.queenvalue

        Else
            material += Form1.bpawndiff * Form1.pawnvalue
            material += Form1.bcastlediff * Form1.castlevalue
            material += Form1.bhorsediff * Form1.horsevalue
            material += Form1.bbishopsdiff * Form1.bishopvalue
            material += Form1.bqueendiff * Form1.queenvalue
            'MsgBox("black pawn diff: " & Form1.bpawndiff & vbCrLf & "black castle diff: " & Form1.bcastlediff & vbCrLf & "black horse diff: " & Form1.bhorsediff & vbCrLf & "black bishop diff: " & Form1.bbishopsdiff & vbCrLf & "black queen diff: " & Form1.bqueendiff & vbCrLf & "white pawn diff: " & Form1.wpawndiff & vbCrLf & "white castle diff: " & Form1.wcastlediff & vbCrLf & "white horse diff: " & Form1.whorsediff & vbCrLf & "white bishop diff: " & Form1.wbishopsdiff & vbCrLf & "white queen diff: " & Form1.wqueendiff)
        End If
        Return material
    End Function
    Public Function Get_all_scores(ByVal board(,) As theboardclass)
        Dim score As Integer
        Dim w As Integer
        Dim b As Integer
        
        count_pieces(board, 0, 2)
        count_pieces(board, 1, 2)
        Form1.wpawndiff = Form1.wpawncount2 - Form1.wpawncount
        Form1.wcastlediff = Form1.wcastlecount2 - Form1.wcastlecount
        Form1.whorsediff = Form1.whorsecount2 - Form1.whorsecount
        Form1.wbishopsdiff = Form1.wbishopcount2 - Form1.wbishopcount
        Form1.wqueendiff = Form1.wqueencount2 - Form1.wqueencount

        Form1.bpawndiff = Form1.bpawncount2 - Form1.bpawncount
        Form1.bcastlediff = Form1.bcastlecount2 - Form1.bcastlecount
        Form1.bhorsediff = Form1.bhorsecount2 - Form1.bhorsecount
        Form1.bbishopsdiff = Form1.bbishopcount2 - Form1.bbishopcount
        Form1.bqueendiff = Form1.bqueencount2 - Form1.bqueencount

        Me.whitevalue = get_score_of_lost("white")
        Me.blackvalue = get_score_of_lost("black")
        w = 4000 + Me.whitevalue
        b = 4000 + Me.blackvalue

        score = b - w
        If score <> 0 Then
            'MsgBox(score)
        End If



        'MsgBox(score)




        Return score
    End Function
    Private Function get_piece_value(ByVal piece As String)
        Select Case piece

            Case "p"
                Return Form1.pawnvalue
            Case "b"
                Return Form1.bishopvalue
            Case "h"
                Return Form1.horsevalue
            Case "q"
                Return Form1.queenvalue
            Case "c"
                Return Form1.castlevalue
            Case Else
                Return 0
        End Select

    End Function
    Function Reorder_moves(ByVal all_moves As List(Of Form1.Efficient_moves), ByVal board(,) As theboardclass)
        Dim reordered As New List(Of Form1.Efficient_moves)
        Dim count As Integer
        Dim counter As Integer = 0
        Dim isokay As Boolean = False
        Dim pos As Form1.position
        For Each Move In all_moves



            If Move.target.sym <> "_" Then
                Move.movescore = 10 * get_piece_value(Move.target.sym) - get_piece_value(Move.origin.sym)
            End If
            If (Move.target.y = 0 Or Move.target.y = 7) And Move.origin.sym = "p" Then
                Move.movescore += 900
            End If
            pos.x = Move.target.x
            pos.y = Move.target.y

            If Move.origin.team = 0 Then
                If check_if_in(Form1.BLACKPawnmoves, pos) = True Then
                    Move.movescore -= get_piece_value(Move.origin.sym)
                End If
            Else
                If check_if_in(Form1.WHITEPawnmoves, pos) = True Then
                    Move.movescore -= get_piece_value(Move.origin.sym)
                End If
            End If



            count = 0
            If counter = 0 Then
                reordered.Add(Move)
            Else
                isokay = False
                For Each FMOVE In reordered
                    If FMOVE.movescore <= Move.movescore Then
                        reordered.Insert(count, Move)
                        isokay = True
                        Exit For

                    End If
                    count += 1
                Next
                If isokay = False Then
                    reordered.Add(Move)
                End If
            End If

            counter += 1
        Next
        all_moves = reordered
        reordered = Nothing
        'MsgBox(reordered.Count & "   " & all_moves.Count)
        Return all_moves

    End Function
    Private Function Make_all_moves(ByVal board(,) As theboardclass, ByVal whatteam As Integer, ByVal Only_captures As Boolean, ByVal all_moves As List(Of AI.Moves))
        Dim counter As Integer = 0
        Dim move As Moves
        all_moves = New List(Of Moves)

        'MsgBox(whatteam)
        Form1.reset()
        For xx = 0 To 7
            For yy = 0 To 7
                If board(xx, yy).getsym <> "k" And board(xx, yy).getteam = whatteam Then
                    board(xx, yy).calculatemoves(board, whatteam)
                End If

            Next
        Next



        For x = 0 To 7
            For y = 0 To 7
                If board(x, y).getsym = "k" Then
                    board(x, y).calculatemoves(board, whatteam)
                End If
            Next
        Next


        If Form1.checked = True Then
            

        End If

        For M = 1 To Form1.pinned.teamblack.Count - 1
            Form1.pinned_change_moves(Form1.pinned.piecepinningblack(M).x, Form1.pinned.piecepinningblack(M).y, Form1.pinned.teamblack(M).x, Form1.pinned.teamblack(M).y)
        Next
        For M = 1 To Form1.pinned.teamwhite.Count - 1
            Form1.pinned_change_moves(Form1.pinned.piecepinningwhite(M).x, Form1.pinned.piecepinningwhite(M).y, Form1.pinned.teamwhite(M).x, Form1.pinned.teamwhite(M).y)
        Next
        For xx = 0 To 7
            For yy = 0 To 7
                If board(xx, yy).getteam = whatteam Then

                    For Each M In board(xx, yy).getmoves


                        If Only_captures = False Then
                            move.From_x = xx
                            move.From_Y = yy
                            move.New_x = M.x
                            move.New_Y = M.y
                            move.team_of_moving_p = board(xx, yy).getteam
                            move.team_of_new_pos = board(M.x, M.y).getteam
                            move.Sym_being_taken = board(M.x, M.y).getsym
                            move.sym_of_moving_piece = board(xx, yy).getsym
                            move.Moves = board(xx, yy).getmoves
                            move.from_value = board(xx, yy).getvalue
                            move.new_value = board(M.x, M.y).getvalue
                            all_moves.Add(move)
                        Else
                            If board(M.x, M.y).getsym <> "_" Then
                                move.From_x = xx
                                move.From_Y = yy
                                move.New_x = M.x
                                move.New_Y = M.y
                                move.team_of_moving_p = board(xx, yy).getteam
                                move.team_of_new_pos = board(M.x, M.y).getteam
                                move.Sym_being_taken = board(M.x, M.y).getsym
                                move.sym_of_moving_piece = board(xx, yy).getsym
                                move.Moves = board(xx, yy).getmoves
                                move.from_value = board(xx, yy).getvalue
                                move.new_value = board(M.x, M.y).getvalue


                                all_moves.Add(move)
                            End If
                        End If


                    Next
                End If


            Next
        Next
        If Form1.checked = True Then
            'MsgBox("")
        End If
        Return all_moves
    End Function
    Structure returns
        Dim score As Integer
        Dim move As Moves
    End Structure
    Private Sub hard_aiV2(ByVal depth As Integer, ByVal board(,) As theboardclass)
        Dim bestmove As Form1.Efficient_moves
        depth = 2
        Dim count As Integer
        Dim loopermax As Integer = 20
        Dim II As Integer
        Dim all_moves As New List(Of Form1.Efficient_moves)
        Dim bestscore As Integer = -99999999
        Dim newscore As Integer
        Form1.is_ai_calulating = True
       

        all_moves = Form1.calculate_all_moves(board, Form1.AIPLAYER.Team_of_AI, all_moves, False)
        count_pieces(board, 1, 1)
        count_pieces(board, 0, 1)
        '
        all_moves = Reorder_moves(all_moves, board)
        'For II = 0 To loopermax
        For Each M In all_moves
            If IsNothing(M.origin.sym) = False Then
                Me.change_board(board(M.origin.x, M.origin.y).getsym, board(M.origin.x, M.origin.y).getteam, M.target.x, M.target.y, M.origin.x, M.origin.y)
                newscore = Alphabeta(board, depth - 1, -999999999, 99999999, False, count)
                board = changeboard.efficient_undo_board(board, M)



                'If M.From_x = 0 And M.From_Y = 4 Then
                '    MsgBox("")
                'End If

                If newscore > bestscore Then

                    bestscore = newscore
                    bestmove = M
                ElseIf newscore = bestscore Then
                    If get_piece_value(M.origin.sym) > get_piece_value(bestmove.origin.sym) Then
                        bestscore = newscore
                        bestmove = M
                    End If
                End If
            End If

        Next
        'If count > 1000 Then
        '    Exit For
        'End If
        ' Next

        all_moves = Nothing
        MsgBox("Moves checked: " & count & vbCrLf & "Piece moving: " & bestmove.origin.sym & vbCrLf & "Move Score: " & bestscore & vbCrLf & " Move From: " & bestmove.origin.x & "," & bestmove.origin.y & " To " & bestmove.target.x & "," & bestmove.target.y & vbCrLf & " Depth searched: " & II)

        'MsgBox(bestmove.sym_of_moving_piece & "  " & bestmove.team_of_moving_p
        Form1.is_ai_calulating = False
        Form1.reset()
        changeboard.changepiecetowhere(Form1.board(bestmove.target.x, bestmove.target.y).getsym, Form1.board(bestmove.target.x, bestmove.target.y).getteam, bestmove.target.x, bestmove.target.y, bestmove.origin.x, bestmove.origin.y, True, False)
    End Sub
    Private Function Alphabeta(ByVal board(,) As theboardclass, ByVal depth As Integer, ByRef alpha As Integer, ByRef beta As Integer, ByVal ismaxin As Boolean, ByRef count As Integer)

        Dim bestmove As Moves

        Dim ST As returns
        Dim score As Integer
        Dim otherteam As Integer
        Dim bestscore As Integer
        Dim lowestscore As Integer

        If Me.Team_of_AI = 0 Then
            otherteam = 1

        Else
            otherteam = 0
        End If

        If depth = 0 Then
            count += 1

            Return Get_all_scores(board) 'Only_capture_search(board, depth, alpha, beta, Not ismaxin, count)
        End If
        Dim every_move As New List(Of Form1.Efficient_moves)
        bestmove = Nothing
        every_move = Form1.calculate_all_moves(board, Form1.AIPLAYER.Team_of_AI, every_move, False)
        every_move = Reorder_moves(every_move, board)

        If ismaxin = True Then


            For Each M In every_move
                board = changeboard.efficient_change_board(board, M)

           

                count += 1
                score = Alphabeta(board, depth - 1, alpha, beta, False, count)

                board = changeboard.efficient_undo_board(board, M)

                bestscore = Math.Max(bestscore, score)

                alpha = Math.Max(alpha, score)
                If beta <= alpha Then
                    Exit For
                End If

            Next
            every_move = Nothing
            Return bestscore
        ElseIf ismaxin = False Then
         


            
            For Each M In every_move

                board = changeboard.efficient_change_board(board, M)

                count += 1
                score = Alphabeta(board, depth - 1, alpha, beta, True, count)
                lowestscore = Math.Min(lowestscore, score)


                board = changeboard.efficient_undo_board(board, M)
                beta = Math.Min(beta, score)
                If beta <= alpha Then
                    Exit For
                End If

            Next
            every_move = Nothing
            Return lowestscore
        End If
    End Function

    Public Sub Write_AI_Info(ByVal Move As Form1.Efficient_moves, ByVal count As Integer, ByVal score As Integer, ByVal depth As Integer, ByVal isbookmove As Boolean, ByVal time As Integer)
        Dim Label_text As String
        If Move.origin.sym = "" Then
            MsgBox("GAME ERROR: No Move Given (CODE: 1)")
        End If
        Label_text &= "Nodes Checked: " & count & " - Score: " & score & " - Depth: " & depth & " - Book Move: " & isbookmove & " - Time Taken: " & time / 10 & "s" & " TT Table Hit: " & Form1.TTHITCount
        Form1.Ai_information_label.Text = Label_text

    End Sub
    Private Sub tmr_tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MoveTimerCount += 1
    End Sub
    Private Sub StartMiniMax(ByVal board(,) As theboardclass, ByVal depth As Integer, ByVal WhosTurn As Integer)
        MoveTimerCount = 0
        Dim tmr As New Timers.Timer
        AddHandler tmr.Elapsed, AddressOf tmr_tick
        tmr.Interval = 100
        tmr.Enabled = True
        

        Dim count As Integer
        Dim BestScore As Integer
        Dim bestMoveMOVE As Form1.Efficient_moves = MiniMaxModule.StartNegaMax(board, depth, Form1.whosgo, count, BestScore)
        tmr.Enabled = False
        Form1.is_ai_calulating = False

        Form1.board = changeboard.efficient_change_board(board, bestMoveMOVE)
        Form1.TTSize = 0
        For II = 0 To Form1.TranspoTable.Count - 1
            If Form1.TranspoTable(II).Hash > 0 Then
                Form1.TTSize += 1
            End If
        Next
        Write_AI_Info(bestMoveMOVE, count, BestScore, depth, False, MoveTimerCount)
        Form1.TTHITCount = 0
        Form1.TTSize = 0
        tmr = Nothing
    End Sub
    'Dim counter As Integer = 0
    'Dim All_Moves As New List(Of Form1.Efficient_moves)
    'Dim ALPHA As Integer = -9999999
    'Dim BETA As Integer = 9999999
    'Dim IsMaximising As Boolean = True
    'Dim CurrentScore As Integer = -999999
    'Dim BestMoveScore As Integer = -9999999
    'Dim BestMoveMOVE As Form1.Efficient_moves = Nothing
    'Dim count As Integer = 0
    'depth = 4
    'Dim isokay As Boolean = False
    'Dim IsBookMove = False
    'All_Moves = Form1.calculate_all_moves(board, WhosTurn, All_Moves, False)
    'All_Moves = Reorder_moves(All_Moves, board)
    'If Form1.changboardcount > 0 Then


    '    Form1.is_ai_calulating = True
    '    Form1.board_info.castlingrights = ""
    '    Form1.CastlePublicLetter = ""

    '    Form1.BlackCountStart.Score = GetTeamValue(countpieces(board, 1))
    '    Form1.WhiteCountStart.Score = GetTeamValue(countpieces(board, 0))


    '    Form1.ogcastlingrights = Form1.board_info.castlingrights

    '    For Each M In All_Moves
    '        counter += 1
    '        M.OriginBoardInfo.castlingrights = Form1.ogcastlingrights

    '        board = changeboard.efficient_change_board(board, M)
    '        WhosTurn = Form1.switchgoes(WhosTurn)
    '        CurrentScore = AlphaBetaMax(-99999999, 99999999, depth - 1, board, WhosTurn, count)
    '        WhosTurn = Form1.switchgoes(WhosTurn)
    '        board = changeboard.efficient_undo_board(board, M)
    '        'If CurrentScore <> 0 Then
    '        '    MsgBox(CurrentScore)
    '        'End If
    '        If CurrentScore >= BestMoveScore Then

    '            BestMoveScore = CurrentScore
    '            BestMoveMOVE = M
    '            isokay = True
    '        End If
    '    Next


    '    'clundy@lpsb.org.uk
    '    If isokay = False Then
    '        MsgBox("NO MOVE")
    '    End If
    '    All_Moves = Nothing
    '    Form1.is_ai_calulating = False
    '    'If IsNothing(BestMoveMOVE) Then
    '    '    MsgBox("NO MOVE")
    '    'End If
    'Else

    '    If Form1.rounds = 1 Then
    '        Me.stringOfMovesToDo = ficsfileconverter.FindGameToCopy(Me.ListOfAllMasterGames)
    '        MsgBox(Form1.PreviousMove.origin.x & "," & Form1.PreviousMove.origin.y & "     " & Form1.PreviousMove.target.x & " " & Form1.PreviousMove.target.y)
    '        Me.ListofStarterMovesString = ficsfileconverter.ConvertFromStringToList(Me.stringOfMovesToDo, ListofStarterMovesString)
    '    End If
    '    IsBookMove = True
    '    BestMoveMOVE = ficsfileconverter.ConvertStringToPos(Me.ListofStarterMovesString(1), Form1.whosgo, All_Moves, True)
    '    BestMoveMOVE.OriginBoardInfo.castlingrights = Form1.ogcastlingrights
    '    If BestMoveMOVE.origin.sym = "x" Then
    '        '------------------------------------------------------------------------------------------------------------------
    '        BestMoveScore = -9999999
    '        IsBookMove = False
    '        depth = 3
    '        Form1.is_ai_calulating = True
    '        Form1.board_info.castlingrights = ""
    '        Form1.CastlePublicLetter = ""
    '        Form1.BlackCountStart.Score = GetTeamValue(countpieces(board, 1))
    '        Form1.WhiteCountStart.Score = GetTeamValue(countpieces(board, 0))
    '        Form1.ogcastlingrights = Form1.board_info.castlingrights
    '        For Each M In All_Moves
    '            M.OriginBoardInfo.castlingrights = Form1.ogcastlingrights
    '            counter += 1
    '            board = changeboard.efficient_change_board(board, M)
    '            WhosTurn = Form1.switchgoes(WhosTurn)
    '            CurrentScore = AlphaBetaMax(-99999999, 99999999, depth - 1, board, WhosTurn, count)
    '            WhosTurn = Form1.switchgoes(WhosTurn)
    '            board = changeboard.efficient_undo_board(board, M)

    '            If CurrentScore > BestMoveScore Then
    '                BestMoveScore = CurrentScore
    '                BestMoveMOVE = M
    '                isokay = True
    '            End If
    '        Next
    '        If isokay = False Then
    '            MsgBox("NO MOVE")
    '        End If
    '        All_Moves = Nothing
    '        Form1.is_ai_calulating = False
    '        'If IsNothing(BestMoveMOVE) Then
    '        '    MsgBox("NO MOVE")
    '        'End If
    '        '--------------------------------------------------------------------------------------------------------------
    '    End If
    '    Me.ListofStarterMovesString.RemoveAt(0)
    '    Me.ListofStarterMovesString.RemoveAt(0)

    'End If
    Public Sub SetStringOfOpening(ByVal StringList As String)
        Me.stringOfMovesToDo = StringList
    End Sub
    Public Function GetStringOfOpening()
        Return Me.stringOfMovesToDo
    End Function

    Public Sub SetListOfStringMoves(ByVal ListOfStrings As List(Of String))
        Me.ListofStarterMovesString = ListOfStrings
    End Sub
    Public Function GetListOfOpeningsString()
        Return Me.ListofStarterMovesString
    End Function

    Private Function MiniMaxSmall(ByVal board(,) As theboardclass, ByVal ALPHA As Integer, ByVal BETA As Integer, ByVal depth As Integer, ByVal IsMaximising As Boolean, ByRef count As Integer, ByVal WhosTurn As Integer)
        If depth = 0 Then

            Return Evaluate_board(board, WhosTurn)
        End If
        If Form1.checkmate = True Then
            If WhosTurn = Form1.incheckpiece.team Then
                Return 99999999
            Else
                Return -99999999
            End If

        End If


        Dim All_moves As New List(Of Form1.Efficient_moves)
        Dim CurrentScore As Integer
        Form1.board_info.castlingrights = ""
        Form1.CastlePublicLetter = ""
        All_moves = Form1.calculate_all_moves(board, WhosTurn, All_moves, False)

        All_moves = Reorder_moves(All_moves, board)
        If All_moves.Count = 0 Then
            Return 0
        End If


        For Each M In All_moves
            count += 1
            M.OriginBoardInfo.castlingrights = Form1.board_info.castlingrights
            board = changeboard.efficient_change_board(board, M)
            WhosTurn = Form1.switchgoes(WhosTurn)
            CurrentScore = -MiniMaxSmall(board, -BETA, -ALPHA, depth - 1, False, count, WhosTurn)
            WhosTurn = Form1.switchgoes(WhosTurn)
            board = changeboard.efficient_undo_board(board, M)
            If CurrentScore >= BETA Then
                All_moves = Nothing
                Return BETA
            End If

            ALPHA = Math.Max(ALPHA, CurrentScore)
        Next
        All_moves = Nothing
        'If BestScore = 0 Then
        '    BestScore = 0
        'End If
        Return ALPHA
    End Function

    'remake using the wiki V5
    Private Function AlphaBetaMax(ByVal ALPHA As Integer, ByVal BETA As Integer, ByVal depth As Integer, ByVal board(,) As theboardclass, ByVal whosturn As Integer, ByRef count As Integer)

        If depth = 0 Then
            count += 1
            Return Evaluate_board(board, whosturn)
        End If

        Dim All_moves As New List(Of Form1.Efficient_moves)
        Dim CurrentScore As Integer
        Form1.board_info.castlingrights = ""
        Form1.CastlePublicLetter = ""
        All_moves = Form1.calculate_all_moves(board, whosturn, All_moves, False)
        All_moves = Reorder_moves(All_moves, board)
        For Each M In All_moves
            M.OriginBoardInfo.castlingrights = Form1.board_info.castlingrights
            board = changeboard.efficient_change_board(board, M)
            whosturn = Form1.switchgoes(whosturn)
            CurrentScore = AlphaBetaMin(ALPHA, BETA, depth - 1, board, whosturn, count)
            whosturn = Form1.switchgoes(whosturn)
            board = changeboard.efficient_undo_board(board, M)
            If CurrentScore >= BETA Then
                All_moves = Nothing
                Return BETA
            End If
            If CurrentScore > ALPHA Then
                ALPHA = CurrentScore
            End If
        Next
        All_moves = Nothing
        Return ALPHA



    End Function
    Private Function AlphaBetaMin(ByVal ALPHA As Integer, ByVal BETA As Integer, ByVal depth As Integer, ByVal board(,) As theboardclass, ByVal whosturn As Integer, ByRef count As Integer)
        If depth = 0 Then
            count += 1
            Return Evaluate_board(board, whosturn)
        End If
        Dim All_moves As New List(Of Form1.Efficient_moves)
        Dim CurrentScore As Integer
        Form1.board_info.castlingrights = ""
        Form1.CastlePublicLetter = ""
        All_moves = Form1.calculate_all_moves(board, whosturn, All_moves, False)
        All_moves = Reorder_moves(All_moves, board)
        For Each M In All_moves
            M.OriginBoardInfo.castlingrights = Form1.board_info.castlingrights
            board = changeboard.efficient_change_board(board, M)
            whosturn = Form1.switchgoes(whosturn)
            CurrentScore = AlphaBetaMax(ALPHA, BETA, depth - 1, board, whosturn, count)
            whosturn = Form1.switchgoes(whosturn)
            board = changeboard.efficient_undo_board(board, M)
            If CurrentScore <= ALPHA Then
                All_moves = Nothing
                Return ALPHA
            End If
            If CurrentScore < BETA Then
                BETA = CurrentScore
            End If

        Next
        All_moves = Nothing



        Return BETA
    End Function






    Private Function MiniMaxFinal(ByVal board(,) As theboardclass, ByRef ALPHA As Integer, ByRef BETA As Integer, ByVal depth As Integer, ByVal IsMaximising As Boolean, ByRef count As Integer, ByVal WhosTurn As Integer)

        If depth = 0 Then
            count += 1
            Return Evaluate_board(board, WhosTurn)
        End If
        If Form1.checkmate = True Then
            If Form1.AIPLAYER.get_team = Form1.incheckpiece.team Then
                Return -99999999
            Else
                Return 99999999
            End If

        End If
        Dim BestScore As Integer
        Dim WorstScore As Integer
        Dim All_moves As New List(Of Form1.Efficient_moves)
        Dim CurrentScore As Integer
        Form1.board_info.castlingrights = ""
        Form1.CastlePublicLetter = ""
        All_moves = Form1.calculate_all_moves(board, WhosTurn, All_moves, False)
        All_moves = Reorder_moves(All_moves, board)
        If IsMaximising = True Then

            For Each M In All_moves
                count += 1

                board = changeboard.efficient_change_board(board, M)
                WhosTurn = Form1.switchgoes(WhosTurn)
                CurrentScore = MiniMaxFinal(board, ALPHA, BETA, depth - 1, False, count, WhosTurn)
                WhosTurn = Form1.switchgoes(WhosTurn)
                board = changeboard.efficient_undo_board(board, M)

                BestScore = Math.Max(BestScore, CurrentScore)
                ALPHA = Math.Max(ALPHA, CurrentScore)
                If BETA <= ALPHA Then
                    Exit For
                End If

            Next

            All_moves = Nothing
            Return BestScore

        ElseIf IsMaximising = False Then

            For Each M In All_moves
                count += 1
                board = changeboard.efficient_change_board(board, M)
                CurrentScore = MiniMaxFinal(board, ALPHA, BETA, depth - 1, False, count, WhosTurn)
                board = changeboard.efficient_undo_board(board, M)

                WorstScore = Math.Min(WorstScore, CurrentScore)
                BETA = Math.Min(BETA, CurrentScore)
                If BETA <= ALPHA Then
                    Exit For
                End If

            Next

            All_moves = Nothing

            Return WorstScore

        End If
    End Function
    Private Function Evaluate_board(ByVal board(,) As theboardclass, ByVal whosturn As Integer)
        Dim score As Integer = 0
        Dim perspective As Integer
        Dim PawnPositionscore As Integer
        Dim KingPositionscore As Integer
        Dim ScoreDiffAfterMoveWhite As Integer
        Dim ScoreDiffAfterMoveBlack As Integer
        Dim Valuediff As Integer

        Dim BlackCountNow As Form1.piececount = countpieces(board, 1)
        Dim WhiteCountNow As Form1.piececount = countpieces(board, 0)

        BlackCountNow.Score = GetTeamValue(BlackCountNow)
        WhiteCountNow.Score = GetTeamValue(WhiteCountNow)
        If whosturn = 0 Then
            perspective = 1
        Else
            perspective = 1
        End If

        ScoreDiffAfterMoveBlack = BlackCountNow.Score
        ScoreDiffAfterMoveWhite = WhiteCountNow.Score
        If whosturn = 0 Then
            Valuediff = ScoreDiffAfterMoveWhite - ScoreDiffAfterMoveBlack
        Else
            Valuediff = ScoreDiffAfterMoveBlack - ScoreDiffAfterMoveWhite
        End If

        For x = 0 To 7
            For y = 0 To 7
                If whosturn = 0 Then
                    Select Case board(x, y).getsym
                        Case "p"
                            score += Form1.wPawnstructureScores(x, y)
                        Case "k"
                            'score += Form1.wKingStructureScores(x, y)
                        Case "b"
                            score += Form1.wBishopStructureScore(x, y)
                        Case "h"
                            score += Form1.wKnightStructureScores(x, y)
                        Case "q"
                            score += Form1.wQueenStructureScores(x, y)
                        Case "c"
                            score += Form1.wRookStructureScores(x, y)
                    End Select
                Else
                    Select Case board(x, y).getsym
                        Case "p"
                            score += Form1.bPawnstructureScores(x, y)
                        Case "k"
                            'score += Form1.bKingStructureScores(x, y)
                        Case "b"
                            score += Form1.bBishopStructureScore(x, y)
                        Case "h"
                            score += Form1.bKnightStructureScores(x, y)
                        Case "q"
                            score += Form1.bQueenStructureScores(x, y)
                        Case "c"
                            score += Form1.bRookStructureScores(x, y)
                    End Select
                End If

            Next
        Next






        score += Valuediff

        Return score
    End Function
    Public Function countpieces(ByVal board(,) As theboardclass, ByVal team As Integer)
        Dim count As Form1.piececount
        For x = 0 To 7
            For y = 0 To 7
                If board(x, y).getteam = team Then
                    Select Case board(x, y).getsym
                        Case "p"
                            count.PawnCount += 1
                        Case "c"
                            count.CastleCount += 1
                        Case "h"
                            count.HorseCount += 1
                        Case "b"
                            count.BishopCount += 1
                        Case "q"
                            count.QueenCount += 1
                    End Select
                End If
            Next
        Next
        Return count
    End Function

    Public Function GetTeamValue(ByVal count As Form1.piececount)
        Dim value As Integer
        value += count.PawnCount * Form1.pawnvalue
        value += count.CastleCount * Form1.castlevalue
        value += count.HorseCount * Form1.horsevalue
        value += count.BishopCount * Form1.bishopvalue
        value += count.QueenCount * Form1.queenvalue
        Return value
    End Function


    Public Function check_if_in(ByVal List_to_search As List(Of Form1.position), ByVal Search_for As Form1.position)
        For Each POS In List_to_search
            If Search_for.x = POS.x And Search_for.y = POS.y Then
                Return True

            End If
        Next
        Return False
    End Function


    'Private Function Only_capture_search(ByVal board(,) As theboardclass, ByRef depth As Integer, ByRef alpha As Integer, ByRef beta As Integer, ByVal ismaxin As Boolean, ByRef count As Integer)

    '    Dim bestmove As Form1.A_Move
    '    Dim Every_move As List(Of Form1.Efficient_moves)
    '    Dim ST As returns
    '    Dim score As Integer
    '    Dim otherteam As Integer
    '    Dim bestscore As Integer = -500
    '    Dim lowestscore As Integer = 500
    '    If Me.Team_of_AI = 0 Then
    '        otherteam = 1

    '    Else
    '        otherteam = 0
    '    End If

    '    'If depth = 0 Then
    '    '    count += 1
    '    '    Return Get_all_scores(board)
    '    'End If



    '    If ismaxin = True Then
    '        bestmove = Nothing
    '        'score = -99999999
    '        Every_move = Form1.calculate_all_moves(board, Me.Team_of_AI, Every_move, False)
    '        If Every_move.Count = 0 Then
    '            Return Get_all_scores(board)
    '        End If
    '        Every_move = Reorder_moves(Every_move, board)

    '        For Each M In Every_move
    '            Me.change_board(board(M.From_x, M.From_Y).getsym, board(M.From_x, M.From_Y).getteam, M.New_x, M.New_Y, M.From_x, M.From_Y)
    '            'If M.Sym_being_taken <> "_" Then
    '            '    MsgBox("team: " & M.team_of_moving_p & " taking " & M.team_of_new_pos)
    '            'End If
    '            count += 1
    '            score = Only_capture_search(board, depth - 1, alpha, beta, False, count)

    '            'If score <> 0 Then
    '            '    MsgBox(score)
    '            'End If
    '            board = Form1.undo_move(board, M)
    '            bestscore = Math.Max(bestscore, score)

    '            alpha = Math.Max(alpha, score)
    '            If beta <= alpha Then
    '                Exit For
    '            End If

    '        Next

    '        Return bestscore
    '    Else

    '        'score = 999999999
    '        bestmove = Nothing
    '        Every_move = Form1.calculate_all_moves(board, otherteam, Every_move, True)
    '        If Every_move.Count = 0 Then
    '            Return Get_all_scores(board)
    '        End If
    '        Every_move = Reorder_moves(Every_move, board)
    '        If Form1.checked = True Then

    '        End If
    '        For Each M In Every_move
    '            Me.change_board(board(M.From_x, M.From_Y).getsym, board(M.From_x, M.From_Y).getteam, M.New_x, M.New_Y, M.From_x, M.From_Y)
    '            count += 1
    '            score = Only_capture_search(board, depth - 1, alpha, beta, True, count)
    '            lowestscore = Math.Min(lowestscore, score)


    '            board = Form1.undo_move(board, M)
    '            beta = Math.Min(beta, score)
    '            If beta <= alpha Then
    '                Exit For
    '            End If

    '        Next
    '        Return lowestscore
    '    End If
    'End Function
    Sub jjjsdc()

    End Sub
End Class































'idiot
