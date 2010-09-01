
package unitvalues;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for LatLonBoxType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="LatLonBoxType">
 *   &lt;complexContent>
 *     &lt;extension base="{http://www.cuahsi.org/waterML/1.0/}GeogLocationType">
 *       &lt;sequence>
 *         &lt;element name="south" type="{http://www.cuahsi.org/waterML/1.0/}Latitude"/>
 *         &lt;element name="west" type="{http://www.cuahsi.org/waterML/1.0/}Longitude"/>
 *         &lt;element name="north" type="{http://www.cuahsi.org/waterML/1.0/}Latitude"/>
 *         &lt;element name="east" type="{http://www.cuahsi.org/waterML/1.0/}Longitude"/>
 *       &lt;/sequence>
 *     &lt;/extension>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "LatLonBoxType", propOrder = {
    "south",
    "west",
    "north",
    "east"
})
public class LatLonBoxType
    extends GeogLocationType
{

    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected double south;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected double west;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected double north;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected double east;

    /**
     * Gets the value of the south property.
     * 
     */
    public double getSouth() {
        return south;
    }

    /**
     * Sets the value of the south property.
     * 
     */
    public void setSouth(double value) {
        this.south = value;
    }

    /**
     * Gets the value of the west property.
     * 
     */
    public double getWest() {
        return west;
    }

    /**
     * Sets the value of the west property.
     * 
     */
    public void setWest(double value) {
        this.west = value;
    }

    /**
     * Gets the value of the north property.
     * 
     */
    public double getNorth() {
        return north;
    }

    /**
     * Sets the value of the north property.
     * 
     */
    public void setNorth(double value) {
        this.north = value;
    }

    /**
     * Gets the value of the east property.
     * 
     */
    public double getEast() {
        return east;
    }

    /**
     * Sets the value of the east property.
     * 
     */
    public void setEast(double value) {
        this.east = value;
    }

}
