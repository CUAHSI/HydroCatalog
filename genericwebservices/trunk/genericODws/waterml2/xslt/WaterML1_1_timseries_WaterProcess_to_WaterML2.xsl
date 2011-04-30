<?xml version="1.0" encoding="UTF-8"?>
<!-- Created with Liquid XML Studio Developer Edition (Education) 9.0.11.3078 (http://www.liquid-technologies.com) -->
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:wml2="http://www.opengis.net/waterml/2.0" xmlns:gml="http://www.opengis.net/gml/3.2" xmlns:om="http://www.opengis.net/om/2.0" xmlns:xlink="http://www.w3.org/1999/xlink" xmlns:wml="http://www.cuahsi.org/waterML/1.1/" xmlns:fn="http://www.w3.org/2005/xpath-functions" xsi:schemaLocation="http://www.opengis.net/waterml/2.0 ../GeneratedSchema_13_10_2010/WaterCollection.xsd" xmlns:xs="http://www.w3.org/2001/XMLSchema" exclude-result-prefixes="xs" version="2.0">
    <!--
    <wml2:ObservationProcess xmlns:gml="http://www.opengis.net/gml/3.2" xmlns:om="http://www.opengis.net/om/2.0" xmlns:wml2="http://www.opengis.net/waterml/2.0" xmlns:xlink="http://www.w3.org/1999/xlink" xmlns:gmd="http://www.isotc211.org/2005/gmd" xmlns:gco="http://www.isotc211.org/2005/gco" xmlns:gss="http://www.isotc211.org/2005/gss" xmlns:gts="http://www.isotc211.org/2005/gts" xmlns:gsr="http://www.isotc211.org/2005/gsr" xmlns:sams="http://www.opengis.net/samplingSpatial/2.0" xmlns:sam="http://www.opengis.net/sampling/2.0" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:schemaLocation="http://www.opengis.net/waterml/2.0 C:\dev_Woml\WaterML\WaterML2.0\trunk\GeneratedSchema_25_03_2011\observationProcess.xsd" gml:id="AAAAA">
    <gml:metaDataProperty type="simple" xlink:role="http://www.liquid-technologies.com" xlink:arcrole="http://www.liquid-technologies.com" xlink:actuate="none" about="http://www.liquid-technologies.com" />
    <gml:descriptionReference owns="true" type="simple" xlink:role="http://www.liquid-technologies.com" xlink:title="string" xlink:actuate="other" nilReason="http://www.liquid-technologies.com" />
    <gml:identifier codeSpace="http://www.liquid-technologies.com">string</gml:identifier>
    <gml:name>string</gml:name>
    <gml:name codeSpace="http://www.liquid-technologies.com">string</gml:name>
    <wml2:processType owns="false" type="simple" xlink:href="http://www.liquid-technologies.com" xlink:arcrole="http://www.liquid-technologies.com" xlink:show="replace" xlink:actuate="onRequest" nilReason="http://www.liquid-technologies.com" gml:remoteSchema="http://www.liquid-technologies.com" />
    <wml2:originatingProcess owns="false" type="simple" xlink:arcrole="http://www.liquid-technologies.com" xlink:show="embed" nilReason="http://www.liquid-technologies.com" />
    <wml2:aggregationPeriod>P6Y1M1DT15H42M30.74S</wml2:aggregationPeriod>
    <wml2:gaugeDatum owns="1" xlink:arcrole="http://www.liquid-technologies.com" xlink:title="string" xlink:show="replace" nilReason="http://www.liquid-technologies.com" />
    <wml2:operator>string</wml2:operator>
    <wml2:operatorComments>string</wml2:operatorComments>
    <wml2:operatorComments>string</wml2:operatorComments>
    <wml2:operatorComments>string</wml2:operatorComments>
    <wml2:operatorComments>string</wml2:operatorComments>
    <wml2:operatorComments>string</wml2:operatorComments>
    <wml2:processReference type="simple" xlink:title="string" gml:remoteSchema="http://www.liquid-technologies.com" />
    <wml2:input type="simple" xlink:href="http://www.liquid-technologies.com" xlink:role="http://www.liquid-technologies.com" xlink:arcrole="http://www.liquid-technologies.com" xlink:title="string" xlink:actuate="none" nilReason="" gml:remoteSchema="http://www.liquid-technologies.com" />
    <wml2:input xlink:href="http://www.liquid-technologies.com" xlink:role="http://www.liquid-technologies.com" xlink:title="string" xlink:show="embed" nilReason="http://www.liquid-technologies.com" />
    <wml2:input owns="false" xlink:href="http://www.liquid-technologies.com" xlink:role="http://www.liquid-technologies.com" xlink:arcrole="http://www.liquid-technologies.com" xlink:title="string" xlink:show="replace" xlink:actuate="other" nilReason="" />
    <wml2:input xlink:arcrole="http://www.liquid-technologies.com" xlink:title="string" xlink:actuate="other" nilReason="http://www.liquid-technologies.com" />
    <wml2:input owns="0" type="simple" xlink:role="http://www.liquid-technologies.com" xlink:show="replace" xlink:actuate="onLoad" nilReason="http://www.liquid-technologies.com" gml:remoteSchema="http://www.liquid-technologies.com" />
    <wml2:parameter type="simple" xlink:href="http://www.liquid-technologies.com" xlink:show="embed" gml:remoteSchema="http://www.liquid-technologies.com" />
    <wml2:parameter type="simple" xlink:role="http://www.liquid-technologies.com" xlink:title="string" xlink:show="embed" />
</wml2:ObservationProcess>
    -->
    <xsl:output method="xml" indent="yes" />
    <xsl:template name="WaterObservationProcess" match="wml:timeSeriesResponse">
      <xsl:comment> http://www.opengis.net/spec/waterml/2.0/req/xml-water-observation/procedure
       The XML element “om:procedure” shall contain a subelement of “wml:WaterObservationProcess” or a member of its substitution group, or a xlink:href attribute referencing a such an element.</xsl:comment> 
       
        <xsl:comment>9.6	Requirements Class: Water Observation Procedures</xsl:comment>
        <wml:WaterObservationProcess>
            <xsl:if test="wml:values/wml:method/wml:methodName">
                <gml:name codeSpace="urn:cuashi/his/localservice">
                    <xsl:value-of select="wml:values/wml:method/wml:methodName" />
                </gml:name>
                <xsl:call-template name="ChooseMethodName" />
            </xsl:if>
            <wml:processType>
                <xsl:attribute name="xlink:href">
                    <xsl:text>http://www.opengis.net/def/processType/WaterML/2.0/Unknown</xsl:text>
                </xsl:attribute>
                <xsl:attribute name="xlink:title">
                    <xsl:call-template name="ChooseMethodName" />
                </xsl:attribute>
            </wml:processType>
            <wml:processReference>
                <xsl:choose>
                    <xsl:when test="wml:values/wml:method/wml:methodLink">
                        <xsl:attribute name="xlink:href">
                            <xsl:value-of select="wml:values/wml:method/wml:methodLink" />
                        </xsl:attribute>
                        <xsl:attribute name="xlink:title">
                            <xsl:call-template name="ChooseMethodName" />
                        </xsl:attribute>
                    </xsl:when>
                    <xsl:when test="wml:values/wml:method/wml:methodDescription">
                        <xsl:attribute name="xlink:href">
                            <xsl:text>urn:cuahsi/wof/method:</xsl:text>
                            <xsl:value-of select="wml:values/wml:method/wml:methodCode" />
                        </xsl:attribute>
                        <xsl:attribute name="xlink:title">
                            <xsl:call-template name="ChooseMethodName" />
                        </xsl:attribute>
                    </xsl:when>
                    <xsl:otherwise>
                        <xsl:attribute name="xlink:href">
                            <xsl:text>urn:cuahsi/wof/method/unknown</xsl:text>
                        </xsl:attribute>
                        <xsl:attribute name="xlink:title">
                            <xsl:call-template name="ChooseMethodName" />
                        </xsl:attribute>
                    </xsl:otherwise>
                </xsl:choose>
            </wml:processReference>
            <xsl:if test="wml:variable/wml:timeScale/wml:timeSupport != 0">
                 <wml2:aggregationPeriod>
                    <xsl:value-of select="concat(&quot;PT&quot;,wml:variable/wml:timeScale/wml:timeSupport,substring(wml:variable/wml:timeScale/wml:unit/wml:unitAbbreviation,1,1))" />
                </wml2:aggregationPeriod>
                <xsl:comment>TBD: fixed example. aggregationPeriod not calculated.</xsl:comment>
           </xsl:if>
            
        </wml:WaterObservationProcess>
    </xsl:template>
    <xsl:template name="ChooseMethodName">
        <xsl:choose>
            <xsl:when test="wml:values/wml:method/wml:methodName">
                <xsl:value-of select="wml:values/wml:method/wml:methodName" />
            </xsl:when>
            <xsl:when test="wml:values/wml:method/wml:methodDescription">
                <xsl:value-of select="wml:values/wml:method/wml:methodDescription" />
            </xsl:when>
            <xsl:otherwise>
                <xsl:text>method name not specified</xsl:text>
            </xsl:otherwise>
        </xsl:choose>
    </xsl:template>
</xsl:stylesheet>
