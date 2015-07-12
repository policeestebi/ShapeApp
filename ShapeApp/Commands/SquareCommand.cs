using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShapeApp.Common;

namespace ShapeApp
{
    public class SquareCommand : Command
    {

        #region Constructor

        public SquareCommand()
            : base()
        {

        }

        #endregion

        #region Methods

        public override bool IsValid(string commandText)
        {
            if (String.IsNullOrEmpty(commandText)) return false;

            if (!commandText.StartsWith(Name)) return false;

            var isValid = OnValid(commandText);

            if (!isValid)
                throw new Exception("Unknow command line" + "\n\n" + "USE: " + GetHelp());

            return isValid;
        }

        public override void DefineArguments()
        {
            Arguments = new List<BaseArgument>();

            Arguments.Add(new ArgumentX { ExtraDesciption = "Corner X coordinate" });
            Arguments.Add(new ArgumentY { ExtraDesciption = "Corner Y coordinate" });
            Arguments.Add(new ArgumentSide { ExtraDesciption = "Length of the side" });

        }

        #endregion

        #region Properties

        public override string Name
        {
            get { return Constants.SQUARE_NAME; }
        }

        #endregion

        #region Events

        #endregion

        #region Attributes

        #endregion

    }
}
