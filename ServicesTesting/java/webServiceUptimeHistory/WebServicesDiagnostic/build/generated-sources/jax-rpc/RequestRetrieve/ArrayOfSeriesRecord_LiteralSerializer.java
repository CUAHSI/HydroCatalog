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

public class ArrayOfSeriesRecord_LiteralSerializer extends LiteralObjectSerializerBase implements Initializable  {
    private static final javax.xml.namespace.QName ns1_SeriesRecord_QNAME = new QName("http://hiscentral.cuahsi.org/20100205/", "SeriesRecord");
    private static final javax.xml.namespace.QName ns1_SeriesRecord_TYPE_QNAME = new QName("http://hiscentral.cuahsi.org/20100205/", "SeriesRecord");
    private CombinedSerializer ns1_mySeriesRecord_LiteralSerializer;
    
    public ArrayOfSeriesRecord_LiteralSerializer(javax.xml.namespace.QName type, java.lang.String encodingStyle) {
        this(type, encodingStyle, false);
    }
    
    public ArrayOfSeriesRecord_LiteralSerializer(javax.xml.namespace.QName type, java.lang.String encodingStyle, boolean encodeType) {
        super(type, true, encodingStyle, encodeType);
    }
    
    public void initialize(InternalTypeMappingRegistry registry) throws Exception {
        ns1_mySeriesRecord_LiteralSerializer = (CombinedSerializer)registry.getSerializer("", RequestRetrieve.SeriesRecord.class, ns1_SeriesRecord_TYPE_QNAME);
    }
    
    public java.lang.Object doDeserialize(XMLReader reader,
        SOAPDeserializationContext context) throws java.lang.Exception {
        RequestRetrieve.ArrayOfSeriesRecord instance = new RequestRetrieve.ArrayOfSeriesRecord();
        java.lang.Object member=null;
        javax.xml.namespace.QName elementName;
        java.util.List values;
        java.lang.Object value;
        
        reader.nextElementContent();
        elementName = reader.getName();
        if ((reader.getState() == XMLReader.START) && (elementName.equals(ns1_SeriesRecord_QNAME))) {
            values = new ArrayList();
            for(;;) {
                elementName = reader.getName();
                if ((reader.getState() == XMLReader.START) && (elementName.equals(ns1_SeriesRecord_QNAME))) {
                    value = ns1_mySeriesRecord_LiteralSerializer.deserialize(ns1_SeriesRecord_QNAME, reader, context);
                    if (value == null) {
                        throw new DeserializationException("literal.unexpectedNull");
                    }
                    values.add(value);
                    reader.nextElementContent();
                } else {
                    break;
                }
            }
            member = new RequestRetrieve.SeriesRecord[values.size()];
            member = values.toArray((Object[]) member);
            instance.setSeriesRecord((RequestRetrieve.SeriesRecord[])member);
        }
        else {
            instance.setSeriesRecord(new RequestRetrieve.SeriesRecord[0]);
        }
        
        XMLReaderUtil.verifyReaderState(reader, XMLReader.END);
        return (java.lang.Object)instance;
    }
    
    public void doSerializeAttributes(java.lang.Object obj, XMLWriter writer, SOAPSerializationContext context) throws java.lang.Exception {
        RequestRetrieve.ArrayOfSeriesRecord instance = (RequestRetrieve.ArrayOfSeriesRecord)obj;
        
    }
    public void doSerialize(java.lang.Object obj, XMLWriter writer, SOAPSerializationContext context) throws java.lang.Exception {
        RequestRetrieve.ArrayOfSeriesRecord instance = (RequestRetrieve.ArrayOfSeriesRecord)obj;
        
        if (instance.getSeriesRecord() != null) {
            for (int i = 0; i < instance.getSeriesRecord().length; ++i) {
                ns1_mySeriesRecord_LiteralSerializer.serialize(instance.getSeriesRecord()[i], ns1_SeriesRecord_QNAME, null, writer, context);
            }
        }
    }
}
