Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Mail

Partial Class MASTER_Forgot_Password
    Inherits System.Web.UI.Page
    Dim conn As New SqlConnection(ConfigurationManager.AppSettings("conn"))
    Dim acs As New HelperClass
    Dim cmd As New SqlCommand
    Dim prmUser As New SqlParameter("USERNAME", SqlDbType.VarChar)
    Dim str_email As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
  
    Private Function check_user(ByVal Username As String) As String
        Dim _count As Integer
        Dim cmd As New SqlCommand("SELECT COUNT (*)  " & _
                                    "  FROM admin_maps_user_master" & _
                                    " WHERE Ltrim(Rtrim(User_name)) =UPPER(@USERNAME)", conn)
        cmd.Parameters.Add(prmUser)
        prmUser.Value = Username
        If conn.State = ConnectionState.Closed Then conn.Open()
        _count = cmd.ExecuteScalar
        cmd.Parameters.Clear()
        conn.Close()
        Return _count
    End Function
    Protected Sub btn_frgtpswd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_frgtpswd.Click
        Dim msg As String

        Dim prmUserId As New SqlParameter("User_ID", SqlDbType.VarChar)
        If txt_mid.Text.Trim = "" Then
            Tell.text("Please enter your User Name...", Me)
            Exit Sub
        End If
        If check_user(txt_mid.Text.Trim) < 1 Then
            Tell.text("Please enter proper username.!!", Me)
            txt_mid.Text = ""
            Exit Sub
        End If

        msg = acs.ValidateText(txt_mid.Text.Trim, "User Name", 100)
        If msg <> "Y" Then
            Tell.text(msg, Me)
            txt_mid.Text = ""
            Exit Sub
        End If

       
        Dim retriveEmail As String = "Select top 1 email_id from admin_maps_user_master where  UPPER(Ltrim(Rtrim(User_name))) =UPPER(Ltrim(Rtrim(@User_ID))) "
        Dim cmd As New SqlCommand(retriveEmail, conn)
        cmd.Parameters.Add(prmUserId)
        prmUserId.Value = txt_mid.Text
        Dim dr As SqlDataReader

        If conn.State = ConnectionState.Closed Then conn.Open()
        dr = cmd.ExecuteReader

        If dr.HasRows = False Then
            Tell.text("No corresponding email found ", Me)
            Exit Sub
        End If
        While (dr.Read)
            str_email = dr("EMAIL_ID")
        End While
        conn.Close()
        cmd.Parameters.Clear()
        'msg = acs.multiEmail(str_email)
        If msg <> "Y" Then
            Tell.text(msg, Me)
            Exit Sub
        End If

       
        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim lck As String = "select count(*) from admin_maps_user_master where account_status='LOCKED' and UPPER(user_name)=UPPER(@User_ID)"
        cmd.CommandText = lck
        cmd.CommandType = CommandType.Text
        cmd.Connection = conn
        cmd.Parameters.Add(prmUserId)
        prmUserId.Value = txt_mid.Text.Trim
        Dim cnt0 As String = cmd.ExecuteScalar
        cmd.Parameters.Clear()
        If cnt0 > 0 Then
            Tell.text("Your account is locked. Please contact Catalyst. customer care for unlocking your account", Me)
            Exit Sub
        End If
        Dim str_chk As String = "select count(*) from admin_maps_user_master where user_name=@User_ID "
        cmd.CommandText = str_chk
        cmd.CommandType = CommandType.Text
        cmd.Connection = conn
        cmd.Parameters.Add(prmUserId)
        prmUserId.Value = txt_mid.Text.Trim
        Dim cnt As String = cmd.ExecuteScalar
        cmd.Parameters.Clear()
        If conn.State = ConnectionState.Open Then conn.Close()
        If cnt > 0 Then
            If conn.State = ConnectionState.Closed Then conn.Open()
            cmd.Parameters.Clear()
            Dim Pass As String = PasswordGenerator(8)
            Dim prmPswd As New SqlParameter("PWD", SqlDbType.VarChar)
            Dim StrUpdate As String = "UPDATE ADMIN_MAPS_USER_MASTER  " & _
                               "SET user_password = @PWD " & _
                               "WHERE UPPER(user_name) = UPPER(@User_ID) "
            Dim cmdUpdate As New SqlCommand(StrUpdate, conn)
            cmdUpdate.Parameters.Add(prmUserId)
            cmdUpdate.Parameters.Add(prmPswd)
            prmPswd.Value = Pass
            prmUserId.Value = txt_mid.Text.Trim
            cmdUpdate.ExecuteNonQuery()
            cmdUpdate.Parameters.Clear()
            Dim login_updte As String = "update ADMIN_USER_LOGIN_COUNT SET Changed='N' where UPPER(user_name) = UPPER(@User_ID) "
            Dim loginUpdate As New SqlCommand(login_updte, conn)
            loginUpdate.Parameters.Add(prmUserId)
            prmUserId.Value = txt_mid.Text.Trim
            loginUpdate.ExecuteNonQuery()
            SendMail(str_email, Pass, txt_mid.Text.Trim)
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "message", "alert('Your password has been sent to your registered email address...');location.href = '../MASTER/index.aspx';", True)

            Session.Clear()
            Session.Abandon()
            Session.RemoveAll()
            If Request.Cookies("ASP.NET_SessionId") IsNot Nothing Then
                Response.Cookies("ASP.NET_SessionId").Value = String.Empty
                Response.Cookies("ASP.NET_SessionId").Expires = DateTime.Now.AddMonths(-20)
            End If
            Response.Cookies.Clear()

        End If

        If conn.State = ConnectionState.Open Then conn.Close()

        txt_mid.Text = ""
        'Server.Transfer("~\master\Index.aspx")

    End Sub
    Public Function PasswordGenerator(ByVal lngLength As Long) As String
        On Error GoTo Err_Proc

        Dim iChr As Integer
        Dim c As Long
        Dim strResult As String = ""
        Dim iAsc As String


        For c = 1 To lngLength
            ' Randomly decide what set of ASCII chars we will use
            iAsc = Int(3 * Rnd() + 1)

            'Randomly pick a char from the random set
            Select Case iAsc
                Case 1
                    iChr = Int((Asc("Z") - Asc("A") + 1) * Rnd() + Asc("A"))
                Case 2
                    iChr = Int((Asc("z") - Asc("a") + 1) * Rnd() + Asc("a"))
                Case 3
                    iChr = Int((Asc("9") - Asc("0") + 1) * Rnd() + Asc("0"))
                Case Else
                    Err.Raise(20000, , "PasswordGenerator has a problem.")
            End Select

            strResult = strResult & Chr(iChr)

        Next c

        PasswordGenerator = strResult


