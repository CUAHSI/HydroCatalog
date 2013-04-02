<%@ Page Language="C#" AutoEventWireup="true" Inherits="editdesc" Codebehind="editdesc.aspx.cs" %>

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

        <asp:Panel ID="Panel1" runat="server" BackColor="Silver" Height="243px" Style="z-index: 101;
            left: 38px; position: absolute; top: 171px" Width="709px">
            <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Style="z-index: 100;
                left: 638px; position: absolute; top: 205px" Text="Insert" />
            <asp:TextBox ID="txtDesc" runat="server" Style="z-index: 101; left: 25px; position: absolute;
                top: 76px" Width="601px" Height="147px" TextMode="MultiLine"></asp:TextBox>
            :
            <asp:Label ID="Label1" runat="server" Style="z-index: 102; left: 23px; position: absolute;
                top: 62px" Text="Description Text" ></asp:Label>
            <asp:TextBox ID="txtTitle" runat="server" Style="z-index: 103; left: 148px; position: absolute;
                top: 27px" Width="293px"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Style="z-index: 104; left: 28px; position: absolute;
                top: 30px" Text="Description Title" ></asp:Label>
   
            <asp:Label ID="Label4" runat="server" Font-Bold="True"
                Style="z-index: 108; left: 6px; position: absolute; top: 4px" Text="Add Description"></asp:Label>
        </asp:Panel>
 
      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CentralHISConnectionString %>"
        SelectCommand="SELECT NetworkID, DescTitle, DescText, DescID FROM NetworkDesc WHERE (NetworkID = @NetworkID)" InsertCommand="INSERT INTO NetworkDesc(DescTitle, descText, NetworkID) VALUES (@title, @text, @NetworkID)" UpdateCommand="UPDATE NetworkDesc SET descText = @text, descTitle = @title WHERE (descID = @descID)" DeleteCommand="DELETE FROM networkDesc WHERE (descID = @descid)">
        <SelectParameters>
          <asp:SessionParameter Name="NetworkID" SessionField="NetworkID" Type="Int64" />
        </SelectParameters>
        <UpdateParameters>
          <asp:Parameter Name="text" />
          <asp:Parameter Name="title" />
          <asp:Parameter Name="descID" />
        </UpdateParameters>
        <InsertParameters>
          <asp:Parameter Name="title" />
          <asp:Parameter Name="text" />
          <asp:Parameter Name="NetworkID" />
        </InsertParameters>
        <DeleteParameters>
          <asp:Parameter Name="descid" />
        </DeleteParameters>
      </asp:SqlDataSource>
    
    </div>
      <asp:GridView ID="GridView1" runat="server" Style="z-index: 104; left: 41px; position: absolute;
        top: 424px" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Width="734px" DataKeyNames="DescID" OnRowCommand="GridView1_RowCommand">
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
          <asp:CommandField ShowEditButton="True" />
          <asp:BoundField DataField="DescTitle" HeaderText="Title" SortExpression="DescTitle" />
          <asp:BoundField DataField="DescText" HeaderText="Text" SortExpression="DescText" />
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
