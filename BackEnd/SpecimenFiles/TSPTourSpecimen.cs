using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heuristicOptimization
{
    class TSPTourSpecimen : CollectionSpecimen<int[]>
    {
        #region Fields
        #endregion

        #region Constructor

        #endregion

        #region Public Methods
        /// <summary>
        /// Creates a new specimen (DNA sequence) -> overriden since duplicates are not permitted (special circumstances for TSP problem)
        /// </summary>
        new public void Create()
        {

        }

        /// <summary>
        /// Gets the random segment.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override int[] GetRandomSegment()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Private Methods
        #endregion

    }
}
