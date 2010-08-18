using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cuahsi.Model.Base;

namespace Cuahsi.Model.OdLocation
{
    /// <summary>
    /// This provides a basic bounding box that can be utlize for searching on geographic objects
    /// </summary>
    public class LocationBase : BaseEntity
    {
         /* backing fields are needed
          * subclasses need to set the bounding box of the 
          * LocationBase. Without this the values in Location are 0.0 until 
          * stored in database. Which means we cannot reuse these as local objects
          * */

        protected double _north;
        protected double _south;
        protected double _east;
        protected double _west;

        public virtual double North
        {
            get
            {
                return _north;
            }
            protected internal set
            {
                _north = value;
            }
        }
        public virtual double East
        {
            get { return _east; }
            protected internal set
            { _east = value; }
        }
        public virtual double South
        {
            get { return _east; }
            protected internal set { _south = value; }
        }
        public virtual double West
        {
            get { return _west; }
            protected internal set { _west = value; }
        }

        public virtual string SpatialReferenceSystemCode { get; set; }

        public LocationBase()
        {
            SpatialReferenceSystemCode = "EPSG:4236";
        }
    }
}
