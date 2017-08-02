<%@ Page Title="" Language="VB" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="false" CodeFile="Rpt_GroupWiseForms.aspx.vb" Inherits="admin_Rpt_GroupWiseForms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
      <h3>
<asp:Label runat="server" id="Label10" Font-Bold="True" Font-Size="X-Large" 
          ForeColor="#0066FF" >Group Wise Screen Report</asp:Label>
           
</h3>

<table id="tabelContainer" class="style2" 
            style="padding-top: 3px; padding-bottom: 3px">
          
            <tr>
                <td align="right" style="height: 26px">
                 
                 
                 <asp:Label ID="Label1" runat="server" Text="Group Name :" Font-Bold="True" 
                        ForeColor="#204673"></asp:Label>
                   
                </td>
                <td >
                    <asp:dropdownlist id="ddl_Grpname" runat="server"  CssClass="DDTextBox" AutoPostBack="true"></asp:dropdownlist></td>
            </tr>
            <tr>
                <td align="right">
                 
                 
                 <asp:Label ID="Label11" runat="server" Text="Screen Name :" Font-Bold="True" 
                        ClientIDMode="AutoID" ForeColor="#204673"></asp:Label>
                   
                </td>
                <td>
                   <asp:dropdownlist id="ddl_Scrnname" runat="server" CssClass="DDTextBox"
							AutoPostBack="true"></asp:dropdownlist></td>
            </tr>
            <tr>
                <td align="right">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
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
                   <asp:linkbutton id="lnkExportToExcel" runat="server"  CssClass="DDLightHeader">Download</asp:linkbutton>
                    </td>
                <td align="center">
                                    
                    &nbsp;</td>
            </tr>
        </table>

        <br />
        <br />

        <div align="center">
        
        <asp:DataGrid ID="Dg_GrpScrn" Width="70%" runat="server" AllowPaging="True" RowStyle-CssClass="td" HeaderStyle-CssClass="th" CellPadding="5"  PageSize="3" CssClass="DDGridView">
        <SelectedItemStyle CssClass="DDSelected" ></SelectedItemStyle>
        <AlternatingItemStyle  />
        <ItemStyle HorizontalAlign="Center" />  
        <HeaderStyle Font-Bold="True" HorizontalAlign="Center" CssClass="DDLightHeader"></HeaderStyle>
        <PagerStyle HorizontalAlign="Left" Mode="NumericPages" CssClass="DDPager" 
                PageButtonCount="3">
        </PagerStyle>
        <FooterStyle  CssClass="DDFooter" />
    </asp:DataGrid>
        <br />
        <br />
        </div>


</asp:Content>

