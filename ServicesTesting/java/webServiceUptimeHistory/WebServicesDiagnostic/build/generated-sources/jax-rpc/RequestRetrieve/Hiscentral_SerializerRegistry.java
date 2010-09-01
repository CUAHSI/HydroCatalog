// This class was generated by the JAXRPC SI, do not edit.
// Contents subject to change without notice.
// JAX-RPC Standard Implementation (1.1.3, build R1)
// Generated source version: 1.1.3

package RequestRetrieve;

import com.sun.xml.rpc.client.BasicService;
import com.sun.xml.rpc.encoding.*;
import com.sun.xml.rpc.encoding.simpletype.*;
import com.sun.xml.rpc.encoding.soap.*;
import com.sun.xml.rpc.encoding.literal.*;
import com.sun.xml.rpc.soap.SOAPVersion;
import com.sun.xml.rpc.wsdl.document.schema.SchemaConstants;
import javax.xml.rpc.*;
import javax.xml.rpc.encoding.*;
import javax.xml.namespace.QName;

public class Hiscentral_SerializerRegistry implements SerializerConstants {
    public Hiscentral_SerializerRegistry() {
    }
    
    public TypeMappingRegistry getRegistry() {
        
        TypeMappingRegistry registry = BasicService.createStandardTypeMappingRegistry();
        TypeMapping mapping12 = registry.getTypeMapping(SOAP12Constants.NS_SOAP_ENCODING);
        TypeMapping mapping = registry.getTypeMapping(SOAPConstants.NS_SOAP_ENCODING);
        TypeMapping mapping2 = registry.getTypeMapping("");
        {
            QName type = new QName("http://hiscentral.cuahsi.org/20100205/", "ArrayOfServiceInfo");
            CombinedSerializer serializer = new RequestRetrieve.ArrayOfServiceInfo_LiteralSerializer(type, "", DONT_ENCODE_TYPE);
            registerSerializer(mapping2,RequestRetrieve.ArrayOfServiceInfo.class, type, serializer);
        }
        {
            QName type = new QName("http://hiscentral.cuahsi.org/20100205/", "GetMappedVariablesResponse");
            CombinedSerializer serializer = new RequestRetrieve.GetMappedVariablesResponse_LiteralSerializer(type, "", DONT_ENCODE_TYPE);
            registerSerializer(mapping2,RequestRetrieve.GetMappedVariablesResponse.class, type, serializer);
        }
        {
            QName type = new QName("http://hiscentral.cuahsi.org/20100205/", "GetSitesInBox2");
            CombinedSerializer serializer = new RequestRetrieve.GetSitesInBox2_LiteralSerializer(type, "", DONT_ENCODE_TYPE);
            registerSerializer(mapping2,RequestRetrieve.GetSitesInBox2.class, type, serializer);
        }
        {
            QName type = new QName("http://hiscentral.cuahsi.org/20100205/", "GetMappedVariables");
            CombinedSerializer serializer = new RequestRetrieve.GetMappedVariables_LiteralSerializer(type, "", DONT_ENCODE_TYPE);
            registerSerializer(mapping2,RequestRetrieve.GetMappedVariables.class, type, serializer);
        }
        {
            QName type = new QName("http://hiscentral.cuahsi.org/20100205/", "ArrayOfString");
            CombinedSerializer serializer = new RequestRetrieve.ArrayOfString_LiteralSerializer(type, "", DONT_ENCODE_TYPE);
            registerSerializer(mapping2,RequestRetrieve.ArrayOfString.class, type, serializer);
        }
        {
            QName type = new QName("http://hiscentral.cuahsi.org/20100205/", "ArrayOfMappedVariable");
            CombinedSerializer serializer = new RequestRetrieve.ArrayOfMappedVariable_LiteralSerializer(type, "", DONT_ENCODE_TYPE);
            registerSerializer(mapping2,RequestRetrieve.ArrayOfMappedVariable.class, type, serializer);
        }
        {
            QName type = new QName("http://hiscentral.cuahsi.org/20100205/", "ArrayOfSeriesRecord");
            CombinedSerializer serializer = new RequestRetrieve.ArrayOfSeriesRecord_LiteralSerializer(type, "", DONT_ENCODE_TYPE);
            registerSerializer(mapping2,RequestRetrieve.ArrayOfSeriesRecord.class, type, serializer);
        }
        {
            QName type = new QName("http://hiscentral.cuahsi.org/20100205/", "getOntologyTreeResponse");
            CombinedSerializer serializer = new RequestRetrieve.GetOntologyTreeResponse_LiteralSerializer(type, "", DONT_ENCODE_TYPE);
            registerSerializer(mapping2,RequestRetrieve.GetOntologyTreeResponse.class, type, serializer);
        }
        {
            QName type = new QName("http://hiscentral.cuahsi.org/20100205/", "GetSeriesCatalogForBox");
            CombinedSerializer serializer = new RequestRetrieve.GetSeriesCatalogForBox_LiteralSerializer(type, "", DONT_ENCODE_TYPE);
            registerSerializer(mapping2,RequestRetrieve.GetSeriesCatalogForBox.class, type, serializer);
        }
        {
            QName type = new QName("http://hiscentral.cuahsi.org/20100205/", "GetWaterOneFlowServiceInfo");
            CombinedSerializer serializer = new RequestRetrieve.GetWaterOneFlowServiceInfo_LiteralSerializer(type, "", DONT_ENCODE_TYPE);
            registerSerializer(mapping2,RequestRetrieve.GetWaterOneFlowServiceInfo.class, type, serializer);
        }
        {
            QName type = new QName("http://hiscentral.cuahsi.org/20100205/", "ArrayOfSite");
            CombinedSerializer serializer = new RequestRetrieve.ArrayOfSite_LiteralSerializer(type, "", DONT_ENCODE_TYPE);
            registerSerializer(mapping2,RequestRetrieve.ArrayOfSite.class, type, serializer);
        }
        {
            QName type = new QName("http://hiscentral.cuahsi.org/20100205/", "ArrayOfInt");
            CombinedSerializer serializer = new RequestRetrieve.ArrayOfInt_LiteralSerializer(type, "", DONT_ENCODE_TYPE);
            registerSerializer(mapping2,RequestRetrieve.ArrayOfInt.class, type, serializer);
        }
        {
            QName type = new QName("http://hiscentral.cuahsi.org/20100205/", "OntologyNode");
            CombinedSerializer serializer = new RequestRetrieve.OntologyNode_LiteralSerializer(type, "", DONT_ENCODE_TYPE);
            registerSerializer(mapping2,RequestRetrieve.OntologyNode.class, type, serializer);
        }
        {
            QName type = new QName("http://hiscentral.cuahsi.org/20100205/", "GetServicesInBox");
            CombinedSerializer serializer = new RequestRetrieve.GetServicesInBox_LiteralSerializer(type, "", DONT_ENCODE_TYPE);
            registerSerializer(mapping2,RequestRetrieve.GetServicesInBox.class, type, serializer);
        }
        {
            QName type = new QName("http://hiscentral.cuahsi.org/20100205/", "ArrayOfOntologyNode");
            CombinedSerializer serializer = new RequestRetrieve.ArrayOfOntologyNode_LiteralSerializer(type, "", DONT_ENCODE_TYPE);
            registerSerializer(mapping2,RequestRetrieve.ArrayOfOntologyNode.class, type, serializer);
        }
        {
            QName type = new QName("http://hiscentral.cuahsi.org/20100205/", "GetMappedVariables2");
            CombinedSerializer serializer = new RequestRetrieve.GetMappedVariables2_LiteralSerializer(type, "", DONT_ENCODE_TYPE);
            registerSerializer(mapping2,RequestRetrieve.GetMappedVariables2.class, type, serializer);
        }
        {
            QName type = new QName("http://hiscentral.cuahsi.org/20100205/", "SeriesRecord");
            CombinedSerializer serializer = new RequestRetrieve.SeriesRecord_LiteralSerializer(type, "", DONT_ENCODE_TYPE);
            registerSerializer(mapping2,RequestRetrieve.SeriesRecord.class, type, serializer);
        }
        {
            QName type = new QName("http://hiscentral.cuahsi.org/20100205/", "GetSearchableConcepts");
            CombinedSerializer serializer = new RequestRetrieve.GetSearchableConcepts_LiteralSerializer(type, "", DONT_ENCODE_TYPE);
            registerSerializer(mapping2,RequestRetrieve.GetSearchableConcepts.class, type, serializer);
        }
        {
            QName type = new QName("http://hiscentral.cuahsi.org/20100205/", "Box");
            CombinedSerializer serializer = new RequestRetrieve.Box_LiteralSerializer(type, "", DONT_ENCODE_TYPE);
            registerSerializer(mapping2,RequestRetrieve.Box.class, type, serializer);
        }
        {
            QName type = new QName("http://hiscentral.cuahsi.org/20100205/", "GetSitesInBox2Response");
            CombinedSerializer serializer = new RequestRetrieve.GetSitesInBox2Response_LiteralSerializer(type, "", DONT_ENCODE_TYPE);
            registerSerializer(mapping2,RequestRetrieve.GetSitesInBox2Response.class, type, serializer);
        }
        {
            QName type = new QName("http://hiscentral.cuahsi.org/20100205/", "Site");
            CombinedSerializer serializer = new RequestRetrieve.Site_LiteralSerializer(type, "", DONT_ENCODE_TYPE);
            registerSerializer(mapping2,RequestRetrieve.Site.class, type, serializer);
        }
        {
            QName type = new QName("http://hiscentral.cuahsi.org/20100205/", "GetSearchableConceptsResponse");
            CombinedSerializer serializer = new RequestRetrieve.GetSearchableConceptsResponse_LiteralSerializer(type, "", DONT_ENCODE_TYPE);
            registerSerializer(mapping2,RequestRetrieve.GetSearchableConceptsResponse.class, type, serializer);
        }
        {
            QName type = new QName("http://hiscentral.cuahsi.org/20100205/AbstractTypes", "StringArray");
            CombinedSerializer serializer = new LiteralFragmentSerializer(type, NOT_NULLABLE, "");
            registerSerializer(mapping2,javax.xml.soap.SOAPElement.class, type, serializer);
        }
        {
            QName type = new QName("http://hiscentral.cuahsi.org/20100205/", "MappedVariable");
            CombinedSerializer serializer = new RequestRetrieve.MappedVariable_LiteralSerializer(type, "", DONT_ENCODE_TYPE);
            registerSerializer(mapping2,RequestRetrieve.MappedVariable.class, type, serializer);
        }
        {
            QName type = new QName("http://hiscentral.cuahsi.org/20100205/", "GetServicesInBox2Response");
            CombinedSerializer serializer = new RequestRetrieve.GetServicesInBox2Response_LiteralSerializer(type, "", DONT_ENCODE_TYPE);
            registerSerializer(mapping2,RequestRetrieve.GetServicesInBox2Response.class, type, serializer);
        }
        {
            QName type = new QName("http://hiscentral.cuahsi.org/20100205/", "GetServicesInBox2");
            CombinedSerializer serializer = new RequestRetrieve.GetServicesInBox2_LiteralSerializer(type, "", DONT_ENCODE_TYPE);
            registerSerializer(mapping2,RequestRetrieve.GetServicesInBox2.class, type, serializer);
        }
        {
            QName type = new QName("http://hiscentral.cuahsi.org/20100205/", "GetSitesInBox");
            CombinedSerializer serializer = new RequestRetrieve.GetSitesInBox_LiteralSerializer(type, "", DONT_ENCODE_TYPE);
            registerSerializer(mapping2,RequestRetrieve.GetSitesInBox.class, type, serializer);
        }
        {
            QName type = new QName("http://hiscentral.cuahsi.org/20100205/", "GetSitesInBoxResponse");
            CombinedSerializer serializer = new RequestRetrieve.GetSitesInBoxResponse_LiteralSerializer(type, "", DONT_ENCODE_TYPE);
            registerSerializer(mapping2,RequestRetrieve.GetSitesInBoxResponse.class, type, serializer);
        }
        {
            QName type = new QName("http://hiscentral.cuahsi.org/20100205/", "GetSeriesCatalogForBoxResponse");
            CombinedSerializer serializer = new RequestRetrieve.GetSeriesCatalogForBoxResponse_LiteralSerializer(type, "", DONT_ENCODE_TYPE);
            registerSerializer(mapping2,RequestRetrieve.GetSeriesCatalogForBoxResponse.class, type, serializer);
        }
        {
            QName type = new QName("http://hiscentral.cuahsi.org/20100205/", "GetMappedVariables2Response");
            CombinedSerializer serializer = new RequestRetrieve.GetMappedVariables2Response_LiteralSerializer(type, "", DONT_ENCODE_TYPE);
            registerSerializer(mapping2,RequestRetrieve.GetMappedVariables2Response.class, type, serializer);
        }
        {
            QName type = new QName("http://hiscentral.cuahsi.org/20100205/", "GetServicesInBoxResponse");
            CombinedSerializer serializer = new RequestRetrieve.GetServicesInBoxResponse_LiteralSerializer(type, "", DONT_ENCODE_TYPE);
            registerSerializer(mapping2,RequestRetrieve.GetServicesInBoxResponse.class, type, serializer);
        }
        {
            QName type = new QName("http://hiscentral.cuahsi.org/20100205/", "GetSeriesCatalogForBox2Response");
            CombinedSerializer serializer = new RequestRetrieve.GetSeriesCatalogForBox2Response_LiteralSerializer(type, "", DONT_ENCODE_TYPE);
            registerSerializer(mapping2,RequestRetrieve.GetSeriesCatalogForBox2Response.class, type, serializer);
        }
        {
            QName type = new QName("http://hiscentral.cuahsi.org/20100205/", "getOntologyTree");
            CombinedSerializer serializer = new RequestRetrieve.GetOntologyTree_LiteralSerializer(type, "", DONT_ENCODE_TYPE);
            registerSerializer(mapping2,RequestRetrieve.GetOntologyTree.class, type, serializer);
        }
        {
            QName type = new QName("http://hiscentral.cuahsi.org/20100205/", "GetWordListResponse");
            CombinedSerializer serializer = new RequestRetrieve.GetWordListResponse_LiteralSerializer(type, "", DONT_ENCODE_TYPE);
            registerSerializer(mapping2,RequestRetrieve.GetWordListResponse.class, type, serializer);
        }
        {
            QName type = new QName("http://hiscentral.cuahsi.org/20100205/", "GetWaterOneFlowServiceInfoResponse");
            CombinedSerializer serializer = new RequestRetrieve.GetWaterOneFlowServiceInfoResponse_LiteralSerializer(type, "", DONT_ENCODE_TYPE);
            registerSerializer(mapping2,RequestRetrieve.GetWaterOneFlowServiceInfoResponse.class, type, serializer);
        }
        {
            QName type = new QName("http://hiscentral.cuahsi.org/20100205/", "ServiceInfo");
            CombinedSerializer serializer = new RequestRetrieve.ServiceInfo_LiteralSerializer(type, "", DONT_ENCODE_TYPE);
            registerSerializer(mapping2,RequestRetrieve.ServiceInfo.class, type, serializer);
        }
        {
            QName type = new QName("http://hiscentral.cuahsi.org/20100205/", "GetWordList");
            CombinedSerializer serializer = new RequestRetrieve.GetWordList_LiteralSerializer(type, "", DONT_ENCODE_TYPE);
            registerSerializer(mapping2,RequestRetrieve.GetWordList.class, type, serializer);
        }
        {
            QName type = new QName("http://hiscentral.cuahsi.org/20100205/", "GetSeriesCatalogForBox2");
            CombinedSerializer serializer = new RequestRetrieve.GetSeriesCatalogForBox2_LiteralSerializer(type, "", DONT_ENCODE_TYPE);
            registerSerializer(mapping2,RequestRetrieve.GetSeriesCatalogForBox2.class, type, serializer);
        }
        return registry;
    }
    
    private static void registerSerializer(TypeMapping mapping, java.lang.Class javaType, javax.xml.namespace.QName xmlType,
        Serializer ser) {
        mapping.register(javaType, xmlType, new SingletonSerializerFactory(ser),
            new SingletonDeserializerFactory((Deserializer)ser));
    }
    
}
