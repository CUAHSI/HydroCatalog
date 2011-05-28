using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicesWebSite.services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WebServiceMonitor" in code, svc and config file together.
    public class WebServiceMonitor : IWebServiceMonitor
    {
        
        public MonitoredServicesResponse PublicServicesStatus()
        {
            throw new NotImplementedException();
        }

        public MonitoredServicesResponse ServiceStatus()
        {
            throw new NotImplementedException();
        }
    }
}
