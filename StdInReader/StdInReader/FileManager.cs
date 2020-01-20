using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace InputReader
{
    public class FileManager : IFileManager
    {
        public StreamReader StreamReader(string path)
        {
            return new StreamReader(path);
        }
    }
}
