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

namespace Lab2
{
    public partial class Form1 : Form
    {
        Painter painter;
        Scene scene;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            painter = new Painter(-2, 2, -2, 2, Canvas.Width, Canvas.Height);
            GraphicEngine gr = GraphicEngine.Instance;
            scene = gr.Scene;
            gr.OnProjectionChanged += OnProjectionChangedHandler;
            DrawForm();
            Affine4DimMatrixBuilder builder = new Affine4DimMatrixBuilder();
            builder.Transfer(-0.5, -0.5, 0.5);
            Matrix affineMatrix = builder.GetAffineMatrix();

            PolygonModelMock model = scene.GetModel("CubeMock") as PolygonModelMock;
            model.ChangeModel(affineMatrix);
        }

        private void DrawForm()
        {
            Bitmap bm = new Bitmap(Canvas.Width, Canvas.Height);
            painter.ReDraw(bm);
            Canvas.Image = bm;
        }

        private void OnProjectionChangedHandler()
        {
            DrawForm();
        }

    }
}
