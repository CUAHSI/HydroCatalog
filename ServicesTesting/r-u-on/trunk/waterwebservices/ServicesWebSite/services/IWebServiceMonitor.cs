using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServicesWebSite.services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWebServiceMonitor" in both code and config file together.
    [ServiceContract(Name = "WebServiceMonitor",
        Namespace = "uri:his.cuahsi.org/Monitoring/1/")]
    public interface IWebServiceMonitor
    {
        [OperationContract]
        [WebGet(UriTemplate = "PublicServicesStatus")]
        MonitoredServicesResponse PublicServicesStatus();

        [OperationContract]
        [WebGet(UriTemplate = "ServiceStatus/{serviceCode}")]
        MonitoredServicesResponse ServiceStatus(string serviceCode);
    }
    
   
}
