Module ficsfileconverter
    Public Function ConvertFileFromFicsRAWToEachLine(ByVal filename As String, ByVal ListOfOpenings As List(Of String))

        Dim line As String
        FileOpen(1, filename, OpenMode.Input)
        Do Until EOF(1)
            line = LineInput(1)
            If InStr(line, "1.") > 0 And InStr(line, "1.") < 4 Then
                ListOfOpenings.Add(line)
            End If
        Loop
        FileClose(1)



        Return ListOfOpenings
    End Function


    Public Sub ConvertGamesToMoves(ByVal ListOfOpenings As List(Of Form1.position))
        For Each Game In ListOfOpenings

        Next

    End Sub
    Public Function ConvertFromStringToList(ByVal Movestring As String, ByVal ListOfMoves As List(Of String))
        Dim list() As String
        list = Split(Movestring, " ")
        For Each M In list
            If InStr(M, ".") = 0 Then
                ListOfMoves.Add(M)
            End If
        Next
        Return ListOfMoves
    End Function

    Public Function FindGameToCopy(ByVal listofgames As List(Of String))
        Dim StringOfMoves As String
        Dim listsplit() As String
        Dim MoveLetter As String
        Dim movestructure As Form1.Efficient_moves
        Dim previous As Form1.Efficient_moves
        Dim all_moves As List(Of Form1.Efficient_moves)

        For Each StringOfMovesRaw In listofgames
            listsplit = Split(StringOfMovesRaw, " ")
            MoveLetter = listsplit(1)
            If InStr(MoveLetter, ".") = 0 Then
                movestructure = ConvertStringToPos(MoveLetter, Form1.whosgo, all_moves, False)
                If reverseMove(movestructure).target.x = Form1.PreviousMove.target.x And reverseMove(movestructure).target.y = Form1.PreviousMove.target.y Then
                    StringOfMoves = StringOfMovesRaw
                    Exit For
                End If
            End If

        Next

        Return StringOfMoves
    End Function

    Public Function reverseMove(ByVal Move As Form1.Efficient_moves)
        Dim ReverseMoveReturn As Form1.Efficient_moves
        Select Case Move.origin.y
            Case 0
                ReverseMoveReturn.origin.y = 7
            Case 1
                ReverseMoveReturn.origin.y = 6
            Case 2
                ReverseMoveReturn.origin.y = 5
            Case 3
                ReverseMoveReturn.origin.y = 4
            Case 4
                ReverseMoveReturn.origin.y = 3
            Case 5
                ReverseMoveReturn.origin.y = 2
            Case 6
                ReverseMoveReturn.origin.y = 1
            Case 7
                ReverseMoveReturn.origin.y = 0

        End Select

        Select Case Move.target.y
            Case 0
                ReverseMoveReturn.target.y = 7
            Case 1
                ReverseMoveReturn.target.y = 6
            Case 2
                ReverseMoveReturn.target.y = 5
            Case 3
                ReverseMoveReturn.target.y = 4
            Case 4
                ReverseMoveReturn.target.y = 3
            Case 5
                ReverseMoveReturn.target.y = 2
            Case 6
                ReverseMoveReturn.target.y = 1
            Case 7
                ReverseMoveReturn.target.y = 0

        End Select

        ReverseMoveReturn.target.x = Move.target.x
        ReverseMoveReturn.origin.x = Move.origin.x
        ReverseMoveReturn.origin.sym = Move.origin.sym
        Return Move
    End Function
    Public Function FindOpeningResponce(ByVal FirstMove As Form1.Efficient_moves, ByVal ListOfgames As List(Of String), ByVal NextMovesList As List(Of Form1.Efficient_moves))
        Dim count As Integer = 0
        Dim Movessplit() As String

        For Each Game In ListOfgames
            Movessplit = Split(Game, " ")
            If ConvertStringToPos(Movessplit(1), Form1.whosgo, NextMovesList, False).origin.x = FirstMove.origin.x And ConvertStringToPos(Movessplit(1), Form1.whosgo, NextMovesList, False).origin.y = FirstMove.origin.y And ConvertStringToPos(Movessplit(1), Form1.whosgo, NextMovesList, False).target.x = FirstMove.target.x And ConvertStringToPos(Movessplit(1), Form1.whosgo, NextMovesList, False).target.y = FirstMove.target.y Then
                For Each Move In Movessplit
                    If InStr(Move, ".") = 0 Then

                        NextMovesList.Add(ConvertStringToPos(Move, Form1.whosgo, NextMovesList, False))
                    End If
                Next
                Exit For
            End If

        Next
        Return NextMovesList
    End Function
    Public Function ConvertLetterPosToMyPos(ByVal LetterPos As String)
        Dim Number As Integer
        Select Case LetterPos
            Case "1"
                Number = 7
            Case "2"
                Number = 6
            Case "3"
                Number = 5
            Case "4"
                Number = 4
            Case "5"
                Number = 3
            Case "6"
                Number = 2
            Case "7"
                Number = 1
            Case "8"
                Number = 0
            Case "a"
                Number = 0
            Case "b"
                Number = 1
            Case "c"
                Number = 2
            Case "d"
                Number = 3
            Case "e"
                Number = 4
            Case "f"
                Number = 5
            Case "g"
                Number = 6
            Case "h"
                Number = 7
        End Select
        Return Number
    End Function
    Public Function ConvertStringToPos(ByVal StringMove As String, ByVal WhosTurn As Integer, ByVal all_moves As List(Of Form1.Efficient_moves), ByVal usemovelist As Boolean) As Form1.Efficient_moves
        Dim Move As Form1.Efficient_moves
        Dim isokay As Boolean = False
        Dim Has_set As Boolean = False
        If usemovelist = True Then
            Select Case StringMove.Length
                Case 1

                Case 2
                    Move.origin.sym = "p"
                    Move.target.x = ConvertLetterPosToMyPos(StringMove(0))
                    Move.target.y = ConvertLetterPosToMyPos(StringMove(1))
                    If WhosTurn = 0 Then
                        For looper = Move.target.y - 1 To 0 Step -1
                            If Form1.board(Move.target.x, looper).getsym = "p" Then
                                Move.origin.x = Move.target.x
                                Move.origin.y = looper
                                looper = 0
                                Has_set = True
                            End If
                        Next
                    Else
                        For looper = Move.target.y + 1 To 7
                            If Form1.board(Move.target.x, looper).getsym = "p" Then
                                Move.origin.x = Move.target.x
                                Move.origin.y = looper
                                looper = 7
                                Has_set = True
                            End If
                        Next
                    End If
                    
                    'Move = reverseMove(Move)
                    Move.target.sym = "_"
                    Move.SpecialMoveFlag = 0
                    Move.origin.team = 0
                Case 3
                    If StringMove = "O-O" Then
                        For Each M In all_moves
                            If M.SpecialMoveFlag = 2 Then
                                If M.target.x = 6 Then

                                    Move.origin.x = M.origin.x
                                    Move.origin.y = M.origin.y
                                    Move.origin.sym = M.origin.sym
                                    Move.SpecialMoveFlag = M.SpecialMoveFlag
                                    Move.target.x = M.target.x
                                    Move.target.y = M.target.y
                                    Move.target.sym = M.target.sym
                                    Move.OriginBoardInfo.castlingrights = M.OriginBoardInfo.castlingrights

                                    Has_set = True
                                End If
                            End If
                        Next
                    Else
                        Move.origin.sym = convert(LCase(StringMove(0)))
                        Move.target.x = ConvertLetterPosToMyPos(StringMove(1))
                        Move.target.y = ConvertLetterPosToMyPos(StringMove(2))
                        For Each M In all_moves
                            If M.origin.sym = Move.origin.sym And M.target.x = Move.target.x And M.target.y = Move.target.y Then
                                Move.origin.x = M.origin.x
                                Move.origin.y = M.origin.y
                                Move.SpecialMoveFlag = M.SpecialMoveFlag
                                Move.target.sym = "_"
                                Move.origin.team = 0
                                Has_set = True
                            End If
                        Next
                    End If

                    

                Case 4
                    'if takingpiece
                    If InStr(StringMove, "x") Then

                        Move.target.x = ConvertLetterPosToMyPos(StringMove(2))
                        Move.target.y = ConvertLetterPosToMyPos(StringMove(3))
                        Move.target.sym = Form1.board(Move.target.x, Move.target.y).getsym
                        For Each M In all_moves
                            If M.target.x = Move.target.x And M.target.y = Move.target.y Then
                                If M.origin.sym = "p" Then
                                    Move.origin.x = M.origin.x
                                    Move.origin.y = M.origin.y
                                    Move.origin.sym = M.origin.sym
                                    Move.SpecialMoveFlag = M.SpecialMoveFlag
                                    Move.target.sym = M.target.sym
                                    Move.origin.team = 0
                                    Has_set = True
                                    isokay = True
                                End If

                            End If
                        Next
                        'if cannot take, ai decides move
                      
                    Else
                        'not taking piece
                        Move.origin.sym = convert(StringMove(0))
                        Move.origin.x = ConvertLetterPosToMyPos(StringMove(1))
                        Move.target.x = ConvertLetterPosToMyPos(StringMove(2))
                        Move.target.y = ConvertLetterPosToMyPos(StringMove(3))
                        For Each M In all_moves
                            If M.target.x = Move.target.x And M.target.y = Move.target.y Then
                                If M.origin.sym = Move.origin.sym Then
                                    Move.origin.x = M.origin.x
                                    Move.origin.y = M.origin.y
                                    Move.origin.sym = M.origin.sym
                                    Move.SpecialMoveFlag = M.SpecialMoveFlag
                                    Move.target.sym = "_"
                                    Move.origin.team = 0
                                    isokay = True
                                    Has_set = True
                                End If

                            End If
                        Next
                       
                    End If


                Case 5

                    If StringMove = "O-O-O" Then
                        For Each M In all_moves
                            If M.SpecialMoveFlag = 2 Then
                                If M.target.x = 2 Then

                                    Move.origin.x = M.origin.x
                                    Move.origin.y = M.origin.y
                                    Move.origin.sym = M.origin.sym
                                    Move.SpecialMoveFlag = M.SpecialMoveFlag
                                    Move.target.x = M.target.x
                                    Move.target.y = M.target.y
                                    Move.target.sym = M.target.sym
                                    Move.OriginBoardInfo.castlingrights = M.OriginBoardInfo.castlingrights
                                    Has_set = True

                                End If
                            End If
                        Next
                    ElseIf InStr(StringMove, "+") = 5 Then
                        Move.origin.sym = "q"
                        Move.target.x = ConvertLetterPosToMyPos(StringMove(2))
                        Move.target.y = ConvertLetterPosToMyPos(StringMove(3))
                        For Each M In all_moves
                            If M.origin.sym = Move.origin.sym And M.target.x = Move.target.x And M.target.y = Move.target.y Then
                                Move.origin.x = M.origin.x
                                Move.origin.y = M.origin.y
                                Move.OriginBoardInfo.castlingrights = M.OriginBoardInfo.castlingrights
                                Move.SpecialMoveFlag = M.SpecialMoveFlag
                                Move.origin.team = M.origin.team
                                Has_set = True
                            End If
                        Next
                    End If




            End Select
            If Has_set = False Then
                Move.origin.sym = "x"
            End If
        Else











            'not using moves
            Select Case StringMove.Length
                Case 1

                Case 2
                    Move.origin.sym = "p"
                    Move.target.x = ConvertLetterPosToMyPos(StringMove(0))
                    Move.target.y = ConvertLetterPosToMyPos(StringMove(1))
                    If WhosTurn = 0 Then
                        For looper = Move.target.y - 1 To 0 Step -1
                            If Form1.board(Move.target.x, looper).getsym = "p" Then
                                Move.origin.x = Move.target.x
                                Move.origin.y = looper
                                looper = 0
                            End If
                        Next
                    Else
                        For looper = Move.target.y + 1 To 7
                            If Form1.board(Move.target.x, looper).getsym = "p" Then
                                Move.origin.x = Move.target.x
                                Move.origin.y = looper
                                looper = 7
                            End If
                        Next
                    End If
                    'Move = reverseMove(Move)
                    Move.target.sym = "_"
                    Move.SpecialMoveFlag = 0
                    Move.origin.team = 0
                Case 3
                Case 4

                    'If InStr(StringMove, "x") Then
                    '    Move.origin.sym = StringMove(0)
                    '    Move.target.x = ConvertLetterPosToMyPos(StringMove(2))
                    '    Move.target.y = ConvertLetterPosToMyPos(StringMove(3))
                    '    For Each M In all_moves
                    '        If M.target.x = Move.target.x And M.target.y = Move.target.y Then
                    '            Move.origin.x = M.origin.x
                    '            Move.origin.y = M.origin.y
                    '            Move.origin.sym = M.origin.sym
                    '            Move.SpecialMoveFlag = M.SpecialMoveFlag
                    '            Move.target.sym = "_"
                    '            Move.origin.team = 0
                    '        End If
                    '    Next
                    'End If

                Case 5

            End Select
        End If
        




        Return Move
    End Function
    Private Function convert(ByVal letter As String)
        Dim newstring As String

        Select Case letter
            Case "R", "r"
                newstring = "c"

            Case "N", "n"
                newstring = "h"
           
            Case Else
                newstring = letter
        End Select

        Return newstring
    End Function
End Module
