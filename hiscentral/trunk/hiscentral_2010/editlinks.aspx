<%@ Page Language="C#" AutoEventWireup="true" Inherits="editlinks" Codebehind="editlinks.aspx.cs" %>

<%@ Register Src="HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>HIS Central</title>
  <link href="styles/his.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <uc1:HeaderControl ID="HeaderControl1" runat="server" />
    <div>

        <asp:Panel ID="Panel1" runat="server" BackColor="Silver" Height="118px" Style="z-index: 101;
            left: 37px; position: absolute; top: 171px" Width="559px">
            <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Style="z-index: 100;
                left: 489px; position: absolute; top: 87px" Text="Insert" />
            <asp:TextBox ID="txtURL" runat="server" Style="z-index: 101; left: 69px; position: absolute;
                top: 60px" Width="465px"></asp:TextBox>
            :
            <asp:Label ID="Label1" runat="server" Style="z-index: 102; left: 29px; position: absolute;
                top: 64px" Text="URL" ></asp:Label>
            <asp:TextBox ID="txtDesc" runat="server" Style="z-index: 103; left: 69px; position: absolute;
                top: 31px" Width="466px"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Style="z-index: 104; left: 12px; position: absolute;
                top: 41px" Text="Citation:" ></asp:Label>
   
            <asp:Label ID="Label4" runat="server" Font-Bold="True"
                Style="z-index: 108; left: 6px; position: absolute; top: 4px" Text="Add Document"></asp:Label>
        </asp:Panel>
 
      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CentralHISConnectionString %>"
        SelectCommand="SELECT NetworkID, LinkText, LinkURL, LinkID FROM Links WHERE (NetworkID = @NetworkID)" InsertCommand="INSERT INTO Links(LinkText, LinkURL, NetworkID) VALUES (@text, @url, @NetworkID)" UpdateCommand="UPDATE Links SET LinkText = @text, LinkURL = @url WHERE (LinkID = @linkID)" DeleteCommand="DELETE FROM Links WHERE (LinkID = @linkid)">
        <SelectParameters>
          <asp:SessionParameter Name="NetworkID" SessionField="NetworkID" Type="Int64" />
        </SelectParameters>
        <UpdateParameters>
          <asp:Parameter Name="text" />
          <asp:Parameter Name="url" />
          <asp:Parameter Name="linkID" />
        </UpdateParameters>
        <InsertParameters>
          <asp:Parameter Name="text" />
          <asp:Parameter Name="url" />
          <asp:Parameter Name="NetworkID" />
        </InsertParameters>
        <DeleteParameters>
          <asp:Parameter Name="linkid" />
        </DeleteParameters>
      </asp:SqlDataSource>
    
    </div>
      <asp:GridView ID="GridView1" runat="server" Style="z-index: 104; left: 36px; position: absolute;
        top: 294px" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Width="734px" DataKeyNames="LinkID" OnRowCommand="GridView1_RowCommand">
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
          <asp:CommandField ShowEditButton="True" />
          <asp:BoundField DataField="LinkText" HeaderText="Citation" SortExpression="LinkText" />
          <asp:BoundField DataField="LinkURL" HeaderText="URL" SortExpression="LinkURL" />
          <asp:CommandField ShowDeleteButton="True" />
        </Columns>
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
      </asp:GridView>
      
    </form>
</body>
</html>
