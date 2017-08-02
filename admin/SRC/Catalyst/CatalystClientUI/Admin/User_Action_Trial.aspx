<%@ Page Title="" Language="VB" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="false"
    CodeFile="User_Action_Trial.aspx.vb" Inherits="admin_User_Action_Trial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    <h3 style="padding: 0px; margin: 0px">
        <asp:Label runat="server" ID="Label10" Font-Bold="True" Font-Size="X-Large" 
            ForeColor="#0066FF">User Action Trail Report</asp:Label>
    </h3>
    <table id="tabelContainer" class="style2" style="padding-top: 3px; padding-bottom: 3px">
        <tr>
            <td align="right" style="height: 26px" colspan="2">
                &nbsp;
            </td>
            <td style="width: 143px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Select User Name :" 
                    Font-Bold="True" ForeColor="#204673"></asp:Label>
            </td>
            <td style="width: 143px">
                <asp:DropDownList ID="ddlUserName" runat="server" CssClass="DDTextBox" AutoPostBack="true">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                &nbsp;<asp:Label ID="Label12" runat="server" Text="Select Action :" 
                    Font-Bold="True" ForeColor="#204673"></asp:Label>
            </td>
            <td style="width: 143px">
                <asp:DropDownList ID="ddlAction" runat="server" CssClass="DDTextBox">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="3" style="padding-left: 3%">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" style="padding-left: 3%">
                &nbsp;</td>
            <td align="center" style="padding-left: 3%">
                <asp:LinkButton ID="lnkQuery" runat="server">View Details</asp:LinkButton>
            </td>
            <td align="center" style="padding-left: 3%; width: 143px;">
                <asp:LinkButton ID="lnkExportToExcelME" runat="server">Download Excel</asp:LinkButton>
            </td>
        </tr>
    </table>
    <br />
    <div align="center">
        <asp:DataGrid ID="DataGrid1" runat="server" Width="80%" PageSize="5" RowStyle-CssClass="td" HeaderStyle-CssClass="th" CellPadding="5" AllowPaging="True" CssClass="DDGridView">
        <SelectedItemStyle ></SelectedItemStyle>
        <AlternatingItemStyle />
        <ItemStyle HorizontalAlign="Center" />  
        <HeaderStyle  HorizontalAlign="Center"  CssClass="DDLightHeader"></HeaderStyle>
        <PagerStyle HorizontalAlign="Left" Mode="NumericPages" CssClass="DDPager" PageButtonCount="3">
        </PagerStyle>
    </asp:DataGrid>
        <br />
    </div>
</asp:Content>
