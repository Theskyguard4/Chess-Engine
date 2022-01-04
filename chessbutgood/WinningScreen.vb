Public Class WinningScreen
   
    
    Private Sub WinningScreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Form1.ViewGame = False
        Form1.CloseGame = False
    End Sub

    Private Sub ViewGameButt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewGameButt.Click
        Form1.ViewGame = True
        Me.Close()
    End Sub

    Private Sub CloseGameButt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseGameButt.Click
        Form1.CloseGame = True
        Me.Close()
    End Sub
End Class