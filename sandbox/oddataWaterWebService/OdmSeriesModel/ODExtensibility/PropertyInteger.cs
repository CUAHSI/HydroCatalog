using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cuahsi.Model.OdExtensibility
{
    public class PropertyInteger : PropertyGeneric
    {
        public PropertyInteger()
        {
            Class = "int";
        }

        public virtual int IntValue { get;  set; }

        public new virtual  void SetValue(object anInt)
        {
          if (anInt == null) return;

            if (typeof(int).Equals(anInt))
            {
                IntValue = (int)anInt;
                return;
            }
            try {
                IntValue = Convert.ToInt32(anInt);
              }  
            catch (Exception e)
            {
                throw new ArgumentException("Cannot Convert Object to int", "anInt", e);
            }
        }

        public new virtual object GetValue()
        {
            return IntValue;
        }

        public override string ToString()
        {
            return IntValue.ToString();
        }
    }
}
