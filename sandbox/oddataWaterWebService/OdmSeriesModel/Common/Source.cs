using System.Globalization;
using Cuahsi.Model.Base;

namespace Cuahsi.Model.OdCore.Shared
{
    public class Source : BaseEntity
    {

        public virtual string Organization { get; set; }

        public virtual string Description { get; set; }

        public virtual string Citation { get; set; }

        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentUICulture, "{0} - {1}", this.Organization, this.Description);
        }
    }
}