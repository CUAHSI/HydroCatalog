using System;
using System.IO;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml;
using cuahsi.his.schema.Abstract.v1_0;
using cuahsi.his.schema.waterml.v1;


namespace cuahsi.his.WaterService
{
    namespace Service
    {
        namespace v1_0.Passthrough
        {

            using schema.Abstract.v1_0;
            // using WaterOneFlow.Schema.v1;
            using cuahsi.his.WaterService.Constants.v1;

            using QueryInfoElement = cuahsi.his.schema.waterml.v1.QueryInfoType;
            using VariablesElement = cuahsi.his.schema.waterml.v1.variables;

           //  using VariablesResponseTypeObject = cuahsi.his.schema.waterml.v1.VariablesResponseType;
           //using SiteInfoResponseTypeObject = cuahsi.his.schema.waterml.v1.SiteInfoResponseType;
           // using TimeSeriesResponseTypeObject = cuahsi.his.schema.waterml.v1.TimeSeriesResponseType;
            using VariablesResponseTypeObject = cuahsi.his.schema.Response.v1_0.VariablesResponseType;
            using SiteInfoResponseTypeObject = cuahsi.his.schema.Response.v1_0.SiteInfoResponseType;
            using TimeSeriesResponseTypeObject = cuahsi.his.schema.Response.v1_0.TimeSeriesResponseType;

            #region TimeSeries
            [XmlSchemaProvider("WaterMLSchema")]
            [XmlRoot(ElementName = "timeSeriesResponse",
               Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
               IsNullable = false)]
            public class TimeSeriesResponseString : TimeSeriesResponseTypeObject, IXmlSerializable
            {
                private QueryInfoElementString _queryInfoString;
                private TimeSeriesElementString __timeSeriesString;

                private string _queryInfo;
                private string _timeSeries;
                private string xml;

                public string Xml
                {
                    get { return xml; }
                    set
                    {
                        TextReader reader = new StringReader(value);
                        XmlReader xReader = XmlReader.Create(reader);
                        WaterService.Service.Schema.Utilities.GetResponseElements.Response res =
                        WaterService.Service.Schema.Utilities.GetResponseElements.StripResponseElement("timeSeriesResponse", xReader);
                        xml = res.Xml;
                    }
                }

                public QueryInfoElementString QueryInfo
                {
                    get { return _queryInfoString; }
                    set { _queryInfoString = value; }
                }

                public TimeSeriesResponseString()
                {
                    // Xml = null;
                }
                public TimeSeriesResponseString(string TimeSeriesResponseTypeXml)
                {
                    Xml = TimeSeriesResponseTypeXml;
                }


                public static XmlQualifiedName WaterMLSchema(XmlSchemaSet xs)
                {
                    //// This method is called by the framework to get the schema for this type.
                    //// We return an existing schema from disk.

                    return TimeSeriesResponseTypeObject.WaterMLSchema(xs);
                }

                #region IXmlSerializable Members

                System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
                {
                    return null;
                }

                void IXmlSerializable.ReadXml(XmlReader reader)
                {


                    xml = reader.ReadInnerXml();
                    //reader.MoveToContent();

                    //Boolean isEmptyElement = reader.IsEmptyElement; // (1)
                    //reader.ReadStartElement();
                    //if (!isEmptyElement) // (1)
                    //{
                    //    xml = reader.ReadInnerXml();

                    //}
                }

                void IXmlSerializable.WriteXml(XmlWriter writer)
                {


                    //  writer.WriteString(Xml);
                    writer.WriteRaw(Xml);
                }

                #endregion
            }

            [XmlRoot(ElementName = "queryInfo",
             Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
             IsNullable = false)]
            public class QueryInfoElementString : QueryInfoElement, IXmlSerializable
            {


                private string xml;

                public string Xml
                {
                    get { return xml; }
                    set
                    {
                        TextReader reader = new StringReader(value);
                        XmlReader xReader = XmlReader.Create(reader);
                        WaterService.Service.Schema.Utilities.GetResponseElements.Response res =
                        WaterService.Service.Schema.Utilities.GetResponseElements.StripResponseElement("timeSeriesResponse", xReader);
                        xml = res.Xml;
                    }
                }



                public QueryInfoElementString()
                {
                    // Xml = null;
                }
                public QueryInfoElementString(string QueryInfoElementString)
                {
                    Xml = QueryInfoElementString;
                }




                #region IXmlSerializable Members

                System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
                {
                    return null;
                }

                void IXmlSerializable.ReadXml(XmlReader reader)
                {


                    xml = reader.ReadInnerXml();
                    //reader.MoveToContent();

                    //Boolean isEmptyElement = reader.IsEmptyElement; // (1)
                    //reader.ReadStartElement();
                    //if (!isEmptyElement) // (1)
                    //{
                    //    xml = reader.ReadInnerXml();

                    //}
                }

                void IXmlSerializable.WriteXml(XmlWriter writer)
                {
                    writer.WriteRaw(Xml);
                }

                #endregion
            }

            [XmlRoot(ElementName = "timeSeries",
          Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
          IsNullable = false)]
            public class TimeSeriesElementString : TimeSeriesType, IXmlSerializable
            {


                private string xml;

