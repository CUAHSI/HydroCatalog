<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addnetwork.aspx.cs" Inherits="addnetwork" %>

<%@ Register Src="HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CUAHSI HIS Central</title>
  <link href="styles/his.css" rel="stylesheet" type="text/css" />
  <link href="styles/his.css" rel="stylesheet" type="text/css" />
  <link href="styles/his.css" rel="stylesheet" type="text/css" />
  <link href="styles/his.css" rel="stylesheet" type="text/css" />

</head>
<body alink="#c0a">
    <form id="form1" runat="server">
   <div>

                <asp:TextBox ID="txtNetworkTitle" runat="server" Style="z-index: 100; left: 253px; position: absolute; top: 227px" Width="459px" Height="20px" TabIndex="1"></asp:TextBox>          
                <asp:TextBox ID="txtServiceWSDL" runat="server" style="z-index: 101; left: 253px; position: absolute;top: 367px" Width="459px" Height="20px" TabIndex="3"></asp:TextBox>               
                <asp:TextBox ID="txtNetworkName" runat="server"  style="z-index: 102; left: 249px; position: absolute; top: 292px" Width="459px" Height="20px" TabIndex="2"></asp:TextBox>                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        
        
        <asp:Label ID="Label6" runat="server" Font-Bold="True" Style="z-index: 103; left: 129px;
          position: absolute; top: 298px" Text="Network Name:" Width="122px"></asp:Label>
                 <asp:Label ID="Label2" runat="server" Font-Bold="True" Style="z-index: 104; left: 140px;
                     position: absolute; top: 235px" Text="Service Title:" Width="111px"></asp:Label>
        &nbsp; &nbsp; &nbsp;
                 <asp:Label ID="Label7" runat="server" Font-Bold="True" Style="z-index: 105; left: 136px;
                     position: absolute; top: 373px" Text="Service WSDL:"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
          <asp:LinkButton ID="SubmitButton" runat="server" CausesValidation="True" CommandName="Update"
              Height="21px" OnClick="SubmitButton_Click" Style="border-right: black thin solid;
              border-top: black thin solid; font-weight: bold; z-index: 106; left: 529px; vertical-align: middle;
              border-left: black thin solid; color: blue; border-bottom: black thin solid;
              position: absolute; top: 541px; background-color: white; text-align: center;
              text-decoration: none" Text="Next >>" Width="69px" TabIndex="11"></asp:LinkButton>
     &nbsp;

        <input id="chkAccept" type="checkbox"  Style="z-index: 112; left: 236px;
          position: absolute; top: 506px"  onclick="javascript:document.getElementById('SubmitButton').disabled = !this.checked" tabindex="11" checked="CHECKED" />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://his.cuahsi.org/documents/Data Policies Draftv2.pdf"
          Style="z-index: 107; left: 270px; position: absolute; top: 511px" Font-Bold="True" Target="_blank" TabIndex="-1">I have read and agree to the Data Service Agreement</asp:HyperLink>
        &nbsp;


              
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CentralHISConnectionString %>"           
            InsertCommand="INSERT INTO HISNetworks(username, NetworkTitle, NetworkName, ServiceWSDL, IsPublic, CreatedDate, IsApproved, FrequentUpdates, ServiceGroup) VALUES (@username, @NetworkTitle, @NetworkName, @ServiceWSDL, @IsPublic, @CreatedDate, @IsApproved, 'true', @ServiceGroup)">


        </asp:SqlDataSource>   
       <uc1:HeaderControl ID="HeaderControl1" runat="server" />
       <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" Style="z-index: 108;
           left: 26px; position: absolute; top: 165px" Text="Register Data Service" Width="225px"></asp:Label>
     <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Small"
       ForeColor="Black" Style="z-index: 109; left: 271px; position: absolute; top: 257px"
       Text="This will appear atop the page associated with your service." Width="603px"></asp:Label>
     <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Small"
       ForeColor="Black" Style="z-index: 110; left: 269px; position: absolute; top: 325px"
       Text="This is a unique code associated with your service.  The network name used when configuring your webservice is appropriate.  This value is unique across this system."
       Width="603px"></asp:Label>
     <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Small"
       ForeColor="Black" Style="z-index: 113; left: 270px; position: absolute; top: 406px"
       Text="Enter the full web URL to your webservice WSDL.  This value is unique across this system."
       Width="603px"></asp:Label>
    </div>
    </form>
</body>
</html>
