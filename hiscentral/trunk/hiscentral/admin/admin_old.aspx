<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_old.aspx.cs" Inherits="admin" %>

<%@ Register Src="HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc2" %>

<%@ Register Src="../HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
  <link href="../styles/his.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;
        <asp:HyperLink ID="HyperLink1" runat="server" Style="z-index: 100; left: 65px; position: absolute;
            top: 190px" Font-Bold="True" ForeColor="#0000C0" Height="19px" NavigateUrl="http://river.sdsc.edu/ssosite" Width="136px">Manage Users</asp:HyperLink>
        <asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="True" ForeColor="#0000C0"
            Height="19px" NavigateUrl="netowner.aspx" Style="z-index: 101; left: 321px; position: absolute;
            top: 192px" Width="168px">Change Network Owners</asp:HyperLink>
        <asp:HyperLink ID="HyperLink3" runat="server" Font-Bold="True" ForeColor="#0000C0"
            Height="19px" NavigateUrl="mailform.aspx" Style="z-index: 102; left: 212px; position: absolute;
            top: 265px" Width="136px">Email</asp:HyperLink>
      <asp:HyperLink ID="HyperLink4" runat="server" Font-Bold="True" ForeColor="#0000C0"
        Height="19px" NavigateUrl="harvesting.aspx" Style="z-index: 103; left: 60px; position: absolute;
        top: 323px" Width="136px">Harvesting</asp:HyperLink>
      <asp:HyperLink ID="HyperLink5" runat="server" Font-Bold="True" ForeColor="#0000C0"
        Height="19px" NavigateUrl="taggeradmin.aspx" Style="z-index: 104; left: 264px; position: absolute;
        top: 379px" Width="136px">ApproveMappings</asp:HyperLink>
      <asp:HyperLink ID="HyperLink6" runat="server" Font-Bold="True" ForeColor="#0000C0"
        Height="19px" NavigateUrl="~/admin/unmappedvariables.aspx" Style="z-index: 106;
        left: 370px; position: absolute; top: 309px" Width="136px">Unmapped Variables</asp:HyperLink>
      <uc2:HeaderControl ID="HeaderControl1" runat="server" />
        
    </div>
    </form>
</body>
</html>
