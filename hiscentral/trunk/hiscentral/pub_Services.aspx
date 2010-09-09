<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="pub_Services.aspx.cs" Inherits="_Default" %>

<%@ Register Src="HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CUAHSI HIS Central</title>


</head>

<body >
    <form id="form1" runat="server">
       <uc1:HeaderControl ID="HeaderControl1" runat="server" />
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" Style="z-index: 100;
            left: 28px; position: absolute; top: 170px" Text="All Registered Data Services" Width="416px"></asp:Label>
   
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CentralHISConnectionString %>"
            SelectCommand="SELECT NetworkID, username, NetworkName, ServiceWSDL, ContactName, Organization, website, IsPublic, NetworkTitle, ProjectStatus, CONVERT(VARCHAR(10), CreatedDate, 102) AS CreatedDate, CONVERT(VARCHAR(10), EarliestRec, 102) AS EarliestRec, CONVERT(VARCHAR(10), LatestRec, 102) AS LatestRec FROM HISNetworks WHERE (IsPublic = 'True') order by servicegroup, networkname">
        </asp:SqlDataSource>
        <div class="mainblock">
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
            CellPadding="4" DataKeyNames="NetworkID" DataSourceID="SqlDataSource1" GridLines="None"
             Style="z-index: 100;
            left: 0px; position: absolute; top: 200px" OnRowCommand="GridView1_RowCommand" ForeColor="#333333" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="True" Font-Size="Small" PageSize="50">
            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
            <Columns>
              <asp:HyperLinkField DataNavigateUrlFields="NetworkID" DataNavigateUrlFormatString="pub_network.aspx?n={0}"
                DataTextField="NetworkTitle" HeaderText="Data Service Title" />
              <asp:HyperLinkField DataNavigateUrlFields="NetworkID" DataNavigateUrlFormatString="pub_network.aspx?n={0}"
                DataTextField="NetworkName" HeaderText="Observation Network Name" />
                <asp:BoundField DataField="ServiceWSDL" HeaderText="WSDL" SortExpression="ServiceWSDL" DataFormatString="&lt;a href={0} target=_new&gt;WSDL&lt;/a&gt;" HtmlEncode="False" />
              <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" SortExpression="CreatedDate" />
                <asp:HyperLinkField DataNavigateUrlFields="website" DataTextField="Organization"
                    HeaderText="Organization" SortExpression="Organization" />
                <asp:BoundField DataField="ContactName" HeaderText="Contact" SortExpression="ContactName" />
              <asp:BoundField DataField="ProjectStatus" HeaderText="Status" SortExpression="ProjectStatus" />
              <asp:BoundField DataField="EarliestRec" HeaderText="Earliest Start Date" SortExpression="EarliestRec" />
              <asp:BoundField DataField="LatestRec" HeaderText="Latest End Date" SortExpression="LatestRec" />
            </Columns>
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="Small" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="LightSteelBlue" Font-Bold="True" ForeColor="Black" Font-Italic="False" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
        </asp:GridView>
          &nbsp;&nbsp;



             </div>
     

    </form>
</body>
</html>
