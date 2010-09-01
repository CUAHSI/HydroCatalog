
package unitvalues;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for UnitsType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="UnitsType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="UnitName" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="UnitDescription" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="UnitType" type="{http://www.cuahsi.org/waterML/1.0/}UnitsTypeEnum" minOccurs="0"/>
 *         &lt;element name="UnitAbbreviation" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *       &lt;/sequence>
 *       &lt;attribute name="UnitID" type="{http://www.w3.org/2001/XMLSchema}int" />
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "UnitsType", propOrder = {
    "unitName",
    "unitDescription",
    "unitType",
    "unitAbbreviation"
})
public class UnitsType {

    @XmlElement(name = "UnitName", namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected String unitName;
    @XmlElement(name = "UnitDescription", namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected String unitDescription;
    @XmlElement(name = "UnitType", namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected UnitsTypeEnum unitType;
    @XmlElement(name = "UnitAbbreviation", namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected String unitAbbreviation;
    @XmlAttribute(name = "UnitID")
    protected Integer unitID;

    /**
     * Gets the value of the unitName property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getUnitName() {
        return unitName;
    }

    /**
     * Sets the value of the unitName property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setUnitName(String value) {
        this.unitName = value;
    }

    /**
     * Gets the value of the unitDescription property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getUnitDescription() {
        return unitDescription;
    }

    /**
     * Sets the value of the unitDescription property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setUnitDescription(String value) {
        this.unitDescription = value;
    }

    /**
     * Gets the value of the unitType property.
     * 
     * @return
     *     possible object is
     *     {@link UnitsTypeEnum }
     *     
     */
    public UnitsTypeEnum getUnitType() {
        return unitType;
    }

    /**
     * Sets the value of the unitType property.
     * 
     * @param value
     *     allowed object is
     *     {@link UnitsTypeEnum }
     *     
     */
    public void setUnitType(UnitsTypeEnum value) {
        this.unitType = value;
    }

    /**
     * Gets the value of the unitAbbreviation property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getUnitAbbreviation() {
        return unitAbbreviation;
    }

    /**
     * Sets the value of the unitAbbreviation property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setUnitAbbreviation(String value) {
        this.unitAbbreviation = value;
    }

    /**
     * Gets the value of the unitID property.
     * 
     * @return
     *     possible object is
     *     {@link Integer }
     *     
     */
    public Integer getUnitID() {
        return unitID;
    }

    /**
     * Sets the value of the unitID property.
     * 
     * @param value
     *     allowed object is
     *     {@link Integer }
     *     
     */
    public void setUnitID(Integer value) {
        this.unitID = value;
    }

}
