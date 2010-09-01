
package unitvalues;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;


/**
 * original sources of the data, providing information sufficient to retrieve and reconstruct the data value from the original data files if necessary
 * 
 * <p>Java class for SourceType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="SourceType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="Organization" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="SourceDescription" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="Metadata" type="{http://www.cuahsi.org/waterML/1.0/}MetaDataType" minOccurs="0"/>
 *         &lt;element name="ContactInformation" type="{http://www.cuahsi.org/waterML/1.0/}ContactInformationType" minOccurs="0"/>
 *         &lt;element name="SourceLink" type="{http://www.w3.org/2001/XMLSchema}anyURI" minOccurs="0"/>
 *       &lt;/sequence>
 *       &lt;attribute name="sourceID" type="{http://www.w3.org/2001/XMLSchema}int" />
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "SourceType", propOrder = {
    "organization",
    "sourceDescription",
    "metadata",
    "contactInformation",
    "sourceLink"
})
public class SourceType {

    @XmlElement(name = "Organization", namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected String organization;
    @XmlElement(name = "SourceDescription", namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected String sourceDescription;
    @XmlElement(name = "Metadata", namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected MetaDataType metadata;
    @XmlElement(name = "ContactInformation", namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected ContactInformationType contactInformation;
    @XmlElement(name = "SourceLink", namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected String sourceLink;
    @XmlAttribute
    protected Integer sourceID;

    /**
     * Gets the value of the organization property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getOrganization() {
        return organization;
    }

    /**
     * Sets the value of the organization property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setOrganization(String value) {
        this.organization = value;
    }

    /**
     * Gets the value of the sourceDescription property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getSourceDescription() {
        return sourceDescription;
    }

    /**
     * Sets the value of the sourceDescription property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setSourceDescription(String value) {
        this.sourceDescription = value;
    }

    /**
     * Gets the value of the metadata property.
     * 
     * @return
     *     possible object is
     *     {@link MetaDataType }
     *     
     */
    public MetaDataType getMetadata() {
        return metadata;
    }

    /**
     * Sets the value of the metadata property.
     * 
     * @param value
     *     allowed object is
     *     {@link MetaDataType }
     *     
     */
    public void setMetadata(MetaDataType value) {
        this.metadata = value;
    }

    /**
     * Gets the value of the contactInformation property.
     * 
     * @return
     *     possible object is
     *     {@link ContactInformationType }
     *     
     */
    public ContactInformationType getContactInformation() {
        return contactInformation;
    }

    /**
     * Sets the value of the contactInformation property.
     * 
     * @param value
     *     allowed object is
     *     {@link ContactInformationType }
     *     
     */
    public void setContactInformation(ContactInformationType value) {
        this.contactInformation = value;
    }

    /**
     * Gets the value of the sourceLink property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getSourceLink() {
        return sourceLink;
    }

    /**
     * Sets the value of the sourceLink property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setSourceLink(String value) {
        this.sourceLink = value;
    }

    /**
     * Gets the value of the sourceID property.
     * 
     * @return
     *     possible object is
     *     {@link Integer }
     *     
     */
    public Integer getSourceID() {
        return sourceID;
    }

    /**
     * Sets the value of the sourceID property.
     * 
     * @param value
     *     allowed object is
     *     {@link Integer }
     *     
     */
    public void setSourceID(Integer value) {
        this.sourceID = value;
    }

}
