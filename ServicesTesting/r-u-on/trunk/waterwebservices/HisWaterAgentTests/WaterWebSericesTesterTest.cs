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
          [Test()]
        public void RunTestsTest()
        {
            WaterWebSericesTester target = new WaterWebSericesTester(); // TODO: Initialize to an appropriate value
            string ws_SiteCode = "NWIS:10263500"; 
            string ws_variableCode = "NWIS:00060"; 
            string ISOTimPeriod = string.Empty; // TODO: Initialize to an appropriate value
           // TestResult expected = null; // TODO: Initialize to an appropriate value
            TestResult actual;
            actual = target.RunTests("TestServer",ws_SiteCode, ws_variableCode, ISOTimPeriod);

            Assert.IsTrue(actual.Working);
          //  Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
