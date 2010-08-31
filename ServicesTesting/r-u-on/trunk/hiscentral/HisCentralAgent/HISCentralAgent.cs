using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ruon;

namespace Cuahsi.His.Ruon
{
    public class HisCentralServer
    {
        public String Name { get; set; }
        public String Endpoint { get; set; }

        public Dictionary<String, String> ToDictionary()
        {
            Dictionary<String, String> asDict = new Dictionary<string, string>(6);
            asDict.Add(HISCentralAgent.SERVERNAME, Name);
            asDict.Add(HISCentralAgent.ENDPOINT, Endpoint);
            return asDict;
        }

        public string[] ToAgentStringArray()
        {
            return this.ToDictionary().Values.ToArray();
        }
    }
    public class HisCentralServerList  :List<HisCentralServer>
    {
        public HisCentralServerList()
        {
           
        }
        public HisCentralServerList(Dictionary<string, string>[] agentMangagedResources)
        {
            foreach (Dictionary<string, string> r in agentMangagedResources)
            {
                HisCentralServer server = new HisCentralServer();

                server.Endpoint = r[HISCentralAgent.ENDPOINT];
                server.Name = r[HISCentralAgent.SERVERNAME];

                this.Add(server);
            }
        }

        public String[][] AsAgentResource()
        {
            List<String[]> s = new List<string[]>(this.Count);
            foreach (var hisCentralServer in this)
            {
                s.Add(new string[] { hisCentralServer.Name, hisCentralServer.Endpoint });
            }
            return s.ToArray();
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
    }

    /// <summary>
    /// This is an example of a trivial agent that can be loaded by the ServiceLoader.<br/>
    /// <br/>
    /// A non-trivial agent would of course have more activities in the constructor and would
    /// probably override Monitor to poll the state of the resoures being monitored. CoffeeOn shows how it's done.
    /// </summary>
    [AgentAttributes("Cuahsi.HISCentral", "R-U-ON Cuahsi HISCentral Agent", "HIS Central Agent")]
    public class HISCentralAgent : ServiceAgent
    {
        public const string SERVERNAME = "ServerName";
        public const string ENDPOINT = "HIS_Central_Url";
        public const string Monitor_SiteInfo = "Monitor_SiteInfo";
        public const string Monitor_SeriesCatalog = "Monitor_SeriesCatalog";
        public const string Monitor_Ontology = "Monitor_Ontology";

        private string hisCentralEndpointsAsString;
        private HisCentralServerList servers;
        private string hisCentral1 = "http://hiscentral.cuahsi.org/webservices/hiscentral.asmx";
        /// <summary>
        /// Constructor, HAS to have this signature
        /// </summary>
        // public HISCentralAgent(IServiceProcess serviceProcess)
        //: base("HISCentralAgent", "1.0", "AAAABIESfWjQAAADDrFZJTSn",
        // 60, null, null, serviceProcess)
        public HISCentralAgent(IServiceProcess serviceProcess)
            : base("HISCentralAgent", "1.0", 
            //"AAAABIESfWjQAAADDrFZJTSn",
            Properties.Settings.Default.AccountId,
              30, null, null, serviceProcess)
        {


            Configuration.MetaConfig(
               new AgentConfig.MetaVar[]
                {
                    // agent parameters
                    new AgentConfig.MetaVar("Monitor_SiteInfo", AgentConfig.Type.Boolean, "true"),
                    new AgentConfig.MetaVar("Monitor_SeriesCatalog", AgentConfig.Type.Boolean, "true"),
                     new AgentConfig.MetaVar("Monitor_Ontology", AgentConfig.Type.Boolean, "true"),
                },
                 new AgentConfig.MetaVar[]
                {
                    // Manage Resources in comma delimited list
                    new AgentConfig.MetaVar(SERVERNAME,AgentConfig.Type.String, "HISCentral" ),
                    new AgentConfig.MetaVar(ENDPOINT, AgentConfig.Type.String, hisCentral1),
                }

           );
            if (Configuration.ManagedResources.Length == 0)
            {
                SetupBaseServices();
            }
            else
            {
                servers = new HisCentralServerList();

                foreach (var list in Configuration.ManagedResources)
                {
                    servers.Add(new HisCentralServer { Name = list["ServerName"], Endpoint = list["HIS_Central_Url"] });
                }
            }
        }

