'***********************************************************************************************************************                                     
' File Name            : <User_Session_Track>
' Location             : In-Solutions Global Pvt. Ltd., Malad                               
' Author               : unknown
' PADss Created        :<Tejas Pinge>, Emp. No: <C1857>
' Date of Creation     : 
' PADss Date           :<26-Jun-13>
' Description          : USER STATUS REPORT
'***********************************************************************************************************************
Imports System.Data
Imports System.Data.SqlClient

Imports System.IO
Public Class admin_User_Session_Track
    Inherits System.Web.UI.Page
    Dim acs As New HelperClass
    Dim rpt As New Reports
    Dim filename As String
    Dim path As String = System.IO.Directory.GetDirectoryRoot(AppDomain.CurrentDomain.BaseDirectory) & "NPCI_LoyaltyReports\ADMIN\UserSessionTrack_REPORT\"
#Region " Web Form Designer Generated Code "
    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    End Sub
    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object
    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        ViewStateUserKey = Session.SessionID
        InitializeComponent()
    End Sub

#End Region
    Dim conn As New SqlConnection(ConfigurationManager.AppSettings("ConnectionStringV"))
    Dim cmd As New SqlCommand
    Dim cmd1 As New SqlCommand
    Dim da As New SqlDataAdapter
    Dim da1 As New SqlDataAdapter
    Dim ds As New DataSet
    Dim ds1 As New DataSet
    Dim strQry1 As String = " SELECT  INDEXNO SRNO, USERNAME [USER NAME], HOSTNAME [HOST IP], LOGINAT [LOGIN AT], LOGOUTAT [LOGOUT AT] FROM SESSION_TRACKING_LOG WHERE 1=1"
    Dim strQry2 As String = " SELECT  INDEXNO SRNO, USERNAME [USER NAME], HOSTNAME [HOST IP], LOGINAT [LOGIN AT], LOGOUTAT [LOGOUT AT] FROM SESSION_TRACKING_LOG WHERE 1=1"
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Session("UserCode") = "" Then
        '    Response.Write("<script language=javascript>alert('Your Session Has EXPIRE/NOT LOGGED  IN Please Login Again.')</script>")
        '    Response.Redirect(acs.mapLink(Request.Path))
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
            LoadReport(0)
        End If

        'To enable back btn
        Response.Write("<script language=javascript>window.history.forward(1)</script>")
    End Sub
    'Display list of username
    Private Sub pop_username()
        Dim d As New data
        Dim Strmcc As String = "select distinct user_name from ADMIN_MAPS_USER_MASTER WHERE USER_NAME <>'SUPERADMIN' UNION ALL select distinct ' ' user_name from ADMIN_MAPS_USER_MASTER WHERE USER_NAME <> 'SUPERADMIN' ORDER BY user_name"
        Dim dsmcc As DataSet = d.GetData(Strmcc)
        ddlUserName.DataTextField = "user_name"
        ddlUserName.DataValueField = "user_name"
        ddlUserName.DataSource = dsmcc
        ddlUserName.DataBind()
        ddlUserName.Dispose()

    End Sub
    'Populates data into datagrid and generate excel according to condition
    Private Sub LoadReport(ByVal a As Integer)
        Dim prmFromDate As New SqlParameter("FromDate", SqlDbType.DateTime)
        Dim prmToDate As New SqlParameter("ToDate", SqlDbType.DateTime)
        Dim prmTID As New SqlParameter("TID", SqlDbType.VarChar, 30)
        Dim prmMECODE As New SqlParameter("MECODE", SqlDbType.VarChar, 30)
        Dim strQry As String = ""
        Dim prmMENAME As New SqlParameter("MENAME", SqlDbType.VarChar, 100)
        Dim prmGRPNAME As New SqlParameter("GRPNAME", SqlDbType.VarChar, 100)

        Dim abp As New HelperClass
        Dim msg As String
        'If both dates are selected
        If txtFromDate.Text.Trim <> "" And txtToDate.Text.Trim <> "" Then
            msg = abp.ValidateFromDateToDate(txtFromDate.Text, txtToDate.Text)
            If msg <> "Y" Then
                Tell.text(msg, Me)
                Exit Sub
            End If
            strQry = strQry & " and LOGINAT between @fromdate and @todate "
            prmFromDate.Value = txtFromDate.Text.Trim
            prmToDate.Value = txtToDate.Text.Trim
            cmd.Parameters.Add(prmFromDate)
            cmd.Parameters.Add(prmToDate)
        ElseIf txtFromDate.Text.Trim <> "" Then
            msg = abp.ValidateDate(txtFromDate.Text, "From Date")
            If msg <> "Y" Then
                Tell.text(msg, Me)
                txtFromDate.Text = ""
                Exit Sub
            End If
            strQry = strQry & " and LOGINAT >=  @fromdate "
            prmFromDate.Value = txtFromDate.Text.Trim
            cmd.Parameters.Add(prmFromDate)
        ElseIf txtToDate.Text.Trim <> "" Then
            msg = abp.ValidateDate(txtToDate.Text, "To Date")
            If msg <> "Y" Then
                txtToDate.Text = ""
                Exit Sub
            End If

            strQry = strQry & " and LOGINAT  <= @todate "
            prmToDate.Value = txtToDate.Text.Trim
            cmd.Parameters.Add(prmToDate)
        End If

        If ddlUserName.SelectedItem.Text.Trim <> "" Then
            strQry = strQry & "  and  rtrim(ltrim(USERNAME)))=rtrim(lrim(@MENAME)) "
            prmMENAME.Value = ddlUserName.SelectedItem.Text.Trim
            cmd.Parameters.Add(prmMENAME)
        End If

        If txtHOSTIP.Text.Trim <> "" Then
            Dim prmHOSTIP As New SqlParameter("HOSTIP", SqlDbType.VarChar, 100)
            prmHOSTIP.Value = txtHOSTIP.Text.Trim
            cmd.Parameters.Add(prmHOSTIP)
            strQry = strQry & " and HOSTNAME = RTRIM(LTRIM(@HOSTIP))"
        End If
        'Establishing database connection
        If conn.State = ConnectionState.Closed Then conn.Open()
        If a = 0 Then
            cmd.CommandText = strQry1 & strQry & " order by  LOGINAT "
        Else
            cmd.CommandText = strQry2 & strQry & " order by  LOGINAT "
        End If
        'Binding data to datagrid
        cmd.Connection = conn
        da.SelectCommand = cmd
        da.Fill(ds)
        DataGrid1.DataSource = ds
        DataGrid1.DataBind()
        If a = 1 Then
            generateExcel(ds)
        End If
        If conn.State = ConnectionState.Open Then conn.Close()
    End Sub
    Private Sub lnkQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkQuery.Click
        Session("SelectedMCODE") = ""
        DataGrid1.DataBind()
        DataGrid1.CurrentPageIndex = 0
        LoadReport(0)
    End Sub
    Private Sub lnkExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadReport(1)
    End Sub
    'To genetrate excel
    Private Sub generateExcel(ByVal ds As DataSet)
        filename = "UserSessionTrack" & Format(DateTime.Now(), "MMMdd")

        If Directory.Exists(path) = False Then
            Directory.CreateDirectory(path)
        End If
        rpt.WriteToExcelNew(ds, path, filename)

        'to create zip file
        rpt.create_zip(path & "\", filename, "*.xls")

        'to write LOG
        acs.writeLogDB(Session("UserCode"), System.IO.Path.GetFileName(Request.Path).ToString, filename + ".xls")

        'To delete file from the path
        rpt.deletedumpxl(path, "*.xls")

        'TO download file
        Dim flname As New System.IO.FileInfo(path + filename & ".zip")
        Response.Clear()
        Response.AppendHeader("content-disposition", "attachment; filename=" + filename & ".zip")
        Response.WriteFile(flname.FullName)
        Response.End()
    End Sub
    'Selecting 'from date' from calender
    Private Sub lnkFromDate_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles lnkFromDate.Click
        Response.Write("<script language=javascript>window.open('popup.aspx?textbox=txtFromDate','cal','width=370,height=240,left=270,top=180')</script>")
    End Sub
    'Selecting 'to date' from calender
    Private Sub lnkToDate_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles lnkToDate.Click
        Response.Write("<script language=javascript>window.open('popup.aspx?textbox=txtToDate','cal','width=370,height=240,left=270,top=180')</script>")
    End Sub
    'To go to selected page in datagrid
    Private Sub DataGrid1_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid1.PageIndexChanged
        DataGrid1.CurrentPageIndex = e.NewPageIndex
        LoadReport(0)
    End Sub
    'To generate Excel
    Private Sub lnkExportToExcelME_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkExportToExcelME.Click
        LoadReport(1)
    End Sub
    Private Sub Datagrid2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    'To go to home page

    'PROCEDURE FOR DISPLAYING ERROR PAGE IF ERROR OCCURS IDURING APPLICATION EXCUTION
    Private Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Error
        Dim PhyFilePath As String = System.AppDomain.CurrentDomain.BaseDirectory
        Dim sUser As String = Session("UserCode")
        Dim sLastError As String = Server.GetLastError.Message.ToString
        Dim sStackTrace As String = Server.GetLastError.StackTrace.ToString
        acs.WriteError(sLastError, sStackTrace, sUser, PhyFilePath, "NPCI_Loyalty-User Session")
    End Sub
End Class
'***********************************************************************************************************************
'End of <User_Session_Track>
'***********************************************************************************************************************