                public string Xml
                {
                    get { return xml; }
                    set
                    {
                        TextReader reader = new StringReader(value);
                        XmlReader xReader = XmlReader.Create(reader);
                        WaterService.Service.Schema.Utilities.GetResponseElements.Response res =
                        WaterService.Service.Schema.Utilities.GetResponseElements.StripResponseElement("timeSeriesResponse", xReader);
                        xml = res.Xml;
                    }
                }



                public TimeSeriesElementString()
                {
                    // Xml = null;
                }
                public TimeSeriesElementString(string TimeSeriesElementString)
                {
                    Xml = TimeSeriesElementString;
                }


             

                #region IXmlSerializable Members

                System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
                {
                    return null;
                }

                void IXmlSerializable.ReadXml(XmlReader reader)
                {


                    xml = reader.ReadInnerXml();
                    //reader.MoveToContent();

                    //Boolean isEmptyElement = reader.IsEmptyElement; // (1)
                    //reader.ReadStartElement();
                    //if (!isEmptyElement) // (1)
                    //{
                    //    xml = reader.ReadInnerXml();

                    //}
                }

                void IXmlSerializable.WriteXml(XmlWriter writer)
                {
                    writer.WriteRaw(Xml);
                }

                #endregion
            }
            //public class TimeSeriesResponseStream : TimeSeriesResponseType, IXmlSerializable
            //{
            // // Reading of message from rest interface, and writign to soap output writer should
            // // speed things up. This will need some work since it needs buffered output, and 
            // // checks to see that we have gotten everything from the data source.

            //    private Stream reader;

            //    public Stream Reader
            //    {
            //        get { return reader; }
            //        set { reader = value; }
            //    }

            //    public TimeSeriesResponseStream()
            //    {
            //        Reader = null;
            //    }
            //    public TimeSeriesResponseStream(StreamReader TimeSeriesResponseTypeStreamReader)
            //    {
            //        Reader = TimeSeriesResponseTypeStreamReader;
            //    }




            //    #region IXmlSerializable Members

            //    System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
            //    {
            //        return null;
            //    }

            //    void IXmlSerializable.ReadXml(XmlReader reader)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    void IXmlSerializable.WriteXml(XmlWriter writer)
            //    {
            //        int bufferSize = 1024;
            //        using (Reader){
            //           while (!Reader.CanRead) {
            //               writer.WriteRaw(Reader.);
            //           }
            //       }
            //    }

            //    #endregion
            //}
            #endregion


            #region variables
            [XmlSchemaProvider("WaterMLSchema")]
            [XmlRoot(ElementName = "variablesResponse",
                Namespace = Constants.v1.ServiceDescriptions.XML_SCHEMA_NAMSPACE
                )]
            public class VariablesResponseString :
           //     VariablesResponseTypeObject,
             IXmlSerializable
            {
                [XmlIgnore]
                [SoapIgnore]
                private string xml;

                [XmlIgnore]
                [SoapIgnore]
                public string Xml
                {
                    get { return xml; }
                    set { xml = value; }
                }

               
                public VariablesResponseString()
                {
                    xml = null;
                }
                

                public VariablesResponseString(string VariablesResponseTypeXml)
                {
                    xml = VariablesResponseTypeXml;
                }


                public static XmlQualifiedName WaterMLSchema(XmlSchemaSet xs)
                {
                    //// This method is called by the framework to get the schema for this type.
                    //// We return an existing schema from disk.

                    return VariablesResponseTypeObject.WaterMLSchema(xs);
                }

                #region IXmlSerializable Members

                System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
                {
                    return null;
                }

                void IXmlSerializable.ReadXml(XmlReader reader)
                {
                    xml = reader.ReadInnerXml();
                }

                void IXmlSerializable.WriteXml(XmlWriter writer)
                {

                    writer.WriteRaw(Xml);
                }
                #endregion

            }
            #endregion

            #region SiteInfo
           [XmlSchemaProvider("WaterMLSchema")]
             [XmlRoot(ElementName = "sitesResponse",
          Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
          IsNullable = false)]
            public class SiteInfoResponseString : SiteInfoResponseTypeObject, IXmlSerializable
            {
                private string xml;

                public string Xml
                {
                    get { return xml; }
                    set
                    {
                        TextReader reader = new StringReader(value);
                        XmlReader xReader = XmlReader.Create(reader);
                        WaterService.Service.Schema.Utilities.GetResponseElements.Response res =
                        WaterService.Service.Schema.Utilities.GetResponseElements.StripResponseElement("sitesResponse", xReader);
                        xml = res.Xml;
                    }
                }

                public SiteInfoResponseString()
                {
                    xml = null;
                }
                public SiteInfoResponseString(string SiteInfoResponseTypeXml)
                {
                    xml = SiteInfoResponseTypeXml;
                }



                public static XmlQualifiedName WaterMLSchema(XmlSchemaSet xs)
                {
                    //// This method is called by the framework to get the schema for this type.
                    //// We return an existing schema from disk.

                    return SiteInfoResponseTypeObject.WaterMLSchema(xs);
                }
                #region IXmlSerializable Members

                System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
                {
                    return null;
                }

                void IXmlSerializable.ReadXml(XmlReader reader)
                {
                    xml = reader.ReadInnerXml();
                }

                void IXmlSerializable.WriteXml(XmlWriter writer)
                {

                    writer.WriteRaw(Xml);
                }

                #endregion
            }
            #endregion

        }
    }
}
