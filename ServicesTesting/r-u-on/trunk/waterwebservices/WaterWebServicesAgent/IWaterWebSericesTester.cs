using System;

namespace cuahsi.wof.ruon
{
    public interface IWaterWebSericesTester
    {
        String TesterStatus { get; set; }
        String Endpoint { get; set; }
        String ServiceName { get; set; }
        event EventHandler UpdatedTesterStatus;
        TestResult GetSites(string serviceName);
        TestResult RunTests(String serverName, String ws_SiteCode, String ws_variableCode, String ISOTimPeriod);
    }
}