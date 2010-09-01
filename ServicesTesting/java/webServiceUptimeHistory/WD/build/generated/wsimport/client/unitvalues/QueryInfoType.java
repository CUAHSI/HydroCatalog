
package unitvalues;

import java.util.ArrayList;
import java.util.List;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;
import javax.xml.datatype.XMLGregorianCalendar;
import unitvalues.QueryInfoType.Criteria;
import unitvalues.QueryInfoType.Criteria.TimeParam;


/**
 * This contains information about the request, and is used to enable the XML responses (timeSeriesResponse, variablesResponse,siteResponse) to be stored on disk.
 * 
 * <p>Java class for QueryInfoType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="QueryInfoType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="creationTime" type="{http://www.w3.org/2001/XMLSchema}dateTime" minOccurs="0"/>
 *         &lt;element name="queryURL" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="querySQL" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="criteria" minOccurs="0">
 *           &lt;complexType>
 *             &lt;complexContent>
 *               &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *                 &lt;sequence minOccurs="0">
 *                   &lt;element name="locationParam" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *                   &lt;element name="variableParam" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *                   &lt;element name="timeParam" minOccurs="0">
 *                     &lt;complexType>
 *                       &lt;complexContent>
 *                         &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *                           &lt;sequence>
 *                             &lt;element name="beginDateTime" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *                             &lt;element name="endDateTime" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *                           &lt;/sequence>
 *                         &lt;/restriction>
 *                       &lt;/complexContent>
 *                     &lt;/complexType>
 *                   &lt;/element>
 *                 &lt;/sequence>
 *               &lt;/restriction>
 *             &lt;/complexContent>
 *           &lt;/complexType>
 *         &lt;/element>
 *         &lt;element name="note" type="{http://www.cuahsi.org/waterML/1.0/}NoteType" maxOccurs="unbounded" minOccurs="0"/>
 *         &lt;element ref="{http://www.cuahsi.org/waterML/1.0/}extension" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "QueryInfoType", propOrder = {
    "creationTime",
    "queryURL",
    "querySQL",
    "criteria",
    "note",
    "extension"
})
public class QueryInfoType {

    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected XMLGregorianCalendar creationTime;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected String queryURL;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected String querySQL;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected Criteria criteria;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
    protected List<NoteType> note;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected Object extension;

    /**
     * Gets the value of the creationTime property.
     * 
     * @return
     *     possible object is
     *     {@link XMLGregorianCalendar }
     *     
     */
    public XMLGregorianCalendar getCreationTime() {
        return creationTime;
    }

    /**
     * Sets the value of the creationTime property.
     * 
     * @param value
     *     allowed object is
     *     {@link XMLGregorianCalendar }
     *     
     */
    public void setCreationTime(XMLGregorianCalendar value) {
        this.creationTime = value;
    }

    /**
     * Gets the value of the queryURL property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getQueryURL() {
        return queryURL;
    }

    /**
     * Sets the value of the queryURL property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setQueryURL(String value) {
        this.queryURL = value;
    }

    /**
     * Gets the value of the querySQL property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getQuerySQL() {
        return querySQL;
    }

    /**
     * Sets the value of the querySQL property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setQuerySQL(String value) {
        this.querySQL = value;
    }

    /**
     * Gets the value of the criteria property.
     * 
     * @return
     *     possible object is
     *     {@link Criteria }
     *     
     */
    public Criteria getCriteria() {
        return criteria;
    }

    /**
     * Sets the value of the criteria property.
     * 
     * @param value
     *     allowed object is
     *     {@link Criteria }
     *     
     */
    public void setCriteria(Criteria value) {
        this.criteria = value;
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
     * In order to simplify comprehension, data sources are encouraged to put additional informaiton in the extension area, using thier own namespace. Clients need not understand information in &lt;extension?
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
     * In order to simplify comprehension, data sources are encouraged to put additional informaiton in the extension area, using thier own namespace. Clients need not understand information in &lt;extension?
     * 
     * @param value
     *     allowed object is
     *     {@link Object }
     *     
     */
    public void setExtension(Object value) {
        this.extension = value;
    }


    /**
     * <p>Java class for anonymous complex type.
     * 
     * <p>The following schema fragment specifies the expected content contained within this class.
     * 
     * <pre>
     * &lt;complexType>
     *   &lt;complexContent>
     *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
     *       &lt;sequence minOccurs="0">
     *         &lt;element name="locationParam" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
     *         &lt;element name="variableParam" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
     *         &lt;element name="timeParam" minOccurs="0">
     *           &lt;complexType>
     *             &lt;complexContent>
     *               &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
     *                 &lt;sequence>
     *                   &lt;element name="beginDateTime" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
     *                   &lt;element name="endDateTime" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
     *                 &lt;/sequence>
     *               &lt;/restriction>
     *             &lt;/complexContent>
     *           &lt;/complexType>
     *         &lt;/element>
     *       &lt;/sequence>
     *     &lt;/restriction>
     *   &lt;/complexContent>
     * &lt;/complexType>
     * </pre>
     * 
     * 
     */
    @XmlAccessorType(XmlAccessType.FIELD)
    @XmlType(name = "", propOrder = {
        "locationParam",
        "variableParam",
        "timeParam"
    })
    public static class Criteria {

        @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
        protected String locationParam;
        @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
        protected String variableParam;
        @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
        protected TimeParam timeParam;

        /**
         * Gets the value of the locationParam property.
         * 
         * @return
         *     possible object is
         *     {@link String }
         *     
         */
        public String getLocationParam() {
            return locationParam;
        }

        /**
         * Sets the value of the locationParam property.
         * 
         * @param value
         *     allowed object is
         *     {@link String }
         *     
         */
        public void setLocationParam(String value) {
            this.locationParam = value;
        }

        /**
         * Gets the value of the variableParam property.
         * 
         * @return
         *     possible object is
         *     {@link String }
         *     
         */
        public String getVariableParam() {
            return variableParam;
        }

        /**
         * Sets the value of the variableParam property.
         * 
         * @param value
         *     allowed object is
         *     {@link String }
         *     
         */
        public void setVariableParam(String value) {
            this.variableParam = value;
        }

        /**
         * Gets the value of the timeParam property.
         * 
         * @return
         *     possible object is
         *     {@link TimeParam }
         *     
         */
        public TimeParam getTimeParam() {
            return timeParam;
        }

        /**
         * Sets the value of the timeParam property.
         * 
         * @param value
         *     allowed object is
         *     {@link TimeParam }
         *     
         */
        public void setTimeParam(TimeParam value) {
            this.timeParam = value;
        }


        /**
         * <p>Java class for anonymous complex type.
         * 
         * <p>The following schema fragment specifies the expected content contained within this class.
         * 
         * <pre>
         * &lt;complexType>
         *   &lt;complexContent>
         *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
         *       &lt;sequence>
         *         &lt;element name="beginDateTime" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
         *         &lt;element name="endDateTime" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
         *       &lt;/sequence>
         *     &lt;/restriction>
         *   &lt;/complexContent>
         * &lt;/complexType>
         * </pre>
         * 
         * 
         */
        @XmlAccessorType(XmlAccessType.FIELD)
        @XmlType(name = "", propOrder = {
            "beginDateTime",
            "endDateTime"
        })
        public static class TimeParam {

            @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
            protected String beginDateTime;
            @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
            protected String endDateTime;

            /**
             * Gets the value of the beginDateTime property.
             * 
             * @return
             *     possible object is
             *     {@link String }
             *     
             */
            public String getBeginDateTime() {
                return beginDateTime;
            }

            /**
             * Sets the value of the beginDateTime property.
             * 
             * @param value
             *     allowed object is
             *     {@link String }
             *     
             */
            public void setBeginDateTime(String value) {
                this.beginDateTime = value;
            }

            /**
             * Gets the value of the endDateTime property.
             * 
             * @return
             *     possible object is
             *     {@link String }
             *     
             */
            public String getEndDateTime() {
                return endDateTime;
            }

            /**
             * Sets the value of the endDateTime property.
             * 
             * @param value
             *     allowed object is
             *     {@link String }
             *     
             */
            public void setEndDateTime(String value) {
                this.endDateTime = value;
            }

        }

    }

}
