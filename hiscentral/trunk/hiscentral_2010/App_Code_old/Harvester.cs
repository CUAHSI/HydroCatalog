using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.XPath;
using System.Net;
using System.Data;

using System.IO;
using System.Reflection;
using System.Net.Sockets;


/// <summary>
/// Summary description for harvester
/// </summary>
public class Harvester
{
  Hashtable varList;
  String URL;
  String connect;
  String stationName;
  List<int> seriescatalogList;
  int SourceID;
  int currentSiteIdentifier;
  int maxVariableIdentifier;
	public Harvester(String id)
	{
    SourceID = int.Parse(id);
    connect = ConfigurationManager.ConnectionStrings["CentralHISConnectionString"].ConnectionString;
    //connect = "Data Source=water.sdsc.edu;Initial Catalog=HISCentral;User ID=ODMuser;Password=im2nopploki;";
    //HarvestNetwork(id);
	}
  public void HarvestNetwork()
  {
    String sql = "SELECT Link, Organization from Sources WHERE sourceID = " + SourceID.ToString();
    URL = " ";
    Console.WriteLine(sql);
    String Organization = " ";
    DataSet ds = new DataSet();
    SqlConnection con = new SqlConnection(connect);

    using (con)
    {
      SqlDataAdapter da = new SqlDataAdapter(sql, con);
      da.Fill(ds, "URL");
    }
    con.Close();
    //should be only one
    foreach (DataRow dataRow in ds.Tables["URL"].Rows)
    {
      URL = dataRow["Link"].ToString();
      Organization = dataRow["Organization"].ToString();
      GetSiteList(Organization);
      //once update is complete insert the date of update
      SqlConnection co = new SqlConnection(connect);
      co.Open();
      String updateSchedule = "UPDATE HISNetworks SET LastHarvested='" + DateTime.Now + "' WHERE NetworkID=" + SourceID;
      Console.WriteLine(updateSchedule);
      SqlCommand msco = new SqlCommand(updateSchedule, co);
      msco.ExecuteNonQuery();
      msco.Dispose();
      co.Close();

    }

  }


  private void GetSiteList(String organization)
  {
    varList = new Hashtable();
    XmlDocument doc = null;
    string nameSpace = "http://www.cuahsi.org/his/1.0/ws/";
    string methodName = "GetSites";
    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(URL);
    req.Headers.Add("SOAPAction", "\"" + nameSpace + methodName + "\"");
    req.ContentType = "text/xml;charset=utf-8";
    req.Method = "POST";
    string soapEnv = "<?xml version=\"1.0\" encoding=\"utf-8\"?><soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\"><soap:Body><GetSites xmlns=\"http://www.cuahsi.org/his/1.0/ws/\"><site/><authToken/></GetSites></soap:Body></soap:Envelope>";
    ASCIIEncoding enc = new ASCIIEncoding();
    byte[] soapEnvByte = enc.GetBytes(soapEnv);
    Stream strm = req.GetRequestStream();

    strm.Write(soapEnvByte, 0, soapEnvByte.Length);
    WebResponse resp = null;
    strm.Close(); try
    {
      resp = req.GetResponse();
    }
    catch (WebException e)
    {
      //Console.WriteLine(e.Message);
      // return null;
    }
    if (resp != null)
    {
      strm = resp.GetResponseStream();
      StreamReader rdr = new StreamReader(strm);
      string result = rdr.ReadToEnd();
      doc = new XmlDocument();
      doc.LoadXml(result);
    }

    ProcessSiteList(doc, organization);


  }


