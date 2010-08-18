using System;
using System.Globalization;
using Cuahsi.Model.Base;

namespace Cuahsi.Model.OdCore.Common
{
    public class ControlledVocabulary : BaseEntity
    {
        public virtual string Name { get; set; }

        public virtual string Definition { get; set; }

        //  public virtual string ControlledVocabulary { get; set; }
        public virtual bool Equals(ControlledVocabulary cv)
        {
            if (cv == null) return false;
            if (GetType() != cv.GetType()) return false;
            if (this.Name.Equals(cv.Name, StringComparison.CurrentCultureIgnoreCase))
                return true;
            return false;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var ds = (ControlledVocabulary)obj;

            return Equals(ds);

        }
        public override int GetHashCode()
        {
            return (Name.GetHashCode() * 397) ^ GetType().GetHashCode();
        }
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentUICulture, "{0} - {1}", this.Name, this.Definition);
        }

    }
}