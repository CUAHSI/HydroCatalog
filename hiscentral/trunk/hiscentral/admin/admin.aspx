<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="admin_harvesting" %>

<%@ Register Src="HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc2" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
  <link href="../styles/his.css" rel="stylesheet" type="text/css" />
  <link href="../styles/his.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    
    <div>
      &nbsp;<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CentralHISConnectionString %>"
            SelectCommand="SELECT [NetworkID], [username], [NetworkName], [ServiceWSDL], [Organization], [IsPublic], [LastHarvested], [FrequentUpdates], [CreatedDate], [ProjectStatus], [NetworkVocab], [IsApproved], [ValueCount], [VariableCount], [SiteCount], [ServiceStatus] FROM [HISNetworks] where username != 'delete_me' ORDER BY [NetworkID]">
        </asp:SqlDataSource>
      <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" Style="z-index: 100;
        left: 79px; position: absolute; top: 179px" Text="All Registered WaterOneFlow Web Services"
        Width="416px"></asp:Label>
      <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
        CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333"
        GridLines="None" OnRowCommand="GridView1_RowCommand"
        Style="z-index: 101; left: 0px; position: absolute; top: 222px; width: 100%;" Height="171px" Width="626px" DataKeyNames="NetworkID" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Font-Size="12px">
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <Columns>
          <asp:BoundField DataField="NetworkID" HeaderText="ID" InsertVisible="False" SortExpression="NetworkID" />
          <asp:BoundField DataField="NetworkName" HeaderText="NetworkName" SortExpression="NetworkName" />
          <asp:BoundField DataField="ServiceWSDL" HeaderText="WSDL" SortExpression="ServiceWSDL" DataFormatString="&lt;a href={0}&gt;wsdl&lt;/a&gt;" HtmlEncode="False" />
          <asp:BoundField DataField="username" HeaderText="Owner" SortExpression="username" />
          <asp:CheckBoxField DataField="IsPublic" HeaderText="IsPublic" SortExpression="IsPublic" />
          <asp:CheckBoxField DataField="FrequentUpdates" HeaderText="Freq" SortExpression="FrequentUpdates" />
          <asp:CheckBoxField DataField="IsApproved" HeaderText="IsApproved" SortExpression="IsApproved" />
          <asp:BoundField DataField="LastHarvested" HeaderText="LastHarvested" SortExpression="LastHarvested" />
          <asp:BoundField DataField="ValueCount" HeaderText="Values" SortExpression="ValueCount" />
          <asp:BoundField DataField="VariableCount" HeaderText="Variables" SortExpression="VariableCount" />
          <asp:BoundField DataField="SiteCount" HeaderText="Sites" SortExpression="SiteCount" />
          <asp:ButtonField CommandName="Details" Text="Details" />
          <asp:ButtonField CommandName="Delete" Text="Delete" />
        </Columns>
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="LightSteelBlue" Font-Bold="True" ForeColor="Black" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <EditRowStyle BackColor="#999999" />
      </asp:GridView>
      &nbsp;
      <uc2:HeaderControl ID="HeaderControl1" runat="server" />
      <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" ForeColor="#0000C0"
        Height="19px" NavigateUrl="http://river.sdsc.edu/ssosite" Style="z-index: 102;
        left: 568px; position: absolute; top: 163px" Width="136px">Manage Users</asp:HyperLink>
      <asp:HyperLink ID="HyperLink3" runat="server" Font-Bold="True" ForeColor="#0000C0"
        Height="19px" NavigateUrl="mailform.aspx" Style="z-index: 103; left: 716px; position: absolute;
        top: 165px" Width="65px">Email</asp:HyperLink>
      <asp:HyperLink ID="HyperLink6" runat="server" Font-Bold="True" ForeColor="#0000C0"
        Height="19px" NavigateUrl="~/admin/unmappedvariables.aspx" Style="z-index: 105;
        left: 789px; position: absolute; top: 154px" Width="136px">Unmapped Variables</asp:HyperLink>
    
    </div>
    </form>
</body>
</html>
