using System.Globalization;
using Cuahsi.Model.Base;

namespace Cuahsi.Model.OdCore.Shared
{
    public class QualityControlLevel : BaseEntity
    {


        public virtual string Code { get; set; }

        public virtual string Name { get; set; }
        public virtual string Description { get; set;} 

        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentUICulture, "{0} - {1}", this.Code, this.Name);
        }
    }
}