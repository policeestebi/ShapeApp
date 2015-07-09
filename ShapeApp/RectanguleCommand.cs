using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeApp.Common;

namespace ShapeApp
{
    public class RectanguleCommand : Command
    {

        #region Constructor

        public RectanguleCommand():base()
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

            Arguments.Add(new ArgumentX());
            Arguments.Add(new ArgumentY());
            Arguments.Add(new ArgumentCentre());
            Arguments.Add(new ArgumentRadius());

        }

        #endregion

        #region Properties

        public override string Name
        {
            get { return Constants.RECTANGULE_NAME; }
        }

        #endregion

        #region Events

        #endregion

        #region Attributes

        #endregion






        public override string GetHelp()
        {
            throw new NotImplementedException();
        }
    }
}
