using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;

namespace ServicesWebSite.services
{
      [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WebServiceMonitor : IWebServiceMonitor
    {
        private string SqlCollection = "select * from LastServiceRecords";
        
        public MonitoredServicesResponse PublicServicesStatus()
        {
            var monitoredServices = new MonitoredServicesResponse();

            using (MonitorDbDataContext conn = new MonitorDbDataContext(ConfigurationManager.ConnectionStrings["hiscentral_loggingReader"].ConnectionString))
            {
                var services = from s in conn.LastServiceRecords
                               select s;
                foreach (var lastServiceRecord in services)
                {
                    var ms = new MonitoredService();
                    ms.Network = lastServiceRecord.ServiceName;
                    ms.LastTested = lastServiceRecord.TimeUpdated;
                    ms.Status = lastServiceRecord.Severity;
                    ms.Endpoint = lastServiceRecord.Endpoint;
                    ms.ErrorMessage = lastServiceRecord.ErrorString;
                    monitoredServices.MonitoredServices.Add(ms);

                }
            }
            return monitoredServices;
        }

        public MonitoredServicesResponse ServiceStatus(string ServiceCode)
        {
            var monitoredServices = new MonitoredServicesResponse();

            using (MonitorDbDataContext conn = new MonitorDbDataContext(ConfigurationManager.ConnectionStrings["hiscentral_loggingConnectionString"].ConnectionString))
            {
                var services = from s in conn.LastServiceRecords
                               where s.ServiceName.Equals(ServiceCode)
                               select s;
                foreach (var lastServiceRecord in services)
                {
                    var ms = new MonitoredService();
                    ms.Network = lastServiceRecord.ServiceName;
                    ms.LastTested = lastServiceRecord.TimeUpdated;
                    ms.Status = lastServiceRecord.Severity;
                    ms.Endpoint = lastServiceRecord.Endpoint;
                    ms.ErrorMessage = lastServiceRecord.ErrorString;
                    monitoredServices.MonitoredServices.Add(ms);

                }
            }
            return monitoredServices;
        }
    }
}
