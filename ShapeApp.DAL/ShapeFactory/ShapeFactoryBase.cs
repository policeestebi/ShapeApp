using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeApp.Entities;


namespace ShapeApp.DAL.ShapeFactory
{
    public abstract class ShapeFactoryBase
    {

        #region Constructor

        #endregion

        #region Methods

        public abstract Shape Create(string shapeDefinition);

        public abstract bool IsValid(string shapeDefinition);

        #endregion

        #region Properties

        #endregion

        #region Attributes

        #endregion

    }
}
