<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CUAHSI HIS Central</title>
  <link href="styles/his.css" rel="stylesheet" type="text/css" />
  <link href="styles/his.css" rel="stylesheet" type="text/css" />
  <link href="styles/his.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server"><uc1:HeaderControl ID="HeaderControl1" runat="server" />

      <div style="z-index: 100; left: 2%; width: 96%; position: absolute; top: 178px;
        height: 192px">
       
          <H2 >
            <b>
              CUAHSI Hydrologic Information System Central Web Service Registry</b></H2>
              <h3>POINT OBSERVATION DATA SERVICES</h3>
          This website supports the sharing of hydrologic data published using WaterOneFlow
          web services. <a href="http://his.cuahsi.org/">CUAHSI HIS</a> point observation data 
          publication services support the publication of data by the research community using WaterOneFlow web services for
          the Observations Data Model (ODM). For more informatin on publishing hydrologic data, visit: 
          <a href="http://his.cuahsi.org/datapublishers.html">Using HIS — Publishing Data.</a> 
          <br />
          1. Server Set-up. Establish a relational database server to host the data you want
          to share. Install ODM on the server.
          <br />
          2. Data Loading. Load the data into ODM.
          <br />
          3. Network Set-up. Establish web services to make the data from ODM publically available.
          <br />
          4. Data Indexing. Register the web services with CUAHSI so that they are accessible
          to data discovery tools such as <a href="http://www.hydroseek.net">HydroSeek</a>.
          <br />

          
          
          <h3>WEB SERVICE REGISTRATION SYSTEM</h3>
          <ul>          
          <li><a href="pub_services.aspx">Listing of registered public data services</a> (<asp:Label
            ID="lblCount" runat="server" Text=""></asp:Label>)</li>
          <li><a href="startree.aspx">Hydrologic Concept Ontology</a> (requires java).</li>
          <li><a href="login.aspx">Login</a></li>
          <li><a href="register.aspx">Sign up for an account as a contributer/data manager</a></li>
          <li><a href="webservices/hiscentral.asmx">HIS Central Web Services API</a></li>


         </ul>
        <p>
          &nbsp;</p>
        <p>
          &nbsp;
        </p>
      
    
    </div>
      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CentralHISConnectionString %>"
        SelectCommand="SELECT COUNT(*) AS Expr1 FROM Sources"></asp:SqlDataSource>
    </form>
</body>
</html>
