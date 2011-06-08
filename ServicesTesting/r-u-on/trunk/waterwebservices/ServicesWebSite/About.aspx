<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="ServicesWebSite.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 286px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Monitors RSS URL&#39;s</h2>
    <div>
    <p>The unprocessed RSS newsfeeds can be found at the following URL's</p>
        <table style="width: 100%;">
            <tr>
                <td class="style1">
                    &nbsp;
                    Monitor</td>
                <td>
                    &nbsp;
                    Rss</td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1" style="border-width: thin">
                    Webservices Active Alerts<br />
                    for Public Websevices Listed in HIS Central<br />
                    Run once per hour</td>
                <td>
                    &nbsp;http://rss.r-u-on.com/rssalarmhistory?id=AAAABIESfWjQAAADDrFZJTSn&amp;criteria=CuahsiServicesActive</td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1" style="border-width: thin">
                    Webservice History (Past 7 Days)<br />
                    for Public Websevices Listed in HIS Central</td>
                <td>
                    &nbsp;http://rss.r-u-on.com/rssalarmhistory?id=AAAABIESfWjQAAADDrFZJTSn&amp;criteria=CuahsiServices&amp;reverse</td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1" style="border-width: thin">
                    HisCentral Service Monitor</td>
                <td>
                    http://rss.r-u-on.com/rssalarmhistory?id=AAAABIESfWjQAAADDrFZJTSn&amp;criteria=HisCentral&amp;reverse</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" style="border-width: thin">
                    &nbsp;Webservices Active Alerts
                    <br />
                    for SDSC Hosted Services<br />
                    run Every 5 minutes</td>
                <td>
                    http://rss.r-u-on.com/rssalarmhistory?id=AAAABIESfWjQAAADDrFZJTSn&amp;criteria=SDSCWaterWebServicesActive</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" style="border-width: thin">
                    Webservice History (Past 7 Days)
                    <br />
                    for SDSC Hosted Services<br />
                    Includes alerts from site that the services are dependent upon</td>
                <td>
                    http://rss.r-u-on.com/rssalarmhistory?id=AAAABIESfWjQAAADDrFZJTSn&amp;criteria=SDSCWaterWebServices&amp;reverse</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
         <p>The public HIS monitors can take 20 minutes to run though all 60+ services. We do 
             not monitor the sites in near real time.</p>
        <p>The SDSC monitors the services is provides, as well as the external services that&nbsp; 
            these services are dependent upon. We also have monitors with CPU and disk 
            space, the you do not see.</p>
    </div>
</asp:Content>
