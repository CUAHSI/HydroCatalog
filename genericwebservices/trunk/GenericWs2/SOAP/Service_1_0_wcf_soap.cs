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


namespace WaterOneFlow.odws
{
    using WaterOneFlow.Schema.v1;
    using ConstantsNs = WaterOneFlowImpl.v1_0.Constants;
    namespace v1_0.wcf.soap
    {


        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
        [System.ServiceModel.ServiceContractAttribute(Namespace = "http://www.cuahsi.org/his/1.0/ws/",  ConfigurationName = "WaterOneFlow")]
       // [System.ServiceModel.ServiceContractAttribute(Namespace = "http://www.cuahsi.org/his/1.0/ws/")]
        public interface IWaterOneFlow
        {

            //[System.ServiceModel.OperationContractAttribute(Action = "http://www.cuahsi.org/his/1.0/ws/GetSitesXml", ReplyAction = "*")]
            //[System.ServiceModel.XmlSerializerFormatAttribute()]
            //string GetSitesXml(string[] site, string authToken);

            //[System.ServiceModel.OperationContractAttribute(Action = "http://www.cuahsi.org/his/1.0/ws/GetSiteInfo", ReplyAction = "*")]
            //[System.ServiceModel.XmlSerializerFormatAttribute()]
            //string GetSiteInfo(string site, string authToken);

            //[System.ServiceModel.OperationContractAttribute(Action = "http://www.cuahsi.org/his/1.0/ws/GetVariableInfo", ReplyAction = "*")]
            //[System.ServiceModel.XmlSerializerFormatAttribute()]
            //string GetVariableInfo(string variable, string authToken);
         
            //[System.ServiceModel.OperationContractAttribute(Action = "http://www.cuahsi.org/his/1.0/ws/GetValues", ReplyAction = "*")]
            //[System.ServiceModel.XmlSerializerFormatAttribute()]
            //string GetValues(string location, string variable, string startDate, string endDate, string authToken);

            // CODEGEN: Generating message contract since message part namespace (http://www.cuahsi.org/waterML/1.0/) does not match the default value (http://www.cuahsi.org/his/1.0/ws/)
            [System.ServiceModel.OperationContractAttribute(Action = "http://www.cuahsi.org/his/1.0/ws/GetSites", ReplyAction = "*")]
            [System.ServiceModel.XmlSerializerFormatAttribute()]
            [return: System.ServiceModel.MessageParameterAttribute(Name = "sitesResponse")]
            Service_soap.GetSitesResponse GetSites(Service_soap.GetSitesRequest request);

            // CODEGEN: Generating message contract since message part namespace (http://www.cuahsi.org/waterML/1.0/) does not match the default value (http://www.cuahsi.org/his/1.0/ws/)
            [System.ServiceModel.OperationContractAttribute(Action = "http://www.cuahsi.org/his/1.0/ws/GetSiteInfoObject", ReplyAction = "*")]
            [System.ServiceModel.XmlSerializerFormatAttribute()]
            [return: System.ServiceModel.MessageParameterAttribute(Name = "sitesResponse")]
            Service_soap.GetSiteInfoObjectResponse GetSiteInfoObject(Service_soap.GetSiteInfoObjectRequest request);

