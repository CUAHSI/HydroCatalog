using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//using Cuahsi.Model.ODExtensibility;

namespace Cuahsi.Model.OdExtensibility
{
    public class PropertyString : PropertyGeneric
    {
        public PropertyString()
        {
            Class = "string";
        }

        public virtual string StringValue { get;  set; }

        public new virtual  void SetValue(object aString)
        {
            if (aString == null) return;

            try {
                StringValue = Convert.ToString(aString);
            }  
            catch (Exception e)
            {
                throw new ArgumentException("Cannot Convert Object to string", "aString", e);
            }
        }

        public new virtual object GetValue()
        {
            return StringValue;
        }

        public override string ToString()
        {
            return StringValue;
        }
    }
}