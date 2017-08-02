<%@ Page Title="" Language="VB" AutoEventWireup="false" CodeFile="Add_NewScreen.aspx.vb"
    MasterPageFile="~/Master/MasterPage2.master" Inherits="admin_Add_NewScreen" %>

<asp:Content runat="server" ID="cont" ContentPlaceHolderID="ContentPlaceHolder3">
    
    <div class="page-header">
        <h1>Admin
								<small>
                                    <i class="ace-icon fa fa-angle-double-right"></i>
                                    Add New Screen
                                </small>
        </h1>
    </div>
    <div class="align-center">
        <asp:Button ID="btn_AddScreen" runat="server" Text="Add Screen" CssClass="btn btn-primary"
            CausesValidation="false"></asp:Button>
    </div>

    <div class="col-sm-12 row top-buffer">
        <div class="col-sm-2">
        </div>
        <div class="col-sm-4 align-right">
            <asp:Label ID="Label1" runat="server" Text="Menu Name :"></asp:Label>
        </div>
        <div class="col-sm-4">
            <asp:DropDownList ID="DD_MenuName" runat="server" AutoPostBack="true">
            </asp:DropDownList>
            <asp:TextBox ID="txt_ModuleCodeHide" runat="server" Visible="False" Width="0px"></asp:TextBox>
        </div>
        <div class="col-sm-2">
            &nbsp;
        </div>
    </div>
    <div class="col-sm-12 row top-buffer">
        <div class="col-sm-2">
        </div>
        <div class="col-sm-4 align-right">
            <asp:Label ID="Label3" runat="server" Text="Function Code :"></asp:Label>
        </div>
        <div class="col-sm-4">
            <asp:TextBox ID="txt_FunctionCode" runat="server" MaxLength="200"
                ReadOnly="true"></asp:TextBox>
        </div>
        <div class="col-sm-2">
            &nbsp;
        </div>
    </div>
    <div class="col-sm-12 row top-buffer">
        <div class="col-sm-2">
            &nbsp;
        </div>
        <div class="col-sm-4 align-right">
            <asp:Label ID="Label2" runat="server" Text="Function Description :"></asp:Label>
        </div>
        <div class="col-sm-4">
            <asp:TextBox ID="txt_FunctionDesc" CssClass="DDTextBox" runat="server" MaxLength="100"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="rfv_txt_FunctionDesc" ControlToValidate="txt_FunctionDesc"
                ErrorMessage="Plase enter Function Description" ForeColor="Red" Display="Dynamic"
                Font-Names="Calibri"></asp:RequiredFieldValidator>
        </div>
        <div class="col-sm-2">
            &nbsp;
        </div>
    </div>
    <div class="col-sm-12 row top-buffer">
        <div class="col-sm-2">
            &nbsp;
        </div>
        <div class="col-sm-4 align-right">
            <asp:Label ID="Label4" runat="server" Text="Tool Tip :"></asp:Label>
        </div>
        <div class="col-sm-4">
            <asp:TextBox ID="txt_ToolTip" CssClass="DDTextBox" runat="server" MaxLength="100"></asp:TextBox>
        </div>
        <div class="col-sm-2">
            &nbsp;
        </div>
    </div>
    <div class="col-sm-12 row top-buffer">
        <div class="col-sm-2">
            &nbsp;
        </div>
        <div class="col-sm-4 align-right">
            <asp:Label ID="Label5" runat="server" Text="path :"></asp:Label>
        </div>
        <div class="col-sm-4">
            <asp:TextBox ID="txt_Path" runat="server" CssClass="DDTextBox" MaxLength="100"></asp:TextBox>
        </div>
        <div class="col-sm-2">
            &nbsp;
        </div>
    </div>
    <div class="align-center top-buffer row col-sm-12">
        <asp:Button ID="btn_CreateScreen" runat="server" Text="Create Screen" CssClass="btn btn-primary"></asp:Button>
    </div>

    <p style="padding: 0px; margin: 0px">
        <asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="#0066CC" Font-Names="Arial"
            Font-Size="14pt">Menu List Details :</asp:Label>
        &nbsp;<asp:Label ID="lab_ErrMsg" runat="server" CssClass="DDValidator"></asp:Label>
    </p>
    <div class="align-center top-buffer row col-sm-12">
        <asp:DataGrid ID="dg_Show" runat="server" AutoGenerateColumns="False" 
             CellPadding="5" CssClass="table table-striped dataTable" PageSize="5"
            AllowPaging="True">
            <Columns>
                <asp:BoundColumn DataField="FUNCTION_CODE" HeaderText="Form ID"></asp:BoundColumn>
                <asp:BoundColumn DataField="MODULE_CODE" HeaderText="Parnent Menu"></asp:BoundColumn>
                <asp:BoundColumn DataField="FUNCTION_DESC" HeaderText="Function Description"></asp:BoundColumn>
                <asp:BoundColumn DataField="FUNCTION_SCREEN" HeaderText="Screen"></asp:BoundColumn>
            </Columns>
            <HeaderStyle CssClass="DDLightHeader" HorizontalAlign="Center"></HeaderStyle>
            <FooterStyle CssClass="DDFooter"></FooterStyle>
            <PagerStyle Mode="NumericPages" CssClass="DDPager" HorizontalAlign="Left"></PagerStyle>
        </asp:DataGrid>
    </div>
</asp:Content>
