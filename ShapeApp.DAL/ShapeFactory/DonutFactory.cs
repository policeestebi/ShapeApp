using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeApp.Entities;

namespace ShapeApp.DAL.ShapeFactory
{
    public class DonutFactory : ShapeFactoryBase
    {
        #region Constructor

        public override Shape Create(string shapeDefinition)
        {
            if (!IsValid(shapeDefinition)) return null;

            return new Donut(shapeDefinition);

        }

        #endregion

        #region Methods

        #endregion

        #region Properties

        public override string Pattern
        {
            get { return @"donut(\s+[-]?[0-9]+(.[0-9]+)?){2}(\s+[0-9]+(.[0-9]+)?){2}"; }
        }

         

        #endregion

        #region Events

        #endregion

        #region Attributes

        #endregion
    }
}
