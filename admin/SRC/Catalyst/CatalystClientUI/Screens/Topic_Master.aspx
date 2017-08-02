<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeBehind="Topic_Master.aspx.cs" Inherits="CatalystClientUI.Topic_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="profilecontent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <link href="../Scripts/Pagination.css" rel="stylesheet" />
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
       
    </script>
    <div class="page-header">
        <h1>Admin
		<small><i class="ace-icon fa fa-angle-double-right"></i>Topic Master</small>
        </h1>
    </div>
    <asp:ToolkitScriptManager runat="server" ID="Toolkit1"></asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title align-center">Topic Master</h3>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="form-group col-sm-6 col-md-12">
                            <label class="col-sm-4 control-label text-right">Topic Name</label>
                            <div class="col-sm-4 control-block">
                                <asp:Label runat="server" ID="lblTopicID" Visible="false" Text="-1"></asp:Label>
                                <asp:TextBox CssClass="form-control" ID="txtName" runat="server" TabIndex="1" autocomplete="off"></asp:TextBox>
                            </div>
                            <div class="col-sm-4 control-block">
                                <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name Required" Display="Dynamic" ControlToValidate="txtName" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group col-sm-6 col-md-12">
                            <label class="col-sm-4 control-label text-right">Topic Description</label>
                            <div class="col-sm-4 control-block">
                                <asp:TextBox CssClass="form-control" ID="txtDescription" runat="server" TabIndex="2" autocomplete="off"></asp:TextBox>
                            </div>
                            <div class="col-sm-4 control-block">
                                <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Description Required" Display="Dynamic" ControlToValidate="txtDescription" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group col-sm-6 col-md-12">
                            <label class="col-sm-4 control-label text-right">Course Name</label>
                            <div class="col-sm-3 control-block">
                                <asp:DropDownList CssClass="form-control" ID="ddlCourse" runat="server" TabIndex="3" AutoPostBack="true" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" AppendDataBoundItems="False"></asp:DropDownList>
                            </div>
                            <div class="col-sm-3 control-block">
                                <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator29" runat="server" ErrorMessage="Course Required" Display="Dynamic" ControlToValidate="ddlCourse" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*" InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group col-sm-6 col-md-12">
                            <label class="col-sm-4 control-label text-right">SubCourse Name</label>
                            <div class="col-sm-3 control-block">
                                <asp:DropDownList CssClass="form-control" ID="ddlSubCourse" runat="server" TabIndex="4" AutoPostBack="true" OnSelectedIndexChanged="ddlSubCourse_SelectedIndexChanged" AppendDataBoundItems="False"></asp:DropDownList>
                            </div>
                            <div class="col-sm-3 control-block">
                                <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Sub Course Required" Display="Dynamic" ControlToValidate="ddlSubCourse" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*" InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group col-sm-6 col-md-12">
                            <label class="col-sm-4 control-label text-right">Subject Name</label>
                            <div class="col-sm-3 control-block">
                                <asp:DropDownList CssClass="form-control" ID="ddlSubject" runat="server" TabIndex="5" AppendDataBoundItems="False" AutoPostBack="true" OnSelectedIndexChanged="ddlSubject_SelectedIndexChanged"></asp:DropDownList>
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
                                <asp:Button runat="server" ID="btnAddTopic" Text="Save" CssClass="btn btn-primary btn-lg btn-block" CausesValidation="true" ValidationGroup="ValidationGroup" OnClick="btnAddTopic_Click" />
                            </div>
                            <div class="col-sm-2 control-block">
                                <asp:Button runat="server" ID="btnClear" Text="Clear" CssClass="btn btn-primary btn-lg btn-block" CausesValidation="false" OnClick="btnClear_Click" />
                            </div>
                        </div>
                    </div>

                    <asp:GridView runat="server" ID="grdTopicMaster" AutoGenerateColumns="false" CssClass="table table-bordered table-striped dataTable"
                        AutoGenerateSelectButton="true" OnSelectedIndexChanging="grdTopicMaster_SelectedIndexChanging" OnRowCommand="grdTopicMaster_RowCommand" AllowPaging="true" PageSize="100" OnPageIndexChanging="grdTopicMaster_PageIndexChanging" ShowHeaderWhenEmpty="true" OnRowDataBound="grdTopicMaster_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Topic ID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblID" Text='<%#Eval("TopicID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sr.No">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Topic Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subject Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblSubject" runat="server" Text='<%#Eval("SubjectID") %>' Visible="false"></asp:Label>
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
                            <%--<asp:TemplateField HeaderText="Visible">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkVisible1" runat="server" Checked='<%#Eval("IsVisible") %>'></asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <span onclick="return confirm('Are you sure want to delete?')">
                                        <asp:LinkButton ID="btnDelete_Topic" runat="server" CausesValidation="False" CommandName="Delete_Topic"
                                            CommandArgument='<%#Eval("TopicID") %>'>Delete</asp:LinkButton></span>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>Data Not Found</EmptyDataTemplate>
                        <PagerStyle CssClass="pagination-ys" />
                    </asp:GridView>

                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>


