<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteMaster.master" CodeFile="loginfail.aspx.cs" Inherits="temp" %>

<asp:Content ID="Content1"  runat="server" ContentPlaceHolderID="MainContent">
    <div style="min-height:460px;">   
    
        <div runat="server" id="EnterUserNameBox" style="margin-right:50px;"> 
                 <h2>Forgot Your Password?</h2>            
                 <h4>Enter your user name and the email address associated with your account</h4>
                 <br />   
                 <table id="Table1" runat="server">
                    <tr>
                        <td style="width:100px;">user name</td>
                        <td><asp:TextBox ID="UserNameText" Width="200" runat="server"></asp:TextBox></td>
                        <td><asp:RequiredFieldValidator ID="req" ControlToValidate="UserNameText" Runat="server" 
							        ErrorMessage="* Required Field" ForeColor="#cc0000" Display="Dynamic" /></td>
                    </tr>    
                    <tr>
                        <td style="width:100px;">email address</td>
                        <td><asp:TextBox ID="EmailAddressText" Width="200" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="reqEmail" ControlToValidate="EmailAddressText" Runat="server" 
							        ErrorMessage="* Required Field" ForeColor="#cc0000" Display="Dynamic" />
						    <asp:RegularExpressionValidator id="regEmail" Runat="server" ControlToValidate="EmailAddressText" ValidationExpression="^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
							        Display="Dynamic" ErrorMessage="Invalid email address" ForeColor="#cc0000"></asp:RegularExpressionValidator>
				        </td>
		             </tr>             
                 </table>            
                 <br />
                 <asp:Button ID="EnterUserNameButton" runat="server" Text="Submit" onclick="EnterUserNameButton_Click"/> 
                 <br />
                 <asp:Label ID="UserNameError" runat="server" Visible="False" ForeColor="Red"></asp:Label>                
          </div>
          
           <div runat="server" id="ValidateUserBox" style="margin-right:50px;" visible="false"> 
                 <h2>Password Reset</h2>            
                 <h4>Answer this question that you chose during account creation correctly to reset your password.</h4>
                 <br />   
                <asp:Label ID="UserNameLabel" runat="server" Visible="false"></asp:Label>
                 <table id="Table2" runat="server">
                    <tr>
                        <td style="width:100px;">Security Question</td>
                        <td><asp:Label ID="QuestionLabel" runat="server"></asp:Label></td>                        
                    </tr>                         
                    <tr>
                        <td style="width:100px;">Your Answer</td>
                        <td><asp:TextBox ID="AnswerBox" Width="300" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="AnswerBox" Runat="server" 
							        ErrorMessage="* Required Field" ForeColor="#cc0000" Display="Dynamic" />
						</td>
		             </tr>             
                 </table>            
                 <br />
                 <asp:Button ID="AnswerButton" runat="server" Text="Submit" Width="60" 
                     onclick="AnswerButton_Click" /> 
                 <br />
                 <asp:Label ID="AnswerQuestionError" runat="server" Visible="False" ForeColor="Red"></asp:Label>                
          </div>
    
           <div runat="server" id="ShowPasswordBox" style="margin-right:50px;" visible="false"> 
                 <h2>Password Successfully Reset !</h2>            
                 
                 <h4>Thank You for taking the trouble to complete the validation process. Your password has been reset.</h4>
                 
                 <p style="color:Red"><b> Important! - We do not email passwords to users in order to guard against several security risks
                     <br />Your NEW PASSWORD will be displayed when you click the 'Show' button below
                     <br />Please make sure you are the only one able to view it before clicking the button
                     <br />Make note of the password and use to access your account. Once you are logged in, it is highly recommended
                      that you change yor password and clear your browser cookies to delete all sensitive information.</b></p>
                 <br />   
                 <div runat="server" id="PasswordContainer" visible="false">
                    <p>
                    Your NEW password is : <b><asp:Label ID="NewPasswordLabel" runat="server" ></asp:Label></b>
                    <br /><br />
                    Please <asp:HyperLink ID="LoginPage" NavigateUrl="~/login.aspx" runat="server" >Login </asp:HyperLink>to your account and change your password.                     
                    </p>
                 </div>
                 <br />
                 <asp:Button ID="ShowPasswordButton" runat="server" Text="Show" 
                     onclick="ShowPasswordButton_Click" />                            
          </div>       
            
     </div>
</asp:Content>
