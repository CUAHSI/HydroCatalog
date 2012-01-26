<%@ Page Language="vb" AutoEventWireup="false" Inherits="MCVReg.cv11" CodeFile="cv11.aspx.vb" %>
<%@ Register TagPrefix="template" TagName="TemplateFooter" src="templateFooter.ascx" %>
<%@ Register TagPrefix="template" TagName="TemplateHeader" src="templateHeader.ascx" %>
<!---<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>default</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">--->
		<template:TemplateHeader runat="server" id="objHeader" />
		
		<form id="form1_11" runat="server">
		
			<asp:Panel ID="pnlMsg_11" Runat="server" Visible="False">
				<asp:Label id="lblMsg_11" Runat="server"></asp:Label>
			</asp:Panel>
			
			<h1>Master Controlled Vocabulary Registry for ODM 1.1</h1>
			<p>CUAHSI's ODM 1.1 has 12 controlled vocabulary tables.  This web page has been developed to promote 
			consistency between different instances of the ODM through a moderated system for changing the 
			master controlled vocabularies.  This web page displays the master controlled vocabulary 
			entries and allows users to request additions or changes to these.  Users may then update their ODM 
			controlled vocabulary tables from this master set using ODM tools as described below.</p><br>
				
				<p>Changes that you request will be forwarded to the master controlled vocabulary moderators who will attend 
				to requests as promptly as possible.  When you submit a request, you should receive an 
				email verifying that you request has been received.  When your request is approved, you 
				should also receive an email confirmation.  If you have a request that cannot be accommodated 
				on this website, please contact the master controlled vocabulary moderators:</p>
				<p>
					<table width="40%">
						<tr valign="top">
							<td>
								<p><b>David Tarboton</b><br>
								Utah State University<br>
								<a href="mailto:david.tarboton@usu.edu">david.tarboton@usu.edu</a></p>
							</td>
							<td>
								<p><b>Michael Piasecki</b><br>
								Drexel University<br>
								<a href="mailto:mp29@drexel.edu">mp29@drexel.edu</a></p>
							</td>
						</tr>
					</table>
				</p><br>
				
			<H2>Controlled Vocabularies:</H2>
				<table cellpadding="3" cellspacing="9">
				<tr>
					<td><a href="edit_cv11.aspx?tbl=CensorCodeCV&id=501576825">CensorCodeCV</a>:</td><td>Used to populate the CensorCode field of the DataValues table</td>
				</tr>
				<tr>
					<td><a href="edit_cv11.aspx?tbl=DataTypeCV&id=485576768">DataTypeCV:</a></td><td>Used to populate the DataType field of the Variables table</td>
				</tr>
				<tr>
					<td><a href="edit_cv11.aspx?tbl=GeneralCategoryCV&id=517576882">GeneralCategoryCV:</a></td><td>Used to populate the GeneralCategory field in the Variables table</td>
				</tr>
				<tr>
					<td><a href="edit_cv11.aspx?tbl=SampleMediumCV&id=533576939">SampleMediumCV:</a></td><td>Used to populate the SampleMedium field in the Variables table</td>
				</tr>
				<tr>
					<td><a href="edit_cv11.aspx?tbl=SampleTypeCV&id=549576996">SampleTypeCV:</a></td><td>Used to populate the SampleType field in the Samples table</td>
				</tr>
				<tr>
					<td><a href="edit_cv11.aspx?tbl=SpatialReferences&id=565577053">SpatialReferences:</a></td><td>Defines the coordinate systems used in the Sites table</td>
				</tr>
				<tr>
					<td><a href="edit_cv11.aspx?tbl=SpeciationCV&id=581577110">SpeciationCV:</a></td><td>Used to poputate the Speciation field in the Variables table</td>
				</tr>
				<tr>
					<td><a href="edit_cv11.aspx?tbl=TopicCategoryCV&id=773577794">TopicCategoryCV:</a></td><td>Used to populate the TopicCategory field in the ISOMetadata table</td>
				</tr>
				<tr>
					<td><a href="edit_cv11.aspx?tbl=Units&id=789577851">Units:</a></td><td>Defines the units used in the Variables and Offset types tables</td>
				</tr>
				<tr>
					<td><a href="edit_cv11.aspx?tbl=ValueTypeCV&id=805577908">ValueTypeCV:</a></td><td>Used to populate the ValueType field in the Variables table</td>
				</tr>
				<tr>
					<td><a href="edit_cv11.aspx?tbl=VariableNameCV&id=821577965">VariableNameCV:</a></td><td>Used to populate the VariableName field in the Variables table</td>
				</tr>
				<tr>
					<td><a href="edit_cv11.aspx?tbl=VerticalDatumCV&id=837578022">VerticalDatumCV:</a></td><td>Used to populate the VerticalDatum field im the Sites table</td>
				</tr>
				</table>
				
				<br>
				<h2>Updating your controlled vocabularies</h2>
				<p>The master controlled vocabularies are published via a set of XML web services that 
				can be accessed at: <a href="http://odm.usu.edu/ODMCV_1_1/ODMCV_1_1.asmx" target="_blank">http://odm.usu.edu/ODMCV_1_1/ODMCV_1_1.asmx</a>.  The methods within this web 
				service will return the most recent ODM controlled vocabulary terms.  The Update Controlled 
				Vocabulary tool in ODM tools will update your controlled vocabulary tables by comparing 
				them with the latest information in the master set published through these web services.</p><br>
				
				<a href="admindefault11.aspx">Controlled Vocabularies Administration</a>
		</form>
		
		<template:templatefooter id="objFooter" runat="server"></template:templatefooter></body>
</HTML>
