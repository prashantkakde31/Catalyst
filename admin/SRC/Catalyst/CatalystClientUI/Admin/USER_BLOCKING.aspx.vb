Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Web.UI.WebControls

Public Class USER_BLOCKING
    Inherits System.Web.UI.Page
    Dim conn As New SqlConnection(ConfigurationManager.AppSettings("ConnectionStringPORTAL"))
    Dim strQuery As String = "SELECT USER_NAME,ACCOUNT_STATUS LOCKED,BLOCKED,DISABLED FROM ADMIN_MAPS_USER_MASTER WHERE 1=1 "
    Dim cmd As New SqlCommand
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Dim objABProCommonClass As New HelperClass

    Protected WithEvents lnkLogout As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkHome As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents MainLabel As System.Web.UI.WebControls.Label
    Protected WithEvents Btn_Logout As System.Web.UI.WebControls.Button

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region
    'load page and bind datagrid & bind ddlUserName dropdown

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Session("UserCode") = "ADMIN"

        Response.Buffer = True
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1.0)
        Response.Expires = 0
        Response.CacheControl = "no-cache"

        If Session("UserCode") = "" Then
            Response.Write("<script language=javascript>alert('Your Session Has EXPIRE/NOT LOGGED  IN Please Login Again.')</script>")
            Response.Redirect("../Master/index.aspx")
        End If

        If Not Page.IsPostBack Then
            '   To Check User Rights
            Dim strchk As String = objABProCommonClass.CheckSession(Session("UserCode"), System.IO.Path.GetFileName(Request.PhysicalPath))
            If strchk = "INVALID" Then
                Session("HomeFlag") = "N"
                Session("UserCode") = ""
                Response.Redirect("../Master/index.aspx")
            End If

            objABProCommonClass.loaddropdown(ddlUserName, "select distinct user_name from ADMIN_MAPS_USER_MASTER WHERE USER_NAME <>'ADMIN' AND DISABLED <> 'Y' UNION ALL select distinct '- - Select - -' user_name from ADMIN_MAPS_USER_MASTER WHERE USER_NAME <> 'ADMIN' ORDER BY user_name", conn, "user_name", "user_name")
            bindDataToGrid()
        End If

        'To enable back btn
        Response.Write("<script language=javascript>window.history.forward(1)</script>")
    End Sub

    'bind data to datagrid
    Private Sub bindDataToGrid()

        Dim prmSelectUser As New SqlParameter("SelectUser", SqlDbType.VarChar, 50)
        Dim prmDisabled As New SqlParameter("Disabled", SqlDbType.VarChar, 1)

        If ddlUserName.SelectedItem.Text.Trim <> "- - Select - -" Then
            strQuery = strQuery & "  and  RTRIM(LTRIM(USER_NAME))=RTRIM(LTRIM(@SelectUser)) "
            prmSelectUser.Value = ddlUserName.SelectedItem.Text.Trim
            cmd.Parameters.Add(prmSelectUser)
        End If

        Dim prmUSERNAME As New SqlParameter("@USERNAME", SqlDbType.VarChar, 50)

        prmUSERNAME.Value = "ADMIN"
        prmDisabled.Value = "Y"
        cmd.Parameters.Add(prmUSERNAME)
        cmd.Parameters.Add(prmDisabled)

        strQuery = strQuery & " AND USER_NAME <>RTRIM(LTRIM(@USERNAME)) AND DISABLED <> @Disabled order by USER_NAME  "
        cmd.CommandText = strQuery
        cmd.Connection = conn
        conn.Open()
        da.SelectCommand = cmd
        da.Fill(ds)

        Datagrid2.DataSource = ds
        Datagrid2.DataBind()
        conn.Close()
    End Sub
    'fill the the datagrid with records
    Private Sub lnkQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkQuery.Click
        Datagrid2.CurrentPageIndex = 0
        bindDataToGrid()
    End Sub
    'this is use to select all records or unselect all records
    Private Sub DataGrid2_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
        If e.Item.ItemType = ListItemType.Header Then
            Dim lnk As LinkButton = e.Item.FindControl("lnkSelectAll")
            Dim dgItem As DataGridItem
            Dim chkSelected As New System.Web.UI.WebControls.CheckBox
            If lnk.Text = "Select All" Then
                lnk.Text = "DeSelect All"
                For Each dgItem In Datagrid2.Items
                    chkSelected = dgItem.FindControl("checkbox1")
                    chkSelected.Checked = True
                Next
            Else
                lnk.Text = "Select All"
                For Each dgItem In Datagrid2.Items
                    chkSelected = dgItem.FindControl("checkbox1")
                    chkSelected.Checked = False
                Next
            End If
        End If
    End Sub
    'this is use to set pagination paroperty to datagrid
    Private Sub DataGrid2_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        Datagrid2.CurrentPageIndex = e.NewPageIndex
        bindDataToGrid()
    End Sub
    'this is use to redirect page to link1(home page)
    Private Sub lnkHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkHome.Click
        Session("HomeFlag") = "Y"
        Response.Redirect(objABProCommonClass.mapLink(Request.Path))
    End Sub
    'this is use ot clear & kill session & redirect to link1(home page)
    Private Sub lnkLogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkLogout.Click
        Session.Abandon()
        Session.Clear()
        Response.Redirect(objABProCommonClass.mapLink(Request.Path))
    End Sub
    ' get from date  from calendar
    Private Sub lnkFromDate_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Response.Write("<script language=javascript>window.open('popup.aspx?textbox=txtFromDate','cal','width=180,height=180,left=270,top=180')</script>")
    End Sub
    ' get to date from calenadar
    Private Sub lnkToDate_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Response.Write("<script language=javascript>window.open('popup.aspx?textbox=txtToDate','cal','width=180,height=180,left=180,top=180')</script>")
    End Sub
    'this is use to update data in ADMIN_MAPS_USER_MASTER table
    Private Sub lnkAuthNewEnrol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkAuthNewEnrol.Click
        Dim cmdUpd As New SqlCommand("update ADMIN_MAPS_USER_MASTER  SET   blocked=@BLOCKED,  UPDATED_BY=@UPDATED_BY,STATUS_DATE=GETDATE() where USER_NAME=@USER_NAME", conn)
        Dim prmUSER_NAME As New SqlParameter("@USER_NAME", SqlDbType.VarChar, 20)
        Dim prmBLOCKED As New SqlParameter("@BLOCKED", SqlDbType.VarChar, 20)
        Dim prmUPDATED_BY As New SqlParameter("@UPDATED_BY", SqlDbType.VarChar, 30)
        cmdUpd.Parameters.Add(prmUPDATED_BY)
        cmdUpd.Parameters.Add(prmUSER_NAME)
        cmdUpd.Parameters.Add(prmBLOCKED)

        Dim dgItem As DataGridItem
        Dim chkSelected As New System.Web.UI.WebControls.CheckBox

        Dim str As String = ""
        If conn.State = ConnectionState.Closed Then conn.Open()
        For Each dgItem In Datagrid2.Items
            chkSelected = dgItem.FindControl("checkbox1")
            prmUSER_NAME.Value = dgItem.Cells(1).Text.Trim
            prmUPDATED_BY.Value = Session("UserCode") + ""
            If chkSelected.Checked = True Then
                If dgItem.Cells(3).Text.Trim = "N" Then
                    prmBLOCKED.Value = "Y"
                ElseIf dgItem.Cells(3).Text.Trim = "Y" Then
                    prmBLOCKED.Value = "N"
                End If
            Else
                prmBLOCKED.Value = dgItem.Cells(3).Text.Trim
            End If
            cmdUpd.ExecuteNonQuery()
            ' INSERT TRAIN
            Dim A As New AdminClass
            If dgItem.Cells(3).Text.Trim = "N" Then
                A.INSERT_INTO_TRAIL(dgItem.Cells(1).Text.Trim, Session("UserCode"), "UNBLOCK")
            ElseIf dgItem.Cells(3).Text.Trim = "Y" Then
                A.INSERT_INTO_TRAIL(dgItem.Cells(1).Text.Trim, Session("UserCode"), "BLOCK")
            End If
        Next
        If conn.State = ConnectionState.Open Then conn.Close()
        bindDataToGrid()
        conn.Dispose()
    End Sub
    'this is use to set pagination property to datagrid2
    Private Sub Datagrid2_PageIndexChanged1(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        Datagrid2.CurrentPageIndex = e.NewPageIndex
        bindDataToGrid()
    End Sub
    'this is use to redirect to home page (link1)
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Session("HomeFlag") = "Y"
        Response.Redirect(objABProCommonClass.mapLink(Request.Path))
    End Sub
    'this is use to clear & kill session and redirect to home page (link1)
    Private Sub Btn_Logout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Logout.Click
        Dim a As New AdminClass
        a.UpateSessionInfo(Session("INDEXNO"))
        Session.Abandon()
        Session.Clear()
        'Response.Redirect("../ADMIN/links1.aspx")
        Response.Redirect(objABProCommonClass.mapLink(Request.Path))
    End Sub
    'this is use to set pagination property to datagrid2
    Private Sub Datagrid2_PageIndexChanged2(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles Datagrid2.PageIndexChanged
        Datagrid2.CurrentPageIndex = e.NewPageIndex
        bindDataToGrid()
    End Sub
    '/*this is use to when error comes then display error page */'

    Private Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Error
        Dim PhyFilePath As String = System.AppDomain.CurrentDomain.BaseDirectory
        Dim sUser As String = Session("UserCode")
        Dim sLastError As String = Server.GetLastError.Message.ToString
        Dim sStackTrace As String = Server.GetLastError.StackTrace.ToString
        objABProCommonClass.WriteError(sLastError, "", sUser, PhyFilePath, "NPCI_Loyalty User Blocking")
    End Sub
End Class
