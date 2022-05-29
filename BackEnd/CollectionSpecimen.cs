using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heuristicOptimization
{
    abstract class CollectionSpecimen<T> : ISpecimen
    {
        #region Fields
        /// <summary>
        /// The list of segments of the DNA strand
        /// </summary>
        public List<T> DNA_1 { get; private set; }
        public T[] DNA { get; protected set; }
        /// <summary>
        /// Gets the length.
        /// </summary>
        /// <value>
        /// The length.
        /// </value>
        public int Length
        {
            get { return this.DNA.Length; }
            private set { }
        }

        //private Function Mutation_Function;
        //private Function CrossBreed_Function;
        private Function Fitness_Function;
        #endregion

        #region Constructor
        public CollectionSpecimen(int length)
        {
            DNA = new T[length];
        }

        public CollectionSpecimen()
        {

        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Performs crossover with another specimen
        /// </summary>
        /// <param name="Spec">The spec.</param>
        public void CrossBreed(CollectionSpecimen<T> Spec)
        {
            throw new NotImplementedException();
        }

        public void CrossBreed(ISpecimen spec)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a new specimen (DNA sequence).
        /// </summary>
        public void Create()
        {
            //this.DNA = new List<T>();
            this.DNA = new T[this.Length];
            for(int i = 0; i < this.Length; i++)
            {
                this.DNA[i] = (this.GetRandomSegment());//populate sequence with random segments
            }
        }

        /// <summary>
        /// Gets the fitness.
        /// </summary>
        /// <returns>the fitness</returns>
        public int GetFitness()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Mutates the specimen.
        /// </summary>
        /// <param name="rate">The rate.</param>
        public void Mutate(double rate)
        {
            for(int i = 0; i < this.DNA.Length; i++)
            {
                if (PerformMutation(rate))
                {
                    PerformRandomSwap(i);
                }
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Swaps the specified elements of the list.
        /// </summary>
        /// <param name="i1">The first element.</param>
        /// <param name="i2">The second element.</param>
        protected void Swap(int i1, int i2)
        {
            T temp = this.DNA[i1];
            this.DNA[i1] = this.DNA[i2];
            this.DNA[i2] = temp;
        }

        /// <summary>
        /// Performs the random swap.
        /// </summary>
        /// <param name="index">The index of the element being swapped.</param>
        protected void PerformRandomSwap(int index)
        {
            Random r = new Random();
            int rand = r.Next(0, this.DNA.Length);//Note that this allows possibility of member swapping with itself; effectively no swap

            this.Swap(index, rand);
        }

        /// <summary>
        /// Gets the random character.
        /// </summary>
        /// <returns></returns>
        protected abstract T GetRandomSegment();

        /// <summary>
        /// Determines whether a mutation is to be performed
        /// </summary>
        /// <param name="rate">The rate.</param>
        /// <returns></returns>
        protected bool PerformMutation(double rate)
        {
            Random r = new Random();
            double rand = r.NextDouble();
            return (rand <= rate) ? true : false;
        }

        /// <summary>
        /// Swaps all values.
        /// </summary>
        /// <param name="Spec">The spec.</param>
        public void SwapAllValues(ISpecimen Spec)
        {/*
            this.DNA.Clear();
            foreach(T segment in ((CollectionSpecimen<T>)Spec).DNA)
            {
                this.DNA.Add(segment);
            }*/
        }
        #endregion
    }
}
