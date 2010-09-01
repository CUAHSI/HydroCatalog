
package unitvalues;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlType;


/**
 * time series (site-variable-observation) can have three types of time periods:
 *  1) definite start and end time, or TimeIntervalType,
 *  2) single observation, or TimeSingleType
 *  3) Real Time station with moving window of data available, or TimeRealTimeType
 * 
 * In order to simplify client development, all types now include beginDateTime, and endDateTime.
 * 
 * A fourth type should be added:
 *  4) continuing site, where start is known, and site is still collecting data. This could be a realTimeType, or rename the real time type to TimeDefinedPeriodType.
 * 
 * 
 * <p>Java class for TimePeriodType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="TimePeriodType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "TimePeriodType")
public class TimePeriodType {


}
