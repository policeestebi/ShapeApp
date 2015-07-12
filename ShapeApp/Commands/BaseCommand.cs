using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ShapeApp
{
    public abstract class BaseCommand
    {
        public bool IsValid(string entry)
        {
            if (String.IsNullOrEmpty(entry)) throw new ArgumentNullException();

            var regex = new Regex(Pattern);

            var match = regex.Match(entry);

            if (match.Success) return true;

            return false;

        }

        public abstract string ExcuteCommand(string param);

        public abstract string Pattern { get; }

    }
}
