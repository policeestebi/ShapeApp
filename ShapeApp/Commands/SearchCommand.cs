using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShapeApp.Common;
using System.Text.RegularExpressions;

namespace ShapeApp
{
    public class SearchCommand:Command
    {
        #region Constructor

        #endregion

        #region Methods

        public override bool IsValid(string commandText)
        {
            if (!commandText.StartsWith(Name)) return false;

            if (String.IsNullOrEmpty(commandText)) return false;

            var regex = new Regex(this.Pattern);

            var match = regex.Match(commandText);

            if (!match.Success)
                throw new Exception("Unknow command line" + "\n\n" + "USE: " + GetHelp());

            return true;

        }

        public override void DefineArguments()
        {
            Arguments = new List<BaseArgument>();
            Arguments.Add(new ArgumentX { ExtraDesciption = "Coordinate X" });
            Arguments.Add(new ArgumentY { ExtraDesciption = "Coordinate Y" });
        }

        #endregion

        #region Properties

        public override string Name
        {
            get { return Constants.COMMAND_SEARCH; }
        }

        public String Pattern
        {
            get
            {
                return @"search(\s+[-]?[0-9]+(.[0-9]+)?){2}";
            }
        }

        #endregion

        #region Events

        #endregion

        #region Attributes

        #endregion
    }
}
