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

        public String TesterStatus { get; set; }
        public event EventHandler UpdatedTesterStatus;

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
              //  TesterStatus = "Running GetSites";
            //    UpdatedTesterStatus(this,null);
                var results = svc.GetSites(new string[] { }, null);
                if (results != null)
                {
                    if (results.site.Length > 0)
                    {
                        testResult.Working = true;
                    }
                }
              //  TesterStatus = "Done GetSites "+testResult.Working;
              //  UpdatedTesterStatus(this, null);

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
                             //   TesterStatus =testResult.errorString;
              //  UpdatedTesterStatus(this,null );
            }
            try
            {

                         //       TesterStatus = "Running GetSiteInfo ";
               // UpdatedTesterStatus(this, null);
                var results = svc.GetSiteInfoObject(ws_SiteCode, null);
                if (results != null)
                {
                    if (results.site.Length > 0)
                    {
                        testResult.Working = true;
                    }
                }
                else
                {
                  //  TesterStatus = "failed getSiteInfo";
                 //   UpdatedTesterStatus(this, null);

                    testResult.Working = false;
                    return testResult;
                }
             //   TesterStatus = "Running GetValues";
             //   UpdatedTesterStatus(this, null);
                var timeSeries = svc.GetValuesObject(ws_SiteCode, ws_variableCode, 
                    isoTimePeriod.StartDate.ToString("yyyy-MM-dd"), isoTimePeriod.EndDate.ToString("yyyy-MM-dd"),
                    null);
                if (timeSeries != null)
                {
                    if (timeSeries.timeSeries != null)
                    {
                        testResult.Working = true;
                    } else
                    {
                        testResult.Working = false;
                        return testResult;
                    }
                }
                else
                {
               //     TesterStatus = "failed GetValues";
              //  UpdatedTesterStatus(this, null);
           
                    testResult.Working = false;
                    return testResult;
                }
           //     TesterStatus = "Done GetValues" + testResult.Working;
              //  UpdatedTesterStatus(this, null);
            }
            catch (Exception ex)
            {
           //     TesterStatus = "failed Service Error " + ex.Message;
            //    UpdatedTesterStatus(this, null);
                testResult.Working = false;
                testResult.errorString = ex.Message;
                return testResult;
            }
         //   TesterStatus = "Done with Run";
           // UpdatedTesterStatus(this, null);
            return testResult;
        }
    }
}


