

<%@ Page MasterPageFile="~/MASTER/MasterPage2.master" Language="vb" AutoEventWireup="false"
    CodeFile="Users_Report.aspx.vb" Inherits="Users_Report" %>
<%@ Register TagPrefix="pnwc" Namespace="PNayak.Web.UI.WebControls" Assembly="PNayak.Web.UI.WebControls.ExportButton" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
 
        <table align="center" style="position: static; width: 650px;" cellpadding="4">
            <tr>
                <td colspan="2" style="height: 25px" align="left">
                    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                    </asp:ToolkitScriptManager>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <span><strong><span style="font-size: 14pt">Admin</span> </strong></span>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 25px;Color:#0066FF;font-size:x-large;font-weight:bold;font-family:Arial;text-align:center">
                    <strong>Users Report</strong>
                </td>
            </tr>
            <tr>
                <td style="background-color: #ffffff; width: 303px;" align="right">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" CssClass="Label" 
                        ForeColor="#204673">From Date</asp:Label>
                </td>
                <td style="background-color: #ffffff; width: 300px;">
                    <asp:TextBox ID="txtFromDate" CssClass="TextBox" TabIndex="1" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" Enabled="True"
                        PopupButtonID="lnkFromDate" Format="dd-MMM-yy" TargetControlID="txtFromDate">
                    </asp:CalendarExtender>
                    <asp:ImageButton ID="lnkFromDate" Format="dd-MMM-yyyy" TabIndex="2" runat="server"
                        ImageUrl="~/MASTER/Images/calendar.gif" Style="height: 16px"></asp:ImageButton>
                </td>
            </tr>
            <tr>
                <td style="background-color: #ffffff; width: 303px;" align="right">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" CssClass="Label" 
                        ForeColor="#204673">To Date</asp:Label>
                </td>
                <td style="background-color: #ffffff; width: 300px;">
                    <asp:TextBox ID="txtToDate" TabIndex="3" runat="server" CssClass="TextBox"></asp:TextBox>
                    <asp:CalendarExtender ID="txtToDate_CalendarExtender" runat="server" Enabled="True"
                        PopupButtonID="lnkToDate" Format="dd-MMM-yy" TargetControlID="txtToDate">
                    </asp:CalendarExtender>
                    <asp:ImageButton ID="lnkToDate" TabIndex="4" runat="server" ImageUrl="~/MASTER/Images/calendar.gif">
                    </asp:ImageButton>
                </td>
            </tr>
            <tr>
                <td style="background-color: #ffffff; width: 303px;" align="right">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" CssClass="Label" 
                        ForeColor="#204673">User Name</asp:Label>
                </td>
                <td style="background-color: #ffffff; width: 300px;">
                    <asp:DropDownList ID="ddlUserName" runat="server" AutoPostBack="True" CssClass="TextBox">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="background-color: #ffffff; width: 303px;" align="right">
                    <asp:Label ID="lblGroup" runat="server" Font-Bold="True" CssClass="Label" 
                        ForeColor="#204673">Group Name</asp:Label>
                </td>
                <td style="background-color: #ffffff; width: 300px;">
                    <asp:DropDownList ID="ddlGroup" runat="server" CssClass="TextBox">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 303px">
                    <asp:LinkButton ID="lnkBtnVwDet" runat="server" Font-Bold="False" ForeColor="Blue"
                        Font-Underline="True" Height="21px" Width="95px">View Detail</asp:LinkButton>
                </td>
                <td>
                    <asp:LinkButton ID="lnkExportToExcelME" runat="server" Font-Bold="False" ForeColor="Blue"
                        Font-Underline="True" Width="87px" Height="21px">Download</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td colspan="2" bgcolor="White">
                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Width="650px">
                        <asp:DataGrid ID="DataGrid1" runat="server" Width="650px" AllowPaging="True" BorderStyle="None"
                            CellPadding="4" PageSize="3" CssClass="DDGridView">
                            <SelectedItemStyle CssClass="DDSelected"></SelectedItemStyle>
                            <AlternatingItemStyle />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            <HeaderStyle Font-Bold="True" HorizontalAlign="Center" CssClass="DDLightHeader">
                            </HeaderStyle>
                            <FooterStyle CssClass="DDFooter"></FooterStyle>
                            <PagerStyle HorizontalAlign="Left" Mode="NumericPages" CssClass="DDPager"></PagerStyle>
                        </asp:DataGrid>
                    </asp:Panel>
                </td>
            </tr>
        </table>
</asp:Content>
