'***********************************************************************************************************************                                     
' File Name            : <Rpt_UserWiseScreen>
' Location             : In-Solutions Global Pvt. Ltd., Malad                               
' Author               : unknown
' PADss Created        :<Tejas Pinge>, Emp. No: <C1857>
' Date of Creation     : 
' PADss Date           :<01-Jul-13>
' Description          :USERWISE REPORT GENERATION
'***********************************************************************************************************************
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Public Class admin_Rpt_UserWiseScreen

    Inherits System.Web.UI.Page
    Dim ds As New DataSet
    Dim acs As New HelperClass
    Dim rpt As New Reports
    Dim path As String = System.IO.Directory.GetDirectoryRoot(AppDomain.CurrentDomain.BaseDirectory) & "NPCI_LoyaltyReports\ADMIN\Rpt_UserWise_Forms\"
    Dim filename As String
    Dim conn As New SqlConnection(ConfigurationManager.AppSettings("ConnectionStringV"))
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        'Put user code to initialize the page here
        'If Session("UserCode") = "" Then
        '    Response.Write("<script language=javascript>alert('Your Session Has EXPIRE/NOT LOGGED  IN Please Login Again.')</script>")
        '    Response.Redirect("MAPSLOGIN2.aspx")
        'End If
        'Session("UserCode") = "ADMIN"
        If Session("UserCode") = "" Then
            Response.Write("<script language=javascript>alert('Your Session Has EXPIRE/NOT LOGGED  IN Please Login Again.')</script>")
            Response.Redirect(acs.mapLink(Request.Path))
        End If





        If Not Page.IsPostBack = True Then
            Dim strchk As String = acs.CheckSession(Session("UserCode"), System.IO.Path.GetFileName(Request.PhysicalPath))
            'strchk = "VALID"
            If strchk = "INVALID" Then
                Session("HomeFlag") = "N"
                Session("UserCode") = ""
                Response.Redirect(acs.mapLink(Request.Path))
            End If

            bindusrname()
            bindgrp()
            bindgrd()
        End If
    End Sub
    'Bind the list of group names to dropdownlist
    Private Sub bindgrp()
        Dim d As New data
        Dim strgrp As String = "SELECT DISTINCT GROUP_NAME FROM ADMIN_MAPS_GROUP_MASTER UNION SELECT '' FROM  ADMIN_MAPS_GROUP_MASTER ORDER BY GROUP_NAME DESC"
        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim ds As DataSet = d.GetData(strgrp)
        DropDownList2.DataTextField = "GROUP_NAME"
        DropDownList2.DataValueField = "GROUP_NAME"
        DropDownList2.DataSource = ds
        DropDownList2.DataBind()
        DropDownList2.Dispose()
        If conn.State = ConnectionState.Open Then conn.Close()
    End Sub
    'Bind the list of User names to dropdownlist
    Private Sub bindusrname()
        Dim d As New data
        Dim strusrname As String = "SELECT DISTINCT USER_NAME FROM  ADMIN_MAPS_USER_MASTER UNION SELECT '' FROM  ADMIN_MAPS_USER_MASTER ORDER BY USER_NAME DESC"
        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim ds As DataSet = d.GetData(strusrname)
        DropDownList1.DataTextField = "USER_NAME"
        DropDownList1.DataValueField = "USER_NAME"
        DropDownList1.DataSource = ds
        DropDownList1.DataBind()
        DropDownList1.Dispose()
        If conn.State = ConnectionState.Open Then conn.Close()
    End Sub
    'Bind the details to datagrid
    Private Sub bindgrd()
        'Dim str As String = "select g.user_name ""USER NAME"",a.GROUP_NAME ""GROUP NAME"",MENU_DESC ""MENU DESC"",MODULE_DESC ""MODULE DESC"", c.FUNCTION_DESC ""FUNCTION DESC"",g.ACCOUNT_STATUS ""ACCOUNT STATUS"", g.BLOCKED, g.DISABLED " & _
        '                    " from admin_maps_group_master a," & _
        '                    " ADMIN_MAPS_GROUP_FORM_DETIALS b," & _
        '                    " admin_maps_function_master c," & _
        '                    " ADMIN_MAPS_MODULE_MASTER d," & _
        '                    " ADMIN_MAPS_MENU_LIST e," & _
        '                    " ADMIN_MAPS_GROUP_USER_MASTER f," & _
        '                    " ADMIN_MAPS_USER_MASTER g" & _
        '                    " where" & _
        '                    " a.group_id = b.group_id and " & _
        '                    " b.form_id=c.function_code and " & _
        '                    " c.MODULE_CODE=d.MODULE_CODE and" & _
        '                    " d.MENU_CODE=e.MENU_CODE and" & _
        '                    " a.group_id=f.group_id and" & _
        '                    " f.user_id = g.user_id"
        'Validation for username


        ' the abovw qury has been modified by nitin, must be verified.
        Dim str As String = " SELECT g.user_name ""USER NAME"", "
        str = str & "  a.GROUP_NAME ""GROUP NAME"", "
        str = str & "  Menu_Desc ""MENU DESC"", "
        str = str & "   c.FUNCTION_DESC ""FUNCTION DESC"", "
        str = str & "  g.ACCOUNT_STATUS ""ACCOUNT STATUS"", "
        str = str & "  g.BLOCKED, "
        str = str & "  g.DISABLED "
        str = str & "FROM admin_maps_group_master a, "
        str = str & "  ADMIN_MAPS_GROUP_FORM_DETIALS b, "
        str = str & "  Admin_Maps_Function_Master C, "
        str = str & "   ADMIN_MAPS_MENU_LIST e, "
        str = str & "  ADMIN_MAPS_GROUP_USER_MASTER f, "
        str = str & "  ADMIN_MAPS_USER_MASTER g "
        str = str & "WHERE a.group_id = b.group_id "
        str = str & "And B.Form_Id    =C.Function_Code "
        str = str & "AND c.module_code  =e.MENU_CODE "
        str = str & "And A.Group_Id   =F.Group_Id "
        str = str & "AND f.user_id    = g.user_id "





        Dim cmd As New SqlCommand
        Dim sUserName As New SqlParameter("USERNAME", SqlDbType.VarChar, 30)
        sUserName.Value = DropDownList1.SelectedItem.Text

        Dim sGroupName As New SqlParameter("GROUPNAME", SqlDbType.VarChar, 100)
        sGroupName.Value = DropDownList2.SelectedItem.Text

        If DropDownList1.SelectedItem.Text <> "" Then
            str = str + " AND g.user_name=@USERNAME"
            cmd.Parameters.Add(sUserName)
        End If
        'Validation of gropuname
        If DropDownList2.SelectedItem.Text <> "" Then
            str = str + " AND a.GROUP_NAME=@GROUPNAME"
            cmd.Parameters.Add(sGroupName)
        End If
        If conn.State = ConnectionState.Closed Then conn.Open()
        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = conn
        Dim da As New SqlDataAdapter(cmd)

        da.Fill(ds)
        Dg_Usrsrn.DataSource = ds
        Dg_Usrsrn.DataBind()
        'Ckeck wheather user has rights or not
        If (Dg_Usrsrn.Items.Count.Equals(0)) Then
            Dg_Usrsrn.Visible = False
            lbl_Messege.Visible = True
            lbl_Messege.Text = "This User Doesn't Have Rights Of Selected Group!............."
        Else
            Dg_Usrsrn.Visible = True
            lbl_Messege.Visible = False
        End If
        If conn.State = ConnectionState.Open Then conn.Close()
    End Sub
    'Depending on choice generate excel
    Public Sub LoadReport(ByVal a As Integer)
        If a = 1 Then
            bindgrd()
            generateExcel(ds)
        End If
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Dispose()
    End Sub
    ' To generate Excel sheet
    Private Sub generateExcel(ByVal ds As DataSet)
        filename = "Rpt_UserWise_Forms" & Format(DateTime.Now(), "MMMdd")

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
    'To display selected page form datagrid
    Private Sub Dg_Usrsrn_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles Dg_Usrsrn.PageIndexChanged
        Dg_Usrsrn.CurrentPageIndex = e.NewPageIndex
        bindgrd()
    End Sub
    ' To display details in datagrid
    Private Sub Btn_Det_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Det.Click
        Dg_Usrsrn.CurrentPageIndex = 0
        bindgrd()
    End Sub
    'To go to Home page

    'To download excel sheet
    Private Sub lnkExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkExportToExcel.Click
        LoadReport(1)
    End Sub
    'PROCEDURE FOR DISPLAYING ERROR PAGE IF ERROR OCCURS IDURING APPLICATION EXCUTION 
    Private Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Error
        Dim PhyFilePath As String = System.AppDomain.CurrentDomain.BaseDirectory
        Dim sUser As String = Session("UserCode")
        Dim sLastError As String = Server.GetLastError.Message.ToString
        Dim sStackTrace As String = Server.GetLastError.StackTrace.ToString
        acs.WriteError(sLastError, sStackTrace, sUser, PhyFilePath, "NPCI_Loyalty UserwiseScreen")
    End Sub

End Class
'***********************************************************************************************************************
'End of <Rpt_UserWiseScreen>
'***********************************************************************************************************************