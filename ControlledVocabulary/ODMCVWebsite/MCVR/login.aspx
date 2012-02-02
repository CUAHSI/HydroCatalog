<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteMaster.master" CodeFile="login.aspx.cs" Title="CUAHSI Hydrologic Information System - Master Controlled Vocabulary Registry | Login" Inherits="login" %>
<%@ Register TagPrefix="Logger" TagName="status" Src="~/status.ascx" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div style="min-height:460px;">
        <h4>Master Controlled Vocabularies - Login</h4>
        <br />
        
        <asp:LoginView ID="LoginView1" runat="server">
            <AnonymousTemplate>
                <p>Please Login with valid account credentials below.</p>
                <br />
                <asp:Login ID="LoginControl" runat="server"              
                    FailureText="Invalid username or password. Please try again." 
                    Height="94px" Width="198px" LoginButtonText="Sign In" 
                    TitleText="" RememberMeText="Remember me." 
                    VisibleWhenLoggedIn="False" DestinationPageUrl="~/manage/default.aspx" 
                    MembershipProvider="CuashiHisSqlMembershipProvider" 
                    PasswordRecoveryText="forgot password?" PasswordRecoveryUrl="~/loginfail.aspx" 
                    PasswordRequiredErrorMessage="Password required." 
                    UserNameRequiredErrorMessage="User Name  required." 
                    CreateUserText="new user?" CreateUserUrl="~/register.aspx" >
                    <TextBoxStyle Height="20px" />
                    <LoginButtonStyle Height="25px" Width="65px" />
                    <TitleTextStyle Height="25px" />
                </asp:Login>
            </AnonymousTemplate>
            <LoggedInTemplate>
                <Logger:status id="Status" runat="server" />
                <p><asp:LoginName ID="LoginName1" runat="server" />, You are Logged In.</p>
                <h4>Quick Links</h4>                    
                    <ul>
                        <li><a href="http://his.cuahsi.org/mastercvreg.html" target="_blank">Master Controlled Vocabulary Registry</a></li>
                        <li><a href="CV/cv10.aspx">Master Controlled Vocabulary Registry for ODM 1.0</a></li>
                        <li><a href="CV/cv11.aspx">Master Controlled Vocabulary Registry for ODM 1.1</a></li>
                        <li><a href="http://his.cuahsi.org/mastercvws.html" target="_blank">Master Controlled Vocabulary Web Services</a></li>
                        <li><a href="http://his.cuahsi.org/mastercvdata.html" target="_blank">Master Controlled Vocabulary Repository Database</a></li>                           
              </ul>
             </LoggedInTemplate>             
        </asp:LoginView>  
           
        <asp:LoginView ID="LoginView2" runat="server">
        <RoleGroups>
                <asp:RoleGroup Roles="Administrator">
                    <ContentTemplate>
                        <ul>
                            <li><a href="manage/default.aspx">Moderator Section</a></li>
                            <li><a href="manage/admin/default.aspx">Administrator Section</a></li>                            
                        </ul>
                    </ContentTemplate>
                </asp:RoleGroup>
                  <asp:RoleGroup Roles="Moderator">
                    <ContentTemplate>
                        <ul>
                            <li><a href="manage/default.aspx">Moderator Section</a></li>                           
                        </ul>
                    </ContentTemplate>
                </asp:RoleGroup>
             </RoleGroups>           
        </asp:LoginView>
        
              
    </div>
</asp:Content>