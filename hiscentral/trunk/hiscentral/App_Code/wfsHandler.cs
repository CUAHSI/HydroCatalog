using System;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

/// <summary>
/// Summary description for wfsHandler
/// </summary>
public class wfsHandler : IHttpHandler

{

  string baseurl = "http://localhost";
	public wfsHandler()
	{
		//
		// TODO: Add constructor logic here
		//
	}
 
  #region IHttpHandler Members

  public bool IsReusable
  {
    get { return false;  }    
  }

  public void ProcessRequest(HttpContext context)
  {
    string networkName = parsePath(context.Request.Path);
    //throw new Exception("The method or operation is not implemented.");
    //context.Response.ContentType = "text/plain";
    if (networkName!=""){
      BOX box = this.getNetworkBox(networkName);
      if (context.Request.RequestType == "POST") {
        getFeature(context, networkName);
      }else{
        if (box != null)
        {
          if (context.Request.QueryString.Count > 0)
          {
            if (context.Request.QueryString[0].ToUpper().Equals("GETCAPABILITIES"))
            {
              getCapabilities(context, networkName, box);
            }
            if (context.Request.QueryString["request"] != null)
            {
              string request = context.Request.Params.Get("request");
              if (request.ToUpper().Equals("GETCAPABILITIES"))
              {
                getCapabilities(context, networkName, box);
              }
              else if (request.ToUpper().Equals("DESCRIBEFEATURETYPE"))
              {
                describeFeatureType(context);
              }
              else if (request.ToUpper().Equals("GETFEATURE"))
              {
                getFeature(context, networkName);
              }
            }
          }
        }
      }
    }else{
      context.Response.StatusCode = 404;
      //context.Response.Write(context.Request.Path);
      context.Response.Close();
    }
    //context.Response.Write(context.Request.Path);
  }
  private void getCapabilities(HttpContext context, string nname, BOX box) {
    
    StringBuilder sb = new StringBuilder();
    sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n");
    sb.Append("<wfs:WFS_Capabilities xmlns=\"http://www.opengis.net/wfs\" version=\"1.1.0\"");
    sb.Append(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"http://schemas.opengis.net/wfs/1.1.0/wfs.xsd\"");
    sb.Append(" xmlns:ows=\"http://www.opengis.net/ows\" xmlns:xlink=\"http://www.w3.org/1999/xlink\"");
    sb.Append(" xmlns:wfs=\"http://www.opengis.net/wfs\" xmlns:ogc=\"http://www.opengis.net/ogc\" xmlns:gml=\"http://www.opengis.net/gml\">");
    sb.Append("<ows:ServiceIdentification>");
    sb.Append("<ows:Name>hiscentral</ows:Name>");
    sb.Append("<ows:Title>CUAHSI HIS Central WFS Map Service</ows:Title>");
    sb.Append("<ows:Abstract>This is an OGC compliant MapService.</ows:Abstract>");
    sb.Append("<ows:Keywords>CUAHSI</ows:Keywords>");
    sb.Append("<ows:ServiceType>WFS</ows:ServiceType>");
    sb.Append("<ows:ServiceTypeVersion>1.1.0</ows:ServiceTypeVersion>");
    //sb.Append("<ows:OnlineResource>" + baseurl + context.Request.Path + "</ows:OnlineResource>");
    sb.Append("<ows:Fees>none</ows:Fees>");
    sb.Append("<ows:AccessConstraints>none</ows:AccessConstraints>");
    sb.Append("</ows:ServiceIdentification>");
    sb.Append("<ows:ServiceProvider> ");
    // <ows:ProviderName /> 
    sb.Append("<ows:ServiceContact>"); 
    //  <ows:IndividualName />   <ows:PositionName /> <ows:ContactInfo><ows:Phone>  <ows:Voice />   <ows:Facsimile />   </ows:Phone><ows:Address>  <ows:DeliveryPoint />   <ows:City />   <ows:AdministrativeArea />   <ows:PostalCode />   <ows:Country />   <ows:ElectronicMailAddress />   </ows:Address>
    sb.Append("<ows:OnlineResource xlink:href=\"" + baseurl + context.Request.Path + "?\" />");
    //<ows:HoursOfService />   <ows:ContactInstructions />   </ows:ContactInfo>
    sb.Append("</ows:ServiceContact>");
    sb.Append("</ows:ServiceProvider>");

    //sb.Append("<ows:Capability xmlns:ogc=\"http://www.opengis.net/ogc\" xmlns:gml=\"http://www/opengis.net/gml\">");
    sb.Append("<ows:OperationsMetadata>");
    sb.Append("<ows:Operation name=\"GetCapabilities\">");
    sb.Append("<ows:DCP>");
    sb.Append("<ows:HTTP>");
    sb.Append("<ows:Get xlink:href=\"" + baseurl + context.Request.Path + "?\" /> ");
    //sb.Append("<ows:Post xlink:href="http://maxim.ucsd.edu/ArcGIS/services/hiscentral/MapServer/WFSServer" /> ");
    sb.Append("</ows:HTTP>");
    sb.Append("</ows:DCP>");
    sb.Append("<ows:Parameter name=\"AcceptVersions\">");
    sb.Append("<ows:Value>1.1.0</ows:Value>"); 
    sb.Append("</ows:Parameter>");
    sb.Append("<ows:Parameter name=\"AcceptFormats\">");
    sb.Append("<ows:Value>text/xml</ows:Value>"); 
    sb.Append("</ows:Parameter>");
    sb.Append("</ows:Operation>");

    sb.Append("<ows:Operation name=\"DescribeFeatureType\">");
    sb.Append("<ows:DCP>");
    sb.Append("<ows:HTTP>");
    sb.Append("<ows:Get xlink:href=\"" + baseurl + context.Request.Path + "?\" /> ");
    //sb.Append("<ows:Post xlink:href="http://maxim.ucsd.edu/ArcGIS/services/hiscentral/MapServer/WFSServer" /> ");
    sb.Append("</ows:HTTP>");
    sb.Append("</ows:DCP>");
    sb.Append("<ows:Parameter name=\"AcceptVersions\">");
    sb.Append("<ows:Value>1.1.0</ows:Value>");
    sb.Append("</ows:Parameter>");
    sb.Append("<ows:Parameter name=\"AcceptFormats\">");
    sb.Append("<ows:Value>text/xml</ows:Value>");
    sb.Append("</ows:Parameter>");
    sb.Append("</ows:Operation>");

    sb.Append("<ows:Operation name=\"GetFeature\">");
    sb.Append("<ows:DCP>");
    sb.Append("<ows:HTTP>");
    sb.Append("<ows:Get xlink:href=\"" + baseurl + context.Request.Path + "?\" /> ");
    sb.Append("<ows:Post xlink:href=\"" + baseurl + context.Request.Path + "?\" /> ");
    //sb.Append("<ows:Post xlink:href="http://maxim.ucsd.edu/ArcGIS/services/hiscentral/MapServer/WFSServer" /> ");
    sb.Append("</ows:HTTP>");
    sb.Append("</ows:DCP>");
    sb.Append("<ows:Parameter name=\"AcceptVersions\">");
    sb.Append("<ows:Value>1.1.0</ows:Value>");
    sb.Append("</ows:Parameter>");
    sb.Append("<ows:Parameter name=\"AcceptFormats\">");
    sb.Append("<ows:Value>text/xml</ows:Value>");
    sb.Append("</ows:Parameter>");
    sb.Append("</ows:Operation>");
    sb.Append("</ows:OperationsMetadata>");
    //sb.Append("<ows:Request>");
    //sb.Append("<ows:GetCapabilities>");
    //sb.Append("<ows:DCPType>");
    //sb.Append("<ows:HTTP>");
    //sb.Append("<ows:Get onlineResource=\"" + baseurl + context.Request.Path + "?\"/>");
    //sb.Append("</ows:HTTP>");
    //sb.Append("</ows:DCPType>");
    //sb.Append("</ows:GetCapabilities>");
    //sb.Append("<ows:DescribeFeatureType>");
    //sb.Append("<ows:SchemaDescriptionLanguage>");
    //sb.Append(" <ows:XMLSCHEMA/>");
    //sb.Append("</ows:SchemaDescriptionLanguage>");
    //sb.Append("<ows:DCPType>");
    //sb.Append("<ows:HTTP>");
    //sb.Append("<ows:Get onlineResource=\"" + baseurl + context.Request.Path + "?\"/>");
    //sb.Append("</ows:HTTP>");
    //sb.Append("</ows:DCPType>");
    //sb.Append("</ows:DescribeFeatureType>");
    //sb.Append("<ows:GetFeature>");
    //sb.Append("<ows:ResultFormat>");
    //sb.Append("<ows:GML2/>");
    //sb.Append("</ows:ResultFormat>");
    //sb.Append("<ows:DCPType>");
    //sb.Append("<ows:HTTP>");
    //sb.Append("<ows:Get onlineResource=\"" + baseurl + context.Request.Path + "?\"/>");
    ////sb.Append("<Post onlineResource=\""+baseurl+context.Request.Path+"?\"/>");
    //sb.Append("</ows:HTTP>");
    //sb.Append("</ows:DCPType>");
    //sb.Append("</ows:GetFeature>");
    //sb.Append("</ows:Request>");
    //sb.Append("</ows:Capability>");
    sb.Append("<wfs:FeatureTypeList>");
    //sb.Append("<Operations>");
    //sb.Append("<Query/>");
    //sb.Append("</Operations>");
    sb.Append("<wfs:FeatureType>");
    sb.Append("<wfs:Name>Series</wfs:Name>");
    sb.Append("<wfs:Title>" + nname + " Sites</wfs:Title>");
    //sb.Append("<wfs:SRS>EPSG:4326</wfs:SRS>");
    // Add box 
    //sb.Append("<LatLongBoundingBox minx=\"" + box.xmin + "\" miny=\"" + box.ymin + "\" maxx=\"" + box.xmax + "\" maxy=\"" + box.ymax + "\"/>");
      sb.Append("<wfs:DefaultSRS>urn:x-ogc:def:crs:EPSG:6.9:4326</wfs:DefaultSRS>"); 
    sb.Append("<wfs:OtherSRS>urn:x-ogc:def:crs:EPSG:6.9:4326</wfs:OtherSRS>");
    sb.Append("<wfs:OutputFormats>");
    sb.Append("<wfs:Format>text/xml; subType=gml/3.1.1/profiles/gmlsf/1.0.0/0</wfs:Format>");
    sb.Append("</wfs:OutputFormats>");

    sb.Append("<ows:WGS84BoundingBox>");
    sb.Append("<ows:LowerCorner>"+box.xmin+" "+box.ymin+"</ows:LowerCorner>");
    sb.Append("<ows:UpperCorner>"+box.xmax+" "+box.ymax+"</ows:UpperCorner>");
    sb.Append("</ows:WGS84BoundingBox>");

    sb.Append("</wfs:FeatureType>");
    sb.Append("</wfs:FeatureTypeList>");
    sb.Append("<ogc:Filter_Capabilities>");
    sb.Append("<ogc:Spatial_Capabilities>");
    sb.Append("<ogc:Spatial_Operators>");
    sb.Append("<ogc:BBOX/>");
    sb.Append("</ogc:Spatial_Operators>");
    sb.Append("</ogc:Spatial_Capabilities>");
    //sb.Append("<ogc:Scalar_Capabilities>");
    //sb.Append("<ogc:Comparison_Operators>");
    //sb.Append("</ogc:Comparison_Operators>");
    //sb.Append("</ogc:Scalar_Capabilities>");
    sb.Append("</ogc:Filter_Capabilities>");
    sb.Append("</wfs:WFS_Capabilities>");

    context.Response.ContentType = "text/xml";
    //context.Response.Headers.Add("content-length",sb.Length.ToString());
    context.Response.AppendHeader("Transfer-Encoding", "None");
    
    context.Response.Write(sb.ToString());
    context.Response.Flush();
    context.Response.Close();  
  }
  private void describeFeatureType(HttpContext context) 
  { 
      StringBuilder sb = new StringBuilder();
      sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
      sb.Append("<xsd:schema targetNamespace=\"http://his.cuahsi.org/his\" xmlns:cuahsi=\"http://his.cuahsi.org/his\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:gml=\"http://www.opengis.net/gml\" elementFormDefault=\"qualified\" version=\"0.1\">");
      sb.Append("<xsd:import namespace=\"http://www.opengis.net/gml\" schemaLocation=\"http://schemas.opengis.net/gml/3.1.1/base/gml.xsd\"/>");

      sb.Append("<xsd:complexType name=\"Series\">");
      sb.Append("<xsd:complexContent>");
      sb.Append("<xsd:extension base=\"gml:AbstractFeatureType\">");
      sb.Append("<xsd:sequence>");
      sb.Append("<xsd:element name=\"SiteCode\" type=\"xsd:string\" minOccurs=\"0\" maxOccurs=\"1\"/>");
      sb.Append("<xsd:element name=\"SourceID\" type=\"xsd:string\" minOccurs=\"0\" maxOccurs=\"1\"/>");
      sb.Append("<xsd:element name=\"ServiceWSDL\" type=\"xsd:string\" minOccurs=\"0\" maxOccurs=\"1\"/>");
      sb.Append("<xsd:element name=\"NetworkName\" type=\"xsd:string\" minOccurs=\"0\" maxOccurs=\"1\"/>");
      sb.Append("<xsd:element name=\"VariableName\" type=\"xsd:string\" minOccurs=\"0\" maxOccurs=\"1\"/>");
      sb.Append("<xsd:element name=\"VariableCode\" type=\"xsd:string\" minOccurs=\"0\" maxOccurs=\"1\"/>");
      //sb.Append("<xsd:element name=\"feature\" type=\"xsd:string\" minOccurs=\"0\" maxOccurs=\"1\"/>");
      //VariableCode, SiteCode, SiteName, Elevation_m, StateName, County, SourceID, VariableName, SiteID, ServiceWSDL, NetworkName
      //sb.Append("<xsd:element name=\"name\" type=\"xsd:string\" minOccurs=\"0\" maxOccurs=\"1\"/>");
      //sb.Append("<xsd:element name=\"fips55\" type=\"xsd:string\" minOccurs=\"0\" maxOccurs=\"1\"/>");
      //sb.Append("<xsd:element name=\"sum\" type=\"xsd:double\" minOccurs=\"0\" maxOccurs=\"1\"/>");
      
      sb.Append("<xsd:element ref=\"gml:multiPointProperty\"/>");
      sb.Append("</xsd:sequence>");
      sb.Append("</xsd:extension>");
      sb.Append("</xsd:complexContent>");
      sb.Append("</xsd:complexType>");
      sb.Append("<xsd:element name=\"sites-6\" type=\"cuahsi:sites_0_Type\" substitutionGroup=\"gml:_Feature\"/>");
      sb.Append("</xsd:schema>");
      //contexr
      //System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
      //xdoc.LoadXml(sb.ToString());
      //context.Response.Headers.Add("Fuck", "You");
      context.Response.AppendHeader("Transfer-Encoding", "None");
      context.Response.ContentType = "text/xml";
      //context.Response.Write(xdoc.ToString());
      //context.Response.Output.w
      context.Response.Write(sb.ToString());
      context.Response.Flush();
      context.Response.Close();  
  }
  private class BOX {
    public double xmin, xmax, ymin, ymax;
  }

