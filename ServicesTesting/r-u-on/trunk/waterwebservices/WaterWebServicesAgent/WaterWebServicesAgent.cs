using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using cuahsi.wof.ruon.wof_1_0;
using log4net;
using Ruon;
using HisServiceTypes;
using HisCentralServicesList;

namespace cuahsi.wof.ruon
{

    //public class ObsSeriesServer
    //{
    //    public String Name { get; set; }
    //    public Boolean Enabled { get; set; }
    //    public String Endpoint { get; set; }
    //    public String SiteCode { get; set; }
    //    public String VariableCode { get; set; }
    //    public String ISOTimeInterval { get; set; }
    //    public ObsSeriesServer()
    //    {

    //    }
    //    public Dictionary<String, String> ToDictionary()
    //    {
    //        Dictionary<String, String> asDict = new Dictionary<string, string>(6);
    //        asDict.Add(WaterWebServicesAgent.SERVERNAME, Name);
    //        asDict.Add(WaterWebServicesAgent.SERVERENABLED, Enabled.ToString());
    //        asDict.Add(WaterWebServicesAgent.ENDPOINT, Endpoint);
    //        asDict.Add(WaterWebServicesAgent.SITECODE, SiteCode);
    //        asDict.Add(WaterWebServicesAgent.VARIABLECODE, VariableCode);
    //        asDict.Add(WaterWebServicesAgent.ISOTIMEPERIOD, ISOTimeInterval);
    //        return asDict;
    //    }

    //    public string[] ToAgentStringArray()
    //    {
    //        return this.ToDictionary().Values.ToArray();
    //    }

    //}
    //public class ObsSeriesServerList : List<ObsSeriesServer>
    //{
    //    private Boolean _editied = false;
    //    public ObsSeriesServerList()
    //    {

    //    }
    //    public ObsSeriesServerList(Dictionary<string, string>[] agentMangagedResources)
    //    {
    //        foreach (Dictionary<string, string> r in agentMangagedResources)
    //        {
    //            ObsSeriesServer server = new ObsSeriesServer();
    //            Boolean enabled;
    //            Boolean.TryParse(r[WaterWebServicesAgent.SERVERENABLED], out enabled);
    //            server.Enabled = enabled;
    //            server.Endpoint = r[WaterWebServicesAgent.ENDPOINT];
    //            server.Name = r[WaterWebServicesAgent.SERVERNAME];
    //            server.SiteCode = r[WaterWebServicesAgent.SITECODE];
    //            server.VariableCode = r[WaterWebServicesAgent.VARIABLECODE];
    //            server.ISOTimeInterval = r[WaterWebServicesAgent.ISOTIMEPERIOD];
    //            this.Add(server);
    //        }
    //    }
    //    public Boolean Edited
    //    {
    //        get { return _editied; }
    //        set { _editied = value; }
    //    }
    //    public Dictionary<string, string>[] AsResource()
    //    {
    //        List<Dictionary<String, String>> s = new List<Dictionary<String, String>>(this.Count);
    //        foreach (var hisCentralServer in this)
    //        {
    //            s.Add(hisCentralServer.ToDictionary());
    //        }
    //        return s.ToArray();
    //    }

    //    public string[][] AsAgentResource()
    //    {
    //        List<string[]> s = new List<string[]>(this.Count);
    //        foreach (var hisCentralServer in this)
    //        {
    //            s.Add(hisCentralServer.ToAgentStringArray());
    //        }
    //        return s.ToArray();
    //    }
    //}

    /// <summary>
    /// This is an example of a trivial agent that can be loaded by the ServiceLoader.<br/>
    /// <br/>
    /// A non-trivial agent would of course have more activities in the constructor and would
    /// probably override Monitor to poll the state of the resoures being monitored. CoffeeOn shows how it's done.
    /// </summary>

#if SDSCServices
    [AgentAttributes("Cuahsi.SDSCServicesSoap", "R-U-ON SDSC WaterWebServicesSoap Agent", "SDSC WaterWebServices Soap Agent")]

#elif DEBUG
      [AgentAttributes("Cuahsi.WaterWebServicesSoap", "R-U-ON Cuahsi WaterWebServicesSoap Agent", "HIS WaterWebServices Soap Agent")]
   
#else
    [AgentAttributes("Cuahsi.WaterWebServicesSoap", "R-U-ON Cuahsi WaterWebServicesSoap Agent", "HIS WaterWebServices Soap Agent")]

#endif

