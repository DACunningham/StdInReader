using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace InputReader
{
    public interface IFileManager
    {
        StreamReader StreamReader(string path);
    }
}
