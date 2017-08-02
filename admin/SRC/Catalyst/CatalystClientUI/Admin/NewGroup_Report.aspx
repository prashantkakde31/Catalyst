<%@ Page Title="" Language="VB" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="false" CodeFile="NewGroup_Report.aspx.vb" Inherits="admin_NewGroup_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">

    <h3 style="padding: 0px; margin: 0px; color: #0066FF;">Group Report</h3>




    <table id="tabelContainer" class="style2">
        <tr>
            <td style="width: 4px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td style="width: 16px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 4px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td style="width: 16px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 4px">
                &nbsp;</td>
            <td align="right">
               <asp:Label ID="Label1" runat="server" Text="Select Group Name :" Font-Bold="True" 
                    ForeColor="#204673"></asp:Label></td>
            <td>
                <asp:dropdownlist id="ddlGroupName"	runat="server" CssClass="DDTextBox"></asp:dropdownlist></td>
            <td style="width: 16px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 4px">
                &nbsp;</td>
            <td align="right">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td style="width: 16px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 4px">
                &nbsp;</td>
            <td>
                <asp:LinkButton ID="lnklblVwDet" runat="server" CssClass="" 
                                   
                    >View Details</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="lnkExportToExcelME" runat="server" CssClass="Button" 
                  
                   >Download Excel Report</asp:LinkButton>
            </td>
            <td style="width: 16px">
                &nbsp;</td>
        </tr>
    </table>

    <p>
    
    
        &nbsp;</p>
    <p>
    
    
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

