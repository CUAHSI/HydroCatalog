
package unitvalues;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;


/**
 * OffsetType  contains full descriptive information for each of the measurement offsets.
 * A set of observations may be done at an offset for the central location.
 * 
 * offsetTypeID links to dataValue/@offsetTypeId
 * 
 * <p>Java class for OffsetType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="OffsetType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="offsetValue" type="{http://www.w3.org/2001/XMLSchema}float"/>
 *         &lt;element name="offsetDescription" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element ref="{http://www.cuahsi.org/waterML/1.0/}units"/>
 *         &lt;element name="offsetIsVertical" type="{http://www.w3.org/2001/XMLSchema}boolean" minOccurs="0"/>
 *         &lt;element name="offsetHorizDirectionDegrees" type="{http://www.w3.org/2001/XMLSchema}int" minOccurs="0"/>
 *       &lt;/sequence>
 *       &lt;attribute name="offsetTypeID" type="{http://www.w3.org/2001/XMLSchema}int" />
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "OffsetType", propOrder = {
    "offsetValue",
    "offsetDescription",
    "units",
    "offsetIsVertical",
    "offsetHorizDirectionDegrees"
})
public class OffsetType {

    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected float offsetValue;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected String offsetDescription;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
    protected Units units;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", defaultValue = "true")
    protected Boolean offsetIsVertical;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected Integer offsetHorizDirectionDegrees;
    @XmlAttribute
    protected Integer offsetTypeID;

    /**
     * Gets the value of the offsetValue property.
     * 
     */
    public float getOffsetValue() {
        return offsetValue;
    }

    /**
     * Sets the value of the offsetValue property.
     * 
     */
    public void setOffsetValue(float value) {
        this.offsetValue = value;
    }

    /**
     * Gets the value of the offsetDescription property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getOffsetDescription() {
        return offsetDescription;
    }

    /**
     * Sets the value of the offsetDescription property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setOffsetDescription(String value) {
        this.offsetDescription = value;
    }

    /**
     * Units of the offsetValue
     * 
     * @return
     *     possible object is
     *     {@link Units }
     *     
     */
    public Units getUnits() {
        return units;
    }

    /**
     * Units of the offsetValue
     * 
     * @param value
     *     allowed object is
     *     {@link Units }
     *     
     */
    public void setUnits(Units value) {
        this.units = value;
    }

    /**
     * Gets the value of the offsetIsVertical property.
     * 
     * @return
     *     possible object is
     *     {@link Boolean }
     *     
     */
    public Boolean isOffsetIsVertical() {
        return offsetIsVertical;
    }

    /**
     * Sets the value of the offsetIsVertical property.
     * 
     * @param value
     *     allowed object is
     *     {@link Boolean }
     *     
     */
    public void setOffsetIsVertical(Boolean value) {
        this.offsetIsVertical = value;
    }

    /**
     * Gets the value of the offsetHorizDirectionDegrees property.
     * 
     * @return
     *     possible object is
     *     {@link Integer }
     *     
     */
    public Integer getOffsetHorizDirectionDegrees() {
        return offsetHorizDirectionDegrees;
    }

    /**
     * Sets the value of the offsetHorizDirectionDegrees property.
     * 
     * @param value
     *     allowed object is
     *     {@link Integer }
     *     
     */
    public void setOffsetHorizDirectionDegrees(Integer value) {
        this.offsetHorizDirectionDegrees = value;
    }

    /**
     * Gets the value of the offsetTypeID property.
     * 
     * @return
     *     possible object is
     *     {@link Integer }
     *     
     */
    public Integer getOffsetTypeID() {
        return offsetTypeID;
    }

    /**
     * Sets the value of the offsetTypeID property.
     * 
     * @param value
     *     allowed object is
     *     {@link Integer }
     *     
     */
    public void setOffsetTypeID(Integer value) {
        this.offsetTypeID = value;
    }

}
