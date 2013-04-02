<%@ Page Language="C#" AutoEventWireup="true" Inherits="seriesinfo" Codebehind="seriesinfo.aspx.cs" %>

<%@ Register Src="HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CentralHISConnectionString %>"
        SelectCommand="SELECT * FROM [SeriesCatalog] WHERE ([SiteID] = @SiteID)">
        <SelectParameters>
          <asp:SessionParameter Name="SiteID" SessionField="SiteID" Type="Int32" />
        </SelectParameters>
      </asp:SqlDataSource>
    
    </div>
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1"
        Style="z-index: 100; left: 23px; position: absolute; top: 276px" CellPadding="4" ForeColor="#333333" GridLines="None">
        <Columns>
          <asp:BoundField DataField="SiteCode" HeaderText="SiteCode" SortExpression="SiteCode" />
          <asp:BoundField DataField="SiteName" HeaderText="SiteName" SortExpression="SiteName" />
          <asp:BoundField DataField="VariableCode" HeaderText="VariableCode" SortExpression="VariableCode" />
          <asp:BoundField DataField="VariableName" HeaderText="VariableName" SortExpression="VariableName" />
          <asp:BoundField DataField="VariableUnitsID" HeaderText="VariableUnitsID" SortExpression="VariableUnitsID" />
          <asp:BoundField DataField="VariableUnitsName" HeaderText="VariableUnitsName" SortExpression="VariableUnitsName" />
          <asp:BoundField DataField="SampleMedium" HeaderText="SampleMedium" SortExpression="SampleMedium" />
          <asp:BoundField DataField="ValueType" HeaderText="ValueType" SortExpression="ValueType" />
          <asp:BoundField DataField="BeginDateTime" HeaderText="BeginDateTime" SortExpression="BeginDateTime" />
          <asp:BoundField DataField="EndDateTime" HeaderText="EndDateTime" SortExpression="EndDateTime" />
          <asp:BoundField DataField="Valuecount" HeaderText="Valuecount" SortExpression="Valuecount" />
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
      </asp:GridView>
      &nbsp;
      <uc1:HeaderControl ID="HeaderControl1" runat="server" />
    </form>
</body>
</html>
