
package unitvalues;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;


/**
 * information about physical samples analyzed in a laboratory.
 * 
 * @sampleID is the link to the datavalues/@sampleID
 * 
 * LabSampleCode is the sample code. In WaterML 1.1 this will be the link to the dataValue
 * 
 * SampleType describes the the sample type 
 * 
 * LabMethod is a LabMethodType containing infomration about lab methods
 * 
 * 
 * <p>Java class for SampleType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="SampleType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="labSampleCode" type="{http://www.w3.org/2001/XMLSchema}string"/>
 *         &lt;element name="SampleType" type="{http://www.cuahsi.org/waterML/1.0/}sampleTypeEnum"/>
 *         &lt;element name="LabMethod" type="{http://www.cuahsi.org/waterML/1.0/}LabMethodType" minOccurs="0"/>
 *       &lt;/sequence>
 *       &lt;attribute name="sampleID" type="{http://www.w3.org/2001/XMLSchema}int" />
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "SampleType", propOrder = {
    "labSampleCode",
    "sampleType",
    "labMethod"
})
public class SampleType {

    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
    protected String labSampleCode;
    @XmlElement(name = "SampleType", namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
    protected SampleTypeEnum sampleType;
    @XmlElement(name = "LabMethod", namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected LabMethodType labMethod;
    @XmlAttribute
    protected Integer sampleID;

    /**
     * Gets the value of the labSampleCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getLabSampleCode() {
        return labSampleCode;
    }

    /**
     * Sets the value of the labSampleCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setLabSampleCode(String value) {
        this.labSampleCode = value;
    }

    /**
     * Gets the value of the sampleType property.
     * 
     * @return
     *     possible object is
     *     {@link SampleTypeEnum }
     *     
     */
    public SampleTypeEnum getSampleType() {
        return sampleType;
    }

    /**
     * Sets the value of the sampleType property.
     * 
     * @param value
     *     allowed object is
     *     {@link SampleTypeEnum }
     *     
     */
    public void setSampleType(SampleTypeEnum value) {
        this.sampleType = value;
    }

    /**
     * Gets the value of the labMethod property.
     * 
     * @return
     *     possible object is
     *     {@link LabMethodType }
     *     
     */
    public LabMethodType getLabMethod() {
        return labMethod;
    }

    /**
     * Sets the value of the labMethod property.
     * 
     * @param value
     *     allowed object is
     *     {@link LabMethodType }
     *     
     */
    public void setLabMethod(LabMethodType value) {
        this.labMethod = value;
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

}
