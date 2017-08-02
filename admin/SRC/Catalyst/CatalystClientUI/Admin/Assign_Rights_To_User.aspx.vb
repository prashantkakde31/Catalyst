Imports System.Data
Imports System.Data.SqlClient


Partial Class admin_Assignt_Rights_to_user

    Inherits System.Web.UI.Page

    Dim conn As New SqlConnection(ConfigurationSettings.AppSettings().Item("ConnectionStringPORTAL"))


    Dim prmUserId2 As New SqlParameter("pUserId2", SqlDbType.VarChar)
    Dim prmUserId As New SqlParameter("pUser_ID", SqlDbType.VarChar)

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
        InitializeComponent()
    End Sub

#End Region

    Protected Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error
        Dim PhyFilePath As String = System.AppDomain.CurrentDomain.BaseDirectory
        Dim sUser As String = Session("UserCode")
        Dim sLastError As String = Server.GetLastError.Message.ToString
        Dim sStackTrace As String = Server.GetLastError.StackTrace.ToString
        acs.WriteError(sLastError, sStackTrace, sUser, PhyFilePath, "NPCI_Loyalty Assign Rights to User")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Session("UserCode") = "ADMIN"

        If Session("UserCode") = "" Then
            Response.Write("<script language=javascript>alert('Your Session Has EXPIRE/NOT LOGGED  IN Please Login Again.')</script>")
            Response.Redirect("../Master/index.aspx")
        End If

        If Not Page.IsPostBack Then
            Dim strchk As String = acs.CheckSession(Session("UserCode"), System.IO.Path.GetFileName(Request.PhysicalPath))
            If strchk = "INVALID" Then
                Session("HomeFlag") = "N"
                Session("UserCode") = ""
                Response.Redirect("../Master/index.aspx")
            End If
            If conn.State = ConnectionState.Closed Then conn.Open()
            DataGrid1.PageIndex = 0
            bindGrid1()
        End If


    End Sub

    Protected Sub btnsave0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave0.Click

        Dim UserID As String
        Dim GroupID As String
        Dim GvRow As GridViewRow
        Dim ChkUsrGrpFlag As String
        Dim ChkFlag As String

        Dim cmdAMGUM As SqlCommand
        Dim cmdCheckAMGUMTemp As New SqlCommand
        Dim cmdInsert As SqlCommand
        Dim cmdDelete As SqlCommand

        Dim prmUserId As New SqlParameter("@UserID", SqlDbType.VarChar)
        Dim prmGroupId As New SqlParameter("@GroupID", SqlDbType.VarChar)
        Dim prmMakerName As New SqlParameter("@MakerName", SqlDbType.VarChar)

        If conn.State = ConnectionState.Closed Then conn.Open()
        UserID = DataGrid1.SelectedRow.Cells(1).Text.Trim

        For Each GvRow In DataGrid2.Rows

            GroupID = GvRow.Cells(1).Text.Trim
            Dim ChkBoxGroup As CheckBox = CType(GvRow.Cells(0).FindControl("checkbox1"), CheckBox)

            'cmdAMGUM = New SqlCommand("Select Decode(count(*),0,0,1) From ADMIN_MAPS_GROUP_USER_MASTER where User_ID = @UserID AND Group_ID= @GroupID", conn)   ' To check userId and Group Id is present in ADMIN_MAPS_GROUP_USER_MASTER or not
            cmdAMGUM = New SqlCommand("Select CASE WHEN COUNT(*) = 0 THEN 0 ELSE 1 END From ADMIN_MAPS_GROUP_USER_MASTER where User_ID = @UserID AND Group_ID= @GroupID", conn)   ' To check userId and Group Id is present in ADMIN_MAPS_GROUP_USER_MASTER or not

            prmUserId.Value = UserID
            prmGroupId.Value = GroupID
            cmdAMGUM.Parameters.Add(prmUserId)
            cmdAMGUM.Parameters.Add(prmGroupId)

            ChkUsrGrpFlag = cmdAMGUM.ExecuteScalar()
            cmdAMGUM.Parameters.Clear()

            'cmdCheckAMGUMTemp = New SqlCommand("Select Decode(count(*),0,0,1) From ADMIN_MAPS_GRP_USR_MSTR_TEMP where User_ID = :UserID AND Group_ID= :GroupID AND Status = 'Pending' ", conn)  ' To check userId and Group Id is present in ADMIN_MAPS_GRP_USR_MSTR_TEMP or not
            cmdCheckAMGUMTemp = New SqlCommand("SELECT CASE WHEN COUNT(*) = 0 THEN 0 ELSE 1 END AS cnt From ADMIN_MAPS_GRP_USR_MSTR_TEMP where User_ID = @UserID AND Group_ID= @GroupID AND Status = 'Pending' ", conn)  ' To check userId and Group Id is present in ADMIN_MAPS_GRP_USR_MSTR_TEMP or not


            cmdCheckAMGUMTemp.Parameters.Add(prmUserId)
            cmdCheckAMGUMTemp.Parameters.Add(prmGroupId)

            ChkFlag = cmdCheckAMGUMTemp.ExecuteScalar()
            cmdCheckAMGUMTemp.Parameters.Clear()

            If ChkBoxGroup.Checked = True Then

                If ChkUsrGrpFlag = "1" Then               ' User Id and Group Id are =====>  PRESENT  <======= in Admin_Maps_Group_User_Master

                    If ChkFlag = "1" Then                 ' User Id and Group Id is now  =====>  PRESENT  <====== in ADMIN_MAPS_GRP_USR_MSTR_TEMP table then it has to be deleted because  first uncheck and then check it again 

                        cmdDelete = New SqlCommand("Delete From ADMIN_MAPS_GRP_USR_MSTR_TEMP where User_Id= @UserID AND Group_ID = @GroupID AND STATUS = 'Pending' ", conn)
                        cmdDelete.Parameters.Add(prmUserId)
                        cmdDelete.Parameters.Add(prmGroupId)
                        cmdDelete.ExecuteNonQuery()
                        cmdDelete.Parameters.Clear()

                    ElseIf ChkFlag = "0" Then

                        'Yet No Action Needed

                    End If

                ElseIf ChkUsrGrpFlag = "0" And ChkFlag = "0" Then            ' User Id and Group Id are =====>  NOT PRESENT  <======= in Admin_Maps_Group_User_Master

                    cmdInsert = New SqlCommand("Insert Into ADMIN_MAPS_GRP_USR_MSTR_TEMP(User_ID, Group_ID, Status, Maker_Date , Maker_Name, REMARK ) values (@UserID, @GroupID, 'Pending', getdate() , @MakerName , 'ADD')", conn)

                    prmMakerName.Value = Session("UserCode")
                    cmdInsert.Parameters.Add(prmUserId)
                    cmdInsert.Parameters.Add(prmGroupId)
                    cmdInsert.Parameters.Add(prmMakerName)

                    cmdInsert.ExecuteNonQuery()
                    cmdInsert.Parameters.Clear()

                End If

            ElseIf ChkBoxGroup.Checked = False Then

                If ChkUsrGrpFlag = "1" And ChkFlag = "0" Then               ' User Id and Group Id are =====> NOT  PRESENT  <======= in Admin_Maps_Group_User_Master

                    cmdInsert = New SqlCommand("Insert Into ADMIN_MAPS_GRP_USR_MSTR_TEMP(User_ID, Group_ID, Status, Maker_Date , Maker_Name, REMARK ) values (@UserID, @GroupID, 'Pending', getdate() , @MakerName , 'DELETE')", conn)
                    prmMakerName.Value = Session("UserCode")
                    cmdInsert.Parameters.Add(prmUserId)
                    cmdInsert.Parameters.Add(prmGroupId)
                    cmdInsert.Parameters.Add(prmMakerName)
                    cmdInsert.ExecuteNonQuery()
                    cmdInsert.Parameters.Clear()

                ElseIf ChkUsrGrpFlag = "0" Then            ' User Id and Group Id are =====> PRESENT  <======= in Admin_Maps_Group_User_Master

                    If ChkFlag = "1" Then                   ' User Id and Group Id is now  =====>  PRESENT  <====== in ADMIN_MAPS_GRP_USR_MSTR_TEMP table and now has to be deleted because some first check and then  Uncheck it again 

                        cmdDelete = New SqlCommand("Delete From ADMIN_MAPS_GRP_USR_MSTR_TEMP where User_Id= @UserID AND Group_ID = @GroupID AND STATUS = 'Pending' ", conn)
                        cmdDelete.Parameters.Add(prmUserId)
                        cmdDelete.Parameters.Add(prmGroupId)
                        cmdDelete.ExecuteNonQuery()
                        cmdDelete.Parameters.Clear()

                    ElseIf ChkFlag = "0" Then

                        'Yet No Action Needed

                    End If

                End If

            End If

        Next
        conn.Close()

        Tell.text("Changes Sucessfully saved ", Me)


    End Sub


    Private Sub bindGrid1()

        Dim cmd1 As New SqlCommand("select user_id ,user_name from ADMIN_MAPS_USER_MASTER WHERE ISNULL(DISABLED,'N') <> 'Y' ORDER BY USER_NAME", conn)

        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet
        da.SelectCommand = cmd1
        If conn.State = ConnectionState.Closed Then conn.Open()
        DataGrid1.SelectedIndex = -1
        da.Fill(ds)
        DataGrid1.DataSource = ds
        DataGrid1.DataBind()
        DataGrid1.Visible = True

    End Sub

    Protected Sub DataGrid1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles DataGrid1.PageIndexChanging
        DataGrid1.SelectedIndex = -1
        DataGrid1.PageIndex = e.NewPageIndex
        bindGrid1()
    End Sub

    Protected Sub DataGrid1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.SelectedIndexChanged
        bindGrid2()
    End Sub

    Protected Sub DataGrid2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles DataGrid2.PageIndexChanging

        DataGrid2.SelectedIndex = -1
        DataGrid2.PageIndex = e.NewPageIndex
        bindGrid2()

    End Sub

    Private Sub bindGrid2()

        If conn.State = ConnectionState.Closed Then conn.Open()

        Dim cmd2 As New SqlCommand(" select GROUP_ID , GROUP_NAME ,  DESCRIPTION from ADMIN_MAPS_GROUP_MASTER", conn)
        Dim da2 As New SqlDataAdapter(cmd2)
        Dim ds2 As New DataSet

        Dim cmd3 As New SqlCommand("select GROUP_ID  from ADMIN_MAPS_GROUP_MASTER where GROUP_ID in (select GROUP_ID from ADMIN_MAPS_GROUP_USER_MASTER where USER_ID=@pUserId2)", conn)
        Dim da3 As New SqlDataAdapter(cmd3)
        Dim ds3 As New DataSet


        Dim cmd4 As New SqlCommand("select GROUP_ID  from ADMIN_MAPS_GRP_USR_MSTR_TEMP where USER_ID= @pUser_ID And Status ='Pending' ", conn)
        Dim da4 As New SqlDataAdapter(cmd4)
        Dim ds4 As New DataSet

        cmd4.Parameters.Add(prmUserId)
        cmd3.Parameters.Add(prmUserId2)
        prmUserId.Value = DataGrid1.SelectedRow.Cells(1).Text.Trim
        prmUserId2.Value = DataGrid1.SelectedRow.Cells(1).Text.Trim


        Dim flag As Boolean = False
        da2.Fill(ds2)
        da3.Fill(ds3)
        da4.Fill(ds4)
        DataGrid2.DataSource = ds2
        DataGrid2.DataBind()
        Dim dgItem As GridViewRow
        Dim GvData As GridViewRow

        For Each dgItem In DataGrid2.Rows

            Dim chkSelected As CheckBox = CType(dgItem.Cells(0).FindControl("checkbox1"), CheckBox)

            For Each dr In ds3.Tables(0).Rows
                If dgItem.Cells(1).Text.Trim = dr("GROUP_ID") Then
                    flag = True
                End If
            Next
            If flag = False Then
                chkSelected.Checked = False
            Else
                chkSelected.Checked = True
                flag = False
            End If
        Next


        For Each GvData In DataGrid2.Rows

            Dim chkBox As CheckBox = CType(GvData.Cells(0).FindControl("checkbox1"), CheckBox)

            For Each dr In ds4.Tables(0).Rows
                If GvData.Cells(1).Text.Trim = dr("GROUP_ID") Then
                    flag = True
                End If
            Next
            If flag = True Then
                chkBox.Checked = True
                flag = False
            End If
        Next


        DataGrid2.Visible = True
        If conn.State = ConnectionState.Open Then conn.Close()
    End Sub


    Protected Sub btn_search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_search.Click
        Dim cmdSelect As New SqlCommand
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim msg As String

        ' user Id validation...
        msg = acs.ValidateText(txt_user.Text.Trim, "User Name", 30)
        If msg <> "Y" Then
            Tell.text(msg, Me)
            txt_user.Text = ""
            SetFocus(txt_user)
            Exit Sub
        End If

        cmdSelect.CommandText = "select user_id ,user_name from ADMIN_MAPS_USER_MASTER WHERE ISNULL(DISABLED,'N') <> 'Y' AND USER_NAME = @UserID"
        cmdSelect.Connection = conn
        Dim prmUserID As New SqlParameter("UserID", SqlDbType.VarChar)
        prmUserID.Value = txt_user.Text.ToUpper
        cmdSelect.Parameters.Add(prmUserID)
        da.SelectCommand = cmdSelect
        If conn.State = ConnectionState.Closed Then conn.Open()
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            DataGrid1.DataSource = ds.Tables(0).DefaultView
            DataGrid1.DataBind()
        Else
            Tell.text("No Data found", Me)
            Exit Sub
        End If
        cmdSelect.Parameters.Clear()
        conn.Close()
    End Sub

    Protected Sub DataGrid2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid2.SelectedIndexChanged

    End Sub
End Class
