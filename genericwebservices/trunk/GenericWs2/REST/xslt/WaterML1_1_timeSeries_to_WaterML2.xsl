<?xml version="1.0" encoding="UTF-8"?>
<!-- Created with Liquid XML Studio Developer Edition (Education) 9.0.11.3078 (http://www.liquid-technologies.com) -->
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" 
xmlns:wml2="http://www.opengis.net/waterml/2.0" 
xmlns:gml="http://www.opengis.net/gml/3.2" 
xmlns:xlink="http://www.w3.org/1999/xlink" 
xmlns:wml="http://www.cuahsi.org/waterML/1.1/" 
xmlns:fn="http://www.w3.org/2005/xpath-functions"
xmlns:xsd="http://www.w3.org/2001/XMLSchema"
 xmlns:om="http://www.opengis.net/om/2.0"
    xmlns:swe="http://www.opengis.net/swe/2.0"
    xmlns:sf="http://www.opengis.net/sampling/2.0"
    xmlns:sams="http://www.opengis.net/samplingSpatial/2.0"
xsi:schemaLocation="http://www.opengis.net/waterml/2.0 ../Schemas/WaterML/waterml2.xsd" 
xmlns:xs="http://www.w3.org/2001/XMLSchema" 
 version="2.0">
<!-- exclude-result-prefixes="xs" -->
    <!-- need to import because this also has a wml:timeSeriesResponse template --> 
  <xsl:import href="WaterML1_1_timseries_WaterProcess_to_WaterML2.xsl" />       
    <xsl:import href="WaterML1_1_timseries_ObservedProperty_to_WaterML2.xsl" /> 
    
  <xsl:param name="wfsBase"></xsl:param>
  <xsl:param name="observedPropertiesBase"></xsl:param>
  <xsl:param name="concept"></xsl:param>

 

  
    <xsl:output method="xml" indent="yes" />
    <xsl:template match="wml:timeSeriesResponse">
        <wml2:Collection>
            <xsl:attribute name="xsi:schemaLocation">http://www.opengis.net/waterml/2.0 ../../Schemas/WaterML/waterml2.xsd</xsl:attribute>

            <xsl:attribute name="gml:id">generated_collection_doc</xsl:attribute>
            <!-- Get a unique list of all the quality codes used in the time series to build up a dict -->
            <xsl:variable name="unique-list" select="wml:timeSeries/wml:values/wml:value/@qualityControlLevel[not(.=following::wml:value/@qualityControlLevel)]" />
            <wml2:metadata>
                <wml2:DocumentMetadata>
                    <xsl:attribute name="gml:id">doc_md</xsl:attribute>
                    <wml2:generationDate>
                        <!--<xsl:value-of select="current-dateTime()"/>-->
                    </wml2:generationDate>
                    <wml2:generationSystem>Translation from WaterML1.0 response document</wml2:generationSystem>
                </wml2:DocumentMetadata>
                <xsl:comment>8.2.8	metadata (OM_Observation)
  wml2:intendedSamplingInterval P2Y2M25DT21H54M52.27S
  wml2:status 
  wml2:sampledMedium 
  wml2:maximumGap P5Y0M24DT12H3M45.94S
                    
    wml2:parameter
       om:NamedValue>
            om:name 
            om:value 
        om:NamedValue
    (and/or)
    wml2:parameter xlink:href="http://www.liquid-technologies.com" xlink:role="http://www.liquid-technologies.com" xlink:actuate="other" gml:remoteSchema="http://www.liquid-technologies.com"
</xsl:comment>
            </wml2:metadata>
            <xsl:comment> 
   8.12.1.7.1	phenomenaDictionary
   8.12.1.7.2	qualifierDictionary 
   8.12.1.7.3	qualityDictionary 
                processing
</xsl:comment>
            <!--  <xsl:if test="not(empty($unique-list))"> -->
            <xsl:if test="not($unique-list)">
                <wml2:qualityDictionary>
                    <gml:Dictionary gml:id="quality">
                        <gml:identifier codeSpace="http://www.cuahsi.org/waterml2/dictionaries/">quality</gml:identifier>
                        <xsl:for-each select="$unique-list">
                            <gml:dictionaryEntry>
                                <gml:Definition>
                                    <xsl:attribute name="gml:id">
                                        <xsl:value-of select="translate(., &quot; &quot;, &quot;_&quot;)" />
                                    </xsl:attribute>
                                    <gml:identifier>
                                        <xsl:attribute name="codeSpace">http://www.cuahsi.org/</xsl:attribute>
                                        <xsl:value-of select="." />
                                    </gml:identifier>
                                </gml:Definition>
                            </gml:dictionaryEntry>
                        </xsl:for-each>
                    </gml:Dictionary>
                </wml2:qualityDictionary>
            </xsl:if>
            <xsl:for-each select="wml:timeSeries">
                <wml2:observationMember>
                    <om:OM_Observation>
                        <xsl:attribute name="gml:id">
                            <xsl:choose>
                                <xsl:when test="@name">
                                    <xsl:value-of select="@name" />
								</xsl:when>
                                <xsl:otherwise>
                                    <xsl:text>observation</xsl:text>
								</xsl:otherwise>
							</xsl:choose>
                            
                        </xsl:attribute>
                        <!-- Figure out the start and end time of the series -->
                        <xsl:variable name="start-time" select="wml:values/wml:value[1]/@dateTime">
                        </xsl:variable>
                        <xsl:variable name="end-time" select="wml:values/wml:value[last()]/@dateTime">
                        </xsl:variable>
                        <om:phenomenonTime>
                            <!-- gml:ids will need to be generated when more than one series as have to be unique in document -->
                            <gml:TimePeriod gml:id="phen_time">
                                <gml:beginPosition>
                                    <xsl:value-of select="$start-time">
                                    </xsl:value-of>
                                </gml:beginPosition>
                                <gml:endPosition>
                                    <xsl:value-of select="$end-time">
                                    </xsl:value-of>
                                </gml:endPosition>
                            </gml:TimePeriod>
                        </om:phenomenonTime>
                        <om:resultTime>
                            <gml:TimeInstant gml:id="eor">
                                <gml:timePosition>
                                    <xsl:value-of select="$end-time">
                                    </xsl:value-of>
                                </gml:timePosition>
                            </gml:TimeInstant>
                        </om:resultTime>
                         <om:procedure>
                            <xsl:call-template name="WaterObservationProcess"/>
                         </om:procedure>
                      <!-- observedProperty needs to be the concept. If no concept, then original variable code-->
                      <!-- This feature-property that provides the (semantic) type of the observation. 	
                      The description of the phenomenon may be quite specific and constrained.
                      The description of the property-type may be presented using various alternative encodings. 							If shown inline, the swe:Phenomenon schema is required. 		
                      -->  
                      
                      <om:observedProperty>
                        <xsl:attribute name="xlink:href">
                                <xsl:value-of select='concat("urn:cuahsi/variableOntology/",$concept)' />
                            </xsl:attribute>
                            <xsl:attribute name="xlink:title">
                                <xsl:value-of select="$concept" />
                            </xsl:attribute>
                        <xsl:call-template name="ObservedProperty">
                          <xsl:with-param name="concept"><xsl:value-of select="$concept"/></xsl:with-param>
                          <xsl:with-param name="observedPropertiesBase"><xsl:value-of select="$observedPropertiesBase"/></xsl:with-param>
                        </xsl:call-template>
                      </om:observedProperty>
                      <!--  
                      <om:observedProperty>
                        <xsl:attribute name="xlink:href">
                                <xsl:value-of select='concat($observedPropertiesBase,wml:variable/wml:variableCode[1]/@vocabulary,":",wml:variable/wml:variableCode[1])' />
                            </xsl:attribute>
                            <xsl:attribute name="xlink:title">
                                <xsl:value-of select="wml:variable/wml:variableName" />
                            </xsl:attribute>
                      </om:observedProperty>
                      -->
                        <om:featureOfInterest>
                            <xsl:if test="wml:sourceInfo/@xsi:type='SiteInfoType'">
                                <xsl:attribute name="xlink:href">
                                    <xsl:value-of select="concat($wfsBase,wml:sourceInfo/wml:siteCode)" />
                                </xsl:attribute>
                            </xsl:if>
                            <xsl:if test="wml:sourceInfo/@xsi:type='DataSetInfoType'">
                                <xsl:attribute name="xlink:href">
                                    <xsl:value-of select="wml:sourceInfo/wml:dataSetIdentifier" />
                                </xsl:attribute>
                            </xsl:if>
                        </om:featureOfInterest>
                        <xsl:comment>9.2.1.1	resultQuality would go here</xsl:comment>
                        <om:result>
                            <wml2:Timeseries>
                                <xsl:attribute name="gml:id">
                                    <xsl:value-of select="concat(@name,&quot;_TS&quot;)">
                                    </xsl:value-of>
                                </xsl:attribute>
                                 <xsl:comment>domainExtent refers to time described above</xsl:comment>
                                <wml2:temporalExtent xlink:href="#phen_time">
                                </wml2:temporalExtent>
                                <xsl:comment>baseTime and  spacing</xsl:comment>
                                <wml2:defaultPointMetadata>
                                    <wml2:DefaultTVPMetadata>
                                       
                                        <xsl:choose>
                                       <xsl:when test="count(wml:values/wml:censorCode) &lt; 1 " >
                                         
                                     <xsl:comment>8.6.4	Data quality. Mapping needed</xsl:comment>
                                        <wml2:quality>
                                            <!-- xlink:href="http://waterdata.usgs.gov/NJ/nwis/help/?provisional"
	                        xlink:title="Provisional data subject to revision."/>
                                        -->
                                            <xsl:attribute name="xlink:href">http://www.opengis.net/def/timeseriesType/WaterML/2.0/notcensored
                                            </xsl:attribute>
                                            <xsl:attribute name="xlink:title">not censored</xsl:attribute>
                                    </wml2:quality>  
                                        </xsl:when>
                                            <xsl:otherwise>
                                                <xsl:for-each select="wml:values/wml:censorCode" >
                                                <wml2:quality>
                                            <!-- xlink:href="http://waterdata.usgs.gov/NJ/nwis/help/?provisional"
	                        xlink:title="Provisional data subject to revision."/>
                                            -->
 <xsl:attribute name="xlink:href">
 <xsl:value-of select="concat('http://www.opengis.net/def/timeseriesType/WaterML/2.0/',wml:censorCode)" />
                                            </xsl:attribute>
                                            <xsl:attribute name="xlink:title">
                                                <xsl:value-of select="wml:censorCode" />
                                            </xsl:attribute>                                    </wml2:quality>
                                                </xsl:for-each>
											</xsl:otherwise>
                                    </xsl:choose>   
                                        <xsl:comment>8.6.5	Data type. need to do a mapping</xsl:comment>
                                        <wml2:interpolationType>
                                            <!--      xlink:href="http://www.opengis.net/def/timeseriesType/WaterML/2.0/Continuous"
	                        xlink:title="Continuous/Instantaneous"/>
                                    -->
                                            <xsl:attribute name="xlink:href">
                                                <xsl:value-of select="concat('http://www.opengis.net/def/timeseriesType/WaterML/2.0/',wml:variable/wml:dataType)" />
                                            </xsl:attribute>
                                            <xsl:attribute name="xlink:title">
                                                <xsl:value-of select="wml:variable/wml:dataType" />
                                            </xsl:attribute>
                                        </wml2:interpolationType>
                               <xsl:if test="count(wml:values/wml:qualityControlLevel) = 1">
                                        <wml2:processing>
                                            <!-- xlink:href="http://waterdata.usgs.gov/NJ/nwis/help/?provisional"
	                        xlink:title="Provisional data subject to revision."/>
                                        -->
                                            <xsl:attribute name="xlink:href">
                                                 <xsl:value-of select="concat('urn:cuahsi/qualityControlLevel',wml:values/wml:qualityControlLevel[1]/wml:qualityControlLevelCode)"/>
                                            </xsl:attribute>
                                            <xsl:attribute name="xlink:title"> <xsl:value-of select="wml:values/wml:qualityControlLevel[1]/wml:definition"/></xsl:attribute>
                                    </wml2:processing>
                                 <xsl:comment>8.6.3	unitOfMeasure. Mapping. The unit of measure is specified using the ISO19103 UnitOfMeasure type. </xsl:comment>
                                        <wml2:uom>
                                            <xsl:attribute name="uom">
                                                <xsl:value-of select="concat(&quot;&quot;,wml:variable/wml:unit/wml:unitAbbreviation)" />
                                            </xsl:attribute>
                                         <!--   <xsl:attribute name="xlink:href">
                                                <xsl:value-of select="concat(&quot;&quot;,wml:variable/wml:unit/wml:unitAbbreviation)" />
                                            </xsl:attribute>
                                            <xsl:attribute name="xlink:title">
                                                <xsl:value-of select="concat(wml:variable/wml:unit/wml:unitAbbreviation,' ', wml:variable/wml:unit/wml:unitName)" />
                                            </xsl:attribute>
                                            -->
                                        </wml2:uom>
                                </xsl:if>
                                </wml2:DefaultTVPMetadata>
                            </wml2:defaultPointMetadata>
                            <xsl:for-each select="wml:values/wml:value">
                                <wml2:point>
                                    <wml2:TimeValuePairMeasure>
                                        <wml2:time>
                                            <xsl:value-of select="@dateTime" />
                                        </wml2:time>
                                        <wml2:value>
                                            <xsl:value-of select="." />
                                        </wml2:value>
                                        <!-- <xsl:if test="not(empty(@qualityControlLevel))">
                     -->
                                       <xsl:if test="count(wml:values/wml:qualityControlLevel) > 1 
                    or 
                                    not( @censored = 'nc')  ">
                                        <wml2:metadata>
                                        <wml2:TVPMetadata>
                                            <xsl:if test="not( @censored = 'nc')">
                                            <!-- wml1 censored ~ quality -->
                                                <wml2:quality>
                                                <xsl:attribute name="xlink:href">
                                                    <xsl:value-of select="@censored" />
                                                </xsl:attribute>
                                            </wml2:quality>
                                        </xsl:if>
                                            <xsl:if test="count(wml:values/wml:qualityControlLevel) > 1">
                                            <!-- wml1 quality control level == processing level -->
                                                <wml2:processing>
                                                <xsl:attribute name="xlink:href">
                                                    <xsl:value-of select="concat(&quot;#&quot;,translate(@qualityControlLevel, &quot; &quot;, &quot;_&quot;))" />
                                                </xsl:attribute>
                                            </wml2:processing>
                                        </xsl:if>
                                        </wml2:TVPMetadata>
                                            </wml2:metadata>
                                        </xsl:if>
                                    </wml2:TimeValuePairMeasure>
                                </wml2:point>
                            </xsl:for-each>
                        </wml2:Timeseries>
                    </om:result>
                </om:OM_Observation>
            </wml2:observationMember>
        </xsl:for-each>
    </wml2:Collection>
</xsl:template>
</xsl:stylesheet>
