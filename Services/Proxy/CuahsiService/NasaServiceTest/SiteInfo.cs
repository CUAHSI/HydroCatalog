using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using cuahsi.his.schema;

using cuahsi.his.WaterService;
using cuahsi.his.WaterService.Parameters;
using cuahsi.his.WaterService.Rest.v1_0;
using cuahsi.his.WaterService.Service.v1_0.Passthrough;
using cuahsi.his.WaterService.Utilities;
using NUnit.Framework;

namespace NasaServiceTest
{    
    using cuahsi.his.schema.waterml.v1;

    [TestFixture]
    public class SiteInfo
    {
     

        private XmlReaderSettings settings;
        private XmlSchemaSet sc; 

        private System.Collections.Generic.List<String> ValidationErrors = new System.Collections.Generic.List<String>();
        private XmlSerializer serializer; 
        
        [TestFixtureSetUp]
        public void setup()
        {
            XmlSchemaSet sc = new XmlSchemaSet();
            sc.Add(GetSchema.SchemaV1_0());
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas = sc;
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);

            serializer = new XmlSerializer(typeof(SiteInfoResponseType));
            serializer = new XmlSerializer(typeof(SiteInfoResponseString));
        }

        // Display any validation errors.
        private  void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            ValidationErrors.Add( e.Message);
        }

        [TestCase("/passthrough_sitesResponse.xslt"
            , "http://hydro1.sci.gsfc.nasa.gov/daac-bin/cuahsi/his.cgi?function=GetSiteInfo&location={0}&product=TRMM_3B42RT.006",
           "NLDAS:X310-Y80")]
        [TestCase("/passthrough_sitesResponse.xslt"
          , "http://hydro1.sci.gsfc.nasa.gov/daac-bin/cuahsi/his.cgi?function=GetSiteInfo&location={0}&product=TRMM_3B42RT.006",
         "GLDAS:X300-Y100")]
        [TestCase("/passthrough_sitesResponse.xslt"
           , "http://hydro1.sci.gsfc.nasa.gov/daac-bin/cuahsi/his.cgi?function=GetSiteInfo&location={0}&product=TRMM_3B42RT.006",
          "TRMM:X310-Y80")]

        public void GetSiteInfo(string xslt, string RestUrl,
            string location)
        {
            var lParam = new locationParam(location);
           
            var svc = new SitesREST_xslt(RestUrl, xslt);

         var result =  (SiteInfoResponseString) svc.GetSites(lParam);

       
        }

        [TestCase("/passthrough_sitesResponse.xslt"
        , "http://hydro1.sci.gsfc.nasa.gov/daac-bin/cuahsi/his.cgi?function=GetSites&product=NLDAS_MOS0125_H.002",
       "")]
        [TestCase("/passthrough_sitesResponse.xslt"
          , "http://hydro1.sci.gsfc.nasa.gov/daac-bin/cuahsi/his.cgi?function=GetSites&product=GLDAS_NOAH025_3H.001",
         "")]
        [TestCase("/passthrough_sitesResponse.xslt"
           , "http://hydro1.sci.gsfc.nasa.gov/daac-bin/cuahsi/his.cgi?function=GetSites&product=TRMM_3B42RT.006",
          "")]

        public void GetSites(string xslt, string RestUrl,
            string location)
        {
            var lParam = new locationParam(location);

            var svc = new SitesREST_xslt(RestUrl, xslt);

            var result = (SiteInfoResponseString)svc.GetSites(lParam);


        }
    }
}