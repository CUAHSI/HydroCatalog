<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editcontacts.aspx.cs" Inherits="editcontacts" %>

<%@ Register Src="HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>HIS Central</title>
  <link href="styles/his.css" rel="stylesheet" type="text/css" />
  <link href="styles/his.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <uc1:HeaderControl ID="HeaderControl1" runat="server" />
    <div>

        <asp:Panel ID="Panel1" runat="server" BackColor="Silver" Height="205px" Style="z-index: 101;
            left: 38px; position: absolute; top: 171px" Width="728px">
            <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Style="z-index: 100;
                left: 557px; position: absolute; top: 166px" Text="Insert" />
            <asp:TextBox ID="txtName" runat="server" Style="z-index: 101; left: 67px; position: absolute;
                top: 31px" Width="472px"></asp:TextBox>
            :
            <asp:Label ID="Label1" runat="server" Style="z-index: 102; left: 22px; position: absolute;
                top: 34px" Text="Name" ></asp:Label>
            <asp:TextBox ID="txtTitle" runat="server" Style="z-index: 103; left: 67px; position: absolute;
                top: 57px" Width="470px"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Style="z-index: 104; left: 22px; position: absolute;
                top: 60px" Text="Title:" ></asp:Label>
          <asp:Label ID="Label3" runat="server" Style="z-index: 105; left: 10px; position: absolute;
            top: 132px" Text="Address:"></asp:Label>
          <asp:Label ID="Label5" runat="server" Style="z-index: 106; left: 302px; position: absolute;
            top: 88px" Text="Email:"></asp:Label>
          <asp:Label ID="Label6" runat="server" Style="z-index: 107; left: 20px; position: absolute;
            top: 92px" Text="Phone"></asp:Label>
   
            <asp:Label ID="Label4" runat="server" Font-Bold="True"
                Style="z-index: 108; left: 79px; position: absolute; top: 8px" Text="Add Contact"></asp:Label>
          <asp:TextBox ID="txtPhone" runat="server" Style="z-index: 109; left: 67px; position: absolute;
            top: 84px"></asp:TextBox>
          <asp:TextBox ID="txtEmail" runat="server" Style="z-index: 110; left: 348px; position: absolute;
            top: 83px" Width="189px"></asp:TextBox>
          <asp:TextBox ID="txtAddress" runat="server" Height="60px" Style="z-index: 111; left: 70px;
            position: absolute; top: 127px" TextMode="MultiLine" Width="464px"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
            ErrorMessage="Name Required" Style="z-index: 112; left: 554px; position: absolute;
            top: 37px"></asp:RequiredFieldValidator>
          <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
            ErrorMessage="Invalid Email" Style="z-index: 114; left: 554px; position: absolute;
            top: 87px" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </asp:Panel>
 
      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CentralHISConnectionString %>"
        SelectCommand="SELECT contactid, NetworkID, Name, Phone, Email, Address, Title FROM Contacts WHERE (NetworkID = @NetworkID)" InsertCommand="INSERT INTO Contacts(NetworkID, Name, Phone, Email, Address, Title) VALUES (@NetworkID, @name, @phone, @email, @address, @title)" UpdateCommand="UPDATE Contacts SET Name = @name, Phone = @phone, Email = @email, Address = @address, Title = @title WHERE (contactid = @contactid)" DeleteCommand="DELETE FROM contacts WHERE contactid= @contactid">
        <SelectParameters>
          <asp:SessionParameter Name="NetworkID" SessionField="NetworkID" Type="Int64" />
        </SelectParameters>
        <UpdateParameters>
          <asp:Parameter Name="name" />
          <asp:Parameter Name="phone" />
          <asp:Parameter Name="email" />
          <asp:Parameter Name="address" />
          <asp:Parameter Name="title" />
          <asp:Parameter Name="contactid" />
        </UpdateParameters>
        <InsertParameters>
          <asp:Parameter Name="NetworkID" />
          <asp:Parameter Name="name" />
          <asp:Parameter Name="phone" />
          <asp:Parameter Name="email" />
          <asp:Parameter Name="address" />
          <asp:Parameter Name="title" />
        </InsertParameters>
        <DeleteParameters>
          <asp:Parameter Name="contactid" />
        </DeleteParameters>
      </asp:SqlDataSource>
    
    </div>
      <asp:GridView ID="GridView1" runat="server" Style="z-index: 104; left: 41px; position: absolute;
        top: 394px" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Width="734px" DataKeyNames="contactid" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
          <asp:CommandField ShowEditButton="True" />
          <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
          <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
          <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
          <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
          <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
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
