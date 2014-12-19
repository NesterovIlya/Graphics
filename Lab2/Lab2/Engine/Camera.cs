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
            ScreenCenter = new Point3D(1, 1, 1);
            ComputeNormal();
        }

        public Camera(Point3D position, Vector3D orientation, Point3D screenCenter)
        {
            Position = position;
            Orientation = orientation;
            ScreenCenter = screenCenter;
            ComputeNormal();
        }

        public void ChangeParams(Point3D position, Point3D screenCenter)
        {
            Position = position;
            ScreenCenter = screenCenter;
            ComputeNormal();
            OnChange();
        }

        public void ChangeParams(Point3D position, Vector3D orientation, Point3D screenCenter)
        {
            Position = position;
            Orientation = orientation;
            ScreenCenter = screenCenter;
            ComputeNormal();
            OnChange();
        }

        private void ComputeNormal()
        {
            Normal = Position-ScreenCenter;
        }


    }
}
