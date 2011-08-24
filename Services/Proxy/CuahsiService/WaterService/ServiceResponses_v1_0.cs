 using System;
using System.IO;
using System.Text;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml;
using cuahsi.his.schema.waterml.v1;
using cuahsi.his.WaterService.Utilities;

using cuahsi.his.WaterService.Service.v1_0.Passthrough;


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

    
        namespace v1_0.xsd
        {
            using ServiceDescriptions = Constants.v1.ServiceDescriptions;
using Abstract=  schema.Abstract.v1_0;
            //using WaterOneFlow.Service.Response.v1;
            using VariablesResponseTypeGeneric = cuahsi.his.schema.Response.v1_0.VariablesResponseType;
            using SiteInfoResponseTypeGeneric = cuahsi.his.schema.Response.v1_0.SiteInfoResponseType;
            using TimeSeriesResponseTypeGeneric = cuahsi.his.schema.Response.v1_0.TimeSeriesResponseType;

            //
            //using WaterOneFlow.Schema.v1;
            using VariablesResponseTypeObject = cuahsi.his.schema.waterml.v1.VariablesResponseType;
            using QueryInfoElement = cuahsi.his.schema.waterml.v1.QueryInfoType;
            using VariablesElement = cuahsi.his.schema.waterml.v1.variables;

            using SiteInfoResponseTypeObject = cuahsi.his.schema.waterml.v1.SiteInfoResponseType;
            using TimeSeriesResponseTypeObject = cuahsi.his.schema.waterml.v1.TimeSeriesResponseType;


            #region variables
            /// <summary>
            /// This class is a wrapper for the Microsoft xsd.exe schema classes
            /// </summary>
            //   [XmlSchemaProvider("WaterMLSchema")]
            [XmlRoot(ElementName = "variablesResponse",
               Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
               IsNullable = false)]
            public class VariablesResponse : VariablesResponseTypeGeneric,
                Abstract.VariablesResponseType, IXmlSerializable
            {


                private VariablesResponseTypeObject responseObject;

                 [XmlIgnore]
                public VariablesResponseTypeObject VariablesResponseType
                {
                    get { return responseObject; }
                    set { responseObject = value; }
                }

                public QueryInfoType queryInfo
                {
                    get { return responseObject.queryInfo; }
                }

                public VariableInfoType[] variables
                {
                    get { return responseObject.variables; }
                }

                public VariablesResponse()
                {
                    responseObject = null;
                   
                }

                public VariablesResponse(string VariablesResponseTypeXml)
                {
                    
                    TextReader reader = new StringReader(VariablesResponseTypeXml);
                    XmlSerializer variablesResponseSerializer = Serializers.variablesSerialier();
                    responseObject = (VariablesResponseTypeObject)variablesResponseSerializer.Deserialize(reader);


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
                    XmlSerializer variablesResponseSerializer = Serializers.variablesSerialier();
                    if (variablesResponseSerializer.CanDeserialize(reader))
                    {
                        responseObject = (VariablesResponseTypeObject)variablesResponseSerializer.Deserialize(reader);
                    }
                }

                void IXmlSerializable.WriteXml(XmlWriter writer)
                {

                    XmlSerializer variablesSerializer = Serializers.variablesSerialier();
                    XmlSerializer queryInfoSerializer = Serializers.queryInfoSerializer();

                    queryInfoSerializer.Serialize(writer, responseObject.queryInfo);
                    variables v = new variables();
                    v.variable = responseObject.variables;
                    variablesSerializer.Serialize(writer, v);


                    //       XmlAttributeOverrides attrOverrides =
                    //new XmlAttributeOverrides();

                    /* Orginal attempt. This adds a double element
                     * <variablesResponse><variablesResponse><variable>content</variable><variable>...
                     * */
                    //XmlWriterSettings settings = new XmlWriterSettings();
                    //variablesResponseSerializer.Serialize(writer, responseObject);


                    /* second attempt. 
                        * <variablesResponse><variablesResponse><variable>content</variable><variable>...
                        * */

                    //StringBuilder sb = new StringBuilder();

                    //XmlWriterSettings setting = new XmlWriterSettings();
                    //setting.OmitXmlDeclaration = true;
                    //setting.ConformanceLevel = ConformanceLevel.Auto;

                    //XmlWriter aWriter = XmlWriter.Create(sb, setting);
                    //queryInfoSerializer.Serialize(aWriter, responseObject.queryInfo, ns);
                    //aWriter.Close();
                    //writer.WriteRaw(sb.ToString());
                    //writer.Flush();

                    //aWriter = XmlWriter.Create(sb, setting);
                    //sb.Remove(0, sb.Length);
                    ////writer.WriteStartElement("variables");
                    ////foreach (object o in responseObject.variables)
                    ////{
                    ////    variableSerializer.Serialize(aWriter, o, ns);
                    ////}
                    ////writer.WriteRaw(sb.ToString());
                    ////writer.WriteEndElement();

                    //variablesSerializer.Serialize(aWriter, responseObject.variables, ns);
                    //writer.WriteRaw(sb.ToString());

                    //queryInfoSerializer.Serialize(writer, responseObject.queryInfo, ns);
                    //variables v = new variables();
                    //v.variable = responseObject.variables;
                    //variablesSerializer.Serialize(writer, v , ns);

                }

                #endregion
            }
            #endregion

            #region SiteInfo
            // [XmlSchemaProvider("WaterMLSchema")]
            [XmlRoot(ElementName = "sitesResponse",
               Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
               IsNullable = false)]
            public class SiteInfoResponse : SiteInfoResponseTypeGeneric, IXmlSerializable
            {
                private SiteInfoResponseTypeObject responseObject;

 
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
                    XmlSerializer serializer = WOFXmlSerializerFactory.GetSerializer(typeof(SiteInfoResponseTypeObject));
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
                    XmlSerializer serializer = WOFXmlSerializerFactory.GetSerializer(typeof(SiteInfoResponseTypeObject));
                    responseObject = (SiteInfoResponseTypeObject)serializer.Deserialize(reader);
                }

                void IXmlSerializable.WriteXml(XmlWriter writer)
                {
                    XmlSerializer qi = Serializers.queryInfoSerializer();
                    qi.Serialize(writer, responseObject.queryInfo);
                    
                    XmlSerializer site = Serializers.siteSerializer();
                    foreach (site s in responseObject.site){
                    site.Serialize(writer, s);
                    }
                }
                #endregion
            }
            #endregion

            #region TimeSeries
           // [XmlSchemaProvider("WaterMLSchema")]
            [XmlRoot(ElementName = "timeSeriesResponse",
                Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
                IsNullable = false)]
            public class TimeSeriesResponse : TimeSeriesResponseTypeGeneric, IXmlSerializable
            {
                private TimeSeriesResponseTypeObject responseObject;

          //      private XmlSerializer serializer= new XmlSerializer(typeof(TimeSeriesResponseTypeObject));

                
                public TimeSeriesResponseTypeObject TimeSeriesResponseType
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
                    XmlSerializer serializer =WOFXmlSerializerFactory.GetSerializer(typeof(TimeSeriesResponseTypeObject));
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
                    XmlSerializer serializer = WOFXmlSerializerFactory.GetSerializer(typeof(TimeSeriesResponseTypeObject));
                    responseObject = (TimeSeriesResponseTypeObject)serializer.Deserialize(reader);
                }

                void IXmlSerializable.WriteXml(XmlWriter writer)
                {
                    if (responseObject.GetType().Equals(typeof (TimeSeriesResponseString)))
                    {
                        //XmlSerializer tsr = Serializers.timeSeriesStringSerializer();

                        writer.WriteRaw(((TimeSeriesResponseString)responseObject).Xml);
                    }
                    else
                    {
                      XmlSerializer qi = Serializers.queryInfoSerializer();
                    qi.Serialize(writer, responseObject.queryInfo);
                    XmlSerializer ts = Serializers.timeSeriesSerializer();
                    ts.Serialize(writer, responseObject.timeSeries);
                }

            }
                #endregion
            }
            #endregion

            public  static class Serializers
            {

                public static XmlSerializer queryInfoSerializer()
                {
                    XmlRootAttribute qi = new XmlRootAttribute("queryInfo");
                    qi.Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE;

                    XmlSerializer queryInfoSerializer = WOFXmlSerializerFactory.GetSerializer(typeof(QueryInfoElement), qi);
       // = new XmlSerializer(typeof(QueryInfoElement), qi);
                    return queryInfoSerializer;

                }

                public static XmlSerializer variablesSerialier()
                {
                    XmlRootAttribute vs = new XmlRootAttribute("variables");
                    vs.Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE;
                    return WOFXmlSerializerFactory.GetSerializer(typeof(variables), vs);

                }

                public static XmlSerializer timeSeriesSerializer()
                {
                    XmlRootAttribute ts = new XmlRootAttribute("timeSeries");
                    ts.Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE;
                    return WOFXmlSerializerFactory.GetSerializer(typeof(TimeSeriesType), ts);
                }

                public static XmlSerializer siteSerializer()
                {
                    XmlRootAttribute site = new XmlRootAttribute("site");
                    site.Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE;
                    return WOFXmlSerializerFactory.GetSerializer(typeof(site)); 
                    
                    
                    // attempts to  sites array to serialize without wrapping element failed. 
                    //XmlRootAttribute site = new XmlRootAttribute(null);
                    //site.Namespace = ServiceDescriptions.XML_SCHEMA_LOCATION;
                    //return new XmlSerializer(typeof(site[]), site);                    

                    //XmlAttributeOverrides attrOverrides = new XmlAttributeOverrides();
                    //// Create the XmlAttributes class.
                    //XmlAttributes attrs = new XmlAttributes();


                    //XmlElementAttribute site = new XmlElementAttribute(null, typeof(site[]));
                    //site.Namespace = ServiceDescriptions.XML_SCHEMA_LOCATION;
                    //attrs.XmlElements.Add(site);
                    //attrOverrides.Add(typeof(site[]), attrs);

                    //return new XmlSerializer(typeof(site[]), attrOverrides); 

                }
                public static XmlSerializer timeSeriesStringSerializer()
                {
                    //XmlRootAttribute ts = new XmlRootAttribute("timeSeries");
                    //ts.Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE;
                    return WOFXmlSerializerFactory.GetSerializer(typeof(TimeSeriesResponseString));
                }
                public static XmlSerializerNamespaces namespaces()
                {
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    //                ns.Add("", ServiceDescriptions.XML_SCHEMA_NAMSPACE);
                    //               // ns.Add("wtr", ServiceDescriptions.XML_SCHEMA_NAMSPACE); 
                    return ns;
                }

            }
        }

    }
}
