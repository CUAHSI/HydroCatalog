using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace cuahsi.his.schema
{
    [XmlSchemaProvider("MySchema")]
    public class TimeSeriesResponse : IXmlSerializable
    {
        public static XmlQualifiedName MySchema(XmlSchemaSet xs)
        {
            // This method is called by the framework to get the schema for this type.
            // We return an existing schema from disk.

            XmlSerializer schemaSerializer = new XmlSerializer(typeof(XmlSchema));
            string xsdPath = null;
            // NOTE: replace the string with your own path.
            xsdPath = System.Web.HttpContext.Current.Server.MapPath("SongStream.xsd");
            XmlSchema s = (XmlSchema)schemaSerializer.Deserialize(
                new XmlTextReader(xsdPath), null);
            xs.XmlResolver = new XmlUrlResolver();
            xs.Add(s);

            return new XmlQualifiedName("songStream", ns);
        }

        void IXmlSerializable.WriteXml(XmlWriter writer) 
        {
      writer.WriteStartElement 
         ("employee", "urn:devx-com") ;      
      writer.WriteAttributeString 
         ("firstName", _firstName);        
      writer.WriteAttributeString 
         ("lastName", _lastName)  ;   
      writer.WriteAttributeString 
         ("address", _address);
      writer.WriteEndElement();
            return;
        }

        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        void IXmlSerializable.ReadXml(System.Xml.XmlReader reader)
    {
     throw new System.NotImplementedException();

    }
    }
}
