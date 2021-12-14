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
    Public Sub DisplayAsLoggedIn(ByVal User As PlayerINFO)
        If Form1.LoggedIn = True Then
            Me.ProfilePictureBox.Image = Form1.loggedInUser.ProfilePictureC
            Me.SignInMainMenuBUTT.Visible() = False
            Me.ProfilePictureBox.Visible = True
            Me.LogoutBUTT.Visible = True

        Else
            Me.SignInMainMenuBUTT.Visible() = True
            Me.ProfilePictureBox.Visible = False
            Me.LogoutBUTT.Visible = False
        End If
    End Sub
    Private Sub MAIN_MENU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Form1.settings.using_FEN = False
        Form1.AssetFolderPath = load_game.get_asset_folder_name
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form1.settings.Playing_Agaisnt_AI = False
        Form1.settings.Player_vs_player = False
        Form1.settings.AI_vs_AI = True
        Form1.Show()
    End Sub

    Private Sub Calculate_moves_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form1.settings.Playing_Agaisnt_AI = False
        Form1.settings.Player_vs_player = False
        Form1.settings.AI_vs_AI = False
        Form1.settings.calculating_all_moves_for_test = True
        Form1.Show()

    End Sub

    Private Sub Settingsbutton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Settingsbutton.Click
        Settings_menu.Show()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        compare_stockfish_perft_results("D:\fishtest.txt", "D:\stockfishresults.txt")
    End Sub

    Private Sub SignInMainMenuBUTT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SignInMainMenuBUTT.Click
        Login.Show()
    End Sub

    Private Sub LogoutBUTT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutBUTT.Click
        Form1.loggedInUser = Nothing
        Form1.LoggedIn = False
        Me.ProfilePictureBox.Visible = False
        Me.LogoutBUTT.Visible = False
        Me.SignInMainMenuBUTT.Visible = True
    End Sub

    Private Sub ExitBUTT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitBUTT.Click
        Me.Close()
    End Sub
End Class