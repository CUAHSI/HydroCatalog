using System;
using System.Collections.Generic;
using System.Text;
using Cuahsi.His.Ruon.org.cuahsi.hiscentral;

namespace Cuahsi.His.Ruon
{
public class HisCentralTestResult
{
    public bool Working { get; set; }
    public String ServiceName { get; set; }
    public String MethodName { get; set; }
    public String errorString { get; set; }
    public TimeSpan runTime { get; set; }
}

    public class HisCentralTester
    {
        private String _serviceName = "HIS_Central";
        private static string hiscentralendpoint = "http://hiscentral.cuahsi.org/webservices/hiscentral.asmx";
        private org.cuahsi.hiscentral.hiscentral svc;

        private Box texas = new Box{xmax=-93.28,xmin=-106.7,ymax=35.5, ymin=28.8};
        
        private Box chesapeak = new Box { xmax = -75.5, xmin = -76.5, ymax = 39.5, ymin = 37.0 };

        private Box small = new Box { xmax = -106.7, xmin = -93.28, ymax = 3.5, ymin = 28.8 };

        private String nitrogen = "Nitrogen";
        private String streamFlux = "Discharge, Stream";

        private DateTime start = new DateTime(2008,01,01);
        private DateTime end = new DateTime(2008, 12, 31);

        public HisCentralTester()
        {
            svc = new hiscentral();
        }
        public String Endpoint
        {
            get { return hiscentralendpoint; }
            set { hiscentralendpoint = value; }
        }
        public String ServiceName
        {
            get { return _serviceName; }
            set { _serviceName = value; }
        }

        public HisCentralTestResult runQueryServiceList(){

         HisCentralTestResult testResult = new HisCentralTestResult{Working = false, ServiceName=ServiceName,MethodName="ServiceInfo" };
           
            try
            {
                var result = svc.GetWaterOneFlowServiceInfo();
                if (result.Length > 0)
                {

                
                testResult.Working = true;
                }
            }
            catch (Exception ex)
            {
                testResult.Working = false;
            }

            return testResult;
        }

        public HisCentralTestResult runServicesByBox()
        {

            HisCentralTestResult testResult = new HisCentralTestResult { Working = false, 
                ServiceName = ServiceName,
                 MethodName = "ServicesByBox"
            };
   
            try
            {

                var result = svc.GetServicesInBox(texas);
                if (result.Length > 0)
                {


                    testResult.Working = true;
                }
            }
            catch (Exception ex)
            {
                testResult.Working = false;
            }

            return testResult;
        }

        public HisCentralTestResult runSeriesCatalogByBox()
        {

            HisCentralTestResult testResult = new HisCentralTestResult
            
            {
                Working = false,
                ServiceName = ServiceName,
                MethodName = "SeriesCatalogByBox"
            };
            try
            {
                int[] networks = new int[0];
                string DateFormatString = "yyyy-MM-dd";
                svc.Timeout = 3*60000;
                var result = svc.getSeriesCatalogInBoxPaged(chesapeak.xmin, chesapeak.xmax, chesapeak.ymin, chesapeak.ymax,
                   nitrogen, "", start.ToString(DateFormatString), end.ToString(DateFormatString), 1);
                if (result.Length > 0)
                {


                    testResult.Working = true;
                }
            }
            catch (Exception ex)
            {
                testResult.Working = false;
            }

            return testResult;
        }

        public HisCentralTestResult runSearchableConcepts()
        {
            HisCentralTestResult testResult = new HisCentralTestResult

            {
                Working = false,
                ServiceName = ServiceName,
                MethodName = "SearchableConcepts"
            };
            try
            {
                svc.Timeout = 3 * 60000;
                var result = svc.GetSearchableConcepts();
                {


                    testResult.Working = true;
                }
            }
            catch (Exception ex)
            {
                testResult.Working = false;
            }

            return testResult;
        }
        public HisCentralTestResult runGetMappedVariablesNitrogen()
        {
            HisCentralTestResult testResult = new HisCentralTestResult

            {
                Working = false,
                ServiceName = ServiceName,
                MethodName = "GetMappedVariables"
            };
            try
            {



                svc.Timeout = 3*60000;
                var result = svc.GetMappedVariables(
                    new string[] { nitrogen},
                    new string[] {}
                    );
                {


                    testResult.Working = true;
                }
            }
            catch (Exception ex)
            {
                testResult.Working = false;
            }

            return testResult;
        }
    }
}
