using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Cuahsi.His.Ruon.org.cuahsi.hiscentral;
using log4net;


namespace Cuahsi.His.Ruon
{
    public interface IHisCentralTestResult
    {
        bool Working { get; set; }
        String ServiceName { get; set; }
        String MethodName { get; set; }
        String errorString { get; set; }
        long runTimeMilliseconds { get; set; }
    }

    public class HisCentralTestResult : IHisCentralTestResult
    {
        public bool Working { get; set; }
        public String ServiceName { get; set; }
        public String MethodName { get; set; }
        public String errorString { get; set; }
        public long runTimeMilliseconds { get; set; }
    }

    public interface IHisCentralTester
    {
        String Endpoint { get; set; }
        String ServiceName { get; set; }
        HisCentralTestResult runQueryServiceList(String serviceName);
        HisCentralTestResult runServicesByBox(String serviceName);
        HisCentralTestResult runSeriesCatalogByBox(String serviceName);
        HisCentralTestResult runSearchableConcepts(String serviceName);
        HisCentralTestResult runGetWordListNitrogen(String serviceName);
        HisCentralTestResult runOntologyTree(String serviceName);
    }

    public class HisCentralTester : IHisCentralTester
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private String _serviceName = "HIS_Central";
        private static string hiscentralendpoint = "http://hiscentral.cuahsi.org/webservices/hiscentral.asmx";
        private org.cuahsi.hiscentral.hiscentral svc;

        private Box texas = new Box { xmax = -93.28, xmin = -106.7, ymax = 35.5, ymin = 28.8 };

        private Box chesapeak = new Box { xmax = -75.5, xmin = -76.5, ymax = 39.5, ymin = 37.0 };

        private Box small = new Box { xmax = -71.0, xmin = -72.0, ymax = 42.0, ymin = 41.0 };

        private String nitrogen = "Nitrogen";
        private String streamFlux = "Discharge, Stream";

        private DateTime start = new DateTime(2008, 01, 01);
        private DateTime end = new DateTime(2008, 12, 31);

        public HisCentralTester()
        {
            svc = new hiscentral();
            log.Debug("Created HIS Central Tester");
        }
        public String Endpoint
        {
            get { return hiscentralendpoint; }
            set
            {
                log.Debug("Set Endpoint");
                hiscentralendpoint = value;
                svc.Url = value;
            }
        }
        public String ServiceName
        {
            get { return _serviceName; }
            set { _serviceName = value; }
        }

