
package unitvalues;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;


/**
 * contains descriptions of the laboratory methods used to analyze physical samples for specific constituents.
 * 
 * <p>Java class for LabMethodType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="LabMethodType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="labName" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="labOrganization" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="LabMethodName" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="labMethodDescription" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="labMethodLink" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *       &lt;/sequence>
 *       &lt;attribute name="labMethodID" type="{http://www.w3.org/2001/XMLSchema}int" />
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "LabMethodType", propOrder = {
    "labName",
    "labOrganization",
    "labMethodName",
    "labMethodDescription",
    "labMethodLink"
})
public class LabMethodType {

    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected String labName;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected String labOrganization;
    @XmlElement(name = "LabMethodName", namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected String labMethodName;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected String labMethodDescription;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected String labMethodLink;
    @XmlAttribute
    protected Integer labMethodID;

    /**
     * Gets the value of the labName property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getLabName() {
        return labName;
    }

    /**
     * Sets the value of the labName property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setLabName(String value) {
        this.labName = value;
    }

    /**
     * Gets the value of the labOrganization property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getLabOrganization() {
        return labOrganization;
    }

    /**
     * Sets the value of the labOrganization property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setLabOrganization(String value) {
        this.labOrganization = value;
    }

    /**
     * Gets the value of the labMethodName property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getLabMethodName() {
        return labMethodName;
    }

    /**
     * Sets the value of the labMethodName property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setLabMethodName(String value) {
        this.labMethodName = value;
    }

    /**
     * Gets the value of the labMethodDescription property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getLabMethodDescription() {
        return labMethodDescription;
    }

    /**
     * Sets the value of the labMethodDescription property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setLabMethodDescription(String value) {
        this.labMethodDescription = value;
    }

    /**
     * Gets the value of the labMethodLink property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getLabMethodLink() {
        return labMethodLink;
    }

    /**
     * Sets the value of the labMethodLink property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setLabMethodLink(String value) {
        this.labMethodLink = value;
    }

    /**
     * Gets the value of the labMethodID property.
     * 
     * @return
     *     possible object is
     *     {@link Integer }
     *     
     */
    public Integer getLabMethodID() {
        return labMethodID;
    }

    /**
     * Sets the value of the labMethodID property.
     * 
     * @param value
     *     allowed object is
     *     {@link Integer }
     *     
     */
    public void setLabMethodID(Integer value) {
        this.labMethodID = value;
    }

}
