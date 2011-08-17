using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HisCentral;
using NUnit;
using NUnit.Framework;

namespace HisCentralTest
{
    [TestFixture()]
    public class GetNetowrksTest
    {

        [TestCase("LittleBearRiver", "LittleBearRiver")]
        
        public void OntologyListHisCentral(string i, string result)
        {

            var code = GetNetworks.GetNetworkByCode(i);

            Assert.AreEqual(code.NetworkName, result);
        }
    }
}
