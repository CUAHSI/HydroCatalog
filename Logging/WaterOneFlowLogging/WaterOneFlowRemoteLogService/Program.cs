using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace WaterOneFlowRemoteLogService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

       static void Main(string[] args)
        {
            ServiceBase[] ServicesToRun;
            //Debugger.Launch();
            if (args.Length > 0)
            {
                if (args[0].ToString() == "DebugMode")
                {
                    LogWorker worker = new LogWorker();
                    //System.Windows.Forms.Application.Run();
                    Console.WriteLine("Press 0 and ENTER to Exit");
                    System.Threading.Thread wt;
                    System.Threading.ThreadStart ts;
                    ts = new ThreadStart(worker.DoWork);
                    wt = new System.Threading.Thread(ts);
                    wt.Start();
                    
                    String keyState = "";
                    while (String.Compare(keyState, "0", true) != 0)
                    {
                        keyState = Console.ReadLine();
                    }
                    worker.StopWork();
  
                }
                else
                {
                    ServicesToRun = new ServiceBase[] { new WaterOneFlowLog() };
                    ServiceBase.Run(ServicesToRun);
                }
            } else
            {
                ServicesToRun = new ServiceBase[] { new WaterOneFlowLog() };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}