<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ontology.aspx.cs" Inherits="admin_Ontology" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:TreeView ID="TreeView1" runat="server" ImageSet="Simple">
      </asp:TreeView>
      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CentralHISConnectionString %>"
        SelectCommand="SELECT * FROM [ConceptTree]"></asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
