<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Password_strength.aspx.vb" Inherits="MASTER_Password_strength"  title="Catalyst." EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="navStyle.css" type="text/css" rel="stylesheet">
    <style type="text/css">

 p.MsoNormal
	{margin:0in;
	margin-bottom:.0001pt;
	font-size:12.0pt;
	font-family:"Times New Roman";
	color:windowtext;}
p
	{margin-right:0in;
	margin-left:0in;
	font-size:12.0pt;
	font-family:"Times New Roman";
	color:black;
        }
        .style1
        {
            width: 100%;
        }
        
        body
        
        {
            background-image:url('../master/images/')
            
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
   
    <table class="style1" 
        
        style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: Purple; border-top-style: solid; border-top-width: thin; border-top-color:Purple;">
        <tr>
            <td align="left">
             <div>
    
        <p class="MsoNormal" style="mso-margin-top-alt: auto; mso-margin-bottom-alt: auto">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Master/Images/NPCI.JPG"
                            Height="49px" Width="257px" />
            </p>
                 <p class="MsoNormal" 
            style="mso-margin-top-alt: auto; mso-margin-bottom-alt: auto">
                     <b><font color="black" face="Arial" size="2">
                     <span style="FONT-FAMILY: Arial; COLOR: black; FONT-SIZE: 10pt; FONT-WEIGHT: bold">
            How safe is your password?</span></font></b><font color="black" face="Arial" 
                size="2"><span style="FONT-FAMILY: Arial; COLOR: black; FONT-SIZE: 10pt"><br />
            <br />
            The first step in protecting your online privacy is creating a safe password - 
            i.e. one that a computer program or persistent individual won&#39;t easily be able 
            to guess in a short period of time. To help you choose a secure password, we&#39;ve 
            created a feature that lets you know visually how safe your password is as soon 
            as you create it.<br />
            <br />
            <b><span style="FONT-WEIGHT: bold">Tips for creating a secure password:</span></b><o:p></o:p></span></font></p>
        <p class="MsoNormal" 
            style="TEXT-INDENT: -0.25in; MARGIN-LEFT: 47.25pt; mso-margin-top-alt: auto; mso-margin-bottom-alt: auto; mso-list: l0 level1 lfo1">
            <font color="black" face="Symbol" size="2">
            <span style="FONT-FAMILY: Symbol; COLOR: black; FONT-SIZE: 10pt">
            <span style="mso-list: Ignore">·<font face="Times New Roman" size="1"><span 
                style="FONT: 7pt 'Times New Roman'">&nbsp; </span></font></span></span>
            </font><font color="black" face="Arial" size="2">
            <span style="FONT-FAMILY: Arial; COLOR: black; FONT-SIZE: 10pt">Include 
            punctuation marks and/or numbers. <o:p></o:p></span></font>
        </p>
        <p class="MsoNormal" 
            style="TEXT-INDENT: -0.25in; MARGIN-LEFT: 47.25pt; mso-margin-top-alt: auto; mso-margin-bottom-alt: auto; mso-list: l0 level1 lfo1">
            <font color="black" face="Symbol" size="2">
            <span style="FONT-FAMILY: Symbol; COLOR: black; FONT-SIZE: 10pt">
            <span style="mso-list: Ignore">·<font face="Times New Roman" size="1"><span 
                style="FONT: 7pt 'Times New Roman'">&nbsp; </span></font></span></span>
            </font><font color="black" face="Arial" size="2">
            <span style="FONT-FAMILY: Arial; COLOR: black; FONT-SIZE: 10pt">Mix capital and 
            lowercase letters. <o:p></o:p></span></font>
        </p>
        <p class="MsoNormal" 
            style="TEXT-INDENT: -0.25in; MARGIN-LEFT: 47.25pt; mso-margin-top-alt: auto; mso-margin-bottom-alt: auto; mso-list: l0 level1 lfo1">
            <font color="black" face="Symbol" size="2">
            <span style="FONT-FAMILY: Symbol; COLOR: black; FONT-SIZE: 10pt">
            <span style="mso-list: Ignore">·<font face="Times New Roman" size="1"><span 
                style="FONT: 7pt 'Times New Roman'">&nbsp; </span></font></span></span>
            </font><font color="black" face="Arial" size="2">
            <span style="FONT-FAMILY: Arial; COLOR: black; FONT-SIZE: 10pt">Include similar 
            looking substitutions, such as the number zero for the letter &#39;O&#39; or &#39;$&#39; for the 
            letter &#39;S&#39;. <o:p></o:p></span></font>
        </p>
        <p class="MsoNormal" 
            style="TEXT-INDENT: -0.25in; MARGIN-LEFT: 47.25pt; mso-margin-top-alt: auto; mso-margin-bottom-alt: auto; mso-list: l0 level1 lfo1">
            <font color="black" face="Symbol" size="2">
            <span style="FONT-FAMILY: Symbol; COLOR: black; FONT-SIZE: 10pt">
            <span style="mso-list: Ignore">·<font face="Times New Roman" size="1"><span 
                style="FONT: 7pt 'Times New Roman'">&nbsp; </span></font></span></span>
            </font><font color="black" face="Arial" size="2">
            <span style="FONT-FAMILY: Arial; COLOR: black; FONT-SIZE: 10pt">Create a unique 
            acronym. <o:p></o:p></span></font>
        </p>
        <p class="MsoNormal" 
            style="TEXT-INDENT: -0.25in; MARGIN-LEFT: 47.25pt; mso-margin-top-alt: auto; mso-margin-bottom-alt: auto; mso-list: l0 level1 lfo1">
            <font color="black" face="Symbol" size="2">
            <span style="FONT-FAMILY: Symbol; COLOR: black; FONT-SIZE: 10pt">
            <span style="mso-list: Ignore">·<font face="Times New Roman" size="1"><span 
                style="FONT: 7pt 'Times New Roman'">&nbsp; </span></font></span></span>
            </font><font color="black" face="Arial" size="2">
            <span style="FONT-FAMILY: Arial; COLOR: black; FONT-SIZE: 10pt">Include phonetic 
            replacements, such as &#39;Luv 2 Laf&#39; for &#39;Love to Laugh&#39;.<o:p></o:p></span></font></p>
        <p class="MsoNormal">
            <b><font color="black" face="Arial" size="2">
            <span style="FONT-FAMILY: Arial; COLOR: black; FONT-SIZE: 10pt; FONT-WEIGHT: bold">
            Things to avoid:</span></font></b><font color="black" face="Arial" size="2"><span 
                style="FONT-FAMILY: Arial; COLOR: black; FONT-SIZE: 10pt"><o:p></o:p></span></font></p>
        <p class="MsoNormal" 
            style="TEXT-INDENT: -0.25in; MARGIN-LEFT: 47.25pt; mso-margin-top-alt: auto; mso-margin-bottom-alt: auto; mso-list: l1 level1 lfo2">
            <font color="black" face="Symbol" size="2">
            <span style="FONT-FAMILY: Symbol; COLOR: black; FONT-SIZE: 10pt">
            <span style="mso-list: Ignore">·<font face="Times New Roman" size="1"><span 
                style="FONT: 7pt 'Times New Roman'">&nbsp; </span></font></span></span>
            </font><font color="black" face="Arial" size="2">
            <span style="FONT-FAMILY: Arial; COLOR: black; FONT-SIZE: 10pt">Don&#39;t use a 
            password that is listed as an example of how to pick a good password. 
<o:p></o:p></span></font>
        </p>
        <p class="MsoNormal" 
            style="TEXT-INDENT: -0.25in; MARGIN-LEFT: 47.25pt; mso-margin-top-alt: auto; mso-margin-bottom-alt: auto; mso-list: l1 level1 lfo2">
            <font color="black" face="Symbol" size="2">
            <span style="FONT-FAMILY: Symbol; COLOR: black; FONT-SIZE: 10pt">
            <span style="mso-list: Ignore">·<font face="Times New Roman" size="1"><span 
                style="FONT: 7pt 'Times New Roman'">&nbsp; </span></font></span></span>
            </font><font color="black" face="Arial" size="2">
            <span style="FONT-FAMILY: Arial; COLOR: black; FONT-SIZE: 10pt">Don&#39;t use a 
            password that contains personal information (name, birth date, etc.) 
<o:p></o:p></span></font>
        </p>
        <p class="MsoNormal" 
            style="TEXT-INDENT: -0.25in; MARGIN-LEFT: 47.25pt; mso-margin-top-alt: auto; mso-margin-bottom-alt: auto; mso-list: l1 level1 lfo2">
            <font color="black" face="Symbol" size="2">
            <span style="FONT-FAMILY: Symbol; COLOR: black; FONT-SIZE: 10pt">
            <span style="mso-list: Ignore">·<font face="Times New Roman" size="1"><span 
                style="FONT: 7pt 'Times New Roman'">&nbsp; </span></font></span></span>
            </font><font color="black" face="Arial" size="2">
            <span style="FONT-FAMILY: Arial; COLOR: black; FONT-SIZE: 10pt">Don&#39;t use words 
            or acronyms that can be found in a dictionary. <o:p></o:p></span></font>
        </p>
        <p class="MsoNormal" 
            style="TEXT-INDENT: -0.25in; MARGIN-LEFT: 47.25pt; mso-margin-top-alt: auto; mso-margin-bottom-alt: auto; mso-list: l1 level1 lfo2">
            <font color="black" face="Symbol" size="2">
            <span style="FONT-FAMILY: Symbol; COLOR: black; FONT-SIZE: 10pt">
            <span style="mso-list: Ignore">·<font face="Times New Roman" size="1"><span 
                style="FONT: 7pt 'Times New Roman'">&nbsp; </span></font></span></span>
            </font><font color="black" face="Arial" size="2">
            <span style="FONT-FAMILY: Arial; COLOR: black; FONT-SIZE: 10pt">Don&#39;t use 
            keyboard patterns (asdf) or sequential numbers (1234). <o:p></o:p></span></font>
        </p>
        <p class="MsoNormal" 
            style="TEXT-INDENT: -0.25in; MARGIN-LEFT: 47.25pt; mso-margin-top-alt: auto; mso-margin-bottom-alt: auto; mso-list: l1 level1 lfo2">
            <font color="black" face="Symbol" size="2">
            <span style="FONT-FAMILY: Symbol; COLOR: black; FONT-SIZE: 10pt">
            <span style="mso-list: Ignore">·<font face="Times New Roman" size="1"><span 
                style="FONT: 7pt 'Times New Roman'">&nbsp; </span></font></span></span>
            </font><font color="black" face="Arial" size="2">
            <span style="FONT-FAMILY: Arial; COLOR: black; FONT-SIZE: 10pt">Don&#39;t make your 
            password all numbers, uppercase letters or lowercase letters. 
<o:p></o:p></span></font>
        </p>
        <p class="MsoNormal" 
            style="TEXT-INDENT: -0.25in; MARGIN-LEFT: 47.25pt; mso-margin-top-alt: auto; mso-margin-bottom-alt: auto; mso-list: l1 level1 lfo2">
            <font color="black" face="Symbol" size="2">
            <span style="FONT-FAMILY: Symbol; COLOR: black; FONT-SIZE: 10pt">
            <span style="mso-list: Ignore">·<font face="Times New Roman" size="1"><span 
                style="FONT: 7pt 'Times New Roman'">&nbsp; </span></font></span></span>
            </font><font color="black" face="Arial" size="2">
            <span style="FONT-FAMILY: Arial; COLOR: black; FONT-SIZE: 10pt">Don&#39;t use 
            repeating characters (aa11).<o:p></o:p></span></font></p>
        <p class="MsoNormal">
            <b><font color="black" face="Arial" size="2">
            <span style="FONT-FAMILY: Arial; COLOR: black; FONT-SIZE: 10pt; FONT-WEIGHT: bold">
            Tips for keeping your password secure:</span></font></b><font color="black" 
                face="Arial" size="2"><span 
                style="FONT-FAMILY: Arial; COLOR: black; FONT-SIZE: 10pt"> 
<o:p></o:p></span></font>
        </p>
        <p class="MsoNormal" 
            style="TEXT-INDENT: -0.25in; MARGIN-LEFT: 47.25pt; mso-margin-top-alt: auto; mso-margin-bottom-alt: auto; mso-list: l2 level1 lfo3">
            <font color="black" face="Symbol" size="2">
            <span style="FONT-FAMILY: Symbol; COLOR: black; FONT-SIZE: 10pt">
            <span style="mso-list: Ignore">·<font face="Times New Roman" size="1"><span 
                style="FONT: 7pt 'Times New Roman'">&nbsp; </span></font></span></span>
            </font><font color="black" face="Arial" size="2">
            <span style="FONT-FAMILY: Arial; COLOR: black; FONT-SIZE: 10pt">Never tell your 
            password to anyone (this includes significant others, roommates, parrots, etc.). 
<o:p></o:p></span></font>
        </p>
        <p class="MsoNormal" 
            style="TEXT-INDENT: -0.25in; MARGIN-LEFT: 47.25pt; mso-margin-top-alt: auto; mso-margin-bottom-alt: auto; mso-list: l2 level1 lfo3">
            <font color="black" face="Symbol" size="2">
            <span style="FONT-FAMILY: Symbol; COLOR: black; FONT-SIZE: 10pt">
            <span style="mso-list: Ignore">·<font face="Times New Roman" size="1"><span 
                style="FONT: 7pt 'Times New Roman'">&nbsp; </span></font></span></span>
            </font><font color="black" face="Arial" size="2">
            <span style="FONT-FAMILY: Arial; COLOR: black; FONT-SIZE: 10pt">Never write your 
            password down. <o:p></o:p></span></font>
        </p>
        <p class="MsoNormal" 
            style="TEXT-INDENT: -0.25in; MARGIN-LEFT: 47.25pt; mso-margin-top-alt: auto; mso-margin-bottom-alt: auto; mso-list: l2 level1 lfo3">
            <font color="black" face="Symbol" size="2">
            <span style="FONT-FAMILY: Symbol; COLOR: black; FONT-SIZE: 10pt">
            <span style="mso-list: Ignore">·<font face="Times New Roman" size="1"><span 
                style="FONT: 7pt 'Times New Roman'">&nbsp; </span></font></span></span>
            </font><font color="black" face="Arial" size="2">
            <span style="FONT-FAMILY: Arial; COLOR: black; FONT-SIZE: 10pt">Never send your 
            password by email. <o:p></o:p></span></font>
        </p>
        <p class="MsoNormal" 
            style="TEXT-INDENT: -0.25in; MARGIN-LEFT: 47.25pt; mso-margin-top-alt: auto; mso-margin-bottom-alt: auto; mso-list: l2 level1 lfo3">
            <font color="black" face="Symbol" size="2">
            <span style="FONT-FAMILY: Symbol; COLOR: black; FONT-SIZE: 10pt">
            <span style="mso-list: Ignore">·<font face="Times New Roman" size="1"><span 
                style="FONT: 7pt 'Times New Roman'">&nbsp; </span></font></span></span>
            </font><font color="black" face="Arial" size="2">
            <span style="FONT-FAMILY: Arial; COLOR: black; FONT-SIZE: 10pt">Periodically 
            test your current password and change it to a new one<o:p></o:p></span></font></p>
        <p class="MsoNormal" 
            style="TEXT-INDENT: -0.25in; MARGIN-LEFT: 47.25pt; mso-margin-top-alt: auto; mso-margin-bottom-alt: auto; mso-list: l2 level1 lfo3">
            <o:p></o:p></p>
    
    </div>
                </td>
        </tr>
        <tr>
            <td align="center">
                <br />
                <asp:Button ID="btn_close" runat="server" CssClass="Button" Text="Close" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
