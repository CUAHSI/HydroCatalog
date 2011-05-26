using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using cuahsi.wof.ruon;
using Ruon;
using ServicesWebSite;

namespace ServicesWebSite.services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MonitoringCollector" in code, svc and config file together.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class MonitoringCollector : IMonitoringCollector
    {
        private string InsertCommand = @"INSERT INTO [hiscentral_logging].[dbo].[ServiceMonitor]
           ([Identifier]
           ,[ServiceName]
           ,[MethodName]
           ,[Working]
           ,[ErrorString]
           ,[RunTime]
           ,[Servity]
           ,[Location]
           ,[Variable]
           ,[StartDate]
           ,[EndDate]
           ,[Endpoint]
           ,[ExceptionMessage])
     VALUES
           (@Identifier
           ,@ServiceName
           ,@MethodName
           ,@Working
           ,@ErrorString
           ,@RunTime
           ,@Servity
           ,@Location
           ,@Variable
           ,@StartDate
           ,@EndDate
           ,@Endpoint
           ,@ExceptionMessage)";
        
        public MonitoringCollector()
        {

         }
       
       public  void AcceptTestResult(TestResult testResult)
       {
           AcceptTestResults(new List<TestResult>(1){testResult});
           return;
       }


       public void AcceptTestResults(List<TestResult> testResult)
       {
           using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["hiscentral_loggingConnectionString"].ConnectionString))
           {
               using (var cmd = new SqlCommand(InsertCommand, conn))
               { 
                   conn.Open();
                   foreach (TestResult result in testResult)
                   {
                       try
                       {
                           cmd.Parameters.Clear();
                           var sev = Enum.GetName(typeof (AlarmSeverity), result.Serverity).ToString();
                           cmd.Parameters.Add(new SqlParameter("Identifier",SqlDbType.UniqueIdentifier));
                           cmd.Parameters["Identifier"].Value = result.Identifier;
                           cmd.Parameters.Add(new SqlParameter("ServiceName", SqlDbType.VarChar, 50));
                           cmd.Parameters["ServiceName"].Value = result.ServiceName ?? String.Empty;
                           cmd.Parameters.Add(new SqlParameter("MethodName", SqlDbType.VarChar, 50));
                           cmd.Parameters["MethodName"].Value = result.MethodName ?? String.Empty;
                           cmd.Parameters.Add(new SqlParameter("Working", SqlDbType.Bit));
                          cmd.Parameters["Working"].Value = result.Working.HasValue? result.Working.Value: false;

                           cmd.Parameters.Add(new SqlParameter("ErrorString",SqlDbType.NText));
                           cmd.Parameters["ErrorString"].Value =  result.ErrorString ?? String.Empty;
                           cmd.Parameters.Add(new SqlParameter("RunTime", result.RunTime));
                           cmd.Parameters.Add(new SqlParameter("Servity", SqlDbType.VarChar, 10));
                           cmd.Parameters["Servity"].Value = sev ;
                           cmd.Parameters.Add(new SqlParameter("Location", SqlDbType.VarChar, 100));
                           cmd.Parameters["Location"].Value = result.Location ?? String.Empty;
                           cmd.Parameters.Add(new SqlParameter("Variable", SqlDbType.VarChar, 100));
                            cmd.Parameters["Variable"].Value =result.Variable ?? String.Empty;
                           cmd.Parameters.Add(new SqlParameter("StartDate", SqlDbType.VarChar, 30));
                           cmd.Parameters["StartDate"].Value =result.StartDate ?? String.Empty;
                           cmd.Parameters.Add(new SqlParameter("EndDate", SqlDbType.VarChar, 30));
                           cmd.Parameters["EndDate"].Value = result.EndDate ?? String.Empty;
                           cmd.Parameters.Add(new SqlParameter("Endpoint", SqlDbType.VarChar, 255));
                           cmd.Parameters["Endpoint"].Value = result.Endpoint ?? String.Empty;
                           cmd.Parameters.Add(new SqlParameter("ExceptionMessage", SqlDbType.NText));
                           cmd.Parameters["ExceptionMessage"].Value =   result.ExceptionMessage ?? String.Empty;
                           cmd.ExecuteNonQuery();
                       } catch (Exception ex )
                       {
                           // log error
                       }
                   }
                   conn.Close();
               }
           }
           return;
       }

        
    }
}
