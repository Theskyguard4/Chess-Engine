Public Class PlayerINFO
    Protected GameAlias As String
    Protected PassWord As String
    Protected Elo As Integer
    Protected ProfilePicture As Image

    Public Sub New(ByVal Name As String, ByVal EloNew As Integer, ByVal PP As Image)
        Me.GameAlias = Name
        Me.Elo = EloNew
        Me.ProfilePicture = PP
    End Sub
    Public Sub New()
    End Sub

    Public Function PasswordC()
        Return Me.PassWord
    End Function
    Public Sub PasswordC(ByVal p As String)
        Me.PassWord = p
    End Sub

    Public Function GameAliasC()
        Return Me.GameAlias
    End Function
    Public Sub GameAliasC(ByVal GA As String)
        Me.GameAlias = GA
    End Sub

    Public Function EloC()
        Return Me.Elo
    End Function
    Public Sub EloC(ByVal E As Integer)
        Me.Elo = E
    End Sub

    Public Function ProfilePictureC()
        Return Me.ProfilePicture
    End Function
    Public Sub ProfilePictureC(ByVal PP As Image)
        Me.ProfilePicture = PP
    End Sub
End Class
