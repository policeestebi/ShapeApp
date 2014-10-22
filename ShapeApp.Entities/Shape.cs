using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeApp.Entities
{
    public abstract class Shape
    {

        #region Constructor

        #endregion

        #region Methods

        public abstract float GetArea();

        public abstract bool IsPointInside(Point point);

        public abstract bool IsValidData(string entry);

        #endregion

        #region Properties

        public string PatternEntry { get; set; }

        public string ShapeName { get; set; }
        
        #endregion

        #region Attributes
        
        #endregion

    }
}
