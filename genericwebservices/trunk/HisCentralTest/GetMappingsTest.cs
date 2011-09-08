using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using HisCentral;
using NUnit;
using NUnit.Framework;

namespace HisCentralTest
{

    

  [TestFixture()]  
    public class GetMappingsTest
    {
      // private HisCentral.GetMappings hisCentral;
      
      [SetUp]
      public void SetUp()
      {
        //  hisCentral = new HisCentral.GetMappings();
      }

    [TestCase(1, "Hydrosphere")]
   [TestCase(9, "Snow depth")]
    [TestCase(14, "Water depth, cross-sectional averaged")]
     [TestCase(4908, "Actinomycetes")]
    [TestCase(5039, "Pigment")]
    [TestCase(1222, "PCB_Mixtures")]
     [TestCase(2392, "Nitrogen, total organic")]
      public void OntologyListHisCentral(int i, string result)
      {
        while (GetMappings.Loaded == false)
        {
            Thread.Sleep(100);
        }
          var ontoList = GetMappings.OntologyList;

          Assert.AreEqual(ontoList[i],result);
      }

    [TestCase("LittleBearRiver:USU58", "Soil Moisture")]
     [TestCase("LittleBearRiver:USU50", "Snow depth")]
    [TestCase("EPA:515-1", "Turbidity")]
     [TestCase("CIMS:TON", "Nitrogen, total organic")]
    [TestCase("NWS-WGRFC:MPE", "Precipitation")]
     [TestCase("NWS-WGRFC:MPE", "Precipitation")]
     public void VariabletHisCentral(string i, string result)
     {

         var conceptForVariable = GetMappings.GetConceptForVariable(i);

         Assert.AreEqual(conceptForVariable,result);
     }

    [TestCase("Unknown:MPE")]
    public void VariabletHisCentralNotFound(string i)
    {

        var conceptForVariable = GetMappings.GetConceptForVariable(i);

        Assert.IsNull(conceptForVariable);
    }
    }
}
