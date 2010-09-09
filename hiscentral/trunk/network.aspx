<%@ Page Language="C#" AutoEventWireup="true" CodeFile="network.aspx.cs" Inherits="network" %>

<%@ Register Src="HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CUAHSI HIS Central</title>
  <link href="styles/his.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
    
    <div></div>    
        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CentralHISConnectionString %>"
            SelectCommand="SELECT username, ServiceWSDL, ServiceAbs, NetworkName, ContactName, ContactEmail, ContactPhone, Organization, website, IsPublic, SupportsAllMethods, Citation, MapIconPath, OrgIconPath, LastHarvested, NetworkTitle, IsApproved, ProjectStatus, NetworkVocab,NetworkID FROM HISNetworks WHERE (NetworkID = @NetworkID)" 
            InsertCommand="INSERT INTO HISNetworks(username, NetworkName, ServiceAbs, ServiceWSDL, ContactEmail, ContactName, ContactPhone, Organization, website) VALUES (,,,,,,,,) " 
            
        UpdateCommand="UPDATE HISNetworks SET NetworkName = @NetworkName, ServiceWSDL = @ServiceWSDL, ServiceAbs = @ServiceAbs, ContactName = @ContactName, ContactEmail = @ContactEmail, ContactPhone = @ContactPhone, Organization = @Organization, website = @website, Citation = @Citation, IsPublic = @IsPublic, NetworkTitle = @NetworkTitle WHERE (NetworkID = @NetworkID)">
            <SelectParameters>
                <asp:SessionParameter Name="NetworkID" SessionField="NetworkID" Type="Int32" />      
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="NetworkName" />
                <asp:Parameter Name="ServiceWSDL" />
                <asp:Parameter Name="ServiceAbs" />
                <asp:Parameter Name="ContactName" />
                <asp:Parameter Name="ContactEmail" />
                <asp:Parameter Name="ContactPhone" />
                <asp:Parameter Name="Organization" />
                <asp:Parameter Name="website" />
                <asp:Parameter Name="Citation" />
                <asp:Parameter Name="IsPublic" />
              <asp:Parameter Name="NetworkTitle" />
                                              
                <asp:Parameter Name="NetworkID" />
                                              
            </UpdateParameters>

        </asp:SqlDataSource>
        <div style="z-index: 121; left: 20px; width: 860px; position: absolute; top: 200px;">
        <asp:FormView ID="FormView1" runat="server" DataSourceID="SqlDataSource1" Height="415px"
            Style="z-index: 100; left: 1px; position: absolute; top: 0px" Width="893px" OnPageIndexChanging="FormView1_PageIndexChanging">
            <EditItemTemplate>
              <div style="z-index: 100; left: 1px; width: 1014px; position: absolute; top: 0px;
                    height: 457px; background-color: #bbbbbb;">
                    
                <asp:TextBox ID="ServiceWSDLTextBox" runat="server" Text='<%# Bind("ServiceWSDL") %>' style="z-index: 100; left: 154px; position: absolute; top: 54px" Width="459px" Height="20px" TabIndex="1" ReadOnly="False"></asp:TextBox>               
                <asp:TextBox ID="ServiceAbsTextBox" runat="server" Text='<%# Bind("ServiceAbs") %>' style="z-index: 101; left: 442px; position: absolute; top: 346px;" Height="90px" TextMode="MultiLine" Width="362px" TabIndex="7"></asp:TextBox>               
                <asp:TextBox ID="NetworkNameTextBox" runat="server" Text='<%# Bind("NetworkName") %>' style="z-index: 102; left: 154px; position: absolute; top: 28px" Width="459px" Height="20px" ReadOnly="True"></asp:TextBox>                
                <asp:TextBox ID="NetworkTitleTextBox" runat="server" Text='<%# Bind("NetworkTitle") %>' style="z-index: 103; left: 154px; position: absolute; top: 2px" Width="459px" Height="20px" ReadOnly="False"></asp:TextBox>                
                <asp:TextBox ID="NetworkIDTextBox" runat="server" Text='<%# Bind("NetworkID") %>' 
                      style="display:none;  left: 732px; position: absolute; top: 158px; height: 35px; width: 215px;" 
                      TabIndex="4"></asp:TextBox>
                <asp:TextBox ID="ContactEmailTextBox" runat="server" Text='<%# Bind("ContactEmail") %>' style="z-index: 105; left: 146px; position: absolute; top: 240px" Height="20px" Width="175px" TabIndex="5"></asp:TextBox>
                <asp:TextBox ID="ContactPhoneTextBox" runat="server" Text='<%# Bind("ContactPhone") %>' style="z-index: 106; left: 146px; position: absolute; top: 267px" Height="20px" Width="175px" TabIndex="6"></asp:TextBox>                               
                <asp:TextBox ID="OrganizationTextBox" runat="server" Text='<%# Bind("Organization") %>' style="z-index: 107; left: 151px; position: absolute; top: 106px" Height="20px" Width="461px" TabIndex="2"></asp:TextBox>                            
                <asp:TextBox ID="websiteLabel" runat="server" Text='<%# Bind("website") %>' style="z-index: 108; left: 151px; position: absolute; top: 131px" Height="20px" Width="461px" TabIndex="3"></asp:TextBox>
                <asp:TextBox ID="CitationTextBox" runat="server" Text='<%# Bind("Citation") %>' style="z-index: 109; left: 439px; position: absolute; top: 223px" Height="85px" Width="363px" TabIndex="3" TextMode="MultiLine"></asp:TextBox>
                <asp:CheckBox ID="PublicCheckbox" runat="server" Style="z-index: 110; left: 146px; position: absolute;
                      top: 337px" Text="Is service public?" Checked='<%# Bind("IsPublic") %>' Font-Size="12px"></asp:CheckBox>
                <asp:Label ID="Label17" runat="server" Font-Italic="True" Font-Size="Small" Height="41px"
                  Style="z-index: 111; left: 153px; position: absolute; top: 368px" Text="Service must be public to be accessible through this portal. "
                  Width="213px"></asp:Label>
                &nbsp;&nbsp;
                
                 <asp:Label ID="Label2" runat="server" Font-Bold="True" Style="z-index: 112; left: 25px;
                     position: absolute; top: 9px" Text="Service Title:" Font-Size="16px" Width="130px"></asp:Label>
                 <asp:Label ID="Label6" runat="server" Font-Bold="True" Style="z-index: 113; left: 23px;
                     position: absolute; top: 34px" Text="Network Vocab" Width="125px" Font-Size="12px"></asp:Label>
                 <asp:Label ID="Label8" runat="server" Font-Bold="True" Style="z-index: 114; left: 34px;
                     position: absolute; top: 219px" Text="Name:" Width="116px" Font-Size="12px"></asp:Label>
                 <asp:Label ID="Label9" runat="server" Font-Bold="True" Style="z-index: 115; left: 34px;
                     position: absolute; top: 263px" Text="Phone:" Font-Size="12px"></asp:Label>
                 <asp:Label ID="Label10" runat="server" Font-Bold="True" Style="z-index: 116; left: 34px;
                     position: absolute; top: 242px" Text="Email:" Width="87px" Font-Size="12px"></asp:Label>
                 <asp:Label ID="Label11" runat="server" Font-Bold="True" Style="z-index: 117; left: 34px;
                     position: absolute; top: 112px" Text="Organization:" Font-Size="12px"></asp:Label>
                 <asp:Label ID="Label12" runat="server" Font-Bold="True" Style="z-index: 118; left: 34px;
                     position: absolute; top: 133px" Text="URL:" Font-Size="12px"></asp:Label>
                 <asp:Label ID="Label7" runat="server" Font-Bold="True" Style="z-index: 119; left: 34px;
                     position: absolute; top: 56px" Text="Service WSDL:" Font-Size="12px"></asp:Label>
                 <asp:Label ID="Label3" runat="server" Font-Bold="True" Style="z-index: 120; left: 446px;
                     position: absolute; top: 324px" Text="Abstract:" Font-Size="16px"></asp:Label>
                 <asp:Label ID="Label4" runat="server" Font-Bold="True" Style="z-index: 121; left: 19px;
                     position: absolute; top: 190px" Text="Contact Info:" Font-Size="16px" Width="125px"></asp:Label>
                 <asp:Label ID="Label5" runat="server" Font-Bold="True" Style="z-index: 122; left: 19px;
                     position: absolute; top: 92px" Text="Source Info:" Font-Size="16px" Width="117px"></asp:Label>
                 <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="16px" Style="z-index: 123;
                      left: 443px; position: absolute; top: 199px" Text="Citation:"></asp:Label>  
                   
                           
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                    Text="Update" style="z-index: 124; left: 48px; position: absolute; top: 428px; border-right: black thin solid; border-top: black thin solid; font-weight: bold; vertical-align: middle; border-left: black thin solid; color: blue; border-bottom: black thin solid; background-color: white; text-align: center; text-decoration: none;" Height="21px" Width="69px" TabIndex="8" Font-Size="12px"></asp:LinkButton>
                <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                    Text="Cancel" style="z-index: 125; left: 138px; position: absolute; top: 428px; border-right: black thin solid; border-top: black thin solid; font-weight: bold; vertical-align: middle; border-left: black thin solid; color: blue; border-bottom: black thin solid; background-color: white; text-align: center; text-decoration: none;" Height="21px" Width="69px" TabIndex="9" Font-Size="12px"></asp:LinkButton>
                
                
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="ContactEmailTextBox"
                         ErrorMessage="Invalid Email" Style="z-index: 126; left: 335px; position: absolute;
                         top: 272px" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="websiteLabel"
                         ErrorMessage="Invalid URL" Style="z-index: 127; left: 624px; position: absolute;
                         top: 133px" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?"></asp:RegularExpressionValidator>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="ContactPhoneTextBox"
                         ErrorMessage="Invalid Phone number" Height="43px" Style="z-index: 128; left: 335px;
                         position: absolute; top: 235px" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"
                         Width="86px" Font-Size="12px"></asp:RegularExpressionValidator>
                &nbsp;&nbsp;
                <asp:Label ID="Label15" runat="server" Font-Italic="True" Font-Size="Small" Style="z-index: 130;
                  left: 160px; position: absolute; top: 162px" Text="What organization is publishing this data?"></asp:Label>
                <asp:Label ID="Label16" runat="server" Font-Italic="True" Font-Size="Small" Style="z-index: 131;
                  left: 149px; position: absolute; top: 298px" Text="Who is the primary contact?"></asp:Label>
                <asp:Label ID="Label18" runat="server" Font-Italic="True" Font-Size="Small" Height="85px"
                  Style="z-index: 132; left: 812px; position: absolute; top: 230px" Text="How do you want your data to be cited when downloaded? "
                  Width="169px"></asp:Label>
                <asp:Label ID="Label19" runat="server" Font-Italic="True" Font-Size="Small" Height="85px"
                  Style="z-index: 134; left: 815px; position: absolute; top: 353px" Text="Provide a brief description about your project and how you collected your data. "
                  Width="169px"></asp:Label>


                  <asp:TextBox ID="ContactNameTextBox" runat="server" Height="20px" 
                      style="z-index: 104; left: 146px; position: absolute; top: 213px" TabIndex="4" 
                      Text='<%# Bind("ContactName") %>' Width="175px"></asp:TextBox>


                </div>
            </EditItemTemplate>
            <InsertItemTemplate>

            </InsertItemTemplate>
            <ItemTemplate>
              <div style="z-index: 100; left: 1px; width: 860px; position: absolute; top: 0px;
                    height: 475px; background-color: #FFFFFF;">
