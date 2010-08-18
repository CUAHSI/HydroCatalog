using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cuahsi.Model.OdCore.Common;

namespace Cuahsi.Model.OdCore.Site
{
    public class SiteTypeCv : ControlledVocabulary
    {
        public virtual string Description
        {
            get;
            set;
        }

        public SiteTypeCv()
        {


        }
    }
}