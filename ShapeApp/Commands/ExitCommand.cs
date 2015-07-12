using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeApp.Common;

namespace ShapeApp
{
    public class ExitCommand : Command
    {

        #region Constructor

        #endregion

        #region Methods

        public override bool IsValid(string commandText)
        {
            if (String.IsNullOrEmpty(commandText)) return false;

            return commandText.Equals(Name);
        }

        public override void DefineArguments()
        {
            Arguments = new List<BaseArgument>();

           

        }

        #endregion

        #region Properties

        public override string Name
        {
            get { return Constants.COMMAND_EXIT ; }
        }

        #endregion

        #region Events

        #endregion

        #region Attributes

        #endregion

    }
}
