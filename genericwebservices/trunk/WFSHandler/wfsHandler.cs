using System;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using System.Configuration;
using System.Web;

using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

/// <summary>
/// Summary description for wfsHandler
/// 
/// <example>
/// <system.web>
///     <httpHandlers>
///         <add verb="*" path="*.wfs" type="cuahsi.his.ogc.wfsHandler"/>
///     </httpHandlers>
/// </system.web>
/// </example>
/// </summary>
/// 
namespace cuahsi.his.ogc
{
    public class wfsHandler : IHttpHandler
    {
        private String connect;
        string baseurl;
        public wfsHandler()
        {
            String connect = ConfigurationManager.ConnectionStrings["ODDB"].ConnectionString;
            
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// constructor For testing.
        /// </summary>
        /// <param name="ODDBconnection"></param>
        /// <param name="query"></param>
        public wfsHandler(string ODDBconnection, string query)
        {
            String connect = ODDBconnection;

            //
            // TODO: Add constructor logic here
            //
        }
        #region IHttpHandler Members

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string networkName = parsePath(context.Request.Path);
            //throw new Exception("The method or operation is not implemented.");
            //context.Response.ContentType = "text/plain";
            baseurl = "http://" + context.Request.Url.Host;
            if (context.Request.Url.Port != 80)
            {
                baseurl += ":" + context.Request.Url.Port;
            }

            if (networkName != "")
            {
                //BOX box = this.getNetworkBox(networkName);
                if (context.Request.RequestType == "POST")
                {
                    getFeature(context, networkName);
                }
                else
                {

                    if (context.Request.QueryString.Count > 0)
                    {
                        if (context.Request.QueryString[0].ToUpper().Equals("GETCAPABILITIES"))
                        {
                            getCapabilities(context, networkName);
                        }
                        if (context.Request.QueryString["request"] != null)
                        {
                            string request = context.Request.Params.Get("request");
                            if (request.ToUpper().Equals("GETCAPABILITIES"))
                            {
                                getCapabilities(context, networkName);
                            }
                            else if (request.ToUpper().Equals("DESCRIBEFEATURETYPE"))
                            {
                                describeFeatureType(context, networkName);
                            }
                            else if (request.ToUpper().Equals("GETFEATURE"))
                            {
                                getFeature(context, networkName);
                            }
                        }
                    }

                }
            }
            else
            {
                context.Response.StatusCode = 404;
                //context.Response.Write(context.Request.Path);
                context.Response.Close();
            }
            //context.Response.Write(context.Request.Path);
        }
        //private string[] getKeywordList(int id)
        //{
        //    string sql = "SELECT conceptKeyword" +
        //                " FROM v_Keywords where networkid = @NetworkID";

        //    //String connect = ConfigurationManager.ConnectionStrings["CentralHISConnectionString"].ConnectionString;
        //    DataSet ds = new DataSet();
        //    SqlConnection con = new SqlConnection(connect);
        //    SqlCommand mysco = new SqlCommand(sql, con);
        //    SqlParameterCollection parms = mysco.Parameters;
        //    parms.Clear();
        //    parms.Add("NetworkID", id);
        //    using (con)
        //    {
        //        SqlDataAdapter da = new SqlDataAdapter(mysco);
        //        da.Fill(ds, "keywords");
        //    }
        //    con.Close();
        //    //Calculate bounding box
        //    System.Data.DataRowCollection rows = ds.Tables["keywords"].Rows;
        //    String[] keywordsList = new String[rows.Count];
        //    for (int i = 0; i < rows.Count; i++)
        //    {

        //        keywordsList[i] = rows[i][0].ToString();

        //    }
        //    return keywordsList;

        //}
        private string[] getKeywordList()
        {
            // TODO: replace with HIS central concepts 
           string sql = @"SELECT distinct variablename as conceptname
                      FROM variables" ;
        DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connect);
            SqlCommand mysco = new SqlCommand(sql, con);
            SqlParameterCollection parms = mysco.Parameters;
            parms.Clear();
            
            using (con)
            {
                SqlDataAdapter da = new SqlDataAdapter(mysco);
                da.Fill(ds, "keywords");
            }
            con.Close();
            //Calculate bounding box
            System.Data.DataRowCollection rows = ds.Tables["keywords"].Rows;
            String[] keywordsList = new String[rows.Count];
            for (int i = 0; i < rows.Count; i++)
            {

                keywordsList[i] = rows[i][0].ToString();

            }
            return keywordsList; 
        }

        
        private Network getHISNetworksRecord()
        {
            string sql = "SELECT NetworkName,NetworkTitle,ServiceWSDL,ServiceAbs,ContactName,ContactEmail," +
                          "ContactPhone,Organization,website,Citation," +
                          "Xmin,Xmax,Ymin,Ymax,ValueCount,VariableCount,SiteCount,EarliestRec,LatestRec" +
                          " FROM HISNetworks where NetworkID = @NetworkID AND (isPublic='true')";

            //String connect = ConfigurationManager.ConnectionStrings["CentralHISConnectionString"].ConnectionString;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connect);
            SqlCommand mysco = new SqlCommand(sql, con);
            SqlParameterCollection parms = mysco.Parameters;
            parms.Clear();
            
            using (con)
            {
                SqlDataAdapter da = new SqlDataAdapter(mysco);
                da.Fill(ds, "networkInfo");
            }
            con.Close();
            //Calculate bounding box
            System.Data.DataRowCollection rows = ds.Tables["networkInfo"].Rows;

            if (rows.Count == 1)
            {

                var net = new Network(rows[0]);
                return net;
                // return rows[0];
            }
            else
            {
                return null;
            }
        }
        private static string encodeForXML(object input)
        {
            string output = "";

            if (input != null)
            {
                Regex fixer = new Regex("&(?![a-zA-Z]{2,6};|#[0-9]{2,4};)");
                output = fixer.Replace(input.ToString(), "&amp;");
                output = output.Replace("<", "&lt;").Replace("\"", "&quot;").Replace(">", "gt;");
            }
            return output;

        }

        #region getCapabilities

        private void getCapabilities(HttpContext context, string networkid)
        {
            int intid = int.Parse(networkid);
            var networkInfo = getHISNetworksRecord();
            String[] keywords = getKeywordList();




            var sb = CapabiltiesXmlString(networkInfo, keywords, baseurl + context.Request.Path);


            context.Response.ContentType = "text/xml";
            //context.Response.Headers.Add("content-length",sb.Length.ToString());
            context.Response.AppendHeader("Transfer-Encoding", "None");

            context.Response.Write(sb.ToString());
            context.Response.Flush();
            context.Response.Close();
        }

        public static String CapabiltiesXmlString(Network networkInfo, string[] keywords, string url)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");

