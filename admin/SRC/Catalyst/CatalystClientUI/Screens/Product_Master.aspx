<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeBehind="Product_Master.aspx.cs" Inherits="CatalystClientUI.Product_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
        }
    </script>
    <div class="page-header">
        <h1>Admin
		<small><i class="ace-icon fa fa-angle-double-right"></i>Product Master</small>
        </h1>
    </div>
    <asp:ToolkitScriptManager runat="server" ID="Toolkit1"></asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title align-center">Product Master</h3>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="form-group col-sm-6 col-md-6">
                            <label class="col-sm-4 control-label text-right">Product Name</label>
                            <div class="col-sm-4 control-block">
                                <asp:Label runat="server" ID="lblProductID" Visible="false" Text="-1"></asp:Label>
                                <asp:TextBox CssClass="form-control" ID="txtName" runat="server" TabIndex="1" autocomplete="off"></asp:TextBox>
                            </div>
                            <div class="col-sm-4 control-block">
                                <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name Required" Display="Dynamic" ControlToValidate="txtName" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group col-sm-6 col-md-6">
                            <label class="col-sm-4 control-label text-right">Product Description</label>
                            <div class="col-sm-4 control-block">
                                <asp:TextBox CssClass="form-control" ID="txtDescription" runat="server" TabIndex="2" autocomplete="off"></asp:TextBox>
                            </div>
                            <div class="col-sm-4 control-block">
                                <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Description Required" Display="Dynamic" ControlToValidate="txtDescription" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group col-sm-6 col-md-6">
                            <label class="col-sm-4 control-label text-right">Course Name</label>
                            <div class="col-sm-4 control-block">
                                <asp:DropDownList CssClass="form-control" ID="ddlCourse" runat="server" TabIndex="3" AutoPostBack="true" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" AppendDataBoundItems="False"></asp:DropDownList>
                            </div>
                            <div class="col-sm-3 control-block">
                                <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator29" runat="server" ErrorMessage="Course Required" Display="Dynamic" ControlToValidate="ddlCourse" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*" InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group col-sm-6 col-md-6">
                            <label class="col-sm-4 control-label text-right">SubCourse Name</label>
                            <div class="col-sm-4 control-block">
                                <asp:DropDownList CssClass="form-control" ID="ddlSubCourse" runat="server" TabIndex="4" AutoPostBack="true" OnSelectedIndexChanged="ddlSubCourse_SelectedIndexChanged" AppendDataBoundItems="False"></asp:DropDownList>
                            </div>
                            <div class="col-sm-3 control-block">
                                <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator10" runat="server" ErrorMessage="Sub Course Required" Display="Dynamic" ControlToValidate="ddlSubCourse" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*" InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group col-sm-6 col-md-6">
                            <label class="col-sm-4 control-label text-right">Subject Name</label>
                            <div class="col-sm-4 control-block">
                                <asp:DropDownList CssClass="form-control" ID="ddlSubject" runat="server" TabIndex="3" OnSelectedIndexChanged="ddlSubject_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="False"></asp:DropDownList>
                            </div>
                            <div class="col-sm-4 control-block">
                                <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Subject Required" Display="Dynamic" ControlToValidate="ddlSubject" ValidationGroup="ValidationGroup" ForeColor="Red" Text="Subject Required" InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group col-sm-6 col-md-6">
                            <label class="col-sm-4 control-label text-right">Topic Name</label>
                            <div class="col-sm-4 control-block">
                                <asp:DropDownList CssClass="form-control" ID="ddlTopic" runat="server" TabIndex="4" OnSelectedIndexChanged="ddlTopic_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="False"></asp:DropDownList>
                            </div>
                            <div class="col-sm-4 control-block">
                                <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator7" runat="server" ErrorMessage="Topic Required" Display="Dynamic" ControlToValidate="ddlTopic" ValidationGroup="ValidationGroup" ForeColor="Red" Text="Topic Required" InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group col-sm-6 col-md-6">
                            <label class="col-sm-4 control-label text-right">Paper Name</label>
                            <div class="col-sm-4 control-block">
                                <asp:DropDownList CssClass="form-control" ID="ddlPaper" runat="server" TabIndex="5" AppendDataBoundItems="False"></asp:DropDownList>
                            </div>
                            <div class="col-sm-4 control-block">
                                <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator8" runat="server" ErrorMessage="Paper Required" Display="Dynamic" ControlToValidate="ddlPaper" ValidationGroup="ValidationGroup" ForeColor="Red" Text="Paper Required" InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group col-sm-6 col-md-6">
                            <label class="col-sm-4 control-label text-right">Discount Type</label>
                            <div class="col-sm-4 control-block">
                                <asp:DropDownList CssClass="form-control" ID="ddlDiscount" runat="server" TabIndex="6" AppendDataBoundItems="False"></asp:DropDownList>
                            </div>
                            <div class="col-sm-4 control-block">
                                <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator9" runat="server" ErrorMessage="Discount Required" Display="Dynamic" ControlToValidate="ddlDiscount" ValidationGroup="ValidationGroup" ForeColor="Red" Text="Discount Required" InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group col-sm-6 col-md-6">
                            <label class="col-sm-4 control-label text-right">Price</label>
                            <div class="col-sm-4 control-block">
                                <asp:TextBox CssClass="form-control" ID="txtPrice" runat="server" TabIndex="7" autocomplete="off"></asp:TextBox>
                                <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator11" runat="server" ErrorMessage="Invalid Price" Display="Dynamic" ControlToValidate="txtPrice" ValidationGroup="ValidationGroup" ForeColor="Red" ValidationExpression="^\d+(\.\d)?$"></asp:RegularExpressionValidator>
                            </div>
                            <div class="col-sm-4 control-block">
                                <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Price Required" Display="Dynamic" ControlToValidate="txtPrice" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group col-sm-6 col-md-6">
                            <label class="col-sm-4 control-label text-right">Base Currency</label>
                            <div class="col-sm-4 control-block">
                                <asp:DropDownList CssClass="form-control" ID="ddlCurrency" runat="server" TabIndex="8" AppendDataBoundItems="False"></asp:DropDownList>
                            </div>
                            <div class="col-sm-4 control-block">
                                <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredBaseCurrency" runat="server" ErrorMessage="Currency Required" Display="Dynamic" ControlToValidate="ddlCurrency" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*" InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group col-sm-6 col-md-6">
                            <label class="col-sm-4 control-label text-right">Valid From</label>
                            <div class="col-sm-4 control-block">
                                <asp:TextBox CssClass="form-control" ID="txtValidFrom" runat="server" TabIndex="9" autocomplete="off"></asp:TextBox>
                            </div>
                            <div class="col-sm-4 control-block">
                                <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator4" runat="server" ErrorMessage="ValidFrom Required" Display="Dynamic" ControlToValidate="txtValidFrom" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group col-sm-6 col-md-6">
                            <label class="col-sm-4 control-label text-right">Valid To</label>
                            <div class="col-sm-4 control-block">
                                <asp:TextBox CssClass="form-control" ID="txtValidTo" runat="server" TabIndex="10" autocomplete="off"></asp:TextBox>

                            </div>
                            <div class="col-sm-4 control-block">
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
                            <div class="col-sm-4 control-block"></div>
                            <div class="col-sm-2 control-block">
                                <asp:Button runat="server" ID="btnAddProduct" Text="Save" CssClass="btn btn-primary btn-lg btn-block" CausesValidation="true" ValidationGroup="ValidationGroup" OnClick="btnAddProduct_Click" />
                            </div>
                            <div class="col-sm-2 control-block">
                                <asp:Button runat="server" ID="btnClear" Text="Clear" CssClass="btn btn-primary btn-lg btn-block" CausesValidation="false" OnClick="btnClear_Click" />
                            </div>
                        </div>
                    </div>
                    <asp:GridView runat="server" ID="grdProductMaster" AutoGenerateColumns="false" CssClass="table table-bordered table-striped dataTable"
                        AutoGenerateSelectButton="true" OnSelectedIndexChanging="grdProductMaster_SelectedIndexChanging" OnRowCommand="grdProductMaster_RowCommand" AllowPaging="true" PageSize="100"
                        OnPageIndexChanging="grdProductMaster_PageIndexChanging" ShowHeaderWhenEmpty="true" OnRowDataBound="grdProductMaster_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Product ID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblID" Text='<%#Eval("ProductID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sr.No">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Product Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Discount">
                                <ItemTemplate>
                                    <asp:Label ID="lblDiscountID" runat="server" Text='<%#Eval("DiscountID") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblDiscountName" runat="server" Text=""></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Paper">
                                <ItemTemplate>
                                    <asp:Label ID="lblYearwisePaperID" runat="server" Text='<%#Eval("YearwisePaperID") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblYearwisePaperName" runat="server" Text=""></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Topic">
                                <ItemTemplate>
                                    <asp:Label ID="lblTopicID" runat="server" Text='<%#Eval("TopicID") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblTopicName" runat="server" Text=""></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subject">
                                <ItemTemplate>
                                    <asp:Label ID="lblSubjectID" runat="server" Text='<%#Eval("SubjectID") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblSubjectName" runat="server" Text=""></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SubCourse Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblSubCourse" runat="server" Text="" Visible="false"></asp:Label>
                                    <asp:Label ID="lblSubCourseName" runat="server" Text=""></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Course Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblCourse" runat="server" Text="" Visible="false"></asp:Label>
                                    <asp:Label ID="lblCourseName" runat="server" Text=""></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Price">
                                <ItemTemplate>
                                    <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("Price","{0:N2}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Currency">
                                <ItemTemplate>
                                    <asp:Label ID="lblCurrencyID" runat="server" Text='<%#Eval("BaseCurrency") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblCurrencyName" runat="server" Text=""></asp:Label>
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
                                        <asp:LinkButton ID="btnDelete_Product" runat="server" CausesValidation="False" CommandName="Delete_Product"
                                            CommandArgument='<%#Eval("ProductID") %>'>Delete</asp:LinkButton></span>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>Data Not Found</EmptyDataTemplate>
                        <PagerStyle CssClass="pagination-ys" />
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
