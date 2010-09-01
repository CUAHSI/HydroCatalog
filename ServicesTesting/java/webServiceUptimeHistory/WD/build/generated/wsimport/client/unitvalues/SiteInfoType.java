
package unitvalues;

import java.util.ArrayList;
import java.util.List;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;
import javax.xml.bind.annotation.XmlValue;
import javax.xml.bind.annotation.adapters.NormalizedStringAdapter;
import javax.xml.bind.annotation.adapters.XmlJavaTypeAdapter;
import javax.xml.datatype.XMLGregorianCalendar;
import unitvalues.SiteInfoType.GeoLocation;
import unitvalues.SiteInfoType.GeoLocation.LocalSiteXY;
import unitvalues.SiteInfoType.SiteCode;


/**
 * A sampling station is any place where data are collected.
 * 
 * SiteInfoType is the Element that for the core information about a point sampling location. The core information includes SiteName, SiteCode(s), location, elevation, timeZone information and note(s).
 * 
 * SiteInfoType is <siteInfo> in a <site> of a   <sitesResponse>.  It is derived from SourceType so that other geographic location descriptions can be utilized in the <sourceInfo> of  the <timeSeriesResponse>
 * 
 * 
 * <p>Java class for SiteInfoType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="SiteInfoType">
 *   &lt;complexContent>
 *     &lt;extension base="{http://www.cuahsi.org/waterML/1.0/}SourceInfoType">
 *       &lt;sequence>
 *         &lt;element name="siteName" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="siteCode" maxOccurs="unbounded">
 *           &lt;complexType>
 *             &lt;simpleContent>
 *               &lt;extension base="&lt;http://www.w3.org/2001/XMLSchema>string">
 *                 &lt;attribute name="agencyCode" type="{http://www.w3.org/2001/XMLSchema}normalizedString" />
 *                 &lt;attribute name="agencyName" type="{http://www.w3.org/2001/XMLSchema}normalizedString" />
 *                 &lt;attribute name="defaultId" type="{http://www.w3.org/2001/XMLSchema}boolean" />
 *                 &lt;attribute name="network" use="required" type="{http://www.w3.org/2001/XMLSchema}normalizedString" />
 *                 &lt;attribute name="siteID" type="{http://www.w3.org/2001/XMLSchema}normalizedString" />
 *               &lt;/extension>
 *             &lt;/simpleContent>
 *           &lt;/complexType>
 *         &lt;/element>
 *         &lt;element ref="{http://www.cuahsi.org/waterML/1.0/}timeZoneInfo" minOccurs="0"/>
 *         &lt;element name="geoLocation" minOccurs="0">
 *           &lt;complexType>
 *             &lt;complexContent>
 *               &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *                 &lt;sequence>
 *                   &lt;element name="geogLocation" type="{http://www.cuahsi.org/waterML/1.0/}GeogLocationType"/>
 *                   &lt;element name="localSiteXY" maxOccurs="unbounded" minOccurs="0">
 *                     &lt;complexType>
 *                       &lt;complexContent>
 *                         &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *                           &lt;sequence>
 *                             &lt;element name="X" type="{http://www.w3.org/2001/XMLSchema}double"/>
 *                             &lt;element name="Y" type="{http://www.w3.org/2001/XMLSchema}double"/>
 *                             &lt;element name="Z" type="{http://www.w3.org/2001/XMLSchema}double" minOccurs="0"/>
 *                             &lt;element name="note" type="{http://www.cuahsi.org/waterML/1.0/}NoteType" maxOccurs="unbounded" minOccurs="0"/>
 *                           &lt;/sequence>
 *                           &lt;attribute name="projectionInformation" type="{http://www.w3.org/2001/XMLSchema}string" />
 *                         &lt;/restriction>
 *                       &lt;/complexContent>
 *                     &lt;/complexType>
 *                   &lt;/element>
 *                 &lt;/sequence>
 *               &lt;/restriction>
 *             &lt;/complexContent>
 *           &lt;/complexType>
 *         &lt;/element>
 *         &lt;element name="elevation_m" type="{http://www.w3.org/2001/XMLSchema}double" minOccurs="0"/>
 *         &lt;element name="verticalDatum" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="note" type="{http://www.cuahsi.org/waterML/1.0/}NoteType" maxOccurs="unbounded" minOccurs="0"/>
 *         &lt;element ref="{http://www.cuahsi.org/waterML/1.0/}extension" minOccurs="0"/>
 *         &lt;element name="altname" type="{http://www.w3.org/2001/XMLSchema}string" maxOccurs="unbounded" minOccurs="0"/>
 *       &lt;/sequence>
 *       &lt;attGroup ref="{http://www.cuahsi.org/waterML/1.0/}DbIdentifiers"/>
 *     &lt;/extension>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "SiteInfoType", propOrder = {
    "siteName",
    "siteCode",
    "timeZoneInfo",
    "geoLocation",
    "elevationM",
    "verticalDatum",
    "note",
    "extension",
    "altname"
})
public class SiteInfoType
    extends SourceInfoType
{

    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected String siteName;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
    protected List<SiteCode> siteCode;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected TimeZoneInfo timeZoneInfo;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected GeoLocation geoLocation;
    @XmlElement(name = "elevation_m", namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected Double elevationM;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected String verticalDatum;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
    protected List<NoteType> note;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected Object extension;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
    protected List<String> altname;
    @XmlAttribute
    protected XMLGregorianCalendar metadataDateTime;
    @XmlAttribute
    @XmlJavaTypeAdapter(NormalizedStringAdapter.class)
    protected String oid;

    /**
     * Gets the value of the siteName property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getSiteName() {
        return siteName;
    }

    /**
     * Sets the value of the siteName property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setSiteName(String value) {
        this.siteName = value;
    }

    /**
     * Gets the value of the siteCode property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the siteCode property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getSiteCode().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link SiteCode }
     * 
     * 
     */
    public List<SiteCode> getSiteCode() {
        if (siteCode == null) {
            siteCode = new ArrayList<SiteCode>();
        }
        return this.siteCode;
    }

    /**
     * Specifies the time zone information about a site. 
     * 
     * The default time zone for this site (+00:00) and if this site shifts to daylight savings time (attribute: usesDaylightSavingsTime)
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
     * Specifies the time zone information about a site. 
     * 
     * The default time zone for this site (+00:00) and if this site shifts to daylight savings time (attribute: usesDaylightSavingsTime)
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
     * Gets the value of the geoLocation property.
     * 
     * @return
     *     possible object is
     *     {@link GeoLocation }
     *     
     */
    public GeoLocation getGeoLocation() {
        return geoLocation;
    }

    /**
     * Sets the value of the geoLocation property.
     * 
     * @param value
     *     allowed object is
     *     {@link GeoLocation }
     *     
     */
    public void setGeoLocation(GeoLocation value) {
        this.geoLocation = value;
    }

    /**
     * Gets the value of the elevationM property.
     * 
     * @return
     *     possible object is
     *     {@link Double }
     *     
     */
    public Double getElevationM() {
        return elevationM;
    }

    /**
     * Sets the value of the elevationM property.
     * 
     * @param value
     *     allowed object is
     *     {@link Double }
     *     
     */
    public void setElevationM(Double value) {
        this.elevationM = value;
    }

    /**
     * Gets the value of the verticalDatum property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getVerticalDatum() {
        return verticalDatum;
    }

    /**
     * Sets the value of the verticalDatum property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setVerticalDatum(String value) {
        this.verticalDatum = value;
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
     * In order to simplify comprehension, data sources are encouraged to put additional informaiton in the extension area, using thier own namespace. Clients need not understand information in <extension?
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
     * In order to simplify comprehension, data sources are encouraged to put additional informaiton in the extension area, using thier own namespace. Clients need not understand information in <extension?
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
     * Gets the value of the altname property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the altname property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getAltname().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link String }
     * 
     * 
     */
    public List<String> getAltname() {
        if (altname == null) {
            altname = new ArrayList<String>();
        }
        return this.altname;
    }

    /**
     * Gets the value of the metadataDateTime property.
     * 
     * @return
     *     possible object is
     *     {@link XMLGregorianCalendar }
     *     
     */
    public XMLGregorianCalendar getMetadataDateTime() {
        return metadataDateTime;
    }

    /**
     * Sets the value of the metadataDateTime property.
     * 
     * @param value
     *     allowed object is
     *     {@link XMLGregorianCalendar }
     *     
     */
    public void setMetadataDateTime(XMLGregorianCalendar value) {
        this.metadataDateTime = value;
    }

    /**
     * Gets the value of the oid property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getOid() {
        return oid;
    }

    /**
     * Sets the value of the oid property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setOid(String value) {
        this.oid = value;
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
     *         &lt;element name="geogLocation" type="{http://www.cuahsi.org/waterML/1.0/}GeogLocationType"/>
     *         &lt;element name="localSiteXY" maxOccurs="unbounded" minOccurs="0">
     *           &lt;complexType>
     *             &lt;complexContent>
     *               &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
     *                 &lt;sequence>
     *                   &lt;element name="X" type="{http://www.w3.org/2001/XMLSchema}double"/>
     *                   &lt;element name="Y" type="{http://www.w3.org/2001/XMLSchema}double"/>
     *                   &lt;element name="Z" type="{http://www.w3.org/2001/XMLSchema}double" minOccurs="0"/>
     *                   &lt;element name="note" type="{http://www.cuahsi.org/waterML/1.0/}NoteType" maxOccurs="unbounded" minOccurs="0"/>
     *                 &lt;/sequence>
     *                 &lt;attribute name="projectionInformation" type="{http://www.w3.org/2001/XMLSchema}string" />
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
        "geogLocation",
        "localSiteXY"
    })
    public static class GeoLocation {

        @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
        protected GeogLocationType geogLocation;
        @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
        protected List<LocalSiteXY> localSiteXY;

        /**
         * Gets the value of the geogLocation property.
         * 
         * @return
         *     possible object is
         *     {@link GeogLocationType }
         *     
         */
        public GeogLocationType getGeogLocation() {
            return geogLocation;
        }

        /**
         * Sets the value of the geogLocation property.
         * 
         * @param value
         *     allowed object is
         *     {@link GeogLocationType }
         *     
         */
        public void setGeogLocation(GeogLocationType value) {
            this.geogLocation = value;
        }

        /**
         * Gets the value of the localSiteXY property.
         * 
         * <p>
         * This accessor method returns a reference to the live list,
         * not a snapshot. Therefore any modification you make to the
         * returned list will be present inside the JAXB object.
         * This is why there is not a <CODE>set</CODE> method for the localSiteXY property.
         * 
         * <p>
         * For example, to add a new item, do as follows:
         * <pre>
         *    getLocalSiteXY().add(newItem);
         * </pre>
         * 
         * 
         * <p>
         * Objects of the following type(s) are allowed in the list
         * {@link LocalSiteXY }
         * 
         * 
         */
        public List<LocalSiteXY> getLocalSiteXY() {
            if (localSiteXY == null) {
                localSiteXY = new ArrayList<LocalSiteXY>();
            }
            return this.localSiteXY;
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
         *         &lt;element name="X" type="{http://www.w3.org/2001/XMLSchema}double"/>
         *         &lt;element name="Y" type="{http://www.w3.org/2001/XMLSchema}double"/>
         *         &lt;element name="Z" type="{http://www.w3.org/2001/XMLSchema}double" minOccurs="0"/>
         *         &lt;element name="note" type="{http://www.cuahsi.org/waterML/1.0/}NoteType" maxOccurs="unbounded" minOccurs="0"/>
         *       &lt;/sequence>
         *       &lt;attribute name="projectionInformation" type="{http://www.w3.org/2001/XMLSchema}string" />
         *     &lt;/restriction>
         *   &lt;/complexContent>
         * &lt;/complexType>
         * </pre>
         * 
         * 
         */
        @XmlAccessorType(XmlAccessType.FIELD)
        @XmlType(name = "", propOrder = {
            "x",
            "y",
            "z",
            "note"
        })
        public static class LocalSiteXY {

            @XmlElement(name = "X", namespace = "http://www.cuahsi.org/waterML/1.0/")
            protected double x;
            @XmlElement(name = "Y", namespace = "http://www.cuahsi.org/waterML/1.0/")
            protected double y;
            @XmlElement(name = "Z", namespace = "http://www.cuahsi.org/waterML/1.0/")
            protected Double z;
            @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
            protected List<NoteType> note;
            @XmlAttribute
            protected String projectionInformation;

            /**
             * Gets the value of the x property.
             * 
             */
            public double getX() {
                return x;
            }

            /**
             * Sets the value of the x property.
             * 
             */
            public void setX(double value) {
                this.x = value;
            }

            /**
             * Gets the value of the y property.
             * 
             */
            public double getY() {
                return y;
            }

            /**
             * Sets the value of the y property.
             * 
             */
            public void setY(double value) {
                this.y = value;
            }

            /**
             * Gets the value of the z property.
             * 
             * @return
             *     possible object is
             *     {@link Double }
             *     
             */
            public Double getZ() {
                return z;
            }

            /**
             * Sets the value of the z property.
             * 
             * @param value
             *     allowed object is
             *     {@link Double }
             *     
             */
            public void setZ(Double value) {
                this.z = value;
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
             * Gets the value of the projectionInformation property.
             * 
             * @return
             *     possible object is
             *     {@link String }
             *     
             */
            public String getProjectionInformation() {
                return projectionInformation;
            }

            /**
             * Sets the value of the projectionInformation property.
             * 
             * @param value
             *     allowed object is
             *     {@link String }
             *     
             */
            public void setProjectionInformation(String value) {
                this.projectionInformation = value;
            }

        }

    }


    /**
     * <p>Java class for anonymous complex type.
     * 
     * <p>The following schema fragment specifies the expected content contained within this class.
     * 
     * <pre>
     * &lt;complexType>
     *   &lt;simpleContent>
     *     &lt;extension base="&lt;http://www.w3.org/2001/XMLSchema>string">
     *       &lt;attribute name="agencyCode" type="{http://www.w3.org/2001/XMLSchema}normalizedString" />
     *       &lt;attribute name="agencyName" type="{http://www.w3.org/2001/XMLSchema}normalizedString" />
     *       &lt;attribute name="defaultId" type="{http://www.w3.org/2001/XMLSchema}boolean" />
     *       &lt;attribute name="network" use="required" type="{http://www.w3.org/2001/XMLSchema}normalizedString" />
     *       &lt;attribute name="siteID" type="{http://www.w3.org/2001/XMLSchema}normalizedString" />
     *     &lt;/extension>
     *   &lt;/simpleContent>
     * &lt;/complexType>
     * </pre>
     * 
     * 
     */
    @XmlAccessorType(XmlAccessType.FIELD)
    @XmlType(name = "", propOrder = {
        "value"
    })
    public static class SiteCode {

        @XmlValue
        protected String value;
        @XmlAttribute
        @XmlJavaTypeAdapter(NormalizedStringAdapter.class)
        protected String agencyCode;
        @XmlAttribute
        @XmlJavaTypeAdapter(NormalizedStringAdapter.class)
        protected String agencyName;
        @XmlAttribute
        protected Boolean defaultId;
        @XmlAttribute(required = true)
        @XmlJavaTypeAdapter(NormalizedStringAdapter.class)
        protected String network;
        @XmlAttribute
        @XmlJavaTypeAdapter(NormalizedStringAdapter.class)
        protected String siteID;

        /**
         * Gets the value of the value property.
         * 
         * @return
         *     possible object is
         *     {@link String }
         *     
         */
        public String getValue() {
            return value;
        }

        /**
         * Sets the value of the value property.
         * 
         * @param value
         *     allowed object is
         *     {@link String }
         *     
         */
        public void setValue(String value) {
            this.value = value;
        }

        /**
         * Gets the value of the agencyCode property.
         * 
         * @return
         *     possible object is
         *     {@link String }
         *     
         */
        public String getAgencyCode() {
            return agencyCode;
        }

        /**
         * Sets the value of the agencyCode property.
         * 
         * @param value
         *     allowed object is
         *     {@link String }
         *     
         */
        public void setAgencyCode(String value) {
            this.agencyCode = value;
        }

        /**
         * Gets the value of the agencyName property.
         * 
         * @return
         *     possible object is
         *     {@link String }
         *     
         */
        public String getAgencyName() {
            return agencyName;
        }

        /**
         * Sets the value of the agencyName property.
         * 
         * @param value
         *     allowed object is
         *     {@link String }
         *     
         */
        public void setAgencyName(String value) {
            this.agencyName = value;
        }

        /**
         * Gets the value of the defaultId property.
         * 
         * @return
         *     possible object is
         *     {@link Boolean }
         *     
         */
        public Boolean isDefaultId() {
            return defaultId;
        }

        /**
         * Sets the value of the defaultId property.
         * 
         * @param value
         *     allowed object is
         *     {@link Boolean }
         *     
         */
        public void setDefaultId(Boolean value) {
            this.defaultId = value;
        }

        /**
         * Gets the value of the network property.
         * 
         * @return
         *     possible object is
         *     {@link String }
         *     
         */
        public String getNetwork() {
            return network;
        }

        /**
         * Sets the value of the network property.
         * 
         * @param value
         *     allowed object is
         *     {@link String }
         *     
         */
        public void setNetwork(String value) {
            this.network = value;
        }

        /**
         * Gets the value of the siteID property.
         * 
         * @return
         *     possible object is
         *     {@link String }
         *     
         */
        public String getSiteID() {
            return siteID;
        }

        /**
         * Sets the value of the siteID property.
         * 
         * @param value
         *     allowed object is
         *     {@link String }
         *     
         */
        public void setSiteID(String value) {
            this.siteID = value;
        }

    }

}
