Public Class MAIN_MENU

    Private Sub Pvpbutton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pvpbutton.Click
        Form1.settings.Playing_Agaisnt_AI = False
        Form1.settings.Player_vs_player = True
        Form1.settings.AI_vs_AI = False
        Form1.Show()

    End Sub

    Private Sub PVAIbutton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PVAIbutton.Click
        Form1.settings.Playing_Agaisnt_AI = True
        Form1.settings.Player_vs_player = False
        Form1.settings.AI_vs_AI = False
        Form1.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FEN_CODE_BUTTON.Click
        Form1.FEN_STRING_USE = New FEN_Code
        FEN_LIST.Show()

    End Sub

    Private Sub MAIN_MENU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Form1.settings.using_FEN = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form1.settings.Playing_Agaisnt_AI = False
        Form1.settings.Player_vs_player = False
        Form1.settings.AI_vs_AI = True
        Form1.Show()
    End Sub

    Private Sub Calculate_moves_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calculate_moves_button.Click
        Form1.settings.Playing_Agaisnt_AI = False
        Form1.settings.Player_vs_player = False
        Form1.settings.AI_vs_AI = False
        Form1.settings.calculating_all_moves_for_test = True
        Form1.Show()

    End Sub
End Class