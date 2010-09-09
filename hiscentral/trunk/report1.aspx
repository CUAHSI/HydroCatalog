<%@ Page Language="C#" AutoEventWireup="true" CodeFile="report1.aspx.cs" Inherits="report1" %>

<%@ Register src="HeaderControl.ascx" tagname="HeaderControl" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
 
    <div style="top:150px; position: absolute;">
    
    
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" 
        CellPadding="4" ForeColor="#333333" GridLines="None" 
            AutoGenerateColumns="False">
        <RowStyle BackColor="#EFF3FB" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:CentralHISConnectionString %>" 
        SelectCommand="sp_UnmappedVariablesByCount" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>
    <uc1:HeaderControl ID="HeaderControl1" runat="server" />
    </form>
</body>
</html>
