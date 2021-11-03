Public Class Promotion
    Public team_of_proting_pawn As Integer
    Public promotion_place As Form1.position
    Protected selected As Boolean = False
    Private piece_being_promoted As String
    Private Sub Promote_to_queen_but_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Promote_to_queen_but.Click
        If selected = False Then
            Confirm_promotion.Show()
            Me.Hide()
            Confirm_promotion.Piece_being_promoted.Text = "Queen"
            selected = True
            Me.setpiecepromoted("q")
        End If


    End Sub

    Private Sub Promote_to_castle_but_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Promote_to_castle_but.Click

        If selected = False Then
            Confirm_promotion.Show()
            Me.Hide()
            Confirm_promotion.Piece_being_promoted.Text = "Castle/Rook"
            selected = True
            Me.setpiecepromoted("c")
        End If
    End Sub

    Private Sub Promote_to_bishop_but_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Promote_to_bishop_but.Click

        If selected = False Then
            Confirm_promotion.Show()
            Me.Hide()
            Confirm_promotion.Piece_being_promoted.Text = "Bishop"
            selected = True
            Me.setpiecepromoted("b")
        End If
    End Sub

    Private Sub Promote_to_horse_but_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Promote_to_horse_but.Click

        If selected = False Then
            Confirm_promotion.Show()
            Me.Hide()
            Confirm_promotion.Piece_being_promoted.Text = "Knight/Horse"
            selected = True
            Me.setpiecepromoted("h")
        End If
    End Sub

    Private Sub Cancel_promotion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_promotion.Click
        Me.Hide()
    End Sub

    Private Sub Promotion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Form1.confirmed = False
        If Me.team_of_proting_pawn = 0 Then
            Me.Team_label.Text = "White Teams Choice"
        Else
            Me.Team_label.Text = "Black Teams Choice"
        End If

    End Sub
    Public Sub selected_set()
        Me.selected = False
    End Sub
    Public Sub setpiecepromoted(ByVal sym)
        Me.piece_being_promoted = sym
    End Sub
    Public Function get_promoted()
        Return Me.piece_being_promoted
    End Function
End Class