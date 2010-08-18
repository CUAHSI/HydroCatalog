using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cuahsi.Model.Base;
using Cuahsi.Model.OdCore.Shared;

namespace Cuahsi.Model.OdCore.Common
{
    public class GenericProvenance : BaseEntity
    {
        public virtual DateTime ActionDate { get; set; }

        /* This is a string. We may not always have the 
* have the Source Record in the catalog
         * */
        public virtual string ActionBy { get; set; }

        /// <summary>
        /// A code is a short string that might be used as a identify to a common action. Such as:
        /// <list type="bullet">
        /// <item>MIN</item>
        /// <item>MAX</item>
        ///  <item>FILTER(HiLow)</item>
        /// </list>
        /// </summary>
        public virtual String Code { get; set; }
        
        /// <summary>
        /// The rational is a brief description of the operation
        /// </summary>
        public virtual String Rational { get; set; }

        /// <summary>
        /// Longer details of the operation.
        /// </summary>
        public virtual String Details { get; set; }

        


    }
}