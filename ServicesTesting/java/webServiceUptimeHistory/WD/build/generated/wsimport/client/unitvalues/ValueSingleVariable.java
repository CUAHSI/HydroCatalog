
package unitvalues;

import java.math.BigDecimal;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlType;
import javax.xml.bind.annotation.XmlValue;
import javax.xml.bind.annotation.adapters.NormalizedStringAdapter;
import javax.xml.bind.annotation.adapters.XmlJavaTypeAdapter;
import javax.xml.datatype.XMLGregorianCalendar;


/**
 * <p>Java class for ValueSingleVariable complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="ValueSingleVariable">
 *   &lt;simpleContent>
 *     &lt;extension base="&lt;http://www.w3.org/2001/XMLSchema>decimal">
 *       &lt;attGroup ref="{http://www.cuahsi.org/waterML/1.0/}offsetAttr"/>
 *       &lt;attGroup ref="{http://www.cuahsi.org/waterML/1.0/}ValueAttr"/>
 *       &lt;attGroup ref="{http://www.cuahsi.org/waterML/1.0/}DbIdentifiers"/>
 *     &lt;/extension>
 *   &lt;/simpleContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "ValueSingleVariable", propOrder = {
    "value"
})
public class ValueSingleVariable {

    @XmlValue
    protected BigDecimal value;
    @XmlAttribute
    protected String offsetDescription;
    @XmlAttribute
    protected Integer offsetTypeID;
    @XmlAttribute
    protected String offsetUnitsAbbreviation;
    @XmlAttribute
    protected String offsetUnitsCode;
    @XmlAttribute
    protected Double offsetValue;
    @XmlAttribute
    protected Double accuracyStdDev;
    @XmlAttribute
    protected CensorCodeEnum censorCode;
    @XmlAttribute
    protected Boolean codedVocabulary;
    @XmlAttribute
    protected String codedVocabularyTerm;
    @XmlAttribute(required = true)
    protected XMLGregorianCalendar dateTime;
    @XmlAttribute
    protected Integer methodID;
    @XmlAttribute
    protected String qualifiers;
    @XmlAttribute
    protected QualityControlLevelEnum qualityControlLevel;
    @XmlAttribute
    protected Integer sampleID;
    @XmlAttribute
    protected Integer sourceID;
    @XmlAttribute
    protected XMLGregorianCalendar metadataDateTime;
    @XmlAttribute
    @XmlJavaTypeAdapter(NormalizedStringAdapter.class)
    protected String oid;

    /**
     * Gets the value of the value property.
     * 
     * @return
     *     possible object is
     *     {@link BigDecimal }
     *     
     */
    public BigDecimal getValue() {
        return value;
    }

    /**
     * Sets the value of the value property.
     * 
     * @param value
     *     allowed object is
     *     {@link BigDecimal }
     *     
     */
    public void setValue(BigDecimal value) {
        this.value = value;
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

    /**
     * Gets the value of the offsetUnitsAbbreviation property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getOffsetUnitsAbbreviation() {
        return offsetUnitsAbbreviation;
    }

    /**
     * Sets the value of the offsetUnitsAbbreviation property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setOffsetUnitsAbbreviation(String value) {
        this.offsetUnitsAbbreviation = value;
    }

    /**
     * Gets the value of the offsetUnitsCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getOffsetUnitsCode() {
        return offsetUnitsCode;
    }

    /**
     * Sets the value of the offsetUnitsCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setOffsetUnitsCode(String value) {
        this.offsetUnitsCode = value;
    }

    /**
     * Gets the value of the offsetValue property.
     * 
     * @return
     *     possible object is
     *     {@link Double }
     *     
     */
    public Double getOffsetValue() {
        return offsetValue;
    }

    /**
     * Sets the value of the offsetValue property.
     * 
     * @param value
     *     allowed object is
     *     {@link Double }
     *     
     */
    public void setOffsetValue(Double value) {
        this.offsetValue = value;
    }

    /**
     * Gets the value of the accuracyStdDev property.
     * 
     * @return
     *     possible object is
     *     {@link Double }
     *     
     */
    public Double getAccuracyStdDev() {
        return accuracyStdDev;
    }

    /**
     * Sets the value of the accuracyStdDev property.
     * 
     * @param value
     *     allowed object is
     *     {@link Double }
     *     
     */
    public void setAccuracyStdDev(Double value) {
        this.accuracyStdDev = value;
    }

    /**
     * Gets the value of the censorCode property.
     * 
     * @return
     *     possible object is
     *     {@link CensorCodeEnum }
     *     
     */
    public CensorCodeEnum getCensorCode() {
        return censorCode;
    }

    /**
     * Sets the value of the censorCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link CensorCodeEnum }
     *     
     */
    public void setCensorCode(CensorCodeEnum value) {
        this.censorCode = value;
    }

    /**
     * Gets the value of the codedVocabulary property.
     * 
     * @return
     *     possible object is
     *     {@link Boolean }
     *     
     */
    public Boolean isCodedVocabulary() {
        return codedVocabulary;
    }

    /**
     * Sets the value of the codedVocabulary property.
     * 
     * @param value
     *     allowed object is
     *     {@link Boolean }
     *     
     */
    public void setCodedVocabulary(Boolean value) {
        this.codedVocabulary = value;
    }

    /**
     * Gets the value of the codedVocabularyTerm property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getCodedVocabularyTerm() {
        return codedVocabularyTerm;
    }

    /**
     * Sets the value of the codedVocabularyTerm property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setCodedVocabularyTerm(String value) {
        this.codedVocabularyTerm = value;
    }

    /**
     * Gets the value of the dateTime property.
     * 
     * @return
     *     possible object is
     *     {@link XMLGregorianCalendar }
     *     
     */
    public XMLGregorianCalendar getDateTime() {
        return dateTime;
    }

    /**
     * Sets the value of the dateTime property.
     * 
     * @param value
     *     allowed object is
     *     {@link XMLGregorianCalendar }
     *     
     */
    public void setDateTime(XMLGregorianCalendar value) {
        this.dateTime = value;
    }

    /**
     * Gets the value of the methodID property.
     * 
     * @return
     *     possible object is
     *     {@link Integer }
     *     
     */
    public Integer getMethodID() {
        return methodID;
    }

    /**
     * Sets the value of the methodID property.
     * 
     * @param value
     *     allowed object is
     *     {@link Integer }
     *     
     */
    public void setMethodID(Integer value) {
        this.methodID = value;
    }

    /**
     * Gets the value of the qualifiers property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getQualifiers() {
        return qualifiers;
    }

    /**
     * Sets the value of the qualifiers property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setQualifiers(String value) {
        this.qualifiers = value;
    }

    /**
     * Gets the value of the qualityControlLevel property.
     * 
     * @return
     *     possible object is
     *     {@link QualityControlLevelEnum }
     *     
     */
    public QualityControlLevelEnum getQualityControlLevel() {
        return qualityControlLevel;
    }

    /**
     * Sets the value of the qualityControlLevel property.
     * 
     * @param value
     *     allowed object is
     *     {@link QualityControlLevelEnum }
     *     
     */
    public void setQualityControlLevel(QualityControlLevelEnum value) {
        this.qualityControlLevel = value;
    }

    /**
     * Gets the value of the sampleID property.
     * 
     * @return
     *     possible object is
     *     {@link Integer }
     *     
     */
    public Integer getSampleID() {
        return sampleID;
    }

    /**
     * Sets the value of the sampleID property.
     * 
     * @param value
     *     allowed object is
     *     {@link Integer }
     *     
     */
    public void setSampleID(Integer value) {
        this.sampleID = value;
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

    /**
     * Gets the value of the metadataDateTime property.
     * 
     * @return
     *     possible object is
     *     {@link XMLGregorianCalendar }
     *     
     */
    public XMLGregorianCalendar getMetadataDateTime() {
        return metadataDateTime;
    }

    /**
     * Sets the value of the metadataDateTime property.
     * 
     * @param value
     *     allowed object is
     *     {@link XMLGregorianCalendar }
     *     
     */
    public void setMetadataDateTime(XMLGregorianCalendar value) {
        this.metadataDateTime = value;
    }

    /**
     * Gets the value of the oid property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getOid() {
        return oid;
    }

    /**
     * Sets the value of the oid property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setOid(String value) {
        this.oid = value;
    }

}
