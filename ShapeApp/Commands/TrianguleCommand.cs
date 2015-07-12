using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeApp.Common;

namespace ShapeApp
{
    public class TrianguleCommand : Command
    {

        #region Constructor

        public TrianguleCommand()
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
                throw new Exception("Unknow command line" + "\n\n" + "USE: ");

            return isValid;
        }

        public override void DefineArguments()
        {
            Arguments = new List<BaseArgument>();

            Arguments.Add(new ArgumentX { ExtraDesciption = "Vertice 1 X coordinate" });
            Arguments.Add(new ArgumentY { ExtraDesciption = "Vertice 2 Y coordinate" });
            Arguments.Add(new ArgumentX { ExtraDesciption = "Vertice 1 X coordinate" });
            Arguments.Add(new ArgumentY { ExtraDesciption = "Vertice 2 Y coordinate" });
            Arguments.Add(new ArgumentX { ExtraDesciption = "Vertice 1 X coordinate" });
            Arguments.Add(new ArgumentY { ExtraDesciption = "Vertice 2 Y coordinate" });

        }

        #endregion

        #region Properties

        public override string Name
        {
            get { return Constants.TRIANGULE_NAME; }
        }

        #endregion

        #region Events

        #endregion

        #region Attributes

        #endregion

    }
}
