using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using cuahsi.his.WaterService.Rest;
using cuahsi.his.WaterService.Utilities;
using NUnit.Framework;

namespace NasaServiceTest
{
    class CompiledXsltTest
    {
             [TestCase("passthrough_timeSeriesResponse.xslt")]
          [TestCase("passthrough_sitesResponse.xslt")]


            public void TestCreation(string xslt )
            {
                CompiledXslt compiledXslt = new CompiledXslt(xslt);
                 Assert.NotNull(compiledXslt);
                 Assert.AreEqual(compiledXslt.Filename, xslt);
             
            }

           [TestCase("passthrough_timeSeriesResponse.xslt", "examples/values/values_ndlas_apcdsfc.xml")]
            public void TestTransform(string xslt,string url )
            {
                CompiledXslt compiledXslt = new CompiledXslt(xslt);
                Assert.NotNull(compiledXslt);
                Assert.AreEqual(compiledXslt.Filename, xslt);

               var reader = XmlReader.Create(url);

                
                MemoryStream memoryStream = new MemoryStream();
                    XmlWriter writer = XmlWriter.Create(memoryStream);
                    compiledXslt.Transform(reader, writer);
                    memoryStream.Position = 0;
                    reader = XmlReader.Create(memoryStream);

            }

       
        } 
    
}
