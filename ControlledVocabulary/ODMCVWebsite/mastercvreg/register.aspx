<%@ Page Language="vb" AutoEventWireup="false" Inherits="MCVReg.register" CodeFile="register.aspx.vb" %>
<%@ Register TagPrefix="template" TagName="templateHeader" src="templateHeader.ascx" %>
<%@ Register TagPrefix="template" TagName="templateFooter" src="templateFooter.ascx" %>
<template:templateHeader id="objHeader" runat="server" />
<h2>Before visiting the ODM Downloads page, please take a moment to register with 
	us. We will only use your email address to let you know about updates to ODM 
	and new releases.</h2>
<form id="form1" runat="server">
	<table width="60%" align="center">
		<tr>
			<td>Name:</td>
			<td><asp:textbox id="txt_name" runat="server" maxlength="120" width="200px"></asp:textbox></td>
		</tr>
		<tr>
			<td colspan="2">&nbsp;</td>
		</tr>
		<tr>
			<td>Organization:</td>
			<td><asp:textbox id="txt_organization" runat="server" maxlength="120" width="250px"></asp:textbox></td>
		</tr>
		<tr>
			<td colspan="2">&nbsp;</td>
		</tr>
		<tr>
			<td>Email Address:&nbsp;&nbsp;</td>
			<td><asp:textbox id="txt_email" runat="server" maxlength="120" width="200px"></asp:textbox>
				<asp:requiredfieldvalidator id="req_email" runat="server" errormessage="Email Address is required to continue."
					controltovalidate="txt_email" display="dynamic" />
			</td>
		</tr>
		<tr>
			<td colspan="2">&nbsp;</td>
		</tr>
		<tr>
			<td>&nbsp;</td>
			<td align="right"><asp:button id="btn_submit" text="Submit and Continue" runat="server"></asp:button></td>
		</tr>
	</table>
</form>
<template:templateFooter id="objFooter" runat="server" />
