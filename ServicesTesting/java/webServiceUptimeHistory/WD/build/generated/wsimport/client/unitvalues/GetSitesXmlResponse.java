
package unitvalues;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for GetSitesXmlResponse element declaration.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;element name="GetSitesXmlResponse">
 *   &lt;complexType>
 *     &lt;complexContent>
 *       &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *         &lt;sequence>
 *           &lt;element name="GetSitesXmlResult" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
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
    "getSitesXmlResult"
})
@XmlRootElement(name = "GetSitesXmlResponse", namespace = "http://www.cuahsi.org/his/1.0/ws/")
public class GetSitesXmlResponse {

    @XmlElement(name = "GetSitesXmlResult", namespace = "http://www.cuahsi.org/his/1.0/ws/")
    protected String getSitesXmlResult;

    /**
     * Gets the value of the getSitesXmlResult property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getGetSitesXmlResult() {
        return getSitesXmlResult;
    }

    /**
     * Sets the value of the getSitesXmlResult property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setGetSitesXmlResult(String value) {
        this.getSitesXmlResult = value;
    }

}
