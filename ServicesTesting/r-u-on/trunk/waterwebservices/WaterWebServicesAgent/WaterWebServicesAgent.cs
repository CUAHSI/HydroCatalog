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

namespace cuahsi.wof.ruon
{

    public class ObsSeriesServer
    {
        public String Name { get; set; }
        public Boolean Enabled { get; set; }
        public String Endpoint { get; set; }
        public String SiteCode { get; set; }
        public String VariableCode { get; set; }
        public String ISOTimeInterval { get; set; }
        public ObsSeriesServer()
        {

        }
        public Dictionary<String, String> ToDictionary()
        {
            Dictionary<String, String> asDict = new Dictionary<string, string>(6);
            asDict.Add(WaterWebServicesAgent.SERVERNAME, Name);
            asDict.Add(WaterWebServicesAgent.SERVERENABLED, Enabled.ToString());
            asDict.Add(WaterWebServicesAgent.ENDPOINT, Endpoint);
            asDict.Add(WaterWebServicesAgent.SITECODE, SiteCode);
            asDict.Add(WaterWebServicesAgent.VARIABLECODE, VariableCode);
            asDict.Add(WaterWebServicesAgent.ISOTIMEPERIOD, ISOTimeInterval);
            return asDict;
        }

        public string[] ToAgentStringArray()
        {
            return this.ToDictionary().Values.ToArray();
        }

    }
    public class ObsSeriesServerList : List<ObsSeriesServer>
    {
        private Boolean _editied = false;
        public ObsSeriesServerList()
        {

        }
        public ObsSeriesServerList(Dictionary<string, string>[] agentMangagedResources)
        {
            foreach (Dictionary<string, string> r in agentMangagedResources)
            {
                ObsSeriesServer server = new ObsSeriesServer();
                Boolean enabled;
                Boolean.TryParse(r[WaterWebServicesAgent.SERVERENABLED], out enabled);
                server.Enabled = enabled;
                server.Endpoint = r[WaterWebServicesAgent.ENDPOINT];
                server.Name = r[WaterWebServicesAgent.SERVERNAME];
                server.SiteCode = r[WaterWebServicesAgent.SITECODE];
                server.VariableCode = r[WaterWebServicesAgent.VARIABLECODE];
                server.ISOTimeInterval = r[WaterWebServicesAgent.ISOTIMEPERIOD];
                this.Add(server);
            }
        }
        public Boolean Edited
        {
            get { return _editied; }
            set { _editied = value; }
        }
        public Dictionary<string, string>[] AsResource()
        {
            List<Dictionary<String, String>> s = new List<Dictionary<String, String>>(this.Count);
            foreach (var hisCentralServer in this)
            {
                s.Add(hisCentralServer.ToDictionary());
            }
            return s.ToArray();
        }

        public string[][] AsAgentResource()
        {
            List<string[]> s = new List<string[]>(this.Count);
            foreach (var hisCentralServer in this)
            {
                s.Add(hisCentralServer.ToAgentStringArray());
            }
            return s.ToArray();
        }
    }

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

        public const string GETSITES = "Use_GetSites";
        public const string GETVALUES = "Use_GetValues";
        public const string SERVERNAME = "Server_Name";
        public const string SERVERENABLED = "Server_Enabled";
        public const string ENDPOINT = "Endpoint_Url";
        public const string SITECODE = "ws_SiteCode";
        public const string VARIABLECODE = "ws_VariableCode";
        public const string ISOTIMEPERIOD = "ISO_TimeInterval";

