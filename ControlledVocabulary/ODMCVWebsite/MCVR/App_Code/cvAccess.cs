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
/// Summary description for cvAccess
/// </summary>
public class cvAccess : DataAccess
{
    private string connectionString;
    private SqlConnection conn;
    private SqlConnection cuahsiConn;

	public cvAccess()
	{
        cuahsiConn = new SqlConnection(ConfigurationManager.ConnectionStrings["CUAHSIWebsiteConnectionString"].ConnectionString);
	}

    public void SetValidConnectionString(string ConnectionString)
    {
        conn = new SqlConnection(ConnectionString);
    }

    public string FormatForSql(string InputString)
    {
        string Result = "";
        if (InputString != string.Empty)
        {
            Result = Regex.Replace(InputString, @"^[\s]+|[\s]+$", "");
            Result = Result.Replace("'", "''");
        }
        return Result;
    }

    public DataTable GetCVContents(string TableName)
    {
        DataTable CV10Results = new DataTable();
        if (TableName != null)
        {
            string query;
            if (TableName == "QualityControlLevels")
                query = "SELECT * FROM " + TableName + " ORDER BY QualityControlLevelID";
            else if (TableName == "SpatialReferences")
                query = "SELECT * FROM " + TableName + " ORDER BY SpatialReferenceID";
            else if (TableName == "Units")
                query = "SELECT * FROM " + TableName + " ORDER BY UnitsID";
            else
                query = "SELECT * FROM " + TableName + " ORDER BY Term";

            SqlCommand cmd = new SqlCommand(query, conn);
            CV10Results = ExecuteSelectCommand(cmd);
        }
        return CV10Results;
    }

    public string GetCVDescription(string TableName)
    {
        SqlCommand cmd = new SqlCommand("SELECT description FROM cv10 WHERE name = @name", cuahsiConn);
        cmd.Parameters.AddWithValue("@name", TableName);
        return ExecuteScalar(cmd);
    }

    public DataTable GetSelectedCV(string TableName, string Field, string Value)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM " + TableName + " WHERE " + Field + " = @Value", conn);
        cmd.Parameters.AddWithValue("@Value", Value);
        return ExecuteSelectCommand(cmd);
    }

    public DataTable GetSelectedCV_BeginningEntry(string TableName)
    {
        SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM " + TableName, conn);
        return ExecuteSelectCommand(cmd);
    }

    public DataTable GetSelectedCV(string TableName, string Field, int Value)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM " + TableName + " WHERE " + Field + " = @Value", conn);
        cmd.Parameters.AddWithValue("@Value", Value);
        return ExecuteSelectCommand(cmd);
    }

    public int GetTableMaxValue(string TableName, string Field)
    {
        int result = 0;
        SqlCommand cmd = new SqlCommand("SELECT MAX(" + Field + ") AS TopValue FROM " + TableName, conn);
        if (ExecuteScalar(cmd) != null)
        {
            result = Convert.ToInt32(ExecuteScalar(cmd));
            result++;
        }
        return result;
    }

    public void InsertIntoTempCV(string TableName, string Fields)
    {
        SqlCommand cmd = new SqlCommand("INSERT INTO temp_" + TableName + " VALUES (" + Fields + ")", conn);
        ExecuteNonQuery(cmd);
    }
}
