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
public class VariableType
{
    /*
     * <?xml version="1.0" encoding="utf-16"?>
<variablesResponse xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <variables xmlns="http://www.cuahsi.org/waterML/1.0/">
    <variable>
      <variableCode vocabulary="NAM">1</variableCode>
      <variableName>Total Precipitation</variableName>
      <variableDescription>Total Precipitation, kg m-2 or mm</variableDescription>
      <units unitsAbbreviation="mm" unitsCode="54" unitsType="Length">millimeter</units>
    </variable>
  </variables>
</variablesResponse>   
     */
    public VariableCode code;
    public String desc="";
    public String name="";
    public VariableUnits units;


	public VariableType()
	{
		//
		// TODO: Add constructor logic here
		//
        code = new VariableCode();
        units = new VariableUnits();


	}
    public class VariableUnits{
        public String abbreviation = "";
        public String code = "";
        public String type = "";
        public String value = "";
    }
    
    public class VariableCode{
        public String Vocabulary = "";
        public String value = "";
    }
}
