using System;
using System.Linq;

namespace Q1
{
    public class Optimizer
    {
        private Truck[] sortedTrucks;

        public Optimizer(Truck[] trucks, Box[] boxes)
        {
            sortedTrucks = trucks;
            Sort();

            foreach (var box in boxes)
            {
                sortedTrucks[0].Add(box);
                Sort();
            }
        }

        public void Optimize()
        {
            for (var i = sortedTrucks.Length - 1; i > 0; i--)
            {
                OptimizeCore(i);
            }
        }

        void OptimizeCore(int i)
        {
            var before = CalcVariance();

            var box = sortedTrucks[i].GetLightest();
            sortedTrucks[i].Remove(box);
            sortedTrucks[0].Add(box);

            var affter = CalcVariance();

            if (before > affter)
            {
                Sort();
                OptimizeCore(i);
            }
            else
            {
                sortedTrucks[0].Remove(box);
                sortedTrucks[i].Add(box);
            }
        }

        void Sort()
        {
            sortedTrucks = sortedTrucks.OrderBy(x => x.TotalWeight).ToArray();
        }

        double CalcVariance()
        {
            if (sortedTrucks.Length == 0)
            {
                return double.NaN;
            }

            var a = Math.Pow(sortedTrucks.Average(x => x.TotalWeight), 2);
            var b = sortedTrucks.Sum(x => Math.Pow(x.TotalWeight, 2)) / sortedTrucks.Length;
            return b - a;
        }
    }
}
