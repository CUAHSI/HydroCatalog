
package unitvalues;

import javax.xml.bind.annotation.XmlEnum;
import javax.xml.bind.annotation.XmlEnumValue;


/**
 * <p>Java class for CensorCodeEnum.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * <p>
 * <pre>
 * &lt;simpleType name="CensorCodeEnum">
 *   &lt;restriction base="{http://www.w3.org/2001/XMLSchema}string">
 *     &lt;enumeration value="lt"/>
 *     &lt;enumeration value="gt"/>
 *     &lt;enumeration value="nc"/>
 *     &lt;enumeration value="nd"/>
 *     &lt;enumeration value="pnq"/>
 *   &lt;/restriction>
 * &lt;/simpleType>
 * </pre>
 * 
 */
@XmlEnum
public enum CensorCodeEnum {

    @XmlEnumValue("gt")
    GT("gt"),
    @XmlEnumValue("lt")
    LT("lt"),
    @XmlEnumValue("nc")
    NC("nc"),
    @XmlEnumValue("nd")
    ND("nd"),
    @XmlEnumValue("pnq")
    PNQ("pnq");
    private final String value;

    CensorCodeEnum(String v) {
        value = v;
    }

    public String value() {
        return value;
    }

    public static CensorCodeEnum fromValue(String v) {
        for (CensorCodeEnum c: CensorCodeEnum.values()) {
            if (c.value.equals(v)) {
                return c;
            }
        }
        throw new IllegalArgumentException(v.toString());
    }

}
