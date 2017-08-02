'***********************************************************************************************************************                                     
' File Name            : <AddNewUsers>
' Location             : In-Solutions Global Pvt. Ltd., Malad                               
' Author               : UNKNOWN 
' PADss Created        : <Tejas Pinge>, Emp. No: <C1857>
' Date of Creation     : 
' PADss Date           : <28-06-13>
' Description          : ADDITION OF NEW GROUP
'***********************************************************************************************************************
Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class admin_AddNewUsers

    Inherits System.Web.UI.Page
    Dim conn As New System.Data.SqlClient.SqlConnection(ConfigurationManager.AppSettings("ConnectionStringV"))
    Dim abp As New HelperClass
    Dim acs As New HelperClass

#Region " Web Form Designer Generated Code "
    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    End Sub
    Protected WithEvents txtPRODUCT As System.Web.UI.WebControls.TextBox
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
        txtpASSWORD.Attributes.Add("autocomplete", "off")
        Response.Buffer = True
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1.0)
        Response.Expires = 0
        Response.CacheControl = "no-cache"
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
            ' PopulateGroup()
            bindgroup()
            Session("EDITFLAG") = "FALSE"
        End If
        Response.Write("<script language=javascript>window.history.forward(1)</script>")
    End Sub
    Private Sub lnkSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkSave.Click
        SaveNewUser()
    End Sub
    Public Sub SaveNewUser()
        Dim cmd As New SqlCommand
        'cmd.CommandText = "openkeys"
        'cmd.Connection = conn
        'cmd.CommandType = CommandType.StoredProcedure
        'If conn.State = ConnectionState.Closed Then conn.Open()
        'cmd.ExecuteNonQuery()

        If Session("EDITFLAG") = "TRUE" Then
            Dim cmdInsert As New SqlCommand
            cmdInsert.CommandText = "INSERT INTO ADMIN_MAPS_USER_MASTER ( USER_ID ,  USER_NAME, USER_PASSWORD, ACCOUNT_STATUS, GROUP_ID, BLOCKED, DISABLED, ENROL_DATE, PASSWORD_DATE, ADDED_BY, UPDATED_BY ,VALID_FROM, VALID_UPTO , USER_FULL_NAME) VALUES ( @USER_ID, upper(@USER_NAME),@USER_PASSWORD, @ACCOUNT_STATUS, @GROUP_ID, 'N', 'N', getdate(), getdate(), @ADDED_BY, @UPDATED_BY ,@VALID_FROM, @VALID_UPTO, @USER_FULL_NAME)"
            cmdInsert.Connection = conn
            Dim prmUSER_ID As New SqlParameter("@USER_ID", SqlDbType.Int, 6)
            Dim prmUSER_NAME As New SqlParameter("@USER_NAME", SqlDbType.VarChar, 30)
            Dim prmUSER_PASSWORD As New SqlParameter("@USER_PASSWORD", SqlDbType.VarChar)
            'Dim prmREGION_NAME As New SqlParameter("REGION_NAME", SqlDbType.VarChar, 30)
            Dim prmGROUP_ID As New SqlParameter("@GROUP_ID", SqlDbType.VarChar, 30)
            'Dim prmBRANCH As New SqlParameter("BRANCH", SqlDbType.VarChar, 30)
            'Dim prmDEPARTMENT As New SqlParameter("DEPARTMENT", SqlDbType.VarChar, 30)
            Dim prmADDED_BY As New SqlParameter("@ADDED_BY", SqlDbType.VarChar, 30)
            Dim prmUPDATED_BY As New SqlParameter("@UPDATED_BY", SqlDbType.VarChar, 30)
            Dim prmVALID_FROM As New SqlParameter("@VALID_FROM", SqlDbType.VarChar, 10)
            Dim prmVALID_UPTO As New SqlParameter("@VALID_UPTO", SqlDbType.VarChar, 10)
            Dim prmUSER_FULL_NAME As New SqlParameter("@USER_FULL_NAME", SqlDbType.VarChar, 255)
            Dim prmACCOUNT_STATUS As New SqlParameter("@ACCOUNT_STATUS", SqlDbType.VarChar, 10)

            cmdInsert.Parameters.Add(prmUSER_ID)
            cmdInsert.Parameters.Add(prmUSER_NAME)
            cmdInsert.Parameters.Add(prmUSER_PASSWORD)
            ' cmdInsert.Parameters.Add(prmREGION_NAME)
            cmdInsert.Parameters.Add(prmGROUP_ID)
            ' cmdInsert.Parameters.Add(prmBRANCH)
            ' cmdInsert.Parameters.Add(prmDEPARTMENT)
            cmdInsert.Parameters.Add(prmADDED_BY)
            cmdInsert.Parameters.Add(prmUPDATED_BY)
            cmdInsert.Parameters.Add(prmVALID_FROM)
            cmdInsert.Parameters.Add(prmVALID_UPTO)
            cmdInsert.Parameters.Add(prmUSER_FULL_NAME)
            cmdInsert.Parameters.Add(prmACCOUNT_STATUS)

            prmUSER_ID.Value = txtUSERID.Text
            prmUSER_NAME.Value = txtUSERNAME.Text
            prmUSER_PASSWORD.Value = txtpASSWORD.Text
            ' prmREGION_NAME.Value = ddlREGIONID.SelectedItem.Text
            prmGROUP_ID.Value = ddlGROUpID.SelectedItem.Text
            ' prmBRANCH.Value = ddlBRANCH.SelectedItem.Text
            ' prmDEPARTMENT.Value = ddlDepartment.SelectedItem.Text
            prmADDED_BY.Value = Session("UserCode")
            prmUPDATED_BY.Value = Session("UserCode")
            prmVALID_FROM.Value = txtFromDate.Text.Trim
            prmVALID_UPTO.Value = txtToDate.Text.Trim
            prmUSER_FULL_NAME.Value = txtUserFullName.Text.Trim

            If ChkBx_OpClk.Checked = True Then
                prmACCOUNT_STATUS.Value = "LOCKED"
            Else
                prmACCOUNT_STATUS.Value = "OPEN"
            End If

            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim su As String = "SELECT ISNULL(COUNT(*),0) FROM ADMIN_MAPS_USER_MASTER WHERE UPPER(USER_NAME)=@USER_NAME1"
            Dim csa As New SqlCommand(su, conn)

            Dim prmUSER_NAME1 As New SqlParameter("@USER_NAME1", SqlDbType.VarChar, 30)
            csa.Parameters.Add(prmUSER_NAME1)
            prmUSER_NAME1.Value = txtUSERNAME.Text.ToUpper.Trim

            Dim SRE As Integer
            SRE = csa.ExecuteScalar
            csa.Parameters.Clear()
            If txtUSERNAME.Text.Trim.Length = 0 Then
                lblMessage.Text = "User name can't be blank"
                MySetFocus(txtUSERNAME)
                Exit Sub
            End If

            Dim msg As String = abp.ValidateText(txtUSERNAME.Text, "USERNAME", 30)
            If msg <> "Y" Then
                Tell.text(msg, Me)
                txtUSERNAME.Text = ""
                MySetFocus(txtUSERNAME)
                Exit Sub
            End If

            If txtpASSWORD.Text.Trim.Length = 0 Then
                lblMessage.Text = "Password can't be blank"
                MySetFocus(txtpASSWORD)
                Exit Sub
            End If
            If txtpASSWORD.Text.Length < 8 Then
                txtpASSWORD.Text = ""
                lblMessage.Text = "Password must be min 8 characters"
                MySetFocus(txtpASSWORD)
                Exit Sub
            End If
            If txtUSERNAME.Text.Trim.ToUpper = txtpASSWORD.Text.ToUpper.Trim Then
                txtpASSWORD.Text = ""
                lblMessage.Text = "Password can't be same as user name"
                MySetFocus(txtpASSWORD)
                Exit Sub
            End If

            msg = abp.ValidateText(txtpASSWORD.Text, "PASSWORD", 50)
            If msg <> "Y" Then
                Tell.text(msg, Me)
                txtpASSWORD.Text = ""
                MySetFocus(txtpASSWORD)
                Exit Sub
            End If

            If txtUserFullName.Text.Trim.Length = 0 Then
                lblMessage.Text = "User full name can't be blank"
                MySetFocus(txtUserFullName)
                Exit Sub
            End If
            msg = abp.ValidateText(txtUserFullName.Text, "USER FULL NAME", 255)
            If msg <> "Y" Then
                Tell.text(msg, Me)
                txtUserFullName.Text = ""
                MySetFocus(txtUserFullName)
                Exit Sub
            End If


            msg = abp.ValidateToDate(txtToDate.Text, "To Date")
            If msg <> "Y" Then
                Tell.text(msg, Me)
                MySetFocus(txtToDate)
                Exit Sub
            End If

            'From date not less than Today
            If CDate(txtFromDate.Text) < Format(Now, "dd-MMM-yy") Then
                Tell.text("From Date should not be Less than today", Me)
                SetFocus(txtFromDate)
                txtFromDate.Text = ""
                Exit Sub
            End If

            'To date not Less than Today
            If CDate(txtToDate.Text) < Format(Now, "dd-MMM-yy") Then
                Tell.text("To Date should not be Less than today", Me)
                SetFocus(txtToDate)
                txtToDate.Text = ""
                Exit Sub
            End If

            'From date and To Date validation to Check From Date not Greater than To Date
            If CDate(txtFromDate.Text) > CDate(txtToDate.Text) Then
                Tell.text("from Date can not be grater than To Date", Me)
                txtFromDate.Text = ""
                SetFocus(txtFromDate)
                Exit Sub
            End If

            If SRE = 0 Then
                cmdInsert.ExecuteNonQuery()


                Dim cmd4 As SqlCommand
                cmd4 = New SqlCommand("insert into ADMIN_MAPS_GROUP_USER_MASTER values (@pUserId,@pFormId)", conn)
                Dim prmUserId As New SqlParameter("@pUserId", SqlDbType.Int, 4, "userid")
                Dim prmFormId As New SqlParameter("@pFormId", SqlDbType.Int, 4, "formid")

                cmd4.Parameters.Add(prmFormId)
                cmd4.Parameters.Add(prmUserId)

                prmUserId.Value = txtUSERID.Text

                prmFormId.Value = returngroupId(ddlGROUpID.SelectedItem.Text.ToUpper)
                cmd4.ExecuteNonQuery()


                Dim sqlQuery As String = "INSERT INTO ADMIN_USER_FORM_DETAIL  (FORMID, USERID) SELECT FORM_ID, @USERID FROM ADMIN_MAPS_GROUP_FORM_DETIALS WHERE GROUP_ID=@GID AND FORM_ID NOT IN (SELECT FORMID FROM ADMIN_USER_FORM_DETAIL WHERE USERID =@USERID)"
                Dim CMDi As New SqlCommand(sqlQuery, conn)
                Dim prmUID As New SqlParameter("@USERID", SqlDbType.Int, 4)
                Dim prmGROUPID As New SqlParameter("@GID", SqlDbType.Int, 4)
                prmGROUPID.Value = returngroupId(ddlGROUpID.SelectedItem.Value)
                CMDi.Parameters.Add(prmGROUPID)
                prmUID.Value = txtUSERID.Text.Trim + ""
                CMDi.Parameters.Add(prmUID)
                CMDi.ExecuteNonQuery()

                'FOR INITIALISE FOR PASS HISTORY
                'Dim CMDX As New SqlCommand("INSERT INTO ADMIN_MAPS_PASSWORD_HISTORY VALUES('1',SYSDATE,'',@NEW_PASSWORD,@USERID)", conn)
                Dim CMDX As New SqlCommand("INSERT INTO ADMIN_MAPS_PASSWORD_HISTORY VALUES('1',getdate(),EncryptByKey(Key_GUID('Key_Encript'),''),EncryptByKey(Key_GUID('Key_Encript'),@NEW_PASSWORD),@USERID)", conn)
                Dim prmUSID As New SqlParameter("@USERID", SqlDbType.VarChar, 30)
                Dim prmNEW_PASS As New SqlParameter("@NEW_PASSWORD", SqlDbType.VarChar)
                prmUSID.Value = txtUSERNAME.Text.Trim + ""
                CMDX.Parameters.Add(prmUSID)
                prmNEW_PASS.Value = txtpASSWORD.Text.Trim + ""
                CMDX.Parameters.Add(prmNEW_PASS)
                CMDX.ExecuteNonQuery()

                'FOR PASS_CHANGE RIGHTS TO USER
                'Dim CMDR As New SqlCommand("INSERT INTO ADMIN_USER_FORM_DETAIL VALUES(@USERID1,'1001')", conn)
                Dim CMDR As New SqlCommand("INSERT INTO ADMIN_USER_FORM_DETAIL VALUES(@USERID1,'5')", conn)
                Dim prmUSID1 As New SqlParameter("@USERID1", SqlDbType.Int)
                prmUSID1.Value = txtUSERID.Text.Trim + ""
                CMDR.Parameters.Add(prmUSID1)
                CMDR.ExecuteNonQuery()

                'FOR PASS_CHANGE RIGHTS TO USER
                Dim _CmdAULC As New SqlCommand("INSERT INTO ADMIN_USER_LOGIN_COUNT VALUES(@User_Name,'0','N')", conn)
                Dim prmUserName As New SqlParameter("@User_Name", SqlDbType.VarChar, 50)
                prmUserName.Value = txtUSERNAME.Text.Trim.ToUpper + ""
                _CmdAULC.Parameters.Add(prmUserName)
                _CmdAULC.ExecuteNonQuery()

                Tell.text("User Added Successfully", Me)

            Else
                lblMessage.Text = "User name already exists"
                Exit Sub
            End If
            If conn.State = ConnectionState.Open Then conn.Close()
            'conn.Dispose()
            conn.Close()
        End If
        Dim Adcls As New AdminClass
        Adcls.INSERT_INTO_TRAIL(txtUSERNAME.Text.Trim, Session("usercode"), "Enrollement" + ChkBx_OpClk.Text.Trim)
        lnkEdit.Enabled = True
        txtUSERID.Text = ""
        txtUSERNAME.Text = ""
        txtpASSWORD.Text = ""
        txtUserFullName.Text = ""
        lblMessage.Text = ""
        txtFromDate.Text = ""
        txtToDate.Text = ""
        ChkBx_OpClk.Checked = False
        ChkBx_OpClk.Text = "OPEN"
        lnkSave.Enabled = False
        bindgroup()
    End Sub
    'set focus control
    Private Sub MySetFocus(ByVal ctrl As Control)
        Dim str As String = "<script language=javascript>document.getElementById('" & ctrl.ClientID & "').focus()</script>"
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MySetFocus", str)
    End Sub
    Private Sub UpdateCorps(ByVal ARN As String)
        'Commented by Subhash Patil(C2196)
        'Dim cmdUpdateBranch As New SqlCommand
        'Dim strUpdateBranch As String = "update tmpmerchant set (ME_CORREF, ME_CORNAM, ME_PAYMENT) = (select corref,corpname,payment from STBLCORPNAME where corpcode= 	(select ME_CORCOD from tmpmerchant where app_req_no=@ARN)) where app_req_no=@ARN  "
        'Dim prmARN As New SqlParameter("@ARN", SqlDbType.VarChar, 20)
        'cmdUpdateBranch.Parameters.Add(prmARN)
        'prmARN.Value = ARN
        'cmdUpdateBranch.CommandText = strUpdateBranch
        'Dim d As New data
        'd.ExQuery(cmdUpdateBranch)
    End Sub
    'Displays Region Names 

    'POpulates group names into dropdownlist
    Private Sub bindgroup()
        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim qry As String = "SELECT '- -Select- -' GROUP_NAME union all SELECT upper(GROUP_NAME) FROM ADMIN_MAPS_GROUP_MASTER "
        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = qry
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        da.SelectCommand = cmd
        da.Fill(ds)
        ddlGROUpID.DataTextField = "GROUP_NAME"
        'ddlGROUpID.DataValueField = ""
        ddlGROUpID.DataSource = ds
        ddlGROUpID.DataBind()

    End Sub


    Private Function returngroupId(ByVal groupname As String) As Integer


        Dim prm As New SqlParameter("@grpname", SqlDbType.VarChar)
        Dim str = "select group_id from admin_maps_group_master where upper(group_name) = @grpname "
        Dim Mycmd As New SqlCommand(str, conn)
        Mycmd.Parameters.Add(prm)
        prm.Value = groupname
        Dim dr As SqlDataReader
        dr = Mycmd.ExecuteReader
        Dim id As Integer

        While (dr.Read)
            id = dr(0)
        End While

        dr.Close()
        Return id

    End Function


    'Displys Branch name according to region name

    'Event that generates new user id for new user addition
    Private Sub lnkEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkEdit.Click
        'Dim cs As New SqlCommand("SELECT MAX(USER_ID)+1 FROM ADMIN_MAPS_USER_MASTER ", conn)
        'If conn.State = ConnectionState.Closed Then conn.Open()
        'txtUSERID.Text = cs.ExecuteScalar

        Dim _r As New Random

        For index As Integer = 1 To 99999

            Dim _StrNo As String = ""
            Dim no As Integer = _r.Next(1, 99999)
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim cs As New SqlCommand("SELECT Count(1) FROM ADMIN_MAPS_USER_MASTER where User_ID In (@ran_num)", conn)
            Dim prm_Number As New SqlParameter("@ran_num", SqlDbType.VarChar, 6)
            prm_Number.Value = no
            cs.Parameters.Add(prm_Number)
            _StrNo = cs.ExecuteScalar

            If _StrNo = 0 Then

                txtUSERID.Text = no
                Exit For
            End If
        Next
        If conn.State = ConnectionState.Open Then conn.Close()


        txtFromDate.Text = Format(Now.Date, "dd-MMM-yy")
        txtToDate.Text = Format(Now.Date.AddDays(30), "dd-MMM-yy")
        lnkSave.Enabled = True
        LinkSave1.Enabled = True
        Session("EDITFLAG") = "TRUE"
        MySetFocus(txtUSERNAME)

    End Sub
    'To select From Date

    'Checking status of check box
    Private Sub ChkBx_OpClk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkBx_OpClk.CheckedChanged
        ChkBx_OpClk.Text = " "
        If ChkBx_OpClk.Checked = True Then
            ChkBx_OpClk.Text = "LOCK"
        Else
            ChkBx_OpClk.Text = "OPEN"
        End If
        ChkBx_OpClk.DataBind()
    End Sub
    'Event to go to Home Page
    'Bindig data to check Box
    Private Sub ChkBx_OpClk_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkBx_OpClk.DataBinding
        ChkBx_OpClk.Text = " "
        If ChkBx_OpClk.Checked = True Then
            ChkBx_OpClk.Text = "LOCK"
        Else
            ChkBx_OpClk.Text = "OPEN"
        End If
    End Sub
    'to populate branches according to region code

    Private Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Error
        Dim PhyFilePath As String = System.AppDomain.CurrentDomain.BaseDirectory
        Dim sUser As String = Session("UserCode")
        Dim sLastError As String = Server.GetLastError.Message.ToString
        Dim sStackTrace As String = Server.GetLastError.StackTrace.ToString
        acs.WriteError(sLastError, sStackTrace, sUser, PhyFilePath, "NPCI_Loyalty AddNewUsers")
    End Sub
    Protected Sub LinkSave1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkSave1.Click
        SaveNewUser()
    End Sub

    Protected Sub ddlGROUpID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlGROUpID.SelectedIndexChanged

    End Sub
End Class
'***********************************************************************************************************************
'End of <AddNewUsers>
'***********************************************************************************************************************



' if tagged='T' AND verify='V' THEN

'update ADIB_INVENTORY_MASTER set CASSETTE_STATUS= status,CASSETTE_VERIFIED=verify,VERIFIED_ON=sysdate,VERIFIED_BY=ucode,CASSETTE_TAGGED=tagged,
'TAGGED_ON=sysdate, TAGGED_BY=ucode,UPDATED_BY =ucode,UPDATED_ON=sysdate where CASSETTE_ID = cst_id;

'else if tagged='T' THEN

' update ADIB_INVENTORY_MASTER set CASSETTE_STATUS= status,CASSETTE_TAGGED=tagged,
' TAGGED_ON=sysdate, TAGGED_BY=ucode,UPDATED_BY =ucode,UPDATED_ON=sysdate where CASSETTE_ID = cst_id;

'  else IF verify='V' THEN

' update ADIB_INVENTORY_MASTER set CASSETTE_STATUS= status,CASSETTE_VERIFIED=verify,VERIFIED_ON=sysdate,VERIFIED_BY=ucode,
' UPDATED_BY =ucode,UPDATED_ON=sysdate where CASSETTE_ID = cst_id
