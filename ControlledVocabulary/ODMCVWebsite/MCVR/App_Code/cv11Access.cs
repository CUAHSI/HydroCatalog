using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for cv11Access
/// </summary>
public class cv11Access : cvAccess
{
	public cv11Access()
	{
        SetValidConnectionString(ConfigurationManager.ConnectionStrings["CV11ConnectionString"].ConnectionString);
	}
}
