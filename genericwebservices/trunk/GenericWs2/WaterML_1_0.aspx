<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WaterML_1_0.aspx.cs" Inherits="GenericWebservice.WaterML_1_0" %>
<%@ Register TagPrefix="wml" TagName="WmlUrl" Src="~/UserControls/TestRestUrl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
 <script type="text/javascript" src="http://ajax.aspnetcdn.com/ajax/jquery/jquery-1.6.js"></script>  
    <script type="text/javascript" src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.10/jquery-ui.js"></script>  
        <script type="text/javascript">
    var networkCode = "<%= ConfigurationManager.AppSettings["Network"] %>" ;
    var vocabularyCode =  "<%= ConfigurationManager.AppSettings["Vocabulary"] %>" ;
   var  SoapPage="cuahsi_1_0.asmx";
 var baseUrl ="REST/waterml_1_0.svc/" ;
var siteMethod="series";
   var valuesMethod="values";
   var  variableMethod="variables";
   </script>
     </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
             <wml:WmlUrl ID="wml2url" runat="server" BaseUrl="REST/waterml_1_0.svc/" siteMethod="series"
                valuesMethod="values" variableMethod="variables" SoapPage="~/cuahsi_1_0.asmx"/>
 <div>
  <p>
        WaterML is delivered over a SOAP API, called "WaterOneFlow". In this version, the API is updated
        to include a REST endpooint</p>
    <p>
        There are two methods in these services:</p>
   
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

        
                <h2>
                    Variables</h2>
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
        <script type="text/javascript">
   

        $(document).ready(function () //executes this code when page loading is done
        {  $('#serviceLocation').attr("href",SoapPage);
            getSites( baseUrl, siteMethod );
            getSeries(baseUrl, valuesMethod );
              $('#loading').fadeOut();
        });
    </script>
     <script type="text/javascript" src="scripts/ExampleWaterMlLinks.js" >
   </script>
</asp:Content>

