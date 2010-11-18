#region Copyright & License
//
// Copyright 2001-2005 The Apache Software Foundation
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion

/* This needs to be modified to write out the N paramters 
from the Log4Net in the Cuahsi logger
*/

using System;
using System.Data;
using System.Data.SqlClient;
using log4net.Appender;
using log4net.Core;
using log4net.Util;

/* We will want to split the message, and only use probably the 
 * [%ndc]
 * 	 loggingEvent.TimeStamp;
	loggingEvent.RenderedMessage;
 * loggingEvent.GetProperties("HostName") //
 * 
	Catch by:
 * loggingEvent.LoggerName  must euqal QueryLog;
		= loggingEvent.Level.Name must equal Info
 */


namespace WaterOneFlowRemoteLogService.Appender
{
    /// <summary>
    /// Simple database appender
    /// </summary>
    /// <remarks>
    /// <para>
    /// This database appender is very simple and does not support a configurable
    /// data schema. The schema supported is hardcoded into the appender.
    /// Also by not extending the AppenderSkeleton base class this appender
    /// avoids the serializable locking that it enforces.
    /// </para>
    /// <para>
    /// This appender can be subclassed to change the database connection
    /// type, or the database schema supported.
    /// </para>
    /// <para>
    /// To change the database connection type the <see cref="GetConnection"/>
    /// method must be overridden.
    /// </para>
    /// <para>
    /// To change the database schema supported by the appender the <see cref="InitializeCommand"/>
    /// and <see cref="SetCommandValues"/> methods must be overridden.
    /// </para>
    /// </remarks>
    public class CuahsiLoggingDbAppender : IAppender, IBulkAppender, IOptionHandler
    // based on FastDbAppender IAppender, IBulkAppender, IOptionHandler
    {
        private string m_name;
        private string m_connectionString;

        public string Name // caseSensetive
        {
            get { return m_name; }
            set { m_name = value; }
        }

        public string ConnectionString // caseSensetive
        {
            get { return m_connectionString; }
            set { m_connectionString = value; }
        }

        public virtual void ActivateOptions()
        {
            /* We need to access ConnectionString in the Activate options
            to make the work
                */
            if (String.IsNullOrEmpty( m_connectionString))
            {
                LogLog.Error("Failed to find connectionString .");
            }
        }

        public virtual void Close()
        {
        }

        public virtual void DoAppend(LoggingEvent loggingEvent)
        {
            using (IDbConnection connection = GetConnection())
            {
                // Open the connection for each event, this takes advantage
                // of the builtin connection pooling
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    InitializeCommand(command);

                    SetCommandValues(command, loggingEvent);
                    command.ExecuteNonQuery();
                }
            }
        }

