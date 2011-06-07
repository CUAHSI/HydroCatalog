<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pub_network.aspx.cs" Inherits="public_network" %>

<%@ Register Src="HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CUAHSI HIS Central</title>
  <link href="styles/his.css" rel="stylesheet" type="text/css" />
      <script type="text/javascript" src="http://dev.virtualearth.net/mapcontrol/mapcontrol.ashx?v=6.2"></script>
      <script type="text/javascript">
      
      var map = null;
      var xmin, xmax, ymin, ymax;      
      function getMap()
      {
         map = new VEMap('myMap');
         if (xmax && xmin && ymax && ymin){
           var x = (xmax+xmin)/2;
           var y = (ymax+ymin)/2;
           
           var ll = new VELatLong(y,x);
           //alert(x +","+y);
           map.SetDashboardSize(VEDashboardSize.Small);
           zoom  = getZoom(xmin,xmax,ymin,ymax);
           //alert (zoom); 
           map.LoadMap(ll, zoom ,'h' ,false);
    
         
           //alert(); 
           addShape(xmin,xmax,ymin,ymax);//",10);
         }else{
           map.LoadMap();
         }
         
      }
      
      function getZoom(x1,x2,y1,y2){
        if (x1!=x2 && y1!=y2){
          w = (x2 - x1) > (y2 - y1) ? x2 - x1 : y2 - y1; 
          //alert (w);
          if (w > 60){
            return 2;          
          }else if (w > 28){
            return 3;
          }else if (w > 14){
            return 4;
          }else if (w > 7){
            return 5;
          }else if (w > 3.5){
            return 4;
          }else if (w >1.8){
            return 7;
          }else if (w > 0.9){
            return 8;
          }else if (w > 0.5){            
            return 9;        
          }else if (w > 0.2){
            return 10;                                                  
          }else if (w > 0.11){
            return 11;
          }else if (w > 0.05){
            return 12;
          }else{
            return 10;                          
          }
          
        }else{
          return 10;
        }
      }
      
      function addShape(x1,x2,y1,y2){
        if (x1!=x2 && y1!=y2){
            //alert(x1 +","+y1+"  "+x2+","+y2);
            try{
                var p1 = new VELatLong(y1,x1);
                var p2 = new VELatLong(y1,x2);
                var p3 = new VELatLong(y2,x2);
                var p4 = new VELatLong(y2,x1);
                zbshape = new VEShape(VEShapeType.Polygon,new Array(p1,p2,p3,p4)); 
                zbshape.SetLineWidth(1);
                zbshape.SetLineColor(new VEColor(255,100,100,1.0));
                zbshape.SetFillColor(new VEColor(255,255,255,0.8)); 
                zbshape.HideIcon();          
                map.AddShape(zbshape);
            }catch(er){
                status = "exception: addzbshape: " + er.message;
                alert(status);
            }
        }
    }  
      </script>
      

  <link href="styles/his.css" rel="stylesheet" type="text/css" />
  <link href="styles/his.css" rel="stylesheet" type="text/css" />
  <link href="styles/his.css" rel="stylesheet" type="text/css" />
  <link href="styles/his.css" rel="stylesheet" type="text/css" />
  <link href="styles/his.css" rel="stylesheet" type="text/css" />


