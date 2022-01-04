Public Class MAIN_MENU
    Public Structure options
        Dim Playing_Agaisnt_AI As Boolean
        Dim AI_vs_AI As Boolean
        Dim Player_vs_player As Boolean
        Dim using_FEN As Boolean
        Dim calculating_all_moves_for_test As Boolean
        Dim DisplayDefaultdata As Boolean
        Dim DisplayAdvancedData As Boolean
        Dim UseSetDepth As Boolean
        Dim DepthSearchIntegerMax As Integer
        Dim DepthSearchTimeMax As Integer
        Dim loggedin As Boolean
        Dim AssetPATH As String
    End Structure
    Structure LoginDetails
        Dim UserName As String
        Dim password As String
        Dim elo As String
        Dim ProfilePicture As Image
    End Structure

    Public settings As options
    Public Games(0) As game
    Public loggedInUser As New PlayerINFO
    Public LoggedIn As Boolean = False
    Public AllUsers As New List(Of String)
    Public AllUsersInfoL As New List(Of LoginDetails)
    Public Sub AddAccount(ByVal username As String, ByVal PATH As String)
        FileOpen(12, Me.settings.AssetPATH & "users.txt", OpenMode.Append)
        PrintLine(12, username)
        PrintLine(12, PATH)
        FileClose(12)
        Dim TempUser As LoginDetails
        FileOpen(99, PATH & "UserInfo_" & username & ".txt", OpenMode.Input)
        TempUser.UserName = LineInput(99)
        TempUser.password = LineInput(99)
        TempUser.elo = LineInput(99)

        TempUser.ProfilePicture = Image.FromFile(PATH & "ProfilePicture_" & TempUser.UserName & ".png")
        AllUsersInfoL.Add(TempUser)

        FileClose(99)
        Me.AllUsersInfoL.Add(TempUser)

    End Sub

    Private Sub LoadListOfUsers()
        Dim Count As Integer = 0
        Dim TempLine As String
        Dim tempuser As LoginDetails
        Dim UsernameListTemp As New List(Of String)
        FileOpen(11, Me.settings.AssetPATH & "users.txt", OpenMode.Input)
        Do Until EOF(11)
            TempLine = LineInput(11)
            UsernameListTemp.Add(TempLine)
            TempLine = LineInput(11)
            AllUsers.Add(TempLine)
        Loop

        FileClose(11)

        For Each User In AllUsers
            Try

                FileOpen(99, User & "UserInfo_" & UsernameListTemp(Count) & ".txt", OpenMode.Input)
                tempuser.UserName = (LineInput(99))
                tempuser.password = (LineInput(99))
                tempuser.elo = (LineInput(99))
                tempuser.ProfilePicture = (Image.FromFile(User & "ProfilePicture_" & UsernameListTemp(Count) & ".png"))
                AllUsersInfoL.Add(tempuser)
                FileClose(99)

            Catch ex As Exception

                AllUsers.RemoveAt(Count)
                UsernameListTemp.RemoveAt(Count)
            End Try
            Count += 1
        Next

    End Sub

    Private Sub Pvpbutton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pvpbutton.Click
        settings.Playing_Agaisnt_AI = False
        settings.Player_vs_player = True
        settings.AI_vs_AI = False
        ReDim Preserve Games(Games.Length)
        Form1.Show()

    End Sub

    Private Sub PVAIbutton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PVAIbutton.Click
        settings.Playing_Agaisnt_AI = True
        settings.Player_vs_player = False
        settings.AI_vs_AI = False
        ReDim Preserve Games(Games.Length)
        Form1.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FEN_CODE_BUTTON.Click
        Form1.FEN_STRING_USE = New FEN_Code
        FEN_LIST.Show()

    End Sub
    Public Sub DisplayAsLoggedIn(ByVal User As PlayerINFO)
        If Me.LoggedIn = True Then
            Me.UsernameLabel.Text = User.GameAliasC
            Me.ProfilePictureBox.Image = Me.loggedInUser.ProfilePictureC
            Me.ProfilePictureBox.SizeMode = PictureBoxSizeMode.StretchImage
            Me.ProfilePictureBox.BorderStyle = BorderStyle.Fixed3D
            Me.SignInMainMenuBUTT.Visible() = False
            Me.ProfilePictureBox.Visible = True
            Me.LogoutBUTT.Visible = True

        Else
            Me.UsernameLabel.Text = ""
            Me.SignInMainMenuBUTT.Visible() = True
            Me.ProfilePictureBox.Visible = False
            Me.LogoutBUTT.Visible = False
        End If
    End Sub
    Private Sub MAIN_MENU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        settings.using_FEN = False
        settings.AssetPATH = load_game.get_asset_folder_name
        LoadListOfUsers()
        Me.loggedInUser.EloC(0)
        Me.loggedInUser.GameAliasC("Guest")
        Me.loggedInUser.ProfilePicPATH(settings.AssetPATH & "DefaultPP.png")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        settings.Playing_Agaisnt_AI = False
        settings.Player_vs_player = False
        settings.AI_vs_AI = True
        ReDim Preserve Games(Games.Length)
        Form1.Show()
    End Sub

    Private Sub Calculate_moves_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        settings.Playing_Agaisnt_AI = False
        settings.Player_vs_player = False
        settings.AI_vs_AI = False
        settings.calculating_all_moves_for_test = True
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
        Me.loggedInUser = Nothing
        Me.UsernameLabel.Text = ""
        Me.LoggedIn = False
        Me.ProfilePictureBox.Visible = False
        Me.LogoutBUTT.Visible = False
        Me.SignInMainMenuBUTT.Visible = True
    End Sub

    Private Sub ExitBUTT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitBUTT.Click
        Me.Close()
    End Sub

    Public Sub NewGame()
        Form1.Close()
        Form1.Show()
    End Sub

    
    Private Sub MMPracticeButt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MMPracticeButt.Click

    End Sub
End Class