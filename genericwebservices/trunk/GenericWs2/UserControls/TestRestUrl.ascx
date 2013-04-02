<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TestRestUrl.ascx.cs" 
Inherits="GenericWebservice.UserControls.TestRestUrl" %>
 <div id='WaterMlRestUrlControl'><p>
        WaterML is delivered over a SOAP API, called "WaterOneFlow". In this version, the API is updated
        to include a REST endpooint</p>
    <p>
        There are two methods in these services:</p>
    <ul>
        <li>REST</li>
     
       <li  ><a id="serviceLocation" href=""       >SOAP API</a></li>

    </ul>
    <div class="bold">Test the Rest Interface</div>
    <div>
    <label for="url">Site:</label> <input name="site" id="site" type="text" size="150" maxlength="1000" onfocus="this.select();" /> 
    <label for="url">Variable:</label>  <input name="variable" id="variable" type="text" size="150" maxlength="1000" onfocus="this.select();" /> 
      <label for="url">Begin  Date:</label>  <input name="begin_date" id="begin_date" type="text" size="150" maxlength="1000" onfocus="this.select();" /> 
       <label for="url">End Date:</label>  <input name="end_date" id="end_date" type="text" size="150" maxlength="1000" onfocus="this.select();" /> 
  </div>
    <div>
    <div class="bold">Generate </div>
    <button type="button" onclick="createVariableURL();">VariableURL</button> 
    <button type="button" onclick="createSeriesURL();">Site + Series URL</button> 
    <button type="button" onclick="createValuesURL();">Values URL</button> 
 <%  if
          (!String.IsNullOrEmpty(SoapPage))
          {
          %> <button type="button" onclick="createAllSitesURL();">All Sites URL</button> 
 <%
          }
%> 
    <div><label for="url">Generated URL:</label>  <input name="url" id="url" type="text" size="150" maxlength="1000" onfocus="this.select();" />  
    </div> <button type="button" name="jump" onclick="newLocation();"><b>Run the Generated URL</b></button> 
	<button type="reset" name="Reset">Reset</button> 
    </div>
    <!-- 
 Timeseries/Values 
 http://{HOST}:{PORT}/{SERVICENAME}/REST/waterml_2.svc/values?location={WOF.SiteCode}&variable={WOF.VariableCode}&startDate={StartDate}&endDate={EndDate}
Site
http://{HOST}:{PORT}/{SERVICENAME}/REST/waterml_2.svc/featureOfInterest?location={WOF.SiteCode}
Variable
http://{HOST}:{PORT}/{SERVICENAME}/REST/waterml_2.svc/observedProperty?variable={WOF.VariableCode}

-->
    <script>
        if (SoapPage != null) { $('#serviceLocation').attr("href", SoapPage); }
    function newLocation()
{
	var url = document.getElementById("url");
	window.location=url.value;
}

    var BaseUrl = "<%= BaseUrl %>";
    function createVariableURL(){
    var vUrl = BaseUrl + "<%= variableMethod %>" + "?variable=" +$("#variable").val();
    $("#url").val( vUrl) ;
    return;
    }
    function createSeriesURL(){
        var vUrl = BaseUrl + "<%= siteMethod %>" + "?location=" + $("#site").val();
    $("#url").val( vUrl) ;
    return;

    }
    function createValuesURL(){
    var vUrl = BaseUrl + "<%= valuesMethod %>"+
    "?location="+$("#site").val()+"&variable=" +$("#variable").val()+"&startDate="+$("#begin_date").val()
    +"&endDate="+$("#end_date").val();
    $("#url").val( vUrl) ;
    return;

    }
    </script>
    </div>