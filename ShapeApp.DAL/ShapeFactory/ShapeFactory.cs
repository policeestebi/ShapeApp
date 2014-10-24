using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeApp.Entities;
using ShapeApp.DAL.Interfaces;

namespace ShapeApp.DAL.ShapeFactory
{
    public class ShapeFactory : IShapeFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public ShapeFactory()
        {
            Factories = new List<ShapeFactoryBase>{
                               new CircleFactory()
                            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shapeDefinition"></param>
        /// <returns></returns>
        public bool IsValid(string shapeDefinition)
        {
            if (string.IsNullOrEmpty(shapeDefinition)) throw new ArgumentNullException();

            foreach (var factory in Factories)
            {
                if (factory.IsValid(shapeDefinition));
                    return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shapeDefinition"></param>
        /// <returns></returns>
        public Shape CreateShape(string shapeDefinition)
        {
            foreach (var factory in Factories)
            {
                var shape = factory.Create(shapeDefinition);

                if (shape != null) return shape;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<ShapeFactoryBase> Factories{get;set;}

    }
}
