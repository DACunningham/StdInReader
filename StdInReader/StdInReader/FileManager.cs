﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StdInReader
{
    class FileManager : IFileManager
    {
        public StreamReader StreamReader(string path)
        {
            return new StreamReader(path);
        }
    }
}