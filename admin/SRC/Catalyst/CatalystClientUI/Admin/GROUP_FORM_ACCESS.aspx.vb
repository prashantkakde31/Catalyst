'***********************************************************************************************************************                                     
' File Name            : <GROUP_FORM_ACCESS>
' Location             : In-Solutions Global Pvt. Ltd., Malad                               
' Author               : UNKNOWN 
' PADss Created        : <SUNIL PUNDPAL>, Emp. No: <C967>
' Date of Creation     : 
' PADss Date           : <28-01-10>
' Description          : GROUP FORM ACCESS
'*********************************************************************************************************************** 
Imports System.Data
Imports System.Data.SqlClient
Public Class admin_GROUP_FORM_ACCESS
    Inherits System.Web.UI.Page
    Dim acs As New HelperClass
#Region "DECLARATIONS"
    Dim conn As New SqlConnection(ConfigurationManager.AppSettings().Item("ConnectionStringV"))

    ' for grid 1
    Dim cmd1 As New SqlCommand("select GROUP_NAME, GROUP_ID, DESCRIPTION from ADMIN_MAPS_GROUP_MASTER ORDER BY GROUP_NAME", conn)
    ' for grid 2
    Dim S2 As String = " select function_code,function_Desc from ADMIN_MAPS_function_master ORDER BY FUNCTION_CODE"
    Dim cmd2 As New SqlCommand(S2, conn)

    'For Module Grid
    Dim cmd4 As New SqlCommand("SELECT MENU_CODE, MENU_DESC FROM ADMIN_MAPS_MENU_LIST ORDER BY MENU_CODE", conn)

    Dim da1 As New SqlDataAdapter(cmd1)
    Dim da2 As New SqlDataAdapter(cmd2)

    Dim da4 As New SqlDataAdapter(cmd4)
    'for select checks
    Dim S3 As String = "select function_code from ADMIN_MAPS_function_master where function_code in (select form_id from ADMIN_MAPS_GROUP_FORM_DETIALS where GROUP_ID=@pUserId2)"
    Dim cmd3 As New SqlCommand(S3, conn)
    Dim da3 As New SqlDataAdapter(cmd3)

    Dim ds1 As New DataSet
    Dim ds2 As New DataSet
    Dim ds3 As New DataSet
    Dim ds4 As New DataSet
    Dim prmUserId2 As New SqlParameter("@pUserId2", SqlDbType.BigInt, 4)
#End Region
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

#Region "page_Load"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load

        'Session("UserCode") = "ADMIN"

        If Session("UserCode") = "" Then
            Response.Write("<script language=javascript>alert('Your Session Has EXPIRE/NOT LOGGED  IN Please Login Again.')</script>")
            Response.Redirect(acs.mapLink(Request.Path))
        End If

        If Not Page.IsPostBack Then

            'Check this user have access right of this page

            Dim strchk As String = acs.CheckSession(Session("UserCode"), System.IO.Path.GetFileName(Request.PhysicalPath))
            'strchk = "VALID"
            If strchk = "INVALID" Then
                Session("HomeFlag") = "N"
                Session("UserCode") = ""
                Response.Redirect(acs.mapLink(Request.Path))
            End If

            da1.Fill(ds1)
            DataGrid1.DataSource = ds1
            DataGrid1.DataBind()
            da4.Fill(ds4)
            DGModule.DataSource = ds4
            DGModule.DataBind()
        End If

        'To enable back btn
        Response.Write("<script language=javascript>window.history.forward(1)</script>")
    End Sub
#End Region

