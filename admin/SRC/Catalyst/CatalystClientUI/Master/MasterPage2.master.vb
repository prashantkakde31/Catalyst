Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Net
Imports System.IO
Imports System.Web
Imports System.Web.Services

Partial Class Master_MasterPage2
    Inherits System.Web.UI.MasterPage
    Dim CONN As New SqlConnection(ConfigurationManager.AppSettings("conn"))
    Dim acs As New HelperClass
    Dim cmd As New SqlCommand
    Dim data As New data
    Dim Reader As SqlDataReader
    Dim da As New SqlDataAdapter
    Dim dr_master, dr, dr_leaf As SqlDataReader
    Dim prmPARENT_ID As New SqlParameter("@PARENT_ID", SqlDbType.Int)
    Dim prmUSER_ID As New SqlParameter("@USER_ID", SqlDbType.Int)
    Dim prmUNAME As New SqlParameter("@UNAME", SqlDbType.Char)
    Dim prmUSER_NAME As New SqlParameter("@USER_NAME", SqlDbType.Char)
    Dim strRootNodeflg As String
    Dim Uid As Integer
    Dim strCmd As String
    Dim menuBuilder As New StringBuilder
    Dim menuBuilderNew As New StringBuilder
    'Dim AntiXsrfTokenKey As String = "__AntiXsrfToken"
    'Dim AntiXsrfUserNameKey As String = "__AntiXsrfUserName"
    'Dim _antiXsrfTokenValue As String


    Protected Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error
        Dim PhyFilePath As String = System.AppDomain.CurrentDomain.BaseDirectory
        Dim sUser As String = Session("UserCode")
        Dim sLastError As String = Server.GetLastError.Message.ToString
        Dim sStackTrace As String = Server.GetLastError.StackTrace.ToString
        acs.WriteError(sLastError, sStackTrace, sUser, PhyFilePath, "NPCI-MasterPage2")
    End Sub

    Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        If Page.User.Identity.IsAuthenticated Then
            Page.ViewStateUserKey = Session.SessionID
        End If

        'If Request.Cookies("ASP.NET_SessionId") IsNot Nothing Then
        '    Response.Cookies("ASP.NET_SessionId").Path = "/NPCI_Loyalty/"
        '    Response.Cookies("ASP.NET_SessionId").Expires = DateTime.Now.AddMinutes(20)
        'End If
        'First, check for the existence of the Anti-XSS cookie
        'Dim requestCookie As = Request.Cookies(
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TreeView1.Attributes.Add("onMouseOver", "window.status='ISG'; return true;")
        lnk_logout.Attributes.Add("onMouseOver", "window.status='ISG'; return true;")

        If Session("UserCode") = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "message", "alert('Your Session Has EXPIRE/NOT LOGGED  IN Please Login Again.');", True)
            Response.Redirect(acs.mapLink(Request.Path))
        End If
       
        If Not Page.IsPostBack Then

            GetUserId()
            BindMenu()
            navigation.InnerHtml = menuBuilderNew.ToString
            TreeView1.Visible = True

            ' Below Line Commented by Jayesh which needs to be open later
            'lbl_time.Text = data.ExScalar("select to_char(max(LOGINAT),'dd-Mon-yy HH24:Mi:SS') as lastlogin from SESSION_TRACKING_LOG where username='" & Session("UserCode") & "'")
            'Below line is added by subhash patil for sql database to get datetime
            'lbl_time.Text = data.ExScalar("SELECT CONVERT(varchar, cast(MAX(LOGINAT) as date), 113) + ' ' + RIGHT(CONVERT(VARCHAR, CONVERT(datetime, MAX(LOGINAT)), 100), 7) AS lastlogin FROM SESSION_TRACKING_LOG where username='" & Session("UserCode") & "'")
            lbl_time.Text = data.ExScalar("SELECT CONVERT(VARCHAR, MAX(LOGINAT),113) AS lastlogin FROM SESSION_TRACKING_LOG where username='" & Session("UserCode") & "'")
            lbl_username.Text = Session("UserCode")
        End If


        'To Disable Back Button  -----> Added By Milan
        'Response.Write("<script language=javascript>window.history.forward(1)</script>")

    End Sub

    Protected Sub lnk_logout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_logout.Click
        If CONN.State = ConnectionState.Closed Then CONN.Open()
        cmd.CommandText = "UPDATE SESSION_TRACKING_LOG SET LOGOUTAT = GETDATE() WHERE LOGINAT = (SELECT MAX(LOGINAT) FROM SESSION_TRACKING_LOG WHERE UPPER(USERNAME)=UPPER(@USER_NAME) ) AND LOGOUTAT IS NULL"

        cmd.Parameters.Add(prmUSER_NAME)
        prmUSER_NAME.Value = Session("UserCode")
        cmd.Connection = CONN
        cmd.ExecuteNonQuery()
        If Not Session("Uname") Is Nothing Then
            Dim j As String
            j = Session("Uname")
            Session.Abandon()
            Session("SelectedNode") = ""
            Response.Cookies.Add(New HttpCookie("ASP.NET_SessionId", ""))
            Session.Clear()
            Session("Uname") = j
        End If
        Session("UserCode") = ""
        Session("SelectedNode") = ""

        '=====Added by Milan=====
        Session.Clear()
        Session.Abandon()
        Session.RemoveAll()

        If Request.Cookies("ASP.NET_SessionId") IsNot Nothing Then
            Response.Cookies("ASP.NET_SessionId").Value = String.Empty
            Response.Cookies("ASP.NET_SessionId").Expires = DateTime.Now.AddMonths(-20)
        End If
        FormsAuthentication.SignOut()
        'Response.Redirect("../Master/index.aspx")
        Response.Cookies.Clear()
        Response.Redirect(acs.mapLink(Request.Path))
    End Sub

    Private Sub BindMenu()
        menuBuilder.Append("<div id='menu'>")
        menuBuilder.Append("<ul class='tabs'>")

        'menuBuilderNew.Append("<div id='menu'>")
        menuBuilderNew.Append("<ul class='nav nav-list'>")
        ''-------------------------------------------------------------------------------------------------
        ''      Gets Menu ItemCounnt
        ''-------------------------------------------------------------------------------------------------
        strCmd = " SELECT  MODULE_CODE ROOT,COUNT(*) CNT FROM  "
        strCmd = strCmd & "                (SELECT DISTINCT USERID, FORMID FROM ADMIN_USER_FORM_DETAIL) D,ADMIN_MAPS_FUNCTION_MASTER "
        strCmd = strCmd & "                WHERE D.FORMID=FUNCTION_CODE AND    "
        strCmd = strCmd & "                D.USERID = @USER_ID "
        strCmd = strCmd & "                GROUP BY MODULE_CODE ORDER BY MODULE_CODE"

        cmd.CommandText = strCmd
        cmd.Connection = CONN

        cmd.Parameters.Add(prmUSER_ID)
        prmUSER_ID.Value = txt_userid.Text

        If CONN.State = ConnectionState.Closed Then CONN.Open()
        dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

        Dim dr_menu As New DataTable()
        dr_menu.Load(dr)
        CONN.Close()
        cmd.Parameters.Clear()

        If dr_menu.Rows.Count > 0 Then
            For Each dr_row As DataRow In dr_menu.Rows
                ''-------------------------------------------------------------------------------------------------
                ''      Check Leaf Nodes Count
                If dr_row("CNT") > 1 Then
                    ''----------------------------------------------
                    ''      Create Root Node & Child Node
                    RootBind(dr_row("ROOT"))
                Else
                    ''----------------------------------------------
                    ''      Treat Child Node as Root Node
                    LeafBind(dr_row("ROOT"))
                End If
            Next
            menuBuilder.Replace("<li>", "<li class='last'>", menuBuilder.ToString.LastIndexOf("<li>"), 20)
            'menuBuilderNew.Replace("<li>", "<li class='last'>", menuBuilderNew.ToString.LastIndexOf("<li>"), 20)
        End If
        menuBuilder.Append("</ul></div>")
        menuBuilderNew.Append("</ul>")

        'If dr.HasRows Then
        '    While dr.Read
        '        ''-------------------------------------------------------------------------------------------------
        '        ''      Check Leaf Nodes Count
        '        If dr("CNT") > 1 Then
        '            ''----------------------------------------------
        '            ''      Create Root Node & Child Node
        '            RootBind(dr("ROOT"))
        '        Else
        '            ''----------------------------------------------
        '            ''      Treat Child Node as Root Node
        '            LeafBind(dr("ROOT"))
        '        End If
        '    End While
        'End If
    End Sub

    Private Sub RootBind(ByVal strRoot As String)
        Dim tempRoot As String = ""
        Dim tempLeaf As String = ""
        Dim lastAppendIndex As Integer
        Dim test As Integer

        ''get root name
        cmd.Parameters.Clear()
        Dim strMenuName, strMenuIcon As String
        Dim stCmd As String = ""
        Dim cmd_root As New SqlCommand

        'cmd.CommandText = "SELECT MENUTEXT FROM CRM_MENU_MASTER_WEB_RD WHERE ITEMID = " & strRoot
        cmd_root.CommandText = "SELECT MENU_DESC FROM ADMIN_MAPS_MENU_LIST WHERE MENU_CODE= " & strRoot
        cmd_root.Connection = CONN
        If CONN.State = ConnectionState.Closed Then CONN.Open()
        strMenuName = cmd_root.ExecuteScalar
        cmd_root.Parameters.Clear()
        CONN.Close()

        cmd_root.CommandText = "SELECT MENU_ICON FROM ADMIN_MAPS_MENU_LIST WHERE MENU_CODE= " & strRoot
        cmd_root.Connection = CONN
        If CONN.State = ConnectionState.Closed Then CONN.Open()
        strMenuIcon = If(Not IsDBNull(cmd_root.ExecuteScalar), cmd_root.ExecuteScalar, "")
        cmd_root.Parameters.Clear()
        CONN.Close()

        '--------------------------------------
        ''      Adding Root Node

        tempRoot = String.Format("<li class='hasmore'><a href='#'><span>{0}</span></a><ul class='dropdown'>", strMenuName.Trim())
        menuBuilder.Append(tempRoot)

        tempRoot = String.Format("<li class=''><a href='#' class='dropdown-toggle'><i class='menu-icon fa " + If(Not IsNothing(strMenuIcon), strMenuIcon, "fa-hand-o-right") + "'></i><span class='menu-text'>{0}</span><b class='arrow  fa fa-angle-down'></b></a><ul class='submenu'>", strMenuName.Trim())
        menuBuilderNew.Append(tempRoot)

        Dim trRoot As New TreeNode(strMenuName, strMenuName)

        '--------------------------------------

        '' gEt aLl lINKs for root having rights.
        strCmd = " SELECT DISTINCT P.MODULE_CODE ROOT,R.FORMID,P.FUNCTION_DESC MENU,P.FUNCTION_SCREEN URL,P.TOOLTIP TOOLTIP "
        strCmd = strCmd & "  FROM   ADMIN_USER_FORM_DETAIL R, ADMIN_MAPS_FUNCTION_MASTER P "
        strCmd = strCmd & " WHERE       P.MODULE_CODE = @PARENT_ID "
        strCmd = strCmd & "         AND R.FORMID = P.FUNCTION_CODE "
        strCmd = strCmd & "         AND R.USERID = @USER_ID "

        Dim cmd_root_one As New SqlCommand

        cmd_root_one.CommandText = strCmd

        cmd_root_one.Connection = CONN
        cmd_root_one.Parameters.Add(prmPARENT_ID)
        cmd_root_one.Parameters.Add(prmUSER_ID)

        prmPARENT_ID.Value = strRoot
        prmUSER_ID.Value = txt_userid.Text

        If CONN.State = ConnectionState.Closed Then CONN.Open()
        dr_master = cmd_root_one.ExecuteReader(CommandBehavior.CloseConnection)

        ''  Loading in another table...
        Dim dt_lf As New DataTable
        dt_lf.Load(dr_master)

        cmd_root_one.Parameters.Clear()

        If dt_lf.Rows.Count > 0 Then
            For Each dr_master As DataRow In dt_lf.Rows
                Dim trLeaf As New TreeNode(dr_master("MENU"), dr_master("URL"))
                tempLeaf = String.Format("<li><a href='{0}' title='{1}'><span>{2}</span></a></li><li class='Pipe'>|</li>", dr_master("URL"), dr_master("TOOLTIP"), dr_master("MENU"))
                menuBuilder.Append(tempLeaf)

                tempLeaf = String.Format("<li class=''><a href='{0}' title='{1}'>{2}</a><b class='arrow'></b></li>", dr_master("URL"), dr_master("TOOLTIP"), dr_master("MENU"))
                menuBuilderNew.Append(tempLeaf)

                If Session("SelectedNode") Is Nothing = False Then
                    If Session("SelectedNode") = dr_master("URL") Then
                        trLeaf.Selected = True
                    End If
                End If
                'Dim trLeaf As New TreeNode(dr_master("MENU"), "", "", dr_master("URL"), "")
                trLeaf.ToolTip = dr_master("TOOLTIP")
                trRoot.ChildNodes.Add(trLeaf)
                ' For Expand (+) and (-) in tree view -----------
                trRoot.SelectAction = TreeNodeSelectAction.Expand
            Next
            test = menuBuilder.Length
            lastAppendIndex = menuBuilder.Length - 23
            menuBuilder.Replace("<li class='Pipe'>|</li>", "", lastAppendIndex, 23)

            'menuBuilder.Replace("<li>", "<li class='last'>", lastAppendIndex, 20)
            menuBuilder.Append("</ul></li>")
            menuBuilderNew.Append("</ul></li>")
        End If

        dt_lf.Clear()

        'If dr_master.HasRows Then
        '    While dr_master.Read
        '        Dim trLeaf As New TreeNode(dr_master("MENU"), dr_master("URL"))
        '        If Session("SelectedNode") Is Nothing = False Then
        '            If Session("SelectedNode") = dr_master("URL") Then
        '                trLeaf.Selected = True
        '            End If
        '        End If
        '        'Dim trLeaf As New TreeNode(dr_master("MENU"), "", "", dr_master("URL"), "")
        '        trLeaf.ToolTip = dr_master("TOOLTIP")
        '        trRoot.ChildNodes.Add(trLeaf)
        '        ' For Expand (+) and (-) in tree view -----------
        '        trRoot.SelectAction = TreeNodeSelectAction.Expand
        '    End While
        'End If
        TreeView1.Nodes.Add(trRoot)
    End Sub


    Private Sub LeafBind(ByVal strRoot As String)
        Dim leaf As String = ""

        strCmd = ""

        strCmd = " SELECT DISTINCT P.MODULE_CODE ROOT,R.FORMID,P.FUNCTION_DESC MENU,P.FUNCTION_SCREEN URL,P.TOOLTIP TOOLTIP,P.FUNCTION_ICON FUNCTION_ICON "
        strCmd = strCmd & "  FROM   ADMIN_USER_FORM_DETAIL R, ADMIN_MAPS_FUNCTION_MASTER P "
        strCmd = strCmd & " WHERE       P.MODULE_CODE = @PARENT_ID "
        strCmd = strCmd & "         AND R.FORMID = P.FUNCTION_CODE and P.FUNCTION_CODE not in ('5')"
        strCmd = strCmd & "         AND R.USERID = @USER_ID "

        Dim cmd_leaf As New SqlCommand

        cmd_leaf.CommandText = strCmd

        cmd_leaf.Connection = CONN
        cmd_leaf.Parameters.Add(prmPARENT_ID)
        cmd_leaf.Parameters.Add(prmUSER_ID)

        prmPARENT_ID.Value = strRoot
        prmUSER_ID.Value = txt_userid.Text

        If CONN.State = ConnectionState.Closed Then CONN.Open()
        dr_master = cmd_leaf.ExecuteReader(CommandBehavior.CloseConnection)

        Dim dt As New DataTable
        dt.Load(dr_master)

        cmd_leaf.Parameters.Clear()

        If dt.Rows.Count > 0 Then
            For Each dr_master As DataRow In dt.Rows
                leaf = String.Format("<li><a href='{0}' title='{1}'><span>{2}</span></a></li>", dr_master("URL"), dr_master("TOOLTIP"), dr_master("MENU"))
                menuBuilder.Append(leaf)

                leaf = String.Format("<li class=''><a href='{0}' title='{1}'><i class='menu-icon fa " + If(Not IsDBNull(dr_master("FUNCTION_ICON")), dr_master("FUNCTION_ICON"), "fa-hand-o-right") + "'></i><span class='menu-text'>{2}</span></a><b class='arrow'></b></li>", dr_master("URL"), dr_master("TOOLTIP"), dr_master("MENU"))
                menuBuilderNew.Append(leaf)

                Dim trLeaf As New TreeNode(dr_master("MENU"), dr_master("URL"))
                'Dim trLeaf As New TreeNode(dr_master("MENU"), "", "", dr_master("URL"), "")
                If Session("SelectedNode") Is Nothing = False Then
                    If Session("SelectedNode") = dr_master("URL") Then
                        trLeaf.Selected = True
                    End If
                End If
                trLeaf.ToolTip = dr_master("TOOLTIP")
                TreeView1.Nodes.Add(trLeaf)
            Next
        End If
        dt.Clear()

        'If dr_master.HasRows Then
        '    While dr_master.Read
        '        Dim trLeaf As New TreeNode(dr_master("MENU"), dr_master("URL"))
        '        'Dim trLeaf As New TreeNode(dr_master("MENU"), "", "", dr_master("URL"), "")
        '        If Session("SelectedNode") Is Nothing = False Then
        '            If Session("SelectedNode") = dr_master("URL") Then
        '                trLeaf.Selected = True
        '            End If
        '        End If
        '        trLeaf.ToolTip = dr_master("TOOLTIP")
        '        TreeView1.Nodes.Add(trLeaf)
        '    End While
        'End If
    End Sub

    Private Sub GetUserId()
        cmd.CommandText = "SELECT USER_ID FROM ADMIN_MAPS_USER_MASTER WHERE UPPER(USER_NAME)=UPPER(@USER_NAME)"
        cmd.Connection = CONN
        cmd.Parameters.Add(prmUSER_NAME)
        prmUSER_NAME.Value = Session("UserCode")

        If CONN.State = ConnectionState.Closed Then CONN.Open()
        txt_userid.Text = cmd.ExecuteScalar
        cmd.Parameters.Clear()
    End Sub

    Protected Sub TreeView1_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TreeView1.SelectedNodeChanged
        Dim str As String = TreeView1.SelectedNode.Value
        Session("SelectedNode") = str
        Response.Redirect(TreeView1.SelectedNode.Value)
    End Sub

    Protected Sub lnkChangePassword_Click(sender As Object, e As EventArgs)
        Server.Transfer("../master/Change_Password.aspx")
    End Sub

    Protected Sub lnkProfile_Click(sender As Object, e As EventArgs)
        'Server.Transfer("../MASTER/Home.aspx")
    End Sub
End Class