  private void ProcessSiteList(XmlDocument doc, String organization)
  {


    XmlElement xRoot = doc.DocumentElement;
    String dbOrg = organization;
    XmlNamespaceManager nsMgr = new XmlNamespaceManager(doc.NameTable);
    nsMgr.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/");
    nsMgr.AddNamespace("wsr", "http://www.cuahsi.org/his/1.0/ws/");
    nsMgr.AddNamespace("wml", "http://www.cuahsi.org/waterML/1.0/");
    XmlNodeList stations = xRoot.SelectNodes("/soap:Envelope/soap:Body/wsr:GetSitesResponse/wml:sitesResponse/wml:site/wml:siteInfo", nsMgr);
    foreach (XmlNode st in stations)
    {
      XmlNode latNode = st.SelectSingleNode("wml:geoLocation/wml:geogLocation/wml:latitude", nsMgr);
      XmlNode lonNode = st.SelectSingleNode("wml:geoLocation/wml:geogLocation/wml:longitude", nsMgr);
      XmlNode staName = st.SelectSingleNode("wml:siteName", nsMgr);
      stationName = staName.InnerText;
      XmlNode staCode = st.SelectSingleNode("wml:siteCode", nsMgr);
      XmlAttributeCollection staAttribute = staCode.Attributes;
      if (staAttribute["network"] != null)
      {
        organization = staAttribute["network"].InnerText;
      }

      if (latNode != null && lonNode != null)
      {
        UpdateSiteList(organization + ":" + staCode.InnerText, stationName.Replace("'", "''"), latNode.InnerText, lonNode.InnerText, dbOrg);
      }
    }
  }

  // This method updates Sites table in the ODM.
  private void UpdateSiteList(String siteCode, String siteName, String latitude, String longitude, String organization)
  {
    currentSiteIdentifier = 0;
    DataSet sites = new DataSet();
    SqlConnection con = new SqlConnection(connect);
    con.Open();
    String siteQuery = "SELECT SiteID FROM Sites WHERE SiteCode='" + siteCode + "' AND OrganizationName='" + organization + "'";
    using (con)
    {
      SqlDataAdapter dst = new SqlDataAdapter(siteQuery, con);
      dst.Fill(sites, "SiteList");
    }
    con.Close();
    if (!(sites.Tables["SiteList"].Rows.Count > 0))
    {
      con = new SqlConnection(connect);
      con.Open();
      String insertNewSite = "INSERT INTO Sites VALUES ('" + siteCode + "','" + siteName + "'," + latitude + "," + longitude + ",NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'" + organization + "',NULL,NULL)";
      Console.WriteLine(insertNewSite);
      SqlCommand mysco = new SqlCommand(insertNewSite, con);
      try
      {
        mysco.ExecuteNonQuery();
      }
      catch (Exception exc)
      {
        Console.WriteLine(exc.Message);
      }
      mysco.Dispose();
      con = new SqlConnection(connect);
      con.Open();
      String maxSiteIDQuery = "SELECT MAX(SiteID) as maxSiteID FROM Sites";
      DataSet maxID = new DataSet();
      using (con)
      {
        SqlDataAdapter mxAd = new SqlDataAdapter(maxSiteIDQuery, con);
        mxAd.Fill(maxID, "maxID");
        mxAd.Dispose();
      }

      foreach (DataRow dRow in maxID.Tables["maxID"].Rows)
      {
        currentSiteIdentifier = int.Parse(dRow["maxSiteID"].ToString());

      }
      con.Close();

    }
    else
    {
      foreach (DataRow daRow in sites.Tables["SiteList"].Rows)
      {
        currentSiteIdentifier = int.Parse(daRow["SiteID"].ToString());

      }
    }

    sites.Dispose();
    con.Close();
    GetSiteInfo(siteCode);
  }

