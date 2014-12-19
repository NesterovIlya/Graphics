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
        private double L;
        private double R;
        private double B;
        private double T;
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
            Graphics g = Graphics.FromImage(bm);
            IModel result;
            GraphicEngine.Instance.Scene.GetModel("CubeMock", out result);
            PolygonModelMock model = result as PolygonModelMock;

            Matrix printedMatrix = GraphicEngine.Instance.CurrentProjection;
            foreach (Face face in model.FaceList)
            {
                List<Point> points = new List<Point>();
                foreach (int pointNumber in face.Points)
                {
                    points.Add(new Point(XFromDec(printedMatrix[0,pointNumber]),YFromDec(printedMatrix[1,pointNumber])));
                }
                g.DrawPolygon(new Pen(Color.Black, 1.0f),points.ToArray());
            }
        }

        public void DrawAxis(Bitmap bm)
        {
            Graphics g = Graphics.FromImage(bm);
            g.DrawLine(
                            new Pen(Color.Black, 1.0f),
                            new Point(WindowSizeX / 2, 0),
                            new Point(WindowSizeX / 2, WindowSizeY));
            g.DrawLine(
                            new Pen(Color.Black, 1.0f),
                            new Point(0, WindowSizeY / 2),
                            new Point(WindowSizeX, WindowSizeY / 2));
        }
    }
}
