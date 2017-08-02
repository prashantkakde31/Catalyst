'***********************************************************************************************************************                                     
' File Name            : <User_Status_report>
' Location             : In-Solutions Global Pvt. Ltd., Malad                               
' Author               : unknown
' PADss Created        :<Tejas Pinge>, Emp. No: <C1857>
' Date of Creation     : 
' PADss Date           :<27-Jun-13>
' Description          : USER STATUS REPORT
'***********************************************************************************************************************
Imports System.Data
Imports System.IO
Imports System.Data.SqlClient
Public Class admin_User_Status_report
    Inherits System.Web.UI.Page
    Dim acs As New HelperClass
    Dim rpt As New Reports
    Dim filename As String
    Dim path As String = System.IO.Directory.GetDirectoryRoot(AppDomain.CurrentDomain.BaseDirectory) & "NPCI_LoyaltyReports\ADMIN\UserStatusReport\"
#Region " Web Form Designer Generated Code "
    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    End Sub
    Private designerPlaceholderDeclaration As System.Object
    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        InitializeComponent()
        ViewStateUserKey = Session.SessionID
    End Sub
#End Region
    Dim conn As New SqlConnection(ConfigurationManager.AppSettings("ConnectionStringV"))
    Dim cmd As New SqlCommand
    Dim cmd1 As New SqlCommand
    Dim da As New SqlDataAdapter
    Dim da1 As New SqlDataAdapter
    Dim ds As New DataSet
    Dim ds1 As New DataSet
    Dim strQry1 As String = " SELECT  USER_ID [USERID], USER_NAME [USER NAME], ACCOUNT_STATUS [ACCOUNT STATUS], REGION_NAME [REGION NAME], BLOCKED, DISABLED, ENROL_DATE [ENROLDATE], PASSWORD_DATE [PASSWORDDATE], ADDED_BY [ADDED BY], UPDATED_BY [UPDATED BY], VALID_FROM [VALID FROM], VALID_UPTO [VALID UPTO] FROM ADMIN_MAPS_USER_MASTER WHERE 1=1 "
    Dim strQry2 As String = " SELECT  USER_ID [USERID], USER_NAME [USER NAME], ACCOUNT_STATUS [ACCOUNT STATUS], REGION_NAME [REGION NAME], BLOCKED, DISABLED, ENROL_DATE [ENROLDATE], PASSWORD_DATE [PASSWORDDATE], ADDED_BY [ADDED BY], UPDATED_BY [UPDATED BY], VALID_FROM [VALID FROM], VALID_UPTO [VALID UPTO] FROM ADMIN_MAPS_USER_MASTER WHERE 1=1 "
    Dim abp As New HelperClass
    Dim msg As String
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
            If strchk = "INVALID" Then
                Session("HomeFlag") = "N"
                Session("UserCode") = ""
                Response.Redirect(acs.mapLink(Request.Path))
            End If
            pop_username()
            pop_Group()
        End If
        If Not Page.IsPostBack Then
            LoadReport(0)
        End If
        'To enable back btn
        Response.Write("<script language=javascript>window.history.forward(1)</script>")
    End Sub
    'Bind the list of username to Dropdownlist
    Private Sub pop_username()
        Dim d As New data
        Dim Strmcc As String = "select distinct user_name from ADMIN_MAPS_USER_MASTER WHERE USER_NAME <>'SUPERADMIN' UNION ALL select distinct ' ' user_name from ADMIN_MAPS_USER_MASTER WHERE USER_NAME <>'SUPERADMIN' ORDER BY user_name"
        Dim dsmcc As DataSet = d.GetData(Strmcc)
        ddlUserName.DataTextField = "user_name"
        ddlUserName.DataValueField = "user_name"
        ddlUserName.DataSource = dsmcc
        ddlUserName.DataBind()
        ddlUserName.Dispose()
    End Sub
    'Bind the List of Groups to dropdownlist
    Private Sub pop_Group()
        Dim d As New data
        Dim Strmcc As String = "select distinct GROUP_ID Group_Name from ADMIN_MAPS_USER_MASTER UNION select distinct ''  GROUP_NAME from ADMIN_MAPS_USER_MASTER ORDER BY Group_Name DESC "
        Dim dsmcc As DataSet = d.GetData(Strmcc)
        ddlGroup.DataTextField = "Group_Name"
        ddlGroup.DataValueField = "Group_Name"
        ddlGroup.DataSource = dsmcc
        ddlGroup.DataBind()
        ddlGroup.Dispose()
    End Sub
    'Populates data into datagrid and generate excel according to condition
    Private Sub LoadReport(ByVal a As Integer)
        Dim prmFromDate As New SqlParameter("@FromDate", SqlDbType.DateTime)
        Dim prmToDate As New SqlParameter("@ToDate", SqlDbType.DateTime)
        Dim prmTID As New SqlParameter("@TID", SqlDbType.VarChar, 30)
        Dim prmMECODE As New SqlParameter("@MECODE", SqlDbType.VarChar, 50)
        Dim strQry As String = ""
        Dim prmMENAME As New SqlParameter("@MENAME", SqlDbType.VarChar, 100)
        Dim prmGRPNAME As New SqlParameter("@GRPNAME", SqlDbType.VarChar, 100)

        'If both dates are entered
        If txtFromDate.Text.Trim <> "" And txtToDate.Text.Trim <> "" Then
            msg = abp.ValidateFromDateToDate(txtFromDate.Text, txtToDate.Text)
            If msg <> "Y" Then
                Tell.text(msg, Me)
                Exit Sub
            End If
            strQry = strQry & " and cast(ENROL_DATE as date) between @fromdate and @todate "
            prmFromDate.Value = txtFromDate.Text.Trim
            prmToDate.Value = txtToDate.Text.Trim
            cmd.Parameters.Add(prmFromDate)
            cmd.Parameters.Add(prmToDate)

            'If only From date is entered
        ElseIf txtFromDate.Text.Trim <> "" Then
            msg = abp.ValidateDate(txtFromDate.Text, "From Date")
            If msg <> "Y" Then
                Tell.text(msg, Me)
                txtFromDate.Text = ""
                Exit Sub
            End If
            strQry = strQry & " and cast(ENROL_DATE as Date) >=  @fromdate "
            prmFromDate.Value = txtFromDate.Text.Trim
            cmd.Parameters.Add(prmFromDate)

            'If only To date is entered
        ElseIf txtToDate.Text.Trim <> "" Then
            msg = abp.ValidateDate(txtToDate.Text, "To Date")
            If msg <> "Y" Then
                Tell.text(msg, Me)
                txtToDate.Text = ""
                Exit Sub
            End If
            strQry = strQry & " and cast(ENROL_DATE as date)  <= @todate "
            prmToDate.Value = txtToDate.Text.Trim
            cmd.Parameters.Add(prmToDate)
        End If
        If ddlUserName.SelectedItem.Text.Trim <> "" Then
            strQry = strQry & "  and  RTRIM(LTRIM(USER_NAME))=RTRIM(LTRIM(@MENAME)) "
            prmMENAME.Value = ddlUserName.SelectedItem.Text.Trim
            cmd.Parameters.Add(prmMENAME)
        End If

        If ddlGroup.SelectedItem.Text.Trim <> "" Then
            strQry = strQry & "  and  RTRIM(LTRIM(GROUP_ID))=RTRIM(LTRIM(@GRPNAME)) "
            prmGRPNAME.Value = ddlGroup.SelectedItem.Text.Trim
            cmd.Parameters.Add(prmGRPNAME)
        End If



        If ddlStatus.SelectedItem.Text.Trim = "LOCKED" Then
            strQry = strQry & "  and  ACCOUNT_STATUS='LOCKED' "
        End If
        If ddlStatus.SelectedItem.Text.Trim = "OPEN" Then
            strQry = strQry & "  and  ACCOUNT_STATUS='OPEN' "
        End If
        If ddlStatus.SelectedItem.Text.Trim = "BLOCKED" Then
            strQry = strQry & "  and  BLOCKED='Y' "
        End If
        If ddlStatus.SelectedItem.Text.Trim = "DISABLED" Then
            strQry = strQry & "  and  DISABLED='Y' "
        End If
        'Establishing database connection
        If conn.State = ConnectionState.Closed Then conn.Open()
        If a = 0 Then
            cmd.CommandText = strQry1 & strQry & " order by  ENROL_DATE "
        Else
            cmd.CommandText = strQry2 & strQry & " order by  ENROL_DATE "
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
    'Shows the details in datagrid
    Private Sub lnkQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkQuery.Click
        Session("SelectedMCODE") = ""
        DataGrid1.DataBind()
        DataGrid1.CurrentPageIndex = 0
        LoadReport(0)
    End Sub
    'Link to generate link for downloading generated excel
    Private Sub lnkExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadReport(1)
    End Sub
    'To generate excel
    Private Sub generateExcel(ByVal ds As DataSet)
        filename = "UserStatusReport" & Format(DateTime.Now(), "MMMdd")

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


    ''Selecting 'from date' from calender
    'Private Sub lnkFromDate_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles lnkFromDate.Click
    '    Response.Write("<script language=javascript>window.open('popup.aspx?textbox=txtFromDate','cal','width=370,height=240,left=270,top=180')</script>")
    'End Sub
    ''Selecting 'to date' from calender
    'Private Sub lnkToDate_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles lnkToDate.Click
    '    Response.Write("<script language=javascript>window.open('popup.aspx?textbox=txtToDate','cal','width=370,height=240,left=270,top=180')</script>")
    'End Sub



    'To go to selected page in datagrid
    Private Sub DataGrid1_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid1.PageIndexChanged
        DataGrid1.CurrentPageIndex = e.NewPageIndex
        LoadReport(0)
    End Sub
    'To generate excel sheet
    Private Sub lnkExportToExcelME_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkExportToExcelME.Click
        LoadReport(1)
    End Sub
    'To download excel sheet
    Private Sub Datagrid2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub
    'To go to home page


    'PROCEDURE FOR DISPLAYING ERROR PAGE IF ERROR OCCURS IDURING APPLICATION EXCUTION 
    Private Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Error
        Dim PhyFilePath As String = System.AppDomain.CurrentDomain.BaseDirectory
        Dim sUser As String = Session("UserCode")
        Dim sLastError As String = Server.GetLastError.Message.ToString
        Dim sStackTrace As String = Server.GetLastError.StackTrace.ToString
        acs.WriteError(sLastError, sStackTrace, sUser, PhyFilePath, "NPCI_Loyalty-User Status")
    End Sub

    Protected Sub lnkFromDate_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles lnkFromDate.Click

    End Sub
End Class
'***********************************************************************************************************************
'End of <User_Status_report>
'***********************************************************************************************************************