using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShapeApp.Entities;

namespace ShapeApp.DAL.ShapeFactory
{
    public class RectangleFactory : ShapeFactoryBase
    {

        #region Constructor

        #endregion

        #region Methods

        public override Shape Create(string shapeDefinition)
        {
            if (!IsValid(shapeDefinition)) return null;

            return new Rectangle(shapeDefinition);

        }

        #endregion

        #region Properties

        public override string Pattern
        {
            get { return @"rectangle(\s+[-]?[0-9]+(.[0-9]+)?){2}(\s+[0-9]+(.[0-9]+)?){2}"; }

        }

        #endregion

        #region Events

        #endregion

        #region Attributes

        #endregion

     
    }
}
