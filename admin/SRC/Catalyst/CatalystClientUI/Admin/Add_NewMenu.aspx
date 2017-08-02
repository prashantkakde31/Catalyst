<%@ Page Title="" Language="VB" AutoEventWireup="false" CodeFile="Add_NewMenu.aspx.vb"
    MasterPageFile="~/Master/MasterPage2.master" Inherits="admin_Add_NewMenu" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder3">
    <div class="page-header">
        <h1>Admin
								<small>
                                    <i class="ace-icon fa fa-angle-double-right"></i>
                                    Add New menu
                                </small>
        </h1>
    </div>

    <style type="text/css">
        .table {
            display: table;
        }

        .row {
            display: table-row;
        }

        .column {
            display: table-cell;
            vertical-align: top;
        }
    </style>
    <div class="align-center">
        <asp:Button ID="btn_Add" runat="server" Text="Add Menu" CssClass="btn btn-primary" />
    </div>
    <div class="col-sm-12 row top-buffer">
        <div class="col-sm-2">
        </div>
        <div class="col-sm-4 align-right">
            <asp:Label ID="Label1" runat="server" Text="Menu Code :">
            </asp:Label>
        </div>
        <div class="col-sm-4">
            <asp:TextBox ID="txt_FunctionCode" runat="server" MaxLength="200">
            </asp:TextBox>
        </div>
        <div class="col-sm-2">
            &nbsp;
        </div>
    </div>
    <div class="col-sm-12 row top-buffer">
        <div class="col-sm-2">
        </div>
        <div class="col-sm-4 align-right">
            <asp:Label ID="Label2" runat="server" Text="Menu Description :"></asp:Label>
        </div>
        <div class="col-sm-4">
            <asp:TextBox ID="txt_FunctionDesc" runat="server" MaxLength="100">
            </asp:TextBox>

        </div>
        <div class="col-sm-2">
            &nbsp;
        </div>
    </div>
    <div class="align-center top-buffer row col-sm-12">
        <asp:Button ID="btn_CreateMenu" runat="server" Text="Create Menu" CssClass="btn btn-primary"></asp:Button>

    </div>

    <p style="padding-bottom: 0px; margin-bottom: 0px">
        <asp:Label ID="Label4" runat="server">Menu List Details :</asp:Label>
        &nbsp;<asp:Label ID="lab_ErrMsg" CssClass="DDValidator" runat="server"></asp:Label>
    </p>
    <div class="align-center top-buffer row col-sm-12">
        <asp:GridView ID="dg_Show" runat="server" AllowPaging="True" PageSize="5" CssClass="table table-striped dataTable">
        </asp:GridView>
    </div>
</asp:Content>
