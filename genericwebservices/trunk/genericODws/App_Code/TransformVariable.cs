using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using cuahsi.his.service.xslt.utilties;

using log4net;
using WaterOneFlow.odws;
using WaterOneFlowImpl;
using W3CDateTime = WaterOneFlowImpl.W3CDateTime;


namespace cuahsi.his.service.xslt
{
    namespace v1_0
    {
        using WaterOneFlow.Schema.v1;

       public class TransformVariable
        {










           private static ILog log = LogManager.GetLogger(typeof(TransformSites));

            private XmlSerializer serializer;

            private GetVariablesOD svc;

            private CompiledXslt xslt;
            private string xsltName;
            public TransformVariable()
                : base()
            {

                InitializeService();


            }

            public TransformVariable(string XlstName)
                : base()
            {
               
                xsltName = XlstName;
                InitializeService();


            }


            private void InitializeService()
            {
                svc = new GetVariablesOD();

                xslt = new CompiledXslt(AppDomain.CurrentDomain.BaseDirectory
                    + xsltName);
                serializer = WOFXmlSerializerFactory.GetSerializer(typeof(VariablesResponseType)); // just get it into the xml serializer factory

            }



            public String ServiceName { get; set; }

            /* PASSTHOUGH VERSION */
            [return: XmlElement(
     Namespace = WaterOneFlowImpl.v1_0.Constants.XML_SCHEMA_NAMSPACE,
ElementName = "variablesResponse",
   IsNullable = false
                // , Type = typeof(VariablesResponseType)
     )]
            public object GeVariable(
       string variable
        )
            {
              

 


                try
                {

                    /*http://hydro1.sci.gsfc.nasa.gov/daac-bin/cuahsi/his.cgi?function=GetVaules
                     * &variable=NLDAS:NLDAS_FORA0125_H.002:apcpsfc
                     * &location=GEOM:POINT(-86.188%2035.063)
                     * &startDate=1980-01-03T11
                     * &endDate=1980-01-04T11                   
                 
                     * http://hydro1.sci.gsfc.nasa.gov/daac-bin/cuahsi/his.cgi?function=GetVaules&variable={1}&location={0}&startDate={2}&endDate={3}   
                       */



                    var result = svc.GetVariableInfo(variable);
    



                    //MemoryStream memoryStream = new MemoryStream();
                    //XmlWriter writer = XmlWriter.Create(memoryStream);
                    //serializer.Serialize(writer, result);
                    //memoryStream.Position = 0;
                    //var reader = XmlReader.Create(memoryStream);

                    //StringBuilder sb = new StringBuilder();
                    //var writer2 = XmlWriter.Create(sb);

                    //xslt.Transform(reader, writer2);


                    StringBuilder sb = new StringBuilder();
                    XmlWriter writer = XmlWriter.Create(sb);
                    serializer.Serialize(writer, result);
                    return sb;

                }


                catch (Exception ex)
                {
                    log.Info(ServiceName + " Connection Error " + ex.Message);
                    throw new WaterOneFlowSourceException("Error connecting to " + ServiceName);
                }





            }

        }





    }
}
