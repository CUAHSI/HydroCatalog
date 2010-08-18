using Cuahsi.Model.Base;

namespace Cuahsi.Model.OdCore.Shared
{
    public class Unit : BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Unit"/> class.
        /// </summary>
        public Unit()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Unit"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        public Unit(Unit source)
        {
            this.Id = source.Id;
            this.Name = source.Name;
            this.Type = source.Type;
            this.Abbreviation = source.Abbreviation;
        }

        public virtual string Name { get; set; }

        public virtual UnitTypeCv Type { get; set; }

        public virtual string Abbreviation { get; set; }

    }
}