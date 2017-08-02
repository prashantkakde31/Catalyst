<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeBehind="Discount_Master.aspx.cs" Inherits="CatalystClientUI.Discount_Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="profilecontent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <link href="../Scripts/Pagination.css" rel="stylesheet" />
    <link href="../src/bootstrap-datepicker.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.12.0.js"></script>
    <script src="../assets/js/bootstrap.js"></script>
    <script src="../src/bootstrap-datepicker.js"></script>
    <style type="text/css">
        body {
            background-color: #eee;
        }

        *[role="form"] {
            max-width: 530px;
            padding: 15px;
            margin: 0 auto;
            background-color: #fff;
            border-radius: 0.3em;
        }

            *[role="form"] h2 {
                margin-left: 5em;
                margin-bottom: 1em;
            }

        .btn {
            display: inline-block;
            padding: 6px 12px;
            margin-bottom: 0;
            font-size: 14px;
            font-weight: normal;
            line-height: 1.42857143;
            text-align: center;
            white-space: nowrap;
            vertical-align: middle;
            -ms-touch-action: manipulation;
            touch-action: manipulation;
            cursor: pointer;
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
            background-image: none;
            border: 1px solid transparent;
            border-radius: 4px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            binddata();
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            if (prm != null) {
                prm.add_endRequest(function (sender, e) {
                    if (sender._postBackSettings.panelsToUpdate != null) {
                        binddata();
                    }
                });
            };
        });
        function binddata() {
            $(<%=txtValidFrom.ClientID%>).datepicker({
                autoclose: true,
                format: 'dd/mm/yyyy',
                numberOfMonths: 2,
                onSelect: function (selected) {
                    $(<%=txtValidTo.ClientID%>).datepicker("option", "minDate", selected)
                }

            });

                $(<%=txtValidTo.ClientID%>).datepicker({
                autoclose: true,
                format: "dd/mm/yyyy",
                numberOfMonths: 2,
                onSelect: function (selected) {
                    $("#txtFromDate").datepicker("option", "maxDate", selected)
                }

            });
        };
    </script>
    <div class="page-header">
        <h1>Admin
		<small><i class="ace-icon fa fa-angle-double-right"></i>Discount Master</small>
        </h1>
    </div>

    <div class="panel panel-info">
        <div class="panel-heading">
            <h3 class="panel-title align-center">Discount Master</h3>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="form-group col-sm-6 col-md-12">
                    <label class="col-sm-4 control-label text-right">Discount Name</label>
                    <div class="col-sm-3 control-block">
                        <asp:Label runat="server" ID="lblDiscountID" Visible="false" Text="-1"></asp:Label>
                        <asp:TextBox CssClass="form-control" ID="txtName" runat="server" TabIndex="1" autocomplete="off"></asp:TextBox>
                    </div>
                    <div class="col-sm-3 control-block">
                        <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name Required" Display="Dynamic" ControlToValidate="txtName" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group col-sm-6 col-md-12">
                    <label class="col-sm-4 control-label text-right">Discount Description</label>
                    <div class="col-sm-3 control-block">
                        <asp:TextBox CssClass="form-control" ID="txtDescription" runat="server" TabIndex="2" autocomplete="off"></asp:TextBox>

                    </div>
                    <div class="col-sm-3 control-block">
                        <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Description Required" Display="Dynamic" ControlToValidate="txtDescription" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group col-sm-6 col-md-12">
                    <label class="col-sm-4 control-label text-right">Discount Percentage</label>
                    <div class="col-sm-3 control-block">
                        <asp:TextBox CssClass="form-control" ID="txtPercentage" runat="server" TabIndex="3" autocomplete="off"></asp:TextBox>

                    </div>
                    <div class="col-sm-3 control-block">
                        <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Percentage Required" Display="Dynamic" ControlToValidate="txtPercentage" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                        <asp:RangeValidator CssClass="err-block" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Percentage should be greater than 0 and less than 100" Display="Dynamic" ControlToValidate="txtPercentage" ValidationGroup="ValidationGroup" ForeColor="Red" MinimumValue="0" MaximumValue="100" Type="Double"></asp:RangeValidator>
                    </div>
                </div>
                <div class="form-group col-sm-6 col-md-12">
                    <label class="col-sm-4 control-label text-right">Valid From</label>
                    <div class="col-sm-3 control-block">
                        <asp:TextBox CssClass="form-control" ID="txtValidFrom" runat="server" TabIndex="3" autocomplete="off"></asp:TextBox>
                    </div>
                    <div class="col-sm-3 control-block">
                        <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator4" runat="server" ErrorMessage="ValidFrom Required" Display="Dynamic" ControlToValidate="txtValidFrom" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group col-sm-6 col-md-12">
                    <label class="col-sm-4 control-label text-right">Valid To</label>
                    <div class="col-sm-3 control-block">
                        <asp:TextBox CssClass="form-control" ID="txtValidTo" runat="server" TabIndex="3" autocomplete="off"></asp:TextBox>

                    </div>
                    <div class="col-sm-3 control-block">
                        <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator5" runat="server" ErrorMessage="ValidTo Required" Display="Dynamic" ControlToValidate="txtValidTo" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <%--<div class="form-group col-sm-6 col-md-12">
                    <label class="col-sm-4 control-label text-right">Visible</label>
                    <div class="col-sm-1 control-block">
                        <asp:CheckBox CssClass="form-control" ID="chkVisible" runat="server" TabIndex="3" autocomplete="off"></asp:CheckBox>
                    </div>
                </div>--%>
                <div class="form-group col-sm-6 col-md-12">
                    <div class="col-sm-3 control-block"></div>
                    <div class="col-sm-2 control-block">
                        <asp:Button runat="server" ID="btnAddDiscount" Text="Save" CssClass="btn btn-primary btn-lg btn-block" CausesValidation="true" ValidationGroup="ValidationGroup" OnClick="btnAddDiscount_Click" />
                    </div>
                    <div class="col-sm-2 control-block">
                        <asp:Button runat="server" ID="btnClear" Text="Clear" CssClass="btn btn-primary btn-lg btn-block" CausesValidation="false" OnClick="btnClear_Click" />
                    </div>
                </div>
            </div>
            <asp:GridView runat="server" ID="grdDiscountMaster" AutoGenerateColumns="false" CssClass="table table-bordered table-striped dataTable"
                AutoGenerateSelectButton="true" OnSelectedIndexChanging="grdDiscountMaster_SelectedIndexChanging" OnRowCommand="grdDiscountMaster_RowCommand" AllowPaging="true" PageSize="100" OnPageIndexChanging="grdDiscountMaster_PageIndexChanging" ShowHeaderWhenEmpty="true">
                <Columns>
                    <asp:TemplateField HeaderText="Discount ID" Visible="false">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblID" Text='<%#Eval("DiscountID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sr.No">
                        <ItemTemplate>
                            <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Discount Name">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Description">
                        <ItemTemplate>
                            <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Percentage">
                        <ItemTemplate>
                            <asp:Label ID="lblPercentage" runat="server" Text='<%#Eval("Percentage") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valid From">
                        <ItemTemplate>
                            <asp:Label ID="lblValidFrom" runat="server" Text='<%#Eval("ValidFrom","{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valid To">
                        <ItemTemplate>
                            <asp:Label ID="lblValidTo" runat="server" Text='<%#Eval("ValidUpto","{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="Visible">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkVisible1" runat="server" Checked='<%#Eval("IsVisible") %>'></asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <span onclick="return confirm('Are you sure want to delete?')">
                                <asp:LinkButton ID="btnDelete_Discount" runat="server" CausesValidation="False" CommandName="Delete_Discount"
                                    CommandArgument='<%#Eval("DiscountID") %>'>Delete</asp:LinkButton></span>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>Data Not Found</EmptyDataTemplate>
                <PagerStyle CssClass="pagination-ys" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

