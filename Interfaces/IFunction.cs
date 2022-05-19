using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heuristicOptimization
{
    interface IFunction
    {
        /// <summary>
        /// Gets the value for given parameters
        /// </summary>
        /// <param name="Parameters">The parameters (string representation).</param>
        /// <returns>the value of the function</returns>
        double Evaluate(string Parameters);

        /// <summary>
        /// Gets the value for given parameters
        /// </summary>
        /// <param name="Parameters">The parameters (array representation).</param>
        /// <returns>the value of the function</returns>
        double Evaluate(double[] Parameters);

        /// <summary>
        /// Sets the constant.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <param name="Value">The value.</param>
        void SetConstant(string ID, double Value);
    }
}
