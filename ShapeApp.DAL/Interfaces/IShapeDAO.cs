using System;
using System.Collections.Generic;
using ShapeApp.Entities;

namespace ShapeApp.DAL.Interfaces
{
    public interface IShapeDAO
    {
        bool Delete(int id);
        bool Insert(ShapeApp.Entities.Shape shape);
        System.Collections.Generic.IEnumerable<Shape> List();
        IList<Shape> GetShapesInsidePoint(Point point);
    }
}
