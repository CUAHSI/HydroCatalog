using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;

namespace cuahsi.his.WaterService.Service
{
    namespace Schema.Utilities
    {

        public class GetResponseElements
        {
            public class Response
            {
                public string Xml;
                public string prefix;
                public string namespaceUri;
                public IDictionary<string, string> namespaces;
                public bool isDefault; 

            }
            public static Response StripResponseElement(string element, XmlReader reader)
            {
                
                reader.MoveToContent();
                
 // get namespace
                string prefix = reader.Prefix;
                string nsUri = reader.NamespaceURI;
                if (reader.LocalName.Equals(element)){

                string xml = reader.ReadInnerXml();
                    

                Response res = new Response();
                res.Xml = xml;
                res.prefix = prefix;
              //  res.namespaces = namespaces;
                    res.namespaceUri = nsUri;
                    res.isDefault = reader.IsDefault;
                    // dispose of reader
                    reader.Close();
                return res;
                } else
                {
                    reader.Close(); 
                    return null;
                }


            }

           
        }
    }
}
