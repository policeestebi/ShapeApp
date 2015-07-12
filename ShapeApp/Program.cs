using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using ShapeApp.BLL.Interfaces;
using System.Reflection;

namespace ShapeApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            var shapeBll = kernel.Get<IShapeBLO>();

            var menu = new App(shapeBll);
            menu.Run();

        }

    }
}
