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

        /// <summary>
        /// Is a the command text valid for this command
        /// </summary>
        /// <param name="commandText">Command Text</param>
        /// <returns>True is the command is valid, otherwise false.</returns>
        public abstract bool IsValid(string commandText);

        /// <summary>
        /// Defines the arguments for the command.
        /// </summary>
        public abstract void DefineArguments();

        /// <summary>
        /// Executes the command. It uses the OnExecute Event.
        /// </summary>
        /// <param name="commandText">Command Text being executed.</param>
        public void ExecuteCommand(string commandText)
        {
            if (onExecute != null)
                onExecute(this, commandText);
        }

        /// <summary>
        /// Override String to show a custom format.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public bool OnValid(string commandText)
        {
            var isValid = true;

            if (this.onValidate != null)
            {
                isValid = this.onValidate(this, commandText);
            }

            return isValid;
        }

        /// <summary>
        /// Gets the command's help info.
        /// </summary>
        /// <returns>Help for the command.</returns>
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

        /// <summary>
        /// Command's name.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Command's arguments
        /// </summary>
        public IList<BaseArgument> Arguments
        {
            get;
            set;
        }

        #endregion

        #region Events

        /// <summary>
        /// Delegate for validation.
        /// </summary>
        /// <param name="sender">The current object.</param>
        /// <param name="coommandText">Command text being executed.</param>
        /// <returns>True if it's valid, otherwise false.</returns>
        public delegate bool OnValidate(object sender, string coommandText);

        /// <summary>
        /// Event for the OnValidate.
        /// </summary>
        public event OnValidate onValidate;

        /// <summary>
        /// Delegate for Executing
        /// </summary>
        /// <param name="sender">The current object.</param>
        /// <param name="commandText">Command text being executed.</param>
        public delegate void OnExecute(object sender, string commandText);
        /// <summary>
        /// Event for onExecute
        /// </summary>
        public event OnExecute onExecute;

        #endregion

        #region Attributes

        #endregion

    }
}
