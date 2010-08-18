using System;
using System.Collections.Generic;
using System.Linq;
using Cuahsi.Model.Base;
using Cuahsi.Model.OdCore.Common;
using Cuahsi.Model.OdCore.Shared;
using Cuahsi.Model.OdExtensibility;


namespace Cuahsi.Model.OdCore.Series
{
    /// <summary>
    /// SeriesRecord contains only the core series information. 
    /// 
    /// </summary>
    /// <remarks>Extend this class to add additional Data Values. See SeriesOdm for an example </remarks>
    public class SeriesRecord : BaseEntity
    {
        private DateTimeOffset _beginDateTimeSeries;
        private TimeSpan _beginDateTimeOffset;
        private DateTime _beginDateTimeUtc;
        private bool _beginDateTimeSetterState = false;
        private DateTimeOffset _endDateTimeSeries;
        private TimeSpan _endDateTimeOffset;
        private DateTime _endDateTimeUtc;
        private bool _endDateTimeSetterState = false;
        private bool _deleted = false;

        public virtual Guid GlobalIdentifier { get; set; }
        public virtual DataServiceCode DataService { get; set; }
        public virtual Site.Site Site { get; set; }
        public virtual Variable.ObservedVariable ObservedVariable { get; set; }
        public virtual IList<QualityControlLevel> QualityControlLevels { get; set; }
        public virtual IList<Method> Methods { get; set; }
        public virtual Int64 ValueCount { get; set; }
        /* DateTimeOffset is only implemented in SQL Server 2008
         * Split into to pieces, dateTime, and DateTimeOffset
         * And Really only need one offset
         * */
        public virtual DateTimeOffset BeginDateTime
        {
            get
            {
                return _beginDateTimeSeries;
            }
            set
            {
                _beginDateTimeSeries = value;
            }
        }
        public virtual DateTimeOffset EndDateTime
        {
            get
            {
                return _endDateTimeSeries;
            }
            set
            {
                _endDateTimeSeries = value;
            }
        }

        protected internal virtual TimeSpan BeginUtcOffset
        {
            get
            {
                return _beginDateTimeSeries.Offset;
            }
            set
            {
                _beginDateTimeOffset = value;
                if (_beginDateTimeSetterState)
                {
                    var dt = DateTime.SpecifyKind(_beginDateTimeUtc, DateTimeKind.Unspecified);
                    BeginDateTime = new DateTimeOffset(dt, _beginDateTimeOffset);
                }
                _beginDateTimeSetterState = !_beginDateTimeSetterState;
            }
        }
        protected internal virtual TimeSpan EndUtcOffset
        {
            get
            {
                return _endDateTimeSeries.Offset;
            }
            set
            {
                _endDateTimeOffset = value;
                if (_endDateTimeSetterState)
                {
                    var dt = DateTime.SpecifyKind(_endDateTimeUtc, DateTimeKind.Unspecified);
                    EndDateTime = new DateTimeOffset(dt, _endDateTimeOffset);
                }
                _endDateTimeSetterState = !_endDateTimeSetterState;
            }
        }

        protected internal virtual DateTime BeginDateTimeUtc
        {
            get
            {
                return _beginDateTimeSeries.UtcDateTime;
            }
            set
            {
                _beginDateTimeUtc = value;
                if (_beginDateTimeSetterState)
                {
                    var dt = DateTime.SpecifyKind(_beginDateTimeUtc, DateTimeKind.Unspecified);
                    BeginDateTime = new DateTimeOffset(dt, _beginDateTimeOffset);
                }
                _beginDateTimeSetterState = !_beginDateTimeSetterState;
            }
        }

        protected internal virtual DateTime EndDateTimeUtc
        {
            get
            {
                return _endDateTimeSeries.UtcDateTime;
            }
            set
            {
                _endDateTimeUtc = value;
                if (_endDateTimeSetterState)
                {
                    var dt = DateTime.SpecifyKind(_endDateTimeUtc, DateTimeKind.Unspecified);
                    EndDateTime = new DateTimeOffset(dt, _endDateTimeOffset);
                }
                _endDateTimeSetterState = !_endDateTimeSetterState;
            }
        }

