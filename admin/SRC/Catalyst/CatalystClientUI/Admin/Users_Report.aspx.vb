'***********************************************************************************************************************                                     
' File Name            : <Users_Report>
' Location             : In-Solutions Global Pvt. Ltd., Malad                               
' Author               : unknown
' PADss Created        :<Tejas Pinge>, Emp. No: <C1857>
' Date of Creation     : 
' PADss Date           :<28-Jun-13>
' Description          : GENERATES USER REPORTS 
'***********************************************************************************************************************
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Public Class Users_Report
    Inherits System.Web.UI.Page
    Dim conn As New System.Data.SqlClient.SqlConnection(ConfigurationManager.AppSettings("ConnectionStringV"))
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

    Dim cmd As New SqlCommand
    Dim cmd1 As New SqlCommand
    Dim da As New SqlDataAdapter
    Dim da1 As New SqlDataAdapter
    Dim ds As New DataSet
    Dim ds1 As New DataSet
    Dim acs As New HelperClass
    Dim rpt As New Reports
    Dim filename As String
    Dim path As String = System.IO.Directory.GetDirectoryRoot(AppDomain.CurrentDomain.BaseDirectory) & "NPCI_LoyaltyReports\ADMIN\ADMIN_Report\"

    Dim strQry1 As String = " SELECT  USER_ID [USER ID], USER_NAME [USER NAME], ACCOUNT_STATUS [ACCOUNT STATUS], REGION_NAME [REGION NAME], GROUP_ID [GROUP ID], BLOCKED, DISABLED, ENROL_DATE [ENROLDATE], PASSWORD_DATE [PASSWORDDATE], ADDED_BY [ADDED BY], UPDATED_BY [UPDATED BY], VALID_FROM [VALID FROM], VALID_UPTO [VALID UPTO] FROM ADMIN_MAPS_USER_MASTER WHERE 1=1 "
    Dim strQry2 As String = " SELECT  USER_ID [USER ID], USER_NAME [USER NAME], ACCOUNT_STATUS [ACCOUNT STATUS], REGION_NAME [REGION NAME], GROUP_ID [GROUP ID], BLOCKED, DISABLED, ENROL_DATE [ENROLDATE], PASSWORD_DATE [PASSWORDDATE], ADDED_BY [ADDED BY], UPDATED_BY [UPDATED BY], VALID_FROM [VALID FROM], VALID_UPTO [VALID UPTO] FROM ADMIN_MAPS_USER_MASTER WHERE 1=1 "
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'If Session("UserCode") = "" Then
        '    Response.Write("<script language=javascript>alert('Your Session Has EXPIRE/NOT LOGGED  IN Please Login Again.')</script>")
        '    Response.Redirect(acs.mapLink(Request.Path))
        'End If


        If Session("UserCode") = "" Then
            Response.Write("<script language=javascript>alert('Your Session Has EXPIRE/NOT LOGGED  IN Please Login Again.')</script>")
            Response.Redirect(acs.mapLink(Request.Path))
        End If


        If Not Page.IsPostBack Then
            Dim strchk As String = acs.CheckSession(Session("UserCode"), System.IO.Path.GetFileName(Request.PhysicalPath))
            If strchk = "INVALID" Then
                Session("HomeFlag") = "N"
                Session("UserCode") = ""
                Response.Redirect(acs.mapLink(Request.Path))
            End If

            Session("EDITFLAG") = "FALSE"

            pop_username()
            pop_GroupName()
        End If

        'To enable back btn
        Response.Write("<script language=javascript>window.history.forward(1)</script>")
    End Sub
    'Binds the list of users to dropdownlist
    Private Sub pop_username()
        Dim d As New data
        Dim Strmcc As String = "select distinct user_name from ADMIN_MAPS_USER_MASTER WHERE USER_NAME <> 'SUPERADMIN' UNION ALL select distinct ' ' user_name from ADMIN_MAPS_USER_MASTER WHERE USER_NAME <> 'SUPERADMIN' ORDER BY user_name   "
        Dim dsmcc As DataSet = d.GetData(Strmcc)
        ddlUserName.DataTextField = "user_name"
        ddlUserName.DataValueField = "user_name"
        ddlUserName.DataSource = dsmcc
        ddlUserName.DataBind()
        ddlUserName.Dispose()
    End Sub
    'Binds the list of Groups to dropdownlist
    Private Sub pop_GroupName()
        Dim d As New data
        Dim Strmcc As String = "select distinct GROUP_ID Group_Name from ADMIN_MAPS_USER_MASTER UNION select distinct ''  GROUP_NAME from ADMIN_MAPS_USER_MASTER ORDER BY Group_Name DESC "
        Dim dsmcc As DataSet = d.GetData(Strmcc)

        ddlGroup.DataTextField = "Group_Name"
        ddlGroup.DataValueField = "Group_Name"
        ddlGroup.DataSource = dsmcc
        ddlGroup.DataBind()
        ddlGroup.Dispose()
    End Sub
    Private Sub MySetFocus(ByVal ctrl As Control)
        'set focus control
        Dim str As String = "<script language=javascript>document.getElementById('" & ctrl.ClientID & "').focus()</script>"
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MySetFocus", str)
    End Sub
    Private Sub UpdateCorps(ByVal ARN As String)
        Dim cmdUpdateBranch As New SqlCommand
        Dim strUpdateBranch As String = "update tmpmerchant set (ME_CORREF, ME_CORNAM, ME_PAYMENT) = (select corref,corpname,payment from STBLCORPNAME where corpcode= 	(select ME_CORCOD from tmpmerchant where app_req_no=:ARN)) where app_req_no=:ARN  "
        Dim prmARN As New SqlParameter("ARN", SqlDbType.VarChar)
        cmdUpdateBranch.Parameters.Add(prmARN)
        prmARN.Value = ARN
        cmdUpdateBranch.CommandText = strUpdateBranch
        Dim d As New data
        d.ExQuery(cmdUpdateBranch)
    End Sub
    'Bind data to datagrid
    Private Sub BINDGRID()
        Dim CD As New SqlDataAdapter("SELECT USER_ID,  USER_NAME,  ACCOUNT_STATUS, REGION_NAME, GROUP_ID, BLOCKED, DISABLED, BRANCH, DEPARTMENT, ENROL_DATE, PASSWORD_DATE, ADDED_BY, UPDATED_BY,VALID_FROM, VALID_UPTO from ADMIN_MAPS_USER_MASTER ", conn)
        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim DS As New DataSet
        CD.Fill(DS)
        DataGrid1.DataSource = DS
        DataGrid1.DataBind()
    End Sub
    'Select 'from_date ' from calender
    '    Private Sub lnkFromDate_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles lnkFromDate.Click
    '        Response.Write("<script language=javascript>window.open('popup.aspx?textbox=txtFromDate','cal','width=370,height=240,left=270,top=180')</script>")
    '    End Sub
    ''Select 'to_date ' from calender
    '    Private Sub lnkToDate_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles lnkToDate.Click
    '        Response.Write("<script language=javascript>window.open('popup.aspx?textbox=txtToDate','cal','width=370,height=240,left=270,top=180')</script>")
    '    End Sub

    'To display data in datgrid
    Private Sub lnkBtnVwDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkBtnVwDet.Click
        Session("SelectedMCODE") = ""
        DataGrid1.DataBind()
        DataGrid1.CurrentPageIndex = 0
        LoadReport(0)
    End Sub
    'Populates data into datagrid and generate excel according to condition
    Private Sub LoadReport(ByVal a As Integer)
        Dim prmFromDate As New SqlParameter("FromDate", SqlDbType.DateTime)
        Dim prmToDate As New SqlParameter("ToDate", SqlDbType.DateTime)
        Dim prmTID As New SqlParameter("TID", SqlDbType.VarChar)
        Dim prmMECODE As New SqlParameter("MECODE", SqlDbType.VarChar)
        Dim strQry As String = ""
        Dim prmMENAME As New SqlParameter("MENAME", SqlDbType.VarChar)
        Dim prmGRPNAME As New SqlParameter("GRPNAME", SqlDbType.VarChar)
        Dim abp As New HelperClass
        Dim msg As String
        If txtFromDate.Text.Trim <> "" And txtToDate.Text.Trim <> "" Then
            msg = abp.ValidateFromDateToDate(txtFromDate.Text, txtToDate.Text)
            If msg <> "Y" Then
                Tell.text(msg, Me)
                Exit Sub
            End If
            strQry = strQry & " and ENROL_DATE between @fromdate and @todate "
            prmFromDate.Value = txtFromDate.Text.Trim
            prmToDate.Value = txtToDate.Text.Trim
            cmd.Parameters.Add(prmFromDate)
            cmd.Parameters.Add(prmToDate)
        ElseIf txtFromDate.Text.Trim <> "" Then
            msg = abp.ValidateDate(txtFromDate.Text, "From Date")
            If msg <> "Y" Then
                Tell.text(msg, Me)
                txtFromDate.Text = ""
                MySetFocus(txtFromDate)
                Exit Sub
            End If
            strQry = strQry & " and ENROL_DATE) >=  @fromdate "
            prmFromDate.Value = txtFromDate.Text.Trim
            cmd.Parameters.Add(prmFromDate)
        ElseIf txtToDate.Text.Trim <> "" Then
            msg = abp.ValidateDate(txtToDate.Text, "To Date")
            If msg <> "Y" Then
                Tell.text(msg, Me)
                txtToDate.Text = ""
                MySetFocus(txtToDate)
                Exit Sub
            End If
            strQry = strQry & " and ENROL_DATE  <= @todate "
            prmToDate.Value = txtToDate.Text.Trim
            cmd.Parameters.Add(prmToDate)
        End If
        If ddlUserName.SelectedItem.Text.Trim <> "" Then
            strQry = strQry & "  and  rtrim(ltrim(USER_NAME))=rtrim(ltrim(@MENAME)) "
            prmMENAME.Value = ddlUserName.SelectedItem.Text.Trim
            cmd.Parameters.Add(prmMENAME)
        End If

        If ddlGroup.SelectedItem.Text.Trim <> "" Then
            strQry = strQry & "  and  rtrim(ltrim(GROUP_ID))=rtrim(ltrim(@GRPNAME)) "
            prmGRPNAME.Value = ddlGroup.SelectedItem.Text.Trim
            cmd.Parameters.Add(prmGRPNAME)
        End If

        If conn.State = ConnectionState.Closed Then conn.Open()
        If a = 0 Then
            cmd.CommandText = strQry1 & strQry & " order by  ENROL_DATE "
        Else
            cmd.CommandText = strQry2 & strQry & " order by  ENROL_DATE "
        End If
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
    'To download generated excel
    Private Sub lnkExportToExcelME_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkExportToExcelME.Click
        LoadReport(1)
    End Sub
    'Generates Excel
    Private Sub generateExcel(ByVal ds As DataSet)
        filename = "ADMIN" & Format(DateTime.Now(), "MMMdd")

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
    'Go to Home page
   
    Private Sub DataGrid1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.SelectedIndexChanged
    End Sub
    'Go to selected page of datagrid
    Private Sub DataGrid1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid1.PageIndexChanged
        DataGrid1.CurrentPageIndex = e.NewPageIndex
        LoadReport(0)
    End Sub
    'PROCEDURE FOR DISPLAYING ERROR PAGE IF ERROR OCCURS IDURING APPLICATION EXCUTION 
    Private Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Error
        Dim PhyFilePath As String = System.AppDomain.CurrentDomain.BaseDirectory
        Dim sUser As String = Session("UserCode")
        Dim sLastError As String = Server.GetLastError.Message.ToString
        Dim sStackTrace As String = Server.GetLastError.StackTrace.ToString
        acs.WriteError(sLastError, sStackTrace, sUser, PhyFilePath, "Catalyst.-User Report")
    End Sub
End Class

'***********************************************************************************************************************
'End of <Users_Report>
'***********************************************************************************************************************