        public HisCentralTestResult runQueryServiceList(String serviceName)
        {


            HisCentralTestResult testResult = new HisCentralTestResult { Working = false, ServiceName = serviceName, MethodName = "ServiceInfo" };
            log.Debug(String.Format("Entering {0} {1} {2}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, testResult.ServiceName, testResult.MethodName));
            var timer = Stopwatch.StartNew();

            try
            {
                var result = svc.GetWaterOneFlowServiceInfo();
                if (result.Length > 0)
                {
                    log.InfoFormat("{0} {1} in {2}ms {3} results from service info",
                       testResult.ServiceName, testResult.MethodName, timer.Elapsed, result.Length);

                    testResult.Working = true;
                }
                else
                {
                    log.InfoFormat("{0} {1} in {2}ms {3} results from service info",
   testResult.ServiceName, testResult.MethodName, timer.Elapsed, result.Length);

                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("{0} {1} in {2}ms {3} results from service info",
   testResult.ServiceName, testResult.MethodName, timer.Elapsed, ex.Message);

                testResult.Working = false;
            }
            timer.Stop();
            testResult.runTimeMilliseconds = timer.ElapsedMilliseconds;
            log.DebugFormat("Leaving {0} {1} {2} {3}",
    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType,
    testResult.ServiceName,
    testResult.MethodName,
    testResult.runTimeMilliseconds);
            return testResult;
        }

        public HisCentralTestResult runServicesByBox(String serviceName)
        {

            HisCentralTestResult testResult = new HisCentralTestResult
            {
                Working = false,
                ServiceName = serviceName,
                MethodName = "ServicesByBox"
            };
            log.DebugFormat("Entering {0} {1} {2}",
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType,
                testResult.ServiceName, testResult.MethodName);
            var timer = Stopwatch.StartNew();

            try
            {

                var result = svc.GetServicesInBox(texas);
                if (result.Length > 0)
                {
                    log.InfoFormat("{0} {1} in {2}ms {3} results from service info",
                       testResult.ServiceName, testResult.MethodName, timer.Elapsed, result.Length);
                    testResult.Working = true;
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("{0} {1} in {2}ms ex {3} ",
                    testResult.ServiceName, testResult.MethodName, timer.Elapsed, ex.Message);
                testResult.Working = false;
            }
            timer.Stop();
            testResult.runTimeMilliseconds = timer.ElapsedMilliseconds;
            log.Debug(String.Format("Leaving {0} {1} {2} {3}",
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType,
                testResult.ServiceName,
                testResult.MethodName,
                testResult.runTimeMilliseconds));
            return testResult;
        }

        public HisCentralTestResult runSeriesCatalogByBox(String serviceName)
        {

            HisCentralTestResult testResult = new HisCentralTestResult
            {
                Working = false,
                ServiceName = serviceName,
                MethodName = "SeriesCatalogByBox"
            };
            log.DebugFormat("Entering {0} {1} {2}",
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType,
                testResult.ServiceName, testResult.MethodName);

            var timer = Stopwatch.StartNew();
            try
            {
                int[] networks = new int[0];
                string DateFormatString = "yyyy-MM-dd";
                svc.Timeout = 3 * 60000;
                //var result = svc.getSeriesCatalogInBoxPaged(chesapeak.xmin, chesapeak.xmax, chesapeak.ymin, chesapeak.ymax,
                //   nitrogen, "", start.ToString(DateFormatString), end.ToString(DateFormatString), 1);
                //
                var result = svc.GetSeriesCatalogForBox2(small.xmin, small.xmax, small.ymin, small.ymax,
                   streamFlux, "", start.ToString(DateFormatString), end.ToString(DateFormatString));
                if (result.Length > 0)
                {
                    log.InfoFormat("{0} {1} in {2}ms {3} results from service info",
                       testResult.ServiceName, testResult.MethodName, timer.Elapsed, result.Length);

                    testResult.Working = true;
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("{0} {1} in {2}ms ex {3} ",
                    testResult.ServiceName, testResult.MethodName, timer.Elapsed, ex.Message);
                testResult.Working = false;
            }
            timer.Stop();
            testResult.runTimeMilliseconds = timer.ElapsedMilliseconds;
            log.DebugFormat("Leaving {0} {1} {2} {3}",
    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType,
    testResult.ServiceName,
    testResult.MethodName,
    testResult.runTimeMilliseconds);
            return testResult;
        }

        public HisCentralTestResult runSearchableConcepts(String serviceName)
        {
            HisCentralTestResult testResult = new HisCentralTestResult

            {
                Working = false,
                ServiceName = ServiceName,
                MethodName = "SearchableConcepts"
            };
            log.DebugFormat("Entering {0} {1} {2}",
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType,
                testResult.ServiceName, testResult.MethodName);

            var timer = Stopwatch.StartNew();

            try
            {
                svc.Timeout = 3 * 60000;
                var result = svc.GetSearchableConcepts();
                {
                    log.InfoFormat("{0} {1} in {2}ms ex {3} ",
                       testResult.ServiceName, testResult.MethodName, timer.Elapsed, result.Length);

                    testResult.Working = true;
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("{0} {1} in {2}ms error {3} ",
    testResult.ServiceName, testResult.MethodName, timer.Elapsed, ex.Message);
                testResult.Working = false;
            }
            timer.Stop();
            testResult.runTimeMilliseconds = timer.ElapsedMilliseconds;
            log.DebugFormat("Leaving {0} {1} {2} {3}",
    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType,
    testResult.ServiceName,
    testResult.MethodName,
    testResult.runTimeMilliseconds);
            return testResult;
        }
        public HisCentralTestResult runGetWordListNitrogen(String serviceName)
        {
            HisCentralTestResult testResult = new HisCentralTestResult

            {
                Working = false,
                ServiceName = serviceName,
                MethodName = "GetWordList"
            };
            log.DebugFormat("Entering {0} {1} {2}",
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType,
                testResult.ServiceName, testResult.MethodName);

            var timer = Stopwatch.StartNew();

            try
            {



                svc.Timeout = 3 * 60000;
                var result = svc.GetWordList(
                    nitrogen, 10
                    );
                {
                    log.InfoFormat("{0} {1} in {2}ms {3} results from getword list",
   testResult.ServiceName, testResult.MethodName, timer.Elapsed, result.Length);

                    testResult.Working = true;
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("{0} {1} in {2}ms error {3} ",
   testResult.ServiceName, testResult.MethodName, timer.Elapsed, ex.Message);
                testResult.Working = false;
            }
            timer.Stop();
            testResult.runTimeMilliseconds = timer.ElapsedMilliseconds;
            log.DebugFormat("Leaving {0} {1} {2} {3}",
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType,
                testResult.ServiceName,
                testResult.MethodName,
                testResult.runTimeMilliseconds);

            return testResult;
        }


        public HisCentralTestResult runOntologyTree(String serviceName)
        {
            HisCentralTestResult testResult = new HisCentralTestResult

            {
                Working = false,
                ServiceName = ServiceName,
                MethodName = "getOntologyTree"
            };
            log.DebugFormat("Entering {0} {1} {2}",
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType,
                testResult.ServiceName, testResult.MethodName);

            var timer = Stopwatch.StartNew();

            try
            {
                svc.Timeout = 3 * 60000;
                var result = svc.getOntologyTree(null);
                {
                    log.InfoFormat("{0} {1} in {2}ms ex {3} ",
                       testResult.ServiceName, testResult.MethodName, timer.Elapsed, result.childNodes.Length);

                    testResult.Working = true;
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("{0} {1} in {2}ms error {3} ",
    testResult.ServiceName, testResult.MethodName, timer.Elapsed, ex.Message);
                testResult.Working = false;
            }
            timer.Stop();
            testResult.runTimeMilliseconds = timer.ElapsedMilliseconds;
            log.DebugFormat("Leaving {0} {1} {2} {3}",
    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType,
    testResult.ServiceName,
    testResult.MethodName,
    testResult.runTimeMilliseconds);
            return testResult;
        }
    }
}
