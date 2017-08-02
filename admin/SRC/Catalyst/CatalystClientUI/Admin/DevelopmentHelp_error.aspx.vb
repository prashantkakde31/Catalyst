Public Class admin_DevelopmentHelp_error
    Inherits System.Web.UI.Page

    Dim acs As New HelperClass
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    End Sub
    'Protected WithEvents lnk_home As System.Web.UI.WebControls.LinkButton

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        lbl_1.Text = Session("UserCode")
        lbl_2.Text = DateTime.Now
    End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Session.Clear()
        Session.Abandon()
        Session.RemoveAll()

        If Request.Cookies("ASP.NET_SessionId") IsNot Nothing Then
            Response.Cookies("ASP.NET_SessionId").Value = String.Empty
            Response.Cookies("ASP.NET_SessionId").Expires = DateTime.Now.AddMonths(-20)
        End If

        Response.Redirect(acs.mapLink(Request.Path))
        Response.Cookies.Clear()

    End Sub
End Class
