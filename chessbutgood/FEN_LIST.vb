Public Class FEN_LIST

   

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FEN_LINE_TB.TextChanged

    End Sub

    Private Sub START_FEN_BUTT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles START_FEN_BUTT.Click
        If Me.FEN_LINE_TB.Text <> "" Or IsNothing(Me.FEN_LINE_TB.Text) = True Then
            Form1.FEN_STRING_USE.Set_FEN(Me.FEN_LINE_TB.Text)
            MAIN_MENU.settings.using_FEN = True
            Me.Hide()

        End If
    End Sub

End Class