        public virtual void DoAppend(LoggingEvent[] loggingEvents)
        {
            using (IDbConnection connection = GetConnection())
            {
                // Open the connection for each event, this takes advantage
                // of the builtin connection pooling
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    InitializeCommand(command);

                    foreach (LoggingEvent loggingEvent in loggingEvents)
                    {
                        SetCommandValues(command, loggingEvent);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        /// <summary>
        /// Create the connection object
        /// </summary>
        /// <returns>the connection</returns>
        /// <remarks>
        /// <para>
        /// This implementation returns a <see cref="SqlConnection"/>.
        /// To change the connection subclass this appender and
        /// return a different connection type.
        /// </para>
        /// </remarks>
        virtual protected IDbConnection GetConnection()
        {
            return new SqlConnection(m_connectionString);
        }

        /// <summary>
        /// Initialize the command object supplied
        /// </summary>
        /// <param name="command">the command to initialize</param>
        /// <remarks>
        /// <para>
        /// This method must setup the database command and the
        /// parameters.
        /// </para>
        /// </remarks>
        virtual protected void InitializeCommand(IDbCommand command)
        {
            command.CommandType = CommandType.Text;
            //command.CommandText = "INSERT INTO [LogTable] ([Time],[Logger],[Level],[Thread],[Message]) VALUES (@Time,@Logger,@Level,@Thread,@Message)";
            command.CommandText = "INSERT INTO [Log11Service] " +
                                  " ([querytime],[machine],[network],[method],[location],[variable],[starttime],[endtime],[proctime],[reccount],[userhost])" +
                                  " VALUES ( @QueryTime,@Machine,@Network,@Method,@Location,@Variable,@StartTime,@EndTime,@ProcTime,@RecCount,@UserHost)";


            IDbDataParameter param = null;

            // @QueryTime
            param = command.CreateParameter();
            param.ParameterName = "@QueryTime";
            param.DbType = DbType.DateTime;
            command.Parameters.Add(param);

            // @Machine
            param = command.CreateParameter();
            param.ParameterName = "@Machine";
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            // @Network
            param = command.CreateParameter();
            param.ParameterName = "@Network";
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            // @Method
            param = command.CreateParameter();
            param.ParameterName = "@Method";
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            // @Location
            param = command.CreateParameter();
            param.ParameterName = "@Location";
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            // @Variable
            param = command.CreateParameter();
            param.ParameterName = "@Variable";
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            // @StartTime
            param = command.CreateParameter();
            param.ParameterName = "@StartTime";
            param.DbType = DbType.DateTimeOffset;
            command.Parameters.Add(param);

            // @EndTime
            param = command.CreateParameter();
            param.ParameterName = "@EndTime";
            param.DbType = DbType.DateTimeOffset;
            command.Parameters.Add(param);


            // @ProcTime
            param = command.CreateParameter();
            param.ParameterName = "@ProcTime";
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            // @RecCount
            param = command.CreateParameter();
            param.ParameterName = "@RecCount";
            param.DbType = DbType.Int64;
            command.Parameters.Add(param);

            // @UserHost
            param = command.CreateParameter();
            param.ParameterName = "@UserHost";
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            /*
			// @Time
			param = command.CreateParameter();
			param.ParameterName = "@Time";
			param.DbType = DbType.DateTime;
			command.Parameters.Add(param);
			
			// @Logger
			param = command.CreateParameter();
			param.ParameterName = "@Logger";
			param.DbType = DbType.String;
			command.Parameters.Add(param);
			
			// @Level
			param = command.CreateParameter();
			param.ParameterName = "@Level";
			param.DbType = DbType.String;
			command.Parameters.Add(param);
			
			// @Thread
			param = command.CreateParameter();
			param.ParameterName = "@Thread";
			param.DbType = DbType.String;
			command.Parameters.Add(param);
			
			
			// @Message
			param = command.CreateParameter();
			param.ParameterName = "@Message";
			param.DbType = DbType.String;
			command.Parameters.Add(param);
             */
        }

        /// <summary>
        /// Set the values for the command parameters
        /// </summary>
        /// <param name="command">the command to update</param>
        /// <param name="loggingEvent">the current logging event to retrieve the values from</param>
        /// <remarks>
        /// <para>
        /// Set the values of the parameters created by the
        /// <see cref="InitializeCommand"/> method.
        /// </para>
        /// </remarks>
        virtual protected void SetCommandValues(IDbCommand command, LoggingEvent loggingEvent)
        {
            /*((IDbDataParameter)command.Parameters["@Time"]).Value = loggingEvent.TimeStamp;
            ((IDbDataParameter)command.Parameters["@Logger"]).Value = loggingEvent.LoggerName;
            ((IDbDataParameter)command.Parameters["@Level"]).Value = loggingEvent.Level.Name;
            ((IDbDataParameter)command.Parameters["@Thread"]).Value = loggingEvent.ThreadName;
            ((IDbDataParameter)command.Parameters["@Message"]).Value = loggingEvent.RenderedMessage;
        */
            string logMessage = loggingEvent.RenderedMessage;
            var queryMessageV1 = new QueryMessageV1(loggingEvent);
            // string dtime = fields[0].Substring(0, fields[0].Length - 4);

            ((IDbDataParameter)command.Parameters["@QueryTime"]).Value = queryMessageV1.CallDateTime;
            
            ((IDbDataParameter)command.Parameters["@Machine"]).Value = queryMessageV1.HisServer;
           
            ((IDbDataParameter)command.Parameters["@Network"]).Value = queryMessageV1.Network;
            ((IDbDataParameter)command.Parameters["@Method"]).Value = queryMessageV1.Method;
            ((IDbDataParameter)command.Parameters["@Location"]).Value = queryMessageV1.Location;
            if (!String.IsNullOrEmpty(queryMessageV1.Variable))
            {
                ((IDbDataParameter)command.Parameters["@Variable"]).Value = queryMessageV1.Variable;
            }
            else
            {
                ((IDbDataParameter)command.Parameters["@Variable"]).Value = DBNull.Value;
            }
            if (!queryMessageV1.StartDateTime.HasValue)
            {
                ((IDbDataParameter)command.Parameters["@StartTime"]).Value = DBNull.Value;
            }
            else
            {
                ((IDbDataParameter)command.Parameters["@StartTime"]).Value = queryMessageV1.StartDateTime.Value.DateTime;
            }
            if (!queryMessageV1.EndDateTime.HasValue)
            {
                ((IDbDataParameter)command.Parameters["@EndTime"]).Value = DBNull.Value;
            }
            else
            {
                ((IDbDataParameter)command.Parameters["@EndTime"]).Value = queryMessageV1.EndDateTime.Value.DateTime;
            }
            if (!queryMessageV1.ProcessingTime.HasValue)
            {
                ((IDbDataParameter)command.Parameters["@ProcTime"]).Value = DBNull.Value;
            }
            else
            {
                ((IDbDataParameter)command.Parameters["@ProcTime"]).Value = queryMessageV1.ProcessingTime.Value.Milliseconds;
            }
            if (!queryMessageV1.Count.HasValue)
            {
                ((IDbDataParameter)command.Parameters["@RecCount"]).Value = DBNull.Value;
            }
            else
            {
                ((IDbDataParameter)command.Parameters["@RecCount"]).Value = queryMessageV1.Count.Value;
            }
            ((IDbDataParameter)command.Parameters["@UserHost"]).Value = queryMessageV1.UserHostIp;

            // string[] fields = logMessage.Split('|');
            //string dtime = fields[0].Substring(0, fields[0].Length - 4);

            //((IDbDataParameter)command.Parameters["@QueryTime"]).Value = Convert.ToDateTime(dtime);
            //((IDbDataParameter)command.Parameters["@Machine"]).Value = fields[1];
            //((IDbDataParameter)command.Parameters["@Network"]).Value = fields[2];
            //((IDbDataParameter)command.Parameters["@Method"]).Value = fields[3];
            //((IDbDataParameter)command.Parameters["@Location"]).Value = fields[4];
            //((IDbDataParameter)command.Parameters["@Variable"]).Value = fields[5];
            //if (fields[6] == "")
            //{
            //    ((IDbDataParameter) command.Parameters["@StartTime"]).Value = DBNull.Value;
            //}
            //else
            //{
            //    ((IDbDataParameter) command.Parameters["@StartTime"]).Value = fields[6];
            //}
            //if (fields[7] == "")
            //{
            //    ((IDbDataParameter) command.Parameters["@EndTime"]).Value = DBNull.Value;
            //}
            //else
            //{
            //    ((IDbDataParameter) command.Parameters["@EndTime"]).Value = fields[7];
            //}
            //if (fields[8] == "")
            //{
            //    ((IDbDataParameter) command.Parameters["@ProcTime"]).Value = DBNull.Value;
            //}
            //else
            //{
            //    ((IDbDataParameter)command.Parameters["@ProcTime"]).Value = Convert.ToInt32(fields[8]);
            //}
            //if (fields[9] == "")
            //{
            //    ((IDbDataParameter) command.Parameters["@RecCount"]).Value = DBNull.Value;
            //}
            //else
            //{
            //    ((IDbDataParameter) command.Parameters["@RecCount"]).Value = Convert.ToInt64(fields[9]);
            //}
            //((IDbDataParameter)command.Parameters["@UserHost"]).Value = fields[10];




        }
    }
}
