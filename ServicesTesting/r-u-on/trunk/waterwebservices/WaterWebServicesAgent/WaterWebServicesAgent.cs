using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ruon;

namespace cuahsi.wof.ruon
{

    public class WofServer
    {
        public String Name { get; set; }
        public Boolean Enabled { get; set; }
        public String Endpoint { get; set; }
        public String SiteCode { get; set; }
        public String VariableCode { get; set; }
        public String ISOTimeInterval { get; set; }

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
    public class ServerList : List<WofServer>
    {
        private Boolean _editied = false;
        public ServerList()
        {

        }
        public ServerList(Dictionary<string, string>[] agentMangagedResources)
        {
            foreach (Dictionary<string, string> r in agentMangagedResources)
            {
                WofServer server = new WofServer();
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
    [AgentAttributes("Cuahsi.WaterWebServicesSoap", "R-U-ON Cuahsi WaterWebServicesSoap Agent", "HIS WaterWebServices Soap Agent")]
    public class WaterWebServicesAgent : ServiceAgent
    {
        public const string GETSITES = "Use_GetSites";
        public const string GETVALUES = "Use_GetValues";
        public const string SERVERNAME = "Server_Name";
        public const string SERVERENABLED = "Server_Enabled";
        public const string ENDPOINT = "Endpoint_Url";
        public const string SITECODE = "ws_SiteCode";
        public const string VARIABLECODE = "ws_VariableCode";
        public const string ISOTIMEPERIOD = "ISO_TimeInterval";

        private ServerList servers;
        private string usgsDailyValues = "http://river.sdsc.edu/wateroneflow/NWIS/DailyValues.asmx";
        /// <summary>
        /// Constructor, HAS to have this signature
        /// </summary>
        // public HISCentralAgent(IServiceProcess serviceProcess)
        //: base("HISCentralAgent", "1.0", "AAAABIESfWjQAAADDrFZJTSn",
        // 60, null, null, serviceProcess)
        public WaterWebServicesAgent(IServiceProcess serviceProcess)
            : base("WaterWebServicesAgent", "1.2", 
            //"AAAABIESfWjQAAADDrFZJTSn",
               Properties.Settings.Default.AccountId ,
             300, null, null, serviceProcess)
        {
            bool isInstalled = Agent.IsInstalled("WaterWebServicesAgent");

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
                }
            }
            else
            {
                servers = new ServerList();

                foreach (var list in Configuration.ManagedResources)
                {
                    servers.Add(new WofServer { Name = list[SERVERNAME], Enabled = Boolean.Parse(list[SERVERENABLED]), Endpoint = list[ENDPOINT] });
                }
            }
        }

        private void SetupBaseServices()
        {
            servers = new ServerList();
            servers.Add(new WofServer
                            {
                                Name = "NWISDV",
                                Enabled = true,
                                Endpoint = "http://river.sdsc.edu/wateroneflow/NWIS/DailyValues.asmx",
                                SiteCode = "NWIS:10263500",
                                VariableCode = "NWIS:00060",
                                ISOTimeInterval = "2010-01-01/2010-01-31"
                            });
            servers.Add(new WofServer
                            {
                                Name = "NWISUV",
                                Enabled = true,
                                Endpoint = "http://river.sdsc.edu/wateroneflow/NWIS/UnitValues.asmx",
                                SiteCode = "NWIS:10109000",
                                VariableCode = "NWIS:00065",
                                ISOTimeInterval = "P1D"
                            });
            servers.Add(new WofServer
                            {
                                Name = "Disabled",
                                Enabled = false,
                                Endpoint =
                                    "http://river.sdsc.edu/wateroneflow/NWIS/UnitValues.asmx",
                                SiteCode = "NWIS:10109000",
                                VariableCode = "NWIS:00065",
                                ISOTimeInterval = "P1D"
                            });
            servers.Add(new WofServer
                {
                    Name = "Bad URL",
                    Enabled = true,
                    Endpoint = "http://example.com/wateroneflow/NWIS/UnitValues.asmx",
                    SiteCode = "NWIS:10109000",
                    VariableCode = "NWIS:00065",
                    ISOTimeInterval = "P1D"
                }
                );
            AgentParams ap = new AgentParams();
            ap.Resources = servers.AsAgentResource();
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
            try
            {
                AgentParams ap = new AgentParams();
                List<IAlarm> alarms = new List<IAlarm>();

                WaterWebSericesTester tester = new WaterWebSericesTester();
                tester.UpdatedTesterStatus += OnTesterStatusUpdate;
                // set endpoint 
                tester.Endpoint = usgsDailyValues;

                foreach (var server in managedResources)
                {
                    if (!Boolean.Parse(server[SERVERENABLED]))
                    {
                        alarms.Add(new Alarm(server[SERVERNAME], server[SERVERNAME] + "Disabled", AlarmSeverity.Minor, server[SERVERNAME] + " Disabled"));
                        continue;
                    }
                    else
                    {
                        alarms.Add(new Clear(server[SERVERNAME], server[SERVERNAME] + "Disabled", server[SERVERNAME] + " Enabled"));
                    }
                    try
                    {
                        tester.Endpoint = server[ENDPOINT];
                        if (Boolean.Parse(Configuration[GETSITES]))
                        {
                            TestResult result = tester.GetSites(server[SERVERNAME]);

                            if (!result.Working)
                            {
                                alarms.Add(new Alarm(result.ServiceName, result.ServiceName + result.MethodName, AlarmSeverity.Critical, server[SERVERNAME] + "Service List Failed"));
                            }
                            else
                            {
                                alarms.Add(new Clear(result.ServiceName, result.ServiceName + result.MethodName, ""));
                            }
                        }
                        if (Boolean.Parse(Configuration[GETVALUES]))
                        {

                            TestResult result = tester.RunTests(server[SERVERNAME], server[SITECODE], server[VARIABLECODE], server[ISOTIMEPERIOD]);

                            if (!result.Working)
                            {
                                alarms.Add(new Alarm(result.ServiceName, result.ServiceName + result.MethodName, AlarmSeverity.Critical, "Series Failed " + server[SERVERNAME] + server[SITECODE] + server[VARIABLECODE] + server[ISOTIMEPERIOD]));
                            }
                            else
                            {
                                alarms.Add(new Clear(result.ServiceName, result.ServiceName + result.MethodName, ""));
                            }
                        }


                    }
                    catch
                    {
                        alarms.Add(new Alarm("HIS Central", "Service_Info", AlarmSeverity.Critical, "Error in Monitor Service"));

                    }

                }
                alarms.Add(new Clear("WaterWebService", "WWS_FAILED", "Working Monitor Service"));

                ReportAlarms(alarms, false);


            }
            catch (Exception ex)
            {
                //   alarms.Add(new Alarm("HIS Central", "Service_Info", AlarmSeverity.Critical, "Error in Monitor Service"));
                // big error. log somewhere
                List<IAlarm> alarms = new List<IAlarm>();
                alarms.Add(new Alarm("WaterWebService", "WWS_FAILED", AlarmSeverity.Critical, "Error in Monitor Service"));
                ReportAlarms(alarms, false);
            }
        }
    }
}
