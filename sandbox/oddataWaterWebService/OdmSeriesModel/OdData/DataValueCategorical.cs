using System;
using System.Collections.Generic;
using Cuahsi.Model.Base;
using Cuahsi.Model.OdCore.Series;

namespace Cuahsi.Model.OdData
{
    public class DataValueCategorical : BaseEntity
    {

        public DataValueCategorical()
        {

        }
        public DataValueCategorical(DataValueCategorical dv)
        {
            
            this.DateTimeUtc = dv.DateTimeUtc;
            this.UtcOffset = dv.UtcOffset;
            this.Value = dv.Value;
            this.Qualifier = dv.Qualifier;

        }

        //public DataValueCategorical(SeriesCategoricalData series)
        //{
        //    Series = series;
        //}

        //public DataValueCategorical(SeriesCategoricalData series, DataValueCategorical dv)
        //{
        //    Series = series;
        //    this.DateTimeUtc = dv.DateTimeUtc;         
        //    this.UtcOffset = dv.UtcOffset;
        //    this.Value = dv.Value;
        //    this.Qualifier = dv.Qualifier;

        //}
      //  public virtual  SeriesCategoricalData Series { get; set; }

        public virtual  double Value { get; set; }

       public virtual double UtcOffset { get; set; }

        public virtual DateTime DateTimeUtc { get; set; } 

       // public virtual  string CensorCode { get; set; }

        public virtual  IList<Qualifier> Qualifier { get; set; }

    //    public virtual  Source Source { get; set; }

    //    public virtual Method Method { get; set; }

    //    public virtual  QualityControlLevel QualityControlLevel { get; set; }


  //      public virtual OffsetType OffsetType { get; set; }
       
    //    public virtual UnitValue VerticalOffset { get; set; }
       

       // public virtual Sample Sample { get; set; } // it's nullable


    }
}
