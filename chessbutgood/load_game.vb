Module load_game
    Public Function get_asset_folder_name()
        Dim foldername As String
        Dim BinLoc As Integer
        Dim FileLocation As Integer
        Dim AssetLocation As String = ""
        Dim FSO
        FSO = CreateObject("Scripting.FileSystemObject")
        foldername = FSO.GetAbsolutePathName(".")
        BinLoc = InStr(foldername, "bin")
        FileLocation = BinLoc - 1
        For II = 0 To FileLocation - 1
            AssetLocation &= foldername(II)
        Next


        AssetLocation &= "assets\"
        foldername = AssetLocation

        Return foldername
    End Function
    Public Sub load_settings_from_file()

        

        Try
            FileOpen(2, Form1.AssetFolderPath & "settings.txt", OpenMode.Input)

        Catch ex As System.IO.FileNotFoundException
            
            Write_settings_into_file(True)


        End Try
        FileClose(2)
    End Sub
    Public Sub Write_settings_into_file(ByVal default_settingsbool As Boolean)
        Dim default_settings_str As String

        Select Case default_settingsbool
            Case True


                FileOpen(2, Form1.AssetFolderPath & "settings.txt", OpenMode.Output)
                default_settings_str = ("-Board_file_name- ( " & "" & ")" & vbCrLf & "-White_Pawn_file_name- ()" & vbCrLf & "-Black_Pawn_file_name- ()" & vbCrLf & "-White_King_file_name- ()" & vbCrLf & "-Black_King_file_name- ()" & vbCrLf & "-White_Castle_file_name- ()" & vbCrLf & "-Black_Castle_file_name- ()" & vbCrLf & "-White_Bishop_file_name- ()" & vbCrLf & "-Black_Bishop_file_name- ()" & vbCrLf & "-White_Horse_file_name- ()" & vbCrLf & "-Black_Horse_file_name- ()" & vbCrLf & "-White_Queen_file_name- ()" & vbCrLf & "-Black_Queen_file_name- ()" & vbCrLf & "-SquareSelected_file_name- ()")
                PrintLine(2, default_settings_str)

            Case False

        End Select
        FileClose(2)
    End Sub
End Module