        private ObsSeriesServerList _obsSeriesServers;
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
       // run once an hour: 3600 seconds, 
            public WaterWebServicesAgent(IServiceProcess serviceProcess)
            : base("CuahsiWaterServicesAgent", "1.3",
                //"AAAABIESfWjQAAADDrFZJTSn",
               Properties.Settings.Default.AccountId,
             3600, null, null, serviceProcess)
        {

            bool isInstalled = Agent.IsInstalled("CuahsiWaterServicesAgent");
#endif

            Configuration.MetaConfig(
                   new AgentConfig.MetaVar[]
                {
                    // agent parameters
                    new AgentConfig.MetaVar(GETSITES, AgentConfig.Type.Boolean, "true"),
                    new AgentConfig.MetaVar(GETVALUES, AgentConfig.Type.Boolean, "true"),
                },
                     new AgentConfig.MetaVar[]
                {
                    // Manage Resources in comma delimited list
                    new AgentConfig.MetaVar(SERVERNAME,AgentConfig.Type.String, "Unknown Server" ),
                    new AgentConfig.MetaVar(SERVERENABLED,AgentConfig.Type.Boolean, "true" ),
                    new AgentConfig.MetaVar(ENDPOINT, AgentConfig.Type.String, usgsDailyValues),
                    new AgentConfig.MetaVar(SITECODE, AgentConfig.Type.String, "NWIS:10263500"),
                    new AgentConfig.MetaVar(VARIABLECODE, AgentConfig.Type.String, "NWIS:00060"),
                    new AgentConfig.MetaVar(ISOTIMEPERIOD, AgentConfig.Type.String, "2010-08-01T13:00:00Z/2010-08-15T00:00:00Z"),
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
                _obsSeriesServers = new ObsSeriesServerList();

                foreach (var list in Configuration.ManagedResources)
                {
                    _obsSeriesServers.Add(new ObsSeriesServer { Name = list[SERVERNAME], Enabled = Boolean.Parse(list[SERVERENABLED]), Endpoint = list[ENDPOINT] });
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
                    alarms.Add(new Alarm("WaterWebService", "WWS_FAILED", AlarmSeverity.Minor, "ERROR Starting up Monitor Service.? Resources list (series to test) Null "));
                    ReportAlarms(alarms, false);
                    return;
                }




                log.Info("starting run");
                foreach (var server in managedResources)
                {
                    Boolean ServiceHasError = false;
                    if (!Boolean.Parse(server[SERVERENABLED]))
                    {
                        log.Debug("Disabled Service " + server[SERVERNAME]);
                        alarms.Add(new Alarm(server[SERVERNAME], server[SERVERNAME] + "Disabled", AlarmSeverity.Minor, server[SERVERNAME] + " Disabled"));
                        continue;
                    }
                    else
                    {
                        alarms.Add(new Clear(server[SERVERNAME], server[SERVERNAME] + "Disabled", server[SERVERNAME] + " Enabled"));
                    }
                    try
                    {
                        log.InfoFormat("Endpoint {0}, start", server[ENDPOINT]);

                        IWaterWebSericesTester tester = null;
                        ServiceTypeEnum serviceType = ServiceTypeEnum.UNKNOWN;
                        try
                        {
                            serviceType = WsdlUtilities.ServiceTypeFromWsdlUrl(server[ENDPOINT]);
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
                                    log.Warn("Cannot determine Service Type: " + server[ENDPOINT]);
                                    throw new ArgumentException("Cannot determine Service Type: " + server[ENDPOINT]);



                            }
                            log.DebugFormat("OK: WSDL or capabilities for {0}", server[SERVERNAME]);
                            alarms.Add(new Clear(server[SERVERNAME], "WSDL"));

                        }
                        catch (System.Net.WebException ex)
                        {
                            log.ErrorFormat("ERROR: Connecting to WSDL or capabilities for {0} at {1} {2} {3}", server[SERVERNAME], server[ENDPOINT], ex.Message, ex.StackTrace);
                            alarms.Add(new Alarm(server[SERVERNAME], "WSDL", AlarmSeverity.Critical, "ERROR: Connecting to Service: " + server[SERVERNAME]));
                            throw new ServiceConnectionException("ERROR: Fetching WSDL or capabilities: " + server[SERVERNAME], ex);

                        }
                        catch (Exception ex)
                        {
                            log.ErrorFormat("ERROR: When parsing WSDL or capabilities (or other error) for {0} url:  {1} {2} {3}", server[SERVERNAME], server[ENDPOINT], ex.Message, ex.StackTrace);
                            alarms.Add(new Alarm(server[SERVERNAME], "WSDL", AlarmSeverity.Critical, "ERROR: Connecting to Service: " + server[SERVERNAME]));
                            throw new ServiceConnectionException("ERROR: Fetching WSDL or capabilities: " + server[SERVERNAME], ex);

                        }


                        tester.UpdatedTesterStatus += OnTesterStatusUpdate;
                        // set endpoint 
                        // tester.Endpoint = usgsDailyValues;

                        timer2.Reset();

                        tester.Endpoint = server[ENDPOINT];
                        if (Boolean.Parse(Configuration[GETSITES]) && !ServiceHasError)
                        {
                            TestResult result = tester.GetSites(server[SERVERNAME]);

                            if (!result.Working.HasValue || !result.Working.Value)
                            {
                                log.ErrorFormat("FAILED: GetSites {0} {1} " + server[SERVERNAME] + server[ENDPOINT]);
                                alarms.Add(new Alarm(result.ServiceName, result.ServiceName + result.MethodName, AlarmSeverity.Critical, "FAILED: GetSites " + server[SERVERNAME]));
                            }
                            else
                            {
                                log.Debug("OK: GetSites " + server[SERVERNAME]);
                                alarms.Add(new Clear(result.ServiceName, result.ServiceName + result.MethodName, ""));
                            }
                        }
                        if (Boolean.Parse(Configuration[GETVALUES]) && !ServiceHasError)
                        {

                            TestResult result = tester.RunTests(server[SERVERNAME], server[SITECODE], server[VARIABLECODE], server[ISOTIMEPERIOD]);

                            if (!result.Working.HasValue || !result.Working.Value)
                            {
                                log.Error(String.Format("FAILED: GetValues {0},{1},{2}.{3}, {4}", server[SERVERNAME], server[SITECODE], server[VARIABLECODE], server[ISOTIMEPERIOD], server[ENDPOINT]));
                                alarms.Add(new Alarm(result.ServiceName, result.ServiceName + result.MethodName, AlarmSeverity.Critical, String.Format("FAILED: GetValues {0},{1},{2}.{3}, {4}", server[SERVERNAME], server[SITECODE], server[VARIABLECODE], server[ISOTIMEPERIOD], server[ENDPOINT])));
                            }
                            else
                            {
                                log.Debug("OK: GetValues " + server[SERVERNAME]);
                                alarms.Add(new Clear(result.ServiceName, result.ServiceName + result.MethodName, ""));
                            }
                        }

                        log.InfoFormat("Endpoint {0}, end: {1}", server[ENDPOINT], timer2.Elapsed);
                        timer2.Reset();

                    }
                    catch (ServiceConnectionException ex)
                    {
                        // already logged above
                    }
                    catch (Exception ex)
                    {
                        log.ErrorFormat("ERROR: Major Error in Monitor Service while testing service {0} {1} {2} {3}", server[SERVERNAME], server[ENDPOINT], ex.Message, ex.StackTrace);
                        alarms.Add(new Alarm(server[SERVERNAME], "WWS_FAILED", AlarmSeverity.Critical, "ERROR in Monitor Service"));

                    }

                }
                alarms.Add(new Clear("WaterWebService", "WWS_FAILED", "Working Monitor Service"));

                ReportAlarms(alarms, false);
                log.Debug("Number of Alarms reported " + alarms.Count);
                log.InfoFormat("Run Complete {0}", timer.Elapsed);
                timer.Stop();


            }
            catch (Exception ex)
            {
                //   alarms.Add(new Alarm("HIS Central", "Service_Info", AlarmSeverity.Critical, "Error in Monitor Service"));
                // big error. log somewhere
                log.Error("Major Service Error " + ex.Message + ex.StackTrace);

                List<IAlarm> alarms = new List<IAlarm>();
                alarms.Add(new Alarm("WaterWebService", "WWS_FAILED", AlarmSeverity.Critical, "ERROR in Monitor Service"));
                ReportAlarms(alarms, false);
                log.InfoFormat("Run Complete {0}", timer.Elapsed);
                timer.Stop();
            }
        }
    }
}
