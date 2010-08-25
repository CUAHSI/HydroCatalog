using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace Cuahsi.His.Ruon
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HisCentralMontiorWindow());
        }
        //private static string _message = " working: {0}  method: {1}";
        //private static HISCentralAgent agent;
        //static void Main(string[] args)
        //{
        //    System.Timers.Timer timer = new Timer(1000);
        //   try
        //   {
             
        //       System.Console.WriteLine("Agent Running");
        //       agent = new HISCentralAgent();
        //       agent.MonitorIntervalSec = -1; 
        //       while (true)
        //       {
        //           timer.Start();
        //       }

        //   } catch (Exception ex)
        //   {
        //       System.Console.WriteLine("Error in Agent");
                
        //   }            

        //    System.Console.WriteLine("\nHit AnyKey to continue");
        //    System.Console.ReadKey();
        //}
    }
}
