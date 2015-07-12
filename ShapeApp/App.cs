﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeApp.BLL.Interfaces;
using ShapeApp.Common;
using ShapeApp.Entities;

namespace ShapeApp
{
    public class App: IDisposable
    {
        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shapeBlo"></param>
        public App(IShapeBLO shapeBlo)
        {
            if (shapeBlo == null) throw new ArgumentNullException("shapeBlo");

            ShapeBlo = shapeBlo;

            InitComponents();
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
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
            var listCommand = new ListCommand();
            var searchCommand = new SearchCommand();

            circleCommand.onExecute += onExecute;
            circleCommand.onValidate += onValidate;

            squareCommand.onExecute += onExecute;
            squareCommand.onValidate += onValidate;

            rectanguleCommand.onExecute += onExecute;
            rectanguleCommand.onValidate += onValidate;

            triangleCommand.onExecute += onExecute;
            triangleCommand.onValidate += onValidate;

            donutCommand.onExecute += onExecute;
            donutCommand.onValidate += onValidate;

            helpCommand.onExecute += helpCommand_onExecute;

            exitCommand.onExecute += exitCommand_onExecute;

            listCommand.onExecute += listCommand_onExecute;

            searchCommand.onExecute += searchCommand_onExecute;

            Commands = new List<Command>();
            Commands.Add(circleCommand);
            Commands.Add(rectanguleCommand);
            Commands.Add(squareCommand);
            Commands.Add(triangleCommand);
            Commands.Add(donutCommand);
            Commands.Add(listCommand);
            Commands.Add(searchCommand);
            Commands.Add(helpCommand);
            Commands.Add(exitCommand);

            //Add Initial Data 

            ExecuteOperation("circle 1.7 -5.05 6.9");
            ExecuteOperation("square 3.55 4.1 2.77");
            ExecuteOperation("rectangle 3.5 2.0 5.6 7.2");
            ExecuteOperation("triangle 4.5 1 -2.5 -33 23 0.3");
            ExecuteOperation("donut 4.5 7.8 1.5 1.8");

        }

       
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
       
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textCommand"></param>
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
        public IShapeBLO ShapeBlo { get; set; }

        #endregion

        #region Events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="commandText"></param>
        private void searchCommand_onExecute(object sender, string commandText)
        {
            try
            {

                var values = commandText.Split(Constants.CHARACTER_SEPARATOR);

                if (values == null || values.Length > 3) return;

                var x = values[1];
                var y = values[2];

                var shapes = ShapeBlo.GetShapesInsidePoint(new Point(

                        decimal.Parse(x, System.Globalization.CultureInfo.InvariantCulture),
                        decimal.Parse(y, System.Globalization.CultureInfo.InvariantCulture)
                    
                    ));

                if (shapes == null) return;

                var listText = new StringBuilder();

                foreach (var shape in shapes)
                {
                    listText.AppendLine(shape.ToString());
                    listText.AppendFormat("Area {0} \n\n",shape.GetArea().ToString("N2"));
                }

                listText.AppendFormat("Total Area: {0}",shapes.Sum(c => c.GetArea()).ToString("N2"));

                Message = listText.ToString();

            }
            catch (Exception)
            {
                Message = "Error occured searching the point. Please try again";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="commandText"></param>
        private void helpCommand_onExecute(object sender, string commandText)
        {
            try
            {
                Message = ShowHelp();
            }
            catch (Exception)
            {
                Message = "Error occurred during the execution of this command. Please try again.";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="coommandText"></param>
        /// <returns></returns>
        public bool onValidate(object sender, string coommandText)
        {
            return ShapeBlo.IsValid(coommandText);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="commandText"></param>
        public void onExecute(object sender, string commandText)
        {
            var shape = ShapeBlo.AddShape(commandText);

            if (shape == null)
            {
                Message = "Shape not created";
                return;
            }

            Message = shape.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="commandText"></param>
        private void exitCommand_onExecute(object sender, string commandText)
        {
            Continue = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="commandText"></param>
        private void listCommand_onExecute(object sender, string commandText)
        {
            var shapes = ShapeBlo.GetAllShapes();

            if (shapes == null) return;

            var listText = new StringBuilder();

            foreach (var shape in shapes)
            {
                listText.AppendLine(shape.ToString()); 
            }

            Message = listText.ToString();

        }

        #endregion

        #region Attributes

        #endregion


        public void Dispose()
        {
            
        }
    }
}
