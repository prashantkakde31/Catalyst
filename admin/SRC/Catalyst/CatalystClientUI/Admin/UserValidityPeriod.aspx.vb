'***********************************************************************************************************************                                     
' File Name            : <UserValidityPeriod>
' Location             : In-Solutions Global Pvt. Ltd., Malad                               
' Author               : Unknown
' Author PADSS         : <Tejas Pinge>, Emp. No: <C1857>
' Date of Creation     : 
' Date of PADSS        : <03/07/2013>
' Description          : 
'***********************************************************************************************************************
Imports System.Data
Imports System.IO
Imports System.Data.SqlClient
Public Class admin_UserValidityPeriod

    Inherits System.Web.UI.Page
    Dim acs As New HelperClass

#Region " Web Form Designer Generated Code "
    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    End Sub
    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object
    Protected Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error
        Dim PhyFilePath As String = System.AppDomain.CurrentDomain.BaseDirectory
        Dim sUser As String = Session("UserCode")
        Dim sLastError As String = Server.GetLastError.Message.ToString
        Dim sStackTrace As String = Server.GetLastError.StackTrace.ToString
        acs.WriteError(sLastError, sStackTrace, sUser, PhyFilePath, "NPCI_Loyalty-User Validity")
    End Sub
    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        ViewStateUserKey = Session.SessionID
        InitializeComponent()
    End Sub
