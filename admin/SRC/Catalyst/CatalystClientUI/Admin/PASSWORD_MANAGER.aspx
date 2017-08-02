<%@ Page Title="" Language="VB" MasterPageFile="~/Master/Site.Master" AutoEventWireup="false" CodeFile="PASSWORD_MANAGER.aspx.vb" Inherits="admin_PASSWORD_MANAGER" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <p align="center" style="padding-top: 1%; margin-top: 1%">
    &nbsp;</p>
    <p align="center" style="padding-top: 1%; margin-top: 1%">
<asp:Label runat="server" id="Label10" Font-Bold="True" Font-Size="X-Large" 
          ForeColor="#0066FF" >Change Password</asp:Label>

</p>
 
<table id="tabelContainer" class="style2" align="center">
        <tr>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp; </td>
            <td align="right">
               <asp:Label ID="Label1" runat="server" Text="Old password :" Font-Bold="True" 
                    Font-Size="Medium" ForeColor="#204673"></asp:Label></td>
            <td>
               <asp:TextBox ID="txt_OLDPASSWORD" runat="server" CssClass="DDTextBox" AutoCompleteType ="Disabled" Enabled="False">**************</asp:TextBox>
            </td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;&nbsp;
                &nbsp;</td>
            <td align="right">
               <asp:Label ID="Label3" runat="server" Text="New Password :" Font-Bold="True" 
                    ForeColor="#204673"></asp:Label></td>
            <td>
             <asp:TextBox ID="txt_password" runat="server" CausesValidation="True" CssClass="DDTextBox"
                             TextMode="Password" onkeyup="passwordChanged();" AutoCompleteType ="Disabled" ToolTip="Type Password Here" MaxLength="15"></asp:TextBox> 
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txt_password" ErrorMessage="Please Enter Password"></asp:RequiredFieldValidator>
            </td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;&nbsp;</td>
            <td align="right">
               <asp:Label ID="Label2" runat="server" Text="Confirm New Password :" 
                    Font-Bold="True" ForeColor="#204673"></asp:Label></td>
            <td>
               <asp:TextBox ID="txt_confirmpassword" runat="server" CausesValidation="True" CssClass="DDTextBox" TextMode="Password" AutoCompleteType ="Disabled" MaxLength="15"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txt_confirmpassword" ErrorMessage="Please Confirm Password"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="right">
                &nbsp;</td>
            <td>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="txt_password" ControlToValidate="txt_confirmpassword" 
                    ErrorMessage="Password Does Not Match"></asp:CompareValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="right">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>


    <br />
    <br />

    <table style="border-bottom-style: dotted; border-bottom-width: 1px;
            border-bottom-color: #C0C0C0" align="center">
            <tr>
                <td>
                    &nbsp;&nbsp;</td>
                <td>
                    &nbsp;&nbsp;
                    </td>
                <td align="center">
                     
                     <asp:Button ID="btn_submit" runat="server" CssClass="DDLightHeader"
                             Text="Change Password"  />        </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td align="center">
                     
                     &nbsp;</td>
            </tr>
        </table>
<br />
<br />
</asp:Content>

