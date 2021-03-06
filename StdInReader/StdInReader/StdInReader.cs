﻿using System;
using System.IO;

namespace InputReader
{
    /// <summary>
    /// <c>InputReader</c> provides methods to read input files and return their data in arrays
    /// </summary>
    public class StdInReader : IStdInReader
    {
        private readonly IFileManager _fileManager;

        public StdInReader(IFileManager fileManager)
        {
            this._fileManager = fileManager;
        }

        /// <summary>
        /// <c>GetInputJaggedArray</c> reads the contents of a file using an environment variable for file location
        /// </summary>
        /// <param name="environmentVar">The environment key associated with the file location.</param>
        /// <returns>A jagged array of type int[][] with the content of each line of the file.</returns>
        public int[][] GetInputJaggedArray(string environmentVar)
        {
            string line = "";
            string file_Path = Environment.GetEnvironmentVariable(environmentVar);

            using (StreamReader fileReader = _fileManager.StreamReader(file_Path))
            {
                string firstLine = fileReader.ReadLine();
                string[] firstLineStr = firstLine.Split(' ');
                int lengthOfArray = Int32.Parse(firstLineStr[0]);
                int numOfOperations = Int32.Parse(firstLineStr[1]);

                int[][] result = new int[numOfOperations + 1][];
                result[0] = new int[2] { lengthOfArray, numOfOperations };

                int counter = 1;

                while ((line = fileReader.ReadLine()) != null)
                {
                    int lineColCount = line.Split(' ').Length;
                    int[] lineInt = new int[lineColCount];
                    string[] lineStr = new string[lineColCount];
                    lineStr = line.Split(' ');

                    for (int i = 0; i < lineStr.Length; i++)
                    {
                        lineInt[i] = Int32.Parse(lineStr[i]);
                    }
                    result[counter] = lineInt;
                    counter++;
                }

                return result;
            }
        }
    }
}
