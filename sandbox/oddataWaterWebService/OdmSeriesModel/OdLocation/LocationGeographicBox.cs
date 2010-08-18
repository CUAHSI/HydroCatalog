using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cuahsi.Model.OdLocation
{
    public class LocationGeographicBox : LocationBase
    {

        //public virtual double Longitude { get; set; }
        //public virtual double Latitude { get; set; }

        public virtual double North
        {
            get { return _north; }
            set { _north = value;}
        }
        public virtual double South
        {
            get { return _south; }
            set { _south = value; }
        }
        public virtual double East
        {
            get { return _east; }
            set { _east = value; }
        }
        public  virtual double West
        {
            get { return _west; }
            set { _west = value; }
        }
    }
}
