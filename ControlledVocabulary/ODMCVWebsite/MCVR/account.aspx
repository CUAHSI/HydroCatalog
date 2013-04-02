<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteMaster.master" CodeFile="account.aspx.cs" Inherits="account" %>

<asp:Content ID="Content1"  runat="server" ContentPlaceHolderID="MainContent">
    <div style="min-height:460px;">
        <div style="position:absolute;right:40px; top:170px;">
           <p>
           <asp:LoginStatus ID="Status" runat="server" LogoutAction="Redirect" LogoutPageUrl="http://his.cuahsi.org/mastercvreg.html" LogoutText="Sign Out" />
           </p>
        </div>    	
        	
        <h2>Welcome, <asp:Label ID="NameLabel" runat="server" style="color:Black;"></asp:Label> - Your Account</h2>
        
        <br />
        
        <asp:LinkButton ID="ChangePasswordButton" runat="server" onclick="ChangePasswordButton_Click">Change Password</asp:LinkButton>
                     
        <asp:ChangePassword ID="ChangePasswordControl" runat="server"
            ChangePasswordButtonText="Submit" 
            ConfirmPasswordCompareErrorMessage="Passwords must match"
            ConfirmPasswordRequiredErrorMessage="Confirm Password required"
            MembershipProvider="CuashiHisSqlMembershipProvider" 
            NewPasswordRegularExpressionErrorMessage="Password minimum 8 charcters long with at least 1 alpha-numeric"
            onchangedpassword="ChangePasswordControl_ChangedPassword"
            Visible="false" 
            ChangePasswordFailureText="Password length minimum: {0}. Non-alphanumeric characters required: {1}." 
            ChangePasswordTitleText="" ConfirmNewPasswordLabelText="Confirm Password:" 
            oncancelbuttonclick="ChangePasswordControl_CancelButtonClick" 
            PasswordLabelText="Old Password:">
        </asp:ChangePassword>

        <div runat="server" id="AccountInfoDisplay" style="margin-right:50px;">
             
             <h3>Account Information</h3>
             <br />   
             <table runat="server">
                <tr>
                    <td style="width:100px;">Email Address</td>
                    <td><asp:Label ID="EmailAddress" runat="server"></asp:Label></td>
                </tr>
                 <tr>
                    <td>Organization</td>
                    <td><asp:Label ID="Organization" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>Department</td>
                    <td><asp:Label ID="Department" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>Phone</td>                       
                    <td><asp:Label ID="Phone" runat="server"></asp:Label></td>
                </tr>
             </table>    
             <br />
             <asp:Button ID="UpdateUserInfoButton" runat="server" Text="Edit" Width="60" onclick="UpdateUserInfoButton_Click" />              
        </div>
        
         <div runat="server" id="EditUserInfoBox" style="margin-right:50px;" visible="false">
             
             <h3>Account Information - Edit</h3>
             <br />   
             <table runat="server">
                <tr>
                    <td style="width:100px;">Email Address</td>
                    <td><asp:TextBox ID="EmailAddressText" Width="200" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="reqEmail" ControlToValidate="EmailAddressText" Runat="server" 
							    ErrorMessage="* Required Field" ForeColor="#cc0000" Display="Dynamic" />
						<asp:RegularExpressionValidator id="regEmail" Runat="server" ControlToValidate="EmailAddressText" ValidationExpression="^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
							    Display="Dynamic" ErrorMessage="Invalid email address" ForeColor="#cc0000"></asp:RegularExpressionValidator>
				    </td>
		         </tr>
                 <tr>
                    <td>First Name</td>
                    <td><asp:TextBox ID="FirstNameText" runat="server" Width="200"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>Last Name</td>
                    <td><asp:TextBox ID="LastNameText" runat="server" Width="200"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>Organization</td>
                    <td><asp:TextBox ID="OrganizationText" runat="server" Width="200"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Department</td>
                    <td><asp:TextBox ID="DepartmentText" runat="server" Width="200"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Phone</td>
                    <td><asp:TextBox ID="PhoneText" runat="server" Width="200"></asp:TextBox></td>
                </tr>
             </table>    
             <br />
            <asp:Button ID="UpdateButton" runat="server" Text="Update" onclick="UpdateButton_Click" />  
            <asp:Button ID="CancelButton" runat="server" Text="Cancel" onclick="CancelButton_Click" />              
        </div>
             
       <h3>Quick Links</h3> 
       <br />       
       <asp:LoginView ID="LoginView2" runat="server">
        <RoleGroups>
                <asp:RoleGroup Roles="Administrator">
                    <ContentTemplate>
                        <ul>
                            <li><a href="manage/default.aspx">Moderator Section</a></li>
                            <li><a href="manage/admin/default.aspx">Administrator Section</a></li> 
                            <li><a href="http://his.cuahsi.org/mastercvreg.html" target="_blank">Master Controlled Vocabulary Registry</a></li>
                            <li><a href="CV/cv10.aspx">Master Controlled Vocabulary Registry for ODM 1.0</a></li>
                            <li><a href="CV/cv11.aspx">Master Controlled Vocabulary Registry for ODM 1.1</a></li>
                            <li><a href="http://his.cuahsi.org/mastercvws.html" target="_blank">Master Controlled Vocabulary Web Services</a></li>
                            <li><a href="http://his.cuahsi.org/mastercvdata.html" target="_blank">Master Controlled Vocabulary Repository Database</a></li>                           
                        </ul>
                    </ContentTemplate>
                </asp:RoleGroup>
                <asp:RoleGroup Roles="Moderator">
                    <ContentTemplate>
                        <ul>
                            <li><a href="manage/default.aspx">Moderator Section</a></li>
                            <li><a href="http://his.cuahsi.org/mastercvreg.html" target="_blank">Master Controlled Vocabulary Registry</a></li>
                            <li><a href="CV/cv10.aspx">Master Controlled Vocabulary Registry for ODM 1.0</a></li>
                            <li><a href="CV/cv11.aspx">Master Controlled Vocabulary Registry for ODM 1.1</a></li>
                            <li><a href="http://his.cuahsi.org/mastercvws.html" target="_blank">Master Controlled Vocabulary Web Services</a></li>
                            <li><a href="http://his.cuahsi.org/mastercvdata.html" target="_blank">Master Controlled Vocabulary Repository Database</a></li>                           
                        </ul>
                    </ContentTemplate>
                </asp:RoleGroup>
                <asp:RoleGroup Roles="User">
                    <ContentTemplate>
                    <ul>
                       <li><a href="http://his.cuahsi.org/mastercvreg.html" target="_blank">Master Controlled Vocabulary Registry</a></li>
                       <li><a href="CV/cv10.aspx">Master Controlled Vocabulary Registry for ODM 1.0</a></li>
                       <li><a href="CV/cv11.aspx">Master Controlled Vocabulary Registry for ODM 1.1</a></li>
                       <li><a href="http://his.cuahsi.org/mastercvws.html" target="_blank">Master Controlled Vocabulary Web Services</a></li>
                       <li><a href="http://his.cuahsi.org/mastercvdata.html" target="_blank">Master Controlled Vocabulary Repository Database</a></li>                           
                    </ul>
                    </ContentTemplate>
                </asp:RoleGroup>
             </RoleGroups>   
                     
        </asp:LoginView>
          
    </div>

</asp:Content>
