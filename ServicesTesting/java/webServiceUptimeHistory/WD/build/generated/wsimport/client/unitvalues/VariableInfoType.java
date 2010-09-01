
package unitvalues;

import java.util.ArrayList;
import java.util.List;
import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlElementRef;
import javax.xml.bind.annotation.XmlElements;
import javax.xml.bind.annotation.XmlType;
import javax.xml.bind.annotation.XmlValue;
import javax.xml.bind.annotation.adapters.NormalizedStringAdapter;
import javax.xml.bind.annotation.adapters.XmlJavaTypeAdapter;
import javax.xml.datatype.XMLGregorianCalendar;
import unitvalues.VariableInfoType.Related;
import unitvalues.VariableInfoType.Related.ParentID;
import unitvalues.VariableInfoType.Related.RelatedID;
import unitvalues.VariableInfoType.TimeSupport;


/**
 * VariableInfoType is a complex type containting full descriptive information about a variable, as described by the ODM. This includes one or more variable codes, the short variable name, a detailed variable description, and suggest
 * 
 * It also extends the ODM model, in several methods:
 * - options contain extended reuqest information. 
 * - note(s) are for generic extenstion.
 * - extension is an element where additional namespace information should be placed.
 * - related allows for parent and child relationships between variables to be communicated.
 * 
 * 
 * 
 * <p>Java class for VariableInfoType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="VariableInfoType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.cuahsi.org/waterML/1.0/}variableCode" maxOccurs="unbounded"/>
 *         &lt;element name="variableName" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="variableDescription" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="valueType" type="{http://www.cuahsi.org/waterML/1.0/}valueTypeEnum" minOccurs="0"/>
 *         &lt;element name="dataType" type="{http://www.cuahsi.org/waterML/1.0/}dataTypeEnum" minOccurs="0"/>
 *         &lt;element name="generalCategory" type="{http://www.cuahsi.org/waterML/1.0/}generalCategoryEnum" minOccurs="0"/>
 *         &lt;element name="sampleMedium" type="{http://www.cuahsi.org/waterML/1.0/}SampleMediumEnum" minOccurs="0"/>
 *         &lt;element ref="{http://www.cuahsi.org/waterML/1.0/}units" minOccurs="0"/>
 *         &lt;element ref="{http://www.cuahsi.org/waterML/1.0/}options" minOccurs="0"/>
 *         &lt;element name="note" type="{http://www.cuahsi.org/waterML/1.0/}NoteType" maxOccurs="unbounded" minOccurs="0"/>
 *         &lt;element name="related" minOccurs="0">
 *           &lt;complexType>
 *             &lt;complexContent>
 *               &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *                 &lt;sequence maxOccurs="unbounded">
 *                   &lt;element name="parentID">
 *                     &lt;complexType>
 *                       &lt;simpleContent>
 *                         &lt;extension base="&lt;http://www.w3.org/2001/XMLSchema>string">
 *                           &lt;attGroup ref="{http://www.cuahsi.org/waterML/1.0/}VocabularyAttributes"/>
 *                         &lt;/extension>
 *                       &lt;/simpleContent>
 *                     &lt;/complexType>
 *                   &lt;/element>
 *                   &lt;element name="relatedID">
 *                     &lt;complexType>
 *                       &lt;simpleContent>
 *                         &lt;extension base="&lt;http://www.w3.org/2001/XMLSchema>string">
 *                           &lt;attGroup ref="{http://www.cuahsi.org/waterML/1.0/}VocabularyAttributes"/>
 *                         &lt;/extension>
 *                       &lt;/simpleContent>
 *                     &lt;/complexType>
 *                   &lt;/element>
 *                 &lt;/sequence>
 *               &lt;/restriction>
 *             &lt;/complexContent>
 *           &lt;/complexType>
 *         &lt;/element>
 *         &lt;element ref="{http://www.cuahsi.org/waterML/1.0/}extension" minOccurs="0"/>
 *         &lt;element name="NoDataValue" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *         &lt;element name="timeSupport" minOccurs="0">
 *           &lt;complexType>
 *             &lt;complexContent>
 *               &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *                 &lt;sequence>
 *                   &lt;element name="unit" type="{http://www.cuahsi.org/waterML/1.0/}UnitsType" minOccurs="0"/>
 *                   &lt;element name="timeInterval" type="{http://www.w3.org/2001/XMLSchema}int" minOccurs="0"/>
 *                 &lt;/sequence>
 *                 &lt;attribute name="isRegular" type="{http://www.w3.org/2001/XMLSchema}boolean" />
 *               &lt;/restriction>
 *             &lt;/complexContent>
 *           &lt;/complexType>
 *         &lt;/element>
 *       &lt;/sequence>
 *       &lt;attGroup ref="{http://www.cuahsi.org/waterML/1.0/}DbIdentifiers"/>
 *       &lt;attGroup ref="{http://www.cuahsi.org/waterML/1.0/}VocabularyAttributes"/>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "VariableInfoType", propOrder = {
    "variableCode",
    "variableName",
    "variableDescription",
    "valueType",
    "dataType",
    "generalCategory",
    "sampleMedium",
    "units",
    "options",
    "note",
    "related",
    "extension",
    "noDataValue",
    "timeSupport"
})
public class VariableInfoType {

    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
    protected List<VariableCode> variableCode;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected String variableName;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected String variableDescription;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected ValueTypeEnum valueType;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected String dataType;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected GeneralCategoryEnum generalCategory;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected SampleMediumEnum sampleMedium;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected Units units;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected Options options;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
    protected List<NoteType> note;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected Related related;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected Object extension;
    @XmlElement(name = "NoDataValue", namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected String noDataValue;
    @XmlElementRef(name = "timeSupport", namespace = "http://www.cuahsi.org/waterML/1.0/", type = JAXBElement.class)
    protected JAXBElement<TimeSupport> timeSupport;
    @XmlAttribute
    protected XMLGregorianCalendar metadataDateTime;
    @XmlAttribute
    @XmlJavaTypeAdapter(NormalizedStringAdapter.class)
    protected String oid;
    @XmlAttribute(name = "default")
    protected Boolean _default;
    @XmlAttribute
    protected String network;
    @XmlAttribute
    protected String vocabulary;

    /**
     * One of more elements representing the Text code used by the organization that collects the data to identify the variable.Gets the value of the variableCode property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the variableCode property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getVariableCode().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link VariableCode }
     * 
     * 
     */
    public List<VariableCode> getVariableCode() {
        if (variableCode == null) {
            variableCode = new ArrayList<VariableCode>();
        }
        return this.variableCode;
    }

    /**
     * Gets the value of the variableName property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getVariableName() {
        return variableName;
    }

    /**
     * Sets the value of the variableName property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setVariableName(String value) {
        this.variableName = value;
    }

    /**
     * Gets the value of the variableDescription property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getVariableDescription() {
        return variableDescription;
    }

    /**
     * Sets the value of the variableDescription property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setVariableDescription(String value) {
        this.variableDescription = value;
    }

    /**
     * Gets the value of the valueType property.
     * 
     * @return
     *     possible object is
     *     {@link ValueTypeEnum }
     *     
     */
    public ValueTypeEnum getValueType() {
        return valueType;
    }

    /**
     * Sets the value of the valueType property.
     * 
     * @param value
     *     allowed object is
     *     {@link ValueTypeEnum }
     *     
     */
    public void setValueType(ValueTypeEnum value) {
        this.valueType = value;
    }

    /**
     * Gets the value of the dataType property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getDataType() {
        return dataType;
    }

    /**
     * Sets the value of the dataType property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setDataType(String value) {
        this.dataType = value;
    }

    /**
     * Gets the value of the generalCategory property.
     * 
     * @return
     *     possible object is
     *     {@link GeneralCategoryEnum }
     *     
     */
    public GeneralCategoryEnum getGeneralCategory() {
        return generalCategory;
    }

    /**
     * Sets the value of the generalCategory property.
     * 
     * @param value
     *     allowed object is
     *     {@link GeneralCategoryEnum }
     *     
     */
    public void setGeneralCategory(GeneralCategoryEnum value) {
        this.generalCategory = value;
    }

    /**
     * Gets the value of the sampleMedium property.
     * 
     * @return
     *     possible object is
     *     {@link SampleMediumEnum }
     *     
     */
    public SampleMediumEnum getSampleMedium() {
        return sampleMedium;
    }

    /**
     * Sets the value of the sampleMedium property.
     * 
     * @param value
     *     allowed object is
     *     {@link SampleMediumEnum }
     *     
     */
    public void setSampleMedium(SampleMediumEnum value) {
        this.sampleMedium = value;
    }

    /**
     * The units of the measurements asociated withthe variable.
     * 
     * This will be changed to UnitsType in WaterML 1.1
     * 
     * @return
     *     possible object is
     *     {@link Units }
     *     
     */
    public Units getUnits() {
        return units;
    }

    /**
     * The units of the measurements asociated withthe variable.
     * 
     * This will be changed to UnitsType in WaterML 1.1
     * 
     * @param value
     *     allowed object is
     *     {@link Units }
     *     
     */
    public void setUnits(Units value) {
        this.units = value;
    }

    /**
     * A list of options. Option elements are key-value pair elements that control how a variable maght be utilized in a service.
     *             Examples:
     *  MODIS web service. Information is aggreated over land or ocean or both. The plotarea option can include: plotarea=land, plotarea=land, plotarea=landocean
     * 
     * USGS uses a statistic code, 0003, to repesent a  value type of 'Average'. The USGS statistic codes also several options that do not fit the ODM data model. 
     * 
     * @return
     *     possible object is
     *     {@link Options }
     *     
     */
    public Options getOptions() {
        return options;
    }

    /**
     * A list of options. Option elements are key-value pair elements that control how a variable maght be utilized in a service.
     *             Examples:
     *  MODIS web service. Information is aggreated over land or ocean or both. The plotarea option can include: plotarea=land, plotarea=land, plotarea=landocean
     * 
     * USGS uses a statistic code, 0003, to repesent a  value type of 'Average'. The USGS statistic codes also several options that do not fit the ODM data model. 
     * 
     * @param value
     *     allowed object is
     *     {@link Options }
     *     
     */
    public void setOptions(Options value) {
        this.options = value;
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
     * Gets the value of the related property.
     * 
     * @return
     *     possible object is
     *     {@link Related }
     *     
     */
    public Related getRelated() {
        return related;
    }

    /**
     * Sets the value of the related property.
     * 
     * @param value
     *     allowed object is
     *     {@link Related }
     *     
     */
    public void setRelated(Related value) {
        this.related = value;
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
     * Gets the value of the noDataValue property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getNoDataValue() {
        return noDataValue;
    }

    /**
     * Sets the value of the noDataValue property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setNoDataValue(String value) {
        this.noDataValue = value;
    }

    /**
     * Gets the value of the timeSupport property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link TimeSupport }{@code >}
     *     
     */
    public JAXBElement<TimeSupport> getTimeSupport() {
        return timeSupport;
    }

    /**
     * Sets the value of the timeSupport property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link TimeSupport }{@code >}
     *     
     */
    public void setTimeSupport(JAXBElement<TimeSupport> value) {
        this.timeSupport = ((JAXBElement<TimeSupport> ) value);
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
     * Gets the value of the default property.
     * 
     * @return
     *     possible object is
     *     {@link Boolean }
     *     
     */
    public Boolean isDefault() {
        return _default;
    }

    /**
     * Sets the value of the default property.
     * 
     * @param value
     *     allowed object is
     *     {@link Boolean }
     *     
     */
    public void setDefault(Boolean value) {
        this._default = value;
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
     * Gets the value of the vocabulary property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getVocabulary() {
        return vocabulary;
    }

    /**
     * Sets the value of the vocabulary property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setVocabulary(String value) {
        this.vocabulary = value;
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
     *       &lt;sequence maxOccurs="unbounded">
     *         &lt;element name="parentID">
     *           &lt;complexType>
     *             &lt;simpleContent>
     *               &lt;extension base="&lt;http://www.w3.org/2001/XMLSchema>string">
     *                 &lt;attGroup ref="{http://www.cuahsi.org/waterML/1.0/}VocabularyAttributes"/>
     *               &lt;/extension>
     *             &lt;/simpleContent>
     *           &lt;/complexType>
     *         &lt;/element>
     *         &lt;element name="relatedID">
     *           &lt;complexType>
     *             &lt;simpleContent>
     *               &lt;extension base="&lt;http://www.w3.org/2001/XMLSchema>string">
     *                 &lt;attGroup ref="{http://www.cuahsi.org/waterML/1.0/}VocabularyAttributes"/>
     *               &lt;/extension>
     *             &lt;/simpleContent>
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
        "parentIDAndRelatedID"
    })
    public static class Related {

        @XmlElements({
            @XmlElement(name = "parentID", namespace = "http://www.cuahsi.org/waterML/1.0/", required = true, type = ParentID.class),
            @XmlElement(name = "relatedID", namespace = "http://www.cuahsi.org/waterML/1.0/", required = true, type = RelatedID.class)
        })
        protected List<Object> parentIDAndRelatedID;

        /**
         * Gets the value of the parentIDAndRelatedID property.
         * 
         * <p>
         * This accessor method returns a reference to the live list,
         * not a snapshot. Therefore any modification you make to the
         * returned list will be present inside the JAXB object.
         * This is why there is not a <CODE>set</CODE> method for the parentIDAndRelatedID property.
         * 
         * <p>
         * For example, to add a new item, do as follows:
         * <pre>
         *    getParentIDAndRelatedID().add(newItem);
         * </pre>
         * 
         * 
         * <p>
         * Objects of the following type(s) are allowed in the list
         * {@link ParentID }
         * {@link RelatedID }
         * 
         * 
         */
        public List<Object> getParentIDAndRelatedID() {
            if (parentIDAndRelatedID == null) {
                parentIDAndRelatedID = new ArrayList<Object>();
            }
            return this.parentIDAndRelatedID;
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
         *       &lt;attGroup ref="{http://www.cuahsi.org/waterML/1.0/}VocabularyAttributes"/>
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
        public static class ParentID {

            @XmlValue
            protected String value;
            @XmlAttribute(name = "default")
            protected Boolean _default;
            @XmlAttribute
            protected String network;
            @XmlAttribute
            protected String vocabulary;

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
             * Gets the value of the default property.
             * 
             * @return
             *     possible object is
             *     {@link Boolean }
             *     
             */
            public Boolean isDefault() {
                return _default;
            }

            /**
             * Sets the value of the default property.
             * 
             * @param value
             *     allowed object is
             *     {@link Boolean }
             *     
             */
            public void setDefault(Boolean value) {
                this._default = value;
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
             * Gets the value of the vocabulary property.
             * 
             * @return
             *     possible object is
             *     {@link String }
             *     
             */
            public String getVocabulary() {
                return vocabulary;
            }

            /**
             * Sets the value of the vocabulary property.
             * 
             * @param value
             *     allowed object is
             *     {@link String }
             *     
             */
            public void setVocabulary(String value) {
                this.vocabulary = value;
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
         *       &lt;attGroup ref="{http://www.cuahsi.org/waterML/1.0/}VocabularyAttributes"/>
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
        public static class RelatedID {

            @XmlValue
            protected String value;
            @XmlAttribute(name = "default")
            protected Boolean _default;
            @XmlAttribute
            protected String network;
            @XmlAttribute
            protected String vocabulary;

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
             * Gets the value of the default property.
             * 
             * @return
             *     possible object is
             *     {@link Boolean }
             *     
             */
            public Boolean isDefault() {
                return _default;
            }

            /**
             * Sets the value of the default property.
             * 
             * @param value
             *     allowed object is
             *     {@link Boolean }
             *     
             */
            public void setDefault(Boolean value) {
                this._default = value;
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
             * Gets the value of the vocabulary property.
             * 
             * @return
             *     possible object is
             *     {@link String }
             *     
             */
            public String getVocabulary() {
                return vocabulary;
            }

            /**
             * Sets the value of the vocabulary property.
             * 
             * @param value
             *     allowed object is
             *     {@link String }
             *     
             */
            public void setVocabulary(String value) {
                this.vocabulary = value;
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
     *   &lt;complexContent>
     *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
     *       &lt;sequence>
     *         &lt;element name="unit" type="{http://www.cuahsi.org/waterML/1.0/}UnitsType" minOccurs="0"/>
     *         &lt;element name="timeInterval" type="{http://www.w3.org/2001/XMLSchema}int" minOccurs="0"/>
     *       &lt;/sequence>
     *       &lt;attribute name="isRegular" type="{http://www.w3.org/2001/XMLSchema}boolean" />
     *     &lt;/restriction>
     *   &lt;/complexContent>
     * &lt;/complexType>
     * </pre>
     * 
     * 
     */
    @XmlAccessorType(XmlAccessType.FIELD)
    @XmlType(name = "", propOrder = {
        "unit",
        "timeInterval"
    })
    public static class TimeSupport {

        @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
        protected UnitsType unit;
        @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
        protected Integer timeInterval;
        @XmlAttribute
        protected Boolean isRegular;

        /**
         * Gets the value of the unit property.
         * 
         * @return
         *     possible object is
         *     {@link UnitsType }
         *     
         */
        public UnitsType getUnit() {
            return unit;
        }

        /**
         * Sets the value of the unit property.
         * 
         * @param value
         *     allowed object is
         *     {@link UnitsType }
         *     
         */
        public void setUnit(UnitsType value) {
            this.unit = value;
        }

        /**
         * Gets the value of the timeInterval property.
         * 
         * @return
         *     possible object is
         *     {@link Integer }
         *     
         */
        public Integer getTimeInterval() {
            return timeInterval;
        }

        /**
         * Sets the value of the timeInterval property.
         * 
         * @param value
         *     allowed object is
         *     {@link Integer }
         *     
         */
        public void setTimeInterval(Integer value) {
            this.timeInterval = value;
        }

        /**
         * Gets the value of the isRegular property.
         * 
         * @return
         *     possible object is
         *     {@link Boolean }
         *     
         */
        public Boolean isIsRegular() {
            return isRegular;
        }

        /**
         * Sets the value of the isRegular property.
         * 
         * @param value
         *     allowed object is
         *     {@link Boolean }
         *     
         */
        public void setIsRegular(Boolean value) {
            this.isRegular = value;
        }

    }

}
