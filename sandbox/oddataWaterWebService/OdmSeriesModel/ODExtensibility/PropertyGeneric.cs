using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cuahsi.Model.Base;

namespace Cuahsi.Model.OdExtensibility
{
    public class PropertyGeneric : BaseEntity
    {

        public virtual string Name{ get; set; }

        public virtual string Uri { get; set; }

        public virtual string Class { get; protected  internal set; }

        public PropertyGeneric()
        {
            Class = "Generic";
        }

        public virtual void SetValue(object value) { }

        public virtual object GetValue()
        {
            return null; }

        public override string ToString()
        {  
               return "Null";
        }
    }
}
