<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<asp:Content ID="Content1"  runat="server" ContentPlaceHolderID="MainContent">
    <div style="min-height:460px;">
        
        <h2>Register at CUAHSI - HIS</h2>        
        
        <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" 
            AnswerLabelText="Security Answer" 
            CompleteSuccessText="Your account has been successfully created !" 
            ConfirmPasswordCompareErrorMessage="Password and Confirmation Password must match." 
            ConfirmPasswordLabelText="Confirm Password" CreateUserButtonText="Register" 
            DuplicateUserNameErrorMessage="user name is unavailable. please enter a different user name" 
            EmailLabelText="E-mail" 
            EmailRegularExpression="^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$" 
            EmailRegularExpressionErrorMessage="Email Address not valid." 
            FinishDestinationPageUrl="~/account.aspx" 
            MembershipProvider="CuashiHisSqlMembershipProvider" 
            oncreateduser="CreateUserWizard1_CreatedUser" PasswordLabelText="Password" 
            QuestionLabelText="Security Question" StepPreviousButtonType="Image" 
            UserNameLabelText="User Name">
            <WizardSteps>
                <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                </asp:CreateUserWizardStep>
                <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                </asp:CompleteWizardStep>
            </WizardSteps>
        </asp:CreateUserWizard>
        
    </div>
</asp:Content>
