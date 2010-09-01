
package unitvalues;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlElementDecl;
import javax.xml.bind.annotation.XmlRegistry;
import javax.xml.namespace.QName;
import unitvalues.QueryInfoType.Criteria;
import unitvalues.QueryInfoType.Criteria.TimeParam;
import unitvalues.SeriesCatalogType.Series;
import unitvalues.SeriesCatalogType.Series.ValueCount;
import unitvalues.SiteInfoType.GeoLocation;
import unitvalues.SiteInfoType.GeoLocation.LocalSiteXY;
import unitvalues.SiteInfoType.SiteCode;
import unitvalues.TimeZoneInfo.DaylightSavingsTimeZone;
import unitvalues.TimeZoneInfo.DefaultTimeZone;
import unitvalues.VariableInfoType.Related;
import unitvalues.VariableInfoType.Related.ParentID;
import unitvalues.VariableInfoType.Related.RelatedID;
import unitvalues.VariableInfoType.TimeSupport;


/**
 * This object contains factory methods for each 
 * Java content interface and Java element interface 
 * generated in the unitvalues package. 
 * <p>An ObjectFactory allows you to programatically 
 * construct new instances of the Java representation 
 * for XML content. The Java representation of XML 
 * content can consist of schema derived interfaces 
 * and classes representing the binding of schema 
 * type definitions, element declarations and model 
 * groups.  Factory methods for each of these are 
 * provided in this class.
 * 
 */
@XmlRegistry
public class ObjectFactory {

    private final static QName _VariableInfoTypeTimeSupport_QNAME = new QName("http://www.cuahsi.org/waterML/1.0/", "timeSupport");
    private final static QName _LatLonBox_QNAME = new QName("http://www.cuahsi.org/waterML/1.0/", "latLonBox");
    private final static QName _Extension_QNAME = new QName("http://www.cuahsi.org/waterML/1.0/", "extension");
    private final static QName _VariablesResponse_QNAME = new QName("http://www.cuahsi.org/waterML/1.0/", "variablesResponse");
    private final static QName _DatasetInfo_QNAME = new QName("http://www.cuahsi.org/waterML/1.0/", "datasetInfo");
    private final static QName _LatLonPoint_QNAME = new QName("http://www.cuahsi.org/waterML/1.0/", "latLonPoint");
    private final static QName _TimeSeriesResponse_QNAME = new QName("http://www.cuahsi.org/waterML/1.0/", "timeSeriesResponse");
    private final static QName _SitesResponse_QNAME = new QName("http://www.cuahsi.org/waterML/1.0/", "sitesResponse");

    /**
     * Create a new ObjectFactory that can be used to create new instances of schema derived classes for package: unitvalues
     * 
     */
    public ObjectFactory() {
    }

    /**
     * Create an instance of {@link DaylightSavingsTimeZone }
     * 
     */
    public DaylightSavingsTimeZone createTimeZoneInfoDaylightSavingsTimeZone() {
        return new DaylightSavingsTimeZone();
    }

    /**
     * Create an instance of {@link GetSitesXmlResponse }
     * 
     */
    public GetSitesXmlResponse createGetSitesXmlResponse() {
        return new GetSitesXmlResponse();
    }

    /**
     * Create an instance of {@link GetSiteInfoObject }
     * 
     */
    public GetSiteInfoObject createGetSiteInfoObject() {
        return new GetSiteInfoObject();
    }

    /**
     * Create an instance of {@link SampleType }
     * 
     */
    public SampleType createSampleType() {
        return new SampleType();
    }

    /**
     * Create an instance of {@link TimeParam }
     * 
     */
    public TimeParam createQueryInfoTypeCriteriaTimeParam() {
        return new TimeParam();
    }

    /**
     * Create an instance of {@link TimeSupport }
     * 
     */
    public TimeSupport createVariableInfoTypeTimeSupport() {
        return new TimeSupport();
    }

    /**
     * Create an instance of {@link GetSitesXml }
     * 
     */
    public GetSitesXml createGetSitesXml() {
        return new GetSitesXml();
    }

    /**
     * Create an instance of {@link unitvalues.QualifiersType.Qualifier }
     * 
     */
    public unitvalues.QualifiersType.Qualifier createQualifiersTypeQualifier() {
        return new unitvalues.QualifiersType.Qualifier();
    }

    /**
     * Create an instance of {@link GetValuesObject }
     * 
     */
    public GetValuesObject createGetValuesObject() {
        return new GetValuesObject();
    }

