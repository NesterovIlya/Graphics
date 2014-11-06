using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{
    public class Matrix
    {
        public int RowSize
        {get; private set;}
        public int ColSize
        {get; private set;}

        protected double[,] Cell;

        public static Matrix IdentityMatrix(int dim)
        {
            if (dim <= 0) throw new exception.DimentionMismatchException("Wrong dimention");
            Matrix matr = new Matrix(dim, dim);
            for (int i = 0; i < dim; i++)
                matr[i, i] = 1;
            return matr;

        }

        public Matrix()
        {
            RowSize = 0;
            ColSize = 0;
            Cell = null;
        }

        public Matrix(Matrix matr)
        {
            RowSize = matr.RowSize;
            ColSize = matr.ColSize;
            Cell = new double[RowSize, ColSize];
            for (int i = 0; i < RowSize; i++)
                for (int j = 0; j < ColSize; j++)
                {
                    Cell[i, j] = matr[i,j];
                } 
        }

        public Matrix(int rowSize, int colSize)
        {
            if (rowSize <= 0 || colSize <=0) throw new exception.DimentionMismatchException("Wrong colSize or rowSize in Matrix constructor.");
            RowSize = rowSize;
            ColSize = colSize;
            Cell = new double[RowSize,ColSize];
            for(int i = 0; i < RowSize; i++)
                for (int j = 0; j < ColSize; j++)
                {
                    Cell[i, j] = 0;
                }
        }

        public Matrix(int rowSize, int colSize, List<double> list)
        {
            if (rowSize <= 0 || colSize <= 0 || list.Count != rowSize*colSize) throw new exception.DimentionMismatchException("Wrong colSize, rowSize or list dimention in Matrix constructor.");
            RowSize = rowSize;
            ColSize = colSize;
            Cell = new double[RowSize, ColSize];
            for (int i = 0; i < RowSize; i++)
                for (int j = 0; j < ColSize; j++)
                {
                    Cell[i, j] = list[i*RowSize + j];
                }
        }


        public static Matrix operator +(Matrix leftOp, Matrix rightOp)
        {
            if (leftOp.RowSize != rightOp.RowSize || leftOp.ColSize != rightOp.ColSize) throw new exception.DimentionMismatchException("Wrong dimentions of arguments in `+` operator.");
            Matrix result = new Matrix(leftOp.RowSize, leftOp.ColSize);
            for (int i = 0; i < result.RowSize; i++)
                for (int j = 0; j < result.ColSize; j++)
                {
                    result[i, j] = leftOp[i,j]+rightOp[i,j];
                }
            return result;
        }

        public static Matrix operator -(Matrix leftOp, Matrix rightOp)
        {
            if (leftOp.RowSize != rightOp.RowSize || leftOp.ColSize != rightOp.ColSize) throw new exception.DimentionMismatchException("Wrong dimentions of arguments in `-` operator.");
            Matrix result = new Matrix(leftOp.RowSize, leftOp.ColSize);
            for (int i = 0; i < result.RowSize; i++)
                for (int j = 0; j < result.ColSize; j++)
                {
                    result[i, j] = leftOp[i, j] - rightOp[i, j];
                }
            return result;
        }

        public static Matrix operator *(Matrix leftOp, Matrix rightOp)
        {
            if (leftOp.ColSize != rightOp.RowSize) throw new exception.DimentionMismatchException("Wrong dimentions of arguments in `*` operator.");
            Matrix result = new Matrix(leftOp.RowSize, rightOp.ColSize);
            for (int i = 0; i < result.RowSize; i++)
                for (int j = 0; j < result.ColSize; j++)
                {
                    double scalar = 0;
                    for (int k=0; k<rightOp.RowSize; k++)
                    {
                        scalar += leftOp[i, k] * rightOp[k, j];
                    }
                    result[i, j] = scalar;
                }
            return result;
            
        }

        public Matrix scalarMult(double op)
        {
            Matrix result = new Matrix(this.RowSize, this.ColSize);
            for (int i = 0; i < result.RowSize; i++)
                for (int j = 0; j < result.ColSize; j++)
                {
                    result[i, j] = this[i, j]*op;
                }
            return result;
        }

        public double this[int i, int j] {get{return Cell[i, j];} set{Cell[i, j] = value;}}

        public void print()
        {
            for (int i = 0; i < this.RowSize; i++)
            {
                for (int j = 0; j < this.ColSize; j++)
                {
                    System.Console.Write(this[i, j] + "\t");
                }
                System.Console.WriteLine();
            }

        }
    }

    public class Affine3DimMatrixBuilder
    {

        private Matrix matrix;

        public Affine3DimMatrixBuilder()
        {
            matrix = Matrix.IdentityMatrix(3);
        }

        public void newAffineMatrix()
        {
            matrix = Matrix.IdentityMatrix(3);
        }

        public Matrix GetAffineMatrix()
        {
            return matrix;
        }

        public void Transfer(Double x, Double y)
        {
            Matrix transferMatrix = Matrix.IdentityMatrix(3);
            transferMatrix[1, 3] = x;
            transferMatrix[2, 3] = y;
            matrix = matrix*transferMatrix;
        }

        public void Rotate(Double angle)
        {
            Matrix rotateMatrix = Matrix.IdentityMatrix(3);
            rotateMatrix[1, 1] = Math.Cos(angle);
            rotateMatrix[1, 2] = -Math.Sin(angle);
            rotateMatrix[2, 1] = Math.Sin(angle);
            rotateMatrix[2, 2] = Math.Cos(angle);
            matrix = matrix * rotateMatrix;
        }

        public void Scale(Double x, Double y)
        {
            Matrix scaleMatrix = Matrix.IdentityMatrix(3);
            scaleMatrix[1, 1] = x;
            scaleMatrix[2, 2] = y;
            matrix = matrix * scaleMatrix;
        }

        public void XReflect()
        {
            Matrix xReflectMatrix = Matrix.IdentityMatrix(3);
            xReflectMatrix[2, 2] = -1;
            matrix = matrix * xReflectMatrix;
        }

        public void YReflect()
        {
            Matrix yReflectMatrix = Matrix.IdentityMatrix(3);
            yReflectMatrix[1, 1] = -1;
            matrix = matrix * yReflectMatrix;
        }

        public void CReflect()
        {
            Matrix cReflectMatrix = Matrix.IdentityMatrix(3);
            cReflectMatrix[1, 1] = -1;
            cReflectMatrix[2, 2] = -1;
            matrix = matrix * cReflectMatrix;
        }
    }
}
