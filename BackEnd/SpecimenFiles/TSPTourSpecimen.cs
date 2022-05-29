using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heuristicOptimization
{
    class TSPTourSpecimen : CollectionSpecimen<int[]>, ISpecimen
    {
        #region Fields
        private long[,] distMatrix = Program.DistanceMatrix;
        private List<int> cityPool;

        private int numRoutes
        {
            get { return this.distMatrix.Length; } 
        }

        #endregion

        #region Constructor
        public TSPTourSpecimen()
        {
            this.DNA = new int[distMatrix.GetLength(1)-1][];//deserialize (eventually)
            this.populateCityPool();
            //base(this.numCities);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Creates a new specimen (DNA sequence) -> overriden since duplicates are not permitted (special circumstances for TSP problem)
        /// </summary>
        new public void Create()
        {
            this.populateCityPool();//move to 'refresh' function
            for(int i = 0; i < this.Length; i++)
            {
                this.DNA[i] = new int[2];
                if (i == 0)
                {
                    this.DNA[i][0] = this.getNewRandomCity();
                    this.DNA[i][1] = this.getNewRandomCity();
                }
                else
                {
                    this.DNA[i][0] = this.DNA[i - 1][1];
                    this.DNA[i][1] = this.getNewRandomCity();
                }
            }
            List<int> ren = new List<int>();
        }

        /// <summary>
        /// Mutates the specimen.
        /// </summary>
        /// <param name="rate">The rate.</param>
        public new void Mutate(double rate)
        {
            for (int i = 0; i < this.Length; i++)
            {
                if (PerformMutation(rate))
                {
                    this.performRandomSwap(i);
                }
            }
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
        private void swap(int i1, int i2)
        {
            //Obtain cities to be swapped
            int[] route1 = this.DNA[i1];
            int[] route2 = this.DNA[i2];

            //Swap destination cities
            int tempCity = route1[1];
            route1[1] = route2[1];
            route2[1] = tempCity;

            //Update next start cities
            if(i1 < this.Length - 1)
            {
                DNA[i1 + 1][0] = DNA[i1][1];
            }
            if(i2 < this.Length - 1)
            {
                DNA[i2 + 1][0] = DNA[i2][1];
            }
        }

        private void performRandomSwap(int index)
        {
            Random r = new Random();
            int rand = r.Next(0, this.Length);//Note that this allows possibility of member swapping with itself; effectively no swap

            this.swap(index, rand);
        }

        /// <summary>
        /// Determines whether the specified city is duplicate.
        /// </summary>
        /// <param name="route">The city.</param>
        /// <returns>
        ///   <c>true</c> if the specified city is duplicate; otherwise, <c>false</c>.
        /// </returns>
        private bool isDuplicate(int[] route)
        {
            foreach(int[] seg in this.DNA)
            {/*
                if(city[0] == seg[0] && city[1] == seg[1])
                {
                    //if (city[1] == seg[1])
                    {
                        return false;
                    }
                }*/
                //OR
                if (seg.Equals(route))//using hash for comparisons
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Populates the city pool.
        /// </summary>
        private void populateCityPool()
        {
            this.cityPool = new List<int>();
            for(int i = 0; i < this.Length+1; i++)
            {
                cityPool.Add(i);
            }
        }

        private int getNewRandomCity()//Destination()//int start)
        {
            Random r = new Random();
            //List<int> pool = new List<int>();
            //for(int i = 0; i < )
            int result = cityPool[r.Next(0, this.cityPool.Count-1)];
            this.cityPool.Remove(result);
            return result;
        }

        public long tourLength()
        {
            long total = 0;
            foreach(int[] i in this.DNA)
            {
                total += Program.DistanceMatrix[i[0], i[1]];
            }
            return total;
        }
        #endregion
    }
}
