<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="WaterMl2.aspx.cs" Inherits="GenericWebservice.WaterMl2" %>

<%@ Register TagPrefix="wml" TagName="WmlUrl" Src="~/UserControls/TestRestUrl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <!-- jquery in master -->
    <!--  <script type="text/javascript" src="scripts/jquery-1.6.min.js"></script>-->
    <script type="text/javascript">
    var networkCode = "<%= ConfigurationManager.AppSettings["Network"] %>" ;
    var vocabularyCode =  "<%= ConfigurationManager.AppSettings["Vocabulary"] %>" ;
    var SoapPage = null;
 var baseUrl ="REST/waterml_2.svc/" ;
var siteMethod="featureOfInterest";
   var valuesMethod="values";
   var  variableMethod="observedProperty";

        $(document).ready(function () //executes this code when page loading is done
        {
            getSites( baseUrl, siteMethod );
            getSeries(baseUrl, valuesMethod );
              $('#loading').fadeOut();
        });
    </script>
    <script type="text/javascript" src="scripts/ExampleWaterMlLinks.js" >
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="Container">
        <div id="Content">
            <!-- URL entry part -->
            <wml:WmlUrl ID="wml2url" runat="server" BaseUrl="REST/waterml_2.svc/" siteMethod="featureOfInterest"
                valuesMethod="values" variableMethod="observedProperty" />
            <p>
                This is a return timeseries in WaterML 2 format, with links to associated information.
            </p>
            <ul>
                <li><b>Timeseries/Values</b> http://{HOST}:{PORT}/{SERVICENAME}/REST/waterml_2.svc/values?location={WOF.SiteCode}&variable={WOF.VariableCode}&startDate={StartDate}&endDate={EndDate}
                </li>
                <li><b>Site</b> http://{HOST}:{PORT}/{SERVICENAME}/REST/waterml_2.svc/featureOfInterest?location={WOF.SiteCode}
                </li>
                <li><b>Variable</b> http://{HOST}:{PORT}/{SERVICENAME}/REST/waterml_2.svc/observedProperty?variable={WOF.VariableCode}
                </li>
            </ul>
        </div>
        <div id="loading" class="loading">
            loading
        </div>

                <h2>
                    Sites</h2>
       
        <div id="RSSBlock">
            <div id="RSSContent" class="urlLists">
            </div>
        </div>


                <h2>Variables</h2>

        
        <div id="VariablesBlock">
            <div id="VariablesContent" class="urlLists">
            </div>
        </div>

                <h2>
                    Values/Timeseries</h2>

        <div id="SeriesBlock">
            <div id="SeriesContent" class="urlLists">
            </div>
        </div>
    </div>
</asp:Content>
