using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Xml;

/// <summary>
/// Summary description for SiteInfo
/// </summary>
public class SitesResponse
{
    private string locationParam;
    private SiteInfo sinfo;
    private SeriesCatalog[] catalogs;

    public String getLocationParam() { return locationParam; }
    public SiteInfo getSiteInfo() { return sinfo; }
    public SeriesCatalog[] getSeriesCatalogs() { return catalogs; }
    

    public SitesResponse(String xml)
	{
        //
        // TODO: Add constructor logic here
        //
        System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
        System.IO.TextReader textReader = new System.IO.StringReader(xml);
        doc.Load(textReader);
        System.Xml.XmlNode node;
        System.Xml.XmlNodeList nodelist;

        // get locationParam
        nodelist = doc.GetElementsByTagName("locationParam");
        if (nodelist.Count > 0)
        {
            node = nodelist.Item(0);
            locationParam = node.InnerText;
        }
        else {
            locationParam = "";
        }

        // get SiteInfo  
        nodelist = doc.GetElementsByTagName("siteInfo");
        if (nodelist.Count > 0)
        {
            node = nodelist.Item(0);
            sinfo = this.getSiteInfo(node);
        } 

        // get Site catalogs...


        nodelist = doc.GetElementsByTagName("seriesCatalog");
        if (nodelist.Count > 0)
        {
            catalogs = this.getSeriesCatalog(nodelist);
        } 




	}
    private SeriesCatalog[] getSeriesCatalog(System.Xml.XmlNodeList nodelist)
    {

        SeriesCatalog[] cats = new SeriesCatalog[nodelist.Count];
        XmlNode node;
        for (int k = 0; k < cats.Length; k++)
        {
            cats[k] = new SeriesCatalog();
            node = nodelist.Item(k);
            if (node.Attributes["menuGroupName"] != null) cats[k].menuGroupName = node.Attributes["menuGroupName"].Value;
            if (node.Attributes["serviceWsdl"] != null) cats[k].wsdl = node.Attributes["serviceWsdl"].Value;
            cats[k].a_series = getSeriesArray(node.ChildNodes);


        }
        return cats;
    }
    private VariableType getVariableType(XmlNode node) {
        VariableType var = new VariableType();
        XmlNodeList subnodelist = node.ChildNodes;
        XmlNode subnode;
        for (int j = 0; j < subnodelist.Count; j++)
        {
            subnode = subnodelist.Item(j);
            switch (subnode.Name)
            {
                case "variableCode":
                    var.code.value = subnode.InnerText;
                    if (subnode.Attributes["vocabulary"] != null) var.code.Vocabulary = subnode.Attributes["vocabulary"].Value;

                    break;
                case "variableName":
                    var.name = subnode.InnerText;
                    break;
                case "units":
                    var.units.value = subnode.InnerText;
                    if (subnode.Attributes["unitsAbbreviation"] != null) var.units.abbreviation = subnode.Attributes["unitsAbbreviation"].Value;
                    if (subnode.Attributes["unitsCode"] != null) var.units.code = subnode.Attributes["unitsCode"].Value;
                    if (subnode.Attributes["unitsType"] != null) var.units.type = subnode.Attributes["unitsType"].Value;
                    break;
                case "variableDescription":
                    var.desc = subnode.InnerText;
                    break;
                default:
                    break;
            }
        }
        return var;
    }

    private SiteInfo getSiteInfo(System.Xml.XmlNode node){
        SiteInfo info = new SiteInfo();
        XmlNodeList subnodes = node.ChildNodes;
        XmlNode subnode;
        for (int i = 0; i < subnodes.Count; i++) {
            subnode = subnodes.Item(i);
            switch (subnode.Name) { 
                case "siteName":
                    info.siteName = subnode.InnerText;
                    break;
                case "siteCode":
                    info.sitecode = subnode.InnerText;
                    break;

                case "geoLocation":
                    info.loc = this.getLocInfo(subnode);
                    break;
                default:
                    break;

            }
        
        }
        return info;
    }
    private GeoLocation getLocInfo(XmlNode node){
        GeoLocation gloc = new GeoLocation();

        XmlNode subnode = node.FirstChild;
        if (subnode.Attributes["srs"] != null)
        {
            gloc.srs = subnode.Attributes["srs"].Value;
        }
        XmlNodeList sublist = subnode.ChildNodes;
        for (int i = 0; i < sublist.Count; i++) {
            switch (sublist.Item(i).Name) { 
                case "latitude":
                    gloc.lat = double.Parse(sublist.Item(i).InnerText);
                    break;
                case "longitude":
                    gloc.lng = double.Parse(sublist.Item(i).InnerText);
                    break;
                default: break;

            }
        }
        return gloc;

    }

    public class GeoLocation
    {
        public string srs;
        public double lat;
        public double lng;
        public GeoLocation() {
            srs = "";
            lat = 0;
            lng = 0;
        }

    }
    public class SeriesCatalog {
        public Series[] a_series;
        public String wsdl;
        public String menuGroupName;
        public SeriesCatalog()
        {
            a_series = new Series[0];
            wsdl = "";
            menuGroupName = "";

        }
        

    }
    public class SiteInfo {

