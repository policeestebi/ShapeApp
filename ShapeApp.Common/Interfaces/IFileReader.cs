using System;
namespace ShapeApp.Common.Interfaces
{
    public interface IFileReader
    {
        /// <summary>
        /// Reads all the lines within a file.
        /// </summary>
        /// <param name="path">File's path</param>
        /// <returns>String with all the lines.</returns>
        string ReadAllLines(string path);
    }
}
