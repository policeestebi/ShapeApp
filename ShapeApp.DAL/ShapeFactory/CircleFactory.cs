using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeApp.Entities;

namespace ShapeApp.DAL.ShapeFactory
{
    public class CircleFactory : ShapeFactoryBase
    {
        public override Shape Create(string shapeDefinition)
        {
            if (!IsValid(shapeDefinition)) return null;

            return new Circle(shapeDefinition);

        }

        public override string Pattern
        {
            get { return @"circle(\s+[-]?[0-9]+(.[0-9]+)?){2}\s+[0-9]+(.[0-9]+)?"; }

            //circle\s+([-]?[0-9]+[.[0-9]+]?\s+){2}[0-9]+[.[0-9]+]?
            //circle(\s+[-]?[0-9]+[.[0-9]+]?){2}\s+[0-9]+[.[0-9]+]?

            //circle\s+[0-9]+[.[0-9]+]?\s+[0-9]+[.[0-9]+]?\s+[0-9]+[.[0-9]+]?"
        }
    }
}
