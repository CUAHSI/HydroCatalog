using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cuahsi.Model.Base;
using Cuahsi.Model.OdCore.Series;
using Cuahsi.Model.OdCore.Shared;

namespace Cuahsi.Model.OdCore.Common
{
    /// <summary>
    /// An Action against a series produces a provenace record with 
    /// they type of SeriesProcessingAction. An action takes one or more input series, 
    /// and produces one or more output series.
    /// A method should be stored, and associated with the action. 
    /// math representation and  and messages from the processing should be stored in the 
    /// <see cref="GenericProvenance.Details"/>details property 
    /// </summary>
    public class SeriesProcessingAction : GenericProvenance
    {
        /// <summary>
        /// List of the input series
        /// <see cref="SeriesRecord"/>
        /// </summary>
        public virtual IList<SeriesRecord> InputSeries
        {
            get; set;
        }

        /// <summary>
        /// List of the outputs
        /// <see cref="SeriesRecord"/>
        /// </summary>
        public virtual IList<SeriesRecord> OutputSeries
        {
            get;
            set;
        }

        /// <summary>
        /// Reference to the method 
        /// <see cref="Method"/>
        /// </summary>
        public virtual Method Method { get; set; }
    }
}