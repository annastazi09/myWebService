<?xml version='1.0'?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <PhoneBook>
      <xsl:apply-templates select="//Person"/>
    </PhoneBook>
  </xsl:template>
  <xsl:template match="//Person">
    <Person>
      <xsl:attribute name="id">
      <xsl:value-of select="id"/>
      </xsl:attribute>
      <xsl:attribute name="FirstName">
        <xsl:value-of select="FirstName"/>
      </xsl:attribute>
      <xsl:attribute name="LastName">
        <xsl:value-of select="LastName"/>
      </xsl:attribute>
      <xsl:attribute name="Country">
        <xsl:value-of select="Country"/>
      </xsl:attribute>
      <xsl:attribute name="City">
        <xsl:value-of select="City"/>
      </xsl:attribute>
      <xsl:attribute name="Phone">
        <xsl:value-of select="Phone"/>
      </xsl:attribute>     
    </Person>
     </xsl:template>  
</xsl:stylesheet>