using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using cuahsi.wof.ruon;

namespace ServicesWebSite.services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMonitoringCollector" in both code and config file together.
    [ServiceContract(Name = "MonitoringCollection",
        Namespace = "uri:his.cuahsi.org/Monitoring/1/")]
    public interface IMonitoringCollector
    {
        [OperationContract(IsOneWay = true)]
        void AcceptTestResult(TestResult testResult);

        [OperationContract(IsOneWay = true)]
        void AcceptTestResults(List<TestResult> testResult);
    }

   
}
