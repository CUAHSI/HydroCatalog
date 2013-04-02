<%@ Page Language="C#" AutoEventWireup="true" Inherits="register" Codebehind="register.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title> <link href="styles/his.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     
    <div>
        <div class="pageheader">
    <div class="whiteline"></div>
    <div class="hislogo"><img src="images/hiscentrallogo.jpg" alt="CUAHSI Hydrologic Information System - Sharing Hydrologic Data" align="left" height="125" width="700"  / ></div>
   
    <div class="whiteline"></div>
 </div>
        <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" BackColor="#F7F6F3" BorderColor="#E6E2D8"
            BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em"
            Style="z-index: 100; left: 20px; position: absolute; top: 200px" OnCreatedUser="CreateUserWizard1_CreatedUser">
            <WizardSteps>
                <asp:CreateUserWizardStep runat="server">
                </asp:CreateUserWizardStep>
                <asp:CompleteWizardStep runat="server">
                  <ContentTemplate>
                    <table border="0" style="font-size: 100%; font-family: Verdana">
                      <tr>
                        <td align="center" colspan="2" style="font-weight: bold; color: black; background-color: LightSteelBlue">
                          Complete</td>
                      </tr>
                      <tr>
                        <td>
                          Your account has been successfully created.</td>
                      </tr>
                      <tr>
                        <td align="right" colspan="2">
                          <asp:Button ID="ContinueButton" runat="server" BackColor="#FFFBFF" BorderColor="#CCCCCC"
                            BorderStyle="Solid" BorderWidth="1px" CausesValidation="False" CommandName="Continue"
                            Font-Names="Verdana" ForeColor="#284775" Text="Continue" ValidationGroup="CreateUserWizard1" />
                        </td>
                      </tr>
                    </table>
                  </ContentTemplate>
                </asp:CompleteWizardStep>
            </WizardSteps>
            <SideBarStyle BackColor="#5D7B9D" Font-Size="0.9em" VerticalAlign="Top" BorderWidth="0px" />
            <TitleTextStyle BackColor="LightSteelBlue" Font-Bold="True" ForeColor="Black" />
            <SideBarButtonStyle ForeColor="White" BorderWidth="0px" Font-Names="Verdana" />
            <NavigationButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid"
                BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
            <HeaderStyle BackColor="#5D7B9D" BorderStyle="Solid"
                Font-Bold="True" Font-Size="0.9em" ForeColor="White" HorizontalAlign="Center" />
            <CreateUserButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid"
                BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
            <ContinueButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid"
                BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
            <StepStyle BorderWidth="0px" />
        </asp:CreateUserWizard>
 

    
    </div>
    </form>
</body>
</html>
