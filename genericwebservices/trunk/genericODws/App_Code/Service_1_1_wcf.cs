
using System;
using System.Configuration;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using log4net;
using WaterOneFlowImpl;

using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Web.Services.Protocols;
using WaterOneFlow.Schema.v1_1;
using WaterOneFlow;

using WaterOneFlowImpl.geom;

using System.ServiceModel;
using System.ServiceModel.Channels;


namespace WaterOneFlow.odws
{
    namespace v1_1.wcf
    {
        using ConstantsNamespace = WaterOneFlowImpl.v1_1.Constants;

        using IService = WaterOneFlow.v1_1.IService;

        public class Config
        {
            public static string ODDB()
            {
                if (ConfigurationManager.ConnectionStrings["ODDB"] != null)
                {
                    return ConfigurationManager.ConnectionStrings["ODDB"].ConnectionString;
                }
                else
                {
                    return null;
                }
            }
        }
//#if DEBUG
//        [WebService(Name = WsDescriptions.WsDefaultName,
//   Namespace = ConstantsNamespace.WS_NAMSPACE,
//    Description = WsDescriptions.SvcDevelopementalWarning + WsDescriptions.WsDefaultDescription)]
//        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//        [SoapActor("*")]
//#else
//        [WebService(Name = WsDescriptions.WsDefaultName,
//        Namespace = ConstantsNamespace.WS_NAMSPACE,
//         Description =  WsDescriptions.WsDefaultDescription)]
//        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//        [SoapActor("*")]
//#endif
      //  public class Service : WebService, IService
        [ServiceBehavior(Namespace = ConstantsNamespace.WS_NAMSPACE)]
        public class Service : IService
    {


            protected ODService ODws;

            private Boolean useODForValues;
            private Boolean requireAuthToken;

            private static readonly ILog log = LogManager.GetLogger(typeof(Service));
            private static readonly ILog queryLog = LogManager.GetLogger("QueryLog");
            private static readonly Logging queryLog2 = new Logging();

            public Service()
            {
                //log4net.Util.LogLog.InternalDebugging = true; 

                // ODws = new ODService(this.Context);//INFO we can extend this for other service types
                ODws = new ODService(null);//INFO we can extend this for other service types


                try
                {
                    useODForValues = Boolean.Parse(ConfigurationManager.AppSettings["UseODForValues"]);
                }
                catch (Exception e)
                {
                    String error = "Missing or invalid value for UseODForValues. Must be true or false";
                    log.Fatal(error);

                    throw new WaterOneFlowServerException("Invalid Server Configuration. " + error);
                    //throw new SoapException("Invalid Server Configuration. " + error,
                }

                try
                {
                    requireAuthToken = Boolean.Parse(ConfigurationManager.AppSettings["requireAuthToken"]);
                }
                catch (Exception e)
                {
                    String error = "Missing or invalid value for requireAuthToken. Must be true or false";
                    log.Fatal(error);

                    throw new WaterOneFlowServerException(error);
                    //throw new SoapException(error,
                    //                        new XmlQualifiedName(SoapExceptionGenerator.ServerError));
                }

            }


            #region IService Members

            public string GetSites(string[] SiteNumbers, String authToken)
            {

                SiteInfoResponseType aSite = GetSitesObject(SiteNumbers, authToken);
                string xml = WSUtils.ConvertToXml(aSite, typeof(SiteInfoResponseType));
                return xml;

            }

            public virtual string GetSiteInfo(string SiteNumber, String authToken)
            {

                SiteInfoResponseType aSite = GetSiteInfoObject(SiteNumber, authToken);
                string xml = WSUtils.ConvertToXml(aSite, typeof(SiteInfoResponseType));

                return xml;
            }

            public string GetVariableInfo(string variable, String authToken)
            {
                VariablesResponseType aVType = GetVariableInfoObject(variable, authToken);
                string xml = WSUtils.ConvertToXml(aVType, typeof(VariablesResponseType));
                return xml;
            }


            public SiteInfoResponseType GetSitesObject(string[] site, String authToken)
            {
                //  GlobalClass.WaterAuth.SitesServiceAllowed(Context, authToken);
                Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();
                queryLog2.LogStart(Logging.Methods.GetSites, site.ToString(),
                  getClientIP());
                try
                {
                    var response = ODws.GetSites(site);

                    if (response != null)
                    {
                        queryLog2.LogEnd(Logging.Methods.GetSites,
                                         site.ToString(),
                                         timer.ElapsedMilliseconds.ToString(),
                                         response.site.Length.ToString(),
                                         getClientIP());
                    }
                    return response;
                }
                catch (ArgumentException ex)
                {
                    throw new WaterOneFlowException(ex.Message);
                }
                catch (WaterOneFlowException ex)
                {
                    throw ex;
                }
                catch (WaterOneFlowServerException ex)
                {
                    throw ex;
                }
                catch (WaterOneFlowSourceException ex)
                {
                    throw ex;
                }
                catch (Exception we)
                {
                    log.Warn(we.Message);
                    throw new WaterOneFlowServerException(we.Message);
                    //throw SoapExceptionGenerator.WOFExceptionToSoapException(we);
                }
            }

