using System.Collections.Generic;
using cuahsi.wof.ruon;

using System;
using NUnit.Framework;
using Ruon;

namespace HisAgentTests
{
    
    
    /// <summary>
    ///This is a test class for IsoTimePeriodTest and is intended
    ///to contain all IsoTimePeriodTest Unit Tests
    ///</summary>
    [TestFixture()]
    public class AgentParmsTest
    {


     

        /// <summary>
        ///A test for TimeSpan
        ///</summary>
        
       [TestCase("test1", true, "http://example", "NWIS:10263500", "NWIS:00060", "2010-01-01/2010-01-31")]
          [TestCase("test2", false, "http://river.sdsc.edu/wateroneflow/NWIS/UnitValues.asmx", "NWIS:00000", "NWIS:00065", "P1D")]
          [TestCase("test3", true, "http://river.sdsc.edu/wateroneflow/NWIS/UnitValues.asmx", "NWIS:00000", "NWIS:00065", "P1D")]
 [Ignore]
            public void ServerList(string serviceName, bool enabled, string serverEndpointurlServerUrl, string siteCode, string variableCode, string date)
           {

         List<Dictionary<string, string>> managedResources   = new  List<Dictionary<string, string>>();

            string a = "BooleanVariable";
            string b = "true";
            var dict = new Dictionary<string, string>();
           dict.Add(a,b);
           managedResources.Add( dict);
       AgentParams p = new AgentParams();
      // p.Resources = managedResources.ToArray();

           }

        
    }
}
