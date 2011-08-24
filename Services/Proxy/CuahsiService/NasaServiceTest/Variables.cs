using System;
using System.IO;
using System.Text;
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
    public class VariableInfo
    {
     

        private XmlReaderSettings settings;
        private XmlSchemaSet sc; 

        private System.Collections.Generic.List<String> ValidationErrors = new System.Collections.Generic.List<String>();
        private XmlSerializer serializer;
        private XmlSerializer serializer2; 
        
        [TestFixtureSetUp]
        public void setup()
        {
            XmlSchemaSet sc = new XmlSchemaSet();
            sc.Add(GetSchema.SchemaV1_0());
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas = sc;
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);

            serializer2 = new XmlSerializer(typeof(VariableInfoType));
            serializer = new XmlSerializer(typeof(VariablesResponseString));
        }

        // Display any validation errors.
        private  void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            ValidationErrors.Add( e.Message);
        }

        [TestCase("/passthrough_variablesResponse.xslt"
            , "http://hydro1.sci.gsfc.nasa.gov/daac-bin/cuahsi/his.cgi?function=GetVariableInfo&variable={0}",
           "TRMM:TRMM_3B42RT.006")]
        [TestCase("/passthrough_variablesResponse.xslt"
           , "http://hydro1.sci.gsfc.nasa.gov/daac-bin/cuahsi/his.cgi?function=GetVariableInfo&variable={0}",
          "")]
        [TestCase("/passthrough_variablesResponse.xslt"
          , "http://hydro1.sci.gsfc.nasa.gov/daac-bin/cuahsi/his.cgi?function=GetVariableInfo&variable={0}",
         null)]
        public void GetVariables(string xslt, string  RestUrl,
            string variable)
        {
            var lParam = new VariableParam(variable);
           
            var svc = new VariablesREST_xslt(RestUrl, xslt);

            var result = (VariablesResponseString)svc.GetVariables(lParam);
            var xmlString = new StringBuilder();
            var xmlWriter = XmlWriter.Create(xmlString);
            serializer.Serialize(xmlWriter,result);


        }
    }
}