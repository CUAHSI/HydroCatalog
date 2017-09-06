﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace cuahsi.his.ogc
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="hiscentral")]
	public partial class ObservationsMetadataDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public ObservationsMetadataDataContext() : 
				base(global::cuahsi.his.ogc.Properties.Settings.Default.hiscentralConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ObservationsMetadataDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ObservationsMetadataDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ObservationsMetadataDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ObservationsMetadataDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<ObservationsSeriesMetadata> ObservationsSeriesMetadatas
		{
			get
			{
				return this.GetTable<ObservationsSeriesMetadata>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.v_ObservationsDataTextGeom")]
	public partial class ObservationsSeriesMetadata
	{
		
		private string _ServCode;
		
		private string _SiteCode;
		
		private string _SiteName;
		
		private string _VarCode;
		
		private string _VarName;
		
		private string _VarUnits;
		
		private string _Vocabulary;
		
		private string _Ontology;
		
		private string _Concept;
		
		private System.Nullable<int> _Valuecount;
		
		private System.Nullable<System.DateTime> _StartDate;
		
		private System.Nullable<System.DateTime> _EndDate;
		
		private System.Nullable<double> _Latitude;
		
		private System.Nullable<double> _Longitude;
		
		private System.Nullable<bool> _IsRegular;
		
		private string _TimeUnits;
		
		private System.Nullable<int> _TimeStep;
		
		private string _DataType;
		
		private string _Medium;
		
		private System.Nullable<int> _MethodID;
		
		private string _Method;
		
		private System.Nullable<int> _QCLevelID;
		
		private string _QCLevel;
		
		private System.Nullable<int> _SourceID;
		
		private string _SourceName;
		
		private string _LocType;
		
		private string _ServType;
		
		private System.Nullable<double> _XLL;
		
		private System.Nullable<double> _YLL;
		
		private System.Nullable<double> _XUR;
		
		private System.Nullable<double> _YUR;
		
		private string _Location;
		
		private string _Variable;
		
		private int _ReqsAuth;
		
		private string _WofVersion;
		
		private string _WaterMLURI;
		
		private string _WFSURI;
		
		private string _WMSURI;
		
		private string _DAccessURI;
		
		private string _StateName;
		
		private string _Geometry;
		
		private string _RecordType;
		
		private System.Nullable<int> _OrgHier;
		
		private string _SerStatus;
		
		private System.Nullable<System.DateTime> _LastUpdate;
		
		public ObservationsSeriesMetadata()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ServCode", DbType="NVarChar(255)")]
		public string ServCode
		{
			get
			{
				return this._ServCode;
			}
			set
			{
				if ((this._ServCode != value))
				{
					this._ServCode = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SiteCode", DbType="VarChar(101)")]
		public string SiteCode
		{
			get
			{
				return this._SiteCode;
			}
			set
			{
				if ((this._SiteCode != value))
				{
					this._SiteCode = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SiteName", DbType="VarChar(200)")]
		public string SiteName
		{
			get
			{
				return this._SiteName;
			}
			set
			{
				if ((this._SiteName != value))
				{
					this._SiteName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_VarCode", DbType="NVarChar(100)")]
		public string VarCode
		{
			get
			{
				return this._VarCode;
			}
			set
			{
				if ((this._VarCode != value))
				{
					this._VarCode = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_VarName", DbType="VarChar(200)")]
		public string VarName
		{
			get
			{
				return this._VarName;
			}
			set
			{
				if ((this._VarName != value))
				{
					this._VarName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_VarUnits", DbType="NVarChar(255)")]
		public string VarUnits
		{
			get
			{
				return this._VarUnits;
			}
			set
			{
				if ((this._VarUnits != value))
				{
					this._VarUnits = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Vocabulary", DbType="NVarChar(255)")]
		public string Vocabulary
		{
			get
			{
				return this._Vocabulary;
			}
			set
			{
				if ((this._Vocabulary != value))
				{
					this._Vocabulary = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ontology", DbType="VarChar(12) NOT NULL", CanBeNull=false)]
		public string Ontology
		{
			get
			{
				return this._Ontology;
			}
			set
			{
				if ((this._Ontology != value))
				{
					this._Ontology = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Concept", DbType="NVarChar(250)")]
		public string Concept
		{
			get
			{
				return this._Concept;
			}
			set
			{
				if ((this._Concept != value))
				{
					this._Concept = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Valuecount", DbType="Int")]
		public System.Nullable<int> Valuecount
		{
			get
			{
				return this._Valuecount;
			}
			set
			{
				if ((this._Valuecount != value))
				{
					this._Valuecount = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StartDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> StartDate
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EndDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> EndDate
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Latitude", DbType="Float")]
		public System.Nullable<double> Latitude
		{
			get
			{
				return this._Latitude;
			}
			set
			{
				if ((this._Latitude != value))
				{
					this._Latitude = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Longitude", DbType="Float")]
		public System.Nullable<double> Longitude
		{
			get
			{
				return this._Longitude;
			}
			set
			{
				if ((this._Longitude != value))
				{
					this._Longitude = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsRegular", DbType="Bit")]
		public System.Nullable<bool> IsRegular
		{
			get
			{
				return this._IsRegular;
			}
			set
			{
				if ((this._IsRegular != value))
				{
					this._IsRegular = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TimeUnits", DbType="NVarChar(255)")]
		public string TimeUnits
		{
			get
			{
				return this._TimeUnits;
			}
			set
			{
				if ((this._TimeUnits != value))
				{
					this._TimeUnits = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TimeStep", DbType="Int")]
		public System.Nullable<int> TimeStep
		{
			get
			{
				return this._TimeStep;
			}
			set
			{
				if ((this._TimeStep != value))
				{
					this._TimeStep = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DataType", DbType="NVarChar(50)")]
		public string DataType
		{
			get
			{
				return this._DataType;
			}
			set
			{
				if ((this._DataType != value))
				{
					this._DataType = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Medium", DbType="VarChar(100)")]
		public string Medium
		{
			get
			{
				return this._Medium;
			}
			set
			{
				if ((this._Medium != value))
				{
					this._Medium = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MethodID", DbType="Int")]
		public System.Nullable<int> MethodID
		{
			get
			{
				return this._MethodID;
			}
			set
			{
				if ((this._MethodID != value))
				{
					this._MethodID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Method", DbType="NVarChar(255)")]
		public string Method
		{
			get
			{
				return this._Method;
			}
			set
			{
				if ((this._Method != value))
				{
					this._Method = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_QCLevelID", DbType="Int")]
		public System.Nullable<int> QCLevelID
		{
			get
			{
				return this._QCLevelID;
			}
			set
			{
				if ((this._QCLevelID != value))
				{
					this._QCLevelID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_QCLevel", DbType="NVarChar(255)")]
		public string QCLevel
		{
			get
			{
				return this._QCLevel;
			}
			set
			{
				if ((this._QCLevel != value))
				{
					this._QCLevel = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SourceID", DbType="Int")]
		public System.Nullable<int> SourceID
		{
			get
			{
				return this._SourceID;
			}
			set
			{
				if ((this._SourceID != value))
				{
					this._SourceID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SourceName", DbType="NVarChar(255)")]
		public string SourceName
		{
			get
			{
				return this._SourceName;
			}
			set
			{
				if ((this._SourceName != value))
				{
					this._SourceName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LocType", DbType="VarChar(8) NOT NULL", CanBeNull=false)]
		public string LocType
		{
			get
			{
				return this._LocType;
			}
			set
			{
				if ((this._LocType != value))
				{
					this._LocType = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ServType", DbType="VarChar(4) NOT NULL", CanBeNull=false)]
		public string ServType
		{
			get
			{
				return this._ServType;
			}
			set
			{
				if ((this._ServType != value))
				{
					this._ServType = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_XLL", DbType="Float")]
		public System.Nullable<double> XLL
		{
			get
			{
				return this._XLL;
			}
			set
			{
				if ((this._XLL != value))
				{
					this._XLL = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_YLL", DbType="Float")]
		public System.Nullable<double> YLL
		{
			get
			{
				return this._YLL;
			}
			set
			{
				if ((this._YLL != value))
				{
					this._YLL = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_XUR", DbType="Float")]
		public System.Nullable<double> XUR
		{
			get
			{
				return this._XUR;
			}
			set
			{
				if ((this._XUR != value))
				{
					this._XUR = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_YUR", DbType="Float")]
		public System.Nullable<double> YUR
		{
			get
			{
				return this._YUR;
			}
			set
			{
				if ((this._YUR != value))
				{
					this._YUR = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Location", DbType="NVarChar(357)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Variable", DbType="NVarChar(356)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ReqsAuth", DbType="Int NOT NULL")]
		public int ReqsAuth
		{
			get
			{
				return this._ReqsAuth;
			}
			set
			{
				if ((this._ReqsAuth != value))
				{
					this._ReqsAuth = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WofVersion", DbType="VarChar(3) NOT NULL", CanBeNull=false)]
		public string WofVersion
		{
			get
			{
				return this._WofVersion;
			}
			set
			{
				if ((this._WofVersion != value))
				{
					this._WofVersion = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WaterMLURI", DbType="NVarChar(255)")]
		public string WaterMLURI
		{
			get
			{
				return this._WaterMLURI;
			}
			set
			{
				if ((this._WaterMLURI != value))
				{
					this._WaterMLURI = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WFSURI", DbType="NVarChar(255)")]
		public string WFSURI
		{
			get
			{
				return this._WFSURI;
			}
			set
			{
				if ((this._WFSURI != value))
				{
					this._WFSURI = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WMSURI", DbType="NVarChar(255)")]
		public string WMSURI
		{
			get
			{
				return this._WMSURI;
			}
			set
			{
				if ((this._WMSURI != value))
				{
					this._WMSURI = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DAccessURI", DbType="NVarChar(255)")]
		public string DAccessURI
		{
			get
			{
				return this._DAccessURI;
			}
			set
			{
				if ((this._DAccessURI != value))
				{
					this._DAccessURI = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StateName", DbType="VarChar(120)")]
		public string StateName
		{
			get
			{
				return this._StateName;
			}
			set
			{
				if ((this._StateName != value))
				{
					this._StateName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Geometry", DbType="NVarChar(MAX)")]
		public string Geometry
		{
			get
			{
				return this._Geometry;
			}
			set
			{
				if ((this._Geometry != value))
				{
					this._Geometry = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RecordType", DbType="VarChar(15) NOT NULL", CanBeNull=false)]
		public string RecordType
		{
			get
			{
				return this._RecordType;
			}
			set
			{
				if ((this._RecordType != value))
				{
					this._RecordType = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OrgHier", DbType="Int")]
		public System.Nullable<int> OrgHier
		{
			get
			{
				return this._OrgHier;
			}
			set
			{
				if ((this._OrgHier != value))
				{
					this._OrgHier = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SerStatus", DbType="VarChar(6) NOT NULL", CanBeNull=false)]
		public string SerStatus
		{
			get
			{
				return this._SerStatus;
			}
			set
			{
				if ((this._SerStatus != value))
				{
					this._SerStatus = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastUpdate", DbType="DateTime")]
		public System.Nullable<System.DateTime> LastUpdate
		{
			get
			{
				return this._LastUpdate;
			}
			set
			{
				if ((this._LastUpdate != value))
				{
					this._LastUpdate = value;
				}
			}
		}
	}
}
#pragma warning restore 1591