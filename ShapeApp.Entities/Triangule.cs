using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeApp.Common;
namespace ShapeApp.Entities
{
    public class Triangule: Shape
    {
        #region Constructor

        public Triangule(Point vertice1, Point vertice2, Point vertice3)
        {
            Vertice1 = vertice1;
            Vertice2 = vertice2;
            vertice3 = Vertice3;
        }

         public Triangule(string shapeDefinition)
            :base(shapeDefinition)
        {
        }

        #endregion

        #region Methods

         public override double GetArea()
         {
             //Tringle area based in 3 vertices
             //See for reference http://www.mathopenref.com/coordtrianglearea.html

             return Convert.ToDouble((Vertice1.X * (Vertice2.Y - Vertice3.Y) + Vertice2.X * (Vertice3.Y - Vertice1.Y) + Vertice3.X * (Vertice1.Y - Vertice2.Y)) / 2);
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

                 if (values == null || values.Length > 7) return;

                 var vetice1X = values[1];

                 var vetice1Y = values[2];

                 var vetice2X = values[3];

                 var vetice2Y = values[4];

                 var vetice3X = values[5];

                 var vetice3Y = values[6];


                 this.Vertice1 = new Point(decimal.Parse(vetice1X, System.Globalization.CultureInfo.InvariantCulture), decimal.Parse(vetice1Y, System.Globalization.CultureInfo.InvariantCulture));

                 this.Vertice2 = new Point(decimal.Parse(vetice2X, System.Globalization.CultureInfo.InvariantCulture), decimal.Parse(vetice2Y, System.Globalization.CultureInfo.InvariantCulture));

                 this.Vertice3 = new Point(decimal.Parse(vetice3X, System.Globalization.CultureInfo.InvariantCulture), decimal.Parse(vetice3Y, System.Globalization.CultureInfo.InvariantCulture));

                 

             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }

         public override string GetFormatString()
         {
             return String.Format("Triangle with vertice 1 at {0} and vertice 2 one {1} and vertice 3 {2}", Vertice1 != null ? Vertice1.ToString(): String.Empty, 
                                                                                                                           Vertice2 != null ? Vertice2.ToString(): String.Empty, 
                                                                                                                           Vertice3 != null ? Vertice3.ToString(): String.Empty);
         }

        #endregion

        #region Properties

        public Point Vertice1 { get; set; }
        public Point Vertice2 { get; set; }
        public Point Vertice3 { get; set; }

        #endregion

        #region Events

        #endregion

        #region Attributes

        #endregion
    }
}
