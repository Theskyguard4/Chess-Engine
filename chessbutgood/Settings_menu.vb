Public Class Settings_menu

    
    

    
    
    Private Sub Display_Game_Data_Default_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Display_Game_Data_Default.CheckedChanged
        Me.Display_Advanced_Data.Enabled() = Me.Display_Game_Data_Default.Checked
    End Sub

    Private Sub Settings_menu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub UseSetDepthCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UseSetDepthCheckBox.CheckedChanged

    End Sub
End Class