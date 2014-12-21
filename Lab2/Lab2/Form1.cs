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

        private bool _mouseIsDown = false;

        private Point3D _prevCoordinates;

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
            textBox1.Text = _camera.Position.X.ToString() +" " + _camera.Position.Y.ToString() + " " + _camera.Position.Z.ToString();
            gr.OnProjectionChanged += OnProjectionChangedHandler;
            DrawForm();
            Affine4DimMatrixBuilder builder = new Affine4DimMatrixBuilder();
            builder.Transfer(-0.5, -0.5, 0.5);
            Matrix affineMatrix = builder.GetAffineMatrix();

            CubeMock model = _scene.GetModel("CubeMock") as CubeMock;
            model.ChangeModel(affineMatrix);
        }

        private void DrawForm()
        {
            Bitmap bm = new Bitmap(Canvas.Width, Canvas.Height);
            _painter.ReDraw(bm);
            Canvas.Image = bm;
        }

        private void OnProjectionChangedHandler()
        {
            textBox1.Text = _camera.Position.X.ToString() + " " + _camera.Position.Y.ToString() + " " + _camera.Position.Z.ToString();
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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    {
                        Affine4DimMatrixBuilder builder = new Affine4DimMatrixBuilder();
                        builder.RotateOX(-Math.PI / 20);
                        Matrix affineMatrix = builder.GetAffineMatrix();

                        CubeMock model = _scene.GetModel("CubeMock") as CubeMock;
                        model.ChangeModel(affineMatrix);

                        break;
                    }
                case Keys.Right:
                    {
                        Affine4DimMatrixBuilder builder = new Affine4DimMatrixBuilder();
                        builder.RotateOX(Math.PI / 20);
                        Matrix affineMatrix = builder.GetAffineMatrix();

                        CubeMock model = _scene.GetModel("CubeMock") as CubeMock;
                        model.ChangeModel(affineMatrix);
                        break;
                    }
                case Keys.Up:
                    {
                        Affine4DimMatrixBuilder builder = new Affine4DimMatrixBuilder();
                        builder.RotateOY(-Math.PI / 20);
                        Matrix affineMatrix = builder.GetAffineMatrix();

                        CubeMock model = _scene.GetModel("CubeMock") as CubeMock;
                        model.ChangeModel(affineMatrix);
                        break;
                    }
                case Keys.Down:
                    {
                        Affine4DimMatrixBuilder builder = new Affine4DimMatrixBuilder();
                        builder.RotateOY(Math.PI / 20);
                        Matrix affineMatrix = builder.GetAffineMatrix();

                        CubeMock model = _scene.GetModel("CubeMock") as CubeMock;
                        model.ChangeModel(affineMatrix);
                        break;
                    }
            }
        }


    }
}
