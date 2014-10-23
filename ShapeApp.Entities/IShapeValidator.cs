using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeApp.Entities
{
    public interface IShapeValidator
    {

        bool ValidateEntry(string entry);

        string Pattern { get; }

    }
}
