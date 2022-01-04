Module BookMovesPlayModule
    Public Function PlayBookMoveYorN(ByVal round As Integer, ByVal board(,) As theboardclass, ByRef outofbook As Boolean, ByVal AiPlayer As AI, ByRef MoveNum As Integer, ByVal whosturn As Integer)
        Dim move As Form1.Efficient_moves


        If outofbook = False Then
            MoveNum += 1
            If round < 20 Then

                If MoveNum = 1 Then
                    Form1.BookMoveCount = 2


                    Form1.AIPLAYER.setListOfStarterMoves(GetRandomOpening(Form1.PreviousMove, Form1.ListOfAllMasterGames, board, whosturn))
                    move = ConvertStringToPos(Form1.AIPLAYER.GetBookMove(Form1.BookMoveCount), whosturn, Form1.all_move_LIST, True)
                    board = efficient_change_board(board, move)
                    Form1.AIPLAYER.Write_AI_Info(move, Form1.BookMoveCount, 0, 1, True, 0)


                    Return board

                Else
                    Dim is_okay As Boolean = True
                    Form1.BookMoveCount += 2

                    move = ConvertStringToPos(Form1.AIPLAYER.GetBookMove(Form1.BookMoveCount), whosturn, Form1.all_move_LIST, True)
                    If move.origin.sym <> "x" Then
                        Form1.is_ai_calulating = True

                        board = efficient_change_board(board, move)
                        Dim NewMovesList As New List(Of Form1.Efficient_moves)
                        whosturn = Form1.switchgoes(whosturn)
                        NewMovesList = Form1.calculate_all_moves(board, whosturn, NewMovesList, False)


                        For Each M In NewMovesList
                            If M.target.sym <> "_" Then
                                If Form1.GetPieceValue(M.target.sym) > 0 And Form1.GetPieceValue(M.origin.sym) < Form1.GetPieceValue(M.target.sym) Then
                                    is_okay = False
                                End If
                            End If
                            If Form1.checked = True Or Form1.checkmate = True Then
                                is_okay = False
                            End If
                        Next
                        whosturn = Form1.switchgoes(whosturn)
                        Form1.reset()
                        move.OriginBoardInfo.castlingrights = Form1.board_info.castlingrights
                        If is_okay = True Then
                            board = efficient_undo_board(board, move)
                            Form1.is_ai_calulating = False
                            board = efficient_change_board(board, move)
                            Form1.AIPLAYER.Write_AI_Info(move, Form1.BookMoveCount, 0, 1, True, 0)
                            Return board
                        Else

                            board = efficient_undo_board(board, move)
                            Form1.is_ai_calulating = False
                        End If


                    End If


                End If

            End If
        End If
        outofbook = True
        If Form1.checkmate = True Then
            Return Nothing
        End If
        Return AiPlayer.get_AImove(board)
    End Function
    Public Function getNextMove(ByVal list_of_Moves As List(Of Form1.Efficient_moves), ByVal move_num As Integer)

    End Function
    Public Function GetBookMove(ByVal OpeningMove As Form1.Efficient_moves, ByVal openingmoves As List(Of String))
        'Return GetRandomOpening(OpeningMove, openingmoves)
    End Function
    Public Function GetRandomOpening(ByVal Move_Notation As Form1.Efficient_moves, ByVal OpeningsList As List(Of String), ByVal board(,) As theboardclass, ByVal whosturn As Integer)
        Dim AvalibleGames As New List(Of String)
        Dim randomnum As Integer
        Dim isokayopening As Boolean = False

        Randomize()
        AvalibleGames = CreateListOfGamesWithResponce(Move_Notation, OpeningsList, AvalibleGames, board, whosturn)
        Do Until isokayopening = True
            randomnum = Int((Rnd() * AvalibleGames.Count - 2) + 1)
            If AvalibleGames(randomnum).Count > 20 Then
                isokayopening = True
            End If
        Loop

        Return Split(AvalibleGames(randomnum), " ")
    End Function
    Public Function DecideOpeningIsSafe()

    End Function
    Public Function CreateListOfGamesWithResponce(ByVal Move_Notation As Form1.Efficient_moves, ByVal OpeningsList As List(Of String), ByVal avalibleGames As List(Of String), ByVal board(,) As theboardclass, ByVal whosturn As Integer)
        Dim nextmovelist As New List(Of String)
        Dim count As Integer = 0
        Dim Movessplit() As String
        Dim move As Form1.Efficient_moves





        For Each Game In OpeningsList
            Movessplit = Split(Game, " ")

            move = ConvertStringToPos(Movessplit(1), whosturn, Form1.all_move_LIST, False)

            If move.target.x = Move_Notation.target.x And move.target.y = Move_Notation.target.y Then
                avalibleGames.Add(Game)
            End If

        Next
        nextmovelist = Nothing
        Return avalibleGames
    End Function

    Public Function GetListOfMovesFromLongString(ByVal FirstMove As Form1.Efficient_moves, ByVal NextMovesList As List(Of String), ByVal game As String)
        Dim count As Integer = 0
        Dim Movessplit() As String


        Movessplit = Split(game, " ")

        For Each Move In Movessplit
            If InStr(Move, ".") = 0 Then
                NextMovesList.Add(Move)
            End If
        Next




        Return NextMovesList
    End Function
End Module
