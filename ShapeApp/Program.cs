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

            ShowMenu();

        }


        /// <summary>
        /// 
        /// </summary>
        public static void ShowMenu() { 
        
            ConsoleKeyInfo op;
            bool exit = false;

            do{
                
                Console.Clear();
                Console.WriteLine("Welcome to ShapeAppb \n\n");
                Console.WriteLine("1-Add a shape.");
                Console.WriteLine("2-Insert a point.");
                Console.WriteLine("3-List all shapes.");
                Console.WriteLine("4-Add data using a txt file.");
                Console.WriteLine("5-Help.");
                Console.WriteLine("5-Exit.");
                Console.WriteLine("\n\n");
                Console.Write("Enter: ");
                op = Console.ReadKey(false);

                exit = CheckOperation(op);
                

            }
            while(!exit);
        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="op"></param>
        /// <returns></returns>
        public static bool CheckOperation(ConsoleKeyInfo op) {

            if (op == null) return false;

            bool exit = false;

            switch (op.Key) { 
            
            
                case ConsoleKey.D5:
                    exit = true;
                    break;
                default:
                    break;
            
            }


            return exit;
        
        }

    }
}