Exit_Proc:
        Exit Function

Err_Proc:

        PasswordGenerator = vbNullString
        Resume Exit_Proc

    End Function
    Private Function SendMail(ByVal Emailids As String, ByVal pass As String, ByVal login As String) As String
        Dim msg As New MailMessage()
        msg.Subject = "User Password Reset Catalyst. Management"
        msg.From = "Vcare@insolutionsglobal.com"
        msg.To = Emailids
        msg.Body = "<b>" & "Dear Merchant," & "</b>" & "<br>" & "<br>"
        msg.Body = msg.Body & "Your user password for Catalyst. Management Frontend Login have been Reset as" & "<br>" & "<br>"
        msg.Body = msg.Body & "USERNAME:  " & login & "<br>"
        msg.Body = msg.Body & "PWD:  " & pass & "<br>" & "<br>"
        msg.Body = msg.Body & " Please access below link to login " & "<br>"
        msg.Body = msg.Body & "<U>" & "<h>" & "<href>" & "https://192.168.171.38:443/NPCI_Loyalty/master/index.aspx" & "</h>" & "</href>" & "</U>" & "<br>" & "<br>"
        msg.Body = msg.Body & "<b>" & "Thanks & Regards" & "<br>"
        msg.Body = msg.Body & "Admin" & "<br>" & "<br>" & "</b>"
        msg.BodyFormat = MailFormat.Html
        SmtpMail.SmtpServer = "192.168.22.22"
        SmtpMail.Send(msg)
        msg.Attachments.Clear()
        Return 0
    End Function
    Protected Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error
        Dim PhyFilePath As String = System.AppDomain.CurrentDomain.BaseDirectory
        Dim sUser As String = Session("UserCode")
        Dim sLastError As String = Server.GetLastError.Message.ToString
        Dim sStackTrace As String = Server.GetLastError.StackTrace.ToString
        acs.WriteError(sLastError, "", sUser, PhyFilePath, "Merchant Web Services")
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Server.Transfer(acs.mapLink(Request.Path))
        'Response.Redirect(acs.mapLink(Request.Path))
    End Sub
End Class


