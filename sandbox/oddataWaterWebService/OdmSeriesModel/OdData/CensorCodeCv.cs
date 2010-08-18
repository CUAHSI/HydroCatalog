using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cuahsi.Model.OdCore.Common;

namespace Cuahsi.Model.OdData
{
    public class CensorCodeCv : ControlledVocabulary
    {
        public virtual bool NotCensored { get; set;}

        public CensorCodeCv()
        {
            NotCensored = true;
        }
    }
}
