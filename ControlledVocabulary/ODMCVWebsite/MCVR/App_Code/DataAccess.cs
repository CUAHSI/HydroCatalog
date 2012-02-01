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
/// Summary description for DataAccess
/// </summary>
public class DataAccess
{
	public DataAccess()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    // execute a command and return the results as a DataTable object
    public DataTable ExecuteSelectCommand(SqlCommand command)
    {
        // The DataTable to be returned 
        DataTable table;
        // Execute the command making sure the connection gets closed in the end
        try
        {
            // Open the data connection 
            command.Connection.Open();
            // Execute the command and save the results in a DataTable
            SqlDataReader reader = command.ExecuteReader();
            table = new DataTable();
            table.Load(reader);
            // Close the reader 
            reader.Close();
        }
        catch (Exception ex)
        {
            //Utilities.LogError(ex);
            throw ex;
        }
        finally
        {
            // Close the connection
            command.Connection.Close();
        }
        return table;
    }

    // execute an update, delete, or insert command 
    // and return the number of affected rows
    public int ExecuteNonQuery(SqlCommand command)
    {
        // The number of affected rows 
        int affectedRows = -1;
        // Execute the command making sure the connection gets closed in the end
        //try
        //{
            // Open the connection of the command
            command.Connection.Open();
            // Execute the command and get the number of affected rows
            affectedRows = command.ExecuteNonQuery();
        //}
        //catch (Exception ex)
        //{
        //    // Log eventual errors and rethrow them
        //    //Utilities.LogError(ex);
        //    //throw ex;
        //}
        //finally
        //{
            // Close the connection
            command.Connection.Close();
        //}
        // return the number of affected rows
        return affectedRows;
    }

    // execute a select command and return a single result as a string
    public static string ExecuteScalar(SqlCommand command)
    {
        // The value to be returned 
        string value = "";
        // Execute the command making sure the connection gets closed in the end
        try
        {
            // Open the connection of the command
            command.Connection.Open();
            // Execute the command and get the number of affected rows
            value = command.ExecuteScalar().ToString();
        }
        catch (Exception ex)
        {
            // Log eventual errors and rethrow them
            //Utilities.LogError(ex);
            throw ex;
        }
        finally
        {
            // Close the connection
            command.Connection.Close();
        }
        // return the result
        return value;
    }
    
    // creates and prepares a new DbCommand object on a new connection

    public SqlCommand CreateCommand(string connectionString)
    {
        // Set the connection string
        SqlConnection conn = new SqlConnection(connectionString);        
        conn.ConnectionString = connectionString;
        // Create a database specific command object
        SqlCommand comm = conn.CreateCommand();
        // Set the command type to stored procedure
        return comm;
    }

}
