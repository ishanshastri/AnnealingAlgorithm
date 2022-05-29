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

        private double ScalingConstant;

        /// <summary>
        /// The current temperature
        /// </summary>
        private double CurrentTemperature;

        /// <summary>
        /// The current generation
        /// </summary>
        private int CurrentGeneration;

        /// <summary>
        /// The maximum fitness
        /// </summary>
        private double MaxFitness;

        /// <summary>
        /// The fittest specimine
        /// </summary>
        private ISpecimen FittestSpec;

        /// <summary>
        /// The temperature function
        /// </summary>
        private Function TemperatureFunction;

        /// <summary>
        /// The mutation probability function (analogous to fitness function)
        /// </summary>
        private Function MutationProbabilityFunction;

        /// <summary>
        /// The current specimen
        /// </summary>
        private ISpecimen CurrentSpecimen;
        #endregion

        #region Constructors
        public AnnealingOven(double t_i, Function t_func, Function mp_func, ISpecimen spec_i) {//Eventually redundant; will all be deserialized from script
            this.TemperatureFunction = t_func;
            this.MutationProbabilityFunction = mp_func;
            this.InitialTemperature = t_i;
            this.CurrentSpecimen = spec_i;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Performs Annealation (algorithm). -> (Annealing)
        /// </summary>
        /// <returns></returns>
        public double Anneal()
        {
            this.setup();
            //Loop for max # of iterations specified, or until given termination condition reached
                //Get Random Specimine

                //Compare with previous value (if any)

                //*If new value is fitter -> reset current value to new value; reset value of 'FittestSpecimine'
                //Else -> use MutationProbabilityFunction to get weighting on whether new current should be swapped with new value (0 < W < 1)
                //Generate random double, and compare with previously obtained weighting (0 < R < 1)
                //If R > W -> perform swap; Else generate new mutation and repeat comparison (GoTo *)
            //EndLoop
            //Return fittest iteration ('FittestSpecimine')

            //for(int time = 0; int < )
            //Consider making global to class
            int CurrIteration = 0;
            double maxFitness = 0;
            double curFitness = 0;
            double CurTemp = this.InitialTemperature;
            double SwapProbability = 0;
            ISpecimen FittestSpec = this.CurrentSpecimen;
            ISpecimen NextSpec = this.CurrentSpecimen;
            this.CurrentSpecimen.Create();//Generate a new specimen

            for(int time = 0; !TerminationConditionReached(); time++)
            {
            }
            //OR
            do
            {
                CurTemp = this.TemperatureFunction.Evaluate(string.Format("curr_iteration={0}", CurrIteration));
                this.CurrentTemperature = ((double)this.InitialTemperature / (Math.Exp(this.CurrentGeneration)));//STUB; take from customized function, as shown above
                curFitness = this.CurrentSpecimen.GetFitness();
                /*if(curFitness >= maxFitness)
                {
                    maxFitness = curFitness;
                    FittestSpec.SwapAllValues(this.CurrentSpecimen);
                }
                else
                {

                }*/
                if (curFitness >= maxFitness)//Keep track of fittest specimen
                {
                    maxFitness = curFitness;
                    FittestSpec.SwapAllValues(this.CurrentSpecimen);
                }

                //Create a new specimen (random)
                NextSpec.Create();

                //Evaluate candidacy of new specimen vs prev. (cur) specimen
                if(NextSpec.GetFitness() > curFitness)
                {
                    SwapProbability = 1;
                }
                else
                {
                    //SwapProbability = MutationProbabilityFunction.Evaluate(string.Format("currTemp={0}", CurTemp));//Eventually
                    SwapProbability = (1 / (Math.Exp((curFitness - NextSpec.GetFitness()) / (CurTemp))));//STUB; eventually above
                }

                //Perform swap depending on swap probability
                if (this.EvolveStatus(SwapProbability))
                {
                    this.CurrentSpecimen.SwapAllValues(NextSpec);
                }
            } while(!TerminationConditionReached());

            return 0;
        }//initial_temp=45; termination_condition=[iterations>200 OR fitness > 0.9]; temperature_function={f(cur_iteration, cur_fittest, cur_max_fitness, ...)}; 

        /// <summary>
        /// Whether termination condition(s) have been met.
        /// </summary>
        /// <returns></returns>
        private bool TerminationConditionReached()
        {
            if(this.CurrentTemperature < 20)//STUB; will rely on customized function
            {
                return true;
            }
            return false;//STUB
        }

        private void setup()
        {
            TSPTourSpecimen tsp = new TSPTourSpecimen();
            tsp.Create();
            long len1 = tsp.tourLength();
            foreach (int[] i in tsp.DNA)
            {
                Console.Write(string.Format("[{0}, {1}], ", i[0], i[1]));
            }
            tsp.Mutate(1);
            Console.WriteLine("\n***");
            foreach (int[] i in tsp.DNA)
            {
                Console.Write(string.Format("[{0}, {1}], ", i[0], i[1]));
            }
            long len2 = tsp.tourLength();
            int diff = Math.Abs((int)(len1 - len2));
            this.ScalingConstant = (this.InitialTemperature * Math.Log(2)) / diff;//get constant for scaling
            //Console.WriteLine(1 / Math.Exp((con * diff) / temp_1));
        }

        private bool EvolveStatus(double prob)
        {
            Random r = new Random();
            double rand = r.NextDouble();
            return (rand <= prob)&&(prob != 0) ? true : false;
        }

        //private void Evolve()
        #endregion
    }
}
