
package unitvalues;

import javax.xml.bind.annotation.XmlEnum;
import javax.xml.bind.annotation.XmlEnumValue;


/**
 * <p>Java class for generalCategoryEnum.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * <p>
 * <pre>
 * &lt;simpleType name="generalCategoryEnum">
 *   &lt;restriction base="{http://www.w3.org/2001/XMLSchema}string">
 *     &lt;enumeration value="Water Quality"/>
 *     &lt;enumeration value="Climate"/>
 *     &lt;enumeration value="Hydrology"/>
 *     &lt;enumeration value="Geology"/>
 *     &lt;enumeration value="Biota"/>
 *     &lt;enumeration value="Unknown"/>
 *     &lt;enumeration value="Instrumentation"/>
 *   &lt;/restriction>
 * &lt;/simpleType>
 * </pre>
 * 
 */
@XmlEnum
public enum GeneralCategoryEnum {

    @XmlEnumValue("Biota")
    BIOTA("Biota"),
    @XmlEnumValue("Climate")
    CLIMATE("Climate"),
    @XmlEnumValue("Geology")
    GEOLOGY("Geology"),
    @XmlEnumValue("Hydrology")
    HYDROLOGY("Hydrology"),
    @XmlEnumValue("Instrumentation")
    INSTRUMENTATION("Instrumentation"),
    @XmlEnumValue("Unknown")
    UNKNOWN("Unknown"),
    @XmlEnumValue("Water Quality")
    WATER_QUALITY("Water Quality");
    private final String value;

    GeneralCategoryEnum(String v) {
        value = v;
    }

    public String value() {
        return value;
    }

    public static GeneralCategoryEnum fromValue(String v) {
        for (GeneralCategoryEnum c: GeneralCategoryEnum.values()) {
            if (c.value.equals(v)) {
                return c;
            }
        }
        throw new IllegalArgumentException(v.toString());
    }

}
