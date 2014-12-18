using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Model.impl.polygon;
using Lab2.MatrixLib;

namespace Lab2.Model.impl
{
    public class PolygonModel : IModel
    {
        public string Name { get; private set; }

        public Matrix WorldCoordinates
        {get; private set;}

        private List<Face> _faceList;

        public PolygonModel()
        {
            _faceList = new List<Face>();
            Name = "unnamed";
        }

        public PolygonModel(string name)
        {
            _faceList = new List<Face>();
            Name = name;
        }

        public PolygonModel(string name, List<Face> faceList)
        {
            _faceList = new List<Face>();
            Name = name;
        }

        public void AddFace(Face face)
        {
            _faceList.Add(face);
        }

        public void Clear()
        {
            _faceList.Clear();
        }

        
    }
}
