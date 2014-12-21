using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Model;
using Lab2.Model.impl.polygon;
using Lab2.MatrixLib;
using System.Windows.Media.Media3D;

namespace Lab2.Engine
{
    public class GraphicEngine
    {
        private static GraphicEngine _engineInstanse;
        public Scene Scene
        { get; private set; }

        public Camera Camera
        { get; private set; }

        public Matrix CurrentProjection
        { get; private set; }

        public Matrix Axis
        { get; private set; }

        private ScreenBasis _screenBasis;

        private Matrix _transformingMatrix;

        private Matrix _projectionMatrix;

        public delegate void ProjectionChanged();

        public event ProjectionChanged OnProjectionChanged;

        private GraphicEngine()
        {
            Scene = new Scene();
            Camera = new Camera();
            Camera.OnChange += CameraChangedHandler;
            _screenBasis = ScreenBasis.GetBasis(Camera);
            _transformingMatrix = Matrix.IdentityMatrix(4);
            ComputeTransformingMatrix();

            _projectionMatrix = new Matrix(3, 4);
            {
                _projectionMatrix[0, 0] = 1;
                _projectionMatrix[1, 1] = 1;
                _projectionMatrix[2, 3] = 1;
            }

            CubeMock pmm = new CubeMock();
            pmm.OnChange += ModelChangedHandler;

            Scene.Add(pmm);

            CurrentProjection = _projectionMatrix * _transformingMatrix * pmm.WorldCoordinates;
            ComputeAxisProjection();
        }

        public static GraphicEngine Instance
        {
            get
            {
                if (_engineInstanse == null) _engineInstanse = new GraphicEngine();
                return _engineInstanse;
            }
        }

        private void ComputeTransformingMatrix()
        {
            _transformingMatrix[0, 0] = _screenBasis.I.X;
            _transformingMatrix[1, 0] = _screenBasis.J.X;
            _transformingMatrix[2, 0] = _screenBasis.K.X;

            _transformingMatrix[0, 1] = _screenBasis.I.Y;
            _transformingMatrix[1, 1] = _screenBasis.J.Y;
            _transformingMatrix[2, 1] = _screenBasis.K.Y;

            _transformingMatrix[0, 2] = _screenBasis.I.Z;
            _transformingMatrix[1, 2] = _screenBasis.J.Z;
            _transformingMatrix[2, 2] = _screenBasis.K.Z;

            _transformingMatrix[0, 3] = -Vector3D.DotProduct(_screenBasis.I,(Vector3D)Camera.ScreenCenter);
            _transformingMatrix[1, 3] = -Vector3D.DotProduct(_screenBasis.J,(Vector3D)Camera.ScreenCenter);
            _transformingMatrix[2, 3] = -Vector3D.DotProduct(_screenBasis.J, (Vector3D)Camera.ScreenCenter);
        }

        private void CameraChangedHandler()
        {
            _screenBasis = ScreenBasis.GetBasis(Camera);
            _transformingMatrix = Matrix.IdentityMatrix(4);
            ComputeTransformingMatrix();

            IModel model = Scene.GetModel("CubeMock");

            CurrentProjection = _projectionMatrix * _transformingMatrix * model.WorldCoordinates;
            ComputeAxisProjection();
            OnProjectionChanged();
        }

        private void ModelChangedHandler()
        {
            IModel model = Scene.GetModel("CubeMock"); ;

            CurrentProjection = _projectionMatrix * _transformingMatrix * model.WorldCoordinates;

            OnProjectionChanged();
        }

        private class ScreenBasis
        {
            public Vector3D I
            { get; set; }

            public Vector3D J
            { get; set; }

            public Vector3D K
            { get; set; }

            public ScreenBasis(Vector3D i, Vector3D j, Vector3D k)
            {
                I = i;
                J = j;
                K = k;
            }

            public static ScreenBasis GetBasis(Camera camera)
            {
                Vector3D k = new Vector3D(camera.Normal.X, camera.Normal.Y, camera.Normal.Z);
                k.Normalize();
                Vector3D i = Vector3D.CrossProduct(camera.Orientation, camera.Normal);
                i.Normalize();
                Vector3D j = Vector3D.CrossProduct(k,i);
                return new ScreenBasis(i,j,k);
            }
        }

        public void ComputeAxisProjection()
        {
            List<double> matrixElem = new List<double>(){
                0, 100,   0,   0,
                0,   0, 100,   0,
                0,   0,   0, 100,
                1,   1,   1,   1
            };
            Matrix axisMatrix = new Matrix(4,4,matrixElem);
            Axis = _projectionMatrix * _transformingMatrix * axisMatrix;
        }
    }
}