  private void GetSiteInfo(String siteCode)
  {
    XmlDocument doc = null;
    string nameSpace = "http://www.cuahsi.org/his/1.0/ws/";
    string methodName = "GetSiteInfoObject";
    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(URL);
    req.Headers.Add("SOAPAction", "\"" + nameSpace + methodName + "\"");
    req.ContentType = "text/xml;charset=utf-8";
    req.Method = "POST";
    string soapEnv = "<?xml version=\"1.0\" encoding=\"utf-8\"?><soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\"><soap:Body><GetSiteInfoObject xmlns=\"http://www.cuahsi.org/his/1.0/ws/\"><site>" + siteCode + "</site><authToken/></GetSiteInfoObject></soap:Body></soap:Envelope>";
    ASCIIEncoding enc = new ASCIIEncoding();
    byte[] soapEnvByte = enc.GetBytes(soapEnv);
    Stream strm = req.GetRequestStream();

    strm.Write(soapEnvByte, 0, soapEnvByte.Length);
    WebResponse resp = null;
    strm.Close(); try
    {
      resp = req.GetResponse();
    }
    catch (WebException e)
    {
      Console.WriteLine(e.Message);
      return;
    }
    if (resp != null)
    {
      strm = resp.GetResponseStream();
      StreamReader rdr = new StreamReader(strm);
      string result = rdr.ReadToEnd();
      doc = new XmlDocument();
      doc.LoadXml(result);
      ProcessSiteInfoForCatalog(doc, siteCode);
    }


  }


