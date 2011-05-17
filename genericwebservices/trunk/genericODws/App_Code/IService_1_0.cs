using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;
using WaterOneFlowImpl;

using Microsoft.Web.Services3;
using Microsoft.Web.Services3.Addressing;
using Microsoft.Web.Services3.Messaging;

/* In order to keep the "Contract" Clean. Descriptions are found the WsDescriptions Class.
 * This is a set of constants.
 * The Namespace is presently held in the Constants.
 * The used of a constant makes mainataing multiple services simpler. Any changes asked for b
 * by the community can be easily propagated to the services.
 * valentine aug 2006
 */
namespace WaterOneFlow
{
    using WaterOneFlow.Schema.v1;
    using ConstantsNs = WaterOneFlowImpl.v1_0.Constants;

    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1,
        Name = WsDescriptions.WsDefaultName, 
        Namespace = Constants.WS_NAMSPACE)]
    [ServiceContract(Name = WsDescriptions.WsDefaultName, Namespace = Constants.WS_NAMSPACE)]
    [XmlSerializerFormat]
    interface IService_1_0
    {

        [WebMethod(Description = WsDescriptions.GetSitesDefaultDesc)]
        string GetSitesXml(
            [XmlArray("site"), XmlArrayItem("string", typeof(string))]
            string[] site, String authToken);

        [WebMethod(Description = WsDescriptions.GetSiteInfoDefaultDesc)]
       
        string GetSiteInfo(string site, String authToken);

        [WebMethod(Description =  WsDescriptions.GetVariableInfoDefaultDesc)]
        
        string GetVariableInfo(string variable, String authToken);


        [WebMethod(Description = WsDescriptions.GetValuesDefaultDesc )]
      
        string GetValues(string location, string variable, string startDate, string endDate, String authToken);

        [WebMethod(Description = WsDescriptions.GetSitesDefaultDesc)]
        //[OperationContract()]
        //[WebGet(
        //    // ResponseFormat = WebMessageFormat.Xml,
        // UriTemplate = "GetSites"
        // )]
        SiteInfoResponseType GetSites(
            [XmlArray("site"), XmlArrayItem("string", typeof(string))]
            string[] site, String authToken);


        [WebMethod(Description = WsDescriptions.GetSiteInfoObjectDefaultDesc)]
        [OperationContract()]
        [WebGet(
            // ResponseFormat = WebMessageFormat.Xml,
      UriTemplate = "series?site={site}&authToken={authToken}"
      )]
        SiteInfoResponseType GetSiteInfoObject(string site, String authToken);



        [WebMethod(Description = WsDescriptions.GetVariableInfoObjectDefaultDesc)]
        [OperationContract()]
        [WebGet(
            // ResponseFormat = WebMessageFormat.Xml,
       UriTemplate = "variables?variable={variable}&authToken={authToken}"
       )]
        VariablesResponseType GetVariableInfoObject(string variable, String authToken);


        [WebMethod(Description = WsDescriptions.GetValuesObjectDefaultDesc)]
        [OperationContract()]
        [WebGet(
            // ResponseFormat = WebMessageFormat.Xml,
        UriTemplate = "values?location={location}&variable={variable}&startDate={startDate}&endDate={endDate}&authToken={authToken}"
        )]
        TimeSeriesResponseType GetValuesObject(string location, string variable, string startDate, string endDate, String authToken);

   
    }
}