using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Services.Protocols;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml.Xsl;
using cuahsi.his.WaterService.Parameters;
using cuahsi.his.WaterService.Service.v1_0.Passthrough;
using cuahsi.his.WaterService.Constants.v1;
using cuahsi.his.WaterService.Service.v1_0.Passthrough;
using cuahsi.his.schema.waterml.v1;
using cuahsi.his.WaterService.Utilities;
using log4net;
//using NwisWOFService.pass;

namespace cuahsi.his.WaterService.Rest

{
    namespace v1_0
    {
       

        using cuahsi.his.schema.Response.v1_0;
        
        

        public class VariablesREST_xslt {
           
  

            private static ILog log = LogManager.GetLogger(typeof(VariablesREST_xslt));

            private XmlSerializer serializer;


            private CompiledXslt xslt;
            private string xsltName;
            public  VariablesREST_xslt()
                : base()
            {
              
                InitializeService();


            }
            public  VariablesREST_xslt(string BaseRestUrl)
                : base()
            {
                RestBaseUrl = BaseRestUrl;
               
                InitializeService();


            }
            public VariablesREST_xslt(string BaseRestUrl, string XlstName)
                : base()
            {
                RestBaseUrl = BaseRestUrl;
                xsltName = XlstName;
                InitializeService();


            }

          
            private void InitializeService()
            {
               
                xslt = new CompiledXslt(AppDomain.CurrentDomain.BaseDirectory
                    + xsltName);
               // serializer = WOFXmlSerializerFactory.GetSerializer(typeof(VariablesResponseType)); // just get it into the xml serializer factory
                serializer = WOFXmlSerializerFactory.GetSerializer(typeof( VariablesResponseString));
            }

  public Boolean DoValidation { get; set; }

  public String RestBaseUrl { get; set; }

            public String ServiceName { get; set; }

            /* PASSTHOUGH VERSION */
            [return: XmlElement(
     Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
ElementName = "variablesResponse",
   IsNullable = false
                , Type = typeof(VariablesResponseString)
     )]
            public VariablesResponseString GetVariables(
     
        VariableParam Variable)
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
                    string url = string.Format(RestBaseUrl,
                                                     String.Empty
                              );
                    if (Variable != null)
                    {
                        url = string.Format(RestBaseUrl,
                                                     Variable.ToString()
                              );
                    }
                    Uri uri = new Uri(url);
                    using (WebClient web = new WebClient())
                    {

                        XmlReader reader = new XmlTextReader(web.OpenRead(url));
                        MemoryStream memoryStream = new MemoryStream();
                        XmlWriter writer = XmlWriter.Create(memoryStream);
                        xslt.Transform(reader, writer);
                        memoryStream.Position = 0;
                        reader = XmlReader.Create(memoryStream);

//#if DEBUG
//                        reader.IsStartElement("variablesResponse", Constants.v1.ServiceDescriptions.XML_SCHEMA_NAMSPACE);
//                        var test = reader.ReadOuterXml();
//                        memoryStream.Position = 0;
//#endif
                         reader.IsStartElement("variablesResponse", Constants.v1.ServiceDescriptions.XML_SCHEMA_NAMSPACE);
                        var response
                              = (VariablesResponseString)serializer.Deserialize(reader.ReadSubtree());
                         //   = (VariablesResponseType)serializer.Deserialize(reader);

                        //TimeSeriesResponseType response
                        //    = new Passthrough(web.OpenRead(url));
                        return response;
                    }
                }

catch (System.Net.WebException we )
{
    log.Info(ServiceName + " Connection Error " + we.Message);
    throw new WaterOneFlowSourceException("Error connecting to " + ServiceName);
}
  catch (   XsltException xe)
                    {
                        log.Info(ServiceName + " Connection Error " + xe.Message);
    throw new WaterOneFlowSourceException("Error transforming information from"  + ServiceName);
}
               catch (Exception ex)
                {
                    log.Info(ServiceName +" Connection Error " + ex.Message);
                    throw new WaterOneFlowSourceException("Error processing information from  " +ServiceName );
                }





            }






        


            public class Passthrough : cuahsi.his.schema.Response.v1_0.TimeSeriesResponseType, IXmlSerializable
            {
                private Stream reader;
                public Passthrough()
                {
                    reader = null;
                }
                public Passthrough(Stream r)
                {
                    reader = r;
                }
                #region IXmlSerializable Members

                System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
                {
                    return null;
                }

                void IXmlSerializable.ReadXml(XmlReader reader)
                {
                    throw new NotImplementedException();
                }
                void IXmlSerializable.WriteXml(XmlWriter writer)
                {
                    // Now read s into a byte buffer.
                    byte[] bytes = new byte[reader.Length];
                    int numBytesToRead = (int)reader.Length;
                    int numBytesRead = 0;
                    while (numBytesToRead > 0)
                    {
                        // Read may return anything from 0 to 10.
                        int n = reader.Read(bytes, numBytesRead, 10);
                        // The end of the file is reached.
                        if (n == 0)
                        {
                            break;
                        }
                        numBytesRead += n;
                        numBytesToRead -= n;
                    }
                    reader.Close();

                }
                #endregion
            }
        }
    }



}
