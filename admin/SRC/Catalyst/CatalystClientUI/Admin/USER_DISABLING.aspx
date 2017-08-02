<%@ Page Title="" Language="VB" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="false" CodeFile="USER_DISABLING.aspx.vb" Inherits="admin_USER_DISABLING" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">

   
    <h3 style="padding: 0px; margin: 0px"><asp:Label runat="server" ID="Label10" 
        Font-Bold="True" Font-Size="X-Large" ForeColor="#0066FF">User Disabling</asp:Label></h3>


<br />

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
    
<td align="center">
    <asp:linkbutton id="lnkAuthNewEnrol"  runat="server"  CssClass="DDLightHeader" >Disable</asp:linkbutton></td>
</tr>

</table>

<br />


<div align="center">

<asp:datagrid id="Datagrid2"        runat="server" Width="80%" AllowPaging="True" RowStyle-CssClass="td" HeaderStyle-CssClass="th" CellPadding="5"  PageSize="5"      AutoGenerateColumns="False"  CssClass="DDGridView">
								<SelectedItemStyle CssClass="DDSelected"></SelectedItemStyle>
								<ItemStyle Wrap="True" HorizontalAlign="Center"></ItemStyle>
								<headerStyle HorizontalAlign="Center"  CssClass="DDLightHeader"></headerStyle>
								<FooterStyle CssClass="DDFooter"></FooterStyle>
								<Columns>
									<asp:TemplateColumn  headerText="Select">
										<headerStyle ForeColor="Blue"></headerStyle>
										<headerTemplate>
											<asp:LinkButton id="lnkSelectAll" runat="server" ForeColor="Blue" CausesValidation="False">Select 
                                            All</asp:LinkButton>
										</headerTemplate>
										<ItemTemplate>
											<asp:CheckBox id="checkbox1" runat="server"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="USER_NAME" headerText="User Name"></asp:BoundColumn>
									<asp:ButtonColumn Text="Select" DataTextField="USER_NAME" 
                                        headerText="User Name" CommandName="Select"></asp:ButtonColumn>
									<asp:BoundColumn DataField="BLOCKED" headerText="Blocked"></asp:BoundColumn>
								</Columns>
								<PagerStyle NextPageText="4" PrevPageText="3" 
                                    HorizontalAlign="Left" Mode="NumericPages" CssClass="DDPager"></PagerStyle>
							</asp:datagrid>

<br />
<br />
</div>

</asp:Content>

