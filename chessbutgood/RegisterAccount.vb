Public Class RegisterAccount

    Private Sub RegisterAccount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ErrorMsgCP.Text = ""
    End Sub

    
    Private Sub cretaeprofileBUTT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cretaeprofileBUTT.Click
        Dim UsernameMSG As String

        Select Case ConfirmMakeProfile()
            Case 0
                UsernameMSG = "Username and Password Confirmed. Account Created!"
                Me.ErrorMsgCP.ForeColor = Color.LightGreen
                Me.ErrorMsgCP.Text = UsernameMSG
                MsgBox(UsernameMSG)
                Me.Close()
            Case 1
                UsernameMSG = "Username Already In use!"
            Case 2
                UsernameMSG = "Password Must include atleast one of each type of char: % , " & vbCrLf & "ABC , abc, 123"
            Case 3
                UsernameMSG = "ERROR: Could Not Create Account"
            Case 4
                UsernameMSG = "Password Must Match"
        End Select
        Me.ErrorMsgCP.ForeColor = Color.IndianRed
        Me.ErrorMsgCP.Text = UsernameMSG
    End Sub
    Private Function ConfirmMakeProfile() As Integer
        Dim Password As String = PasswordTB.Text
        Dim username As String = UsernameTB.Text

        If Password = RepeatPasswordTB.Text Then
            If PasswordStrenthOKAY(Password) = True Then
                If username <> "" Then
                    For Each user In MAIN_MENU.AllUsersInfoL

                        If user.UserName = username Then

                            Return 1

                        End If

                    Next
                Else
                    Return 2
                End If
            Else
                Return 2
            End If
        Else
            Return 4
        End If
        Try
            SaveNewAccount(username, Password, MAIN_MENU.settings.AssetPATH & "DefaultPP.png", 500)
        Catch ex As Exception
            Return 3
        End Try
        Return 0
    End Function
    Public Sub SaveNewAccount(ByVal username As String, ByVal password As String, ByVal ImagePath As String, ByVal elo As Integer)
        Dim SaveDirectory As String
        Dim fd As OpenFileDialog = New OpenFileDialog()
        Dim strFileName As String
        Dim SelectedDirectoryPath As String = ""
        Dim Splitline() As String
        Dim ProfilePicrure As Image = Image.FromFile(ImagePath)


        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "D:\"
        fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            strFileName = fd.FileName
        End If
        Splitline = strFileName.Split("\")

        For II = 0 To Splitline.Length - 2
            SelectedDirectoryPath &= Splitline(II) & "\"
        Next
        SaveDirectory = SelectedDirectoryPath & "CA_USER_" & username & "\"
        My.Computer.FileSystem.CreateDirectory(SaveDirectory)
        FileOpen(10, SaveDirectory & "UserInfo_" & username & ".txt", OpenMode.Output)
        PrintLine(10, username)
        PrintLine(10, password)
        PrintLine(10, elo)
        FileClose(10)

        ProfilePicrure.Save(SaveDirectory & "ProfilePIcture_" & username & ".png", System.Drawing.Imaging.ImageFormat.Png)

        MAIN_MENU.AddAccount(username, SaveDirectory)
    End Sub
    Private Function PasswordStrenthOKAY(ByVal password As String) As Boolean
        Dim Strenth As Integer = 0
        Dim NUMBERS As String = "1234567890"
        Dim CAPTITALS As String = "QWERTYUIOPASDFGHJKLZXCVBNM"
        Dim LOWERCASE As String = "qwertyuiopasdfghjklzxcvbnm"
        Dim CHARS As String = "!£$%^&*()-_=+[{]};:'@#~,<.>/?"

        Dim CapBool As Boolean = False
        Dim NumBool As Boolean = False
        Dim LowCBool As Boolean = False
        Dim CharBool As Boolean = False
        Dim letterCount As Integer = 0


        For Each Letter In password
            If InStr(CAPTITALS, Letter) > 0 Then
                CapBool = True
            End If
            If InStr(LOWERCASE, Letter) > 0 Then
                LowCBool = True
            End If
            If InStr(NUMBERS, Letter) > 0 Then
                NumBool = True
            End If
            If InStr(CHARS, Letter) > 0 Then
                CharBool = True
            End If

        Next
        If CapBool = True And LowCBool = True And NumBool = True And CharBool = True And password.Length >= 6 Then
            Return True
        End If
        Return False
    End Function
End Class