Public Class game
    Protected GameMovesString As List(Of String)
    Protected StartingTeam As Integer
    Protected BlackTeam As PlayerINFO
    Protected WhiteTeam As PlayerINFO
    Protected MoveCount As Integer
    Protected StartFEN As String
    Protected EndFEN As String

    Public Sub New(ByVal StartTeam As Integer, ByVal SFEN As String, ByVal BlackT As PlayerINFO, ByVal WhiteT As PlayerINFO)
        Me.StartingTeam = StartTeam
        Me.StartFEN = SFEN
        Me.BlackTeam = New PlayerINFO(BlackT.GameAliasC, BlackTeam.EloC, BlackT.ProfilePictureC)
        Me.WhiteTeam = New PlayerINFO(WhiteT.GameAliasC, WhiteT.EloC, WhiteT.ProfilePictureC)
    End Sub

    Public Sub GameMoveStringC(ByVal GMS As List(Of String))
        Me.GameMovesString = GMS
    End Sub
    Public Function GameMoveStringC()
        Return Me.GameMovesString
    End Function

    Public Sub StartingTeamC(ByVal ST As Integer)
        Me.StartingTeam = ST
    End Sub
    Public Function StartingTeamC()
        Return Me.StartingTeam
    End Function

    Public Sub Team(ByVal WhatTeam As Integer, ByVal Teams As PlayerINFO)
        Select Case WhatTeam
            Case 0
                Me.WhiteTeam = Teams
            Case 1
                Me.BlackTeam = Teams
        End Select
    End Sub
    Public Function Team(ByVal WhatTeam As Integer)
        Select Case WhatTeam
            Case 0
                Return Me.WhiteTeam
            Case 1
                Return Me.BlackTeam
        End Select
    End Function

    Public Sub MoveCountC(ByVal MC As Integer)
        Me.MoveCount = MC
    End Sub
    Public Function MoveCountC()
        Return Me.MoveCount
    End Function

    Public Sub FEN(ByVal SorE As String, ByVal Fen As String)
        Select Case SorE
            Case "START"
                Me.StartFEN = Fen
            Case "END"
                Me.EndFEN = Fen
        End Select
    End Sub
    Public Function FEN(ByVal SorE As String)
        Select Case SorE
            Case "START"
                Return Me.StartFEN
            Case "END"
                Return Me.EndFEN
        End Select
    End Function
End Class