            public virtual SiteInfoResponseType GetSiteInfoObject(string site, String authToken)
            {
                //   GlobalClass.WaterAuth.SiteInfoServiceAllowed(Context, authToken);
                Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();
                if (site != null)
                {
                    queryLog2.LogStart(Logging.Methods.GetSiteInfo, site.ToString(),
                                      getClientIP());
                }
                else
                {
                    queryLog2.LogStart(Logging.Methods.GetSiteInfo, "NULL",
                                       getClientIP());

                }
                try
                {

                    var response = ODws.GetSiteInfo(site);
                    if (site != null && response != null)
                    {

                        queryLog2.LogEnd(Logging.Methods.GetSiteInfo,
                                         site.ToString(),
                                         timer.ElapsedMilliseconds.ToString(),
                                         response.site.Length.ToString(),
                                         getClientIP());
                    }
                    else
                    {
                        queryLog2.LogEnd(Logging.Methods.GetSiteInfo,
                                       "NULL",
                                       timer.ElapsedMilliseconds.ToString(),
                                       response.site.Length.ToString(),
                                      getClientIP());
                    }

                    return response;
                }
                catch (ArgumentException ex)
                {
                    throw new WaterOneFlowException(ex.Message);
                }
                catch (WaterOneFlowException ex)
                {
                    throw ex;
                }
                catch (WaterOneFlowServerException ex)
                {
                    throw ex;
                }
                catch (WaterOneFlowSourceException ex)
                {
                    throw ex;
                }
                catch (Exception we)
                {
                    log.Warn(we.Message);
                    throw new WaterOneFlowServerException(we.Message);
                    //throw SoapExceptionGenerator.WOFExceptionToSoapException(we);
                }


            }

            public VariablesResponseType GetVariableInfoObject(string variable, String authToken)
            {
                //    GlobalClass.WaterAuth.VariableInfoServiceAllowed(Context, authToken);
                Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();
                queryLog2.LogStart(Logging.Methods.GetVariablesObject, "",
                      getClientIP());
                try
                {
                    var response =  ODws.GetVariableInfo(variable);
                    if (response != null)
                    {
                        queryLog2.LogEnd(Logging.Methods.GetVariables,
                                         "",
                                         timer.ElapsedMilliseconds.ToString(),
                                         response.variables.Length.ToString(),
                                        getClientIP());
                    }
                    return response;
                }
                catch (ArgumentException ex)
                {
                    throw new WaterOneFlowException(ex.Message);
                }
                catch (WaterOneFlowException ex)
                {
                    throw ex;
                }
                catch (WaterOneFlowServerException ex)
                {
                    throw ex;
                }
                catch (WaterOneFlowSourceException ex)
                {
                    throw ex;
                }
                catch (Exception we)
                {
                    log.Warn(we.Message);
                    throw new WaterOneFlowServerException(we.Message);
                    //throw SoapExceptionGenerator.WOFExceptionToSoapException(we);
                }

            }

            public virtual string GetValues(string location, string variable, string startDate, string endDate, String authToken)
            {
                TimeSeriesResponseType aSite = GetValuesObject(location, variable, startDate, endDate, null);
                return WSUtils.ConvertToXml(aSite, typeof(TimeSeriesResponseType));
            }

            public virtual TimeSeriesResponseType GetValuesObject(string location,
                string variable, string startDate, string endDate, String authToken)
            {
                //       GlobalClass.WaterAuth.DataValuesServiceAllowed(Context, authToken);
                Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();
                queryLog2.LogValuesStart(Logging.Methods.GetValues, // method
                                  location, //locaiton
            variable, //variable
            startDate, // startdate
            endDate, //enddate
           getClientIP());
                if (!useODForValues)
                    throw new WaterOneFlowException("GetValues implemented external to this service. Call GetSiteInfo, and SeriesCatalog includes the service Wsdl for GetValues. Attribute:serviceWsdl on Element:seriesCatalog XPath://seriesCatalog/[@serviceWsdl]");
                //throw new SoapException(
                //    "GetValues implemented external to this service. Call GetSiteInfo, and SeriesCatalog includes the service Wsdl for GetValues. Attribute:serviceWsdl on Element:seriesCatalog XPath://seriesCatalog/[@serviceWsdl]",
                //    new XmlQualifiedName("ServiceException"));
                try
                {
                    var response = ODws.GetValues(location, variable, startDate, endDate);
                    if (response != null)
                    {
                        queryLog2.LogValuesEnd(Logging.Methods.GetValues,
                             location, //locaiton
                              variable, //variable
                              startDate, // startdate
                              endDate, //enddate
                              timer.ElapsedMilliseconds, // processing time
                                            // assume one for now 
                              response.timeSeries[0].values[0].value.Length, // count 
                              getClientIP());
                    }
                    return response;
                }
                catch (ArgumentException ex)
                {
                    throw new WaterOneFlowException(ex.Message);
                }
                catch (WaterOneFlowException ex)
                {
                    throw ex;
                }
                catch (WaterOneFlowServerException ex)
                {
                    throw ex;
                }
                catch (WaterOneFlowSourceException ex)
                {
                    throw ex;
                }
                catch (Exception we)
                {
                    log.Warn(we.Message);
                    throw new WaterOneFlowServerException(we.Message);
                    //throw SoapExceptionGenerator.WOFExceptionToSoapException(we);
                }


            }

