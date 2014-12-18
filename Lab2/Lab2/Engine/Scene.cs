using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Model;

namespace Lab2.Engine
{
    public class Scene
    {
        private Dictionary<string, IModel> _objects;

        public Scene()
        {
            _objects = new Dictionary<string, IModel>();
        }

        public void Add(IModel model)
        {
            _objects.Add(model.Name, model);
        }

        public bool GetModel(string name, out IModel model)
        {
            return _objects.TryGetValue(name,out model);
        }

        public void Clear()
        {
            _objects.Clear();
        }
    }
}
