<%@ Page Language="C#" AutoEventWireup="true" Inherits="RecoverPass" Codebehind="RecoverPass.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:PasswordRecovery ID="PasswordRecovery1" runat="server" Style="z-index: 100;
            left: 85px; position: absolute; top: 137px" OnSendingMail="PasswordRecovery1_SendingMail" OnVerifyingAnswer="PasswordRecovery1_VerifyingAnswer">
        </asp:PasswordRecovery>
      <asp:TextBox ID="txtUserName" runat="server" Style="z-index: 101; left: 139px; position: absolute;
        top: 281px"></asp:TextBox>
      <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Style="z-index: 102;
        left: 327px; position: absolute; top: 303px" Text="Button" />
      <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Style="z-index: 103;
        left: 330px; position: absolute; top: 359px" Text="Button" />
      <asp:TextBox ID="txtAnswer" runat="server" Style="z-index: 104; left: 136px; position: absolute;
        top: 336px"></asp:TextBox>
      <asp:Label ID="lblQuestion" runat="server" Style="z-index: 105; left: 133px; position: absolute;
        top: 313px"></asp:Label>
      <asp:Label ID="lblPassword" runat="server" Style="z-index: 107; left: 165px; position: absolute;
        top: 384px"></asp:Label>
    
    </div>
    </form>
</body>
</html>
