<%@ Page Title="" Language="VB" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="false" CodeFile="audit_log_reports.aspx.vb" Inherits="admin_audit_log_reports" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server" >
    <h3>
<asp:Label runat="server" id="Label10" Font-Bold="True" Font-Size="X-Large" 
          ForeColor="#0066FF" > Audit Log Report</asp:Label>
          <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
          </h3>
          

<p align="left" style="padding-left: 37%">

<asp:RadioButtonList ID="rbl_rpt_type"  runat="server" AutoPostBack="True" 
        Font-Bold="True" ForeColor="#0066FF" >
                            <asp:ListItem Selected="True" Value="0">Unsuccessful logins</asp:ListItem>
                            <asp:ListItem Value="1">Dormant User(LoggedIn atleast once)</asp:ListItem>
                            <asp:ListItem Value="2">Dormant User(Not LoggedIn since created)</asp:ListItem>
                        </asp:RadioButtonList>

</p>

<table id="tabelContainer" class="style2" 
            style="padding-top: 3px; padding-bottom: 3px">
            <tr>
                <td align="right" style="height: 26px">
                 
                 
                 <asp:Label ID="Label1" runat="server" Text="From Date :" Font-Bold="True" 
                        ForeColor="#204673"></asp:Label>
                   
                </td>
                <td style="height: 26px"><asp:TextBox ID="txtFromDate" runat="server" BackColor="White" CssClass="DDTextBox"    ></asp:TextBox>
                
                <asp:CalendarExtender runat="server" PopupButtonID="lnkFromDate" TargetControlID="txtFromDate" Format="dd-MM-yy"></asp:CalendarExtender>
                </td>

                <td>
                    <asp:ImageButton ID="lnkFromDate" runat="server" 
                        ImageUrl="~/MASTER/Images/calendar.gif" tabIndex="10" 
                        style="width: 16px" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label2" runat="server" Text="To Date :" Font-Bold="True" 
                        ForeColor="#204673"></asp:Label>
                </td>
                <td>
                   <asp:TextBox ID="txtToDate" runat="server" CssClass="DDTextBox"  ></asp:TextBox>
                   
                   <asp:CalendarExtender runat="server" ID="cal2" Format="dd-MM-yy" TargetControlID="txtToDate" PopupButtonID="lnkToDate" ></asp:CalendarExtender>
                   
                   </td><td>
                    <asp:ImageButton ID="lnkToDate" runat="server" 
                        ImageUrl="~/MASTER/Images/calendar.gif" tabIndex="12" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label3" runat="server" Text="User Name :" 
                        Font-Bold="True" ForeColor="#204673"></asp:Label>
                </td>
                <td>
                   <asp:DropDownList ID="ddlUserName" runat="server" AutoPostBack="True" CssClass="DDTextBox">
                    </asp:DropDownList></td><td></td>
            </tr>
            </table>


        <p align="center">
        
        
        
        <asp:DataGrid ID="DataGrid1" runat="server" RowStyle-CssClass="td" HeaderStyle-CssClass="th" CellPadding="5"  AllowPaging="True" PageSize="4" 
                CssClass="DDGridView" Width="80%">
        <SelectedItemStyle  CssClass="DDSelected" />
        <AlternatingItemStyle />
        <ItemStyle  />  
        <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="DDLightHeader"></HeaderStyle>
        <PagerStyle HorizontalAlign="Center" Mode="NumericPages" CssClass="DDPager" PageButtonCount="3">
        </PagerStyle>
        <FooterStyle CssClass="DDFooter" />
    </asp:DataGrid>
        
        
        </p>


        <p></p>

</asp:Content>

