using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.MatrixLib;

namespace Lab2.Model.impl.polygon
{
    public class PolygonModelMock : IModel
    {
        public string Name { get; private set; }

        public Matrix WorldCoordinates
        {get; private set;}

        public List<Face> FaceList
        { get; private set; }

        public PolygonModelMock()
        {
            FaceList = new List<Face>();
            Name = "CubeMock";
            Init();
        }

        private void Init()
        {
            List<double> vertexList = new List<double>(){0,0,1,1,0,0,1,1,0,1,1,0,0,1,1,0,0,0,0,0,-1,-1,-1,-1,1,1,1,1,1,1,1,1};
            WorldCoordinates = new Matrix(4, 8, vertexList);

            int[] vertex; 
            Face face;

            vertex = new int[4] { 0, 1, 2, 3 };
            face = new Face();
            face.AddRange(vertex);
            FaceList.Add(face);

            vertex = new int[4] { 1, 2, 6, 5 };
            face = new Face();
            face.AddRange(vertex);
            FaceList.Add(face);

            vertex = new int[4] { 4, 5, 6, 7 };
            face = new Face();
            face.AddRange(vertex);
            FaceList.Add(face);

            vertex = new int[4] { 0, 4, 7, 3 };
            face = new Face();
            face.AddRange(vertex);
            FaceList.Add(face);

            vertex = new int[4] { 0, 1, 5, 4 };
            face = new Face();
            face.AddRange(vertex);
            FaceList.Add(face);

            vertex = new int[4] { 3, 2, 6, 7 };
            face = new Face();
            face.AddRange(vertex);
            FaceList.Add(face);
        }
    }
}
