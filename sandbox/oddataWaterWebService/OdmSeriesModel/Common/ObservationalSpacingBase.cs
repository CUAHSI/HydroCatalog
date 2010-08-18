using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cuahsi.Model.Base;

namespace Cuahsi.Model.OdCore.Shared
{
    public enum SpacingType
    {
        Unknown,
        Fixed,
        Variable
    }
    public class ObservationalSpacing : BaseEntity
    {
        public ObservationalSpacing()
        {
            SpacingType = SpacingType.Unknown;
            IsRegular = false;
        }


        public virtual SpacingType SpacingType { get; protected internal set; }

        public virtual bool IsRegular { get; set; }
        /// <summary>
        ///  The set or most often used spacing
        /// </summary>
        public virtual int ObservationSpacing { get; set; }
        public virtual Unit ObservationSpacingUnit { get; set; }


        public static ObservationalSpacing ObservationalSpacingUnknown()
        {
            return new ObservationalSpacing();
        }

    public static ObservationalSpacing ObservationalSpacingFixed()
    {
        return new ObservationalSpacing
                   {
                       SpacingType = SpacingType.Fixed,
                       IsRegular = true
                   };
    }
}
    public class ObservationalSpacingVariable : ObservationalSpacing
    {

        public ObservationalSpacingVariable()
        {
            SpacingType = SpacingType.Variable;
            IsRegular = true;
        }

        public virtual int ObservationSpacingMinimum { get; set; }
        public virtual int ObservationSpacingMaximum { get; set; }
    }

}
