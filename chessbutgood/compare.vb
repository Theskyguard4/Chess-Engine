Module compare
    Public Sub compare_stockfish_perft_results(ByVal Myresultsdir As String, ByVal StockFishDir As String)
        Dim StockFishArray(1) As String
        Dim MyArray(1) As String
        Dim counter As Integer = 0
        Dim stockfishmove As String
        Dim stockfishcount As String
        Dim mymoves As String
        Dim mycount As String
        Dim new_file_string As String = ""
        Dim fullstockfishcount As Integer
        FileOpen(1, StockFishDir, OpenMode.Input)
        Do Until EOF(1)
            StockFishArray(counter) = LineInput(1)
            counter += 1
            ReDim Preserve StockFishArray(counter)
        Loop
        ReDim Preserve StockFishArray(counter - 1)
        FileClose(1)
        


        counter = 0
        FileOpen(2, Myresultsdir, OpenMode.Input)
        Do Until EOF(2)
            MyArray(counter) = LineInput(2)
            counter += 1
            ReDim Preserve MyArray(counter)
        Loop
        ReDim Preserve MyArray(counter - 1)
        FileClose(2)
        If StockFishArray(1) = MyArray(1) Then
            MyArray = Nothing
        End If
        Dim count As Integer = 0
        Dim Initialmovecount As Integer = 0
        Dim isokay As Boolean = False
        For Each sfMove In StockFishArray
            isokay = False
            stockfishmove = sfMove.Split(":")(0)
            stockfishcount = Right(sfMove.Split(":")(1), sfMove.Split(":")(1).Length - 1)
            fullstockfishcount += stockfishcount
            For Each Mymove In MyArray
                mymoves = Mymove.Split(":")(0)
                mycount = Int(Right(Mymove.Split(":")(1), Mymove.Split(":")(1).Length - 1))
                If mymoves = stockfishmove Then
                    isokay = True
                    If mycount = stockfishcount Then
                        new_file_string &= Mymove & " CORRECT    Mine = " & mycount & " -- StockFish = " & stockfishcount & vbCrLf
                    Else
                        new_file_string &= Mymove & " WRONG    Mine = " & mycount & " -- StockFish = " & stockfishcount & vbCrLf
                    End If
                    Initialmovecount += 1
                    count += Int(mycount)
                End If


            Next
            If isokay = False Then
                new_file_string &= "Missing Move: " & stockfishmove & vbCrLf
            End If
        Next
        new_file_string &= "Final Count: " & count & " Intial Moves: " & Initialmovecount & " StockfishFullCount: " & fullstockfishcount + Initialmovecount
        FileOpen(3, "D:\OutputFileStockfishComparison.txt", OpenMode.Output)
        Print(3, new_file_string)
        FileClose(3)
        MsgBox("compared")
    End Sub
End Module
