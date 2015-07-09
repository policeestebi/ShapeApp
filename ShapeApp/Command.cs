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
            
        public abstract string Name { get; }
        public abstract bool IsValid(string commandText);
        public abstract void DefineArguments();
        
        public void ExecuteCommand(string commandText){

            if(onExecute != null)
                onExecute(this,commandText); 

        }

        public override string ToString()
        {
            var command = new StringBuilder();

            command.Append(Name + " ");

            if(Arguments != null){

                Arguments.ToList().ForEach( c =>
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
                isValid  = this.onValidate(this, commandText);
            }

            return isValid;
        }

        public abstract string GetHelp();

        public delegate bool OnValidate(object sender, string coommandText);
        public event OnValidate onValidate;

        public delegate void OnExecute(object sender,string commandText);
        public event OnExecute onExecute;

        public IList<BaseArgument> Arguments
        {
            get;set;
        }
    }
}