        public virtual IList<Source> Sources { get; set; }
        public virtual TimeScale Scale { get; set; }
        public virtual IList<PropertyGeneric> SharedSeriesProperties { get; set; }
        public virtual IList<PropertyGeneric> SeriesProperties { get; set; }
        public virtual IList<GenericProvenance> Provenance { get; set; }
     
        public virtual DateTime CreatedOn { get; set; }
        public virtual String CreatedBy { get; set; }
        public virtual DateTime LastUpdate { get; protected internal set; }
        public virtual DateTime LastChecked { get; protected internal set; }
        /// <summary>
        /// Deleted. Mark deleted, if series is not longer to be used
        /// </summary>
        /// <remarks>If during harvest, series is not found in list, it should be marked as deleted.</remarks>
        public virtual bool Deleted
        {
            get
            {
                return _deleted;
            }
            set
            {

                if (!(_deleted = value))
                {
                    _deleted = value;
                    SetLastUpdate();
                }

            }
        }

        public virtual void SetLastUpdate()
        {
            LastUpdate = DateTime.Now;
        }

        public virtual void SetLastChecked()
        {
            LastChecked = DateTime.Now;
        }

        //public virtual DateTimeOffset? BeginDateTimeOffset
        //{
        //    get
        //    {
        //        return _beginDateTimeOffset;
        //    }
        //    set
        //    {
        //        _beginDateTimeOffset = value;
        //        if (_beginDateTimeOffset.HasValue)
        //        {
        //            UtcOffset = _beginDateTimeOffset.Value.Offset;
        //        }
        //    }
        //}
        //public virtual DateTimeOffset? EndDateTimeOffset
        //{
        //    get
        //    {
        //        return _endDateTimeOffset;
        //    }
        //    set
        //    {
        //        _endDateTimeOffset = value;
        //        if (_endDateTimeOffset.HasValue)
        //        {

        //            if (!(_endDateTimeOffset.Value.Offset.Equals(TimeSpan.Zero)) && _beginDateTimeOffset.HasValue)
        //            {
        //                if (_endDateTimeOffset.Value.Offset.Subtract(_beginDateTimeOffset.Value.Offset)
        //                    > TimeSpan.FromHours(2))
        //                {
        //                    _endDateTimeOffset = new DateTimeOffset(_endDateTimeOffset.Value.DateTime, UtcOffset.Value);
        //                }
        //            }
        //        }
        //    }
        //}

        /* moved unit, TimeScale from Variable to Series
         * */
        public virtual Unit Unit { get; set; }
        // public virtual TimeScale TimeScale { get; set; }
        public virtual DataType DataType { get; set; }
        public virtual ObservationalSpacing ObservationSpacing { get; set; }

        public SeriesRecord()
        {
            GlobalIdentifier = Guid.NewGuid();
            SeriesProperties = new List<PropertyGeneric>();
            Provenance = new List<GenericProvenance>();

            Methods = new List<Method>();
            Sources = new List<Source>();
            QualityControlLevels = new List<QualityControlLevel>();

   

        }
        public new virtual bool IsValid
        {
            get { return (GetRuleViolations().Count() == 0); }
        }


        public new virtual IEnumerable<RuleViolation> GetRuleViolations()
        {
            if (Site == null)
            {
                yield return new RuleViolation("SeriesRecord: Site is required", "Site");
            }
            else
            {
                Site.GetRuleViolations();
            }

            if (ObservedVariable == null)
            {
                yield return new RuleViolation("SeriesRecord: ObservedVariable is required", "ObservedVariable");
            }
            else
            {
                ObservedVariable.GetRuleViolations();
            }

            if (GlobalIdentifier == null || GlobalIdentifier == Guid.Empty)
                yield return new RuleViolation("SeriesRecord: GlobalIdentifier is empty. Should have been set on creation", "GlobalIdentifier");

            if (DataService == null)
            {
                yield return new RuleViolation("SeriesRecord: DataService is required", "DataService");
            }
            else
            {
                DataService.GetRuleViolations();
            }

            if (Sources.Count == 0)
            {
                yield return new RuleViolation("SeriesRecord: One or more Sources is required", "Sources");
            }

            yield break;
        }

    }
}