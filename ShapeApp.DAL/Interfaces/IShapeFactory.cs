using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeApp.Entities;
using ShapeApp.DAL.ShapeFactory;

namespace ShapeApp.DAL.Interfaces
{
    public interface IShapeFactory
    {
        bool IsValid(string shapeDefinition);

        Shape CreateShape(string shapeDefinition);

        public IEnumerable<ShapeFactoryBase> Factories { get; set; }
    }
}
