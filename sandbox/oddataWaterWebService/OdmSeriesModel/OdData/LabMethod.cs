using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cuahsi.Model.Base;
using Cuahsi.Model.OdCore.Shared;

namespace Cuahsi.Model.OdData
{
    public class LabMethod : BaseEntity
    {

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        /// <summary>
        /// Link to page describing lab metho
        /// </summary>
        public virtual Uri WebLink { get; set; }

        public virtual Source LabInformation { get; set; }
    }
}
