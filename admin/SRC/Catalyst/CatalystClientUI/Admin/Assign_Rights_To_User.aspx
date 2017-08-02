<%@ Page Title="" Language="VB" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="false" CodeFile="Assign_Rights_To_User.aspx.vb" Inherits="admin_Assignt_Rights_to_user" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">

    <div>
        <table>
            <tr>
                <td align="right"
                    style="border-top: 1px dotted #666666; border-left-color: #; height: 35px; border-top-style: none; border-bottom-style: dotted; border-bottom-width: 1px; border-bottom-color: #666666;">


                    <asp:Label ID="lbl_userName" runat="server"
                        Text="User Name :" ForeColor="#204673" Font-Bold="True"></asp:Label>
                </td>
                <td style="border-top: 1px dotted #666666; height: 35px; border-top-style: none; border-bottom-style: dotted; border-bottom-width: 1px; border-bottom-color: #666666;">
                    <asp:TextBox ID="txt_user" CssClass="DDTextBox" runat="server"></asp:TextBox>&nbsp;&nbsp;
               <asp:Button ID="btn_search" CssClass="DDLightHeader" runat="server"
                   Text="Search" /></td>
                <td style="border-bottom: 1px dotted #666666; border-top: 1px none #666666; border-left-color: #; height: 35px; width: 10px;"></td>
            </tr>


        </table>
        <table class="style2">


            <tr>
                <td align="right">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>


                    <asp:GridView ID="DataGrid1" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                        Visible="False" EmptyDataText="No Records Found" CssClass="DDGridView" RowStyle-CssClass="td" HeaderStyle-CssClass="th" CellPadding="6">
                        <AlternatingRowStyle />

                        <Columns>

                            <asp:ButtonField CommandName="Select" Text="Select" />
                            <asp:BoundField DataField="user_id" HeaderText="User ID" ReadOnly="True" />
                            <asp:BoundField DataField="user_name" HeaderText="User Name" ReadOnly="True" />

                        </Columns>
                        <FooterStyle CssClass="DDFooter" />
                        <HeaderStyle CssClass="" />
                        <PagerStyle CssClass="DDPager" HorizontalAlign="Left" />

                        <RowStyle CssClass="td"></RowStyle>

                        <SelectedRowStyle CssClass="DDSelected" />

                    </asp:GridView>




                </td>
                <td>
                    <asp:GridView ID="DataGrid2" runat="server" AllowPaging="True" AutoGenerateColumns="False" EmptyDataText="No Records Found"
                        hrizontalAlign="Center" PageSize="5" CssClass="DDGridView" RowStyle-CssClass="td" HeaderStyle-CssClass="th" CellPadding="6" Visible="False">
                        <AlternatingRowStyle />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%-- AutoPostBack="true" oncheckedchanged="checkbox1_CheckedChanged"--%>
                                    <asp:CheckBox ID="checkbox1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="GROUP_ID" HeaderText="Group ID" ReadOnly="True" />
                            <asp:BoundField DataField="GROUP_NAME" HeaderText="Group Name"
                                ReadOnly="True" />
                            <asp:BoundField DataField="DESCRIPTION" HeaderText="Description"
                                ReadOnly="True" />
                        </Columns>
                        <FooterStyle CssClass="DDFooter" />
                        <HeaderStyle CssClass="" />
                        <PagerStyle CssClass="DDPager" HorizontalAlign="Left" />

                        <RowStyle CssClass="td"></RowStyle>

                        <SelectedRowStyle CssClass="DDSelected" />
                    </asp:GridView>
                    <br />

                </td>
                <td align="left" valign="bottom">

                    <asp:Button ID="btnsave0" CssClass="Button" runat="server"
                        Width="90px" Font-Bold="True" Text="Save" Height="25px"></asp:Button>
                </td>
            </tr>
            <tr>
                <td align="right">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>

        </table>
    </div>




</asp:Content>

