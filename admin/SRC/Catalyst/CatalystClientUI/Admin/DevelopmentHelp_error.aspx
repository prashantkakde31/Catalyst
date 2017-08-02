<%@ Page Title="" Language="VB" MasterPageFile="~/Master/Site.Master" AutoEventWireup="false"
    CodeFile="DevelopmentHelp_error.aspx.vb" Inherits="admin_DevelopmentHelp_error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style4
        {
            width: 600px;
        }
        .style5
        {
            width: 274px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div align="center" style="padding-top: 30px">
    <table style="border: thin groove #000000;border-color:black;" align="center">
    <tr>
  <td bgcolor="#6666FF" style="border: thin groove black;" align="center">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="22px" Font-Names="Calibri"
                        ForeColor="White">Technical Error</asp:Label>
                </td>
    </tr>
    <tr><td>
        <table align="center" cellpadding="5" cellspacing="5" class="style4">
            <tr>
                <td bgcolor="#996600" class="style5" align="center" >
                    <asp:Label ID="lbl_1" runat="server" Font-Bold="True" Font-Size="12px" Font-Names="Arial"
                        ForeColor="White"></asp:Label>
                </td>
                <td bgcolor="#996600" align="center">
                    <asp:Label ID="lbl_2" runat="server" Font-Bold="True" Font-Size="12px" Font-Names="Arial"
                        ForeColor="White"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <br />
                    <p style="border: thin groove #000000; width: 462px; background-color: #996600; color: #FFFFFF;
                        font-size: large; font-family: cambria; font-weight: lighter; padding-right: 0px;
                        padding-left: 0px; margin-right: 0px; margin-left: 0px;" align="center">
                        Some Technical Error Occured, Please Contact ISG</p>
                    <br />
                    <asp:Button ID="Button1" runat="server" CssClass="DDLightHeader" Font-Bold="True"
                        Font-Italic="False" Font-Underline="False" Text="Close" Width="85px" 
                        BackColor="#996600" />
                    &nbsp;<br />
                </td>
            </tr>
            </table>
        </td></tr>
        </table>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </div>
</asp:Content>
