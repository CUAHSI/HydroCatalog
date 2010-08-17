<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestWSDL-WebMethod.aspx.cs" Inherits="WsdlValidationTests_WebVersion._Default" %>
<%@ Import Namespace="WsdlValidationTests"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>WaterOneFlow Web Service Status Tests</title>
<meta http-equiv="content-type" content="text/html; charset=UTF-8" />
<style type="text/css">	
	table.test { 	
		border-style:	solid;
		border-color:	#336699;
		border-width:	1px;	
		font-family: Verdana;
		font-weight: normal;
		font-size: 11px;		
		width: 700px;
		background-color: #336699;
	}
	
	table.test2 { 		
		margin: 2px;
		border-style:	solid;
		border-color:	#CCFFFF;
		border-width:	1px;	
		font-family: Verdana;
		font-weight: normal;
		font-size: 11px;		
		width: 550px;
		background-color: #CCFFFF;
	}

	td.header {
		width:				1000px;
		background-color:	#336699;
	}
	
	tr.test_tr1 {
		
		background-color:	#CCFFFF;
	}
	
	tr.test_tr2 {		
		background-color:	#FFFFCC;
	}
	
	tr.test_tr3 {
		
		background-color:	#66CCCC;
	}
	
	tr.test_tr4 {		
		background-color:	#99FFFF;
	}
	
	ul.wsdl_tests {
		padding: 4px;
		margin: 4px;
		list-style-type:	none;
	}
