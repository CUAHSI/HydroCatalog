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
    public class TimeSeries
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

            serializer = new XmlSerializer(typeof(TimeSeriesResponseType));
            serializer = new XmlSerializer(typeof(TimeSeriesResponseString));
        }

        // Display any validation errors.
        private  void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            ValidationErrors.Add( e.Message);
        }

        [TestCase("/passthrough_timeSeriesResponse.xslt"
            , "http://hydro1.sci.gsfc.nasa.gov/daac-bin/cuahsi/his.cgi?function=GetVaules&variable={1}&location={0}&startDate={2}&endDate={3}",
           "GEOM:POINT(-86.188 35.063)", "NLDAS:NLDAS_FORA0125_H.002:apcpsfc",
        "1980-01-03",  "1980-01-04")]

        public void GetValue(string xslt, string  RestUrl,
            string location, string variable, string begin, string end)
        {
            var lParam = new locationParam(location);
            var vParam = new VariableParam(variable);

            var beginTime = W3CDateTime.Parse(begin);
            var endTime = W3CDateTime.Parse(end);

            var svc = new ValuesREST_xslt(RestUrl, xslt);

         var result =  (TimeSeriesResponseString) svc.GetTimeSeries(lParam, vParam, beginTime, endTime);

       
        }
    }
}