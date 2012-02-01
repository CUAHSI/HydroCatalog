<%@ Page Language="C#" AutoEventWireup="true" Title="CUAHSI HIS | Master Controlled Vocabulary Registry | Administrator | ODM 1.0" CodeFile="manageCV10.aspx.cs" Inherits="manage_admin_manageCV" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size:12px;font-family:Arial;">
    <h2>ODM 1.0 Controlled Vocabularies</h2>
        
    <div runat="server" id="EditContainer">
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" 
                DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
                AutoGenerateColumns="False" DataKeyNames="id">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                 <asp:CommandField ShowDeleteButton="False" ShowEditButton="True" /> 
                 <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                              <asp:LinkButton ID="LinkButtonJava2" runat="server" CausesValidation="false" 
                                CommandName="Delete" Text="Delete" onclientclick="return confirm('Are you sure you want to delete this user?')" ></asp:LinkButton>
                        </ItemTemplate>
                   </asp:TemplateField>
                 <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="True" 
                    SortExpression="id" />
                 <asp:TemplateField HeaderText="Name" SortExpression="name">
                    <EditItemTemplate>
                        <asp:Label ID="name1" runat="server" Text='<%# Eval("name") %>'></asp:Label>  </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="name2" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Description" SortExpression="description">
                    <EditItemTemplate>
                        <asp:TextBox ID="nameBox" Text='<%# Bind("description") %>' Width="330px" TextMode="MultiLine" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="name" runat="server" Text='<%# Bind("description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>                     
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <br />
        <asp:LinkButton ID="AddButton" runat="server" onclick="AddButton_Click">Add a new entry</asp:LinkButton>        
    </div>
    
    <div runat="server" id="AddContainer" visible="false">
        <asp:DetailsView ID="NewEntry" runat="server" Height="153px" Width="229px" 
            CellPadding="4" DataSourceID="SqlDataSource1" DefaultMode="Insert" 
            ForeColor="#333333" GridLines="None" onitemcommand="NewEntry_ItemCommand" 
            oniteminserted="NewEntry_ItemInserted" AutoGenerateRows="False">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
            <RowStyle BackColor="#EFF3FB" />
            <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <Fields>                
                <asp:TemplateField HeaderText="ID" SortExpression="id">
                    <EditItemTemplate>
                        <asp:Label ID="id1" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="id2" runat="server" Text='<%# Bind("id") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="ID cannot be blank" ControlToValidate="id2"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="id2" MinimumValue="0" MaximumValue="9999999999" ErrorMessage="ID value not valid"></asp:RangeValidator>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="id3" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Name" DataField="name" />
                <asp:TemplateField HeaderText="Description" SortExpression="description">
                    <EditItemTemplate>
                        <asp:Label ID="description1" runat="server" Text='<%# Eval("description") %>'></asp:Label>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="description2" runat="server" TextMode="MultiLine" Width="400px" Text='<%# Bind("description") %>'></asp:TextBox>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="description3" runat="server" Text='<%# Bind("description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowInsertButton="True" />
            </Fields>
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:DetailsView>
    
    </div>
        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:CUAHSIWebsiteConnectionString %>" 
            DeleteCommand="DELETE FROM [cv10] WHERE [id] = @id" 
            InsertCommand="INSERT INTO [cv10] ([id], [name], [description]) VALUES (@id, @name, @description)" 
            SelectCommand="SELECT [id], [name], [description] FROM [cv10] ORDER BY [name] " 
            UpdateCommand="UPDATE [cv10] SET [description] = @description WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="description" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="id" Type="Int32" />
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="description" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
    
    
    <asp:Button ID="FinishButton" runat="server" Text="Done" OnClientClick="self.close()" style="position:absolute;bottom:10px;right:15px;" />
    
    </div>
    </form>
    
</body>
</html>
