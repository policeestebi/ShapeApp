using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeApp.Entities;
using ShapeApp.DAL.ShapeFactory;

namespace ShapeApp.DAL.Interfaces
{
    public interface IShapeFactory:IDisposable
    {
        /// <summary>
        /// Checks if the shapeDefinition is valid.
        /// </summary>
        /// <param name="shapeDefinition">String with the shape definition.</param>
        /// <returns></returns>
        bool IsValid(string shapeDefinition);

        /// <summary>
        /// Creates a new shape based on a shape definition.
        /// </summary>
        /// <param name="shapeDefinition">String with the shape definition.</param>
        /// <returns></returns>
        Shape CreateShape(string shapeDefinition);

        /// <summary>
        /// List of the factories.
        /// </summary>
        IEnumerable<ShapeFactoryBase> Factories { get; set; }
    }
}
