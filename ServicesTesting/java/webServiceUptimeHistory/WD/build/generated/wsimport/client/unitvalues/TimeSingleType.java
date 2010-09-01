
package unitvalues;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;
import javax.xml.datatype.XMLGregorianCalendar;


/**
 * For where a series is a single observation.
 * 
 * timeSingle, beginDateTime, and endDateTime will have the same value. The beginDateTime and endDateTime are provided to simplify usage by clients.They should be be calculated based on the duration stored in realTimeDataPeriod
 * 
 * <p>Java class for TimeSingleType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="TimeSingleType">
 *   &lt;complexContent>
 *     &lt;extension base="{http://www.cuahsi.org/waterML/1.0/}TimePeriodType">
 *       &lt;sequence>
 *         &lt;element name="timeSingle" type="{http://www.w3.org/2001/XMLSchema}dateTime"/>
 *         &lt;element name="beginDateTime" type="{http://www.w3.org/2001/XMLSchema}dateTime"/>
 *         &lt;element name="endDateTime" type="{http://www.w3.org/2001/XMLSchema}dateTime"/>
 *       &lt;/sequence>
 *     &lt;/extension>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "TimeSingleType", propOrder = {
    "timeSingle",
    "beginDateTime",
    "endDateTime"
})
public class TimeSingleType
    extends TimePeriodType
{

    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
    protected XMLGregorianCalendar timeSingle;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
    protected XMLGregorianCalendar beginDateTime;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
    protected XMLGregorianCalendar endDateTime;

    /**
     * Gets the value of the timeSingle property.
     * 
     * @return
     *     possible object is
     *     {@link XMLGregorianCalendar }
     *     
     */
    public XMLGregorianCalendar getTimeSingle() {
        return timeSingle;
    }

    /**
     * Sets the value of the timeSingle property.
     * 
     * @param value
     *     allowed object is
     *     {@link XMLGregorianCalendar }
     *     
     */
    public void setTimeSingle(XMLGregorianCalendar value) {
        this.timeSingle = value;
    }

    /**
     * Gets the value of the beginDateTime property.
     * 
     * @return
     *     possible object is
     *     {@link XMLGregorianCalendar }
     *     
     */
    public XMLGregorianCalendar getBeginDateTime() {
        return beginDateTime;
    }

    /**
     * Sets the value of the beginDateTime property.
     * 
     * @param value
     *     allowed object is
     *     {@link XMLGregorianCalendar }
     *     
     */
    public void setBeginDateTime(XMLGregorianCalendar value) {
        this.beginDateTime = value;
    }

    /**
     * Gets the value of the endDateTime property.
     * 
     * @return
     *     possible object is
     *     {@link XMLGregorianCalendar }
     *     
     */
    public XMLGregorianCalendar getEndDateTime() {
        return endDateTime;
    }

    /**
     * Sets the value of the endDateTime property.
     * 
     * @param value
     *     allowed object is
     *     {@link XMLGregorianCalendar }
     *     
     */
    public void setEndDateTime(XMLGregorianCalendar value) {
        this.endDateTime = value;
    }

}
