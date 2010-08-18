using System;
using System.Collections.Generic;
using System.Linq;
using Cuahsi.Model.Base;
using Cuahsi.Model.compatibility.Odm;
using Cuahsi.Model.OdCore.Shared;
using Cuahsi.Model.OdData;

namespace Sdsc.Odm.SeriesModel.OdData
{
    public class DataValueOdm : DataValueCore
    {

        public DataValueOdm()
        {

        }

        public DataValueOdm(SeriesOdm seriesOdm)
        {
            Series = seriesOdm;

        }
        /// <summary>
        /// Copy a value to a new series.
        /// </summary>
        /// <param name="seriesOdm"></param>
        /// <param name="dv"></param>
        public DataValueOdm(SeriesOdm seriesOdm,DataValueOdm dv )
        {
            Series = seriesOdm;
            this.CensorCode = dv.CensorCode;
            this.OffsetType = dv.OffsetType;
            this.Sample = dv.Sample;
            //this.DateTimeUtc = dv.DateTimeUtc;
            //this.UtcOffset = dv.UtcOffset;
            this.DateTimeObs = dv.DateTimeObs;
            this.Qualifiers = dv.Qualifiers;
            this.Sample = dv.Sample;
            this.Value = dv.Value;
            this.ValueAccuracy = dv.ValueAccuracy;
            this.VerticalOffset = dv.VerticalOffset;
        }

        public new virtual SeriesOdm Series { get; set; }

        public virtual CensorCodeCv CensorCode { get; set; }

        public virtual OffsetType OffsetType { get; set; }

        public virtual UnitValue VerticalOffset { get; set; }

        public virtual Sample Sample { get; set; } // it's nullable

        public new virtual  bool IsValid
        {
            get { return (GetRuleViolations().Count() == 0); }
        }

        public new virtual IEnumerable<RuleViolation> GetRuleViolations()
        {
            base.GetRuleViolations();

            if (DateTimeUtc == new DateTime())
                yield return new RuleViolation("DateTimeUtc is default DateTimeUtc. Which means it most likely has not been set", "DateTimeUtc");
           
            if (UtcOffset == new TimeSpan())
                yield return new RuleViolation("UtcOffset is default UtcOffset. Which means it most likely has not been set", "UtcOffset");

            if (Series == null)
            {
                yield return new RuleViolation(
                    "SeriesOdm cannot be null. A datavalue is associated with a series.",
                    "SeriesOdm");
            }
            else
            {
                Series.GetRuleViolations();
            }

            #region     ODM Specific Constraints for all data values

 
            if (CensorCode == null)
            {
                yield return new RuleViolation("CensorCode cannot be null for an ODM Datavalue.",
                                               "CensorCode");
            }


            #endregion     ODM Specific Constraints for all data values

            #region OffsetTypeContrains
            if (VerticalOffset != null)
            {
                if (OffsetType == null)
                {
                    yield return new RuleViolation("OffsetType cannot be null when a datavalue has a vertical offset specified.",
                                                   "OffsetType");
                }
            }
            #endregion

            yield break;
        }


    }
}