#Region "GRID_Action"
    'Module_Grid Click
    'Datgrid related functions
    Private Sub DGModule_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGModule.SelectedIndexChanged
        Session("ModlId") = DGModule.SelectedItem.Cells(1).Text.Trim + ""
        DataGrid2.CurrentPageIndex = 0
        BindGrid2()
        DataGrid2.Visible = True
    End Sub
    'To go to selected page in datagrid DGModule
    Private Sub DGModule_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DGModule.PageIndexChanged
        DGModule.CurrentPageIndex = e.NewPageIndex
        da4.Fill(ds4)
        DGModule.DataSource = ds4
        DGModule.DataBind()
    End Sub
    'Group_Grid Click
    Private Sub DataGrid1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.SelectedIndexChanged
        Session("GrpId") = DataGrid1.SelectedItem.Cells(2).Text.Trim
        DataGrid2.CurrentPageIndex = 0
        BindGrid2()
        DGModule.Visible = True
    End Sub
    'To go to selected page in datgrid1
    Private Sub DataGrid1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid1.PageIndexChanged
        DataGrid1.CurrentPageIndex = e.NewPageIndex
        da1.Fill(ds1)
        DataGrid1.DataSource = ds1
        DataGrid1.DataBind()
    End Sub
    'To go to selected page in datagrid2
    Private Sub DataGrid2_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid2.PageIndexChanged
        DataGrid2.CurrentPageIndex = e.NewPageIndex
        BindGrid2()
    End Sub
    'Go to selected page in datagrid2
    Private Sub DataGrid2_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid2.ItemCommand
        Dim dgItem As DataGridItem
        Dim chkSelected As New CheckBox
        For Each dgItem In DataGrid2.Items
            chkSelected = dgItem.FindControl("checkbox1")
            chkSelected.Checked = True
        Next
    End Sub
#End Region

#Region "Buttons_Action"
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim dr As DataRow
        Dim flag As Boolean = False
        Dim chkSelected As New CheckBox
        Dim dgItem As DataGridItem
        Dim varFormId As Integer
        Dim cmd3 As New SqlCommand("select function_code  from ADMIN_MAPS_function_master where function_code in (select form_id from ADMIN_MAPS_GROUP_FORM_DETIALS where group_id=@pUserId2)", conn)
        Dim prmUserid2 As New SqlParameter("pUserId2", SqlDbType.BigInt, 4)
        prmUserid2.Value = CType(DataGrid1.SelectedItem.Cells(2).Text, Integer)
        da3 = New SqlDataAdapter(cmd3)
        cmd3.Parameters.Add(prmUserid2)
        prmUserid2.Value = CType(DataGrid1.SelectedItem.Cells(2).Text, Integer)
        da3.Fill(ds3)
        For Each dgItem In DataGrid2.Items
            chkSelected = dgItem.FindControl("checkbox1")
            varFormId = CType(dgItem.Cells(1).Text, Integer)
            For Each dr In ds3.Tables(0).Rows
                If varFormId = dr("function_code") Then
                    flag = True
                    Exit For
                End If
            Next
            Dim prmUserId As New SqlParameter("pUserId", SqlDbType.BigInt, 4, "userid")
            Dim prmFormId As New SqlParameter("pFormId", SqlDbType.BigInt, 4, "formid")
            Dim cmd4 As SqlCommand

            If flag = False Then
                If chkSelected.Checked = True Then
                    'insert selected fn
                    cmd4 = New SqlCommand("insert into ADMIN_MAPS_GROUP_FORM_DETIALS( GROUP_ID,FORM_ID) values (@pUserId,@pFormId)", conn)
                    cmd4.Parameters.Add(prmFormId)
                    cmd4.Parameters.Add(prmUserId)
                    If conn.State = ConnectionState.Closed Then conn.Open()
                    prmUserId.Value = CType(DataGrid1.SelectedItem.Cells(2).Text, Integer)
                    prmFormId.Value = varFormId
                    cmd4.ExecuteNonQuery()
                End If
            Else
                If chkSelected.Checked = False Then
                    'delete unselected fn
                    cmd4 = New SqlCommand("delete from ADMIN_MAPS_GROUP_FORM_DETIALS where group_id=@pUserId and form_id=@pFormId", conn)
                    cmd4.Parameters.Add(prmFormId)
                    cmd4.Parameters.Add(prmUserId)
                    If conn.State = ConnectionState.Closed Then conn.Open()
                    prmUserId.Value = CType(DataGrid1.SelectedItem.Cells(2).Text, Integer)
                    prmFormId.Value = varFormId
                    cmd4.ExecuteNonQuery()
                End If
            End If

            'THIS WILL REBUILD ALL FORMS ACCESS TO ALL USERS  FOR ALL GROUPS 
            Dim SDEL As String = " DELETE FROM ADMIN_USER_FORM_DETAIL "
            Dim SINS As String = " INSERT INTO ADMIN_USER_FORM_DETAIL (USERID, FORMID) SELECT A.USER_ID, B.FORM_ID FROM  ADMIN_MAPS_GROUP_USER_MASTER A,ADMIN_MAPS_GROUP_FORM_DETIALS B  WHERE 	 A.GROUP_ID=B.GROUP_ID "
            Dim SCMD As New SqlCommand(SDEL, conn)
            SCMD.ExecuteNonQuery()
            SCMD.CommandText = SINS
            SCMD.ExecuteNonQuery()
            flag = False
        Next
        If conn.State = ConnectionState.Open Then conn.Close()

        Tell.text("Changes Sucessfully saved ", Me)

    End Sub

