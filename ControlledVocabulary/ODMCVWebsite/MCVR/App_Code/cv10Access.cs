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
using System.Data.SqlClient;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for cv10Access
/// </summary>
public class cv10Access : cvAccess
{
	public cv10Access()
	{
        SetValidConnectionString(ConfigurationManager.ConnectionStrings["CV10ConnectionString"].ConnectionString);
    }

    public void SendSubmissionMail(string actionFlag,string tableName,string tableID,string submitterInfo,string changeInfo,string msgTo)
    {
        string moderator = "ravichandvegiraju@gmail.com";

        Mail SendMail = new Mail();
        SendMail.RequestSubmitEmailNotification(actionFlag,moderator,tableName,tableID,submitterInfo,changeInfo,msgTo);
    }
}
