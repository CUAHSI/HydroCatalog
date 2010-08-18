using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cuahsi.Model.Base;
using Cuahsi.Model.OdCore.Common;
using Cuahsi.Model.OdExtensibility;


namespace Cuahsi.Model.OdData
{
   public  class Instrument :BaseEntity
    {
       public virtual String Code { get; set; }
       public virtual String Name { get; set; }

       public virtual IList<PropertyGeneric> InstrumentProperties { get; set; }
       public virtual IList<GenericProvenance> InsturmentProvenance { get; set; }

       public Instrument()
       {
           InstrumentProperties = new List<PropertyGeneric>();
           InsturmentProvenance = new List<GenericProvenance>();
       }
    }
}