#End Region
    'Function to bind data to datagrid
    Private Function BindGrid2()
        Dim Sqr As String = ""
        Dim cmd As New SqlCommand
        Dim flag As Boolean = False
        Dim iModId As New SqlParameter("MODID", SqlDbType.BigInt, 4)

        If Session("ModlId") <> 0 Then
            Sqr = "SELECT FUNCTION_CODE,FUNCTION_DESC FROM ADMIN_MAPS_FUNCTION_MASTER WHERE MODULE_CODE =@MODID"
            cmd.Parameters.Add(iModId)
            iModId.Value = Session("ModlId")
        Else
            Sqr = "SELECT FUNCTION_CODE,FUNCTION_DESC FROM ADMIN_MAPS_FUNCTION_MASTER"
        End If

        Dim ds As New DataSet
        cmd.CommandText = Sqr
        cmd.Connection = conn
        Dim da As New SqlDataAdapter(cmd)
        da.SelectCommand = cmd
        da.Fill(ds)
        DataGrid2.DataSource = ds
        DataGrid2.DataBind()
        cmd.Parameters.Clear()
        Dim dgItem As DataGridItem
        Dim chkSelected As New CheckBox
        Dim daa As New SqlDataAdapter
        Dim cmda As New SqlCommand
        Dim dsa As New DataSet
        Dim dra As DataRow
        Dim sGroupId As New SqlParameter("GROUPID", SqlDbType.VarChar, 30)
        sGroupId.Value = Session("GrpId")
        iModId.Value = Session("ModlId")

        If Session("ModlId") <> Nothing And Session("GrpId") <> Nothing Then
            Sqr = " select function_code from ADMIN_MAPS_function_master" & _
                  " where MODULE_CODE= @MODID AND" & _
                  " function_code in (select form_id from ADMIN_MAPS_GROUP_FORM_DETIALS WHERE GROUP_ID= @GROUPID)"
            cmda.Connection = conn
            cmda.CommandText = Sqr
            cmda.Parameters.Add(iModId)
            cmda.Parameters.Add(sGroupId)
            daa.SelectCommand = (cmda)
            daa.Fill(dsa)
            For Each dgItem In DataGrid2.Items
                chkSelected = dgItem.FindControl("checkbox1")
                For Each dra In dsa.Tables(0).Rows
                    If dgItem.Cells(1).Text = dra("function_code") Then
                        flag = True
                    End If
                Next
                If flag = True Then
                    chkSelected.Checked = True
                    flag = False
                Else
                    chkSelected.Checked = False
                    flag = False
                End If
            Next
        End If
        Return ds
    End Function
    'PROCEDURE FOR DISPLAYING ERROR PAGE IF ERROR OCCURS IDURING APPLICATION EXCUTION 
    Private Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Error
        Dim PhyFilePath As String = System.AppDomain.CurrentDomain.BaseDirectory
        Dim sUser As String = Session("UserCode")
        Dim sLastError As String = Server.GetLastError.Message.ToString
        Dim sStackTrace As String = Server.GetLastError.StackTrace.ToString
        acs.WriteError(sLastError, sStackTrace, sUser, PhyFilePath, "NPCI_Loyalty Group Form Access")
    End Sub
End Class

'***********************************************************************************************************************
'End of <GROUP_FORM_ACCESS>
'***********************************************************************************************************************