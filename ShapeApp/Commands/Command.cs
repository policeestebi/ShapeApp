using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeApp
{
    public abstract class Command
    {
        public Command(){

            DefineArguments();

        }
        
        #region Constructor

        #endregion

        #region Methods

        public abstract bool IsValid(string commandText);

        public abstract void DefineArguments();

        public void ExecuteCommand(string commandText)
        {

            if (onExecute != null)
                onExecute(this, commandText);

        }

        public override string ToString()
        {
            var command = new StringBuilder();

            command.Append(Name + " ");

            if (Arguments != null)
            {

                Arguments.ToList().ForEach(c =>
                {

                    command.Append(c.Name + " ");

                }
                 );

            }

            return command.ToString();

        }

        public bool OnValid(string commandText)
        {
            var isValid = true;

            if (this.onValidate != null)
            {
                isValid = this.onValidate(this, commandText);
            }

            return isValid;
        }

        public string GetHelp()
        {
            var help = new StringBuilder();

            help.AppendLine(this.ToString());

            if (Arguments != null)
            {

                help.AppendLine("Where: ");

                Arguments.ToList().ForEach(c =>
                {

                    help.AppendFormat(c.Name + ": {0} ", c.ExtraDesciption );

                }
                 );

            }
            return help.ToString();

        }

        #endregion

        #region Properties

        public abstract string Name { get; }

        public IList<BaseArgument> Arguments
        {
            get;
            set;
        }

        #endregion

        #region Events

        public delegate bool OnValidate(object sender, string coommandText);
        public event OnValidate onValidate;

        public delegate void OnExecute(object sender, string commandText);
        public event OnExecute onExecute;

        #endregion

        #region Attributes

        #endregion

    }
}