            sb.Append("<wfs:WFS_Capabilities version=\"1.1.0\" xmlns=\"http://www.opengis.net/wfs\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"http://www.opengis.net/gml http://schemas.opengis.net/gml/3.1.1/base/gml.xsd http://www.opengis.net/ogc http://schemas.opengis.net/filter/1.1.0/filter.xsd http://www.opengis.net/ows http://schemas.opengis.net/ows/1.0.0/owsAll.xsd http://www.opengis.net/wfs http://schemas.opengis.net/wfs/1.1.0/wfs.xsd\" xmlns:ows=\"http://www.opengis.net/ows\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" xmlns:wfs=\"http://www.opengis.net/wfs\" xmlns:ogc=\"http://www.opengis.net/ogc\" xmlns:gml=\"http://www.opengis.net/gml\">");
            sb.Append("<ows:ServiceIdentification>");
            sb.Append("<ows:Title>");
            sb.Append(encodeForXML(networkInfo.NetworkTitle));
            sb.Append("</ows:Title>");
            sb.Append("<ows:Abstract>");
            sb.Append(encodeForXML(networkInfo.ServiceAbs));
            sb.Append("</ows:Abstract>");
            sb.Append("<ows:Keywords>");
            sb.Append("<ows:Keyword>DataCart</ows:Keyword>");
            sb.Append("<ows:Keyword>Hydrology</ows:Keyword>");
            sb.Append("<ows:Keyword>CUAHSI</ows:Keyword>");
            for (int i = 0; i < keywords.Length; i++)
            {
                sb.Append("<ows:Keyword>");
                sb.Append(encodeForXML(keywords[i]));
                sb.Append("</ows:Keyword>");
            }
            sb.Append("</ows:Keywords>");
            sb.Append("<ows:ServiceType>WFS</ows:ServiceType>");
            sb.Append("<ows:ServiceTypeVersion>1.1.0</ows:ServiceTypeVersion>");
            sb.Append("<ows:Fees>none</ows:Fees>");
            sb.Append("<ows:AccessConstraints>none</ows:AccessConstraints>");
            sb.Append("</ows:ServiceIdentification>");
            sb.Append("<ows:ServiceProvider>");
            sb.Append("<ows:ProviderName>");
            sb.Append(encodeForXML(networkInfo.Organization));
            sb.Append("</ows:ProviderName>");
            sb.Append("<ows:ProviderSite xlink:href=\"");
            sb.Append(encodeForXML(networkInfo.Website));//www.arizona.edu
            sb.Append("\"/>");
            sb.Append("<ows:ServiceContact>");
            sb.Append("<ows:IndividualName>");
            sb.Append(encodeForXML(networkInfo.ContactName));
            sb.Append("</ows:IndividualName>");
            sb.Append("<ows:ContactInfo>");
            sb.Append("<ows:OnlineResource xlink:href=\"");
            sb.Append(encodeForXML(networkInfo.Website));
            sb.Append("?\" />");
            sb.Append("<ows:Phone>");
            sb.Append("<ows:Voice>");
            sb.Append(encodeForXML(networkInfo.ContactPhone));
            sb.Append("</ows:Voice>");
            sb.Append("</ows:Phone>");
            sb.Append("<ows:Address>");
            sb.Append("<ows:ElectronicMailAddress>"); //m@az.edu</ows:ElectronicMailAddress>
            sb.Append(encodeForXML(networkInfo.ContactEmail));
            sb.Append("</ows:ElectronicMailAddress>");
            sb.Append("</ows:Address>");
            sb.Append("</ows:ContactInfo>");
            sb.Append("</ows:ServiceContact>");
            sb.Append("</ows:ServiceProvider>");
            sb.Append("<ows:OperationsMetadata>");
            sb.Append("<ows:Operation name=\"GetCapabilities\">");
            sb.Append("<ows:DCP>");
            sb.Append("<ows:HTTP>");
            sb.Append("<ows:Get xlink:href=\"");
            sb.Append(url);
            sb.Append("?\" />");
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
            sb.Append("<ows:Get xlink:href=\"");
            sb.Append(url);
            sb.Append("?\" />");
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
            sb.Append("<ows:Get xlink:href=\"");
            sb.Append(url);
            sb.Append("?\" />");
            sb.Append("<ows:Post xlink:href=\"");
            sb.Append(url);
            sb.Append("?\" />");
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
            sb.Append("<wfs:FeatureTypeList>");
            sb.Append("<wfs:FeatureType>");
            sb.Append("<wfs:Name>");
            sb.Append(encodeForXML(networkInfo.NetworkName));
            sb.Append(":DataCart");
            sb.Append("</wfs:Name>");
            sb.Append("<wfs:Title>");
            sb.Append("DataCart");

            sb.Append("</wfs:Title>");
            //<wfs:LatLongBoundingBox minx="-65.734527587999935" miny="18.316404343000045" maxx="-65.734527587999935" maxy="18.316404343000045" />
            sb.Append("<wfs:DefaultSRS>urn:x-ogc:def:crs:EPSG:6.9:4326</wfs:DefaultSRS>");
            sb.Append("<wfs:OtherSRS>urn:x-ogc:def:crs:EPSG:6.9:4326</wfs:OtherSRS>");
            sb.Append("<wfs:OutputFormats>");
            sb.Append("<wfs:Format>text/xml; subType=gml/3.1.1/profiles/gmlsf/1.0.0/0</wfs:Format>");
            sb.Append("</wfs:OutputFormats>");
            sb.Append("<ows:WGS84BoundingBox>");
            sb.Append("<ows:LowerCorner>");
            //  -111.3417 42.12035
            sb.AppendFormat("{0} {1}",networkInfo.Xmin,networkInfo.Ymin);
            sb.Append("</ows:LowerCorner>");
            sb.Append("<ows:UpperCorner>");
            //-111.2884 42.25035
            sb.AppendFormat("{0} {1}", networkInfo.Xmax, networkInfo.Ymax);
            //sb.Append(networkInfo["Xmax"].ToString()).Append(" ");
            //sb.Append(networkInfo["Ymax"].ToString());
            sb.Append("</ows:UpperCorner>");
            sb.Append("</ows:WGS84BoundingBox>");
            sb.Append("</wfs:FeatureType>");
            sb.Append("</wfs:FeatureTypeList>");
            sb.Append("<ogc:Filter_Capabilities>");
            sb.Append("<ogc:Spatial_Capabilities>");
            sb.Append("<ogc:GeometryOperands>");
            sb.Append("<ogc:GeometryOperand>gml:Envelope</ogc:GeometryOperand>");
            sb.Append("<ogc:GeometryOperand>gml:Point</ogc:GeometryOperand>");
            sb.Append("<ogc:GeometryOperand>gml:Polygon</ogc:GeometryOperand>");
            sb.Append("<ogc:GeometryOperand>gml:LineString</ogc:GeometryOperand>");
            sb.Append("</ogc:GeometryOperands>");
            sb.Append("<ogc:SpatialOperators>");
            sb.Append("<ogc:SpatialOperator name=\"BBOX\" />");
            //sb.Append("<ogc:SpatialOperator name=\"Equals\" />");
            //sb.Append("<ogc:SpatialOperator name=\"Disjoint\" />");
            //sb.Append("<ogc:SpatialOperator name=\"Intersects\" />");
            //sb.Append("<ogc:SpatialOperator name=\"Crosses\" />");
            //sb.Append("<ogc:SpatialOperator name=\"Touches\" />");
            //sb.Append("<ogc:SpatialOperator name=\"Within\" />");
            //sb.Append("<ogc:SpatialOperator name=\"Contains\" />");
            //sb.Append("<ogc:SpatialOperator name=\"Overlaps\" />");
            sb.Append("</ogc:SpatialOperators>");
            sb.Append("</ogc:Spatial_Capabilities>");
            sb.Append("<ogc:Scalar_Capabilities>");
            sb.Append("<ogc:LogicalOperators />");
            sb.Append("<ogc:ComparisonOperators>");
            sb.Append("<ogc:ComparisonOperator>EqualTo</ogc:ComparisonOperator>");
            sb.Append("<ogc:ComparisonOperator>NotEqualTo</ogc:ComparisonOperator>");
            sb.Append("<ogc:ComparisonOperator>LessThan</ogc:ComparisonOperator>");
            //sb.Append("<ogc:ComparisonOperator>GreaterThan</ogc:ComparisonOperator>");
            //sb.Append("<ogc:ComparisonOperator>LessThanEqualTo</ogc:ComparisonOperator>");
            sb.Append("<ogc:ComparisonOperator>GreaterThanEqualTo</ogc:ComparisonOperator>");
            sb.Append("<ogc:ComparisonOperator>Like</ogc:ComparisonOperator>");
            //sb.Append("<ogc:ComparisonOperator>Between</ogc:ComparisonOperator>");
            //sb.Append("<ogc:ComparisonOperator>NullCheck</ogc:ComparisonOperator>");
            sb.Append("</ogc:ComparisonOperators>");
            sb.Append("</ogc:Scalar_Capabilities>");
            sb.Append("<ogc:Id_Capabilities>");
            sb.Append("<ogc:EID />");
            sb.Append("<ogc:FID />");
            sb.Append("</ogc:Id_Capabilities>");
            sb.Append("</ogc:Filter_Capabilities>");
            sb.Append("</wfs:WFS_Capabilities>");
            return sb.ToString();
        }

