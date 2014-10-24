using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeApp.DAL.ShapeFactory;
using ShapeApp.DAL;

namespace ShapeApp.BLL
{
    public class ShapeBLO
    {
        #region Constructor

        public ShapeBLO(ShapeDAO shape)
        {
            ShapeDAO = shape;
        }

        public ShapeBLO()
        {
            ShapeDAO = ShapeDAO.Instance;
        }

        #endregion


        public bool AddShape(string shapeDefinition)
        {
            
        }


        public ShapeDAO ShapeDAO { get; set; }

    }
}
