using System;
using System.IO;

namespace MyClass
{
    public class FileProcess
    {
        public bool FileExists(string fileName) 
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("file");
            }

            return File.Exists(fileName);
        }
    }
}
