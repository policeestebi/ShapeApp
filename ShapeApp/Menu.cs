using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeApp
{
    public class Menu
    {
        #region Constructor

        public Menu()
        {
            InitComponents();
        }

        #endregion

        #region Methods

        private void InitComponents()
        {
            Continue = true;

            var circleCommand = new CircleCommand();
            var squareCommand = new SquareCommand();
            var rectanguleCommand = new RectanguleCommand();
            var triangleCommand = new TrianguleCommand();
            var donutCommand = new DonutCommand();
            var helpCommand = new HelpCommand();
            var exitCommand = new ExitCommand();

            circleCommand.onExecute +=circleCommand_onExecute;
            circleCommand.onValidate +=circleCommand_onValidate;

            squareCommand.onExecute += squareCommand_onExecute;         
            squareCommand.onValidate += squareCommand_onValidate;

            rectanguleCommand.onExecute +=rectangule_onExecute;
            rectanguleCommand.onValidate +=rectangule_onValidate;

            triangleCommand.onExecute +=triangle_onExecute;
            triangleCommand.onValidate += triangle_onValidate;

            donutCommand.onExecute += donut_onExecute;
            donutCommand.onValidate += donut_onValidate;

            helpCommand.onExecute += helpCommand_onExecute;

            exitCommand.onExecute += exitCommand_onExecute;


            Commands = new List<Command>();
            Commands.Add(circleCommand);
            Commands.Add(rectanguleCommand);
            Commands.Add(squareCommand);
            Commands.Add(triangleCommand);
            Commands.Add(donutCommand);
            Commands.Add(helpCommand);
            Commands.Add(exitCommand);

        }

      


        public String ShowHelp()
        {

            if (Commands == null) return string.Empty;

            var help = new StringBuilder();

            Commands.ToList().ForEach(

                    c =>
                    {
                        help.AppendLine(c.GetHelp() + "\n");
                    }

                );

            return help.ToString();

        }
       

        public String ShowMenu()
        {
            var options = new StringBuilder();

            options.AppendLine("\t\t-------------------------------------------------");
            options.AppendLine("\t\t--------------Welcome to Shape App---------------");
            options.AppendLine("\t\t----------By Esteban Ramirez González------------");
            options.AppendLine("\t\t-------------------------------------------------");
            options.AppendLine("\n");

            Commands.ToList().ForEach(
                    c =>
                    {
                        options.AppendLine("-- " + c.ToString());
                    }
                );


            if (!string.IsNullOrEmpty(Message))
            {
                options.AppendLine("\n");
                options.AppendLine(Message);
            }

            Message = string.Empty;

            return options.ToString();

        }

        public void Run()
        {
            string op;

            do{
                Console.Clear();
                Console.WriteLine(ShowMenu());
                Console.Write("Enter: ");
                op = Console.ReadLine();
                op = op.Trim().ToLower();
                ExecuteOperation(op);

            } while (Continue);
        }

        private void ExecuteOperation(string textCommand)
        {
            try
            {

                foreach (var command in Commands)
                {
                    if (command.IsValid(textCommand))
                    {
                        command.ExecuteCommand(textCommand);
                        return;
                    }
                }

                Message = "Command does not exist";

            }
            catch (Exception ex)
            {
                Message = ex.Message;       
            }

        }

        

        #endregion

        #region Properties

        public IList<Command> Commands { get; set; }
        public bool Continue { get; set; }
        public string Message { get; set; }

        #endregion

        #region Events

        public void helpCommand_onExecute(object sender, string commandText)
        {
            try
            {
                Message = ShowHelp();
            }
            catch (Exception ex)
            {
                Message = "Error occurred during the execution of this command. Please try again.";
            }
        }

        public void exitCommand_onExecute(object sender, string commandText)
        {
            Continue = false;
        }

        bool donut_onValidate(object sender, string coommandText)
        {
            throw new NotImplementedException();
        }

        private void donut_onExecute(object sender, string commandText)
        {
            throw new NotImplementedException();
        }

        private bool triangle_onValidate(object sender, string coommandText)
        {
            throw new NotImplementedException();
        }

        private void triangle_onExecute(object sender, string commandText)
        {
            throw new NotImplementedException();
        }

        private bool rectangule_onValidate(object sender, string coommandText)
        {
            throw new NotImplementedException();
        }

        private void rectangule_onExecute(object sender, string commandText)
        {
            throw new NotImplementedException();
        }

        private bool squareCommand_onValidate(object sender, string coommandText)
        {
            throw new NotImplementedException();
        }

        private void squareCommand_onExecute(object sender, string commandText)
        {
            throw new NotImplementedException();
        }

        private bool circleCommand_onValidate(object sender, string coommandText)
        {
            throw new NotImplementedException();
        }

        private void circleCommand_onExecute(object sender, string commandText)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Attributes

        #endregion

    }
}
