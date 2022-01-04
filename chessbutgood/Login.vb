Public Class Login

    Private CorrectPassUser As Boolean = False
    
    Private Sub EnterSignInBUTT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnterSignInBUTT.Click
        Dim IndexOfUser As Integer = 0
        Dim count As Integer = 0
        If UsernameTB.Text <> "" And PasswordTB.Text <> "" Then
            For Each User In MAIN_MENU.AllUsersInfoL
                If User.UserName = UsernameTB.Text Then

                    If User.password = PasswordTB.Text Then
                        CorrectPassUser = True
                        IndexOfUser = count
                        Exit For
                    End If
                End If
                count += 1
            Next
        End If

        If CorrectPassUser = True Then
            Dim TempUser As New PlayerINFO
            TempUser.GameAliasC(MAIN_MENU.AllUsersInfoL(IndexOfUser).UserName)
            TempUser.EloC(MAIN_MENU.AllUsersInfoL(IndexOfUser).elo)
            TempUser.ProfilePictureC(MAIN_MENU.AllUsersInfoL(IndexOfUser).ProfilePicture)
            TempUser.PasswordC(MAIN_MENU.AllUsersInfoL(IndexOfUser).password)
            MAIN_MENU.loggedInUser = TempUser
            Me.LoginERRORLabel.ForeColor = Color.LightGreen
            Me.LoginERRORLabel.Text = "Login Successfull!"
            MsgBox("Loggin Succesfull" & vbCrLf & "User: " & MAIN_MENU.AllUsersInfoL(IndexOfUser).UserName)
            MAIN_MENU.LoggedIn = True
            MAIN_MENU.DisplayAsLoggedIn(MAIN_MENU.loggedInUser)


            Me.Close()
        Else
            Me.LoginERRORLabel.ForeColor = Color.MediumVioletRed
            Me.LoginERRORLabel.Text = "Username Or Paswword Incorrect!"
        End If
    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        PasswordTB.PasswordChar = "*"
    End Sub

    Private Sub ImportProfilesButt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportProfilesButt.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()
        Dim strFileName As String
        Dim SelectedDirectoryPath As String = ""
        Dim Splitline() As String
        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "D:\"
        fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            strFileName = fd.FileName
        End If
        Try
            Splitline = strFileName.Split("\")
            If InStr(Splitline(Splitline.Length - 2), "CA_USER") > 0 Then
                For II = 0 To Splitline.Length - 2
                    SelectedDirectoryPath &= Splitline(II) & "\"
                Next
            End If
        Catch ex As Exception
            'just continue as normal, exception raised if no file selected
        End Try
        
    End Sub

    
    
    Private Sub RegisterBUTT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegisterBUTT.Click
        RegisterAccount.Show()
    End Sub

    Private Sub VAPButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VAPButton.Click
        ListofProfilesDisplay.Show()
    End Sub
End Class