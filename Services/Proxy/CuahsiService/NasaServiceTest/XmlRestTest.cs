using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using cuahsi.his.WaterService.Rest;
using cuahsi.his.WaterService.Utilities;
using NUnit.Framework;

namespace NasaServiceTest
{
    [TestFixture]
    
    public class GetXmlFromRestTest
     {
         [TestCase("http://hydro1.sci.gsfc.nasa.gov/daac-bin/cuahsi/his.cgi?function=GetVaules&variable=NLDAS:NLDAS_FORA0125_H.002:apcpsfc&location=GEOM:POINT%28-86.188%2035.063%29&startDate=1980-01-03T11&endDate=1980-01-04T11")]
        [TestCase("http://hydro1.sci.gsfc.nasa.gov/daac-bin/cuahsi/his.cgi?function=GetVaules&variable=NLDAS:NLDAS_FORA0125_H.002:apcpsfc&location=NLDAS:X310-Y80&startDate=1980-01-03T11&endDate=1980-01-04T11")]
        public void TimeSeriesResponse(string url)
         {
            CompiledXslt compiledXslt = new CompiledXslt("passthrough_timeSeriesResponse.xslt");
            var svc = new GetXmlFromRest(compiledXslt);

          var reader=   svc.GetXmlReader(url);

            while (reader.Read())
            {
                
            }
         }

         [TestCase("http://hydro1.sci.gsfc.nasa.gov/daac-bin/cuahsi/his.cgi?function=GetSiteInfo&location=NLDAS:X310-Y80")]
         public void SitesResponse(string url)
        {
            CompiledXslt compiledXslt = new CompiledXslt("passthrough_sitesResponse.xslt");
            var svc = new GetXmlFromRest(compiledXslt);

            var reader = svc.GetXmlReader(url);

            while (reader.Read())
            {

            }
        }
      }
}