            // CODEGEN: Generating message contract since message part namespace (http://www.cuahsi.org/waterML/1.0/) does not match the default value (http://www.cuahsi.org/his/1.0/ws/)
            [System.ServiceModel.OperationContractAttribute(Action = "http://www.cuahsi.org/his/1.0/ws/GetVariableInfoObject", ReplyAction = "*")]
            [System.ServiceModel.XmlSerializerFormatAttribute()]
            [return: System.ServiceModel.MessageParameterAttribute(Name = "variablesResponse")]
            Service_soap.GetVariableInfoObjectResponse GetVariableInfoObject(Service_soap.GetVariableInfoObjectRequest request);

 
            // CODEGEN: Generating message contract since message part namespace (http://www.cuahsi.org/waterML/1.0/) does not match the default value (http://www.cuahsi.org/his/1.0/ws/)
            [System.ServiceModel.OperationContractAttribute(Action = "http://www.cuahsi.org/his/1.0/ws/GetValuesObject", ReplyAction = "*")]
            [System.ServiceModel.XmlSerializerFormatAttribute()]
            [return: System.ServiceModel.MessageParameterAttribute(Name = "timeSeriesResponse")]
            Service_soap.GetValuesObjectResponse GetValuesObject(Service_soap.GetValuesObjectRequest request);
        }




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
        public class Service_soap : WaterOneFlow.odws.v1_0.wcf.Service_1_0, 
            WaterOneFlow.odws.v1_0.wcf.soap.IWaterOneFlow 
        {
            protected ODService ODws;
            //private StandardServices aStandard;
            private Boolean useODForValues;
            private Boolean requireAuthToken;

            private static readonly ILog log = LogManager.GetLogger(typeof(Service_1_0));
            private static readonly ILog queryLog = LogManager.GetLogger("QueryLog");
            private static readonly Logging queryLog2 = new Logging();

            public Service_soap()
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
            public GetSitesResponse GetSites(GetSitesRequest request)
            {
                var response = new GetSitesResponse();
                response.sitesResponse = GetSites(request.site, request.authToken);
                return response;
            }

            [System.Diagnostics.DebuggerStepThroughAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            [System.ServiceModel.MessageContractAttribute(WrapperName = "GetSites", WrapperNamespace = "http://www.cuahsi.org/his/1.0/ws/", IsWrapped = true)]
            public partial class GetSitesRequest
            {

                [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.cuahsi.org/his/1.0/ws/", Order = 0)]
                public string[] site;

                [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.cuahsi.org/his/1.0/ws/", Order = 1)]
                public string authToken;

                public GetSitesRequest()
                {
                }

                public GetSitesRequest(string[] site, string authToken)
                {
                    this.site = site;
                    this.authToken = authToken;
                }
            }
            [System.Diagnostics.DebuggerStepThroughAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            [System.ServiceModel.MessageContractAttribute(WrapperName = "GetSitesResponse", WrapperNamespace = "http://www.cuahsi.org/his/1.0/ws/", IsWrapped = true)]
            public partial class GetSitesResponse
            {

                [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.cuahsi.org/waterML/1.0/", Order = 0)]
                public SiteInfoResponseType sitesResponse;

                public GetSitesResponse()
                {
                }

                public GetSitesResponse(SiteInfoResponseType sitesResponse)
                {
                    this.sitesResponse = sitesResponse;
                }
            }

           

            public GetSiteInfoObjectResponse GetSiteInfoObject(GetSiteInfoObjectRequest request)
            {
                var response = new GetSiteInfoObjectResponse();
                response.sitesResponse = GetSiteInfoObject(request.site, request.authToken);
                return response;
            }

         

            [System.Diagnostics.DebuggerStepThroughAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            [System.ServiceModel.MessageContractAttribute(WrapperName = "GetSiteInfoObject", WrapperNamespace = "http://www.cuahsi.org/his/1.0/ws/", IsWrapped = true)]
            public partial class GetSiteInfoObjectRequest
            {

                [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.cuahsi.org/his/1.0/ws/", Order = 0)]
                public string site;

                [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.cuahsi.org/his/1.0/ws/", Order = 1)]
                public string authToken;

                public GetSiteInfoObjectRequest()
                {
                }

                public GetSiteInfoObjectRequest(string site, string authToken)
                {
                    this.site = site;
                    this.authToken = authToken;
                }
            }
            [System.Diagnostics.DebuggerStepThroughAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            [System.ServiceModel.MessageContractAttribute(WrapperName = "GetSiteInfoObjectResponse", WrapperNamespace = "http://www.cuahsi.org/his/1.0/ws/", IsWrapped = true)]
            public partial class GetSiteInfoObjectResponse
            {

                [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.cuahsi.org/waterML/1.0/", Order = 0)]
                public SiteInfoResponseType sitesResponse;

                public GetSiteInfoObjectResponse()
                {
                }

                public GetSiteInfoObjectResponse(SiteInfoResponseType sitesResponse)
                {
                    this.sitesResponse = sitesResponse;
                }
            }

            public GetVariableInfoObjectResponse GetVariableInfoObject(GetVariableInfoObjectRequest request)
            {

                var response = new GetVariableInfoObjectResponse();
                response.variablesResponse = GetVariableInfoObject(request.variable, request.authToken);
                return response;
            }


          
            [System.Diagnostics.DebuggerStepThroughAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            [System.ServiceModel.MessageContractAttribute(WrapperName = "GetVariableInfoObject", WrapperNamespace = "http://www.cuahsi.org/his/1.0/ws/", IsWrapped = true)]
            public partial class GetVariableInfoObjectRequest
            {

                [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.cuahsi.org/his/1.0/ws/", Order = 0)]
                public string variable;

                [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.cuahsi.org/his/1.0/ws/", Order = 1)]
                public string authToken;

                public GetVariableInfoObjectRequest()
                {
                }

                public GetVariableInfoObjectRequest(string variable, string authToken)
                {
                    this.variable = variable;
                    this.authToken = authToken;
                }
            }
            [System.Diagnostics.DebuggerStepThroughAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            [System.ServiceModel.MessageContractAttribute(WrapperName = "GetVariableInfoObjectResponse", WrapperNamespace = "http://www.cuahsi.org/his/1.0/ws/", IsWrapped = true)]
            public partial class GetVariableInfoObjectResponse
            {

                [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.cuahsi.org/waterML/1.0/", Order = 0)]
                public VariablesResponseType variablesResponse;

                public GetVariableInfoObjectResponse()
                {
                }

                public GetVariableInfoObjectResponse(VariablesResponseType variablesResponse)
                {
                    this.variablesResponse = variablesResponse;
                }
            }

            public GetValuesObjectResponse GetValuesObject(GetValuesObjectRequest request)
            {
                var response = new GetValuesObjectResponse();
                response.timeSeriesResponse = GetValuesObject(request.location, request.variable, request.startDate, request.endDate
                                 , request.authToken);
                return response;

            }

            public virtual string GetValues(string locationParam, string VariableCode, string StartDate, string EndDate,
                                            String authToken)
            {
                TimeSeriesResponseType aSite = GetValuesObject(locationParam, VariableCode, StartDate, EndDate, null);
                return WSUtils.ConvertToXml(aSite, typeof(TimeSeriesResponseType));
            }

          
            [System.Diagnostics.DebuggerStepThroughAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            [System.ServiceModel.MessageContractAttribute(WrapperName = "GetValuesObject", WrapperNamespace = "http://www.cuahsi.org/his/1.0/ws/", IsWrapped = true)]
            public partial class GetValuesObjectRequest
            {

                [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.cuahsi.org/his/1.0/ws/", Order = 0)]
                public string location;

                [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.cuahsi.org/his/1.0/ws/", Order = 1)]
                public string variable;

                [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.cuahsi.org/his/1.0/ws/", Order = 2)]
                public string startDate;

                [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.cuahsi.org/his/1.0/ws/", Order = 3)]
                public string endDate;

                [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.cuahsi.org/his/1.0/ws/", Order = 4)]
                public string authToken;

                public GetValuesObjectRequest()
                {
                }

                public GetValuesObjectRequest(string location, string variable, string startDate, string endDate, string authToken)
                {
                    this.location = location;
                    this.variable = variable;
                    this.startDate = startDate;
                    this.endDate = endDate;
                    this.authToken = authToken;
                }
            }
            [System.Diagnostics.DebuggerStepThroughAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            [System.ServiceModel.MessageContractAttribute(WrapperName = "GetValuesObjectResponse", WrapperNamespace = "http://www.cuahsi.org/his/1.0/ws/", IsWrapped = true)]
            public partial class GetValuesObjectResponse
            {

                [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.cuahsi.org/waterML/1.0/", Order = 0)]
                public TimeSeriesResponseType timeSeriesResponse;

                public GetValuesObjectResponse()
                {
                }

                public GetValuesObjectResponse(TimeSeriesResponseType timeSeriesResponse)
                {
                    this.timeSeriesResponse = timeSeriesResponse;
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