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

            for (int i = 0; i < adjacencyMatrix.RowSize-1; i++)
            {
                for (int j = i + 1; j < adjacencyMatrix.ColSize; j++)
                {
                    if (adjacencyMatrix[i, j] == 1)
                        g.DrawLine(
                            new Pen(Color.Red, 2),
                            new Point(XFromDec(printedMatrix[i, 0]), YFromDec(printedMatrix[i, 1])),
                            new Point(XFromDec(printedMatrix[j, 0]), YFromDec(printedMatrix[j, 1])));
                }
            }
        }

    }
}
