using System;
using System.Diagnostics;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using System.Configuration;
using System.Web.Caching;



using com.hp.hpl.jena.rdf.model;
using com.hp.hpl.jena.util.iterator;
using com.hp.hpl.jena.ontology;

using log4net;



/// <summary>
/// Summary description for hiscentral
/// </summary>
[WebService(Namespace = "http://hiscentral.cuahsi.org/20100205/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class hiscentral : System.Web.Services.WebService
{

    private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    private static readonly ILog queryLog = LogManager.GetLogger("QueryLog");
    private const string logFormat = "{0}|{1}|{2}|{3}";

    public hiscentral()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    private const string media = "http://www.cuahsi.org/waterquality#medium";
    private const string mediumPropertyURI = "http://www.cuahsi.org/waterquality#hasMedium";









    public struct Box
    {
        public double xmin;
        public double xmax;
        public double ymin;
        public double ymax;
    }



    #region sites queries:
    public struct Site
    {
        public string SiteName;
        public string SiteCode;
        public double Latitude;
        public double Longitude;
        public string HUC;
        public int HUCnumeric;
        public string servCode;
        public string servURL;
    }

    /*
     * GetSitesInBox
     * 
     * Input Parameters: 
     * 
     * Lat/Long Box, Ontology Concept (optional), Begin Date (Optional), End Date 
     * (Optional), Number of Data Values (Optional), a comma separated list of ServiceIDs (Optional)
     * Returns: A list of all sites that fall within the bounding box, have variables that are mapped 
     * to or fall under the Ontology Concept, overlap the date range of interest, have a minimum number 
     * of data values, and are within the list of services.  
     * Return Format: A list of WaterML siteInfo elements that includes enough information to identify 
     * the service from which the sites were extracted and the HUC Code and HUC Name for the HUC in which 
     * the sites are located (as a general rule, anywhere the siteInfo element is used it should contain  
     * the HUC Code and HUC Name).
     */

    [WebMethod]
    public Site[] GetSitesInBox2(double xmin, double xmax, double ymin, double ymax, string conceptKeyword, string networkIDs)
    {

     


        Box box = new Box();
        box.xmax = xmax;
        box.xmin = xmin;
        box.ymax = ymax;
        box.ymin = ymin;
        int[] ids = new int[0];
        if (networkIDs != "" && networkIDs != " ")
        {
            String[] sids = networkIDs.Split(',');
            ids = new int[sids.Length];
            for (int i = 0; i < ids.Length; i++)
            {
                ids[i] = int.Parse(sids[i]);
            }
        }




        return GetSitesInBox(box, conceptKeyword, ids);
    }
    [WebMethod]
    public Site[] GetSitesInBox(Box box, string conceptKeyword, int[] networkIDs)
    {
        string objecformat = "concept:{0},box({1},{2},{3},{4}),network({5}";
        string methodName = "GetSitesInBox";
        Stopwatch timer = new Stopwatch();
        timer.Start();
        string networksString = String.Empty;
        if (networkIDs != null)
        {
            foreach (var iD in networkIDs)
            {
                networksString += iD.ToString();
            }
        }

        log.InfoFormat(logFormat, methodName, "Start", 0,
           String.Format(objecformat,
           conceptKeyword,
           box.xmin, box.xmax, box.ymin, box.ymax
           , networksString));

        string connect = ConfigurationManager.ConnectionStrings["CentralHISConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connect);
        // allowing blank keywords through
        Site[] sites = new Site[0];



        String sql = "SELECT distinct SiteCode,  SiteName, HUCnumeric, ServiceWSDL, NetworkName, latitude, longitude " +
           " FROM site_concept_search"
            //+ " WHERE (conceptid = @keyword) AND (Latitude BETWEEN @l
            //at1 and @lat2) AND (Longitude BETWEEN @long1 and @long2) AND ((BeginDateTime between @bdate and @edate ) OR (EndDateTime between @bdate and @edate ) OR  ((@bdate > BeginDateTime) AND (@edate < EndDateTime)))";
              + " WHERE (Latitude < @lat1) and (Latitude > @lat2) AND (Longitude <  @long1) and (Longitude > @long2) ";

        if (conceptKeyword != null && conceptKeyword != "")
        {
            String conceptids = getCommaInt(getChildIDsFlat(conceptKeyword));
            //conceptCode = getCommaString(getChildConceptsFlat(conceptCode));
            if (!(conceptids == ""))
            {
                sql += " AND conceptid in (" + conceptids + ")";
            }

        }
        if (networkIDs != null && networkIDs.Length != 0)
        {
            sql += " AND Networkid in(";
            for (int i = 0; i < networkIDs.Length; i++)
            {
                if (i > 0) sql += ",";
                sql += networkIDs[i].ToString();

            }
            sql += ")";

        }
        //AND ((@bdate between BeginDateTime and EndDateTime ) OR ( @edate between BeginDateTime and EndDateTime ))
        using (con)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            //da.SelectCommand.Parameters.AddWithValue("@keyword", conceptCode);
            da.SelectCommand.CommandTimeout = 300;

            da.SelectCommand.Parameters.AddWithValue("@lat1", box.ymax);
            da.SelectCommand.Parameters.AddWithValue("@lat2", box.ymin);
            da.SelectCommand.Parameters.AddWithValue("@long1", box.xmax);
            da.SelectCommand.Parameters.AddWithValue("@long2", box.xmin);
            //da.SelectCommand.Parameters.AddWithValue("@bdate", beginDate);
            //da.SelectCommand.Parameters.AddWithValue("@edate", endDate);
            DataSet ds = new DataSet();
            da.Fill(ds, "SearchCatalog");

            System.Data.DataRowCollection rows = ds.Tables["SearchCatalog"].Rows;
            sites = new Site[rows.Count];
            DataRow row;
            for (int i = 0; i < rows.Count; i++)
            {
                row = rows[i];
                sites[i] = new Site();
                sites[i].SiteCode = row["SiteCode"] != null ? row["SiteCode"].ToString() : "";
                sites[i].SiteName = row["SiteName"] != null ? row["SiteName"].ToString() : "";
                sites[i].servURL = row["ServiceWSDL"] != null ? row["ServiceWSDL"].ToString() : "";
                sites[i].servCode = row["NetworkName"] != null ? row["NetworkName"].ToString() : "";
                //sites[i].HUCnumeric = row["HUCnumeric"] != null ? (int)row["HUCnumeric"] : 0;
                sites[i].Latitude = (double)row["latitude"];
                sites[i].Longitude = (double)row["longitude"];


            }
        }
        log.InfoFormat(logFormat, methodName, "Start", timer.ElapsedMilliseconds,
     String.Format(objecformat,
     conceptKeyword,
     box.xmin, box.xmax, box.ymin, box.ymax
     , networksString));
        timer.Stop();

        return sites;
    }



    #endregion

    #region variable queries:
    [WebMethod]
    public MappedVariable[] GetMappedVariables2(String conceptids, String Networkids)
    {
        String[] ceptsArray = conceptids.Split(',');
        String[] netsArray = Networkids.Split(',');
        return GetMappedVariables(ceptsArray, netsArray);
    }

    [WebMethod]
    public MappedVariable[] GetMappedVariables(String[] conceptids, String[] Networkids)
    {
        string objecformat = "concept:{0},network({1}";
        string methodName = "GetMappedVariables";
        Stopwatch timer = new Stopwatch();
        timer.Start();
        
        log.InfoFormat(logFormat, methodName, "Start", 0,
                       String.Format(objecformat,
                                     String.Join(",", conceptids),
String.Join(",", Networkids) )
                                     
           ); 
        
        string options = "";
        string sql = "SELECT     MappingsApproved.ConceptID, Variables.AltVariableName, Variables.AltVariableCode, Variables.ValueType, Variables.IsRegular, " +
                         "Variables.TimeSupport, Variables.TimeUnitID, Variables.DataType, Variables.GeneralCategory, HISNetworks.NetworkName, " +
                         "HISNetworks.ServiceWSDL " +
                      "FROM HISNetworks INNER JOIN " +
                         "Variables ON HISNetworks.NetworkID = Variables.networkId INNER JOIN " +
                         "MappingsApproved ON Variables.VariableID = MappingsApproved.VariableID " +
                      "WHERE     (HISNetworks.IsPublic = 1)";
        if (conceptids != null && conceptids.Length > 0)
        {
            if (!(conceptids.Length == 1 && conceptids[0].Length == 0))
            {
                options += " AND MappingsApproved.ConceptID in(";
                // get child concepts
                int i = 0;
                foreach (string cept in conceptids)
                {
                    if (i > 0) options += ",";
                    i++;
                    options += "'" + cept + "'";
                }
                options += ")";
            }
        }
        if (Networkids != null && Networkids.Length > 0)
        {
            if (!(Networkids.Length == 1 && Networkids[0].Length == 0))
            {
                options += " AND HISNetworks.networkid in(";
                // get child concepts
                int i = 0;
                //string[] ids = Networkids.Split(',');
                foreach (string id in Networkids)
                {
                    if (i > 0) options += ",";
                    i++;
                    options += id;
                }
                options += ")";
            }
        }
        sql += options;


        string connect = ConfigurationManager.ConnectionStrings["CentralHISConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connect);
        MappedVariable[] mappedVars = new MappedVariable[0];
        using (con)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            //da.SelectCommand.Parameters.AddWithValue("@keyword", keyword);

            //da.SelectCommand.Parameters.AddWithValue("@lat1", box.ymax);
            //da.SelectCommand.Parameters.AddWithValue("@lat2", box.ymin);
            //da.SelectCommand.Parameters.AddWithValue("@long1", box.xmax);
            //da.SelectCommand.Parameters.AddWithValue("@long2", box.xmin);
            //da.SelectCommand.Parameters.AddWithValue("@bdate", beginDate);
            //da.SelectCommand.Parameters.AddWithValue("@edate", endDate);
            DataSet ds = new DataSet();
            da.Fill(ds, "MappedVars");

            System.Data.DataRowCollection rows = ds.Tables["MappedVars"].Rows;
            mappedVars = new MappedVariable[rows.Count];
            DataRow row;
            for (int i = 0; i < rows.Count; i++)
            {
                row = rows[i];
                mappedVars[i] = new MappedVariable();
                mappedVars[i].variableName = row["AltVariableName"] != null ? row["AltVariableName"].ToString() : "";
                mappedVars[i].variableCode = row["AltVariableCode"] != null ? row["AltVariableCode"].ToString() : "";
                mappedVars[i].WSDL = row["ServiceWSDL"] != null ? row["ServiceWSDL"].ToString() : "";
                mappedVars[i].servCode = row["NetworkName"] != null ? row["NetworkName"].ToString() : "";
                mappedVars[i].conceptCode = row["ConceptID"] != null ? row["ConceptID"].ToString() : "";
                //mappedVars[i].conceptKeyword = getOntologyKeyword(mappedVars[i].conceptCode);
            }
        }

        log.InfoFormat(logFormat, methodName, "End", timer.ElapsedMilliseconds,
                      String.Format(objecformat,
                                    String.Join(",", conceptids),
String.Join(",", Networkids))

          );
        timer.Stop();
        return mappedVars;


    }
    public struct MappedVariable
    {
        public string variableName;
        public string variableCode;
        public string servCode;
        public string WSDL;
        public string conceptKeyword;
        public string conceptCode;
    }
    #endregion

    # region ServiceInfo struct and queries
    # region ServiceInfo wiki info
    /*
   GetWaterOneFlowServiceInfo

Input Parameters: A comma separated list of ServiceIDs (Optional)

Returns: A list of all WaterOneFlow web services registered with HIS Central. We need a WaterML serviceInfo type to define this and should probably have the following elements.
Data Service Name
Data Service Title
Data Service WSDL URL
Data Service Description URL
Geographic Extent (xmin, xmax, ymin, ymax)
Abstract
Contact Name
Contact Email
Contact Phone
Organization
Organization Website
Supported Methods
Citation
Value Count
Variable Count
Site Count
Earliest Record DateTime
Latest Record DateTime
ServiceStatus
   */
    #endregion
    public struct ServiceInfo
    {
        public string servURL;
        public string Title, ServiceDescriptionURL;
        public string name, Email, phone;
        public string organization, orgwebsite, citation, aabstract;
        public int valuecount, variablecount, sitecount;
        public int ServiceID;
        public string NetworkName;
        public double minx, miny, maxx, maxy;
        public string serviceStatus;
    }
    [WebMethod]
    public ServiceInfo[] GetServicesInBox(Box box)
    {
        return GetServicesInBox2(box.xmin, box.xmax, box.ymin, box.ymax);
    }
    [WebMethod]
    public ServiceInfo[] GetServicesInBox2(double xmin, double ymin, double xmax, double ymax)
    {
        string objecformat = "box({1},{2},{3},{4})";
        string methodName = "GetServicesInBox2";
        Stopwatch timer = new Stopwatch();
        timer.Start();
        
        
        log.InfoFormat(logFormat, methodName, "Start", 0,
           String.Format(objecformat,
           
           xmin, xmax, ymin, ymax
           ));

        String sql = "SELECT NetworkID, NetworkName, NetworkTitle, ServiceWSDL, ServiceAbs, ContactName, ContactEmail, ContactPhone, Organization, website,  " +
                    "   Citation, NetworkVocab, ProjectStatus, Xmin, Xmax, Ymin, Ymax, ValueCount, VariableCount, SiteCount, EarliestRec, LatestRec, ServiceStatus " +
                    "FROM hisnetworks where ispublic='true' " +
         "AND (((xmin between @minx and @maxx) or (xmax between @minx and @maxx))AND((ymin between @miny and @maxy) or (ymax between @miny and @maxy))) OR " +
         "(((@minx between xmin and xmax) or (@maxx between xmin and xmax))AND((@miny between ymin and ymax) or (@maxy between ymin and ymax))) ";
        String connect = ConfigurationManager.ConnectionStrings["CentralHISConnectionString"].ConnectionString;
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(connect);
        using (con)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, con);

            da.SelectCommand.Parameters.AddWithValue("@maxy", ymax);
            da.SelectCommand.Parameters.AddWithValue("@miny", ymin);
            da.SelectCommand.Parameters.AddWithValue("@maxx", xmax);
            da.SelectCommand.Parameters.AddWithValue("@minx", xmin);

            da.Fill(ds, "Service_LIST");
        }
        con.Close();
        //ds.Tables["URL"].Rows
        System.Data.DataRowCollection rows = ds.Tables["Service_LIST"].Rows;

var r= getServiceInfoArray(rows);
        log.InfoFormat(logFormat, methodName, "end", timer.ElapsedMilliseconds,
          String.Format(objecformat,

          xmin, xmax, ymin, ymax
          ));
        timer.Stop();

        return r;

    }
    [WebMethod]
    public ServiceInfo[] GetWaterOneFlowServiceInfo()
    {
        string methodName = "GetSitesInBox2";
        Stopwatch timer = new Stopwatch();
        timer.Start();
       
        //if (networkIDs != null )
        //{
        //    foreach (var iD in networkIDs)
        //    {
        //        networksString += iD.ToString();
        //    }
        //}
        log.InfoFormat(logFormat, methodName, "Start", 0,
           String.Empty);
        //SELECT     NetworkID, username, NetworkName, NetworkTitle, ServiceWSDL, ServiceAbs, ContactName, ContactEmail, ContactPhone, Organization, website, 
        //                  IsPublic, SupportsAllMethods, Citation, MapIconPath, OrgIconPath, LastHarvested, FrequentUpdates, logo, icon, IsApproved, NetworkVocab, 
        //                  ProjectStatus, CreatedDate, Xmin, Xmax, Ymin, Ymax, ValueCount, VariableCount, SiteCount, EarliestRec, LatestRec, ServiceStatus
        //FROM         HISNetworks
        //WHERE     (IsPublic = 'true')

        String sql = "SELECT NetworkID, NetworkName, NetworkTitle, ServiceWSDL, ServiceAbs, ContactName, ContactEmail, ContactPhone, Organization, website,  " +
                     "   Citation, NetworkVocab, ProjectStatus, Xmin, Xmax, Ymin, Ymax, ValueCount, VariableCount, SiteCount, EarliestRec, LatestRec, ServiceStatus " +
                     "FROM hisnetworks where ispublic='true' ";
        String connect = ConfigurationManager.ConnectionStrings["CentralHISConnectionString"].ConnectionString;
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(connect);
        using (con)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(ds, "Service_LIST");
        }
        con.Close();
        //ds.Tables["URL"].Rows
        System.Data.DataRowCollection rows = ds.Tables["Service_LIST"].Rows;

        

      
         var r=   getServiceInfoArray(rows);
log.InfoFormat(logFormat, methodName, "end", timer.ElapsedMilliseconds,
         String.Empty);
        timer.Stop();
        return r;

    }

    private ServiceInfo[] getServiceInfoArray(DataRowCollection rows)
    {
        ServiceInfo[] infos = new ServiceInfo[rows.Count];
        DataRow row;
        for (int i = 0; i < rows.Count; i++)
        {
            row = rows[i];
            infos[i] = new ServiceInfo();
            infos[i].ServiceID = int.Parse(row[0].ToString());
            infos[i].servURL = row["ServiceWSDL"] != null ? row["ServiceWSDL"].ToString() : "";
            infos[i].Title = row["NetworkTitle"] != null ? row["NetworkTitle"].ToString() : "";
            infos[i].NetworkName = row["NetworkName"] != null ? row["NetworkName"].ToString() : "";
            if (row["Xmin"] != null && row["Xmin"].ToString() != "")
            {
                infos[i].minx = double.Parse(row["Xmin"].ToString());
                infos[i].maxx = double.Parse(row["Xmax"].ToString());
                infos[i].miny = double.Parse(row["Ymin"].ToString());
                infos[i].maxy = double.Parse(row["Ymax"].ToString());
            }
            infos[i].valuecount = (row["ValueCount"] != null && row["ValueCount"].ToString() != "") ? int.Parse(row["ValueCount"].ToString()) : 0;
            infos[i].variablecount = (row["VariableCount"] != null && row["VariableCount"].ToString() != "") ? int.Parse(row["VariableCount"].ToString()) : 0;
            infos[i].sitecount = (row["SiteCount"] != null && row["SiteCount"].ToString() != "") ? int.Parse(row["SiteCount"].ToString()) : 0;
            infos[i].citation = row["citation"] != null ? row["citation"].ToString() : "";
            infos[i].aabstract = row["ServiceAbs"] != null ? row["ServiceAbs"].ToString() : "";
            infos[i].organization = row["Organization"] != null ? row["Organization"].ToString() : "";
            infos[i].phone = row["ContactPhone"] != null ? row["ContactPhone"].ToString() : "";
            infos[i].Email = row["ContactEmail"] != null ? row["ContactEmail"].ToString() : "";
            infos[i].orgwebsite = row["website"] != null ? row["website"].ToString() : "";
            infos[i].ServiceDescriptionURL = "http://hiscentral.cuahsi.org/pub_network.aspx?n=" + infos[i].ServiceID;
            infos[i].serviceStatus = row["ServiceStatus"] != null ? row["ServiceStatus"].ToString() : "";
        }
        return infos;
    }
    #endregion

    #region Series methods

    public struct SeriesRecord
    {
        /*
         * SiteCode ,SiteName ,HUCnumeric ,ServiceWSDL ,NetworkName ,Latitude ,Longitude 
  ,BeginDateTime ,EndDateTime ,Valuecount ,VariableName ,VariableCode ,NetworkID 
  ,TimeUnits ,HUC ,GeneralCategory ,UTCOffset ,DataType ,SampleMedium ,IsRegular 
  ,ConceptKeyword ,ConceptID ,ValueType        */

        public string ServCode;
        public string ServURL;
        public string location;
        public string VarCode;
        public string VarName;
        public string beginDate;
        public string endDate;
        public string authtoken;
        public int ValueCount;

        public string Sitename;
        public double latitude;
        public double longitude;

        public string datatype;
        public string valuetype;
        public string samplemedium;
        public string timeunits;
        public string conceptKeyword;
        public string genCategory;
        public string TimeSupport;


    }
    //private int[] getNetworkIDS(String[] netnames) { 

    //  //if (netnames == null || netnames.Length=0) return new int[0]; 
    //  //int[]
    //  //String sql = "Select networkid from hisnetworks"


    //}
    //private SeriesRecord[] getSeriesInHuc(string huc, string keyword, string beginDate, string endDate, int numRecs, int[] serviceids) { 
    // 
    //}
    [WebMethod]
    public SeriesRecord[] GetSeriesCatalogForBox(Box box, String conceptCode, int[] networkIDs, string beginDate, string endDate)
    {
        String snetids = "";
        if (networkIDs != null && networkIDs.Length > 0)
        {
            for (int i = 0; i < networkIDs.Length; i++)
            {
                if (i > 0) snetids += ",";
                snetids += (networkIDs[i]).ToString();

            }
        }
        return GetSeriesCatalogForBox2(box.xmin, box.xmax, box.ymin, box.ymax, conceptCode, snetids, beginDate, endDate);
    }

    [WebMethod]
    public SeriesRecord[] GetSeriesCatalogForBox2(double xmin, double xmax, double ymin, double ymax, string conceptKeyword, String networkIDs, string beginDate, string endDate)
    {
        string objecformat = "concept:{0},box({1},{2},{3},{4}),network({5},daterange{6}-{7}";
        string methodName = "GetSeriesCatalogForBox2";
        Stopwatch timer = new Stopwatch();
        timer.Start();
        string networksString = networkIDs ?? String.Empty;

        //if (networkIDs != null )
        //{
        //    foreach (var iD in networkIDs)
        //    {
        //        networksString += iD.ToString();
        //    }
        //}
        log.InfoFormat(logFormat, methodName, "Start", 0,
           String.Format(objecformat,
           conceptKeyword,
           xmin, xmax, ymin, ymax
           , networksString, 
           beginDate ?? String.Empty, endDate ?? String.Empty)
           );

        Box box = new Box();
        box.xmax = xmax;
        box.xmin = xmin;
        box.ymax = ymax;
        box.ymin = ymin;


        string connect = ConfigurationManager.ConnectionStrings["CentralHISConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connect);
        // allowing blank keywords through
        SeriesRecord[] series = new SeriesRecord[0];
        //if (!string.IsNullOrEmpty(keyword))
        //{
        /*
         SELECT TOP ,SiteCode,SiteName ,HUCnumeric ,ServiceWSDL ,NetworkName ,
           Latitude ,Longitude ,BeginDateTime ,EndDateTime ,Valuecount ,
           VariableName ,VariableCode ,NetworkID ,TimeUnits ,HUC ,GeneralCategory ,
           UTCOffset ,DataType ,SampleMedium ,IsRegular ,ConceptKeyword ,ConceptID ,
           ValueType 
         * */

        String conceptids = "";
        String sql = "SELECT SiteCode, SiteName, HUCnumeric, ServiceWSDL,NetworkName ,Latitude ,Longitude ," +
            " BeginDateTime,EndDateTime,Valuecount,VariableName,VariableCode,NetworkID, " +
            " TimeUnits,HUC,GeneralCategory,UTCOffset,DataType,SampleMedium,IsRegular, " +
            " ConceptKeyword,ConceptID,ValueType,TimeSupport "
                      + " FROM v_conceptSearch"
            //+ " WHERE (conceptid = @keyword) AND (Latitude BETWEEN @lat1 and @lat2) AND (Longitude BETWEEN @long1 and @long2) AND ((BeginDateTime between @bdate and @edate ) OR (EndDateTime between @bdate and @edate ) OR  ((@bdate > BeginDateTime) AND (@edate < EndDateTime)))";
                      + " WHERE ((Latitude < @lat1) and (Latitude > @lat2) AND (Longitude <  @long1) and (Longitude > @long2)) AND"
                      + " ((@bdate between BeginDateTime and EndDateTime ) OR ( @edate between BeginDateTime and EndDateTime ) OR (@edate > EndDateTime and @bdate < BeginDateTime))";
        if (conceptKeyword != null && conceptKeyword != "")
        {
            conceptids = getCommaInt(getChildIDsFlat(conceptKeyword));
            if (conceptids == "") conceptids = "0";

            sql += " AND (conceptid in (" + conceptids + "))";



        }
        if (networkIDs != null && networkIDs != "")
        {
            String[] ids = networkIDs.Split(',');
            sql += " AND Networkid in(";
            for (int i = 0; i < ids.Length; i++)
            {
                if (i > 0) sql += ",";
                sql += ids[i].ToString();

            }
            sql += ")";

        }



        using (con)
        {

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            //da.SelectCommand.Parameters.AddWithValue("@keyword", conceptCode);
            da.SelectCommand.CommandTimeout = 300;
            da.SelectCommand.Parameters.AddWithValue("@lat1", box.ymax);
            da.SelectCommand.Parameters.AddWithValue("@lat2", box.ymin);
            da.SelectCommand.Parameters.AddWithValue("@long1", box.xmax);
            da.SelectCommand.Parameters.AddWithValue("@long2", box.xmin);
            da.SelectCommand.Parameters.AddWithValue("@bdate", beginDate);
            da.SelectCommand.Parameters.AddWithValue("@edate", endDate);
            DataSet ds = new DataSet();
            da.Fill(ds, "SearchCatalog");

            System.Data.DataRowCollection rows = ds.Tables["SearchCatalog"].Rows;
            series = new SeriesRecord[rows.Count];
            DataRow row;
            for (int i = 0; i < rows.Count; i++)
            {
                row = rows[i];
                series[i] = new SeriesRecord();
                series[i].location = row[0] != null ? row[0].ToString() : "";
                series[i].Sitename = row[1] != null ? row[1].ToString() : "";
                series[i].ServURL = row["ServiceWSDL"] != null ? row["ServiceWSDL"].ToString() : "";
                series[i].ServCode = row["NetworkName"] != null ? row["NetworkName"].ToString() : "";
                series[i].latitude = (double)row["latitude"];
                series[i].longitude = (double)row["longitude"];
                series[i].ValueCount = (int)row["ValueCount"];
                series[i].VarName = row["VariableName"] != null ? row["VariableName"].ToString() : "";
                series[i].VarCode = row["VariableCode"] != null ? row["VariableCode"].ToString() : "";
                series[i].beginDate = row["BeginDateTime"] != null ? row["BeginDateTime"].ToString() : "";
                series[i].endDate = row["EndDateTime"] != null ? row["EndDateTime"].ToString() : "";
                /*  datatype; valuetype;samplemedium;timeunits; conceptKeyword; genCategory;*/
                series[i].datatype = row["DataType"] != null ? row["DataType"].ToString() : "";
                series[i].valuetype = row["ValueType"] != null ? row["ValueType"].ToString() : "";
                series[i].samplemedium = row["SampleMedium"] != null ? row["SampleMedium"].ToString() : "";
                series[i].timeunits = row["TimeUnits"] != null ? row["TimeUnits"].ToString() : "";
                series[i].conceptKeyword = row["conceptKeyword"] != null ? row["conceptKeyword"].ToString() : "";
                series[i].genCategory = row["GeneralCategory"] != null ? row["GeneralCategory"].ToString() : "";
                series[i].TimeSupport = row["TimeSupport"] != null ? row["TimeSupport"].ToString() : "";

            }
        }
        //}
        log.InfoFormat(logFormat, methodName, "end", timer.ElapsedMilliseconds,
          String.Format(objecformat,
          conceptKeyword,
          xmin, xmax, ymin, ymax
          , networksString,
          beginDate ?? String.Empty, endDate ?? String.Empty)
          );
        timer.Stop();

        return series;

    }
    [WebMethod]
    public SeriesRecord[] getSeriesCatalogInBoxPaged(double xmin, double xmax, double ymin, double ymax, string conceptKeyword, String networkIDs, string beginDate, string endDate, int pageno)
    {

        string objecformat = "concept:{0},box({1},{2},{3},{4}),network({5},daterange{6}-{7}";
        string methodName = "getSeriesCatalogInBoxPaged";
        Stopwatch timer = new Stopwatch();
        timer.Start();
        string networksString = networkIDs ?? String.Empty;

        //if (networkIDs != null )
        //{
        //    foreach (var iD in networkIDs)
        //    {
        //        networksString += iD.ToString();
        //    }
        //}
        log.InfoFormat(logFormat, methodName, "Start", 0,
           String.Format(objecformat,
           conceptKeyword,
           xmin, xmax, ymin, ymax
           , networksString,
           beginDate ?? String.Empty, endDate ?? String.Empty)
           );

        string connect = ConfigurationManager.ConnectionStrings["CentralHISConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connect);

        SeriesRecord[] series = new SeriesRecord[0];

        bool filterNetowrk = false;
        bool filterKeyword = false;


        using (con)
        {


            SqlCommand cmd = new SqlCommand("sp_SeriesSearch", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@minx", xmin);
            cmd.Parameters.AddWithValue("@miny", ymin);
            cmd.Parameters.AddWithValue("@maxx", xmax);
            cmd.Parameters.AddWithValue("@maxy", ymax);
            cmd.Parameters.AddWithValue("@beginDate", beginDate);
            cmd.Parameters.AddWithValue("@endDate", endDate);
            cmd.Parameters.AddWithValue("@pageno", pageno);
            cmd.CommandTimeout = 600;

            if (networkIDs != null && networkIDs != "")
            {
                cmd.Parameters.AddWithValue("@networkIDs", networkIDs);
                filterNetowrk = true;
            }
            if (conceptKeyword != null && conceptKeyword != "")
            {
                //verifyKeyword isvalid, and replace synonyms
                conceptKeyword = ResolveSynonyms(conceptKeyword);
                if (conceptKeyword == "")
                {
                    throw (new Exception("concept keyword not found"));
                }
                cmd.Parameters.AddWithValue("@conceptName", conceptKeyword);
                filterKeyword = true;
            }
            if (filterNetowrk && filterKeyword) cmd.CommandText = "sp_SeriesSearch_keyword_NetworkIDs";
            if (filterKeyword && !filterNetowrk) cmd.CommandText = "sp_SeriesSearch_keyword";
            if (filterNetowrk && !filterKeyword) cmd.CommandText = "sp_SeriesSearch_NetworkIDs";


            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();

            da.Fill(ds, "SearchCatalog");

            System.Data.DataRowCollection rows = ds.Tables["SearchCatalog"].Rows;
            series = new SeriesRecord[rows.Count];
            DataRow row;
            for (int i = 0; i < rows.Count; i++)
            {
                row = rows[i];
                series[i] = new SeriesRecord();
                series[i].location = row[0] != null ? row[0].ToString() : "";
                series[i].Sitename = row[1] != null ? row[1].ToString() : "";
                series[i].ServURL = row["ServiceWSDL"] != null ? row["ServiceWSDL"].ToString() : "";
                series[i].ServCode = row["NetworkName"] != null ? row["NetworkName"].ToString() : "";
                series[i].latitude = (double)row["latitude"];
                series[i].longitude = (double)row["longitude"];
                series[i].ValueCount = (int)row["ValueCount"];
                series[i].VarName = row["VariableName"] != null ? row["VariableName"].ToString() : "";
                series[i].VarCode = row["VariableCode"] != null ? row["VariableCode"].ToString() : "";
                series[i].beginDate = row["BeginDateTime"] != null ? row["BeginDateTime"].ToString() : "";
                series[i].endDate = row["EndDateTime"] != null ? row["EndDateTime"].ToString() : "";
                /*  datatype; valuetype;samplemedium;timeunits; conceptKeyword; genCategory;*/
                series[i].datatype = row["DataType"] != null ? row["DataType"].ToString() : "";
                series[i].valuetype = row["ValueType"] != null ? row["ValueType"].ToString() : "";
                series[i].samplemedium = row["SampleMedium"] != null ? row["SampleMedium"].ToString() : "";
                series[i].timeunits = row["TimeUnits"] != null ? row["TimeUnits"].ToString() : "";
                series[i].conceptKeyword = row["conceptKeyword"] != null ? row["conceptKeyword"].ToString() : "";
                series[i].genCategory = row["GeneralCategory"] != null ? row["GeneralCategory"].ToString() : "";
                series[i].TimeSupport = row["TimeSupport"] != null ? row["TimeSupport"].ToString() : "";

            }
        }
        //}
        log.InfoFormat(logFormat, methodName, "end", timer.ElapsedMilliseconds,
         String.Format(objecformat,
         conceptKeyword,
         xmin, xmax, ymin, ymax
         , networksString,
         beginDate ?? String.Empty, endDate ?? String.Empty)
         );
        timer.Stop();
        return series;
    }
    #endregion

    # region ontology stuff

    public struct OntologyConcpt
    {
        string ConceptID;
        string ConceptText;
    }
    public struct OntologyPath
    {
        public string conceptID;
        public string SearchableKeyword;
        public string ConceptName;
        public string ConceptPath;


    }
    [WebMethod]
    public OntologyPath[] getSearchablePaths()
    {
        String sql = "SELECT ConceptID,synonym as SearchableConcept,ConceptName,Path FROM v_SynonymLookup order by path";

        OntologyPath[] thetable = new OntologyPath[0];

        OntologyPath item;


        DataSet ds = new DataSet();
        String connect = ConfigurationManager.ConnectionStrings["CentralHISConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connect);
        int i = 0;
        using (con)
        {


            SqlDataAdapter da = new SqlDataAdapter(sql, con);


            da.Fill(ds, "rows");
            thetable = new OntologyPath[ds.Tables["rows"].Rows.Count];

            foreach (DataRow dataRow in ds.Tables["rows"].Rows)
            {
                item = new OntologyPath();
                item.conceptID = dataRow[0].ToString();
                item.SearchableKeyword = dataRow[1].ToString();
                item.ConceptName = dataRow[2].ToString();
                item.ConceptPath = dataRow[3].ToString();


                thetable[i] = item;

                i++;
            }

        }
        return thetable;

    }



    private string ResolveSynonyms(String keyword)
    {





        string returnval = "";
        DataSet ds = new DataSet();
        String connect = ConfigurationManager.ConnectionStrings["CentralHISConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connect);
        int i = 0;
        string sql = "select conceptName from v_synonymlookup where synonym = @conceptName";
        using (con)
        {

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.SelectCommand.Parameters.Add("@conceptName", keyword);
            da.Fill(ds, "conceptlist");
        }
        if (ds.Tables["conceptlist"].Rows.Count >= 1)
        {
            DataRow dataRow = ds.Tables["conceptlist"].Rows[0];

            returnval = dataRow[0].ToString();

        }
        return returnval;
    }
    #region removed methods
    //[WebMethod]
    //public OntologyConcept[] GetSearchableConcepts() {
    //  WebRequest objWebClient = System.Net.HttpWebRequest.Create(url);
    //  WebResponse objResponse;

    //  objResponse = objWebClient.GetResponse();

    //  String strResult;

    //  using (StreamReader sr =
    //      new StreamReader(objResponse.GetResponseStream()))
    //  {
    //    strResult = sr.ReadToEnd();
    //  }

    //  Response.Write(strResult);
    //}
    // need to come back to optimize these searches..
    //[WebMethod]
    //public String getOntologyKeyword(String conceptCode) { 
    //   OntologyClass[] ont = GetSearchableConcepts();
    //   OntologyClass o;
    //   for (int i=0;i<ont.Length;i++){
    //       o=ont[i];
    //       if (o.conceptcode.Equals(conceptCode)) return o.keyword;
    //   }
    //   return "ConceptCode not found";     

    //}
    //[WebMethod]
    //public String getOntologyConceptCode(String keyword) { 
    //     OntologyClass[] ont = GetSearchableConcepts();
    //   OntologyClass o;
    //   for (int i=0;i<ont.Length;i++){
    //       o=ont[i];
    //       if (o.keyword.Equals(keyword)) return o.conceptcode;
    //   }
    //   return "ConceptCode not found"; 
    //}
    #endregion
    public String[] getOntologyKeywords()
    {



        // allowing blank keywords through




        String sql = "SELECT conceptName from v_searchableConcepts";
        //  appContext = HttpContext.Current;
        string cacheKey = "ajaxVocabulary";

        string[] autoCompleteWordList = (string[])HttpRuntime.Cache.Get(cacheKey);
        if (autoCompleteWordList == null)
        {
            DataSet ds = new DataSet();
            String connect = ConfigurationManager.ConnectionStrings["CentralHISConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(connect);
            int i = 0;
            using (con)
            {


                SqlDataAdapter da = new SqlDataAdapter(sql, con);


                da.Fill(ds, "conceptlist");
                autoCompleteWordList = new String[ds.Tables["conceptlist"].Rows.Count];

                foreach (DataRow dataRow in ds.Tables["conceptlist"].Rows)
                {

                    //conceptid = dataRow["conceptid"].ToString();
                    String cptcode = dataRow["conceptName"].ToString();
                    //conceptKeyword = dataRow["conceptKeyword"].ToString();

                    autoCompleteWordList[i] = cptcode;

                    i++;
                }

            }
            //autoCompleteWordList = words.ToArray();
            Array.Sort(autoCompleteWordList, new CaseInsensitiveComparer());
            HttpRuntime.Cache.Add(cacheKey, autoCompleteWordList, null, DateTime.Now.AddDays(3), Cache.NoSlidingExpiration, CacheItemPriority.High, null);
        }
        return autoCompleteWordList;
        //  autoCompleteWordList = temp;
        //  appContext.Cache.Insert("ajaxVocabulary", autoCompleteWordList);

    }


    public String[] GetConceptPaths()
    {

        int[] concepts = new int[0];
        int id;
        //concepts[0] = conceptName;
        //String sql = "Select conceptid, path from conceptPaths where conceptName = @conceptName";
        String sql = "SELECT  ConceptPaths.ConceptID, ConceptPaths.Path, ConceptPaths.ConceptKeyword " +
                      " FROM         ConceptPaths INNER JOIN " +
                      " v_searchableConcepts ON ConceptPaths.ConceptID = v_searchableConcepts.ConceptID" +
                      " WHERE     (v_searchableConcepts.ConceptName = @conceptName)";

        DataSet ds = new DataSet();
        String connect = ConfigurationManager.ConnectionStrings["CentralHISConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connect);

        using (con)
        {


            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            //da.SelectCommand.Parameters.AddWithValue("conceptName", conceptName);

            da.Fill(ds, "conceptPath");



            //con.Close();
            int rowcount = ds.Tables["conceptPath"].Rows.Count;
            if (rowcount > 0)
            {

                String path = ds.Tables["conceptPath"].Rows[0][1].ToString();
                id = (int)ds.Tables["conceptPath"].Rows[0][0];
                concepts = new int[1];
                concepts[0] = id;
                sql = "Select conceptid, path from conceptPaths where path like '" + path + "%'";
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "conceptids");
                int i = 0;
                rowcount = ds.Tables["conceptids"].Rows.Count;
                if (rowcount > 0)
                {
                    concepts = new int[rowcount];
                    //concepts[i] = id;
                    //i++;
                    //OntologyNode[] child = new OntologyNode[rowcount];
                    foreach (DataRow dataRow in ds.Tables["conceptids"].Rows)
                    {

                        //conceptid = dataRow["conceptid"].ToString();
                        id = (int)dataRow[0];
                        //conceptKeyword = dataRow["conceptKeyword"].ToString();

                        concepts[i] = id;

                        i++;
                    }
                }



            }

        }
        con.Close();
        return new String[0];
    }
    [WebMethod]
    public String[] GetSearchableConcepts()
    {
        return getOntologyKeywords();

        ////  appContext = HttpContext.Current;
        //string cacheKey = "OntologyClasses";

        //OntologyClass[] ont = (OntologyClass[])HttpRuntime.Cache.Get(cacheKey);
        //if (ont == null)
        //{
        //  // dwv use a static class to generate the application URL
        //  //String ajaxOwl = getServerUrl() + "ontology/ajax.owl";
        //   //myLoader = new OntologyLoader("http://water.sdsc.edu/search/ontology/ajax.owl");
        //  //myLoader = new OntologyLoader(ajaxOwl);
        //  //OnToAJAX ajaxVoc = new OnToAJAX(myLoader.getOntologyModel());
        //  OntModel ontology = OntologyLoader.loadOntology("http://www.hydroseek.net/search/ontology/search.owl");
        //  //List<String> words = analyzeNodes(ontology);
        //  List<OntologyClass> elements = new List<OntologyClass>();

        //    List<string> mediumList = new List<string>();
        //    mediumList = getMediumList(ontology);
        //    for (ExtendedIterator allClassesItr = ontology.listClasses(); allClassesItr.hasNext(); )
        //    {
        //      OntClass k = (OntClass)allClassesItr.next();

        //      if (isCorrectElement(k))
        //      {
        //        OntologyClass oc = new OntologyClass();
        //        oc.keyword = k.getLabel("en");
        //        oc.conceptcode = k.getLocalName();
        //        elements.Add(oc);
        //        //if (checkMediumRestriction(om, k))
        //        //{

        //        //  //if (mediumList != null)
        //        //  //{
        //        //  //  foreach (String ml in mediumList)
        //        //  //  {

        //        //  //    elements.Add(k.getLabel("en") + " (" + ml + ")");
        //        //  //  }
        //        //  //}
        //        //}

        //      }
        //    }

        //  ont = elements.ToArray();
        //  //Array.Sort(autoCompleteWordList, new CaseInsensitiveComparer());
        //  HttpRuntime.Cache.Add(cacheKey, ont, null, DateTime.Now.AddDays(3), Cache.NoSlidingExpiration, CacheItemPriority.High, null);
        //}
        //return ont;
        ////  autoCompleteWordList = temp;
        ////  appContext.Cache.Insert("ajaxVocabulary", autoCompleteWordList);

    }

    [WebMethod]
    public OntologyNode getOntologyTree(String conceptKeyword)
    {
        if (conceptKeyword == null || conceptKeyword.Equals("")) conceptKeyword = "Hydrosphere";
        String sql = "SELECT conceptid, conceptName from v_ConceptsUnionSynonyms where conceptName  = @conceptKeyword";
        DataSet ds = new DataSet();
        String connect = ConfigurationManager.ConnectionStrings["CentralHISConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connect);

        using (con)
        {

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.SelectCommand.Parameters.AddWithValue("conceptKeyword", conceptKeyword);
            da.Fill(ds, "concept");
        }
        con.Close();

        int rowcount = ds.Tables["concept"].Rows.Count;
        OntologyNode node = new OntologyNode();
        if (rowcount > 0)
        {
            DataRow row = ds.Tables["concept"].Rows[0];

            node.keyword = row[1].ToString();
            node.conceptid = (int)row[0];
            return getChildNodes(node);
        }
        return node;

    }
    private string getCommaString(String[] ss)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        for (int i = 0; i < ss.Length; i++)
        {
            if (i > 0) sb.Append(',');
            sb.Append("'").Append(ss[i]).Append("'");
        }
        return sb.ToString();
    }
    private string getCommaInt(int[] ss)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        for (int i = 0; i < ss.Length; i++)
        {
            if (i > 0) sb.Append(',');
            sb.Append(ss[i]);
        }
        return sb.ToString();
    }


    public int[] getChildIDsFlat(String conceptName)
    {
        int[] concepts = new int[0];
        int id;
        //concepts[0] = conceptName;
        //String sql = "Select conceptid, path from conceptPaths where conceptName = @conceptName";
        String sql = "SELECT  ConceptPaths.ConceptID, ConceptPaths.Path " +
                      " FROM         ConceptPaths INNER JOIN " +
                      " v_searchableConcepts ON ConceptPaths.ConceptID = v_searchableConcepts.ConceptID" +
                      " WHERE     (v_searchableConcepts.ConceptName = @conceptName)";

        DataSet ds = new DataSet();
        String connect = ConfigurationManager.ConnectionStrings["CentralHISConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connect);

        using (con)
        {


            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.SelectCommand.Parameters.AddWithValue("conceptName", conceptName);

            da.Fill(ds, "conceptPath");



            //con.Close();
            int rowcount = ds.Tables["conceptPath"].Rows.Count;
            if (rowcount > 0)
            {

                String path = ds.Tables["conceptPath"].Rows[0][1].ToString();
                id = (int)ds.Tables["conceptPath"].Rows[0][0];
                concepts = new int[1];
                concepts[0] = id;
                sql = "Select conceptid from conceptPaths where path like '" + path + conceptName + "/%'";
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "conceptids");
                int i = 0;
                rowcount = ds.Tables["conceptids"].Rows.Count;
                if (rowcount > 0)
                {
                    concepts = new int[rowcount];
                    //concepts[i] = id;
                    //i++;
                    //OntologyNode[] child = new OntologyNode[rowcount];
                    foreach (DataRow dataRow in ds.Tables["conceptids"].Rows)
                    {

                        //conceptid = dataRow["conceptid"].ToString();
                        id = (int)dataRow[0];
                        //conceptKeyword = dataRow["conceptKeyword"].ToString();

                        concepts[i] = id;

                        i++;
                    }
                }



            }

        }
        con.Close();
        return concepts;
    }

    public String[] getChildConceptsFlat(String conceptName)
    {
        String[] concepts = new String[1];
        concepts[0] = conceptName;
        String sql = "Select path from conceptPaths where conceptName = @conceptName";


        DataSet ds = new DataSet();
        String connect = ConfigurationManager.ConnectionStrings["CentralHISConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connect);

        using (con)
        {


            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.SelectCommand.Parameters.AddWithValue("conceptName", conceptName);

            da.Fill(ds, "conceptPath");



            //con.Close();
            int rowcount = ds.Tables["conceptPath"].Rows.Count;
            if (rowcount > 0)
            {

                String path = ds.Tables["conceptPath"].Rows[0][0].ToString();
                sql = "Select conceptName from conceptPaths where path like '" + path + "%'";
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "concepts");
                int i = 0;
                rowcount = ds.Tables["concepts"].Rows.Count;
                if (rowcount > 0)
                {
                    concepts = new String[rowcount];
                    //OntologyNode[] child = new OntologyNode[rowcount];
                    foreach (DataRow dataRow in ds.Tables["concepts"].Rows)
                    {

                        //conceptid = dataRow["conceptid"].ToString();
                        String cptcode = dataRow["conceptName"].ToString();
                        //conceptKeyword = dataRow["conceptKeyword"].ToString();

                        concepts[i] = cptcode;

                        i++;
                    }
                }



            }

        }
        con.Close();
        return concepts;
    }

    private OntologyNode getChildNodes(OntologyNode parentNode)
    {
        OntologyNode node = new OntologyNode();
        String sql = "SELECT conceptid,  conceptName from v_conceptHierarchy where parentid = " + parentNode.conceptid + ";";



        DataSet ds = new DataSet();
        String connect = ConfigurationManager.ConnectionStrings["CentralHISConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connect);

        using (con)
        {

            SqlDataAdapter da2 = new SqlDataAdapter(sql, con);
            da2.Fill(ds, "concepts");
        }
        con.Close();


        //should be only one
        String conceptKeyword;
        int conceptid;
        int i = 0;

        int rowcount = ds.Tables["concepts"].Rows.Count;
        if (rowcount > 0)
        {
            OntologyNode[] child = new OntologyNode[rowcount];
            foreach (DataRow dataRow in ds.Tables["concepts"].Rows)
            {

                conceptid = (int)dataRow["conceptid"];
                //conceptcode = dataRow["conceptCode"].ToString();
                conceptKeyword = dataRow["conceptName"].ToString();
                child[i] = new OntologyNode();
                child[i].keyword = conceptKeyword;
                child[i].conceptid = conceptid;
                //rentNode.ChildNodes.Add(childNode);
                child[i] = getChildNodes(child[i]);
                //nextIDs.Add(conceptid);
                //conceptcode = dataRow["conceptCode"].ToString();
                i++;
            }
            parentNode.childNodes = child;
        }
        return parentNode;
    }

    public struct OntologyNode
    {
        public string keyword;
        public int conceptid;
        public OntologyNode[] childNodes;
    }


    [WebMethod]
    public string[] GetWordList(string prefixText, int count)
    {
        List<String> wordlist = new List<String>();


        int i = 0;
        string connect = ConfigurationManager.ConnectionStrings["CentralHISConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connect);
        String sql1 = "SELECT conceptName from v_searchableconcepts where conceptName = @prefixText";
        String sql2 = "SELECT top (" + count + ") conceptName from v_searchableconcepts where conceptName like @prefixText";
        DataSet ds = new DataSet();

        using (con)
        {
            // first get the item if it matches exactly...
            SqlDataAdapter da = new SqlDataAdapter(sql1, con);
            da.SelectCommand.Parameters.AddWithValue("prefixText", prefixText);
            da.Fill(ds, "words");


            foreach (DataRow dataRow in ds.Tables["words"].Rows)
            {

                wordlist.Add(dataRow[0].ToString());
                i++;
                if (i >= count) return wordlist.ToArray();

            }
            // get the items that match prefix at the beginig of the text. 
            da = new SqlDataAdapter(sql2, con);
            da.SelectCommand.Parameters.AddWithValue("prefixText", prefixText + "%");
            da.Fill(ds, "words");


            foreach (DataRow dataRow in ds.Tables["words"].Rows)
            {
                if (!wordlist.Contains(dataRow[0].ToString()))
                {
                    wordlist.Add(dataRow[0].ToString());
                    i++;
                }

                if (i >= count) return wordlist.ToArray();

            }
            // get the items that match prefix at the anywhere in the text. 
            da = new SqlDataAdapter(sql2, con);
            da.SelectCommand.Parameters.AddWithValue("prefixText", "%" + prefixText + "%");
            da.Fill(ds, "words");


            foreach (DataRow dataRow in ds.Tables["words"].Rows)
            {
                if (!wordlist.Contains(dataRow[0].ToString()))
                {
                    wordlist.Add(dataRow[0].ToString());
                    i++;
                }
                if (i >= count) return wordlist.ToArray();

            }


        }
        con.Close();
        return wordlist.ToArray();
    }




    # region commented out stuff

    //public class OntologyClass
    //{
    //    public string keyword;
    //    public string conceptcode;
    //}

    //private List<string> analyzeNodes(OntModel om)
    //{
    //  List<string> elements = new List<string>();
    //  List<string> mediumList = new List<string>();
    //  mediumList = getMediumList(om);
    //  for (ExtendedIterator allClassesItr = om.listClasses(); allClassesItr
    //      .hasNext(); )
    //  {
    //    OntClass k = (OntClass)allClassesItr.next();

    //    if (isCorrectElement(k))
    //    {
    //      elements.Add(k.getLabel("en"));
    //      if (checkMediumRestriction(om, k))
    //      {

    //        if (mediumList != null)
    //        {
    //          foreach (String ml in mediumList)
    //          {
    //            elements.Add(k.getLabel("en") + " (" + ml + ")");
    //          }
    //        }
    //      }
    //    }
    //  }


    //  return elements;
    //}

    //private bool isCorrectElement(OntClass c)
    //{
    //  bool iscor = false;
    //  //Make sure to handle exceptions!! 
    //  if (c != null)
    //  {
    //    if (c.getLocalName() != null && c.getNameSpace() != null )
    //    {
    //      iscor = c.getNameSpace().IndexOf("extended") < 0 && c.getNameSpace().IndexOf("navigation") < 0 && c.getNameSpace().IndexOf("gcmd") < 0 && !c.getLocalName().Equals("medium") && c.getLocalName().IndexOf("Axiom_") < 0 && (c.getLabel("en").ToUpper() != "OTHER");
    //    }

    //  }

    //  return iscor;
    //}
    //private bool checkMediumRestriction(OntModel m, OntClass k)
    //{
    //  bool hasMediumOptions = false;

    //  for (ExtendedIterator supClassesItr = k.listSuperClasses(); supClassesItr.hasNext(); )
    //  {
    //    OntClass s = (OntClass)supClassesItr.next();
    //    if (s.isRestriction())
    //    {

    //      Restriction r = s.asRestriction();
    //      if (r.isAllValuesFromRestriction())
    //      {

    //        AllValuesFromRestriction h = r.asAllValuesFromRestriction();
    //        if (h.getOnProperty().getLocalName() == "hasMedium")
    //        {
    //          hasMediumOptions = true;
    //        }

    //      }
    //    }

    //  }

    //  return hasMediumOptions;
    //}
    //private List<string> getMediumList(OntModel om)
    //{

    //  // Load the medium property to be used later
    //  //mediumProperty = om.getDatatypeProperty(mediumPropertyURI);

    //  // Here's the class where medium CV is located
    //  OntClass medium = om.getOntClass(media);

    //  // The List to store allowable media
    //  List<string> mediumList = new List<string>();
    //  if (medium != null)
    //  {
    //    // Get the medium instances
    //    for (ExtendedIterator mediumInst = medium.listInstances(); mediumInst.hasNext(); )
    //    {
    //      Individual i = (Individual)mediumInst.next();
    //      mediumList.Add(i.getLabel("en"));

    //    }
    //  }
    //  return mediumList;
    //}

    //private OntClass findMatchingConcept(OntModel m, SqlConnection con, string keyword)
    //  {
    //      OntClass k = null;
    //      OntClass pref = null;
    //      OntClass medium = m.getOntClass(media);
    //      string strippedName = null;
    //      string mediump = null;
    //      if (medium != null)
    //      {
    //          for (ExtendedIterator mediumInst = medium.listInstances(); mediumInst.hasNext(); )
    //          {

    //              Individual i = (Individual)mediumInst.next();
    //              mediump = i.getLabel("en");
    //              if (keyword.Contains("(" + mediump + ")"))
    //              {
    //                  strippedName = keyword.Replace(" (" + mediump + ")", "");
    //                  break;
    //              }
    //          }
    //      }

    //      for (ExtendedIterator allClassesItr = m.listClasses(); allClassesItr.hasNext(); )
    //      {

    //          k = (OntClass)allClassesItr.next();
    //          string classLabel = k.getLabel("en");

    #endregion

    #endregion
}

