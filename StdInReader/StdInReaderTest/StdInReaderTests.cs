using Moq;
using StdInReader;
using System;
using System.IO;
using System.Text;
using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using System.Collections;

namespace StdInReaderTest
{
    public class StdInReaderTests
    {
        [Fact]
        public void StdInReader_ValidFilePath_ReturnsArrayWithData()
        {
            // Arrange
            Environment.SetEnvironmentVariable("INPUT_FILE", "C:\\test.txt");
            int[][] testArray = GetCorrectResult();

            var mockFileManager = new Mock<IFileManager>();
            mockFileManager.Setup(f => f.StreamReader(It.IsAny<string>()))
                .Returns(GetMockStream());

            // Act
            StdInReader.StdInReader reader = new StdInReader.StdInReader(mockFileManager.Object);
            int[][] result = reader.GetInputJaggedArray("INPUT_FILE");


            // Assert
            for (int i = 0; i < result.Length; i++)
            {
                result[i].Should().Equal(testArray[i]);
            }
        }

        private StreamReader GetMockStream()
        {
            string fakeFileContents = "5 3\n" +
                "1 2 50\n" +
                "2 3 50\n" +
                "3 4 50\n";
            byte[] fakeFileBytes = Encoding.UTF8.GetBytes(fakeFileContents);
            MemoryStream fakeMemoryStream = new MemoryStream(fakeFileBytes);
            return new StreamReader(fakeMemoryStream);
        }

        private int[][] GetCorrectResult()
        {
            int[][] result = new int[4][];
            result[0] = new int[2] { 5, 3 };
            result[1] = new int[3] { 1, 2, 50 };
            result[2] = new int[3] { 2, 3, 50 };
            result[3] = new int[3] { 3, 4, 50 };

            return result;
        }
    }
}
