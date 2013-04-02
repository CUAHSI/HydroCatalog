<%@ Page Language="C#" AutoEventWireup="true" Title="CUAHSI HIS | Master Controlled Vocabulary Registry | Administrator | User Account" CodeFile="account.aspx.cs" Inherits="manage_account" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size:12px;font-family:Arial;">
    
        <h2>Manage User - <asp:Label ID="NameLabel" runat="server" Text="Label"></asp:Label></h2>     
    
        <div runat="server" id="UserDetailsBox">
        
            <h3 style="color:#336699;">User Information</h3>
            
            <div id="UserDetailsDisplay" runat="server" visible="true">
                <fieldset>
                    <legend>Account Info</legend>
                    <table id="Table1" runat="server">
                        <tr>
                            <td style="width:100px;">Name</td>
                            <td><asp:Label ID="FirstNameLabel" runat="server"></asp:Label> <asp:Label ID="LastNameLabel" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Email Address</td>
                            <td><asp:Label ID="EmailAddressLabel" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Current Role</td>
                            <td><asp:Label ID="RoleLabel" runat="server"></asp:Label></td>
                        </tr>                
                        <tr>
                            <td>Organization</td>
                            <td><asp:Label ID="OrganizationLabel" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Department</td>
                            <td><asp:Label ID="DepartmentLabel" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Designation</td>
                            <td><asp:Label ID="DesignationLabel" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Phone</td>                       
                            <td><asp:Label ID="PhoneLabel" runat="server"></asp:Label></td>
                        </tr>
                    </table>                
                </fieldset>                         
                <asp:LinkButton ID="EditUserLink" runat="server" onclick="EditUserLink_Click">Edit account</asp:LinkButton>
            </div>   

            <div id="UserDetailsEdit" runat="server" visible="false">
                <fieldset>
                    <legend>Account Info - Edit</legend>
                    <table id="Table2" runat="server">
                        <tr>
                            <td style="width:100px;">Email Address</td>
                            <td><asp:TextBox ID="EmailAddressText" Width="200" runat="server"></asp:TextBox></td>
                            <td><asp:RequiredFieldValidator ID="reqEmail" ControlToValidate="EmailAddressText" Runat="server" 
							            ErrorMessage="* Required Field" ForeColor="#cc0000" Display="Dynamic" />
				            <asp:RegularExpressionValidator id="regEmail" Runat="server" ControlToValidate="EmailAddressText" ValidationExpression="^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
							            Display="Dynamic" ErrorMessage="Invalid email address" ForeColor="#cc0000"></asp:RegularExpressionValidator>
			                </td>
                        </tr>
                        <tr>
                            <td>Role</td>
                            <td><asp:RadioButtonList ID="RoleRadioList" runat="server"></asp:RadioButtonList></td>
                        </tr>  
                        <tr>
                            <td colspan="2"><p style="color:Red;">Important: Changing a user's Role from 'Moderator' to 'User' will erase all saved CV Permissions.</p></td>                            
                        </tr>  
                         <tr>
                            <td colspan="2"><p style="color:Red;">After you finish editing user information, Please refresh the admin to page to reflect changes you have just made.</p></td>                            
                        </tr>                     
                    </table>                                         
                </fieldset>  
                   
                <asp:Button ID="UpdateButton" runat="server" Text="Update" onclick="UpdateButton_Click"></asp:Button>
                <asp:Button ID="CancelButton" runat="server" Text="Cancel" onclick="CancelButton_Click"></asp:Button>
            </div> 
        </div>
        
        <div runat="server" id="ManagePermissionLinks" visible="false">
        
            <br />
            <h3 style="color:#336699;">Manage User Permissions</h3>
            
            <asp:LinkButton ID="cv10PermissionsButton" runat="server" 
                onclick="cv10PermissionsButton_Click">ODM 1.0 Permissions</asp:LinkButton>
            <br /><br />
            <asp:LinkButton ID="cv11PermissionsButton" runat="server" 
                onclick="cv11PermissionsButton_Click">ODM 1.1 Permissions</asp:LinkButton>
            
        </div>
        
        <div id="ManagePermissionsBox" runat="server" visible="false">
                
                <br />
                <h3 style="color:#336699;">Manage User Permissions</h3>
                <fieldset style="min-height:60px;">
                    <legend>Current <asp:Label ID="CVTypeLabel" runat="server"></asp:Label> Permissions</legend>
                    <div style="padding: 3px; text-align: justify;">
                        <asp:Label ID="CurrentPermissionsListLabel" runat="server"></asp:Label>
                    </div>            
                </fieldset>
                <br />
                <table id="Table3" runat="server">
                    <tr>
                        <td style="width:120px;"><asp:Button ID="AddPermissionButton" runat="server" 
                                Text="Add Permission" onclick="AddPermissionButton_Click" /></td>
                        <td><asp:DropDownList ID="RemainingPermissions" Width="150" runat="server"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td><br /></td>
                        <td><br /></td>
                    </tr>   
                     <tr>
                        <td><asp:Button ID="RemovePermissionButton" runat="server" Text="Remove Permission" 
                                onclick="RemovePermissionButton_Click" /></td>
                        <td><asp:DropDownList ID="CurrentPermissions" Width="150" runat="server"></asp:DropDownList></td>
                        <td>or <asp:Button ID="RemoveAllPermissionsButton" runat="server" Text=" Clear All" 
                                onclick="RemoveAllPermissionsButton_Click" /></td>
                    </tr>             
                </table>  
                
                <br /><br />                      
                           
                <asp:Button ID="FinishManageButton" runat="server" 
                    Text="Finished Managing Permissions" onclick="FinishManageButton_Click" />
                           
         </div>               
      
    </div>
    
     <asp:Button ID="FinishButton" runat="server" Text="Done" OnClientClick="self.close()" style="position:absolute;bottom:10px;right:15px;" />
      
    </form>
</body>
</html>