</style>
</head>
<body>
	<table>
	<tr>
		<td class="header">
			<img src="./Images/hislogo.jpg" alt="CUAHSI HIS, Sharing hydrologic data" />
		</td>
	</tr>
	</table>
	<div  id="test_result">
		<h4>
		WaterOneFlow WSDL Validation Service will perform checks listed below.
		</h4>		
		<ul class="wsdl_tests">
			<li>Verify WSDL URI is well formed</li>
			<li>Verify WSDL specified by URI existts</li>
			<li>Verify WSDL specified by URI is in valid format</li>
			<li>Verify WSDL specifies common WaterOneFlow web service methods specified below:</li>
			<li>
				<ul class="wsdl_tests">
					<li>GetSiteInfo </li>
					<li>GetSiteInfoObject</li>
					<li>GetSites</li>
					<li>GetSitesXml</li>
					<li>GetValues</li>	
					<li>GetValuesObject</li>
					<li>GetVariableInfo</li>
					<li>GetVariableInfoObject</li>
				</ul>
			</li>
		</ul>
		<!--  
		Ok, below is the table template I need to automatically generate !!!
		-->
		<h4>
		Enter WSDL URI to perform tests mentioned Above. 
		</h4>
		<form runat="server" action="#" method="get">
		    <input type="text" name="URI" size="113" /> <br />
		    <input type="submit" value="Run WaterOneFlow WSDL verification tests" /> <br /><br />
		
		<% 
	
            if (Page.Request.QueryString["URI"] != null) {
                string URI = Page.Request.QueryString["URI"]; %>
        <br />
		<table class="test">
			<tr>
				<td colspan="2">
					<p>
					<b>Web Service WSDL SPECIFIED</b> <br />
					- <%= URI %> <br />
				<%	if (WebServiceTestsUsingWsdl.doesUriResourceExists( URI ) ) { %>
				    - Resource specified by URI EXISTS.	 <br />  
				<%	} else { %>
					- Resource specified by URI DOES NOT EXISTS. <br /> 
				<%	} %>
				<%	if (WebServiceTestsUsingWsdl.doesWsdlUriWellFormed(
                                                 URI, UriKind.RelativeOrAbsolute ) ) { %>
				    - URI is WELL FORMED.	<br />    
				<%	} else { %>
					- URI IS NOT WELL FORMED. <br />
				<%	} %>					
			    <%	if (WebServiceTestsUsingWsdl.isWsdlValid( URI ) ) { %>
				    - WSDL specified by URI is VALID.	<br />    
				<%	} else { %>
					- WSDL specified by URI is NOT VALID. <br />
				<%	} %>
					</p>
				</td>				
			</tr>			
			
			<%      int trClass = 0;
                    
             
                    foreach (string methodName in mapOfMethodNameAndParams.Keys) {
                        Hashtable paramNameType = 
                                  (Hashtable) mapOfMethodNameAndParams[methodName];
                        string trClassName = "test_tr1";               
                        
                        if ( trClass++ % 2 != 0) {
                            trClassName = "test_tr2";
                        }                  
                        
                        if ( WebServiceTestsUsingWsdl.verifyWebMethodExistsInType( 
                                                      URI,methodName) ) { %>
                        <tr class="<%= trClassName %>" style="vertical-align:top">
				            <td>					
					            <img src="./Images/pass.gif" alt="METHOD EXISTS" /><%= methodName %>					
				            </td>						
			                <td>
				                <table class="test2">	
				                <%  int trClass2 = 0;
                            
                                    foreach (string paramName in paramNameType.Keys) {
                                        string trClassName2 = "test_tr3";
                                        if (trClass2++%2 != 0) {
                                            trClassName2 = "test_tr4";
                                        } %>
                                        <tr class="<%=trClassName2%>">
                                     <% if (WebServiceTestsUsingWsdl.verifyWebMethodParamNamesAndTypes(
                                            URI, methodName,
                                            paramName, (string) paramNameType[paramName])) {%>                                        
                                            <td>
                                                <img src="./Images/pass.gif" alt="PASS" />
                                            </td>						                							                    
                                    <%
                                        } else { %>
                                            <td>
                                                <img src="./Images/fail.gif" alt="FAIL" />
                                            </td>
                                    <%  } %>
                                            <td style="vertical-align:top">					
							                    Expected parameter name: <%=paramName%>
						                    </td>
						                    <td>										
							                    Expected parameter type: <%=(string) paramNameType[paramName]%>
						                    </td>		
                                           </tr>	
                                 <% }%>										                			
				                </table>
			                </td>		
			            </tr>     
                      <%  } else {%>
                      <tr class="<%=trClassName%>" style="vertical-align:top">
				            <td>					
					            <img src="./Images/fail.gif" alt="METHOD DOES NOT EXIST" /><%=methodName%>					
				            </td>
				            <td>
				                METHOD IS NOT SUPPORTED BY WSDL !!!
				            </td>
				      </tr>				        			            			           
		            <%
                        }
                    } %>
        </table>
        <br />
        <% } %>
		</form>
		<br />
		<h4>
		WSDL validation results on operational WaterOneFlow Web Services
		</h4>
		
		<% if ( listOfWsdlUris != null ) {
         for (int i = 0; i < listOfWsdlUris.Count; i++) {
                     %>
        <br />
		<table class="test">
			<tr>
				<td colspan="2">
					<p>
					<b>WaterOneFlow Web Service</b> <br />
					- <%= listOfWsdlUris[i] %> <br />
				<%	if (WebServiceTestsUsingWsdl.doesUriResourceExists( (string)listOfWsdlUris[i] ) ) { %>
				    - Resource specified by URI EXISTS.	 <br />  
				<%	} else { %>
					- Resource specified by URI DOES NOT EXISTS. <br /> 
				<%	} %>
				<%	if (WebServiceTestsUsingWsdl.doesWsdlUriWellFormed(
                                                 (string)listOfWsdlUris[i], UriKind.RelativeOrAbsolute ) ) { %>
				    - URI is WELL FORMED.	<br />    
				<%	} else { %>
					- URI IS NOT WELL FORMED. <br />
				<%	} %>					
			    <%	if (WebServiceTestsUsingWsdl.isWsdlValid( (string)listOfWsdlUris[i] ) ) { %>
				    - WSDL specified by URI is VALID.	<br />    
				<%	} else { %>
					- WSDL specified by URI is NOT VALID. <br />
				<%	} %>
					</p>
				</td>				
			</tr>			
			
			<%      int trClass = 0;
                    
             
                    foreach (string methodName in mapOfMethodNameAndParams.Keys) {
                        Hashtable paramNameType = 
                                  (Hashtable) mapOfMethodNameAndParams[methodName];
                        string trClassName = "test_tr1";               
                        
                        if ( trClass++ % 2 != 0) {
                            trClassName = "test_tr2";
                        }                  
                        
                        if ( WebServiceTestsUsingWsdl.verifyWebMethodExistsInType( 
                                                      (string)listOfWsdlUris[i],methodName) ) { %>
                        <tr class="<%= trClassName %>" style="vertical-align:top">
				            <td>					
					            <img src="./Images/pass.gif" alt="METHOD EXISTS" /><%= methodName %>					
				            </td>						
			                <td>
				                <table class="test2">	
				                <%  int trClass2 = 0;
                            
                                    foreach (string paramName in paramNameType.Keys) {
                                        string trClassName2 = "test_tr3";
                                        if (trClass2++%2 != 0) {
                                            trClassName2 = "test_tr4";
                                        } %>
                                        <tr class="<%=trClassName2%>">
                                     <% if (WebServiceTestsUsingWsdl.verifyWebMethodParamNamesAndTypes(
                                            (string) listOfWsdlUris[i], methodName,
                                            paramName, (string) paramNameType[paramName])) {%>                                        
                                            <td>
                                                <img src="./Images/pass.gif" alt="PASS" />
                                            </td>						                							                    
                                    <%
                                        } else { %>
                                            <td>
                                                <img src="./Images/fail.gif" alt="FAIL" />
                                            </td>
                                    <%  } %>
                                            <td style="vertical-align:top">					
							                    Expected parameter name: <%=paramName%>
						                    </td>
						                    <td>										
							                    Expected parameter type: <%=(string) paramNameType[paramName]%>
						                    </td>		
                                           </tr>	
                                 <% }%>										                			
				                </table>
			                </td>		
			            </tr>     
                      <%  } else {%>
                      <tr class="<%=trClassName%>" style="vertical-align:top">
				            <td>					
					            <img src="./Images/fail.gif" alt="METHOD DOES NOT EXIST" /><%=methodName%>					
				            </td>
				            <td>
				                METHOD IS NOT SUPPORTED BY WSDL !!!
				            </td>
				      </tr>				        			            			           
		            <%
                        }
                    } %>
        </table>
        <br />
    <%   }
    } %>
	</div>
</body>
</html>