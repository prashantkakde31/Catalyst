<%@ Page Title="" Language="VB" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="false"
    CodeFile="User_Status_report.aspx.vb" Inherits="admin_User_Status_report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    <h3 style="padding: 0px; margin: 0px; color: #0066FF;">
        User Status Report</h3>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <table id="tabelContainer" class="style2">
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
            </td>
            <td style="width: 16px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td align="right">
                <asp:Label ID="Label1" runat="server" Text="From Date :" Font-Bold="True" ForeColor="#204673"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFromDate" CssClass="DDTextBox" runat="server" TabIndex="1"></asp:TextBox>
                <asp:CalendarExtender ID="calext" runat="server" TargetControlID="txtFromDate" PopupButtonID="lnkFromDate"
                    Format="dd-MMM-yy">
                </asp:CalendarExtender>
            </td>
            <td style="width: 16px">
                <asp:ImageButton ID="lnkFromDate" runat="server" ImageUrl="~/MASTER/Images/calendar.gif"
                    TabIndex="2" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td align="right">
                <asp:Label ID="Label2" runat="server" Text="To Date :" Font-Bold="True" ForeColor="#204673"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtToDate" runat="server" CssClass="DDTextBox" TabIndex="3"></asp:TextBox><asp:CalendarExtender
                    ID="cal" runat="server" TargetControlID="txtToDate" PopupButtonID="lnkToDate"
                    Format="dd-MMM-yy">
                </asp:CalendarExtender>
            </td>
            <td style="width: 16px">
                <asp:ImageButton ID="lnkToDate" runat="server" ImageUrl="~/MASTER/Images/calendar.gif"
                    TabIndex="4" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="User Name :" Font-Bold="True" ForeColor="#204673"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlUserName" runat="server" CssClass="DDTextBox" AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td style="width: 16px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Group :" Font-Bold="True" ForeColor="#204673"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlGroup" runat="server" CssClass="DDTextBox">
                </asp:DropDownList>
            </td>
            <td style="width: 16px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Status :" Font-Bold="True" ForeColor="#204673"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="DDTextBox">
                    <asp:ListItem Selected="True"></asp:ListItem>
                    <asp:ListItem Value="LOCKED">LOCKED</asp:ListItem>
                    <asp:ListItem Value="DISABLED">DISABLED</asp:ListItem>
                    <asp:ListItem Value="BLOCKED">BLOCKED</asp:ListItem>
                    <asp:ListItem Value="OPEN">OPEN</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 16px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td style="padding-top: 5px">
                <asp:LinkButton ID="lnkQuery" runat="server" CssClass="">View Details</asp:LinkButton>
            </td>
            <td style="padding-top: 5px">
                <asp:LinkButton ID="lnkExportToExcelME" runat="server" CssClass="Button">Download</asp:LinkButton>
            </td>
            <td style="width: 16px">
                &nbsp;
            </td>
        </tr>
    </table>
    <asp:DataGrid ID="DataGrid1" runat="server" PageSize="5" RowStyle-CssClass="td" HeaderStyle-CssClass="th"
        AllowPaging="True" CssClass="DDGridView" Font-Size="10px" Width="628px">
        <SelectedItemStyle CssClass="DDSelected"></SelectedItemStyle>
        <AlternatingItemStyle />
        <ItemStyle HorizontalAlign="Center"></ItemStyle>
        <HeaderStyle Font-Bold="True" HorizontalAlign="Center" CssClass="DDLightHeader">
        </HeaderStyle>
        <FooterStyle CssClass="DDFooter"></FooterStyle>
        <PagerStyle HorizontalAlign="Left" Mode="NumericPages" CssClass="DDPager"></PagerStyle>
    </asp:DataGrid>
</asp:Content>
