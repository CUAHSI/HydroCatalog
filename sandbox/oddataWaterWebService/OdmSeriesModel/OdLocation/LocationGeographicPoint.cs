using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cuahsi.Model.OdLocation
{
    public class LocationGeographicPoint : LocationBase
    {
        // backing fields are needed.  We are setting values in LocationBase
        private double _lon ;
        private double _lat;

        public virtual double Longitude { get{ return _lon;} set
        {
            _lon = value;
            _north = _lon;
            _south = _lon;
        } }
        public virtual double Latitude { get
        {
            return 
                _lat;}
         set
         {
             _lat = value;
             _east = _lat;
             _west = _lat;
         }
         }

        public new virtual double North
        {
            get { return Latitude; }
           // protected internal set {  }
        }
        public new  virtual double South
        {
            get { return Latitude; }
          //  protected  internal set { }
        }
        public new  virtual double East
        {
            get { return Longitude; }
            // protected  internal set { }
        }
        public new virtual double West
        {
            get { return Longitude; }
            //protected   internal set { }
        }
    }
}
