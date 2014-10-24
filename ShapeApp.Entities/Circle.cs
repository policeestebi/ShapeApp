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

            Center = center;
            Radius = radius;
        }

        public Circle(string shapeDefinition)
            :base(shapeDefinition)
        {
        }

        #endregion

        #region Methods

        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override bool IsPointInside(Point point)
        {
            throw new NotImplementedException();
        }

        public override void CreateShapeBaseOnText(string shapeDefinition)
        {
            try
            {

                if (String.IsNullOrEmpty(shapeDefinition)) return;

                var values = shapeDefinition.Split(Constants.CHARACTER_SEPARATOR);

                if (values == null || values.Length == 4) return;

                //X Center point
                var centerX = values[1];

                var centerY = values[2];

                var radius = values[3];

                this.Center = new Point(Convert.ToDecimal(centerX), Convert.ToDecimal(centerY));

                Radius = Convert.ToDouble(radius) ;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public override string GetFormatString()
        {
            return String.Format("Circle with centre at {0} and radius {1}", Center.ToString(), Radius.ToString());
        }

        #endregion

        #region Properties

        public double Radius { get; set; }

        public Point Center { get; set; }

        #endregion

        #region Attributes

        #endregion








       
    }
}
