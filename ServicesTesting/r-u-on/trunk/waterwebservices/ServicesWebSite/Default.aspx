﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ServicesWebSite._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Cuahsi Service Monitor Feeds
    </h2>
    <p>
        This site provides information about the status of the Public CUAHSI 
        WateroneFlow services listed in HisCental. </p>
    <p>
    
        There are two presentations of information from the monitoring services.
    
    <p>
    
        First is a set of listing the status of the public services.<br />
       <ul> <li >All Services (<asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/PublicServicesStatus.aspx">html</asp:HyperLink>
        ,
        <asp:HyperLink ID="HyperLink2" runat="server" 
            NavigateUrl="~/services/WebServiceMonitor.svc/PublicServicesStatus">XML</asp:HyperLink>
           ,
           <asp:HyperLink ID="HyperLink4" runat="server" 
               NavigateUrl="~/services/WebServiceMonitor.svc/help">WCF Rest Help Page</asp:HyperLink>
&nbsp;)<br /></li>
      <li >  Statistics 
          <asp:HyperLink ID="HyperLink3" runat="server" 
              NavigateUrl="~/PublicServiceStatistics.aspx">html</asp:HyperLink>
           </li>
 </ul>
    <p>
    
        Second is a set from the r-u-on.com rss feeds.<ul>
  <li class="active"> Red are active Alerts</li> 
    <li class="disable"> Olive are Alerts that being filtered (disabled).</li> 
    <li class="historic"> Green are Alerts that have cleared.</li> 
    </ul>
      &nbsp;</p>
        <p>
       These pages are rss feeds rendered to HTML from a monitoring service    <a href="http://www.r-u-on.com/">r-u-on.com</a>. (for small sites can use it for free).
         There are serveral custom monitors to monitor the web services that report to R-U-On: 
          <li>
  <ul >WaterServices to Monitor the public services listed in His Central</ul> 
    <ul >His Central to Monitor the HIS Central Web Service</ul> 
    <ul > SDSC WaterServices to monitor the SDSC hosted services. This feed also lists alerts raised by the dependencies.</ul> 
    </li>. </p>
    <p>
</asp:Content>