  private void ProcessSiteInfoForCatalog(XmlDocument doc, String siteCode)
  {
    seriescatalogList = new List<int>();
    XmlElement xRoot = doc.DocumentElement;
    XmlNamespaceManager nsMgr = new XmlNamespaceManager(doc.NameTable);
    nsMgr.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/");
    nsMgr.AddNamespace("wsr", "http://www.cuahsi.org/his/1.0/ws/");
    nsMgr.AddNamespace("wml", "http://www.cuahsi.org/waterML/1.0/");
    String varNameString = "NULL";
    String valTypeString = "NULL";
    String dataTypeString = "NULL";
    String sampleMediumString = "'Surface Water'";
    String unitsString = "NULL";
    String unitsCodeString = "NULL";
    String isRegString = "NULL";
    String unitIDString = "NULL";
    String timeIntervalString = "NULL";
    String varVocab = "NULL";
    String varID;
    XmlNodeList stations = xRoot.SelectNodes("/soap:Envelope/soap:Body/wsr:GetSiteInfoObjectResponse/wml:sitesResponse/wml:site/wml:seriesCatalog/wml:series", nsMgr);
    foreach (XmlNode st in stations)
    {
      XmlNode varCode = st.SelectSingleNode("wml:variable/wml:variableCode", nsMgr);
      XmlAttributeCollection varCodeVocabulary = varCode.Attributes;
      varVocab = varCodeVocabulary["vocabulary"].InnerText;
      varID = varCodeVocabulary["variableID"].InnerText;
      XmlNode varName = st.SelectSingleNode("wml:variable/wml:variableName", nsMgr);
      if (varName != null) { varNameString = varName.InnerText; }
      XmlNode valType = st.SelectSingleNode("wml:variable/wml:valueType", nsMgr);
      if (valType != null) { valTypeString = valType.InnerText ; }
      XmlNode dataType = st.SelectSingleNode("wml:variable/wml:dataType", nsMgr);
      if (dataType != null) { dataTypeString =  dataType.InnerText ; }
      XmlNode sampleMedium = st.SelectSingleNode("wml:variable/wml:sampleMedium", nsMgr);
      if (sampleMedium != null) { sampleMediumString = sampleMedium.InnerText ; }
      XmlNode units = st.SelectSingleNode("wml:variable/wml:units", nsMgr);
      if (units != null){
        unitsString = units.InnerText ;
        XmlAttributeCollection unitsCode = units.Attributes;
        if (unitsCode != null && unitsCode["unitsCode"] != null) { unitsCodeString = "'" + unitsCode["unitsCode"].InnerText + "'"; }
        XmlNode timeSup = st.SelectSingleNode("wml:variable/wml:timeSupport", nsMgr);
        if (timeSup != null)
        {
          XmlAttributeCollection isReg = timeSup.Attributes;
          if (isReg != null) { isRegString = "'" + isReg["isRegular"].InnerText + "'"; }

          XmlNode timeUnit = st.SelectSingleNode("wml:variable/wml:timeSupport/wml:unit", nsMgr);
          if (isReg != null && isReg["isRegular"].InnerText.Equals("false") && timeUnit == null)
          {
            unitIDString = "104";
            timeIntervalString = "0";
            dataTypeString = "Instantaneous";
          }
          else
          {
            if (timeUnit != null)
            {
              XmlAttributeCollection unitID = timeUnit.Attributes;
              if (unitID != null)
              {
                unitIDString = unitID["UnitID"].InnerText;
              }
            }

            XmlNode timeInterval = st.SelectSingleNode("wml:variable/wml:timeSupport/wml:timeInterval", nsMgr);
            if (timeInterval != null)
            {
              timeIntervalString = timeInterval.InnerText;
            }
          }
        }
      }

      XmlNode valueCount = st.SelectSingleNode("wml:valueCount", nsMgr);
      XmlNode beginDate = st.SelectSingleNode("wml:variableTimeInterval/wml:beginDateTime", nsMgr);
      XmlNode endDate = st.SelectSingleNode("wml:variableTimeInterval/wml:endDateTime", nsMgr);
      if (varVocab != "NWIS" && varVocab != "EPA")
      {
        bool isNewVar = false;
        try
        {
          // this makes sure duplicates won't be inserted
          varList.Add(varID, varID);
          isNewVar = true;
        }
        catch
        {
          isNewVar = false;
        }

        if (isNewVar)
        {
          createNewVar(varVocab + ":" + varCode.InnerText, varNameString, unitsString, varID, valTypeString, sampleMediumString, unitsCodeString, dataTypeString, timeIntervalString, unitIDString, isRegString);

        }
        //Keep a list that comes from web service to compare with the database
        seriescatalogList.Add(int.Parse(varList[varID].ToString()));
        insertIntoSeriesCatalog(currentSiteIdentifier, siteCode, stationName.Replace("'", "''"), varList[varID].ToString(), varVocab + ":" + varCode.InnerText, varNameString, beginDate.InnerText, endDate.InnerText, valueCount.InnerText);
      }

    }
    // This part deals with deletion of no longer supported measurements by deleting records in the database that has no match in the webservice output
    SqlConnection con = new SqlConnection(connect);
    con.Open();
    String queryBuilder = " ";
    foreach (int k in seriescatalogList)
    {
      queryBuilder = queryBuilder + " AND VariableID<>" + k;
    }
    String updateCatalog = "DELETE FROM SeriesCatalog WHERE SiteID=" + currentSiteIdentifier + queryBuilder;
    SqlCommand msco = new SqlCommand(updateCatalog, con);
    msco.ExecuteNonQuery();
    msco.Dispose();
    con.Close();
    queryBuilder = " ";
  }
  private void createNewVar(String varCode, String varName, String units, String variableID, String valueType, String sampleMedium, String unitsCode, String dataType, String timeSupport, String timeUnit, String isRegular)
  {

    DataSet vars = new DataSet();
    SqlConnection con = new SqlConnection(connect);
    con.Open();
    String varQuery = "SELECT VariableID FROM Variables WHERE AltVariableCode='" + varCode + "' AND networkId=" + SourceID;
    // String varQuery = "SELECT VariableID FROM Variables WHERE AltVariableCode='" + varCode + "' AND AltVariableName=" + varName;
    // if (dataType!="NULL") varQuery = varQuery + " AND dataType="+dataType;
    // if (timeSupport!="NULL") varQuery = varQuery + " AND timeSupport="+timeSupport;
    // if (timeUnit != "NULL") varQuery = varQuery + " AND timeUnitID=" + timeUnit;
    //  if (sampleMedium != "NULL") varQuery = varQuery + " AND SampleMedium=" + sampleMedium;
    //  if (units != "NULL") varQuery = varQuery + " AND AltUnits=" + units;
    using (con)
    {
      SqlDataAdapter dst = new SqlDataAdapter(varQuery, con);
      dst.Fill(vars, "VariableList");
    }
    con.Close();

    con = new SqlConnection(connect);
    con.Open();
    if (!(vars.Tables["VariableList"].Rows.Count > 0))
    {
      String maxVarIDQuery = "SELECT MAX(VariableID) as maxVariableID FROM Variables";
      DataSet maxID = new DataSet();
      using (con)
      {
        SqlDataAdapter mxAd = new SqlDataAdapter(maxVarIDQuery, con);
        mxAd.Fill(maxID, "maxID");
        mxAd.Dispose();
      }

      foreach (DataRow dRow in maxID.Tables["maxID"].Rows)
      {

        try
        {
          maxVariableIdentifier = int.Parse(dRow["maxVariableID"].ToString());
        }
        catch (Exception)
        {
          maxVariableIdentifier = 0;
        }

      }
      con.Close();
      if (varCode.Length < 21)
      {
        con = new SqlConnection(connect);
        con.Open();
        //String insertVar = "INSERT INTO Variables VALUES (" + (maxVariableIdentifier + 1) + ",NULL,NULL," + sampleMedium + "," + valueType + "," + isRegular + "," + timeSupport + "," + timeUnit + "," + dataType + ", NULL,'" + varCode + "'," + varName + "," + units + "," + SourceID + ")";
        String insertVar = "INSERT INTO Variables(VariableID, SampleMedium, ValueType, IsRegular, TimeSupport,TimeUnitID,DataType, AltVariableCode, AltVariableName, AltUnits, networkID)" +
               "VALUES (@VariableID, @SampleMedium, @ValueType, @IsRegular, @TimeSupport,@TimeUnitID,@DataType, @AltVariableCode, @AltVariableName, @AltUnits, @networkID)";
        //match the variableID in the web service with its counterpart in the database
        varList[variableID] = maxVariableIdentifier + 1;
        SqlCommand mysco = new SqlCommand(insertVar, con);
        SqlParameterCollection parms = mysco.Parameters;

        parms.Clear();
        parms.AddWithValue("VariableID", maxVariableIdentifier + 1);
        //parms.AddWithValue("Variable", null);
        //parms.AddWithValue("UnitID", null);
        parms.AddWithValue("SampleMedium", sampleMedium);
        parms.AddWithValue("ValueType", valueType);
        parms.AddWithValue("IsRegular", (isRegular=="true" ? true : false));
        parms.AddWithValue("TimeSupport", timeSupport);
        parms.AddWithValue("TimeUnitID", timeUnit);
        parms.AddWithValue("DataType", dataType);
        //parms.AddWithValue("GeneralCategory", null);
        parms.AddWithValue("AltVariableCode", varCode);
        parms.AddWithValue("AltVariableName", varName);
        parms.AddWithValue("AltUnits", units);
        parms.AddWithValue("networkID", SourceID);
        mysco.ExecuteNonQuery();
        mysco.Dispose();
        con.Close();
      }
    }
    else
    {

      foreach (DataRow dRow in vars.Tables["VariableList"].Rows)
      {
        //match the variableID in the web service with its counterpart in the database
        varList[variableID] = int.Parse(dRow["VariableID"].ToString());

      }


    }

  }


