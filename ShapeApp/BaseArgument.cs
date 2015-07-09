using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeApp
{
    public abstract class BaseArgument
    {
        #region Constructor

        #endregion

        #region Methods

        #endregion

        #region Properties

        public abstract string Name { get; }

        public abstract string Desrption { get; }

        public string ExtraDesciption
        {
            get;
            set;
        }

        #endregion

        #region Events
        
        #endregion

        #region Attributes

        #endregion
    }
}
