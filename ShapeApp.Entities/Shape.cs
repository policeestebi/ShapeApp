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

        /// <summary>
        /// 
        /// </summary>
        public Shape()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shapeDefinition"></param>
        public Shape(string shapeDefinition)
        {
            CreateShapeBaseOnText(shapeDefinition);
        }

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shapeDefinition"></param>
        /// <returns></returns>
        public abstract void CreateShapeBaseOnText(string shapeDefinition);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract string GetFormatString();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("Shape {0}: {1} ", Id.ToString(), GetFormatString());
        }

        #endregion

        #region Properties

        public int Id { get; set; }
     
        #endregion

        #region Attributes

        #endregion

    }
}