            public SiteInfoResponseType GetSiteInfoMultpleObject(string[] site, string authToken)
            {
                //        GlobalClass.WaterAuth.SiteInfoServiceAllowed(Context, authToken);

                try
                {
                    return ODws.GetSiteInfo(site, true);
                }
                catch (ArgumentException ex)
                {
                    throw new WaterOneFlowException(ex.Message);
                }
                catch (WaterOneFlowException ex)
                {
                    throw ex;
                }
                catch (WaterOneFlowServerException ex)
                {
                    throw ex;
                }
                catch (WaterOneFlowSourceException ex)
                {
                    throw ex;
                }
                catch (Exception we)
                {
                    log.Warn(we.Message);
                    throw new WaterOneFlowServerException(we.Message);
                    //throw SoapExceptionGenerator.WOFExceptionToSoapException(we);
                }
            }

            public SiteInfoResponseType GetSitesByBoxObject(float west, float south, float east, float north, bool IncludeSeries, string authToken)
            {
                //         GlobalClass.WaterAuth.SiteInfoServiceAllowed(Context, authToken);
                Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();
                box queryBox = new box(west, south, east, north);
                queryLog2.LogStart(Logging.Methods.GetSitesInBoxObject, queryBox.ToString(),
                    getClientIP());

                var response =
                    ODws.GetSitesInBox(west, south, east, north, IncludeSeries);

                if (response != null)
                {
                    queryLog2.LogEnd(Logging.Methods.GetSitesInBoxObject,
                      queryBox.ToString(),
                     timer.ElapsedMilliseconds.ToString(),
                     response.site.Length.ToString(),
                     getClientIP());
                }
                return response;
            }

            public TimeSeriesResponseType GetValuesForASiteObject(string site, 
                string StartDate, string EndDate,
                string authToken)
            {
                //         GlobalClass.WaterAuth.DataValuesServiceAllowed(Context, authToken); 
                Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();
                queryLog2.LogValuesStart(Logging.Methods.GetValuesForSiteObject, // method
                                 site, //locaiton
                               "ALL", //variable
                               StartDate, // startdate
                               EndDate, //enddate
                              getClientIP());
                
                var response =  ODws.GetValuesForASite(site, StartDate, EndDate);
                if (response != null)
                {
                    queryLog2.LogValuesEnd(Logging.Methods.GetValuesForSiteObject,

                                           site, //locaiton
                                           "ALL", //variable
                                           StartDate, // startdate
                                           EndDate, //enddate
                                           timer.ElapsedMilliseconds, // processing time
                                           // assume one for now 
                                           -9999, // May need to count all. 
                                           getClientIP());
                }
                return response;
            }

            public TimeSeriesResponseType GetValuesByBoxObject(string variable, string StartDate, string EndDate, float west, float south, float east, float north, string authToken)
            {
                throw new NotImplementedException();
            }

            public string GetVariables(String authToken)
            {
                VariablesResponseType aVType = GetVariableInfoObject(null, authToken);
                string xml = WSUtils.ConvertToXml(aVType, typeof(VariablesResponseType));
                return xml;
            }

            public VariablesResponseType GetVariablesObject(String authToken)
            {
                Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();
                queryLog2.LogStart(Logging.Methods.GetVariablesObject, "",
                      getClientIP());

                var response = GetVariableInfoObject(null, authToken);

                if (response != null)
                {
                    queryLog2.LogEnd(Logging.Methods.GetVariables,
                                     "",
                                     timer.ElapsedMilliseconds.ToString(),
                                     response.variables.Length.ToString(),
                                     getClientIP());
                }
                return response;


            }

            #endregion
         private string getClientIP()
            {
                //WebOperationContext webContext = WebOperationContext.Current;

                OperationContext context = OperationContext.Current;

                MessageProperties messageProperties = context.IncomingMessageProperties;

                RemoteEndpointMessageProperty endpointProperty =

                    messageProperties[RemoteEndpointMessageProperty.Name]

                    as RemoteEndpointMessageProperty;


                return endpointProperty.Address;
            }

        }
 
    }
}