    /**
     * Create an instance of {@link SeriesCatalogType }
     * 
     */
    public SeriesCatalogType createSeriesCatalogType() {
        return new SeriesCatalogType();
    }

    /**
     * Create an instance of {@link unitvalues.Qualifier }
     * 
     */
    public unitvalues.Qualifier createQualifier() {
        return new unitvalues.Qualifier();
    }

    /**
     * Create an instance of {@link SiteInfoType }
     * 
     */
    public SiteInfoType createSiteInfoType() {
        return new SiteInfoType();
    }

    /**
     * Create an instance of {@link SiteInfoResponseType }
     * 
     */
    public SiteInfoResponseType createSiteInfoResponseType() {
        return new SiteInfoResponseType();
    }

    /**
     * Create an instance of {@link Criteria }
     * 
     */
    public Criteria createQueryInfoTypeCriteria() {
        return new Criteria();
    }

    /**
     * Create an instance of {@link GeoLocation }
     * 
     */
    public GeoLocation createSiteInfoTypeGeoLocation() {
        return new GeoLocation();
    }

    /**
     * Create an instance of {@link GetSitesResponse }
     * 
     */
    public GetSitesResponse createGetSitesResponse() {
        return new GetSitesResponse();
    }

    /**
     * Create an instance of {@link NoteType }
     * 
     */
    public NoteType createNoteType() {
        return new NoteType();
    }

    /**
     * Create an instance of {@link GeogLocationType }
     * 
     */
    public GeogLocationType createGeogLocationType() {
        return new GeogLocationType();
    }

    /**
     * Create an instance of {@link GetValuesObjectResponse }
     * 
     */
    public GetValuesObjectResponse createGetValuesObjectResponse() {
        return new GetValuesObjectResponse();
    }

    /**
     * Create an instance of {@link GetVariableInfoObject }
     * 
     */
    public GetVariableInfoObject createGetVariableInfoObject() {
        return new GetVariableInfoObject();
    }

    /**
     * Create an instance of {@link Variables }
     * 
     */
    public Variables createVariables() {
        return new Variables();
    }

    /**
     * Create an instance of {@link TimeZoneInfo }
     * 
     */
    public TimeZoneInfo createTimeZoneInfo() {
        return new TimeZoneInfo();
    }

    /**
     * Create an instance of {@link GetValuesResponse }
     * 
     */
    public GetValuesResponse createGetValuesResponse() {
        return new GetValuesResponse();
    }

    /**
     * Create an instance of {@link TimePeriodRealTimeType }
     * 
     */
    public TimePeriodRealTimeType createTimePeriodRealTimeType() {
        return new TimePeriodRealTimeType();
    }

    /**
     * Create an instance of {@link Units }
     * 
     */
    public Units createUnits() {
        return new Units();
    }

    /**
     * Create an instance of {@link QueryInfoType }
     * 
     */
    public QueryInfoType createQueryInfoType() {
        return new QueryInfoType();
    }

    /**
     * Create an instance of {@link QualifiersType }
     * 
     */
    public QualifiersType createQualifiersType() {
        return new QualifiersType();
    }

    /**
     * Create an instance of {@link TsValuesSingleVariableType }
     * 
     */
    public TsValuesSingleVariableType createTsValuesSingleVariableType() {
        return new TsValuesSingleVariableType();
    }

    /**
     * Create an instance of {@link DataSetInfoType }
     * 
     */
    public DataSetInfoType createDataSetInfoType() {
        return new DataSetInfoType();
    }

    /**
     * Create an instance of {@link LatLonPointType }
     * 
     */
    public LatLonPointType createLatLonPointType() {
        return new LatLonPointType();
    }

    /**
     * Create an instance of {@link LabMethodType }
     * 
     */
    public LabMethodType createLabMethodType() {
        return new LabMethodType();
    }

    /**
     * Create an instance of {@link ContactInformationType }
     * 
     */
    public ContactInformationType createContactInformationType() {
        return new ContactInformationType();
    }

    /**
     * Create an instance of {@link Related }
     * 
     */
    public Related createVariableInfoTypeRelated() {
        return new Related();
    }

    /**
     * Create an instance of {@link ValueCount }
     * 
     */
    public ValueCount createSeriesCatalogTypeSeriesValueCount() {
        return new ValueCount();
    }

    /**
     * Create an instance of {@link RelatedID }
     * 
     */
    public RelatedID createVariableInfoTypeRelatedRelatedID() {
        return new RelatedID();
    }

