<%@ Page Language="C#" AutoEventWireup="true" Inherits="Variables" Codebehind="Variables.aspx.cs" %>

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
        SelectCommand="SELECT * FROM [Variables] WHERE ([networkId] = @networkId)">
        <SelectParameters>
          <asp:SessionParameter Name="networkId" SessionField="NetworkID" Type="Int32" />
        </SelectParameters>
      </asp:SqlDataSource>
    
    </div>
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="VariableID"
        DataSourceID="SqlDataSource1" Style="z-index: 100; left: 9px; position: absolute;
        top: 179px" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" PageSize="20">
        <Columns>
          <asp:BoundField DataField="AltVariableName" HeaderText="Variable Name" SortExpression="AltVariableName" />
          <asp:BoundField DataField="AltVariableCode" HeaderText="VariableCode" SortExpression="AltVariableCode" />
          <asp:BoundField DataField="AltUnits" HeaderText="Units" SortExpression="AltUnits" />
          <asp:BoundField DataField="ValueType" HeaderText="ValueType" SortExpression="ValueType" />
          <asp:BoundField DataField="DataType" HeaderText="DataType" SortExpression="DataType" />
          <asp:BoundField DataField="SampleMedium" HeaderText="SampleMedium" SortExpression="SampleMedium" />
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
      </asp:GridView>
      <uc1:HeaderControl ID="HeaderControl1" runat="server" />
      <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Style="z-index: 102;
        left: 15px; color: blue; position: absolute; top: 149px; background-color: transparent"
        Text="Map Variables" Width="117px" />
    </form>
</body>
</html>
