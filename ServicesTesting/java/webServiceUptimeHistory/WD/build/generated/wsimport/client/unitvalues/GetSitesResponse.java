
package unitvalues;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for GetSitesResponse element declaration.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;element name="GetSitesResponse">
 *   &lt;complexType>
 *     &lt;complexContent>
 *       &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *         &lt;sequence>
 *           &lt;element ref="{http://www.cuahsi.org/waterML/1.0/}sitesResponse" minOccurs="0"/>
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
    "sitesResponse"
})
@XmlRootElement(name = "GetSitesResponse", namespace = "http://www.cuahsi.org/his/1.0/ws/")
public class GetSitesResponse {

    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected SiteInfoResponseType sitesResponse;

    /**
     * Gets the value of the sitesResponse property.
     * 
     * @return
     *     possible object is
     *     {@link SiteInfoResponseType }
     *     
     */
    public SiteInfoResponseType getSitesResponse() {
        return sitesResponse;
    }

    /**
     * Sets the value of the sitesResponse property.
     * 
     * @param value
     *     allowed object is
     *     {@link SiteInfoResponseType }
     *     
     */
    public void setSitesResponse(SiteInfoResponseType value) {
        this.sitesResponse = value;
    }

}
