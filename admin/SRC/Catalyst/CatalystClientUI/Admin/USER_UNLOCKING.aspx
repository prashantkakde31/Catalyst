<%@ Page Title="" Language="VB" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="false" CodeFile="USER_UNLOCKING.aspx.vb" Inherits="admin_USER_UNLOCKING" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">


    <h3>
<asp:Label runat="server" ID="Label10" Font-Size="X-Large" ForeColor="#0066FF" >User Unlocking</asp:Label>
</h3>


<table width="100%">
<tr>

<td align="right">
<asp:Label ID="Label1" runat="server" Text="Select User Name :" Font-Bold="True" 
        ForeColor="#204673"></asp:Label>
</td>

<td>
<asp:dropdownlist id="ddlUserName" CssClass="DDTextBox"
				runat="server" AutoPostBack="True"></asp:dropdownlist>
</td>
</tr>

<tr>

<td align="right">
    &nbsp;</td>

<td>
    &nbsp;</td>
</tr>

<tr>

<td align="center">
    <asp:linkbutton id="lnkQuery" runat="server" CssClass="DDLightHeader">Query</asp:linkbutton>
    </td>

<td align="center">
    <asp:linkbutton id="lnkAuthNewEnrol"  runat="server"  CssClass="DDLightHeader" >Disable</asp:linkbutton></td>
</tr>

</table>

<br />


<div align="center">

<asp:datagrid id="Datagrid2"  runat="server" Width="80%" RowStyle-CssClass="td" HeaderStyle-CssClass="th" CellPadding="5"  PageSize="5"
				AllowPaging="True"  AutoGenerateColumns="False"   CssClass="DDGridView">
				<SelectedItemStyle CssClass="DDSelected"></SelectedItemStyle>
				<AlternatingItemStyle  />
				<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
				<HeaderStyle HorizontalAlign="Center" CssClass="DDLightHeader"></HeaderStyle>
				<FooterStyle CssClass="DDFooter"></FooterStyle>
				<Columns>
					<asp:TemplateColumn HeaderText="Select">
						<HeaderStyle ></HeaderStyle>
						<HeaderTemplate>
							<asp:LinkButton id="lnkSelectAll" runat="server" CausesValidation="False">Select All</asp:LinkButton>
						</HeaderTemplate>
						<ItemTemplate>
							<asp:CheckBox id="checkbox1" runat="server"></asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="USER_NAME" HeaderText="User Name"></asp:BoundColumn>
					<asp:ButtonColumn Text="Select" DataTextField="USER_NAME" 
                        HeaderText="User Name" CommandName="Select"></asp:ButtonColumn>
					<asp:BoundColumn DataField="LOCKED" HeaderText="Locked"></asp:BoundColumn>
				</Columns>
				<PagerStyle NextPageText="4" PrevPageText="3" HorizontalAlign="Left" 
                    Mode="NumericPages" CssClass="DDPager"></PagerStyle>
			</asp:datagrid>

<br />
<br />
</div>

</asp:Content>

