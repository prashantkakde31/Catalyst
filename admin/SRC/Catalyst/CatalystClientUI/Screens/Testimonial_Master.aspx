<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeBehind="Testimonial_Master.aspx.cs" Inherits="CatalystClientUI.Testimonial_Master" %>

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

        .modal1 {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 0;
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
            -moz-opacity: 0.8;
        }

        .center1 {
            z-index: 1000;
            margin: 300px auto;
            padding: 10px;
            width: 130px;
            border-radius: 10px;
            filter: alpha(opacity=80);
            opacity: 0.6;
            -moz-opacity: 1;
        }
    </style>
    <div class="page-header">
        <h1>Admin
		<small><i class="ace-icon fa fa-angle-double-right"></i>Testimonial Master</small>
        </h1>
    </div>
    <%--<asp:ToolkitScriptManager runat="server" ID="Toolkit1"></asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <ContentTemplate>--%>
    <div class="panel panel-info">
        <div class="panel-heading">
            <h3 class="panel-title align-center">Testimonial Master</h3>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="form-group col-sm-6 col-md-12">
                    <label class="col-sm-4 control-label text-right">Author Name</label>
                    <div class="col-sm-4 control-block">
                        <asp:Label runat="server" ID="lblTestimonialID" Visible="false" Text="-1"></asp:Label>
                        <asp:TextBox CssClass="form-control" ID="txtAuthor" runat="server" TabIndex="1" autocomplete="off"></asp:TextBox>
                    </div>
                    <div class="col-sm-4 control-block">
                        <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Author Name Required" Display="Dynamic" ControlToValidate="txtAuthor" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group col-sm-6 col-md-12">
                    <label class="col-sm-4 control-label text-right">Photo</label>
                    <div class="col-sm-4 control-block">
                        <asp:FileUpload runat="server" ID="fileUpload" />
                        <asp:Label ID="lblUrl" runat="server" Visible="false"></asp:Label>
                    </div>
                    <%-- <div class="col-sm-4 control-block">
                                <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Description Required" Display="Dynamic" ControlToValidate="txtDescription" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                            </div>--%>
                </div>
                <div class="form-group col-sm-6 col-md-12">
                    <label class="col-sm-4 control-label text-right">Contents</label>
                    <div class="col-sm-4 control-block">
                        <asp:TextBox CssClass="form-control" ID="txtContents" runat="server" TabIndex="2" autocomplete="off" TextMode="MultiLine" Rows="3" Columns="100"></asp:TextBox>
                    </div>
                    <div class="col-sm-4 control-block">
                        <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Contents Required" Display="Dynamic" ControlToValidate="txtContents" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
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
                        <asp:Button runat="server" ID="btnAdd" Text="Save" CssClass="btn btn-primary btn-lg btn-block" CausesValidation="true" ValidationGroup="ValidationGroup" OnClick="btnAdd_Click" />
                    </div>
                    <div class="col-sm-2 control-block">
                        <asp:Button runat="server" ID="btnClear" Text="Clear" CssClass="btn btn-primary btn-lg btn-block" CausesValidation="false" OnClick="btnClear_Click" />
                    </div>
                </div>
            </div>

            <asp:GridView runat="server" ID="grdTestimonial" AutoGenerateColumns="false" CssClass="table table-bordered table-striped dataTable"
                AutoGenerateSelectButton="true" OnSelectedIndexChanging="grdTestimonial_SelectedIndexChanging" OnRowCommand="grdTestimonial_RowCommand" AllowPaging="true" PageSize="100" OnPageIndexChanging="grdTestimonial_PageIndexChanging" ShowHeaderWhenEmpty="true">
                <Columns>
                    <asp:TemplateField HeaderText="Testimonial ID" Visible="false">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblID" Text='<%#Eval("TestimonialID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sr.No">
                        <ItemTemplate>
                            <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Author Name">
                        <ItemTemplate>
                            <asp:Label ID="lblAuthorName" runat="server" Text='<%#Eval("AuthorName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Contents">
                        <ItemTemplate>
                            <asp:Label ID="lblContents" runat="server" Text='<%#Eval("Contents") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Photo">
                        <ItemTemplate>
                            <asp:Image ID="img1" runat="server" ImageUrl='<%# "~/Upload/Testimonial/"+Eval("Photo") %>' Height="100px" Width="100px" Visible="false" />
                            <asp:Label ID="lblimg" runat="server" Text='<%# Eval("Photo") %>'></asp:Label>
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
                                <asp:LinkButton ID="btnDelete_Testimonial" runat="server" CausesValidation="False" CommandName="Delete_Testimonial"
                                    CommandArgument='<%#Eval("TestimonialID") %>'>Delete</asp:LinkButton></span>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>Data Not Found</EmptyDataTemplate>
                <PagerStyle CssClass="pagination-ys" />
            </asp:GridView>
        </div>
    </div>
    <%--  </ContentTemplate>--%>
    <%-- <Triggers>
            <asp:PostBackTrigger ControlID="btnAddCourse" />
            <asp:PostBackTrigger ControlID="btnClear" />
        </Triggers>--%>
    <%-- </asp:UpdatePanel>
    <asp:UpdateProgress ID="updateprogress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="modal1">
                <div class="center1">
                    <img src="../Images/loading2.gif" style="height: 200px; width: 200px" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
