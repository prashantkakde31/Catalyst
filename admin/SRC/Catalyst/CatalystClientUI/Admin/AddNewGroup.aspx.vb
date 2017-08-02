'**********************************************************************************************************************                                     
' File Name            : <AddNewGroup>
' Location             : In-Solutions Global Pvt. Ltd., Malad                               
' Author               : UNKNOWN 
' PADss Created        : <Sonali Mayekar>, Emp. No: <C1194>
' Date of Creation     : 
' PADss Date           : <10-09-12>
' Description          : ADDITION OF NEW GROUP
'*********************************************************************************************************************** 
Imports System
Imports System.Data

Imports System.Data.SqlClient

Partial Class admin_AddNewGroup
    Inherits System.Web.UI.Page
    Dim conn As New System.Data.SqlClient.SqlConnection(ConfigurationManager.AppSettings("conn"))
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

        'Session("UserCode") = "ADMIN"
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
        End If
        Response.Write("<script language=javascript>window.history.forward(1)</script>")
    End Sub
    Private Sub lnkSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkSave.Click
        Dim rep As New Reports
        If Session("EDITFLAG") = "TRUE" Then
            Dim cmdInsert As New SQLCommand
            cmdInsert.CommandText = "INSERT INTO ADMIN_MAPS_GROUP_MASTER ( GROUP_ID ,  GROUP_NAME, DESCRIPTION ) VALUES ( @GROUP_ID,  @GROUP_NAME, @DESCRIPTION)"
            cmdInsert.Connection = conn
            Dim prmGROUP_ID As New SqlParameter("GROUP_ID", SqlDbType.Int, 6)
            Dim prmGROUP_NAME As New SqlParameter("GROUP_NAME", SqlDbType.Char, 30)
            Dim prmDESCRIPTION As New SqlParameter("DESCRIPTION", SqlDbType.Char, 255)
            Dim prmREGION_NAME As New SqlParameter("REGION_NAME", SqlDbType.Char, 30)

            cmdInsert.Parameters.Add(prmGROUP_ID)
            cmdInsert.Parameters.Add(prmGROUP_NAME)
            cmdInsert.Parameters.Add(prmDESCRIPTION)
            prmGROUP_ID.Value = txtGROUPID.Text

            Dim cd As New HelperClass
            Dim msg As String = cd.ValidateText(txtGROUPNAME.Text, "Group Name", 50)
            If msg <> "Y" Then
                Tell.text(msg, Me)
                txtGROUPNAME.Text = ""
                txtDESCRIPTION.Text = ""
                MySetFocus(txtGROUPNAME)
                Exit Sub
            Else
                prmGROUP_NAME.Value = txtGROUPNAME.Text
            End If
            msg = cd.ValidateText(txtDESCRIPTION.Text, "Group Description", 255)
            If msg <> "Y" Then
                Tell.text(msg, Me)
                txtGROUPNAME.Text = ""
                txtDESCRIPTION.Text = ""
                MySetFocus(txtDESCRIPTION)
                Exit Sub
            Else
                prmDESCRIPTION.Value = txtDESCRIPTION.Text
            End If
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim su As String = "SELECT isnull(COUNT(*),0) FROM ADMIN_MAPS_GROUP_MASTER WHERE rtrim(ltrim(upper(GROUP_NAME)))=UPPER(@GPNAME)"
            Dim csa As New SQLCommand(su, conn)
            Dim prmgpname As New SQLParameter("GPNAME", SqlDbType.VarChar, 50)
            csa.Parameters.Add(prmgpname)
            prmgpname.Value = txtGROUPNAME.Text.ToUpper.Trim
            Dim SRE As Integer = csa.ExecuteScalar
            If txtGROUPNAME.Text.Trim.Length = 0 Then
                Tell.text("GROUP NAME CAN'T BE BLANK", Me)
                MySetFocus(txtGROUPNAME)
                Exit Sub
            End If
            If SRE = 0 Then
                cmdInsert.ExecuteNonQuery()
            Else
                Tell.text("GROUP NAME ALREADY EXISTS", Me)
                Exit Sub
            End If
            If conn.State = ConnectionState.Open Then conn.Close()
            cmdInsert.Dispose()
        End If
        Dim Adcls As New AdminClass
        Adcls.INSERT_INTO_TRAIL(txtGROUPNAME.Text.Trim, Session("usercode"), "NEW GROUP")
        lnkEdit.Enabled = True
        txtGROUPID.Text = ""
        txtGROUPNAME.Text = ""
        txtDESCRIPTION.Text = ""
        lnkSave.Enabled = False
        Tell.text("Group Created Sucessfully", Me)
        MySetFocus(lnkEdit)
    End Sub
    Private Sub MySetFocus(ByVal ctrl As Control)
        Dim str As String = "<script language=javascript>document.getElementById('" & ctrl.ClientID & "').focus()</script>"
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MySetFocus", str)
    End Sub
    Private Sub lnkEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkEdit.Click
        Dim cs As New SqlCommand("SELECT isnull(MAX(GROUP_ID),0)+1 FROM ADMIN_MAPS_GROUP_MASTER ", conn)
        If conn.State = ConnectionState.Closed Then conn.Open()
        txtGROUPID.Text = cs.ExecuteScalar
        txtGROUPNAME.Text = ""
        txtDESCRIPTION.Text = ""
        lnkSave.Enabled = True
        Session("EDITFLAG") = "TRUE"
        MySetFocus(txtGROUPNAME)
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Dispose()
    End Sub

    Private Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Error
        Dim PhyFilePath As String = System.AppDomain.CurrentDomain.BaseDirectory
        Dim sUser As String = Session("UserCode")
        Dim sLastError As String = Server.GetLastError.Message.ToString
        Dim sStackTrace As String = Server.GetLastError.StackTrace.ToString
        acs.WriteError(sLastError, sStackTrace, sUser, PhyFilePath, "NPCI_Loyalty-AddNewGroup")
    End Sub
End Class

'***********************************************************************************************************************
'End of <AddNewGroup>
'***********************************************************************************************************************