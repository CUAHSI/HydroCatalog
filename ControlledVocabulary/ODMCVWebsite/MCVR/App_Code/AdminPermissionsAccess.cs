using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
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
/// Summary description for AdminPermissionsAccess
/// </summary>
public class AdminPermissionsAccess : DataAccess
{
    private SqlConnection cuahsiConn;

	public AdminPermissionsAccess()
	{
        cuahsiConn = new SqlConnection(ConfigurationManager.ConnectionStrings["CUAHSIWebsiteConnectionString"].ConnectionString);
	}

    public string GetCurrentCV10Permissions(string UserName)
    {
        SqlCommand cmd = new SqlCommand("SELECT DISTINCT name FROM cv10_Managers WHERE UserId = (SELECT UserId FROM aspnet_Users WHERE UserName = @UserName)", cuahsiConn);
        cmd.Parameters.AddWithValue("@UserName", UserName);
        DataTable List = ExecuteSelectCommand(cmd);

        string result = "";
        if (List.Rows.Count > 0)
        {
            foreach (DataRow li in List.Rows)
                result += li[0].ToString() + ", ";
        }
        if (result.Length > 0)
        {
            result.Trim();
            result.Remove(result.Length - 1, 1);
        }
        return result;
    }

    public List<string> GetCurrentCV10PermissionsList(string UserName)
    {
        SqlCommand cmd = new SqlCommand("SELECT DISTINCT name FROM cv10_Managers WHERE UserId = (SELECT UserId FROM aspnet_Users WHERE UserName = @UserName)", cuahsiConn);
        cmd.Parameters.AddWithValue("@UserName", UserName);
        DataTable List = ExecuteSelectCommand(cmd);

        List<string> result = new List<string>();
        
        if (List.Rows.Count > 0)
        {
            foreach (DataRow li in List.Rows)
                result.Add(li[0].ToString());
        }
        
        return result;
    }

    public List<string> GetRemainingCV10Permissions(string UserName)
    {
        SqlCommand cmd = new SqlCommand("SELECT name FROM cv10 WHERE name NOT IN (SELECT DISTINCT name FROM cv10_Managers WHERE UserId = (SELECT UserId FROM aspnet_Users WHERE UserName = @UserName))", cuahsiConn);
        cmd.Parameters.AddWithValue("@UserName", UserName);
        DataTable List = ExecuteSelectCommand(cmd);

        List<string> result = new List<string>();

        if (List.Rows.Count > 0)
        {
            foreach (DataRow li in List.Rows)
                result.Add(li[0].ToString());
        }
        return result;
    }

    public void AddCV10Permission(string UserName, string name)
    {
        SqlCommand cmd_ID = new SqlCommand("SELECT id FROM cv10 WHERE name = @name", cuahsiConn);
        cmd_ID.Parameters.AddWithValue("@name", name);
        int ID = Convert.ToInt32(ExecuteScalar(cmd_ID));

        SqlCommand cmd_UserID = new SqlCommand("SELECT UserId FROM aspnet_Users WHERE UserName = @UserName", cuahsiConn);
        cmd_UserID.Parameters.AddWithValue("@UserName", UserName);

        SqlCommand command = new SqlCommand("INSERT INTO cv10_Managers VALUES (@ID,@name,@UserId)", cuahsiConn);
        command.Parameters.AddWithValue("@ID", ID);
        command.Parameters.AddWithValue("@name", name);

        cmd_UserID.Connection.Open();
        command.Parameters.AddWithValue("@UserId", cmd_UserID.ExecuteScalar());
        cmd_UserID.Connection.Close();

        ExecuteNonQuery(command);
    }

    public void RemoveCV10Permission(string UserName, string name)
    {
        SqlCommand cmd_UserID = new SqlCommand("SELECT UserId FROM aspnet_Users WHERE UserName = @UserName", cuahsiConn);
        cmd_UserID.Parameters.AddWithValue("@UserName", UserName);

        SqlCommand cmd = new SqlCommand("DELETE FROM cv10_Managers WHERE (name = @name) AND (UserId = @UserId)", cuahsiConn);
        cmd.Parameters.AddWithValue("@name", name);

        cmd_UserID.Connection.Open();
        cmd.Parameters.AddWithValue("@UserId", cmd_UserID.ExecuteScalar());
        cmd_UserID.Connection.Close();

        ExecuteNonQuery(cmd);  
    }

    public void RemoveAllCV10Permissions(string UserName)
    {
        SqlCommand cmd_UserID = new SqlCommand("SELECT UserId FROM aspnet_Users WHERE UserName = @UserName", cuahsiConn);
        cmd_UserID.Parameters.AddWithValue("@UserName", UserName);

        SqlCommand cmd = new SqlCommand("DELETE FROM cv10_Managers WHERE (UserId = @UserId)", cuahsiConn);

        cmd_UserID.Connection.Open();
        cmd.Parameters.AddWithValue("@UserId", cmd_UserID.ExecuteScalar());
        cmd_UserID.Connection.Close();

        ExecuteNonQuery(cmd);
    }