        public string siteName; 
        public string sitecode;
        public GeoLocation loc;
        public SiteInfo() { 
            siteName = "";
            sitecode = "";
            loc = new GeoLocation();
        }
    }
    private Series[] getSeriesArray(XmlNodeList nodelist){
        int count = 0;
        for (int i = 0; i < nodelist.Count; i++) { 
            if (nodelist.Item(i).Name.ToLower()=="series"){
                count++;
            }
        }
        Series[] seriesAry = new Series[count];
        count = 0;
        for (int i = 0; i < nodelist.Count; i++)
        {
            if (nodelist.Item(i).Name.ToLower() == "series")
            {
               
                seriesAry[count] = getSeries(nodelist.Item(i));
                count++;
            }
        }
        return seriesAry;

    }
    public Series getSeries(XmlNode node) {
        Series s = new Series();
        XmlNodeList subnodes = node.ChildNodes;
        XmlNode subnode;
        for (int i = 0; i < subnodes.Count; i++)
        {
            subnode = subnodes.Item(i);
            switch (subnode.Name)
            {
                case "variable":
                    s.vtype = getVariableType(subnode);
                    break;
                case "valueCount":
                    s.valueCount = int.Parse(subnode.InnerText);
                    if (subnode.Attributes["countIsEstimated"] != null) s.isEstimate = (subnode.Attributes["countIsEstimated"].Value.ToLower() == "true");
                    break;
                case "variableTimeInterval":
                    s.startDateTime = subnode.FirstChild.InnerText;

                    if (s.startDateTime == "P31D")
                    {
                        DateTime enddate = DateTime.Now;
                        s.endDateTime = TestUtils.getStringFromDate(enddate);
                        s.startDateTime = TestUtils.getStringFromDate(enddate.AddDays(-31));
                        //s.isRealTime = true;
                    }
                    else
                    {
                        s.endDateTime = subnode.LastChild.InnerText;
                        if (s.startDateTime == s.endDateTime) s.isRealTime = true;
                    }
                    break;
                default: break;

            }
        }
        return s;
    
    }
    public class Series
    {
        /*   <series>
   <variable>
      <variableCode vocabulary="NWIS" default="true" variableID="12582">00065</variableCode> 
      <variableName>Gage height, feet</variableName> 
      <units unitsAbbreviation="ft" unitsCode="48">international foot</units> 
    </variable>
    <valueCount countIsEstimated="true">278</valueCount> 
-   <variableTimeInterval": xsi:type="TimeIntervalType">
      <beginDateTime>2005-09-26T00:00:00</beginDateTime> 
      <endDateTime>2006-07-31T00:00:00</endDateTime> 
    </variableTimeInterval>
  </series>*/

        public VariableType vtype;
        public string startDateTime;
        public string endDateTime;
        public Boolean isRealTime;
        public int valueCount;
        public Boolean isEstimate;
        public Series()
        {
            vtype = new VariableType();
            startDateTime = "";
            endDateTime = "";
            valueCount = 0;
            isEstimate = false;
            isRealTime = false;

        }
    }

}
/*
 
<sitesResponse xmlns:gml="http://www.opengis.net/gml" xmlns:xlink="http://www.w3.org/1999/xlink" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:wtr="http://www.cuahsi.org/waterML/" xmlns="http://www.cuahsi.org/waterML/1.0/">
 <queryInfo>
  <criteria>
   <locationParam>NWIS:01103025</locationParam> 
  </criteria>
 </queryInfo>
 <site>
  <siteInfo>
   <siteName>ALEWIFE BROOK NEAR ARLINGTON, MA</siteName> 
   <siteCode network="NWIS" siteID="4603496">01103025</siteCode> 
   <geoLocation>
    <geogLocation xsi:type="LatLonPointType" srs="EPSG:4269">
     <latitude>42.40704077</latitude> 
     <longitude>-71.1339422</longitude> 
    </geogLocation>
   </geoLocation>
  </siteInfo>
  <seriesCatalog menuGroupName="USGS Daily Values" serviceWsdl="http://water.sdsc.edu/waterOneFlow/DailyValues.asmx">
   <note type="sourceUrl">http://waterdata.usgs.gov/nwis/dv?referred_module=sw&format=rdb&date_format=YYYY-MM-DD&begin_date=2006-11-09&site_no=01103025</note> 
   <series>
   <variable>
    <variableCode vocabulary="NWIS" default="true" variableID="12582">00065</variableCode> 
      <variableName>Gage height, feet</variableName> 
      <units unitsAbbreviation="ft" unitsCode="48">international foot</units> 
    </variable>
    <valueCount countIsEstimated="true">278</valueCount> 
-   <variableTimeInterval xsi:type="TimeIntervalType">
      <beginDateTime>2005-09-26T00:00:00</beginDateTime> 
      <endDateTime>2006-07-31T00:00:00</endDateTime> 
    </variableTimeInterval>
  </series>
- <series>
- <variable>
  <variableCode vocabulary="NWIS" default="true" variableID="12574">00055</variableCode> 
  <variableName>Stream velocity, feet per second</variableName> 
  <units unitsAbbreviation="ft/s" unitsCode="113">feet per second</units> 
  </variable>
  <valueCount countIsEstimated="true">278</valueCount> 
- <variableTimeInterval xsi:type="TimeIntervalType">
  <beginDateTime>2005-09-26T00:00:00</beginDateTime> 
  <endDateTime>2006-07-31T00:00:00</endDateTime> 
  </variableTimeInterval>
  </series>
  </seriesCatalog>
  </site>
  </sitesResponse>
 */

