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
            FileClose(2)
            read_settingsfile()
        Catch ex As System.IO.FileNotFoundException
            
            Write_settings_into_file(True)


        End Try

    End Sub
    Public Sub read_settingsfile() 'must be in default order, if not, delate file and rerun
        Dim count As Integer = 0
        Dim settings_line As String
        Dim start As Integer
        Dim path As String
        Dim finish As Integer
        FileOpen(2, Form1.AssetFolderPath & "settings.txt", OpenMode.Input)
        Do Until EOF(2)
            settings_line = LineInput(2)
            start = InStr(settings_line, "(") - 1
            finish = InStr(settings_line, ")") - 1
            If start < 0 Or finish < 0 Then
                MsgBox("ERROR: Path Not Found (No Path In Line " & count + 1 & ")")
                Exit Do
            End If
            path = ""
            For II = start + 1 To finish - 1
                path &= settings_line(II)
            Next
            Select Case count
                Case 0
                    'board
                Case 1
                    Form1.whitepawnfile = path
                Case 2
                    Form1.blackpawnfile = path
                Case 3
                    Form1.whitekingfile = path
                Case 4
                    Form1.blackkingfile = path
                Case 5
                    Form1.whitecastlefile = path
                Case 6
                    Form1.blackcastlefile = path
                Case 7
                    Form1.whitebishopfile = path
                Case 8
                    Form1.blackbishopfile = path
                Case 9
                    Form1.whitehorsefile = path
                Case 10
                    Form1.blackhorsefile = path
                Case 11
                    Form1.whitequeenfile = path
                Case 12
                    Form1.blackqueenfile = path
                Case 13
                    Form1.selectedblankfile = path
                Case 14
                    Form1.blankfile = path

                Case 15
                    Form1.settings.DisplayDefaultdata = path
                Case 16
                    Form1.settings.DisplayAdvancedData = path
                Case 17
                    Form1.settings.UseSetDepth = path
                Case 18
                    Form1.settings.DepthSearchTimeMax = path
                Case 19
                    Form1.settings.DepthSearchIntegerMax = path
                Case 29 ' after all files
            End Select
            count += 1
            path = ""
        Loop
        FileClose(2)
    End Sub
    Public Sub Write_settings_into_file(ByVal default_settingsbool As Boolean)
        Dim default_settings_str As String

        Select Case default_settingsbool
            Case True

                Form1.whitepawnfile = Form1.AssetFolderPath & "wpawn.png"
                Form1.blackpawnfile = Form1.AssetFolderPath & "bpawn.png"

                Form1.whitekingfile = Form1.AssetFolderPath & "wking.png"
                Form1.blackkingfile = Form1.AssetFolderPath & "bking.png"

                Form1.whitequeenfile = Form1.AssetFolderPath & "wqueen.png"
                Form1.blackqueenfile = Form1.AssetFolderPath & "bqueen.png"

                Form1.whitebishopfile = Form1.AssetFolderPath & "wbich.png"
                Form1.blackbishopfile = Form1.AssetFolderPath & "bbich.png"

                Form1.whitecastlefile = Form1.AssetFolderPath & "wcastle.png"
                Form1.blackcastlefile = Form1.AssetFolderPath & "bcastle.png"

                Form1.whitehorsefile = Form1.AssetFolderPath & "whorse.png"
                Form1.blackhorsefile = Form1.AssetFolderPath & "bhorse.png"

                Form1.selectedblankfile = Form1.AssetFolderPath & "selected.png"
                Form1.blankfile = Form1.AssetFolderPath & "blankse.png"


                Form1.settings.DisplayDefaultdata = True
                Form1.settings.DisplayAdvancedData = False
                Form1.settings.UseSetDepth = False
                Form1.settings.DepthSearchTimeMax = 30
                Form1.settings.DepthSearchIntegerMax = 4


                FileOpen(2, Form1.AssetFolderPath & "settings.txt", OpenMode.Output)
                default_settings_str = ("-Board_file_name- ( " & "" & ")" & vbCrLf & "-White_Pawn_file_name- (" & Form1.whitepawnfile & ")" & vbCrLf & "-Black_Pawn_file_name- (" & Form1.blackpawnfile & ")" & vbCrLf & "-White_King_file_name- (" & Form1.whitekingfile & ")" & vbCrLf & "-Black_King_file_name- (" & Form1.blackkingfile & ")" & vbCrLf & "-White_Castle_file_name- (" & Form1.whitecastlefile & ")" & vbCrLf & "-Black_Castle_file_name- (" & Form1.blackcastlefile & ")" & vbCrLf & "-White_Bishop_file_name- (" & Form1.whitebishopfile & ")" & vbCrLf & "-Black_Bishop_file_name- (" & Form1.blackbishopfile & ")" & vbCrLf & "-White_Horse_file_name- (" & Form1.whitehorsefile & ")" & vbCrLf & "-Black_Horse_file_name- (" & Form1.blackhorsefile & ")" & vbCrLf & "-White_Queen_file_name- (" & Form1.whitequeenfile & ")" & vbCrLf & "-Black_Queen_file_name- (" & Form1.blackqueenfile & ")" & vbCrLf & "-SquareSelected_file_name- (" & Form1.selectedblankfile & ")" & vbCrLf & "-BlankSquare_file_name- (" & Form1.blankfile & ")" & vbCrLf & "-Display_default_data_- (" & Form1.settings.DisplayDefaultdata & ")" & vbCrLf & "-Display_advanced_data- (" & Form1.settings.DisplayAdvancedData & ")" & vbCrLf & "-UseSetDepthIntBOOL- (" & Form1.settings.UseSetDepth & ")" & vbCrLf & "-SetDepthTime- (" & Form1.settings.DepthSearchTimeMax & ")" & vbCrLf & "-SetDepthMaxINT- (" & Form1.settings.DepthSearchIntegerMax & ")")
                PrintLine(2, default_settings_str)

            Case False

        End Select
        FileClose(2)
        MsgBox("Created Settings.txt (Settings Reset)")
    End Sub
End Module
