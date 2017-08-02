<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeBehind="Paper_Master.aspx.cs" Inherits="CatalystClientUI.Paper_Master" %>

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
            $(<%=txtYear.ClientID%>).datepicker({
                autoclose: true,
                minViewMode: 2,
                format: 'yyyy'
            });

            $(<%=txtMonth.ClientID%>).datepicker({
                autoclose: true,
                format: "mm",
                startView: "months",
                minViewMode: "months"
            });

        };

    </script>
    <div class="page-header">
        <h1>Admin
		<small><i class="ace-icon fa fa-angle-double-right"></i>Paper Master</small>
        </h1>
    </div>
    <asp:ToolkitScriptManager runat="server" ID="Toolkit1"></asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title align-center">Paper Master</h3>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="form-group col-sm-6 col-md-6">
                            <label class="col-sm-4 control-label text-right">Paper Name</label>
                            <div class="col-sm-4 control-block">
                                <asp:Label runat="server" ID="lblPaperID" Visible="false" Text="-1"></asp:Label>
                                <asp:TextBox CssClass="form-control" ID="txtName" runat="server" TabIndex="1" autocomplete="off"></asp:TextBox>
                            </div>
                            <div class="col-sm-4 control-block">
                                <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name Required" Display="Dynamic" ControlToValidate="txtName" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group col-sm-6 col-md-6">
                            <label class="col-sm-4 control-label text-right">Paper Description</label>
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
                                <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Sub Course Required" Display="Dynamic" ControlToValidate="ddlSubCourse" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*" InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group col-sm-6 col-md-6">
                            <label class="col-sm-4 control-label text-right">Subject Name</label>
                            <div class="col-sm-4 control-block">
                                <asp:DropDownList CssClass="form-control" ID="ddlSubject" runat="server" TabIndex="3" OnSelectedIndexChanged="ddlSubject_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="False"></asp:DropDownList>
                            </div>
                        </div>
                        <%--<div class="form-group col-sm-6 col-md-6">
                            <label class="col-sm-4 control-label text-right">Topic Name</label>
                            <div class="col-sm-4 control-block">
                                <asp:DropDownList CssClass="form-control" ID="ddlTopic" runat="server" TabIndex="4" AppendDataBoundItems="False"></asp:DropDownList>
                            </div>
                        </div>--%>
                        <div class="form-group col-sm-6 col-md-6">
                            <label class="col-sm-4 control-label text-right">IsSample</label>
                            <div class="col-sm-2 control-block">
                                <asp:CheckBox CssClass="form-control" ID="chkSample" runat="server" TabIndex="6"></asp:CheckBox>
                            </div>
                        </div>

                        <div class="form-group col-sm-6 col-md-6">
                            <label class="col-sm-4 control-label text-right">Year</label>
                            <div class="col-sm-4 control-block">
                                <asp:TextBox CssClass="form-control" ID="txtYear" runat="server" TabIndex="7"></asp:TextBox>
                            </div>
                            <div class="col-sm-4 control-block">
                                <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Year Required" Display="Dynamic" ControlToValidate="txtYear" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group col-sm-6 col-md-6">
                            <label class="col-sm-4 control-label text-right">Month</label>
                            <div class="col-sm-4 control-block">
                                <asp:TextBox runat="server" ID="txtMonth" TabIndex="8"></asp:TextBox>
                            </div>
                            <div class="col-sm-4 control-block">
                                <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Month Required" Display="Dynamic" ControlToValidate="txtMonth" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group col-sm-6 col-md-6">
                            <label class="col-sm-4 control-label text-right">IsYearwise</label>
                            <div class="col-sm-2 control-block">
                                <asp:CheckBox CssClass="form-control" ID="chkYearwise" runat="server" TabIndex="9"></asp:CheckBox>
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
                                <asp:Button runat="server" ID="btnAddPaper" Text="Save" CssClass="btn btn-primary btn-lg btn-block" CausesValidation="true" ValidationGroup="ValidationGroup" OnClick="btnAddPaper_Click" />
                            </div>
                            <div class="col-sm-2 control-block">
                                <asp:Button runat="server" ID="btnClear" Text="Clear" CssClass="btn btn-primary btn-lg btn-block" CausesValidation="false" OnClick="btnClear_Click1" />
                            </div>
                        </div>
                    </div>
                    <asp:GridView runat="server" ID="grdPaperMaster" AutoGenerateColumns="false" CssClass="table table-bordered table-striped dataTable"
                        AutoGenerateSelectButton="true" OnSelectedIndexChanging="grdSubjectMaster_SelectedIndexChanging" OnRowCommand="grdSubjectMaster_RowCommand" AllowPaging="true" PageSize="100" OnPageIndexChanging="grdSubjectMaster_PageIndexChanging" ShowHeaderWhenEmpty="true" OnRowDataBound="grdPaperMaster_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Paper ID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblID" Text='<%#Eval("PaperID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sr.No">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Paper Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="Topic Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblTopicID" runat="server" Text='<%#Eval("TopicID") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblTopicName" runat="server" Text=""></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Subject Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblSubjectID" runat="server" Text='<%#Eval("SubjectId") %>' Visible="false"></asp:Label>
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
                            <asp:TemplateField HeaderText="IsSample">
                                <ItemTemplate>
                                    <asp:Label ID="lblIsSample" runat="server" Text='<%#Eval("IsSample") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="YearWise">
                                <ItemTemplate>
                                    <asp:Label ID="lblYearWise" runat="server" Text='<%#Eval("IsYearwise") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Year">
                                <ItemTemplate>
                                    <asp:Label ID="lblYear" runat="server" Text='<%#Eval("Year") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Month">
                                <ItemTemplate>
                                    <asp:Label ID="lblMonth" runat="server" Text='<%#Eval("Month") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Disable" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblDisable" runat="server" Text='<%#Eval("DisableQuestionAnswer") %>'></asp:Label>
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
                                        <asp:LinkButton ID="btnDelete_Paper" runat="server" CausesValidation="False" CommandName="Delete_Paper"
                                            CommandArgument='<%#Eval("PaperID") %>'>Delete</asp:LinkButton></span>|
                                    <span onclick="return confirm('Are you sure want to Enable/Disable Question?')">
                                        <asp:LinkButton ID="btnDisable_Question" runat="server" CausesValidation="False" CommandName="Disable_QUESTION"
                                            CommandArgument='<%#Eval("PaperID") %>' Text=""></asp:LinkButton></span>|
                                    <span onclick="return confirm('Are you sure want to Enable/Disable Help?')">
                                        <asp:LinkButton ID="btnDisable_HELP" runat="server" CausesValidation="False" CommandName="Disable_HELP"
                                            CommandArgument='<%#Eval("PaperID") %>' Text=""></asp:LinkButton></span>|
                                                                       <span onclick="return confirm('Are you sure want to Enable/Disable Both?')">
                                                                           <asp:LinkButton ID="btnDisable_Both" runat="server" CausesValidation="False" CommandName="Disable_BOTH"
                                                                               CommandArgument='<%#Eval("PaperID") %>' Text=""></asp:LinkButton></span>
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

