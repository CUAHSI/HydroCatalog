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

       public class TransformValues
        {










           private static ILog log = LogManager.GetLogger(typeof(TransformValues));

            private XmlSerializer serializer;

            private GetValuesOD valuesSvc;

            private CompiledXslt xslt;
            private string xsltName;
            public TransformValues()
                : base()
            {

                InitializeService();


            }

            public TransformValues(string XlstName)
                : base()
            {
               
                xsltName = XlstName;
                InitializeService();


            }


            private void InitializeService()
            {
                valuesSvc = new GetValuesOD();

                xslt = new CompiledXslt(AppDomain.CurrentDomain.BaseDirectory
                    + xsltName);
                serializer = WOFXmlSerializerFactory.GetSerializer(typeof(TimeSeriesResponseType)); // just get it into the xml serializer factory

            }



            public String ServiceName { get; set; }

            /* PASSTHOUGH VERSION */
            [return: XmlElement(
     Namespace = WaterOneFlowImpl.v1_0.Constants.XML_SCHEMA_NAMSPACE,
ElementName = "timeSeriesResponse",
   IsNullable = false
                // , Type = typeof(TimeSeriesResponseType)
     )]
            public object GetTimeSeries(
       string Location,
        string Variable,
        string BeginDateTime, string EndDateTime)
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

                

                    var result = valuesSvc.getValues(Location.ToString(),
                                                           Variable.ToString(),
                                                           BeginDateTime,
                                                           EndDateTime);



                    MemoryStream memoryStream = new MemoryStream();
                    XmlWriter writer = XmlWriter.Create(memoryStream);
                    serializer.Serialize(writer, result);
                    memoryStream.Position = 0;
                    var reader = XmlReader.Create(memoryStream);

                    StringBuilder sb = new StringBuilder();
                    var writer2 = XmlWriter.Create(sb);

                    xslt.Transform(reader, writer2);




                    return sb;

                }


                catch (Exception ex)
                {
                    log.Info(ServiceName + " Connection Error " + ex.Message);
                    throw new WaterOneFlowSourceException("Error connecting to " + ServiceName);
                }





            }

        }




        //        /// <summary>
        //        /// read string from USGS, and reserializes it.
        //        /// </summary>
        //        /// <param name="dailyValues"></param>
        //        /// <returns></returns>
        //        private cuahsi.his.schema.Response.v1_0.TimeSeriesResponseType reserializeResponse(String dailyValues)
        //        {
        //            cuahsi.his.schema.Response.v1_0.TimeSeriesResponseType res = null;
        //            try
        //            {
        //                TextReader reader = new StringReader(dailyValues);



        //                res = (cuahsi.his.schema.Response.v1_0.TimeSeriesResponseType)serializer.Deserialize(reader);

        //            }
        //            catch
        //            {
        //                log.Error("USGS DailyValue Bad WaterML Format");
        //                throw new WaterOneFlowSourceException("Error retrieving information from USGS");

        //            }
        //            return res;
        //        }



        //        public class Passthrough : cuahsi.his.schema.Response.v1_0.TimeSeriesResponseType, IXmlSerializable
        //        {
        //            private Stream reader;
        //            public Passthrough()
        //            {
        //                reader = null;
        //            }
        //            public Passthrough(Stream r)
        //            {
        //                reader = r;
        //            }
        //            #region IXmlSerializable Members

        //            System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
        //            {
        //                return null;
        //            }

        //            void IXmlSerializable.ReadXml(XmlReader reader)
        //            {
        //                throw new NotImplementedException();
        //            }
        //            void IXmlSerializable.WriteXml(XmlWriter writer)
        //            {
        //                // Now read s into a byte buffer.
        //                byte[] bytes = new byte[reader.Length];
        //                int numBytesToRead = (int)reader.Length;
        //                int numBytesRead = 0;
        //                while (numBytesToRead > 0)
        //                {
        //                    // Read may return anything from 0 to 10.
        //                    int n = reader.Read(bytes, numBytesRead, 10);
        //                    // The end of the file is reached.
        //                    if (n == 0)
        //                    {
        //                        break;
        //                    }
        //                    numBytesRead += n;
        //                    numBytesToRead -= n;
        //                }
        //                reader.Close();

        //            }
        //            #endregion
        //        }
        //    }
        //}




    }
}
