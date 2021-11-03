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
End Module
