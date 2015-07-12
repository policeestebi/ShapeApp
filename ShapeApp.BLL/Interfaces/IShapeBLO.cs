using System;
using System.Collections.Generic;
using ShapeApp.Entities;
namespace ShapeApp.BLL.Interfaces
{
    public interface IShapeBLO
    {
        Shape AddShape(string shapeDefinition);
        bool DeleteShape(int id);
        System.Collections.Generic.IList<Shape> GetShapesInsidePoint(Point point);
        bool IsValid(string shapeDefinition);
        IList<Shape> GetAllShapes();
        string LoadShapesFromFile(string path);
    }
}
