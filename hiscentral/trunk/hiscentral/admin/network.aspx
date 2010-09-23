<%@ Page Language="C#" AutoEventWireup="true" CodeFile="network.aspx.cs" Inherits="admin_network" %>

<%@ Register Src="HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc2" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
  <link href="styles/his.css" rel="stylesheet" type="text/css" />
  <link href="../styles/his.css" rel="stylesheet" type="text/css" />
  <link href="../styles/his.css" rel="stylesheet" type="text/css" />
  <link href="../styles/his.css" rel="stylesheet" type="text/css" />
  <link href="../styles/his.css" rel="stylesheet" type="text/css" />
  <link href="../styles/his.css" rel="stylesheet" type="text/css" />
  <link href="../styles/his.css" rel="stylesheet" type="text/css" />
</head>
<script language=javascript>
function setUser(index){
  //alert(index);
  var txt=document.getElementById("FormView1$txtUserName");
  var ddl = document.getElementById("ddlUsers");
  if (txt != null) txt.value = ddl.options[index].text;
}
</script>
<body>
    <form id="form1" runat="server">
    <div></div>    
        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CentralHISConnectionString %>"
            SelectCommand="SELECT username, ServiceWSDL, ServiceAbs, IsApproved, NetworkName, ContactName, ContactEmail, ContactPhone, Organization, website, IsPublic, SupportsAllMethods, Citation, MapIconPath, OrgIconPath, LastHarvested, FrequentUpdates FROM HISNetworks WHERE (NetworkID = @NetworkID)"                         
            UpdateCommand="UPDATE HISNetworks SET NetworkName = @NetworkName, ServiceWSDL = @ServiceWSDL, ServiceAbs = @ServiceAbs, ContactName = @ContactName, ContactEmail = @ContactEmail, ContactPhone = @ContactPhone, Organization = @Organization, website = @website, IsApproved = @IsApproved, Citation = @Citation, IsPublic = @IsPublic, username = @username, FrequentUpdates = @FrequentUpdates WHERE (NetworkID = @NetworkID)">
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
                <asp:Parameter Name="IsApproved" />
                <asp:Parameter Name="Citation" />
                <asp:Parameter Name="IsPublic" />
                <asp:Parameter Name="username" />
              <asp:Parameter Name="FrequentUpdates" />
                <asp:SessionParameter Name="NetworkID" SessionField="NetworkID" Type="Int32" />               
            </UpdateParameters>

        </asp:SqlDataSource>
        <div style="z-index: 106; left: 20px; width: 860px; position: absolute; top: 200px;">
        <asp:FormView ID="FormView1" runat="server" DataSourceID="SqlDataSource1" Height="389px"
            Style="z-index: 100; left: 0px; position: absolute; top: 0px" Width="730px" OnPageIndexChanging="FormView1_PageIndexChanging">
            <EditItemTemplate>
              <div style="z-index: 100; left: 1px; width: 860px; position: absolute; top: 0px;
                    height: 475px; background-color: #bbbbbb;">
                <asp:TextBox ID="txtUserName" runat="server" Font-Bold="False" Style="z-index: 100; left: 649px;
                     position: absolute; top: 28px" Text='<%# Bind("UserName") %>' Width="172px"></asp:TextBox>
                     
                    
                <asp:TextBox ID="ServiceWSDLTextBox" runat="server" Text='<%# Bind("ServiceWSDL") %>' style="z-index: 101; left: 154px; position: absolute; top: 54px" Width="459px" Height="20px" TabIndex="1"></asp:TextBox>               
                <asp:TextBox ID="ServiceAbsTextBox" runat="server" Text='<%# Bind("ServiceAbs") %>' style="z-index: 102; left: 442px; position: absolute; top: 346px;" Height="90px" TextMode="MultiLine" Width="362px" TabIndex="7"></asp:TextBox>               
                <asp:TextBox ID="NetworkNameTextBox" runat="server" Text='<%# Bind("NetworkName") %>' style="z-index: 103; left: 154px; position: absolute; top: 28px" Width="459px" Height="20px"></asp:TextBox>                
                <asp:TextBox ID="ContactNameTextBox" runat="server" Text='<%# Bind("ContactName") %>' style="z-index: 104; left: 146px; position: absolute; top: 213px" Height="20px" Width="175px" TabIndex="4"></asp:TextBox>
                <asp:TextBox ID="ContactEmailTextBox" runat="server" Text='<%# Bind("ContactEmail") %>' style="z-index: 105; left: 146px; position: absolute; top: 240px" Height="20px" Width="175px" TabIndex="5"></asp:TextBox>
                <asp:TextBox ID="ContactPhoneTextBox" runat="server" Text='<%# Bind("ContactPhone") %>' style="z-index: 106; left: 146px; position: absolute; top: 267px" Height="20px" Width="175px" TabIndex="6"></asp:TextBox>                               
                <asp:TextBox ID="OrganizationTextBox" runat="server" Text='<%# Bind("Organization") %>' style="z-index: 107; left: 151px; position: absolute; top: 106px" Height="20px" Width="461px" TabIndex="2"></asp:TextBox>                            
                <asp:TextBox ID="websiteLabel" runat="server" Text='<%# Bind("website") %>' style="z-index: 108; left: 151px; position: absolute; top: 131px" Height="20px" Width="461px" TabIndex="3"></asp:TextBox>
                <asp:TextBox ID="CitationTextBox" runat="server" Text='<%# Bind("Citation") %>' style="z-index: 109; left: 439px; position: absolute; top: 223px" Height="85px" Width="363px" TabIndex="3" TextMode="MultiLine"></asp:TextBox>
                <asp:CheckBox ID="PublicCheckbox" runat="server" Style="z-index: 110; left: 146px; position: absolute;
                      top: 307px" Text="Is service public?" Checked='<%# Bind("IsPublic") %>'></asp:CheckBox>
                <asp:CheckBox ID="Approvedcheckbox" runat="server" Style="z-index: 111; left: 146px; position: absolute;
                      top: 337px" Text="Approved?" Checked='<%# Bind("IsApproved") %>'></asp:CheckBox>                      
                &nbsp;&nbsp;
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Larger" Style="z-index: 112;
                  left: 19px; position: absolute; top: 18px" Text="Network:" Width="106px"></asp:Label>
                
                 <asp:Label ID="Label15" runat="server" Font-Bold="True" Style="z-index: 113; left: 650px;
                     position: absolute; top: 6px" Text="Owner:" Font-Size="Larger" Width="106px"></asp:Label>
                 <asp:Label ID="Label6" runat="server" Font-Bold="True" Style="z-index: 114; left: 34px;
                     position: absolute; top: 36px" Text="Name:" Width="84px"></asp:Label>
                 <asp:Label ID="Label8" runat="server" Font-Bold="True" Style="z-index: 115; left: 34px;
                     position: absolute; top: 219px" Text="Name:" Width="116px"></asp:Label>
                 <asp:Label ID="Label9" runat="server" Font-Bold="True" Style="z-index: 116; left: 34px;
                     position: absolute; top: 263px" Text="Phone:"></asp:Label>
                 <asp:Label ID="Label10" runat="server" Font-Bold="True" Style="z-index: 117; left: 34px;
                     position: absolute; top: 242px" Text="Email:" Width="87px"></asp:Label>
                 <asp:Label ID="Label11" runat="server" Font-Bold="True" Style="z-index: 118; left: 34px;
                     position: absolute; top: 112px" Text="Organization:"></asp:Label>
                 <asp:Label ID="Label12" runat="server" Font-Bold="True" Style="z-index: 119; left: 34px;
                     position: absolute; top: 133px" Text="URL:"></asp:Label>
                 <asp:Label ID="Label7" runat="server" Font-Bold="True" Style="z-index: 120; left: 34px;
                     position: absolute; top: 56px" Text="Service WSDL:"></asp:Label>
                 <asp:Label ID="Label3" runat="server" Font-Bold="True" Style="z-index: 121; left: 446px;
                     position: absolute; top: 324px" Text="Abstract:" Font-Size="Larger"></asp:Label>
                 <asp:Label ID="Label4" runat="server" Font-Bold="True" Style="z-index: 122; left: 19px;
                     position: absolute; top: 190px" Text="Contact Info:" Font-Size="Larger" Width="125px"></asp:Label>
                 <asp:Label ID="Label5" runat="server" Font-Bold="True" Style="z-index: 123; left: 19px;
                     position: absolute; top: 92px" Text="Source Info:" Font-Size="Larger" Width="117px"></asp:Label>
                 <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Larger" Style="z-index: 124;
                      left: 443px; position: absolute; top: 199px" Text="Citation:"></asp:Label>  
                   
                           
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                    Text="Update" style="z-index: 125; left: 48px; position: absolute; top: 428px; border-right: black thin solid; border-top: black thin solid; font-weight: bold; vertical-align: middle; border-left: black thin solid; color: blue; border-bottom: black thin solid; background-color: white; text-align: center; text-decoration: none;" Height="21px" Width="69px" TabIndex="8"></asp:LinkButton>
                <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                    Text="Cancel" style="z-index: 126; left: 138px; position: absolute; top: 428px; border-right: black thin solid; border-top: black thin solid; font-weight: bold; vertical-align: middle; border-left: black thin solid; color: blue; border-bottom: black thin solid; background-color: white; text-align: center; text-decoration: none;" Height="21px" Width="69px" TabIndex="9"></asp:LinkButton>
                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("FrequentUpdates") %>' Style="z-index: 128;
                  left: 147px; position: absolute; top: 366px" Text="Batch Update?" />


                </div>
            </EditItemTemplate>
            <InsertItemTemplate>
              <div style="z-index: 100; left: 1px; width: 860px; position: absolute; top: 0px;
                    height: 475px; background-color: #bbbbbb;">
                    
                
                <asp:TextBox ID="ServiceAbsTextBox" runat="server" Text='<%# Bind("ServiceAbs") %>' style="z-index: 101; left: 421px; position: absolute; top: 204px;" Height="258px" TextMode="MultiLine" Width="368px"></asp:TextBox>               
                <asp:TextBox ID="ServiceWSDLTextBox" runat="server" Text='<%# Bind("ServiceWSDL") %>' style="z-index: 100; left: 154px; position: absolute; top: 54px" Width="459px" Height="20px"></asp:TextBox>               
                <asp:TextBox ID="NetworkNameTextBox" runat="server" Text='<%# Bind("NetworkName") %>' style="z-index: 102; left: 154px; position: absolute; top: 28px" Width="459px" Height="20px"></asp:TextBox>                
                <asp:TextBox ID="ContactNameTextBox" runat="server" Text='<%# Bind("ContactName") %>' style="z-index: 103; left: 146px; position: absolute; top: 213px" Height="20px" Width="175px"></asp:TextBox>
                <asp:TextBox ID="ContactEmailTextBox" runat="server" Text='<%# Bind("ContactEmail") %>' style="z-index: 104; left: 146px; position: absolute; top: 240px" Height="20px" Width="175px"></asp:TextBox>
                <asp:TextBox ID="ContactPhoneTextBox" runat="server" Text='<%# Bind("ContactPhone") %>' style="z-index: 105; left: 146px; position: absolute; top: 267px" Height="20px" Width="175px"></asp:TextBox>                               
                <asp:TextBox ID="OrganizationTextBox" runat="server" Text='<%# Bind("Organization") %>' style="z-index: 106; left: 151px; position: absolute; top: 106px" Height="20px" Width="461px"></asp:TextBox>                            
                <asp:TextBox ID="websiteLabel" runat="server" Text='<%# Bind("website") %>' style="z-index: 109; left: 151px; position: absolute; top: 131px" Height="20px" Width="461px"></asp:TextBox>
                
                 <asp:Label ID="Label2" runat="server" Font-Bold="True" Style="z-index: 110; left: 19px;
                     position: absolute; top: 18px" Text="Network:" Font-Size="Larger" Width="106px"></asp:Label>
                 <asp:Label ID="Label6" runat="server" Font-Bold="True" Style="z-index: 111; left: 34px;
                     position: absolute; top: 36px" Text="Name:" Width="84px"></asp:Label>
                 <asp:Label ID="Label8" runat="server" Font-Bold="True" Style="z-index: 112; left: 34px;
                     position: absolute; top: 219px" Text="Name:" Width="116px"></asp:Label>
                 <asp:Label ID="Label9" runat="server" Font-Bold="True" Style="z-index: 113; left: 34px;
                     position: absolute; top: 263px" Text="Phone:"></asp:Label>
                 <asp:Label ID="Label10" runat="server" Font-Bold="True" Style="z-index: 114; left: 34px;
                     position: absolute; top: 242px" Text="Email:" Width="87px"></asp:Label>
                 <asp:Label ID="Label11" runat="server" Font-Bold="True" Style="z-index: 115; left: 34px;
                     position: absolute; top: 112px" Text="Organization:"></asp:Label>
                 <asp:Label ID="Label12" runat="server" Font-Bold="True" Style="z-index: 116; left: 34px;
                     position: absolute; top: 133px" Text="URL:"></asp:Label>
                 <asp:Label ID="Label7" runat="server" Font-Bold="True" Style="z-index: 117; left: 34px;
                     position: absolute; top: 56px" Text="Service WSDL:"></asp:Label>
                 <asp:Label ID="Label3" runat="server" Font-Bold="True" Style="z-index: 118; left: 425px;
                     position: absolute; top: 182px" Text="Abstract:" Font-Size="Larger"></asp:Label>
                 <asp:Label ID="Label4" runat="server" Font-Bold="True" Style="z-index: 119; left: 19px;
                     position: absolute; top: 190px" Text="Contact Info:" Font-Size="Larger" Width="125px"></asp:Label>
                 <asp:Label ID="Label5" runat="server" Font-Bold="True" Style="z-index: 120; left: 19px;
                     position: absolute; top: 92px" Text="Source Info:" Font-Size="Larger" Width="117px"></asp:Label>
                  <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Larger" Style="z-index: 128;
                      left: 443px; position: absolute; top: 199px" Text="Source Citation:"></asp:Label>                     
                           
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                    Text="Update" style="z-index: 121; left: 26px; position: absolute; top: 437px">
                </asp:LinkButton>
                <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                    Text="Cancel" style="z-index: 122; left: 87px; position: absolute; top: 440px">
                </asp:LinkButton>
                
                
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="ContactEmailTextBox"
                         ErrorMessage="Invalid Email" Style="z-index: 123; left: 335px; position: absolute;
                         top: 272px" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="websiteLabel"
                         ErrorMessage="Invalid URL" Style="z-index: 124; left: 624px; position: absolute;
                         top: 133px" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?"></asp:RegularExpressionValidator>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="ContactPhoneTextBox"
                         ErrorMessage="Invalid Phone number" Height="43px" Style="z-index: 126; left: 335px;
                         position: absolute; top: 235px" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"
                         Width="86px"></asp:RegularExpressionValidator>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="NetworkNameTextBox"
                         ErrorMessage="Required Field" Style="z-index: 107; left: 631px; position: absolute;
                         top: 35px"></asp:RequiredFieldValidator>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ServiceWSDLTextBox"
                         ErrorMessage="Required Field" Style="z-index: 108; left: 630px; position: absolute;
                         top: 59px"></asp:RequiredFieldValidator>                               
                </div>
            </InsertItemTemplate>
            <ItemTemplate>
              <div style="z-index: 100; left: 1px; width: 860px; position: absolute; top: 0px;
                    height: 475px; background-color: #b0c4de;">
