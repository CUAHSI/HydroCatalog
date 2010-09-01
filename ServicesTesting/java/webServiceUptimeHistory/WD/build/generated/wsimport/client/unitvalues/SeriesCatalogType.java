
package unitvalues;

import java.util.ArrayList;
import java.util.List;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;
import javax.xml.bind.annotation.XmlValue;
import unitvalues.SeriesCatalogType.Series;
import unitvalues.SeriesCatalogType.Series.ValueCount;


/**
 * Series catalog represents a list of series, where each  separate data series are for the purposes of identifying or displaying what data are available at each site. 
 * 
 * <p>Java class for seriesCatalogType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="seriesCatalogType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="note" type="{http://www.cuahsi.org/waterML/1.0/}NoteType" maxOccurs="unbounded" minOccurs="0"/>
 *         &lt;element name="series" maxOccurs="unbounded" minOccurs="0">
 *           &lt;complexType>
 *             &lt;complexContent>
 *               &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *                 &lt;sequence>
 *                   &lt;element name="dataType" type="{http://www.cuahsi.org/waterML/1.0/}dataTypeEnum" minOccurs="0"/>
 *                   &lt;element name="variable" type="{http://www.cuahsi.org/waterML/1.0/}VariableInfoType"/>
 *                   &lt;element name="valueCount">
 *                     &lt;complexType>
 *                       &lt;simpleContent>
 *                         &lt;extension base="&lt;http://www.w3.org/2001/XMLSchema>int">
 *                           &lt;attribute name="countIsEstimated" type="{http://www.w3.org/2001/XMLSchema}boolean" />
 *                         &lt;/extension>
 *                       &lt;/simpleContent>
 *                     &lt;/complexType>
 *                   &lt;/element>
 *                   &lt;element name="variableTimeInterval" type="{http://www.cuahsi.org/waterML/1.0/}TimePeriodType"/>
 *                   &lt;element name="valueType" type="{http://www.cuahsi.org/waterML/1.0/}valueTypeEnum" minOccurs="0"/>
 *                   &lt;element name="generalCategory" type="{http://www.cuahsi.org/waterML/1.0/}generalCategoryEnum" minOccurs="0"/>
 *                   &lt;element name="sampleMedium" type="{http://www.cuahsi.org/waterML/1.0/}SampleMediumEnum" minOccurs="0"/>
 *                   &lt;element name="Method" type="{http://www.cuahsi.org/waterML/1.0/}MethodType" minOccurs="0"/>
 *                   &lt;element name="Source" type="{http://www.cuahsi.org/waterML/1.0/}SourceType" minOccurs="0"/>
 *                   &lt;element name="QualityControlLevel" type="{http://www.cuahsi.org/waterML/1.0/}QualityControlLevelType" minOccurs="0"/>
 *                   &lt;element ref="{http://www.cuahsi.org/waterML/1.0/}extension" minOccurs="0"/>
 *                 &lt;/sequence>
 *               &lt;/restriction>
 *             &lt;/complexContent>
 *           &lt;/complexType>
 *         &lt;/element>
 *         &lt;element ref="{http://www.cuahsi.org/waterML/1.0/}extension" minOccurs="0"/>
 *       &lt;/sequence>
 *       &lt;attribute name="menuGroupName" type="{http://www.w3.org/2001/XMLSchema}string" />
 *       &lt;attribute name="serviceWsdl" type="{http://www.w3.org/2001/XMLSchema}anyURI" />
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "seriesCatalogType", propOrder = {
    "note",
    "series",
    "extension"
})
public class SeriesCatalogType {

    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
    protected List<NoteType> note;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
    protected List<Series> series;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected Object extension;
    @XmlAttribute
    protected String menuGroupName;
    @XmlAttribute
    protected String serviceWsdl;

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
     * Gets the value of the series property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the series property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getSeries().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link Series }
     * 
     * 
     */
    public List<Series> getSeries() {
        if (series == null) {
            series = new ArrayList<Series>();
        }
        return this.series;
    }

    /**
     * Gets the value of the extension property.
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
     * Sets the value of the extension property.
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
     * Gets the value of the menuGroupName property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getMenuGroupName() {
        return menuGroupName;
    }

    /**
     * Sets the value of the menuGroupName property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setMenuGroupName(String value) {
        this.menuGroupName = value;
    }

    /**
     * Gets the value of the serviceWsdl property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getServiceWsdl() {
        return serviceWsdl;
    }

    /**
     * Sets the value of the serviceWsdl property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setServiceWsdl(String value) {
        this.serviceWsdl = value;
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
     *         &lt;element name="dataType" type="{http://www.cuahsi.org/waterML/1.0/}dataTypeEnum" minOccurs="0"/>
     *         &lt;element name="variable" type="{http://www.cuahsi.org/waterML/1.0/}VariableInfoType"/>
     *         &lt;element name="valueCount">
     *           &lt;complexType>
     *             &lt;simpleContent>
     *               &lt;extension base="&lt;http://www.w3.org/2001/XMLSchema>int">
     *                 &lt;attribute name="countIsEstimated" type="{http://www.w3.org/2001/XMLSchema}boolean" />
     *               &lt;/extension>
     *             &lt;/simpleContent>
     *           &lt;/complexType>
     *         &lt;/element>
     *         &lt;element name="variableTimeInterval" type="{http://www.cuahsi.org/waterML/1.0/}TimePeriodType"/>
     *         &lt;element name="valueType" type="{http://www.cuahsi.org/waterML/1.0/}valueTypeEnum" minOccurs="0"/>
     *         &lt;element name="generalCategory" type="{http://www.cuahsi.org/waterML/1.0/}generalCategoryEnum" minOccurs="0"/>
     *         &lt;element name="sampleMedium" type="{http://www.cuahsi.org/waterML/1.0/}SampleMediumEnum" minOccurs="0"/>
     *         &lt;element name="Method" type="{http://www.cuahsi.org/waterML/1.0/}MethodType" minOccurs="0"/>
     *         &lt;element name="Source" type="{http://www.cuahsi.org/waterML/1.0/}SourceType" minOccurs="0"/>
     *         &lt;element name="QualityControlLevel" type="{http://www.cuahsi.org/waterML/1.0/}QualityControlLevelType" minOccurs="0"/>
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
    @XmlType(name = "", propOrder = {
        "dataType",
        "variable",
        "valueCount",
        "variableTimeInterval",
        "valueType",
        "generalCategory",
        "sampleMedium",
        "method",
        "source",
        "qualityControlLevel",
        "extension"
    })
    public static class Series {

        @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
        protected String dataType;
        @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
        protected VariableInfoType variable;
        @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
        protected ValueCount valueCount;
        @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
        protected TimePeriodType variableTimeInterval;
        @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
        protected ValueTypeEnum valueType;
        @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
        protected GeneralCategoryEnum generalCategory;
        @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
        protected SampleMediumEnum sampleMedium;
        @XmlElement(name = "Method", namespace = "http://www.cuahsi.org/waterML/1.0/")
        protected MethodType method;
        @XmlElement(name = "Source", namespace = "http://www.cuahsi.org/waterML/1.0/")
        protected SourceType source;
        @XmlElement(name = "QualityControlLevel", namespace = "http://www.cuahsi.org/waterML/1.0/")
        protected QualityControlLevelType qualityControlLevel;
        @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
        protected Object extension;

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
         * Gets the value of the variable property.
         * 
         * @return
         *     possible object is
         *     {@link VariableInfoType }
         *     
         */
        public VariableInfoType getVariable() {
            return variable;
        }

        /**
         * Sets the value of the variable property.
         * 
         * @param value
         *     allowed object is
         *     {@link VariableInfoType }
         *     
         */
        public void setVariable(VariableInfoType value) {
            this.variable = value;
        }

        /**
         * Gets the value of the valueCount property.
         * 
         * @return
         *     possible object is
         *     {@link ValueCount }
         *     
         */
        public ValueCount getValueCount() {
            return valueCount;
        }

        /**
         * Sets the value of the valueCount property.
         * 
         * @param value
         *     allowed object is
         *     {@link ValueCount }
         *     
         */
        public void setValueCount(ValueCount value) {
            this.valueCount = value;
        }

        /**
         * Gets the value of the variableTimeInterval property.
         * 
         * @return
         *     possible object is
         *     {@link TimePeriodType }
         *     
         */
        public TimePeriodType getVariableTimeInterval() {
            return variableTimeInterval;
        }

        /**
         * Sets the value of the variableTimeInterval property.
         * 
         * @param value
         *     allowed object is
         *     {@link TimePeriodType }
         *     
         */
        public void setVariableTimeInterval(TimePeriodType value) {
            this.variableTimeInterval = value;
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
         * Gets the value of the method property.
         * 
         * @return
         *     possible object is
         *     {@link MethodType }
         *     
         */
        public MethodType getMethod() {
            return method;
        }

        /**
         * Sets the value of the method property.
         * 
         * @param value
         *     allowed object is
         *     {@link MethodType }
         *     
         */
        public void setMethod(MethodType value) {
            this.method = value;
        }

        /**
         * Gets the value of the source property.
         * 
         * @return
         *     possible object is
         *     {@link SourceType }
         *     
         */
        public SourceType getSource() {
            return source;
        }

        /**
         * Sets the value of the source property.
         * 
         * @param value
         *     allowed object is
         *     {@link SourceType }
         *     
         */
        public void setSource(SourceType value) {
            this.source = value;
        }

        /**
         * Gets the value of the qualityControlLevel property.
         * 
         * @return
         *     possible object is
         *     {@link QualityControlLevelType }
         *     
         */
        public QualityControlLevelType getQualityControlLevel() {
            return qualityControlLevel;
        }

        /**
         * Sets the value of the qualityControlLevel property.
         * 
         * @param value
         *     allowed object is
         *     {@link QualityControlLevelType }
         *     
         */
        public void setQualityControlLevel(QualityControlLevelType value) {
            this.qualityControlLevel = value;
        }

        /**
         * Gets the value of the extension property.
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
         * Sets the value of the extension property.
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
         *   &lt;simpleContent>
         *     &lt;extension base="&lt;http://www.w3.org/2001/XMLSchema>int">
         *       &lt;attribute name="countIsEstimated" type="{http://www.w3.org/2001/XMLSchema}boolean" />
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
        public static class ValueCount {

            @XmlValue
            protected int value;
            @XmlAttribute
            protected Boolean countIsEstimated;

            /**
             * Gets the value of the value property.
             * 
             */
            public int getValue() {
                return value;
            }

            /**
             * Sets the value of the value property.
             * 
             */
            public void setValue(int value) {
                this.value = value;
            }

            /**
             * Gets the value of the countIsEstimated property.
             * 
             * @return
             *     possible object is
             *     {@link Boolean }
             *     
             */
            public Boolean isCountIsEstimated() {
                return countIsEstimated;
            }

            /**
             * Sets the value of the countIsEstimated property.
             * 
             * @param value
             *     allowed object is
             *     {@link Boolean }
             *     
             */
            public void setCountIsEstimated(Boolean value) {
                this.countIsEstimated = value;
            }

        }

    }

}
