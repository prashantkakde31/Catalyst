<%@ Page Title="" Language="VB" MasterPageFile="~/Master/Site.Master" AutoEventWireup="false"
    CodeFile="login.aspx.vb" Inherits="Master_login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<script runat="server">

    Protected Sub LoginImageButton_Click(sender As Object, e As EventArgs)

    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        /*.modalPopup
        {
            background-color: #FFFFFF;
            width: 550px;
            border: 3px solid #000000;
        }
        .modalPopup .header
        {
            background-color: #3366CC;
            height: 30px;
            color: White;
            line-height: 30px;
            text-align: center;
            font-weight: bold;
        }
        .modalPopup .body
        {
            min-height: 50px;
            line-height: 30px;
            text-align: center;
            font-weight: bold;
        }
        .modalPopup .footer
        {
            padding: 3px;
        }
        .modalPopup .yes, .modalPopup .no
        {
            height: 23px;
            color: White;
            line-height: 23px;
            text-align: center;
            font-weight: bold;
            cursor: pointer;
        }
        .modalPopup .yes
        {
            background-color: #9F9F9F;
            border: 1px solid #5C5C5C;
        }
        .modalPopup .no
        {
            background-color: #9F9F9F;
            border: 1px solid #5C5C5C;
        }
        .width1
        {
            width: 550px;
        }*/

        /****************************************************************************/
        .wrapper {
            width: 30%;
            margin: 80px auto 20px auto;
            
        }

        .form-signin {
            max-width: 420px;
            padding: 30px 38px 66px;
            margin: 0 auto;
            background-color: #eee;
            border: 3px dotted rgba(0,0,0,0.1);
        }

        .form-signin-heading {
            text-align: center;
            margin-bottom: 30px;
        }

        .form-control {
            position: relative;
            font-size: 16px;
            height: auto;
            padding: 10px;
        }

        input[type="text"] {
            margin-bottom: 0px;
            border-bottom-left-radius: 0;
            border-bottom-right-radius: 0;
        }

        input[type="password"] {
            margin-bottom: 20px;
            border-top-left-radius: 0;
            border-top-right-radius: 0;
        }

        .colorgraph {
            height: 7px;
            border-top: 0;
            background: #c4e17f;
            border-radius: 5px;
            background-image: -webkit-linear-gradient(left, #c4e17f, #c4e17f 12.5%, #f7fdca 12.5%, #f7fdca 25%, #fecf71 25%, #fecf71 37.5%, #f0776c 37.5%, #f0776c 50%, #db9dbe 50%, #db9dbe 62.5%, #c49cde 62.5%, #c49cde 75%, #669ae1 75%, #669ae1 87.5%, #62c2e4 87.5%, #62c2e4);
            background-image: -moz-linear-gradient(left, #c4e17f, #c4e17f 12.5%, #f7fdca 12.5%, #f7fdca 25%, #fecf71 25%, #fecf71 37.5%, #f0776c 37.5%, #f0776c 50%, #db9dbe 50%, #db9dbe 62.5%, #c49cde 62.5%, #c49cde 75%, #669ae1 75%, #669ae1 87.5%, #62c2e4 87.5%, #62c2e4);
            background-image: -o-linear-gradient(left, #c4e17f, #c4e17f 12.5%, #f7fdca 12.5%, #f7fdca 25%, #fecf71 25%, #fecf71 37.5%, #f0776c 37.5%, #f0776c 50%, #db9dbe 50%, #db9dbe 62.5%, #c49cde 62.5%, #c49cde 75%, #669ae1 75%, #669ae1 87.5%, #62c2e4 87.5%, #62c2e4);
            background-image: linear-gradient(to right, #c4e17f, #c4e17f 12.5%, #f7fdca 12.5%, #f7fdca 25%, #fecf71 25%, #fecf71 37.5%, #f0776c 37.5%, #f0776c 50%, #db9dbe 50%, #db9dbe 62.5%, #c49cde 62.5%, #c49cde 75%, #669ae1 75%, #669ae1 87.5%, #62c2e4 87.5%, #62c2e4);
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
        /****************************************************************************/
    </style>
    <script type="text/javascript">

        function submitForm() {
            setHashValue();
        }
        function submitForm2(eve) {
            //	if (eve.keyCode == 13) {
            submitForm();
            //	}
        }
        function setHashValue() {
            var plaintext = document.getElementById('<%= Login.FindControl("Password").ClientID %>').value;

            //concat value of hidden field to passord and then hashing
            if (plaintext != "") {

                plaintext += document.getElementById('<%= lblID.ClientID %>').value;
                document.getElementById('<%= Login.FindControl("Password").ClientID %>').value = SHA256(plaintext);
            }
        }


        /**
        *
        *  Secure Hash Algorithm (SHA256)
        *  http://www.webtoolkit.info/
        *
        *  Original code by Angel Marin, Paul Johnston.
        *
        **/

        function SHA256(s) {

            var chrsz = 8;
            var hexcase = 0;

            function safe_add(x, y) {
                var lsw = (x & 0xFFFF) + (y & 0xFFFF);
                var msw = (x >> 16) + (y >> 16) + (lsw >> 16);
                return (msw << 16) | (lsw & 0xFFFF);
            }

            function S(X, n) { return (X >>> n) | (X << (32 - n)); }
            function R(X, n) { return (X >>> n); }
            function Ch(x, y, z) { return ((x & y) ^ ((~x) & z)); }
            function Maj(x, y, z) { return ((x & y) ^ (x & z) ^ (y & z)); }
            function Sigma0256(x) { return (S(x, 2) ^ S(x, 13) ^ S(x, 22)); }
            function Sigma1256(x) { return (S(x, 6) ^ S(x, 11) ^ S(x, 25)); }
            function Gamma0256(x) { return (S(x, 7) ^ S(x, 18) ^ R(x, 3)); }
            function Gamma1256(x) { return (S(x, 17) ^ S(x, 19) ^ R(x, 10)); }

            function core_sha256(m, l) {
                var K = new Array(0x428A2F98, 0x71374491, 0xB5C0FBCF, 0xE9B5DBA5, 0x3956C25B, 0x59F111F1, 0x923F82A4, 0xAB1C5ED5, 0xD807AA98, 0x12835B01, 0x243185BE, 0x550C7DC3, 0x72BE5D74, 0x80DEB1FE, 0x9BDC06A7, 0xC19BF174, 0xE49B69C1, 0xEFBE4786, 0xFC19DC6, 0x240CA1CC, 0x2DE92C6F, 0x4A7484AA, 0x5CB0A9DC, 0x76F988DA, 0x983E5152, 0xA831C66D, 0xB00327C8, 0xBF597FC7, 0xC6E00BF3, 0xD5A79147, 0x6CA6351, 0x14292967, 0x27B70A85, 0x2E1B2138, 0x4D2C6DFC, 0x53380D13, 0x650A7354, 0x766A0ABB, 0x81C2C92E, 0x92722C85, 0xA2BFE8A1, 0xA81A664B, 0xC24B8B70, 0xC76C51A3, 0xD192E819, 0xD6990624, 0xF40E3585, 0x106AA070, 0x19A4C116, 0x1E376C08, 0x2748774C, 0x34B0BCB5, 0x391C0CB3, 0x4ED8AA4A, 0x5B9CCA4F, 0x682E6FF3, 0x748F82EE, 0x78A5636F, 0x84C87814, 0x8CC70208, 0x90BEFFFA, 0xA4506CEB, 0xBEF9A3F7, 0xC67178F2);
                var HASH = new Array(0x6A09E667, 0xBB67AE85, 0x3C6EF372, 0xA54FF53A, 0x510E527F, 0x9B05688C, 0x1F83D9AB, 0x5BE0CD19);
                var W = new Array(64);
                var a, b, c, d, e, f, g, h, i, j;
                var T1, T2;

                m[l >> 5] |= 0x80 << (24 - l % 32);
                m[((l + 64 >> 9) << 4) + 15] = l;

                for (var i = 0; i < m.length; i += 16) {
                    a = HASH[0];
                    b = HASH[1];
                    c = HASH[2];
                    d = HASH[3];
                    e = HASH[4];
                    f = HASH[5];
                    g = HASH[6];
                    h = HASH[7];

                    for (var j = 0; j < 64; j++) {
                        if (j < 16) W[j] = m[j + i];
                        else W[j] = safe_add(safe_add(safe_add(Gamma1256(W[j - 2]), W[j - 7]), Gamma0256(W[j - 15])), W[j - 16]);

                        T1 = safe_add(safe_add(safe_add(safe_add(h, Sigma1256(e)), Ch(e, f, g)), K[j]), W[j]);
                        T2 = safe_add(Sigma0256(a), Maj(a, b, c));

                        h = g;
                        g = f;
                        f = e;
                        e = safe_add(d, T1);
                        d = c;
                        c = b;
                        b = a;
                        a = safe_add(T1, T2);
                    }

                    HASH[0] = safe_add(a, HASH[0]);
                    HASH[1] = safe_add(b, HASH[1]);
                    HASH[2] = safe_add(c, HASH[2]);
                    HASH[3] = safe_add(d, HASH[3]);
                    HASH[4] = safe_add(e, HASH[4]);
                    HASH[5] = safe_add(f, HASH[5]);
                    HASH[6] = safe_add(g, HASH[6]);
                    HASH[7] = safe_add(h, HASH[7]);
                }
                return HASH;
            }

            function str2binb(str) {
                var bin = Array();
                var mask = (1 << chrsz) - 1;
                for (var i = 0; i < str.length * chrsz; i += chrsz) {
                    bin[i >> 5] |= (str.charCodeAt(i / chrsz) & mask) << (24 - i % 32);
                }
                return bin;
            }

            function Utf8Encode(string) {
                string = string.replace(/\r\n/g, "\n");
                var utftext = "";

                for (var n = 0; n < string.length; n++) {

                    var c = string.charCodeAt(n);

                    if (c < 128) {
                        utftext += String.fromCharCode(c);
                    }
                    else if ((c > 127) && (c < 2048)) {
                        utftext += String.fromCharCode((c >> 6) | 192);
                        utftext += String.fromCharCode((c & 63) | 128);
                    }
                    else {
                        utftext += String.fromCharCode((c >> 12) | 224);
                        utftext += String.fromCharCode(((c >> 6) & 63) | 128);
                        utftext += String.fromCharCode((c & 63) | 128);
                    }

                }

                return utftext;
            }

            function binb2hex(binarray) {
                var hex_tab = hexcase ? "0123456789ABCDEF" : "0123456789abcdef";
                var str = "";
                for (var i = 0; i < binarray.length * 4; i++) {
                    str += hex_tab.charAt((binarray[i >> 2] >> ((3 - i % 4) * 8 + 4)) & 0xF) +
			hex_tab.charAt((binarray[i >> 2] >> ((3 - i % 4) * 8)) & 0xF);
                }
                return str;
            }

            s = Utf8Encode(s);
            return binb2hex(core_sha256(str2binb(s), s.length * chrsz));

        }
    </script>
    <%--
    <script src="../Script/hash_encrypt.js" type="text/javascript"></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />--%>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <br />
    <%--<div style="padding-left: 20px;">
        <asp:Panel runat="server" ID="pan1">
            <asp:Login ID="Login" runat="server" DisplayRememberMe="False" Font-Size="Medium"
                LoginButtonImageUrl="~/Master/Images/login.jpg" Width="100%" LoginButtonType="Image"
                TitleText="" Font-Names="Arial">
                <LayoutTemplate>
    --%>                <%--    <br>
                        <asp:Label ID="Label1" runat="server" Text="User Name" Font-Names="Arial" Font-Size="13px"
                            Font-Bold="True" ForeColor="#003366"></asp:Label>
                        </span>
                    <asp:TextBox ID="UserName" runat="server" CssClass="DDTextBox" MaxLength="15" size="0"
                        OnTextChanged="UserName_TextChanged1" Width="200px"></asp:TextBox>&nbsp;&nbsp;<span
                            class="darkred"><span class="darkred">
                            <%--<span class="darkred">Your Registered    MID</span>
                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                    CssClass="DDValidator" ErrorMessage="User Name is required." ToolTip="User Name is required."
                    ValidationGroup="Login" Font-Bold="True" Font-Names="Arial" Font-Size="13px">* 
               Enter User Name </asp:RequiredFieldValidator>
                            </span>
                            <br />
                        </span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    <span class="loginpage">&nbsp;<asp:Label ID="Label2" runat="server" Text="Password"
                        Font-Size="13px" Font-Bold="True" ForeColor="#003366" Font-Names="Arial" CssClass=""></asp:Label>
                        </span>
                    <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="DDTextBox"
                        MaxLength="15" size="0" Width="200px"></asp:TextBox>&nbsp;
                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                        ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login"
                        CssClass="DDValidator" Font-Bold="True" Font-Names="Arial" Font-Size="13px">* Enter Password</asp:RequiredFieldValidator>
                    <span>
                        <br />
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <span style="margin-top: 10px;">
                            <asp:ImageButton ID="LoginImageButton" runat="server" 
                        AlternateText="Log In" CommandName="Login"
                                Height="35px" ImageUrl="~/Master/Images/login.jpg" 
                        ValidationGroup="Login" Width="80px"
                                OnClientClick="setHashValue();" 
                        onclick="LoginImageButton_Click1" />
                        </span>&nbsp; </span>--%>
    <%--          <br>
                    <table cellspacing="10px">
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="User Name" Font-Names="Arial" Font-Size="13px"
                                    Font-Bold="True" ForeColor="#003366"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="UserName" runat="server" CssClass="DDTextBox" MaxLength="15" size="0"
                                    OnTextChanged="UserName_TextChanged1" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                    CssClass="DDValidator" ErrorMessage="User Name is required." ToolTip="User Name is required."
                                    ValidationGroup="Login" Font-Bold="True" Font-Names="Arial" Font-Size="13px">* 
               Enter User Name </asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Password" Font-Size="13px" Font-Bold="True"
                                    ForeColor="#003366" Font-Names="Arial" CssClass=""></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Password" runat="server" TextMode="Password" AutoCompleteType="Disabled" CssClass="DDTextBox"
                                    MaxLength="999" size="0" Width="200px"></asp:TextBox>&nbsp;
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                    ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login"
                                    CssClass="DDValidator" Font-Bold="True" Font-Names="Arial" Font-Size="13px">* Enter Password</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="padding-left: 100px">
                                <asp:ImageButton ID="LoginImageButton" runat="server" AlternateText="Log In" CommandName="Login"
                                    Height="35px" ImageUrl="~/Master/Images/login.jpg" ValidationGroup="Login" Width="80px"
                                    OnClientClick="setHashValue();" OnClick="LoginImageButton_Click1" />
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
            </asp:Login>
            
            <%-- <asp:LinkButton ID="LinkButton1" CssClass="linkButton" runat="server" Font-Bold="True"
                Font-Underline="True" ForeColor="#953D3E" Font-Overline="False" Font-Names="Arial"
                Font-Size="13px">Forgot Password</asp:LinkButton>
        </asp:Panel>
        <br />
        <br />
        <br />
    </div>--%>

    <div class="container">
        <div class="wrapper">
            <h3 class="form-signin-heading">Catalyst</h3>
            <hr class="colorgraph">
            <br>
            <%--<asp:Panel runat="server" ID="Panel1">--%>
            <asp:Login ID="Login" runat="server" DisplayRememberMe="False" Font-Size="Medium"
                LoginButtonImageUrl="~/Master/Images/login.jpg" Width="100%" LoginButtonType="Image"
                TitleText="" Font-Names="Arial">
                <LayoutTemplate>
                    <asp:TextBox ID="UserName" runat="server" class="form-control" MaxLength="15" size="0"
                        OnTextChanged="UserName_TextChanged1" placeholder="Username"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                        CssClass="DDValidator" ErrorMessage="User Name is required." ToolTip="User Name is required."
                        ValidationGroup="Login" Font-Bold="True" Font-Names="Arial" Font-Size="13px">* 
               Enter User Name </asp:RequiredFieldValidator>
                    <asp:TextBox ID="Password" runat="server" TextMode="Password" AutoCompleteType="Disabled" CssClass="form-control"
                        MaxLength="999" size="0" placeholder="Password"></asp:TextBox>&nbsp;
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                    ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login"
                                    CssClass="DDValidator" Font-Bold="True" Font-Names="Arial" Font-Size="13px">* Enter Password</asp:RequiredFieldValidator>

                    <%--<input type="text" class="form-control" name="Username" placeholder="Username" required="" autofocus="" />--%>
                    <%--<input type="password" class="form-control" name="Password" placeholder="Password" required="" />--%>

                    <asp:Button ID="LoginImageButton" runat="server" Text="Log In" CommandName="Login"
                        ValidationGroup="Login"
                        OnClientClick="setHashValue();" OnClick="LoginImageButton_Click" CssClass="btn btn-lg btn-primary btn-block" />

                    <%-- <button class="btn btn-lg btn-primary btn-block" name="Submit" value="Login" type="Submit">Login</button>--%>
                </LayoutTemplate>
            </asp:Login>
            <%--</asp:Panel>--%>
            <asp:HiddenField runat="server" ID="lblID" />
        </div>
    </div>

</asp:Content>
