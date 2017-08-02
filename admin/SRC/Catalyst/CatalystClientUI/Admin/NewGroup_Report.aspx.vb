'***********************************************************************************************************************                                     
' File Name            : <NewGroup_Report>
' Location             : In-Solutions Global Pvt. Ltd., Malad                               
' Author               : UNKNOWN 
' PADss Created        : <SUNIL PUNDPAL>, Emp. No: <C967>
' Date of Creation     : 
' PADss Date           : <29-01-10>
' Description          : NEW GROUP REPORT
'***********************************************************************************************************************
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class admin_NewGroup_Report
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
    Dim path As String = System.IO.Directory.GetDirectoryRoot(AppDomain.CurrentDomain.BaseDirectory) & "NPCI_LoyaltyReports\ADMIN\GroupReport\"
    Dim filename As String

    Dim strQry1 As String = " SELECT GROUP_NAME as [GROUP NAME],GROUP_ID as [GROUP ID],DESCRIPTION FROM ADMIN_MAPS_GROUP_MASTER WHERE 1=1 "
    Dim strQry2 As String = " SELECT GROUP_NAME as [GROUP NAME],GROUP_ID as [GROUP ID],DESCRIPTION FROM ADMIN_MAPS_GROUP_MASTER WHERE 1=1 "
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
            pop_GroupName()
            Session("EDITFLAG") = "FALSE"
        End If
        Response.Write("<script language=javascript>window.history.forward(1)</script>")
    End Sub
    'Binding the list of Group names to dropdownlist
    Private Sub pop_GroupName()
        Dim d As New data
        'Dim Strmcc As String = "select Group_Name from ADMIN_MAPS_GROUP_MASTER UNION select distinct ''  GROUP_NAME from ADMIN_MAPS_GROUP_MASTER ORDER BY Group_Name DESC "
        Dim Strmcc As String = "SELECT '--Select--' AS GROUP_NAME UNION ALL SELECT GROUP_NAME FROM ADMIN_MAPS_GROUP_MASTER "

        Dim dsmcc As DataSet = d.GetData(Strmcc)
        ddlGroupName.DataTextField = "Group_Name"
        ddlGroupName.DataValueField = "Group_Name"
        ddlGroupName.DataSource = dsmcc
        ddlGroupName.DataBind()
        ddlGroupName.Dispose()
    End Sub
    'set focus control
    Private Sub MySetFocus(ByVal ctrl As Control)
        Dim str As String = "<script language=javascript>document.getElementById('" & ctrl.ClientID & "').focus()</script>"
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MySetFocus", str)
    End Sub
    'To go to home page
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Session("HomeFlag") = "Y"
        Response.Redirect(acs.mapLink(Request.Path))
    End Sub
    'To bind details to datagrid
    Private Sub lnklblVwDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnklblVwDet.Click
        Session("SelectedMCODE") = ""
        DataGrid1.DataBind()
        DataGrid1.CurrentPageIndex = 0
        LoadReport(0)
    End Sub
    'To download excel 
    Private Sub lnkExportToExcelME_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkExportToExcelME.Click
        LoadReport(1)
    End Sub
    'To generate the data according to condition
    Private Sub LoadReport(ByVal a As Integer)
        Dim prmFromDate As New SqlParameter("@FromDate", SqlDbType.DateTime)
        Dim prmToDate As New SqlParameter("@ToDate", SqlDbType.DateTime)
        Dim prmTID As New SqlParameter("@TID", SqlDbType.VarChar, 30)
        Dim prmMECODE As New SqlParameter("@MECODE", SqlDbType.VarChar, 50)
        Dim strQry As String = ""
        Dim prmMENAME As New SqlParameter("@MENAME", SqlDbType.VarChar, 100)
        Dim prmGRPNAME As New SqlParameter("@GRPNAME", SqlDbType.VarChar, 100)

        If ddlGroupName.SelectedItem.Text.Trim <> "" Then
            strQry = strQry & "  and  RTRIM(LTRIM(GROUP_NAME))=RTRIM(LTRIM(@GRPNAME))  "
            prmGRPNAME.Value = ddlGroupName.SelectedItem.Text.Trim
            cmd.Parameters.Add(prmGRPNAME)
        End If

        If conn.State = ConnectionState.Closed Then conn.Open()
        If a = 0 Then
            cmd.CommandText = strQry1 & strQry & " order by  GROUP_NAME "
        Else
            cmd.CommandText = strQry2 & strQry & " order by  GROUP_NAME "
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
    'To generate excel
    Private Sub generateExcel(ByVal ds As DataSet)
        filename = "GroupReport" & Format(DateTime.Now(), "MMMdd")

        If Directory.Exists(path) = False Then
            Directory.CreateDirectory(path)
        End If
        rpt.WriteToExcelNew(ds, path, filename)

        'to create zip file
        rpt.create_zip(path & "\", filename, "*.xls")

        'to write LOG
        'acs.writeLogDB(Session("UserCode"), System.IO.Path.GetFileName(Request.Path).ToString, filename + ".xls")

        'To delete file from the path
        rpt.deletedumpxl(path, "*.xls")

        'TO download file
        Dim flname As New System.IO.FileInfo(path + filename & ".zip")
        Response.Clear()
        Response.AppendHeader("content-disposition", "attachment; filename=" + filename & ".zip")
        Response.WriteFile(flname.FullName)
        Response.End()
    End Sub
    'To go to home page

    'PROCEDURE FOR DISPLAYING ERROR PAGE IF ERROR OCCURS IDURING APPLICATION EXCUTION
    Private Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Error
        Dim PhyFilePath As String = System.AppDomain.CurrentDomain.BaseDirectory
        Dim sUser As String = Session("UserCode")
        Dim sLastError As String = Server.GetLastError.Message.ToString
        Dim sStackTrace As String = Server.GetLastError.StackTrace.ToString
        acs.WriteError(sLastError, sStackTrace, sUser, PhyFilePath, "NPCI_Loyalty New Group")
    End Sub
End Class
'***********************************************************************************************************************
'End of <NewGroup_Report>
'***********************************************************************************************************************