  private void insertIntoSeriesCatalog(int currentSiteIdentifier, String siteCode, String siteName, String AssignedVarID, String varCode, String varName, String beginDate, String endDate, String valueCount)
  {

    DataSet series = new DataSet();
    SqlConnection con = new SqlConnection(connect);
    con.Open();
    String seriesQuery = "SELECT VariableID FROM SeriesCatalog WHERE SiteID=" + currentSiteIdentifier + " AND VariableCode='" + varCode + "' AND VariableID=" + AssignedVarID;

    using (con)
    {
      SqlDataAdapter dst = new SqlDataAdapter(seriesQuery, con);
      dst.Fill(series, "Catalog");
    }
    con.Close();
    // if there's no similar catalog entry, insert it
    if (!(series.Tables["Catalog"].Rows.Count > 0) && varCode.Length < 21)
    {
      con = new SqlConnection(connect);
      con.Open();
      //String insertVar = "INSERT INTO SeriesCatalog VALUES (NULL," + currentSiteIdentifier + ",'" + siteCode + "','" + siteName + "'," + AssignedVarID + ",'" + varCode + "'," + varName + ",NULL,NULL,NULL,NULL,'" + beginDate + "','" + endDate + "'," + valueCount + ",NULL,NULL," + SourceID + ")";
      //SqlCommand mysco = new SqlCommand(insertVar, con);
      //String insertVar = "INSERT INTO SeriesCatalog(SeriesID, SiteID, SiteCode, SiteName, VariableID, VariableName, VariableUnitsID,VariableUnitsName, SampleMedium,ValueType,BeginDateTime, EndDateTime, ValueCount, GeneralCategory, UTCOffset, SourceID)" +
      //         "VALUES (@SeriesID, @SiteID, @SiteCode, @SiteName, @VariableID, @VariableName, @VariableUnitsID,@VariableUnitsName, @SampleMedium,@ValueType,@BeginDateTime, @EndDateTime, @ValueCount, @GeneralCategory, @UTCOffset, @SourceID)";
      String insertVar = "INSERT INTO SeriesCatalog( SiteID, SiteCode, SiteName, VariableID, VariableName, VariableCode,  BeginDateTime, EndDateTime, ValueCount,  SourceID)" +
               "VALUES (@SiteID, @SiteCode, @SiteName, @VariableID, @VariableName, @VariableCode, @BeginDateTime, @EndDateTime, @ValueCount, @SourceID)";
      //match the variableID in the web service with its counterpart in the database
      
      SqlCommand mysco = new SqlCommand(insertVar, con);
      SqlParameterCollection parms = mysco.Parameters;
      parms.Clear();
      //parms.AddWithValue("SeriesID", null);
      parms.AddWithValue("SiteID", currentSiteIdentifier);
      parms.AddWithValue("SiteCode", siteCode);
      parms.AddWithValue("Sitename", siteName);
      parms.AddWithValue("VariableID", AssignedVarID);
      parms.AddWithValue("VariableCode", varCode);
      parms.AddWithValue("VariableName", varName);
      //parms.AddWithValue("VariableUnitsID", null);
      //parms.AddWithValue("VariableUnitsName", null);
      //parms.AddWithValue("SampleMedium", null);
      //parms.AddWithValue("ValueType", null);
      parms.AddWithValue("BeginDateTime", beginDate);
      parms.AddWithValue("EndDateTime", endDate);
      parms.AddWithValue("ValueCount", valueCount);
      //parms.AddWithValue("GeneralCategory", null);
      //parms.AddWithValue("UTCOffset", null);
      parms.AddWithValue("SourceID", SourceID);
      mysco.ExecuteNonQuery();
      mysco.Dispose();
      con.Close();

    }
    // if catalog entry already exists, update the entry
    else
    {
      con = new SqlConnection(connect);
      con.Open();
      String updateVar = "UPDATE SeriesCatalog SET BeginDateTime='" + beginDate + "', EndDateTime='" + endDate + "', ValueCount=" + valueCount + " WHERE SiteID=" + currentSiteIdentifier + "AND VariableID=" + AssignedVarID;
      SqlCommand mysco = new SqlCommand(updateVar, con);
      mysco.ExecuteNonQuery();
      mysco.Dispose();
      con.Close();

    }

  }
}
