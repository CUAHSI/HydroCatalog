using Cuahsi.Model.Base;

namespace Cuahsi.Model.OdCore.Shared
{
    public class UnitValue : BaseEntity
    {
        /* This was originally a class that utilized generics, and gave the 
         * NHibernate ORM, fits.
         * The goal is to store a unit with a value in a time period.
         * This will be often utlized (eg 15 minutes, 1 hour.
         * This is now a separate table
         * */
        public virtual Unit Unit     { get; set; }
        public virtual decimal Value { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitValue"/> class.
        /// </summary>
        public UnitValue()
            : base()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitValue"/> class.
        /// </summary>
        /// <param name="unit">The unit.</param>
        /// <param name="value">The value.</param>
        public UnitValue(Unit unit, decimal value)
            
        {
            this.Unit = unit;
            this.Value = value;
        }

        public UnitValue(UnitValue source)
            
        {
            this.Unit = source.Unit;
            this.Value = source.Value;
        }

       
    }
}