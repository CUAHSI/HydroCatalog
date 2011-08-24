<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:s="http://www.w3.org/2001/XMLSchema"
  >
  <xsl:output
    method="xml"
    indent="no"
    encoding="utf-8"
    omit-xml-declaration="no"
  />
  <!-- dissolve any schema extension elements to the base structure -->

  <xsl:template match="/" xml:space="default">
    <xsl:apply-templates />
  </xsl:template>

  <xsl:template match="*" priority="0.5" xml:space="default">
    <xsl:copy>
      <xsl:copy-of select="attribute::*" />
      <xsl:choose>
        <xsl:when test="child::*" />
        <xsl:otherwise>
          <xsl:value-of select="." />
        </xsl:otherwise>
      </xsl:choose>
      <xsl:apply-templates select="child::*" />
    </xsl:copy>
  </xsl:template>

  <xsl:template match="s:complexType" priority="1.0">
    <xsl:element name="s:complexType" namespace="http://www.w3.org/2001/XMLSchema">
      <xsl:copy-of select="attribute::*" />
      <xsl:element name="s:sequence">
        <xsl:copy-of select=".//s:sequence/*" />
        <xsl:if test="./s:complexContent/s:extension">
          <xsl:comment>
            schema extension expanded: <xsl:value-of
            select="./s:complexContent/s:extension/@base"/>
          </xsl:comment>
          <xsl:call-template name="fetch-sequence">
            <xsl:with-param name="typename"
              select="substring-after(./s:complexContent/s:extension/@base,':')" />
          </xsl:call-template>
        </xsl:if>
      </xsl:element>
    </xsl:element>
  </xsl:template>

  <xsl:template name="fetch-sequence">
    <xsl:param name="typename" />
    <xsl:copy-of select="//s:complexType[@name = $typename]//s:sequence/*" />
    <xsl:if test="//s:complexType[@name = $typename]/s:complexContent/s:extension">
      <xsl:call-template name="fetch-sequence">
        <xsl:with-param name="typename"
          select="substring-after(//s:complexType[@name = $typename]/s:complexContent/s:extension/@base,':')" />
      </xsl:call-template>
    </xsl:if>
  </xsl:template>

</xsl:stylesheet>
