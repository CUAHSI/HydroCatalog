using System;
using System.Globalization;

namespace Cuahsi.Model.OdCore.Common
{
    public class VersionInfo
    {
        public virtual string CreatedByStaff { get; set; }
        public virtual string UpdatedByStaff { get; set; }
        public virtual DateTime? CreatedDateTime { get; set; }
        public virtual DateTime? UpdatedDateTime { get; set; }
    }
}