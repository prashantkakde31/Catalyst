<%@ Page Title="" Language="VB" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="false" CodeFile="User_Session_Track.aspx.vb" Inherits="admin_User_Session_Track" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">



    <h3 style="padding: 0px; margin: 0px; color: #0066FF;">Session Report<asp:ToolkitScriptManager 
            ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
    </h3>




    <table id="tabelContainer" class="style2">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td style="width: 16px">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="right">
               <asp:Label ID="Label1" runat="server" Text="From Date :" Font-Bold="True" 
                    ForeColor="#204673"></asp:Label></td>
            <td>
                <asp:textbox id="txtFromDate" CssClass="DDTextBox"				runat="server"  
                    tabIndex="1"></asp:textbox>
                    <asp:CalendarExtender runat="server" ID="cal1" PopupButtonID="lnkFromDate" TargetControlID="txtFromDate" Format="dd-MM-yy"></asp:CalendarExtender>
            </td>
            <td style="width: 16px">
                <asp:ImageButton ID="lnkFromDate" runat="server" 
                    ImageUrl="~/MASTER/Images/calendar.gif" tabIndex="2" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="right">
               <asp:Label ID="Label2" runat="server" Text="To Date :" Font-Bold="True" 
                    ForeColor="#204673"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtToDate" runat="server" CssClass="DDTextBox" tabIndex="3"></asp:TextBox>

                <asp:CalendarExtender runat="server" ID="cal2" PopupButtonID="lnkToDate" TargetControlID="txtToDate" Format="dd-MM-yy"></asp:CalendarExtender>
            </td>
            <td style="width: 16px">
                <asp:ImageButton ID="lnkToDate" runat="server" 
                    ImageUrl="~/MASTER/Images/calendar.gif" tabIndex="4" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
               <asp:Label ID="Label3" runat="server" Text="User Name :" Font-Bold="True" 
                    ForeColor="#204673"></asp:Label></td>
            <td>
               <asp:dropdownlist id="ddlUserName" 	runat="server" CssClass="DDTextBox" AutoPostBack="True"></asp:dropdownlist></td>
            <td style="width: 16px">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td style="width: 16px">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:LinkButton ID="lnkQuery" runat="server" CssClass="" 
                                   
                    >View Details</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="lnkExportToExcelME" runat="server" CssClass="Button" 
                  
                   >Download</asp:LinkButton>
            </td>
            <td style="width: 16px">
                &nbsp;</td>
        </tr>
    </table>

    <p>
    
    
        <asp:TextBox ID="txtHOSTIP" runat="server" BackColor="White" 
            BorderColor="DimGray" BorderStyle="Solid" BorderWidth="1px" 
            Font-Names="Verdana" Font-Size="X-Small" ForeColor="Navy" Height="24px" 
            style="POSITION: absolute; z-index: 102; left: 273px; top: 292px;" tabIndex="6" 
            Visible="False" Width="142px"></asp:TextBox>
    
    
    <asp:datagrid id="DataGrid1" runat="server" Width="80%"   RowStyle-CssClass="td" PageSize="5" HeaderStyle-CssClass="th" CellPadding="5" 
					AllowPaging="True"  CssClass="DDGridView">
					<SelectedItemStyle CssClass="DDSelected"></SelectedItemStyle>
					    <AlternatingItemStyle  />
					<ItemStyle HorizontalAlign="Center"></ItemStyle>
					<HeaderStyle HorizontalAlign="Center" CssClass="DDLightHeader"></HeaderStyle>
					<FooterStyle CssClass="DDFooter"></FooterStyle>
					<PagerStyle HorizontalAlign="Left" Mode="NumericPages" CssClass="DDPager"></PagerStyle>
				</asp:datagrid>
    
    </p>

</asp:Content>

