
package unitvalues;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for TimeSeriesResponseType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="TimeSeriesResponseType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="queryInfo" type="{http://www.cuahsi.org/waterML/1.0/}QueryInfoType" minOccurs="0"/>
 *         &lt;element name="timeSeries" type="{http://www.cuahsi.org/waterML/1.0/}TimeSeriesType"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "TimeSeriesResponseType", propOrder = {
    "queryInfo",
    "timeSeries"
})
public class TimeSeriesResponseType {

    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected QueryInfoType queryInfo;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
    protected TimeSeriesType timeSeries;

    /**
     * Gets the value of the queryInfo property.
     * 
     * @return
     *     possible object is
     *     {@link QueryInfoType }
     *     
     */
    public QueryInfoType getQueryInfo() {
        return queryInfo;
    }

    /**
     * Sets the value of the queryInfo property.
     * 
     * @param value
     *     allowed object is
     *     {@link QueryInfoType }
     *     
     */
    public void setQueryInfo(QueryInfoType value) {
        this.queryInfo = value;
    }

    /**
     * Gets the value of the timeSeries property.
     * 
     * @return
     *     possible object is
     *     {@link TimeSeriesType }
     *     
     */
    public TimeSeriesType getTimeSeries() {
        return timeSeries;
    }

    /**
     * Sets the value of the timeSeries property.
     * 
     * @param value
     *     allowed object is
     *     {@link TimeSeriesType }
     *     
     */
    public void setTimeSeries(TimeSeriesType value) {
        this.timeSeries = value;
    }

}
