using System;

using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

using CUAHSI = hiscentral_2010.CUAHSI;
/// <summary>
/// Summary description for TestUtils
/// </summary>
public class TestUtils
{

	
    public static string ConvertToXml(object toSerialize, Type objectType)
    {
        // create a string wrtiter to hold the xml string
        // the a xml writer with the proper settings.
        // use that writer to serialize the document.
        // use an  namespace to create a fully qualified odcument.
        StringWriter aWriter = new StringWriter();
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.ConformanceLevel = ConformanceLevel.Document; // Fragment fails
        settings.Indent = true;
        settings.Encoding = System.Text.Encoding.UTF8;

        XmlWriter xWriter = XmlWriter.Create(aWriter, settings);
        XmlRootAttribute xRoot = null;
        // if the web weference changes, these will need to change
        if (objectType == typeof(CUAHSI.VariablesResponseType))
        {
            xRoot = new XmlRootAttribute("variablesResponse");
        }
        else
        {
            if (objectType == typeof(CUAHSI.TimeSeriesResponseType))
            {
                xRoot = new XmlRootAttribute("timeSeriesResponse");
            }
            else
            {
                //if (objectType == typeof(CUAHSI.SiteInfoResponseType))
                //{
                //    xRoot = new XmlRootAttribute("sitesResponse");
                //}
            }

        }
        XmlSerializer aSerializer = new XmlSerializer(objectType, xRoot);
        //aSerialize(xWriter, toSerialize);
        aSerializer.Serialize(xWriter, toSerialize);
        string xml = aWriter.ToString();
        aWriter.Flush();
        aWriter.Close();
        return xml;
    }
    public static DateTime getDateFromString(String dt)
    {
        try
        {
            String[] vals = dt.Split('-');
            int year = int.Parse(vals[0]);
            int month = int.Parse(vals[1]);
            int day = int.Parse(vals[2].Substring(0, 2));
            return new DateTime(year, month, day);
        }
        catch (Exception e)
        {
            return DateTime.Now;
        }
    }
    public static String getStringFromDate(DateTime dt)
    {
        String year, month, day;
        year = dt.Year.ToString();
        month = dt.Month < 10 ? "0" + dt.Month : dt.Month.ToString();
        day = dt.Day < 10 ? "0" + dt.Day : dt.Day.ToString();
        return year + "-" + month + "-" + day;
    }
}
	
