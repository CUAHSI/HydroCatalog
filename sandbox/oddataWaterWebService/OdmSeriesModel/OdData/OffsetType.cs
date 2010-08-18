using Cuahsi.Model.Base;
using Cuahsi.Model.OdCore.Shared;

namespace Cuahsi.Model.OdData
{
    public class OffsetType : BaseEntity
    {

        public virtual string Description { get; set; }

        public virtual Unit Unit { get; set; }
    }
}
