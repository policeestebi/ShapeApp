using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeApp.Entities;
using System.Data;

namespace ShapeApp.DAL
{
    public class ShapeDAO
    {

        protected ShapeDAO()
        {
            currentId = 1;
            shapeCollection = new Dictionary<int, Shape>();
        }


        public ShapeDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ShapeDAO();

                return instance;
            }
        }

        public bool Insert(Shape shape)
        {
            if (shape == null) throw new ArgumentNullException();

            if (shapeCollection == null) return false;

            shape.Id = currentId++;

            shapeCollection.Add(shape.Id, shape);

            return true;

        }

        public bool Delete(int id)
        {
            if (shapeCollection == null) return false;

            return shapeCollection.Remove(id);
        }

        public IEnumerable<Shape> List()
        {
            return shapeCollection.Select(c => c.Value).ToList();
        }

        private static ShapeDAO instance;

        private int currentId;

        private IDictionary<int, Shape> shapeCollection; 

    }
}
