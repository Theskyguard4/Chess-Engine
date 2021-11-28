Module createboard
    Dim allcheckedplaces() As theboardclass

    
    Function makeboard(ByVal board(,) As theboardclass)

        For y = 0 To 7

            For x = 0 To 7

                If y <= 2 Or y >= 6 Then


                End If


                If y = 0 Then
                    Select Case x
                        Case 0
                            board(x, y) = makeeach("c", 0)
                        Case 1
                            board(x, y) = makeeach("h", 0)
                        Case 2
                            board(x, y) = makeeach("b", 0)
                        Case 3
                            board(x, y) = makeeach("q", 0)
                        Case 4
                            board(x, y) = makeeach("k", 0)
                        Case 5
                            board(x, y) = makeeach("b", 0)
                        Case 6
                            board(x, y) = makeeach("h", 0)
                        Case 7
                            board(x, y) = makeeach("c", 0)
                    End Select
                ElseIf y = 1 Then
                    board(x, y) = makeeach("p", 0)
                ElseIf y = 6 Then
                    board(x, y) = makeeach("p", 1)

                ElseIf y = 7 Then
                    Select Case x
                        Case 0
                            board(x, y) = makeeach("c", 1)
                        Case 1
                            board(x, y) = makeeach("h", 1)
                        Case 2
                            board(x, y) = makeeach("b", 1)
                        Case 3
                            board(x, y) = makeeach("q", 1)
                        Case 4
                            board(x, y) = makeeach("k", 1)
                        Case 5
                            board(x, y) = makeeach("b", 1)
                        Case 6
                            board(x, y) = makeeach("h", 1)
                        Case 7
                            board(x, y) = makeeach("c", 1)
                    End Select

                Else
                    board(x, y) = makeeach("_", 2)
                End If


            Next
        Next

        Return board

    End Function
    Function makeeach(ByVal piecesymbal As String, ByVal team As Integer) As theboardclass
        Dim theboard As theboardclass
        theboard = New theboardclass(piecesymbal, team)
        Select Case piecesymbal
            Case "p"
                If team = 0 Then
                    Form1.wpawncount += 1
                Else
                    Form1.bpawncount += 1
                End If



            Case "c"
                If team = 0 Then
                    Form1.wcastlecount += 1
                Else
                    Form1.bcastlecount += 1
                End If



            Case "h"
                If team = 0 Then
                    Form1.whorsecount += 1
                Else
                    Form1.bhorsecount += 1
                End If



            Case "b"
                If team = 0 Then
                    Form1.wbishopcount += 1
                Else
                    Form1.bbishopcount += 1
                End If

            Case "q"
                If team = 0 Then
                    Form1.wqueencount += 1
                Else
                    Form1.bqueencount += 1
                End If



        End Select

        Return theboard

    End Function

    Sub drawboard(ByVal board(,) As theboardclass)
        Dim count As Integer = 1
        For y = 0 To 7
            For x = 0 To 7

                board(x, y).getpiece.drawimages(x, y, count)
                count += 1
            Next
        Next

    End Sub

End Module
