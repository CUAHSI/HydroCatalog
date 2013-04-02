<%@ Page Language="C#" AutoEventWireup="true" Inherits="mailform" Codebehind="mailform.aspx.cs" %>

<%@ Register Src="HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc2" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
  <link href="../styles/his.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
      &nbsp;</div>
      <asp:TextBox ID="txtMessage" runat="server" Height="205px" Style="z-index: 100; left: 78px;
        position: absolute; top: 291px" TextMode="MultiLine" Width="356px"></asp:TextBox>
      <asp:Button ID="btnSend" runat="server" OnClick="btnSend_Click" Style="z-index: 101;
        left: 388px; position: absolute; top: 525px" Text="Send" Width="52px" />
      <asp:Label ID="Label1" runat="server" Style="z-index: 102; left: 83px; position: absolute;
        top: 265px" Text="Message:"></asp:Label>
      <asp:Label ID="Label3" runat="server" Style="z-index: 103; left: 81px; position: absolute;
        top: 209px" Text="Subject:"></asp:Label>
      <asp:Label ID="Label2" runat="server" Style="z-index: 104; left: 458px; position: absolute;
        top: 211px" Text="Recipients:"></asp:Label>
      <asp:TextBox ID="txtSubject" runat="server" Style="z-index: 105; left: 80px; position: absolute;
        top: 230px" Width="346px"></asp:TextBox>
      <asp:ListBox ID="lbxUsers" runat="server" Height="247px" SelectionMode="Multiple"
        Style="z-index: 106; left: 462px; position: absolute; top: 238px" Width="343px">
      </asp:ListBox>
      <asp:Label ID="lblexception" runat="server" Style="z-index: 108; left: 78px; position: absolute;
        top: 564px"></asp:Label>
      <uc2:HeaderControl ID="HeaderControl1" runat="server" />
    </form>
</body>
</html>
