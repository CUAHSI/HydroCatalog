<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addnetwork_old.aspx.cs" Inherits="addnetwork" %>

<%@ Register Src="HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CUAHSI HIS Central</title>
  <link href="styles/his.css" rel="stylesheet" type="text/css" />
  <link href="styles/his.css" rel="stylesheet" type="text/css" />
  <link href="styles/his.css" rel="stylesheet" type="text/css" />

</head>
<body alink="#c0a">
    <form id="form1" runat="server">
   <div>
      <div style="z-index: 100; left: 15px; width: 797px; position: absolute; top: 200px;
                    height: 455px; background-color: #b0c4de;">
                <asp:TextBox ID="txtNetworkTitle" runat="server" Style="z-index: 130; left: 143px; position: absolute; top: 22px" Width="459px" Height="20px" TabIndex="1"></asp:TextBox>          
                <asp:TextBox ID="txtServiceWSDL" runat="server" style="z-index: 100; left: 143px; position: absolute;top: 76px" Width="459px" Height="20px" TabIndex="3"></asp:TextBox>               
                <asp:TextBox ID="txtNetworkName" runat="server"  style="z-index: 101; left: 143px; position: absolute; top: 50px" Width="459px" Height="20px" TabIndex="2"></asp:TextBox>                &nbsp;
                <asp:TextBox ID="txtContactName" runat="server"  style="z-index: 102; left: 143px; position: absolute; top: 243px" Height="20px" Width="175px" TabIndex="6"></asp:TextBox>
                <asp:TextBox ID="txtContactEmail" runat="server" style="z-index: 103; left: 143px; position: absolute; top: 270px" Height="20px" Width="175px" TabIndex="7"></asp:TextBox>
                <asp:TextBox ID="txtContactPhone" runat="server"  style="z-index: 104; left: 143px; position: absolute; top: 297px" Height="20px" Width="175px" TabIndex="8"></asp:TextBox>                               
                <asp:TextBox ID="txtOrganization" runat="server"  style="z-index: 105; left: 143px; position: absolute; top: 123px" Height="20px" Width="461px" TabIndex="4"></asp:TextBox>                            
                <asp:TextBox ID="txtwebsite" runat="server"  style="z-index: 106; left: 143px; position: absolute; top: 150px" Height="20px" Width="461px" TabIndex="5"></asp:TextBox>
                <asp:TextBox ID="CitationTextBox" runat="server"  style="z-index: 107; left: 449px; position: absolute; top: 225px" Height="85px" Width="320px" TabIndex="9" TextMode="MultiLine"></asp:TextBox>
        
        
        <asp:Label ID="Label6" runat="server" Font-Bold="True" Style="z-index: 108; left: 53px;
          position: absolute; top: 55px" Text="Vocabulary:" Width="84px"></asp:Label>
                 <asp:Label ID="Label2" runat="server" Font-Bold="True" Style="z-index: 109; left: 46px;
                     position: absolute; top: 26px" Text="Service Title:" Width="111px"></asp:Label>
                 <asp:Label ID="Label8" runat="server" Font-Bold="True" Style="z-index: 110; left: 31px;
                     position: absolute; top: 249px" Text="Name:" Width="116px"></asp:Label>
                 <asp:Label ID="Label9" runat="server" Font-Bold="True" Style="z-index: 111; left: 31px;
                     position: absolute; top: 293px" Text="Phone:"></asp:Label>
                 <asp:Label ID="Label10" runat="server" Font-Bold="True" Style="z-index: 112; left: 31px;
                     position: absolute; top: 272px" Text="Email:" Width="87px"></asp:Label>
                 <asp:Label ID="Label11" runat="server" Font-Bold="True" Style="z-index: 113; left: 37px;
                     position: absolute; top: 133px" Text="Organization:"></asp:Label>
                 <asp:Label ID="Label12" runat="server" Font-Bold="True" Style="z-index: 114; left: 39px;
                     position: absolute; top: 155px" Text="URL:"></asp:Label>
                 <asp:Label ID="Label7" runat="server" Font-Bold="True" Style="z-index: 115; left: 33px;
                     position: absolute; top: 80px" Text="Service WSDL:"></asp:Label>
                 <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Larger" Style="z-index: 116;
                      left: 443px; position: absolute; top: 199px" Text="Citation:"></asp:Label>  
                 <asp:Label ID="Label4" runat="server" Font-Bold="True" Style="z-index: 117; left: 16px;
                     position: absolute; top: 220px" Text="Contact Info:" Font-Size="Larger" Width="125px"></asp:Label>
                 <asp:Label ID="Label5" runat="server" Font-Bold="True" Style="z-index: 118; left: 22px;
                     position: absolute; top: 109px" Text="Source Info:" Font-Size="Larger" Width="117px"></asp:Label>
                
                
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtContactEmail"
                         ErrorMessage="Invalid Email" Style="z-index: 119; left: 336px; position: absolute;
                         top: 276px" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtwebsite"
                         ErrorMessage="Invalid URL" Style="z-index: 120; left: 624px; position: absolute;
                         top: 133px" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?"></asp:RegularExpressionValidator>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtContactPhone"
                         ErrorMessage="(888) 123-4567" Height="44px" Style="z-index: 121; left: 337px;
                         position: absolute; top: 301px" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"
                         Width="110px"></asp:RegularExpressionValidator>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNetworkName"
                         ErrorMessage="Required Field" Style="z-index: 122; left: 634px; position: absolute;
                         top: 54px"></asp:RequiredFieldValidator>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtServiceWSDL"
                         ErrorMessage="Required Field" Style="z-index: 123; left: 634px; position: absolute;
                         top: 84px"></asp:RequiredFieldValidator>                               
          <asp:LinkButton ID="SubmitButton" runat="server" CausesValidation="True" CommandName="Update"
              Height="21px" OnClick="SubmitButton_Click" Style="border-right: black thin solid;
              border-top: black thin solid; font-weight: bold; z-index: 124; left: 60px; vertical-align: middle;
              border-left: black thin solid; color: blue; border-bottom: black thin solid;
              position: absolute; top: 397px; background-color: white; text-align: center;
              text-decoration: none" Text="Submit" Width="69px" TabIndex="11"></asp:LinkButton>
          <asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
              Height="21px" OnClick="InsertCancelButton_Click" Style="border-right: black thin solid;
              border-top: black thin solid; font-weight: bold; z-index: 125; left: 150px; vertical-align: middle;
              border-left: black thin solid; color: blue; border-bottom: black thin solid;
              position: absolute; top: 398px; background-color: white; text-align: center;
              text-decoration: none" Text="Cancel" Width="69px" TabIndex="12"></asp:LinkButton>

        <input id="chkAccept" type="checkbox"  Style="z-index: 129; left: 21px;
          position: absolute; top: 353px"  onclick="javascript:document.getElementById('SubmitButton').disabled = !this.checked" tabindex="11" />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://his.cuahsi.org/documents/Data Policies Draftv2.pdf"
          Style="z-index: 126; left: 50px; position: absolute; top: 359px" Font-Bold="True" Target="_blank" TabIndex="-1">I have read and agree to the Data Service Agreement</asp:HyperLink>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNetworkTitle"
          ErrorMessage="Required Field" Style="z-index: 127; left: 637px; position: absolute;
          top: 28px"></asp:RequiredFieldValidator>


                </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CentralHISConnectionString %>"           
            InsertCommand="INSERT INTO HISNetworks(username, NetworkTitle, NetworkName, ServiceWSDL, ContactEmail, ContactName, ContactPhone, Organization, website,Citation,IsPublic,CreatedDate,IsApproved,FrequentUpdates) 
                                       VALUES (@username,@NetworkTitle,@NetworkName,@ServiceWSDL,@ContactEmail,@ContactName,@ContactPhone,@Organization,@website,@Citation,@IsPublic,@CreatedDate, @IsApproved, 'true')">


        </asp:SqlDataSource>   
       <uc1:HeaderControl ID="HeaderControl1" runat="server" />
       <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" Style="z-index: 101;
           left: 26px; position: absolute; top: 165px" Text="Register Data Service" Width="225px"></asp:Label>
    </div>
    </form>
</body>
</html>
