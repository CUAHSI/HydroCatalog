
package unitvalues;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlType;


/**
 * GeogLocationType is the base class for the two geometry types: LatLonPointType, and LatLonBoxType.
 * Any additional types should derive from this type.
 * The default spatial reference system is  @srs is EPSG:4326  or Geographic lat long.
 * 
 * 
 * <p>Java class for GeogLocationType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="GeogLocationType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *       &lt;/sequence>
 *       &lt;attribute name="srs" type="{http://www.w3.org/2001/XMLSchema}string" default="EPSG:4326" />
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "GeogLocationType")
public class GeogLocationType {

    @XmlAttribute
    protected String srs;

    /**
     * Gets the value of the srs property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getSrs() {
        if (srs == null) {
            return "EPSG:4326";
        } else {
            return srs;
        }
    }

    /**
     * Sets the value of the srs property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setSrs(String value) {
        this.srs = value;
    }

}
