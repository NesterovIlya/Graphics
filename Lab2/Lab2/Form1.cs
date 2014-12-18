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

namespace Lab2
{
    public partial class Form1 : Form
    {
        Painter painter;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            painter = new Painter(-5, 5, -5, 5, this.ClientSize.Width, this.ClientSize.Height);
            DrawForm();
        }

        private void DrawForm()
        {
            GraphicEngine gr = GraphicEngine.Instance;
            Bitmap bm = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            painter.ReDraw(bm, gr.CurrentProjection);
            this.BackgroundImage = bm;
        }
    }
}
