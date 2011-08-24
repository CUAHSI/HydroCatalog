﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServicesWebSite.services
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="hiscentral_logging")]
	public partial class MonitorDbDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public MonitorDbDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["hiscentral_loggingReader"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public MonitorDbDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MonitorDbDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MonitorDbDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MonitorDbDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<ServicesWebSite.services.monitors.LastServiceRecord> LastServiceRecords
		{
			get
			{
				return this.GetTable<ServicesWebSite.services.monitors.LastServiceRecord>();
			}
		}
		
		public System.Data.Linq.Table<ServicesWebSite.services.monitors.ServiceWorkingStat> ServiceWorkingStats
		{
			get
			{
				return this.GetTable<ServicesWebSite.services.monitors.ServiceWorkingStat>();
			}
		}
	}
}
namespace ServicesWebSite.services.monitors
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.LastServiceRecords")]
	public partial class LastServiceRecord
	{
		
		private System.Data.Linq.Binary _TimeChecked;
		
		private System.Guid _Identifier;
		
		private string _ServiceName;
		
		private string _MethodName;
		
		private System.Nullable<bool> _Working;
		
		private string _ErrorString;
		
		private System.Nullable<long> _RunTime;
		
		private string _Severity;
		
		private string _Location;
		
		private string _Variable;
		
		private string _StartDate;
		
		private string _EndDate;
		
		private string _Endpoint;
		
		private string _ExceptionMessage;
		
		private System.Nullable<System.DateTime> _TimeUpdated;
		
		public LastServiceRecord()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TimeChecked", AutoSync=AutoSync.Always, DbType="rowversion NOT NULL", CanBeNull=false, IsDbGenerated=true, IsVersion=true, UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary TimeChecked
		{
			get
			{
				return this._TimeChecked;
			}
			set
			{
				if ((this._TimeChecked != value))
				{
					this._TimeChecked = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Identifier", DbType="UniqueIdentifier NOT NULL", UpdateCheck=UpdateCheck.Never)]
		public System.Guid Identifier
		{
			get
			{
				return this._Identifier;
			}
			set
			{
				if ((this._Identifier != value))
				{
					this._Identifier = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ServiceName", DbType="NVarChar(50)", UpdateCheck=UpdateCheck.Never)]
		public string ServiceName
		{
			get
			{
				return this._ServiceName;
			}
			set
			{
				if ((this._ServiceName != value))
				{
					this._ServiceName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MethodName", DbType="NVarChar(50)", UpdateCheck=UpdateCheck.Never)]
		public string MethodName
		{
			get
			{
				return this._MethodName;
			}
			set
			{
				if ((this._MethodName != value))
				{
					this._MethodName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Working", DbType="Bit", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<bool> Working
		{
			get
			{
				return this._Working;
			}
			set
			{
				if ((this._Working != value))
				{
					this._Working = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ErrorString", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string ErrorString
		{
			get
			{
				return this._ErrorString;
			}
			set
			{
				if ((this._ErrorString != value))
				{
					this._ErrorString = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RunTime", DbType="BigInt", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<long> RunTime
		{
			get
			{
				return this._RunTime;
			}
			set
			{
				if ((this._RunTime != value))
				{
					this._RunTime = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Severity", DbType="NVarChar(10)", UpdateCheck=UpdateCheck.Never)]
		public string Severity
		{
			get
			{
				return this._Severity;
			}
			set
			{
				if ((this._Severity != value))
				{
					this._Severity = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Location", DbType="NVarChar(100)", UpdateCheck=UpdateCheck.Never)]
		public string Location
		{
			get
			{
				return this._Location;
			}
			set
			{
				if ((this._Location != value))
				{
					this._Location = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Variable", DbType="NVarChar(100)", UpdateCheck=UpdateCheck.Never)]
		public string Variable
		{
			get
			{
				return this._Variable;
			}
			set
			{
				if ((this._Variable != value))
				{
					this._Variable = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StartDate", DbType="NVarChar(30)", UpdateCheck=UpdateCheck.Never)]
		public string StartDate
		{
			get
			{
				return this._StartDate;
			}
			set
			{
				if ((this._StartDate != value))
				{
					this._StartDate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EndDate", DbType="NVarChar(30)", UpdateCheck=UpdateCheck.Never)]
		public string EndDate
		{
			get
			{
				return this._EndDate;
			}
			set
			{
				if ((this._EndDate != value))
				{
					this._EndDate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Endpoint", DbType="NVarChar(255)", UpdateCheck=UpdateCheck.Never)]
		public string Endpoint
		{
			get
			{
				return this._Endpoint;
			}
			set
			{
				if ((this._Endpoint != value))
				{
					this._Endpoint = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ExceptionMessage", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string ExceptionMessage
		{
			get
			{
				return this._ExceptionMessage;
			}
			set
			{
				if ((this._ExceptionMessage != value))
				{
					this._ExceptionMessage = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TimeUpdated", DbType="DateTime", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<System.DateTime> TimeUpdated
		{
			get
			{
				return this._TimeUpdated;
			}
			set
			{
				if ((this._TimeUpdated != value))
				{
					this._TimeUpdated = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ServiceWorkingStats")]
	public partial class ServiceWorkingStat
	{
		
		private string _ServiceName;
		
		private string _MethodName;
		
		private System.Nullable<int> _TotalTests;
		
		private System.Nullable<int> _WorkingTests;
		
		private System.Nullable<int> _FailedTests;
		
		public ServiceWorkingStat()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ServiceName", DbType="NVarChar(50)")]
		public string ServiceName
		{
			get
			{
				return this._ServiceName;
			}
			set
			{
				if ((this._ServiceName != value))
				{
					this._ServiceName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MethodName", DbType="NVarChar(50)")]
		public string MethodName
		{
			get
			{
				return this._MethodName;
			}
			set
			{
				if ((this._MethodName != value))
				{
					this._MethodName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TotalTests", DbType="Int")]
		public System.Nullable<int> TotalTests
		{
			get
			{
				return this._TotalTests;
			}
			set
			{
				if ((this._TotalTests != value))
				{
					this._TotalTests = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WorkingTests", DbType="Int")]
		public System.Nullable<int> WorkingTests
		{
			get
			{
				return this._WorkingTests;
			}
			set
			{
				if ((this._WorkingTests != value))
				{
					this._WorkingTests = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FailedTests", DbType="Int")]
		public System.Nullable<int> FailedTests
		{
			get
			{
				return this._FailedTests;
			}
			set
			{
				if ((this._FailedTests != value))
				{
					this._FailedTests = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
