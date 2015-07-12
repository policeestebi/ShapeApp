using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeApp.Entities;
using System.Text.RegularExpressions;


namespace ShapeApp.DAL.ShapeFactory
{
    public abstract class ShapeFactoryBase: IDisposable
    {

        #region Constructor

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shapeDefinition"></param>
        /// <returns></returns>
        public abstract Shape Create(string shapeDefinition);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shapeDefinition"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        public abstract string Pattern { get;}

        #endregion


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
