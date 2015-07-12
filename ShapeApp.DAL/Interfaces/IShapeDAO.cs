using System;
using System.Collections.Generic;
using ShapeApp.Entities;

namespace ShapeApp.DAL.Interfaces
{
    public interface IShapeDAO: IDisposable 
    {
        /// <summary>
        /// Deletes a shape.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);

        /// <summary>
        /// Inserts a shape.
        /// </summary>
        /// <param name="shape"></param>
        /// <returns></returns>
        bool Insert(ShapeApp.Entities.Shape shape);

        /// <summary>
        /// Gets the list of current shapes.
        /// </summary>
        /// <returns></returns>
        System.Collections.Generic.IEnumerable<Shape> List();

        /// <summary>
        /// Gets a list of shapes that contain a point.
        /// </summary>
        /// <param name="point">Point</param>
        /// <returns>List of shapes.</returns>
        IList<Shape> GetShapesInsidePoint(Point point);
    }
}
