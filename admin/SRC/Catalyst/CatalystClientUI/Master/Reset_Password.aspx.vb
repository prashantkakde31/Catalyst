Imports System
Imports System.Data
Imports System.Data.SqlClient
Public Class admin_Reset_User_Password

    Inherits System.Web.UI.Page
    Dim acs As New HelperClass
#Region " Web Form Designer Generated Code "
    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    End Sub
    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        ViewStateUserKey = Session.SessionID
        InitializeComponent()
    End Sub
#End Region
    Dim conn As New SqlConnection(ConfigurationManager.AppSettings.Item("ConnectionStringV"))
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load


        If Session("UserCode") = "" Then
            Response.Write("<script language=javascript>alert('Your Session Has EXPIRE/NOT LOGGED  IN Please Login Again.')</script>")
            Response.Redirect(acs.mapLink(Request.Path))
        End If


        If Not Page.IsPostBack Then
            'Check this user have access right of this page
            Dim strchk As String = acs.CheckSession(Session("UserCode"), System.IO.Path.GetFileName(Request.PhysicalPath))
            'strchk = "VALID"
            If strchk = "INVALID" Then
                Session("HomeFlag") = "N"
                Session("UserCode") = ""
                Response.Redirect(acs.mapLink(Request.Path))
            End If
            pop_username()
        End If
        TextBox1.Attributes.Add("onkeypress", "funAlphaNumeric();")
        TextBox2.Attributes.Add("onkeypress", "funAlphaNumeric();")
        Response.Write("<script language=javascript>window.history.forward(1)</script>")
    End Sub
    ' SET NEW PASSWORD 
    Private Sub LinkButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        ' CHECK IF PASSWORD MATCH
        If TextBox2.Text = TextBox1.Text Then
            'Dim cmd As New SqlCommand("update ADMIN_MAPS_user_master set USER_PASSWORD= SYS_ENCRIPT(:newPassword,'E'), PASSWORD_DATE=SYSDATE  where UPPER(USER_NAME)= UPPER(:userCode) ", conn)
            Dim cmd As New SqlCommand("update ADMIN_MAPS_user_master set USER_PASSWORD = @newPassword , PASSWORD_DATE=getdate()  where UPPER(USER_NAME)= UPPER(@userCode) ", conn)
            Dim prmUCode As New SqlParameter("@userCode", SqlDbType.VarChar, 30)
            Dim prmNewPassword As New SqlParameter("@newPassword", SqlDbType.VarChar, 30)
            ' NO BLANK PASSWORD
            If TextBox1.Text.Trim = "" Then
                Tell.text("BLANK PASSOWRD NOT ALLOWED", Me)
                Exit Sub
            End If
            ' MIN 8 CHARS ONLY
            If TextBox1.Text.Length < 8 Then
                Tell.text("MINIMUM 8 CHARCTER ", Me)
                Exit Sub
            End If
            ' PASSWORD CANT BE AS USER NAME 
            If TextBox1.Text = ddlUserName.SelectedItem.Text Then
                Tell.text("PASSWORD CANT BE SAME AS USERNAME  ", Me)
                Exit Sub
            End If

            Dim abp As New HelperClass
            Dim msg As String = abp.ValidateText(TextBox1.Text, "PASSWORD", 50)
            If msg <> "Y" Then
                Tell.text(msg, Me)
                TextBox1.Text = ""
                Exit Sub
            End If

            prmNewPassword.Value = TextBox1.Text
            prmUCode.Value = ddlUserName.SelectedItem.Text + ""
            cmd.Parameters.Add(prmUCode)
            cmd.Parameters.Add(prmNewPassword)

            If conn.State = ConnectionState.Closed Then conn.Open()
            cmd.ExecuteNonQuery()
            Dim A As New AdminClass
            A.INSERT_INTO_TRAIL(ddlUserName.SelectedItem.Text.Trim.ToUpper, Session("UserCode"), "PASSWORD RESET")
            If conn.State = ConnectionState.Open Then conn.Close()
            Tell.text("Password Has Been Changed ", Me)
        Else
            'Response.Write("<script language=javascript>alert('Passwords do not match ')</script>")
            Tell.text("Passwords Do Not Match", Me)
        End If
    End Sub
    'Binds the data to dropdownList 
    Private Sub pop_username()
        Dim d As New data
        Dim Strmcc As String = "select distinct user_name from ADMIN_MAPS_user_master WHERE USER_NAME <> 'SUPERADMIN' AND DISABLED <> 'Y'"
        Dim dsmcc As DataSet = d.GetData(Strmcc)
        ddlUserName.DataTextField = "user_name"
        ddlUserName.DataValueField = "user_name"
        ddlUserName.DataSource = dsmcc
        ddlUserName.DataBind()
        ddlUserName.Dispose()
    End Sub
    'To go to Home page

    'PROCEDURE FOR DISPLAYING ERROR PAGE IF ERROR OCCURS IDURING APPLICATION EXCUTION 
    Private Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Error
        Dim PhyFilePath As String = System.AppDomain.CurrentDomain.BaseDirectory
        Dim sUser As String = Session("UserCode")
        Dim sLastError As String = Server.GetLastError.Message.ToString
        Dim sStackTrace As String = Server.GetLastError.StackTrace.ToString
        acs.WriteError(sLastError, sStackTrace, sUser, PhyFilePath, "ABPro")
    End Sub
End Class
'***********************************************************************************************************************
'End of <Reset_Password>
'***********************************************************************************************************************
