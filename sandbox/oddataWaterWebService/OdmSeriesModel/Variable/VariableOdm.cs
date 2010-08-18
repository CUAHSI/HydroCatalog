using System;
using System.Collections.Generic;
using System.Globalization;
using Cuahsi.Model.Base;
using Cuahsi.Model.OdCore.Common;
using Cuahsi.Model.OdCore.Series;
using Cuahsi.Model.OdCore.Shared;
using Cuahsi.Model.OdCore.Variable;


namespace Cuahsi.Model.compatibility.Odm
{
    /// <summary>
    ///  Full descriptive information about a variable
    /// </summary>
    /// <remarks>Time Units and Time Support have been moved to the SeriesOdm Record. <see cref="SeriesRecord"/>
    /// NoDataValue is associated with derived classes</remarks>
    public class VariableOdm : Cuahsi.Model.OdCore.Variable.ObservedVariable
    {
        public VariableOdm()
        {
            
        }
        /// <summary>
        /// VariableOdm Object from from a previous variableOdm
        /// </summary>
        /// <param name="variableOdm">ObservedVariable to duplicate</param>
        public VariableOdm(VariableOdm variableOdm)
        {
            this.Id = variableOdm.Id;
            this.DataService = variableOdm.DataService; 
            this.Code = variableOdm.Code;
            this.Name = variableOdm.Name;
            //this.Unit = variableOdm.Unit;
            this.Speciation = variableOdm.Speciation;
            this.GeneralCategory = variableOdm.GeneralCategory;
           // this.DataType = variableOdm.DataType;
            this.ValueType = variableOdm.ValueType;
            this.SampleMedium = variableOdm.SampleMedium;
            this.VariableProperties = variableOdm.VariableProperties;
            this.IsRegular = variableOdm.IsRegular;
            this.NoDataValue = variableOdm.NoDataValue;
            this.TimeSupport = variableOdm.TimeSupport;
        }

        /// <summary>
        /// VariableOdm Object from from a previous observedVariable
        /// </summary>
        /// <param name="observedVariable">VariableOdm to duplicate</param>
        public VariableOdm(Cuahsi.Model.OdCore.Variable.ObservedVariable observedVariable)
        {
            this.Id = observedVariable.Id;
            this.DataService = observedVariable.DataService; 
            this.Code = observedVariable.Code;
            this.Name = observedVariable.Name;
          //  this.Unit = observedVariable.Unit;
            this.Speciation = observedVariable.Speciation;
            this.GeneralCategory = observedVariable.GeneralCategory;
          //  this.DataType = observedVariable.DataType;
            this.ValueType = observedVariable.ValueType;
            this.SampleMedium = observedVariable.SampleMedium;
            this.VariableProperties = observedVariable.VariableProperties;
            
            //this.IsRegular = observedVariable.IsRegular;
            //this.NoDataValue = observedVariable.NoDataValue;
            //this.TimeScale = new UnitValue<double>(observedVariable.TimeScale);
        }

        //this.IsRegular = variable.IsRegular;
        public virtual bool IsRegular { get; set; }
        //this.NoDataValue = variable.NoDataValue;
        public virtual float NoDataValue { get; set; }
        //this.TimeScale = new UnitValue<double>(variable.TimeScale);
        public virtual float TimeSupport { get; set; }
    }
}