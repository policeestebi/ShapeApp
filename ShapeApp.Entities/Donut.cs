using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeApp.Common;

namespace ShapeApp.Entities
{
    public class Donut:Shape
    {
        #region Constructor

        public Donut(Point centre, double radius1, double radius2)
        {

            Centre = centre;
            Radius1 = radius1;
            Radius2 = radius2;

        }

         public Donut(string shapeDefinition)
            :base(shapeDefinition)
        {
        }

        #endregion

        #region Methods

        public override double GetArea()
        {
            var area1 = Math.PI * Radius1 * Radius1;
            var area2 = Math.PI * Radius2 * Radius2;

            if(area1 > area2)
                return area1 -area2;
            else
                return area2-area1;
        }

        public override bool IsPointInside(Point point)
        {
            var innerCircle = new Circle(Centre, Radius1);
            var outerCicle = new Circle(Centre, Radius2);

            if (innerCircle.IsPointInside(point)) return false;

            if (outerCicle.IsPointInside(point)) return true;

            return false;
        }

        public override void CreateShapeBaseOnText(string shapeDefinition)
        {
            try
            {

                if (String.IsNullOrEmpty(shapeDefinition)) return;

                var values = shapeDefinition.Split(Constants.CHARACTER_SEPARATOR);

                if (values == null || values.Length > 5) return;

                //X Center point
                var centerX = values[1];

                var centerY = values[2];

                var radius = values[3];

                var radius2 = values[4];

                this.Centre = new Point(decimal.Parse(centerX, System.Globalization.CultureInfo.InvariantCulture), decimal.Parse(centerY, System.Globalization.CultureInfo.InvariantCulture));

                this.Radius1 = double.Parse(radius, System.Globalization.CultureInfo.InvariantCulture);

                this.Radius2 = double.Parse(radius2, System.Globalization.CultureInfo.InvariantCulture);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override string GetFormatString()
        {
            return String.Format("Donut with centre at {0} and radius one {1} and radius {2}",(Centre != null ? Centre.ToString() : String.Empty), 
                                                                                                                Radius1.ToString() , 
                                                                                                                Radius2.ToString());
        }

        #endregion

        #region Properties

        public Point Centre { get; set; }

        /// <summary>
        /// Smallest one
        /// </summary>
        public double Radius1 { get; set; }

        /// <summary>
        /// Largest one
        /// </summary>
        public double Radius2 { get; set; }

        #endregion

        #region Events

        #endregion

        #region Attributes


        #endregion
    }
}
