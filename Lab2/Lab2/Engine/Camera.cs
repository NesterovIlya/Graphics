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
        { get; set; }

        public Vector3D Orientation
        { get; set; }

        public Point3D ScreenCenter
        { get; set; }

        public Vector3D Normal
        { get; private set; }

        public Camera()
        {
            Position = new Point3D(2, 4, 2);
            Orientation = new Vector3D(0, 1, 0);
            ScreenCenter = new Point3D(1, 2, 1);
            ComputeNormal();
        }

        public Camera(Point3D position, Vector3D orientation, Point3D screenCenter)
        {
            Position = position;
            Orientation = orientation;
            ScreenCenter = screenCenter;
            ComputeNormal();
        }

        private void ComputeNormal()
        {
            Normal = Position-ScreenCenter;
        }


    }
}
