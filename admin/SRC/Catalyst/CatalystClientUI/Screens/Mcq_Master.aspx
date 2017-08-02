<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeBehind="Mcq_Master.aspx.cs" Inherits="CatalystClientUI.Mcq_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="profilecontent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <link href="../Scripts/Pagination.css" rel="stylesheet" />
    <link href="../src/bootstrap-datepicker.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.12.0.js"></script>
    <script src="../assets/js/bootstrap.js"></script>
    <%--<script src="../src/bootstrap-datepicker.js"></script>--%>
    <%--<script src="../assets/js/date-time/bootstrap-datetimepicker.js"></script>--%>
    <script src="../assets/js/date-time/bootstrap-timepicker.js"></script>
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

        .display {
            display: none;
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
            $('#<%=txtTime.ClientID%>').timepicker({
                timeFormat: 'h:mm:ss',
                minuteStep: 1,
                showSeconds: true,
                showMeridian: false,
                defaultTime: '00:05:00'
            });

            $("input:file").change(function () {
                var fileName = $(this).val();
                $(".filename").html(fileName);
            });

            $('#<%=QuestionImage.ClientID%>').change(function () {
                if (typeof (FileReader) != "undefined") {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $('#<%=PreviewQuestion.ClientID%>').attr("src", e.target.result);
                    }
                    reader.readAsDataURL($(this)[0].files[0]);
                    } else {
                        alert("This browser does not support FileReader.");
                    }
            });
                $('#<%=QuestionImage2.ClientID%>').change(function () {
                if (typeof (FileReader) != "undefined") {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $('#<%=PreviewQuestion2.ClientID%>').attr("src", e.target.result);
                    }
                    reader.readAsDataURL($(this)[0].files[0]);
                    } else {
                        alert("This browser does not support FileReader.");
                    }
                });


                $('#<%=CommonAnswer.ClientID%>').change(function () {
                if (typeof (FileReader) != "undefined") {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $('#<%=PreviewCommonAnswer.ClientID%>').attr("src", e.target.result);
                    }
                    reader.readAsDataURL($(this)[0].files[0]);
                    } else {
                        alert("This browser does not support FileReader.");
                    }
                });
                $('#<%=AnswerImage1.ClientID%>').change(function () {
                if (typeof (FileReader) != "undefined") {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $('#<%=PreviewAnswerImage1.ClientID%>').attr("src", e.target.result);
                    }
                    reader.readAsDataURL($(this)[0].files[0]);
                    } else {
                        alert("This browser does not support FileReader.");
                    }
                });
                $('#<%=AnswerImage2.ClientID%>').change(function () {
                if (typeof (FileReader) != "undefined") {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $('#<%=PreviewAnswerImage2.ClientID%>').attr("src", e.target.result);
                    }
                    reader.readAsDataURL($(this)[0].files[0]);
                    } else {
                        alert("This browser does not support FileReader.");
                    }
                });
                $('#<%=AnswerImage3.ClientID%>').change(function () {
                if (typeof (FileReader) != "undefined") {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $('#<%=PreviewAnswerImage3.ClientID%>').attr("src", e.target.result);
                    }
                    reader.readAsDataURL($(this)[0].files[0]);
                    } else {
                        alert("This browser does not support FileReader.");
                    }
                });
                $('#<%=AnswerImage4.ClientID%>').change(function () {
                if (typeof (FileReader) != "undefined") {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $('#<%=PreviewAnswerImage4.ClientID%>').attr("src", e.target.result);
                    }
                    reader.readAsDataURL($(this)[0].files[0]);
                    } else {
                        alert("This browser does not support FileReader.");
                    }
                });

                $('#<%=SolutionImage.ClientID%>').change(function () {
                if (typeof (FileReader) != "undefined") {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $('#<%=PreviewSolutionImage.ClientID%>').attr("src", e.target.result);
                    }
                    reader.readAsDataURL($(this)[0].files[0]);
                    } else {
                        alert("This browser does not support FileReader.");
                    }
                });

                $('#<%=btnClear1.ClientID%>').click(function () {
                //Reference the FileUpload and get its Id and Name.
                var fileUpload = $('#<%=QuestionImage.ClientID%>');
                    var id = fileUpload.attr("id");
                    var name = fileUpload.attr("name");

                    //Create a new FileUpload element.
                    var newFileUpload = $("<input type = 'file' />");

                    //Append it next to the original FileUpload.
                    fileUpload.after(newFileUpload);

                    //Remove the original FileUpload.
                    fileUpload.remove();

                    //Set the Id and Name to the new FileUpload.
                    newFileUpload.attr("id", id);
                    newFileUpload.attr("name", name);
                    return false;
                });

                $('#<%=btnClear2.ClientID%>').click(function () {
                //Reference the FileUpload and get its Id and Name.
                var fileUpload = $('#<%=CommonAnswer.ClientID%>');
                    var id = fileUpload.attr("id");
                    var name = fileUpload.attr("name");

                    //Create a new FileUpload element.
                    var newFileUpload = $("<input type = 'file' />");

                    //Append it next to the original FileUpload.
                    fileUpload.after(newFileUpload);

                    //Remove the original FileUpload.
                    fileUpload.remove();

                    //Set the Id and Name to the new FileUpload.
                    newFileUpload.attr("id", id);
                    newFileUpload.attr("name", name);
                    return false;
                });
                $('#<%=btnClear3.ClientID%>').click(function () {
                //Reference the FileUpload and get its Id and Name.
                var fileUpload = $('#<%=SolutionImage.ClientID%>');
                    var id = fileUpload.attr("id");
                    var name = fileUpload.attr("name");

                    //Create a new FileUpload element.
                    var newFileUpload = $("<input type = 'file' />");

                    //Append it next to the original FileUpload.
                    fileUpload.after(newFileUpload);

                    //Remove the original FileUpload.
                    fileUpload.remove();

                    //Set the Id and Name to the new FileUpload.
                    newFileUpload.attr("id", id);
                    newFileUpload.attr("name", name);
                    return false;
                });

                $('#<%=btnAnswerClear1.ClientID%>').click(function () {
                //Reference the FileUpload and get its Id and Name.
                var fileUpload = $('#<%=AnswerImage1.ClientID%>');
                    var id = fileUpload.attr("id");
                    var name = fileUpload.attr("name");

                    //Create a new FileUpload element.
                    var newFileUpload = $("<input type = 'file' />");

                    //Append it next to the original FileUpload.
                    fileUpload.after(newFileUpload);

                    //Remove the original FileUpload.
                    fileUpload.remove();

                    //Set the Id and Name to the new FileUpload.
                    newFileUpload.attr("id", id);
                    newFileUpload.attr("name", name);
                    return false;
                });
                $('#<%=btnAnswerClear2.ClientID%>').click(function () {
                //Reference the FileUpload and get its Id and Name.
                var fileUpload = $('#<%=AnswerImage2.ClientID%>');
                    var id = fileUpload.attr("id");
                    var name = fileUpload.attr("name");

                    //Create a new FileUpload element.
                    var newFileUpload = $("<input type = 'file' />");

                    //Append it next to the original FileUpload.
                    fileUpload.after(newFileUpload);

                    //Remove the original FileUpload.
                    fileUpload.remove();

                    //Set the Id and Name to the new FileUpload.
                    newFileUpload.attr("id", id);
                    newFileUpload.attr("name", name);
                    return false;
                });
                $('#<%=btnAnswerClear3.ClientID%>').click(function () {
                //Reference the FileUpload and get its Id and Name.
                var fileUpload = $('#<%=AnswerImage3.ClientID%>');
                    var id = fileUpload.attr("id");
                    var name = fileUpload.attr("name");

                    //Create a new FileUpload element.
                    var newFileUpload = $("<input type = 'file' />");

                    //Append it next to the original FileUpload.
                    fileUpload.after(newFileUpload);

                    //Remove the original FileUpload.
                    fileUpload.remove();

                    //Set the Id and Name to the new FileUpload.
                    newFileUpload.attr("id", id);
                    newFileUpload.attr("name", name);
                    return false;
                });

                $('#<%=btnAnswerClear4.ClientID%>').click(function () {
                //Reference the FileUpload and get its Id and Name.
                var fileUpload = $('#<%=AnswerImage4.ClientID%>');
                    var id = fileUpload.attr("id");
                    var name = fileUpload.attr("name");

                    //Create a new FileUpload element.
                    var newFileUpload = $("<input type = 'file' />");

                    //Append it next to the original FileUpload.
                    fileUpload.after(newFileUpload);

                    //Remove the original FileUpload.
                    fileUpload.remove();

                    //Set the Id and Name to the new FileUpload.
                    newFileUpload.attr("id", id);
                    newFileUpload.attr("name", name);
                    return false;
                });
            };


    </script>
    <div class="page-header">
        <h1>Admin
		<small><i class="ace-icon fa fa-angle-double-right"></i>Mcq Master</small>
        </h1>
    </div>
    <asp:ToolkitScriptManager runat="server" ID="Toolkit1"></asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title align-center">Mcq Master</h3>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="form-group col-sm-6 col-md-3">
                            <label class="col-sm-5 control-label text-left">Marks</label>
                            <div class="col-sm-6 control-block">
                                <asp:TextBox CssClass="form-control" ID="txtMarks" runat="server" TabIndex="1" autocomplete="off"></asp:TextBox>
                                <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid Marks" Display="Dynamic" ControlToValidate="txtMarks" ValidationGroup="ValidationGroup" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                            </div>
                            <div class="col-sm-1 control-block">
                                <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Marks Required" Display="Dynamic" ControlToValidate="txtMarks" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group col-sm-6 col-md-3">
                            <label class="col-sm-5 control-label text-left">Time To Solve</label>
                            <div class="col-sm-6 control-block">
                                <asp:TextBox CssClass="form-control" ID="txtTime" runat="server" TabIndex="2" autocomplete="off"></asp:TextBox>
                            </div>
                            <div class="col-sm-1 control-block">
                                <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Time Required" Display="Dynamic" ControlToValidate="txtTime" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group col-sm-6 col-md-3">
                            <label class="col-sm-5 control-label text-right">Course Name</label>
                            <div class="col-sm-6 control-block">
                                <asp:DropDownList CssClass="form-control" ID="ddlCourse" runat="server" TabIndex="3" AutoPostBack="true" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" AppendDataBoundItems="False"></asp:DropDownList>
                            </div>
                            <div class="col-sm-1 control-block">
                                <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator29" runat="server" ErrorMessage="Course Required" Display="Dynamic" ControlToValidate="ddlCourse" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*" InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group col-sm-6 col-md-3">
                            <label class="col-sm-5 control-label text-right">SubCourse Name</label>
                            <div class="col-sm-6 control-block">
                                <asp:DropDownList CssClass="form-control" ID="ddlSubCourse" runat="server" TabIndex="4" AutoPostBack="true" OnSelectedIndexChanged="ddlSubCourse_SelectedIndexChanged" AppendDataBoundItems="False"></asp:DropDownList>
                            </div>
                            <div class="col-sm-1 control-block">
                                <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator10" runat="server" ErrorMessage="Sub Course Required" Display="Dynamic" ControlToValidate="ddlSubCourse" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*" InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group col-sm-6 col-md-3">
                            <label class="col-sm-5 control-label text-left">Subject Name</label>
                            <div class="col-sm-6 control-block">
                                <asp:DropDownList CssClass="form-control" ID="ddlSubject" runat="server" TabIndex="5" OnSelectedIndexChanged="ddlSubject_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="False"></asp:DropDownList>
                            </div>
                            <div class="col-sm-1 control-block">
                                <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator11" runat="server" ErrorMessage="Subject Required" Display="Dynamic" ControlToValidate="ddlSubject" ValidationGroup="ValidationGroup" ForeColor="Red" Text="Year Paper Required" InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group col-sm-6 col-md-3">
                            <label class="col-sm-5 control-label text-left">Topic Id</label>
                            <div class="col-sm-6 control-block">
                                <asp:DropDownList CssClass="form-control" ID="ddlTopicPaper" runat="server" TabIndex="6" OnSelectedIndexChanged="ddlTopicPaper_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                            <div class="col-sm-1 control-block">
                                <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Topic Paper Required" Display="Dynamic" ControlToValidate="ddlTopicPaper" ValidationGroup="ValidationGroup" ForeColor="Red" Text="Topic Paper Required" InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group col-sm-6 col-md-3">
                            <label class="col-sm-5 control-label text-right">YearWisePaper Id</label>
                            <div class="col-sm-6 control-block">
                                <asp:DropDownList CssClass="form-control" ID="ddlYearPaper" runat="server" TabIndex="7" AutoPostBack="true" OnSelectedIndexChanged="ddlYearPaper_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="col-sm-1 control-block">
                                <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator7" runat="server" ErrorMessage="Year Paper Required" Display="Dynamic" ControlToValidate="ddlYearPaper" ValidationGroup="ValidationGroup" ForeColor="Red" Text="Year Paper Required" InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group col-sm-6 col-md-8">
                            <label class="col-sm-2 control-label text-left">Question Text 1</label>
                            <div class="col-sm-10 control-block">
                                <asp:Label runat="server" ID="lblMcqID" Visible="false" Text="-1"></asp:Label>
                                <asp:TextBox CssClass="form-control" ID="txtText1" runat="server" TabIndex="8" autocomplete="off" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Text 1 Required" Display="Dynamic" ControlToValidate="txtText1" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group col-sm-6 col-md-4">
                            <div class="row">
                                <label class="col-sm-3 control-label text-left">Question Image</label>
                                <div class="col-sm-4 control-block">
                                    <asp:FileUpload runat="server" ID="QuestionImage" TabIndex="9" Style="font-size: 10px" />
                                </div>
                                <div class="col-sm-3 control-block">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator42" runat="server"
                                        ControlToValidate="QuestionImage"
                                        ErrorMessage="Only .jpg,.png,.jpeg,.gif Files are allowed" Font-Bold="True"
                                        Font-Size="Medium"
                                        ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$" ValidationGroup="ValidationGroup" Display="Dynamic" ForeColor="Red">
                                    </asp:RegularExpressionValidator>
                                </div>
                                <div class="col-sm-2">
                                    <asp:Button ID="btnClear1" Text="Clear" runat="server" OnClick="btnClear1_Click" UseSubmitBehavior="false" CssClass="btn btn-primary" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-2"></div>
                                <div class="col-sm-8 align-center">
                                    <asp:Image runat="server" ImageUrl="../Images/image.jpg" alt="No Image" class="img-thumbnail" ID="PreviewQuestion" Style="width: 50%; height: 50%" />
                                </div>
                            </div>
                        </div>

                        <div class="form-group col-sm-6 col-md-8">
                            <div class="row">
                                <label class="col-sm-2 control-label text-left">Question Audio</label>
                                <div class="col-sm-8 control-block">
                                    <asp:FileUpload runat="server" ID="QuestionAudio" TabIndex="10" Style="font-size: 10px" />
                                </div>
                                <div class="col-sm-2 control-block">
                                    <asp:RegularExpressionValidator
                                        ID="RegularExpressionValidator4" runat="server" ErrorMessage="Only wav or mp3 file is allowed!"
                                        ValidationExpression="^.+(.wav|.WAV|.mp3|.MP3)$"
                                        ControlToValidate="QuestionAudio" Display="Dynamic" ValidationGroup="ValidationGroup" ForeColor="Red"> 
                                    </asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-2"></div>
                                <div class="col-sm-8 align-center">
                                    <asp:Label ID="QuestionAudioLink" runat="server" Text="" ForeColor="Blue" Font-Underline="true"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="form-group col-sm-6 col-md-4">
                            <div class="row">
                                <label class="col-sm-3 control-label text-left">Question Image 2</label>
                                <div class="col-sm-4 control-block">
                                    <asp:FileUpload runat="server" ID="QuestionImage2" TabIndex="11" Style="font-size: 10px" />
                                </div>
                                <div class="col-sm-3 control-block">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                                        ControlToValidate="QuestionImage2"
                                        ErrorMessage="Only .jpg,.png,.jpeg,.gif Files are allowed" Font-Bold="True"
                                        Font-Size="Medium"
                                        ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$" ValidationGroup="ValidationGroup" Display="Dynamic" ForeColor="Red">
                                    </asp:RegularExpressionValidator>
                                </div>
                                <div class="col-sm-2">
                                    <asp:Button ID="btnClear4" Text="Clear" runat="server" OnClick="btnClear4_Click" UseSubmitBehavior="false" CssClass="btn btn-primary" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-2"></div>
                                <div class="col-sm-8 align-center">
                                    <asp:Image runat="server" ImageUrl="../Images/image.jpg" alt="No Image" class="img-thumbnail" ID="PreviewQuestion2" Style="width: 50%; height: 50%" />
                                </div>
                            </div>
                        </div>

                        <div class="form-group col-sm-6 col-md-8">
                            <label class="col-sm-2 control-label text-left">Question Text 2</label>
                            <div class="col-sm-10 control-block">
                                <asp:TextBox CssClass="form-control" ID="txtQuestionText2" runat="server" TabIndex="12" autocomplete="off" TextMode="MultiLine" Rows="5"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-sm-6 col-md-4">
                            <div class="row">
                                <label class="col-sm-3 control-label text-left">Common Answer Image</label>
                                <div class="col-sm-4 control-block">
                                    <asp:FileUpload runat="server" ID="CommonAnswer" TabIndex="13" Style="font-size: 10px" />
                                </div>
                                <div class="col-sm-3 control-block">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                                        ControlToValidate="CommonAnswer"
                                        ErrorMessage="Only .jpg,.png,.jpeg,.gif Files are allowed" Font-Bold="True"
                                        Font-Size="Medium"
                                        ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$" ValidationGroup="ValidationGroup" ForeColor="Red"></asp:RegularExpressionValidator>
                                </div>
                                <div class="col-sm-2">
                                    <asp:Button ID="btnClear2" Text="Clear" runat="server" OnClick="btnClear2_Click" UseSubmitBehavior="false" CssClass="btn btn-primary" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8 align-center">
                                    <asp:Image runat="server" ImageUrl="../Images/image.jpg" alt="No Image" class="img-thumbnail" ID="PreviewCommonAnswer" Style="width: 50%; height: 50%" />
                                </div>
                            </div>
                        </div>
                        <asp:HiddenField ID="AnswerType" runat="server" Value="NONE" />
                        <div class="form-group col-sm-6 col-md-12 well">
                            <label class="col-sm-1 control-label text-center">Sr.</label>
                            <label class="col-sm-5 control-label text-center">Answer</label>
                            <label class="col-sm-4 control-label text-center">Answer Image</label>
                            <label class="col-sm-2 control-label text-center">Right Answer</label>
                        </div>
                        <div class="form-group col-sm-6 col-md-12 well">
                            <label class="col-sm-1 control-label text-center">a.</label>
                            <div class="col-sm-5 control-block">
                                <asp:Label runat="server" ID="lblAnswerID1" Text="" Visible="false"></asp:Label>
                                <asp:TextBox CssClass="form-control" ID="txtAnswer1" runat="server" TabIndex="14" autocomplete="off" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Answer 1 Required" Display="None" ControlToValidate="txtAnswer1" ValidationGroup="ValidationGroup2" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-sm-3 control-block">
                                <div class="row">
                                    <asp:FileUpload runat="server" ID="AnswerImage1" TabIndex="15" Style="font-size: 10px" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                        ControlToValidate="AnswerImage1"
                                        ErrorMessage="Only .jpg,.png,.jpeg,.gif Files are allowed" Font-Bold="True"
                                        Font-Size="Medium"
                                        ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$" ValidationGroup="ValidationGroup3" ForeColor="Red" Display="None"></asp:RegularExpressionValidator>
                                </div>
                                <div class="row">
                                    <div class="col-sm-2">
                                        <asp:Button ID="btnAnswerClear1" Text="Clear" runat="server" OnClick="btnAnswerClear1_Click" UseSubmitBehavior="false" CssClass="btn btn-primary" Style="margin-top: 4px;" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-2 control-block align-center">
                                <asp:Image runat="server" ImageUrl="../Images/image.jpg" alt="No Image" class="img-thumbnail" ID="PreviewAnswerImage1" Style="width: 50%; height: 50%" />
                            </div>
                            <div class="col-sm-1 control-block align-center">
                                <asp:RadioButton runat="server" ID="opt1" GroupName="CorrectAnswer" CssClass="radio-inline" TabIndex="16"></asp:RadioButton>
                                <asp:Label ID="lblAnswer1" runat="server" Text="" Visible="false"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group col-sm-6 col-md-12 well">
                            <label class="col-sm-1 control-label text-center">b.</label>
                            <div class="col-sm-5 control-block">
                                <asp:Label runat="server" ID="lblAnswerID2" Text="" Visible="false"></asp:Label>
                                <asp:TextBox CssClass="form-control" ID="txtAnswer2" runat="server" TabIndex="17" autocomplete="off" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Answer 2 Required" Display="None" ControlToValidate="txtAnswer2" ValidationGroup="ValidationGroup2" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-sm-3 control-block">
                                <div class="row">
                                    <asp:FileUpload runat="server" ID="AnswerImage2" TabIndex="18" Style="font-size: 10px" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server"
                                        ControlToValidate="AnswerImage2"
                                        ErrorMessage="Only .jpg,.png,.jpeg,.gif Files are allowed" Font-Bold="True"
                                        Font-Size="Medium"
                                        ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$" ValidationGroup="ValidationGroup3" ForeColor="Red" Display="None"></asp:RegularExpressionValidator>
                                </div>
                                <div class="row">
                                    <div class="col-sm-2">
                                        <asp:Button ID="btnAnswerClear2" Text="Clear" runat="server" OnClick="btnAnswerClear2_Click" UseSubmitBehavior="false" CssClass="btn btn-primary" Style="margin-top: 4px;" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-2 control-block align-center">
                                <asp:Image runat="server" ImageUrl="../Images/image.jpg" alt="No Image" class="img-thumbnail" ID="PreviewAnswerImage2" Style="width: 50%; height: 50%" />
                            </div>
                            <div class="col-sm-1 control-block align-center">
                                <asp:RadioButton runat="server" ID="opt2" GroupName="CorrectAnswer" CssClass="radio-inline" TabIndex="19"></asp:RadioButton>
                                <asp:Label ID="lblAnswer2" runat="server" Text="" Visible="false"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group col-sm-6 col-md-12 well">
                            <label class="col-sm-1 control-label text-center">c.</label>
                            <div class="col-sm-5 control-block">
                                <asp:Label runat="server" ID="lblAnswerID3" Text="" Visible="false"></asp:Label>
                                <asp:TextBox CssClass="form-control" ID="txtAnswer3" runat="server" TabIndex="20" autocomplete="off" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator8" runat="server" ErrorMessage="Answer 3 Required" Display="None" ControlToValidate="txtAnswer3" ValidationGroup="ValidationGroup2" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-sm-3 control-block">
                                <div class="row">
                                    <asp:FileUpload runat="server" ID="AnswerImage3" TabIndex="21" Style="font-size: 10px" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server"
                                        ControlToValidate="AnswerImage3"
                                        ErrorMessage="Only .jpg,.png,.jpeg,.gif Files are allowed" Font-Bold="True"
                                        Font-Size="Medium"
                                        ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$" ValidationGroup="ValidationGroup3" ForeColor="Red" Display="None"></asp:RegularExpressionValidator>
                                </div>
                                <div class="row">
                                    <div class="col-sm-2">
                                        <asp:Button ID="btnAnswerClear3" Text="Clear" runat="server" OnClick="btnAnswerClear3_Click" UseSubmitBehavior="false" CssClass="btn btn-primary" Style="margin-top: 4px;" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-2 control-block align-center">
                                <asp:Image runat="server" ImageUrl="../Images/image.jpg" alt="No Image" class="img-thumbnail" ID="PreviewAnswerImage3" Style="width: 50%; height: 50%" />
                            </div>
                            <div class="col-sm-1 control-block align-center">
                                <asp:RadioButton runat="server" ID="opt3" GroupName="CorrectAnswer" CssClass="radio-inline" TabIndex="22"></asp:RadioButton>
                                <asp:Label ID="lblAnswer3" runat="server" Text="" Visible="false"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group col-sm-6 col-md-12 well">
                            <label class="col-sm-1 control-label text-center">d.</label>
                            <div class="col-sm-5 control-block">
                                <asp:Label runat="server" ID="lblAnswerID4" Text="" Visible="false"></asp:Label>
                                <asp:TextBox CssClass="form-control" ID="txtAnswer4" runat="server" TabIndex="23" autocomplete="off" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator9" runat="server" ErrorMessage="Answer 4 Required" Display="None" ControlToValidate="txtAnswer4" ValidationGroup="ValidationGroup2" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-sm-3 control-block">
                                <div class="row">
                                    <asp:FileUpload runat="server" ID="AnswerImage4" TabIndex="24" Style="font-size: 10px" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server"
                                        ControlToValidate="AnswerImage4"
                                        ErrorMessage="Only .jpg,.png,.jpeg,.gif Files are allowed" Font-Bold="True"
                                        Font-Size="Medium"
                                        ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$" ValidationGroup="ValidationGroup3" ForeColor="Red" Display="None"></asp:RegularExpressionValidator>
                                </div>
                                <div class="row">
                                    <div class="col-sm-2">
                                        <asp:Button ID="btnAnswerClear4" Text="Clear" runat="server" OnClick="btnAnswerClear4_Click" UseSubmitBehavior="false" CssClass="btn btn-primary" Style="margin-top: 4px;" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-2 control-block align-center">
                                <asp:Image runat="server" ImageUrl="../Images/image.jpg" alt="No Image" class="img-thumbnail" ID="PreviewAnswerImage4" Style="width: 50%; height: 50%" />
                            </div>
                            <div class="col-sm-1 control-block align-center">
                                <asp:RadioButton runat="server" ID="opt4" GroupName="CorrectAnswer" CssClass="radio-inline" TabIndex="25"></asp:RadioButton>
                                <asp:Label ID="lblAnswer4" runat="server" Text="" Visible="false"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group col-sm-6 col-md-8">
                            <asp:ValidationSummary ID="ValClient"
                                DisplayMode="BulletList"
                                EnableClientScript="true" ValidationGroup="ValidationGroup2" runat="server" CssClass="alert alert-danger padd" />
                        </div>
                        <div class="form-group col-sm-6 col-md-12">
                            <label class="col-sm-3 control-label text-left">Solution Text</label>
                        </div>
                        <div class="form-group col-sm-6 col-md-8">
                            <div class="col-sm-12 control-block">
                                <asp:TextBox CssClass="form-control" ID="txtSolution" runat="server" TabIndex="26" autocomplete="off" TextMode="MultiLine" Rows="8"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group col-sm-6 col-md-4">
                            <div class="row">
                                <label class="col-sm-3 control-label text-left">Solution Image</label>
                                <div class="col-sm-4 control-block">
                                    <asp:FileUpload runat="server" ID="SolutionImage" TabIndex="27" Style="font-size: 10px" />
                                </div>

                                <div class="col-sm-3 control-block">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator41" runat="server"
                                        ControlToValidate="SolutionImage"
                                        ErrorMessage="Only .jpg,.png,.jpeg,.gif Files are allowed" Font-Bold="True"
                                        Font-Size="Medium"
                                        ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$" ValidationGroup="ValidationGroup" ForeColor="Red"></asp:RegularExpressionValidator>
                                </div>
                                <div class="col-sm-2">
                                    <asp:Button ID="btnClear3" Text="Clear" runat="server" OnClick="btnClear3_Click" UseSubmitBehavior="false" CssClass="btn btn-primary" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-2"></div>
                                <div class="col-sm-8 align-center">
                                    <asp:Image runat="server" ImageUrl="../Images/image.jpg" alt="No Image" class="img-thumbnail" ID="PreviewSolutionImage" Style="width: 50%; height: 50%" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group col-sm-6 col-md-6">
                            <label class="col-sm-2 control-label text-left">Solution Audio </label>
                            <div class="col-sm-5 control-block">
                                <asp:FileUpload runat="server" ID="HintAudio" TabIndex="28" Style="font-size: 10px" />
                            </div>
                            <div class="col-sm-5 control-block">
                                <asp:Label ID="HintAudioLink" runat="server" Text="" ForeColor="Blue" Font-Underline="true"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group col-sm-6 col-md-4">
                            <asp:RegularExpressionValidator
                                ID="RegularExpressionValidator5" runat="server" ErrorMessage="Only wav or mp3 file is allowed!"
                                ValidationExpression="^.+(.wav|.WAV|.mp3|.MP3)$"
                                ControlToValidate="HintAudio" Display="Dynamic" ValidationGroup="ValidationGroup" ForeColor="Red"> 
                            </asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group col-sm-6 col-md-12">
                        <label class="col-sm-1 control-label text-left">Supported Document</label>
                        <div class="col-sm-3 control-block">
                            <asp:FileUpload runat="server" ID="document" TabIndex="29" Style="font-size: 10px" />
                        </div>
                        <div class="col-sm-3 control-block">
                            <asp:FileUpload runat="server" ID="document2" TabIndex="30" Style="font-size: 10px" />
                        </div>
                        <div class="col-sm-3 control-block">
                            <asp:FileUpload runat="server" ID="document3" TabIndex="31" Style="font-size: 10px" />
                        </div>
                    </div>
                    <div class="form-group col-sm-6 col-md-12">
                        <div class="col-sm-4 control-block">
                            <asp:Label ID="SupportedDocumentLink" runat="server" Text="" ForeColor="Blue" Font-Underline="true"></asp:Label>
                        </div>
                        <div class="col-sm-4 control-block">
                            <asp:Label ID="SupportedDocumentLink2" runat="server" Text="" ForeColor="Blue" Font-Underline="true"></asp:Label>
                        </div>
                        <div class="col-sm-4 control-block">
                            <asp:Label ID="SupportedDocumentLink3" runat="server" Text="" ForeColor="Blue" Font-Underline="true"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group col-sm-6 col-md-6">
                        <label class="col-sm-2 control-label text-left">Video Link</label>
                        <div class="col-sm-4 control-block">
                            <asp:FileUpload runat="server" ID="HintVideo" TabIndex="32" Style="font-size: 10px" />
                        </div>
                        <div class="col-sm-2 control-block">
                            <asp:RegularExpressionValidator ID="ValRegBrowsedFile" runat="server" ValidationGroup="ValidationGroup" ControlToValidate="HintVideo" ForeColor="Red" ErrorMessage="Invalid Video File" ValidationExpression="^.*\.(avi|AVI|wmv|WMV|flv|FLV|mpg|MPG|mp4|MP4)$">
                            </asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group col-sm-6 col-md-2">
                        <asp:Label ID="VideoUrl" runat="server" Text="" ForeColor="Blue" Font-Underline="true"></asp:Label>
                    </div>
                    <div class="form-group col-sm-6 col-md-4">
                        <label class="col-sm-2 control-label text-left">Video URL</label>
                        <div class="col-sm-6 control-block">
                            <asp:TextBox CssClass="form-control" ID="txtVideoUrl" runat="server" TabIndex="33" autocomplete="off"></asp:TextBox>
                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ValidationGroup="ValidationGroup" ControlToValidate="txtVideoUrl" ForeColor="Red" ErrorMessage="Invalid Video Url" ValidationExpression="http(?:s?):\/\/(?:www\.)?youtu(?:be\.com\/watch\?v=|\.be\/)([\w\-\_]*)(&(amp;)?‌​[\w\?‌​=]*)?">
                                </asp:RegularExpressionValidator>--%>
                        </div>
                    </div>
                    <div>
                        <asp:Label ID="QuestionImageLink" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="QuestionImageLink2" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="SolutionImageLink" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="VideoLink" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="CommonAns" runat="server" Text="" Visible="false"></asp:Label>
                    </div>
                    <div class="form-group col-sm-6 col-md-12">
                        <div class="col-sm-4 control-block"></div>
                        <div class="col-sm-2 control-block">
                            <asp:Button runat="server" ID="btnAddAnswer" Text="Save" CssClass="btn btn-primary btn-lg btn-block" CausesValidation="true" ValidationGroup="ValidationGroup" OnClick="btnAddAnswer_Click" TabIndex="34" />
                        </div>
                        <div class="col-sm-2 control-block">
                            <asp:Button runat="server" ID="btnClear" Text="Clear" CssClass="btn btn-primary btn-lg btn-block" CausesValidation="false" OnClick="btnClear_Click" TabIndex="35" />
                        </div>
                    </div>
                </div>
                <asp:GridView runat="server" ID="grdMcqMater" AutoGenerateColumns="false" CssClass="table table-bordered table-striped dataTable"
                    AutoGenerateSelectButton="true" OnSelectedIndexChanging="grdMcqMater_SelectedIndexChanging" OnRowCommand="grdMcqMater_RowCommand" AllowPaging="true" PageSize="100"
                    OnPageIndexChanging="grdMcqMater_PageIndexChanging" ShowHeaderWhenEmpty="true" OnRowDataBound="grdMcqMater_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="Product ID" Visible="false">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblID" Text='<%#Eval("McqID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sr.No">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Question Text1">
                            <ItemTemplate>
                                <asp:Label ID="lblQuestion" runat="server" Text='<%#Eval("QuestionText1") %>'></asp:Label>
                                <asp:Label ID="lblQuestion2" runat="server" Text='<%#Eval("QuestionText2") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hint Text">
                            <ItemTemplate>
                                <asp:Label ID="lblHint" runat="server" Text='<%#Eval("HintText") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Paper Name">
                            <ItemTemplate>
                                <asp:Label ID="lblPaperId" runat="server" Text='<%#Eval("YearwisePaperID") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lblPaperName" runat="server" Text=""></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Topic Name">
                            <ItemTemplate>
                                <asp:Label ID="lblTopicId" runat="server" Text='<%#Eval("TopicwisePaperID") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lblTopicName" runat="server" Text=""></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Subject Name">
                            <ItemTemplate>
                                <asp:Label ID="lblSubjectID" runat="server" Text="" Visible="false"></asp:Label>
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
                        <asp:TemplateField HeaderText="Marks">
                            <ItemTemplate>
                                <asp:Label ID="lblMarks" runat="server" Text='<%#Eval("Marks") %>'></asp:Label>
                                <asp:Label ID="lblCorrectAnswer" runat="server" Text='<%#Eval("CorrectAnswerID") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Time To Solve">
                            <ItemTemplate>
                                <asp:Label ID="lblTime" runat="server" Text='<%#Eval("TimeToSolve") %>' ToolTip="HH:MM:SS"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hidden" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="GrdQuestionImage" runat="server" Text='<%#Eval("QuestionImageLink") %>'></asp:Label>
                                <asp:Label ID="GrdQuestionImage2" runat="server" Text='<%#Eval("QuestionImage2") %>'></asp:Label>
                                <asp:Label ID="QuestionAudioLink" runat="server" Text='<%#Eval("QuestionAudioLink") %>'></asp:Label>
                                <asp:Label ID="SolutionImageUrl" runat="server" Text='<%#Eval("HintImageLink") %>'></asp:Label>
                                <asp:Label ID="HintAudioLink" runat="server" Text='<%#Eval("HintAudioLink") %>'></asp:Label>
                                <asp:Label ID="VideoLink" runat="server" Text='<%#Eval("VideoLink") %>'></asp:Label>
                                <asp:Label ID="SupportedDocumentLink" runat="server" Text='<%#Eval("SupportedDocumentLink") %>'></asp:Label>
                                <asp:Label ID="SupportedDocumentLink2" runat="server" Text='<%#Eval("SupportedDocumentLink2") %>'></asp:Label>
                                <asp:Label ID="SupportedDocumentLink3" runat="server" Text='<%#Eval("SupportedDocumentLink3") %>'></asp:Label>
                                <asp:Label ID="VideoUrl" runat="server" Text='<%#Eval("HintVideoUrl") %>'></asp:Label>
                                <asp:Label ID="CommonAnswerImage" runat="server" Text='<%#Eval("CommonAnswerImage") %>'></asp:Label>
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
                                    <asp:LinkButton ID="btnDelete_Question" runat="server" CausesValidation="False" CommandName="Delete_Question"
                                        CommandArgument='<%#Eval("McqID") %>'>Delete</asp:LinkButton></span>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>Data Not Found</EmptyDataTemplate>
                    <PagerStyle CssClass="pagination-ys" />
                </asp:GridView>

            </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnAddAnswer" />
            <asp:PostBackTrigger ControlID="btnClear" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
