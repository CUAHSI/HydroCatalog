using System;
using System.Collections.Generic;
using System.Globalization;
using Cuahsi.Model.Base;
using Cuahsi.Model.OdCore.Common;
using Cuahsi.Model.OdCore.Series;
using Cuahsi.Model.OdCore.Shared;
using Cuahsi.Model.OdExtensibility;

namespace Cuahsi.Model.OdCore.Variable
{
    /// <summary>
    ///  Full descriptive information about a variable
    /// </summary>
    /// <remarks>Time Units and Time Support have been moved to the SeriesOdm Record. <see cref="SeriesRecord"/>
    /// NoDataValue is associated with derived classes</remarks>
    public class ObservedVariable : BaseEntity
    {
        /// <summary>
        ///  VariableOdm Object
        /// </summary>
        public ObservedVariable()
        {
            GlobalIdentifier = Guid.NewGuid(); 
            VariableProperties = new List<PropertyGeneric>();
            AlternateVariableCodes = new List<GenericCode>();
        }

        /// <summary>
        /// VariableOdm Object from from a previous observedVariable
        /// </summary>
        /// <param name="observedVariable">VariableOdm to duplicate</param>
        public ObservedVariable(ObservedVariable observedVariable)
        {
            GlobalIdentifier = Guid.NewGuid(); 
            //this.Id = observedVariable.Id;
            this.DataService = observedVariable.DataService; 
            this.Code = observedVariable.Code;
            this.Name = observedVariable.Name;
          //  this.Unit = new Unit(observedVariable.Unit);
            this.Speciation = observedVariable.Speciation;
            this.GeneralCategory = observedVariable.GeneralCategory;
           // this.DataType = observedVariable.DataType;
            this.ValueType = observedVariable.ValueType;
            this.SampleMedium = observedVariable.SampleMedium;
            this.VariableProperties = observedVariable.VariableProperties;
            this.Description = observedVariable.Description;

            //this.IsRegular = observedVariable.IsRegular;
            //this.NoDataValue = observedVariable.NoDataValue;
            //this.TimeScale = new UnitValue<double>(observedVariable.TimeScale);
        }
        /// <summary>
        /// Unique identifier for each variable.
        /// </summary>
        public virtual Guid GlobalIdentifier { get; set; }

        /// <summary>
        /// Reference to Vocabulary of the organization that collects the data to identify the variable.
        /// </summary>
        public virtual DataServiceCode DataService { get; set; }

        /// <summary>
        /// Text code used by the organization that collects the data to identify the variable.
        /// </summary>
        public virtual string Code { get; set; }

        /// <summary>
        /// List of alternate codes. 
        /// Often an agency may recode.  This may be an equivalent code from a different data source.
        /// </summary>
        public virtual IList<GenericCode> AlternateVariableCodes { get; set; }

        /// <summary>
        /// Full text name of the variable that was measured, observed, modeled, etc
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Details of the variable that was measured, observed, modeled, etc
        /// </summary>
        public virtual string Description { get; set; }

        ///// <summary>
        ///// references the Units of the data values associated with the variable.
        ///// </summary>
        //public virtual Unit Unit { get; set; }

        /// <summary>
        /// Text code used to identify how the data value is expressed (i.e., total phosphorus concentration expressed as P).  
        /// This should be from the SpeciationCV controlled vocabulary table.
        /// </summary>
        public virtual SpeciationCv Speciation { get; set; }

        /// <summary>
        /// General category of the data values from the GeneralCategoryCV controlled vocabulary table.
        /// </summary>
        public virtual GeneralCategoryCv GeneralCategory { get; set; }

        ///// <summary>
        ///// Text value that identifies the data values as one of several types from the DataTypeCV controlled vocabulary table.
        ///// </summary>
        //public virtual DataTypeCv DataType { get; set; }

        /// <summary>
        /// Text value indicating what type of data value is being recorded.  This should be from the ValueTypeCV controlled vocabulary table.
        /// </summary>
        public virtual ValueTypeCv ValueType { get; set; }

        /// <summary>
        /// The medium in which the sample or observation was taken or made.  This should be from the SampleMediumCV controlled vocabulary table
        /// </summary>
        public virtual SampleMediaCv SampleMedium { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IList<PropertyGeneric> VariableProperties { get; set; }

        // Move these to series
        //       public virtual bool IsRegular { get; set; }
//        public virtual double NoDataValue { get; set; }
        //       public virtual UnitValue<double> TimeScale { get; set; }

        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentUICulture, "{0} - {1}", this.Code, this.Name);
        }

    }
}