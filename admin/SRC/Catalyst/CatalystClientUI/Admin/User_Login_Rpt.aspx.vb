'***********************************************************************************************************************                                  
' File Name            : <User_Login_Rpt>
' Location             : In-Solutions Global Pvt. Ltd., Malad                               
' Author               : Unknown 
' PADss Created        : <SUNIL PUNDPAL>, Emp. No: <C967>
' Date of Creation     : 
' PADss Date           : <17-Jul-12>
' Description          : Generating User Login report
'***********************************************************************************************************************

Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class ADMIN_User_Login_Rpt
    Inherits System.Web.UI.Page
    Dim cmd As New SqlCommand
    Dim cmd1 As New SqlCommand
    Dim da As New SqlDataAdapter
    Dim da1 As New SqlDataAdapter
    Dim ds As New DataSet
    Dim ds1 As New DataSet
    Dim acs As New HelperClass
    Dim _AdminClass As New AdminClass
    Dim msg As String
    Dim strQry1 As String = " SELECT USERNAME , LOGINAT ,LOGOUTAT  FROM SESSION_TRACKING_LOG  WHERE 1=1 "
    Dim conn As New System.Data.SqlClient.SqlConnection(ConfigurationManager.AppSettings("ConnectionStringPORTAL"))

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txt_username.Attributes.Add("onkeypress", "funAlphaNumeric();")
        If Session("UserCode") = "" Then
            Response.Redirect("../Master/index.aspx")
        End If

        If Not Page.IsPostBack Then
            '   To Check User Rights
            Dim strchk As String = acs.CheckSession(Session("UserCode"), System.IO.Path.GetFileName(Request.PhysicalPath))
            If strchk = "INVALID" Then
                Session("HomeFlag") = "N"
                Session("UserCode") = ""
                Response.Redirect("../Master/index.aspx")
            End If
        End If

        txt_username.Attributes.Add("onkeypress", "funAlphaNumeric();")
        Response.Write("<script language=javascript>window.history.forward(1)</script>")
    End Sub
   
    Private Sub MySetFocus(ByVal ctrl As Control)
        'set focus control
        Dim str As String = "<script language=javascript>document.getElementById('" & ctrl.ClientID & "').focus()</script>"
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "MySetFocus", str)
    End Sub

    'To display data in datgrid
    Private Sub lnkBtnVwDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkBtnVwDet.Click
        DataGrid1.PageIndex = 0
        LoadReport(0)
    End Sub
    'Populates data into datagrid and generate excel according to condition
    Private Sub LoadReport(ByVal a As Integer)
        Dim prmFromDate As New SqlParameter("FromDate", SqlDbType.DateTime)
        Dim prmToDate As New SqlParameter("ToDate", SqlDbType.DateTime)
        Dim strQry As String = ""

        If txt_username.Text.Trim = "" And txtFromDate.Text.Trim = "" And txtToDate.Text.Trim = "" Then
            Tell.text("Please enter username or fromdate todate", Me)
            Exit Sub
        End If

        '   From date To Date Validation...
        If txtFromDate.Text.Trim <> "" And txtToDate.Text.Trim <> "" Then
            msg = acs.ValidateFromDateToDate(txtFromDate.Text, txtToDate.Text)
            If msg <> "Y" Then
                If msg.IndexOf("From") > -1 Then
                    txtFromDate.Text = ""
                    SetFocus(txtFromDate)
                End If
                If msg.IndexOf("To") > -1 Then
                    txtToDate.Text = ""
                    SetFocus(txtToDate)
                End If
                Tell.text(msg, Me)
                pnl_id.Visible = False
                ExportLinkButton1.Visible = False
                Exit Sub
            End If

            strQry = strQry & " and LOGINAT between @fromdate and @todate "
            prmFromDate.Value = txtFromDate.Text.Trim
            prmToDate.Value = txtToDate.Text.Trim
            cmd.Parameters.Add(prmFromDate)
            cmd.Parameters.Add(prmToDate)
            cmd.CommandText = strQry1 & strQry & " order by  LOGINAT DESC "

        ElseIf txtFromDate.Text.Trim = "" And txtToDate.Text.Trim <> "" Then
            Tell.text("Please enter From date..", Me)
            pnl_id.Visible = False
            Exit Sub
        ElseIf txtToDate.Text.Trim = "" And txtFromDate.Text.Trim <> "" Then
            Tell.text("Please enter To date..", Me)
            pnl_id.Visible = False
            Exit Sub
        End If

        '   User Name Validation....
        If txt_username.Text.Trim <> "" Then
            If Mecode_validate() < 1 Then
                Tell.text("Invalid merchant!!!!!", Me)
                txt_username.Text = ""
                pnl_id.Visible = False
                ExportLinkButton1.Visible = False
                Exit Sub
            End If

            cmd.CommandText = strQry1 & strQry & " AND upper(USERNAME)= @UserName "
            cmd.Parameters.AddWithValue("UserName", txt_username.Text.Trim.ToUpper)
        End If
        
        cmd.Connection = conn
        da.SelectCommand = cmd
        da.Fill(ds)
        cmd.Parameters.Clear()

        If ds.Tables(0).Rows.Count > 0 Then
            DataGrid1.DataSource = ds
            DataGrid1.DataBind()
            DataGrid1.Visible = True
            generateExcel(ds)
            ExportLinkButton1.Visible = True
            pnl_id.Visible = True
        Else
            Tell.text("No data found", Me)
            DataGrid1.Visible = False
            pnl_id.Visible = False
            ExportLinkButton1.Visible = False
        End If

        If conn.State = ConnectionState.Open Then conn.Close()
    End Sub
    Private Function Mecode_validate() As Integer

        Dim Cmd_ As New SqlCommand
        'cmd.CommandText = "SELECT count(1) FROM ADMIN_MAPS_USER_MASTER WHERE upper(USER_NAME)='" + txt_username.Text.Trim.ToUpper + "'"
        Cmd_.CommandText = "SELECT count(1) FROM ADMIN_MAPS_USER_MASTER WHERE upper(USER_NAME)= @UserName"
        Cmd_.Parameters.AddWithValue("UserName", txt_username.Text.Trim.ToUpper)

        Cmd_.Connection = conn
        Cmd_.CommandType = CommandType.Text

        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim cnt As Integer = Cmd_.ExecuteScalar()
        Cmd_.Parameters.Clear()
        Return cnt
    End Function

    Private Sub clear()
        txt_username.Text = ""
        txtFromDate.Text = ""
        txtToDate.Text = ""
        ExportLinkButton1.Visible = False
        pnl_id.Visible = False
    End Sub
    
    Private Sub generateExcel(ByVal ds As DataSet)
        ExportLinkButton1.DataBind()
        ExportLinkButton1.Dataview = ds.Tables(0).DefaultView
        ExportLinkButton1.FileNameToExport = "ADMIN" + Format(Now.Date, "ddMM") + ".xls"
        ExportLinkButton1.ExportType = PNayak.Web.UI.WebControls.ExportButton.ExportTypeEnum.Excel
        ExportLinkButton1.Separator = PNayak.Web.UI.WebControls.ExportButton.SeparatorTypeEnum.TAB
    End Sub

    ''Go to selected page of datagrid
    'Private Sub DataGrid1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid1.PageIndexChanged

    'End Sub

    Private Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Error
        Dim PhyFilePath As String = System.AppDomain.CurrentDomain.BaseDirectory
        Dim sUser As String = Session("UserCode")
        Dim sLastError As String = Server.GetLastError.Message.ToString
        Dim sStackTrace As String = Server.GetLastError.StackTrace.ToString
        acs.WriteError(sLastError, sStackTrace, sUser, PhyFilePath, "Catalyst. User Login Report")
    End Sub

    Protected Sub lnk_reset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_reset.Click
        txt_username.Text = ""
        txtFromDate.Text = ""
        txtToDate.Text = ""
        ExportLinkButton1.Visible = False
        DataGrid1.Visible = False
        pnl_id.Visible = False
    End Sub

    Protected Sub DataGrid1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles DataGrid1.PageIndexChanging
        DataGrid1.PageIndex = e.NewPageIndex
        LoadReport(0)
    End Sub
End Class
