using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heuristicOptimization
{
    [Serializable]
    public class Function : IFunction
    {
        #region Fields
        /// <summary>
        /// The constants used in the function (map to values)
        /// </summary>
        public Dictionary<string, double> Constants;

        /// <summary>
        /// The parameters (stores the names)
        /// </summary>
        public List<string> Parameters;
        #endregion

        #region Constructor
        //Eventually will not be needed; functions will be directly deserialzed from script
        #endregion

        #region Methods
        /// <summary>
        /// Gets the value for given parameters
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>
        /// the value of the function
        /// </returns>
        public double Evaluate(double[] parameters)
        {
            return 0;//stub
        }

        /// <summary>
        /// Gets the value for given parameters
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>
        /// the value of the function
        /// </returns>
        public double Evaluate(string parameters)
        {
            return 0;//stub
        }

        /// <summary>
        /// Sets the constant.
        /// </summary>
        /// <param name="constants"></param>
        /// <param name="val"></param>
        public void SetConstant(string constants, double val)
        {
            //stub
        }
        #endregion
    }
}
