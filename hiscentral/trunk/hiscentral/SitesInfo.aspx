<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SitesInfo.aspx.cs" Inherits="SitesInfo" %>

<%@ Register Src="HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CUAHSI HIS Central</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CentralHISConnectionString %>"
        
            SelectCommand="SELECT SiteCode, SiteName, SiteID, Latitude, Longitude FROM Sites WHERE Networkid = @Networkid">
        <SelectParameters>
            <asp:SessionParameter Name="Networkid" SessionField="Networkid" />      
        </SelectParameters>
      </asp:SqlDataSource>
      
    
    </div>
      <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        DataKeyNames="SiteID" DataSourceID="SqlDataSource1" Style="z-index: 100; left: 59px;
        position: absolute; top: 228px" CellPadding="4" ForeColor="#333333" GridLines="None" Height="338px" Width="804px" OnRowCommand="GridView1_RowCommand" PageSize="25">
        <Columns>
          <asp:BoundField DataField="SiteName" HeaderText="SiteName" SortExpression="SiteName" />
          <asp:BoundField DataField="SiteCode" HeaderText="SiteCode" SortExpression="SiteCode" />
          <asp:BoundField DataField="Latitude" HeaderText="Latitude" SortExpression="Latitude" >
            <ItemStyle Font-Size="Smaller" />
          </asp:BoundField>
          <asp:BoundField DataField="Longitude" HeaderText="Longitude" SortExpression="Longitude" >
            <ItemStyle Font-Size="Smaller" />
          </asp:BoundField>
          <asp:ButtonField Text="Series Catalog" CommandName="siteinfo" />
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
      </asp:GridView>
      &nbsp;&nbsp;
      <uc1:HeaderControl ID="HeaderControl1" runat="server" />
    </form>
</body>
</html>
