Public Class CalBoard
    Private theBoard(,) As theboardclass
    Private score_of_board As Integer
    Public Sub New(ByVal board(,) As theboardclass)
        For xx = 0 To 7
            For yy = 0 To 7
                theBoard(xx, yy) = New theboardclass(board(xx, yy).getsym, board(xx, yy).getteam)
            Next
        Next
    End Sub
    Public Sub set_score(ByVal Num As Integer)
        Me.score_of_board = Num
    End Sub
    Public Function Get_score()
        Return Me.score_of_board
    End Function
    Public Function get_moves(ByVal x As Integer, ByVal y As Integer) As List(Of Form1.position)

        Return Me.theBoard(x, y).getmoves()



    End Function
    'Public Sub calculate_moves(ByVal whosgo As Integer)

    '    For xxx = 0 To 7
    '        For yyy = 0 To 7
    '            If theBoard(xxx, yyy).getsym = "k" Then
    '                Me.theBoard(xxx, yyy).calculatekingmoves(theBoard)
    '            Else
    '                Me.theBoard(x, y).calculatemoves(theBoard, whosgo)
    '            End If
    '        Next

    '    Next
    'End Sub
End Class
