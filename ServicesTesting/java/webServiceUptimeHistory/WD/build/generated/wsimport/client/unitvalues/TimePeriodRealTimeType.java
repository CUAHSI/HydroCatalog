
package unitvalues;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;
import javax.xml.datatype.Duration;
import javax.xml.datatype.XMLGregorianCalendar;


/**
 * Use where a site has an evolving period where data is available.
 * The US Geological Survey real time data is available for 30 days, the realTimeDataPeriod element is an XML duration and woudl be "30d"
 * 
 * The beginDateTime and endDateTime are provided to simplify usage by clients.They should be be calculated based on the duration stored in realTimeDataPeriod
 * 
 * <p>Java class for TimePeriodRealTimeType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="TimePeriodRealTimeType">
 *   &lt;complexContent>
 *     &lt;extension base="{http://www.cuahsi.org/waterML/1.0/}TimePeriodType">
 *       &lt;sequence>
 *         &lt;element name="realTimeDataPeriod" type="{http://www.w3.org/2001/XMLSchema}duration"/>
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
@XmlType(name = "TimePeriodRealTimeType", propOrder = {
    "realTimeDataPeriod",
    "beginDateTime",
    "endDateTime"
})
public class TimePeriodRealTimeType
    extends TimePeriodType
{

    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
    protected Duration realTimeDataPeriod;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
    protected XMLGregorianCalendar beginDateTime;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
    protected XMLGregorianCalendar endDateTime;

    /**
     * Gets the value of the realTimeDataPeriod property.
     * 
     * @return
     *     possible object is
     *     {@link Duration }
     *     
     */
    public Duration getRealTimeDataPeriod() {
        return realTimeDataPeriod;
    }

    /**
     * Sets the value of the realTimeDataPeriod property.
     * 
     * @param value
     *     allowed object is
     *     {@link Duration }
     *     
     */
    public void setRealTimeDataPeriod(Duration value) {
        this.realTimeDataPeriod = value;
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
