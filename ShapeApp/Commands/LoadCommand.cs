using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeApp.Common;

namespace ShapeApp
{
    public class LoadCommand: Command
    {
        #region Constructor

        #endregion

        #region Methods

        public override bool IsValid(string commandText)
        {
            if (String.IsNullOrEmpty(commandText)) return false;

            if (!commandText.StartsWith(Name)) return false;

            var isValid = commandText.Split(Constants.CHARACTER_SEPARATOR).Length == 2;

            if (!isValid)
                throw new Exception("Unknow command line" + "\n\n" + "USE: " + GetHelp());

            return isValid;
        }

        public override void DefineArguments()
        {
            Arguments = new List<BaseArgument>();

            Arguments.Add(new ArgumentPath { ExtraDesciption = "File Path" });
           
        }

        #endregion

        #region Properties

        public override string Name
        {
            get { return Constants.COMMAND_LOAD; }
        }

        #endregion

        #region Events

        #endregion

        #region Attributes

        #endregion
    }
}
