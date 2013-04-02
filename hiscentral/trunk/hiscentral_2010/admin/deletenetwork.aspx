<%@ Page Language="C#" AutoEventWireup="true" Inherits="admin_deletenetwork" Codebehind="deletenetwork.aspx.cs" %>

<%@ Register Src="HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc1" %>

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
      <uc1:HeaderControl ID="HeaderControl1" runat="server" />
      <asp:Button ID="btnNo" runat="server" OnClick="btnNo_Click" Style="z-index: 100;
        left: 385px; position: absolute; top: 422px" Text="Cancel" Width="200px" />
      <asp:Button ID="btnYes" runat="server" OnClick="btnYes_Click" Style="z-index: 101;
        left: 177px; position: absolute; top: 277px" Text="Yes, delete the network record and all harvested data" Width="406px" Height="34px" />
      <asp:Label ID="Label1" runat="server" Style="z-index: 102; left: 65px; position: absolute;
        top: 218px" Text="Are you sure you want to delete this network?"></asp:Label>
      &nbsp;
      <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Style="z-index: 105;
        left: 179px; position: absolute; top: 328px" Text="Delete harvested data only"
        Width="403px" Height="39px" />
    
    </div>
    </form>
</body>
</html>