    public class WaterWebServicesAgent : ServiceAgent
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //public const string GETSITES = "Use_GetSites";
        //public const string GETVALUES = "Use_GetValues";
        //public const string READFROMCENTRAL = "Use_HISCENTRAL_forSeries";
        //public const string SERVERNAME = "Server_Name";
        //public const string SERVERENABLED = "Server_Enabled";
        //public const string ENDPOINT = "Endpoint_Url";
        //public const string SITECODE = "ws_SiteCode";
        //public const string VARIABLECODE = "ws_VariableCode";
        //public const string ISOTIMEPERIOD = "ISO_TimeInterval";

        //public const string MONITORSERVICE_SERVICENAME = "WaterWebService";

        //public const string MONITORSERVICE_METHOD = "WWS_STATUS";

        //public const string URLDISABLED_METHODNAME = "URL_STATUS";
        //public const string DISABLED_MESSAGE = " DISABLED";
        //public const string ENABLED_MESSAGE = " ENABLED";

        private ObsSeriesServerList _obsSeriesServers;
        private ObsSeriesServerList _obsSeriesServersNew;
        
        private string usgsDailyValues = "http://river.sdsc.edu/wateroneflow/NWIS/DailyValues.asmx";
        /// <summary>
        /// Constructor, HAS to have this signature
        /// </summary>
        // public HISCentralAgent(IServiceProcess serviceProcess)
        //: base("HISCentralAgent", "1.0", "AAAABIESfWjQAAADDrFZJTSn",
        // 60, null, null, serviceProcess)
#if SDSCServices
        // 300 seconds-five minutes
        public WaterWebServicesAgent(IServiceProcess serviceProcess)
            : base("WaterWebServicesAgent", "1.3", 
            //"AAAABIESfWjQAAADDrFZJTSn",
               Properties.Settings.Default.AccountId ,
             300, null, null, serviceProcess)
        {
        bool isInstalled = Agent.IsInstalled("WaterWebServicesAgent");
      
#elif DEBUG
        // 0seconds, aka run once
        public WaterWebServicesAgent(IServiceProcess serviceProcess)
            : base("CuahsiWaterServicesAgent", "1.3",
                //"AAAABIESfWjQAAADDrFZJTSn",
               Properties.Settings.Default.AccountId,
             0, null, null, serviceProcess)
        {

            bool isInstalled = Agent.IsInstalled("CuahsiWaterServicesAgent");
        
#else
        // run once an hour: 3600 seconds, or as configured in the DLL .config
        public WaterWebServicesAgent(IServiceProcess serviceProcess)
            : base("CuahsiWaterServicesAgent", "1.3",
                //"AAAABIESfWjQAAADDrFZJTSn",
               Properties.Settings.Default.AccountId,
             Properties.Settings.Default.RunInterval, null, null, serviceProcess)
        {

            bool isInstalled = Agent.IsInstalled("CuahsiWaterServicesAgent");
            
#endif
            log.DebugFormat("RunInterval Property:{0}, Agent:{1})",
                      Properties.Settings.Default.RunInterval, MonitorIntervalSec);
            Configuration.MetaConfig(
                   new AgentConfig.MetaVar[]
                {
                    // agent parameters
                    new AgentConfig.MetaVar(constants.GETSITES, AgentConfig.Type.Boolean, "true"),
                    new AgentConfig.MetaVar(constants.GETVALUES, AgentConfig.Type.Boolean, "true"),
 #if SDSCServices
       
                    new AgentConfig.MetaVar(constants.READFROMCENTRAL,AgentConfig.Type.Boolean, "false"),
#else
                   new AgentConfig.MetaVar(constants.READFROMCENTRAL,AgentConfig.Type.Boolean, "true"),

#endif
                },
                     new AgentConfig.MetaVar[]
                {
                    // Manage Resources in comma delimited list
                    new AgentConfig.MetaVar(constants.SERVERNAME,AgentConfig.Type.String, "Unknown Server" ),
                    new AgentConfig.MetaVar(constants.SERVERENABLED,AgentConfig.Type.Boolean, "true" ),
                    new AgentConfig.MetaVar(constants.ENDPOINT, AgentConfig.Type.String, usgsDailyValues),
                    new AgentConfig.MetaVar(constants.SITECODE, AgentConfig.Type.String, "NWIS:10263500"),
                    new AgentConfig.MetaVar(constants.VARIABLECODE, AgentConfig.Type.String, "NWIS:00060"),
                    new AgentConfig.MetaVar(constants.ISOTIMEPERIOD, AgentConfig.Type.String, "2010-08-01T13:00:00Z/2010-08-15T00:00:00Z"),
                }

               );

            if (Configuration.ManagedResources.Length == 0)
            {
                try
                {
                    SetupBaseServices();
                }
                catch (Exception ex)
                {
                    // log something
                    log.Error("Setup failed");
                }
            }
            else
            {
                log.Debug("Reading Services");
                _obsSeriesServers = new ObsSeriesServerList();

                foreach (var list in Configuration.ManagedResources)
                {
                    _obsSeriesServers.Add(new ObsSeriesServer { Name = list[constants.SERVERNAME], Enabled = Boolean.Parse(list[constants.SERVERENABLED]), Endpoint = list[constants.ENDPOINT] });
                }
            }
        }

        


        private void SetupBaseServices()
        {
            _obsSeriesServers = new ObsSeriesServerList();
            _obsSeriesServers.Add(new ObsSeriesServer
                            {
                                Name = "NWISDV",
                                Enabled = true,
                                Endpoint = "http://river.sdsc.edu/wateroneflow/NWIS/DailyValues.asmx?WSDL",
                                SiteCode = "NWIS:10263500",
                                VariableCode = "NWIS:00060",
                                ISOTimeInterval = "2010-01-01/2010-01-31"
                            });
            _obsSeriesServers.Add(new ObsSeriesServer
                            {
                                Name = "NWISUV",
                                Enabled = true,
                                Endpoint = "http://river.sdsc.edu/wateroneflow/NWIS/UnitValues.asmx?WSDL",
                                SiteCode = "NWIS:10109000",
                                VariableCode = "NWIS:00065",
                                ISOTimeInterval = "P1D"
                            });
            _obsSeriesServers.Add(new ObsSeriesServer
                            {
                                Name = "Disabled",
                                Enabled = false,
                                Endpoint =
                                    "http://river.sdsc.edu/wateroneflow/NWIS/UnitValues.asmx?WSDL",
                                SiteCode = "NWIS:10109000",
                                VariableCode = "NWIS:00065",
                                ISOTimeInterval = "P1D"
                            });
            _obsSeriesServers.Add(new ObsSeriesServer
                {
                    Name = "Bad URL",
                    Enabled = true,
                    Endpoint = "http://example.com/wateroneflow/NWIS/UnitValues.asmx?WSDL",
                    SiteCode = "NWIS:10109000",
                    VariableCode = "NWIS:00065",
                    ISOTimeInterval = "P1D"
                }
                );
            AgentParams ap = new AgentParams();
            ap.Resources = _obsSeriesServers.AsAgentResource();
            this.SetParameters(ap);
        }

        public event EventHandler UpdatedStatus;
        public string AgentStatus { get; set; }

        override protected void Uninstall()
        {
            base.Uninstall();
            Dispose();
            //
        }

        override protected void Monitor()
        {
            Monitor(Configuration.ManagedResources);
        }

        public void OnTesterStatusUpdate(object sender, EventArgs eventArgs)
        {
            AgentStatus = ((WaterWebSericesTester)sender).TesterStatus;
            UpdatedStatus(this, null);
        }
        public void Monitor(Dictionary<string, string>[] managedResources)
        {
            log.Debug("Starting Monitor method");
            List<ITestResult2> testResults = new List<ITestResult2>();

            Stopwatch timer = new Stopwatch();
            timer.Start();
            Stopwatch timer2 = new Stopwatch();
            timer2.Start();
            try
            {
                AgentParams ap = new AgentParams();
                List<IAlarm> alarms = new List<IAlarm>();
                if (managedResources == null)
                {
                    log.Error("ManageResources is null (starting up?)");
                    var startupError = new TestResult
                    {
                        Working = false,
                        ServiceName = constants.MONITORSERVICE_SERVICENAME,
                        MethodName = constants.MONITORSERVICE_METHOD,
                        ErrorString =
                             "ERROR Starting up Monitor Service.? Resources list (series to test) Null ",
                        Serverity = AlarmSeverity.Minor
                    };

                    testResults.Add(startupError);

                    alarms.Add(new Alarm(startupError.ServiceName, startupError.MethodName, AlarmSeverity.Minor, "ERROR Starting up Monitor Service.? Resources list (series to test) Null "));

                    ReportAlarms(alarms, false);
                    SendTestResults(testResults);
                    return;
                }




                log.Info("starting run");
                foreach (var server in managedResources)
                {
                    Boolean ServiceHasError = false;
                    if (!Boolean.Parse(server[constants.SERVERENABLED]))
                    {
                        log.Debug(constants.URLDISABLED_METHODNAME + " " + server[constants.SERVERNAME]);
                        var disabledAlarm = new TestResult(false,
                            AlarmSeverity.Minor,
                            server[constants.SERVERNAME],
                            constants.URLDISABLED_METHODNAME,
                             server[constants.ENDPOINT],
                             server[constants.SERVERNAME] + constants.DISABLED_MESSAGE);
                        testResults.Add(disabledAlarm);

                        alarms.Add(new Alarm(server[constants.SERVERNAME], server[constants.SERVERNAME] + constants.URLDISABLED_METHODNAME, AlarmSeverity.Minor, server[constants.SERVERNAME] + " Disabled"));
                        continue;
                    }
                    else
                    {
                        var clearAlarm = new TestResult(true,
                            AlarmSeverity.Clear,
                            server[constants.SERVERNAME],
                             constants.URLDISABLED_METHODNAME,
                             server[constants.ENDPOINT],
                             server[constants.SERVERNAME] + constants.ENABLED_MESSAGE);
                        testResults.Add(clearAlarm);
                        alarms.Add(new Clear(server[constants.SERVERNAME], server[constants.SERVERNAME] + constants.URLDISABLED_METHODNAME, server[constants.SERVERNAME] + " Enabled"));
                    }

                    try
                    {
                        log.InfoFormat("Endpoint {0}, start", server[constants.ENDPOINT]);

                        IWaterWebSericesTester tester = null;
                        ServiceTypeEnum serviceType = ServiceTypeEnum.UNKNOWN;
                        try
                        {
                            serviceType = WsdlUtilities.ServiceTypeFromWsdlUrl(server[constants.ENDPOINT]);
                            switch (serviceType)
                            {
                                case HisServiceTypes.ServiceTypeEnum.WOF_1_0:
                                    tester = new cuahsi.wof.ruon.wof_1_0.WaterWebSericesTester();
                                    break;
                                case HisServiceTypes.ServiceTypeEnum.WOF_1_1:
                                    tester = new cuahsi.wof.ruon.wof_1_1.WaterWebSericesTester();
                                    break;
                                case HisServiceTypes.ServiceTypeEnum.WOF_1_1_badNamespace:
                                    tester = new cuahsi.wof.ruon.wof_1_1_badnamespace.WaterWebSericesTester();
                                    break;
                                default:
                                    log.Warn("Cannot determine Service Type: " + server[constants.ENDPOINT]);
                                    throw new ArgumentException("Cannot determine Service Type: " + server[constants.ENDPOINT]);



                            }
                            log.DebugFormat("OK: WSDL or capabilities for {0}", server[constants.SERVERNAME]);
                            var clearAlarm = new TestResult(true,
                            AlarmSeverity.Clear,
                            server[constants.SERVERNAME],
                             "WSDL",
                             server[constants.ENDPOINT],
                             "OK: WSDL or capabilities");
                            testResults.Add(clearAlarm);

                            alarms.Add(new Clear(server[constants.SERVERNAME], "WSDL"));

                        }
                        catch (System.Net.WebException ex)
                        {
                            string errorMessage =
                                string.Format("ERROR: Connecting to WSDL or capabilities for {0} at {1} {2} {3}",
                                              server[constants.SERVERNAME], server[constants.ENDPOINT], ex.Message, ex.StackTrace);
                            log.ErrorFormat(errorMessage);
                            var errorService = new TestResult
                            {
                                Working = false,
                                ServiceName = server[constants.SERVERNAME],
                                MethodName = "WSDL",
                                ErrorString = "ERROR: Connecting to Service: " + server[constants.SERVERNAME],
                                Serverity = AlarmSeverity.Critical,
                                Endpoint = server[constants.ENDPOINT],
                                ExceptionMessage = errorMessage
                            };

                            testResults.Add(errorService);

                            alarms.Add(new Alarm(server[constants.SERVERNAME], "WSDL", AlarmSeverity.Critical, "ERROR: Connecting to Service: " + server[constants.SERVERNAME]));

                            throw new ServiceConnectionException("ERROR: Fetching WSDL or capabilities: " + server[constants.SERVERNAME], ex);

                        }
                        catch (Exception ex)
                        {
                            string errorMessage =
                                string.Format("ERROR: When parsing WSDL or capabilities (or other error) for {0} url:  {1} {2} {3}", server[constants.SERVERNAME], server[constants.ENDPOINT], ex.Message, ex.StackTrace);
                            log.Error(errorMessage);
                            var errorService = new TestResult
                            {
                                Working = false,
                                ServiceName = server[constants.SERVERNAME],
                                MethodName = "WSDL",
                                ErrorString = "ERROR: Connecting to Service: " + server[constants.SERVERNAME],
                                Serverity = AlarmSeverity.Critical,
                                Endpoint = server[constants.ENDPOINT],
                                ExceptionMessage = errorMessage
                            };
                            testResults.Add(errorService);
                            alarms.Add(new Alarm(server[constants.SERVERNAME], "WSDL", AlarmSeverity.Critical, "ERROR: Connecting to Service: " + server[constants.SERVERNAME]));
                            throw new ServiceConnectionException("ERROR: Fetching WSDL or capabilities: " + server[constants.SERVERNAME], ex);

                        }


                        tester.UpdatedTesterStatus += OnTesterStatusUpdate;
                        // set endpoint 
                        // tester.Endpoint = usgsDailyValues;

                        timer2.Reset();

                        tester.Endpoint = server[constants.ENDPOINT];
                        if (Boolean.Parse(Configuration[constants.GETSITES]) && !ServiceHasError)
                        {
                            TestResult result = tester.GetSites(server[constants.SERVERNAME]);
                            testResults.Add(result);

                            if (!result.Working.HasValue || !result.Working.Value)
                            {
                                log.ErrorFormat("FAILED: GetSites {0} {1} " + server[constants.SERVERNAME] + server[constants.ENDPOINT]);
                                alarms.Add(new Alarm(result.ServiceName, result.ServiceName + result.MethodName, AlarmSeverity.Critical, "FAILED: GetSites " + server[constants.SERVERNAME]));
                            }
                            else
                            {
                                log.Debug("OK: GetSites " + server[constants.SERVERNAME]);
                                alarms.Add(new Clear(result.ServiceName, result.ServiceName + result.MethodName, ""));
                            }
                        }
                        if (Boolean.Parse(Configuration[constants.GETVALUES]) && !ServiceHasError)
                        {

                            TestResult result = tester.RunTests(server[constants.SERVERNAME], server[constants.SITECODE], server[constants.VARIABLECODE], server[constants.ISOTIMEPERIOD]);
                            testResults.Add(result);

                            if (!result.Working.HasValue || !result.Working.Value)
                            {
                                log.Error(String.Format("FAILED: GetValues {0},{1},{2}.{3}, {4}", server[constants.SERVERNAME], server[constants.SITECODE], server[constants.VARIABLECODE], server[constants.ISOTIMEPERIOD], server[constants.ENDPOINT]));
                                alarms.Add(new Alarm(result.ServiceName, result.ServiceName + result.MethodName, AlarmSeverity.Critical, String.Format("FAILED: GetValues {0},{1},{2}.{3}, {4}", server[constants.SERVERNAME], server[constants.SITECODE], server[constants.VARIABLECODE], server[constants.ISOTIMEPERIOD], server[constants.ENDPOINT])));
                            }
                            else
                            {
                                log.Debug("OK: GetValues " + server[constants.SERVERNAME]);

                                alarms.Add(new Clear(result.ServiceName, result.ServiceName + result.MethodName, ""));
                            }
                        }

                        log.InfoFormat("Endpoint {0}, end: {1}", server[constants.ENDPOINT], timer2.Elapsed);
                        timer2.Reset();

                    }
                    catch (ServiceConnectionException ex)
                    {
                        // already logged above
                    }
                    catch (Exception ex)
                    {
                        string errorMessage =
                                string.Format("ERROR: Major Error in Monitor Service while testing service {0} {1} {2} {3}", server[constants.SERVERNAME], server[constants.ENDPOINT], ex.Message, ex.StackTrace);
                        log.Error(errorMessage);
                        var errorService = new TestResult
                        {
                            Working = false,
                            ServiceName = server[constants.SERVERNAME],
                            MethodName = constants.MONITORSERVICE_METHOD,
                            ErrorString = "ERROR in Monitor Service testing service " + server[constants.SERVERNAME],
                            Serverity = AlarmSeverity.Critical
                        };

                        testResults.Add(errorService);

                        alarms.Add(new Alarm(server[constants.SERVERNAME], constants.MONITORSERVICE_METHOD, AlarmSeverity.Critical, "ERROR in Monitor Service"));

                    }

                }

                var clearService = new TestResult(true,
                           AlarmSeverity.Clear,
                          constants. MONITORSERVICE_SERVICENAME,
                            constants.MONITORSERVICE_METHOD);
                clearService.ErrorString = "OK: Monitor Service Working";
                testResults.Add(clearService);

                alarms.Add(new Clear(constants.MONITORSERVICE_SERVICENAME, constants.MONITORSERVICE_METHOD, "OK: Working Monitor Service"));
               
                // get new services, and clear removed services
                _obsSeriesServersNew = HisCentralServicesList.HisSeriesList.SeriesList();
                HisCentralServicesList.HisSeriesList.DisableSeries(_obsSeriesServers, _obsSeriesServersNew);

                foreach (string removedNetwork in HisCentralServicesList.HisSeriesList.RemovedNetworks(_obsSeriesServers, _obsSeriesServersNew))
                {
                    alarms.Add(new Clear(removedNetwork, constants.MONITORSERVICE_METHOD, "OK: Working Monitor Service"));
                    // I might need to add testResult here.
                }
   //

                ReportAlarms(alarms, false);
                SendTestResults(testResults);

                log.Debug("Number of Alarms reported " + alarms.Count);
                log.InfoFormat("Run Complete {0}", timer.Elapsed);
                timer.Stop();


            }
            catch (Exception ex)
            {
                //   alarms.Add(new Alarm("HIS Central", "Service_Info", AlarmSeverity.Critical, "Error in Monitor Service"));
                // big error. log somewhere
                String errorMessage = "Major Service Error " + ex.Message + ex.StackTrace;
                log.Error(errorMessage);
                var errorService = new TestResult
                                       {
                                           Working = false,
                                           ServiceName = constants.MONITORSERVICE_SERVICENAME,
                                           MethodName = constants.MONITORSERVICE_METHOD,
                                           ErrorString = "ERROR in Monitor Service",
                                           Serverity = AlarmSeverity.Critical,
                                           ExceptionMessage = errorMessage
                                       };

                testResults.Add(errorService);

                List<IAlarm> alarms = new List<IAlarm>();
                alarms.Add(new Alarm(constants.MONITORSERVICE_SERVICENAME, constants.MONITORSERVICE_METHOD, AlarmSeverity.Critical, "ERROR in Monitor Service"));
                ReportAlarms(alarms, false);
                SendTestResults(testResults);
                log.InfoFormat("Run Complete {0}", timer.Elapsed);
                timer.Stop();
            }
         if (Boolean.Parse(Configuration[constants.READFROMCENTRAL])){
            UpdateServiceList();
}
        }

    private void UpdateServiceList ()
    {
        log.Info("Updateing Services List");
        _obsSeriesServersNew = HisCentralServicesList.HisSeriesList.SeriesList();
        HisCentralServicesList.HisSeriesList.DisableSeries(_obsSeriesServers, _obsSeriesServersNew);
        
        AgentParams ap = new AgentParams();
        ap.Resources = _obsSeriesServersNew.AsAgentResource();
        this.SetParameters(ap);
    }
        protected void SendTestResults(List<ITestResult2> testResults)
        {
           try{
               using (var svc = new MonitoringCollection.MonitoringCollectionClient())
            {
                List<MonitoringCollection.TestResult> list =
                    testResults.ConvertAll(
                        new Converter<ITestResult2, MonitoringCollection.TestResult>(TestResultToMcTestResult));
                svc.AcceptTestResults(list.ToArray());
            }
           } catch (Exception ex)
           {
               log.Error("Could Not send results to Web Service. Look at the binding size. http://stackoverflow.com/questions/784606/large-wcf-web-service-request-failing-with-400-http-bad-request "+ ex.Message + ex.StackTrace);
           }
        }

        public static MonitoringCollection.TestResult TestResultToMcTestResult(ITestResult2 testResult)
        {
            var tr = new MonitoringCollection.TestResult
                         {
                             Working = testResult.Working,
                             ServiceName = testResult.ServiceName,
                             MethodName = testResult.MethodName,
                             ErrorString = testResult.ErrorString,
                             Serverity = testResult.Serverity,
                             ExceptionMessage = testResult.ExceptionMessage,
                             Location = testResult.Location,
                             Variable = testResult.Variable,
                             StartDate = testResult.StartDate,
                             EndDate = testResult.EndDate,
                             Endpoint = testResult.Endpoint,
                             Identifier = testResult.Identifier,
                             RunTime = testResult.RunTime,

                         };
            return tr;
        }
    }

}
