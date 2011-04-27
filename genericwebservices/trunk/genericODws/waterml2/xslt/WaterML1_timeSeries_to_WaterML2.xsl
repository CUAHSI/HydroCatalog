<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
    xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
    xmlns:wml2="http://www.opengis.net/waterml/2.0"
    xmlns:gml="http://www.opengis.net/gml/3.2"
    xmlns:om="http://www.opengis.net/om/2.0" 
    xmlns:xlink="http://www.w3.org/1999/xlink"
    xmlns:wml="http://www.cuahsi.org/waterML/1.0/"
    xmlns:fn="http://www.w3.org/2005/xpath-functions"
    xsi:schemaLocation="http://www.opengis.net/waterml/2.0 ../GeneratedSchema_13_10_2010/WaterCollection.xsd"
      xmlns:xs="http://www.w3.org/2001/XMLSchema"
      exclude-result-prefixes="xs"
      version="2.0">
  <!-- XSL to translate between a WaterML1.0 timeSeriesResponse document and a WaterML2.0 collection. Currently only a partial translation. History:
    2010-08-20 - Created - Pete Taylor 
  --> 
  
  <xsl:output method="xml" indent="yes"/> 
  
  <xsl:template match="wml:timeSeriesResponse">
    <wml2:WaterMonitoringCollection>
      
      <xsl:attribute name="gml:id">generated_collection_doc</xsl:attribute>
      
      <!-- Get a unique list of all the quality codes used in the time series to build up a dict -->
      <xsl:variable name="unique-list"              select="wml:timeSeries/wml:values/wml:value/@qualityControlLevel[not(.=following::wml:value/@qualityControlLevel)]" />
      
      <wml2:metadata>
        <wml2:DocumentMetadata>
          <xsl:attribute name="gml:id">doc_md</xsl:attribute>
          <wml2:generationDate><!--<xsl:value-of select="current-dateTime()"/>--></wml2:generationDate>
          <wml2:generationSystem>Translation from WaterML1.0 response document</wml2:generationSystem>
        </wml2:DocumentMetadata>
      </wml2:metadata>

      <!--  <xsl:if test="not(empty($unique-list))"> -->
        <xsl:if test="not($unique-list)">
        <wml2:qualityDictionary>
          <gml:Dictionary gml:id="quality">
            <gml:identifier codeSpace="http://www.cuahsi.org/waterml2/dictionaries/">quality</gml:identifier>
            <xsl:for-each select="$unique-list">
              <gml:dictionaryEntry>
                <gml:Definition>
                  <xsl:attribute name="gml:id">
                    <xsl:value-of select='translate(., " ", "_")'/>
                  </xsl:attribute>
                  <gml:identifier>
                    <xsl:attribute name="codeSpace">http://www.cuahsi.org/</xsl:attribute>
                    <xsl:value-of select='.'/>
                  </gml:identifier>
                </gml:Definition>
              </gml:dictionaryEntry>
            </xsl:for-each>
          </gml:Dictionary>
        </wml2:qualityDictionary>
      </xsl:if>
      
      <xsl:for-each select="wml:timeSeries">
        <wml2:observationMember>
          <wml2:WaterMonitoringObservation>
            <xsl:attribute name="gml:id">
              <xsl:value-of select="@name"/>
            </xsl:attribute>
            
            <!-- Figure out the start and end time of the series -->
            <xsl:variable name="start-time" select="wml:values/wml:value[1]/@dateTime"></xsl:variable>
            
            <xsl:variable name="end-time" select="wml:values/wml:value[last()]/@dateTime"></xsl:variable>
            
            <om:phenomenonTime>
              <!-- gml:ids will need to be generated when more than one series as have to be unique in document -->
              <gml:TimePeriod gml:id="phen_time">
                <gml:beginPosition><xsl:value-of select="$start-time"></xsl:value-of></gml:beginPosition>
                <gml:endPosition><xsl:value-of select="$end-time"></xsl:value-of></gml:endPosition>
              </gml:TimePeriod>
            </om:phenomenonTime>
            
            <om:resultTime>
              <gml:TimeInstant gml:id="eor">
                <gml:timePosition><xsl:value-of select="$end-time"></xsl:value-of></gml:timePosition>
              </gml:TimeInstant>
            </om:resultTime>
            
            <om:procedure>
              <xsl:attribute name="xlink:href">
                <xsl:value-of select="wml:values/wml:method/wml:MethodLink"/>
              </xsl:attribute>
            </om:procedure>
            
            <om:observedProperty>
              <xsl:attribute name="xlink:href">USU39</xsl:attribute>
              <xsl:attribute name="xlink:title">
                <xsl:value-of select="wml:variable/wml:variableName"/>
              </xsl:attribute>
            </om:observedProperty>
            
            <om:featureOfInterest>
              <xsl:if test="wml:sourceInfo/@xsi:type='SiteInfoType'">  
                <xsl:attribute name="xlink:href">
                  <xsl:value-of select="wml:sourceInfo/wml:siteCode"/>
                </xsl:attribute>
              </xsl:if>
              <xsl:if test="wml:sourceInfo/@xsi:type='DataSetInfoType'">  
                <xsl:attribute name="xlink:href">
                  <xsl:value-of select="wml:sourceInfo/wml:dataSetIdentifier"/>
                </xsl:attribute>
              </xsl:if>
            </om:featureOfInterest>
            
            <om:result>
              <wml2:Timeseries>
                <xsl:attribute name="gml:id"><xsl:value-of select='concat(@name,"_TS")'></xsl:value-of></xsl:attribute>
                <wml2:domainExtent xlink:href="#phen_time"></wml2:domainExtent>
                <wml2:defaultTimeValuePair>
                  <wml2:TimeValuePair>
                   <wml2:unitOfMeasure>
                     <xsl:attribute name="xlink:href">
                       <xsl:value-of select="wml:variable/wml:units/@unitsAbbreviation"/>
                     </xsl:attribute>
                   </wml2:unitOfMeasure>
                  </wml2:TimeValuePair>  
                </wml2:defaultTimeValuePair>
                
                <xsl:for-each select="wml:values/wml:value">
                  <wml2:element>
                    <wml2:TimeValuePair>
                      <wml2:time>
                        <xsl:value-of select="@dateTime"/>
                      </wml2:time>
                      <wml2:value>
                        <xsl:value-of select="."/>
                      </wml2:value>
                     <!-- <xsl:if test="not(empty(@qualityControlLevel))">
                     -->
                      <xsl:if test="not(@qualityControlLevel)">
                       <wml2:quality>
                         <xsl:attribute name="xlink:href">
                           <xsl:value-of select='concat("#",translate(@qualityControlLevel, " ", "_"))'/>
                         </xsl:attribute>
                       </wml2:quality>
                      </xsl:if>
                    </wml2:TimeValuePair>
                  </wml2:element>
                </xsl:for-each>
              </wml2:Timeseries>
            </om:result>
          </wml2:WaterMonitoringObservation>
        </wml2:observationMember>
      </xsl:for-each>
    </wml2:WaterMonitoringCollection>
  </xsl:template>
    
</xsl:stylesheet>
