using System;
using System.IO;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml;

using cuahsi.his.schema.Response;


namespace cuahsi.his.WaterService
{
    namespace Service
    {

        /* change the namspace, and the using references, 
         * and the code will work for a different verion the 
         * complied microsfot schema classes that were complied with
         * xsd.exe 
         * 
         * Classes are complied with a command line like
         * xsd /c /n:WaterOneFlow.Schema.v1_1  cuahsiTimeSeries_v1_1.xsd
         */

        namespace v1_1.xsd
        {
            using ServiceDescriptions = Constants.v1_1.ServiceDescriptions;
            using Abstract = cuahsi.his.schema.Abstract.v1_1;

            //using WaterOneFlow.Service.Response.v1;
            using VariablesResponseTypeGeneric = cuahsi.his.schema.Response.v1_1.VariablesResponseType;
            using SiteInfoResponseTypeGeneric = cuahsi.his.schema.Response.v1_1.SiteInfoResponseType;
            using TimeSeriesResponseTypeGeneric = cuahsi.his.schema.Response.v1_1.TimeSeriesResponseType;
      
            //
            //using WaterOneFlow.Schema.v1;
            using VariablesResponseTypeObject = cuahsi.his.schema.waterml.v1_1.VariablesResponseType;
            using SiteInfoResponseTypeObject = cuahsi.his.schema.waterml.v1_1.SiteInfoResponseType;
            using TimeSeriesResponseTypeObject = cuahsi.his.schema.waterml.v1_1.TimeSeriesResponseType;


#region variables
/// <summary>
/// This class is a wrapper for the Microsoft xsd.exe schema classes
/// </summary>
        [XmlSchemaProvider("WaterMLSchema")]
        [XmlRoot(ElementName = "variablesResponse", Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE)]
        public class VariablesResponse : VariablesResponseTypeGeneric, IXmlSerializable
        {


            private VariablesResponseTypeObject responseObject;

            private XmlSerializer serializer = new XmlSerializer(typeof(VariablesResponseTypeObject));

            public VariablesResponseTypeObject VariablesResponseType
            {
                get { return responseObject; }
                set { responseObject = value; }
            }

            public VariablesResponse()
            {
                responseObject = null;

            }
           
            public VariablesResponse(string VariablesResponseTypeXml)
            {
 
                    TextReader reader = new StringReader(VariablesResponseTypeXml);
                    responseObject = (VariablesResponseTypeObject)serializer.Deserialize(reader);
 
                    
                }


            public VariablesResponse(VariablesResponseTypeObject variablesResponseObject)
             {
                 responseObject = variablesResponseObject;
             }



            #region IXmlSerializable Members

            System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
            {
                return null;
            }

            void IXmlSerializable.ReadXml(XmlReader reader)
            {
                responseObject = (VariablesResponseTypeObject)serializer.Deserialize(reader);
            }

            void IXmlSerializable.WriteXml(XmlWriter writer)
            {
                serializer.Serialize(writer, responseObject);
            }

            #endregion
        }
        #endregion

        #region SiteInfo
        [XmlSchemaProvider("WaterMLSchema")]
            [XmlRoot(ElementName = "sitesResponse",
                Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE)]
            
            public class SiteInfoResponse : SiteInfoResponseTypeGeneric, IXmlSerializable
        {
                  private SiteInfoResponseTypeObject responseObject;

            private XmlSerializer serializer = new XmlSerializer(typeof(SiteInfoResponseTypeObject));

            public SiteInfoResponseTypeObject SiteInfoResponseType
            {
                get { return responseObject; }
                set { responseObject = value; }
            }

            public SiteInfoResponse()
            {
                responseObject = null;

            }
           
            public SiteInfoResponse(string SiteInfoResponseTypeXml)
            {

                TextReader reader = new StringReader(SiteInfoResponseTypeXml);
                    responseObject = (SiteInfoResponseTypeObject)serializer.Deserialize(reader);
 
                    
                }


            public SiteInfoResponse(SiteInfoResponseTypeObject siteInfoResponseObject)
             {
                 responseObject = siteInfoResponseObject;
             }



            #region IXmlSerializable Members

            System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
            {
                return null;
            }

            void IXmlSerializable.ReadXml(XmlReader reader)
            {
                responseObject = (SiteInfoResponseTypeObject)serializer.Deserialize(reader);
            }

            void IXmlSerializable.WriteXml(XmlWriter writer)
            {
                serializer.Serialize(writer, responseObject);
            }
            #endregion
        }
        #endregion

        #region TimeSeries
       // [XmlSchemaProvider("WaterMLSchema")]
            [XmlRoot(ElementName = "timeSeriesResponse",
                Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE)]
            public class TimeSeriesResponse : TimeSeriesResponseTypeGeneric, IXmlSerializable
        {
                           private TimeSeriesResponseTypeObject responseObject;

            private XmlSerializer serializer = new XmlSerializer(typeof(TimeSeriesResponseTypeObject));

            public TimeSeriesResponseTypeObject SiteInfoResponseType
            {
                get { return responseObject; }
                set { responseObject = value; }
            }

            public TimeSeriesResponse()
            {
                responseObject = null;

            }
           
            public TimeSeriesResponse(string timeSeriesResponseTypeXml)
            {

                TextReader reader = new StringReader(timeSeriesResponseTypeXml);
                    responseObject = (TimeSeriesResponseTypeObject)serializer.Deserialize(reader);
 
                    
                }


            public TimeSeriesResponse(TimeSeriesResponseTypeObject timeSeriesResponseObject)
             {
                 responseObject = timeSeriesResponseObject;
             }



            #region IXmlSerializable Members

            System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
            {
                return null;
            }

            void IXmlSerializable.ReadXml(XmlReader reader)
            {
                responseObject = (TimeSeriesResponseTypeObject)serializer.Deserialize(reader);
            }

            void IXmlSerializable.WriteXml(XmlWriter writer)
            {
                serializer.Serialize(writer, responseObject);
            }
            #endregion
        }
        #endregion
    }
    }
}
