<%@ Page Language="VB" MasterPageFile="~/MASTER/MasterPage2.master" AutoEventWireup="false" CodeFile="Query_Execution.aspx.vb" Inherits="MASTER_Query_Execution" title="Untitled Page" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <table style="width: 400px; height: 400px;" border="0" cellpadding="0" 
        cellspacing="0" >
        <tr>
            <td colspan="2" align="center">
                <asp:label id="Label4" 
                    style="Z-INDEX: 108; LEFT: 490px; TOP: 208px" runat="server"
				Font-Size="Small" Font-Underline="True" Font-Bold="True" CssClass="Label"> Query 
                Executor</asp:label>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <asp:dropdownlist id="DB_DDL" style="Z-INDEX: 113; LEFT: 208px;  TOP: 96px" runat="server"
				Width="136px" Height="16px" Visible="False">
				<asp:ListItem Value="BOBRISK">BOBRISK</asp:ListItem>
				<asp:ListItem Value="CENTRAL">CENTRAL</asp:ListItem>
				<asp:ListItem Value="INTERCHANGE">INTERCHANGE</asp:ListItem>
				<asp:ListItem Value="MERCHANT">MERCHANT</asp:ListItem>
			        <asp:ListItem Selected="True">PORTAL</asp:ListItem>
			</asp:dropdownlist>
                <asp:label id="Label6" style="Z-INDEX: 114; LEFT: 208px;  TOP: 72px" runat="server"
				Width="95px" Font-Bold="True" CssClass="Label" Visible="False">Select User</asp:label>
                <asp:label id="lbl_datetime" style="Z-INDEX: 115; LEFT: 864px; TOP: 0px; margin-left: 0px;"
				runat="server" Width="138px" Height="19px" CssClass="Label"></asp:label>
            </td>
        </tr>
        <tr>
            <td style="height: 20px;" colspan="2" valign="top">
                <asp:label id="Label2" style="Z-INDEX: 105; LEFT: 8px; TOP: 96px" 
                    runat="server" CssClass="Label">SQL Statement</asp:label></td>
        </tr>
        <tr>
            <td colspan="2" style="height: 111px" valign="top">
			<asp:textbox id="TextBox1" style="Z-INDEX: 1; LEFT: 8px;  TOP: 120px" tabIndex="1"
				runat="server" Font-Names="Courier New" Font-Size="X-Small" Width="519px" Height="111px" 
                    TextMode="MultiLine"></asp:textbox></td>
        </tr>
        <tr>
            <td colspan="2" style="height: 31px" valign="middle">
			    &nbsp;
			    <asp:button id="Button1" style="Z-INDEX: 103; LEFT: 346px;  TOP: 384px" tabIndex="2"
				runat="server" Width="79px" Text="Query" CssClass="Button" Height="23px"></asp:button>
			    &nbsp;<asp:button id="Button2" style="Z-INDEX: 106; LEFT: 428px; TOP: 384px" tabIndex="3"
				runat="server" Width="80px" Text="Reset" CssClass="Button" Height="23px"></asp:button>
			<asp:Button id="Button3" style="Z-INDEX: 117; LEFT: 512px;  TOP: 384px" runat="server"
				Height="24px" Width="72px" Text="Clipboard" CssClass="Button" Visible="False"></asp:Button>
			</td>
        </tr>
        <tr>
            <td colspan="2" style="height: 35px">
                <asp:label id="Label1" style="Z-INDEX: 104; LEFT: 8px;  TOP: 240px" runat="server"
				Font-Size="Small" Visible="False"></asp:label>
			</td>
        </tr>
        <tr>
            <td style="width: 107px; height: 36px;" align="right">
                <asp:Label ID="Label8" runat="server" Text="Enter File name for excel :" 
                    Visible="False" Width="209px" CssClass="Label" Font-Bold="True" 
                    Font-Names="Verdana" Font-Size="Small"></asp:Label>
            </td>
            <td style="height: 36px;padding-left:5px">
                <asp:textbox id="TextBox2" style="Z-INDEX: 111; LEFT: 768px;  TOP: 240px"
				runat="server" Width="230px" Visible="False"></asp:textbox></td>
        </tr>
        <tr>
            <td style="width: 107px; height: 40px;" align="right">
                <asp:button id="Download_Excel_Btn" style="Z-INDEX: 110; LEFT: 544px;  TOP: 240px"
				runat="server" Width="156px" Height="28px" Text="Download Excel" 
                    Visible="False" CssClass="Button"></asp:button></td>
            <td style="height: 40px">
                <asp:LinkButton ID="lnk_download" runat="server" CssClass="Link" 
                    Visible="False">Download</asp:LinkButton>
			<asp:Label id="Label7" style="Z-INDEX: 118; LEFT: 344px;  TOP: 272px" runat="server"
				Height="16px" Width="168px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 107px">
			    &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
			    <asp:Panel ID="Panel1" runat="server" ScrollBars="Horizontal" Width="700px" 
                    Visible="False" >
                    <asp:datagrid id="DataGrid1" 
    style="Z-INDEX: 102; LEFT: 8px;  TOP: 272px" runat="server"
				Font-Names="Verdana" Font-Size="X-Small" CellPadding="3" BorderWidth="1px" 
                    BorderStyle="None" BackColor="White" AllowPaging="True" 
                    CssClass="DataGrid" Height="300px" 
    Width="600px">
                        <SelectedItemStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#738A9C">
                        </SelectedItemStyle>
                        <AlternatingItemStyle BackColor="#E0E0E0"></AlternatingItemStyle>
                        <HeaderStyle Font-Bold="True" ForeColor="Black" BackColor="ControlLight">
                        </HeaderStyle>
                        <PagerStyle HorizontalAlign="Right" Position="TopAndBottom" Mode="NumericPages">
                        </PagerStyle>
                    </asp:datagrid>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="2">
			    &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