<asp:Label ID="hiddenUserName" runat="server" Font-Bold="True" Style="z-index: 100; left: 575px;
                     position: absolute; top: 5px" Text='<%# Bind("UserName") %>' Font-Size="Larger" Width="117px"></asp:Label>                                               
                
                <div style="z-index: 139; top:341px; left:489px; position:absolute; width:356px;
                     height: 116px; overflow:auto;">
                     <asp:Label ID="ServiceAbsLabel" runat="server" Text='<%# Bind("ServiceAbs") %>' style="z-index: 101; left: 0px; position: absolute; top: 0px;" Font-Size="12px"></asp:Label>
                 </div>
                <asp:Label ID="ServiceWSDLLabel" runat="server" Text='<%# Bind("ServiceWSDL") %>' style="z-index: 101; left: 154px; position: absolute; top: 54px" Width="459px" Height="20px" Font-Size="12px"></asp:Label>          
                <asp:Label ID="NetworkNameLabel" runat="server" Text='<%# Bind("NetworkName") %>' style="z-index: 102; left: 155px; position: absolute; top: 34px" Width="459px" Height="20px" Font-Size="12px"></asp:Label>
                <asp:Label ID="NetworkTitleLabel" runat="server" Text='<%# Bind("NetworkTitle") %>' style="z-index: 103; left: 188px; position: absolute; top: 15px" Width="382px" Height="20px" Font-Bold="True" Font-Size="16px"></asp:Label>                                
                <asp:Label ID="ContactNameLabel" runat="server" Text='<%# Bind("ContactName") %>' style="z-index: 104; left: 146px; position: absolute; top: 213px" Height="20px" Width="175px" Font-Size="12px"></asp:Label>
                <asp:Label ID="ContactEmailLabel" runat="server" Text='<%# Bind("ContactEmail") %>' style="z-index: 105; left: 146px; position: absolute; top: 240px" Height="20px" Width="175px" Font-Size="12px"></asp:Label>
                <asp:Label ID="ContactPhoneLabel" runat="server" Text='<%# Bind("ContactPhone") %>' style="z-index: 106; left: 146px; position: absolute; top: 267px" Height="20px" Width="175px" Font-Size="12px"></asp:Label>                               
                <asp:Label ID="OrganizationLabel" runat="server" Text='<%# Bind("Organization") %>' style="z-index: 107; left: 151px; position: absolute; top: 106px" Height="20px" Width="461px" Font-Size="12px"></asp:Label>                            
                <asp:Label ID="websiteLabel" runat="server" Text='<%# Bind("website") %>' style="z-index: 108; left: 151px; position: absolute; top: 131px" Height="20px" Width="461px" Font-Size="12px"></asp:Label>
                
                
                
 
                      
           
                      
                <asp:Label ID="PublicLabel" runat="server" Style="z-index: 109; left: 146px; position: absolute;
                      top: 307px" Text='<%# (Eval("IsPublic").ToString()=="True")?"Service is public":"Service is private" %>' Font-Size="12px"></asp:Label>

                
                 <asp:Label ID="Label2" runat="server" Font-Bold="True" Style="z-index: 110; left: 19px;
                     position: absolute; top: 18px" Text="Data Service Title:" Font-Size="16px" Width="161px"></asp:Label>
                 <asp:Label ID="Label6" runat="server" Font-Bold="True" Style="z-index: 111; left: 34px;
                     position: absolute; top: 36px" Text="Network Vocab" Width="106px" Font-Size="12px"></asp:Label>
                 <asp:Label ID="Label8" runat="server" Font-Bold="True" Style="z-index: 112; left: 34px;
                     position: absolute; top: 219px" Text="Name:" Width="116px" Font-Size="12px"></asp:Label>
                 <asp:Label ID="Label9" runat="server" Font-Bold="True" Style="z-index: 113; left: 34px;
                     position: absolute; top: 263px" Text="Phone:" Font-Size="12px"></asp:Label>
                 <asp:Label ID="Label10" runat="server" Font-Bold="True" Style="z-index: 114; left: 34px;
                     position: absolute; top: 242px" Text="Email:" Width="87px" Font-Size="12px"></asp:Label>
                 <asp:Label ID="Label11" runat="server" Font-Bold="True" Style="z-index: 115; left: 34px;
                     position: absolute; top: 112px" Text="Organization:" Font-Size="12px"></asp:Label>
                 <asp:Label ID="Label12" runat="server" Font-Bold="True" Style="z-index: 116; left: 34px;
                     position: absolute; top: 133px" Text="URL:" Font-Size="12px"></asp:Label>
                 <asp:Label ID="Label7" runat="server" Font-Bold="True" Style="z-index: 117; left: 34px;
                     position: absolute; top: 56px" Text="Service WSDL:" Font-Size="12px"></asp:Label>
                 <asp:Label ID="Label3" runat="server" Font-Bold="True" Style="z-index: 118; left: 486px;
                     position: absolute; top: 318px" Text="Abstract:" Font-Size="16px"></asp:Label>
                 <asp:Label ID="Label4" runat="server" Font-Bold="True" Style="z-index: 119; left: 19px;
                     position: absolute; top: 190px" Text="Contact Info:" Font-Size="16px" Width="125px"></asp:Label>
                 <asp:Label ID="Label5" runat="server" Font-Bold="True" Style="z-index: 120; left: 19px;
                     position: absolute; top: 92px" Text="Source Info:" Font-Size="16px" Width="117px"></asp:Label>
                  <div style="z-index: 138; left: 488px; overflow: auto; width: 356px; position: absolute;
                      top: 215px; height: 106px">
                <asp:Label ID="CitationLabel" runat="server" Text='<%# Bind("citation") %>' style="z-index: 100; left: 0px; position: absolute; top: 0px" Height="20px" TabIndex="3" Font-Size="12px"></asp:Label>
                  </div>
                  <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Size="16px" Style="z-index: 121;
                      left: 489px; position: absolute; top: 191px" Text="Citation:"></asp:Label>
                 

                <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                    Text="Edit Details" style="z-index: 122; left: 27px; position: absolute; top: 384px; border-right: black thin solid; border-top: black thin solid; font-weight: bold; border-left: black thin solid; color: blue; border-bottom: black thin solid; background-color: white; text-align: center; text-decoration: none;" Height="19px" Width="123px" Font-Size="12px"></asp:LinkButton>

                
                <asp:Label ID="Label14" runat="server" Font-Bold="True" Style="z-index: 124; left: 24px;
                  position: absolute; top: 336px" Text="LastHarvested:" Font-Size="16px"></asp:Label>
                <asp:Label ID="lblHarvestDate" runat="server" Style="z-index: 125; left: 147px; position: absolute;
                  top: 339px" Text='<%# Bind("LastHarvested") %>' Font-Size="12px" Width="157px"></asp:Label>
                                


                <asp:Label ID="lblApproved" runat="server" Style="z-index: 140; left: 147px; position: absolute;
                  top: 362px" Text='<%# (Eval("IsApproved").ToString()=="True")?"Approved":"Not Approved" %>'
                  Width="152px" Font-Size="12px"></asp:Label>

                </div>
            </ItemTemplate>
        </asp:FormView>
        </div>
        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="SiteInfo"
                    Text="Sites Info" style="z-index: 100; left: 51px; position: absolute; top: 917px; border-right: black thin solid; border-top: black thin solid; font-weight: bold; border-left: black thin solid; color: blue; border-bottom: black thin solid; background-color: white; text-align: center; text-decoration: none;" Height="19px" Width="92px" OnClick="LinkButton1_Click" Font-Size="12px"></asp:LinkButton>
                &nbsp;
 <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="SiteInfo"
                  Height="19px" OnClick="LinkButton2_Click" Style="border-right: black thin solid;
                  border-top: black thin solid; font-weight: bold; z-index: 101; left: 52px; border-left: black thin solid;
                  color: blue; border-bottom: black thin solid; position: absolute; top: 891px; background-color: white;
                  text-align: center; text-decoration: none" Text="List Variables" Width="106px" Font-Size="12px"></asp:LinkButton>
                <asp:LinkButton ID="lnkLinks" runat="server" CausesValidation="False" CommandName="SiteInfo"
                  Height="16px" OnClick="lnkLinks_Click" Style="border-right: black thin solid; border-top: black thin solid;
                  font-weight: bold; z-index: 102; left: 456px; border-left: black thin solid; color: blue;
                  border-bottom: black thin solid; position: absolute; top: 897px; background-color: white;
                  text-align: center; text-decoration: none" Text="Links" Width="95px" Font-Size="12px"></asp:LinkButton>
                <asp:LinkButton ID="LnkContacts" runat="server" CausesValidation="False" CommandName="SiteInfo"
                  Height="16px" OnClick="LnkContacts_Click" Style="border-right: black thin solid;
                  border-top: black thin solid; font-weight: bold; z-index: 103; left: 456px; border-left: black thin solid;
                  color: blue; border-bottom: black thin solid; position: absolute; top: 874px; background-color: white;
                  text-align: center; text-decoration: none" Text="Contacts" Width="94px" Font-Size="12px"></asp:LinkButton>
                <asp:LinkButton ID="lnkDesc" runat="server" CausesValidation="False" CommandName="SiteInfo"
                  Height="16px" OnClick="lnkDesc_Click" Style="border-right: black thin solid; border-top: black thin solid;
                  font-weight: bold; z-index: 104; left: 456px; border-left: black thin solid; color: blue;
                  border-bottom: black thin solid; position: absolute; top: 852px; background-color: white;
                  text-align: center; text-decoration: none" Text="Descriptions" Width="94px" Font-Size="12px"></asp:LinkButton>
                <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandName="SiteInfo"
                  Height="19px" OnClick="LinkButton4_Click" Style="border-right: black thin solid;
                  border-top: black thin solid; font-weight: bold; z-index: 105; left: 50px; border-left: black thin solid;
                  color: blue; border-bottom: black thin solid; position: absolute; top: 864px; background-color: white;
                  text-align: center; text-decoration: none" Text="Tag Variables" Width="115px" Font-Size="12px"></asp:LinkButton>
                <asp:LinkButton ID="LinkButton7" runat="server" CausesValidation="False" CommandName="SiteInfo"
                  Height="19px" OnClick="LinkButton5_Click" Style="border-right: black thin solid;
                  border-top: black thin solid; font-weight: bold; z-index: 106; left: 51px; border-left: black thin solid;
                  color: blue; border-bottom: black thin solid; position: absolute; top: 788px; background-color: white;
                  text-align: center; text-decoration: none" Text="Test Service" Width="111px" Font-Size="12px"></asp:LinkButton> 
        <uc1:HeaderControl ID="HeaderControl1" runat="server" />
        <asp:Label ID="Label25" runat="server" Font-Bold="True" Font-Size="18px" Style="z-index: 107;
            left: 23px; position: absolute; top: 160px" 
        Text="Data Service Details:" Width="225px"></asp:Label>
      <asp:HyperLink ID="lnkPublic" runat="server" Style="z-index: 108; left: 269px; position: absolute;
        top: 163px" Font-Size="12px">View Public Details Page</asp:HyperLink>
      <asp:LinkButton ID="LinkButton5" runat="server" CausesValidation="False" CommandName="SiteInfo"
        Height="19px" OnClick="LinkButton5_Click1" Style="border-right: black thin solid;
        border-top: black thin solid; font-weight: bold; z-index: 109; left: 42px; border-left: black thin solid;
        color: blue; border-bottom: black thin solid; position: absolute; top: 684px; background-color: white;
        text-align: center; text-decoration: none" Text="Request Data Harvest" Width="168px" Font-Size="12px"></asp:LinkButton>
      <asp:LinkButton ID="LinkButton6" runat="server" CausesValidation="False" CommandName="SiteInfo"
        Height="19px" OnClick="LinkButton6_Click" Style="border-right: black thin solid;
        border-top: black thin solid; font-weight: bold; z-index: 110; left: 43px; border-left: black thin solid;
        color: blue; border-bottom: black thin solid; position: absolute; top: 710px; background-color: white;
        text-align: center; text-decoration: none" Text="Request Approval" Width="166px" Font-Size="12px"></asp:LinkButton>
      <asp:Label ID="lblMessage" runat="server" Height="9px" Style="z-index: 111; left: 48px;
        position: absolute; top: 739px" Font-Size="12px"></asp:Label> 
               <asp:Image ID="ImageButton1" runat="server" Height="100px" OnClick="upload_Click" 
                      ImageUrl="getLogo.aspx"  
                      Style="z-index: 112; left: 690px; position: absolute; top: 680px" Width="100px" />
               <asp:Image ID="ImageButton2" runat="server" OnClick="upload_Click" 
                      ImageUrl="getIcon.aspx"
                      Style="z-index: 113;left: 655px; position: absolute; top: 683px" />  
               <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="SiteInfo"
                  Height="19px" OnClick="upload_Click" Style="border-right: black thin solid;
                  border-top: black thin solid; font-weight: bold; z-index: 114; left: 531px; border-left: black thin solid;
                  color: blue; border-bottom: black thin solid; position: absolute; top: 686px; background-color: white;
                  text-align: center; text-decoration: none" Text="Change Images" Width="112px" Font-Size="12px"></asp:LinkButton>        
      <asp:Label ID="Label26" runat="server" Font-Italic="True" Font-Size="Small" Height="41px"
        Style="z-index: 115; left: 173px; position: absolute; top: 786px" Text="Use this page to test the methods on your service."
        Width="213px"></asp:Label>
      <asp:Label ID="Label20" runat="server" Font-Italic="True" Font-Size="Small" Height="78px"
        Style="z-index: 116; left: 175px; position: absolute; top: 859px" Text="After your service has been harvested, you need to tag your variables with using the Hydrologic Ontology. Addtionally, you can view the harvested data by listing the variables and sites."
        Width="213px"></asp:Label>
      <asp:Label ID="Label21" runat="server" Font-Bold="True" Style="z-index: 117; left: 434px;
        position: absolute; top: 829px" Text="Additional Metadata? "></asp:Label>
      <asp:Label ID="Label22" runat="server" Font-Italic="True" Font-Size="Small" Height="41px"
        Style="z-index: 118; left: 227px; position: absolute; top: 684px" Text="Send a message to the site administrator requesting approval or an additional harvest. (If you just submitted a new service, a message has already been sent). "
        Width="213px"></asp:Label>
      <asp:Label ID="Label23" runat="server" Font-Italic="True" Font-Size="Small" Height="41px"
        Style="z-index: 119; left: 566px; position: absolute; top: 863px" Text="Provide any addtional information you may want included on your service's public page.  "
        Width="213px"></asp:Label>
      <asp:Label ID="Label24" runat="server" Font-Italic="True" Font-Size="Small" Height="33px"
        Style="z-index: 122; left: 536px; position: absolute; top: 721px" Text="Upload a custom logo and map icon to be used for your data service"
        Width="145px"></asp:Label>
      
               
    </form>
</body>
</html>
