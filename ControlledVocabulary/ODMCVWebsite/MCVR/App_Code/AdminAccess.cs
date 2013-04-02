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

/// <summary>
/// Summary description for AdminAccess
/// </summary>
public class AdminAccess : DataAccess
{
    private MembershipUserCollection Managers,Users,All;
    private SqlConnection cv10Conn;
    private SqlConnection cv11Conn;

	public AdminAccess()
	{   
        Managers = new MembershipUserCollection();
        Users = new MembershipUserCollection();
        All = Membership.GetAllUsers();
        cv10Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CV10ConnectionString"].ConnectionString);
        cv11Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CV11ConnectionString"].ConnectionString);
    }

    public MembershipUserCollection GetManagers()
    {
        Managers.Clear();

        foreach (MembershipUser person in All)
        {
            if (Roles.IsUserInRole(person.UserName, "Manager"))
            {
                Managers.Add(person);
            }
        }
        return Managers;
    }

    public MembershipUserCollection GetUsers()
    {
        Users.Clear();

        foreach (MembershipUser person in All)
        {
            if (Roles.IsUserInRole(person.UserName, "User"))
            {
                Users.Add(person);
            }
        }
        return Users;
    }

    public void DeleteUser(string UserName)
    {
       Membership.DeleteUser(UserName);        
    }

    public DataTable CV10Result(string query)
    {
        SqlCommand cmd = new SqlCommand(query, cv10Conn);
        return ExecuteSelectCommand(cmd);
    }

    public DataTable CV11Result(string query)
    {
        SqlCommand cmd = new SqlCommand(query, cv11Conn);
        return ExecuteSelectCommand(cmd);
    }


}
