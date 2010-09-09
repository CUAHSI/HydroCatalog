using Cuahsi.His.Ruon;

using System;
using NUnit.Framework;
using NUnit.Mocks;
using Ruon;

namespace HisAgentTests
{
    
    
    /// <summary>
    ///This is a test class for HisCentralTesterTest and is intended
    ///to contain all HisCentralTesterTest Unit Tests
    ///</summary>
    [TestFixture()]
    public class HisAgentTest
    {
        #region Fake Results
        IHisCentralTestResult good = new HisCentralTestResult
                                         {
                                             MethodName = "Dummy",Working = true,ServiceName ="MockService"
                                             , runTimeMilliseconds = 1
                                         };
        IHisCentralTestResult bad = new HisCentralTestResult
        {
            MethodName = "Dummy",
            Working = false,
            ServiceName = "MockService",
            runTimeMilliseconds = 1
        };
        IHisCentralTestResult LongRun = new HisCentralTestResult
        {
            MethodName = "Dummy",
            Working = false,
            ServiceName = "MockService",
            runTimeMilliseconds = 60000,
            errorString = "Mock Service Error Message"
        };
        #endregion

        private HisCentralServerList servers;
        private HisCentralServerList oneServer;

        [SetUp]
        public void setup()
        {
            servers = new HisCentralServerList();
            servers.Add(new HisCentralServer { Name = "MockServers1", Endpoint = "http://hiscentral.cuahsi.org/webservices/hiscentral.asmx" });
            servers.Add(new HisCentralServer { Name = "MockServers2", Endpoint = "http://hiscentral.cuahsi.org/webservices/hiscentral.asmx" });

            oneServer = new HisCentralServerList();
            oneServer.Add(new HisCentralServer { Name = "OneServer", Endpoint = "http://hiscentral.cuahsi.org/webservices/hiscentral.asmx" });
 
        }
        #region Alarm Predicates
        // This method implements the test condition for the Find
        // method.
        private static bool AlarmIsCritial(IAlarm p)
        {
            if ( p.ToString().StartsWith("<alarm") && p.ToString().Contains("severity=\"C\"")
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // This method implements the test condition for the Find
        // method.
        private static bool AlarmIsMajor(IAlarm p)
        {
            if ( p.ToString().StartsWith("<alarm") && p.ToString().Contains("severity=\"M\"")
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // This method implements the test condition for the Find
        // method.
        private static bool AlarmIsClear(IAlarm p)
        {
            if (p.ToString().StartsWith("<clear")
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // This method implements the test condition for the Find
        // method.
        private static bool AlarmIsServiceError(IAlarm p)
        {
            if (p.ToString().StartsWith("<alarm") && p.ToString().Contains("id=\"ServiceError\"")
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

             // This method implements the test condition for the Find
        // method.
        private static bool AlarmIsCriticalServiceError(IAlarm p)
        {
            if (p.ToString().StartsWith("<event") && p.ToString().Contains("id=\"CriticalServiceError\"")
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
                  // This method implements the test condition for the Find
        // method.
        private static bool AlarmIsServiceAllFailed(IAlarm p)
        {
            if (p.ToString().StartsWith("<alarm") && p.ToString().Contains("id=\"ServiceAllFailed\"")
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        /// <summary>
        ///A test for all working
        ///</summary>
        [Test()]
        public void TestAgentUningMock_allWorking()
        {

            DynamicMock mockHisCentral = new DynamicMock(typeof(IHisCentralTester));
            mockHisCentral.Expect("Endpoint", "http://hiscentral.cuahsi.org/webservices/hiscentral.asmx");
            mockHisCentral.ExpectAndReturn("runQueryServiceList", good, "OneServer");
            mockHisCentral.ExpectAndReturn("runServicesByBox", good, "OneServer");
            mockHisCentral.ExpectAndReturn("runSeriesCatalogByBox", good, "OneServer");
            mockHisCentral.ExpectAndReturn("runSearchableConcepts", good, "OneServer");
            mockHisCentral.ExpectAndReturn("runGetWordListNitrogen", good, "OneServer");

           HISCentralAgent target = new HISCentralAgent(null);
            target.MonitorIntervalSec = -1; 
           target.Tester = (IHisCentralTester) mockHisCentral.MockInstance;
            // TODO: Initialize to an appropriate value
            //HisCentralTestResult expected = null; // TODO: Initialize to an appropriate value
            HisCentralTestResult actual;
            var alarms = target.Monitor(oneServer.AsResource());
            Assert.IsFalse(alarms.Exists(AlarmIsCriticalServiceError)); 
            Assert.IsFalse(alarms.Exists(AlarmIsServiceError)); 

            Assert.IsFalse(alarms.Exists(AlarmIsServiceAllFailed));
            IAlarm criticalAlarm = alarms.Find( AlarmIsCritial);
             Assert.IsNull(criticalAlarm);
            //  Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for all failing. Should return a ServiceAllFailed alarm
        ///</summary>
        [Test()]

        public void TestAgentUningMock_allFailing()
        {

            DynamicMock mockHisCentral = new DynamicMock(typeof(IHisCentralTester));
            mockHisCentral.Expect("Endpoint","http://hiscentral.cuahsi.org/webservices/hiscentral.asmx");
            mockHisCentral.ExpectAndReturn("runQueryServiceList", bad, "OneServer");
            mockHisCentral.ExpectAndReturn("runServicesByBox", bad, "OneServer");
            mockHisCentral.ExpectAndReturn("runSeriesCatalogByBox", bad, "OneServer");
            mockHisCentral.ExpectAndReturn("runSearchableConcepts", bad, "OneServer");
            mockHisCentral.ExpectAndReturn("runGetWordListNitrogen", bad, "OneServer");

            HISCentralAgent target = new HISCentralAgent(null);
            target.MonitorIntervalSec = -1;
            target.Tester = (IHisCentralTester)mockHisCentral.MockInstance;
            // TODO: Initialize to an appropriate value
            //HisCentralTestResult expected = null; // TODO: Initialize to an appropriate value
            HisCentralTestResult actual;
            var alarms = target.Monitor(oneServer.AsResource());
            Assert.IsFalse(alarms.Exists(AlarmIsCriticalServiceError)); 
            Assert.IsFalse(alarms.Exists(AlarmIsServiceError)); 

            Assert.IsTrue(alarms.Exists(AlarmIsServiceAllFailed));
            System.Collections.Generic.List<IAlarm> criticalAlarm = alarms.FindAll(AlarmIsCritial);
            Assert.That(criticalAlarm.Count ==1); // the service error is one
            
        }

        /// <summary>
        /// Test one failing. Should not return a critical Alarm
        /// </summary>
        [Test()]
        public void TestAgentUningMock_PartialFail()
        {

            DynamicMock mockHisCentral = new DynamicMock(typeof(IHisCentralTester));
            mockHisCentral.Expect("Endpoint", "http://hiscentral.cuahsi.org/webservices/hiscentral.asmx");
            mockHisCentral.ExpectAndReturn("runQueryServiceList", bad, "OneServer");
            mockHisCentral.ExpectAndReturn("runServicesByBox", good, "OneServer");
            mockHisCentral.ExpectAndReturn("runSeriesCatalogByBox", good, "OneServer");
            mockHisCentral.ExpectAndReturn("runSearchableConcepts", good, "OneServer");
            mockHisCentral.ExpectAndReturn("runGetWordListNitrogen", good, "OneServer");

            HISCentralAgent target = new HISCentralAgent(null);
            target.MonitorIntervalSec = -1;
            target.Tester = (IHisCentralTester)mockHisCentral.MockInstance;
            // TODO: Initialize to an appropriate value
            //HisCentralTestResult expected = null; // TODO: Initialize to an appropriate value
            HisCentralTestResult actual;
            var alarms = target.Monitor(oneServer.AsResource());
            Assert.IsFalse(alarms.Exists(AlarmIsCriticalServiceError));
            Assert.IsFalse(alarms.Exists(AlarmIsServiceError)); // all checks fail

            Assert.IsFalse(alarms.Exists(AlarmIsServiceAllFailed));
            System.Collections.Generic.List<IAlarm> criticalAlarm = alarms.FindAll(AlarmIsCritial);
            Assert.That(criticalAlarm.Count == 0); // the service error is one

            Assert.That(alarms.FindAll(AlarmIsMajor).Count == 1); // one bad
        }

       
    }
}
