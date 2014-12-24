using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Lab2.Engine
{
    public class Camera
    {
        public Point3D Position
        { get; private set; }

        public Vector3D Orientation
        { get; private set; }

        public double DistanceToScreen
        { get; private set; }

        public Point3D ScreenCenter
        { get; private set; }

        public Vector3D Normal
        { get; private set; }

        public delegate void CameraChanged();

        public event CameraChanged OnChange;

        public Camera()
        {
            Position = new Point3D(2, 2, 2);
            Orientation = new Vector3D(1, 0, 0);
            Normal = (Vector3D)Position;
            DistanceToScreen = 1;
            ComputeScreenCenter();
        }

        public Camera(Point3D position, Vector3D orientation, Vector3D normal, double distanceToScreen)
        {
            Position = position;
            Orientation = orientation;
            Normal = normal;
            DistanceToScreen = distanceToScreen;
            ComputeScreenCenter();
        }

        public void ChangeParams(Point3D position)
        {
            Position = position;
            ComputeScreenCenter();
            OnChange();
        }

        public void ChangeParams(Vector3D normal)
        {
            Normal = normal;
            ComputeScreenCenter();
            OnChange();
        }

        public void ChangeParams(double distanceToScreen)
        {
            DistanceToScreen = distanceToScreen;
            OnChange();
        }

        public void ChangeParams(Point3D position, Vector3D normal)
        {
            Position = position;
            Normal = normal;
            ComputeScreenCenter();
            OnChange();
        }

        public void ChangeParams(Point3D position, Vector3D normal, double distanceToScreen)
        {
            Position = position;
            Normal = normal;
            DistanceToScreen = distanceToScreen;
            ComputeScreenCenter();
            OnChange();
        }

        public void ChangeParams(Point3D position, Vector3D orientation, Vector3D normal, double distanceToScreen)
        {
            Position = position;
            Orientation = orientation;
            Normal = normal;
            DistanceToScreen = distanceToScreen;
            ComputeScreenCenter();
            OnChange();
        }

        private void ComputeScreenCenter()
        {
            ScreenCenter = Position - Normal;
        }
    }
}
