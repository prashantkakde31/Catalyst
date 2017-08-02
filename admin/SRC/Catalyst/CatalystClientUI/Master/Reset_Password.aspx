<%@ Page Title="" Language="VB" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="false" CodeFile="Reset_Password.aspx.vb" Inherits="admin_Reset_User_Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">


   
    <p align="center" style="padding-top: 1%; margin-top: 1%">
<asp:Label runat="server" id="Label10" Font-Bold="True" Font-Size="X-Large" 
          ForeColor="#0066FF" >Reset User Password</asp:Label>

           
</p>



    <br />



<br />

<table id="tabelContainer" class="style2" 
            style="padding-top: 3px; padding-bottom: 3px">
          
            <tr>
                <td align="right" style="height: 26px">
                 
                 
                 <asp:Label ID="Label1" runat="server" Text="Select User :" Font-Bold="True" 
                        ForeColor="#204673"></asp:Label>
                   
                </td>
                <td >
                    <asp:dropdownlist id="ddlUserName" runat="server" CssClass="DDTextBox">
				<asp:ListItem Selected="True"></asp:ListItem>
				<asp:ListItem Value="LOCKED">LOCKED</asp:ListItem>
				<asp:ListItem Value="DISABLED">DISABLED</asp:ListItem>
				<asp:ListItem Value="BLOCKED">BLOCKED</asp:ListItem>
				<asp:ListItem Value="OPEN">OPEN</asp:ListItem>
			</asp:dropdownlist>
                </td>
            </tr>
            <tr>
                <td align="right">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label4" runat="server" Text="Enter New password :" 
                        Font-Bold="True" ForeColor="#204673"></asp:Label>
                </td>
                <td>
                   <asp:textbox id="TextBox1" runat="server" TextMode="Password" AutoCompleteType="Disabled" MaxLength="50" CssClass="DDTextBox"></asp:textbox>
                    <br />
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label6" runat="server" Text="Confirm Password :" 
                        Font-Bold="True" ForeColor="#204673"></asp:Label>
                </td>
                <td>
                   <asp:textbox id="TextBox2" runat="server" TextMode="Password" AutoCompleteType="Disabled" CssClass="DDTextBox"></asp:textbox></td>
            </tr>
            <tr>
                <td align="right">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" colspan="2">
                    <br />
                </td>
            </tr>
            </table>




   <table class="style2" style="border-top-style: dotted; border-top-width: 1px;
            border-top-color: #C0C0C0">
            <tr>
                <td>
                    &nbsp;&nbsp;</td>
                <td>
                    &nbsp;&nbsp;
                    </td>
                <td align="center">
                                    
                <asp:linkbutton id="LinkButton1"
				 runat="server" CssClass="DDLightHeader" >Reset Password</asp:linkbutton>
                
                   
                
                </td>
            </tr>
        </table>
         <br />
                    <br />
                    <br />

</asp:Content>

