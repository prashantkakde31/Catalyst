<%@ Page Title="" Language="VB" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="false" CodeFile="Add_User_To_Group.aspx.vb" Inherits="admin_Add_User_To_Group" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    <div class="page-header">
        <h1>Admin
								<small>
                                    <i class="ace-icon fa fa-angle-double-right"></i>
                                    Add User To Group
                                </small>
        </h1>
    </div>

    <div class="col-sm-12 row top-buffer">
        <div class="col-sm-2"></div>
        <div class="col-sm-4 align-right">
            <asp:Label ID="Label1" runat="server" Text="Menu Code :" Font-Bold="True"
                ForeColor="#204673"></asp:Label>
        </div>
        <div class="col-sm-4">
            <asp:TextBox ID="txt_user" runat="server"></asp:TextBox>
            <asp:Button ID="btn_search" runat="server" Text="Search" CssClass="btn btn-primary" />
        </div>
        <div class="col-sm-2">
            &nbsp;
        </div>
    </div>
    <div class="col-sm-12 row top-buffer">
        <div class="col-sm-6">
            <asp:DataGrid ID="DataGrid1" runat="server" AllowPaging="True" CssClass="table table-striped dataTable" PageSize="5" AutoGenerateColumns="False">
                <Columns>
                    <asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
                    <asp:BoundColumn DataField="User ID" HeaderText="User Id"></asp:BoundColumn>
                    <asp:BoundColumn DataField="User Name" HeaderText="User Name"></asp:BoundColumn>
                </Columns>
                <PagerStyle
                    Mode="NumericPages" CssClass="DDPager" HorizontalAlign="Left"></PagerStyle>
            </asp:DataGrid>
        </div>
        <div class="col-sm-6">
            <asp:DataGrid ID="DataGrid2" runat="server" CssClass="table table-striped dataTable" PageSize="5" AllowPaging="True" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateColumn>
                        <HeaderTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="OldLace">Select 
                            All</asp:LinkButton>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Checked="True"></asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:BoundColumn DataField="Group ID" HeaderText="Group ID">
                        <HeaderStyle />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Group Name" HeaderText="Group Name">
                        <HeaderStyle />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Description" HeaderText="Description">
                        <HeaderStyle />
                    </asp:BoundColumn>
                </Columns>
                <PagerStyle
                    Mode="NumericPages" CssClass="DDPager" HorizontalAlign="Left"></PagerStyle>
            </asp:DataGrid>
        </div>
    </div>
    <div class="col-sm-12 row top-buffer">

        <asp:Button ID="btnsave0" runat="server"
            Text="Save" CssClass="btn btn-primary" Width="70px" Enabled="False"></asp:Button>
    </div>
</asp:Content>

