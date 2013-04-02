<%@ Register TagPrefix="template" TagName="TemplateHeader" src="templateHeader.ascx" %>
<%@ Register TagPrefix="template" TagName="TemplateFooter" src="templateFooter.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Inherits="MCVReg.edit_cv" CodeFile="edit_cv.aspx.vb" %>
<!---<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>default</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">--->
	<template:TemplateHeader runat="server" id="objHeader" />
		<style>th, td {margin:10px; padding:10px; vertical-align:center;}</style>

		<form id="form1" runat="server">
			<asp:panel id="pnlMsg" Visible="False" Runat="server">
				<H4>
					<asp:Label id="lblMsg" Runat="server"></asp:Label></H4>
				<asp:Panel id="pnlReturn" Runat="server" Visible="False">
					<BR>
					<asp:LinkButton id="lnkCV" Runat="server">Return to the Controlled Vocabulary table list</asp:LinkButton>
					<BR>
					<BR>
					<asp:LinkButton id="lnkODM" Runat="server">ODM Home</asp:LinkButton>
				</asp:Panel>
			</asp:panel>
			
			<asp:panel id="pnl1" Runat="server">
				<h2><asp:Label id="lblTableName" Runat="server"></asp:Label></h2>
				<asp:button id="btnBack" Runat="server" Text="Back to CV Page"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp; 
				<asp:dropdownlist id="ddlcv" runat="server" AutoPostBack="True"></asp:dropdownlist><BR>
				<asp:label id="lblTableInformation" runat="server"></asp:label>
				<BR><BR>
				<asp:DataGrid id="dgCV" Runat="server" EnableViewState="True" OnItemCommand="dgCV_ItemCommand"
					AutoGenerateColumns="False" AlternatingItemStyle-BackColor="#C4E1FF"
					CellPadding="8" HeaderStyle-BackColor="#003366" HeaderStyle-ForeColor="#FFFFFF"
					AllowSorting="True" OnSortCommand="SortCommand_OnClick"></asp:DataGrid></asp:panel>
					

			<asp:panel id="pnl2" Visible="False" Runat="server">
				<H2>
					<asp:Label id="lblTable" Runat="server"></asp:Label></H2>
				<TABLE>
					<TR>
						<TD>&nbsp;</TD>
						<TD>Edit values below</TD>
					</TR>
					<TR>
						<TD>
							<asp:Label id="lbl1" Runat="server" Visible="False"></asp:Label></TD>
						<TD>
							<asp:TextBox id="txt1" Runat="server" Visible="False" Width="300"></asp:TextBox><br>
							<asp:RequiredFieldValidator ID="req1" ControlToValidate="txt1" Runat="server" Enabled="False" 
								ErrorMessage="* Required Field" ForeColor="#cc0000" Display="Dynamic" />
							</TD>
						<TD align="right">
							<asp:CheckBox id="chkDelete" Runat="server" Text="Delete this entry"></asp:CheckBox></TD>
					</TR>
			
					<TR>
						<TD>
							<asp:label id="lbl2" Runat="server" Visible="False"></asp:label></TD>
						<TD>
							<asp:TextBox id="txt2" Runat="server" Visible="False" Width="300"></asp:TextBox>
							<asp:RegularExpressionValidator id="reg1" Runat="server" ControlToValidate="txt2" ValidationExpression="^[-,\d]+$" Display="Dynamic"
								ErrorMessage="Values may only be numeric for this field." ForeColor="#cc0000" Enabled="False" />
							<asp:RequiredFieldValidator ID="req2" ControlToValidate="txt2" Runat="server" Enabled="False" 
								ErrorMessage="* Required Field" ForeColor="#cc0000" Display="Dynamic" />
								</TD>
					</TR>

					<TR>
						<TD>
							<asp:label id="lbl3" Runat="server" Visible="False"></asp:label></TD>
						<TD>
							<asp:TextBox id="txt3" Runat="server" Visible="False" Width="300"></asp:TextBox>
							<asp:RequiredFieldValidator ID="req3" ControlToValidate="txt3" Runat="server" Enabled="False" 
								ErrorMessage="* Required Field" ForeColor="#cc0000" Display="Dynamic" />
							</TD>
					</TR>
					<TR>
						<TD>
							<asp:Label id="lbl4" Runat="server" Visible="False"></asp:Label></TD>
						<TD>
							<asp:TextBox id="txt4" Runat="server" Visible="False" Width="300"></asp:TextBox>
							<asp:RequiredFieldValidator ID="req4" ControlToValidate="txt4" Runat="server" Enabled="False" 
								ErrorMessage="* Required Field" ForeColor="#cc0000" Display="Dynamic" />
							<asp:DropDownList id="ddl1" Runat="server" Visible="False">
								<asp:ListItem Value="True"></asp:ListItem>
								<asp:ListItem Value="False"></asp:ListItem>
							</asp:DropDownList></TD>
					</TR>
					<TR>
						<TD>
							<asp:Label id="lbl5" Runat="server" Visible="False"></asp:Label></TD>
						<TD>
							<asp:TextBox id="txt5" Runat="server" Visible="False" Width="300"></asp:TextBox>
							</TD>
					</TR>
					<TR>
						<TD vAlign="top">Reason<BR>
							for request</TD>
						<TD>
							<asp:TextBox id="txtReason" Runat="server" Width="300" TextMode="MultiLine" Rows="3"></asp:TextBox>
							<asp:RequiredFieldValidator ID="reqReason" ControlToValidate="txtReason" Runat="server" Enabled="False" 
								ErrorMessage="* Required Field" ForeColor="#cc0000" Display="Dynamic" />
							</TD>
					</TR>
					<TR>
						<TD>&nbsp;</TD>
					</TR>
					<TR>
						<TD colSpan="2">We may need to contact you to discuss this request</TD>
					</TR>
					<TR>
						<TD>&nbsp;</TD>
					</TR>
					<TR>
						<TD>Your name</TD>
						<TD>
							<asp:TextBox id="txtName" Runat="server" Width="300"></asp:TextBox>
							<asp:RequiredFieldValidator ID="reqName" ControlToValidate="txtName" Runat="server" Enabled="False" 
								ErrorMessage="* Required Field" ForeColor="#cc0000" Display="Dynamic" />
							</TD>
					</TR>
					<TR>
						<TD>Email</TD>
						<TD>
							<asp:TextBox id="txtEmail" Runat="server" Width="300"></asp:TextBox>
							<asp:RequiredFieldValidator ID="reqEmail" ControlToValidate="txtEmail" Runat="server" Enabled="False" 
								ErrorMessage="* Required Field" ForeColor="#cc0000" Display="Dynamic" />
							<asp:RegularExpressionValidator id="regEmail" Runat="server" ControlToValidate="txtEmail" ValidationExpression="^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
								Display="Dynamic" ErrorMessage="Invalid email address" ForeColor="#cc0000"></asp:RegularExpressionValidator></TD>
					</TR>
					<TR>
						<TD>&nbsp;</TD>
					</TR>
					<TR>
						<td>&nbsp;</td>
						<TD align="right" colSpan="2">
							<asp:Button id="btnSubmit" Runat="server" Text="Submit Changes"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:Button id="btnCancel" Runat="server" Text="Cancel" CausesValidation="False"></asp:Button></TD>
					</TR>
				</TABLE>
				<asp:label id="lblAction" runat="server" visible="false"></asp:label>
				<asp:Label id="lblEdit1" Runat="server" Visible="False"></asp:Label>
				<asp:Label id="lblEdit2" Runat="server" Visible="False"></asp:Label>
				<asp:Label id="lblEdit3" Runat="server" Visible="False"></asp:Label>
				<asp:Label id="lblEdit4" Runat="server" Visible="False"></asp:Label>
				<asp:Label id="lblEdit5" Runat="server" Visible="False"></asp:Label>
			</asp:panel>
		</form>
	<template:templatefooter id="objFooter" runat="server"></template:templatefooter></body></html>