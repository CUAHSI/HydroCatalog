<%@ Page Language="C#" AutoEventWireup="true" Inherits="admin_unmappedvariables" Codebehind="unmappedvariables.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CentralHISConnectionString %>"
        SelectCommand="SELECT Variables.AltVariableCode, Variables.AltVariableName, Variables.VariableID, Variables.SampleMedium, Variables.networkId, HISNetworks.NetworkName FROM Variables INNER JOIN HISNetworks ON Variables.networkId = HISNetworks.NetworkID WHERE (Variables.VariableID NOT IN (SELECT VariableID FROM MappingsApproved))">
      </asp:SqlDataSource>
    
    </div>
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="VariableID"
        DataSourceID="SqlDataSource1" Style="z-index: 100; left: 83px; position: absolute;
        top: 234px">
        <Columns>
          <asp:BoundField DataField="NetworkName" HeaderText="NetworkName" SortExpression="NetworkName" />
          <asp:BoundField DataField="AltVariableName" HeaderText="AltVariableName" SortExpression="AltVariableName" />
          <asp:BoundField DataField="AltVariableCode" HeaderText="AltVariableCode" SortExpression="AltVariableCode" />
          <asp:BoundField DataField="VariableID" HeaderText="VariableID" ReadOnly="True" SortExpression="VariableID" />
          <asp:BoundField DataField="SampleMedium" HeaderText="SampleMedium" SortExpression="SampleMedium" />
          <asp:BoundField DataField="networkId" HeaderText="networkId" SortExpression="networkId" />
        </Columns>
      </asp:GridView>
    </form>
</body>
</html>
