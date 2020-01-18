using System;
using System.IO;

namespace StdInReader
{
    /// <summary>
    /// <c>StdInReader</c> provides static methods to read input files and return their data in arrays
    /// </summary>
    public static class StdInReader
    {
        /// <summary>
        /// <c>GetInputJaggedArray</c> reads the contents of a file using an environment variable for file location
        /// </summary>
        /// <param name="environmentVar">The environment key associated with the file location.</param>
        /// <returns>A jagged array of type int[][] with the content of each line of the file.</returns>
        public static int[][] GetInputJaggedArray(string environmentVar)
        {
            string line = "";
            string file_Path = Environment.GetEnvironmentVariable(environmentVar);
            StreamReader fileReader = new StreamReader(file_Path);

            string firstLine = fileReader.ReadLine();
            string[] firstLineStr = firstLine.Split(' ');
            int numOfOperations = Int32.Parse(firstLineStr[1]);

            int[][] result = new int[numOfOperations][];
            int[] lineInt = new int[3];
            string[] lineStr = new string[3];
            int counter = 1;

            while ((line = fileReader.ReadLine()) != null)
            {
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
