using System;
using System.Configuration;
using System.Diagnostics;
using System.Text;
using log4net;
//using System.Web;
//using System.Web.Services;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

using WaterOneFlowImpl;
using WaterOneFlow;

using System.ServiceModel;
using System.ServiceModel.Channels;

// Load the configuration from the 'wateroneflow.logging.log4net' file

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "wateroneflow.logging.log4net", Watch = true)]

namespace WaterOneFlow.odws
{
    using WaterOneFlow.Schema.v1;
    using ConstantsNs = WaterOneFlowImpl.v1_0.Constants;
    namespace v1_0.wcf
    {


        




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
        //    [WebService(Name = WsDescriptions.WsDefaultName,
        //        Namespace = Constants.WS_NAMSPACE,
        //        Description = WsDescriptions.SvcDevelopementalWarning + WsDescriptions.WsDefaultDescription)]
        //    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

        //#else
        //        [WebService(Name = WsDescriptions.WsDefaultName,
        //          Namespace = Constants.WS_NAMSPACE,
        //          Description = WsDescriptions.WsDefaultDescription)]
        //        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

        //#endif
        // public class Service_1_0 : WebService, IService_1_0

        [ServiceBehavior(Namespace = ConstantsNs.WS_NAMSPACE)]
        public class Service_1_0 //: IService_1_0
        {
            protected ODService ODws;
            //private StandardServices aStandard;
            private Boolean useODForValues;
            private Boolean requireAuthToken;

            private static readonly ILog log = LogManager.GetLogger(typeof(Service_1_0));
            private static readonly ILog queryLog = LogManager.GetLogger("QueryLog");
            private static readonly Logging queryLog2 = new Logging();

            public Service_1_0()
            {
                //log4net.Util.LogLog.InternalDebugging = true; 

                // ODws = new ODService(this.Context); //INFO we can extend this for other service types
                ODws = new ODService(null); //INFO we can extend this for other service types
                // aStandard = new StandardServices();

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

            public string GetSitesXml(string[] SiteNumbers, String authToken)
            {
                SiteInfoResponseType aSite = GetSites(SiteNumbers, null);
                string xml = WSUtils.ConvertToXml(aSite, typeof(SiteInfoResponseType));
                return xml;
            }

            public virtual string GetSiteInfo(string SiteNumber, String authToken)
            {
                SiteInfoResponseType aSite = GetSiteInfoObject(SiteNumber, null);
                string xml = WSUtils.ConvertToXml(aSite, typeof(SiteInfoResponseType));
                return xml;
            }

            public string GetVariableInfo(string Variable, String authToken)
            {
                VariablesResponseType aVType = GetVariableInfoObject(Variable, null);
                string xml = WSUtils.ConvertToXml(aVType, typeof(VariablesResponseType));
                return xml;
            }

           
            public SiteInfoResponseType GetSites(string[] SiteNumbers, String authToken)
            {
                //  GlobalClass.WaterAuth.SitesServiceAllowed(Context, authToken);
                Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();

                string location = null;
                if (SiteNumbers != null)
                {
                    location = SiteNumbers.ToString();
                }
                queryLog2.LogStart(Logging.Methods.GetSites, location,
                    getClientIP());


                try
                {
                    var response = ODws.GetSites(SiteNumbers);

                    if (response != null)
                    {
                        queryLog2.LogEnd(Logging.Methods.GetSites,
                            location.ToString(),
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
          

            public virtual SiteInfoResponseType GetSiteInfoObject(string SiteNumber, String authToken)
            {
                //   GlobalClass.WaterAuth.SiteInfoServiceAllowed(Context, authToken);
                Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();

                queryLog2.LogStart(Logging.Methods.GetSiteInfo, SiteNumber,
                    getClientIP());

                try
                {
                    var response = ODws.GetSiteInfo(SiteNumber);

                    if (response != null)
                    {
                        queryLog2.LogEnd(Logging.Methods.GetSiteInfo,
                                         SiteNumber,
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

           


            public VariablesResponseType GetVariableInfoObject(string Variable, String authToken)
            {
                //  GlobalClass.WaterAuth.VariableInfoServiceAllowed(Context, authToken);
                Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();
                queryLog2.LogStart(Logging.Methods.GetVariablesObject, Variable,
                      getClientIP());
                try
                {
                    var response = ODws.GetVariableInfo(Variable);

                    if (response != null)
                    {
                        queryLog2.LogEnd(Logging.Methods.GetVariables,
                                         Variable,
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
           

            public virtual string GetValues(string locationParam, string VariableCode, string StartDate, string EndDate,
                                            String authToken)
            {
                TimeSeriesResponseType aSite = GetValuesObject(locationParam, VariableCode, StartDate, EndDate, null);
                return WSUtils.ConvertToXml(aSite, typeof(TimeSeriesResponseType));
            }

            public virtual TimeSeriesResponseType GetValuesObject(string locationParam, string VariableCode,
                                                                  string StartDate, string EndDate, String authToken)
            {
                //   GlobalClass.WaterAuth.DataValuesServiceAllowed(Context, authToken);
                Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();
                queryLog2.LogValuesStart(Logging.Methods.GetValues, // method
                                 locationParam, //locaiton
                               VariableCode, //variable
                               StartDate, // startdate
                               EndDate, //enddate
                               getClientIP()
                               );
                if (!useODForValues)
                    throw new WaterOneFlowException("GetValues implemented external to this service. Call GetSiteInfo, and SeriesCatalog includes the service Wsdl for GetValues. Attribute:serviceWsdl on Element:seriesCatalog XPath://seriesCatalog/[@serviceWsdl]");
                //throw new SoapException(
                //    "GetValues implemented external to this service. Call GetSiteInfo, and SeriesCatalog includes the service Wsdl for GetValues. Attribute:serviceWsdl on Element:seriesCatalog XPath://seriesCatalog/[@serviceWsdl]",
                //    new XmlQualifiedName("ServiceException"));

                try
                {
                    var response = ODws.GetValues(locationParam, VariableCode, StartDate, EndDate);
                    if (response != null)
                    {
                        queryLog2.LogValuesEnd(Logging.Methods.GetValues,
                                               locationParam, //locaiton
                                               VariableCode, //variable
                                               StartDate, // startdate
                                               EndDate, //enddate
                                               timer.ElapsedMilliseconds, // processing time
                                               response.timeSeries.values.value.Length, // count 
                                               getClientIP()
                            );
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