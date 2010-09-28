using System;
using System.IO;
using System.Reflection;
using System.Web;
using System.Web.SessionState;
using System.Configuration;
using System.Net;
using System.Xml;
using log4net;

/// <summary>
/// Summary description for GlobalClass
/// </summary>
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "hiscentral.log4net", Watch = true)]
namespace HisCentral
{

    public class GlobalClass : System.Web.HttpApplication
    {
        private static readonly ILog perfLog = LogManager.GetLogger("PerformanceLogger");

       
      
        void Application_Start(object sender, EventArgs e)
        {

           
            

            // Code that runs on application startup
            String codeDate = File.GetCreationTimeUtc(Assembly.GetExecutingAssembly().Location).ToString();

            String process = "GenericODWS_Start";
            String path = Context.Request.ApplicationPath;
           

            String contact = ConfigurationManager.AppSettings["contactEmail"];

           
            log4net.GlobalContext.Properties["contact"] = contact;

            log4net.GlobalContext.Properties["path"] = path;

            log4net.GlobalContext.Properties["codeDate"] = codeDate;
            perfLog.Info(process);
            var stats = new ServiceStatistics();
            Application.Add("ServiceStatistics", stats);
  
        }




         void Application_End(object sender, EventArgs e)
        {
     
            //  Code that runs on application shutdown
            String process = "GenericODWS_Stop";
            
            perfLog.Info(process);
            perfLog.Info(((ServiceStatistics)Application["ServiceStatistics"]).ToString());
        }

         void Application_Error(object sender, EventArgs e)
        {
          
            // Code that runs when an unhandled error occurs
            perfLog.Error("Application Error");
            perfLog.Info(((ServiceStatistics)Application["ServiceStatistics"]).ToString());
        }

        void Session_Start(object sender, EventArgs e)
        {
            
            perfLog.Debug("sessionStart");

            perfLog.Info(((ServiceStatistics)Application["ServiceStatistics"]).ToString());
        }

         void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.
            perfLog.Debug("sessionEnd");
            perfLog.Info(((ServiceStatistics)Application["ServiceStatistics"]).ToString());
        }
    }
}
