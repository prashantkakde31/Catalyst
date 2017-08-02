<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Forgot_Password.aspx.vb"
    Inherits="MASTER_Forgot_Password" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<link rel="stylesheet" href="../master/style_sheet.css" type="text/css">
<link href="style_sheet.css" rel="stylesheet" type="text/css" />
<link href="navStyle.css" rel="stylesheet" type="text/css" />
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        body
        {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
            background-image: url(../master/images/axis-background.png);
        }
        a.footerlink:link
        {
            text-decoration: none;
            color: #FFFFFF;
        }
        a.footerlink:visited
        {
            text-decoration: none;
            color: #FFFFFF;
        }
        a.footerlink:hover
        {
            text-decoration: underline;
            color: #FFFFFF;
        }
        a.footerlink:active
        {
            text-decoration: none;
            color: #FFFFFF;
        }
        .top_link
        {
            color: #FFFFFF;
        }
        .style14:Hover
        {
            color: white;
            text-decoration: underline;
        }
        
        
        a.graylink:link
        {
            text-decoration: none;
            color: #7a7a7a;
        }
        a.graylink:visited
        {
            text-decoration: none;
            color: #7a7a7a;
        }
        a.graylink:hover
        {
            text-decoration: underline;
            color: red;
        }
        a.graylink:active
        {
            text-decoration: underline;
            color: red;
        }
        .style1
        {
            height: 27px;
        }
        .style3
        {
            width: 314px;
        }
        .style4
        {
            height: 14px;
            width: 314px;
        }
        .style5
        {
            width: 311px;
        }
        .style6
        {
            width: 395px;
        }
        .style7
        {
            height: 14px;
            width: 395px;
        }
        .style8
        {
            color: #ffffff;
            height: 34px;
        }
        .Button
        {
        }
        .style9
        {
            color: #666;
            font-style: normal;
            font-variant: normal;
            font-weight: normal;
            font-size: .7em;
            line-height: normal;
            font-family: Tahoma, Arial, Sans-Serif;
            margin-left: 19px;
            margin-right: 0px;
            margin-top: 0px;
            margin-bottom: 0px;
            padding: 0px;
        }
        .style10
        {
            width: 411px;
        }
        .BUTTON_1
        {}
    </style>
    <script type="text/javascript">
        //Start- Email Id Validation on Allowing only 2 dots
        function validateField(fieldname) {


            var cnt = 0;
            var str = new String(fieldname.value);
            var lmail = new String(str.substring(str.indexOf("@"), str.length));
            var i;
            for (i = 0; i < lmail.length; i++) {
                if (lmail.charAt(i) == ".") {
                    cnt = cnt + 1;
                }
            }

            if (cnt > 2) {
                window.alert("Invalid Email Id");
                fieldname.value = "";
            }
        }
        //Ends - Email Id Validation on Allowing only 2 dots
    </script>
</head>
<body oncontextmenu="return false">
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td width="100%" align="center" valign="top" class="header1">
                    <table width="900" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td align="right" class="style8" colspan="2">
                                <strong><a href="http://www.npci.org.in/aboutus.aspx" target="_blank" class="copyright"
                                    style="color: rgb(102, 0, 51)">About Us </a>&nbsp; &nbsp;| &nbsp;<a href="http://www.npci.org.in/contactus.aspx"
                                        target="_blank" class="copyright" style="color: rgb(102, 0, 51)">Contact Us</a> &nbsp;|
                                    &nbsp; <a href="#" class="copyright" style="color: rgb(102, 0, 51)">Help</a>&nbsp; </strong>
                                &nbsp;
                                <tr>
                                    <td height="80" align="left" width="219">
                                        <img src="Images/NPCI.JPG" height="49px" width="257px" class="white_header">
                                    </td>
                                    <td align="left" style="padding-left: 25px;">
                                        &nbsp;
                                    </td>
                                    <td width="10">
                                    </td>
                                </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="445" valign="top">
                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="440" align="left" valign="top" bgcolor="#FFFFFF" 
                                style="border-top-style: solid;
                                border-bottom-style: solid; border-top-width: 3px; border-bottom-width: 3px;
                                border-top-color: #0046B0; border-bottom-color: #0046B0; background-image: url('Images/axis-background.png');">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <table class="style1" border="2px" style="position: absolute; border-color: #000000;
                                    top: 247px; left: 345px; height: 125px; width: 474px;">
                                    <tr>
                                        <td align="left" colspan="2" style="background-color: rgb(92, 149, 79); color: #A50032;"
                                            class="style5">
                                            <asp:Button ID="Button1" runat="server" Height="25px" Text="Close" Width="56px" 
                                                CssClass="Button" Font-Bold="False" Font-Names="Arial" Font-Size="Small" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Label ID="Label1" runat="server" Text="Forgot Password" Font-Bold="True" 
                                                ForeColor="White" Font-Names="Arial" Font-Size="15px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="style3">
                                            <asp:Label ID="Label2" runat="server" Text="User Name" Font-Bold="True" Font-Names="Arial"
                                                Font-Size="13px"></asp:Label>
                                        </td>
                                        <td class="style6">
                                            <asp:TextBox ID="txt_mid" runat="server" CssClass="TextBox" Width="124px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style4">
                                        </td>
                                        <td class="style7" style="padding:5px">
                                            <asp:Button ID="btn_frgtpswd" runat="server" Text="Submit" CssClass="BUTTON_1" 
                                                Height="24px" Font-Bold="False" Font-Names="Arial" Font-Size="Small" 
                                                Width="75px" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <table class="style9" width="100%">
        <tr>
            <td align="center" class="style10" style="padding-left: 8%; color: rgb(102, 0, 51);
                font-size: small">
                National Payments Corporation Of India |<a href="../master/Terms and conditions/Privacy and Terms.html"
                    target="_blank" class="footerlink" onmouseover="window.status='ISG'; return true;"
                    style="color: rgb(102, 0, 51)">Terms & Condition of Use</a>
            </td>
            <td align="center" class="style3" style="padding-right: 10%; color: rgb(102, 0, 51);
                font-size: small">
                <asp:Label ID="Labelins" runat="server">Best Viewd in 1024 * 768</asp:Label>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
