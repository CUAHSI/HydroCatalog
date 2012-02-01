<%@ Control Language="C#" AutoEventWireup="true" CodeFile="status.ascx.cs" Inherits="statues" %>

<asp:LoginView ID="LoginView1" runat="server">
    <LoggedInTemplate>
       <div style="position:absolute; right: 40px;">
            <p><asp:LoginName ID="UserName" runat="server" /> | 
            <asp:HyperLink ID="AccountLink" NavigateUrl="~/account.aspx" runat="server">My Account </asp:HyperLink>|
            <asp:LoginStatus ID="Status" runat="server" LogoutAction="Redirect" LogoutPageUrl="http://his.cuahsi.org/mastercvreg.html" LogoutText="Sign Out" />
            </p>
      </div>    
    </LoggedInTemplate>
    <AnonymousTemplate>
          <div style="position:absolute; right: 40px;">
            <p>
              <asp:LoginStatus ID="Status" runat="server" LogoutAction="Redirect" LogoutPageUrl="http://his.cuahsi.org/mastercvreg.html" LogoutText="Sign Out" LoginText=" Sign In" />
            </p>
         </div>   
    </AnonymousTemplate>
</asp:LoginView>

