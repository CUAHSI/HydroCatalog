using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Runtime.Remoting;
using System.ServiceProcess;
using System.Text;
using System.Threading;

// Configure log4net using the .config file
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "CuahsiRemoteLogger.log4net", Watch = true)]


namespace WaterOneFlowRemoteLogService
{
    partial class WaterOneFlowLog : ServiceBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private LogWorker worker = new LogWorker();
 
        public WaterOneFlowLog()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // TODO: Add code here to start your service.
            // Log an info level message
            System.Threading.Thread wt;
            System.Threading.ThreadStart ts;
            ts = new ThreadStart(worker.DoWork);
            wt = new System.Threading.Thread(ts);
            wt.Start();
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
            worker.StopWork();
            // Log an info level message
            if (log.IsInfoEnabled) log.Info("Application [RemotingServer] End");
        }
        
       
        }
    }

