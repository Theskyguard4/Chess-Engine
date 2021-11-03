Public Class FEN_Code
    Private FEN_string As String
    Public Sub Set_FEN(ByVal FEN)
        FEN_string = FEN
    End Sub
    Public Function GET_FEN()
        Return FEN_string
    End Function
    Public Sub New()

    End Sub
    Private Function convert(ByVal FEN As String)
        Dim newstring As String
        For I = 0 To FEN_string.Length - 1
            Select Case FEN(I).ToString
                Case "R"
                    newstring &= "C"
                Case "r"
                    newstring &= "c"
                Case "N"
                    newstring &= "H"
                Case "n"
                    newstring &= "h"
                Case Else
                    newstring &= FEN_string(I)
            End Select
        Next
        Return newstring
    End Function

    Public Function Setboard(ByVal board(,) As theboardclass)
        Dim count As Integer = 0
        Dim y As Integer = 0
        Dim Num As Integer = 0
        FEN_string = convert(FEN_string)
        For I = 0 To FEN_string.Length - 1
            If count < 8 And y < 8 Then
                If IsNumeric(FEN_string(I)) = True Then
                    For II = 1 To Val(FEN_string(I))
                        board(count, y) = New theboardclass("_", "2")
                        count += 1
                    Next


                Else
                    If FEN_string(I) <> "/" Then
                        If AscW(FEN_string(I)) >= 65 And AscW(FEN_string(I)) <= 90 Then
                            board(count, y) = New theboardclass(LCase(FEN_string(I)), "1")
                            Select Case LCase(FEN_string(I))
                                Case "p"
                                    Form1.wpawncount += 1
                                Case "c"
                                    Form1.wcastlecount += 1
                                Case "b"
                                    Form1.wbishopcount += 1
                                Case "h"
                                    Form1.whorsecount += 1
                                Case "q"
                                    Form1.wqueencount += 1

                            End Select
                        ElseIf AscW(FEN_string(I)) >= 97 And AscW(FEN_string(I)) <= 122 Then
                            board(count, y) = New theboardclass(LCase(FEN_string(I)), "0")
                            Select Case LCase(FEN_string(I))
                                Case "p"
                                    Form1.bpawncount += 1
                                Case "c"
                                    Form1.bcastlecount += 1
                                Case "b"
                                    Form1.bbishopcount += 1
                                Case "h"
                                    Form1.bhorsecount += 1
                                Case "q"
                                    Form1.bqueencount += 1

                            End Select
                        End If
                        count += 1
                    Else
                        y += 1
                    End If


                End If
            Else
                count = 0
                y += 1
            End If



        Next




        Return board
    End Function
    Public Function Save_board(ByVal board(,) As theboardclass)
        Dim FEN_STRING_NEW As String
        Dim count As Integer = 0

        For yy = 0 To 7
            For xx = 0 To 7
                If board(xx, yy).getsym = "_" Then
                    count += 1
                Else
                    If count <> 0 Then
                        FEN_STRING_NEW &= count.ToString
                    End If
                    If board(xx, yy).getteam = 0 Then
                        FEN_STRING_NEW &= LCase(board(xx, yy).getsym)
                    ElseIf board(xx, yy).getteam = 1 Then
                        FEN_STRING_NEW &= UCase(board(xx, yy).getsym)
                    End If
                    count = 0
                End If

            Next
            If count <> 0 Then

                FEN_STRING_NEW &= count.ToString
                count = 0
            End If
            If yy <> 7 Then
                FEN_STRING_NEW &= "/"
            End If



        Next
        Return FEN_STRING_NEW

    End Function
End Class
