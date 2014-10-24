using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeApp.DAL.ShapeFactory;
using ShapeApp.DAL;
using ShapeApp.DAL.Interfaces;

namespace ShapeApp.BLL
{
    public class ShapeBLO
    {
        #region Constructor

        public ShapeBLO(ShapeDAO shape,IShapeFactory shapeFactory)
        {
            ShapeDAO = shape;
            ShapeFactory = shapeFactory;
        }

        public ShapeBLO()
        {
            ShapeDAO = ShapeDAO.Instance;
            ShapeFactory = new ShapeFactory();
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shapeDefinition"></param>
        /// <returns></returns>
        public bool AddShape(string shapeDefinition)
        {
            if(ShapeDAO == null || ShapeFactory == null) return false;

            var shape = ShapeFactory.CreateShape(shapeDefinition);

            if (shape == null) return false;

            return ShapeDAO.Insert(shape);
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
        public ShapeDAO ShapeDAO { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IShapeFactory ShapeFactory { get; set; }

    }
}
