using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Lab2.MatrixLib;

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

        public void ReDraw(Bitmap bm, Matrix printedMatrix)
        {
            Graphics g = Graphics.FromImage(bm);


            for (int i = 0; i < printedMatrix.ColSize;i++)
            {
                g.DrawEllipse(
                    new Pen(Color.Black, 1f),
                    new Rectangle(
                        new Point(XFromDec(printedMatrix[0, i] - 0.1), YFromDec(printedMatrix[1, i] + 0.1)),
                        new Size(2, 2)));

            }
            /*for (int i = 0; i < adjacencyMatrix.ColSize; i++)
            {
                g.DrawLine(
                           new Pen(Color.Red, 3.0f),
                           new Point(XFromDec(printedMatrix[0, (int)adjacencyMatrix[0, i] - 1]), YFromDec(printedMatrix[1, (int)adjacencyMatrix[0, i] - 1])),
                           new Point(XFromDec(printedMatrix[0, (int)adjacencyMatrix[1, i] - 1]), YFromDec(printedMatrix[1, (int)adjacencyMatrix[1, i] - 1])));
            }*/
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
