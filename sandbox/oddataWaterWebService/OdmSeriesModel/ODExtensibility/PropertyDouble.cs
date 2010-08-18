using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cuahsi.Model.OdExtensibility
{
    public class PropertyDouble : PropertyGeneric
    {
        public PropertyDouble()
        {
            Class = "double";
        }

        public virtual double DoubleValue { get;  set; }

        public new virtual  void SetValue(object aDouble)
        {
          if (aDouble == null) return;

            if (typeof(double).Equals(aDouble))
            {
                DoubleValue = (int)aDouble;
                return;
            }
            try {
                DoubleValue = Convert.ToDouble(aDouble);
              }  
            catch (Exception e)
            {
                throw new ArgumentException("Cannot Convert Object to double", "aDouble", e);
            }
        }

        public new virtual object GetValue()
        {
            return DoubleValue;
        }

        public override string ToString()
        {
            return DoubleValue.ToString();
        }
    }
}
