using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for VariableType
/// </summary>
public class VariableTypes
{

/*
     
      
<?xml version="1.0" encoding="utf-16"?>
<variablesResponse xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <variables xmlns="http://www.cuahsi.org/waterML/1.0/">
    <variable>
      <variableCode vocabulary="NAM">1</variableCode>
      <variableName>Total Precipitation</variableName>
      <variableDescription>Total Precipitation, kg m-2 or mm</variableDescription>
      <units unitsAbbreviation="mm" unitsCode="54" unitsType="Length">millimeter</units>
    </variable>
  </variables>
</variablesResponse>   */

    private VariableType[] variables;
    public VariableType[] getVariables() {
        return variables;
    }
    public VariableTypes(String xml)
    {
        //
        // TODO: Add constructor logic here
        //
        System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
        System.IO.TextReader textReader = new System.IO.StringReader(xml);
        doc.Load(textReader);
        System.Xml.XmlNode node, subnode;
        System.Xml.XmlNodeList nodelist = doc.GetElementsByTagName("variable");
        System.Xml.XmlNodeList subnodelist;
        VariableType var; 
        if (nodelist != null && nodelist.Count>0){
            variables = new VariableType[nodelist.Count];
            var = new VariableType();
            
            for (int i = 0; i < variables.Length; i++){
                node = nodelist.Item(i);
                subnodelist = node.ChildNodes;
                for (int j = 0; j < subnodelist.Count; j++) { 
                    subnode = subnodelist.Item(j);
                    switch (subnode.Name){
                        case "variableCode":
                            var.code.value = subnode.InnerText;
                            if (subnode.Attributes["vocabulary"]!=null) var.code.Vocabulary = subnode.Attributes["vocabulary"].Value;
                            
                            break;
                        case "variableName":
                            var.name = subnode.InnerText;
                            break;
                        case "units":
                            var.units.value = subnode.InnerText;
                            if (subnode.Attributes["unitsAbbreviation"]!=null) var.units.abbreviation = subnode.Attributes["unitsAbbreviation"].Value;
                            if (subnode.Attributes["unitsCode"]!=null) var.units.code = subnode.Attributes["unitsCode"].Value;
                            if (subnode.Attributes["unitsType"]!=null) var.units.type = subnode.Attributes["unitsType"].Value;
                            break;
                        case "variableDescription":
                            var.desc = subnode.InnerText;
                            break;
                        default:
                            break;
                    }
                
                }
                
            }       

        }

    }
}
