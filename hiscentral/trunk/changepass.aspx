<%@ Page Language="C#" AutoEventWireup="true" CodeFile="changepass.aspx.cs" Inherits="changepassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CUAHSI HIS Central</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ChangePassword ID="ChangePassword1" runat="server" BackColor="#E3EAEB" BorderColor="#E6E2D8"
            BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana"
            Font-Size="0.8em" Style="z-index: 100; left: 48px; position: absolute; top: 181px">
            <CancelButtonStyle BackColor="White" BorderColor="#C5BBAF" BorderStyle="Solid" BorderWidth="1px"
                Font-Names="Verdana" Font-Size="0.8em" ForeColor="#1C5E55" />
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            <PasswordHintStyle Font-Italic="True" ForeColor="#1C5E55" />
            <ChangePasswordButtonStyle BackColor="White" BorderColor="#C5BBAF" BorderStyle="Solid"
                BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#1C5E55" />
            <ContinueButtonStyle BackColor="White" BorderColor="#C5BBAF" BorderStyle="Solid"
                BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#1C5E55" />
            <TitleTextStyle BackColor="#1C5E55" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
            <TextBoxStyle Font-Size="0.8em" />
        </asp:ChangePassword>
      <img src="images/masthead.jpg" style="z-index: 101; left: 0px; position: absolute;
        top: 0px" />
    
    </div>
    </form>
</body>
</html>
