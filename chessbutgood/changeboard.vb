Module changeboard
    Sub changepiecetowhere(ByVal s As String, ByVal t As Integer, ByVal x As Integer, ByVal y As Integer, ByVal piece_selected_X As Integer, ByVal piece_Selected_Y As Integer, ByVal db As Boolean, ByVal castling As Boolean)



        If castling = True Then
            Select Case t
                Case 0
                    Form1.whitecastled = True

                Case 1
                    Form1.blackcastled = True
            End Select
        End If
        Form1.deletemoves(Form1.board(piece_selected_X, piece_Selected_Y).getmoves, Form1.board)
        Form1.board(x, y).setpiece(Form1.board(piece_selected_X, piece_Selected_Y).getsym, Form1.board(piece_selected_X, piece_Selected_Y).getteam)
        Form1.board(x, y).set_value(Form1.board(piece_selected_X, piece_Selected_Y).getvalue)
        Form1.board(piece_selected_X, piece_Selected_Y).set_value(0)

        Form1.board(piece_selected_X, piece_Selected_Y).set_hasmoved(True)

        Form1.board(x, y).set_hasmoved(True)

        If Form1.board(piece_selected_X, piece_Selected_Y).getsym <> "_" Then

            If Form1.board(piece_selected_X, piece_Selected_Y).getteam = 0 Then

                Select Case Form1.board(x, y).getsym
                    Case "p"
                        Form1.wpawncount -= 1
                    Case "b"
                        Form1.wbishopcount -= 1
                    Case "c"
                        Form1.wcastlecount -= 1
                    Case "q"
                        Form1.wqueencount -= 1
                    Case "h"
                        Form1.whorsecount -= 1

                End Select
            Else

                Select Case Form1.board(x, y).getsym
                    Case "p"
                        Form1.bpawncount -= 1
                    Case "b"
                        Form1.bbishopcount -= 1
                    Case "c"
                        Form1.bcastlecount -= 1
                    Case "q"
                        Form1.bqueencount -= 1
                    Case "h"
                        Form1.bhorsecount -= 1

                End Select
            End If
        End If
        Form1.board(piece_selected_X, piece_Selected_Y).setpiece("_", 2)
        If db = True Then
            drawboard(Form1.board)

        End If








    End Sub
    Public Sub settoblank(ByVal x As Integer, ByVal y As Integer)
        Form1.board(x, y).setpiece("_", 2)
    End Sub
    Sub changepiecetowhere(ByVal s As String, ByVal t As Integer, ByVal x As Integer, ByVal y As Integer, ByVal piece_selected_X As Integer, ByVal piece_Selected_Y As Integer, ByVal db As Boolean, ByVal castling As Boolean, ByVal the_board(,) As theboardclass)



        If castling = True Then
            Select Case t
                Case 0
                    Form1.whitecastled = True

                Case 1
                    Form1.blackcastled = True
            End Select
        End If
        Form1.deletemoves(Form1.board(piece_selected_X, piece_Selected_Y).getmoves, Form1.board)
        Form1.board(x, y).setpiece(Form1.board(piece_selected_X, piece_Selected_Y).getsym, Form1.board(piece_selected_X, piece_Selected_Y).getteam)
        Form1.board(x, y).set_value(Form1.board(piece_selected_X, piece_Selected_Y).getvalue)
        Form1.board(piece_selected_X, piece_Selected_Y).set_value(0)

        Form1.board(piece_selected_X, piece_Selected_Y).set_hasmoved(True)

        Form1.board(x, y).set_hasmoved(True)

        If Form1.board(piece_selected_X, piece_Selected_Y).getsym <> "_" Then

            If Form1.board(piece_selected_X, piece_Selected_Y).getteam = 0 Then

                Select Case Form1.board(x, y).getsym
                    Case "p"
                        Form1.wpawncount -= 1
                    Case "b"
                        Form1.wbishopcount -= 1
                    Case "c"
                        Form1.wcastlecount -= 1
                    Case "q"
                        Form1.wqueencount -= 1
                    Case "h"
                        Form1.whorsecount -= 1

                End Select
            Else

                Select Case Form1.board(x, y).getsym
                    Case "p"
                        Form1.bpawncount -= 1
                    Case "b"
                        Form1.bbishopcount -= 1
                    Case "c"
                        Form1.bcastlecount -= 1
                    Case "q"
                        Form1.bqueencount -= 1
                    Case "h"
                        Form1.bhorsecount -= 1

                End Select
            End If
        End If
        Form1.board(piece_selected_X, piece_Selected_Y).setpiece("_", 2)
        If db = True Then
            drawboard(Form1.board)

        End If








    End Sub
    Public Function efficient_undo_board(ByVal the_board(,) As theboardclass, ByVal the_move As Form1.Efficient_moves)
        Form1.rounds -= 1
        Form1.changboardcount -= 1
        Select Case the_move.SpecialMoveFlag
            Case 0 'no special move
                If the_move.origin.sym = "p" Then
                    If the_move.origin.y + 2 = the_move.target.y Or the_move.origin.y - 2 = the_move.target.y Then
                        the_board(the_move.target.x, the_move.target.y).set_has_moved_2(False)

                    End If
                End If
                the_board(the_move.origin.x, the_move.origin.y).setpiece(the_move.origin.sym, the_move.origin.team)
                the_board(the_move.target.x, the_move.target.y).setpiece(the_move.target.sym, the_move.target.team)
                For Each letter In the_move.OriginBoardInfo.castlingrights
                    Select Case letter
                        Case "K"
                            the_board(7, 0).setpiece("c", 0)
                            the_board(5, 0).setpiece("_", 2)
                            the_board(7, 0).set_hasmoved(False)
                            the_board(4, 0).set_hasmoved(False)
                        Case "Q"
                            the_board(0, 0).setpiece("c", 0)
                            the_board(3, 0).setpiece("_", 2)
                            the_board(0, 0).set_hasmoved(False)
                            the_board(4, 0).set_hasmoved(False)

                        Case "k"
                            the_board(7, 7).setpiece("c", 1)
                            the_board(5, 7).setpiece("_", 2)
                            the_board(7, 7).set_hasmoved(False)
                            the_board(4, 7).set_hasmoved(False)
                        Case "q"
                            the_board(0, 7).setpiece("c", 1)
                            the_board(3, 7).setpiece("_", 2)
                            the_board(0, 7).set_hasmoved(False)
                            the_board(4, 7).set_hasmoved(False)
                    End Select
                Next


            Case 1 'en pasent
                Dim opteam
                If the_move.origin.team = 0 Then
                    opteam = 1
                Else
                    opteam = 0
                End If

                If the_move.OriginBoardInfo.enPassentsquare.y = 2 Then
                    the_board(the_move.origin.x, the_move.origin.y).setpiece("p", the_move.origin.team)
                    the_board(the_move.target.x, the_move.target.y).setpiece("_", 2)

                    the_board(the_move.target.x, the_move.target.y + 1).setpiece("p", opteam)
                ElseIf the_move.OriginBoardInfo.enPassentsquare.y = 5 Then
                    the_board(the_move.origin.x, the_move.origin.y).setpiece("p", the_move.origin.team)
                    the_board(the_move.target.x, the_move.target.y).setpiece("_", 2)

                    the_board(the_move.target.x, the_move.target.y - 1).setpiece("p", opteam)
                End If

            Case 2 'castling
                For Each letter In the_move.OriginBoardInfo.castlingrights
                    Select Case letter
                        Case "K"
                            the_board(7, 0).setpiece("c", 0)
                            the_board(5, 0).setpiece("_", 2)
                            the_board(7, 0).set_hasmoved(False)
                        Case "Q"
                            the_board(0, 0).setpiece("c", 0)
                            the_board(3, 0).setpiece("_", 2)
                            the_board(0, 0).set_hasmoved(False)

                        Case "k"
                            the_board(7, 7).setpiece("c", 1)
                            the_board(5, 7).setpiece("_", 2)
                            the_board(7, 7).set_hasmoved(False)
                        Case "q"
                            the_board(0, 7).setpiece("c", 1)
                            the_board(3, 7).setpiece("_", 2)
                            the_board(0, 7).set_hasmoved(False)
                    End Select
                Next
                the_board(the_move.origin.x, the_move.origin.y).setpiece("k", the_move.origin.team)
                the_board(the_move.target.x, the_move.target.y).setpiece("_", 2)
                the_board(the_move.origin.x, the_move.origin.y).set_hasmoved(False)
            Case 3 'promotion
            Case Else
                MsgBox("")
        End Select
        Form1.board_info.castlingrights = the_move.OriginBoardInfo.castlingrights

        Return the_board
    End Function
    Public Function efficient_change_board(ByVal the_board(,) As theboardclass, ByRef Move As Form1.Efficient_moves)
        Form1.rounds += 1
        Form1.changboardcount += 1
        Form1.PreviousMove = Move
        Select Case Move.SpecialMoveFlag
            Case 0
                If Move.origin.sym = "p" Then
                    If Move.origin.y + 2 = Move.target.y Or Move.origin.y - 2 = Move.target.y Then
                        the_board(Move.target.x, Move.target.y).set_has_moved_2(True)
                        the_board(Move.target.x, Move.target.y).set_round_2_moves(Form1.rounds)
                    End If
                End If
                the_board(Move.target.x, Move.target.y).setpiece(Move.origin.sym, Move.origin.team)
                the_board(Move.origin.x, Move.origin.y).setpiece("_", 2)

                'hasmoved
                the_board(Move.target.x, Move.target.y).set_hasmoved(True)
                the_board(Move.origin.x, Move.origin.y).set_hasmoved(True)
            Case 1 ' enpassent

                the_board(Move.target.x, Move.target.y).setpiece(Move.origin.sym, Move.origin.team)
                the_board(Move.origin.x, Move.origin.y).setpiece("_", 2)
                If Move.OriginBoardInfo.enPassentsquare.y = 2 Then

                    the_board(Move.target.x, Move.target.y + 1).setpiece("_", 2)
                Else
                    the_board(Move.target.x, Move.target.y - 1).setpiece("_", 2)

                End If


            Case 2 ' castling

                the_board(Move.target.x, Move.target.y).setpiece(Move.origin.sym, Move.origin.team)
                the_board(Move.origin.x, Move.origin.y).setpiece("_", 2)

                'hasmoved
                the_board(Move.target.x, Move.target.y).set_hasmoved(True)
                the_board(Move.origin.x, Move.origin.y).set_hasmoved(True)
                If Move.target.x = 6 Then
                    the_board(5, Move.target.y).setpiece("c", Move.origin.team)

                    the_board(7, Move.origin.y).setpiece("_", 2)
                ElseIf Move.target.x = 2 Then
                    the_board(3, Move.target.y).setpiece("c", Move.origin.team)

                    the_board(0, Move.origin.y).setpiece("_", 2)
                End If

            Case 3 ' promotion

        End Select
        Return the_board
    End Function
End Module
