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

public class GetOntologyTreeResponse_LiteralSerializer extends LiteralObjectSerializerBase implements Initializable  {
    private static final javax.xml.namespace.QName ns1_getOntologyTreeResult_QNAME = new QName("http://hiscentral.cuahsi.org/20100205/", "getOntologyTreeResult");
    private static final javax.xml.namespace.QName ns1_OntologyNode_TYPE_QNAME = new QName("http://hiscentral.cuahsi.org/20100205/", "OntologyNode");
    private CombinedSerializer ns1_myOntologyNode_LiteralSerializer;
    
    public GetOntologyTreeResponse_LiteralSerializer(javax.xml.namespace.QName type, java.lang.String encodingStyle) {
        this(type, encodingStyle, false);
    }
    
    public GetOntologyTreeResponse_LiteralSerializer(javax.xml.namespace.QName type, java.lang.String encodingStyle, boolean encodeType) {
        super(type, true, encodingStyle, encodeType);
    }
    
    public void initialize(InternalTypeMappingRegistry registry) throws Exception {
        ns1_myOntologyNode_LiteralSerializer = (CombinedSerializer)registry.getSerializer("", RequestRetrieve.OntologyNode.class, ns1_OntologyNode_TYPE_QNAME);
    }
    
    public java.lang.Object doDeserialize(XMLReader reader,
        SOAPDeserializationContext context) throws java.lang.Exception {
        RequestRetrieve.GetOntologyTreeResponse instance = new RequestRetrieve.GetOntologyTreeResponse();
        java.lang.Object member=null;
        javax.xml.namespace.QName elementName;
        java.util.List values;
        java.lang.Object value;
        
        reader.nextElementContent();
        elementName = reader.getName();
        if (reader.getState() == XMLReader.START) {
            if (elementName.equals(ns1_getOntologyTreeResult_QNAME)) {
                member = ns1_myOntologyNode_LiteralSerializer.deserialize(ns1_getOntologyTreeResult_QNAME, reader, context);
                if (member == null) {
                    throw new DeserializationException("literal.unexpectedNull");
                }
                instance.setGetOntologyTreeResult((RequestRetrieve.OntologyNode)member);
                reader.nextElementContent();
            } else {
                throw new DeserializationException("literal.unexpectedElementName", new Object[] { ns1_getOntologyTreeResult_QNAME, reader.getName() });
            }
        }
        else {
            throw new DeserializationException("literal.expectedElementName", reader.getName().toString());
        }
        
        XMLReaderUtil.verifyReaderState(reader, XMLReader.END);
        return (java.lang.Object)instance;
    }
    
    public void doSerializeAttributes(java.lang.Object obj, XMLWriter writer, SOAPSerializationContext context) throws java.lang.Exception {
        RequestRetrieve.GetOntologyTreeResponse instance = (RequestRetrieve.GetOntologyTreeResponse)obj;
        
    }
    public void doSerialize(java.lang.Object obj, XMLWriter writer, SOAPSerializationContext context) throws java.lang.Exception {
        RequestRetrieve.GetOntologyTreeResponse instance = (RequestRetrieve.GetOntologyTreeResponse)obj;
        
        if (instance.getGetOntologyTreeResult() == null) {
            throw new SerializationException("literal.unexpectedNull");
        }
        ns1_myOntologyNode_LiteralSerializer.serialize(instance.getGetOntologyTreeResult(), ns1_getOntologyTreeResult_QNAME, null, writer, context);
    }
}
