<%@ Page Language="C#" AutoEventWireup="true" Inherits="admin_Harvest" Codebehind="Harvest.aspx.cs" %>

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
      &nbsp;
      <asp:Button ID="Button1" runat="server" Text="Begin Harvest" style="z-index: 100; left: 187px; position: absolute; top: 215px" Height="36px" OnClick="Button1_Click" Width="129px" />
      &nbsp;
      <uc2:HeaderControl ID="HeaderControl1" runat="server" />
      <asp:HyperLink ID="HyperLink1" runat="server" Style="z-index: 102; left: 203px; position: absolute;
        top: 284px" Target="_blank" Visible="False">Harvest log</asp:HyperLink>
      
    </div>
    </form>
</body>
</html>
