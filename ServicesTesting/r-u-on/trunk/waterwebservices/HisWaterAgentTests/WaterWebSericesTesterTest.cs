using cuahsi.wof.ruon;

using System;
using NUnit.Framework;

namespace HisAgentTests
{
    
    
    /// <summary>
    ///This is a test class for WaterWebSericesTesterTest and is intended
    ///to contain all WaterWebSericesTesterTest Unit Tests
    ///</summary>
    [TestFixture()]
    public class WaterWebSericesTesterTest
    {


      


        /// <summary>
        ///A test for GetSites
        ///</summary>
         [Test()]
        public void GetSitesTest()
        {
            WaterWebSericesTester target = new WaterWebSericesTester(); // TODO: Initialize to an appropriate value
           // TestResult expected = null; // TODO: Initialize to an appropriate value
            TestResult actual;
            actual = target.GetSites("Test Server");
            Assert.IsTrue(actual.Working);
           // Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for WaterWebSericesTester Constructor
        ///</summary>
          [Test()]
        [Ignore]
        public void WaterWebSericesTesterConstructorTest()
        {
            WaterWebSericesTester target = new WaterWebSericesTester();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Endpoint
        ///</summary>
        [Test()]
        public void EndpointTest()
        {
            WaterWebSericesTester target = new WaterWebSericesTester(); // TODO: Initialize to an appropriate value
            string expected = "http://www.example.com/"; // TODO: Initialize to an appropriate value
            string actual;
            target.Endpoint = expected;
            actual = target.Endpoint;
            Assert.AreEqual(expected, actual);
           // Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ServiceName
        ///</summary>
         [Test()]
        public void ServiceNameTest()
        {
            WaterWebSericesTester target = new WaterWebSericesTester(); // TODO: Initialize to an appropriate value
            string expected = "Example";
            target.ServiceName = expected;
            string actual;
            actual = target.ServiceName;
            Assert.AreEqual(expected, actual, "Setting Service Name Failed");

           
        }

        /// <summary>
        ///A test for RunTests
        ///</summary>
          [TestCase("http://river.sdsc.edu/wateroneflow/NWIS/DailyValues.asmx","NWIS:10263500", "NWIS:00060", "2010-01-01/2010-01-31")]
          [TestCase("http://river.sdsc.edu/wateroneflow/NWIS/UnitValues.asmx", "NWIS:10109000", "NWIS:00065", "P1D")]

         public void RunTestsTest(string endpoint, string ws_SiteCode, string ws_variableCode, string ISOTimPeriod)
        {
            WaterWebSericesTester target = new WaterWebSericesTester(); // TODO: Initialize to an appropriate value
            target.Endpoint = endpoint;
           // TestResult expected = null; // TODO: Initialize to an appropriate value
            TestResult actual;
            actual = target.RunTests("TestServer",ws_SiteCode, ws_variableCode, ISOTimPeriod);

            Assert.IsTrue(actual.Working);
          //  Assert.Inconclusive("Verify the correctness of this test method.");
        }

          /// <summary>
          ///A test for RunTests
          ///</summary>
          [TestCase("http://example", "NWIS:10263500", "NWIS:00060", "2010-01-01/2010-01-31")]
          [TestCase("http://river.sdsc.edu/wateroneflow/NWIS/UnitValues.asmx", "NWIS:00000", "NWIS:00065", "P1D")]
          [TestCase("http://river.sdsc.edu/wateroneflow/NWIS/UnitValues.asmx", "NWIS:00000", "NWIS:00065", "1D")]
          public void BadDataTests(string endpoint, string ws_SiteCode, string ws_variableCode, string ISOTimPeriod)
          {
              WaterWebSericesTester target = new WaterWebSericesTester(); // TODO: Initialize to an appropriate value
              target.Endpoint = endpoint;
              // TestResult expected = null; // TODO: Initialize to an appropriate value
              TestResult actual;
              actual = target.RunTests("TestServer", ws_SiteCode, ws_variableCode, ISOTimPeriod);

              Assert.IsFalse(actual.Working);
              //  Assert.Inconclusive("Verify the correctness of this test method.");
          }
    }
}
