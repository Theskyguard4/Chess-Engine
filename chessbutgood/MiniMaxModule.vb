Module MiniMaxModule
    Public Sub AiRootCall()

    End Sub


   
    Public Function NegaMaxTakesOnly(ByVal Board(,) As theboardclass, ByVal ALPHA As Integer, ByVal BETA As Integer, ByRef count As Integer, ByVal depth As Integer, ByVal WhosTurn As Integer, ByVal ply As Integer)

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
                If Form1.incheckpiece.team = WhosTurn Then
                    Return 999999
                Else
                    Return -999999
                End If
            End If
        End If

        For Each Move In All_takes

            Move.OriginBoardInfo.castlingrights = Form1.board_info.castlingrights
            Board = Make_change(Board, WhosTurn, Move)
            score = -NegaMaxTakesOnly(Board, -BETA, -ALPHA, count, depth - 1, WhosTurn, ply)
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
    Public Function NegaMax(ByVal Board(,) As theboardclass, ByVal ALPHA As Integer, ByVal BETA As Integer, ByRef count As Integer, ByVal depth As Integer, ByVal WhosTurn As Integer, ByVal ply As Integer)


        If depth = 0 Then
            count += 1
            Return -NegaMaxTakesOnly(Board, -BETA, -ALPHA, count, depth - 1, WhosTurn, ply)
        End If


        Dim All_Moves As New List(Of Form1.Efficient_moves)
        Dim score As Integer
        Dim max As Integer
        All_Moves = GetAllMovesOrdered(Board, WhosTurn, All_Moves, False)

        If All_Moves.Count = 0 Then
            If Form1.checkmate = True Then
                If Form1.incheckpiece.team = WhosTurn Then
                    Return 999999
                Else
                    Return -999999
                End If
            Else
                If WhosTurn = 0 Then
                    Return -99999
                Else
                    Return 0
                End If
            End If

        End If




        For Each Move In All_Moves

            If Form1.AIPLAYER.GetTimer / 10 > 10 Then
                Exit For
            End If

            Move.OriginBoardInfo.castlingrights = Form1.board_info.castlingrights
            Board = Make_change(Board, WhosTurn, Move)
            score = -NegaMax(Board, -BETA, -ALPHA, count, depth - 1, WhosTurn, 1)
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
        bestScore = -9999999
        Dim All_Start_Moves As New List(Of Form1.Efficient_moves)
        Dim Move_list_copy As New List(Of Form1.Efficient_moves)
        Dim score As Integer
        depth = 5
        Form1.is_ai_calulating = True
        All_Start_Moves = GetAllMovesOrdered(board, whosTurn, All_Start_Moves, False)
        Dim ITDCount As Byte = 1
        Dim maxdepth As Byte = 4
        Dim hasMovedsave As Boolean
        Dim ply As Integer = 0
        Dim ismovepicked = False
        Dim quitloop As Boolean = True
        Dim bestmovefromfullsearch As Form1.Efficient_moves
        Dim bestscorefullsearch As Integer
        SetEndGameWieght(board)
        Do Until Form1.AIPLAYER.GetTimer / 10 > 10 Or All_Start_Moves.Count = 0 Or ITDCount >= 100 Or bestScore = 999999
            ismovepicked = False
            For Each Move In All_Start_Moves
                hasMovedsave = Move.has_moved

                'If Move.origin.sym = "p" Then
                '    If Move.target.y = 7 Then
                '        MsgBox("")
                '    End If
                'End If

                If Form1.AIPLAYER.GetTimer / 10 > 10 Then
                    quitloop = False
                    Exit For
                End If
                Move.OriginBoardInfo.castlingrights = Form1.ogcastlingrights
                board = Make_change(board, whosTurn, Move)
                score = -NegaMax(board, -99999999, 99999999, count, ITDCount, whosTurn, 1)
                Move.movescore = score
                board = Undo_change(board, whosTurn, Move)
                board(Move.origin.x, Move.origin.x).set_hasmoved(hasMovedsave)
                If score >= bestScore Then
                    BestMove = Move
                    bestScore = score
                    ismovepicked = True
                End If
               
            Next
            If quitloop = True Then
                bestmovefromfullsearch = BestMove
                bestscorefullsearch = bestScore
            End If

            All_Start_Moves = Iterative_deepening_reorder(All_Start_Moves)

            ITDCount += 1

        Loop

        bestScore = bestscorefullsearch

        depth = ITDCount
        All_Start_Moves = Nothing
        Form1.is_ai_calulating = False
        Return bestmovefromfullsearch


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




    Public Function NegamaxWithTranspotable(ByVal Board(,) As theboardclass, ByVal ALPHA As Integer, ByVal BETA As Integer, ByRef count As Integer, ByVal depth As Integer, ByVal WhosTurn As Integer, ByVal colour As Integer)
        Dim ALPHAOrigin As Integer = ALPHA
        count += 1
        Dim TranspoEntrySave As Form1.HashData = Form1.TranspoTable(Get_Index(Form1.CurrentHash))
        If Form1.AIPLAYER.GetTimer / 10 > 10 Then
            Exit Function
        End If
        If ZobristHashingModule.CompareHashInTable(Form1.TranspoTable, Form1.CurrentHash) = True And TranspoEntrySave.depth >= depth Then
            Form1.TTHITCount += 1
            Select Case TranspoEntrySave.entryflag
                Case "UPPER"
                    BETA = Math.Min(BETA, TranspoEntrySave.Eval)
                Case "LOWER"
                    ALPHA = Math.Max(ALPHA, TranspoEntrySave.Eval)
                Case "EXACT"
                    Return TranspoEntrySave.Eval
            End Select
            If ALPHA >= BETA Then
                Return TranspoEntrySave.Eval
            End If

        End If

        If depth = 0 Then

            Return -NegamaxWithTranspotableTakesonly(Board, -BETA, -ALPHA, count, depth - 1, WhosTurn, -colour)
        End If


        Dim All_Moves As New List(Of Form1.Efficient_moves)
        Dim score As Long
        Dim max As Integer
        All_Moves = GetAllMovesOrdered(Board, WhosTurn, All_Moves, False)

        If All_Moves.Count = 0 Then
            If Form1.checkmate = True Then
                If Form1.incheckpiece.team = 0 Then
                    Return 999999
                Else
                    Return -999999

                End If
            
                Return 0
            End If

        End If


        score = -999999999

        For Each Move In All_Moves

            Move.OriginBoardInfo.castlingrights = Form1.board_info.castlingrights
            Board = Make_change(Board, WhosTurn, Move)
            score = Math.Max(score, -NegamaxWithTranspotable(Board, -BETA, -ALPHA, count, depth - 1, WhosTurn, -colour))
            Board = Undo_change(Board, WhosTurn, Move)
            ALPHA = Math.Max(ALPHA, score)
            If ALPHA >= BETA Then
                Exit For
            End If

        Next
        Dim TransoNew As Form1.HashData

        TransoNew.Eval = score
        TransoNew.Hash = Form1.CurrentHash
        If score <= ALPHAOrigin Then
            TransoNew.entryflag = "UPPER"
        ElseIf score >= BETA Then
            TransoNew.entryflag = "LOWER"
        Else
            TransoNew.entryflag = "EXACT"
        End If
        TransoNew.depth = depth
        If Form1.TranspoTable(Get_Index(Form1.CurrentHash)).depth < depth Then
            Form1.TranspoTable(Get_Index(Form1.CurrentHash)) = TransoNew
        End If
        All_Moves = Nothing
        Return score
    End Function

    Public Function NegamaxWithTranspotableTakesonly(ByVal Board(,) As theboardclass, ByVal ALPHA As Integer, ByVal BETA As Integer, ByRef count As Integer, ByVal depth As Integer, ByVal WhosTurn As Integer, ByVal colour As Integer)
        Dim ALPHAOrigin As Integer = ALPHA
        count += 1
        Dim TranspoEntrySave As Form1.HashData = Form1.TranspoTable(Get_Index(Form1.CurrentHash))
        
        If ZobristHashingModule.CompareHashInTable(Form1.TranspoTable, Form1.CurrentHash) = True And TranspoEntrySave.depth >= depth Then
            Form1.TTHITCount += 1
            Select Case TranspoEntrySave.entryflag
                Case "UPPER"
                    BETA = Math.Min(BETA, TranspoEntrySave.Eval)
                Case "LOWER"
                    ALPHA = Math.Max(ALPHA, TranspoEntrySave.Eval)
                Case "EXACT"
                    Return TranspoEntrySave.Eval
            End Select
            If ALPHA >= BETA Then
                Return TranspoEntrySave.Eval
            End If

        End If
        Dim eval As Integer = EvaluateBoard(Board, WhosTurn)

        If eval >= BETA Then
            Return BETA
        End If
        ALPHA = Math.Max(ALPHA, eval)

        Dim All_Moves As New List(Of Form1.Efficient_moves)
        Dim score As Long
        Dim max As Integer
        All_Moves = GetAllMovesOrdered(Board, WhosTurn, All_Moves, True)

        If All_Moves.Count = 0 Then
            If Form1.checkmate = True Then
                If Form1.incheckpiece.team = 0 Then
                    Return 999999
                Else
                    Return -999999

                End If

                Return 0
            End If

        End If


        score = -999999999

        For Each Move In All_Moves

            Move.OriginBoardInfo.castlingrights = Form1.board_info.castlingrights
            Board = Make_change(Board, WhosTurn, Move)
            score = Math.Max(score, -NegamaxWithTranspotableTakesonly(Board, -BETA, -ALPHA, count, depth - 1, WhosTurn, -colour))
            Board = Undo_change(Board, WhosTurn, Move)
            ALPHA = Math.Max(ALPHA, score)
            If ALPHA >= BETA Then
                Exit For
            End If

        Next
        Dim TransoNew As Form1.HashData

        TransoNew.Eval = score
        TransoNew.Hash = Form1.CurrentHash
        If score <= ALPHAOrigin Then
            TransoNew.entryflag = "UPPER"
        ElseIf score >= BETA Then
            TransoNew.entryflag = "LOWER"
        Else
            TransoNew.entryflag = "EXACT"
        End If
        TransoNew.depth = depth
        If Form1.TranspoTable(Get_Index(Form1.CurrentHash)).depth < depth Then
            Form1.TranspoTable(Get_Index(Form1.CurrentHash)) = TransoNew
        End If

        Form1.TTSize += 1
        All_Moves = Nothing
        Return score
    End Function
End Module
