using System;
using System.Collections;
using System.Collections.Generic;
using Ruon;

namespace Cuahsi.His.Ruon
{
    public class HisCentralServer
    {
        public String Name{ get; set;}
        public String Endpoint{ get; set;}
       
    }
    public class HisCentralServerList
    {
        private List<HisCentralServer> _servers = new List<HisCentralServer>();
        public List<HisCentralServer> Servers
        {
            get { return _servers; }
            
        }
         public String[][] AsAgentResource()
         {
             List<String[]> s = new List<string[]>(Servers.Count);
             foreach (var hisCentralServer in Servers)
             {
                 s.Add(new string[]{hisCentralServer.Name,hisCentralServer.Endpoint});
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
    public class HISCentralAgent:ServiceAgent
    {
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
            : base("HISCentralAgent", "1.0", "AAAABIESfWjQAAADDrFZJTSn",
              600, null, null, serviceProcess)
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
                    new AgentConfig.MetaVar("ServerName",AgentConfig.Type.String, "HISCentral" ),
                    new AgentConfig.MetaVar("HIS_Central_Url", AgentConfig.Type.String, hisCentral1),
                }

           );
           if (Configuration.ManagedResources.Length == 0)
           {
               SetupBaseServices();
           } else
           {
               servers = new HisCentralServerList();

               foreach (var list in Configuration.ManagedResources)
               {
                   servers.Servers.Add(new HisCentralServer { Name = list["ServerName"], Endpoint = list["HIS_Central_Url"] });
               }
           }
        }

        private void SetupBaseServices()
        {
            servers = new HisCentralServerList();
            servers.Servers.Add(new HisCentralServer{Name="His1", Endpoint="http://hiscentral.cuahsi.org/webservices/hiscentral.asmx"});
            servers.Servers.Add(new HisCentralServer { Name = "His2", Endpoint = "http://hiscentral.cuahsi.org/webservices/hiscentral.asmx" });
                //string[] his1 = { "His1", "http://hiscentral.cuahsi.org/webservices/hiscentral.asmx" };
                //string[] his2 = { "His2", "http://hiscentral.cuahsi.org/webservices/hiscentral.asmx" };
                AgentParams ap = new AgentParams();
               // ap.Resources = new string[][] { his1, his2 };
                ap.Resources = servers.AsAgentResource();
                this.SetParameters(ap);
            
            
        }
        override protected void Monitor()
        {
            try
            {
                   AgentParams ap = new AgentParams();
                List<IAlarm> alarms = new List<IAlarm>();

                HisCentralTester tester = new HisCentralTester();
                // set endpoint 
                tester.Endpoint = "http://hiscentral.cuahsi.org/webservices/hiscentral.asmx";
               
                foreach (var server in Configuration.ManagedResources)
                {
                    try
                    {
                        tester.Endpoint = server["HIS_Central_Url"];
                        if (Boolean.Parse(Configuration["Monitor_SiteInfo"]))
                        {
                            HisCentralTestResult result = tester.runQueryServiceList();

                            if (!result.Working)
                            {
                                alarms.Add(new Alarm(result.ServiceName, result.MethodName, AlarmSeverity.Critical, "Service List Failed"));
                            }
                            else
                            {
                                alarms.Add(new Clear(result.ServiceName, result.MethodName, ""));
                            }
                        }
                        if (Boolean.Parse(Configuration["Monitor_SeriesCatalog"]))
                        {

                            HisCentralTestResult result = tester.runSeriesCatalogByBox();

                            if (!result.Working)
                            {
                                alarms.Add(new Alarm(result.ServiceName, result.MethodName, AlarmSeverity.Critical, "Series Failed"));
                            }
                            else
                            {
                                alarms.Add(new Clear(result.ServiceName, result.MethodName, ""));
                            }

                           
                        }
                        
                      if (Boolean.Parse(Configuration["Monitor_Ontology"]))
                        {

                            HisCentralTestResult result = tester.runSeriesCatalogByBox();

                            if (!result.Working)
                            {
                                alarms.Add(new Alarm(result.ServiceName, result.MethodName, AlarmSeverity.Critical, "Ontology Failed"));
                            }
                            else
                            {
                                alarms.Add(new Clear(result.ServiceName, result.MethodName, ""));
                            }

           
                        }


                         ReportAlarms(alarms, false);
                    }catch
                        {
                            alarms.Add(new Alarm("HIS Central", "Service_Info", AlarmSeverity.Critical, "Error in Monitor Service"));
                            ReportAlarms(alarms, false);
                        }
                }
                //// Get the state
                //int state = machine.GetState();

                //if (state >= 0)
                //{
                //    AlarmConsts alarmConsts = AlarmConstants(state);
                //    if (alarmConsts.severity == AlarmSeverity.Clear) // i.e. not an alarm: clear is needed
                //    {
                //        alarms.Add(new Clear(alarmConsts.resource, alarmConsts.id, alarmConsts.description));
                //    }
                //    else
                //    {
                //        alarms.Add(new Alarm(alarmConsts.resource, alarmConsts.id, alarmConsts.severity, alarmConsts.description));
                //    }

                //    // incremental=false will make sure ELECTRICITY alarm will go down (if exists)
                //    // It is okay to report every time, since ReportAlarms 
                //    // will ignore if it is identical to last time (non-incremental mode only!!!)
                //    ReportAlarms(alarms, false);
                //    reportedElectricityProblem = false;
                //}
                //else
                //{
                //    if (!reportedElectricityProblem)
                //    {
                //        AlarmConsts alarmConsts = AlarmConstants(state);
                //        alarms.Add(new Alarm(alarmConsts.resource, alarmConsts.id, alarmConsts.severity, alarmConsts.description));
                //        ReportAlarms(alarms, true); // Incremental so we don't loose the cofee level alarms.
                //        reportedElectricityProblem = true;
                //    }
                //}
            }
            catch (Exception ex)
            {
                // log error
            }
        }
    }
}
