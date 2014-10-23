using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeApp.Common;

namespace ShapeApp.Entities
{
    public class Circle : Shape
    {

        #region Constructor

        public Circle(Point center, double radius)
            : base()
        {

            
        }

        #endregion

        #region Methods

        public override double GetArea()
        {
            throw new NotImplementedException();
        }

        public override bool IsPointInside(Point point)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Properties

        #endregion

        #region Attributes

        #endregion




        
    }
}
