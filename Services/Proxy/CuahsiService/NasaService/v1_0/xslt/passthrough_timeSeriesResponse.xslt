<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
xmlns:wml11="http://www.cuahsi.org/waterML/1.1/" 
xmlns:wml10="http://www.cuahsi.org/waterML/1.0/"
xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" >
  <xsl:output method="xml" version="1.0"
encoding="utf-8" indent="yes"/>
     <xsl:namespace-alias stylesheet-prefix="wml11" result-prefix="wml10" />

    <xsl:template match="//wml10:timeSeriesResponse"><xsl:copy-of select="." />
    </xsl:template>
</xsl:stylesheet>
