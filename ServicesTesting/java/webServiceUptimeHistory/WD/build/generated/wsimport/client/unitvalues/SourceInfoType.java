
package unitvalues;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlType;


/**
 * SourceInfoType is used to describe the data source in the timeSeriesResponse.
 * SourceInfoType is the base type for data source information. At present, two types are derived from SourceInfoType: SiteInfoType, and DataSetInfoType. SiteInfoType describes tlocation for  a timeseries where that time series is located at a site or a DataSetInfoType describes time series derived from a dataset, such as a netCDF file, or a gridded model.
 * 
 * 
 * <p>Java class for SourceInfoType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="SourceInfoType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "SourceInfoType")
public class SourceInfoType {


}
