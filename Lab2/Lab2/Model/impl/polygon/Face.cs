using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Model.impl.polygon
{
    public class Face
    {
        public List<int> Points
        { get; set; }

        public Face()
        {
            Points = new List<int>();
        }

        public void Add(int pointNumber)
        {
            Points.Add(pointNumber);
        }

        public void AddRange(int[] pointNumbers)
        {
            Points.AddRange(pointNumbers);
        }

        public bool Remove(int point)
        {
            return Points.Remove(point);
        }

        public void RemoveAt(int index)
        {
            Points.RemoveAt(index);
        }

    }
}
