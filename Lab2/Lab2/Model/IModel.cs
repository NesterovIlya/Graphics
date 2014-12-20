using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.MatrixLib;

namespace Lab2.Model
{
    public interface IModel
    {
        string Name
        { get; }

        Matrix WorldCoordinates
        { get; }

        void ChangeModel(Matrix affineMatrix);
    }
}
