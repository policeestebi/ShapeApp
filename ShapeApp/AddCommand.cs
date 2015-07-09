using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeApp.BLL;
using ShapeApp.Common;

namespace ShapeApp
{
    public class AddCommand : BaseCommand
    {

        public override string ExcuteCommand(string param)
        {
            throw new NotImplementedException();
        }

        public override string Pattern
        {
            get
            {
                return Constants.COMMAND_ADD + @"\s+";
            }
           
        }
    }
}
