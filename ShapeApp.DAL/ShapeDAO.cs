using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeApp.Entities;
using System.Data;
using ShapeApp.DAL.Interfaces;

namespace ShapeApp.DAL
{
    public class ShapeDAO : IShapeDAO, IDisposable
    {

        public ShapeDAO()
        {
            CurrentId = 1;
            shapeCollection = new Dictionary<int, Shape>();
        }

        public bool Insert(Shape shape)
        {
            if (shape == null) throw new ArgumentNullException();

            if (shapeCollection == null) return false;

            shape.Id = CurrentId++;

            shapeCollection.Add(shape.Id, shape);

            return true;

        }

        public IList<Shape> GetShapesInsidePoint(Point point){

            try 
	        {	
                var shapes = new List<Shape>();

		        foreach (var item in shapeCollection)
	            {
		            if(item.Value.IsPointInside(point)){

                        shapes.Add(item.Value);

                    }
	            }

                return shapes;
	        }
	        catch (Exception)
	        {
		        throw new Exception("Error checking the point");
	        }

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

        private int CurrentId
        {
            get;
            set;
        }

        private IDictionary<int, Shape> shapeCollection;


        public void Dispose()
        {
            if (shapeCollection != null)
            {
                shapeCollection.Clear();
            }

            shapeCollection = null;
        }
    }
}
