using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeApp.Entities
{
    public struct Point
    {

        public Point(decimal x, decimal y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return String.Format("({0} , {1})", X.ToString(), Y.ToString());
        }

        public decimal X { get; set; }
        public decimal Y { get; set; }

    }
}
