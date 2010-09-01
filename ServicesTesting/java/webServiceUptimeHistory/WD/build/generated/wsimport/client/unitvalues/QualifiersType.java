
package unitvalues;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;
import javax.xml.bind.annotation.adapters.CollapsedStringAdapter;
import javax.xml.bind.annotation.adapters.XmlJavaTypeAdapter;
import unitvalues.QualifiersType.Qualifier;


/**
 * qualifying comments that accompany the data
 * 
 * <p>Java class for QualifiersType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="QualifiersType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="qualifier">
 *           &lt;complexType>
 *             &lt;complexContent>
 *               &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *                 &lt;sequence>
 *                   &lt;element name="qualifierCode" type="{http://www.w3.org/2001/XMLSchema}token"/>
 *                 &lt;/sequence>
 *                 &lt;attGroup ref="{http://www.cuahsi.org/waterML/1.0/}VocabularyAttributes"/>
 *                 &lt;attribute name="qualifierID" type="{http://www.w3.org/2001/XMLSchema}int" />
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
@XmlType(name = "QualifiersType", propOrder = {
    "qualifier"
})
public class QualifiersType {

    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
    protected Qualifier qualifier;

    /**
     * Gets the value of the qualifier property.
     * 
     * @return
     *     possible object is
     *     {@link Qualifier }
     *     
     */
    public Qualifier getQualifier() {
        return qualifier;
    }

    /**
     * Sets the value of the qualifier property.
     * 
     * @param value
     *     allowed object is
     *     {@link Qualifier }
     *     
     */
    public void setQualifier(Qualifier value) {
        this.qualifier = value;
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
     *         &lt;element name="qualifierCode" type="{http://www.w3.org/2001/XMLSchema}token"/>
     *       &lt;/sequence>
     *       &lt;attGroup ref="{http://www.cuahsi.org/waterML/1.0/}VocabularyAttributes"/>
     *       &lt;attribute name="qualifierID" type="{http://www.w3.org/2001/XMLSchema}int" />
     *     &lt;/restriction>
     *   &lt;/complexContent>
     * &lt;/complexType>
     * </pre>
     * 
     * 
     */
    @XmlAccessorType(XmlAccessType.FIELD)
    @XmlType(name = "", propOrder = {
        "qualifierCode"
    })
    public static class Qualifier {

        @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
        @XmlJavaTypeAdapter(CollapsedStringAdapter.class)
        protected String qualifierCode;
        @XmlAttribute
        protected Integer qualifierID;
        @XmlAttribute(name = "default")
        protected Boolean _default;
        @XmlAttribute
        protected String network;
        @XmlAttribute
        protected String vocabulary;

        /**
         * Gets the value of the qualifierCode property.
         * 
         * @return
         *     possible object is
         *     {@link String }
         *     
         */
        public String getQualifierCode() {
            return qualifierCode;
        }

        /**
         * Sets the value of the qualifierCode property.
         * 
         * @param value
         *     allowed object is
         *     {@link String }
         *     
         */
        public void setQualifierCode(String value) {
            this.qualifierCode = value;
        }

        /**
         * Gets the value of the qualifierID property.
         * 
         * @return
         *     possible object is
         *     {@link Integer }
         *     
         */
        public Integer getQualifierID() {
            return qualifierID;
        }

        /**
         * Sets the value of the qualifierID property.
         * 
         * @param value
         *     allowed object is
         *     {@link Integer }
         *     
         */
        public void setQualifierID(Integer value) {
            this.qualifierID = value;
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
