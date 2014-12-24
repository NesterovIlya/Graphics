using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.MatrixLib;

namespace Lab2.Model.impl.polygon
{
    public class PyramideMock : IModel
    {
        public string Name { get; private set; }

        public Matrix WorldCoordinates
        {get; private set;}

        private Matrix _inputCoordinates;

        public delegate void ModelChanged();

        public event ModelChanged OnChange;

        public List<Face> FaceList
        { get; private set; }

        public PyramideMock()
        {
            FaceList = new List<Face>();
            Name = "PyramideMock";
            Init();
        }

        private void Init()
        {
            List<double> vertexList = new List<double>(){
                1, 0, 0, 0, 0,
                0, 0, 1, 0,-1,
                0, 1, 0,-1, 0,
                1, 1, 1, 1, 1
            };
             _inputCoordinates = new Matrix(4, 5, vertexList);
             WorldCoordinates = new Matrix(_inputCoordinates);

            int[] vertex; 
            Face face;

            vertex = new int[4] { 1, 2, 3, 4 };
            face = new Face();
            face.AddRange(vertex);
            FaceList.Add(face);

            vertex = new int[3] { 0, 1, 2 };
            face = new Face();
            face.AddRange(vertex);
            FaceList.Add(face);

            vertex = new int[3] { 0, 2, 3};
            face = new Face();
            face.AddRange(vertex);
            FaceList.Add(face);

            vertex = new int[3] { 0, 3, 4 };
            face = new Face();
            face.AddRange(vertex);
            FaceList.Add(face);

            vertex = new int[3] { 0, 4, 1 };
            face = new Face();
            face.AddRange(vertex);
            FaceList.Add(face);
        }

        public void ChangeModel(Matrix affineMatrix)
        {
            WorldCoordinates = affineMatrix * WorldCoordinates;
            OnChange();
        }
    }
}
