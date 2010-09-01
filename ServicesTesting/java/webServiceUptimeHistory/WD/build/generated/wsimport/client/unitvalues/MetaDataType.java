
package unitvalues;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;


/**
 * MetadataType contains the information from the ODM table IsoMetadata. It is anticpated that many data sources may not have this fully available.
 * 
 *  IsoMetadata table contains dataset and project level metadata required by the CUAHSI HIS metadata system (http://www.cuahsi.org/his/documentation.html) for compliance with standards such as the draft ISO 19115 or ISO 8601.  The mandatory fields in this table must be populated to provide a complete set of ISO compliant metadata in the database.  
 * 
 * <p>Java class for MetaDataType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="MetaDataType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="TopicCategory" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="Title" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="Abstract" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="ProfileVersion" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="MetadataLink" type="{http://www.w3.org/2001/XMLSchema}anyURI" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "MetaDataType", propOrder = {
    "topicCategory",
    "title",
    "_abstract",
    "profileVersion",
    "metadataLink"
})
public class MetaDataType {

    @XmlElement(name = "TopicCategory", namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected String topicCategory;
    @XmlElement(name = "Title", namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected String title;
    @XmlElement(name = "Abstract", namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected String _abstract;
    @XmlElement(name = "ProfileVersion", namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected String profileVersion;
    @XmlElement(name = "MetadataLink", namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected String metadataLink;

    /**
     * Gets the value of the topicCategory property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getTopicCategory() {
        return topicCategory;
    }

    /**
     * Sets the value of the topicCategory property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setTopicCategory(String value) {
        this.topicCategory = value;
    }

    /**
     * Gets the value of the title property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getTitle() {
        return title;
    }

    /**
     * Sets the value of the title property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setTitle(String value) {
        this.title = value;
    }

    /**
     * Gets the value of the abstract property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getAbstract() {
        return _abstract;
    }

    /**
     * Sets the value of the abstract property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setAbstract(String value) {
        this._abstract = value;
    }

    /**
     * Gets the value of the profileVersion property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getProfileVersion() {
        return profileVersion;
    }

    /**
     * Sets the value of the profileVersion property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setProfileVersion(String value) {
        this.profileVersion = value;
    }

    /**
     * Gets the value of the metadataLink property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getMetadataLink() {
        return metadataLink;
    }

    /**
     * Sets the value of the metadataLink property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setMetadataLink(String value) {
        this.metadataLink = value;
    }

}
