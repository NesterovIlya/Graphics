using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Lab2.MatrixLib;
using Lab2.Model.impl.polygon;
using Lab2.Model;
using Lab2.Engine;

namespace Lab2
{
    class Painter
    {
        public double L
        { get; private set; }
        public double R
        { get; private set; }
        public double B
        { get; private set; }
        public double T
        { get; private set; }

        private int WindowSizeX;
        private int WindowSizeY;


        public Painter(double L, double R, double B, double T, int windowSizeX, int windowSizeY)
        {
            this.L = L;
            this.R = R;
            this.B = B;
            this.T = T;
            this.WindowSizeX = windowSizeX;
            this.WindowSizeY = windowSizeY;
        }

        public void ChangeWindowSize(int windowSizeX, int windowSizeY)
        {
            this.WindowSizeX = windowSizeX;
            this.WindowSizeY = windowSizeY;
        }

        private int XFromDec(Double x)
        {
            return (int)((x - L) / (R - L) * WindowSizeX);
        }

        private int YFromDec(Double y)
        {
            return (int)((T - y) / (T - B) * WindowSizeY);
        }

        public void ReDraw(Bitmap bm)
        {
            DrawAxis(bm);
            Graphics g = Graphics.FromImage(bm);

            PyramideMock model = GraphicEngine.Instance.Scene.GetModel("PyramideMock") as PyramideMock;


            Matrix printedMatrix = GraphicEngine.Instance.CurrentProjection;
            foreach (Face face in model.FaceList)
            {
                List<Point> points = new List<Point>();
                foreach (int pointNumber in face.Points)
                {
                    points.Add(new Point(XFromDec(printedMatrix[0, pointNumber]), YFromDec(printedMatrix[1, pointNumber])));
                }
                g.DrawPolygon(new Pen(Color.Brown, 2.0f),points.ToArray());
            }
        }

        private void DrawAxis(Bitmap bm)
        {
            Graphics g = Graphics.FromImage(bm);

            Matrix axisMatrix = GraphicEngine.Instance.Axis;

            g.DrawLine(
                            new Pen(Color.Black, 1.0f),
                            new Point(XFromDec(axisMatrix[0,0]),YFromDec(axisMatrix[1,0])),
                            new Point(XFromDec(axisMatrix[0,1]), YFromDec(axisMatrix[1,1])));
            g.DrawLine(
                            new Pen(Color.Black, 1.0f),
                            new Point(XFromDec(axisMatrix[0,0]), YFromDec(axisMatrix[1,0])),
                            new Point(XFromDec(axisMatrix[0,2]), YFromDec(axisMatrix[1,2])));
            g.DrawLine(
                            new Pen(Color.Black, 1.0f),
                            new Point(XFromDec(axisMatrix[0,0]), YFromDec(axisMatrix[1,0])),
                            new Point(XFromDec(axisMatrix[0,3]), YFromDec(axisMatrix[1,3])));
        }
    }
}
