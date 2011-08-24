<%@ Page Language="C#" AutoEventWireup="true" Inherits="admin_netwowner" Codebehind="netowner.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      &nbsp;
      <asp:DropDownList ID="ddlUsers" runat="server" Style="z-index: 100; left: 279px;
        position: absolute; top: 191px" Width="171px">
      </asp:DropDownList>
      <asp:Label ID="lblNetworkName" runat="server" Style="z-index: 101; left: 115px; position: absolute;
        top: 191px" Width="153px"></asp:Label>
      <asp:Button ID="btnUpdate" runat="server" Style="z-index: 103; left: 463px; position: absolute;
        top: 189px" Text="Update User" Width="115px" />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CentralHISConnectionString %>"
            SelectCommand="SELECT username, NetworkName WHERE (NetworkID = @NetworkID)"             
            UpdateCommand="UPDATE HISNetworks SET username= @UserName WHERE [NetworkID] = @NetworkID">
            <SelectParameters>
                <asp:SessionParameter Name="NetworkID" SessionField="NetworkID" Type="Int32" />      
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="NetworkName" />
                <asp:Parameter Name="UserName" />

                
                <asp:SessionParameter Name="NetworkID" SessionField="NetworkID" Type="Int32" />               
            </UpdateParameters>

        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
