Public Class FEN_Code
    Private FEN_string As String
    Public Sub Set_FEN(ByVal FEN)
        FEN_string = FEN
    End Sub
    Public Function GET_FEN()
        Return FEN_string
    End Function
    Public Sub New()

    End Sub
    Private Function convert(ByVal FEN As String)
        Dim newstring As String
        For I = 0 To FEN_string.Length - 1
            Select Case FEN(I).ToString
                Case "R"
                    newstring &= "C"
                Case "r"
                    newstring &= "c"
                Case "N"
                    newstring &= "H"
                Case "n"
                    newstring &= "h"
                Case Else
                    newstring &= FEN_string(I)
            End Select
        Next
        Return newstring
    End Function
    Private Function convertback(ByVal FEN As String)
        Dim newstring As String
        For I = 0 To FEN.Length - 1
            Select Case FEN(I).ToString
                Case "C"
                    newstring &= "R"
                Case "c"
                    newstring &= "r"
                Case "H"
                    newstring &= "N"
                Case "h"
                    newstring &= "n"
                Case Else
                    newstring &= FEN(I)
            End Select
        Next
        Return newstring
    End Function

    Public Function Setboard(ByVal board(,) As theboardclass)
        Dim count As Integer = 0
        Dim FieldCount As Integer = 0
        Dim y As Integer = 0
        Dim Num As Integer = 0
        Dim xpos As String
        Dim ypos As String
        FEN_string = convert(FEN_string)
        For I = 0 To FEN_string.Length - 1
            If count < 8 And y < 8 Then
                If IsNumeric(FEN_string(I)) = True Then
                    For II = 1 To Val(FEN_string(I))
                        board(count, y) = New theboardclass("_", "2")
                        count += 1
                    Next


                Else
                    If FEN_string(I) <> "/" Then
                        If AscW(FEN_string(I)) >= 65 And AscW(FEN_string(I)) <= 90 Then
                            board(count, y) = New theboardclass(LCase(FEN_string(I)), "1")
                            Select Case LCase(FEN_string(I))
                                Case "p"
                                    Form1.wpawncount += 1
                                Case "c"
                                    Form1.wcastlecount += 1
                                Case "b"
                                    Form1.wbishopcount += 1
                                Case "h"
                                    Form1.whorsecount += 1
                                Case "q"
                                    Form1.wqueencount += 1

                            End Select
                        ElseIf AscW(FEN_string(I)) >= 97 And AscW(FEN_string(I)) <= 122 Then
                            board(count, y) = New theboardclass(LCase(FEN_string(I)), "0")
                            Select Case LCase(FEN_string(I))
                                Case "p"
                                    Form1.bpawncount += 1
                                Case "c"
                                    Form1.bcastlecount += 1
                                Case "b"
                                    Form1.bbishopcount += 1
                                Case "h"
                                    Form1.bhorsecount += 1
                                Case "q"
                                    Form1.bqueencount += 1

                            End Select
                        End If
                        count += 1
                    Else
                        y += 1
                    End If


                End If
            Else
                count = 0
                y += 1
            End If

            If FEN_string(I) = " " Then
                FieldCount += 1
                Select Case FieldCount
                    Case 1
                        Dim team_letter As String
                        team_letter = FEN_string(I + 1)
                        Select Case team_letter
                            Case "w", "W"
                                Form1.whosgo = 1
                            Case "b", "B"
                                Form1.whosgo = 0
                        End Select
                    Case 2
                        Dim Castlingfield2 As String = ""
                        Dim counter As Integer = I + 1
                        Do Until FEN_string(counter) = " "
                            Castlingfield2 &= FEN_string(counter)
                            counter += 1
                        Loop
                        Form1.ogcastlingrights = Castlingfield2
                        For Each Letter In Castlingfield2
                            Select Case Letter
                                Case "K"
                                    board(7, 7).set_hasmoved(False)
                                    board(4, 0).set_hasmoved(False)
                                Case "Q"
                                    board(0, 7).set_hasmoved(False)
                                    board(4, 0).set_hasmoved(False)
                                Case "k"
                                    board(7, 0).set_hasmoved(False)
                                    board(4, 7).set_hasmoved(False)
                                Case "q"
                                    board(0, 0).set_hasmoved(False)
                                    board(4, 7).set_hasmoved(False)

                            End Select
                        Next
                    Case 3
                        Dim en_pasent_square As String

                        If FEN_string(I + 1) <> "-" Then
                            xpos = FEN_string(I + 1)
                            ypos = FEN_string(I + 2)


                            Select Case xpos
                                Case "a"
                                    xpos = "0"
                                Case "b"
                                    xpos = "1"
                                Case "c"
                                    xpos = "2"
                                Case "d"
                                    xpos = "3"
                                Case "e"
                                    xpos = "4"
                                Case "f"
                                    xpos = "5"
                                Case "g"
                                    xpos = "6"
                                Case "h"
                                    xpos = "7"
                            End Select
                            Select Case ypos
                                Case "8"
                                    ypos = "0"
                                Case "7"
                                    ypos = "1"
                                Case "6"
                                    ypos = "2"
                                Case "5"
                                    ypos = "3"
                                Case "4"
                                    ypos = "4"
                                Case "3"
                                    ypos = "5"
                                Case "2"
                                    ypos = "6"
                                Case "1"
                                    ypos = "7"
                            End Select
                            en_pasent_square = xpos & ypos
                            If ypos = "2" Then
                                board(Int(xpos), 3).set_has_moved_2(True)

                            ElseIf ypos = "5" Then
                                board(Int(xpos), 4).set_has_moved_2(True)

                            End If

                        End If

                    Case 4
                    Case 5
                        Dim round As String
                        round = FEN_string(I + 1)

                        Form1.rounds = Int(round) + 1
                        If ypos = "2" Then
                            board(Int(xpos), 3).set_round_2_moves(Form1.rounds)

                        ElseIf ypos = "5" Then
                            board(Int(xpos), 4).set_round_2_moves(Form1.rounds)

                        End If

                    Case 6
                        'If FEN_string(I + 1) = "L" Then
                        '    If Form1.whosgo = 1 Then
                        '        Form1.whosgo = 0
                        '    Else
                        '        Form1.whosgo = 1
                        '    End If
                        'End If
                End Select

            End If

        Next




        Return board
    End Function
    Public Function Save_board(ByVal board(,) As theboardclass)
        Dim FEN_STRING_NEW As String
        Dim count As Integer = 0
        Dim fieldcastling As String = ""
        Dim team_letter As String = ""
        Dim half_count As String = "0"
        Dim full_count As String = Form1.rounds - 1
        Dim en_pasent As String = "-"
        For yy = 0 To 7
            For xx = 0 To 7
                If board(xx, yy).getsym = "_" Then
                    count += 1
                Else
                    If count <> 0 Then
                        FEN_STRING_NEW &= count.ToString
                    End If
                    If board(xx, yy).getteam = 0 Then
                        FEN_STRING_NEW &= LCase(board(xx, yy).getsym)
                    ElseIf board(xx, yy).getteam = 1 Then
                        FEN_STRING_NEW &= UCase(board(xx, yy).getsym)
                    End If
                    count = 0
                End If

            Next
            If count <> 0 Then

                FEN_STRING_NEW &= count.ToString
                count = 0
            End If
            If yy <> 7 Then
                FEN_STRING_NEW &= "/"
            End If



        Next

        If board(4, 0).Get_hasmoved = False Then
            For Each M In board(4, 0).getmoves
                If M.SpecialMove = 2 Then
                    Select Case M.x
                        Case 2
                            fieldcastling &= "q"
                        Case 6
                            fieldcastling &= "k"
                    End Select
                End If
            Next
        End If
        If board(4, 7).Get_hasmoved = False Then
            For Each M In board(4, 7).getmoves
                If M.SpecialMove = 2 Then
                    Select Case M.x
                        Case 2
                            fieldcastling &= "Q"
                        Case 6
                            fieldcastling &= "K"
                    End Select
                End If
            Next
        End If
        If fieldcastling = "" Then
            fieldcastling = "-"
        End If
        Select Case Form1.whosgo
            Case 0
                team_letter = "w"
            Case 1
                team_letter = "b"
        End Select
        For x = 0 To 7
            For y = 0 To 7
                If board(x, y).getsym = "p" Then
                    For Each M In board(x, y).getmoves
                        If M.SpecialMove = 1 Then
                            Select Case M.x
                                Case 0
                                    en_pasent &= "a"
                                Case 1
                                    en_pasent &= "b"
                                Case 2
                                    en_pasent &= "c"
                                Case 3
                                    en_pasent &= "d"
                                Case 4
                                    en_pasent &= "e"
                                Case 5
                                    en_pasent &= "f"
                                Case 6
                                    en_pasent &= "g"
                                Case 7
                                    en_pasent &= "h"

                            End Select
                        End If
                    Next
                End If
            Next
        Next
        FEN_STRING_NEW &= " " & team_letter & " " & fieldcastling & " " & en_pasent & " " & half_count & " " & full_count
        Return convertback(FEN_STRING_NEW)

    End Function
    Public Function set_board(ByVal the_board(,) As theboardclass, ByVal fen As String)
        Dim count As Integer = 0
        Dim FieldCount As Integer = 0
        Dim y As Integer = 0
        Dim Num As Integer = 0
        Dim xpos As String
        Dim ypos As String
        FEN_string = convert(FEN_string)
        For I = 0 To FEN_string.Length - 1
            If count < 8 And y < 8 Then
                If IsNumeric(FEN_string(I)) = True Then
                    For II = 1 To Val(FEN_string(I))
                        the_board(count, y).setpiece("_", 2)
                        count += 1
                    Next


                Else
                    If FEN_string(I) <> "/" Then
                        If AscW(FEN_string(I)) >= 65 And AscW(FEN_string(I)) <= 90 Then
                            the_board(count, y).setpiece(LCase(FEN_string(I)), 1)
                            Select Case LCase(FEN_string(I))
                                Case "p"
                                    Form1.wpawncount += 1
                                Case "c"
                                    Form1.wcastlecount += 1
                                Case "b"
                                    Form1.wbishopcount += 1
                                Case "h"
                                    Form1.whorsecount += 1
                                Case "q"
                                    Form1.wqueencount += 1

                            End Select
                        ElseIf AscW(FEN_string(I)) >= 97 And AscW(FEN_string(I)) <= 122 Then
                            the_board(count, y).setpiece(LCase(FEN_string(I)), 0)
                            Select Case LCase(FEN_string(I))
                                Case "p"
                                    Form1.bpawncount += 1
                                Case "c"
                                    Form1.bcastlecount += 1
                                Case "b"
                                    Form1.bbishopcount += 1
                                Case "h"
                                    Form1.bhorsecount += 1
                                Case "q"
                                    Form1.bqueencount += 1

                            End Select
                        End If
                        count += 1
                    Else
                        y += 1
                    End If


                End If
            Else
                count = 0
                y += 1
            End If

            If FEN_string(I) = " " Then
                FieldCount += 1
                Select Case FieldCount
                    Case 1
                        Dim team_letter As String
                        team_letter = FEN_string(I + 1)
                        Select Case team_letter
                            Case "w", "W"
                                Form1.whosgo = 1
                            Case "b", "B"
                                Form1.whosgo = 0
                        End Select
                    Case 2
                        Dim Castlingfield2 As String = ""
                        Dim counter As Integer = I + 1
                        Do Until FEN_string(counter) = " "
                            Castlingfield2 &= FEN_string(counter)
                            counter += 1
                        Loop
                        For Each Letter In Castlingfield2
                            Select Case Letter
                                Case "K"
                                    the_board(7, 7).set_hasmoved(False)
                                    the_board(4, 0).set_hasmoved(False)
                                Case "Q"
                                    the_board(0, 7).set_hasmoved(False)
                                    the_board(4, 0).set_hasmoved(False)
                                Case "k"
                                    the_board(7, 0).set_hasmoved(False)
                                    the_board(4, 7).set_hasmoved(False)
                                Case "q"
                                    the_board(0, 0).set_hasmoved(False)
                                    the_board(4, 7).set_hasmoved(False)

                            End Select
                        Next
                    Case 3
                        Dim en_pasent_square As String

                        If FEN_string(I + 1) <> "-" Then
                            xpos = FEN_string(I + 1)
                            ypos = FEN_string(I + 2)


                            Select Case xpos
                                Case "a"
                                    xpos = "0"
                                Case "b"
                                    xpos = "1"
                                Case "c"
                                    xpos = "2"
                                Case "d"
                                    xpos = "3"
                                Case "e"
                                    xpos = "4"
                                Case "f"
                                    xpos = "5"
                                Case "g"
                                    xpos = "6"
                                Case "h"
                                    xpos = "7"
                            End Select
                            Select Case ypos
                                Case "8"
                                    ypos = "0"
                                Case "7"
                                    ypos = "1"
                                Case "6"
                                    ypos = "2"
                                Case "5"
                                    ypos = "3"
                                Case "4"
                                    ypos = "4"
                                Case "3"
                                    ypos = "5"
                                Case "2"
                                    ypos = "6"
                                Case "1"
                                    ypos = "7"
                            End Select
                            en_pasent_square = xpos & ypos
                            If ypos = "2" Then
                                the_board(Int(xpos), 3).set_has_moved_2(True)

                            ElseIf ypos = "5" Then
                                the_board(Int(xpos), 4).set_has_moved_2(True)

                            End If

                        End If

                    Case 4
                    Case 5
                        Dim round As String
                        round = FEN_string(I + 1)

                        Form1.rounds = Int(round) + 1
                        If ypos = "2" Then
                            the_board(Int(xpos), 3).set_round_2_moves(Form1.rounds)

                        ElseIf ypos = "5" Then
                            the_board(Int(xpos), 4).set_round_2_moves(Form1.rounds)

                        End If

                    Case 6
                        'If FEN_string(I + 1) = "L" Then
                        '    If Form1.whosgo = 1 Then
                        '        Form1.whosgo = 0
                        '    Else
                        '        Form1.whosgo = 1
                        '    End If
                        'End If
                End Select

            End If

        Next




        Return the_board
    End Function

End Class
