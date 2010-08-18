using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cuahsi.Model.OdCore.Common;

namespace Cuahsi.Model.OdCore.Shared
{
    public class UnitTypeCv: ControlledVocabulary
    {

        public UnitTypeCv()
        {
         
        }

        public static UnitTypeCv Time()
        {
            return new UnitTypeCv
                       {
                           Name = "Time"
                       };
        }
    }
}