using System.Globalization;
using Cuahsi.Model.Base;
using Cuahsi.Model.OdCore;

namespace Cuahsi.Model.OdData
{
    public class Sample : BaseEntity
    {

        public virtual string LabSampleCode { get; set; }

        public virtual string LocalSampleCode { get; set; }

        public virtual SampleTypeCv Type { get; set; }

        public virtual LabMethod LabMethod { get; set; }

        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentUICulture, "{0} - {1}", this.LabSampleCode, this.Type);
        }
    }
}
