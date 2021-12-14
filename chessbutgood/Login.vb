Public Class Login
    Private All_Users(0) As PlayerINFO
    Private CorrectPassUser As Boolean = False
    Private Sub Load_All_users()
        Dim line As String
        Dim splitline() As String
        Dim usercount As Integer
        Dim PP As Image

        FileOpen(1, Form1.AssetFolderPath & "users.txt", OpenMode.Input)
        Do Until EOF(1)
            line = LineInput(1)

            If InStr(line, "Username:") > 0 Then
                All_Users(usercount) = New PlayerINFO
                splitline = line.Split(":")
                All_Users(usercount).GameAliasC(splitline(1))
                splitline = LineInput(1).Split(":")
                All_Users(usercount).PasswordC(splitline(1))
                splitline = LineInput(1).Split(":")
                All_Users(usercount).EloC(splitline(1))
                splitline = LineInput(1).Split(";")
                PP = Image.FromFile((splitline(1)))
                All_Users(usercount).ProfilePictureC(PP)
                All_Users(usercount).ProfilePicPATH(splitline(1))
                ReDim Preserve All_Users(All_Users.Length)
                usercount += 1
            End If
        Loop

        FileClose(1)
    End Sub
    Private Sub EnterSignInBUTT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnterSignInBUTT.Click
        Dim IndexOfUser As Integer
        If All_Users.Length - 1 <> 0 Then
            For II = 0 To All_Users.Length - 2
                If All_Users(II).GameAliasC = Me.UsernameTB.Text Then
                    IndexOfUser = II
                End If
            Next

            If All_Users(IndexOfUser).PasswordC = Me.PasswordTB.Text Then
                CorrectPassUser = True
            End If
        Else
            CorrectPassUser = False
        End If
       

        If CorrectPassUser Then
            Me.LoginERRORLabel.ForeColor = Color.LightGreen
            Me.LoginERRORLabel.Text = "Login Successfull!"
            MsgBox("Loggin Succesfull" & vbCrLf & "User: " & All_Users(IndexOfUser).GameAliasC)
            Form1.LoggedIn = True
            Form1.loggedInUser = All_Users(IndexOfUser)
            MAIN_MENU.DisplayAsLoggedIn(Form1.loggedInUser)

            Me.Close()
        Else
            Me.LoginERRORLabel.ForeColor = Color.MediumVioletRed
            Me.LoginERRORLabel.Text = "Username Or Paswword Incorrect!"
        End If
    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_All_users()
        PasswordTB.PasswordChar = "*"
    End Sub
End Class