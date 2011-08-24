using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenSearchUriTemplate
{
    public class TemplateParameters
    {
        public  Dictionary<string, string> ParameterNames =
            new Dictionary<string, string>()
                                {
                                    {"Cuahsi.Variable", "Complete 'vocabulary:variableCode'"},
                                   {"Cuahsi.VariableCode", "variableCode 'vocabulary:variableCode'"},
                                    {"Cuahsi.Vocabularye", "vocabulary 'vocabulary:variableCode'"},
                                    {"Cuahsi.Site", "complete 'Network:SiteCode"},
{"Cuahsi.Network", "Network 'Network:SiteCode"},
{"Cuahsi.SiteCode", "SiteCode 'Network:SiteCode"},
{"time:start", "BeginDateTime"},
{"time:end", "EndDateTime"},
{"time:end", "EndDateTime"},
{"Cuahsi.VariableOption.{Option}", "option from   'vocabulary:variableCode/{Option}=ABCD'"},
{"Cuahsi.VariableOption.DataType", "DataType option from   'vocabulary:variableCode/DataType=ABCD'"},
{"Cuahsi.SiteOption.Agency", "Agency from 'Network:SiteCode/Agency=ABCD'"},

 {"Cuahsi.Location", "complete 'GEOM:POINT(x y) or GEOM:BOX()"},
  {"Cuahsi.Location.Point", "POINT(x y)  portion from 'GEOM:POINT(x y)"},
  {"Cuahsi.Location.Box", "BOX() portion from  'GEOM:BOX()"},
 {"geo:lat", "Y from POINT(x y)  'GEOM:POINT(x y)"},
  {"geo:lon", "X from POINT(x y)  'GEOM:POINT(x y)"},
   {"geo:box", "geo:box  minX, minY, maxX, maxY from 'GEOM:BOX()"}
                                };
    }
}
