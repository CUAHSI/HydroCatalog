using Cuahsi.His.Ruon;

using System;
using NUnit.Framework;

namespace HisAgentTests
{
    
    
    /// <summary>
    ///This is a test class for HisCentralTesterTest and is intended
    ///to contain all HisCentralTesterTest Unit Tests
    ///</summary>
    [TestFixture()]
    public class HisCentralTesterTest
    {


     


        /// <summary>
        ///A test for runSeriesCatalogByBox
        ///</summary>
        [Test()]
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
          [Test()]
        public void runQueryServiceListTest()
        {
            HisCentralTester target = new HisCentralTester(); // TODO: Initialize to an appropriate value
            //HisCentralTestResult expected = null; // TODO: Initialize to an appropriate value
            HisCentralTestResult actual;
            actual = target.runQueryServiceList("test");
            Assert.IsTrue(actual != null);
            Assert.IsTrue(actual.Working);
        }

        /// <summary>
        ///A test for runServicesByBox
        ///</summary>
        [Test()]
        public void runServicesByBoxTest()
        {
            HisCentralTester target = new HisCentralTester(); // TODO: Initialize to an appropriate value
            //HisCentralTestResult expected = null; // TODO: Initialize to an appropriate value
            HisCentralTestResult actual;
            actual = target.runServicesByBox("test");
            Assert.IsTrue(actual.Working);
        }

        /// <summary>
        ///A test for Endpoint
        ///</summary>
        [Test()]
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
        ///A test for Endpoint
        ///</summary>
        [Test()]
        public void BadEndpointTest()
        {
            HisCentralTester target = new HisCentralTester(); // TODO: Initialize to an appropriate value
            string badendpoint = "http://www.example.com/"; // TODO: Initialize to an appropriate value
          
            target.Endpoint = badendpoint;
            
            
            var actual = target.runQueryServiceList("test");
            Assert.IsFalse(actual.Working);

        }

        /// <summary>
        ///A test for ServiceName
        ///</summary>
          [Test()]
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
