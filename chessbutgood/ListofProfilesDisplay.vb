Public Class ListofProfilesDisplay

    Private Sub ListOfUsers_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ListOfUsers.CellContentClick
        

    End Sub

    Private Sub ListofProfilesDisplay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Temp As New DataTable

        Temp.Columns.Add("UserName")
        Temp.Columns.Add("Elo")
        For II = 0 To MAIN_MENU.AllUsersInfoL.Count - 1
            Temp.Rows.Add(MAIN_MENU.AllUsersInfoL(II).UserName, MAIN_MENU.AllUsersInfoL(II).elo)

        Next

        ListOfUsers.DataSource = Temp

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class