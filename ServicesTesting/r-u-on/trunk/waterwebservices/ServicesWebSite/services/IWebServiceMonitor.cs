using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicesWebSite.services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWebServiceMonitor" in both code and config file together.
    [ServiceContract(Name = "WebServiceMonitor",
        Namespace = "uri:his.cuahsi.org/Monitoring/1/")]
    public interface IWebServiceMonitor
    {
        [OperationContract]
        MonitoredServicesResponse PublicServicesStatus();

        [OperationContract]
        MonitoredServicesResponse ServiceStatus();
    }
    
    [DataContract(Name = "MonitoredServicesResponse",
        Namespace = "uri:his.cuahsi.org/Monitoring/1/")]
    public class MonitoredServicesResponse
    {
        [DataMember]
        public List<MonitoredService> MonitoredServices { get; private set; }
        
        public MonitoredServicesResponse()
        {
            MonitoredServices = new List<MonitoredService>();
        }
    }

    [DataContract(Name = "MonitoredService",
        Namespace = "uri:his.cuahsi.org/Monitoring/1/")]
    public class MonitoredService
    {
        [DataMember]
        public string Network { get; set; }
        [DataMember]
        public string Endpoint { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public DateTime LastTested { get; set; }
        [DataMember]
        public string Reliability { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
        
    }
}
