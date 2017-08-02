<%@ Page Title="" Language="VB" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="false" CodeFile="GROUP_FORM_ACCESS.aspx.vb" Inherits="admin_GROUP_FORM_ACCESS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    <div class="page-header">
        <h1>Admin<small>
            <i class="ace-icon fa fa-angle-double-right"></i>
            User Access Control
        </small>
        </h1>
    </div>
    <div class="col-sm-12 row top-buffer">
        <div class="col-sm-6">
            <asp:DataGrid ID="DataGrid1" runat="server" AllowPaging="True"
                AutoGenerateColumns="False" PageSize="5" CssClass="table table-striped dataTable" Font-Size="Small">
                <Columns>
                    <asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
                    <asp:BoundColumn DataField="GROUP_NAME" HeaderText="Group Name"></asp:BoundColumn>
                    <asp:BoundColumn DataField="GROUP_ID" HeaderText="Group ID"></asp:BoundColumn>
                    <asp:BoundColumn DataField="DESCRIPTION" HeaderText="DESCRIPTION"></asp:BoundColumn>
                </Columns>
                <PagerStyle
                    Mode="NumericPages" CssClass="DDPager"></PagerStyle>
            </asp:DataGrid>
        </div>
        <div class="col-sm-3">
            <asp:DataGrid ID="DGModule" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                Visible="false" PageSize="5" CssClass="table table-striped dataTable" Font-Size="Small">
                <Columns>
                    <asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
                    <asp:BoundColumn DataField="MENU_CODE" HeaderText="Menu Code"></asp:BoundColumn>
                    <asp:BoundColumn DataField="MENU_DESC" HeaderText="Description"></asp:BoundColumn>
                </Columns>
                <PagerStyle
                    Mode="NumericPages" CssClass="DDPager"></PagerStyle>
            </asp:DataGrid>
        </div>
        <div class="col-sm-3">
            <asp:DataGrid ID="DataGrid2" runat="server" PageSize="5" AllowPaging="True"
                AutoGenerateColumns="False" Visible="False" CssClass="table table-striped dataTable" Font-Size="Small">
                <Columns>
                    <asp:TemplateColumn>
                        <HeaderTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="Gray">Select All</asp:LinkButton>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" Width="20px" AutoPostBack="True"></asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:BoundColumn DataField="FUNCTION_CODE" HeaderText="Function Code"></asp:BoundColumn>
                    <asp:BoundColumn DataField="FUNCTION_DESC" HeaderText="Description"></asp:BoundColumn>
                </Columns>
                <PagerStyle NextPageText="" PrevPageText="0" Mode="NumericPages"
                    CssClass="DDPager"></PagerStyle>
            </asp:DataGrid>
        </div>
    </div>
    <div class="align-center top-buffer row col-sm-12">
        <asp:Button ID="btnsave" runat="server" Text="Save"
            CssClass="btn btn-primary"></asp:Button>
    </div>
</asp:Content>