  private BOX getNetworkBox(string nname) {
    string sql = "SELECT xmin,xmax,ymin,ymax " +
              "FROM  HISnetworks WHERE (NetworkName =@NetworkName) AND (isPublic='true')";
    String connect = ConfigurationManager.ConnectionStrings["CentralHISConnectionString"].ConnectionString;
    DataSet ds = new DataSet();
    SqlConnection con = new SqlConnection(connect);
    SqlCommand mysco = new SqlCommand(sql, con);
    SqlParameterCollection parms = mysco.Parameters;
    parms.Clear();
    parms.Add("NetworkName", nname);
    using (con)
    {
      SqlDataAdapter da = new SqlDataAdapter(mysco);
      da.Fill(ds, "networkBox");
    }
    con.Close();
    //Calculate bounding box
    System.Data.DataRowCollection rows = ds.Tables["networkBox"].Rows;

    if (rows.Count >= 1)
    {
      BOX box = new BOX();
      box.xmin = double.Parse(rows[0]["xmin"].ToString());
      box.xmax = double.Parse(rows[0]["xmax"].ToString());
      box.ymin = double.Parse(rows[0]["ymin"].ToString());
      box.ymax = double.Parse(rows[0]["ymax"].ToString());
      return box;
    }
    else {
      return null;
    }
  }
  private void getFeature(HttpContext context, string nname){
    string sql = "SELECT Latitude, Longitude, VariableCode, SiteCode, SiteName, Elevation_m, StateName, County, SourceID, VariableName, SiteID, ServiceWSDL, NetworkName " +
                  "FROM  v_MySelect WHERE (NetworkName =@NetworkName)";
    String connect = ConfigurationManager.ConnectionStrings["CentralHISConnectionString"].ConnectionString;
    DataSet ds = new DataSet();
    SqlConnection con = new SqlConnection(connect);
    SqlCommand mysco = new SqlCommand(sql, con);
    SqlParameterCollection parms = mysco.Parameters;
    parms.Clear();
    parms.Add("NetworkName", nname);
    using (con)
    {
      SqlDataAdapter da = new SqlDataAdapter(mysco);
      da.Fill(ds, "myselect");
    }
    con.Close();
    //Calculate bounding box
    System.Data.DataRowCollection rows = ds.Tables["myselect"].Rows;
    double lat, lon, xmin = 180, xmax=-180, ymin=90, ymax=-90;
    for (int i=0;i<rows.Count;i++){
      lat = (double)rows[i]["Latitude"];
      lon = (double)rows[i]["Longitude"];
      ymin = (ymin<lat) ? ymin : lat;
      ymax = (ymax>lat) ? ymax : lat;
      xmin = (xmin<lon) ? xmin : lon;
      xmax = (xmax>lon) ? xmax : lon;
    }
    
    StringBuilder sb = new StringBuilder();
    //http://www.opengis.net/wfs
    /*
   <wfs:FeatureCollection xsi:schemaLocation='http://maxim.ucsd.edu/hiscentral/MapServer/WFSServer http://maxim.ucsd.edu/ArcGIS/services/hiscentral/MapServer/WFSServer?request=DescribeFeatureType%26typename=States' xmlns:hiscentral='http://maxim.ucsd.edu/hiscentral/MapServer/WFSServer' xmlns:gml='http://www.opengis.net/gml' xmlns:wfs='http://www.opengis.net/wfs' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>
     */
    sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
    sb.Append("<wfs:FeatureCollection xmlns:cuahsi=\"http://www.cuahsi.org/cuahsi\" xmlns:gml=\"http://www.opengis.net/gml\" xmlns:wfs=\"http://www.opengis.net/wfs\" xmlns:ogc=\"http://www.opengis.net/ogc\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ");
    sb.AppendFormat("xsi:schemaLocation=\'{0} {1} {2} {3}' >"
        , "http://www.cuahsi.org/cuahsi", baseurl + context.Request.Path + "?SERVICE=WFS&amp;VERSION=1.1.0&amp;REQUEST=DescribeFeatureType&amp;TYPENAME=Series&amp;OUTPUTFORMAT=XMLSCHEMA",
       "http://www.opengis.net/wfs", "http://schemas.opengis.net/gml/3.1.1/base/gml.xsd");
    
    sb.Append("<gml:boundedBy><gml:Envelope srsName=\"EPSG:4326\">");
    sb.Append("<gml:lowerCorner>"+ymin+" "+xmin+"</gml:lowerCorner>");
    sb.Append("<gml:upperCorner>"+ymax+" "+xmax+"</gml:upperCorner>"); 
    sb.Append("</gml:Envelope>"); 
    sb.Append("</gml:boundedBy>"); 
    // for each feature
    for (int i=0;i<rows.Count;i++){
      // geometry
      lat = (double)rows[i]["Latitude"];
      lon = (double)rows[i]["Longitude"];
      string sitecode = rows[i]["SiteCode"].ToString();
      string sourceid = rows[i]["SourceID"].ToString();
      string sitename = rows[i]["SiteName"].ToString();
      string varname = rows[i]["VariableName"].ToString();
      string varcode = rows[i]["VariableCode"].ToString();
      string wsdl = rows[i]["ServiceWSDL"].ToString();



      sb.Append("<gml:featureMember>");
      sb.Append("<cuahsi:Series gml:id=\""+i+"\">");
      //sb.Append("<esri:_shape_>");
      sb.Append("<gml:MultiPoint srsName=\"EPSG:4326\">");
      sb.Append("<gml:pointMember>");
      sb.Append("<gml:Point srsName=\"EPSG:4326\">");
      sb.Append("<gml:pos>"+lat+" "+lon+"</gml:pos> ");
      sb.Append("</gml:Point>");
      sb.Append("</gml:pointMember>");
      sb.Append("</gml:MultiPoint>");
      sb.Append("<cuahsi:series.SiteCode>").Append(sitecode).Append("</cuahsi:series.SiteCode>");
      sb.Append("<cuahsi:series.SourceID>").Append(sourceid).Append("</cuahsi:series.SourceID>");
      sb.Append("<cuahsi:series.ServiceWSDL>").Append(wsdl).Append("</cuahsi:series.ServiceWSDL>");
      sb.Append("<cuahsi:series.NetworkName>").Append(nname).Append("</cuahsi:series.NetworkName>");
      sb.Append("<cuahsi:series.VariableName>").Append(varname).Append("</cuahsi:series.VariableName>");
      sb.Append("<cuahsi:series.VariableCode>").Append(varcode).Append("</cuahsi:series.VariableCode>");
      sb.Append("</cuahsi:Series>");
      sb.Append("</gml:featureMember>");
      //sb.Append("</esri:_shape_>");
      //attributes

    }
    sb.Append("</wfs:FeatureCollection>");
    context.Response.ContentType = "text/xml";
    context.Response.AppendHeader("Transfer-Encoding", "None");
    context.Response.Write(sb.ToString());
    context.Response.Flush();
    context.Response.Close();  
  }

