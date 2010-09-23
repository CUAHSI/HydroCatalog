<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Services.aspx.cs" Inherits="services" %>

<%@ Register Src="HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CUAHSI HIS Central</title>

</head>

<body >
    <form id="form1" runat="server">
       <uc1:HeaderControl ID="HeaderControl1" runat="server" />
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" Style="z-index: 102;
            left: 28px; position: absolute; top: 170px" Text="All Registered Data Services" Width="416px"></asp:Label>
   
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CentralHISConnectionString %>"
            SelectCommand="SELECT NetworkID, username, NetworkName, ServiceWSDL, ContactName, Organization, website, IsPublic FROM HISNetworks WHERE (IsPublic = 'True')">
        </asp:SqlDataSource>
        <div class="mainblock">
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
            CellPadding="4" DataKeyNames="NetworkID" DataSourceID="SqlDataSource1" GridLines="None"
             Style="z-index: 100;
            left: 0px; position: absolute; top: 200px" OnRowCommand="GridView1_RowCommand" ForeColor="#333333" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
            <Columns>
                <asp:CommandField SelectText="Details" ShowSelectButton="True" />
                <asp:BoundField DataField="NetworkName" HeaderText="Name" SortExpression="NetworkName" />
                <asp:BoundField DataField="ServiceWSDL" HeaderText="WSDL" SortExpression="ServiceWSDL" />
                <asp:BoundField DataField="ContactName" HeaderText="Contact" SortExpression="ContactName" />
                <asp:HyperLinkField DataNavigateUrlFields="website" DataTextField="Organization"
                    HeaderText="Organization" SortExpression="Organization" />
            </Columns>
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="LightSteelBlue" Font-Bold="True" ForeColor="Black" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
        </asp:GridView>
        &nbsp; &nbsp;&nbsp;


             </div>
     

    </form>
</body>
</html>
