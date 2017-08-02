<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MASTER/MasterPage2.master"
    CodeFile="USER_BLOCKING.aspx.vb" Inherits="USER_BLOCKING" Title="ICICI Merchant Services - Web Portal" %>

<asp:Content ID="content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder3">
    <table style="width: 500px;" cellpadding="4px" cellspacing="0">
        <tr>
            <td style="height: 30px;" colspan="2">
                <asp:Label runat="server" ID="Label10" 
        Font-Bold="True" Font-Size="X-Large" ForeColor="#0066FF">User Blocking</asp:Label>&nbsp;</td>
        </tr>
        <%--<tr class="maroonbar">
<td style="height:16px; text-align: left;" colspan="2" class="white">
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:label id="Label6" runat="server" Font-Bold="True">User Blocking Screen</asp:label>
			    </td>
</tr--%>
        <tr>
            <td style="width: 200px; height: 30px;">
                <asp:Label ID="Label2" runat="server" Font-Bold="False" CssClass="Label">UserName</asp:Label>
            </td>
            <td style="width: 300px; height: 30px;">
                <asp:DropDownList ID="ddlUserName" runat="server" Width="170px" AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 200px; height: 30px;">
                <asp:LinkButton ID="lnkQuery" runat="server" Font-Bold="True" TabIndex="2" Font-Names="Verdana"
                    Font-Size="X-Small">Query</asp:LinkButton>
            </td>
            <td style="width: 300px; height: 30px;">
                <asp:LinkButton ID="lnkAuthNewEnrol" TabIndex="4" runat="server" Font-Bold="True"
                    Font-Names="Verdana" Font-Size="X-Small" ForeColor="Black">BLOCK/UNBLOCK 
                        USERS</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style="width: 200px; height: 30px;">
                &nbsp;
            </td>
            <td style="width: 300px; height: 30px;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 30px;" colspan="2">
                <asp:DataGrid ID="Datagrid2" TabIndex="3" runat="server" Width="500px" AllowPaging="True"
                    CellPadding="4" AutoGenerateColumns="False" BorderStyle="None" 
                    CssClass="DDGridView">
                  <%--  <SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
                    <ItemStyle Wrap="True" HorizontalAlign="Center"></ItemStyle>
                    <HeaderStyle Font-Bold="True" CssClass="GridHeader"></HeaderStyle>
                    <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                  --%>
                  <SelectedItemStyle CssClass="DDSelected"></SelectedItemStyle>
								<ItemStyle Wrap="True" HorizontalAlign="Center"></ItemStyle>
								<headerStyle HorizontalAlign="Center"  CssClass="DDLightHeader"></headerStyle>
								<FooterStyle CssClass="DDFooter"></FooterStyle>
                    <Columns>
                        <asp:TemplateColumn HeaderText="Select">
                            <HeaderStyle ForeColor="White"></HeaderStyle>
                            <HeaderTemplate>
                                <asp:LinkButton ID="lnkSelectAll" runat="server" ForeColor="White" CausesValidation="False">Select 
                                            All</asp:LinkButton>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="checkbox1" runat="server"></asp:CheckBox>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn Visible="False" DataField="USER_NAME" HeaderText="User Name"></asp:BoundColumn>
                        <asp:ButtonColumn Text="Select" DataTextField="USER_NAME" HeaderText="User Name"
                            CommandName="Select"></asp:ButtonColumn>
                        <asp:BoundColumn DataField="BLOCKED" HeaderText="Blocked"></asp:BoundColumn>
                    </Columns>
                    <PagerStyle NextPageText="4" PrevPageText="3" HorizontalAlign="Center" Mode="NumericPages"
                        CssClass="GridHeader"></PagerStyle>
                </asp:DataGrid>
            </td>
        </tr>
        <tr>
            <td style="width: 200px; height: 30px;">
                &nbsp;
            </td>
            <td style="width: 300px; height: 30px;">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
