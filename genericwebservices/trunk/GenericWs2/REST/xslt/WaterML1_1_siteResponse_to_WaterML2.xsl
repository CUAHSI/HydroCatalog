<?xml version="1.0" encoding="UTF-8"?>
<!-- Created with Liquid XML Studio Developer Edition (Education) 9.0.11.3078 (http://www.liquid-technologies.com) -->
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
xmlns:xs="http://www.w3.org/2001/XMLSchema"
xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" 
xmlns:wml2="http://www.opengis.net/waterml/2.0"
xmlns:sam="http://www.opengis.net/sampling/2.0" 
xmlns:gml="http://www.opengis.net/gml/3.2" 
xmlns:om="http://www.opengis.net/om/2.0" 
xmlns:sams="http://www.opengis.net/samplingSpatial/2.0"
xmlns:xlink="http://www.w3.org/1999/xlink"
xmlns:wml="http://www.cuahsi.org/waterML/1.1/" 
xsi:schemaLocation="http://www.opengis.net/waterml/2.0  ../Transforms/Schemas/WaterML/waterml2.xsd" 
exclude-result-prefixes="xs" version="2.0">
    
    <xsl:output method="xml" indent="yes" />
    <xsl:template match="wml:sitesResponse">
        <sam:SF_SamplingFeatureCollection>
            <xsl:comment>reference to sampledFeature would be here. eg something like a river reach stored in a WFS (or a web page)</xsl:comment>
            <xsl:for-each select="wml:site">
                <sam:member>
                    <wml2:WaterObservationPoint>
                        <gml:name codeSpace="TODO">
                            <xsl:value-of select="wml:siteInfo/wml:siteCode" />
                        </gml:name>
                        <gml:description>
                            <xsl:value-of select="wml:siteInfo/wml:siteName" />
                        </gml:description>
                        <sams:shape>
                            <gml:Point>
                                <xsl:attribute name="gml:id">
                                    <xsl:value-of select="concat(wml:siteInfo/wml:siteCode, &quot;_pos&quot;)" />
                                </xsl:attribute>
                                <gml:pos>
                                    <xsl:attribute name="srsName">
                                        <xsl:value-of select="wml:siteInfo/wml:geoLocation/wml:geogLocation/@srs" />
                                    </xsl:attribute>
                                    <xsl:value-of select="wml:siteInfo/wml:geoLocation/wml:geogLocation/wml:latitude" />
                                    <xsl:value-of select="wml:siteInfo/wml:geoLocation/wml:geogLocation/wml:longitude" />
                                </gml:pos>
                            </gml:Point>
                        </sams:shape>
                        <xsl:apply-templates select="wml:siteInfo/wml:elevation_m" />
                        <xsl:apply-templates select="wml:siteInfo/wml:verticalDatum" />
                        <xsl:for-each select="wml:siteInfo/wml:note">
                            <sam:parameter>
                                <om:NamedValue>
                                    <om:name xlink:href="http://www.cuahsi.org/waterml2/params/unknownNoteName/">
                                        <xsl:attribute name="xlink:href">
                                            <xsl:value-of select="concat('http://www.cuahsi.org/waterml2/params/', @title)" />
                                        </xsl:attribute>
                                    </om:name>
                                    <om:value xsi:type="xsd:string">
                                        <xsl:value-of select="." />
                                    </om:value>
                                </om:NamedValue>
                            </sam:parameter>
                        </xsl:for-each>
                        <xsl:for-each select="wml:siteInfo/wml:siteProperty">
                            <sam:parameter>
                                <om:NamedValue>
                                    <om:name xlink:href="http://www.cuahsi.org/waterml2/params/unknownPropertyName/">
                                        <xsl:attribute name="xlink:href">
                                            <xsl:value-of select="concat('http://www.cuahsi.org/waterml2/params/', @name)" />
                                        </xsl:attribute>
                                    </om:name>
                                    <om:value xsi:type="xsd:string">
                                        <xsl:value-of select="." />
                                    </om:value>
                                </om:NamedValue>
                            </sam:parameter>
                        </xsl:for-each>
                    </wml2:WaterObservationPoint>
                </sam:member>
            </xsl:for-each>
        </sam:SF_SamplingFeatureCollection>
    </xsl:template>
    <xsl:template match="wml:elevation_m">
        <sam:parameter>
            <om:NamedValue>
                <om:name xlink:href="http://www.cuahsi.org/waterml2/params/elevation_m/">
                </om:name>
                <om:value xsi:type="xsd:string">
                    <xsl:value-of select="." />
                </om:value>
            </om:NamedValue>
        </sam:parameter>
    </xsl:template>
    <xsl:template match="wml:verticalDatum">
        <sam:parameter>
            <om:NamedValue>
                <om:name xlink:href="http://www.cuahsi.org/waterml2/params/verticalDatum/">
                </om:name>
                <om:value xsi:type="xsd:string">
                    <xsl:value-of select="." />
                </om:value>
            </om:NamedValue>
        </sam:parameter>
    </xsl:template>
</xsl:stylesheet>