</head>
<body>
    <form id="form1" runat="server">
    <div></div>    
        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CentralHISConnectionString %>"
            SelectCommand="SELECT username, ServiceWSDL, ServiceAbs, NetworkName, ContactName, ContactEmail, ContactPhone, Organization, website, IsPublic, SupportsAllMethods, Citation, MapIconPath, OrgIconPath, LastHarvested,FrequentUpdates, Xmin, Xmax, Ymin, Ymax, ValueCount, VariableCount, SiteCount, EarliestRec, LatestRec, ServiceStatus, ProjectStatus, NetworkTitle, NetworkID, CreatedDate FROM HISNetworks WHERE (NetworkID = @NetworkID)" 
            InsertCommand="INSERT INTO HISNetworks(username, NetworkName, ServiceAbs, ServiceWSDL, ContactEmail, ContactName, ContactPhone, Organization, website) VALUES (,,,,,,,,) " 
            UpdateCommand="UPDATE HISNetworks SET NetworkName= @NetworkName, ServiceWSDL =@ServiceWSDL, ServiceAbs =@ServiceAbs, ContactName =@ContactName, ContactEmail =@ContactEmail, ContactPhone =@ContactPhone, Organization =@Organization, website =@website, Citation =@Citation, isPublic=@IsPublic WHERE [NetworkID] = @NetworkID">
            <SelectParameters>
              <asp:QueryStringParameter Name="NetworkID" QueryStringField="n" Type="Int32" />
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
                
                <asp:SessionParameter Name="NetworkID" SessionField="NetworkID" Type="Int32" />               
            </UpdateParameters>

        </asp:SqlDataSource>

        <uc1:HeaderControl ID="HeaderControl1" runat="server" />
     

 
                <asp:Label ID="lblServiceWSDLLabel" runat="server"  style="z-index: 100; left: 127px; position: absolute; top: 227px" Width="439px" Height="20px" Font-Italic="True" Font-Size="Small"></asp:Label>          
                <asp:Label ID="lblNetworkNameLabel" runat="server"  style="z-index: 101; left: 124px; position: absolute; top: 202px" Width="446px" Height="20px" Font-Bold="True" Font-Size="Small"></asp:Label>                
                <asp:Label ID="lblContactNameLabel" runat="server"  style="z-index: 102; left: 221px; position: absolute; top: 254px" Height="20px" Width="311px" Font-Size="Small"></asp:Label>
                <asp:Label ID="lblContactEmailLabel" runat="server"  style="z-index: 103; left: 221px; position: absolute; top: 276px" Height="20px" Width="311px" Font-Size="Small"></asp:Label>
                <asp:Label ID="lblContactPhoneLabel" runat="server" style="z-index: 104; left: 221px; position: absolute; top: 298px" Height="20px" Width="311px" Font-Size="Small"></asp:Label>                               
                   <asp:Label ID="lblSiteCount" runat="server" Font-Size="Small" Height="20px" Style="z-index: 105;
                     left: 92px; position: absolute; top: 348px" Width="105px"></asp:Label>
                   <asp:Label ID="lblVariableCount" runat="server" Font-Size="Small" Height="20px" Style="z-index: 106;
                     left: 92px; position: absolute; top: 366px" Width="105px"></asp:Label>
                   <asp:Label ID="lblValueCount" runat="server" Font-Size="Small" Height="20px" Style="z-index: 107;
                     left: 92px; position: absolute; top: 386px" Width="105px"></asp:Label>
                   <asp:Label ID="lblLastHarvested" runat="server" Font-Size="Small" Height="20px" Style="z-index: 107;
                     left: 92px; position: absolute; top: 416px" Width="300px"></asp:Label>                     
                <asp:Label ID="lblOrganizationLabel" runat="server"  style="z-index: 108; left: 124px; position: absolute; top: 177px" Height="20px" Width="670px" Font-Bold="True" Font-Size="Large"></asp:Label>                            
                
                
                
                
 
                      
               <asp:Image ID="imgLogo" runat="server" Height="100px" 
                      ImageUrl="getLogo.aspx" 
                      Style="z-index: 109; left: 13px; position: absolute; top: 177px" Width="100px" />
               <asp:Image ID="imgIcon" runat="server"  
                      ImageUrl="getIcon.aspx"
                      Style="z-index: 110;left: 10px; position: absolute; top: 142px" Height="24px" Width="24px" />             &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                 <asp:Label ID="Label4" runat="server" Font-Bold="True" Style="z-index: 111; left: 141px;
                     position: absolute; top: 254px" Text="Contact:" Font-Size="Small" Width="67px"></asp:Label>
                &nbsp; &nbsp; &nbsp;&nbsp;
                   <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" Style="z-index: 112;
                     left: 20px; position: absolute; top: 350px" Text="Sites:" Width="67px"></asp:Label>
                   <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" Style="z-index: 113;
                     left: 20px; position: absolute; top: 390px" Text="Values:" Width="67px"></asp:Label>
                   <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Small" Style="z-index: 114;
                     left: 20px; position: absolute; top: 370px" Text="Variables:" Width="67px"></asp:Label>
                   <asp:Label ID="lblNorth" runat="server" Font-Size="X-Small" Style="z-index: 115;
                     left: 471px; position: absolute; top: 363px"></asp:Label>
                   <asp:Label ID="lblEast" runat="server" Font-Size="X-Small" Style="z-index: 116; left: 530px;
                     position: absolute; top: 379px"></asp:Label>
                   <asp:Label ID="lblWest" runat="server" Font-Size="X-Small" Style="z-index: 117; left: 418px;
                     position: absolute; top: 379px"></asp:Label>
                   <asp:Label ID="lblSouth" runat="server" Font-Size="X-Small" Style="z-index: 118; left: 472px;
                     position: absolute; top: 397px"></asp:Label>
                   <h3 Style="left: 16px; position: absolute; top: 302px; width:525px; z-index: 119;" >
                     Service Statistics:</h3>


      <asp:LinkButton ID="lnkEdit" runat="server" Font-Bold="True" PostBackUrl="network.aspx"
        Style="z-index: 120; left: 790px; position: absolute; top: 149px" Visible="False"
        Width="163px">Edit Service Details</asp:LinkButton>
                          <div id='myMap' style="position:relative; z-index:125; width:368px; height:329px; left: 592px; top: 196px;"></div>
      <asp:Label ID="lblNetworkTitle" runat="server" Font-Bold="True" Font-Size="X-Large" Height="20px"
        Style="z-index: 121; left: 42px; position: absolute; top: 142px" Width="740px"></asp:Label>
      <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Small" Style="z-index: 126;
        left: 306px; position: absolute; top: 351px" Text="Geographic Extent:" Width="127px"></asp:Label>
               
    </form>
    <script type="text/javascript">
    getMap();
    
    </script>

  <asp:Panel ID="pnlLinks" runat="server" Style="z-index: 123; left: 591px;
    position: absolute; top: 580px" Width="361px">
    <asp:Literal ID="litCit_Pubs" runat="server"></asp:Literal></asp:Panel>
  <asp:Panel ID="pnlDesc" runat="server" Height="50px" Style="z-index: 124; left: 15px;
    position: absolute; top: 427px" Width="551px">
    <asp:Literal ID="litDesc" runat="server"></asp:Literal></asp:Panel>
</body>
</html>
