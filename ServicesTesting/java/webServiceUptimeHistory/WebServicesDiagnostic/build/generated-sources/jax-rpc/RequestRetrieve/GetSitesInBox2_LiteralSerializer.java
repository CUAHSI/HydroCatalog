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

public class GetSitesInBox2_LiteralSerializer extends LiteralObjectSerializerBase implements Initializable  {
    private static final javax.xml.namespace.QName ns1_xmin_QNAME = new QName("http://hiscentral.cuahsi.org/20100205/", "xmin");
    private static final javax.xml.namespace.QName ns2_double_TYPE_QNAME = SchemaConstants.QNAME_TYPE_DOUBLE;
    private CombinedSerializer ns2_myns2__double__double_Double_Serializer;
    private static final javax.xml.namespace.QName ns1_xmax_QNAME = new QName("http://hiscentral.cuahsi.org/20100205/", "xmax");
    private static final javax.xml.namespace.QName ns1_ymin_QNAME = new QName("http://hiscentral.cuahsi.org/20100205/", "ymin");
    private static final javax.xml.namespace.QName ns1_ymax_QNAME = new QName("http://hiscentral.cuahsi.org/20100205/", "ymax");
    private static final javax.xml.namespace.QName ns1_conceptKeyword_QNAME = new QName("http://hiscentral.cuahsi.org/20100205/", "conceptKeyword");
    private static final javax.xml.namespace.QName ns2_string_TYPE_QNAME = SchemaConstants.QNAME_TYPE_STRING;
    private CombinedSerializer ns2_myns2_string__java_lang_String_String_Serializer;
    private static final javax.xml.namespace.QName ns1_networkIDs_QNAME = new QName("http://hiscentral.cuahsi.org/20100205/", "networkIDs");
    
    public GetSitesInBox2_LiteralSerializer(javax.xml.namespace.QName type, java.lang.String encodingStyle) {
        this(type, encodingStyle, false);
    }
    
    public GetSitesInBox2_LiteralSerializer(javax.xml.namespace.QName type, java.lang.String encodingStyle, boolean encodeType) {
        super(type, true, encodingStyle, encodeType);
    }
    
    public void initialize(InternalTypeMappingRegistry registry) throws Exception {
        ns2_myns2__double__double_Double_Serializer = (CombinedSerializer)registry.getSerializer("", double.class, ns2_double_TYPE_QNAME);
        ns2_myns2_string__java_lang_String_String_Serializer = (CombinedSerializer)registry.getSerializer("", java.lang.String.class, ns2_string_TYPE_QNAME);
    }
    
