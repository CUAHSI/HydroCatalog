using System;
using System.Diagnostics;
using cuahsi.wof.ruon.wof_1_0;
using cuahsi.wof.ruon.wof_1_1;
using log4net;


namespace cuahsi.wof.ruon.wof_1_1
{
    public class WaterWebSericesTester : IWaterWebSericesTester
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

       
        public string serviceName = "WaterOneFlowSoap_Undefined";
        public string endpointSoap = "WaterOneFlowSoap_Undefined";
        private WaterOneFlow svc;

        public WaterWebSericesTester()
        {

            svc = new WaterOneFlow();
            svc.Timeout = Properties.Settings.Default.TimeOutInSeconds * 1000;
            log.Debug("Created WaterWebServices Monitor");
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
            var siteTimer = new Stopwatch();
            siteTimer.Start();
            TestResult testResult = new TestResult {  ServiceName = serviceName, MethodName = "GetSites" };
            try
            {
                //  TesterStatus = "Running GetSites";
                //    UpdatedTesterStatus(this,null);
                var results = svc.GetSitesObject(new string[] { }, null);
                if (results != null)
                {
                    if (results.site.Length > 0)
                    {
                        log.DebugFormat("OK GetSites {0} sitecount {1} in {2} ms " , serviceName , results.site.Length,siteTimer.ElapsedMilliseconds);
                        testResult.Working = true;
                       
                    }
                }
                //  TesterStatus = "Done GetSites "+testResult.Working;
                //  UpdatedTesterStatus(this, null);

            }
            catch (Exception ex)
            {
                log.ErrorFormat("FAILED: GetSites {0} exception {1}", serviceName, ex.Message);
                testResult.ErrorString = ex.Message;
                testResult.Working = false;
            }
            siteTimer.Stop();
            testResult.RunTimeGetSitesSeries = siteTimer.ElapsedMilliseconds;
           
            return testResult;
        }

        public TestResult RunTests(String serverName, String ws_SiteCode, String ws_variableCode, String ISOTimPeriod)
        {
            var runtimer = new Stopwatch();
            runtimer.Start();

            TestResult testResult = new TestResult {  ServiceName = serverName, MethodName = "TestService" };
            IsoTimePeriod isoTimePeriod = new IsoTimePeriod();
            try
            {
                // set to 1 day for now
                isoTimePeriod = IsoTimePeriod.Parse(ISOTimPeriod);
            } catch (Exception ex)
            {
                testResult.ErrorString = String.Format("FAILED PARAMETER: Bad Time Period {0} for {1}",ISOTimPeriod, serverName);
                log.Error(testResult.ErrorString, ex);
                testResult.Working = false;
                return testResult; // can't get a result. Bad data
               
            }
            try
            {
                
                var results = svc.GetSiteInfoObject(ws_SiteCode, null);
                if (results != null)
                {
                    if (results.site.Length > 0)
                    {
                        testResult.Working = true;
                    } else
                    {
                        log.ErrorFormat("FAILED: GetSiteInfo {0} zero sites in {1} ms", serviceName, runtimer.ElapsedMilliseconds);
                        testResult.Working = false;
                    }
                }
                else
                {
                    //  TesterStatus = "failed getSiteInfo";
                    //   UpdatedTesterStatus(this, null);


                    log.ErrorFormat("FAILED:  GetSiteInfo {0} null results in {1} ms", serviceName, runtimer.ElapsedMilliseconds);
                    testResult.Working = false;
                    
                    // return testResult; // keep going to get values
                }

               

                //   TesterStatus = "Running GetValues";
                //   UpdatedTesterStatus(this, null);
                var valuesTimer = new Stopwatch();
                valuesTimer.Start();

                try
                {
 
                    var timeSeries = svc.GetValuesObject(ws_SiteCode, ws_variableCode,
                                                         isoTimePeriod.StartDate.ToString("yyyy-MM-dd"),
                                                         isoTimePeriod.EndDate.ToString("yyyy-MM-dd"),
                                                         null);
                    if (timeSeries != null)
                    {
                        if (timeSeries.timeSeries != null)
                        {
                            testResult.Working = true;
                        }
                        else
                        {
                            log.ErrorFormat(
                                "FAILED:  GetValues empty or null timeseries |{0}|{1}|{2}|{3}|{4}| in {5}ms error: {6}",
                                serviceName, ws_SiteCode, ws_variableCode,
                                isoTimePeriod.StartDate.ToString("yyyy-MM-dd"),
                                isoTimePeriod.EndDate.ToString("yyyy-MM-dd"),
                                valuesTimer.ElapsedMilliseconds,
                                timeSeries.ToString());

                            testResult.Working = false;
                            //  return testResult;
                        }
                    }
                    else
                    {
                        //     TesterStatus = "failed GetValues";
                        //  UpdatedTesterStatus(this, null);
                        log.ErrorFormat("FAILED: GetValues null results |{0}|{1}|{2}|{3}|{4}| in {5} ms",
                                        serviceName, ws_SiteCode, ws_variableCode,
                                        isoTimePeriod.StartDate.ToString("yyyy-MM-dd"),
                                        isoTimePeriod.EndDate.ToString("yyyy-MM-dd"),
                                        valuesTimer.ElapsedMilliseconds);
                        testResult.Working = false;
                        // return testResult;
                    }
                }
                catch (Exception ex)
                {
                    //     TesterStatus = "failed Service Error " + ex.Message;
                    //    UpdatedTesterStatus(this, null);
                    log.ErrorFormat("FAILED: GetValues {0} in {2} ms exception {1} ", serverName, valuesTimer.ElapsedMilliseconds, ex.Message);
                    testResult.Working = false;
                    testResult.ErrorString = ex.Message;
                    //  return testResult;
                }
                valuesTimer.Stop();
                
                //     TesterStatus = "Done GetValues" + testResult.Working;
                //  UpdatedTesterStatus(this, null);
            }
            catch (Exception ex)
            {
                //     TesterStatus = "failed Service Error " + ex.Message;
                //    UpdatedTesterStatus(this, null);
                log.ErrorFormat("FAILED:  Service {0} in {2} ms exception {1} ", serverName, runtimer.ElapsedMilliseconds, ex.Message);
                testResult.Working = false;
                testResult.ErrorString = ex.Message;
                //  return testResult;
            }
            //   TesterStatus = "Done with Run";
            // UpdatedTesterStatus(this, null);
            log.DebugFormat("OK: CompletedRun for service {0} in {1} ms, worked={2} ", serviceName, runtimer.ElapsedMilliseconds, testResult.Working);
            testResult.RunTime = runtimer.ElapsedMilliseconds;
            runtimer.Stop();
          
           
            return testResult;
        }
    }
}