using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new Menu();

            menu.Run();

        }


        /// <summary>
        /// 
        /// </summary>
        public static void ShowMenu() { 
        
            string op;
            bool exit = false;

            do{
                
                Console.Clear();
                Console.WriteLine("\t\t\tWelcome to ShapeAppb \n\n");
                Console.WriteLine("1-Add a shape.");
                Console.WriteLine("2-Insert a point.");
                Console.WriteLine("3-List all shapes.");
                Console.WriteLine("4-Add data using a txt file.");
                Console.WriteLine("5-Help.");
                Console.WriteLine("6-Exit.");
                Console.WriteLine("\n\n");
                Console.Write("Enter: ");
                op = Console.ReadLine();

                op = op.ToLower();

                exit = CheckOperation(op);
                

            }
            while(!exit);
        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="op"></param>
        /// <returns></returns>
        public static bool CheckOperation(string op) {

            return true;
            /*if (op == null) return false;

            bool exit = false;

            switch (op. { 
            
            
                case ConsoleKey.NumPad6:
                    exit = true;
                    break;
                default:
                    break;
            
            }


            return exit;*/
        
        }

    }
}