    public java.lang.Object doDeserialize(XMLReader reader,
        SOAPDeserializationContext context) throws java.lang.Exception {
        RequestRetrieve.GetSitesInBox2 instance = new RequestRetrieve.GetSitesInBox2();
        java.lang.Object member=null;
        javax.xml.namespace.QName elementName;
        java.util.List values;
        java.lang.Object value;
        
        reader.nextElementContent();
        elementName = reader.getName();
        if (reader.getState() == XMLReader.START) {
            if (elementName.equals(ns1_xmin_QNAME)) {
                member = ns2_myns2__double__double_Double_Serializer.deserialize(ns1_xmin_QNAME, reader, context);
                if (member == null) {
                    throw new DeserializationException("literal.unexpectedNull");
                }
                instance.setXmin(((Double)member).doubleValue());
                reader.nextElementContent();
            } else {
                throw new DeserializationException("literal.unexpectedElementName", new Object[] { ns1_xmin_QNAME, reader.getName() });
            }
        }
        else {
            throw new DeserializationException("literal.expectedElementName", reader.getName().toString());
        }
        elementName = reader.getName();
        if (reader.getState() == XMLReader.START) {
            if (elementName.equals(ns1_xmax_QNAME)) {
                member = ns2_myns2__double__double_Double_Serializer.deserialize(ns1_xmax_QNAME, reader, context);
                if (member == null) {
                    throw new DeserializationException("literal.unexpectedNull");
                }
                instance.setXmax(((Double)member).doubleValue());
                reader.nextElementContent();
            } else {
                throw new DeserializationException("literal.unexpectedElementName", new Object[] { ns1_xmax_QNAME, reader.getName() });
            }
        }
        else {
            throw new DeserializationException("literal.expectedElementName", reader.getName().toString());
        }
        elementName = reader.getName();
        if (reader.getState() == XMLReader.START) {
            if (elementName.equals(ns1_ymin_QNAME)) {
                member = ns2_myns2__double__double_Double_Serializer.deserialize(ns1_ymin_QNAME, reader, context);
                if (member == null) {
                    throw new DeserializationException("literal.unexpectedNull");
                }
                instance.setYmin(((Double)member).doubleValue());
                reader.nextElementContent();
            } else {
                throw new DeserializationException("literal.unexpectedElementName", new Object[] { ns1_ymin_QNAME, reader.getName() });
            }
        }
        else {
            throw new DeserializationException("literal.expectedElementName", reader.getName().toString());
        }
        elementName = reader.getName();
        if (reader.getState() == XMLReader.START) {
            if (elementName.equals(ns1_ymax_QNAME)) {
                member = ns2_myns2__double__double_Double_Serializer.deserialize(ns1_ymax_QNAME, reader, context);
                if (member == null) {
                    throw new DeserializationException("literal.unexpectedNull");
                }
                instance.setYmax(((Double)member).doubleValue());
                reader.nextElementContent();
            } else {
                throw new DeserializationException("literal.unexpectedElementName", new Object[] { ns1_ymax_QNAME, reader.getName() });
            }
        }
        else {
            throw new DeserializationException("literal.expectedElementName", reader.getName().toString());
        }
        elementName = reader.getName();
        if (reader.getState() == XMLReader.START) {
            if (elementName.equals(ns1_conceptKeyword_QNAME)) {
                member = ns2_myns2_string__java_lang_String_String_Serializer.deserialize(ns1_conceptKeyword_QNAME, reader, context);
                if (member == null) {
                    throw new DeserializationException("literal.unexpectedNull");
                }
                instance.setConceptKeyword((java.lang.String)member);
                reader.nextElementContent();
            }
        }
        elementName = reader.getName();
        if (reader.getState() == XMLReader.START) {
            if (elementName.equals(ns1_networkIDs_QNAME)) {
                member = ns2_myns2_string__java_lang_String_String_Serializer.deserialize(ns1_networkIDs_QNAME, reader, context);
                if (member == null) {
                    throw new DeserializationException("literal.unexpectedNull");
                }
                instance.setNetworkIDs((java.lang.String)member);
                reader.nextElementContent();
            }
        }
        
        XMLReaderUtil.verifyReaderState(reader, XMLReader.END);
        return (java.lang.Object)instance;
    }
    
    public void doSerializeAttributes(java.lang.Object obj, XMLWriter writer, SOAPSerializationContext context) throws java.lang.Exception {
        RequestRetrieve.GetSitesInBox2 instance = (RequestRetrieve.GetSitesInBox2)obj;
        
    }
    public void doSerialize(java.lang.Object obj, XMLWriter writer, SOAPSerializationContext context) throws java.lang.Exception {
        RequestRetrieve.GetSitesInBox2 instance = (RequestRetrieve.GetSitesInBox2)obj;
        
        if (new Double(instance.getXmin()) == null) {
            throw new SerializationException("literal.unexpectedNull");
        }
        ns2_myns2__double__double_Double_Serializer.serialize(new Double(instance.getXmin()), ns1_xmin_QNAME, null, writer, context);
        if (new Double(instance.getXmax()) == null) {
            throw new SerializationException("literal.unexpectedNull");
        }
        ns2_myns2__double__double_Double_Serializer.serialize(new Double(instance.getXmax()), ns1_xmax_QNAME, null, writer, context);
        if (new Double(instance.getYmin()) == null) {
            throw new SerializationException("literal.unexpectedNull");
        }
        ns2_myns2__double__double_Double_Serializer.serialize(new Double(instance.getYmin()), ns1_ymin_QNAME, null, writer, context);
        if (new Double(instance.getYmax()) == null) {
            throw new SerializationException("literal.unexpectedNull");
        }
        ns2_myns2__double__double_Double_Serializer.serialize(new Double(instance.getYmax()), ns1_ymax_QNAME, null, writer, context);
        if (instance.getConceptKeyword() != null) {
            ns2_myns2_string__java_lang_String_String_Serializer.serialize(instance.getConceptKeyword(), ns1_conceptKeyword_QNAME, null, writer, context);
        }
        if (instance.getNetworkIDs() != null) {
            ns2_myns2_string__java_lang_String_String_Serializer.serialize(instance.getNetworkIDs(), ns1_networkIDs_QNAME, null, writer, context);
        }
    }
}
