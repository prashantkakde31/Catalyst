<%@ Page Title="" Language="VB" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="false"
    CodeFile="AddNewUsers.aspx.vb" Inherits="admin_AddNewUsers" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    <div>
        <table class="style2" style="border-bottom-style: dotted; border-bottom-width: 1px;
            border-bottom-color: #C0C0C0">
            <tr>
                <td>
                    <asp:LinkButton CssClass="linkButton" ID="lnkEdit" runat="server">Add New </asp:LinkButton>
                </td>
                <td>
                    &nbsp;
                    <asp:Label ID="lblMessage" runat="server" Font-Bold="False" Font-Size="Small" 
                        ForeColor="Red" Width="195px"></asp:Label>
                </td>
                <td align="center">
                    <asp:LinkButton ID="lnkSave" runat="server" CssClass="linkButton" Enabled="False">Save</asp:LinkButton>
                </td>
            </tr>
        </table>

        <br />



        <table id="tabelContainer" class="style2" 
            style="padding-top: 3px; padding-bottom: 3px">
            <tr>
                <td align="center" colspan="2">
                    <h3><asp:Label runat="server" id="Labelmsg" Font-Bold="True" ForeColor="#0066FF" > Add New User Screen </asp:Label> 
                        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                        </asp:ToolkitScriptManager>
                    </h3>
                  </td>
            </tr>
            <tr>
                <td align="right" style="height: 26px">
                 
                 
                 <asp:Label ID="Label1" runat="server" Text="User ID :" Font-Bold="True" 
                        ForeColor="#204673"></asp:Label>
                   
                </td>
                <td style="height: 26px">
                    <asp:TextBox ID="txtUSERID" runat="server"  MaxLength="50" 
                        ReadOnly="true" CssClass="DDTextBox"></asp:TextBox>
                
                        
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label2" runat="server" Text="Login Id :" Font-Bold="True" 
                        ForeColor="#204673"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUSERNAME" runat="server" CssClass="DDTextBox" MaxLength="50" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label3" runat="server" Text="Login User Name :" 
                        Font-Bold="True" ForeColor="#204673"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUserFullName" runat="server" CssClass="DDTextBox" 
                        ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label4" runat="server" Text="Password :" Font-Bold="True" 
                        ForeColor="#204673"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtpASSWORD" runat="server" CssClass="DDTextBox" MaxLength="60" 
                         TextMode="password" AutoCompleteType="Disabled"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label5" runat="server" Text="Role" Font-Bold="True" 
                        ForeColor="#204673"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlGROUpID" runat="server" CssClass="DDDropDown" 
                        >
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label6" runat="server" Text="Valid From :" Font-Bold="True" 
                        ForeColor="#204673"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="DDTextBox"  ></asp:TextBox>

                    <asp:CalendarExtender  runat="server" ID = "cal" TargetControlID="txtFromDate" PopupButtonID="lnkFromDate" Format="dd-MMM-yy" ></asp:CalendarExtender>
                    <asp:ImageButton ID="lnkFromDate" runat="server" 
                        ImageUrl="~/MASTER/Images/calendar.gif" tabIndex="10" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label7" runat="server" Text="Valid Upto :" Font-Bold="True" 
                        ForeColor="#204673"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtToDate" runat="server" CssClass="DDTextBox" ></asp:TextBox>
                    <asp:CalendarExtender  runat="server" ID = "CalendarExtender1" TargetControlID="txtToDate" PopupButtonID="lnkToDate" Format="dd-MMM-yy" ></asp:CalendarExtender>
                    <asp:ImageButton ID="lnkToDate" runat="server" 
                        ImageUrl="~/MASTER/Images/calendar.gif" tabIndex="12" />
                </td>
            </tr>
            <tr>
                <td align="right" style="height: 24px">
                    <asp:Label ID="Label8" runat="server" Text="Check To Lock" Font-Bold="True" 
                        ForeColor="#204673"></asp:Label>
                </td>
                <td style="height: 24px">
                    <asp:CheckBox ID="ChkBx_OpClk" runat="server" CssClass="DDTextBox" 
                        ForeColor="#0066FF" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:LinkButton ID="LinkSave1" runat="server" CssClass="DDLightHeader" Enabled="False"                   
                        > Save</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>



    </div>
</asp:Content>
