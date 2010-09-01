
package unitvalues;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for GetVariableInfoResponse element declaration.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;element name="GetVariableInfoResponse">
 *   &lt;complexType>
 *     &lt;complexContent>
 *       &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *         &lt;sequence>
 *           &lt;element name="GetVariableInfoResult" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;/sequence>
 *       &lt;/restriction>
 *     &lt;/complexContent>
 *   &lt;/complexType>
 * &lt;/element>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "", propOrder = {
    "getVariableInfoResult"
})
@XmlRootElement(name = "GetVariableInfoResponse", namespace = "http://www.cuahsi.org/his/1.0/ws/")
public class GetVariableInfoResponse {

    @XmlElement(name = "GetVariableInfoResult", namespace = "http://www.cuahsi.org/his/1.0/ws/")
    protected String getVariableInfoResult;

    /**
     * Gets the value of the getVariableInfoResult property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getGetVariableInfoResult() {
        return getVariableInfoResult;
    }

    /**
     * Sets the value of the getVariableInfoResult property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setGetVariableInfoResult(String value) {
        this.getVariableInfoResult = value;
    }

}
