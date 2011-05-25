using System;
using System.Collections.Generic;
using System.Configuration;
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
                       cmd.Parameters.Clear();
                       cmd.Parameters.Add(new SqlParameter("Identifier", result.Identifier));
                       cmd.Parameters.Add(new SqlParameter("ServiceName", result.ServiceName ?? String.Empty ) );
                       cmd.Parameters.Add(new SqlParameter("MethodName", result.MethodName ?? String.Empty));
                       cmd.Parameters.Add(new SqlParameter("Working", result.Working));
                       cmd.Parameters.Add(new SqlParameter("ErrorString", result.ErrorString ?? String.Empty));
                       cmd.Parameters.Add(new SqlParameter("RunTime", result.RunTime));
                       cmd.Parameters.Add(new SqlParameter("Servity",Enum.GetName(typeof(AlarmSeverity),result.Serverity) ));
                       cmd.Parameters.Add(new SqlParameter("Location", result.Location ?? String.Empty));
                       cmd.Parameters.Add(new SqlParameter("Variable", result.Variable ?? String.Empty));
                       cmd.Parameters.Add(new SqlParameter("StartDate", result.StartDate ?? String.Empty));
                       cmd.Parameters.Add(new SqlParameter("EndDate", result.EndDate ?? String.Empty));
                       cmd.Parameters.Add(new SqlParameter("Endpoint", result.Endpoint ?? String.Empty));
                       cmd.Parameters.Add(new SqlParameter("ExceptionMessage", result.ExceptionMessage ?? String.Empty));
                       cmd.ExecuteNonQuery();
                   }
                   conn.Close();
               }
           }
           return;
       }

        
    }
}