    /**
     * Create an instance of {@link MethodType }
     * 
     */
    public MethodType createMethodType() {
        return new MethodType();
    }

    /**
     * Create an instance of {@link DocumentationType }
     * 
     */
    public DocumentationType createDocumentationType() {
        return new DocumentationType();
    }

    /**
     * Create an instance of {@link TimeIntervalType }
     * 
     */
    public TimeIntervalType createTimeIntervalType() {
        return new TimeIntervalType();
    }

    /**
     * Create an instance of {@link GetSiteInfo }
     * 
     */
    public GetSiteInfo createGetSiteInfo() {
        return new GetSiteInfo();
    }

    /**
     * Create an instance of {@link MetaDataType }
     * 
     */
    public MetaDataType createMetaDataType() {
        return new MetaDataType();
    }

    /**
     * Create an instance of {@link GetSiteInfoObjectResponse }
     * 
     */
    public GetSiteInfoObjectResponse createGetSiteInfoObjectResponse() {
        return new GetSiteInfoObjectResponse();
    }

    /**
     * Create an instance of {@link DefaultTimeZone }
     * 
     */
    public DefaultTimeZone createTimeZoneInfoDefaultTimeZone() {
        return new DefaultTimeZone();
    }

    /**
     * Create an instance of {@link GetVariableInfo }
     * 
     */
    public GetVariableInfo createGetVariableInfo() {
        return new GetVariableInfo();
    }

    /**
     * Create an instance of {@link TimePeriodType }
     * 
     */
    public TimePeriodType createTimePeriodType() {
        return new TimePeriodType();
    }

    /**
     * Create an instance of {@link GetVariableInfoObjectResponse }
     * 
     */
    public GetVariableInfoObjectResponse createGetVariableInfoObjectResponse() {
        return new GetVariableInfoObjectResponse();
    }

    /**
     * Create an instance of {@link ArrayOfString }
     * 
     */
    public ArrayOfString createArrayOfString() {
        return new ArrayOfString();
    }

    /**
     * Create an instance of {@link VariablesResponseType }
     * 
     */
    public VariablesResponseType createVariablesResponseType() {
        return new VariablesResponseType();
    }

    /**
     * Create an instance of {@link OffsetType }
     * 
     */
    public OffsetType createOffsetType() {
        return new OffsetType();
    }

    /**
     * Create an instance of {@link OptionGroup }
     * 
     */
    public OptionGroup createOptionGroup() {
        return new OptionGroup();
    }

    /**
     * Create an instance of {@link Option }
     * 
     */
    public Option createOption() {
        return new Option();
    }

    /**
     * Create an instance of {@link UnitsType }
     * 
     */
    public UnitsType createUnitsType() {
        return new UnitsType();
    }

    /**
     * Create an instance of {@link TimeSeriesResponseType }
     * 
     */
    public TimeSeriesResponseType createTimeSeriesResponseType() {
        return new TimeSeriesResponseType();
    }

    /**
     * Create an instance of {@link TimeSeriesType }
     * 
     */
    public TimeSeriesType createTimeSeriesType() {
        return new TimeSeriesType();
    }

    /**
     * Create an instance of {@link Series }
     * 
     */
    public Series createSeriesCatalogTypeSeries() {
        return new Series();
    }

    /**
     * Create an instance of {@link SiteCode }
     * 
     */
    public SiteCode createSiteInfoTypeSiteCode() {
        return new SiteCode();
    }

    /**
     * Create an instance of {@link GetVariableInfoResponse }
     * 
     */
    public GetVariableInfoResponse createGetVariableInfoResponse() {
        return new GetVariableInfoResponse();
    }

    /**
     * Create an instance of {@link QualityControlLevelType }
     * 
     */
    public QualityControlLevelType createQualityControlLevelType() {
        return new QualityControlLevelType();
    }

    /**
     * Create an instance of {@link LocalSiteXY }
     * 
     */
    public LocalSiteXY createSiteInfoTypeGeoLocationLocalSiteXY() {
        return new LocalSiteXY();
    }

    /**
     * Create an instance of {@link VariableCode }
     * 
     */
    public VariableCode createVariableCode() {
        return new VariableCode();
    }

    /**
     * Create an instance of {@link ParentID }
     * 
     */
    public ParentID createVariableInfoTypeRelatedParentID() {
        return new ParentID();
    }

