Module MiniMaxModule
    Public Sub AiRootCall()

    End Sub


   
    Public Function NegaMaxTakesOnly(ByVal Board(,) As theboardclass, ByVal ALPHA As Integer, ByVal BETA As Integer, ByRef count As Integer, ByVal depth As Integer, ByVal WhosTurn As Integer)

        Dim score As Integer
        Dim Eval As Integer


        Eval = EvaluationCodeMODULE.EvaluateBoard(Board, WhosTurn)
        If Eval >= BETA Then
            count += 1
            Return BETA
        End If
        If Eval >= ALPHA Then
            ALPHA = Eval
        End If
        Dim All_takes As New List(Of Form1.Efficient_moves)
        All_takes = GetAllMovesOrdered(Board, WhosTurn, All_takes, True)
        If All_takes.Count = 0 Then
            If Form1.checkmate = True Then
                If Form1.incheckpiece.team = 0 Then
                    Return 0
                Else
                    Return -99999
                End If
            End If
        End If
        For Each Move In All_takes
           
            Move.OriginBoardInfo.castlingrights = Form1.board_info.castlingrights
            Board = Make_change(Board, WhosTurn, Move)
            score = -NegaMaxTakesOnly(Board, -BETA, -ALPHA, count, depth - 1, WhosTurn)
            Board = Undo_change(Board, WhosTurn, Move)

            If score >= BETA Then
                All_takes = Nothing

                Return BETA
            End If

            If score > ALPHA Then ALPHA = score

        Next
        All_takes = Nothing

        Return ALPHA
    End Function
    Public Function NegaMax(ByVal Board(,) As theboardclass, ByVal ALPHA As Integer, ByVal BETA As Integer, ByRef count As Integer, ByVal depth As Integer, ByVal WhosTurn As Integer)

        If depth = 0 Then
            count += 1
            Return -NegaMaxTakesOnly(Board, -BETA, -ALPHA, count, depth - 1, WhosTurn)
        End If


        Dim All_Moves As New List(Of Form1.Efficient_moves)
        Dim score As Integer

        All_Moves = GetAllMovesOrdered(Board, WhosTurn, All_Moves, False)
        
        If All_Moves.Count = 0 Then
            If Form1.checkmate = True Then
                If Form1.incheckpiece.team = 0 Then
                    Return 0
                Else
                    Return -99999
                End If
            End If

        End If
        
        For Each Move In All_Moves
            
            If Form1.AIPLAYER.GetTimer / 10 > 10 Then

                Exit For
            End If

            Move.OriginBoardInfo.castlingrights = Form1.board_info.castlingrights
            Board = Make_change(Board, WhosTurn, Move)
            score = -NegaMax(Board, -BETA, -ALPHA, count, depth - 1, WhosTurn)
            Board = Undo_change(Board, WhosTurn, Move)

            If score >= BETA Then
                All_Moves = Nothing
                Return BETA
            End If

            If score > ALPHA Then ALPHA = score

        Next
        All_Moves = Nothing
        Return ALPHA

    End Function
    Public Function StartNegaMax(ByVal board(,) As theboardclass, ByRef depth As Integer, ByVal whosTurn As Integer, ByRef count As Integer, ByRef bestScore As Integer) As Form1.Efficient_moves
        Dim BestMove As Form1.Efficient_moves
        bestScore = -999999
        Dim All_Start_Moves As New List(Of Form1.Efficient_moves)
        Dim Move_list_copy As New List(Of Form1.Efficient_moves)
        Dim score As Integer
        depth = 5
        Form1.is_ai_calulating = True
        All_Start_Moves = GetAllMovesOrdered(board, whosTurn, All_Start_Moves, False)
        Dim ITDCount As Byte = 1
        Dim maxdepth As Byte = 4
        Dim ismovepicked = False
        Do Until Form1.AIPLAYER.GetTimer / 10 > 10 Or All_Start_Moves.Count = 0
            ismovepicked = False


            For Each Move In All_Start_Moves

                If Form1.AIPLAYER.GetTimer / 10 > 10 Then
                    ITDCount -= 1
                    Exit For
                End If

                Move.OriginBoardInfo.castlingrights = Form1.ogcastlingrights
                board = Make_change(board, whosTurn, Move)
                score = -NegaMax(board, -99999999, 99999999, count, ITDCount, whosTurn)
                Move.movescore = score
                board = Undo_change(board, whosTurn, Move)

                If score >= bestScore Then
                    BestMove = Move
                    bestScore = score
                    ismovepicked = True
                End If
            Next
            All_Start_Moves = Iterative_deepening_reorder(All_Start_Moves)
            ITDCount += 1
        Loop


        depth = ITDCount
        All_Start_Moves = Nothing
        Form1.is_ai_calulating = False
        Return BestMove
    End Function
    Private Function Make_change(ByVal board(,) As theboardclass, ByRef Whosturn As Integer, ByRef MOVE As Form1.Efficient_moves)
        Whosturn = Form1.switchgoes(Whosturn)
        board = changeboard.efficient_change_board(board, MOVE)
        Return board
    End Function
    Private Function Undo_change(ByVal board(,) As theboardclass, ByRef Whosturn As Integer, ByVal MOVE As Form1.Efficient_moves)
        board = changeboard.efficient_undo_board(board, MOVE)
        Whosturn = Form1.switchgoes(Whosturn)
        Return board



    End Function

    Public Function GetAllMovesOrdered(ByVal board(,) As theboardclass, ByVal whoturn As Integer, ByRef All_moves As List(Of Form1.Efficient_moves), ByVal is_takes As Boolean)

        Form1.board_info.castlingrights = ""
        Form1.CastlePublicLetter = ""
        All_moves = Form1.calculate_all_moves(board, whoturn, All_moves, is_takes)
        All_moves = Form1.AIPLAYER.Reorder_moves(All_moves, board)
        Form1.ogcastlingrights = Form1.board_info.castlingrights

        Return All_moves
    End Function

    Public Function Iterative_deepening_reorder(ByVal all_moves As List(Of Form1.Efficient_moves))
        Dim reordered As New List(Of Form1.Efficient_moves)
        Dim count As Integer
        Dim counter As Integer = 0
        Dim isokay As Boolean = False
        Dim pos As Form1.position
        For Each move In all_moves
            count = 0
            If counter = 0 Then
                reordered.Add(move)
            Else
                isokay = False
                For Each FMOVE In reordered
                    If FMOVE.movescore <= move.movescore Then
                        reordered.Insert(count, move)
                        isokay = True
                        Exit For

                    End If
                    count += 1
                Next
                If isokay = False Then
                    reordered.Add(move)
                End If
            End If

            counter += 1
        Next
        all_moves = reordered
        reordered = Nothing

        Return all_moves
    End Function
End Module
