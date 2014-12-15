using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Model.impl.polygon
{
    public class Face
    {
        private List<int> _points;

        public Face()
        {
            _points = new List<int>();
        }

        public void Add(int pointNumber)
        {
            _points.Add(pointNumber);
        }

        public void AddRange(int[] pointNumbers)
        {
            _points.AddRange(pointNumbers);
        }

        public bool Remove(int point)
        {
            return _points.Remove(point);
        }

        public void RemoveAt(int index)
        {
            _points.RemoveAt(index);
        }

    }
}
