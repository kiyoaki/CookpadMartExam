using System;
using System.Linq;

namespace Q1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException($"{nameof(input)}={input}");
            }

            var splited = input.Split(' ');
            if (splited.Length == 0)
            {
                throw new ArgumentException($"{nameof(input)}={input}");
            }

            var boxes = splited.Select(x => new Box(x)).ToArray();
            var trucks = Enumerable.Range(1, 3).Select(x => new Truck(x)).ToArray();
            var optimizer = new Optimizer(trucks, boxes);
            optimizer.Optimize();

            foreach (var truck in trucks)
            {
                Console.WriteLine(truck.ToString());
            }
        }
    }
}
