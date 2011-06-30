using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace cuahsi.his.schema
{
    namespace Abstract {
        namespace v1_0 {
              [XmlRoot(ElementName = "variablesResponse",
                Namespace = Constants.v1.ServiceDescriptions.XML_SCHEMA_NAMSPACE)]
    public  interface VariablesResponseType{}

              [XmlRoot(ElementName = "sitesResponse",
                      Namespace = Constants.v1.ServiceDescriptions.XML_SCHEMA_NAMSPACE)]
              public interface SiteInfoResponseType { }

              [XmlRoot(ElementName = "timeSeriesResponse",
                      Namespace = Constants.v1.ServiceDescriptions.XML_SCHEMA_NAMSPACE)]
              public interface TimeSeriesResponseType { }
    }
        namespace v1_1
        {
            [XmlRoot(ElementName = "variablesResponse",
                Namespace = Constants.v1_1.ServiceDescriptions.XML_SCHEMA_NAMSPACE)]
            public interface VariablesResponseType { }
            [XmlRoot(ElementName = "sitesResponse",
                      Namespace = Constants.v1_1.ServiceDescriptions.XML_SCHEMA_NAMSPACE)]
            public interface SiteInfoResponseType { }
            [XmlRoot(ElementName = "timeSeriesResponse",
                      Namespace = Constants.v1_1.ServiceDescriptions.XML_SCHEMA_NAMSPACE)]
            public interface TimeSeriesResponseType { }
        }
    
    }
}
