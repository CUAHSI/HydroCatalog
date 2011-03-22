using System;
using System.Collections.Generic;

using System.Text;
using HisCentralHarvester2;

using NUnit.Framework;

namespace HisCentralHarvestTest
{
  namespace waterml_10
  {
      
  using waterml = HisCentralHarvester2.waterml_10; 
    [TestFixture]
    public class TestWof10
    {
         

        public waterml.WaterOneFlow setup(string url)
        {
            waterml.WaterOneFlow  wof = new waterml.WaterOneFlow();
            wof.Url = url;
            return wof;
        }
        [TestCase("http://localhost:3987/v1_0/cuahsi_1_0.asmx")]
        [TestCase("http://icewater.usu.edu/littlebearriver/cuahsi_1_0.asmx")]
        public void Sites(string url)
        {
            waterml.WaterOneFlow wof = setup(url);

            waterml.SiteInfoResponseType sitesResp = wof.GetSites(new string[]{}, "");
            //waterml_10.SiteInfoResponseTypeSite[] sites = sitesResp.site;
            waterml.site[] sites = sitesResp.site;
            Assert.IsNotNull(sites);
        }

        [TestCase("http://localhost:3987/v1_0/cuahsi_1_0.asmx","NLDAS:X310-Y80")]
        [TestCase("http://icewater.usu.edu/littlebearriver/cuahsi_1_0.asmx", "LittleBearRiver:USU-LBR-ExpFarm")]
       public void SiteSiteInfo(string url, string sitecode)
       {
              waterml.WaterOneFlow wof = setup(url);
              waterml.SiteInfoResponseType siteinforesp = wof.GetSiteInfoObject(sitecode, "");
              
            Assert.IsNotNull(siteinforesp);
       }
    }
    }
  namespace waterml_10_old
  {

      using waterml = HisCentralHarvester2.waterml_10;
      [TestFixture]
      public class TestWof10
      {


          public waterml.WaterOneFlow setup(string url)
          {
              waterml.WaterOneFlow wof = new waterml.WaterOneFlow();
              wof.Url = url;
              return wof;
          }
          [TestCase("http://localhost:3987/v1_0/cuahsi_1_0.asmx")]
          [TestCase("http://icewater.usu.edu/littlebearriver/cuahsi_1_0.asmx")]
          public void Sites(string url)
          {
              waterml.WaterOneFlow wof = setup(url);

              waterml.SiteInfoResponseType sitesResp = wof.GetSites(new string[] { }, "");
              //waterml_10.SiteInfoResponseTypeSite[] sites = sitesResp.site;
              waterml.site[] sites = sitesResp.site;

              Assert.IsNotNull(sites);
          }

          [TestCase("http://localhost:3987/v1_0/cuahsi_1_0.asmx", "NLDAS:X310-Y80")]
          [TestCase("http://icewater.usu.edu/littlebearriver/cuahsi_1_0.asmx", "LittleBearRiver:USU-LBR-ExpFarm")]
          public void SiteSiteInfo(string url, string sitecode)
          {
              waterml.WaterOneFlow wof = setup(url);
              waterml.SiteInfoResponseType siteinforesp = wof.GetSiteInfoObject(sitecode, "");

              Assert.IsNotNull( siteinforesp  );
          }
      }
  }

   [TestFixture]
    class HisHarvestTest
    {
       public void SiteSiteInfo(string url, string sitecode, string org)
       {
           
       }
    }
}

