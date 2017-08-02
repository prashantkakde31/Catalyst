Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Security.Cryptography

Partial Class Master_login
    Inherits System.Web.UI.Page
    Dim conn As New SqlConnection(ConfigurationManager.AppSettings("conn"))
    Public tmpUserid As String
    Public varUserCnt As Int16
    Public varUserCnt1 As Int16
    Dim DATA As New data
    Dim ADMINCLASS As New AdminClass
    Dim prmUser As New SqlParameter("@USERNAME", SqlDbType.VarChar)
    Dim prmPwd As New SqlParameter("@PWD", SqlDbType.VarChar)
    Dim prmHost As New SqlParameter("@HOST", SqlDbType.VarChar)
    Dim msg As String = ""
    Dim cmd As New SqlCommand
    Dim acs As New HelperClass

    Protected Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error
        Dim PhyFilePath As String = System.AppDomain.CurrentDomain.BaseDirectory
        Dim sUser As String = Session("UserCode")
        Dim sLastError As String = Server.GetLastError.Message.ToString
        Dim sStackTrace As String = Server.GetLastError.StackTrace.ToString
        acs.WriteError(sLastError, sStackTrace, sUser, PhyFilePath, "Catalyst.")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'acs.encryptConfig(True) ' encrypts the connection string in web config
        Response.Write("<script language=javascript>window.history.forward(1)</script>")
        Dim Username As TextBox = TryCast(Login.FindControl("Username"), TextBox)
        Dim password As TextBox = TryCast(Login.FindControl("Password"), TextBox)
        Username.Attributes.Add("onkeypress", "funAlphaNumeric();")
        Username.Attributes.Add("oncopy", "return false;")
        password.Attributes.Add("oncopy", "return false;")
        Username.Attributes.Add("onpaste", "return false;")
        password.Attributes.Add("onpaste", "return false;")
        Username.Attributes.Add("autocomplete", "off")
        password.Attributes.Add("autocomplete", "off")
        If Not Page.IsPostBack Then
            Session("loginAttempts") = 0
            Dim _Password As String = Context.Items("PasswordChange")
            If _Password = "PasswordChange" Then
                Tell.text("Password Has Been Changed. Please Login to Continue ", Me)
            End If
            Dim s As Guid
            s = Guid.NewGuid
            lblID.Value = s.ToString()
        End If
    End Sub
    ''' <summary>
    ''' Function Used for Generating random string (Added by Subhash Patil 11/11/2014)
    ''' </summary>
    ''' <param name="r"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function RandomString(ByVal r As Random) As String
        Dim s As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!@#$%^&*0123456789"
        Dim sb As StringBuilder = New StringBuilder
        Dim cnt As Integer = r.Next(15, 33)
        Dim i As Integer = 1
        Do While (i <= cnt)
            Dim idx As Integer = r.Next(0, s.Length)
            sb.Append(s.Substring(idx, 1))
            i = (i + 1)
        Loop
        Return sb.ToString
    End Function


    Private Function CreateSHA256Signature(ByVal RawData As String) As String
        Dim hasher As SHA256 = SHA256Managed.Create()
        Dim HashValue As Byte() = hasher.ComputeHash(Encoding.ASCII.GetBytes(RawData))
        Dim strHex As String = ""
        For Each b As Byte In HashValue
            strHex += b.ToString("x2")
        Next
        Return strHex
    End Function
    Protected Sub Login_Authenticate(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.AuthenticateEventArgs) Handles Login.Authenticate

        Dim _CountUser As Integer = 0
        Dim _CountValid As Integer = 0
        Dim _CountDur As String = ""

        'If Login.Password = CreateSHA256Signature("pass") Then
        '    Tell.text("Success", Me)
        'Else
        '    Tell.text("invalid", Me)
        'End If
        msg = acs.ValidateText(Login.UserName, "UserName", 100)
        If msg <> "Y" Then
            Tell.error(msg, Me)
            Login.UserName = ""
            Exit Sub
        End If

        msg = acs.ValidateText(Login.Password, "Password", 100)
        If msg <> "Y" Then
            Tell.error(msg, Me)
            Exit Sub
        End If


        'CHECK USER NAME

        cmd.CommandText = "SELECT COUNT(*) FROM ADMIN_MAPS_USER_MASTER WHERE UPPER(USER_NAME)=UPPER(@USERNAME)"
        cmd.Connection = conn
        cmd.Parameters.Add(prmUser)
        prmUser.Value = Login.UserName
        If conn.State = ConnectionState.Closed Then conn.Open()
        _CountUser = cmd.ExecuteScalar
        cmd.Parameters.Clear()
        conn.Close()

        If _CountUser < 1 Then
            Tell.error("Your user name or password is incorrect.", Me)
            Exit Sub
        End If

        'Start - 18-Mar-11 - Sunil - To check account status of User
        cmd.CommandText = "SELECT COUNT(*) FROM ADMIN_MAPS_USER_MASTER WHERE UPPER(USER_NAME)=UPPER(@USERNAME) AND (ACCOUNT_STATUS='LOCKED' OR BLOCKED='Y' OR DISABLED='Y' ) "
        cmd.Connection = conn
        cmd.Parameters.Add(prmUser)
        prmUser.Value = Login.UserName
        If conn.State = ConnectionState.Closed Then conn.Open()
        _CountUser = cmd.ExecuteScalar
        cmd.Parameters.Clear()
        conn.Close()

        If _CountUser > 0 Then
            Tell.error("Cannot login your Account is Locked , Blocked Or Disabled..!", Me)
            Exit Sub
        End If

        'Added by sonali
        cmd.CommandText = "SELECT COUNT(*) FROM ADMIN_MAPS_USER_MASTER WHERE UPPER(USER_NAME)=UPPER(@USERNAME) AND (VALID_UPTO < CAST(GETDATE() AS date))"
        cmd.Connection = conn
        cmd.Parameters.Add(prmUser)
        prmUser.Value = Login.UserName
        If conn.State = ConnectionState.Closed Then conn.Open()
        _CountValid = cmd.ExecuteScalar
        cmd.Parameters.Clear()
        conn.Close()

        If _CountValid > 0 Then
            Tell.error("Your Account is expired ..Please contact administrator..!", Me)
            Exit Sub
        End If

        'check password expiry


        'Added by Subhash Patil 10/11/2014
        Dim password As String = ""

        'Added by subhash to open key for encryption
        'cmd.CommandText = "openkeys"
        'cmd.Connection = conn
        'cmd.CommandType = CommandType.StoredProcedure
        'If conn.State = ConnectionState.Closed Then conn.Open()
        'cmd.ExecuteNonQuery()

        cmd.CommandText = "select user_password from admin_maps_user_master where  UPPER(USER_NAME)=UPPER(@USERNAME)"
        cmd.CommandType = CommandType.Text
        cmd.Parameters.Add(prmUser)
        prmUser.Value = Login.UserName
        If conn.State = ConnectionState.Closed Then conn.Open()
        password = cmd.ExecuteScalar
        cmd.Parameters.Clear()
        conn.Close()
        Dim tmp As String = CreateSHA256Signature(password & lblID.Value)

        If Login.Password = tmp Then
            _CountUser = 1

        Else
            _CountUser = 0
            ' Session("loginAttempts") = IncreaseLoginAttempt()
        End If

        If _CountUser < 1 Then
            Session("loginAttempts") = Session("loginAttempts") + 1

            If Session("loginAttempts") = 1 Then
                Tell.error("Your user name or password is incorrect.Account will be locked after 3 failure attempts.", Me)
            End If

            ''If Session("loginAttempts") = 2 Or Session("loginAttempts") = 3 Then
            ''    Tell.error("Your user ID or password is incorrect again.", Me)
            ''End If

            If Session("loginAttempts") = 2 Then
                Tell.error("Your user Name or password is incorrect again.Account will be locked if you enter wrong user Name or password again.", Me)
            End If

            If Session("loginAttempts") > 2 Then
                ADMINCLASS.INSERT_INTO_TRAIL(Login.UserName, "SYSADMIN", "LOCKED FOR FAILED LOGIN ATTEMPTS")
                'DATA.ExQuery("UPDATE ADMIN_MAPS_USER_MASTER SET ACCOUNT_STATUS='LOCKED' WHERE USER_NAME='" & Login.UserName & "'")
                cmd.CommandText = "UPDATE ADMIN_MAPS_USER_MASTER SET ACCOUNT_STATUS='LOCKED' WHERE UPPER(USER_NAME)=UPPER(@USERNAME)"
                cmd.Connection = conn
                cmd.Parameters.Add(prmUser)
                prmUser.Value = Login.UserName
                If conn.State = ConnectionState.Closed Then conn.Open()
                cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()
                conn.Close()

                Session("loginAttempts") = 0
                Tell.error("Your Account has been locked.Contact Administrator for unlocking the password", Me)
            End If
            Exit Sub
        End If

        '-----Added By Milan----------------
        '  To check Session State of respective user whether logged previously through other user
        'Dim USERCODE As String = Login.UserName
        'Dim flag As Boolean = Login_session(USERCODE)
        'If flag = False Then
        '    Tell.error("User is already Logged In OR Incorrectly Terminated Last Time. Please Try After Some Time.", Me)
        '    Exit Sub
        'End If

        'CHECK FIRST LOGIN 
        'cmd.CommandText = "SELECT COUNT(*) FROM ADMIN_USER_LOGIN_COUNT WHERE UPPER(USER_NAME)=UPPER(@USERNAME) AND CHANGED IN ('N','Y')"
        'cmd.Connection = conn
        'cmd.Parameters.Add(prmUser)
        'If conn.State = ConnectionState.Closed Then conn.Open()
        '_CountUser = cmd.ExecuteScalar
        'cmd.Parameters.Clear()
        'conn.Close()

        'If _CountUser > 0 Then
        '    Session("USERCODE") = Login.UserName.ToUpper
        '    Response.Redirect(acs.Admin_ChngePasswd(Request.Path),False)
        'End If


        'Insert Login time
        Dim _IndexNumber As Integer
        '_IndexNumber = DATA.ExScalar("SELECT NVL(MAX(INDEXNO)+1,0) FROM SESSION_TRACKING_LOG ")
        _IndexNumber = DATA.ExScalar("SELECT ISNULL(MAX(INDEXNO)+1,0) FROM SESSION_TRACKING_LOG ")
        '_IndexNumber = _IndexNumber + 1
        'DATA.ExQuery("INSERT INTO SESSION_TRACKING_LOG ( indexno,USERNAME, HOSTNAME, LOGINAT) VALUES ('" & _IndexNumber & "','" & Login.UserName & "','" & Request.UserHostName & "',sysdate)")

        'cmd.CommandText = "INSERT INTO SESSION_TRACKING_LOG ( indexno,USERNAME, HOSTNAME, LOGINAT) VALUES ('" & _IndexNumber & "',UPPER(@USERNAME),@HOST,sysdate)"
        cmd.CommandText = "INSERT INTO SESSION_TRACKING_LOG ( indexno,USERNAME, HOSTNAME, LOGINAT) VALUES (" & _IndexNumber & ",UPPER(@USERNAME),@HOST,getdate())"
        cmd.Parameters.Add(prmUser)
        cmd.Parameters.Add(prmHost)
        prmHost.Value = Request.UserHostName
        If conn.State = ConnectionState.Closed Then conn.Open()
        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        conn.Close()

        'Update login Count
        'DATA.ExQuery("UPDATE ADMIN_USER_LOGIN_COUNT SET LOGIN_COUNT = (SELECT MAX(NVL(LOGIN_COUNT,0))+1 FROM ADMIN_USER_LOGIN_COUNT WHERE USER_NAME='" & Login.UserName & "') WHERE USER_NAME='" & Login.UserName & "'")

        'cmd.CommandText = "UPDATE ADMIN_USER_LOGIN_COUNT SET LOGIN_COUNT = (SELECT MAX(NVL(LOGIN_COUNT,0))+1 FROM ADMIN_USER_LOGIN_COUNT WHERE UPPER(USER_NAME)=UPPER(@USERNAME)) WHERE UPPER(USER_NAME)=UPPER(@USERNAME)"/
        cmd.CommandText = "UPDATE ADMIN_USER_LOGIN_COUNT SET LOGIN_COUNT = (SELECT MAX(ISNULL(LOGIN_COUNT,0))+1 FROM ADMIN_USER_LOGIN_COUNT WHERE UPPER(USER_NAME)=UPPER(@USERNAME)) WHERE UPPER(USER_NAME)=UPPER(@USERNAME)"
        cmd.Parameters.Add(prmUser)
        If conn.State = ConnectionState.Closed Then conn.Open()
        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        conn.Close()

        'LOGIN SUCCESS

        If CHECKOUT() Then
            Session("Username") = Login.UserName.ToUpper
            'class1.add_db(TextBox1.Text, Session.SessionID)

            Dim hostname As String
            hostname = Request.UserHostName

            Dim cmd As New SqlCommand("insert into log values(@UserName,'" & hostname & "',getdate(),'','" & Session.SessionID & "','')", conn)
            cmd.Parameters.AddWithValue("UserName", Login.UserName.ToUpper)
            If conn.State = ConnectionState.Closed Then conn.Open()
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()

        Else
            Response.Write("<script language=javascript>alert('For Security Reason Please Close This Browser and open new window');window.close()</script>")
        End If


        Session("UserCode") = Login.UserName.ToUpper
        'THIRTY_DAYS()
        Dim cmd2 As New SqlCommand("select GROUP_ID from admin_maps_user_master where user_name=@UserName", conn)
        cmd2.Parameters.AddWithValue("UserName", Login.UserName.ToUpper)
        If conn.State = ConnectionState.Closed Then conn.Open()
        Session("GROUPID") = cmd2.ExecuteScalar
        cmd.Parameters.Clear()
        If conn.State = ConnectionState.Open Then conn.Close()
        Session("SelectedNode") = ""

        'RegenerateID();
        Response.Redirect(acs.Default_Page(Request.Path))

    End Sub

    Private Function CHECKOUT() As String
        Dim CON As New SqlClient.SqlConnection(ConfigurationManager.AppSettings.Item("conn"))
        Dim cmd As New SqlCommand
        Dim j As Int16
        If CON.State = ConnectionState.Closed Then
            CON.Open()
        End If
        'cmd.CommandText = "select count(*) from logdb where sessionid='" & Session.SessionID & "'"
        cmd.CommandText = "select count(*) from log where sessionid='" & Session.SessionID & "'"
        cmd.Connection = CON
        j = cmd.ExecuteScalar()
        CON.Close()
        If j <> 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    'Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
    '    Server.Transfer(acs.ForgotPassword_Page(Request.Path))
    'End Sub

    Protected Sub UserName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub UserName_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    'function for limiting session
    Protected Function Login_session(ByVal userName As String) As Boolean
        Dim d As System.Collections.Generic.List(Of String) = TryCast(Application("UsersLoggedIn"), System.Collections.Generic.List(Of String))
        If d IsNot Nothing Then
            SyncLock d
                If d.Contains(userName) Then
                    ' User is already logged in!!!
                    Return False
                End If
                d.Add(userName)
            End SyncLock
        End If
        Application("UserLoggedIn") = userName
        Return True
    End Function

    Private Sub THIRTY_DAYS()
        'Dim SQL1 As String = "SELECT round(NVL((PASSWORD_DATE+30) - SYSDATE  ,0) ) FROM ADMIN_MAPS_USER_MASTER WHERE UPPER(USER_NAME)= UPPER(@USERNAME) "
        Dim SQL1 As String = "SELECT DATEDIFF(DAY, GETDATE(), DATEADD(day, 30, PASSWORD_DATE)) AS dt_cnt FROM ADMIN_MAPS_USER_MASTER WHERE UPPER(USER_NAME)= UPPER(@USERNAME) "

        Dim prmUSERNAME As New SqlParameter("@USERNAME", SqlDbType.VarChar, 20)
        Dim SCMD As New SqlCommand(SQL1, conn)
        SCMD.Parameters.Add(prmUSERNAME)
        prmUSERNAME.Value = Login.UserName.ToUpper()
        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim SCOUNT As Long = SCMD.ExecuteScalar
        If SCOUNT = 2 Then
            Tell.error("YOUR PASSWORD WILL EXPIRE IN 2 DAYS", Me)
        End If
        If SCOUNT = 1 Then
            Tell.error("YOUR PASSWORD WILL EXPIRE IN 1 DAY", Me)
        End If
        If SCOUNT <= 0 Then
            Response.Redirect(acs.Admin_ChngePasswd(Request.Path))
        End If
        If conn.State = ConnectionState.Open Then conn.Close()
    End Sub


    Protected Sub RegenerateID()
        Dim manager
        Dim oldId As String
        Dim newId As String
        Dim isRedir As Boolean
        Dim isAdd As Boolean
        Dim ctx As HttpApplication
        Dim mods As HttpModuleCollection
        Dim ssm As System.Web.SessionState.SessionStateModule
        Dim fields() As System.Reflection.FieldInfo
        Dim rqIdField As System.Reflection.FieldInfo
        Dim rqLockIdField As System.Reflection.FieldInfo
        Dim rqStateNotFoundField As System.Reflection.FieldInfo
        Dim store As SessionStateStoreProviderBase
        Dim field As System.Reflection.FieldInfo
        Dim lockId
        manager = New System.Web.SessionState.SessionIDManager
        oldId = manager.GetSessionID(Context)
        newId = manager.CreateSessionID(Context)
        manager.SaveSessionID(Context, newId, isRedir, isAdd)
        ctx = HttpContext.Current.ApplicationInstance
        mods = ctx.Modules
        ssm = CType(mods.Get("Session"), System.Web.SessionState.SessionStateModule)
        fields = ssm.GetType.GetFields(System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Instance)
        store = Nothing : rqLockIdField = Nothing : rqIdField = Nothing : rqStateNotFoundField = Nothing
        For Each field In fields
            If (field.Name.Equals("_store")) Then store = CType(field.GetValue(ssm), SessionStateStoreProviderBase)
            If (field.Name.Equals("_rqId")) Then rqIdField = field
            If (field.Name.Equals("_rqLockId")) Then rqLockIdField = field
            If (field.Name.Equals("_rqSessionStateNotFound")) Then rqStateNotFoundField = field
        Next
        lockId = rqLockIdField.GetValue(ssm)
        If ((Not IsNothing(lockId)) And (Not IsNothing(oldId))) Then store.ReleaseItemExclusive(Context, oldId, lockId)
        rqStateNotFoundField.SetValue(ssm, True)
        rqIdField.SetValue(ssm, newId)

    End Sub
End Class
