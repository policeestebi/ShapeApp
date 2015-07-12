using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeApp.DAL.ShapeFactory;
using ShapeApp.DAL;
using ShapeApp.DAL.Interfaces;
using ShapeApp.Entities;


namespace ShapeApp.BLL
{
    public class ShapeBLO : ShapeApp.BLL.Interfaces.IShapeBLO
    {
        #region Constructor

        public ShapeBLO(IShapeDAO shape,IShapeFactory shapeFactory)
        {
            ShapeDAO = shape;
            ShapeFactory = shapeFactory;
        }

        
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shapeDefinition"></param>
        /// <returns></returns>
        public Shape AddShape(string shapeDefinition)
        {
            if(ShapeDAO == null || ShapeFactory == null) return null;

            var shape = ShapeFactory.CreateShape(shapeDefinition);

            if (shape == null) return null;

            ShapeDAO.Insert(shape);

            return shape;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteShape(int id)
        {
            if (ShapeDAO == null) return false;

            return ShapeDAO.Delete(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public IList<Shape> GetShapesInsidePoint(Point point)
        {
            return ShapeDAO.GetShapesInsidePoint(point);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shapeDefinition"></param>
        /// <returns></returns>
        public bool IsValid(string shapeDefinition)
        {
            if (ShapeFactory == null) return false;

            return ShapeFactory.IsValid(shapeDefinition);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<Shape> GetAllShapes()
        {
            return ShapeDAO.List().ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        public IShapeDAO ShapeDAO { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IShapeFactory ShapeFactory { get; set; }

    }
}
