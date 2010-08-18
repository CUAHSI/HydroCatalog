using System;
using System.Collections.Generic;
using System.Linq;
using Cuahsi.Model.Base;
using Cuahsi.Model.OdCore.Series;
using Cuahsi.Model.OdCore.Shared;
using Cuahsi.Model.OdData;
using Sdsc.Odm.SeriesModel.OdData;

namespace Cuahsi.Model.compatibility.Odm
{
    public class SeriesOdm : SeriesRecord
    {

        public virtual double? NoDataValue { get; set; }
        /// <summary>
        /// List of Data Values with ODM Attributes as determined by Hydrodesktop.
        /// </summary>
        /// <remarks>Use AddDataValue, and AddDataValues to add values.</remarks>

        public  virtual IList<DataValueOdm> DataValues
        {
            get; protected internal set;
        } 

        public SeriesOdm()
        {
            DataValues = new List<DataValueOdm>();

        }
        public SeriesOdm(SeriesRecord s)
        {
            this.DataService = s.DataService;
            this.GlobalIdentifier = new Guid();

            this.Site = s.Site;
            this.ObservedVariable = s.ObservedVariable;
            this.Scale = s.Scale;
            this.ValueCount = s.ValueCount;
            this.SeriesProperties = s.SeriesProperties;

            this.Sources = s.Sources;
            this.Methods = s.Methods;
            this.QualityControlLevels = s.QualityControlLevels;

            this.BeginDateTime = s.BeginDateTime;
            this.EndDateTime = s.EndDateTime;
            //this.UtcOffset = s.UtcOffset;

            DataValues = new List<DataValueOdm>();
        }
        public SeriesOdm(SeriesOdm s)
        {
            this.DataService = s.DataService;
            this.GlobalIdentifier = s.GlobalIdentifier;
            this.Site = s.Site;
            this.ObservedVariable = s.ObservedVariable;
            this.Scale = s.Scale;
            this.ValueCount = s.ValueCount;
            this.SeriesProperties = s.SeriesProperties;

            this.Sources = s.Sources;
            this.Methods = s.Methods;
            this.QualityControlLevels = s.QualityControlLevels;

            this.BeginDateTime = s.BeginDateTime;
            this.EndDateTime = s.EndDateTime;
           // this.UtcOffset = s.UtcOffset;

            DataValues = s.DataValues;
        }

        public virtual void AddDataValue(DataValueOdm dv)
        {

            this.DataValues.Add(new DataValueOdm(this, dv));
        }
        public virtual void AddDataValues(IList<DataValueOdm> dv)
        {
            foreach (var dataValue in dv)
            {

                this.DataValues.Add(new DataValueOdm(this, dataValue));
            }

        }

        #region Courtesy methods
        public virtual Method Method
        {
            get {return Methods.Count > 0 ? Methods[0] : null;}
        }
        public virtual QualityControlLevel QualityControlLevel    
        {
            get { return QualityControlLevels.Count > 0 ? QualityControlLevels[0] : null; }
        }
        public virtual Source Source
        {
            get { return Sources.Count > 0 ? Sources[0] : null; }
        }
        #endregion

       
        /* tired to see if we could enforce the ODM spec in the class
         * eg One QualityControlLeve, one Method, One Prefix
         * Need to look at Nhibernate validator
         */
        //public virtual new  IList<QualityControlLevel> QualityControlLevels {  get; set;}
        //public virtual IList<Method> Methods { get; set; }
        //public virtual IList<Prefix> Sources { get; set; }

        public new virtual bool IsValid
        {
            get { return (GetRuleViolations().Count() == 0); }
        }

        public new virtual IEnumerable<RuleViolation> GetRuleViolations()
        {
            foreach (var violation in base.GetRuleViolations())
            {
                yield return violation;
            }

            if (Methods.Count != 1)
            {
                yield return new RuleViolation("SeriesOdm: One Method Only", "SeriesOdm.Method");
            }
            if (Sources.Count != 1)
            {
                yield return new RuleViolation("SeriesOdm: One Sources Only", "SeriesOdm.Sources");
            }
            if (QualityControlLevels.Count != 1)
            {
                yield return new RuleViolation("SeriesOdm: One QualityControlLevels Only", "SeriesOdm.QualityControlLevels");
            }
  
            if (Scale == null)
            {
                yield return new RuleViolation("SeriesOdm: Scale/TimeSupport information is required", "Scale");
            }
         
            /* SeriesOdm needs to add some methods to 
        * check the datavalues list and see:
        * * 1 Source
        * * 1 method
        * * 1 QC level
        * That all data values are valid
        * */


            yield break;
        }

    }
}