  //private string getServiceBBox(){
//    SELECT     SearchView.SiteID, SearchView.Latitude, SearchView.Longitude, SearchView.Organization, SearchView.BeginDateTime, SearchView.EndDateTime, 
//                      SearchView.VariableCode, SearchView.SourceID, SearchView.SiteCode, SearchView.HUCnumeric, HISNetworks.ServiceWSDL
//FR OM         SearchView INNER JOIN
//                      HISNetworks ON SearchView.SourceID = HISNetworks.NetworkID
//where HISNetworks.NetworkID = 95
 // }

  /*
   * <?xml version="1.0" encoding="UTF-8" ?> 
- <wfs:FeatureCollection xmlns:esri="http://www.esri.com/esri" xmlns:gml="http://www.opengis.net/gml" xmlns:wfs="http://www.opengis.net/wfs" xmlns:ogc="http://www.opengis.net/ogc" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:schemaLocation="http://www.esri.com/esri http://eslhpbl6:8080/wfsconnector/com.esri.wfs.Esrimap/sangis_dc_FS?request=describefeaturetype&service=WFS&version=1.1.0 http://www.opengis.net/wfs http://eslhpbl6:8080/wfsconnector/schema/wfs/1.1.0/wfs.xsd">
- <gml:boundedBy>
- <gml:Envelope srsName="EPSG:2230">
  <gml:lowerCorner>6157048.17041714 1780161.06958443</gml:lowerCorner> 
  <gml:upperCorner>6578931.16959405 2097727.8595122</gml:upperCorner> 
  </gml:Envelope>
  </gml:boundedBy>
- <gml:featureMember>
- <esri:SANGIS.SCHOOL_SDO-9 gml:id="SANGIS.SCHOOL_SDO-9.69">
- <esri:_shape_>
- <gml:MultiPoint srsName="EPSG:2230">
- <gml:pointMember>
- <gml:Point srsName="EPSG:2230">
  <gml:pos>6249622.47987936 2018105.45022203</gml:pos> 
  </gml:Point>
  </gml:pointMember>
  </gml:MultiPoint>
  </esri:_shape_>
  <esri:sangis.school_sdo.school>CO-OPERATIVE LEARNING CENTER</esri:sangis.school_sdo.school> 
  <esri:sangis.school_sdo.address>454 PAPAYA S</esri:sangis.school_sdo.address> 
  <esri:sangis.school_sdo.zip>92083</esri:sangis.school_sdo.zip> 
  <esri:sangis.school_sdo.type>P</esri:sangis.school_sdo.type> 
  <esri:sangis.school_sdo.priv>Y</esri:sangis.school_sdo.priv> 
  <esri:sangis.school_sdo.grades /> 
  <esri:sangis.school_sdo.level_>PRESCHOOL</esri:sangis.school_sdo.level_> 
  <esri:sangis.school_sdo.district>PRIVATE</esri:sangis.school_sdo.district> 
  <esri:sangis.school_sdo.sixtosix>N</esri:sangis.school_sdo.sixtosix> 
  <esri:shape.area>0</esri:shape.area> 
  <esri:shape.len>0</esri:shape.len> 
  </esri:SANGIS.SCHOOL_SDO-9>
  </gml:featureMember>
- <gml:featureMember>

   */
  private string parsePath(string path)
  {
    
    string[] parms = path.Split('/');
    for(int i=0;i<parms.Length;i++){
      if (parms[i].ToLower()=="wfs"){
        i++;
        return parms[i];
      }
    }
    return "";
  }
  #endregion
}
