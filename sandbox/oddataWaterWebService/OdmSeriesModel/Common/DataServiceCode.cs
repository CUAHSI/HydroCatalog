using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cuahsi.Model.Base;
using Cuahsi.Model.OdCore.Shared;

namespace Cuahsi.Model.OdCore.Common
{
    public class DataServiceCode : BaseEntity
    {
        public virtual string PrefixCode { get; set; }
        public virtual Source Source
        {
            get; set;
        }

       // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
                var ds = (DataServiceCode) obj;
            if (ds == null ) return false;
                if (this.PrefixCode.Equals(ds.PrefixCode,StringComparison.CurrentCultureIgnoreCase))
                    return true;
                return false;

            
        }

// override object.GetHashCode
        public override int GetHashCode()
        {
           
            return (PrefixCode.GetHashCode() * 397) ^ GetType().GetHashCode(); 
           // return base.GetHashCode();
        }
    }
}