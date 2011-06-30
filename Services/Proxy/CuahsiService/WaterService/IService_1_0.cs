using System;
using System.Web.Services;
using System.Xml.Serialization;
using System.Web.Services.Protocols;
using cuahsi.his.WaterService.Constants.v1;
using cuahsi.his.WaterService.Service.v1_0.Passthrough;


/* In order to keep the "Contract" Clean. Descriptions are found the WsDescriptions Class.
 * This is a set of constants.
 * The Namespace is presently held in the Constants.
 * The used of a constant makes mainataing multiple services simpler. Any changes asked for b
 * by the community can be easily propagated to the services.
 * valentine aug 2006
 */
namespace cuahsi.his.WaterService
{
    //using WaterOneFlow.Service.Response.v1;
    using VariablesResponseTypeGeneric = cuahsi.his.schema.Response.v1_0.VariablesResponseType;
    using SiteInfoResponseTypeGeneric = cuahsi.his.schema.Response.v1_0.SiteInfoResponseType;
    using TimeSeriesResponseTypeGeneric = cuahsi.his.schema.Response.v1_0.TimeSeriesResponseType;

    //using WaterOneFlow.Schema.v1;

    using SiteInfoResponseTypeObject = schema.Abstract.v1_0.SiteInfoResponseType;
    using TimeSeriesResponseTypeObject = schema.Abstract.v1_0.TimeSeriesResponseType;
    using VariablesResponseTypeObject = schema.Abstract.v1_0.VariablesResponseType;

    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1,
        Name = WsDescriptions.WsDefaultName,
        Namespace = Constants.v1.ServiceDescriptions.WS_NAMSPACE)]

    public interface IService_1_0
    {

        [WebMethod(Description = WsDescriptions.GetSitesDefaultDesc)]
        string GetSitesXml(string[] site, String authToken);

        [WebMethod(Description = WsDescriptions.GetSiteInfoDefaultDesc)]
        string GetSiteInfo(string site, String authToken);

        [WebMethod(Description =  WsDescriptions.GetVariableInfoDefaultDesc)]
        string GetVariableInfo(string variable, String authToken);


        [WebMethod(Description = WsDescriptions.GetValuesDefaultDesc)]
        string GetValues(string location, string variable, string startDate, string endDate, String authToken);

        [return: XmlElement(Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
 ElementName = "sitesResponse", IsNullable = false, Type = typeof(SiteInfoResponseTypeGeneric))]
        [WebMethod(Description = WsDescriptions.GetSitesDefaultDesc)]
        object GetSites(string[] site, String authToken);

        [return: XmlElement(Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
 ElementName = "sitesResponse", IsNullable = false, Type = typeof(SiteInfoResponseTypeGeneric))]
        [WebMethod(Description = WsDescriptions.GetSiteInfoObjectDefaultDesc)]
        object GetSiteInfoObject(string site, String authToken);


        [return: XmlElement(Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
ElementName = "variablesResponse", IsNullable = false, Type = typeof(VariablesResponseTypeGeneric))]
        [XmlInclude(typeof(VariablesResponseString))]
        [XmlInclude(typeof(VariablesResponseTypeGeneric))]
        [WebMethod(Description = WsDescriptions.GetVariableInfoObjectDefaultDesc)]
        object GetVariableInfoObject(string variable, String authToken);

        [return: XmlElement(Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
 ElementName = "timeSeriesResponse", IsNullable = false, Type = typeof(TimeSeriesResponseTypeGeneric))]
        [WebMethod(Description = WsDescriptions.GetValuesObjectDefaultDesc)]
        object GetValuesObject(string location, string variable, string startDate, string endDate, String authToken);

   
    }
}