    /**
     * Create an instance of {@link SourceInfoType }
     * 
     */
    public SourceInfoType createSourceInfoType() {
        return new SourceInfoType();
    }

    /**
     * Create an instance of {@link SourceType }
     * 
     */
    public SourceType createSourceType() {
        return new SourceType();
    }

    /**
     * Create an instance of {@link GetSites }
     * 
     */
    public GetSites createGetSites() {
        return new GetSites();
    }

    /**
     * Create an instance of {@link VariableInfoType }
     * 
     */
    public VariableInfoType createVariableInfoType() {
        return new VariableInfoType();
    }

    /**
     * Create an instance of {@link ValueSingleVariable }
     * 
     */
    public ValueSingleVariable createValueSingleVariable() {
        return new ValueSingleVariable();
    }

    /**
     * Create an instance of {@link Site }
     * 
     */
    public Site createSite() {
        return new Site();
    }

    /**
     * Create an instance of {@link QualityControlLevel }
     * 
     */
    public QualityControlLevel createQualityControlLevel() {
        return new QualityControlLevel();
    }

    /**
     * Create an instance of {@link Options }
     * 
     */
    public Options createOptions() {
        return new Options();
    }

    /**
     * Create an instance of {@link LatLonBoxType }
     * 
     */
    public LatLonBoxType createLatLonBoxType() {
        return new LatLonBoxType();
    }

    /**
     * Create an instance of {@link TimeSingleType }
     * 
     */
    public TimeSingleType createTimeSingleType() {
        return new TimeSingleType();
    }

    /**
     * Create an instance of {@link GetValues }
     * 
     */
    public GetValues createGetValues() {
        return new GetValues();
    }

    /**
     * Create an instance of {@link GetSiteInfoResponse }
     * 
     */
    public GetSiteInfoResponse createGetSiteInfoResponse() {
        return new GetSiteInfoResponse();
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link TimeSupport }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://www.cuahsi.org/waterML/1.0/", name = "timeSupport", scope = VariableInfoType.class)
    public JAXBElement<TimeSupport> createVariableInfoTypeTimeSupport(TimeSupport value) {
        return new JAXBElement<TimeSupport>(_VariableInfoTypeTimeSupport_QNAME, TimeSupport.class, VariableInfoType.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link LatLonBoxType }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://www.cuahsi.org/waterML/1.0/", name = "latLonBox")
    public JAXBElement<LatLonBoxType> createLatLonBox(LatLonBoxType value) {
        return new JAXBElement<LatLonBoxType>(_LatLonBox_QNAME, LatLonBoxType.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link Object }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://www.cuahsi.org/waterML/1.0/", name = "extension")
    public JAXBElement<Object> createExtension(Object value) {
        return new JAXBElement<Object>(_Extension_QNAME, Object.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link VariablesResponseType }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://www.cuahsi.org/waterML/1.0/", name = "variablesResponse")
    public JAXBElement<VariablesResponseType> createVariablesResponse(VariablesResponseType value) {
        return new JAXBElement<VariablesResponseType>(_VariablesResponse_QNAME, VariablesResponseType.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link DataSetInfoType }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://www.cuahsi.org/waterML/1.0/", name = "datasetInfo")
    public JAXBElement<DataSetInfoType> createDatasetInfo(DataSetInfoType value) {
        return new JAXBElement<DataSetInfoType>(_DatasetInfo_QNAME, DataSetInfoType.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link LatLonPointType }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://www.cuahsi.org/waterML/1.0/", name = "latLonPoint")
    public JAXBElement<LatLonPointType> createLatLonPoint(LatLonPointType value) {
        return new JAXBElement<LatLonPointType>(_LatLonPoint_QNAME, LatLonPointType.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link TimeSeriesResponseType }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://www.cuahsi.org/waterML/1.0/", name = "timeSeriesResponse")
    public JAXBElement<TimeSeriesResponseType> createTimeSeriesResponse(TimeSeriesResponseType value) {
        return new JAXBElement<TimeSeriesResponseType>(_TimeSeriesResponse_QNAME, TimeSeriesResponseType.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link SiteInfoResponseType }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://www.cuahsi.org/waterML/1.0/", name = "sitesResponse")
    public JAXBElement<SiteInfoResponseType> createSitesResponse(SiteInfoResponseType value) {
        return new JAXBElement<SiteInfoResponseType>(_SitesResponse_QNAME, SiteInfoResponseType.class, null, value);
    }

}
