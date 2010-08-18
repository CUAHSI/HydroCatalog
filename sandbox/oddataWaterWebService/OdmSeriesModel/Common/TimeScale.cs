using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cuahsi.Model.Base;

namespace Cuahsi.Model.OdCore.Shared
{
    public class TimeScale : BaseEntity
    {
        public TimeScale()
        {
            IsRegular = true;
           
        }

        public virtual Boolean IsRegular { get;  set; }

       
       // public virtual int? TimeSupport { get; set; }
        //public virtual Unit TimeSupportUnit { get; set; }

        /* many series will be using the same values, 
        * eg
        * 1 day
        * 15 minutes
        * this normalizes the model, a bit
 */
        //public virtual UnitValue ObservationSpacing { get; set; } 
        public virtual ObservationalSpacing ObservationSpacing { get; set; } 

    }
}