using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeApp.Common;

namespace ShapeApp.Entities
{
    public class Rectangle:Shape
    {
        #region Constructor

         public Rectangle(Point corner, double side1, double side2)
        {

            Corner = corner;
            Side1 = side1;
            Side2 = side2;
            CalculateCorners();

        }

        public Rectangle(string shapeDefinition)
            :base(shapeDefinition)
        {
            CalculateCorners();

        }

        #endregion

        #region Methods

        public override double GetArea()
        {
            return Side1 * Side2;
        }

        public override bool IsPointInside(Point point)
        {
            //Calcule the four areas of the triangule
            //Check this link for reference
            //http://www.emanueleferonato.com/2012/03/09/algorithm-to-determine-if-a-point-is-inside-a-square-with-mathematics-no-hit-test-involved/

            var trianguleA = new Triangle(Corner,Corner2,point);
            var trianguleB = new Triangle(Corner2,Corner3,point);
            var trianguleC = new Triangle(Corner3,Corner4,point);
            var trianguleD = new Triangle(Corner4,Corner,point);

            if (trianguleA.GetAreaNotAbs() > 0 ||
                trianguleB.GetAreaNotAbs() > 0 ||
                trianguleC.GetAreaNotAbs() > 0 ||
                trianguleD.GetAreaNotAbs() > 0)
                return false;

            return true;

        }

        public override void CreateShapeBaseOnText(string shapeDefinition)
        {
            try
            {

                if (String.IsNullOrEmpty(shapeDefinition)) return;

                var values = shapeDefinition.Split(Constants.CHARACTER_SEPARATOR);

                if (values == null || values.Length > 5) return;

                var cornerX = values[1];

                var cornerY = values[2];

                var side1 = values[3];

                var side2 = values[4];

                this.Corner = new Point(decimal.Parse(cornerX, System.Globalization.CultureInfo.InvariantCulture), decimal.Parse(cornerY, System.Globalization.CultureInfo.InvariantCulture));

                this.Side1 = double.Parse(side1, System.Globalization.CultureInfo.InvariantCulture);

                this.Side2 = double.Parse(side2, System.Globalization.CultureInfo.InvariantCulture);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override string GetFormatString()
        {
            return String.Format("Rectangule with corner at {0} and side one {1} and side 2 {2}",  Corner != null ? Corner.ToString() : String.Empty, Side1.ToString(), Side2.ToString());
        }

        private void CalculateCorners()
        {
            Corner2 = new Point(Convert.ToDecimal(Corner.X + Convert.ToDecimal(Side2)), Corner.Y);
            Corner3 = new Point(Corner2.X, Convert.ToDecimal(Corner2.Y - Convert.ToDecimal(Side1)));
            Corner4 = new Point(Corner.X, Convert.ToDecimal(Corner.Y - Convert.ToDecimal(Side1)));
        }



        #endregion

        #region Properties

        public Point Corner { get; set; }

        public Point Corner2 { get; set; }

        public Point Corner3 { get; set; }

        public Point Corner4 { get; set; }

        /// <summary>
        /// Height
        /// </summary>
        public double Side1 { get; set; }


        /// <summary>
        /// Width
        /// </summary>
        public double Side2 { get; set; }

        #endregion

        #region Events

        #endregion

        #region Attributes

        #endregion
    }
}
