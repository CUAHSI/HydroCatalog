
package unitvalues;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for GetSiteInfoResponse element declaration.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;element name="GetSiteInfoResponse">
 *   &lt;complexType>
 *     &lt;complexContent>
 *       &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *         &lt;sequence>
 *           &lt;element name="GetSiteInfoResult" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
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
    "getSiteInfoResult"
})
@XmlRootElement(name = "GetSiteInfoResponse", namespace = "http://www.cuahsi.org/his/1.0/ws/")
public class GetSiteInfoResponse {

    @XmlElement(name = "GetSiteInfoResult", namespace = "http://www.cuahsi.org/his/1.0/ws/")
    protected String getSiteInfoResult;

    /**
     * Gets the value of the getSiteInfoResult property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getGetSiteInfoResult() {
        return getSiteInfoResult;
    }

    /**
     * Sets the value of the getSiteInfoResult property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setGetSiteInfoResult(String value) {
        this.getSiteInfoResult = value;
    }

}
