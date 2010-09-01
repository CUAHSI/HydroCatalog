
package unitvalues;

import javax.xml.bind.annotation.XmlEnum;
import javax.xml.bind.annotation.XmlEnumValue;


/**
 * <p>Java class for valueTypeEnum.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * <p>
 * <pre>
 * &lt;simpleType name="valueTypeEnum">
 *   &lt;restriction base="{http://www.w3.org/2001/XMLSchema}string">
 *     &lt;enumeration value="Field Observation"/>
 *     &lt;enumeration value="Sample"/>
 *     &lt;enumeration value="Model Simulation Result"/>
 *     &lt;enumeration value="Derived Value"/>
 *     &lt;enumeration value="Unknown"/>
 *   &lt;/restriction>
 * &lt;/simpleType>
 * </pre>
 * 
 */
@XmlEnum
public enum ValueTypeEnum {

    @XmlEnumValue("Derived Value")
    DERIVED_VALUE("Derived Value"),
    @XmlEnumValue("Field Observation")
    FIELD_OBSERVATION("Field Observation"),
    @XmlEnumValue("Model Simulation Result")
    MODEL_SIMULATION_RESULT("Model Simulation Result"),
    @XmlEnumValue("Sample")
    SAMPLE("Sample"),
    @XmlEnumValue("Unknown")
    UNKNOWN("Unknown");
    private final String value;

    ValueTypeEnum(String v) {
        value = v;
    }

    public String value() {
        return value;
    }

    public static ValueTypeEnum fromValue(String v) {
        for (ValueTypeEnum c: ValueTypeEnum.values()) {
            if (c.value.equals(v)) {
                return c;
            }
        }
        throw new IllegalArgumentException(v.toString());
    }

}
