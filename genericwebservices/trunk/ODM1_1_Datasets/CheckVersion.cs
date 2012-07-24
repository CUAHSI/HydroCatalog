using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace WaterOneFlow.odm.v1_1
{
    public static  class CheckVersion
    {
        public static Boolean isOdm111(string connectionString)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var command = conn.CreateCommand();
                command.CommandText = "Select VersionNumber from ODMversion";
                conn.Open();
                var version = Convert.ToString(command.ExecuteScalar());
                conn.Close();
                if (version.Equals("1.1.1"))
                {
                    return true;
                }
                else {return false;}
            }
        }
    }
}
