Imports System.Data.SqlClient
'Imports System.Windows.Forms.Clipboard
Imports System.Drawing
Imports System.Data


Partial Class MASTER_Query_Execution
    Inherits System.Web.UI.Page
    Dim I As Integer
    Dim Repo As New Reports
    Dim p As String = Server.MapPath("..\Master\Excel_Files\")
    Dim p_excel As String = Server.MapPath("..\Master\Excel_Files")
    Dim p_zip As String = Server.MapPath(" ") & "\Excel_Files\"
    Dim fileName As String
    'Dim C1 As System.Windows.Forms.Clipboard
    Dim sqlcon As New SqlConnection(ConfigurationSettings.AppSettings("ConnectionStringPORTAL"))
    'Dim oracon_central As New OracleConnection(ConfigurationSettings.AppSettings("ConnectionString60_Central"))
    'Dim oracon_Interchange As New OracleConnection(ConfigurationSettings.AppSettings("ConnectionStringB"))
    'Dim oracon_Merchant As New OracleConnection(ConfigurationSettings.AppSettings("ConnectionStringMerchant"))
    'Dim ora_portal As New OracleConnection(ConfigurationSettings.AppSettings("ConnectionStringPORTAL"))
    Dim sqlda As SqlDataAdapter
    Dim ds As New DataSet
    Dim acs As New HelperClass

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Put user code to initialize the page here
        lbl_datetime.Text = Format(Now.Date, "dd-MMM-yyyy")
        ' Session("UserCode") = "ADMIN"
        If Session("UserCode") = "" Then
            Response.Redirect("../master/index.aspx")
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
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        loadReport(0)
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Label1.Visible = False
        lnk_download.Visible = False
        Download_Excel_Btn.Visible = False
        TextBox2.Visible = False
        TextBox2.Text = ""
        Panel1.Visible = False
        Label8.Visible = False
    End Sub

    Protected Sub Download_Excel_Btn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Download_Excel_Btn.Click
        loadReport(1)
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_download.Click
        Dim filename As String
        If TextBox2.Text = "" Then
            fileName = "Noname"
        Else
            fileName = TextBox2.Text.ToUpper
        End If
        Dim filepath As String = p_zip & filename & "-" & Format(Now.Date, "dd-MMM-yy") & ".zip"
        Dim flname As New System.IO.FileInfo(filepath)
        Response.Clear()
        Response.AppendHeader("content-disposition", "attachment; filename=" + filename + ".zip")
        Response.WriteFile(flname.FullName)
        Response.End()
    End Sub

    Protected Sub DataGrid1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid1.PageIndexChanged
        DataGrid1.CurrentPageIndex = e.NewPageIndex
        loadReport(0)
    End Sub
    Private Sub loadReport(ByVal str As Integer)
        Try
            'DataGrid1.CurrentPageIndex = 0
            If TextBox1.Text = "" Then
                Label1.Text = "You must specify the SQL Statement before executing."
                Label1.ForeColor = Color.Red
                Label1.Visible = True
                Exit Sub
            Else
                'Dim Qstr As String
                'Qstr = TextBox1.Text.ToUpper.Trim
                'Qstr = Qstr.Replace(" FROM ", " FROM '" & DB_Combo.SelectedItem.Text & "'.")
                'If DB_DDL.SelectedItem.Text = "BOBRISK" Then
                '    oracon.Open()
                '    orada = New OracleDataAdapter(Trim(TextBox1.Text.ToUpper.Trim), oracon)
                '    orada.Fill(ds)
                'ElseIf DB_DDL.SelectedItem.Text = "CENTRAL" Then
                '    oracon_central.Open()
                '    orada = New OracleDataAdapter(Trim(TextBox1.Text.ToUpper.Trim), oracon_central)
                '    orada.Fill(ds)
                'ElseIf DB_DDL.SelectedItem.Text = "INTERCHANGE" Then
                '    oracon_Interchange.Open()
                '    orada = New OracleDataAdapter(Trim(TextBox1.Text.ToUpper.Trim), oracon_Interchange)
                '    orada.Fill(ds)
                'ElseIf DB_DDL.SelectedItem.Text = "MERCHANT" Then
                '    oracon_Merchant.Open()
                '    orada = New OracleDataAdapter(Trim(TextBox1.Text.ToUpper.Trim), oracon_Merchant)
                '    orada.Fill(ds)
                ' ElseIf DB_DDL.SelectedItem.Text = "PORTAL" Then
                'ora_portal.Open()
                sqlcon.Open()
                sqlda = New SqlDataAdapter(Trim(TextBox1.Text.ToUpper.Trim), sqlcon)
                sqlda.Fill(ds)
                'Else
                '    Label1.Text = "SELECT SOURCE DATABASE "
                'End If

                If ds.Tables(0).Rows.Count > 0 Then
                    Label1.Visible = True
                    Label1.Text = "Total Records : " & ds.Tables(0).Rows.Count
                    Label1.ForeColor = Color.Blue
                    DataGrid1.DataSource = ds
                    DataGrid1.DataBind()
                    Panel1.Visible = True
                    'fileName = "CHECK"
                    Download_Excel_Btn.Visible = True
                    TextBox2.Visible = True
                    Label8.Visible = True
                    If str = 1 Then
                        If TextBox2.Text = "" Then
                            fileName = "Noname"
                        Else
                            fileName = TextBox2.Text.ToUpper
                        End If
                        Repo.WriteToExcel_By_DS(ds, p, fileName)
                        Repo.create_zip(p_zip, fileName & "-" & Format(Now.Date, "dd-MMM-yy"), "*.xls")
                        Repo.deletedumpxl(p_zip, "*.xls")
                        lnk_download.Visible = True

                    End If

                Else
                    Label1.Visible = True
                    Label1.Text = "No Rows Returned."
                    DataGrid1.DataSource = Nothing
                    DataGrid1.DataBind()
                    Label1.ForeColor = Color.Blue
                    'excel_download.Visible = False
                    lnk_download.Visible = False
                    Download_Excel_Btn.Visible = False
                    TextBox2.Visible = False
                    Panel1.Visible = False
                End If
            End If
        Catch ex As Exception
            Label1.Visible = True
            Label1.Text = ex.Message
            Label1.ForeColor = Color.Red
            DataGrid1.DataSource = Nothing
            DataGrid1.DataBind()
        Finally
            sqlcon.Close()
        End Try
    End Sub
    Private Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Error
        Dim PhyFilePath As String = System.AppDomain.CurrentDomain.BaseDirectory
        Dim sUser As String = Session("UserCode")
        Dim sLastError As String = Server.GetLastError.Message.ToString
        Dim sStackTrace As String = Server.GetLastError.StackTrace.ToString
        acs.WriteError(sLastError, sStackTrace, sUser, PhyFilePath, "NPCI_Loyalty-Query Execution")
    End Sub

End Class
