using System.Collections.Generic;
using System.Linq;

namespace Q1
{
    public class Truck
    {
        readonly List<Box> boxes;

        public Truck(int id)
        {
            Id = id;
            boxes = new List<Box>();
        }

        public int Id { get; }
        public double TotalWeight { get; private set; }


        public void Add(Box box)
        {
            boxes.Add(box);
            TotalWeight += box.Weight;
        }

        public Box GetLightest()
        {
            var lightest = boxes.OrderBy(x => x.Weight).FirstOrDefault();
            if (lightest == null)
            {
                return null;
            }

            return lightest;
        }

        public void Remove(Box box)
        {
            boxes.Remove(box);
            TotalWeight -= box.Weight;
        }

        public override string ToString()
        {
            var boxId = string.Join(",", boxes.OrderBy(x => x.Id).Select(x => x.Id));
            return $"truck_{Id}:{boxId}";
        }
    }
}
