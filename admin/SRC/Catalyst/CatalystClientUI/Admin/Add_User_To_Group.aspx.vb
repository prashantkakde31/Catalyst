Imports System.Data
Imports System.Data.SqlClient

Partial Class admin_Add_User_To_Group

    Inherits System.Web.UI.Page
    Dim conn As New SqlConnection(ConfigurationSettings.AppSettings().Item("ConnectionStringPORTAL"))
    Dim cmd1 As New SqlCommand("select user_id AS [User ID],user_name AS [User Name] from ADMIN_MAPS_USER_MASTER WHERE isnull(DISABLED,'N') <> 'Y' ORDER BY USER_NAME", conn)
    Dim cmd2 As New SqlCommand(" select GROUP_ID AS [Group ID], GROUP_NAME AS [Group Name],  DESCRIPTION AS [Description] from ADMIN_MAPS_GROUP_MASTER", conn)
    Dim cmd3 As New SqlCommand("select GROUP_ID  from ADMIN_MAPS_GROUP_MASTER where GROUP_ID in (select GROUP_ID from ADMIN_MAPS_GROUP_USER_MASTER where USER_ID=@pUserId2)", conn)
    Dim da1 As New SqlDataAdapter(cmd1)
    Dim da2 As New SqlDataAdapter(cmd2)
    Dim da3 As New SqlDataAdapter(cmd3)
    Dim ds1 As New DataSet
    Dim ds2 As New DataSet
    Dim ds3 As New DataSet
    Dim prmUserId2 As New SqlParameter("@pUserId2", SqlDbType.Int, 4)
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
    'To show data into datagrid2 according to choice
    Private Sub DataGrid1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.SelectedIndexChanged
        prmUserId2.Value = CType(DataGrid1.SelectedItem.Cells(1).Text, Integer)
        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim dr As DataRow
        Dim flag As Boolean = False
        da2.Fill(ds2)
        da3.Fill(ds3)
        DataGrid2.DataSource = ds2
        DataGrid2.DataBind()
        Dim dgItem As DataGridItem
        Dim chkSelected As New CheckBox
        For Each dgItem In DataGrid2.Items
            chkSelected = dgItem.FindControl("checkbox1")
            For Each dr In ds3.Tables(0).Rows
                If dgItem.Cells(1).Text = dr("GROUP_ID") Then
                    flag = True
                End If
            Next
            If flag = False Then
                chkSelected.Checked = False
            Else
                flag = False
            End If
        Next
    End Sub
    'To save records into tables
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave0.Click
        Dim dr As DataRow
        Dim flag As Boolean = False
        Dim chkSelected As New CheckBox
        Dim dgItem As DataGridItem
        Dim varFormId As Integer

        Dim cmd3 As New SqlCommand("select GROUP_ID  from ADMIN_MAPS_GROUP_MASTER where GROUP_ID in (select GROUP_ID from ADMIN_MAPS_GROUP_USER_MASTER where USER_ID=@pUserId2)", conn)
        Dim prmUserid2 As New SqlParameter("@pUserId2", SqlDbType.Int, 4)
        prmUserid2.Value = CType(DataGrid1.SelectedItem.Cells(1).Text, Integer)
        da3 = New SqlDataAdapter(cmd3)
        cmd3.Parameters.Add(prmUserid2)
        prmUserid2.Value = CType(DataGrid1.SelectedItem.Cells(1).Text, Integer)
        da3.Fill(ds3)
        For Each dgItem In DataGrid2.Items
            chkSelected = dgItem.FindControl("checkbox1")
            varFormId = CType(dgItem.Cells(1).Text, Integer)
            For Each dr In ds3.Tables(0).Rows
                If varFormId = dr(0) Then
                    flag = True
                    Exit For
                End If
            Next

            Dim prmGROUPID1 As New SqlParameter("@GROUPID1", SqlDbType.Int, 4, "GROUPID1")
            Dim prmGROUPID2 As New SqlParameter("@GROUPID2", SqlDbType.Int, 4, "GROUPID2")
            Dim prmGUSERID As New SqlParameter("@GUSERID", SqlDbType.Int, 4, "GUSERID")

            If flag = False Then
                If chkSelected.Checked = True Then
                    If conn.State = ConnectionState.Closed Then conn.Open()
                    Dim cmd4 As SqlCommand
                    cmd4 = New SqlCommand("insert into ADMIN_MAPS_GROUP_USER_MASTER values (@pUserId,@pFormId)", conn)
                    Dim prmUserId As New SqlParameter("@pUserId", SqlDbType.Int, 4, "userid")
                    Dim prmFormId As New SqlParameter("@pFormId", SqlDbType.Int, 4, "formid")
                    cmd4.Parameters.Add(prmFormId)
                    cmd4.Parameters.Add(prmUserId)
                    prmUserId.Value = CType(DataGrid1.SelectedItem.Cells(1).Text, Integer)
                    prmFormId.Value = varFormId
                    cmd4.ExecuteNonQuery()

                    conn.Close()
                End If
            Else
                If chkSelected.Checked = False Then
                    If conn.State = ConnectionState.Closed Then conn.Open()
                    Dim cmd5 As New SqlCommand("delete from ADMIN_MAPS_GROUP_USER_MASTER where GROUP_ID=@GROUPIDD and USER_ID =@USERIDD", conn)
                    Dim prmGROUPIDD As New SqlParameter("@GROUPIDD", SqlDbType.Int, 4)
                    Dim prmUSERIDD As New SqlParameter("@USERIDD", SqlDbType.Int, 4)
                    cmd5.Parameters.Add(prmGROUPIDD)
                    cmd5.Parameters.Add(prmUSERIDD)
                    prmGROUPIDD.Value = varFormId
                    prmUSERIDD.Value = CType(DataGrid1.SelectedItem.Cells(1).Text, Integer)
                    cmd5.ExecuteNonQuery()

                    conn.Close()
                End If
            End If
            If conn.State = ConnectionState.Closed Then conn.Open()
            ' THIS WILL DELETE ALL USER FORMS 
            Dim cmd7 As SqlCommand
            cmd7 = New SqlCommand("DELETE FROM ADMIN_USER_FORM_DETAIL WHERE USERID = @USER_ID7", conn)
            Dim prmUserId7 As New SqlParameter("@USER_ID7", SqlDbType.Int)
            cmd7.Parameters.Add(prmUserId7)
            prmUserId7.Value = CType(DataGrid1.SelectedItem.Cells(1).Text, Integer)
            cmd7.ExecuteNonQuery()
            ' THIS WILL UPDATE ALL USER FORMS WRT ALLOCATED GROUPS

            Dim cmd6 As SqlCommand
            cmd6 = New SqlCommand("INSERT INTO ADMIN_USER_FORM_DETAIL (USERID, FORMID) SELECT @USER_ID,  FORM_ID FROM ADMIN_MAPS_GROUP_FORM_DETIALS WHERE  GROUP_ID IN (SELECT GROUP_ID FROM ADMIN_MAPS_GROUP_USER_MASTER where USER_ID =@USER_ID)", conn)
            Dim prmUserId6 As New SqlParameter("@USER_ID", SqlDbType.Int)
            cmd6.Parameters.Add(prmUserId6)
            prmUserId6.Value = CType(DataGrid1.SelectedItem.Cells(1).Text, Integer)
            cmd6.ExecuteNonQuery()

            flag = False
        Next

        Tell.text("Changes Sucessfully saved ", Me)

    End Sub
    'To go to selected page in datagrid2
    Private Sub DataGrid2_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid2.PageIndexChanged
        DataGrid2.CurrentPageIndex = e.NewPageIndex
        If conn.State = ConnectionState.Closed Then conn.Open()
        prmUserId2.Value = CType(DataGrid1.SelectedItem.Cells(1).Text, Integer)
        Dim dr As DataRow
        Dim flag As Boolean = False
        da2.Fill(ds2)
        da3.Fill(ds3)
        DataGrid2.DataSource = ds2
        DataGrid2.DataBind()
        Dim dgItem As DataGridItem
        Dim chkSelected As New CheckBox
        For Each dgItem In DataGrid2.Items
            chkSelected = dgItem.FindControl("checkbox1")
            For Each dr In ds3.Tables(0).Rows
                If dgItem.Cells(1).Text = dr("GROUP_ID") Then
                    flag = True
                End If
            Next
            If flag = False Then
                chkSelected.Checked = False
            Else
                flag = False
            End If
        Next

    End Sub
    'To go to selected page no of datagrid
    Private Sub DataGrid2_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid2.ItemCommand
        Dim dgItem As DataGridItem
        Dim chkSelected As New CheckBox
        For Each dgItem In DataGrid2.Items
            chkSelected = dgItem.FindControl("checkbox1")
            chkSelected.Checked = True
        Next
    End Sub

    Private Sub DataGrid2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid2.SelectedIndexChanged

    End Sub
    Private Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        DataGrid2.CurrentPageIndex = 0
    End Sub
    'To go to selected page in datagrid1
    Private Sub DataGrid1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid1.PageIndexChanged
        DataGrid1.CurrentPageIndex = e.NewPageIndex
        bindGrid1()
    End Sub
    'Common function to bind data to grid
    Private Sub bindGrid1()
        da1.Fill(ds1)
        DataGrid1.DataSource = ds1
        DataGrid1.DataBind()
    End Sub
    '---* PROCEDURE FOR DISPLAYING ERROR PAGE IF ERROR OCCURS IDURING APPLICATION EXCUTION ----
    Private Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Error
        Dim PhyFilePath As String = System.AppDomain.CurrentDomain.BaseDirectory
        Dim sUser As String = Session("UserCode")
        Dim sLastError As String = Server.GetLastError.Message.ToString
        Dim sStackTrace As String = Server.GetLastError.StackTrace.ToString
        acs.WriteError(sLastError, "", sUser, PhyFilePath, "NPCI_Loyalty-AddUserToGroup")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Session("UserCode") = "ADMIN"
        If Session("UserCode") = "" Then
            Response.Write("<script language=javascript>alert('Your Session Has EXPIRE/NOT LOGGED  IN Please Login Again.')</script>")
            'Response.Redirect("../Master/Login.aspx")
            Response.Redirect(acs.mapLink(Request.Path))
        End If
        If Not Page.IsPostBack Then
            Dim strchk As String = acs.CheckSession(Session("UserCode"), System.IO.Path.GetFileName(Request.PhysicalPath))
            If strchk = "INVALID" Then
                Session("HomeFlag") = "N"
                Session("UserCode") = ""
                'Response.Redirect("../Master/Login.aspx")
                Response.Redirect(acs.mapLink(Request.Path))
            End If
            If conn.State = ConnectionState.Closed Then conn.Open()
            DataGrid1.CurrentPageIndex = 0
            bindGrid1()
        End If
        cmd3.Parameters.Add(prmUserId2)
    End Sub

    Protected Sub btn_search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_search.Click
        Dim cmd As New SqlCommand
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim msg As String

        ' user Id validation...
        msg = acs.ValidateText(txt_user.Text, "User Name", 30)
        If msg <> "Y" Then
            Tell.text(msg, Me)
            txt_user.Text = ""
            SetFocus(txt_user)
            Exit Sub
        End If

        cmd.CommandText = "select user_id AS [User ID],user_name AS [User Name] from ADMIN_MAPS_USER_MASTER WHERE isnull(DISABLED,'N') <> 'Y' AND USER_NAME = @UIDS"
        cmd.Connection = conn
        Dim prmUID As New SqlParameter("@UIDS", SqlDbType.VarChar)
        prmUID.Value = txt_user.Text.ToUpper
        cmd.Parameters.Add(prmUID)
        da.SelectCommand = cmd
        If conn.State = ConnectionState.Closed Then conn.Open()
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            DataGrid1.DataSource = ds.Tables(0).DefaultView
            DataGrid1.DataBind()
        Else
            Tell.text("No Data found", Me)
            Exit Sub
        End If
        cmd.Parameters.Clear()
        conn.Close()
    End Sub
End Class
'***********************************************************************************************************************
'End of <Add_User_To_Group>
'***********************************************************************************************************************