using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heuristicOptimization
{
    class AnnealingOven
    {
        /*
        static int s(int sd)
        {
            return 3;
        }
        private int InitialTemperature;

        Func<int, int> f = s;*/
        #region Fields
        /// <summary>
        /// The initial temperature
        /// </summary>
        private double InitialTemperature;

        /// <summary>
        /// The temperature function
        /// </summary>
        private Function TemperatureFunction;

        /// <summary>
        /// The mutation probability function (analogous to fitness function)
        /// </summary>
        private Function MutationProbabilityFunction;
        #endregion

        #region Constructors
        public AnnealingOven(double t_i, Function t_func, Function mp_func) {//Eventually redundant; will all be deserialized from script
            this.TemperatureFunction = t_func;
            this.MutationProbabilityFunction = mp_func;
            this.InitialTemperature = t_i;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Performs Annealation (algorithm). -> (Annealing)
        /// </summary>
        /// <returns></returns>
        public double Anneal()
        {
            //Loop for max # of iterations specified, or until given termination condition reached
                //Get Random Specimine

                //Compare with previous value (if any)

                //*If new value is fitter -> reset current value to new value; reset value of 'FittestSpecimine'
                //Else -> use MutationProbabilityFunction to get weighting on whether new current should be swapped with new value (0 < W < 1)
                    //Generate random double, and compare with previously obtained weighting (0 < R < 1)
                    //If R > W -> perform swap; Else generate new mutation and repeat comparison (GoTo *)
            //EndLoop
            //Return fittest iteration ('FittestSpecimine')
            return 0;
        }


        #endregion
    }
}
