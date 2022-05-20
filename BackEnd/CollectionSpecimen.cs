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
        List<T> Segments;
        #endregion

        #region Constructor
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

        }

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
            for(int i = 0; i < this.Segments.Count; i++)
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
        private void Swap(int i1, int i2)
        {
            T temp = this.Segments[i1];
            this.Segments[i1] = this.Segments[i2];
            this.Segments[i2] = temp;
        }

        /// <summary>
        /// Performs the random swap.
        /// </summary>
        /// <param name="index">The index of the element being swapped.</param>
        private void PerformRandomSwap(int index)
        {
            Random r = new Random();
            int rand = r.Next(0, this.Segments.Count);//Note that this allows possibility of member swapping with itself; effectively no swap

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
        private bool PerformMutation(double rate)
        {
            Random r = new Random();
            double rand = r.NextDouble();
            return (rand <= rate) ? true : false;
        }
        #endregion
    }
}
