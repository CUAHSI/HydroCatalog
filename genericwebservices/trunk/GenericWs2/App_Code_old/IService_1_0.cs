using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;
using WaterOneFlow.Schema.v1;
using WaterOneFlowImpl;

//using Microsoft.Web.Services3;
//using Microsoft.Web.Services3.Addressing;
//using Microsoft.Web.Services3.Messaging;

using Constants = WaterOneFlowImpl.v1_0.Constants;

/* In order to keep the "Contract" Clean. Descriptions are found the WsDescriptions Class.
 * This is a set of constants.
 * The Namespace is presently held in the Constants.
 * The used of a constant makes mainataing multiple services simpler. Any changes asked for b
 * by the community can be easily propagated to the services.
 * valentine aug 2006
 */
namespace WaterOneFlow.v1_0
{
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1,
        Name = WsDescriptions.WsDefaultName,
        Namespace = Constants.WS_NAMSPACE)]
  
    [ServiceContract(Name = WsDescriptions.WsDefaultName,
        Namespace = Constants.WS_NAMSPACE //"http://www.cuahsi.org/his/1.0/ws/"
        // ,  ConfigurationName = "WaterOneFlow"
    //   , SessionMode = SessionMode.Allowed //http://stackoverflow.com/questions/4767102/wcf-sessions-with-a-wshttpbinding-and-without-windows-security
    )]

    [XmlSerializerFormat]
    interface IService_1_0
    {

        [WebMethod(Description = WsDescriptions.GetSitesDefaultDesc)]
     //   [System.ServiceModel.OperationContractAttribute(Action = "http://www.cuahsi.org/his/1.0/ws/GetSitesXml", ReplyAction = "*")]
      //  [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetSitesXml(
            [XmlArray("site"), XmlArrayItem("string", typeof(string))]
                string[] site, String authToken);

        [WebMethod(Description = WsDescriptions.GetSiteInfoDefaultDesc)]
     //   [System.ServiceModel.OperationContractAttribute(Action = "http://www.cuahsi.org/his/1.0/ws/GetSiteInfo", ReplyAction = "*")]
      //  [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetSiteInfo(string site, String authToken);

        [WebMethod(Description =  WsDescriptions.GetVariableInfoDefaultDesc)]
      //  [System.ServiceModel.OperationContractAttribute(Action = "http://www.cuahsi.org/his/1.0/ws/GetVariableInfo", ReplyAction = "*")]
       // [System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetVariableInfo(string variable, String authToken);


        [WebMethod(Description = WsDescriptions.GetValuesDefaultDesc )]
       // [System.ServiceModel.OperationContractAttribute(Action = "http://www.cuahsi.org/his/1.0/ws/GetValues", ReplyAction = "*")]
        //[System.ServiceModel.XmlSerializerFormatAttribute()]
        string GetValues(string location, string variable, string startDate, string endDate, String authToken);

        [WebMethod(Description = WsDescriptions.GetSitesDefaultDesc)]
      //  [OperationContract()]
      // [WebGet(
      //      // ResponseFormat = WebMessageFormat.Xml,
      //UriTemplate = "sites?site={site}&authToken={authToken}"
      //)]
        SiteInfoResponseType GetSites(
            [XmlArray("site"), XmlArrayItem("string", typeof(string))]
                string[] site, String authToken);

         [WebGet(
             // ResponseFormat = WebMessageFormat.Xml,
        UriTemplate = "sites?location={sites}&authToken={authToken}"
        )]
        SiteInfoResponseType GetSites(   
                string sites, String authToken);

        [WebMethod(Description = WsDescriptions.GetSiteInfoObjectDefaultDesc)]
        //[FaultContract(typeof(WaterOneFlowException))]
        //[FaultContract(typeof(WaterOneFlowServerException))]
        //[FaultContract(typeof(WaterOneFlowSourceException))]
        [OperationContract(Action = Constants.WS_NAMSPACE + "GetSiteInfoObject")]
        [WebGet(
            // ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "siteinfo?location={site}&authToken={authToken}"
            )]
        SiteInfoResponseType GetSiteInfoObject(string site, String authToken);



        [WebMethod(Description = WsDescriptions.GetVariableInfoObjectDefaultDesc)]
        //[FaultContract(typeof(WaterOneFlowException))]
        //[FaultContract(typeof(WaterOneFlowServerException))]
        //[FaultContract(typeof(WaterOneFlowSourceException))]
        [OperationContract(Action = Constants.WS_NAMSPACE + "GetVariableInfoObject")]
        [WebGet(
            // ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "variables?variable={variable}&authToken={authToken}"
            )]
        VariablesResponseType GetVariableInfoObject(string variable, String authToken);


        [WebMethod(Description = WsDescriptions.GetValuesObjectDefaultDesc)]
        [OperationContract(Action = Constants.WS_NAMSPACE + "GetValuesObject")]
        //[FaultContract(typeof(WaterOneFlowException))]
        //[FaultContract(typeof(WaterOneFlowServerException))]
        //[FaultContract(typeof(WaterOneFlowSourceException))]
        [WebGet(
            // ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "datavalues?location={location}&variable={variable}&startDate={startDate}&endDate={endDate}&authToken={authToken}"
            )]
        TimeSeriesResponseType GetValuesObject(string location, string variable, string startDate, string endDate, String authToken);

   
    }
}