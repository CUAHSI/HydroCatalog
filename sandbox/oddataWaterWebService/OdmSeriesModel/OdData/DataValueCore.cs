using System;
using System.Collections.Generic;
using Cuahsi.Model.Base;
using Cuahsi.Model.OdCore.Series;

namespace Cuahsi.Model.OdData
{
    public class DataValueCore : BaseEntity
    {
        private  DateTimeOffset _dateTimeObs;

        /* in order to make this work, we need to be able to 
         * set the DateTime. DateTimeUtc and UtcOffset will not
         * be populated at the same time when loaded from the DB,
         * so we create a third to hold state. When both have been loaded, we can load 
         * the DateTimeOffset.
         * */
        private TimeSpan _dateTimeOffset;
        private DateTime _dateTimeUtc;
        // true when one has been set, and the second one has not
        private bool _dateTimeSetterState = false;


        public DataValueCore()
        {

        }
        /// <summary>
        /// Make a copy, new value no id.
        /// </summary>

        /// <param name="dv"></param>
        public DataValueCore(DataValueCore dv)
        {
            this.Qualifiers = dv.Qualifiers;
            this.Value = dv.Value;
            this.ValueAccuracy = dv.ValueAccuracy;

            this.DateTimeObs = dv.DateTimeObs;
            // this.DateTimeUtc = dv.DateTimeUtc;
            //this.UtcOffset = dv.UtcOffset;
        }

        ///// <summary>
        ///// Make a copy, new value no id.
        ///// </summary>
        ///// <param name="series"></param>
        ///// <param name="dv"></param>
        //public DataValueCore(SeriesCoreData series, DataValueCore dv)
        //{
        //    this.Series = series;
        //    this.Qualifiers = dv.Qualifiers;
        //    this.Value = dv.Value;
        //    this.ValueAccuracy = dv.ValueAccuracy;

        //    this.DateTimeObs = dv.DateTimeObs;
        //    // this.DateTimeUtc = dv.DateTimeUtc;
        //    //this.UtcOffset = dv.UtcOffset;
        //}

    //    public virtual SeriesCoreData Series { get; set; }

        public virtual double Value { get; set; }

        public virtual double? ValueAccuracy { get; set; }

        /* DateTimeOffset is only available in MSsql 2008.
         * So the original implementation using DateTimeOffset does not function
         * 
         * Replacing with a DateTimeUtc, and a TimeSpan
         * 
        //public virtual DateTimeOffset DateTimeObs { get; set; } 
         * 
         */
        public virtual DateTimeOffset DateTimeObs
        {
            get
            {
                return _dateTimeObs;
            }
            set
            {
                _dateTimeObs = value;
            }
        }

        protected internal virtual TimeSpan UtcOffset
        {
            get
            {
                return _dateTimeObs.Offset;
            }
             set
            {
                _dateTimeOffset = value;
                if (_dateTimeSetterState)
                {
                    var dt = DateTime.SpecifyKind(_dateTimeUtc, DateTimeKind.Unspecified);
                    DateTimeObs = new DateTimeOffset(dt, _dateTimeOffset);
                }
                _dateTimeSetterState = !_dateTimeSetterState;
            }
        }
        protected internal virtual DateTime DateTimeUtc
        {
            get
            {
                return _dateTimeObs.UtcDateTime;
            }
             set
            {
                _dateTimeUtc = value;
                if (_dateTimeSetterState)
                {
                    var dt = DateTime.SpecifyKind(_dateTimeUtc, DateTimeKind.Unspecified);
                    DateTimeObs = new DateTimeOffset(dt, _dateTimeOffset);
                }

                _dateTimeSetterState = !_dateTimeSetterState;
            }
        }



        // public virtual  string CensorCode { get; set; }

        public virtual IList<Qualifier> Qualifiers { get; set; }

        //    public virtual  Source Source { get; set; }

        //    public virtual Method Method { get; set; }

        //    public virtual  QualityControlLevel QualityControlLevel { get; set; }


        //      public virtual OffsetType OffsetType { get; set; }

        //    public virtual UnitValue VerticalOffset { get; set; }


        // public virtual Sample Sample { get; set; } // it's nullable


    }
}
