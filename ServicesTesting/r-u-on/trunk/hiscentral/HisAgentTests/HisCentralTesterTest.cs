using Cuahsi.His.Ruon;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HisAgentTests
{
    
    
    /// <summary>
    ///This is a test class for HisCentralTesterTest and is intended
    ///to contain all HisCentralTesterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class HisCentralTesterTest
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
        ///A test for runSeriesCatalogByBox
        ///</summary>
        [TestMethod()]
        public void runSeriesCatalogByBoxTest()
        {
            HisCentralTester target = new HisCentralTester(); // TODO: Initialize to an appropriate value
            //HisCentralTestResult expected = null; // TODO: Initialize to an appropriate value
            HisCentralTestResult actual;
            actual = target.runSeriesCatalogByBox("test");
            Assert.IsTrue( actual != null);
          //  Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for runQueryServiceList
        ///</summary>
        [TestMethod()]
        public void runQueryServiceListTest()
        {
            HisCentralTester target = new HisCentralTester(); // TODO: Initialize to an appropriate value
            //HisCentralTestResult expected = null; // TODO: Initialize to an appropriate value
            HisCentralTestResult actual;
            actual = target.runQueryServiceList("test");
            Assert.IsTrue(actual != null);
        }

        /// <summary>
        ///A test for runServicesByBox
        ///</summary>
        [TestMethod()]
        public void runServicesByBoxTest()
        {
            HisCentralTester target = new HisCentralTester(); // TODO: Initialize to an appropriate value
            //HisCentralTestResult expected = null; // TODO: Initialize to an appropriate value
            HisCentralTestResult actual;
            actual = target.runServicesByBox("test");
            Assert.IsTrue(actual != null);
        }

        /// <summary>
        ///A test for Endpoint
        ///</summary>
        [TestMethod()]
        public void EndpointTest()
        {
            HisCentralTester target = new HisCentralTester(); // TODO: Initialize to an appropriate value
            string expected = "http://www.example.com/"; // TODO: Initialize to an appropriate value
            string actual;
            target.Endpoint = expected;
            actual = target.Endpoint;
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for ServiceName
        ///</summary>
        [TestMethod()]
        public void ServiceNameTest()
        {
            HisCentralTester target = new HisCentralTester(); // TODO: Initialize to an appropriate value
            string expected = "testTest"; // TODO: Initialize to an appropriate value
            string actual;
            target.ServiceName = expected;
            actual = target.ServiceName;
            Assert.AreEqual(expected, actual);
           // Assert.Inconclusive("Verify the correctness of this test method.");
        }

       
    }
}
