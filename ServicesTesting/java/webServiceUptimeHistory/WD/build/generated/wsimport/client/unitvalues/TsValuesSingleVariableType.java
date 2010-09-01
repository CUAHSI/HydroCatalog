
package unitvalues;

import java.math.BigInteger;
import java.util.ArrayList;
import java.util.List;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;
import javax.xml.bind.annotation.adapters.CollapsedStringAdapter;
import javax.xml.bind.annotation.adapters.NormalizedStringAdapter;
import javax.xml.bind.annotation.adapters.XmlJavaTypeAdapter;


/**
 * TsValuesSingleVariableTypea aggregates the list of values and associated metadata. It is the values element in the timeSereisResponse
 * 
 * Attributes are optional, but use @count is encouraged. 
 * 
 * The atrributes @unitsAreConverted, @untsCode,@unitsAbbreviation, and @unitsType were originally included to allow for translation from orignal variable units.  Thier use is not encouraged. Get unit information from the Variable element.
 * 
 * <p>Java class for TsValuesSingleVariableType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="TsValuesSingleVariableType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="value" type="{http://www.cuahsi.org/waterML/1.0/}ValueSingleVariable" maxOccurs="unbounded"/>
 *         &lt;element ref="{http://www.cuahsi.org/waterML/1.0/}qualifier" maxOccurs="unbounded" minOccurs="0"/>
 *         &lt;element ref="{http://www.cuahsi.org/waterML/1.0/}qualityControlLevel" maxOccurs="unbounded" minOccurs="0"/>
 *         &lt;element name="method" type="{http://www.cuahsi.org/waterML/1.0/}MethodType" maxOccurs="unbounded" minOccurs="0"/>
 *         &lt;element name="source" type="{http://www.cuahsi.org/waterML/1.0/}SourceType" maxOccurs="unbounded" minOccurs="0"/>
 *         &lt;element name="offset" type="{http://www.cuahsi.org/waterML/1.0/}OffsetType" maxOccurs="unbounded" minOccurs="0"/>
 *       &lt;/sequence>
 *       &lt;attGroup ref="{http://www.cuahsi.org/waterML/1.0/}unitsAttr"/>
 *       &lt;attribute name="count" type="{http://www.w3.org/2001/XMLSchema}nonNegativeInteger" />
 *       &lt;attribute name="timeZoneShiftApplied" type="{http://www.w3.org/2001/XMLSchema}boolean" />
 *       &lt;attribute name="unitsAreConverted" type="{http://www.w3.org/2001/XMLSchema}boolean" default="false" />
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "TsValuesSingleVariableType", propOrder = {
    "value",
    "qualifier",
    "qualityControlLevel",
    "method",
    "source",
    "offset"
})
public class TsValuesSingleVariableType {

    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
    protected List<ValueSingleVariable> value;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
    protected List<Qualifier> qualifier;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
    protected List<QualityControlLevel> qualityControlLevel;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
    protected List<MethodType> method;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
    protected List<SourceType> source;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
    protected List<OffsetType> offset;
    @XmlAttribute
    protected BigInteger count;
    @XmlAttribute
    protected Boolean timeZoneShiftApplied;
    @XmlAttribute
    protected Boolean unitsAreConverted;
    @XmlAttribute
    @XmlJavaTypeAdapter(NormalizedStringAdapter.class)
    protected String unitsAbbreviation;
    @XmlAttribute
    @XmlJavaTypeAdapter(CollapsedStringAdapter.class)
    protected String unitsCode;
    @XmlAttribute
    protected UnitsTypeEnum unitsType;

    /**
     * Gets the value of the value property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the value property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getValue().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link ValueSingleVariable }
     * 
     * 
     */
    public List<ValueSingleVariable> getValue() {
        if (value == null) {
            value = new ArrayList<ValueSingleVariable>();
        }
        return this.value;
    }

    /**
     * multiple <qualifier>s containg the data qualifying comments that accompany the data.Gets the value of the qualifier property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the qualifier property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getQualifier().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link Qualifier }
     * 
     * 
     */
    public List<Qualifier> getQualifier() {
        if (qualifier == null) {
            qualifier = new ArrayList<Qualifier>();
        }
        return this.qualifier;
    }

    /**
     * <qualityControlLevel> contains the quality control levels that are used for versioning data within the data values Gets the value of the qualityControlLevel property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the qualityControlLevel property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getQualityControlLevel().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link QualityControlLevel }
     * 
     * 
     */
    public List<QualityControlLevel> getQualityControlLevel() {
        if (qualityControlLevel == null) {
            qualityControlLevel = new ArrayList<QualityControlLevel>();
        }
        return this.qualityControlLevel;
    }

    /**
     * Gets the value of the method property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the method property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getMethod().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link MethodType }
     * 
     * 
     */
    public List<MethodType> getMethod() {
        if (method == null) {
            method = new ArrayList<MethodType>();
        }
        return this.method;
    }

    /**
     * Gets the value of the source property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the source property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getSource().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link SourceType }
     * 
     * 
     */
    public List<SourceType> getSource() {
        if (source == null) {
            source = new ArrayList<SourceType>();
        }
        return this.source;
    }

    /**
     * Gets the value of the offset property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the offset property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getOffset().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link OffsetType }
     * 
     * 
     */
    public List<OffsetType> getOffset() {
        if (offset == null) {
            offset = new ArrayList<OffsetType>();
        }
        return this.offset;
    }

    /**
     * Gets the value of the count property.
     * 
     * @return
     *     possible object is
     *     {@link BigInteger }
     *     
     */
    public BigInteger getCount() {
        return count;
    }

    /**
     * Sets the value of the count property.
     * 
     * @param value
     *     allowed object is
     *     {@link BigInteger }
     *     
     */
    public void setCount(BigInteger value) {
        this.count = value;
    }

    /**
     * Gets the value of the timeZoneShiftApplied property.
     * 
     * @return
     *     possible object is
     *     {@link Boolean }
     *     
     */
    public Boolean isTimeZoneShiftApplied() {
        return timeZoneShiftApplied;
    }

    /**
     * Sets the value of the timeZoneShiftApplied property.
     * 
     * @param value
     *     allowed object is
     *     {@link Boolean }
     *     
     */
    public void setTimeZoneShiftApplied(Boolean value) {
        this.timeZoneShiftApplied = value;
    }

    /**
     * Gets the value of the unitsAreConverted property.
     * 
     * @return
     *     possible object is
     *     {@link Boolean }
     *     
     */
    public boolean isUnitsAreConverted() {
        if (unitsAreConverted == null) {
            return false;
        } else {
            return unitsAreConverted;
        }
    }

    /**
     * Sets the value of the unitsAreConverted property.
     * 
     * @param value
     *     allowed object is
     *     {@link Boolean }
     *     
     */
    public void setUnitsAreConverted(Boolean value) {
        this.unitsAreConverted = value;
    }

    /**
     * Gets the value of the unitsAbbreviation property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getUnitsAbbreviation() {
        return unitsAbbreviation;
    }

    /**
     * Sets the value of the unitsAbbreviation property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setUnitsAbbreviation(String value) {
        this.unitsAbbreviation = value;
    }

    /**
     * Gets the value of the unitsCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getUnitsCode() {
        return unitsCode;
    }

    /**
     * Sets the value of the unitsCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setUnitsCode(String value) {
        this.unitsCode = value;
    }

    /**
     * Gets the value of the unitsType property.
     * 
     * @return
     *     possible object is
     *     {@link UnitsTypeEnum }
     *     
     */
    public UnitsTypeEnum getUnitsType() {
        return unitsType;
    }

    /**
     * Sets the value of the unitsType property.
     * 
     * @param value
     *     allowed object is
     *     {@link UnitsTypeEnum }
     *     
     */
    public void setUnitsType(UnitsTypeEnum value) {
        this.unitsType = value;
    }

}
