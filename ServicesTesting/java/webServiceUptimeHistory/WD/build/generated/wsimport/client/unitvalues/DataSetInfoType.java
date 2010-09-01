
package unitvalues;

import java.util.ArrayList;
import java.util.List;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;


/**
 * DataSetInfoType describes time series derived from a dataset, such as a netCDF file, or a gridded model.
 * 
 * <p>Java class for DataSetInfoType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="DataSetInfoType">
 *   &lt;complexContent>
 *     &lt;extension base="{http://www.cuahsi.org/waterML/1.0/}SourceInfoType">
 *       &lt;sequence>
 *         &lt;element name="dataSetIdentifier" type="{http://www.w3.org/2001/XMLSchema}string"/>
 *         &lt;element ref="{http://www.cuahsi.org/waterML/1.0/}timeZoneInfo" minOccurs="0"/>
 *         &lt;element name="dataSetDescription" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="note" type="{http://www.cuahsi.org/waterML/1.0/}NoteType" maxOccurs="unbounded" minOccurs="0"/>
 *         &lt;element name="dataSetLocation" type="{http://www.cuahsi.org/waterML/1.0/}GeogLocationType" minOccurs="0"/>
 *         &lt;element ref="{http://www.cuahsi.org/waterML/1.0/}extension" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/extension>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "DataSetInfoType", propOrder = {
    "dataSetIdentifier",
    "timeZoneInfo",
    "dataSetDescription",
    "note",
    "dataSetLocation",
    "extension"
})
public class DataSetInfoType
    extends SourceInfoType
{

    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
    protected String dataSetIdentifier;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected TimeZoneInfo timeZoneInfo;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected String dataSetDescription;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
    protected List<NoteType> note;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected GeogLocationType dataSetLocation;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected Object extension;

    /**
     * Gets the value of the dataSetIdentifier property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getDataSetIdentifier() {
        return dataSetIdentifier;
    }

    /**
     * Sets the value of the dataSetIdentifier property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setDataSetIdentifier(String value) {
        this.dataSetIdentifier = value;
    }

    /**
     * the default time zone for this site (+00:00) and if this site shifts to daylight savings time (attribute: usesDaylightSavingsTime)
     * 
     * @return
     *     possible object is
     *     {@link TimeZoneInfo }
     *     
     */
    public TimeZoneInfo getTimeZoneInfo() {
        return timeZoneInfo;
    }

    /**
     * the default time zone for this site (+00:00) and if this site shifts to daylight savings time (attribute: usesDaylightSavingsTime)
     * 
     * @param value
     *     allowed object is
     *     {@link TimeZoneInfo }
     *     
     */
    public void setTimeZoneInfo(TimeZoneInfo value) {
        this.timeZoneInfo = value;
    }

    /**
     * Gets the value of the dataSetDescription property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getDataSetDescription() {
        return dataSetDescription;
    }

    /**
     * Sets the value of the dataSetDescription property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setDataSetDescription(String value) {
        this.dataSetDescription = value;
    }

    /**
     * Gets the value of the note property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the note property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getNote().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link NoteType }
     * 
     * 
     */
    public List<NoteType> getNote() {
        if (note == null) {
            note = new ArrayList<NoteType>();
        }
        return this.note;
    }

    /**
     * Gets the value of the dataSetLocation property.
     * 
     * @return
     *     possible object is
     *     {@link GeogLocationType }
     *     
     */
    public GeogLocationType getDataSetLocation() {
        return dataSetLocation;
    }

    /**
     * Sets the value of the dataSetLocation property.
     * 
     * @param value
     *     allowed object is
     *     {@link GeogLocationType }
     *     
     */
    public void setDataSetLocation(GeogLocationType value) {
        this.dataSetLocation = value;
    }

    /**
     * In order to simplify comprehension, data sources are encouraged to put additional informaiton in the extension area, using thier own namespace. Clients need not understand information in extension element
     * 
     * @return
     *     possible object is
     *     {@link Object }
     *     
     */
    public Object getExtension() {
        return extension;
    }

    /**
     * In order to simplify comprehension, data sources are encouraged to put additional informaiton in the extension area, using thier own namespace. Clients need not understand information in extension element
     * 
     * @param value
     *     allowed object is
     *     {@link Object }
     *     
     */
    public void setExtension(Object value) {
        this.extension = value;
    }

}
