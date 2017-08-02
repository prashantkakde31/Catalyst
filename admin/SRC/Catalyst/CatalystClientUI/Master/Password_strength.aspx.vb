
Partial Class MASTER_Password_strength
    Inherits System.Web.UI.Page


    Protected Sub btn_close_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_close.Click
        Response.Write("<script language=javascript>{ window.close() }</script>")
    End Sub
End Class
