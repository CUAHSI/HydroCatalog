
package unitvalues;

import javax.xml.bind.annotation.XmlEnum;
import javax.xml.bind.annotation.XmlEnumValue;


/**
 * <p>Java class for QualityControlLevelEnum.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * <p>
 * <pre>
 * &lt;simpleType name="QualityControlLevelEnum">
 *   &lt;restriction base="{http://www.w3.org/2001/XMLSchema}string">
 *     &lt;enumeration value="Raw data"/>
 *     &lt;enumeration value="Quality controlled data"/>
 *     &lt;enumeration value="Derived products"/>
 *     &lt;enumeration value="Interpreted products"/>
 *     &lt;enumeration value="Knowledge products"/>
 *     &lt;enumeration value="Unknown"/>
 *   &lt;/restriction>
 * &lt;/simpleType>
 * </pre>
 * 
 */
@XmlEnum
public enum QualityControlLevelEnum {

    @XmlEnumValue("Derived products")
    DERIVED_PRODUCTS("Derived products"),
    @XmlEnumValue("Interpreted products")
    INTERPRETED_PRODUCTS("Interpreted products"),
    @XmlEnumValue("Knowledge products")
    KNOWLEDGE_PRODUCTS("Knowledge products"),
    @XmlEnumValue("Quality controlled data")
    QUALITY_CONTROLLED_DATA("Quality controlled data"),
    @XmlEnumValue("Raw data")
    RAW_DATA("Raw data"),
    @XmlEnumValue("Unknown")
    UNKNOWN("Unknown");
    private final String value;

    QualityControlLevelEnum(String v) {
        value = v;
    }

    public String value() {
        return value;
    }

    public static QualityControlLevelEnum fromValue(String v) {
        for (QualityControlLevelEnum c: QualityControlLevelEnum.values()) {
            if (c.value.equals(v)) {
                return c;
            }
        }
        throw new IllegalArgumentException(v.toString());
    }

}
