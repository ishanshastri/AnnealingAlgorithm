using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heuristicOptimization
{
    interface ISpecimen
    {
        void Mutate(double MutRate);
        void CrossBreed(ISpecimen Spec);
        void Create();
        void SwapAllValues(ISpecimen Spec);

        int GetFitness();
    }
}
