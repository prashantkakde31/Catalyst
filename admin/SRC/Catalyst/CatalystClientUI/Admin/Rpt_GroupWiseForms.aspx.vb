'***********************************************************************************************************************                                     
' File Name            : <Rpt_GroupWiseForms>
' Location             : In-Solutions Global Pvt. Ltd., Malad                               
' Author               : Unknown
' Author PADSS         : <Tejas Pinge>, Emp. No: <C1857>
' Date of Creation     : 
' Date of PADSS        : <03-Jul-13>
' Description          : 
'***********************************************************************************************************************
Imports System.Data
Imports System.IO
Imports System.Data.SqlClient
Public Class admin_Rpt_GroupWiseForms
    Inherits System.Web.UI.Page
    Dim ds As New DataSet
    Dim objHelperClass As New HelperClass
    Dim rpt As New Reports
    Dim path As String = System.IO.Directory.GetDirectoryRoot(AppDomain.CurrentDomain.BaseDirectory) & "NPCI_LoyaltyReports\ADMIN\Rpt_GroupWise_Forms\"
    Dim filename As String
    Dim acs As New HelperClass

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

    Dim conn As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionStringV"))

    'this is use to load page  and records add in dropdown
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        'Put user code to initialize the page here
        'If Session("UserCode") = "" Then
        '    Response.Write("<script language=javascript>alert('Your Session Has EXPIRE/NOT LOGGED  IN Please Login Again.')</script>")
        '    Response.Redirect(objHelperClass.mapLink(Request.Path))
        'End If

        'Session("UserCode") = "ADMIN"

        If Session("UserCode") = "" Then
            Response.Write("<script language=javascript>alert('Your Session Has EXPIRE/NOT LOGGED  IN Please Login Again.')</script>")
            Response.Redirect(acs.mapLink(Request.Path))
        End If

        If Not Page.IsPostBack = True Then
            Dim strchk As String = objHelperClass.CheckSession(Session("UserCode"), System.IO.Path.GetFileName(Request.PhysicalPath))
            'strchk = "VALID"
            If strchk = "INVALID" Then
                Session("HomeFlag") = "N"
                Session("UserCode") = ""
                Response.Redirect(objHelperClass.mapLink(Request.Path))
            End If
            bindgrp()
            bindScr()
            bindgrid()
            lbl_Messege.Visible = False
        End If
    End Sub
    Private Sub bindScr()
        Dim d As New data
        Dim strsrn As String = "SELECT DISTINCT FUNCTION_DESC FROM ADMIN_MAPS_FUNCTION_MASTER UNION SELECT '' FROM ADMIN_MAPS_FUNCTION_MASTER ORDER BY FUNCTION_DESC DESC"
        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim dssrn As DataSet = d.GetData(strsrn)
        ddl_Scrnname.DataTextField = "FUNCTION_DESC"
        ddl_Scrnname.DataValueField = "FUNCTION_DESC"
        ddl_Scrnname.DataSource = dssrn
        ddl_Scrnname.DataBind()
        ddl_Scrnname.Dispose()
        If conn.State = ConnectionState.Open Then conn.Close()
    End Sub
    Private Sub bindgrp()
        Dim d As New data
        Dim strgrp As String = "SELECT DISTINCT GROUP_NAME FROM ADMIN_MAPS_GROUP_MASTER UNION SELECT '' FROM ADMIN_MAPS_GROUP_MASTER  ORDER BY GROUP_NAME DESC"
        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim dsgrp As DataSet = d.GetData(strgrp)
        ddl_Grpname.DataTextField = "GROUP_NAME"
        ddl_Grpname.DataValueField = "GROUP_NAME"
        ddl_Grpname.DataSource = dsgrp
        ddl_Grpname.DataBind()
        ddl_Grpname.Dispose()
        If conn.State = ConnectionState.Open Then conn.Close()
    End Sub
    'this is use to bind datagrid 
    Private Sub bindgrid()


        Dim str As String = " SELECT A.GROUP_NAME,E.MENU_DESC ,C.FUNCTION_DESC "
        str = str & "         FROM ADMIN_MAPS_GROUP_MASTER A,ADMIN_MAPS_GROUP_FORM_DETIALS B, "
        str = str & "         ADMIN_MAPS_FUNCTION_MASTER C, ADMIN_MAPS_MENU_LIST E "
        str = str & "     WHERE A.GROUP_ID = B.GROUP_ID AND "
        str = str & "         B.FORM_ID=C.FUNCTION_CODE AND "
        str = str & "         E.MENU_CODE=C.MODULE_CODE "


        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim cmd As New SqlCommand(str, conn)

        If ddl_Grpname.SelectedItem.Text <> "" Then
            Dim prmGROUP_NAME As New SqlParameter("GROUP_NAME", SqlDbType.VarChar, 100)
            cmd.Parameters.Add(prmGROUP_NAME)
            prmGROUP_NAME.Value = ddl_Grpname.SelectedItem.Text

            str = str & " AND a.GROUP_NAME=@GROUP_NAME"
        End If
        If ddl_Scrnname.SelectedItem.Text <> "" Then
            Dim prmScrnname As New SqlParameter("Scrnname", SqlDbType.VarChar, 100)
            cmd.Parameters.Add(prmScrnname)
            prmScrnname.Value = ddl_Scrnname.SelectedItem.Text
            str = str & " AND c.FUNCTION_DESC=@Scrnname"
        End If

        Dim da As New SqlDataAdapter
        cmd.CommandText = str
        cmd.Connection = conn
        da.SelectCommand = cmd

        da.Fill(ds)
        Dg_GrpScrn.DataSource = ds
        Dg_GrpScrn.DataBind()
        If (Dg_GrpScrn.Items.Count.Equals(0)) Then
            Dg_GrpScrn.Visible = False
            lbl_Messege.Visible = True
            lbl_Messege.Text = "Group doesn't have rights for selected screen!"
        Else
            Dg_GrpScrn.Visible = True
            lbl_Messege.Visible = False
        End If
        If conn.State = ConnectionState.Open Then conn.Close()
    End Sub
    'this is use to load report and genrate excel
    Private Sub LoadReport(ByVal a As Integer)
        If a = 1 Then
            bindgrid()
            generateExcel(ds)
        End If
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Dispose()
    End Sub
    'this proc use to genrate excel
    Private Sub generateExcel(ByVal ds As DataSet)
        filename = "Rpt_GroupWise_Forms" & Format(DateTime.Now(), "MMMdd")

        If Directory.Exists(path) = False Then
            Directory.CreateDirectory(path)
        End If
        rpt.WriteToExcelNew(ds, path, filename)

        'to create zip file
        rpt.create_zip(path & "\", filename, "*.xls")

        'to write LOG
        objHelperClass.writeLogDB(Session("UserCode"), System.IO.Path.GetFileName(Request.Path).ToString, filename + ".xls")

        'To delete file from the path
        rpt.deletedumpxl(path, "*.xls")

        'TO download file

        Dim flname As New System.IO.FileInfo(path + filename & ".zip")
        Response.Clear()
        Response.AppendHeader("content-disposition", "attachment; filename=" + filename & ".zip")
        Response.WriteFile(flname.FullName)
        Response.End()
    End Sub
    'this is use to display home page 

    'this is use to set pageindex 0 and bind datagrid
    Private Sub Btn_Det_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Det.Click
        Dg_GrpScrn.CurrentPageIndex = 0
        bindgrid()
    End Sub
    'this is use to set pageindex and bind datagrid
    Private Sub Dg_GrpScrn_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles Dg_GrpScrn.PageIndexChanged
        Dg_GrpScrn.CurrentPageIndex = e.NewPageIndex
        bindgrid()
    End Sub
    'this is use to export data in excel
    Private Sub lnkExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkExportToExcel.Click
        LoadReport(1)
    End Sub
    'this is use to when error comes then display error page 
    Private Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Error
        Dim PhyFilePath As String = System.AppDomain.CurrentDomain.BaseDirectory
        Dim sUser As String = Session("UserCode")
        Dim sLastError As String = Server.GetLastError.Message.ToString
        Dim sStackTrace As String = Server.GetLastError.StackTrace.ToString
        objHelperClass.WriteError(sLastError, sStackTrace, sUser, PhyFilePath, "NPCI_Loyalty Groupwise")
    End Sub
End Class
'***********************************************************************************************************************
'End of <Rpt_GroupWiseForms>
'***********************************************************************************************************************