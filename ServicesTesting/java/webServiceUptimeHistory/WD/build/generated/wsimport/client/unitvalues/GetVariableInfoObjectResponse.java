
package unitvalues;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for GetVariableInfoObjectResponse element declaration.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;element name="GetVariableInfoObjectResponse">
 *   &lt;complexType>
 *     &lt;complexContent>
 *       &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *         &lt;sequence>
 *           &lt;element ref="{http://www.cuahsi.org/waterML/1.0/}variablesResponse" minOccurs="0"/>
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
    "variablesResponse"
})
@XmlRootElement(name = "GetVariableInfoObjectResponse", namespace = "http://www.cuahsi.org/his/1.0/ws/")
public class GetVariableInfoObjectResponse {

    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected VariablesResponseType variablesResponse;

    /**
     * Gets the value of the variablesResponse property.
     * 
     * @return
     *     possible object is
     *     {@link VariablesResponseType }
     *     
     */
    public VariablesResponseType getVariablesResponse() {
        return variablesResponse;
    }

    /**
     * Sets the value of the variablesResponse property.
     * 
     * @param value
     *     allowed object is
     *     {@link VariablesResponseType }
     *     
     */
    public void setVariablesResponse(VariablesResponseType value) {
        this.variablesResponse = value;
    }

}
