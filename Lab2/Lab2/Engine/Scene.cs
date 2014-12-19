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

        public IModel GetModel(string name)
        {
            IModel model;
            if (_objects.TryGetValue(name, out model)) return model;
            else throw new KeyNotFoundException();
        }

        public void Clear()
        {
            _objects.Clear();
        }
    }
}
