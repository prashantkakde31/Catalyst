
'***********************************************************************************************************************                                     
' File Name            : <USER_DISABLING>
' Location             : In-Solutions Global Pvt. Ltd., Malad                               
' Author               : <Poonam Warke>, Emp. No: <C871>                          
' Date of Creation     : <23/01/2010>
' Description          : 
'***********************************************************************************************************************
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class admin_USER_DISABLING
    Inherits System.Web.UI.Page
    Dim conn As New SqlConnection(ConfigurationManager.AppSettings("ConnectionStringV"))
    Dim strQuery As String = "SELECT USER_NAME,ACCOUNT_STATUS LOCKED,BLOCKED,DISABLED,UPDATED_BY FROM ADMIN_MAPS_USER_MASTER WHERE DISABLED = 'N'  "
    Dim cmd As New SqlCommand
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Dim HelperClass As New HelperClass
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
    'load page add records in dropdown and bind data in datagrid 
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Session("UserCode") = "" Then
        '    Response.Write("<script language=javascript>alert('Your Session Has EXPIRE/NOT LOGGED  IN Please Login Again.')</script>")
        '    Response.Redirect(HelperClass.mapLink(Request.Path))
        'End If


        'Session("UserCode") = "ADMIN"

        If Session("UserCode") = "" Then
            Response.Write("<script language=javascript>alert('Your Session Has EXPIRE/NOT LOGGED  IN Please Login Again.')</script>")
            Response.Redirect(acs.mapLink(Request.Path))
        End If



        If Not Page.IsPostBack Then
            Dim strchk As String = HelperClass.CheckSession(Session("UserCode"), System.IO.Path.GetFileName(Request.PhysicalPath))
            If strchk = "INVALID" Then
                Session("HomeFlag") = "N"
                Session("UserCode") = ""
                Response.Redirect(HelperClass.mapLink(Request.Path))
            End If
            HelperClass.loaddropdown(ddlUserName, "select distinct user_name from ADMIN_MAPS_USER_MASTER WHERE USER_NAME <>'SUPERADMIN' AND DISABLED <> 'Y' UNION ALL select distinct ' ' user_name from ADMIN_MAPS_USER_MASTER WHERE USER_NAME <> 'SUPERADMIN' ORDER BY user_name", conn, "user_name", "user_name")
            bindDataToGrid()
        End If

        'To enable back btn
        Response.Write("<script language=javascript>window.history.forward(1)</script>")
    End Sub
    'bind data to datagrid
    Private Sub bindDataToGrid()
        Dim prmSelectUser As New SqlParameter("@SelectUser", SqlDbType.VarChar, 50)
        If ddlUserName.SelectedItem.Text.Trim <> "" Then
            strQuery = strQuery & "  and  RTRIM(LTRIM(USER_NAME))=RTRIM(LTRIM(@SelectUser)) "
            prmSelectUser.Value = ddlUserName.SelectedItem.Text.Trim
            cmd.Parameters.Add(prmSelectUser)
        End If

        strQuery = strQuery & " AND USER_NAME <> 'SUPERADMIN' AND DISABLED <> 'Y' order by USER_NAME  "
        'build the data set
        cmd.CommandText = strQuery
        cmd.Connection = conn
        If conn.State = ConnectionState.Closed Then conn.Open()
        da.SelectCommand = cmd
        da.Fill(ds)
        'fill the grid
        Datagrid2.DataSource = ds
        Datagrid2.DataBind()
        conn.Dispose()
    End Sub
    'refill the the datagrid
    Private Sub lnkQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkQuery.Click
        Datagrid2.CurrentPageIndex = 0
        bindDataToGrid()
    End Sub
    'if cilck on the header  and if the selected contril is the select all link button 
    Private Sub DataGrid2_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles Datagrid2.ItemCommand
        'command on the datagrid
        'if select item is is header
        If e.Item.ItemType = ListItemType.Header Then
            'define  a link button control as =  in the grid item find a control as lnkselectall
            Dim lnk As LinkButton = e.Item.FindControl("lnkSelectAll")
            Dim dgItem As DataGridItem
            ' define a new check box control 
            Dim chkSelected As New System.Web.UI.WebControls.CheckBox
            ' if text of the given link button   'select all' is clicked make  it deselect all
            If lnk.Text = "Select All" Then
                lnk.Text = "DeSelect All"
                'for each item in the grid  checkbox value is selected
                For Each dgItem In Datagrid2.Items
                    chkSelected = dgItem.FindControl("checkbox1")
                    chkSelected.Checked = True
                Next
            Else
                'else de select check boxes
                lnk.Text = "Select All"
                For Each dgItem In Datagrid2.Items
                    chkSelected = dgItem.FindControl("checkbox1")
                    chkSelected.Checked = False
                Next
            End If
        End If
    End Sub
    'this is use to set NewPageIndex and bind datagrid
    Private Sub DataGrid2_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        'refersh the grid 
        Datagrid2.CurrentPageIndex = e.NewPageIndex
        bindDataToGrid()
    End Sub

    'this is use to update block or unblock in the ADMIN_MAPS_USER_MASTER table
    Private Sub lnkAuthNewEnrol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkAuthNewEnrol.Click
        Dim cmdUpd As New SqlCommand("update ADMIN_MAPS_USER_MASTER  SET   DISABLED=@BLOCKED ,  UPDATED_BY=@UPDATED_BY  ,STATUS_DATE=getdate() where UPPER(USER_NAME)=UPPER(@USER_NAME)", conn)
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
                    cmdUpd.ExecuteNonQuery()
                    Dim A As New AdminClass
                    A.INSERT_INTO_TRAIL(dgItem.Cells(1).Text.Trim, Session("UserCode"), "DISABLE")
                End If
            End If
        Next
        If conn.State = ConnectionState.Open Then conn.Close()
        bindDataToGrid()
        conn.Dispose()
    End Sub
    'this is use to set pageindex of datagrid2
    Private Sub Datagrid2_PageIndexChanged1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles Datagrid2.PageIndexChanged
        Datagrid2.CurrentPageIndex = e.NewPageIndex
        bindDataToGrid()
    End Sub
    'this is use to display home page 

    'this is use to display error page if error comes
    Private Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Error
        Dim PhyFilePath As String = System.AppDomain.CurrentDomain.BaseDirectory
        Dim sUser As String = Session("UserCode")
        Dim sLastError As String = Server.GetLastError.Message.ToString
        Dim sStackTrace As String = Server.GetLastError.StackTrace.ToString
        HelperClass.WriteError(sLastError, sStackTrace, sUser, PhyFilePath, "Catalyst. user Disabling")
    End Sub
End Class
'***********************************************************************************************************************
'End of <USER_DISABLING>
'***********************************************************************************************************************