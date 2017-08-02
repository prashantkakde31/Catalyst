<%@ Page Language="VB" MasterPageFile="~/MASTER/MasterPage2.master" AutoEventWireup="false" CodeFile="Change_Password.aspx.vb" Inherits="MASTER_Change_Password" Title="Catalyst." EnableViewState="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">

    <script language="javascript" type="text/javascript">
        function keyEnterCheck() {
            if (event.keyCode == 13) {
                event.returnValue = false;
                return false;
            }
        }

        function passwordChanged() {
            var strength = document.getElementById('strength');
            var strongRegex = new RegExp("^(?=.{8,})(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*\\W).*$", "g");
            var mediumRegex = new RegExp("^(?=.{7,})(((?=.*[A-Z])(?=.*[a-z]))|((?=.*[A-Z])(?=.*[0-9]))|((?=.*[a-z])(?=.*[0-9]))).*$", "g");
            var enoughRegex = new RegExp("(?=.{6,}).*", "g");
            var pwd = document.getElementById("ctl00_ContentPlaceHolder1_txt_newpassword");

            if (pwd.value.length == 0) {
                strength.innerHTML = '';
            }
            else if (false == enoughRegex.test(pwd.value)) {
                strength.innerHTML = 'More Characters';
                Message.innerHTML = '';
            }
            else if (strongRegex.test(pwd.value)) {
                //strength.innerHTML = '<span style="color:green">  Strong  <br></span>';
                strength.innerHTML = '<span  style="height: 8px; width: 100px" > <asp:TextBox ID="Strong" runat="server" BackColor="Green" Height="7px" ReadOnly="True" Width="100px" ></asp:TextBox> </span>';
                Message.innerHTML = '<span style="color:Black">  &nbsp;&nbsp;Strong</span>';

                //style="height: 9px; width: 98px; background-color: red;" 
            }
            else if (mediumRegex.test(pwd.value)) {
                //strength.innerHTML = '<span style="color:orange">Medium!</span>';
                strength.innerHTML = '<span style="height: 8px; width: 100px" > <asp:TextBox ID="Medium" runat="server" BackColor="Orange" Height="7px" ReadOnly="True" Width="75px" ></asp:TextBox> </span>';
                Message.innerHTML = '<span style="color:Black">  &nbsp;&nbsp;Medium</span>';
            }
            else {
                //strength.innerHTML = '<span style="color:red">Weak!</span>';
                strength.innerHTML = '<span style="height: 8px; width: 100px" > <asp:TextBox ID="Weak" runat="server" BackColor="Red" Height="7px" ReadOnly="True" Width="50px" ></asp:TextBox> </span>';
                Message.innerHTML = '<span style="color:Black">  &nbsp;&nbsp;Weak</span>';
            }





        }
    </script>



    <table class="style15">
        <tr>
            <td align="right">&nbsp;</td>
            <td style="width: 6px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label runat="server" ID="Label10" Font-Bold="True" Font-Size="Large"
                    ForeColor="#0066FF">Profile Settings</asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 29px">
                <asp:Label ID="Label1" runat="server"
                    CssClass="Label" Text="Display Name" Font-Bold="True" ForeColor="#204673"></asp:Label>
            </td>
            <td style="width: 6px; height: 29px;"><b>:</b></td>
            <td style="height: 29px">&nbsp;<%--<asp:Button ID="btn_OldPassword" runat="server" CssClass="Button" Text="Ok" 
                    Width="48px" TabIndex="2" />--%>
                <asp:TextBox ID="txtName" runat="server" Visible="true" TabIndex="1" Width="185px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="txtName" ErrorMessage="Please enter name"
                    ValidationGroup="b" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ErrorMessage="Invalid Name" Display="Dynamic"
                    ControlToValidate="txtName" ValidationGroup="b" ForeColor="Red"
                    ValidationExpression="^[a-zA-Z ]{1,50}$"></asp:RegularExpressionValidator>
                <br />
            </td>
        </tr>
        <tr>
            <td align="right">&nbsp;</td>
            <td style="width: 6px">&nbsp;</td>
            <td>
                <asp:Button ID="btnProfile" runat="server" CssClass="Button"
                    Text="Save Profile" ValidationGroup="b" Width="152px" OnClick="btnProfile_Click"/>
                <br />
                <hr style="width: 60%;" size="2" />
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 29px">
                <asp:Label ID="Label5" runat="server"
                    CssClass="Label" Text="Enter Old Password" Font-Bold="True" ForeColor="#204673"></asp:Label>
            </td>
            <td style="width: 6px; height: 29px;"><b>:</b></td>
            <td style="height: 29px">
                <asp:TextBox ID="txt_oldpassword" runat="server" AutoCompleteType="Disabled"
                    BackColor="White" CssClass="TextBox" TextMode="Password" Width="185px"
                    MaxLength="15" TabIndex="2"></asp:TextBox>
                &nbsp;<%--<asp:Button ID="btn_OldPassword" runat="server" CssClass="Button" Text="Ok" 
                    Width="48px" TabIndex="2" />--%>
                <asp:TextBox ID="txt_oldpwd" runat="server" AutoCompleteType="Disabled" Visible="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 4px"></td>
            <td style="width: 6px; height: 4px;"></td>
            <td style="height: 4px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:LinkButton ID="lnk_passwordStrength" runat="server"
                    CausesValidation="False" CssClass="Link_password" Visible="False"
                    OnClientClick="window.open('Password_strength.aspx?textbox=txtFromDate','cal','width=520,height=575,left=350,top=50')">Password 
                Strength</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lbl_NewPassword" runat="server" CssClass="Label"
                    Text="Enter New Password" Visible="False" Font-Bold="True" ForeColor="#204673"></asp:Label></td>
            <td style="width: 6px">
                <asp:Label ID="lbl_Dot_NewPassword" runat="server"
                    Font-Bold="True" Text=":"></asp:Label></td>
            <td>
                <asp:TextBox ID="txt_newpassword" runat="server" onkeyup="passwordChanged();"
                    BackColor="White" CssClass="TextBox" TextMode="Password" AutoCompleteType="Disabled"
                    Visible="False" Width="185px" MaxLength="15" ValidationGroup="a" TabIndex="3"></asp:TextBox>
                <span id="strength"></span>
                <span id="Message"></span>

                &nbsp;</td>
        </tr>
        <tr>
            <td align="right">&nbsp;</td>
            <td style="width: 6px">&nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ControlToValidate="txt_newpassword" ErrorMessage="Please Enter New Password"
                    ValidationGroup="a" Visible="False" ForeColor="Red"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lbl_ConfirmPassword" runat="server"
                    CssClass="Label" Text="Confirm New Password" Visible="False" Font-Bold="True" ForeColor="#204673"></asp:Label></td>
            <td style="width: 6px">
                <asp:Label ID="lbl_Dot_ConfirmPassword" runat="server"
                    Font-Bold="True" Text=":"></asp:Label></td>
            <td>
                <asp:TextBox ID="txt_confirmpassword" runat="server" BackColor="White" AutoCompleteType="Disabled"
                    CssClass="TextBox" TextMode="Password" Visible="False" Width="185px"
                    MaxLength="15" ValidationGroup="a" TabIndex="4"></asp:TextBox>
                &nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server"
                    ControlToCompare="txt_newpassword" ControlToValidate="txt_confirmpassword"
                    ErrorMessage="Password Does Not Match" Visible="False" ForeColor="Red"></asp:CompareValidator></td>
        </tr>
        <tr>
            <td align="right">&nbsp;</td>
            <td style="width: 6px">&nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                    ControlToValidate="txt_confirmpassword" ErrorMessage="Please Confirm Password"
                    ValidationGroup="a" Visible="False" ForeColor="Red"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right">&nbsp;</td>
            <td style="width: 6px">&nbsp;</td>
            <td>
                <asp:Button ID="btn_ChangePassword" runat="server" CssClass="Button"
                    Text="Change Password" Visible="False" ValidationGroup="a" Width="152px"
                    TabIndex="5" /></td>
        </tr>
    </table>





</asp:Content>
