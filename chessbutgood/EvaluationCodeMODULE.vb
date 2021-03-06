Module EvaluationCodeMODULE
    Public Function EvaluateBoard(ByVal board(,) As theboardclass, ByVal WhosTurn As Integer)
        Dim Score As Integer
        Dim Perspective As Integer
        



        If WhosTurn = 0 Then Perspective = 1 Else Perspective = -1

        Score = (MaterialEval(board) + PieceStructure(board, WhosTurn) + PushKingToCorner(board, WhosTurn) + bringkingscloser(board, WhosTurn) + -KingSafety(board, WhosTurn)) * Perspective
        Return Score
    End Function
    Public Sub SetEndGameWieght(ByVal board(,) As theboardclass)
        Dim whitecount As Form1.piececount = Form1.AIPLAYER.countpieces(board, 0)
        Dim blackcount As Form1.piececount = Form1.AIPLAYER.countpieces(board, 1)
        If whitecount.QueenCount = 1 And blackcount.QueenCount = 1 Or IntPieceCount(board, 0) + IntPieceCount(board, 1) > 10 Then
            Form1.EndGameWieght = 1
        Else
            Form1.EndGameWieght = 32 - (IntPieceCount(board, 0) + IntPieceCount(board, 1))
        End If
    End Sub
    Public Function bringkingscloser(ByVal board(,) As theboardclass, ByVal whosturn As Integer)
        Dim score As Integer
        Dim diff As Form1.BasicPosition
        Dim diffadded As Integer
        diff.X = Form1.whitekingloc.x - Form1.blackkingloc.x
        diff.y = Form1.whitekingloc.y - Form1.blackkingloc.y
        If diff.X < 0 Then
            diff.X = diff.X * -1
        End If
        If diff.y < 0 Then
            diff.y = diff.y * -1
        End If
        diffadded = diff.X + diff.y
        score = diffadded

        Return score * Form1.EndGameWieght
    End Function

    Public Function PushKingToCorner(ByVal board(,) As theboardclass, ByVal whosturn As Integer)
        Dim score As Integer


        Dim posofking As Form1.BasicPosition
        Dim Friendlykingpos As Form1.BasicPosition
        Dim disToMiddle As Form1.BasicPosition
        Select Case whosturn
            Case 1
                posofking.X = Form1.blackkingloc.x
                posofking.y = Form1.blackkingloc.y

                Friendlykingpos.X = Form1.whitekingloc.x
                Friendlykingpos.y = Form1.whitekingloc.y
            Case 0

                posofking.X = Form1.whitekingloc.x
                posofking.y = Form1.whitekingloc.y

                Friendlykingpos.X = Form1.blackkingloc.x
                Friendlykingpos.y = Form1.blackkingloc.y
        End Select


        'middle squares 3,3 4,3 4,4 3,4
        Dim kingdisXY As Form1.BasicPosition
        Dim KINGDiffer As Integer

        disToMiddle.X = Math.Max(3 - posofking.X, posofking.X - 4)
        disToMiddle.y = Math.Max(3 - posofking.y, posofking.y - 4)
        score += disToMiddle.X + disToMiddle.y


        'kingdisXY.X = (Friendlykingpos.X - posofking.X)
        'kingdisXY.y = (Friendlykingpos.y - posofking.y)
        'KINGDiffer = kingdisXY.X + kingdisXY.y
        'score += (14 - KINGDiffer)





        Return score * Form1.EndGameWieght
    End Function
    Public Function PawnStructure(ByVal board(,) As theboardclass, ByVal whoturn As Integer)

    End Function
    Public Function MaterialEval(ByVal board(,) As theboardclass)
        Dim MaterialScore As Integer
        Dim BlackCountNow As Form1.piececount = Form1.AIPLAYER.countpieces(board, 1)
        Dim WhiteCountNow As Form1.piececount = Form1.AIPLAYER.countpieces(board, 0)
        If Form1.changboardcount > 10 Then
            If Form1.GAMEPoint = "START" Then
                Form1.GAMEPoint = "MID"
            End If

        End If
        If BlackCountNow.QueenCount = 0 And WhiteCountNow.QueenCount = 0 Then
            If Form1.GAMEPoint <> "END" Then
                Form1.GAMEPoint = "END"
            End If

        End If


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
                            Dim yinvert As Integer
                            Select Case y
                                Case 0
                                    yinvert = 7
                                Case 1
                                    yinvert = 6
                                Case 2
                                    yinvert = 5
                                Case 3
                                    yinvert = 4
                                Case 4
                                    yinvert = 3
                                Case 5
                                    yinvert = 2
                                Case 6
                                    yinvert = 1
                                Case 7
                                    yinvert = 0
                            End Select
                            blackstructure += yinvert * 50 * Form1.EndGameWieght
                        Case "b"
                            blackstructure += Form1.bBishopStructureScore(x, y)
                        Case "h"
                            blackstructure += Form1.bKnightStructureScores(x, y)
                        Case "q"
                            blackstructure += Form1.bQueenStructureScores(x, y)
                        Case "k"
                            Select Case Form1.GAMEPoint
                                Case "START"
                                    blackstructure += Form1.bKingSTARTStructureScores(x, y)
                                Case "MID"
                                    blackstructure += Form1.bKingSTARTStructureScores(x, y)
                                Case "END"
                                    blackstructure += Form1.bKingENDStructureScores(x, y)
                            End Select
                        Case "c"
                            blackstructure += Form1.bRookStructureScores(x, y)

                    End Select
                Else
                    Select Case board(x, y).getsym
                        Case "p"
                            whitestructure += Form1.wPawnstructureScores(x, y)
                            whitestructure += y * 50 * Form1.EndGameWieght
                        Case "b"
                            whitestructure += Form1.wBishopStructureScore(x, y)
                        Case "h"
                            whitestructure += Form1.wBishopStructureScore(x, y)
                        Case "q"
                            Select Case Form1.GAMEPoint
                                Case "START"
                                    whitestructure += Form1.wQueenStartStructureScores(x, y)
                                Case Else
                                    whitestructure += Form1.wQueenStructureScores(x, y)
                            End Select
                        Case "k"
                            Select Case Form1.GAMEPoint
                                Case "START"
                                    whitestructure += Form1.wKingSTARTStructureScores(x, y)
                                Case "MID"
                                Case "END"
                                    whitestructure += Form1.wKingENDStructureScores(x, y)
                            End Select
                        Case "c"
                            whitestructure += Form1.wRookStructureScores(x, y)

                    End Select
                End If



            Next
        Next


        StructureScore = whitestructure + blackstructure
        Return StructureScore
    End Function
    Public Function IntPieceCount(ByVal board(,) As theboardclass, ByVal team As Integer)
        Dim count As Integer
        For x = 0 To 7
            For y = 0 To 7
                If board(x, y).getsym <> "_" And board(x, y).getteam = team Then
                    count += 1
                End If
            Next
        Next
        Return count
    End Function
    Public Function KingSafety(ByVal board(,) As theboardclass, ByVal Whosgo As Integer)
        Dim score As Integer = 0
        Dim ValueOfAttack As Integer
        Dim SquareAttackcount As Integer
        Dim KingZone As New List(Of Form1.BasicPosition)
        Dim TempPos As Form1.BasicPosition
        Dim Value As Integer
        Dim isokay As Boolean = False
        Dim AttackingWieght() As Integer = {0, 0, 50, 75, 88, 94, 97, 99}
        Select Case Whosgo
            Case 0
                For Each Pos In board(Form1.whitekingloc.x, Form1.whitekingloc.y).getmoves

                    TempPos.X = Pos.x
                    TempPos.y = Pos.y
                    KingZone.Add(TempPos)

                Next
                



            Case 1
                For Each Pos In board(Form1.blackkingloc.x, Form1.blackkingloc.y).getmoves

                    TempPos.X = Pos.x
                    TempPos.y = Pos.y
                    KingZone.Add(TempPos)

                Next
        End Select
        For x = 0 To 7
            For y = 0 To 7

                If board(x, y).getteam <> 2 And board(x, y).getteam <> Whosgo Then
                    isokay = False
                    For Each AttackingSquare In board(x, y).getmoves
                        For Each Pos In KingZone
                            If AttackingSquare.x = Pos.X And AttackingSquare.y = Pos.y Then
                                If isokay = False Then
                                    SquareAttackcount += 1
                                End If
                                ValueOfAttack += GetValueKS(board(x, y).getsym)
                                isokay = True
                            End If
                        Next
                    Next


                End If
            Next
        Next
        KingZone = Nothing
        score = ValueOfAttack * AttackingWieght(SquareAttackcount) / 100
       
        Return score
    End Function
    Private Function GetValueKS(ByVal sym As String)
        Select Case sym
            Case "h"
                Return 20
            Case "c"
                Return 40
            Case "q"
                Return 80
            Case "b"
                Return 20
            Case Else
                Return 0
        End Select
    End Function

End Module
