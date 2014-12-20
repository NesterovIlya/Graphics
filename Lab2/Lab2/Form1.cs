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
            gr.OnProjectionChanged += OnProjectionChangedHandler;
            DrawForm();
            Affine4DimMatrixBuilder builder = new Affine4DimMatrixBuilder();
            builder.Transfer(-0.5, -0.5, 0.5);
            Matrix affineMatrix = builder.GetAffineMatrix();

            PolygonModelMock model = _scene.GetModel("CubeMock") as PolygonModelMock;
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
            DrawForm();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseIsDown = true;
            _prevCoordinates = new Point3D(XFromScreen(e.X),YFromScreen(e.Y),0);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseIsDown = false;
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_mouseIsDown) return;

            Point3D currentCoordinates = new Point3D(XFromScreen(e.X), YFromScreen(e.Y),0);

            Vector3D transferPosition = currentCoordinates - _prevCoordinates;
            _prevCoordinates = currentCoordinates;

            //Point3D newPosition = new Point3D(_camera.Position);
        }

        private double XFromScreen(int x)
        {
            return (double)x * (_painter.R - _painter.L) / Canvas.Width + _painter.L;
        }

        private double YFromScreen(int y)
        {
            return (double)y * (_painter.T - _painter.B) / Canvas.Height - _painter.T;
        }


    }
}
