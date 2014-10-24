using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeApp.Entities;
using System.Text.RegularExpressions;


namespace ShapeApp.DAL.ShapeFactory
{
    public abstract class ShapeFactoryBase
    {

        #region Constructor

        #endregion

        #region Methods

        public abstract Shape Create(string shapeDefinition);

        public bool IsValid(string shapeDefinition)
        {
            if (String.IsNullOrEmpty(shapeDefinition)) throw new ArgumentNullException();

            var regex = new Regex(this.Pattern);

            var match = regex.Match(shapeDefinition);

            if (match.Success) return true;

            return false;
        }

        #endregion

        #region Properties

        #endregion

        #region Attributes

        public abstract string Pattern { get;}

        #endregion

    }
}
