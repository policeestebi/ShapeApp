﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;

using ShapeApp.BLL;
using ShapeApp.BLL.Interfaces;
using ShapeApp.DAL;
using ShapeApp.DAL.Interfaces;
using ShapeApp.DAL.ShapeFactory;

namespace ShapeApp
{
    public class Bindings: NinjectModule
    {

        public override void Load()
        {
            Bind<IShapeDAO>().To<ShapeDAO>();
            Bind<IShapeFactory>().ToMethod(c =>
            {
                var shapeFactories = new List<ShapeFactoryBase>();
                shapeFactories.Add(new CircleFactory());
                shapeFactories.Add(new SquareFactory());
                shapeFactories.Add(new RectangleFactory());
                shapeFactories.Add(new TrianguleFactory());
                shapeFactories.Add(new DonutFactory());

                var shapeFactory = new ShapeFactory(shapeFactories);


                return shapeFactory;
            }
            
            );
            Bind<IShapeBLO>().To<ShapeBLO>();
        }

        private IShapeFactory BindShapeFactory()
        {
            var shapeFactories = new List<ShapeFactoryBase>();
            shapeFactories.Add(new CircleFactory());
            shapeFactories.Add(new SquareFactory());
            shapeFactories.Add(new RectangleFactory());
            shapeFactories.Add(new TrianguleFactory());
            shapeFactories.Add(new DonutFactory());

            var shapeFactory = new ShapeFactory(shapeFactories);


            return shapeFactory;
        }


    }
}
