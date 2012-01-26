<%@ Page Language="vb" AutoEventWireup="false" Inherits="MCVReg.admindefault11" CodeFile="admindefault11.aspx.vb" %>
<%@ Register TagPrefix="template" TagName="TemplateFooter" src="templateFooter.ascx" %>
<%@ Register TagPrefix="template" TagName="TemplateHeader" src="templateHeader.ascx" %>
<!---<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Controlled Vocabularies Administration</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">--->
		<template:TemplateHeader runat="server" id="objHeader" />
		<form id="Form1" method="post" runat="server">
			<h2>Pending Controlled Vocabulary Submissions &mdash; ODM Version 1.1</h2>
				<style>th, td {margin:10px; padding:10px; vertical-align:center;}</style>
				<table width="90%" align="center">
					<tr>
						<td>
							<asp:Table ID="tbl1" Runat="server"></asp:Table>
						</td>
					</tr>
				</table>
			<a href="cv11.aspx">Return to Controlled Vocabulary Table list</a><br><br>
		</form>
		<template:templatefooter id="objFooter" runat="server"></template:templatefooter>
	</body>
</HTML>
