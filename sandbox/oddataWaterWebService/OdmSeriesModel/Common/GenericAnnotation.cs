using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cuahsi.Model.Base;
using Cuahsi.Model.OdCore.Shared;

namespace Cuahsi.Model.OdCore.Common
{
    public class GenericAnnotation : BaseEntity
    {

        public virtual DateTime ActionDate { get; set; }
        public virtual string ActionBy { get; set; }

        public virtual String Code { get; set; }

        public virtual Method Method { get; set; }
        
        public virtual String BriefDescription { get; set; }

        public virtual String Details { get; set; }

        


    }
}