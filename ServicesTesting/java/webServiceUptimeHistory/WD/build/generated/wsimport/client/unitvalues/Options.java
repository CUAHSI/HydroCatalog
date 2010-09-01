
package unitvalues;

import java.util.ArrayList;
import java.util.List;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;


/**
 * A list of options. Option elements are key-value pair elements that control how a variable maght be utilized in a service.
 *             Examples:
 *  MODIS web service. Information is aggreated over land or ocean or both. The plotarea option can include: plotarea=land, plotarea=land, plotarea=landocean
 * 
 * USGS uses a statistic code, 0003, to repesent a  value type of 'Average'. The USGS statistic codes also several options that do not fit the ODM data model. 
 * 
 * <p>Java class for options element declaration.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;element name="options">
 *   &lt;complexType>
 *     &lt;complexContent>
 *       &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *         &lt;sequence>
 *           &lt;element ref="{http://www.cuahsi.org/waterML/1.0/}option" maxOccurs="unbounded" minOccurs="0"/>
 *         &lt;/sequence>
 *       &lt;/restriction>
 *     &lt;/complexContent>
 *   &lt;/complexType>
 * &lt;/element>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "", propOrder = {
    "option"
})
@XmlRootElement(name = "options")
public class Options {

    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
    protected List<Option> option;

    /**
     * Option elements are key-value pair elements that control how a variable maght be utilized in a service.
     *             Examples:
     *  MODIS web service. Information is aggreated over land or ocean or both. The plotarea option can include: plotarea=land, plotarea=land, plotarea=landocean
     * 
     * USGS uses a statistic code, 0003, to repesent a  value type of 'Average'. The USGS statistic codes also several options that do not fit the ODM data model. Gets the value of the option property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the option property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getOption().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link Option }
     * 
     * 
     */
    public List<Option> getOption() {
        if (option == null) {
            option = new ArrayList<Option>();
        }
        return this.option;
    }

}
