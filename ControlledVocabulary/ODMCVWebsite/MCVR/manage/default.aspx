<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteMaster.master" CodeFile="default.aspx.cs" Inherits="manage_Default" %>
<%@ Register TagPrefix="Logger" TagName="status" Src="~/status.ascx" %>

<asp:Content ID="Content1"  runat="server" ContentPlaceHolderID="MainContent">
    <div style="min-height:460px;">
    
    <Logger:status id="Status" runat="server" />
    
     <h2>Master Controlled Vocabulary - Moderator Section</h2>
           
       <asp:LoginView ID="LoginViewUser" runat="server">
            <RoleGroups>
                <asp:RoleGroup Roles="Administrator">
                    <ContentTemplate>
                       <p>Welcome, You are logged in as Site Administrator.</p>
                       <h4>Administrator Section</h4>
                       <p>In order to manage user accounts, permissions and vocabulary responsibilities please visit the 
                          <asp:HyperLink ID="link" NavigateUrl="~/manage/admin/default.aspx" runat="server">admin page</asp:HyperLink>.
                       </p>
                       <h4>Moderator Section</h4>
                       <p>All current change requests for CUAHSI-HIS controlled vocabularies are accessible below. Please manage any requests that you are responsible for.</p>                    
                    </ContentTemplate>
                </asp:RoleGroup>
                <asp:RoleGroup Roles="Moderator">
                    <ContentTemplate>
                        <p><b><asp:Label ID="NameLabel" runat="server" Text="Label"></asp:Label></b>, Thank you for logging in. All current change requests for CUAHSI-HIS controlled vocabularies are accessible below. Please manage any requests that you are responsible for.</p>
                    </ContentTemplate>
                </asp:RoleGroup>        
            </RoleGroups>
        </asp:LoginView>        
                
        <h3>ODM 1.0 Pending Controlled Vocabulary Submissions</h3>
        <br />
        
        <div runat="server" id="cv10Submissions">
            
            <table width="90%">
			    <tr>
					<td>
					    <asp:Table ID="cv10Subs" Runat="server"></asp:Table>
					</td>
				</tr>
			</table>
        </div>
        
        <h3>ODM 1.1 Pending Controlled Vocabulary Submissions</h3>
        <br />
                
        <div runat="server" id="Div1">
            <table width="90%">
			    <tr>
					<td>
					    <asp:Table ID="cv11Subs" Runat="server"></asp:Table>
					</td>
				</tr>
			</table>
        </div>
        
    </div>			
	  
</asp:Content>
