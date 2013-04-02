using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Services;

using System.Xml.Serialization;
using cuahsi.his.WaterService.Service.v1_0.Passthrough;


namespace cuahsi.his.WaterService.Service
{
    namespace Services.v1_0
    {

        using cuahsi.his.schema.Response.v1_0;
        //using WaterOneFlow.Service.Abstract;
        using cuahsi.his.WaterService.Constants.v1;
         
        //        ConformsTo = WsiProfiles.BasicProfile1_1,
        [WebServiceBinding(Name = WsDescriptions.WsDefaultName, 
            ConformsTo = WsiProfiles.BasicProfile1_1, 
        Namespace = ServiceDescriptions.WS_NAMSPACE )]
        public abstract class IWaterOneFlowWebService : System.Web.Services.WebService, IService_1_0
        {
            [WebMethod(Description = WsDescriptions.GetSitesDefaultDesc )]
            public abstract string GetSitesXml(string[] sites, String authToken);

            [WebMethod(Description = WsDescriptions.GetSiteInfoDefaultDesc)]
            public abstract string GetSiteInfo(string site, String authToken);

            [WebMethod(Description = WsDescriptions.GetVariableInfoDefaultDesc)]
            public abstract string GetVariableInfo(string variable, String authToken);


            [WebMethod(Description = WsDescriptions.GetValuesDefaultDesc)]
            public abstract string GetValues(string location, string variable, string startDate, string endDate, String authToken);

            [return: XmlElement(Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
    ElementName = "sitesResponse",IsNullable = false ,Type=typeof(SiteInfoResponseType))]
            [WebMethod(Description = WsDescriptions.GetSitesDefaultDesc)]
            public abstract object GetSites(string[] site, String authToken);

            [return: XmlElement(Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
   ElementName = "sitesResponse", IsNullable = false,Type=typeof(SiteInfoResponseType))]
            [WebMethod(Description = WsDescriptions.GetSiteInfoObjectDefaultDesc)]
            public abstract object GetSiteInfoObject(string site, String authToken);


            [return: XmlElement(Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
   ElementName = "variablesResponse", IsNullable = false,Type=typeof(VariablesResponseType))]
            [WebMethod(Description = WsDescriptions.GetVariableInfoObjectDefaultDesc)]
            [XmlInclude(typeof(VariablesResponseString))]
            [XmlInclude(typeof(VariablesResponseType))]
            public abstract object GetVariableInfoObject(string variable, String authToken);

            [return: XmlElement(Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
   ElementName = "timeSeriesResponse", IsNullable = false,Type=typeof(TimeSeriesResponseType))]
            [WebMethod(Description = WsDescriptions.GetValuesObjectDefaultDesc)]
            public abstract object GetValuesObject(string location, string variable, string startDate, string endDate, String authToken);
        }

    }// namespace v1
    namespace Services.v1_1
    {

        using cuahsi.his.schema.Abstract.v1_1;
        //using WaterOneFlow.Service.Abstract;

        using cuahsi.his.WaterService.Constants.v1_1;

        //        ConformsTo = WsiProfiles.BasicProfile1_1,
        [WebServiceBinding(Name = WsDescriptions.WsDefaultName,
            ConformsTo = WsiProfiles.BasicProfile1_1,
        Namespace = ServiceDescriptions.WS_NAMSPACE)]
        public abstract class IWaterOneFlowWebService : System.Web.Services.WebService
        {
            [WebMethod(Description = WsDescriptions.GetSitesDefaultDesc)]
            public abstract string GetSitesXml(string[] sites, String authToken);

            [WebMethod(Description = WsDescriptions.GetSiteInfoDefaultDesc)]
            public abstract string GetSiteInfo(string site, String authToken);

            [WebMethod(Description = WsDescriptions.GetVariableInfoDefaultDesc)]
            public abstract string GetVariableInfo(string variable, String authToken);


            [WebMethod(Description = WsDescriptions.GetValuesDefaultDesc)]
            public abstract string GetValues(string location, string variable, string startDate, string endDate, String authToken);

            [return: XmlElement(Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
   ElementName = "sitesResponse", IsNullable = false)]
            [WebMethod(Description = WsDescriptions.GetSitesDefaultDesc)]
            public abstract SiteInfoResponseType GetSites(string[] site, String authToken);

            [return: XmlElement(Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
   ElementName = "sitesResponse", IsNullable = false)]
            [WebMethod(Description = WsDescriptions.GetSiteInfoObjectDefaultDesc)]
            public abstract SiteInfoResponseType GetSiteInfoObject(string site, String authToken);


            [return: XmlElement(Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
   ElementName = "variablesResponse", IsNullable = false)]
            [WebMethod(Description = WsDescriptions.GetVariableInfoObjectDefaultDesc)]
            public abstract VariablesResponseType GetVariableInfoObject(string variable, String authToken);

            [return: XmlElement(Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
   ElementName = "timeSeriesResponse", IsNullable = false)]
            [WebMethod(Description = WsDescriptions.GetValuesObjectDefaultDesc)]
            public abstract TimeSeriesResponseType GetValuesObject(string location, string variable, string startDate, string endDate, String authToken);

//            [return: XmlElement(Namespace = "http://www.cuahsi.org/his/wof",
//ElementName = "WOF_Capabilities", IsNullable = false)]
//            [WebMethod(Description = "Get Capabilities")]
//            public abstract WofCapabilities GetCapabilties();
        }
    }// namespace v1_1

    
}
