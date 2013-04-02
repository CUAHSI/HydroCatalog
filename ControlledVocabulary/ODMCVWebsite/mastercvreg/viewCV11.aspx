<%@ Register TagPrefix="template" TagName="TemplateHeader" src="templateHeader.ascx" %>
<%@ Register TagPrefix="template" TagName="TemplateFooter" src="templateFooter.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Inherits="MCVReg.viewCV11" CodeFile="viewCV11.aspx.vb" %>
<!---<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>viewCV</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout"> --->
		<template:TemplateHeader runat="server" id="objHeader" />
		<style>th, td {margin:10px; padding:10px; vertical-align:center;}</style>
		<form id="Form1" method="post" runat="server">
			<asp:panel id="pnlMsg" Visible="False" Runat="server">
				<H4>
					<asp:Label id="lblMsg" Runat="server" ForeColor="#003366"></asp:Label></H4>
				<asp:Panel id="pnlReturn" Runat="server" Visible="False">
					<BR>
					<a href="admindefault11.aspx">Return to Pending Controlled Vocabularies Submissions</a>
					<BR>
				</asp:Panel>
			</asp:panel>
			<asp:Panel ID="pnl1" Runat="server">
			<asp:Label ID="lblTableName" Runat="server"></asp:Label><br>
			<br>
				<TABLE cellpadding="8">
					<TR>
						<TD valign="middle">
							<asp:Label id="lbl1" Runat="server" Visible="False"></asp:Label></TD>
						<td><asp:Label ID="lblHeader2" Runat="server"></asp:Label><br>
							<asp:textbox id="txtEdit1" runat="server" visible="false"></asp:textbox>
							<asp:RequiredFieldValidator ID="req1" ControlToValidate="txtEdit1" Runat="server" Enabled="False" 
								ErrorMessage="* Required Field" ForeColor="#cc0000" Display="Dynamic" />
							</td>
						<TD><asp:Label ID="lblHeader1" Runat="server"></asp:Label><br>
							<asp:TextBox id="txt1" Runat="server" Visible="False" ReadOnly="True"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD valign="middle">
							<asp:Label id="lbl2" Runat="server" Visible="False"></asp:Label></TD>
						<td>
							<asp:textbox id="txtEdit2" runat="server" visible="false" Width="300"></asp:textbox><br>
							<asp:RegularExpressionValidator id="reg1" Runat="server" Enabled="False" ForeColor="#cc0000" ErrorMessage="Values may only be numeric for this field."
								Display="Dynamic" ValidationExpression="^\d+$" ControlToValidate="txtEdit2" />
							<asp:RequiredFieldValidator ID="req2" ControlToValidate="txtEdit2" Runat="server" Enabled="False" 
								ErrorMessage="* Required Field" ForeColor="#cc0000" Display="Dynamic" />
								</td>
						<TD>
							<asp:TextBox id="txt2" Runat="server" Visible="False" Width="300" ReadOnly="True"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD valign="middle">
							<asp:label id="lbl3" Runat="server" Visible="False"></asp:label></TD>
						<td>
							<asp:textbox id="txtEdit3" runat="server" visible="false" Width="300"></asp:textbox>
							<asp:RequiredFieldValidator ID="req3" ControlToValidate="txtEdit3" Runat="server" Enabled="False" 
								ErrorMessage="* Required Field" ForeColor="#cc0000" Display="Dynamic" />
							</td>
						<TD>
							<asp:TextBox id="txt3" Runat="server" Visible="False" Width="300" ReadOnly="True"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD valign="middle">
							<asp:Label id="lbl4" Runat="server" Visible="False"></asp:Label></TD>
						<td valign="middle">
							<asp:textbox id="txtEdit4" runat="server" visible="false" width="300"></asp:textbox>
							<asp:DropDownList id="ddl2" Runat="server" Visible="False">
								<asp:ListItem Value="True"></asp:ListItem>
								<asp:ListItem Value="False"></asp:ListItem>
							</asp:DropDownList>
							<asp:RequiredFieldValidator ID="req4" ControlToValidate="txtEdit4" Runat="server" Enabled="False" 
								ErrorMessage="* Required Field" ForeColor="#cc0000" Display="Dynamic" />
							</td>
						</TD>
						<TD>
							<asp:TextBox id="txt4" Runat="server" Visible="False" Width="300" ReadOnly="True"></asp:TextBox>
							<asp:DropDownList id="ddl1" Runat="server" Visible="False" Enabled="False">
								<asp:ListItem Value="True"></asp:ListItem>
								<asp:ListItem Value="False"></asp:ListItem>
							</asp:DropDownList>
							</TD>
					</TR>
					<TR>
						<TD valign="middle">
							<asp:Label id="lbl5" Runat="server" Visible="False"></asp:Label></TD>
						<td>
							<asp:textbox id="txtEdit5" runat="server" visible="false" width="300"></asp:textbox></td>
						<TD>
							<asp:TextBox id="txt5" Runat="server" Visible="False" Width="300" ReadOnly="True"></asp:TextBox></TD>
					</TR>
					<tr>
						<td>Requested Change:</td>
						<td><asp:Label ID="lblAction" Runat="server"></asp:Label></td>
					</tr>
					<tr>
						<td>Submitter:</td>
						<td><asp:Label ID="lblSubmitter" Runat="server"></asp:Label></td>
					</tr>
					<tr>
						<td>Email Address:&nbsp;&nbsp;</td>
						<td><asp:Label ID="lblEmail" Runat="server"></asp:Label></td>
					</tr>
					<tr>
						<td>Reason:</td>
						<td><asp:Label ID="lblReason" Runat="server"></asp:Label></td>
					</tr>
					<TR>
						<TD vAlign="top">Admin Notes:</TD>
						<TD>
							<asp:TextBox id="txtReason" Runat="server" Rows="3" TextMode="MultiLine" width="300"></asp:TextBox>
							<asp:RequiredFieldValidator ID="reqReason" ControlToValidate="txtReason" Runat="server"  
								ErrorMessage="* Required Field" ForeColor="#cc0000" Display="Dynamic" />
							</TD>
					</TR>
				</table>
				<asp:Label ID="lblEmailAddress" Runat="server" Visible="False"></asp:Label>
				<!---<asp:DataGrid ID="dgViewCV" Runat="server" CellPadding="8" AutoGenerateColumns="False"></asp:DataGrid>--->
			<br>
			<br>
			<asp:Button ID="btnSubmit" Runat="server" Text="Accept Changes"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:Button ID="btnReject" Runat="server" Text="Reject Submission"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:button id="btnReturn" runat="server" text="Return to Pending Submissions" causesvalidation="false"></asp:button>
			</asp:Panel>
		</form>
		<template:templatefooter id="objFooter" runat="server"></template:templatefooter>
	</body>
</HTML>
