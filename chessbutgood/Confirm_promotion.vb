Public Class Confirm_promotion

    Private Sub Cancel_promotion_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_promotion_button.Click
        Promotion.selected_set()
        Promotion.Show()

        Me.Hide()
    End Sub

    Private Sub Confirm_promotion_but_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Confirm_promotion_but.Click
        Promotion.selected_set()
        Promotion.Hide()
        Form1.board(Promotion.promotion_place.x, Promotion.promotion_place.y).setpiece(Promotion.get_promoted, Form1.board(Promotion.promotion_place.x, Promotion.promotion_place.y).getteam)
        Me.Hide()
        Form1.confirmed = True

    End Sub

    Private Sub Confirm_promotion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class