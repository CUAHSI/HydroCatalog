using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Services.Description;
using NUnit.Framework;
using HisServiceTypes;

namespace HisAgentTests
{
   [TestFixture]
    public class ServiceUtilityTest
    {
       [TestCase("ExampleWsdl/cuahsi_1_0.asmx.xml", ServiceTypeEnum.WOF_1_0)]
       [TestCase("ExampleWsdl/cuahsi_1_1.asmx.xml", ServiceTypeEnum.WOF_1_1)]
       [TestCase("ExampleWsdl/cuahsi_1_1_badEndpoint.xml", ServiceTypeEnum.WOF_1_1_badNamespace)]
       public void ServiceTypeTest(string file, ServiceTypeEnum serviceType)
       {
           var actualType = WsdlUtilities.ServiceTypeFromWsdlFile(file);

           Assert.AreEqual(serviceType,actualType, file);

       }

       [TestCase("http://river.sdsc.edu/wateroneflow/NWIS/DailyValues.asmx?WSDL", ServiceTypeEnum.WOF_1_0)]
       [TestCase("http://ees-his06.ad.ufl.edu/SFe_SRWMD_SurfWater/cuahsi_1_0.asmx?WSDL", ServiceTypeEnum.WOF_1_0)]
       [TestCase("http://192.31.21.100/czo_udel/cuahsi_1_0.asmx?WSDL", ServiceTypeEnum.WOF_1_0)]
       [TestCase("http://icewater.usu.edu/MudLake/cuahsi_1_0.asmx?WSDL", ServiceTypeEnum.WOF_1_0)]
       
       [TestCase("http://hydro10.sdsc.edu/LBRSDSC/Cuahsi_1_1.asmx?WSDL", ServiceTypeEnum.WOF_1_1)]
       [TestCase("http://his09.umbc.edu/BaltPrecip/cuahsi_1_1.asmx?WSDL", ServiceTypeEnum.WOF_1_1_badNamespace)]
       [TestCase("http://cbe.cae.drexel.edu/NADP/cuahsi_1_1.asmx?WSDL", ServiceTypeEnum.WOF_1_1_badNamespace)]
       [TestCase("http://watershed.uta.edu/nws_wgrfc_daily_mpe_recent_values/cuahsi_1_1.asmx?WSDL", ServiceTypeEnum.WOF_1_1)]
       
       public void ServiceTypeUrlTest(string url, ServiceTypeEnum serviceType)
       {
           var actualType = WsdlUtilities.ServiceTypeFromWsdlUrl(url);

           Assert.AreEqual(serviceType, actualType, url);

       }

       [TestCase("ExampleWsdl/cuahsi_1_1_badEndpoint.xml", ServiceTypeEnum.WOF_1_1_badNamespace)]
       [TestCase("ExampleWsdl/cuahsi_1_1_badEndpoint2.xml", ServiceTypeEnum.WOF_1_1_badNamespace)]
       [TestCase("ExampleWsdl/cuahsi_1_0.asmx.xml", ServiceTypeEnum.WOF_1_0)]
       public void TestWof1_0_returnWml11(string file, ServiceTypeEnum serviceType)
       {
           var myServiceDescription =
            ServiceDescription.Read(file);

           var actualType = WsdlUtilities.CheckForWrongNamespaceWof1_1(myServiceDescription);

           Assert.AreEqual(serviceType, actualType, file);


       }
    }
}
