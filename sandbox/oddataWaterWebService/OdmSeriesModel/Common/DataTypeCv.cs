using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cuahsi.Model.OdCore.Common;

namespace Cuahsi.Model.OdCore.Shared
{
    public class DataTypeCv: ControlledVocabulary
    {

        public DataTypeCv()
        {

            RequiresTimeSupport = false;
        }
        public virtual Boolean RequiresTimeSupport { get; set; }
    }
}