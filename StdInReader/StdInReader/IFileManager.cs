using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StdInReader
{
    public interface IFileManager
    {
        StreamReader StreamReader(string path);
    }
}
