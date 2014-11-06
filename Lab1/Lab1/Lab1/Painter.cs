using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixLib;
using System.Drawing;

namespace Lab1
{
    class Painter
    {
        private double L;
        private double R;
        private double B;
        private double T;
        private int WindowSizeX;
        private int WindowSizeY;
        /*private Matrix InputMatrix;
        private Matrix AffineMatrix;
        private Matrix AdjacencyMatrix;*/


        public Painter(double L, double R, double B, double T, int windowSizeX, int windowSizeY)
        {
            this.L = L;
            this.R = R;
            this.B = B;
            this.T = T;
            this.WindowSizeX = windowSizeX;
            this.WindowSizeY = windowSizeY;
        }

        private int XFromDec(Double x)
        {
            return (int)((x-L)/(R-L)*WindowSizeX);
        }

        private int YFromDec(Double y)
        {
            return (int)((T-y)/(T-B)*WindowSizeY);
        }

        public void ReDraw(Bitmap bm, Matrix printedMatrix, Matrix adjacencyMatrix)
        {
            Graphics g = Graphics.FromImage(bm);

            g.FillRectangle(Brushes.Red, 0, 0, 200, 10);
            g.FillRectangle(Brushes.White, 0, 11, 200, 10);

            g.DrawLine(
                            new Pen(Color.DarkGray, 2.0f),
                            new Point(1, 1),
                            new Point(40, 40));
            for (int i = 0; i < adjacencyMatrix.RowSize-1; i++)
            {
                for (int j = i + 1; j < adjacencyMatrix.ColSize; j++)
                {
                    if (adjacencyMatrix[i, j] == 1)
                        g.DrawLine(
                            new Pen(Color.DarkGray, 2.0f),
                            new Point(XFromDec(printedMatrix[0, i]), YFromDec(printedMatrix[1, i])),
                            new Point(XFromDec(printedMatrix[0, j]), YFromDec(printedMatrix[1, j])));
                }
            }
        }

    }
}
