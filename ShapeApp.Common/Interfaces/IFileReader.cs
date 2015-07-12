using System;
namespace ShapeApp.Common.Interfaces
{
    public interface IFileReader
    {
        string ReadAllLines(string path);
    }
}