        private void SetupBaseServices()
        {
            servers = new HisCentralServerList();
            servers.Add(new HisCentralServer { Name = "His1", Endpoint = "http://hiscentral.cuahsi.org/webservices/hiscentral.asmx" });
            servers.Add(new HisCentralServer { Name = "His2", Endpoint = "http://hiscentral.cuahsi.org/webservices/hiscentral.asmx" });
            //string[] his1 = { "His1", "http://hiscentral.cuahsi.org/webservices/hiscentral.asmx" };
            //string[] his2 = { "His2", "http://hiscentral.cuahsi.org/webservices/hiscentral.asmx" };
            AgentParams ap = new AgentParams();
            // ap.Resources = new string[][] { his1, his2 };
            ap.Resources = servers.AsAgentResource();
            this.SetParameters(ap);


        }
        override protected void Monitor()
        {
            Monitor(Configuration.ManagedResources);
        }

       public void Monitor(Dictionary<string, string>[] managedResources)
        {
            try
            {
                AgentParams ap = new AgentParams();
                List<IAlarm> alarms = new List<IAlarm>();

                HisCentralTester tester = new HisCentralTester();
                // set endpoint 
                tester.Endpoint = "http://hiscentral.cuahsi.org/webservices/hiscentral.asmx";

                foreach (var server in managedResources)
                {
                    try
                    {
                        tester.Endpoint = server["HIS_Central_Url"];
                        if (Boolean.Parse(Configuration["Monitor_SiteInfo"]))
                        {
                            HisCentralTestResult result = tester.runQueryServiceList(server["ServerName"]);

                            if (!result.Working)
                            {
                                alarms.Add(new Alarm(result.ServiceName, result.ServiceName + result.MethodName, AlarmSeverity.Critical, "Service List Failed " + result.ServiceName));
                            }
                            else
                            {
                                alarms.Add(new Clear(result.ServiceName, result.ServiceName + result.MethodName, ""));
                            }
                        }
                        if (Boolean.Parse(Configuration["Monitor_SeriesCatalog"]))
                        {

                            HisCentralTestResult result = tester.runSeriesCatalogByBox(server["ServerName"]);

                            if (!result.Working)
                            {
                                alarms.Add(new Alarm(result.ServiceName, result.ServiceName + result.MethodName, AlarmSeverity.Critical, "Series Failed " + result.ServiceName));
                            }
                            else
                            {
                                alarms.Add(new Clear(result.ServiceName, result.ServiceName + result.MethodName, ""));
                            }


                        }

                        if (Boolean.Parse(Configuration["Monitor_Ontology"]))
                        {

                            HisCentralTestResult result = tester.runSeriesCatalogByBox(server["ServerName"]);

                            if (!result.Working)
                            {
                                alarms.Add(new Alarm(result.ServiceName, result.ServiceName + result.MethodName, AlarmSeverity.Critical, "Ontology Failed " + result.ServiceName));
                            }
                            else
                            {
                                alarms.Add(new Clear(result.ServiceName, result.ServiceName + result.MethodName, ""));
                            }

                        }

                    }
                    catch (Exception ex)
                    {
                        alarms.Add(new Event("HIS Central", "ServiceError", AlarmSeverity.Critical, "Error in Monitor Service" + server["ServerName"]));
                    }
                }

                ReportAlarms(alarms, false);

            }
            catch (Exception ex)
            {
                // log error
                List<IAlarm> alarms = new List<IAlarm>();
                alarms.Add(new Event("HIS Central", "CriticalServiceError", AlarmSeverity.Critical, "Critical Error in Monitor Service"));

                ReportAlarms(alarms, false);
            }
        }
    }
}
