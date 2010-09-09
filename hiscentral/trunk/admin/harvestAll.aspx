<%@ Page Language="C#" AutoEventWireup="true" CodeFile="harvestAll.aspx.cs" Inherits="HarvestAll" %>

<%@ Register Src="HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc2" %>

<%@ Register Src="../HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc1" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
  <link href="../styles/his.css" rel="stylesheet" type="text/css" />
  <link href="../styles/his.css" rel="stylesheet" type="text/css" />
  <link href="../styles/his.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
      &nbsp;
      <asp:Button ID="Button1" runat="server" Text="Begin Harvest" style="z-index: 100; left: 66px; position: absolute; top: 199px" Height="36px" OnClick="Button1_Click" Width="129px" />
      &nbsp;
      <uc2:HeaderControl ID="HeaderControl1" runat="server" />
      &nbsp;
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1"
        Height="120px" Style="z-index: 101; left: 69px; position: absolute; top: 258px"
        Width="458px">
        <Columns>
          <asp:BoundField DataField="NetworkID" HeaderText="NetworkID" InsertVisible="False"
            ReadOnly="True" SortExpression="NetworkID" />
          <asp:BoundField DataField="NetworkName" HeaderText="NetworkName" SortExpression="NetworkName" />
          <asp:BoundField DataField="NetworkTitle" HeaderText="NetworkTitle" SortExpression="NetworkTitle" />
          <asp:BoundField DataField="LastHarvested" HeaderText="LastHarvested" SortExpression="LastHarvested" />
          <asp:CheckBoxField DataField="IsApproved" HeaderText="IsApproved" SortExpression="IsApproved" />
          <asp:CheckBoxField DataField="IsPublic" HeaderText="IsPublic" SortExpression="IsPublic" />
          <asp:CheckBoxField DataField="FrequentUpdates" HeaderText="FrequentUpdates" SortExpression="FrequentUpdates" />
        </Columns>
      </asp:GridView>
      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CentralHISConnectionString %>"
        SelectCommand="SELECT NetworkID, NetworkName, NetworkTitle, LastHarvested, IsApproved, IsPublic, FrequentUpdates FROM HISNetworks WHERE (FrequentUpdates = 1) AND (IsPublic = 1)">
      </asp:SqlDataSource>
      
    </div>
      <asp:Label ID="lblCommand" runat="server" Style="z-index: 103; left: 231px; position: absolute;
        top: 185px"></asp:Label>
    </form>
</body>
</html>
