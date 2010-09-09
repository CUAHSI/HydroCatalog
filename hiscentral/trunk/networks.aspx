<%@ Page Language="C#" AutoEventWireup="true" CodeFile="networks.aspx.cs" Inherits="networks" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333"
            GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Style="z-index: 100;
            left: 119px; position: absolute; top: 161px" DataKeyNames="NetworkID">
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:CommandField SelectText="Details" ShowSelectButton="True" />
                <asp:BoundField DataField="NetworkName" HeaderText="NetworkName" SortExpression="NetworkName" />
                <asp:BoundField DataField="ServiceWSDL" HeaderText="ServiceWSDL" SortExpression="ServiceWSDL" />
                <asp:BoundField DataField="ContactName" HeaderText="ContactName" SortExpression="ContactName" />
                <asp:HyperLinkField DataNavigateUrlFields="website" DataTextField="Organization"
                    HeaderText="Organization" />
            </Columns>
            <RowStyle BackColor="#E3EAEB" />
            <EditRowStyle BackColor="#7C6F57" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT [NetworkID], [username], [NetworkName], [ServiceWSDL], [ContactName], [Organization], [website] FROM [HISNetworks]">
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
