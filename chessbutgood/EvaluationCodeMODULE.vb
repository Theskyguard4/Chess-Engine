Module EvaluationCodeMODULE
    Public Function EvaluateBoard(ByVal board(,) As theboardclass, ByVal WhosTurn As Integer)
        Dim Score As Integer
        Dim Perspective As Integer
        

        If WhosTurn = 0 Then Perspective = 1 Else Perspective = -1

        Score = (MaterialEval(board) + PieceStructure(board, WhosTurn)) * Perspective
        Return Score
    End Function
    Public Function MaterialEval(ByVal board(,) As theboardclass)
        Dim MaterialScore As Integer
        Dim BlackCountNow As Form1.piececount = Form1.AIPLAYER.countpieces(board, 1)
        Dim WhiteCountNow As Form1.piececount = Form1.AIPLAYER.countpieces(board, 0)
        MaterialScore = (Form1.pawnvalue * (BlackCountNow.PawnCount - WhiteCountNow.PawnCount) +
                                Form1.queenvalue * (BlackCountNow.QueenCount - WhiteCountNow.QueenCount) +
                                Form1.bishopvalue * (BlackCountNow.BishopCount - WhiteCountNow.BishopCount) +
                                Form1.castlevalue * (BlackCountNow.CastleCount - WhiteCountNow.CastleCount) +
                                Form1.horsevalue * (BlackCountNow.HorseCount - WhiteCountNow.HorseCount))
        Return MaterialScore
    End Function
    Public Function PieceStructure(ByVal board(,) As theboardclass, ByVal whosturn As Integer)
        Dim StructureScore As Integer
        Dim whitestructure As Integer
        Dim blackstructure As Integer
        For y = 0 To 7
            For x = 0 To 7
                If whosturn = 0 Then
                    Select Case board(x, y).getsym
                        Case "p"
                            blackstructure += Form1.bPawnstructureScores(x, y)
                        Case "b"
                            blackstructure += Form1.bBishopStructureScore(x, y)
                        Case "h"
                            blackstructure += Form1.bKnightStructureScores(x, y)
                        Case "q"
                            blackstructure += Form1.bQueenStructureScores(x, y)
                        Case "k"
                            blackstructure += Form1.bKingStructureScores(x, y)
                        Case "c"
                            blackstructure += Form1.bRookStructureScores(x, y)

                    End Select
                Else
                    Select Case board(x, y).getsym
                        Case "p"
                            whitestructure += Form1.wPawnstructureScores(x, y)
                        Case "b"
                            whitestructure += Form1.wBishopStructureScore(x, y)
                        Case "h"
                            whitestructure += Form1.wBishopStructureScore(x, y)
                        Case "q"
                            whitestructure += Form1.wQueenStructureScores(x, y)
                        Case "k"
                            whitestructure += Form1.wKingStructureScores(x, y)
                        Case "c"
                            whitestructure += Form1.wRookStructureScores(x, y)

                    End Select
                End If
                        


            Next
        Next


        StructureScore = whitestructure + blackstructure
        Return StructureScore
    End Function
End Module