        #endregion

        #region describeFeatureType (canned response).

        private void describeFeatureType(HttpContext context, String networkCode)
        {

           // int intid = int.Parse(networkid);
           // DataRow r = getHISNetworksRecord(intid);

          var  describeFeature = DescribeFeatureXmlString(baseurl + context.Request.Path, networkCode);
            //contexr
            //System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
            //xdoc.LoadXml(sb.ToString());
            //context.Response.Headers.Add("Fuck", "You");
            context.Response.AppendHeader("Transfer-Encoding", "None");
            context.Response.ContentType = "text/xml";
            //context.Response.Write(xdoc.ToString());
            //context.Response.Output.w
            context.Response.Write(describeFeature);
            context.Response.Flush();
            context.Response.Close();
        }

        public static string DescribeFeatureXmlString(string url, string networkCode)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            sb.Append("<xs:schema targetNamespace=\"");
            sb.Append(url);
            sb.Append("\" elementFormDefault=\"qualified\" xmlns:czo_merced=\"http://water.sdsc.edu/arcgis/services/czo_merced/MapServer/WFSServer\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\" xmlns:gml=\"http://www.opengis.net/gml\">");
            sb.Append("<xs:import namespace=\"http://www.opengis.net/gml\" schemaLocation=\"http://schemas.opengis.net/gml/3.1.1/base/gml.xsd\" />");
            sb.Append("<xs:element name=\"DataCart\" type=\"");
            //  sb.Append(r["networkName"]);
            sb.Append(networkCode);
            sb.Append(":DataCartType\" substitutionGroup=\"gml:_Feature\" />");
            sb.Append("<xs:complexType name=\"DataCartType\">");
            sb.Append("<xs:complexContent>");
            sb.Append("<xs:extension base=\"gml:AbstractFeatureType\">");
            sb.Append("<xs:sequence>");
            sb.Append("<xs:element minOccurs=\"0\" name=\"ServCode\">");
            sb.Append("<xs:simpleType>");
            sb.Append("<xs:restriction base=\"xs:string\">");
            sb.Append("<xs:maxLength value=\"255\" />");
            sb.Append("</xs:restriction>");
            sb.Append("</xs:simpleType>");
            sb.Append("</xs:element>");
            sb.Append("<xs:element minOccurs=\"0\" name=\"SiteCode\">");
            sb.Append("<xs:simpleType>");
            sb.Append("<xs:restriction base=\"xs:string\">");
            sb.Append("<xs:maxLength value=\"101\" />");
            sb.Append("</xs:restriction>");
            sb.Append("</xs:simpleType>");
            sb.Append("</xs:element>");
            sb.Append("<xs:element minOccurs=\"0\" name=\"SiteName\">");
            sb.Append("<xs:simpleType>");
            sb.Append("<xs:restriction base=\"xs:string\">");
            sb.Append("<xs:maxLength value=\"200\" />");
            sb.Append("</xs:restriction>");
            sb.Append("</xs:simpleType>");
            sb.Append("</xs:element>");
            sb.Append("<xs:element minOccurs=\"0\" name=\"VarCode\">");
            sb.Append("<xs:simpleType>");
            sb.Append("<xs:restriction base=\"xs:string\">");
            sb.Append("<xs:maxLength value=\"100\" />");
            sb.Append("</xs:restriction>");
            sb.Append("</xs:simpleType>");
            sb.Append("</xs:element>");
            sb.Append("<xs:element minOccurs=\"0\" name=\"VarName\">");
            sb.Append("<xs:simpleType>");
            sb.Append("<xs:restriction base=\"xs:string\">");
            sb.Append("<xs:maxLength value=\"200\" />");
            sb.Append("</xs:restriction>");
            sb.Append("</xs:simpleType>");
            sb.Append("</xs:element>");
            sb.Append("<xs:element minOccurs=\"0\" name=\"VarUnits\">");
            sb.Append("<xs:simpleType>");
            sb.Append("<xs:restriction base=\"xs:string\">");
            sb.Append("<xs:maxLength value=\"255\" />");
            sb.Append("</xs:restriction>");
            sb.Append("</xs:simpleType>");
            sb.Append("</xs:element>");
            sb.Append("<xs:element minOccurs=\"0\" name=\"Vocabulary\">");
            sb.Append("<xs:simpleType>");
            sb.Append("<xs:restriction base=\"xs:string\">");
            sb.Append("<xs:maxLength value=\"255\" />");
            sb.Append("</xs:restriction>");
            sb.Append("</xs:simpleType>");
            sb.Append("</xs:element>");
            sb.Append("<xs:element name=\"Ontology\">");
            sb.Append("<xs:simpleType>");
            sb.Append("<xs:restriction base=\"xs:string\">");
            sb.Append("<xs:maxLength value=\"12\" />");
            sb.Append("</xs:restriction>");
            sb.Append("</xs:simpleType>");
            sb.Append("</xs:element>");
            sb.Append("<xs:element minOccurs=\"0\" name=\"Concept\">");
            sb.Append("<xs:simpleType>");
            sb.Append("<xs:restriction base=\"xs:string\">");
            sb.Append("<xs:maxLength value=\"250\" />");
            sb.Append("</xs:restriction>");
            sb.Append("</xs:simpleType>");
            sb.Append("</xs:element>");
            sb.Append("<xs:element minOccurs=\"0\" name=\"Valuecount\" type=\"xs:int\" />");
            sb.Append("<xs:element minOccurs=\"0\" name=\"StartDate\" type=\"xs:dateTime\" />");
            sb.Append("<xs:element minOccurs=\"0\" name=\"EndDate\" type=\"xs:dateTime\" />");
            sb.Append("<xs:element minOccurs=\"0\" name=\"Latitude\" type=\"xs:double\" />");
            sb.Append("<xs:element minOccurs=\"0\" name=\"Longitude\" type=\"xs:double\" />");
            sb.Append("<xs:element minOccurs=\"0\" name=\"IsRegular\" type=\"xs:short\" />");
            sb.Append("<xs:element minOccurs=\"0\" name=\"TimeUnits\">");
            sb.Append("<xs:simpleType>");
            sb.Append("<xs:restriction base=\"xs:string\">");
            sb.Append("<xs:maxLength value=\"255\" />");
            sb.Append("</xs:restriction>");
            sb.Append("</xs:simpleType>");
            sb.Append("</xs:element>");
            sb.Append("<xs:element minOccurs=\"0\" name=\"TimeStep\" type=\"xs:int\" />");
            sb.Append("<xs:element minOccurs=\"0\" name=\"DataType\">");
            sb.Append("<xs:simpleType>");
            sb.Append("<xs:restriction base=\"xs:string\">");
            sb.Append("<xs:maxLength value=\"50\" />");
            sb.Append("</xs:restriction>");
            sb.Append("</xs:simpleType>");
            sb.Append("</xs:element>");
            sb.Append("<xs:element minOccurs=\"0\" name=\"Medium\">");
            sb.Append("<xs:simpleType>");
            sb.Append("<xs:restriction base=\"xs:string\">");
            sb.Append("<xs:maxLength value=\"100\" />");
            sb.Append("</xs:restriction>");
            sb.Append("</xs:simpleType>");
            sb.Append("</xs:element>");
            sb.Append("<xs:element minOccurs=\"0\" name=\"MethodID\" type=\"xs:int\" />");
            sb.Append("<xs:element minOccurs=\"0\" name=\"Method\">");
            sb.Append("<xs:simpleType>");
            sb.Append("<xs:restriction base=\"xs:string\">");
            sb.Append("<xs:maxLength value=\"255\" />");
            sb.Append("</xs:restriction>");
            sb.Append("</xs:simpleType>");
            sb.Append("</xs:element>");
            sb.Append("<xs:element minOccurs=\"0\" name=\"QCLevelID\" type=\"xs:int\" />");
            sb.Append("<xs:element minOccurs=\"0\" name=\"QCLevel\">");
            sb.Append("<xs:simpleType>");
            sb.Append("<xs:restriction base=\"xs:string\">");
            sb.Append("<xs:maxLength value=\"255\" />");
            sb.Append("</xs:restriction>");
            sb.Append("</xs:simpleType>");
            sb.Append("</xs:element>");
            sb.Append("<xs:element minOccurs=\"0\" name=\"SourceID\" type=\"xs:int\" />");
            sb.Append("<xs:element minOccurs=\"0\" name=\"SourceName\">");
            sb.Append("<xs:simpleType>");
            sb.Append("<xs:restriction base=\"xs:string\">");
            sb.Append("<xs:maxLength value=\"255\" />");
            sb.Append("</xs:restriction>");
            sb.Append("</xs:simpleType>");
            sb.Append("</xs:element>");
            sb.Append("<xs:element name=\"LocType\">");
            sb.Append("<xs:simpleType>");
            sb.Append("<xs:restriction base=\"xs:string\">");
            sb.Append("<xs:maxLength value=\"8\" />");
            sb.Append("</xs:restriction>");
            sb.Append("</xs:simpleType>");
            sb.Append("</xs:element>");
            sb.Append("<xs:element name=\"ServType\">");
            sb.Append("<xs:simpleType>");
            sb.Append("<xs:restriction base=\"xs:string\">");
            sb.Append("<xs:maxLength value=\"4\" />");
            sb.Append("</xs:restriction>");
            sb.Append("</xs:simpleType>");
            sb.Append("</xs:element>");
            sb.Append("<xs:element minOccurs=\"0\" name=\"XLL\" type=\"xs:double\" />");
            sb.Append("<xs:element minOccurs=\"0\" name=\"YLL\" type=\"xs:double\" />");
            sb.Append("<xs:element minOccurs=\"0\" name=\"XUR\" type=\"xs:double\" />");
            sb.Append("<xs:element minOccurs=\"0\" name=\"YUR\" type=\"xs:double\" />");
            sb.Append("<xs:element minOccurs=\"0\" name=\"Location\">");
            sb.Append("<xs:simpleType>");
            sb.Append("<xs:restriction base=\"xs:string\">");
            sb.Append("<xs:maxLength value=\"357\" />");
            sb.Append("</xs:restriction>");
            sb.Append("</xs:simpleType>");
            sb.Append("</xs:element>");
            sb.Append("<xs:element minOccurs=\"0\" name=\"Variable\">");
            sb.Append("<xs:simpleType>");
            sb.Append("<xs:restriction base=\"xs:string\">");
            sb.Append("<xs:maxLength value=\"356\" />");
            sb.Append("</xs:restriction>");
            sb.Append("</xs:simpleType>");
            sb.Append("</xs:element>");
            sb.Append("<xs:element name=\"ReqsAuth\" type=\"xs:int\" />");
            sb.Append("<xs:element name=\"WofVersion\">");
            sb.Append("<xs:simpleType>");
            sb.Append("<xs:restriction base=\"xs:string\">");
            sb.Append("<xs:maxLength value=\"3\" />");
            sb.Append("</xs:restriction>");
            sb.Append("</xs:simpleType>");
            sb.Append("</xs:element>");
            sb.Append("<xs:element minOccurs=\"0\" name=\"WaterMLURI\">");
            sb.Append("<xs:simpleType>");
            sb.Append("<xs:restriction base=\"xs:string\">");
            sb.Append("<xs:maxLength value=\"255\" />");
            sb.Append("</xs:restriction>");
            sb.Append("</xs:simpleType>");
            sb.Append("</xs:element>");
            sb.Append("<xs:element minOccurs=\"0\" name=\"WFSURI\">");
            sb.Append("<xs:simpleType>");
            sb.Append("<xs:restriction base=\"xs:string\">");
            sb.Append("<xs:maxLength value=\"255\" />");
            sb.Append("</xs:restriction>");
            sb.Append("</xs:simpleType>");
            sb.Append("</xs:element>");
            sb.Append("<xs:element minOccurs=\"0\" name=\"WMSURI\">");
            sb.Append("<xs:simpleType>");
            sb.Append("<xs:restriction base=\"xs:string\">");
            sb.Append("<xs:maxLength value=\"255\" />");
            sb.Append("</xs:restriction>");
            sb.Append("</xs:simpleType>");
            sb.Append("</xs:element>");
            sb.Append("<xs:element minOccurs=\"0\" name=\"DAccessURI\">");
            sb.Append("<xs:simpleType>");
            sb.Append("<xs:restriction base=\"xs:string\">");
            sb.Append("<xs:maxLength value=\"255\" />");
            sb.Append("</xs:restriction>");
            sb.Append("</xs:simpleType>");
            sb.Append("</xs:element>");
            sb.Append("<xs:element minOccurs=\"0\" name=\"StateName\">");
            sb.Append("<xs:simpleType>");
            sb.Append("<xs:restriction base=\"xs:string\">");
            sb.Append("<xs:maxLength value=\"120\" />");
            sb.Append("</xs:restriction>");
            sb.Append("</xs:simpleType>");
            sb.Append("</xs:element>");
            sb.Append("<xs:element minOccurs=\"0\" name=\"Shape\" type=\"gml:PointPropertyType\" />");
            sb.Append("<xs:element name=\"RecordType\">");
            sb.Append("<xs:simpleType>");
            sb.Append("<xs:restriction base=\"xs:string\">");
            sb.Append("<xs:maxLength value=\"15\" />");
            sb.Append("</xs:restriction>");
            sb.Append("</xs:simpleType>");
            sb.Append("</xs:element>");
            sb.Append("<xs:element minOccurs=\"0\" name=\"OrgHier\" type=\"xs:int\" />");
            sb.Append("<xs:element name=\"SerStatus\">");
            sb.Append("<xs:simpleType>");
            sb.Append("<xs:restriction base=\"xs:string\">");
            sb.Append("<xs:maxLength value=\"6\" />");
            sb.Append("</xs:restriction>");
            sb.Append("</xs:simpleType>");
            sb.Append("</xs:element>");
            sb.Append("<xs:element minOccurs=\"0\" name=\"LastUpdate\" type=\"xs:dateTime\" />");
            sb.Append("</xs:sequence>");
            sb.Append("</xs:extension>");
            sb.Append("</xs:complexContent>");
            sb.Append("</xs:complexType>");
            sb.Append("</xs:schema>");
            return sb.ToString();
        }

        #endregion


        private class BOX
        {
            public double xmin, xmax, ymin, ymax;
        }

        private BOX getNetworkBox(string nname)
        {
            string sql = "SELECT xmin,xmax,ymin,ymax " +
                      "FROM  HISnetworks WHERE (NetworkName =@NetworkName) AND (isPublic='true')";
           // String connect = ConfigurationManager.ConnectionStrings["CentralHISConnectionString"].ConnectionString;
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
            else
            {
                return null;
            }
        }
        private string bboxFilter2SQLWhere(ref SqlParameterCollection parms, string bbox)
        {

            string where = "";


            string[] coords = bbox.Split(',');
            if (coords.Length == 4)
            {
                where += " and ((longitude between " + coords[0] + " and " + coords[2] + ") and (latitude between " + coords[1] + " and " + coords[3] + "))";
                //where += " and ((longitude between @minx and @maxx) and (latitude between @miny and @maxy))";
                //parms.AddWithValue("@minx", coords[1]);
                //parms.AddWithValue("@miny", coords[1]);
                //parms.AddWithValue("@maxx", coords[2]);
                //parms.AddWithValue("@maxy", coords[3]);
            }
            return where;
        }

        private string filter2SQLWhere(ref SqlParameterCollection parms, string filterText)
        {

            string where = " ";

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.LoadXml(filterText);
            System.Xml.XmlNode mainnode = doc.FirstChild.FirstChild;

            where += processFilterNode(ref parms, mainnode);

            ////mainnode.Name;
            //System.Xml.XmlNode subnode;
            //if (mainnode.LocalName.ToLower() == "and")
            //{
            //    //foreach (System.Xml.XmlNode subnode in mainnode.ChildNodes)
            //    for (int i=0; i<mainnode.ChildNodes.Count;i++){

            //        subnode = mainnode.ChildNodes[i];
            //        if (i==0) {
            //            where += " (";
            //        }else {
            //            where += " and ";
            //        }

            //        where += processFilterNode(ref parms, subnode);
            //    }
            //    where += ") ";

            //}
            //else if (mainnode.LocalName.ToLower() == "or")
            //{
            //    //foreach (System.Xml.XmlNode subnode in mainnode.ChildNodes)
            //    for (int i = 0; i < mainnode.ChildNodes.Count; i++)
            //    {

            //        subnode = mainnode.ChildNodes[i];
            //        if (i == 0)
            //        {
            //            where += " (";
            //        }
            //        else
            //        {
            //            where += " or ";
            //        }

            //        where += processFilterNode(ref parms, subnode);
            //    }
            //    where += ") ";

            //}
            //else 
            //{
            //    where += processFilterNode(ref parms, mainnode);
            //}



            return where;

        }
        private string processFilterNode(ref SqlParameterCollection parms, System.Xml.XmlNode filterNode)
        {
            string where = "";
            string field, val, paramName;
            System.Xml.XmlNode subnode;
            switch (filterNode.LocalName.ToLower())
            {

                case "and":
                    for (int i = 0; i < filterNode.ChildNodes.Count; i++)
                    {
                        subnode = filterNode.ChildNodes[i];
                        if (i == 0)
                        {
                            where += " (";
                        }
                        else
                        {
                            where += " and ";
                        }

                        where += processFilterNode(ref parms, subnode);
                    }
                    where += ") ";
                    break;
                case "or":
                    for (int i = 0; i < filterNode.ChildNodes.Count; i++)
                    {
                        subnode = filterNode.ChildNodes[i];
                        if (i == 0)
                        {
                            where += " (";
                        }
                        else
                        {
                            where += " or ";
                        }

                        where += processFilterNode(ref parms, subnode);
                    }
                    where += ") ";
                    break;

                    break;

                case "bbox":
                    string[] ll = filterNode.ChildNodes[1].ChildNodes[0].InnerText.Split(' ');
                    string[] ur = filterNode.ChildNodes[1].ChildNodes[1].InnerText.Split(' ');
                    //where += " and ((longitude between @minx and @maxx) and (latitude between @miny and @maxy))";                
                    //parms.AddWithValue("@minx", ll[1]);
                    //parms.AddWithValue("@miny", ll[0]);
                    //parms.AddWithValue("@maxx", ur[1]);
                    //parms.AddWithValue("@maxy", ur[0]);
                    //filterNode.
                    where += "((longitude between " + ll[1] + " and " + ur[1] + ") and (latitude between " + ll[0] + " and " + ur[0] + "))";
                    break;
                case "propertyislike":
                    field = filterNode.ChildNodes[0].InnerText.Split(':')[1];
                    paramName = getParamName(parms, field);
                    val = filterNode.ChildNodes[1].InnerText;
                    where += field + " LIKE @" + paramName;
                    parms.AddWithValue("@" + paramName, val);

                    break;
                case "propertyisequalto":
                    field = filterNode.ChildNodes[0].InnerText.Split(':')[1];
                    paramName = getParamName(parms, field);
                    val = filterNode.ChildNodes[1].InnerText;
                    where += field + " = @" + paramName;
                    parms.AddWithValue("@" + paramName, val);
                    break;
                case "propertyisgreaterthan":
                    field = filterNode.ChildNodes[0].InnerText.Split(':')[1];
                    paramName = getParamName(parms, field);
                    val = filterNode.ChildNodes[1].InnerText;
                    where += field + " > @" + paramName;
                    parms.AddWithValue("@" + paramName, val);
                    break;
                case "propertyislessthan":
                    field = filterNode.ChildNodes[0].InnerText.Split(':')[1];
                    paramName = getParamName(parms, field);
                    val = filterNode.ChildNodes[1].InnerText;
                    where += field + " < @" + paramName;
                    parms.AddWithValue("@" + paramName, val);
                    break;



            }


            return where;

        }
        private string getParamName(SqlParameterCollection parms, string field)
        {
            string paramName = field;

            if (parms.Contains("@" + paramName))
            {
                paramName = getParamName(parms, field + "I");
            }
            return paramName;

        }


        private void getFeature(HttpContext context, string networkid)
        {
            string sql = "SELECT ServCode,SiteCode,SiteName,VarCode,VarName,VarUnits,Vocabulary,Ontology,Concept" +
                ",Valuecount,StartDate,EndDate,Latitude,Longitude,IsRegular,TimeUnits,TimeStep,DataType,Medium" +
                ",MethodID,Method,QCLevelID,QCLevel,SourceID,SourceName,LocType,ServType,XLL,YLL,XUR,YUR,Location" +
                ",Variable,ReqsAuth,WofVersion,WaterMLURI,WFSURI,WMSURI,DAccessURI,StateName,Geometry,RecordType,OrgHier" +
                ",SerStatus,LastUpdate FROM hiscentral.dbo.v_ObservationsMetadata where sourceid = @Sourceid";





            String connect = ConfigurationManager.ConnectionStrings["CentralHISConnectionString"].ConnectionString;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connect);
            SqlCommand mysco = new SqlCommand(sql, con);
            SqlParameterCollection parms = mysco.Parameters;
            bool hits = false;
            parms.Clear();
            parms.AddWithValue("@Sourceid", networkid);
            if (context.Request.QueryString["filter"] != null)
            {
                sql += " and " + filter2SQLWhere(ref parms, context.Request.QueryString["filter"]);

            }
            if (context.Request.QueryString["BBOX"] != null)
            {
                sql += bboxFilter2SQLWhere(ref parms, context.Request.QueryString["BBOX"]);

            }
            if (context.Request.QueryString["resultType"] != null)
            {
                if (context.Request.QueryString["resultType"] == "hits")
                {
                    hits = true;
                }

            }

            mysco.CommandText = sql;

            using (con)
            {
                SqlDataAdapter da = new SqlDataAdapter(mysco);
                da.Fill(ds, "myselect");
            }
            con.Close();
            //Calculate bounding box
            string NetworkName = "cuahsi";
            System.Data.DataRowCollection rows = ds.Tables["myselect"].Rows;
            StringBuilder sb = new StringBuilder();
            /*
                          * <wfs:FeatureCollection numberOfFeatures='45' timeStamp='12/7/2010 3:21:43 PM' 
                  xsi:schemaLocation='http://129.116.104.176/ArcGIS/rest/services/Themes/TexasSalinity/MapServer/WFSServer 
                 * http://129.116.104.176/ArcGIS/services/Themes/TexasSalinity/MapServer/WFSServer?request=DescribeFeatureType%26version=1.1.0%26typename=TexasSalinity 
                 * http://www.opengis.net/wfs http://schemas.opengis.net/wfs/1.1.0/wfs.xsd' xmlns:Themes_TexasSalinity='http://129.116.104.176/ArcGIS/rest/services/Themes/TexasSalinity/MapServer/WFSServer' 
                 * xmlns:gml='http://www.opengis.net/gml' xmlns:wfs='http://www.opengis.net/wfs' 
                 * xmlns:xlink='http://www.w3.org/1999/xlink' 
                 * xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'></wfs:FeatureCollection>
             */
            // return just the count
            if (hits)
            {
                sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                sb.Append("<wfs:FeatureCollection ");
                sb.Append("numberOfFeatures='").Append(rows.Count).Append("' timeStamp='").Append(System.DateTime.Now.ToString()).Append("' ");
                sb.AppendFormat("xsi:schemaLocation='{0} {1} {2} {3}' "
                    , baseurl + context.Request.Path
                    , baseurl + context.Request.Path + "?SERVICE=WFS&amp;VERSION=1.1.0&amp;REQUEST=DescribeFeatureType&amp;TYPENAME=DataCart&amp;OUTPUTFORMAT=XMLSCHEMA"
                    , "http://www.opengis.net/wfs"
                    , "http://schemas.opengis.net/wfs/1.0.0/WFS-basic.xsd");
                sb.AppendFormat(" xmlns:{0}='{1}'", NetworkName, baseurl + context.Request.Path);

                sb.Append(" xmlns:gml='http://www.opengis.net/gml'");
                sb.Append(" xmlns:wfs='http://www.opengis.net/wfs'");
                sb.Append(" xmlns:ogc='http://www.opengis.net/ogc'");
                sb.Append(" xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>");
                sb.Append("</wfs:FeatureCollection>");
                context.Response.ContentType = "text/xml";
                context.Response.AppendHeader("Transfer-Encoding", "None");
                context.Response.Write(sb.ToString());
                context.Response.Flush();
                context.Response.Close();
                return;
            }


            if (rows.Count > 0)
            {
                NetworkName = rows[0]["servCode"].ToString();
            }
            double lat, lon, xmin = 180, xmax = -180, ymin = 90, ymax = -90;
            for (int i = 0; i < rows.Count; i++)
            {
                lat = (double)rows[i]["Latitude"];
                lon = (double)rows[i]["Longitude"];
                ymin = (ymin < lat) ? ymin : lat;
                ymax = (ymax > lat) ? ymax : lat;
                xmin = (xmin < lon) ? xmin : lon;
                xmax = (xmax > lon) ? xmax : lon;
            }


            //http://www.opengis.net/wfs

            /*

            
           <wfs:FeatureCollection xsi:schemaLocation='http://maxim.ucsd.edu/hiscentral/MapServer/WFSServer http://maxim.ucsd.edu/ArcGIS/services/hiscentral/MapServer/WFSServer?request=DescribeFeatureType%26typename=States' xmlns:hiscentral='http://maxim.ucsd.edu/hiscentral/MapServer/WFSServer' xmlns:gml='http://www.opengis.net/gml' xmlns:wfs='http://www.opengis.net/wfs' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>
             */
            sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sb.Append("<wfs:FeatureCollection ");



            sb.AppendFormat("xsi:schemaLocation='{0} {1} {2} {3}' "
                , baseurl + context.Request.Path
                , baseurl + context.Request.Path + "?SERVICE=WFS&amp;VERSION=1.1.0&amp;REQUEST=DescribeFeatureType&amp;TYPENAME=DataCart&amp;OUTPUTFORMAT=XMLSCHEMA"
                , "http://www.opengis.net/wfs"
                , "http://schemas.opengis.net/wfs/1.0.0/WFS-basic.xsd");
            sb.AppendFormat(" xmlns:{0}='{1}'", NetworkName, baseurl + context.Request.Path);

            sb.Append(" xmlns:gml='http://www.opengis.net/gml'");
            sb.Append(" xmlns:wfs='http://www.opengis.net/wfs'");
            sb.Append(" xmlns:ogc='http://www.opengis.net/ogc'");
            sb.Append(" xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>");

            if (rows.Count > 0)
            {
                sb.Append("<gml:boundedBy><gml:Box srsName='EPSG:4326'>");
                sb.Append("<gml:coordinates>");
                sb.Append(xmin).Append(',').Append(ymin).Append(' ').Append(xmax).Append(',').Append(ymax);
                //sb.Append("<gml:lowerCorner>"+ymin+" "+xmin+"</gml:lowerCorner>");
                //sb.Append("<gml:upperCorner>"+ymax+" "+xmax+"</gml:upperCorner>"); 
                //sb.Append("</gml:Envelope>"); 
                sb.Append("</gml:coordinates>");
                sb.Append("</gml:Box>");
                sb.Append("</gml:boundedBy>");
            }
            // for each feature
            for (int i = 0; i < rows.Count; i++)
            {
                // geometry
                lat = (double)rows[i]["Latitude"];
                lon = (double)rows[i]["Longitude"];
                //string sitecode = rows[i]["SiteCode"].ToString();
                //string sourceid = rows[i]["SourceID"].ToString();
                //string sitename = rows[i]["SiteName"].ToString();
                //string varname = rows[i]["VariableName"].ToString();
                //string varcode = rows[i]["VariableCode"].ToString();
                //string wsdl = rows[i]["ServiceWSDL"].ToString();



                sb.Append("<gml:featureMember>");
                sb.Append('<').Append(NetworkName).Append(":DataCart fid='F-1__").Append(i).Append("'>");
                sb.Append('<').Append(NetworkName).Append(":ServCode>"); //UpMetN_cduc
                sb.Append(NetworkName);
                sb.Append("</").Append(NetworkName).Append(":ServCode>"); //
                sb.Append('<').Append(NetworkName).Append(":SiteCode>"); //UpMetN_cduc
                sb.Append(rows[i]["SiteCode"].ToString());
                sb.Append("</").Append(NetworkName).Append(":SiteCode>"); //
                sb.Append('<').Append(NetworkName).Append(":SiteName>"); //Providence upper met station north aspect
                sb.Append(rows[i]["SiteName"].ToString());
                sb.Append("</").Append(NetworkName).Append(":SiteName>"); //
                sb.Append('<').Append(NetworkName).Append(":VarCode>"); //SnowDepth57
                sb.Append(rows[i]["varCode"].ToString());
                sb.Append("</").Append(NetworkName).Append(":VarCode>"); //
                sb.Append('<').Append(NetworkName).Append(":VarName>"); //Snow Depth
                sb.Append(rows[i]["VarName"].ToString());
                sb.Append("</").Append(NetworkName).Append(":VarName>"); //
                sb.Append('<').Append(NetworkName).Append(":VarUnits>"); //centimeter
                sb.Append(rows[i]["VarUnits"].ToString());
                sb.Append("</").Append(NetworkName).Append(":VarUnits>"); //
                sb.Append('<').Append(NetworkName).Append(":Vocabulary>"); //czo_merced
                sb.Append(rows[i]["Vocabulary"].ToString());
                sb.Append("</").Append(NetworkName).Append(":Vocabulary>"); //
                sb.Append('<').Append(NetworkName).Append(":Ontology>"); //CUAHSI201004
                sb.Append(rows[i]["Ontology"].ToString());
                sb.Append("</").Append(NetworkName).Append(":Ontology>"); //
                sb.Append('<').Append(NetworkName).Append(":Concept>"); //Snow depth
                sb.Append(rows[i]["Concept"].ToString());
                sb.Append("</").Append(NetworkName).Append(":Concept>"); //
                sb.Append('<').Append(NetworkName).Append(":Valuecount>"); //6490
                sb.Append(rows[i]["Valuecount"].ToString());
                sb.Append("</").Append(NetworkName).Append(":Valuecount>"); //
                sb.Append('<').Append(NetworkName).Append(":StartDate>"); //2008-10-09T00:00:00
                sb.Append(rows[i]["StartDate"].ToString());
                sb.Append("</").Append(NetworkName).Append(":StartDate>"); //
                sb.Append('<').Append(NetworkName).Append(":EndDate>"); //2009-02-21T00:00:00
                sb.Append(rows[i]["EndDate"].ToString());
                sb.Append("</").Append(NetworkName).Append(":EndDate>"); //
                sb.Append('<').Append(NetworkName).Append(":Latitude>"); //37.061042785644531
                sb.Append(lat);
                sb.Append("</").Append(NetworkName).Append(":Latitude>"); //
                sb.Append('<').Append(NetworkName).Append(":Longitude>"); //-119.18241882324219
                sb.Append(lon);
                sb.Append("</").Append(NetworkName).Append(":Longitude>"); //
                sb.Append('<').Append(NetworkName).Append(":IsRegular>"); //1
                sb.Append(rows[i]["IsRegular"].ToString());
                sb.Append("</").Append(NetworkName).Append(":IsRegular>"); //
                sb.Append('<').Append(NetworkName).Append(":TimeUnits>"); //hour
                sb.Append(rows[i]["TimeUnits"].ToString());
                sb.Append("</").Append(NetworkName).Append(":TimeUnits>"); //
                sb.Append('<').Append(NetworkName).Append(":TimeStep>"); //1
                sb.Append(rows[i]["TimeStep"].ToString());
                sb.Append("</").Append(NetworkName).Append(":TimeStep>"); //
                sb.Append('<').Append(NetworkName).Append(":DataType>"); //Continuous
                sb.Append(rows[i]["DataType"].ToString());
                sb.Append("</").Append(NetworkName).Append(":DataType>"); //
                sb.Append('<').Append(NetworkName).Append(":Medium>"); //SurfaceWater
                sb.Append(rows[i]["Medium"].ToString());
                sb.Append("</").Append(NetworkName).Append(":Medium>"); //
                sb.Append('<').Append(NetworkName).Append(":Method>"); //
                sb.Append(rows[i]["Method"].ToString());
                sb.Append("</").Append(NetworkName).Append(":Method>"); //
                sb.Append('<').Append(NetworkName).Append(":QCLevel>"); //
                sb.Append(rows[i]["QCLevel"].ToString());
                sb.Append("</").Append(NetworkName).Append(":QCLevel>"); //
                sb.Append('<').Append(NetworkName).Append(":SourceID>"); //161
                sb.Append(networkid);
                sb.Append("</").Append(NetworkName).Append(":SourceID>"); //
                sb.Append('<').Append(NetworkName).Append(":SourceName>"); //
                sb.Append(rows[i]["SourceName"].ToString());
                sb.Append("</").Append(NetworkName).Append(":SourceName>"); //
                sb.Append('<').Append(NetworkName).Append(":LocType>"); //SiteCode
                sb.Append(rows[i]["LocType"].ToString());
                sb.Append("</").Append(NetworkName).Append(":LocType>"); //
                sb.Append('<').Append(NetworkName).Append(":ServType>"); //SOAP
                sb.Append(rows[i]["ServType"].ToString());
                sb.Append("</").Append(NetworkName).Append(":ServType>"); //
                sb.Append('<').Append(NetworkName).Append(":XLL>"); //-119.18241882324219
                sb.Append(rows[i]["XLL"].ToString());
                sb.Append("</").Append(NetworkName).Append(":XLL>"); //
                sb.Append('<').Append(NetworkName).Append(":YLL>"); //37.061042785644531
                sb.Append(rows[i]["YLL"].ToString());
                sb.Append("</").Append(NetworkName).Append(":YLL>"); //
                sb.Append('<').Append(NetworkName).Append(":XUR>"); //-119.18241882324219
                sb.Append(rows[i]["XUR"].ToString());
                sb.Append("</").Append(NetworkName).Append(":XUR>"); //
                sb.Append('<').Append(NetworkName).Append(":YUR>"); //37.061042785644531
                sb.Append(rows[i]["YUR"].ToString());
                sb.Append("</").Append(NetworkName).Append(":YUR>"); //
                sb.Append('<').Append(NetworkName).Append(":Location>"); //czo_merced:UpMetN_cduc
                sb.Append(rows[i]["Location"].ToString());
                sb.Append("</").Append(NetworkName).Append(":Location>"); //
                sb.Append('<').Append(NetworkName).Append(":Variable>"); //czo_merced:SnowDepth57
                sb.Append(rows[i]["Variable"].ToString());
                sb.Append("</").Append(NetworkName).Append(":Variable>"); //
                sb.Append('<').Append(NetworkName).Append(":ReqsAuth>"); //0
                sb.Append(rows[i]["ReqsAuth"].ToString());
                sb.Append("</").Append(NetworkName).Append(":ReqsAuth>"); //
                sb.Append('<').Append(NetworkName).Append(":WofVersion>"); //1.0
                sb.Append(rows[i]["WofVersion"].ToString());
                sb.Append("</").Append(NetworkName).Append(":WofVersion>"); //
                sb.Append('<').Append(NetworkName).Append(":WaterMLURI>"); //http://192.31.21.100/czo_merced/cuahsi_1_0.asmx?WSDL
                sb.Append(rows[i]["WaterMLURI"].ToString());
                sb.Append("</").Append(NetworkName).Append(":WaterMLURI>"); //
                sb.Append('<').Append(NetworkName).Append(":WFSURI>"); //
                sb.Append(baseurl + context.Request.Path);
                sb.Append("</").Append(NetworkName).Append(":WFSURI>"); //
                sb.Append('<').Append(NetworkName).Append(":WMSURI>"); //
                sb.Append("</").Append(NetworkName).Append(":WMSURI>"); //
                sb.Append('<').Append(NetworkName).Append(":DAccessURI>"); //
                sb.Append(rows[i]["DAccessURI"].ToString());
                sb.Append("</").Append(NetworkName).Append(":DAccessURI>"); //
                sb.Append('<').Append(NetworkName).Append(":Shape>"); //
                sb.Append("<gml:Point>"); //
                sb.Append("<gml:coordinates>"); //-119.18241882299998,37.06104278600003
                sb.Append(lon).Append(',').Append(lat);
                sb.Append("</gml:coordinates>"); //
                sb.Append("</gml:Point>"); //
                sb.Append("</").Append(NetworkName).Append(":Shape>"); //
                sb.Append('<').Append(NetworkName).Append(":RecordType>"); //ObservationsODM
                sb.Append(rows[i]["RecordType"].ToString());
                sb.Append("</").Append(NetworkName).Append(":RecordType>"); //
                sb.Append('<').Append(NetworkName).Append(":SerStatus>"); //Active
                sb.Append(rows[i]["SerStatus"].ToString());
                sb.Append("</").Append(NetworkName).Append(":SerStatus>"); //
                sb.Append('<').Append(NetworkName).Append(":LastUpdate>"); //2010-11-19T10:46:35
                sb.Append(rows[i]["LastUpdate"].ToString());

                sb.Append("</").Append(NetworkName).Append(":LastUpdate>"); //


                sb.Append("</").Append(NetworkName).Append(":DataCart >");
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
            for (int i = 0; i < parms.Length; i++)
            {
                if (parms[i].ToLower() == "wfs")
                {
                    i++;
                    return parms[i];
                }
            }
            return "";
        }
        #endregion
    }
}
