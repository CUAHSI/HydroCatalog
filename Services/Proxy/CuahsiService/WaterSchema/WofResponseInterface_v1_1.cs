using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;


namespace cuahsi.his.schema
{
    namespace Response
    {
     
        namespace v1_1
        {

            using cuahsi.his.schema.Constants.v1_1;
            #region variables
            /// <summary>
            /// Returns a waterML 1.1 Xml Schema for the VariablesResponseType Type Element
            /// <para>This class should be extended, and the programmer must implement
            /// IXmlSerializable interface in the extended class. Only the WriteXml method
            /// needs full implmentation to be used in web service. The GetSchema, and
            /// ReadXml can bel left as  NotImplementedException</para>
            /// <para>This will allow for programers to impelement pass through 
            /// XML, or a variety of 
            /// XmlSerializers.</para>
            /// </summary>

            [XmlSchemaProvider("WaterMLSchema")]
            [XmlRoot(Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
       ElementName = "variablesResponse")]
            public class VariablesResponseType : IXmlSerializable
            {
                // used in the schema method
                // needed to convert Element variablesResponse to a complex
                // type derived from "VariablesResponseType"
               private const string TypeName = "VariablesResponseType";
               //   private const string TypeName = "variablesResponse";

                public VariablesResponseType()
                {

                }

                /// <summary>
                /// Returns the WaterML XmlSchema, v1
                /// <para>This is an embdeded resource, "cuahsiTimeSeries_v1"</para>
                /// </summary>
                /// <param name="xs"></param>
                /// <returns></returns>
                public static XmlQualifiedName WaterMLSchema(XmlSchemaSet xs)
                {
                    //// This method is called by the framework to get the schema for this type.
                    //// We return an existing schema from disk.

                    xs.XmlResolver = new XmlUrlResolver();
                    xs.Add(GetSchemaResource.Schema());
                    
                    return new XmlQualifiedName(TypeName, ServiceDescriptions.XML_SCHEMA_NAMSPACE);
                }
                #region IXmlSerializable Members

                public System.Xml.Schema.XmlSchema GetSchema()
                {
                    return null;
                }

                public void ReadXml(System.Xml.XmlReader reader)
                {
                    throw new NotImplementedException();
                }

                public void WriteXml(System.Xml.XmlWriter writer)
                {
                    throw new NotImplementedException();
                }

                #endregion
            }
             
            #endregion

            #region Sites Response
            /// <summary>
            /// Returns a waterML 1.1  Xml Schema for the SiteInfoResponseType Type Element
            /// <para>This class should be extended, and the programmer must implement
            /// IXmlSerializable interface in the extended class. Only the WriteXml method
            /// needs full implmentation to be used in web service. The GetSchema, and
            /// ReadXml can bel left as  NotImplementedException</para>
            /// <para>This will allow for programers to impelement pass through 
            /// XML, or a variety of 
            /// XmlSerializers.</para>
            /// </summary>

            [XmlSchemaProvider("WaterMLSchema")]
            [XmlRoot(Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE, 
                ElementName = "sitesResponse")]
            public class SiteInfoResponseType : IXmlSerializable
            {
                private const string TypeName = "SiteInfoResponseType";

                public SiteInfoResponseType()
                {

                }
                public static XmlQualifiedName WaterMLSchema(XmlSchemaSet xs)
                {
                    //// This method is called by the framework to get the schema for this type.
                    //// We return an existing schema from disk.

                  

                    xs.XmlResolver = new XmlUrlResolver();
                    xs.Add(GetSchemaResource.Schema());

                    return new XmlQualifiedName(TypeName, ServiceDescriptions.XML_SCHEMA_NAMSPACE);
                }
                #region IXmlSerializable Members

                public System.Xml.Schema.XmlSchema GetSchema()
                {
                    return null;
                }

                public void ReadXml(System.Xml.XmlReader reader)
                {
                    throw new NotImplementedException();
                }

                public void WriteXml(System.Xml.XmlWriter writer)
                {
                    throw new NotImplementedException();
                }

                #endregion
            }

#endregion

            #region TimeSeries
            /// <summary>
            /// Returns a waterML 11.1  Xml Schema for the TimeSeriesResponseType Type Element (aka GetValues)
            /// <para>This class should be extended, and the programmer must implement
            /// IXmlSerializable interface in the extended class. Only the WriteXml method
            /// needs full implmentation to be used in web service. The GetSchema, and
            /// ReadXml can bel left as  NotImplementedException</para>
            /// <para>This will allow for programers to impelement pass through 
            /// XML, or a variety of 
            /// XmlSerializers.</para>
            /// </summary>

            [XmlSchemaProvider("WaterMLSchema")]
            [XmlRoot(Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE, 
                ElementName = "timeSeriesResponse")]
            public class TimeSeriesResponseType : IXmlSerializable
            {
                // used in the schema method
                private const string TypeName = "TimeSeriesResponseType";

                public TimeSeriesResponseType()
                {

                }
                public static XmlQualifiedName WaterMLSchema(XmlSchemaSet xs)
                {
                    //// This method is called by the framework to get the schema for this type.
                    //// We return an existing schema from disk.


                    xs.XmlResolver = new XmlUrlResolver();
                    xs.Add(GetSchemaResource.Schema());

                    return new XmlQualifiedName(TypeName, ServiceDescriptions.XML_SCHEMA_NAMSPACE);
                }
                #region IXmlSerializable Members

                public System.Xml.Schema.XmlSchema GetSchema()
                {
                    return null;
                }

                public void ReadXml(System.Xml.XmlReader reader)
                {
                    throw new NotImplementedException();
                }

                public void WriteXml(System.Xml.XmlWriter writer)
                {
                    throw new NotImplementedException();
                }

                #endregion
            }

            #endregion

            #region Get Schema
            public class GetSchemaResource
        {
                public static XmlSchema Schema()
            {
                    return GetSchema.SchemaV1_1();

                }
        }
            #endregion
        }// namespace v1

    }// namespace response
}
