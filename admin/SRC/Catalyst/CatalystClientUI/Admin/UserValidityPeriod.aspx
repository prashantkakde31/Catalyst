<%@ Page Title="" Language="VB" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="false"
    CodeFile="UserValidityPeriod.aspx.vb" Inherits="admin_UserValidityPeriod" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    <h3 style="padding: 0px; margin: 0px">
        
        <asp:Label runat="server" ID="Label10" Font-Size="X-Large" ForeColor="#0066FF" >User Validity Period</asp:Label>
    </h3>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <br />
    <table id="tabelContainer" class="style2" style="padding-top: 3px; padding-bottom: 3px">
        <tr>
            <td align="right" style="height: 26px" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="User Name :" Font-Bold="True" 
                    ForeColor="#204673"></asp:Label>
            </td>
            <td colspan="2" align="left">
                <asp:DropDownList ID="ddlUserName" runat="server" CssClass="DDTextBox" 
                    AutoPostBack="true">
                </asp:DropDownList>
            <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                <asp:Label ID="Label11" runat="server" Text="Valid From :" Font-Bold="True" 
                    ForeColor="#204673"></asp:Label>
            </td>
            <td colspan="2" align="left">
                <asp:textbox id="txtFromDate" runat="server" CssClass="DDTextBox"	ReadOnly="True"></asp:textbox>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                &nbsp;<asp:Label ID="Label12" runat="server" Text="Valid UpTo :" 
                    Font-Bold="True" ForeColor="#204673"></asp:Label>
            </td>
            <td colspan="2" align="left">
            <asp:textbox id="txtToDate" CssClass="DDTextBox" runat="server" ></asp:textbox>
            <asp:CalendarExtender runat="server"  id="cal" PopupButtonID="lnkToDate" TargetControlID="txtToDate" Format="MM/dd/yy"></asp:CalendarExtender>
            <asp:imagebutton style="Z-INDEX: 0" id="lnkToDate" tabIndex="4" runat="server" 
                                ImageUrl="~/MASTER/Images/calendar.gif"></asp:imagebutton>
                <asp:Label ID="Label13" runat="server" ForeColor="Red" Text="*"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="4" style="padding-left: 3%">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" style="padding-left: 3%">
                <asp:button id="Btn_Clear" runat="server"
								Text="Clear" CssClass="DDLightHeader" ></asp:button></td>
            <td align="center" style="padding-left: 3%">
               <asp:button id="Btn_Viewdet"  runat="server"
								 Text="View Detail" Visible="False" CssClass="DDLightHeader"></asp:button></td>
            <td align="center" style="padding-left: 3%">
               <asp:button id="Btn_Save" runat="server"
								 Text="Save" CssClass="DDLightHeader" ></asp:button></td>
            <td align="center" style="padding-left: 3%">

              <asp:linkbutton id="lnkExportToExcelME" runat="server" 
                              Visible="False" BackColor="White">Download Excel Report</asp:linkbutton></td>
        </tr>
    </table>

    <br />
    

    <div align="center">
    
    <asp:DataGrid ID="DataGrid1" RowStyle-CssClass="td" HeaderStyle-CssClass="th" CellPadding="5"  PageSize="4" runat="server" Width="80%" AllowPaging="True" CssClass="DDGridView">
        <SelectedItemStyle CssClass="DDSelected"></SelectedItemStyle>
        <AlternatingItemStyle />
        <ItemStyle HorizontalAlign="Center" />  
        <HeaderStyle Font-Bold="True" HorizontalAlign="Center" CssClass="DDLightHeader"></HeaderStyle>
        <PagerStyle HorizontalAlign="Center" Mode="NumericPages" CssClass="DDPager" >
        </PagerStyle>
    </asp:DataGrid>
    <br />
    </div>
   
</asp:Content>
