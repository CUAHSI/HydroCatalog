<%@ Page Language="C#" AutoEventWireup="true" Title="CUAHSI Hydrologic Information System - Master Controlled Vocabulary Registry" MasterPageFile="~/SiteMaster.master"  CodeFile="cv10.aspx.cs" Inherits="CV_cv10" %>
<%@ Register TagPrefix="Logger" TagName="status" Src="~/status.ascx" %>

<asp:Content ID="Content1"  runat="server" ContentPlaceHolderID="MainContent">
 
    <Logger:status id="Status" runat="server" />
 
    <h1>Master Controlled Vocabulary Registry for ODM 1.0</h1>
    
    <p>CUAHSI's ODM 1.0 has 12 controlled vocabulary tables. This web page has been 
        developed to promote consistency between different instances of the ODM through 
        a moderated system for changing the master controlled vocabularies. This web 
        page displays the master controlled vocabulary entries and allows users to 
        request additions or changes to these. Users may then update their ODM 
        controlled vocabulary tables from this master set using ODM tools as described 
        below.</p><br />
			
	<p>Changes that you request will be forwarded to the master controlled vocabulary 
        Moderators who will attend to requests as promptly as possible. When you submit 
        a request, you should receive an email verifying that you request has been 
        received. When your request is approved, you should also receive an email 
        confirmation. If you have a request that cannot be accommodated on this website, 
        please contact the master controlled vocabulary Moderators:</p>
							
	<table width="40%">
		<tr valign="top">
			<td>
				<p><b>David Tarboton</b><br />
				    Utah State University<br />
				<a href="mailto:david.tarboton@usu.edu">david.tarboton@usu.edu</a></p>
			</td>
			<td>
				<p><b>Michael Piasecki</b><br />
				    Drexel University<br />
				<a href="mailto:mp29@drexel.edu">mp29@drexel.edu</a></p>
			</td>
		</tr>
	</table>
	
    <br />
    
    <h2>Controlled Vocabularies:</h2>
    
    <asp:GridView ID="CVList" runat="server" AutoGenerateColumns="False" DataSourceID="CVInfo" 
        CellPadding="5" CellSpacing="2" ForeColor="#333333" GridLines="None" 
        ShowHeader="False" Width="443px">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:HyperLinkField DataTextField="name" DataNavigateUrlFields="id,name" 
                DataNavigateUrlFormatString="editcv10.aspx?id={0}&amp;tbl={1}&amp;type=&quot;cv10&quot;" />
            <asp:BoundField DataField="description" />
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    
     <asp:ObjectDataSource ID="CVInfo" runat="server" SelectMethod="GetCVInfo" 
         TypeName="GetCVs">
         <SelectParameters>
             <asp:Parameter DefaultValue="cv10" Name="type" Type="String" />
         </SelectParameters>
     </asp:ObjectDataSource>
				
    <br />
	
	<h2>Updating your controlled vocabularies</h2>
	<p>The master controlled vocabularies are published via a set of XML web services 
        that can be accessed at: <a href="http://water.usu.edu/odmcv/odmcv.asmx" target="_blank">
        http://water.usu.edu/odmcv/odmcv.asmx</a>. The methods within this web service 
        will return the most recent ODM controlled vocabulary terms. The Update 
        Controlled Vocabulary tool in ODM tools will update your controlled vocabulary 
        tables by comparing them with the latest information in the master set published 
        through these web services.</p><br />
		
	<a href="../manage/default.aspx">Controlled Vocabularies Administration</a>
   
</asp:Content>
