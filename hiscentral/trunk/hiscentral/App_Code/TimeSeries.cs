using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for TimeSeries
/// </summary>
public class TimeSeries
{


    private TimeValue[] m_values;
    private VariableType m_var;
    public TimeValue[] getValues() { return m_values; }
    public VariableType getVariable() { return m_var; }
	public TimeSeries(String xml)
	{
        
        System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
        System.IO.TextReader textReader = new System.IO.StringReader(xml);
        doc.Load(textReader);
        System.Xml.XmlNode node, subnode;
        System.Xml.XmlNodeList nodelist = doc.GetElementsByTagName("variable");
        System.Xml.XmlNodeList subnodelist;
       

        // get variable info
        if (nodelist != null && nodelist.Count > 0)
        {
            node = nodelist.Item(0);
            m_var = new VariableType();
            subnodelist = node.ChildNodes;
            for (int j = 0; j < subnodelist.Count; j++)
            {
                subnode = subnodelist.Item(j);
                switch (subnode.Name)
                {
                    case "variableCode":
                        m_var.code.value = subnode.InnerText;
                        if (subnode.Attributes["vocabulary"] != null) m_var.code.Vocabulary = subnode.Attributes["vocabulary"].Value;

                        break;
                    case "variableName":
                        m_var.name = subnode.InnerText;
                        break;
                    case "units":
                        m_var.units.value = subnode.InnerText;
                        if (subnode.Attributes["unitsAbbreviation"] != null) m_var.units.abbreviation = subnode.Attributes["unitsAbbreviation"].Value;
                        if (subnode.Attributes["unitsCode"] != null) m_var.units.code = subnode.Attributes["unitsCode"].Value;
                        if (subnode.Attributes["unitsType"] != null) m_var.units.type = subnode.Attributes["unitsType"].Value;
                        break;
                    case "variableDescription":
                        m_var.desc = subnode.InnerText;
                        break;
                    default:
                        break;
                }

            }

        }
        // get values
        nodelist = doc.GetElementsByTagName("values");
        if (nodelist != null && nodelist.Count > 0) {
            node = nodelist.Item(0);
            subnodelist = node.ChildNodes;
            m_values = new TimeValue[subnodelist.Count];
            for (int j = 0; j < subnodelist.Count; j++)
            {
                subnode = subnodelist.Item(j);
                m_values[j] = new TimeValue();
                m_values[j].val = subnode.InnerText;
                if (subnode.Attributes["dateTime"] != null) m_values[j].time = subnode.Attributes["dateTime"].Value;

            }
        }
	}
}
public class TimeValue
{
    public string time;
    public string val;
    public TimeValue() {
        time = "";
        val = "";
    }
}
/*
   SAMPLE RESPONSE     
<timeSeriesResponse xmlns:gml="http://www.opengis.net/gml" xmlns:xlink="http://www.w3.org/1999/xlink" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:wtr="http://www.cuahsi.org/waterML/" xmlns="http://www.cuahsi.org/waterML/1.0/">
    <queryInfo>
    <queryURL>http://motherlode.ucar.edu:8080/thredds/dodsC/model/NCEP/NAM/CONUS_12km/NAM_CONUS_12km_20061108_0000.grib2.ascii?Total_precipitation[0:1:27][310:1:310][149:1:149]</queryURL> 
    <criteria>
        <locationParam>GEOM:POINT(-113 45)</locationParam> 
        <variableParam>NAM:1</variableParam> 
        <timeParam>
            <beginDateTime>2006-11-09T00:00:00</beginDateTime> 
            <endDateTime>2006-11-11T00:00:00-08:00</endDateTime> 
        </timeParam>
    </criteria>
    </queryInfo>
    <timeSeries name="NAM12KM">
      <sourceInfo xsi:type="DataSetInfoType">
          <dataSetIdentifier>NAM12KM</dataSetIdentifier> 
          <dataSetLocation xsi:type="LatLonPointType">
              <latitude>45</latitude> 
              <longitude>-113</longitude> 
          </dataSetLocation>
      </sourceInfo>
      <variable>
          <variableCode vocabulary="NAM">1</variableCode> 
          <variableName>Total Precipitation</variableName> 
          <variableDescription>Total Precipitation, kg m-2 or mm</variableDescription> 
          <units unitsAbbreviation="mm" unitsCode="54" unitsType="Length">millimeter</units> 
      </variable>
      <values unitsAbbreviation="54" count="17">
          <value dateTime="2006-11-09T00:00:00">0</value> 
          <value dateTime="2006-11-09T03:00:00">0</value> 
          <value dateTime="2006-11-09T06:00:00">1</value> 
          <value dateTime="2006-11-09T09:00:00">1</value> 
          <value dateTime="2006-11-09T12:00:00">1.375</value> 
          <value dateTime="2006-11-09T15:00:00">1</value> 
          <value dateTime="2006-11-09T18:00:00">1</value> 
          <value dateTime="2006-11-09T21:00:00">0</value> 
          <value dateTime="2006-11-10T00:00:00">1.25</value> 
          <value dateTime="2006-11-10T03:00:00">0</value> 
          <value dateTime="2006-11-10T06:00:00">5</value> 
          <value dateTime="2006-11-10T09:00:00">11</value> 
          <value dateTime="2006-11-10T12:00:00">18</value> 
          <value dateTime="2006-11-10T15:00:00">8</value> 
          <value dateTime="2006-11-10T18:00:00">1</value> 
          <value dateTime="2006-11-10T21:00:00">0</value> 
          <value dateTime="2006-11-11T00:00:00">0</value> 
      </values>
    </timeSeries>
  </timeSeriesResponse>
         
         */
