using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ShapeApp.Entities
{
    public abstract class Shape
    {

        #region Constructor

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract double GetArea();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public abstract bool IsPointInside(Point point);

       

        #endregion

        #region Properties

        public int Id { get; set; }
     
        #endregion

        #region Attributes

        #endregion

    }
}
