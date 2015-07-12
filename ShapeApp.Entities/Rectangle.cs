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

        }

        public Rectangle(string shapeDefinition)
            :base(shapeDefinition)
        {
        }

        #endregion

        #region Methods

        public override double GetArea()
        {
            return Side1 * Side2;
        }

        public override bool IsPointInside(Point point)
        {
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

        #endregion

        #region Properties

        public Point Corner { get; set; }

        public double Side1 { get; set; }

        public double Side2 { get; set; }

        #endregion

        #region Events

        #endregion

        #region Attributes

        #endregion
    }
}
