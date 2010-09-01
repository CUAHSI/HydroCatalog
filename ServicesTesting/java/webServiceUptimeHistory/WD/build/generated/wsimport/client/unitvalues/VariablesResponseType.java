
package unitvalues;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;


/**
 * VariablesResponseType is object type returned by the method GetVariableInfo. The elemnt name is variablesResponse.  The request will contain a variables element containing a list of variable elements.
 * 
 * <p>Java class for VariablesResponseType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="VariablesResponseType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="queryInfo" type="{http://www.cuahsi.org/waterML/1.0/}QueryInfoType" minOccurs="0"/>
 *         &lt;element ref="{http://www.cuahsi.org/waterML/1.0/}variables"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "VariablesResponseType", propOrder = {
    "queryInfo",
    "variables"
})
public class VariablesResponseType {

    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected QueryInfoType queryInfo;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
    protected Variables variables;

    /**
     * Gets the value of the queryInfo property.
     * 
     * @return
     *     possible object is
     *     {@link QueryInfoType }
     *     
     */
    public QueryInfoType getQueryInfo() {
        return queryInfo;
    }

    /**
     * Sets the value of the queryInfo property.
     * 
     * @param value
     *     allowed object is
     *     {@link QueryInfoType }
     *     
     */
    public void setQueryInfo(QueryInfoType value) {
        this.queryInfo = value;
    }

    /**
     * variables element contains a list of variable elements
     * 
     * @return
     *     possible object is
     *     {@link Variables }
     *     
     */
    public Variables getVariables() {
        return variables;
    }

    /**
     * variables element contains a list of variable elements
     * 
     * @param value
     *     allowed object is
     *     {@link Variables }
     *     
     */
    public void setVariables(Variables value) {
        this.variables = value;
    }

}
