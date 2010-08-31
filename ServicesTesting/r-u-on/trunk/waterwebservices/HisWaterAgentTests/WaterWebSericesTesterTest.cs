using System.Collections.Generic;
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

          [TestCase("test1", true,"http://example", "NWIS:10263500", "NWIS:00060", "2010-01-01/2010-01-31")]
          [TestCase("test2", false, "http://river.sdsc.edu/wateroneflow/NWIS/UnitValues.asmx", "NWIS:00000", "NWIS:00065", "P1D")]
          [TestCase("test3", true, "http://river.sdsc.edu/wateroneflow/NWIS/UnitValues.asmx", "NWIS:00000", "NWIS:00065", "1D")]
        public void WofServer(string serviceName, bool enabled,string serverEndpointurlServerUrl,  string siteCode, string variableCode, string date)
        {
            var wof = new WofServer();
            wof.Name = serviceName;
            wof.Enabled = enabled;
            wof.Endpoint = serverEndpointurlServerUrl;
            wof.SiteCode = siteCode;
            wof.VariableCode = variableCode;
            wof.ISOTimeInterval = date;

            Assert.That(wof.Name == serviceName);
            Assert.That(wof.Enabled== enabled);
            Assert.That( wof.Endpoint == serverEndpointurlServerUrl);
            Assert.That(wof.SiteCode == siteCode);
            Assert.That(wof.VariableCode == variableCode);
            Assert.That(wof.ISOTimeInterval == date);
        }


          [TestCase("test1", true, "http://example", "NWIS:10263500", "NWIS:00060", "2010-01-01/2010-01-31")]
          [TestCase("test2", false, "http://river.sdsc.edu/wateroneflow/NWIS/UnitValues.asmx", "NWIS:00000", "NWIS:00065", "P1D")]
          [TestCase("test3", true, "http://river.sdsc.edu/wateroneflow/NWIS/UnitValues.asmx", "NWIS:00000", "NWIS:00065", "P1D")]
 
            public void ServerList(string serviceName, bool enabled, string serverEndpointurlServerUrl, string siteCode, string variableCode, string date)
            {
              
              var servers = new ServerList();
              servers.Add(new WofServer
              {
                  Name = serviceName,
                  Enabled = enabled,
                  Endpoint = serverEndpointurlServerUrl,
                  SiteCode = siteCode,
                  VariableCode = variableCode,
                  ISOTimeInterval = date
              });
             var  asResource = servers.AsAgentResource();

                Assert.That(asResource[0][0] == servers[0].Name, "failed agentres name" + serviceName);
                Assert.That(Boolean.Parse(asResource[0][1]) == servers[0].Enabled, "failed agentres enabled" + serviceName);
                Assert.That(asResource[0][2] == servers[0].Endpoint, "failed agentres endpoint" + serviceName);
                Assert.That(asResource[0][3] == servers[0].SiteCode, "failed agentres site" + serviceName);
                Assert.That(asResource[0][4] == servers[0].VariableCode, "failed agentres variable" + serviceName);
                Assert.That(asResource[0][5] == servers[0].ISOTimeInterval, "failed agentres datetime" + serviceName);

               var asResoruceDict = servers.AsResource();

               Assert.That(asResoruceDict[0][WaterWebServicesAgent.SERVERNAME ]== servers[0].Name, "failed dict name" + serviceName);
               Assert.That(Boolean.Parse(asResoruceDict[0][WaterWebServicesAgent.SERVERENABLED]) == servers[0].Enabled, "failed dict enabled" + serviceName);
               Assert.That(asResoruceDict[0][WaterWebServicesAgent.ENDPOINT] == servers[0].Endpoint, "failed dict endpoint" + serviceName);
               Assert.That(asResoruceDict[0][WaterWebServicesAgent.SITECODE] == servers[0].SiteCode, "failed dict site" + serviceName);
               Assert.That(asResoruceDict[0][WaterWebServicesAgent.VARIABLECODE] == servers[0].VariableCode, "failed dict variable" + serviceName);
               Assert.That(asResoruceDict[0][WaterWebServicesAgent.ISOTIMEPERIOD] == servers[0].ISOTimeInterval, "failed dict datetime" + serviceName);

               var listToServers = new ServerList(asResoruceDict);

               Assert.That(listToServers[0].Name == servers[0].Name, "failed dict name" + serviceName);
               Assert.That(listToServers[0].Enabled == servers[0].Enabled, "failed dict enabled" + serviceName);
               Assert.That(listToServers[0].Endpoint == servers[0].Endpoint, "failed dict endpoint" + serviceName);
               Assert.That(listToServers[0].SiteCode == servers[0].SiteCode, "failed dict site" + serviceName);
               Assert.That(listToServers[0].VariableCode == servers[0].VariableCode, "failed dict variable" + serviceName);
               Assert.That(listToServers[0].ISOTimeInterval == servers[0].ISOTimeInterval, "failed dict datetime" + serviceName);


            }
    }
}
