<%@ Page Language="C#" AutoEventWireup="true" Inherits="profile" Codebehind="profile.aspx.cs" %>

<%@ Register Src="HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;</div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CentralHISConnectionString %>"
            SelectCommand="SELECT [website], [Organization], [phone], [email], [username], [userid] FROM [UserInfo]" DeleteCommand="DELETE FROM [UserInfo] WHERE [userid] = @userid" 
            InsertCommand="INSERT INTO [UserInfo] ([website], [Organization], [phone], [email], [username]) VALUES (@website, @Organization, @phone, @email, @username)" 
            UpdateCommand="UPDATE [UserInfo] SET [website] = @website, [Organization] = @Organization, [phone] = @phone, [email] = @email, [username] = @username WHERE [userid] = @userid">
            <SelectParameters>
             
                <asp:SessionParameter Name="NetworkID" SessionField="NetworkID" Type="Int32" />      
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="website" Type="String" />
                <asp:Parameter Name="Organization" Type="String" />
                <asp:Parameter Name="phone" Type="String" />
                <asp:Parameter Name="email" Type="String" />
                <asp:Parameter Name="username" Type="String" />
                <asp:Parameter Name="userid" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="website" Type="String" />
                <asp:Parameter Name="Organization" Type="String" />
                <asp:Parameter Name="phone" Type="String" />
                <asp:Parameter Name="email" Type="String" />
                <asp:Parameter Name="username" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
        <asp:FormView ID="FormView1" runat="server" DataSourceID="SqlDataSource1" Style="z-index: 100;
            left: 88px; position: absolute; top: 203px">
            <EditItemTemplate>
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Style="z-index: 111; left: 22px;
                    position: absolute; top: 52px" Text='<%# Eval("username") %>'></asp:Label>

                <asp:TextBox ID="phoneTextBox" runat="server" Style="z-index: 101; left: 158px; position: absolute;
                    top: 113px" Text='<%# Bind("phone") %>' Width="328px"></asp:TextBox>
                <asp:TextBox ID="OrganizationTextBox" runat="server" Style="z-index: 102; left: 158px;
                    position: absolute; top: 81px" Text='<%# Bind("Organization") %>' Width="328px"></asp:TextBox>
                <asp:TextBox ID="websiteTextBox" runat="server" Style="z-index: 103; left: 158px;
                    position: absolute; top: 179px" Text='<%# Bind("website") %>' Width="328px"></asp:TextBox>

                <asp:TextBox ID="emailTextBox" runat="server" Style="z-index: 104; left: 158px; position: absolute;
                    top: 145px" Text='<%# Bind("email") %>' Width="328px"></asp:TextBox>
    
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Style="z-index: 107; left: 22px;
                    position: absolute; top: 147px" Text="Email:" Width="118px"></asp:Label>
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Style="z-index: 108; left: 22px;
                    position: absolute; top: 182px" Text="Website:" Width="118px"></asp:Label>
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Style="z-index: 109; left: 22px;
                    position: absolute; top: 114px" Text="Phone:" Width="118px"></asp:Label>
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Style="z-index: 110; left: 22px;
                    position: absolute; top: 81px" Text="Organization:" Width="118px"></asp:Label>
                    
                <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                    Style="z-index: 105; left: 83px; position: absolute; top: 216px" Text="Cancel"></asp:LinkButton>
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                    Style="z-index: 106; left: 26px; position: absolute; top: 214px" Text="Update"></asp:LinkButton>
            </EditItemTemplate>
            <InsertItemTemplate>
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                    Text="Insert">
                </asp:LinkButton>
                <asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                    Text="Cancel">
                </asp:LinkButton>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Style="z-index: 111; left: 22px;
                    position: absolute; top: 52px" Text='<%# Eval("username") %>'></asp:Label>

                <asp:Label ID="phoneTextBox" runat="server" Style="z-index: 101; left: 158px; position: absolute;
                    top: 113px" Text='<%# Bind("phone") %>' Width="328px"></asp:Label>
                <asp:Label ID="OrganizationTextBox" runat="server" Style="z-index: 102; left: 158px;
                    position: absolute; top: 81px" Text='<%# Bind("Organization") %>' Width="328px"></asp:Label>
                <asp:Label ID="websiteTextBox" runat="server" Style="z-index: 103; left: 158px;
                    position: absolute; top: 179px" Text='<%# Bind("website") %>' Width="328px"></asp:Label>

                <asp:Label ID="emailTextBox" runat="server" Style="z-index: 104; left: 158px; position: absolute;
                    top: 145px" Text='<%# Bind("email") %>' Width="328px"></asp:Label>
    
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Style="z-index: 107; left: 22px;
                    position: absolute; top: 147px" Text="Email:" Width="118px"></asp:Label>
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Style="z-index: 108; left: 22px;
                    position: absolute; top: 182px" Text="Website:" Width="118px"></asp:Label>
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Style="z-index: 109; left: 22px;
                    position: absolute; top: 114px" Text="Phone:" Width="118px"></asp:Label>
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Style="z-index: 110; left: 22px;
                    position: absolute; top: 81px" Text="Organization:" Width="118px"></asp:Label>
                <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                    Style="z-index: 105; left: 83px; position: absolute; top: 216px" Text="Edit"></asp:LinkButton>                    
            </ItemTemplate>
        </asp:FormView>
        <uc1:HeaderControl ID="HeaderControl1" runat="server" />
        <asp:Label ID="Label6" runat="server" Font-Bold="True" Style="z-index: 102; left: 112px;
            position: absolute; top: 194px" Text="Update your profile"></asp:Label>
    </form>
</body>
</html>
