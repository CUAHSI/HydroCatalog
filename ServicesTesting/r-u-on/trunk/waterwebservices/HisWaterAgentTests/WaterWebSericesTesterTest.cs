using cuahsi.wof.ruon;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HisAgentTests
{
    
    
    /// <summary>
    ///This is a test class for WaterWebSericesTesterTest and is intended
    ///to contain all WaterWebSericesTesterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class WaterWebSericesTesterTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetSites
        ///</summary>
        [TestMethod()]
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
        [TestMethod()]
        [Ignore]
        public void WaterWebSericesTesterConstructorTest()
        {
            WaterWebSericesTester target = new WaterWebSericesTester();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Endpoint
        ///</summary>
        [TestMethod()]
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
        [TestMethod()]
        public void ServiceNameTest()
        {
            WaterWebSericesTester target = new WaterWebSericesTester(); // TODO: Initialize to an appropriate value
            string expected = "Example";
            string actual;
            actual = target.ServiceName;
            target.ServiceName = expected;
            actual = target.Endpoint;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for RunTests
        ///</summary>
        [TestMethod()]
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
