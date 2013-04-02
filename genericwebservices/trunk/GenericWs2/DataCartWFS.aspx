<%@ Page Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="DataCartWFS.aspx.cs" Inherits="GenericWebservice.DataCartWFS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="Container">
        <div id="Content">
    <div>
    
        The Observation Data Series are served as Simple GML over the OpenGeospatial Consortium Web Feature Service (WFS)<br />
&nbsp;</div>
   <ul>
   <li>GetCapabilties <a href="wfs/datacart.ashx?Service=WFS&request=GetCapabilities">http://{host}:{port}/{path}wfs/datacart.wfs?Service=WFS&request=GetCapabilities</a></li>
     <li>DescribeFeatureType <a href="wfs/datacart.ashx?Service=WFS&request=DescribeFeatureType">http://{host}:{port}/{path}wfs/datacart.wfs?Service=WFS&request=DescribeFeatureType</a></li>
   <li>GetFeature (for all features) <a href="wfs/datacart.ashx?Service=WFS&request=GetFeature">http://{host}:{port}/{path}wfs/datacart.wfs?Service=WFS&request=GetFeature </a></li>
 <li>GetFeature with a box query http://{host}:{port}/{path}wfs/datacart.ashx?Service=WFS&request=GetFeature?BBOX=W,S,W,N </a></li>
   </ul>
       </div>
    </div>
</asp:Content>
