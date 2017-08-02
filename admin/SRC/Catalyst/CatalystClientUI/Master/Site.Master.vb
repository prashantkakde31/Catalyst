Imports System.Data
Imports System.Data.SqlClient


Public Class MASTER_Site
    Inherits System.Web.UI.MasterPage

    Dim CONN As New SqlConnection(ConfigurationManager.AppSettings("ConnectionStringV"))
    Dim acs As New HelperClass
    Dim cmd As New SqlCommand
    Dim prmUSER_NAME As New SqlParameter("USER_NAME", SqlDbType.VarChar)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ''lnk_logout.Attributes.Add("onMouseOver", "window.status='ISG'; return true;")

    End Sub


End Class