
package unitvalues;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for LatLonPointType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="LatLonPointType">
 *   &lt;complexContent>
 *     &lt;extension base="{http://www.cuahsi.org/waterML/1.0/}GeogLocationType">
 *       &lt;sequence>
 *         &lt;element name="latitude" type="{http://www.cuahsi.org/waterML/1.0/}Latitude"/>
 *         &lt;element name="longitude" type="{http://www.cuahsi.org/waterML/1.0/}Longitude"/>
 *       &lt;/sequence>
 *     &lt;/extension>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "LatLonPointType", propOrder = {
    "latitude",
    "longitude"
})
public class LatLonPointType
    extends GeogLocationType
{

    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected double latitude;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected double longitude;

    /**
     * Gets the value of the latitude property.
     * 
     */
    public double getLatitude() {
        return latitude;
    }

    /**
     * Sets the value of the latitude property.
     * 
     */
    public void setLatitude(double value) {
        this.latitude = value;
    }

    /**
     * Gets the value of the longitude property.
     * 
     */
    public double getLongitude() {
        return longitude;
    }

    /**
     * Sets the value of the longitude property.
     * 
     */
    public void setLongitude(double value) {
        this.longitude = value;
    }

}
