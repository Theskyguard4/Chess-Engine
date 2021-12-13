Module ZobristHashingModule
    Public Function Get_Index(ByVal Hash As Long)
        Dim index As Integer = Hash Mod Form1.TranspoTable.Count
        If index < 0 Then
            index *= -1
        End If
        Return index
    End Function

    Public Function CompareHashInTable(ByVal TT() As Form1.HashData, ByVal CHash As Long)
        Try
            If TT(Get_Index(CHash)).Hash = CHash Then
                Return True
            Else
                Return False
            End If
        Catch ex As IndexOutOfRangeException
            MsgBox("ERROR: " & Get_Index(CHash) & " Is Not In TT Array")
        End Try
        
    End Function

    Public Function GetHashEval(ByVal TT() As Form1.HashData, ByVal CHash As Long)
        Return TT(Get_Index(CHash)).Eval
    End Function

    Public Function InitZoHash(ByVal table(,) As String)
        Dim num As Integer
        Randomize()
        For Square = 0 To 63
            For Piece = 0 To 11
                num = Int((Rnd() * 99999))
                table(Square, Piece) = Random_64bit_bin() 'Convert.ToString(num, 2)
                'table(Square, Piece) = table(Square, Piece).PadRight(63, "0")

            Next
        Next

        Return table
    End Function
    Public Function HashBoard(ByVal board(,) As theboardclass)
        Dim h As Long
        Dim j As Integer
        Dim count As Integer = 0


        For y = 0 To 7
            For x = 0 To 7

                If board(x, y).getsym <> "_" Then
                    If board(x, y).getteam = 0 Then
                        Select Case board(x, y).getsym
                            Case "p"
                                j = 0
                            Case "k"
                                j = 1
                            Case "q"
                                j = 2
                            Case "b"
                                j = 3
                            Case "h"
                                j = 4
                            Case "c"
                                j = 5
                        End Select
                    ElseIf board(x, y).getteam = 1 Then
                        Select Case board(x, y).getsym
                            Case "p"
                                j = 6
                            Case "k"
                                j = 7
                            Case "q"
                                j = 8
                            Case "b"
                                j = 9
                            Case "h"
                                j = 10
                            Case "c"
                                j = 11
                        End Select
                    End If
                    Dim g As Long = Convert.ToInt64(Form1.HashTableRan(count, j), 2)
                    h = h Xor g

                End If
                count += 1


            Next
        Next

        Return h
    End Function
    Public Function UpdateHash(ByVal board(,) As theboardclass, ByVal Move As Form1.Efficient_moves, ByVal Hash As Long)
        Dim g As Long = Hash
        Dim originsquare As Integer
        Dim targetsquare As Integer
        Dim newsquare As Integer
        Dim team As Integer
        Dim sym As String
        Dim x As Integer
        Dim y As Integer
        Dim j As Integer
        Dim squareinhasharray As Integer
        For II = 0 To 2
            squareinhasharray = 0
            Select Case II
                Case 0
                    team = Move.origin.team
                    sym = Move.origin.sym
                    x = Move.origin.x
                    y = Move.origin.y
                Case 1
                    team = Move.target.team
                    sym = Move.target.sym
                    x = Move.target.x
                    y = Move.target.y
                Case 2
                    team = Move.origin.team
                    sym = Move.origin.sym
                    x = Move.origin.x
                    y = Move.origin.y
            End Select
            For yy = 0 To y
                If y = y Then
                    For xx = 0 To x
                        squareinhasharray += 1

                    Next
                Else
                    For xx = 0 To 7
                        squareinhasharray += 1

                    Next
                End If
                
            Next
            squareinhasharray -= 1


            If team = 0 Then
                Select Case sym
                    Case "p"
                        j = 0
                    Case "k"
                        j = 1
                    Case "q"
                        j = 2
                    Case "b"
                        j = 3
                    Case "h"
                        j = 4
                    Case "c"
                        j = 5
                End Select
            ElseIf team = 1 Then
                Select Case sym
                    Case "p"
                        j = 6
                    Case "k"
                        j = 7
                    Case "q"
                        j = 8
                    Case "b"
                        j = 9
                    Case "h"
                        j = 10
                    Case "c"
                        j = 11
                End Select
            End If
            Dim i As Long = Convert.ToInt64(Form1.HashTableRan(squareinhasharray, j), 2)
            Hash = Hash Xor i


        Next


        Return Hash

    End Function
    Public Function Random_64bit_bin() As String
        Dim stringint As String
        Dim num As Integer


        For x = 0 To 63
            num = Int((Rnd() * 10) + 1)
            If num > 5 Then
                stringint &= "0"
            Else
                stringint &= "1"
            End If
        Next

        Return stringint

    End Function
End Module
