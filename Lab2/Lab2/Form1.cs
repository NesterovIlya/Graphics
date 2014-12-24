using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab2.Engine;
using Lab2.MatrixLib;
using Lab2.Model.impl.polygon;
using System.Windows.Media.Media3D;

namespace Lab2
{
    public partial class Form1 : Form
    {
        private Painter _painter;
        private Scene _scene;
        private Lab2.Engine.Camera _camera;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _painter = new Painter(-2, 2, -2, 2, Canvas.Width, Canvas.Height);
            GraphicEngine gr = GraphicEngine.Instance;
            _scene = gr.Scene;
            _camera = gr.Camera;
            gr.OnProjectionChanged += OnProjectionChangedHandler;
            DrawForm();
        }

        private void DrawForm()
        {
            Bitmap bm = new Bitmap(Canvas.Width, Canvas.Height);
            _painter.ReDraw(bm);
            Canvas.Image = bm;
        }

        private void OnProjectionChangedHandler()
        {
            DrawForm();
        }

        private double XFromScreen(int x)
        {
            return (double)x * (_painter.R - _painter.L) / Canvas.Width + _painter.L;
        }

        private double YFromScreen(int y)
        {
            return (double)y * (_painter.T - _painter.B) / Canvas.Height - _painter.T;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Affine4DimMatrixBuilder builder = new Affine4DimMatrixBuilder();
            builder.Scale(1.1, 1.1, 1.1);
            Matrix affineMatrix = builder.GetAffineMatrix();

            PyramideMock model = _scene.GetModel("PyramideMock") as PyramideMock;
            model.ChangeModel(affineMatrix);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Affine4DimMatrixBuilder builder = new Affine4DimMatrixBuilder();
            builder.Scale(0.9, 0.9, 0.9);
            Matrix affineMatrix = builder.GetAffineMatrix();

            PyramideMock model = _scene.GetModel("PyramideMock") as PyramideMock;
            model.ChangeModel(affineMatrix);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Affine4DimMatrixBuilder builder = new Affine4DimMatrixBuilder();
            builder.RotateOX(-Math.PI / 20);
            Matrix affineMatrix = builder.GetAffineMatrix();

            PyramideMock model = _scene.GetModel("PyramideMock") as PyramideMock;
            model.ChangeModel(affineMatrix);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Affine4DimMatrixBuilder builder = new Affine4DimMatrixBuilder();
            builder.YOZReflect();
            Matrix affineMatrix = builder.GetAffineMatrix();

            PyramideMock model = _scene.GetModel("PyramideMock") as PyramideMock;
            model.ChangeModel(affineMatrix);
        }


    }
}
