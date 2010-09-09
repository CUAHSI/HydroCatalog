<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Harvest.aspx.cs" Inherits="Harvest" %>

<%@ Register Src="HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      &nbsp;
      <asp:Button ID="Button1" runat="server" Text="Begin Harvest" style="z-index: 100; left: 195px; position: absolute; top: 276px" Height="51px" OnClick="Button1_Click" Width="172px" />
      <uc1:HeaderControl ID="HeaderControl1" runat="server" />
    </div>
    </form>
</body>
</html>
