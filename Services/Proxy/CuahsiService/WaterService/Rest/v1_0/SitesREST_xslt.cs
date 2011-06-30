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
using cuahsi.his.WaterService.Parameters;
using cuahsi.his.WaterService.Service.v1_0.Passthrough;
using cuahsi.his.WaterService.Constants.v1;
using cuahsi.his.WaterService.Service.v1_0.Passthrough;
using cuahsi.his.schema.waterml.v1;
using cuahsi.his.WaterService.Utilities;
using log4net;


namespace cuahsi.his.WaterService.Rest
{
    namespace v1_0
    {


        using cuahsi.his.schema.waterml.v1;



        public class SitesREST_xslt
        {



            private static ILog log = LogManager.GetLogger(typeof(SitesREST_xslt));

            private XmlSerializer serializer;


            private CompiledXslt xslt;
            private string xsltName;
            public SitesREST_xslt()
                : base()
            {

                InitializeService();


            }
            public SitesREST_xslt(string BaseRestUrl)
                : base()
            {
                RestBaseUrl = BaseRestUrl;

                InitializeService();


            }
            public SitesREST_xslt(string BaseRestUrl, string XlstName)
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
                serializer = WOFXmlSerializerFactory.GetSerializer(typeof(SiteInfoResponseType)); // just get it into the xml serializer factory
                serializer = WOFXmlSerializerFactory.GetSerializer(typeof(SiteInfoResponseString));
            }

            public Boolean DoValidation { get; set; }

            public String RestBaseUrl { get; set; }

            public String ServiceName { get; set; }

            /* PASSTHOUGH VERSION */
            [return: XmlElement(
     Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
ElementName = "sitesResponse",
   IsNullable = false
                // , Type = typeof(TimeSeriesResponseType)
     )]
            public SiteInfoResponseString GetSites(
       locationParam Location
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
                    string url = RestBaseUrl;
                    if (Location != null)
                    {
                        url = string.Format(RestBaseUrl,
                                                     Location.ToString()
                              );
                    }

                    ;
                    Uri uri = new Uri(url);
                    using (WebClient web = new WebClient())
                    {

                        XmlReader reader = new XmlTextReader(web.OpenRead(url));
                        var memoryStream = new MemoryStream();
                        XmlWriter writer = XmlWriter.Create(memoryStream);
                        xslt.Transform(reader, writer);
                        memoryStream.Position = 0;
                        reader = XmlReader.Create(memoryStream);
                        var response
                            = (SiteInfoResponseString)serializer.Deserialize(reader);


                        return response;
                    }
                }


                catch (Exception ex)
                {
                    log.Info(ServiceName + " Connection Error " + ex.Message);
                    throw new WaterOneFlowSourceException("Error connecting to " + ServiceName);
                }





            }






            /// <summary>
            /// read string from USGS, and reserializes it.
            /// </summary>
            /// <param name="dailyValues"></param>
            /// <returns></returns>
            private cuahsi.his.schema.Response.v1_0.SiteInfoResponseType reserializeResponse(String dailyValues)
            {
                cuahsi.his.schema.Response.v1_0.SiteInfoResponseType res = null;
                try
                {
                    TextReader reader = new StringReader(dailyValues);



                    res = (cuahsi.his.schema.Response.v1_0.SiteInfoResponseType)serializer.Deserialize(reader);

                }
                catch
                {
                    log.Error("USGS DailyValue Bad WaterML Format");
                    throw new WaterOneFlowSourceException("Error retrieving information from USGS");

                }
                return res;
            }



            public class Passthrough : cuahsi.his.schema.Response.v1_0.SiteInfoResponseType, IXmlSerializable
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
