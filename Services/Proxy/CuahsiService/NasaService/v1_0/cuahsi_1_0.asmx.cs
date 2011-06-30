using System;
using System.Text;
using System.Web.Services;
using System.Xml.Serialization;
using System.Xml;
using System.Web.Services.Protocols;

using cuahsi.his.schema.Response.v1_0;
using cuahsi.his.WaterService;
using cuahsi.his.WaterService.Constants.v1;
using cuahsi.his.WaterService.Parameters;
using cuahsi.his.WaterService.Rest.v1_0;
using cuahsi.his.WaterService.Service.Services.v1_0;
using cuahsi.his.WaterService.Service.v1_0.Passthrough;

using cuahsi.his.WaterService.Utilities;
using VariableParam = cuahsi.his.WaterService.Parameters.v1_0.VariableParam;

namespace cuahsi.CuahsiService
{
    using Constants = cuahsi.his.WaterService.Constants.v1;

 
    
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Name = WsDescriptions.WsDefaultName, Namespace = Constants.ServiceDescriptions.WS_NAMSPACE, Description = WsDescriptions.WsDefaultDescription)]
    [WebServiceBinding(Name = WsDescriptions.WsDefaultName,
            ConformsTo = WsiProfiles.BasicProfile1_1,
        Namespace = ServiceDescriptions.WS_NAMSPACE)]
    public class NasaXsltService 
        //: IWaterOneFlowWebService
    {



        [WebMethod(Description = WsDescriptions.GetSitesDefaultDesc)]
        public  string GetSitesXml(string[] site, string authToken)
        {
            SiteInfoResponseString aSite = (SiteInfoResponseString)GetSites(site, null);
            XmlSerializer serializer = WOFXmlSerializerFactory.GetSerializer(typeof(SiteInfoResponseString));
            StringBuilder xml = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(xml, WaterXmlSettings.NoDocument());

            serializer.Serialize(writer, aSite);
            return xml.ToString();
        }

        [WebMethod(Description = WsDescriptions.GetSiteInfoDefaultDesc)]
        public  string GetSiteInfo(string site, string authToken)
        {
            SiteInfoResponseString aSite = (SiteInfoResponseString)GetSiteInfoObject(site, null);
            XmlSerializer serializer = WOFXmlSerializerFactory.GetSerializer(
                 typeof(SiteInfoResponseString));
            StringBuilder xml = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(xml, WaterXmlSettings.NoDocument());


            serializer.Serialize(writer, aSite);
            return xml.ToString();
        }

        [WebMethod(Description = WsDescriptions.GetVariableInfoDefaultDesc)]
        public  string GetVariableInfo(string variable, string authToken)
        {
            VariablesResponseString aVType = (VariablesResponseString)GetVariableInfoObject(variable, null);
            XmlSerializer xs = WOFXmlSerializerFactory.GetSerializer(
                typeof(VariablesResponseString));
            StringBuilder xml = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(xml, WaterXmlSettings.NoDocument());


            xs.Serialize(writer, aVType);
            return xml.ToString();
        }

        [WebMethod(Description = WsDescriptions.GetValuesDefaultDesc)]
        public  string GetValues(string location, string variable, string startDate, string endDate, string authToken)
        {
            TimeSeriesResponseString aSite = (TimeSeriesResponseString)GetValuesObject(location, variable, startDate, endDate, null);
              XmlSerializer xs = WOFXmlSerializerFactory.GetSerializer(
               typeof(TimeSeriesResponseString));
            StringBuilder xml = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(xml, WaterXmlSettings.NoDocument());


            xs.Serialize(writer, aSite);
            return xml.ToString();
        }

        [return: XmlElement(Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
     ElementName = "sitesResponse", IsNullable = false, Type = typeof(SiteInfoResponseString ))]
        [WebMethod(Description = WsDescriptions.GetSitesDefaultDesc)]
        public SiteInfoResponseString GetSites(string[] site, string authToken)
        {
          //  var lParam = String.IsNullOrEmpty(variable) ? null : new locationParam(variable);

            var svc = new SitesREST_xslt(
                NdlasMos125NasaConfiguration10.SitesRestUriTemplate,
                NdlasMos125NasaConfiguration10.SitesRestXslt);

            var result = svc.GetSites(null);

            return result;
        }

        [return: XmlElement(Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
    ElementName = "sitesResponse", IsNullable = false, Type = typeof(SiteInfoResponseString))]
        [WebMethod(Description = WsDescriptions.GetSiteInfoObjectDefaultDesc)]
        public SiteInfoResponseString GetSiteInfoObject(string site, string authToken)
        {
            var lParam = String.IsNullOrEmpty(site) ? null : new locationParam(site); 
            
            var svc = new SitesREST_xslt(
               NdlasMos125NasaConfiguration10.SiteInfoRestUriTemplate,
               NdlasMos125NasaConfiguration10.SiteInfoRestXslt);

            var result = svc.GetSites(lParam);

            return result;
        }

        [return: XmlElement(Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
  ElementName = "variablesResponse", IsNullable = false
  , Type = typeof(VariablesResponseString)
  )]
        [WebMethod(Description = WsDescriptions.GetVariableInfoObjectDefaultDesc)]
        public VariablesResponseString GetVariableInfoObject(string variable, string authToken)
        {
          var lParam = String.IsNullOrEmpty(variable) ? null: new VariableParam(variable);

            var svc = new VariablesREST_xslt(
                NdlasMos125NasaConfiguration10.VariablesRestUriTemplate, 
                NdlasMos125NasaConfiguration10.VariablesRestXslt);

            var result = svc.GetVariables(lParam);

           return result;
        }

        [return: XmlElement(Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
ElementName = "timeSeriesResponse", IsNullable = false, Type = typeof(TimeSeriesResponseString))]
        [WebMethod(Description = WsDescriptions.GetValuesObjectDefaultDesc)]
        public TimeSeriesResponseString GetValuesObject(string location, string variable, string startDate, string endDate, string authToken)
        {
            var lParam = new locationParam(location);
            var vParam = new VariableParam(variable);

            var beginTime = W3CDateTime.Parse(startDate);
            var endTime =  W3CDateTime.Parse(endDate);

            var svc = new ValuesREST_xslt(
                NdlasMos125NasaConfiguration10.TimeSeriesRestUriTemplate, 
                NdlasMos125NasaConfiguration10.TimeSeriesRestXslt);

            var result = svc.GetTimeSeries(lParam, vParam, beginTime, endTime);

            return result;
        }
    }
}