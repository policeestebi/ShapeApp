using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ShapeApp.Common
{
    public class FileReader : ShapeApp.Common.Interfaces.IFileReader
    {
        #region Constructor

        public FileReader()
        {

        }

        #endregion

        #region Methods

        public String ReadAllLines(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("File does not exist");

            var content = string.Empty;

            using (var reader = new StreamReader(path))
            {
                content = reader.ReadToEnd();
            }

            return content;

        }

        #endregion

        #region Properties

        #endregion

        #region Events

        #endregion

        #region Attributes

        

        #endregion

    }
}
