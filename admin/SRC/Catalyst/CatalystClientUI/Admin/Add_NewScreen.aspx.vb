
'***********************************************************************************************************************                                     
' File Name            : <Add_NewScreen>
' Location             : In-Solutions Global Pvt. Ltd., Malad                               
' Author               : <Jaweed Khan>
' Author PADSS         : <Sonali Mayekar>, Emp. No: <C1194>
' Date of Creation     : <28/11/2006>
' Date of PADSS        : <28/01/2012>
'***********************************************************************************************************************
Imports System.Data.SqlClient
Imports System.Data

Partial Class admin_Add_NewScreen

    Inherits System.Web.UI.Page
    Dim da As New SqlDataAdapter
    Dim cmd As New SqlCommand
    Dim ds As New DataSet
    Dim strQuery As String
    Dim acs As New HelperClass
    'Public objHelp As SqlHelper
    Dim conn As New SqlConnection(ConfigurationSettings.AppSettings("conn"))

#Region " Web Form Designer Generated Code "
    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    End Sub
    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object
    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        ViewStateUserKey = Session.SessionID
        InitializeComponent()
    End Sub
#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        'Session("UserCode") = "ADMIN"
        'If Session("UserCode") = "" Then
        '    Response.Write("<script language=javascript>alert('Your Session Has EXPIRE/NOT LOGGED  IN Please Login Again.')</script>")
        '    Response.Redirect(acs.mapLink(Request.Path))
        'End If

        txt_FunctionCode.Attributes.Add("onkeypress", "funNumber();")
        txt_FunctionDesc.Attributes.Add("onkeypress", "funCharacter();")
        'txt_Path.Attributes.Add("onkeypress", "funCharacter();")

        If Not IsPostBack Then
            Dim strchk As String = acs.CheckSession(Session("UserCode"), System.IO.Path.GetFileName(Request.PhysicalPath))
            If strchk = "INVALID" Then
                Session("HomeFlag") = "N"
                Session("UserCode") = ""
                Response.Redirect(acs.mapLink(Request.Path))
            End If

            populateGrid()
            'acs.loaddropdown(DD_MenuName, "Select Distinct MENU_CODE,MENU_DESC From ADMIN_MAPS_menu_list Union  Select to_number('') ,' ' MENU_DESC From ADMIN_MAPS_menu_list order by menu_desc", conn, "MENU_DESC", "MENU_CODE")
            acs.loaddropdown(DD_MenuName, "Select Distinct MENU_CODE,MENU_DESC From ADMIN_MAPS_menu_list ", conn, "MENU_DESC", "MENU_CODE")
            Me.btn_CreateScreen.Attributes.Add("onClick", "return Validate();")
            Me.btn_CreateScreen.Enabled = False
        End If
    End Sub
    Sub populateGrid()
        strQuery = "select * from ADMIN_MAPS_FUNCTION_MASTER Order By FUNCTION_CODE"
        cmd.CommandText = strQuery
        cmd.Connection = conn
        If conn.State = ConnectionState.Closed Then conn.Open()
        da.SelectCommand = cmd
        da.Fill(ds)
        dg_Show.DataSource = ds
        dg_Show.DataBind()
    End Sub
    Sub ClearTexts()
        txt_FunctionCode.Text = ""
        txt_FunctionDesc.Text = ""
        txt_ToolTip.Text = ""
        txt_Path.Text = ""
        DD_MenuName.SelectedIndex = 0

    End Sub
    Private Sub MysetFocus(ByVal ctrl As Control)
        Dim str As String = "<script language=javascript>document.getElementById('" & ctrl.ClientID & "').focus()</script>"
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MySetFocus", str)
    End Sub

    Private Sub btn_AddScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AddScreen.Click
        Dim strcc As String = "SELECT MAX(FUNCTION_CODE)+1 FROM ADMIN_MAPS_FUNCTION_MASTER"
        Dim CMDCC As New SqlCommand(strcc, conn)
        If conn.State = ConnectionState.Closed Then conn.Open()
        txt_FunctionCode.Text = CMDCC.ExecuteScalar
        btn_CreateScreen.Enabled = True
        SetFocus(txt_FunctionDesc)
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Dispose()
    End Sub
    Private Sub btn_CreateScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CreateScreen.Click
        If DD_MenuName.SelectedIndex = 0 Then
            Tell.text("Please Select the Menu Name", Me)
            Exit Sub
        End If


        Dim sMsg As String = acs.ValidateText(txt_FunctionDesc.Text, "Function Desc", 100)
        If sMsg.Trim <> "Y" Then
            Tell.text(sMsg, Me)
            Exit Sub
        End If
        sMsg = acs.ValidateText(txt_Path.Text, "Path", 100)
        If sMsg.Trim <> "Y" Then
            Tell.text(sMsg, Me)
            Exit Sub
        End If

        sMsg = acs.ValidateText(txt_FunctionCode.Text, ",Function Code", 4)
        If sMsg.Trim <> "Y" Then
            Tell.text(sMsg, Me)
            Exit Sub
        End If

        sMsg = acs.ValidateText(txt_ToolTip.Text, ",ToolTip", 100)
        If sMsg.Trim <> "Y" Then
            Tell.text(sMsg, Me)
            Exit Sub
        End If


        Dim cmdInsert As New SqlCommand

        If DD_MenuName.SelectedIndex = 0 Then
            lab_ErrMsg.Text = "Please Select Module Name!..."
            Exit Sub
        Else

            txt_ModuleCodeHide.Text = DD_MenuName.SelectedItem.Value

            cmdInsert.CommandText = "Insert Into ADMIN_MAPS_FUNCTION_MASTER (FUNCTION_CODE, MODULE_CODE, FUNCTION_DESC, FUNCTION_SCREEN,TOOLTIP ) values(@FUNCTION_CODE, @MENU_CODE, @FUNCTION_DESC, @FUNCTION_SCREEN,@ToolTip)"
            cmdInsert.Connection = conn
            Dim prmFUNCTION_CODE As New SqlParameter("@FUNCTION_CODE", SqlDbType.Int, 4)
            Dim prmMENU_CODE As New SqlParameter("@MENU_CODE", SqlDbType.Int, 4)
            Dim prmFUNCTION_DESC As New SqlParameter("@FUNCTION_DESC", SqlDbType.VarChar, 100)
            Dim prmFUNCTION_SCREEN As New SqlParameter("@FUNCTION_SCREEN", SqlDbType.VarChar, 100)
            Dim prmToolTip As New SqlParameter("@ToolTip", SqlDbType.VarChar, 100)

            cmdInsert.Parameters.Add(prmFUNCTION_CODE)
            cmdInsert.Parameters.Add(prmMENU_CODE)
            cmdInsert.Parameters.Add(prmFUNCTION_DESC)
            cmdInsert.Parameters.Add(prmFUNCTION_SCREEN)
            cmdInsert.Parameters.Add(prmToolTip)

            prmFUNCTION_CODE.Value = txt_FunctionCode.Text.Trim
            prmMENU_CODE.Value = txt_ModuleCodeHide.Text.Trim
            prmFUNCTION_DESC.Value = txt_FunctionDesc.Text.Trim
            prmFUNCTION_SCREEN.Value = txt_Path.Text.Trim
            prmToolTip.Value = txt_ToolTip.Text.Trim


            If conn.State = ConnectionState.Closed Then conn.Open()
            cmdInsert.ExecuteNonQuery()
            lab_ErrMsg.Text = "New Module Added Successfully!..."
        End If
        populateGrid()
        ClearTexts()
        btn_CreateScreen.Enabled = False
    End Sub

    Private Sub dg_Show_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dg_Show.PageIndexChanged
        dg_Show.CurrentPageIndex = e.NewPageIndex
        populateGrid()
    End Sub
    Private Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Error
        Dim PhyFilePath As String = System.AppDomain.CurrentDomain.BaseDirectory
        Dim sUser As String = Session("UserCode")
        Dim sLastError As String = Server.GetLastError.Message.ToString
        Dim sStackTrace As String = Server.GetLastError.StackTrace.ToString
        acs.WriteError(sLastError, sStackTrace, sUser, PhyFilePath, "NPCI_Loyalty-AddNewScreen")
    End Sub
End Class
'***********************************************************************************************************************
'End of <Add_NewScreen>
'***********************************************************************************************************************