'***********************************************************************************************************************                                     
' File Name            : <Add_NewMenu>
' Location             : In-Solutions Global Pvt. Ltd., Malad                               
' Author               :<JAWEED KHAN> 
' PADss Created        :<Sonali Mayekar>, Emp. No: <C1194>
' Date of Creation     : <02/07/2007>
' PADss Date           :<07/09/2012>
' Description          : ADDING NEW MENU
'*********************************************************************************************************************** 
Imports System
Imports System.Data
''Imports System.Data.SQLClient

Imports System.Data.SqlClient

Partial Class admin_Add_NewMenu

    Inherits System.Web.UI.Page
    Dim da As New SqlDataAdapter
    Dim cmd As New SqlCommand
    Dim ds As New DataSet
    Dim strQuery As String
    ''Public SQLhelper As SQLHelper
    Dim conn As New System.Data.SqlClient.SqlConnection(ConfigurationManager.AppSettings("conn"))
    Dim abp As New HelperClass
    Dim acs As New HelperClass

#Region " Web Form Designer Generated Code "
    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    End Sub
    Protected WithEvents Panel_MenuDetails As System.Web.UI.WebControls.Panel
    Private designerPlaceholderDeclaration As System.Object
    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        ViewStateUserKey = Session.SessionID
        InitializeComponent()
    End Sub
#End Region
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load

        ' ''Session("UserCode") = "ADMIN"
        ''If Session("UserCode") = "" Then
        ''    Response.Write("<script language=javascript>alert('Your Session Has EXPIRE/NOT LOGGED  IN Please Login Again.')</script>")
        ''    Response.Redirect(acs.mapLink(Request.Path))
        ''End If


        txt_FunctionCode.Attributes.Add("onkeypress", "funNumber();")
        txt_FunctionDesc.Attributes.Add("onkeypress", "funCharacter();")

        If Not IsPostBack Then
            'Check this user have access right of this page
            Dim strchk As String = acs.CheckSession(Session("UserCode"), System.IO.Path.GetFileName(Request.PhysicalPath))
            If strchk = "INVALID" Then
                Session("HomeFlag") = "N"
                Session("UserCode") = ""
                Response.Redirect(acs.mapLink(Request.Path))
            End If

            populateGrid()
            Me.btn_CreateMenu.Attributes.Add("onClick", "return Validate();")
            Me.btn_CreateMenu.Enabled = False
        End If
    End Sub

    Sub populateGrid()
        strQuery = "Select *  from ADMIN_MAPS_MENU_LIST "
        cmd.CommandText = strQuery
        cmd.Connection = conn
        If conn.State = ConnectionState.Closed Then conn.Open()
        da.SelectCommand = cmd
        da.Fill(ds)
        dg_Show.DataSource = ds
        dg_Show.DataBind()
    End Sub
    Private Sub btn_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Add.Click
        'Dim strcc As String = "select max(a1 ) +1 from ( (SELECT MAX(nvl(MENU_CODE,0)) A1 FROM ADMIN_MAPS_menu_list))"
        Dim strcc As String = "SELECT isnull(MAX(MENU_CODE),0) + 1 FROM ADMIN_MAPS_MENU_LIST"

        Dim CMDCC As New SqlCommand(strcc, conn)
        If conn.State = ConnectionState.Closed Then conn.Open()
        Call ClearTexts()
        txt_FunctionCode.Text = CMDCC.ExecuteScalar
        btn_CreateMenu.Enabled = True
        MySetFocus(txt_FunctionDesc)
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Dispose()
        txt_FunctionDesc.Text = ""
    End Sub
    Private Sub MySetFocus(ByVal ctrl As Control)
        Dim str As String = "<script language=javascript>document.getElementById('" & ctrl.ClientID & "').focus()</script>"
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MySetFocus", str)
    End Sub
    Private Sub btn_CreateMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CreateMenu.Click
        Dim cmdInsert As New SqlCommand
        Dim intCounter As Integer
        cmdInsert.CommandText = "Insert Into ADMIN_MAPS_MENU_LIST (MENU_CODE, MENU_DESC) values(@MENU_CODE, @MENU_DESC)"
        cmdInsert.Connection = conn

        Dim prmMENU_CODE As New SqlParameter("@MENU_CODE", SqlDbType.Int, 4)
        Dim prmMENU_DESC As New SqlParameter("@MENU_DESC", SqlDbType.NChar, 100)

        cmdInsert.Parameters.Add(prmMENU_CODE)
        cmdInsert.Parameters.Add(prmMENU_DESC)

        Dim msg As String
        msg = abp.ValidateText(txt_FunctionCode.Text, "Function Code", 4)
        If msg <> "Y" Then
            Tell.text(msg, Me)
            txt_FunctionCode.Text = ""
            MySetFocus(txt_FunctionCode)
            Exit Sub
        End If

        If abp.ValidateNumber(txt_FunctionCode.Text.Trim) = False Then
            Tell.text("Please enter the number", Me)
            txt_FunctionCode.Text = ""
            MySetFocus(txt_FunctionCode)
            Exit Sub
        End If

        msg = abp.ValidateText(txt_FunctionDesc.Text, "FUNCTION DESCRIPTION", 100)
        If msg <> "Y" Then
            Tell.text(msg, Me)
            txt_FunctionDesc.Text = ""
            MySetFocus(txt_FunctionDesc)
            Exit Sub
        End If

        prmMENU_CODE.Value = txt_FunctionCode.Text.Trim.ToUpper
        prmMENU_DESC.Value = txt_FunctionDesc.Text.Trim

        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim strQuery As String = "Select Count(*) From ADMIN_MAPS_MENU_LIST Where MENU_CODE= @MENU_COD "
        Dim prmMENU_COD As New SqlParameter("@MENU_COD", SqlDbType.Int, 4)
        prmMENU_COD.Value = txt_FunctionCode.Text.Trim.ToUpper

        Dim cmd As New SqlCommand()
        cmd.CommandText = strQuery
        cmd.Connection = conn
        cmd.Parameters.Add(prmMENU_COD)

        intCounter = cmd.ExecuteScalar()

        If (intCounter > 0) Then
            lab_ErrMsg.Text = "Menu Code Already Exist!..."
        Else
            cmdInsert.ExecuteNonQuery()
            lab_ErrMsg.Text = "New Menu Added Successfully!..."
        End If
        If (conn.State = ConnectionState.Open) Then
            conn.Close()
        End If

        populateGrid()
        ClearTexts()
    End Sub
    Sub ClearTexts()
        txt_FunctionCode.Text = ""
        txt_FunctionDesc.Text = ""
    End Sub
    'Private Sub dg_Show_PageIndexChanged1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
    '    dg_Show.CurrentPageIndex = e.NewPageIndex
    '    populateGrid()
    'End Sub
    Private Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Error
        Dim PhyFilePath As String = System.AppDomain.CurrentDomain.BaseDirectory
        Dim sUser As String = Session("UserCode")
        Dim sLastError As String = Server.GetLastError.Message.ToString
        Dim sStackTrace As String = Server.GetLastError.StackTrace.ToString
        acs.WriteError(sLastError, sStackTrace, sUser, PhyFilePath, "NPCI_Loyalty-AddNewMenu")
    End Sub

    Protected Sub dg_Show_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles dg_Show.PageIndexChanging
        dg_Show.PageIndex = e.NewPageIndex

        ''dg_Show.CurrentPageIndex = e.NewPageIndex
        populateGrid()
    End Sub
End Class
'***********************************************************************************************************************
'End of <Add_NewMenu>
'***********************************************************************************************************************