<%@ Page Title="" Language="VB" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="false"
    CodeFile="AddNewGroup.aspx.vb" Inherits="admin_AddNewGroup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    <div class="page-header">
        <h1>Admin
								<small>
                                    <i class="ace-icon fa fa-angle-double-right"></i>
                                    Add New Group
                                </small>
        </h1>
    </div>
    <div class="align-center">
        <asp:Button ID="lnkEdit" runat="server" Text="Add" CssClass="btn btn-primary"></asp:Button>
    </div>
    <div class="col-sm-12 row top-buffer">
        <div class="col-sm-2"></div>
        <div class="col-sm-4">
            <asp:Label ID="Label1" runat="server" Text="Group ID :"></asp:Label>
        </div>
        <div class="col-sm-4">
            <asp:TextBox ID="txtGROUPID" runat="server" ReadOnly="True" MaxLength="50"></asp:TextBox>
        </div>
        <div class="col-sm-2"></div>
    </div>

    <div class="col-sm-12 row top-buffer">
        <div class="col-sm-2"></div>
        <div class="col-sm-4">
            <asp:Label ID="Label2" runat="server" Text="Group Name :"></asp:Label>
        </div>
        <div class="col-sm-4">
            <asp:TextBox ID="txtGROUPNAME" runat="server" MaxLength="50"></asp:TextBox>
        </div>
        <div class="col-sm-2"></div>
    </div>
    <div class="col-sm-12 row top-buffer">
        <div class="col-sm-2"></div>
        <div class="col-sm-4">
            <asp:Label ID="Label3" runat="server" Text="Description  :"></asp:Label>

        </div>
        <div class="col-sm-4">
            <asp:TextBox ID="txtDESCRIPTION" runat="server" MaxLength="200"
                TextMode="MultiLine" Height="44px"></asp:TextBox>
        </div>
        <div class="col-sm-2"></div>
    </div>
    <div class="align-center top-buffer row col-sm-12">
        <asp:LinkButton ID="lnkSave" runat="server" Enabled="False"
            Width="70px">Save</asp:LinkButton>
    </div>

</asp:Content>
