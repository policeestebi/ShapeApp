using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeApp.Common;

namespace ShapeApp
{
    public class DonutCommand : Command
    {
        #region Constructor

        public DonutCommand()
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

            Arguments.Add(new ArgumentX { ExtraDesciption = "Centre X coordinate" });
            Arguments.Add(new ArgumentY { ExtraDesciption = "Centre Y coordinate" });
            Arguments.Add(new ArgumentRadius { ExtraDesciption = "Inner Radius " });
            Arguments.Add(new ArgumentRadius { ExtraDesciption = "Outer Radius " });

        }

       

        #endregion

        #region Properties

        public override string Name
        {
            get { return Constants.DONUT_NAME; }
        }

        #endregion

        #region Events

        #endregion

        #region Attributes

        #endregion
    }
}
