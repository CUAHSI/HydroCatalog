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
xsi:schemaLocation="http://www.opengis.net/waterml/2.0 ../../Schemas/WaterML/waterml2.xsd" 
xmlns:xs="http://www.w3.org/2001/XMLSchema" 
 version="2.0">
<!-- exclude-result-prefixes="xs" -->
    <!-- need to import because this also has a wml:timeSeriesResponse template --> 
  <xsl:import href="WaterML1_1_timseries_WaterProcess_to_WaterML2.xsl" />       
    <xsl:import href="WaterML1_1_timseries_ObservedProperty_to_WaterML2.xsl" /> 
    
  <xsl:param name="wfsBase"></xsl:param>
  <xsl:param name="observedPropertiesBase"></xsl:param>
  <xsl:param name="concept"></xsl:param>
    <xsl:param name="generationdate">2011-01-01T00:00:00Z</xsl:param>
 

  
    <xsl:output method="xml" indent="yes"  omit-xml-declaration="no"/>
    
    <!-- this assumes that the codes are unique for a file. ok since it comes from an ODM -->
    <xsl:key name="qualifiers" match="wml:qualifier" use="wml:qualifierCode"/>
    <xsl:key name="qclevel" match="wml:timeSeries/wml:values/wml:qualityControlLevel" use="wml:qualityControlLevelCode"/>
    <xsl:template match="wml:timeSeriesResponse">
        <wml2:collection>
            <xsl:attribute name="xsi:schemaLocation">http://www.opengis.net/waterml/2.0 ../../Schemas/WaterML/waterml2.xsd</xsl:attribute>
            <xsl:attribute name="gml:id">generated_collection_doc</xsl:attribute>
            <!-- Get a unique list of all the quality codes used in the time series to build up a dict -->
            <xsl:variable name="unique-list" select="wml:timeSeries/wml:values/wml:value/@qualityControlLevel[not(.=following::wml:value/@qualityControlLevel)]" />
            <wml2:metadata>
                <wml2:DocumentMetadata>
                    <xsl:attribute name="gml:id">doc_md</xsl:attribute>
                    <wml2:generationDate>
                        <xsl:value-of select="$generationdate"/>
                    </wml2:generationDate>
                    <wml2:generationSystem>Translation from WaterML1.1 response document</wml2:generationSystem>
                </wml2:DocumentMetadata>
              
            </wml2:metadata>
            <xsl:comment> 
   8.12.1.7.1	phenomenaDictionary
   8.12.1.7.2	qualifierDictionary 
   8.12.1.7.3	qualityDictionary 
                processing
            </xsl:comment>
        
            <xsl:if test="count(wml:timeSeries/wml:variable) >0">
                   <wml2:localDictionary>
                    <gml:Dictionary gml:id="phenomena">
                        <gml:identifier codeSpace="http://www.cuahsi.org/waterml2/dictionaries/">phenomena</gml:identifier>
                        <xsl:for-each select="wml:timeSeries/wml:variable">
                           <!-- <gml:phenomenonEntry>
                                <gml:Definition>
                                    <xsl:attribute name="gml:id">
                                        <xsl:value-of select="concat('qualifier-',translate( wml:variableCode[1], &quot; &quot;, &quot;_&quot;))" />
                                    </xsl:attribute>
                                    <gml:identifier>
                                        <xsl:attribute name="codeSpace">wml:variableCode[1][@network]</xsl:attribute>
                                        <xsl:value-of select="wml:variableCode[1][text()]" />
                                    </gml:identifier>
                                    <gml:name>
                                        <xsl:attribute name="codeSpace">wml:variableCode[1][@network]</xsl:attribute>
                                        <xsl:value-of select="wml:variableName[text()]" />
                                    </gml:name>
                                    
                                </gml:Definition>
                            </gml:phenomenonEntry>
                           -->
                            <xsl:call-template name="phenomenaDictionaryEntry">
                                <xsl:with-param name="concept"><xsl:value-of select="$concept"/></xsl:with-param>
                                <xsl:with-param name="observedPropertiesBase"><xsl:value-of select="$observedPropertiesBase"/></xsl:with-param>
                            </xsl:call-template>
                        </xsl:for-each>
                      <!--  <xsl:variable name="PhenomenonEntry"> <xsl:call-template name="phenomenonEntry" >
                            <xsl:with-param name="wfsBase"><xsl:value-of select="$wfsBase"/></xsl:with-param> 
                            <xsl:with-param name="observedPropertiesBase"><xsl:value-of select="observedPropertiesBase"/></xsl:with-param>
                            <xsl:with-param name="concept"><xsl:value-of select="$concept"/></xsl:with-param>
                        </xsl:call-template></xsl:variable>
                        <xsl:comment> 
                           <xsl:value-of select="$PhenomenonEntry" disable-output-escaping="no"></xsl:value-of>
                        </xsl:comment>
                        -->
                    </gml:Dictionary>
                </wml2:localDictionary>
            </xsl:if>
      <!--      <xsl:if test="count(distinct-values(wml:timeSeries/wml:values/wml:qualifier)) >0"> -->
    <!-- xslt 2.0 -->
            <!-- <xsl:if test="count(wml:timeSeries/wml:values/wml:qualifier[not(qualifierCode = preceding::qualifierCode)]) >0">
            -->
            <xsl:if test="count(wml:timeSeries/wml:values/wml:qualifier) >0">
               <wml2:localDictionary>
                    <gml:Dictionary gml:id="qualifier">
                        <gml:identifier codeSpace="http://www.cuahsi.org/waterml2/dictionaries/">qualifier</gml:identifier>
                       <xsl:for-each select="wml:timeSeries/wml:values/wml:qualifier[generate-id(.) =
                            generate-id(key('qualifiers',  wml:qualifierCode)[1])]">
                  
                    <!--     <xsl:for-each select="wml:timeSeries/wml:values/wml:qualifier[not(qualifierCode = preceding::qualifierCode)]">
                   -->       
                        <gml:dictionaryEntry>  
                            <gml:Definition>
                                    <xsl:attribute name="gml:id">
                                        <xsl:value-of select="concat('qualifier-',translate( wml:qualifierCode, &quot; &quot;, &quot;_&quot;))" />
                                    </xsl:attribute>
                                    <gml:identifier>
                                        <xsl:attribute name="codeSpace">http://www.cuahsi.org/</xsl:attribute>
                                        <xsl:value-of select="wml:qualifierCode" />
                                    </gml:identifier>
                                    <gml:name>
                                        <xsl:attribute name="codeSpace">http://www.cuahsi.org/</xsl:attribute>
                                        <xsl:value-of select="wml:qualifierDescription" />
                                    </gml:name>
     
                                </gml:Definition>
                            </gml:dictionaryEntry>
                        </xsl:for-each>
                    </gml:Dictionary>
               </wml2:localDictionary>
            </xsl:if>
            <!--  <xsl:if test="not(empty($unique-list))"> -->
          <xsl:if test="count(wml:timeSeries/wml:values/wml:qualityControlLevel) >0">
     
              <!-- works in xslt 2.0 aka not .net -->
          <!--  <xsl:if test="count(//wml:timeSeries/wml:values/wml:qualityControlLevel[not(qualityControlLevelCode = preceding::qualityControlLevelCode)]  )>0">
          -->
          <wml2:localDictionary>
                    <gml:Dictionary gml:id="quality">
                        <gml:identifier codeSpace="http://www.cuahsi.org/waterml2/dictionaries/">quality</gml:identifier>
                     <!--  <xsl:for-each select="wml:timeSeries/wml:values/wml:qualityControlLevel"> -->
                       <!-- xslt 2.0 -->
                        <!-- <xsl:for-each select="//wml:timeSeries/wml:values/wml:qualityControlLevel[not(qualityControlLevelCode = preceding::qualityControlLevelCode)] ">
                        -->
                        <xsl:for-each select="//wml:timeSeries/wml:values/wml:qualityControlLevel[generate-id(.) =
                            generate-id(key('qclevel',  wml:qualityControlLevelCode)[1])] " >     <!--key('qclevel', '0' )  wml:qualityControlLevelCode -->
                                <gml:dictionaryEntry>
                                <gml:Definition>
                                    <xsl:attribute name="gml:id">
                                        <xsl:value-of select="concat('qclevel-',translate( wml:qualityControlLevelCode, &quot; &quot;, &quot;_&quot;))" />
                                    </xsl:attribute>
                                    <gml:identifier>
                                        <xsl:attribute name="codeSpace">http://www.cuahsi.org/</xsl:attribute>
                                        <xsl:value-of select="wml:qualityControlLevelCode" />
                                    </gml:identifier>
                                    <gml:name>
                                        <xsl:attribute name="codeSpace">http://www.cuahsi.org/</xsl:attribute>
                                        <xsl:value-of select="wml:definition" />
                                    </gml:name>
                                    <gml:remarks><xsl:value-of select="wml:explanation" /></gml:remarks>
                                </gml:Definition>
                            </gml:dictionaryEntry>
                        </xsl:for-each>
                    </gml:Dictionary>
          </wml2:localDictionary>
          </xsl:if>
            
            <xsl:for-each select="wml:timeSeries">
                <wml2:observationMember>
                    <xsl:variable name="obsMemberNumber" select="position()"/>   
                    <om:OM_Observation>
                        <xsl:attribute name="gml:id">
                            <xsl:choose>
                                <xsl:when test="@name">
                                    <xsl:value-of select="@name" />
								</xsl:when>
                                <xsl:otherwise>
                                    <xsl:value-of select="concat('observation-',$obsMemberNumber)"/>
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
                            <gml:TimePeriod >
                                <xsl:attribute name="gml:id"><xsl:value-of select="concat('phen_time-',$obsMemberNumber)"/></xsl:attribute>
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
                            <gml:TimeInstant >
                                <xsl:attribute name="gml:id"><xsl:value-of select="concat('eor-',$obsMemberNumber)"/></xsl:attribute>
                                
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
                            <xsl:value-of
                                select="concat(wml:variable/wml:variableCode[1]/@vocabulary,'-',wml:variable/wml:variableCode[1])"
                            /> 
                                <xsl:value-of select='concat("#","variableCode-",$concept)' />
                            </xsl:attribute>
                            <xsl:attribute name="xlink:title">
                                <xsl:value-of select="$concept" />
                            </xsl:attribute>
                  <!--      <xsl:call-template name="ObservedProperty">
                          <xsl:with-param name="concept"><xsl:value-of select="$concept"/></xsl:with-param>
                          <xsl:with-param name="observedPropertiesBase"><xsl:value-of select="$observedPropertiesBase"/></xsl:with-param>
                        </xsl:call-template>
                        -->
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
                                    <xsl:value-of select="concat(@name,'_TS-',position() )">
                                    </xsl:value-of>
                                </xsl:attribute>
                                 <xsl:comment>domainExtent refers to time described above</xsl:comment>
                                <wml2:temporalExtent >
                                    <xsl:attribute name="xlink:href"><xsl:value-of select="concat('#phen_time-',$obsMemberNumber)"/></xsl:attribute>
                                    
                                </wml2:temporalExtent>
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
                               <wml2:metadata>
                                    <wml2:TSMetadata>
                                        <!--       <wml2:cumulative>false</wml2:cumulative> -->
                                        <xsl:choose>
                                            <xsl:when test="wml:variable/wml:timeScale/wml:timeSupport > 0">
                                                <wml2:cumulative>true</wml2:cumulative>
                                                <wml2:aggregationDuration>
                                                    <xsl:call-template name="TimeUnitToPeriod">
                                                        <xsl:with-param name="TimeSupport" select="wml:variable/wml:timeScale/wml:timeSupport"/>
                                                        <xsl:with-param name="Unit"  select="wml:variable/wml:timeScale/wml:unit"/>
                                                    </xsl:call-template>
                                                </wml2:aggregationDuration>
                                            </xsl:when>
                                            <xsl:otherwise> <wml2:cumulative>false</wml2:cumulative></xsl:otherwise>
                                        </xsl:choose>
    
                                      <!--       <wml2:aggregationDuration>P1D</wml2:aggregationDuration>-->    
                                 
                                    </wml2:TSMetadata>
                                </wml2:metadata>
                                
                                <xsl:comment>baseTime and  spacing</xsl:comment>
                               
                                <wml2:defaultPointMetadata>
                                    <wml2:DefaultTVPMetadata>
                                     
                                        <xsl:choose>
                                       <xsl:when test="count(wml:values/wml:censorCode) = 0 or
                                           count(wml:values/wml:censorCode) > 0" >
                                         
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
                                           
                                            <xsl:otherwise> <!-- there is one -->
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
                               <xsl:if test="count(wml:values/wml:qualityControlLevel) > 0">
                                        <wml2:processing>
                                            <!-- xlink:href="http://waterdata.usgs.gov/NJ/nwis/help/?provisional"
	                        xlink:title="Provisional data subject to revision."/>
                                        -->
                                            <xsl:attribute name="xlink:href">
                                                 <xsl:value-of select="concat('urn:cuahsi/qualityControlLevel',wml:values/wml:qualityControlLevel[1]/wml:qualityControlLevelCode)"/>
                                            </xsl:attribute>
                                            <xsl:attribute name="xlink:title"> <xsl:value-of select="wml:values/wml:qualityControlLevel[1]/wml:definition"/></xsl:attribute>
                                    </wml2:processing>
                               </xsl:if>
                                        <xsl:comment>8.6.3	unitOfMeasure. Mapping. The unit of measure is specified using the ISO19103 UnitOfMeasure type. </xsl:comment>
                                        <wml2:uom>
                                            <xsl:attribute name="uom">
                                                <xsl:call-template name="UOMCreator">
                                                    <xsl:with-param name="Unit" select="wml:variable/wml:unit" />
                                                </xsl:call-template>
                                                
                                            </xsl:attribute>  
                                        </wml2:uom>
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
                                        <xsl:if test="count(../wml:qualityControlLevel) > 1 or 
                                            count(../wml:qualifier) > 0 ">
                                            <wml2:metadata>
                                                <wml2:TVPMetadata>
                                                    <xsl:if test="count(../wml:qualityControlLevel) > 1 and @qualityControlLevelCode">
                                                    <wml2:quality>
                                                <xsl:attribute name="xlink:href">
                                                    <xsl:value-of select="concat('qclevel-',translate(@qualityControlLevelCode, &quot; &quot;, &quot;_&quot;))" />
                                                </xsl:attribute>
                                                    </wml2:quality>
                                                    </xsl:if>
                                                    <xsl:if test="@qualifiers">
                                                        <wml2:qualifier>
                                                            <xsl:attribute name="xlink:href">
                                                                <xsl:value-of select="concat('qualifer-',translate(@qualifiers, &quot; &quot;, &quot;_&quot;))" />
                                                            </xsl:attribute>
                                                        </wml2:qualifier>
                                                        </xsl:if>
                                                <xsl:if test="@sampleCode" >
                                                    <!-- <wml2:relatedObservation xlink:href="http://my_sampling.org/sample_453" xlink:title="Original sample"/> -->
                                                    <xsl:comment>relatedObservation for sample <xsl:value-of select="@sampleCode"/> should go here</xsl:comment>
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
    </wml2:collection>
    </xsl:template>
    <xsl:include href="WaterML1_1_common_to_waterml2.xsl"/>
</xsl:stylesheet>