    public string GetCurrentCV11Permissions(string UserName)
    {
        SqlCommand cmd = new SqlCommand("SELECT DISTINCT name FROM cv11_Managers WHERE UserId = (SELECT UserId FROM aspnet_Users WHERE UserName = @UserName)", cuahsiConn);
        cmd.Parameters.AddWithValue("@UserName", UserName);
        DataTable List = ExecuteSelectCommand(cmd);

        string result = "";
        if (List.Rows.Count > 0)
        {
            foreach (DataRow li in List.Rows)
                result += li[0].ToString() + ", ";
        }
        if (result.Length > 0)
        {
            result.Trim();
            result.Remove(result.Length - 1, 1);
        }
        return result;
    }

    public List<string> GetCurrentCV11PermissionsList(string UserName)
    {
        SqlCommand cmd = new SqlCommand("SELECT DISTINCT name FROM cv11_Managers WHERE UserId = (SELECT UserId FROM aspnet_Users WHERE UserName = @UserName)", cuahsiConn);
        cmd.Parameters.AddWithValue("@UserName", UserName);
        DataTable List = ExecuteSelectCommand(cmd);

        List<string> result = new List<string>();

        if (List.Rows.Count > 0)
        {
            foreach (DataRow li in List.Rows)
                result.Add(li[0].ToString());
        }

        return result;
    }

    public List<string> GetRemainingCV11Permissions(string UserName)
    {
        SqlCommand cmd = new SqlCommand("SELECT name FROM cv11 WHERE name NOT IN (SELECT DISTINCT name FROM cv11_Managers WHERE UserId = (SELECT UserId FROM aspnet_Users WHERE UserName = @UserName))", cuahsiConn);
        cmd.Parameters.AddWithValue("@UserName", UserName);
        DataTable List = ExecuteSelectCommand(cmd);

        List<string> result = new List<string>();

        if (List.Rows.Count > 0)
        {
            foreach (DataRow li in List.Rows)
                result.Add(li[0].ToString());
        }
        return result;
    }

    public void AddCV11Permission(string UserName, string name)
    {
        SqlCommand cmd_ID = new SqlCommand("SELECT id FROM cv11 WHERE name = @name", cuahsiConn);
        cmd_ID.Parameters.AddWithValue("@name", name);
        int ID = Convert.ToInt32(ExecuteScalar(cmd_ID));

        SqlCommand cmd_UserID = new SqlCommand("SELECT UserId FROM aspnet_Users WHERE UserName = @UserName", cuahsiConn);
        cmd_UserID.Parameters.AddWithValue("@UserName", UserName);

        SqlCommand command = new SqlCommand("INSERT INTO cv11_Managers VALUES (@ID,@name,@UserId)", cuahsiConn);
        command.Parameters.AddWithValue("@ID", ID);
        command.Parameters.AddWithValue("@name", name);

        cmd_UserID.Connection.Open();
        command.Parameters.AddWithValue("@UserId", cmd_UserID.ExecuteScalar());
        cmd_UserID.Connection.Close();

        ExecuteNonQuery(command);
    }

    public void RemoveCV11Permission(string UserName, string name)
    {
        SqlCommand cmd_UserID = new SqlCommand("SELECT UserId FROM aspnet_Users WHERE UserName = @UserName", cuahsiConn);
        cmd_UserID.Parameters.AddWithValue("@UserName", UserName);

        SqlCommand cmd = new SqlCommand("DELETE FROM cv11_Managers WHERE (name = @name) AND (UserId = @UserId)", cuahsiConn);
        cmd.Parameters.AddWithValue("@name", name);

        cmd_UserID.Connection.Open();
        cmd.Parameters.AddWithValue("@UserId", cmd_UserID.ExecuteScalar());
        cmd_UserID.Connection.Close();

        ExecuteNonQuery(cmd);
    }

    public void RemoveAllCV11Permissions(string UserName)
    {
        SqlCommand cmd_UserID = new SqlCommand("SELECT UserId FROM aspnet_Users WHERE UserName = @UserName", cuahsiConn);
        cmd_UserID.Parameters.AddWithValue("@UserName", UserName);

        SqlCommand cmd = new SqlCommand("DELETE FROM cv11_Managers WHERE (UserId = @UserId)", cuahsiConn);
        
        cmd_UserID.Connection.Open();
        cmd.Parameters.AddWithValue("@UserId", cmd_UserID.ExecuteScalar());
        cmd_UserID.Connection.Close();

        ExecuteNonQuery(cmd);
    }

    public string getAdminEmail()
    {
        string email = "";
        List<string> administrators = Roles.GetUsersInRole("Administrator").ToList<string>();
        email = Membership.GetUser(administrators[0]).Email.ToString();
        return email;
    }

    public string getAdminEmails()
    {
        string email = "";
        List<string> administrators = Roles.GetUsersInRole("Administrator").ToList<string>();
        if (administrators.Count > 1)
        {
            foreach (string person in administrators)
            {
                email += Membership.GetUser(person).Email.ToString() + ",";
            }
        }
        else
            email = Membership.GetUser(administrators[0]).Email.ToString();

        return email;
    }

}
