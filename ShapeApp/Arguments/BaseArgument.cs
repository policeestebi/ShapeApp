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

        /// <summary>
        /// Command's name.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Commands's Description
        /// </summary>
        public abstract string Desrption { get; }

        /// <summary>
        /// Extra information when it is defined to a command.
        /// </summary>
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
