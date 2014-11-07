using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MatrixLib;

namespace Lab1
{
    public partial class Form1 : Form
    {

        Matrix InputMatrix;
        Matrix CurrentMatrix;
        Matrix AdjacencyMatrix;
        Painter painter;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            painter = new Painter(-20,20,-20,20,MainScreen.ClientSize.Width,MainScreen.ClientSize.Height);
        }

        private void readDataButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void DrawForm(Matrix printedMatrix)
        {
            Bitmap bm = new Bitmap(MainScreen.Width, MainScreen.Height);
            painter.ReDraw(bm, printedMatrix, AdjacencyMatrix);
            MainScreen.Image = bm;
        }

        private void ShowAxis()
        {
            Bitmap bm = new Bitmap(MainScreen.Width, MainScreen.Height);
            painter.DrawAxis(bm);
            MainScreen.BackgroundImage = bm;

        }

        private void LoadData()
        {
            viewCoordTextBox.Clear();
            List<Double> rez1 = new List<double>();
            List<Double> rez2 = new List<double>();
            String[] arr1 = System.IO.File.ReadAllLines("InputMatrix.txt");
            String[] arr2 = System.IO.File.ReadAllLines("adjacencyMatrix.txt");
            foreach (String str in arr1)
            {
                List<Double> tmp = str.Split(' ').Select(n => Convert.ToDouble(n)).ToList();
                rez1.AddRange(tmp);
            }
            foreach (String str in arr2)
            {
                List<Double> tmp = str.Split(' ').Select(n => Convert.ToDouble(n)).ToList();
                rez2.AddRange(tmp);
            }
            try
            {
                InputMatrix = new Matrix(3, 32, rez1);
                AdjacencyMatrix = new Matrix(2, 32, rez2);
                CurrentMatrix = new Matrix(InputMatrix);
                for (int i=0;i<InputMatrix.RowSize;i++)
                {
                    string str = "";
                    for(int j=0;j<InputMatrix.ColSize;j++)
                        str = str + InputMatrix[i, j] + "  ";
                    viewCoordTextBox.Text = viewCoordTextBox.Text + str + Environment.NewLine + Environment.NewLine;
                }
            }
            catch (MatrixLib.exception.MatrixException e)
            {
                MessageBox.Show("Неверные объявленные размеры входной матрицы!");
            }
        }

        private void DrawButton_Click(object sender, EventArgs e)
        {
            Affine3DimMatrixBuilder builder = new Affine3DimMatrixBuilder();
            //builder.Transfer(0,5);
            Matrix affineMatrix = builder.GetAffineMatrix();
            CurrentMatrix = affineMatrix * InputMatrix;
            DrawForm(CurrentMatrix);
        }

        private void AxisButton_Click(object sender, EventArgs e)
        {
            ShowAxis();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            painter.ChangeWindowSize(MainScreen.Width, MainScreen.Height);
            ShowAxis();
        }

        private void turnLeftbutton_Click(object sender, EventArgs e)
        {
            Affine3DimMatrixBuilder builder = new Affine3DimMatrixBuilder();
            builder.Transfer(0, -2);
            builder.Rotate(Math.PI/4);
            builder.Transfer(0, 2);
            Matrix affineMatrix = builder.GetAffineMatrix();
            CurrentMatrix = affineMatrix * CurrentMatrix;
            DrawForm(CurrentMatrix);
        }

        private void turnRightbutton_Click(object sender, EventArgs e)
        {
            Affine3DimMatrixBuilder builder = new Affine3DimMatrixBuilder();
            //builder.Transfer(0, -2);
            builder.Rotate(-Math.PI / 4);
           // builder.Transfer(0, 2);
            Matrix affineMatrix = builder.GetAffineMatrix();
            CurrentMatrix = affineMatrix * CurrentMatrix;
            DrawForm(CurrentMatrix);
        }


        //private void 
    }
}
