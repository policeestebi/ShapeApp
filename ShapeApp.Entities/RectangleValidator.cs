using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ShapeApp.Entities
{
    public class RectangleValidator: IShapeValidator
    {

        public bool ValidateEntry(string entry)
        {
            if (String.IsNullOrEmpty(entry)) throw new ArgumentNullException();

            var regularExpression = new Regex(Pattern);

            var match = regularExpression.Match(entry);

            if (match.Success)
            {
                return true;
            }

            return false;
        }

        public string Pattern
        {
            get
            {
                return @"Rectangle\s+[0-9]+[.[0-9]+]?\s+[0-9]+[.[0-9]+]?\s+[0-9]+[.[0-9]+]?\s+[0-9]+[.[0-9]+]?";
            }
            
        }
    }
}
