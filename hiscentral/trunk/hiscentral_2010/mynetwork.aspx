<%@ Page Language="C#" AutoEventWireup="false" Inherits="mynetwork" Codebehind="mynetwork.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div style="z-index: 100; left: 155px; width: 700px; position: absolute; top: 268px;
                    height: 356px; background-color: #bbbbbb;">
                                <asp:TextBox ID="ServiceWSDLTextBox" runat="server" Text='<%# Bind("ServiceWSDL") %>' style="z-index: 100; left: 186px; position: absolute; top: 90px" Width="462px"></asp:TextBox>
               
                     <asp:TextBox ID="ServiceAbsTextBox" runat="server" Text='<%# Bind("ServiceAbs") %>' style="z-index: 101; left: 340px; position: absolute; top: 181px;" Height="164px" TextMode="MultiLine" Width="348px"></asp:TextBox>
                 
                
               
                <asp:TextBox ID="NetworkNameTextBox" runat="server" Text='<%# Bind("NetworkName") %>' style="z-index: 102; left: 186px; position: absolute; top: 69px" Width="462px"></asp:TextBox><br />
                
                <asp:TextBox ID="ContactNameTextBox" runat="server" Text='<%# Bind("ContactName") %>' style="z-index: 103; left: 122px; position: absolute; top: 149px"></asp:TextBox>
                <asp:TextBox ID="ContactEmailTextBox" runat="server" Text='<%# Bind("ContactEmail") %>' style="z-index: 104; left: 122px; position: absolute; top: 169px"></asp:TextBox>
                <asp:TextBox ID="ContactPhoneTextBox" runat="server" Text='<%# Bind("ContactPhone") %>' style="z-index: 105; left: 122px; position: absolute; top: 193px"></asp:TextBox><br />
                
                
                <asp:TextBox ID="OrganizationTextBox" runat="server" Text='<%# Bind("Organization") %>' style="z-index: 106; left: 173px; position: absolute; top: 258px"></asp:TextBox><br />
                <asp:TextBox ID="websiteLabel" runat="server" Text='<%# Bind("website") %>' style="z-index: 107; left: 120px; position: absolute; top: 280px"></asp:TextBox><br />
                 <asp:Label ID="Label2" runat="server" Font-Bold="True" Style="z-index: 108; left: 44px;
                     position: absolute; top: 52px" Text="Network:" Font-Size="Larger"></asp:Label>
                 <asp:Label ID="Label6" runat="server" Font-Bold="True" Style="z-index: 109; left: 67px;
                     position: absolute; top: 70px" Text="Name:"></asp:Label>
                 <asp:Label ID="Label8" runat="server" Font-Bold="True" Style="z-index: 110; left: 67px;
                     position: absolute; top: 153px" Text="Name:"></asp:Label>
                 <asp:Label ID="Label9" runat="server" Font-Bold="True" Style="z-index: 111; left: 67px;
                     position: absolute; top: 175px" Text="Email:"></asp:Label>
                 <asp:Label ID="Label10" runat="server" Font-Bold="True" Style="z-index: 112; left: 67px;
                     position: absolute; top: 196px" Text="Phone:"></asp:Label>
                 <asp:Label ID="Label11" runat="server" Font-Bold="True" Style="z-index: 113; left: 67px;
                     position: absolute; top: 259px" Text="Organization:"></asp:Label>
                 <asp:Label ID="Label12" runat="server" Font-Bold="True" Style="z-index: 114; left: 67px;
                     position: absolute; top: 278px" Text="URL:"></asp:Label>
                 <asp:Label ID="Label7" runat="server" Font-Bold="True" Style="z-index: 115; left: 67px;
                     position: absolute; top: 90px" Text="Service WSDL:"></asp:Label>
                 <asp:Label ID="Label3" runat="server" Font-Bold="True" Style="z-index: 116; left: 342px;
                     position: absolute; top: 162px" Text="Abstract:" Font-Size="Larger"></asp:Label>
                 <asp:Label ID="Label4" runat="server" Font-Bold="True" Style="z-index: 117; left: 46px;
                     position: absolute; top: 131px" Text="Contact Info:" Font-Size="Larger"></asp:Label>
                 <asp:Label ID="Label5" runat="server" Font-Bold="True" Style="z-index: 118; left: 47px;
                     position: absolute; top: 238px" Text="Source Info:" Font-Size="Larger"></asp:Label>
                             &nbsp;&nbsp;
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                    Text="Update" style="z-index: 119; left: 32px; position: absolute; top: 321px">
                </asp:LinkButton>
                <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                    Text="Cancel" style="z-index: 121; left: 98px; position: absolute; top: 320px">
                </asp:LinkButton>
                </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CentralHISConnectionString %>"
            SelectCommand="SELECT [username], [ServiceWSDL], [ServiceAbs], [NetworkName], [ContactName], [ContactEmail], [ContactPhone], [Organization], [website] FROM [HISNetworks] WHERE ([NetworkID] = @NetworkID)" 
            InsertCommand="INSERT INTO HISNetworks(username, NetworkName, ServiceAbs, ServiceWSDL, ContactEmail, ContactName, ContactPhone, Organization, website) VALUES (,,,,,,,,) " 
            UpdateCommand="UPDATE HISNetworks SET NetworkName =, ServiceWSDL =, ServiceAbs =, ContactName =, ContactEmail =, ContactPhone =, Organization =, website =  WHERE ([NetworkID] = @NetworkID) " ProviderName="<%$ ConnectionStrings:CentralHISConnectionString.ProviderName %>">
            <SelectParameters>
                <asp:SessionParameter Name="NetworkID" SessionField="NetworkID" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="NetworkID" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
