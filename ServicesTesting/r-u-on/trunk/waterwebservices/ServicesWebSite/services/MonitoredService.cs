using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServicesWebSite.services
{
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
        public DateTime? LastTested { get; set; }
        [DataMember]
        public string Reliability { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
        
    }
}