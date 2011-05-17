<?xml version="1.0" encoding="utf-8"?>
<!-- Created with Liquid XML Studio Developer Edition (Education) 9.0.11.3078 (http://www.liquid-technologies.com) -->
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:dc="http://purl.org/dc/elements/1.1/" version="1.0">
    <xsl:template match="//rss">
        <html>
            <head>
    <!--            <style type="text/css">
        p.active {color:#FF0000;}
        p.historic {color:#00AA00;}
        p.disabled {color:#AAAA00;}
        </style>
        -->
            </head>
            <body>
                <h1>
                    <xsl:value-of select="/rss/channel/title" />
                </h1>
                <p>
                    <xsl:value-of select="/rss/channel/description" disable-output-escaping="yes" />
                </p>
   
                <xsl:for-each select="/rss/channel/item">
                    <h2>
                        <xsl:value-of select="title" />
                    </h2>
                    <p>
                        <xsl:choose>
                            <xsl:when test="contains(description,'Active')">
                                <xsl:choose>
                                    <xsl:when test="contains(description,'Disabled')">
                                        <xsl:attribute name="class">disabled</xsl:attribute>
                                    </xsl:when>
                                    <xsl:otherwise>
                                        <xsl:attribute name="class">active</xsl:attribute>
                                    </xsl:otherwise>
                                </xsl:choose>
                            </xsl:when>
                            <xsl:otherwise>
                                <xsl:attribute name="class">historic</xsl:attribute>
                            </xsl:otherwise>
                        </xsl:choose>
                        <xsl:value-of select="description" disable-output-escaping="yes" />
                    </p>
                    <p>
                        <!--  <xsl:element name="a">
      	<xsl:attribute name="href">
        	<xsl:value-of select="link"/>
      	</xsl:attribute>
      	Read more...
    </xsl:element>
            -->
                    </p>

                </xsl:for-each>
            </body>
        </html>
    </xsl:template>
</xsl:stylesheet>
