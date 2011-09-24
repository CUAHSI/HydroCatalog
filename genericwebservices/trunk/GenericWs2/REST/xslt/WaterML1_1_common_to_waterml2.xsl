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
    <doc xmlns="http://www.oxygenxml.com/ns/doc/xsl">
        <desc>This includes vocabulary translaotion and other elements</desc>
    </doc>
    <xsl:template name="TimeUnitToPeriod">
        <xsl:param name="Unit"></xsl:param>
        <xsl:param name="TimeSupport"></xsl:param>
        <xsl:choose>
            
            <xsl:when test="$Unit/wml:unitName = 'minute'">PT<xsl:value-of select="$TimeSupport"/>M</xsl:when>
            <xsl:when test="$Unit/wml:unitName = 'min'">PT<xsl:value-of select="$TimeSupport"/>M</xsl:when>
            <xsl:when test="$Unit/wml:unitAbbreviation = 'minute'">PT<xsl:value-of select="$TimeSupport"/>M</xsl:when>
            <xsl:when test="$Unit/wml:unitAbbreviation = 'M'">PT<xsl:value-of select="$TimeSupport"/>M</xsl:when>
            <xsl:when test="$Unit/wml:unitAbbreviation = 'm'">PT<xsl:value-of select="$TimeSupport"/>M</xsl:when>
            
            <xsl:when test="$Unit/wml:unitName = 'hour'">PT<xsl:value-of select="$TimeSupport"/>H</xsl:when>
            <xsl:when test="$Unit/wml:unitName = 'h'">PT<xsl:value-of select="$TimeSupport"/>H</xsl:when>
            <xsl:when test="$Unit/wml:unitName = 'hr'">PT<xsl:value-of select="$TimeSupport"/>H</xsl:when>
            <xsl:when test="$Unit/wml:unitAbbreviation = 'hour'">PT<xsl:value-of select="$TimeSupport"/>H</xsl:when>
            <xsl:when test="$Unit/wml:unitAbbreviation = 'h'">PT<xsl:value-of select="$TimeSupport"/>H</xsl:when>
            <xsl:when test="$Unit/wml:unitAbbreviation = 'hr'">PT<xsl:value-of select="$TimeSupport"/>H</xsl:when>
           
            <xsl:when test="$Unit/wml:unitName = 'second'">PT<xsl:value-of select="$TimeSupport"/>S</xsl:when>
            <xsl:when test="$Unit/wml:unitName = 'sec'">PT<xsl:value-of select="$TimeSupport"/>S</xsl:when>
            <xsl:when test="$Unit/wml:unitName = 's'">PT<xsl:value-of select="$TimeSupport"/>S</xsl:when>
            <xsl:when test="$Unit/wml:unitAbbreviation = 'second'">PT<xsl:value-of select="$TimeSupport"/>S</xsl:when>
            <xsl:when test="$Unit/wml:unitAbbreviation = 'sec'">PT<xsl:value-of select="$TimeSupport"/>S</xsl:when>
            <xsl:when test="$Unit/wml:unitName = 's'">PT<xsl:value-of select="$TimeSupport"/>S</xsl:when>
            
            <xsl:when test="$Unit/wml:unitName = 'day'">P<xsl:value-of select="$TimeSupport"/>D</xsl:when>
            <xsl:when test="$Unit/wml:unitName = 'd'">P<xsl:value-of select="$TimeSupport"/>D</xsl:when>
            <xsl:when test="$Unit/wml:unitAbbreviation = 'day'">P<xsl:value-of select="$TimeSupport"/>D</xsl:when>
            <xsl:when test="$Unit/wml:unitAbbreviation = 'd'">P<xsl:value-of select="$TimeSupport"/>D</xsl:when>
            
            <xsl:when test="$Unit/wml:unitName = 'month'">P<xsl:value-of select="$TimeSupport"/>M</xsl:when>
            <xsl:when test="$Unit/wml:unitName = 'mon'">P<xsl:value-of select="$TimeSupport"/>M</xsl:when>
            <xsl:when test="$Unit/wml:unitAbbreviation = 'month'">P<xsl:value-of select="$TimeSupport"/>M</xsl:when>
            <xsl:when test="$Unit/wml:unitAbbreviation = 'm'">P<xsl:value-of select="$TimeSupport"/>M</xsl:when>
           
            <xsl:when test="$Unit/wml:unitName = 'year'">P<xsl:value-of select="$TimeSupport"/>Y</xsl:when>
            <xsl:when test="$Unit/wml:unitName = 'yr'">P<xsl:value-of select="$TimeSupport"/>Y</xsl:when>
            <xsl:when test="$Unit/wml:unitAbbreviation = 'year'">P<xsl:value-of select="$TimeSupport"/>Y</xsl:when>
            <xsl:when test="$Unit/wml:unitAbbreviation = 'yr'">P<xsl:value-of select="$TimeSupport"/>Y</xsl:when>
            <xsl:when test="$Unit/wml:unitAbbreviation = 'y'">P<xsl:value-of select="$TimeSupport"/>Y</xsl:when>
        </xsl:choose>
    </xsl:template>
    <xsl:template name="UOMCreator">
        <xsl:param name="Unit"/>
            
       <xsl:choose>
           <xsl:when test="$Unit/wml:unitAbbreviation">
               <xsl:value-of select="$Unit/wml:unitAbbreviation"/>
           </xsl:when>
           <xsl:when test="$Unit/wml:unitName = 'cubic feet per second'">ft^3/s</xsl:when>
           <!-- many many more needed -->
           <xsl:otherwise >
               <xsl:value-of select="$Unit/wml:unitName"/>
           </xsl:otherwise>
       </xsl:choose>
    </xsl:template>
    
    <xsl:template name="DataTypeToInterpolationType" >
        <xsl:param name="dataTypeName" />
        <wml2:interpolationType>
            <!--      xlink:href="http://www.opengis.net/def/timeseriesType/WaterML/2.0/Continuous"
                xlink:title="Continuous/Instantaneous"/>
            -->
            <xsl:choose >
                <xsl:when test="$dataTypeName='mean' or $dataTypeName='Average'">
                    <xsl:attribute name="xlink:href">
                        <xsl:value-of select="concat('http://www.opengis.net/def/timeseriesType/WaterML/2.0/',
                            'AverageSucc')" />
                    </xsl:attribute>
                    <xsl:attribute name="xlink:title">
                        Average in succeeding interval ($dataTypeName)
                    </xsl:attribute>
                </xsl:when>
                <xsl:when test="$dataTypeName='Continuous' or $dataTypeName='Instantaneous ' ">
                    <xsl:attribute name="xlink:href">
                        <xsl:value-of select="concat('http://www.opengis.net/def/timeseriesType/WaterML/2.0/',
                            'Continuous')" />
                    </xsl:attribute>
                    <xsl:attribute name="xlink:title">
                        Continuous
                    </xsl:attribute>
                </xsl:when>
                <xsl:when test="$dataTypeName='Constant Over Interval' ">
                    <xsl:attribute name="xlink:href">
                        <xsl:value-of select="concat('http://www.opengis.net/def/timeseriesType/WaterML/2.0/',
                            'ConstSucc')" />
                    </xsl:attribute>
                    <xsl:attribute name="xlink:title">
                        Constant in succeeding interval ($dataTypeName)
                    </xsl:attribute>
                </xsl:when>
                <xsl:when test="$dataTypeName='Maximum' ">
                    <xsl:attribute name="xlink:href">
                        <xsl:value-of select="concat('http://www.opengis.net/def/timeseriesType/WaterML/2.0/',
                            'MaxSucc')" />
                    </xsl:attribute>
                    <xsl:attribute name="xlink:title">
                        Maximum in succeeding interval
                    </xsl:attribute>
                </xsl:when>
                <xsl:when test="$dataTypeName='Minimum ' ">
                    <xsl:attribute name="xlink:href">
                        <xsl:value-of select="concat('http://www.opengis.net/def/timeseriesType/WaterML/2.0/',
                            'MinSucc')" />
                    </xsl:attribute>
                    <xsl:attribute name="xlink:title">
                        Minimum  in succeeding interval
                    </xsl:attribute>
                </xsl:when>
                <xsl:when test="$dataTypeName='Sporadic' ">
                    <xsl:attribute name="xlink:href">
                        <xsl:value-of select="concat('http://www.opengis.net/def/timeseriesType/WaterML/2.0/',
                            'Discontinuous')" />
                    </xsl:attribute>
                    <xsl:attribute name="xlink:title">
                        Discontinuous
                    </xsl:attribute>
                </xsl:when>
                <xsl:when test="$dataTypeName='Cumulative' ">
                    <xsl:attribute name="xlink:href">
                        <xsl:value-of select="concat('http://www.opengis.net/def/timeseriesType/WaterML/2.0/',
                            'TotalSucc')" />
                    </xsl:attribute>
                    <xsl:attribute name="xlink:title">
                        Instantaneous total ($dataTypeName)
                    </xsl:attribute>
                </xsl:when>
                <xsl:when test="$dataTypeName='Incremental' ">
                    <xsl:attribute name="xlink:href">
                        <xsl:value-of select="concat('http://www.opengis.net/def/timeseriesType/WaterML/2.0/',
                            'InstantTotal')" />
                    </xsl:attribute>
                    <xsl:attribute name="xlink:title">
                        Succeeding total
                    </xsl:attribute>
                </xsl:when>
                <xsl:when test="$dataTypeName='Variance'
                    or $dataTypeName='StandardDeviation'
                    or $dataTypeName='Mode'
                    or $dataTypeName='Median'
                    or $dataTypeName='Best Easy Systematic Estimator'">
                    <xsl:attribute name="xlink:href">
                        <xsl:value-of select="concat('http://www.opengis.net/def/timeseriesType/WaterML/2.0/',
                            'ConstSucc')" />
                    </xsl:attribute>
                    <xsl:attribute name="xlink:title">
                       Constant in succeeding interval ( $dataTypeName )
                    </xsl:attribute>
                </xsl:when>
            <xsl:otherwise>
            <xsl:attribute name="xlink:href">
                <xsl:value-of select="concat('http://www.opengis.net/def/timeseriesType/WaterML/2.0/',wml:variable/wml:dataType)" />
            </xsl:attribute>
            <xsl:attribute name="xlink:title">
                <xsl:value-of select="wml:variable/wml:dataType" />
            </xsl:attribute>
            </xsl:otherwise>
            </xsl:choose>
        </wml2:interpolationType>
    </xsl:template>
   
</xsl:stylesheet>