using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Model;

namespace Lab2.Engine
{
    public class GraphicEngine
    {
        private static GraphicEngine _engineInstanse;
        private Scene _scene;

        private GraphicEngine()
        {
            _scene = new Scene();
        }

        public static GraphicEngine Instance
        {
            get
            {
                if (_engineInstanse == null) _engineInstanse = new GraphicEngine();
                return _engineInstanse;
            }
        }

        

    }
}
