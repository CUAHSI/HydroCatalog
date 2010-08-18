using Cuahsi.Model.Base;

namespace Cuahsi.Model.OdCore.Shared
{
    public class Method : BaseEntity
    {
        public virtual string Code { get; set;} 

        public virtual string Description { get; set; }

        public virtual string Link { get; set; }
    }
}