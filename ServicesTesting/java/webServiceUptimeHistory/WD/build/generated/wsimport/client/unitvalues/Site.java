
package unitvalues;

import java.util.ArrayList;
import java.util.List;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;


/**
 * A site element can have two parts: siteInfo, and one or more seriesCatalogs.
 * The siteInfo element contains the basic site information, siteName, location, siteCodes, properties.
 * The seriesCatalog contains the list of observation series conducted at a site.
 * 
 * Rules:
 * GetSites(site[]) or GetSites(null), return no seriesCatalogs elements
 * 
 * GetSiteInfo(site) return all information about a site, including the seriesCatalog.
 * 
 * <p>Java class for site element declaration.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;element name="site">
 *   &lt;complexType>
 *     &lt;complexContent>
 *       &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *         &lt;sequence>
 *           &lt;element name="siteInfo" type="{http://www.cuahsi.org/waterML/1.0/}SiteInfoType"/>
 *           &lt;element name="seriesCatalog" type="{http://www.cuahsi.org/waterML/1.0/}seriesCatalogType" maxOccurs="unbounded" minOccurs="0"/>
 *           &lt;element ref="{http://www.cuahsi.org/waterML/1.0/}extension" minOccurs="0"/>
 *         &lt;/sequence>
 *       &lt;/restriction>
 *     &lt;/complexContent>
 *   &lt;/complexType>
 * &lt;/element>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "", propOrder = {
    "siteInfo",
    "seriesCatalog",
    "extension"
})
@XmlRootElement(name = "site")
public class Site {

    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
    protected SiteInfoType siteInfo;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
    protected List<SeriesCatalogType> seriesCatalog;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected Object extension;

    /**
     * Gets the value of the siteInfo property.
     * 
     * @return
     *     possible object is
     *     {@link SiteInfoType }
     *     
     */
    public SiteInfoType getSiteInfo() {
        return siteInfo;
    }

    /**
     * Sets the value of the siteInfo property.
     * 
     * @param value
     *     allowed object is
     *     {@link SiteInfoType }
     *     
     */
    public void setSiteInfo(SiteInfoType value) {
        this.siteInfo = value;
    }

    /**
     * Gets the value of the seriesCatalog property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the seriesCatalog property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getSeriesCatalog().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link SeriesCatalogType }
     * 
     * 
     */
    public List<SeriesCatalogType> getSeriesCatalog() {
        if (seriesCatalog == null) {
            seriesCatalog = new ArrayList<SeriesCatalogType>();
        }
        return this.seriesCatalog;
    }

    /**
     * In order to simplify comprehension, data sources are encouraged to put additional informaiton in the extension area, using thier own namespace. Clients need not understand information in extension element
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
     * In order to simplify comprehension, data sources are encouraged to put additional informaiton in the extension area, using thier own namespace. Clients need not understand information in extension element
     * 
     * @param value
     *     allowed object is
     *     {@link Object }
     *     
     */
    public void setExtension(Object value) {
        this.extension = value;
    }

}
