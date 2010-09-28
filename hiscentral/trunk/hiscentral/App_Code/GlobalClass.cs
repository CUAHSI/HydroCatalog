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
        private static readonly ILog log = LogManager.GetLogger("PerformanceLogger");

       
      
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
            log.Info(process);
            var stats = new ServiceStatistics();
            Application.Add("ServiceStatistics", stats);
  
        }




         void Application_End(object sender, EventArgs e)
        {
     
            //  Code that runs on application shutdown
            String process = "GenericODWS_Stop";
            
            log.Info(process);
            log.Info(((ServiceStatistics)Application["ServiceStatistics"]).ToString());
        }

         void Application_Error(object sender, EventArgs e)
        {
          
            // Code that runs when an unhandled error occurs
            log.Error("Application Error");
            log.Info(((ServiceStatistics)Application["ServiceStatistics"]).ToString());
        }

        void Session_Start(object sender, EventArgs e)
        {
            
            log.Debug("sessionStart");

            log.Info(((ServiceStatistics)Application["ServiceStatistics"]).ToString());
        }

         void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.
            log.Debug("sessionEnd");
            log.Info(((ServiceStatistics)Application["ServiceStatistics"]).ToString());
        }
    }
}
