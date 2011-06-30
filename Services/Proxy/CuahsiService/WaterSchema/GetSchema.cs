using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Resources;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace cuahsi.his.schema
{

    #region Get Schema
    public class GetSchema
    {
        public static XmlSchema SchemaV1_0()
        {
            return GetResource(Properties.Settings.Default.SchemaResourceNameV1_0);

        }

        public static XmlSchema SchemaV1_1()
        {
            return GetResource(Properties.Settings.Default.SchemaResourceNameV1_1);

        }


       

        public static String SchemaXmlV1_0()
        {
            String r = GetSchemaXmlReader(Properties.Settings.Default.SchemaResourceNameV1_0);
            return r;

        }

        public static string SchemaXmlV1_1()
        {
            return GetSchemaXmlReader(Properties.Settings.Default.SchemaResourceNameV1_1);

        }


       

        private static String GetSchemaXmlReader(String ResourceName)
        {
            ResourceManager rm = Properties.Resources.ResourceManager;
            string xsdResource = (String)rm.GetObject(ResourceName);

            return xsdResource;
        }
        private static XmlSchema GetResource(String ResourceName)
        {
            XmlSerializer schemaSerializer = new XmlSerializer(typeof(XmlSchema));
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("wtr11", Constants.v1_1.ServiceDescriptions.XML_SCHEMA_NAMSPACE);
            ns.Add("wtr10", Constants.v1.ServiceDescriptions.XML_SCHEMA_NAMSPACE);

            string xsdPath = null;

 
            string xsdResource = GetSchemaXmlReader(ResourceName);
            if (xsdResource == null)
            {
                throw new SettingsPropertyNotFoundException("Cannot Read Missing resource from Assembely: cuahsiTimeSeries_v1");
            }
            else
            {
                XmlReader reader;

                StringReader xsd = new StringReader(xsdResource);

                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ValidationType = new ValidationType();
                settings.ValidationType = ValidationType.Schema;
                reader = XmlReader.Create(xsd, settings);

                XmlSchema s = XmlSchema.Read(
 reader, null);

                s.Namespaces.Add("wtr11", Constants.v1_1.ServiceDescriptions.XML_SCHEMA_NAMSPACE );
                s.Namespaces.Add("wtr10",Constants.v1.ServiceDescriptions.XML_SCHEMA_NAMSPACE);


                return s;
            }
        }

    #endregion
    }
}
