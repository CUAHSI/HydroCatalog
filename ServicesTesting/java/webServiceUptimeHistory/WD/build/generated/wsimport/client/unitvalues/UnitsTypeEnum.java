
package unitvalues;

import javax.xml.bind.annotation.XmlEnum;
import javax.xml.bind.annotation.XmlEnumValue;


/**
 * <p>Java class for UnitsTypeEnum.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * <p>
 * <pre>
 * &lt;simpleType name="UnitsTypeEnum">
 *   &lt;restriction base="{http://www.w3.org/2001/XMLSchema}string">
 *     &lt;enumeration value="Angle"/>
 *     &lt;enumeration value="Area"/>
 *     &lt;enumeration value="Dimensionless"/>
 *     &lt;enumeration value="Energy"/>
 *     &lt;enumeration value="Energy Flux"/>
 *     &lt;enumeration value="Flow"/>
 *     &lt;enumeration value="Force"/>
 *     &lt;enumeration value="Frequency"/>
 *     &lt;enumeration value="Length"/>
 *     &lt;enumeration value="Light"/>
 *     &lt;enumeration value="Mass"/>
 *     &lt;enumeration value="Permeability"/>
 *     &lt;enumeration value="Power"/>
 *     &lt;enumeration value="Pressure/Stress"/>
 *     &lt;enumeration value="Resolution"/>
 *     &lt;enumeration value="Scale"/>
 *     &lt;enumeration value="Temperature"/>
 *     &lt;enumeration value="Time"/>
 *     &lt;enumeration value="Velocity"/>
 *     &lt;enumeration value="Volume"/>
 *   &lt;/restriction>
 * &lt;/simpleType>
 * </pre>
 * 
 */
@XmlEnum
public enum UnitsTypeEnum {

    @XmlEnumValue("Angle")
    ANGLE("Angle"),
    @XmlEnumValue("Area")
    AREA("Area"),
    @XmlEnumValue("Dimensionless")
    DIMENSIONLESS("Dimensionless"),
    @XmlEnumValue("Energy")
    ENERGY("Energy"),
    @XmlEnumValue("Energy Flux")
    ENERGY_FLUX("Energy Flux"),
    @XmlEnumValue("Flow")
    FLOW("Flow"),
    @XmlEnumValue("Force")
    FORCE("Force"),
    @XmlEnumValue("Frequency")
    FREQUENCY("Frequency"),
    @XmlEnumValue("Length")
    LENGTH("Length"),
    @XmlEnumValue("Light")
    LIGHT("Light"),
    @XmlEnumValue("Mass")
    MASS("Mass"),
    @XmlEnumValue("Permeability")
    PERMEABILITY("Permeability"),
    @XmlEnumValue("Power")
    POWER("Power"),
    @XmlEnumValue("Pressure/Stress")
    PRESSURE_STRESS("Pressure/Stress"),
    @XmlEnumValue("Resolution")
    RESOLUTION("Resolution"),
    @XmlEnumValue("Scale")
    SCALE("Scale"),
    @XmlEnumValue("Temperature")
    TEMPERATURE("Temperature"),
    @XmlEnumValue("Time")
    TIME("Time"),
    @XmlEnumValue("Velocity")
    VELOCITY("Velocity"),
    @XmlEnumValue("Volume")
    VOLUME("Volume");
    private final String value;

    UnitsTypeEnum(String v) {
        value = v;
    }

    public String value() {
        return value;
    }

    public static UnitsTypeEnum fromValue(String v) {
        for (UnitsTypeEnum c: UnitsTypeEnum.values()) {
            if (c.value.equals(v)) {
                return c;
            }
        }
        throw new IllegalArgumentException(v.toString());
    }

}
