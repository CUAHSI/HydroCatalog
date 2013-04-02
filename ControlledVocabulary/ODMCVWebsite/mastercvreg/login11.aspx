<%@ Register TagPrefix="template" TagName="TemplateHeader" src="templateHeader.ascx" %>
<%@ Register TagPrefix="template" TagName="TemplateFooter" src="templateFooter.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Inherits="MCVReg.login11" CodeFile="login11.aspx.vb" %>
<!---<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Controlled Vocabularies Administration</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">	--->
		<template:TemplateHeader runat="server" id="objHeader" />
		
		<form id="Form1" method="post" runat="server">
			<p>Please log in below to view submitted change requests to Controlled Vocabularies:</p>
			<blockquote>
			<table>
				<tr>
					<td>Username:&nbsp;</td>
					<td><asp:TextBox ID="txtName" Runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td>Password:&nbsp;</td>
					<td><asp:TextBox ID="txtPass" TextMode="Password" Runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td colspan="2" align="right"><asp:Button ID="btnSubmit" Runat="server" Text="Login"></asp:Button></td>
				</tr>
			</table></blockquote>
		</form>
		
		<template:templatefooter id="objFooter" runat="server"></template:templatefooter>
	</body>
</HTML>
