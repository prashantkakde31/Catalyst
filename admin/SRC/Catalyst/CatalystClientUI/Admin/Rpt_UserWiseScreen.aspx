<%@ Page Title="" Language="VB" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="false" CodeFile="Rpt_UserWiseScreen.aspx.vb" Inherits="admin_Rpt_UserWiseScreen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">


    <h3>
 
<asp:Label runat="server" id="Label10" Font-Bold="True" Font-Size="X-Large" 
          ForeColor="#0066FF" >User Wise Screen Report</asp:Label>
          </h3>
          

<table id="tabelContainer" class="style2" 
            style="padding-top: 3px; padding-bottom: 3px">
          
            <tr>
                <td align="right" style="height: 26px">
                 
                 
                 <asp:Label ID="Label1" runat="server" Text="User Name :" Font-Bold="True" 
                        ForeColor="#204673"></asp:Label>
                   
                </td>
                <td >
                    <asp:dropdownlist id="DropDownList1" runat="server"  CssClass="DDTextBox" AutoPostBack="true"></asp:dropdownlist></td>
            </tr>
            <tr>
                <td align="right">
                 
                 
                 <asp:Label ID="Label11" runat="server" Text="Group Name :" Font-Bold="True" 
                        ForeColor="#204673"></asp:Label>
                   
                </td>
                <td>
                   <asp:dropdownlist id="DropDownList2" runat="server" CssClass="DDTextBox"
							AutoPostBack="true"></asp:dropdownlist></td>
            </tr>
           
            <tr>
                <td align="left" colspan="2" style="padding-left: 3%">
                    <asp:label id="lbl_Messege" runat="server" ForeColor="Red" CssClass="Label">Label</asp:label>
                </td>
            </tr>
            </table>
            <table class="style2" style="border-top-style: dotted; border-top-width: 1px;
            border-top-color: #C0C0C0">
            <tr>
                <td align="center">
                   <asp:button id="Btn_Det" runat="server"  CssClass="DDLightHeader"
							Text="View Detail"></asp:button></td>
                <td>
                   <asp:linkbutton id="lnkExportToExcel" runat="server"  CssClass="DDListView">Download</asp:linkbutton>
                    </td>
                <td align="center">
                                    
                    &nbsp;</td>
            </tr>
        </table>

        <br />
       
        <div align="center">
        
        <asp:DataGrid ID="Dg_Usrsrn" Width="80%" runat="server"  RowStyle-CssClass="td" 
                HeaderStyle-CssClass="th" CellPadding="5" AllowPaging="True"  PageSize="5" 
                CssClass="DDGridView">
        <SelectedItemStyle CssClass="DDSelected"></SelectedItemStyle>
        <AlternatingItemStyle  />
        <ItemStyle HorizontalAlign="Center" />  
        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" CssClass="DDLightHeader"></HeaderStyle>
        <PagerStyle HorizontalAlign="Left" Mode="NumericPages" CssClass="DDPager" PageButtonCount="3">
        </PagerStyle>
    </asp:DataGrid>
        <br />
        <br />
        </div>





</asp:Content>