#End Region
    Dim rpt As New Reports
    Dim path As String = System.IO.Directory.GetDirectoryRoot(AppDomain.CurrentDomain.BaseDirectory) & "NPCI_LoyaltyReports\ADMIN\UserSessionTrack_REPORT\"
    Dim filename As String
    Dim conn As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionStringV"))
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
    Private Sub pop_username()
        Dim d As New data
        Dim Strmcc As String = "select distinct user_name from ADMIN_MAPS_USER_MASTER WHERE BLOCKED='N' AND DISABLED='N' AND USER_NAME <>'SUPERADMIN' UNION ALL select distinct '- - Select - -' user_name from ADMIN_MAPS_USER_MASTER WHERE USER_NAME <> 'SUPERADMIN' ORDER BY user_name"
        Dim dsmcc As DataSet = d.GetData(Strmcc)
        ddlUserName.DataTextField = "user_name"
        ddlUserName.DataValueField = "user_name"
        ddlUserName.DataSource = dsmcc
        ddlUserName.DataBind()
        ddlUserName.Dispose()
    End Sub
    Private Sub LoadReport(ByVal a As Integer)
        Dim strqry As String = "SELECT DISTINCT USER_NAME [User Name], cast(valid_from as date) [Valid From],Cast(VALID_UPTO as Date) [Valid Upto] FROM ADMIN_MAPS_USER_MASTER WHERE BLOCKED='N' AND DISABLED='N'"
        Dim cmdqry As New SqlCommand()

        If ddlUserName.SelectedIndex <> 0 Then
            strqry = strqry & " AND USER_NAME=@USER_NAME"
            Dim prmUSER_NAME As New SqlParameter("@USER_NAME", SqlDbType.VarChar, 30)
            cmdqry.Parameters.Add(prmUSER_NAME)
            prmUSER_NAME.Value = ddlUserName.SelectedItem.Text.Trim
        End If

        'strqry = strqry & " ORDER BY to_date(TO_CHAR(VALID_UPTO,'dd-Mon-yyyy'))"
        strqry = strqry & " ORDER BY CAST(VALID_UPTO AS DATE)"

        cmdqry.CommandText = strqry
        cmdqry.Connection = conn

        If conn.State = ConnectionState.Closed Then conn.Open()

        Dim daqry As New SqlDataAdapter(cmdqry)
        Dim dsqry As New DataSet
        daqry.Fill(dsqry)
        If a = 1 Then
            generateExcel(dsqry)
            ddlUserName.SelectedIndex = 0
            txtFromDate.Text = ""
            txtToDate.Text = ""
            LoadReport(0)
        End If
        DataGrid1.DataSource = dsqry
        DataGrid1.DataBind()
        DataGrid1.Visible = True
    End Sub
    Private Sub lnkExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadReport(1)
    End Sub
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


    Private Sub DataGrid1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid1.PageIndexChanged
        DataGrid1.CurrentPageIndex = e.NewPageIndex
        LoadReport(0)
    End Sub
    Private Sub Btn_Viewdet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Viewdet.Click
        LoadReport(0)
    End Sub
    Private Sub ddlUserName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlUserName.SelectedIndexChanged
        DataGrid1.CurrentPageIndex = 0
        txtFromDate.Text = ""
        txtToDate.Text = ""
        If ddlUserName.SelectedIndex <> 0 Then
            Dim strqry As String = "SELECT cast(VALID_FROM as Date) VALID_FROM, Cast(VALID_UPTO as Date) VALID_UPTO FROM ADMIN_MAPS_USER_MASTER WHERE UPPER(USER_NAME)=UPPER(@USER_NAME)"
            Dim cmdqry As New SqlCommand(strqry, conn)

            Dim prmUSER_NAME As New SqlParameter("@USER_NAME", SqlDbType.VarChar, 30)
            prmUSER_NAME.Value = ddlUserName.SelectedItem.Text.Trim
            cmdqry.Parameters.Add(prmUSER_NAME)

            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim rdr As SqlDataReader
            rdr = cmdqry.ExecuteReader(CommandBehavior.CloseConnection)
            rdr.Read()
            If rdr.HasRows Then
                txtFromDate.Text = rdr("VALID_FROM")
                txtToDate.Text = rdr("VALID_UPTO")
            End If
            rdr.Close()
        End If
        LoadReport(0)
    End Sub
    Protected Sub Btn_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Save.Click
        'insert into ADMIN_MAPS_USER_ACTION_TRAIL table
        If ddlUserName.SelectedIndex = 0 Then
            Tell.text("Please Select User Name", Me)
            Exit Sub
        End If
        If txtToDate.Text = "" Then
            Tell.text("Please Select Validity Upto Date", Me)
            Exit Sub
        End If
        If Not IsDate(txtToDate.Text.Trim) Then
            Tell.text("Please enter valid to date", Me)
            txtToDate.Text = ""
            Exit Sub
        End If
        If txtToDate.Text.Trim < Date.Now() Then
            Tell.text("Please Select Validity date greater than Todays date", Me)
            txtToDate.Text = ""
            Exit Sub
        End If

        Dim strinst As String = "INSERT INTO ADMIN_MAPS_USER_ACTION_TRAIL(USER_NAME, UPDATED_BY, ACTION, ACTION_DATE) VALUES(@USER_NAME,'" + Session("UserCode") + "','USERS VALIDITIY EXTENDED',getdate())"
        Dim cmdinst As New SqlCommand(strinst, conn)

        Dim prmUSER_NAME As New SqlParameter("@USER_NAME", SqlDbType.VarChar, 30)
        prmUSER_NAME.Value = ddlUserName.SelectedItem.Text.Trim
        cmdinst.Parameters.Add(prmUSER_NAME)

        'update table ADMIN_MAPS_USER_MASTER
        Dim strupd As String = "UPDATE ADMIN_MAPS_USER_MASTER SET VALID_UPTO=@VALID_UPTO WHERE UPPER(USER_NAME)=UPPER(@USER_NAME)"
        Dim cmdupd As New SqlCommand(strupd, conn)

        Dim prmVALID_UPTO As New SqlParameter("@VALID_UPTO", SqlDbType.DateTime)
        cmdupd.Parameters.Add(prmVALID_UPTO)
        prmVALID_UPTO.Value = txtToDate.Text

        If conn.State = ConnectionState.Closed Then conn.Open()

        cmdinst.ExecuteNonQuery()
        cmdinst.Parameters.Clear()

        cmdupd.Parameters.Add(prmUSER_NAME)
        cmdupd.ExecuteNonQuery()
        Tell.text("Validity Extended", Me)
        LoadReport(0)
        lnkExportToExcelME.Visible = True
    End Sub
    Protected Sub Btn_Clear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Clear.Click
        ddlUserName.SelectedIndex = 0
        txtFromDate.Text = ""
        txtToDate.Text = ""
        LoadReport(0)
        'DataGrid1.Visible = False
        lnkExportToExcelME.Visible = False
    End Sub
    Protected Sub lnkExportToExcelME_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkExportToExcelME.Click
        LoadReport(1)
    End Sub
End Class
'***********************************************************************************************************************
'End of <UserValidityPeriod>
'***********************************************************************************************************************
