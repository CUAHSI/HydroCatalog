using System;
using cuahsi.wof.ruon.CuahsiSoap;


namespace cuahsi.wof.ruon
{
    public class TestResult
    {
        public bool Working { get; set; }
        public String ServiceName { get; set; }
        public String MethodName { get; set; }
        public String errorString { get; set; }
        public TimeSpan runTime { get; set; }
    }
    public class WaterWebSericesTester
    {
        public string serviceName = "WaterOneFlowSoap_Undefined";
        public string endpointSoap = "WaterOneFlowSoap_Undefined";
        private WaterOneFlow svc;

        public WaterWebSericesTester()
        {

            svc = new WaterOneFlow();
        }
        public String Endpoint
        {
            get { return endpointSoap; }
            set { endpointSoap = value;
                svc.Url = Endpoint;

            }
        }
        public String ServiceName
        {
            get { return serviceName; }
            set { serviceName = value; }
        }

        public TestResult GetSites(string serviceName)
        {
            TestResult testResult = new TestResult { Working = false, ServiceName = serviceName, MethodName = "GetSites" };
            try
            {

                var results = svc.GetSites(new string[] { }, null);
                if (results != null)
                {
                    if (results.site.Length > 0)
                    {
                        testResult.Working = true;
                    }
                }
            }
            catch (Exception ex)
            {
                testResult.errorString = ex.Message;
            }
            return testResult;
        }

        public TestResult RunTests(String serverName, String ws_SiteCode, String ws_variableCode, String ISOTimPeriod)
        {
            TestResult testResult = new TestResult { Working = false, ServiceName = serverName, MethodName = "TestService" };
           IsoTimePeriod isoTimePeriod = new IsoTimePeriod();
            try
            {
                // set to 1 day for now
                isoTimePeriod = IsoTimePeriod.Parse(ISOTimPeriod);
            } catch (Exception ex)
            {
                testResult.errorString = String.Format("Bad Time Period {0} for {1}",ISOTimPeriod, serverName);
            }
            try
            {


                var results = svc.GetSiteInfoObject(ws_SiteCode, null);
                if (results != null)
                {
                    if (results.site.Length > 0)
                    {
                        testResult.Working = true;
                    }
                }
                
                var timeSeries = svc.GetValuesObject(ws_SiteCode, ws_variableCode, "2010-08-01", "2010-08-10", null);
                if (results != null)
                {
                    if (results.site.Length > 0)
                    {
                        testResult.Working = true;
                    }
                }
            }
            catch (Exception ex)
            {
                testResult.errorString = ex.Message;
            }
            return testResult;
        }
    }
}


