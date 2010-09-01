// This class was generated by the JAXRPC SI, do not edit.
// Contents subject to change without notice.
// JAX-RPC Standard Implementation (1.1.3, build R1)
// Generated source version: 1.1.3

package RequestRetrieve;

import com.sun.xml.rpc.encoding.*;
import com.sun.xml.rpc.encoding.xsd.XSDConstants;
import com.sun.xml.rpc.encoding.literal.*;
import com.sun.xml.rpc.encoding.literal.DetailFragmentDeserializer;
import com.sun.xml.rpc.encoding.simpletype.*;
import com.sun.xml.rpc.encoding.soap.SOAPConstants;
import com.sun.xml.rpc.encoding.soap.SOAP12Constants;
import com.sun.xml.rpc.streaming.*;
import com.sun.xml.rpc.wsdl.document.schema.SchemaConstants;
import javax.xml.namespace.QName;
import java.util.List;
import java.util.ArrayList;

public class GetSitesInBoxResponse_LiteralSerializer extends LiteralObjectSerializerBase implements Initializable  {
    private static final javax.xml.namespace.QName ns1_GetSitesInBoxResult_QNAME = new QName("http://hiscentral.cuahsi.org/20100205/", "GetSitesInBoxResult");
    private static final javax.xml.namespace.QName ns1_ArrayOfSite_TYPE_QNAME = new QName("http://hiscentral.cuahsi.org/20100205/", "ArrayOfSite");
    private CombinedSerializer ns1_myArrayOfSite_LiteralSerializer;
    
    public GetSitesInBoxResponse_LiteralSerializer(javax.xml.namespace.QName type, java.lang.String encodingStyle) {
        this(type, encodingStyle, false);
    }
    
    public GetSitesInBoxResponse_LiteralSerializer(javax.xml.namespace.QName type, java.lang.String encodingStyle, boolean encodeType) {
        super(type, true, encodingStyle, encodeType);
    }
    
    public void initialize(InternalTypeMappingRegistry registry) throws Exception {
        ns1_myArrayOfSite_LiteralSerializer = (CombinedSerializer)registry.getSerializer("", RequestRetrieve.ArrayOfSite.class, ns1_ArrayOfSite_TYPE_QNAME);
    }
    
    public java.lang.Object doDeserialize(XMLReader reader,
        SOAPDeserializationContext context) throws java.lang.Exception {
        RequestRetrieve.GetSitesInBoxResponse instance = new RequestRetrieve.GetSitesInBoxResponse();
        java.lang.Object member=null;
        javax.xml.namespace.QName elementName;
        java.util.List values;
        java.lang.Object value;
        
        reader.nextElementContent();
        elementName = reader.getName();
        if (reader.getState() == XMLReader.START) {
            if (elementName.equals(ns1_GetSitesInBoxResult_QNAME)) {
                member = ns1_myArrayOfSite_LiteralSerializer.deserialize(ns1_GetSitesInBoxResult_QNAME, reader, context);
                if (member == null) {
                    throw new DeserializationException("literal.unexpectedNull");
                }
                instance.setGetSitesInBoxResult((RequestRetrieve.ArrayOfSite)member);
                reader.nextElementContent();
            }
        }
        
        XMLReaderUtil.verifyReaderState(reader, XMLReader.END);
        return (java.lang.Object)instance;
    }
    
    public void doSerializeAttributes(java.lang.Object obj, XMLWriter writer, SOAPSerializationContext context) throws java.lang.Exception {
        RequestRetrieve.GetSitesInBoxResponse instance = (RequestRetrieve.GetSitesInBoxResponse)obj;
        
    }
    public void doSerialize(java.lang.Object obj, XMLWriter writer, SOAPSerializationContext context) throws java.lang.Exception {
        RequestRetrieve.GetSitesInBoxResponse instance = (RequestRetrieve.GetSitesInBoxResponse)obj;
        
        if (instance.getGetSitesInBoxResult() != null) {
            ns1_myArrayOfSite_LiteralSerializer.serialize(instance.getGetSitesInBoxResult(), ns1_GetSitesInBoxResult_QNAME, null, writer, context);
        }
    }
}
