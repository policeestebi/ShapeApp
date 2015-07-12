using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShapeApp.Common;

namespace ShapeApp.Entities
{
    public class Square:Shape
    {
        #region Constructor

         public Square(Point corner, double side)
        {

            Corner = corner;
            Side = side;
        
        }

         public Square(string shapeDefinition)
            :base(shapeDefinition)
        {

        }

        #endregion

        #region Methods

         public override double GetArea()
         {
             return Side * Side;
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

                 if (values == null || values.Length > 4) return;

                 var cornerX = values[1];

                 var cornerY = values[2];

                 var side = values[3];

                 this.Corner = new Point(decimal.Parse(cornerX, System.Globalization.CultureInfo.InvariantCulture), decimal.Parse(cornerY, System.Globalization.CultureInfo.InvariantCulture));

                 this.Side = double.Parse(side, System.Globalization.CultureInfo.InvariantCulture);

             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }

         public override string GetFormatString()
         {
             return String.Format("Square with corner at {0} and side one {1}", Corner != null ? Corner.ToString(): String.Empty, Side.ToString());
         }

        #endregion

        #region Properties

        public Point Corner { get; set; }

        public double Side { get; set; }

        #endregion

        #region Events

        #endregion

        #region Attributes

        #endregion
    }
}
