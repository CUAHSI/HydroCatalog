
package unitvalues;

import java.util.ArrayList;
import java.util.List;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;


/**
 * A sitesResponse contains a list of zero or more site elements.
 * 
 * The siteInfo element contains the basic site information, siteName, location, siteCodes, properties.
 * The seriesCatalog contains the list of observation series conducted at a site.
 * 
 * A site element can have two parts: siteInfo, and one or more seriesCatalogs.
 * Rules:
 * GetSites(site[]) or GetSites(null), return no seriesCatalogs elements
 * 
 * GetSiteInfo(site) return all information about a site, including the seriesCatalog.
 * 
 * <p>Java class for SiteInfoResponseType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="SiteInfoResponseType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="queryInfo" type="{http://www.cuahsi.org/waterML/1.0/}QueryInfoType" minOccurs="0"/>
 *         &lt;element ref="{http://www.cuahsi.org/waterML/1.0/}site" maxOccurs="unbounded" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "SiteInfoResponseType", propOrder = {
    "queryInfo",
    "site"
})
public class SiteInfoResponseType {

    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/")
    protected QueryInfoType queryInfo;
    @XmlElement(namespace = "http://www.cuahsi.org/waterML/1.0/", required = true)
    protected List<Site> site;

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
     * A sitesResponse contains a list of zero or more site elements. A site element is Gets the value of the site property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the site property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getSite().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link Site }
     * 
     * 
     */
    public List<Site> getSite() {
        if (site == null) {
            site = new ArrayList<Site>();
        }
        return this.site;
    }

}