<asp:Label ID="hiddenUserName" runat="server" Font-Bold="True" Style="z-index: 100; left: 575px;
                     position: absolute; top: 5px" Text='<%# Bind("UserName") %>' Font-Size="Larger" Width="117px"></asp:Label>                                               
                
                <div style="z-index: 129; top:341px; left:340px; position:absolute; width:505px;
                     height: 116px; overflow:auto;">
                     <asp:Label ID="ServiceAbsLabel" runat="server" Text='<%# Bind("ServiceAbs") %>' style="z-index: 101; left: 0px; position: absolute; top: 0px;"></asp:Label>
                 </div>
                <asp:Label ID="ServiceWSDLLabel" runat="server" Text='<%# Bind("ServiceWSDL") %>' style="z-index: 101; left: 154px; position: absolute; top: 54px" Width="459px" Height="20px"></asp:Label>          
                <asp:Label ID="NetworkNameLabel" runat="server" Text='<%# Bind("NetworkName") %>' style="z-index: 102; left: 154px; position: absolute; top: 28px" Width="459px" Height="20px"></asp:Label>                
                <asp:Label ID="ContactNameLabel" runat="server" Text='<%# Bind("ContactName") %>' style="z-index: 103; left: 146px; position: absolute; top: 213px" Height="20px" Width="175px"></asp:Label>
                <asp:Label ID="ContactEmailLabel" runat="server" Text='<%# Bind("ContactEmail") %>' style="z-index: 104; left: 146px; position: absolute; top: 240px" Height="20px" Width="175px"></asp:Label>
                <asp:Label ID="ContactPhoneLabel" runat="server" Text='<%# Bind("ContactPhone") %>' style="z-index: 105; left: 146px; position: absolute; top: 267px" Height="20px" Width="175px"></asp:Label>                               
                <asp:Label ID="OrganizationLabel" runat="server" Text='<%# Bind("Organization") %>' style="z-index: 106; left: 151px; position: absolute; top: 106px" Height="20px" Width="461px"></asp:Label>                            
                <asp:Label ID="websiteLabel" runat="server" Text='<%# Bind("website") %>' style="z-index: 107; left: 151px; position: absolute; top: 131px" Height="20px" Width="461px"></asp:Label>
                <asp:Image ID="OrgIcon" runat="server" ImageUrl='<%# "../getLogo.aspx?name=" +Eval("NetworkName") %>' Style="z-index: 108;
                      left: 631px; position: absolute; top: 40px" Height="100px" Width="100px" />
                <asp:Image ID="MapIcon" runat="server" ImageUrl='<%# "../getIcon.aspx?name=" + Eval("NetworkName") %>' Style="z-index: 109;
                      left: 630px; position: absolute; top: 155px" Height="15px" Width="15px" />
                <asp:Label ID="PublicLabel" runat="server" Style="z-index: 110; left: 147px; position: absolute;
                      top: 290px" Text='<%# (Eval("IsPublic").ToString()=="True")?"Service is public":"Service is private" %>'></asp:Label>
               <asp:Label ID="Label16" runat="server" Style="z-index: 111; left: 148px; position: absolute;
                  top: 312px" Text='<%# (Eval("IsApproved").ToString()=="True")?"Service is approved":"Service is not approved" %>'></asp:Label>                      

                
                 <asp:Label ID="Label2" runat="server" Font-Bold="True" Style="z-index: 112; left: 19px;
                     position: absolute; top: 18px" Text="Data Service:" Font-Size="Larger" Width="106px"></asp:Label>
                 <asp:Label ID="Label6" runat="server" Font-Bold="True" Style="z-index: 113; left: 34px;
                     position: absolute; top: 36px" Text="Name:" Width="84px"></asp:Label>
                 <asp:Label ID="Label8" runat="server" Font-Bold="True" Style="z-index: 114; left: 34px;
                     position: absolute; top: 219px" Text="Name:" Width="116px"></asp:Label>
                 <asp:Label ID="Label9" runat="server" Font-Bold="True" Style="z-index: 115; left: 34px;
                     position: absolute; top: 263px" Text="Phone:"></asp:Label>
                 <asp:Label ID="Label10" runat="server" Font-Bold="True" Style="z-index: 116; left: 34px;
                     position: absolute; top: 242px" Text="Email:" Width="87px"></asp:Label>
                 <asp:Label ID="Label11" runat="server" Font-Bold="True" Style="z-index: 117; left: 34px;
                     position: absolute; top: 112px" Text="Organization:"></asp:Label>
                 <asp:Label ID="Label12" runat="server" Font-Bold="True" Style="z-index: 118; left: 34px;
                     position: absolute; top: 133px" Text="URL:"></asp:Label>
                 <asp:Label ID="Label7" runat="server" Font-Bold="True" Style="z-index: 119; left: 34px;
                     position: absolute; top: 56px" Text="Service WSDL:"></asp:Label>
                 <asp:Label ID="Label3" runat="server" Font-Bold="True" Style="z-index: 120; left: 342px;
                     position: absolute; top: 324px" Text="Abstract:" Font-Size="Larger"></asp:Label>
                 <asp:Label ID="Label4" runat="server" Font-Bold="True" Style="z-index: 121; left: 19px;
                     position: absolute; top: 190px" Text="Contact Info:" Font-Size="Larger" Width="125px"></asp:Label>
                 <asp:Label ID="Label5" runat="server" Font-Bold="True" Style="z-index: 122; left: 19px;
                     position: absolute; top: 92px" Text="Source Info:" Font-Size="Larger" Width="117px"></asp:Label>
                  <div style="z-index: 128; left: 339px; overflow: auto; width: 505px; position: absolute;
                      top: 215px; height: 106px">
                <asp:Label ID="CitationLabel" runat="server" Text='<%# Bind("citation") %>' style="z-index: 100; left: 0px; position: absolute; top: 0px" Height="20px" TabIndex="3"></asp:Label>
                  </div>
                  <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Size="Larger" Style="z-index: 123;
                      left: 338px; position: absolute; top: 198px" Text="Citation:"></asp:Label>
                                 
                <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                    Text="Edit" style="z-index: 124; left: 22px; position: absolute; top: 430px; border-right: black thin solid; border-top: black thin solid; font-weight: bold; border-left: black thin solid; color: blue; border-bottom: black thin solid; background-color: white; text-align: center; text-decoration: none;" Height="19px" Width="78px"></asp:LinkButton>
                &nbsp; &nbsp;
                <asp:Label ID="Label14" runat="server" Font-Bold="True" Style="z-index: 125; left: 36px;
                  position: absolute; top: 336px" Text="LastHarvested:"></asp:Label>
                <asp:Label ID="lblHarvestDate" runat="server" Style="z-index: 126; left: 147px; position: absolute;
                  top: 339px" Text='<%# Bind("LastHarvested") %>'></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblBatchHarvested" runat="server" Style="z-index: 130; left: 150px;
                  position: absolute; top: 369px" Text='<%# (Eval("FrequentUpdates").ToString()=="True")? "Service is batch harvested":"Service is NOT batch harvested" %>'></asp:Label>




                </div>
            </ItemTemplate>
        </asp:FormView>
          <asp:LinkButton ID="btnStats" runat="server" CausesValidation="True" CommandName="Update"
            Height="21px" OnClick="btnStats_Click" Style="border-right: black thin solid; border-top: black thin solid;
            font-weight: bold; z-index: 100; left: 233px; vertical-align: middle; border-left: black thin solid;
            color: blue; border-bottom: black thin solid; position: absolute; top: 429px; background-color: white;
            text-align: center; text-decoration: none" TabIndex="8" Text="Stats" Width="69px"></asp:LinkButton>
        </div>
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" Style="z-index: 100;
            left: 23px; position: absolute; top: 160px" Text="Data Service Details:" Width="225px"></asp:Label>
      <asp:DropDownList ID="ddlUsers" runat="server" Style="z-index: 101; left: 670px;
        position: absolute; top: 176px" Width="179px" OnPreRender="ddlUsers_PreRender">
      </asp:DropDownList><asp:LinkButton ID="btnHarvest" runat="server" CausesValidation="True" CommandName="Update"
                    Text="Harvest" style="z-index: 102; left: 245px; position: absolute; top: 634px; border-right: black thin solid; border-top: black thin solid; font-weight: bold; vertical-align: middle; border-left: black thin solid; color: blue; border-bottom: black thin solid; background-color: white; text-align: center; text-decoration: none;" Height="21px" Width="69px" TabIndex="8" OnClick="btnHarvest_Click"></asp:LinkButton>
      <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
        Height="21px" OnClick="btnHarvest_Click" Style="border-right: black thin solid;
        border-top: black thin solid; font-weight: bold; z-index: 103; left: 233px; vertical-align: middle;
        border-left: black thin solid; color: blue; border-bottom: black thin solid; position: absolute;
        top: 630px; background-color: white; text-align: center; text-decoration: none"
        TabIndex="8" Text="Harvest" Width="69px"></asp:LinkButton>
      <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="True" CommandName="Update"
        Height="21px" OnClick="btnHarvest_Click" Style="border-right: black thin solid;
        border-top: black thin solid; font-weight: bold; z-index: 104; left: 232px; vertical-align: middle;
        border-left: black thin solid; color: blue; border-bottom: black thin solid; position: absolute;
        top: 616px; background-color: white; text-align: center; text-decoration: none"
        TabIndex="8" Text="Harvest" Width="69px"></asp:LinkButton>
      <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="True" CommandName="Update"
        Height="21px" OnClick="btnHarvest_Click" Style="border-right: black thin solid;
        border-top: black thin solid; font-weight: bold; z-index: 107; left: 161px; vertical-align: middle;
        border-left: black thin solid; color: blue; border-bottom: black thin solid; position: absolute;
        top: 628px; background-color: white; text-align: center; text-decoration: none"
        TabIndex="8" Text="Harvest" Width="69px"></asp:LinkButton>
      <uc2:HeaderControl ID="HeaderControl1" runat="server" />
<% if (Page.User.IsInRole("Administrator") || Page.User.Identity.Name == ((System.Data.DataRowView) this.FormView1.DataItem).Row[0].ToString()){ %>

<% } %>       
               
    </form>
</body>
</html>
