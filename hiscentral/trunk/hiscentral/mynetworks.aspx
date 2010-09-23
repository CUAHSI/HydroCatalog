<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mynetworks.aspx.cs" Inherits="mynetworks" %>

<%@ Register Src="HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CUAHSI HIS Central</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True"
            AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333"
            GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" Style="z-index: 100;
            left: 0px; position: absolute; top: 198px; width: 100%;" DataKeyNames="NetworkID" OnRowCommand="GridView1_RowCommand">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:CommandField SelectText="Details" ShowSelectButton="True" />
                <asp:ButtonField Text="Test" />
                <asp:BoundField DataField="NetworkName" HeaderText="NetworkName" SortExpression="NetworkName" />
                <asp:BoundField DataField="ServiceWSDL" HeaderText="ServiceWSDL" SortExpression="ServiceWSDL" />
                <asp:BoundField DataField="ContactName" HeaderText="ContactName" SortExpression="ContactName" />
                <asp:HyperLinkField DataNavigateUrlFields="website" DataTextField="Organization"
                    HeaderText="Organization" />
            </Columns>
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <EditRowStyle BackColor="#999999" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="LightSteelBlue" Font-Bold="True" ForeColor="Black" CssClass="H3" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CentralHISConnectionString %>"
            SelectCommand="SELECT [NetworkID], [username], [NetworkName], [ServiceWSDL], [ContactName], [Organization], [website] FROM [HISNetworks]" OnInit="SqlDataSource1_Init" OnSelecting="SqlDataSource1_Selecting" 
            DeleteCommand="DELETE FROM HISNetworks WHERE [NetworkID]= @NetworkID ">
        </asp:SqlDataSource>
        <uc1:HeaderControl ID="HeaderControl1" runat="server" />
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" Style="z-index: 102;
            left: 22px; position: absolute; top: 160px" Text="My Services:" Width="173px"></asp:Label>
    
    </div>
    </form>
</body>
</html>
