'***********************************************************************************************************************                                     
' File Name            : <USER_UNLOCKING>
' Location             : In-Solutions Global Pvt. Ltd., Malad                               
' Author               : unknown
' PADss Created        :<Tejas Pinge>, Emp. No: <C1857>
' Date of Creation     : 
' PADss Date           :<27/07/2013>
' Description          : UNLOCKING THE LOCKED USER
'***********************************************************************************************************************
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class admin_USER_UNLOCKING

    Inherits System.Web.UI.Page
    Dim conn As New SqlConnection(ConfigurationManager.AppSettings("ConnectionStringV"))
    Dim strQuery As String = "SELECT USER_NAME,ACCOUNT_STATUS LOCKED,BLOCKED,DISABLED FROM ADMIN_MAPS_USER_MASTER WHERE ACCOUNT_STATUS='LOCKED' AND DISABLED <> 'Y' "
    Dim cmd As New SqlCommand
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Dim acs As New HelperClass
    Dim dr As SqlDataReader
#Region " Web Form Designer Generated Code "
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    End Sub
    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
        ViewStateUserKey = Session.SessionID
    End Sub
#End Region
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Buffer = True
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1.0)
        Response.Expires = 0
        Response.CacheControl = "no-cache"
        'If Session("UserCode") = "" Then
        '    Response.Write("<script language=javascript>alert('Your Session Has EXPIRE/NOT LOGGED  IN Please Login Again.')</script>")
        '    Response.Redirect("MAPSlogin.aspx")
        'End If

        'Session("UserCode") = "ADMIN"

        If Session("UserCode") = "" Then
            Response.Write("<script language=javascript>alert('Your Session Has EXPIRE/NOT LOGGED  IN Please Login Again.')</script>")
            Response.Redirect(acs.mapLink(Request.Path))
        End If


        If Not Page.IsPostBack Then
            Dim strchk As String = acs.CheckSession(Session("UserCode"), System.IO.Path.GetFileName(Request.PhysicalPath))

            'strchk = "VALID"
            If strchk = "INVALID" Then
                Session("HomeFlag") = "N"
                Session("UserCode") = ""
                Response.Redirect(acs.mapLink(Request.Path))
            End If
            pop_username()
            bindDataToGrid()
        End If
        Response.Write("<script language=javascript>window.history.forward(1)</script>")
    End Sub
    'Bind the username to DropDownlist
    Private Sub pop_username()
        Dim d As New data
        Dim Strmcc As String = "select distinct user_name from ADMIN_MAPS_USER_MASTER WHERE USER_NAME <>'SUPERADMIN' AND DISABLED <> 'Y' UNION ALL select distinct ' ' user_name from ADMIN_MAPS_USER_MASTER WHERE USER_NAME <> 'SUPERADMIN' ORDER BY user_name"
        'Dim Strmcc As String = "select distinct user_name from ADMIN_MAPS_USER_MASTER WHERE USER_NAME <>'SUPERADMIN' AND ACCOUNT_STATUS='LOCKED' UNION ALL select distinct '- - Select - -' user_name from ADMIN_MAPS_USER_MASTER WHERE USER_NAME <> 'SUPERADMIN' ORDER BY user_name"

        Dim dsmcc As DataSet = d.GetData(Strmcc)
        ddlUserName.DataTextField = "user_name"
        ddlUserName.DataValueField = "user_name"
        ddlUserName.DataSource = dsmcc
        ddlUserName.DataBind()
        ddlUserName.Dispose()
    End Sub
    Private Sub bindDataToGrid()
        strQuery = strQuery & " order by USER_NAME "
        cmd.CommandText = strQuery
        cmd.Connection = conn
        If conn.State = ConnectionState.Closed Then conn.Open()
        da.SelectCommand = cmd
        da.Fill(ds)
        Datagrid2.DataSource = ds
        Dim i As Integer = Math.Ceiling(ds.Tables(0).Rows.Count / Datagrid2.PageSize) - 1
        If i < Datagrid2.CurrentPageIndex And Datagrid2.CurrentPageIndex <> 0 Then
            Datagrid2.CurrentPageIndex = Datagrid2.CurrentPageIndex - 1
        End If
        Datagrid2.DataBind()
        conn.Dispose()
    End Sub
    Private Sub lnkQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkQuery.Click
        If conn.State = ConnectionState.Closed Then conn.Open()
        Datagrid2.CurrentPageIndex = 0
        Dim cmd As New SqlCommand
        cmd.CommandText = "SELECT USER_NAME,ACCOUNT_STATUS LOCKED,BLOCKED,DISABLED FROM ADMIN_MAPS_USER_MASTER where USER_NAME=@USER_NAME"
        cmd.Connection = conn
        Dim prmUSER_NAME As New SqlParameter("@USER_NAME", SqlDbType.VarChar, 30)
        prmUSER_NAME.Value = ddlUserName.SelectedItem.Text
        cmd.Parameters.Add(prmUSER_NAME)
        dr = cmd.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(dr)
        Datagrid2.DataSource = dt
        Datagrid2.DataBind()
        conn.Close()
    End Sub
    Private Sub DataGrid2_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles Datagrid2.ItemCommand
        If e.Item.ItemType = ListItemType.Header Then
            Dim lnk As LinkButton = e.Item.FindControl("lnkSelectAll")
            Dim dgItem As DataGridItem
            'define a new check box control 
            Dim chkSelected As New System.Web.UI.WebControls.CheckBox
            If lnk.Text = "Select All" Then
                lnk.Text = "DeSelect All"
                'for each item in the grid  checkbox value is selected
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
    Private Sub DataGrid2_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        Datagrid2.CurrentPageIndex = e.NewPageIndex
        bindDataToGrid()
    End Sub

    'Updates the status of User Depending upon check box selection
    Private Sub lnkAuthNewEnrol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkAuthNewEnrol.Click
        Dim cmdUpd As New SqlCommand("update ADMIN_MAPS_USER_MASTER  SET   ACCOUNT_STATUS=@BLOCKED  ,UPDATED_BY=@UPDATED_BY,STATUS_DATE=getdate() where USER_NAME=@USER_NAME", conn)
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
                prmBLOCKED.Value = "OPEN"
                cmdUpd.ExecuteNonQuery()
                Dim A As New AdminClass
                A.INSERT_INTO_TRAIL(dgItem.Cells(1).Text.Trim, Session("UserCode"), "LOCK OPEN")
            End If
        Next
        If conn.State = ConnectionState.Open Then conn.Close()
        bindDataToGrid()
        conn.Dispose()
    End Sub
    'Go to selected page index
    Private Sub Datagrid2_PageIndexChanged1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles Datagrid2.PageIndexChanged
        Datagrid2.CurrentPageIndex = e.NewPageIndex
        bindDataToGrid()
    End Sub
    'Go to Home Page

    Private Sub ddlUserName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlUserName.SelectedIndexChanged
    End Sub
    'PROCEDURE FOR DISPLAYING ERROR PAGE IF ERROR OCCURS IDURING APPLICATION EXCUTION
    Private Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Error
        Dim PhyFilePath As String = System.AppDomain.CurrentDomain.BaseDirectory
        Dim sUser As String = Session("UserCode")
        Dim sLastError As String = Server.GetLastError.Message.ToString
        Dim sStackTrace As String = Server.GetLastError.StackTrace.ToString
        acs.WriteError(sLastError, sStackTrace, sUser, PhyFilePath, "NPCI_Loyalty-User Unlocking")
    End Sub
End Class
'***********************************************************************************************************************
'End of <USER_UNLOCKING>
'***********************************************************************************************************************