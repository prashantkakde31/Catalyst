<%@ Page Language="VB" MasterPageFile="~/MASTER/MasterPage2.master" AutoEventWireup="false"
    CodeFile="User_Login_Rpt.aspx.vb" Inherits="ADMIN_User_Login_Rpt" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="pnwc" Namespace="PNayak.Web.UI.WebControls" Assembly="PNayak.Web.UI.WebControls.ExportButton" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    <script type="text/javascript">
        $(function () {
            $("#ctl00_ContentPlaceHolder1_txtFromDate").datepicker(
                        {
                            dateFormat: "dd-M-y",
                            showButtonPanel: true,
                            changeMonth: true,
                            changeYear: true,
                            showOn: "button",
                            buttonImage: "../MASTER/Images/SmallCalendar.gif",
                            buttonImageOnly: true
                        });

            $("#ctl00_ContentPlaceHolder1_txtToDate").datepicker(
                        { dateFormat: "dd-M-y",
                            showButtonPanel: true,
                            changeMonth: true,
                            changeYear: true,
                            showOn: "button",
                            buttonImage: "../MASTER/Images/SmallCalendar.gif",
                            buttonImageOnly: true
                        });
        });
    </script>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <table>
        <tr>
            <td align="center" colspan="4">
                <asp:Label runat="server" ID="Label10" Font-Bold="True" Font-Size="X-Large" ForeColor="#0066FF">User Login Report</asp:Label>
            </td>
        </tr>
        <%--<tr class="maroonbar">
    <td style="height:20px; text-align: left;" align="center" colspan="3" class="white">
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:label id="MainLabel" 
                runat="server" style="font-weight: 700">User Report Screen </asp:label>
				    </td>
    </tr>--%>
        <tr>
            <td style="width: 127px">
                &nbsp;</td>
            <td style="height: 28px;" align="center" colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 127px">
            </td>
            <td style="width: 120px; height: 28px;">
                <asp:Label ID="Label3" runat="server" Width="80px" Font-Bold="True" CssClass="Label"
                    ForeColor="#204673">User Name</asp:Label>
            </td>
            <td style="width: 180px; height: 28px;">
                &nbsp;<asp:TextBox ID="txt_username" runat="server" CssClass="TextBox"></asp:TextBox>
            </td>
            <td style="width: 400px; height: 28px;" width="100px">
            </td>
        </tr>
        <tr>
            <td style="width: 127px">
            </td>
            <td style="width: 120px; height: 28px;">
                <asp:Label ID="Label2" runat="server" Width="80px" runat="server" Font-Bold="True"
                    CssClass="Label" ForeColor="#204673">From 
        Date</asp:Label>
            </td>
            <td style="width: 180px; height: 28px;">
                &nbsp;<asp:TextBox ID="txtFromDate" TabIndex="1" runat="server" Height="20px" Width="70px"
                    CssClass="TextBox" MaxLength="9"></asp:TextBox>
                &nbsp;<asp:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" Enabled="True"
                    PopupButtonID="lnkFromDate" Format="dd-MMM-yy" TargetControlID="txtFromDate">
                </asp:CalendarExtender>
                <asp:ImageButton ID="lnkFromDate" Format="dd-MMM-yyyy" TabIndex="2" runat="server"
                    ImageUrl="~/MASTER/Images/calendar.gif" Style="height: 16px"></asp:ImageButton>
            </td>
            <td style="width: 400px;" rowspan="2" valign="top" width="100px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 127px">
            </td>
            <td style="width: 120px; height: 28px;">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" CssClass="Label" ForeColor="#204673">To Date</asp:Label>
            </td>
            <td style="width: 180px; height: 28px;">
                &nbsp;<asp:TextBox ID="txtToDate" TabIndex="3" runat="server" Height="20px" Width="70px"
                    CssClass="TextBox" MaxLength="9"></asp:TextBox>
                &nbsp;<asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                    PopupButtonID="ImageButton1" Format="dd-MMM-yy" TargetControlID="txtToDate">
                </asp:CalendarExtender>
                <asp:ImageButton ID="ImageButton1" Format="dd-MMM-yyyy" TabIndex="2" runat="server"
                    ImageUrl="~/MASTER/Images/calendar.gif" Style="height: 16px"></asp:ImageButton>
            </td>
        </tr>
        <tr>
            <td style="width: 127px; height: 30px;">
                &nbsp;
            </td>
            <td style="height: 30px;" colspan="2">
                &nbsp;<asp:LinkButton ID="lnkBtnVwDet" runat="server" Font-Bold="True" ForeColor="black"
                    Font-Underline="True" Font-Size="X-Small" Font-Names="Verdana">View Detail</asp:LinkButton>&nbsp;<pnwc:ExportLinkButton
                        ID="ExportLinkButton1" runat="server" Font-Bold="True" ForeColor="black" Font-Underline="True"
                        Font-Size="X-Small" Font-Names="Verdana" Separator="TAB" Visible="False">&nbsp;Download Excel</pnwc:ExportLinkButton>
                &nbsp;<asp:LinkButton ID="lnk_reset" runat="server" Font-Bold="True" Font-Size="X-Small"
                    ForeColor="Black" Font-Names="Verdana">Reset</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style="height: 200px;" colspan="3">
                <asp:Panel runat="server" ID="pnl_id" ScrollBars="Horizontal" Visible="False" Width="700px">
                    <asp:GridView ID="DataGrid1" runat="server" AllowPaging="True" CellPadding="3" CssClass="DDGridView"
                        Width="100%">
                        <RowStyle HorizontalAlign="Center" />
                        <PagerStyle CssClass="DDPager" />
                        <HeaderStyle CssClass="DDLightHeader" />
                        <AlternatingRowStyle CssClass="Alternate_Row" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="height: 30px;" colspan="3">
                <asp:Label ID="lblGroup" runat="server" Width="89px" Visible="False" CssClass="Label"
                    Font-Bold="False">Group Name</asp:Label>
                &nbsp;<asp:DropDownList ID="ddlGroup" runat="server" Width="150px" Visible="False"
                    Height="16px" CssClass="TextBox">
                </asp:DropDownList>
                &nbsp;<asp:Label ID="lblMessage" runat="server" Font-Size="Small" Font-Bold="True"
                    ForeColor="Black" Width="97px"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
